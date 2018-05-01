Imports System.IO

''' <summary>
''' Помощник, работающий с исключениями
''' </summary>
''' <remarks>Основная задача: логгирование необработанных исключений, возникающих в системе</remarks>
Public Class ExceptHelper

#Region "FilesNDirs"
    Public Const DIRNAME_ERRORLOGS As String = "errors"
    Public Const FILENAME_VOYAGE_UPDARER As String = "VoyageUpdater.exe"
    Public Const FILENAME_ERRORLOG As String = "ErrorLog.txt"
#End Region

    ''' <summary>
    ''' Запись сообщения об исключении в файл
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <remarks>используется 1 файл на каждый день</remarks>
    Public Shared Sub WriteToLog(ByVal ex As Exception)
        'If Not Directory.Exists(DIRNAME_ERRORLOGS) Then
        '    Directory.CreateDirectory(DIRNAME_ERRORLOGS)
        'End If
        ''
        Try
            '    Dim FileName As String = String.Format("ErrorLog-{0}.txt", Now.ToString("dd-MM.yyyy"))
            '    Dim logWriter As New StreamWriter(Path.Combine(DIRNAME_ERRORLOGS, FileName), True)
            'Dim logMessage As String = String.Format("{0}: {1}{2}{3}{4}", Now.ToString, ex.Message,
            '                                         Environment.NewLine, ex.ToString,
            '                                         Environment.NewLine)
            '    logWriter.WriteLine(logMessage)
            '    logWriter.Close()
            Dim fileName As String = String.Format("ErrorLog-{0}.txt", Now.ToString("dd-MM.yyyy"))
            Dim filePath As String = System.IO.Path.Combine(DIRNAME_ERRORLOGS, fileName)
            Dim fileLogger As LogWriter_File = New LogWriter_File(LogType.None, Now, filePath)
            If fileLogger.PrintMessage(ex.ToString, ex.Message) = LogResult.Error Then
                MessageBox.Show($"При попытке сохранить исключение в файл лога произошла ошибка.",
                                "Внимание!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                'MainForm.AddLogString($"При попытке сохранить исключение в файл лога произошла ошибка.")
            End If
        Catch ex1 As Exception
            'MainForm.AddLogString($"Ошибка помощника исключений. Текст ошибки: {ex1.ToString}")
            MessageBox.Show($"Ошибка помощника исключений. Текст ошибки: {ex1.ToString}",
                            "Внимание!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Покажем пользователю сообщение об ошибке
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    Public Shared Sub ShowError(ByVal ex As Exception)
        'ExceptDialog.ShowExMessage(ex)
        'MainForm.AddLogString(ex.ToString)
    End Sub

End Class
