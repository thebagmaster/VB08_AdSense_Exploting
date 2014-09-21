Imports System.Runtime.InteropServices
Public Class Spoof
    <DllImport("urlmon.dll")> Public Shared Function UrlMkSetSessionOption(ByVal dwOption As Integer, ByVal pBuffer As String, ByVal dwBufferLength As Integer, ByVal dwReserved As Integer) As Integer
    End Function
    Private Sub ChangeUserAgent(ByVal Agent As String)
        UrlMkSetSessionOption(&H10000001, Agent, Agent.Length, 0)
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ChangeUserAgent("Penis")
            wb.Navigate(TextBox1.Text)
        End If
    End Sub
End Class
