Imports System.IO
Public Class ProxyR
    Dim pxy(2000) As String
    Dim pxycnt As Integer
    Private Sub ProxyR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Function getProxies()
        pxycnt = 0
        Dim objWriter As New System.IO.StreamReader("C:\proxies.txt")
        Do
            pxy(pxycnt) = objWriter.ReadLine()
            pxycnt = pxycnt + 1
        Loop Until (objWriter.EndOfStream)
        objWriter.Close()
        Return 0
    End Function
    Function sortProxies()
        Dim b As Boolean = True
        Dim ts As String
        Do Until Not b
            b = False
            For t As Integer = 0 To pxycnt - 2
                If pxy(t + 1) < pxy(t) Then
                    ts = pxy(t)
                    pxy(t) = pxy(t + 1)
                    pxy(t + 1) = ts
                    b = True
                End If
            Next
        Loop
        For t As Integer = 0 To pxycnt - 3
            TextBox1.Text = TextBox1.Text + vbCrLf + pxy(t)
        Next
        Return 0
    End Function
End Class
