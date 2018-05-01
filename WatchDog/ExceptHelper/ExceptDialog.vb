Public Class ExceptDialog
    Private Shared _ex As Exception
    Private Shared _thisExceptDialog As ExceptDialog

    Private Sub New(ByVal ex As Exception)

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        _ex = ex
    End Sub

    Public Shared Sub ShowExMessage(ByVal ex As Exception)
        _thisExceptDialog = New ExceptDialog(ex)
        _thisExceptDialog.ShowDialog()
    End Sub

    Private Sub ExceptDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitControls()
    End Sub

    Private Sub InitControls()
        _thisExceptDialog.Text = _ex.Message
        txtExceptMessage.EditValue = _ex.ToString
    End Sub

End Class