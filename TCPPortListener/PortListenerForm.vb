Imports System.Net
Imports System.Net.Sockets

Public Class PortListenerForm

    Private tcpListener As TcpListener = Nothing

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        initListener()
    End Sub

    Private Sub initListener()
        Dim thisPort As Integer = TextBox1.Text

        If tcpListener Is Nothing Then
            Button1.Text = $"Прекратить слушать порт {thisPort}"
            '
            'Dim clientPort As Integer = thisPort
            'Dim ipAddress As IPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList(0)
            'Dim ipLocalEndPoint As IPEndPoint = New IPEndPoint(ipAddress, clientPort)
            'Dim clientSocket As TcpClient = New TcpClient(ipLocalEndPoint)
            'clientSocket.Connect("127.0.0.1", clientPort)


            Dim ipAddress As IPAddress = Dns.GetHostEntry("localhost").AddressList(0)
            Try
                tcpListener = New TcpListener(ipAddress, thisPort)
                tcpListener.Start()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Ошибка!")
            End Try
        Else
            Button1.Text = "Начать слушать порт"
            tcpListener.Stop()
            tcpListener = Nothing
        End If

    End Sub


End Class
