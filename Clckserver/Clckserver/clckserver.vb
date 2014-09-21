Public Class clckserver
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Interval = Int(90000)
        Shell("c:\windows\crsclck.exe")
    End Sub
    Private Sub clckserver_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Shell("c:\windows\clckserver.exe")
    End Sub
    Private Sub clckserver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
    End Sub
End Class
