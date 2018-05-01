<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WatchDogForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WatchDogForm))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnCheckPort = New System.Windows.Forms.Button()
        Me.btnCheckPortListeners = New System.Windows.Forms.Button()
        Me.listPortListeners = New System.Windows.Forms.ListBox()
        Me.txtPortAuto = New System.Windows.Forms.TextBox()
        Me.chkUseControl = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRunProcess = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPortmanual = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.chkStartWithWindows = New System.Windows.Forms.CheckBox()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemShowMainForm = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.listLogs = New System.Windows.Forms.ListBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'btnCheckPort
        '
        Me.btnCheckPort.Location = New System.Drawing.Point(216, 20)
        Me.btnCheckPort.Name = "btnCheckPort"
        Me.btnCheckPort.Size = New System.Drawing.Size(193, 23)
        Me.btnCheckPort.TabIndex = 1
        Me.btnCheckPort.Text = "Проверить, занят ли порт"
        Me.btnCheckPort.UseVisualStyleBackColor = True
        '
        'btnCheckPortListeners
        '
        Me.btnCheckPortListeners.Location = New System.Drawing.Point(532, 276)
        Me.btnCheckPortListeners.Name = "btnCheckPortListeners"
        Me.btnCheckPortListeners.Size = New System.Drawing.Size(168, 23)
        Me.btnCheckPortListeners.TabIndex = 2
        Me.btnCheckPortListeners.Text = "Прочитать открытые порты"
        Me.btnCheckPortListeners.UseVisualStyleBackColor = True
        '
        'listPortListeners
        '
        Me.listPortListeners.FormattingEnabled = True
        Me.listPortListeners.Location = New System.Drawing.Point(9, 19)
        Me.listPortListeners.Name = "listPortListeners"
        Me.listPortListeners.Size = New System.Drawing.Size(691, 251)
        Me.listPortListeners.TabIndex = 3
        '
        'txtPortAuto
        '
        Me.txtPortAuto.Location = New System.Drawing.Point(278, 16)
        Me.txtPortAuto.Name = "txtPortAuto"
        Me.txtPortAuto.Size = New System.Drawing.Size(70, 20)
        Me.txtPortAuto.TabIndex = 4
        Me.txtPortAuto.Text = "666"
        '
        'chkUseControl
        '
        Me.chkUseControl.AutoSize = True
        Me.chkUseControl.Location = New System.Drawing.Point(9, 19)
        Me.chkUseControl.Name = "chkUseControl"
        Me.chkUseControl.Size = New System.Drawing.Size(263, 17)
        Me.chkUseControl.TabIndex = 5
        Me.chkUseControl.Text = "Перезапускать процесс, если указанный порт"
        Me.chkUseControl.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Порт для проверки:"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(177, 55)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(429, 20)
        Me.txtFileName.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Перезапускаемый процесс:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnRunProcess)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chkUseControl)
        Me.GroupBox1.Controls.Add(Me.txtPortAuto)
        Me.GroupBox1.Controls.Add(Me.txtFileName)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(706, 87)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Автоматический контроль работы приложения"
        '
        'btnRunProcess
        '
        Me.btnRunProcess.Image = Global.WatchDog.My.Resources.Resources.bullet_arrow_right
        Me.btnRunProcess.Location = New System.Drawing.Point(656, 53)
        Me.btnRunProcess.Name = "btnRunProcess"
        Me.btnRunProcess.Size = New System.Drawing.Size(28, 23)
        Me.btnRunProcess.TabIndex = 11
        Me.btnRunProcess.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(622, 53)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 23)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(354, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "свободен"
        '
        'txtPortmanual
        '
        Me.txtPortmanual.Location = New System.Drawing.Point(140, 22)
        Me.txtPortmanual.Name = "txtPortmanual"
        Me.txtPortmanual.Size = New System.Drawing.Size(70, 20)
        Me.txtPortmanual.TabIndex = 10
        Me.txtPortmanual.Text = "666"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCheckPort)
        Me.GroupBox2.Controls.Add(Me.txtPortmanual)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(706, 58)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ручная проверка порта"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.listPortListeners)
        Me.GroupBox3.Controls.Add(Me.btnCheckPortListeners)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 165)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(706, 307)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Список открытых для прослушивания портов"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(554, 527)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(168, 23)
        Me.btnExit.TabIndex = 13
        Me.btnExit.Text = "Выход из программы"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'chkStartWithWindows
        '
        Me.chkStartWithWindows.AutoSize = True
        Me.chkStartWithWindows.Location = New System.Drawing.Point(31, 529)
        Me.chkStartWithWindows.Name = "chkStartWithWindows"
        Me.chkStartWithWindows.Size = New System.Drawing.Size(243, 17)
        Me.chkStartWithWindows.TabIndex = 14
        Me.chkStartWithWindows.Text = "Запускать программу при старте Windows"
        Me.chkStartWithWindows.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.Location = New System.Drawing.Point(392, 529)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(156, 23)
        Me.btnAbout.TabIndex = 15
        Me.btnAbout.Text = "О программе..."
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemShowMainForm, Me.itemExit})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 48)
        '
        'itemShowMainForm
        '
        Me.itemShowMainForm.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.itemShowMainForm.Name = "itemShowMainForm"
        Me.itemShowMainForm.Size = New System.Drawing.Size(124, 22)
        Me.itemShowMainForm.Text = "Открыть"
        '
        'itemExit
        '
        Me.itemExit.Name = "itemExit"
        Me.itemExit.Size = New System.Drawing.Size(124, 22)
        Me.itemExit.Text = "Выход..."
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipText = "Watch dog по-прежнему запущен. Щелкните дважды на иконку, что бы открыть главное о" &
    "кно."
        Me.NotifyIcon1.BalloonTipTitle = "Внимание!"
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(740, 509)
        Me.TabControl1.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(732, 483)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Управление"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.listLogs)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(732, 483)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Логи"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'listLogs
        '
        Me.listLogs.FormattingEnabled = True
        Me.listLogs.HorizontalScrollbar = True
        Me.listLogs.Location = New System.Drawing.Point(6, 6)
        Me.listLogs.Name = "listLogs"
        Me.listLogs.Size = New System.Drawing.Size(720, 459)
        Me.listLogs.TabIndex = 0
        '
        'WatchDogForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 570)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.chkStartWithWindows)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "WatchDogForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Watch dog"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnCheckPort As Button
    Friend WithEvents btnCheckPortListeners As Button
    Friend WithEvents listPortListeners As ListBox
    Friend WithEvents txtPortAuto As TextBox
    Friend WithEvents chkUseControl As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPortmanual As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnExit As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents chkStartWithWindows As CheckBox
    Friend WithEvents btnAbout As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents itemShowMainForm As ToolStripMenuItem
    Friend WithEvents itemExit As ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents btnRunProcess As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents listLogs As ListBox
End Class
