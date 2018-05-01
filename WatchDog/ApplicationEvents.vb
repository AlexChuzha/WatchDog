Imports System.Globalization
Imports System.Threading.Thread

Namespace My
    ' Для MyApplication имеются следующие события:
    ' Startup: возникает при запуске приложения перед созданием начальной формы.
    ' Shutdown: возникает после закрытия всех форм приложения.  Это событие не происходит при прерывании работы приложения из-за ошибки.
    ' UnhandledException: возникает, если в приложение обнаруживает необработанное исключение.
    ' StartupNextInstance: возникает при запуске приложения, допускающего одновременное выполнение только одной копии, если это приложение уже активно. 
    ' NetworkAvailabilityChanged: возникает при изменении состояния подключения: при подключении или отключении.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            ' The following line provides localization for data formats. 
            CurrentThread.CurrentCulture = New CultureInfo("ru-RU")

            ' The following line provides localization for the application's user interface. 
            CurrentThread.CurrentUICulture = New CultureInfo("ru-RU")
            '
            'Определение точки как разделителя дробной части
            Dim VoyageCulture As New CultureInfo(CurrentThread.CurrentCulture.Name)
            VoyageCulture.NumberFormat.NumberDecimalSeparator = "."
            CurrentThread.CurrentCulture = VoyageCulture
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            e.ExitApplication = False
            'Все необработанные исключения записываются в файл лога - 1 файл на каждый день
            ExceptHelper.WriteToLog(e.Exception)
            ExceptHelper.ShowError(e.Exception)

        End Sub

    End Class
End Namespace
