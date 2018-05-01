Imports System.Drawing
Imports System.IO
Imports DevExpress.XtraBars.Alerter
Imports System.Windows.Forms
Imports VoyageHotel

Public Module LogWriter

    ''' <summary>
    ''' Результат сохранения записи лога
    ''' </summary>
    Public Enum LogResult As Integer
        ''' <summary>
        ''' Сохранение прошло успешно
        ''' </summary>
        Success = 0

        ''' <summary>
        ''' Один из членов класса не определен
        ''' </summary>
        PropertyNull = 1

        ''' <summary>
        ''' При попытке записи лога произошла ошибка
        ''' </summary>
        [Error] = 2
    End Enum

    ''' <summary>
    ''' Тип сохраняемого в логе сообщения
    ''' </summary>
    Public Enum LogType As Integer
        ''' <summary>
        ''' Сообщение не имеет типа
        ''' </summary>
        None = 0
        '
        ''' <summary>
        ''' Процесс, связанный с этим сообщением остановлен/прерван
        ''' </summary>
        [Stop] = 100
        '
        ''' <summary>
        ''' Это сообщение об ощике
        ''' </summary>
        [Error] = 110
        '
        ''' <summary>
        ''' Сообщение-вопрос
        ''' </summary>
        Question = 120
        '
        ''' <summary>
        ''' Сообщение, требующее к себе внимание
        ''' </summary>
        Attention = 130
        '
        ''' <summary>
        ''' Важное предупреждение
        ''' </summary>
        Warning = 140
        '
        ''' <summary>
        ''' Информационное сообщение
        ''' </summary>
        Information = 150
    End Enum

    ''' <summary>
    ''' Тип ошибки в системе
    ''' </summary>
    Public Enum ErrorType As Integer

        ''' <summary>
        ''' Неизвестная ошибка
        ''' </summary>
        _Unknown = -1

        ''' <summary>
        ''' Нт ошибок
        ''' </summary>
        OK = 0

        ''' <summary>
        ''' На балансе карты не хватает средств для предоставления услуги
        ''' </summary>
        NoMoney = 1

        ''' <summary>
        ''' Услуга не найдена
        ''' </summary>
        NoService = 2

        ''' <summary>
        ''' Реле не найдено
        ''' </summary>
        NoRelay = 30

    End Enum


    ''' <summary>
    ''' Интерфейс логгера - писателя логов
    ''' </summary>
    Public Interface ILogWriter

        ''' <summary>
        ''' Тип логгируемого сообщения
        ''' </summary>
        ''' <returns></returns>
        Property Type As LogType

        ''' <summary>
        ''' Дата, время сообщения
        ''' </summary>
        ''' <returns></returns>
        Property LogDateTime As Date

        ''' <summary>
        ''' Вывести сообщение на устройство (файл, события системы, сообщение на экране и т.д)
        ''' </summary>
        ''' <returns></returns>
        Function PrintMessage(ByVal Message As String, ByVal Caption As String) As LogResult

        ''' <summary>
        ''' Вывести сообщение на устройство c указанным типом сообщения
        ''' </summary>
        ''' <returns></returns>
        Function PrintMessage(ByVal Message As String, ByVal Caption As String, ByVal Type As LogType) As LogResult

    End Interface

    ''' <summary>
    ''' Логгер - для записи в файл
    ''' </summary>
    Public Class LogWriter_File
        Implements ILogWriter

        Public Property LogDateTime As Date Implements ILogWriter.LogDateTime

        Public Property Type As LogType Implements ILogWriter.Type

        ''' <summary>
        ''' Путь к файлу
        ''' </summary>
        ''' <returns></returns>
        Private Property filePath As String = ""

        Public Sub New(Type As LogType, DateTime As Date, ByVal FilePath As String)
            Me.Type = Type
            Me.LogDateTime = DateTime
            Me.filePath = FilePath
        End Sub

        Public Function PrintMessage(Message As String, Caption As String) As LogResult Implements ILogWriter.PrintMessage
            Return Me.PrintMessage(Message, Caption, Me.Type)
        End Function

        Public Function PrintMessage(Message As String, Caption As String, Type As LogType) As LogResult Implements ILogWriter.PrintMessage
            If filePath = String.Empty Then
                Return LogResult.PropertyNull
            End If
            '
            Try
                If Not File.Exists(filePath) Then
                    Using fs As FileStream = File.Create(filePath)
                        'Просто закрываем поток, дльнейшая работа с файлом пройдет внизу
                        fs.Close()
                    End Using
                End If
                Dim logWriter As New StreamWriter(filePath, True)
                Dim logMessage As String = $"{LogDateTime.ToString}. Тип сообщения:{getTypeToString(Type)}: {Caption}
                                            {Environment.NewLine}{Message}
                                            {Environment.NewLine}"
                logWriter.WriteLine(logMessage)
                logWriter.Close()
                Return LogResult.Success
            Catch ex As Exception
                Return LogResult.Error
            End Try
        End Function

        Private Function getTypeToString(ByVal Type As LogType) As String
            Dim result As String = "Типо сообщения не определен"
            Select Case Type
                Case LogType.None
                    '
                Case LogType.Stop
                    result = "Процесс отменен"
                Case LogType.Error
                    result = "Ошибка"
                Case LogType.Question
                    result = "Вопрос"
                Case LogType.Attention
                    result = "Внимание"
                Case LogType.Warning
                    result = "Предупреждение"
                Case LogType.Information
                    result = "Информация"
                Case Else
                    '
            End Select
            '
            Return result
        End Function

    End Class

    ''' <summary>
    ''' Логгер - для записи Windows-сообщения
    ''' </summary>
    Public Class LogWriter_WindowsEvent
        Implements ILogWriter

        Public Property LogDateTime As Date Implements ILogWriter.LogDateTime

        Public Property Type As LogType Implements ILogWriter.Type

        ''' <summary>
        ''' Логгер в журнал событий Windows
        ''' </summary>
        Private Property EventLogWindows As EventLog

        Public Sub New(Type As LogType, DateTime As Date, EventLogWindows As EventLog)
            Me.Type = Type
            Me.LogDateTime = DateTime
            Me.EventLogWindows = EventLogWindows
        End Sub

        Public Function PrintMessage(Message As String, Caption As String) As LogResult Implements ILogWriter.PrintMessage
            Return Me.PrintMessage(Message, Caption, Me.Type)
        End Function

        Public Function PrintMessage(Message As String, Caption As String, Type As LogType) As LogResult Implements ILogWriter.PrintMessage
            If EventLogWindows Is Nothing Then
                Return LogResult.PropertyNull
            End If
            '
            Try
                EventLogWindows.WriteEntry(Message, getEventLogEntryType(Type))
                Return LogResult.Success
            Catch ex As Exception
                Return LogResult.Error
            End Try
        End Function

        ''' <summary>
        ''' Возвращает тип события журнала Windows
        ''' </summary>
        ''' <returns></returns>
        Public Function getEventLogEntryType(ByVal Type As LogType) As EventLogEntryType
            Dim result As EventLogEntryType
            Select Case Type
                Case LogType.None
                    result = EventLogEntryType.Information
                Case LogType.Stop
                    result = EventLogEntryType.Error
                Case LogType.Error
                    result = EventLogEntryType.Error
                Case LogType.Question
                    result = EventLogEntryType.Information
                Case LogType.Attention
                    result = EventLogEntryType.Warning
                Case LogType.Warning
                    result = EventLogEntryType.Warning
                Case LogType.Information
                    result = EventLogEntryType.Information
                Case Else
                    '
            End Select
            '
            Return result
        End Function

    End Class

    ''' <summary>
    ''' Логгер - для отображения на экране стандартного сообщения
    ''' </summary>
    Public Class LogWriter_MessageBox
        Implements ILogWriter

        Public Property LogDateTime As Date Implements ILogWriter.LogDateTime

        Public Property Type As LogType Implements ILogWriter.Type

        Public Sub New(Type As LogType, DateTime As Date)
            Me.Type = Type
            Me.LogDateTime = DateTime
        End Sub

        Public Function PrintMessage(Message As String, Caption As String) As LogResult Implements ILogWriter.PrintMessage
            Return Me.PrintMessage(Message, Caption, Me.Type)
        End Function

        Public Function PrintMessage(Message As String, Caption As String, Type As LogType) As LogResult Implements ILogWriter.PrintMessage
            MessageBox.Show(Message, Caption, MessageBoxButtons.OK, getMessageBoxIcon(Type))
            Return LogResult.Success
        End Function

        Private Function getMessageBoxIcon(ByVal Type As LogType) As MessageBoxIcon
            Dim result As MessageBoxIcon = MessageBoxIcon.None
            '
            Select Case Type
                Case LogType.None
                    result = MessageBoxIcon.None
                Case LogType.Stop
                    result = MessageBoxIcon.Stop
                Case LogType.Error
                    result = MessageBoxIcon.Error
                Case LogType.Question
                    result = MessageBoxIcon.Question
                Case LogType.Attention
                    result = MessageBoxIcon.Exclamation
                Case LogType.Warning
                    result = MessageBoxIcon.Warning
                Case LogType.Information
                    result = MessageBoxIcon.Information
                Case Else
                    '
            End Select
            '
            Return result
        End Function

    End Class



End Module
