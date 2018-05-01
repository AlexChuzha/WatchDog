Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports Microsoft.Win32

Public Class WatchDogForm

    Private tcpListener As TcpListener = Nothing

    Private formLoaded As Boolean = False

    Dim _fileNameSettings As String = "Settings.txt"
    Private Property fileNameSettings As String
        Get
            Return _fileNameSettings
        End Get
        Set(value As String)
            _fileNameSettings = value
        End Set
    End Property

    Dim fileNameLog As String = "Log.txt"

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        readTextFile()
        '
        'Покажем, записана ли программа в автозапуск
        Dim rk As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", True)
        Dim result = rk.GetValue(Application.ProductName)
        chkStartWithWindows.Checked = (result IsNot Nothing)
        '
        chkUseControl.Checked = True
        '
        Dim startInfo As String = ""
        If txtFileName.Text = "" OrElse
        Not File.Exists(txtFileName.Text) Then
            startInfo = "Система запущена, однако процесс для автозапуска не указан!"
        Else
            startInfo = "Система запущена, процесс для автозапуска определен."
        End If
        writeLogFile(startInfo)
        '
        formLoaded = True
    End Sub

    ''' <summary>
    ''' Проверяем, есть ли запущенные процессы
    ''' </summary>
    ''' <param name="thisFileName"></param>
    ''' <returns></returns>
    Private Function checkProcessExist(ByVal thisFileName As String) As Boolean
        Dim processes() As Process = Process.GetProcessesByName(thisFileName)
        Return processes.Length > 0
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCheckPort.Click
        If checkPortIsFree(txtPortmanual.Text) Then
            MsgBox("Порт СВОБОДЕН!")
        Else
            MsgBox("Порт прослушивается!")
        End If
    End Sub

    ''' <summary>
    ''' Проверка, прослушивают ли порт
    ''' </summary>
    ''' <returns></returns>
    Private Function checkPortIsFree(ByVal Port As Integer) As Boolean
        'True = порт свободен, его не прослушивают
        Dim isAvailable As Boolean = True
        Dim IPGlobalProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipEndPoints() As IPEndPoint = IPGlobalProperties.GetActiveTcpListeners
        For Each endPoint As IPEndPoint In ipEndPoints
            If endPoint.Port = Port Then
                isAvailable = False
                Exit For
            End If
        Next
        '
        Return isAvailable
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCheckPortListeners.Click
        listPortListeners.Items.Clear()
        Dim IPGlobalProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipEndPoints() As IPEndPoint = IPGlobalProperties.GetActiveTcpListeners
        For Each endPoint As IPEndPoint In ipEndPoints
            Dim dataStr As String = $"{endPoint.Address} * {endPoint.AddressFamily} * {endPoint.Port}"
            listPortListeners.Items.Add(dataStr)
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MessageBox.Show("Вы уверены, что хотите полностью закрыть программу? Контроль портов производиться не будет!",
                           "Внимание!",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning) = DialogResult.Yes Then
            Application.ExitThread()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        selectProcessForControl()
    End Sub

    Private Function selectProcessForControl(Optional ShowMessage As Boolean = False) As Boolean
        'If chkUseControl.Checked Then
        '    chkUseControl.Checked = False
        'End If
        If ShowMessage Then
            If MessageBox.Show("Для начала необходимо указать, какой процесс должна запускать система при возникновении соответствующих условий" & Environment.NewLine & "Продолжить?",
                            "Внимание!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information) = DialogResult.No Then
                Return False
            End If
        End If

        OpenFileDialog1.InitialDirectory = "c:\"
        OpenFileDialog1.Filter = "Исполнимые файлы (*.exe)|*.exe"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtFileName.Text = OpenFileDialog1.FileName
            saveTextFile()
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Сохраняем при успешном входе в систему логи в файл
    ''' </summary>
    Private Sub saveTextFile()
        If Not File.Exists(fileNameSettings) Then
            Dim FileStr As FileStream = File.Create(fileNameSettings)
            FileStr.Close()
        End If
        '
        Dim textArray() As String = New String() {txtFileName.Text, txtPortAuto.Text}
        File.WriteAllLines(fileNameSettings, textArray)
    End Sub

    ''' <summary>
    ''' Читаем список ранее успежно залогинившихся
    ''' </summary>
    Private Sub readTextFile()
        If Not File.Exists(fileNameSettings) Then
            Exit Sub
        End If
        '
        Dim textArray() As String = File.ReadAllLines(fileNameSettings)
        If textArray.Length > 1 Then
            txtFileName.Text = textArray(0)
            txtPortAuto.Text = Val(textArray(1))
        End If
    End Sub

    Private Sub chkUseControl_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseControl.CheckedChanged
        If chkUseControl.Checked Then
            Const SHOW_MESSAGE_BEFORE_ADD_PROCESS As Boolean = True
            If txtFileName.Text = "" Then
                If selectProcessForControl(SHOW_MESSAGE_BEFORE_ADD_PROCESS) Then
                    startProcessControl()
                    Exit Sub
                End If
            Else
                If Not File.Exists(txtFileName.Text) Then
                    If selectProcessForControl(SHOW_MESSAGE_BEFORE_ADD_PROCESS) Then
                        startProcessControl()
                        Exit Sub
                    End If
                End If
            End If
            startProcessControl()
        Else
            stopProcessControl()
        End If
    End Sub

    Private Sub startProcessControl()
        Timer1.Interval = 120000
        Timer1.Enabled = True
    End Sub

    Private Sub stopProcessControl()
        Timer1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Проверка, прослушивают ли порт
        If checkPortIsFree(Val(txtPortAuto.Text)) Then
            Try
                'Порт никто не прослушивает - нужно запустить указанный процесс
                runProcess(RunProcessType.AutoRun)
                Timer1.Interval = 10000
            Catch ex As Exception
                '
            End Try
        End If
    End Sub

    Private Sub chkStartWithWindows_CheckedChanged(sender As Object, e As EventArgs) Handles chkStartWithWindows.CheckedChanged
        setRunOnWindowsStart(chkStartWithWindows.Checked)
    End Sub

    Private Sub setRunOnWindowsStart(ByVal RunOnWindowsStart As Boolean)
        Try
            Dim rk As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", True)
            If RunOnWindowsStart Then
                rk.SetValue(Application.ProductName, Application.ExecutablePath)
            Else
                rk.DeleteValue(Application.ProductName, False)
            End If
        Catch ex As Exception
            MessageBox.Show($"При попытке создать запись в реестре произошла ошибка. Текст ошибки: {ex.Message}")
        End Try
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Dim aboutDialog As New AboutDialog
        aboutDialog.ShowDialog()
    End Sub

    Private Sub itemShowMainForm_Click(sender As Object, e As EventArgs) Handles itemShowMainForm.Click
        showProgram()
    End Sub

    Private Sub itemExit_Click(sender As Object, e As EventArgs) Handles itemExit.Click
        ExitForm()
    End Sub

    Private Sub showProgram()
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Function ExitForm() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Вы уверены, что хотите выйти из программы? Внимание, работа Watch dog будет прекращена!",
                                                       "Внимание!",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Application.ExitThread()
        End If
        '
        Return result
    End Function

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        hideProgram()
        e.Cancel = True
    End Sub

    Private Sub hideProgram()
        NotifyIcon1.ShowBalloonTip(500)
        Me.Hide()
    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        showProgram()
    End Sub

    Private Sub btnRunProcess_Click(sender As Object, e As EventArgs) Handles btnRunProcess.Click
        runProcess(RunProcessType.ManualRun)
    End Sub

    ''' <summary>
    ''' Тип запуска процесса
    ''' </summary>
    Private Enum RunProcessType As Integer

        ''' <summary>
        ''' Не определено
        ''' </summary>
        _Unknown = -1

        ''' <summary>
        ''' Система запустила автоматически
        ''' </summary>
        AutoRun = 1

        ''' <summary>
        ''' Пользователь запустил вручную
        ''' </summary>
        ManualRun = 2

    End Enum

    Private Sub runProcess(ByVal RunProcessType As RunProcessType)
        Dim processName As String = txtFileName.Text
        Const SHOW_MESSAGE_BEFORE_ADD_PROCESS As Boolean = True
        '
        If processName = "" Then
            If selectProcessForControl(SHOW_MESSAGE_BEFORE_ADD_PROCESS) Then
                runProcess(RunProcessType)
                Exit Sub
            End If
        Else
            If Not File.Exists(processName) Then
                If selectProcessForControl(SHOW_MESSAGE_BEFORE_ADD_PROCESS) Then
                    runProcess(RunProcessType)
                    Exit Sub
                End If
            End If
        End If
        '
        Process.Start(processName)
        writeLogFile(RunProcessType, processName)
    End Sub

    Private Sub writeLogFile(ByVal Text As String)
        If Not File.Exists(fileNameLog) Then
            Dim FileStr As FileStream = File.Create(fileNameLog)
            FileStr.Close()
        End If
        '
        Dim eventStr As String = $"### {Now.ToString}: {Text}"
        Dim textArray() As String = New String() {eventStr}
        File.AppendAllLines(fileNameLog, textArray)
        '
        listLogs.Items.Add(eventStr)
    End Sub

    Private Sub writeLogFile(ByVal RunProcessType As RunProcessType, ByVal RunProcessName As String)
        Dim runTypeText As String = IIf(RunProcessType = RunProcessType.AutoRun, "Процесс запущен системой", "Пользователь сам запустил процесс")
        Dim eventStr As String = $"[ Запуск процесса {RunProcessName}] [{runTypeText}]"
        writeLogFile(eventStr)
    End Sub

    Private Sub txtPortAuto_TextChanged(sender As Object, e As EventArgs) Handles txtPortAuto.TextChanged
        If Not formLoaded Then
            Exit Sub
        End If
        '
        saveTextFile()
    End Sub
End Class
