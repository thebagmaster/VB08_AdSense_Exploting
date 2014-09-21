Imports System.Runtime.InteropServices
Public Class crsclck
    <Runtime.InteropServices.DllImport("wininet.dll", SetLastError:=True)> Private Shared Function InternetSetOption(ByVal hInternet As IntPtr, ByVal dwOption As Integer, ByVal lpBuffer As IntPtr, ByVal lpdwBufferLength As Integer) As Boolean
    End Function
    Dim rp As Integer
    Dim tmo As Integer
    Dim pxycnt As Integer
    Dim pxy(1111) As String
    Dim url As String
    Dim t2 As Integer
    Dim intStart, intEnd As Integer
    Dim strExtract, strInput As String
    Public Function RemoveTag(ByVal InpData As String) As String
        strInput = InpData
        While InStr(strInput, "<") <> 0
            intStart = InStr(strInput, "<")
            intEnd = InStr(strInput, ">")
            If intStart > 1 Then
                strExtract = Mid(strInput, 1, intStart - 1) & Mid(strInput, intEnd + 1, Len(strInput) - intEnd)
            Else
                strExtract = Mid(strInput, intEnd + 1, Len(strInput) - intEnd)
            End If
            strInput = strExtract
        End While
        Return strInput
    End Function
    Public Structure Struct_INTERNET_PROXY_INFO
        Public dwAccessType As Integer
        Public proxy As IntPtr
        Public proxyBypass As IntPtr
    End Structure
    Private Sub RefreshIESettings(ByVal strProxy As String)
        Const INTERNET_OPTION_PROXY As Integer = 38
        Const INTERNET_OPEN_TYPE_PROXY As Integer = 3

        Dim struct_IPI As Struct_INTERNET_PROXY_INFO

        ' Filling in structure
        struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY
        struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy)
        struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local")

        ' Allocating memory
        Dim intptrStruct As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI))

        ' Converting structure to IntPtr
        Marshal.StructureToPtr(struct_IPI, intptrStruct, True)

        Dim iReturn As Boolean = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, System.Runtime.InteropServices.Marshal.SizeOf(struct_IPI))
    End Sub
    Private Function grabProxies()
        pxycnt = 0
        Dim objWriter As New System.IO.StreamReader("C:\proxies.txt")
        Do
            pxy(pxycnt) = objWriter.ReadLine()
            pxycnt = pxycnt + 1
        Loop Until (objWriter.EndOfStream)
        objWriter.Close()
        Return 0
    End Function
    Function rndandnav()
        rp = Int(Rnd() * pxycnt)
        RefreshIESettings(pxy(rp))
        wb.Navigate(url)
        tmo = 0
        Return 0
    End Function
    Function clickrand()
        Dim pas As Point, r As Point, p As Point
        Dim i As HtmlElement
        t2 = Int(Rnd() * 3.9)
        Try
            i = wb.Document.Body.GetElementsByTagName("iframe").Item(t2)
            i.ScrollIntoView(True)
        Catch ex As Exception
        End Try
        t = 0
        pas = Point.Empty
        getcolorcoords(pas)
        r.x = pas.X
        r.y = pas.Y
        p.X = Int(Rnd() * Me.Width)
        p.Y = Int(Rnd() * Me.Height)
        Cursor.Position = p
        Do While Not (p.X = r.X And p.Y = r.Y)
            If p.Y < r.Y Then
                p.Y = p.Y + 1
            End If
            If p.Y > r.Y Then
                p.Y = p.Y - 1
            End If
            If p.X < r.X Then
                p.X = p.X + 1
            End If
            If p.X > r.X Then
                p.X = p.X - 1
            End If
            Cursor.Position = p
            System.Threading.Thread.Sleep(1)
        Loop
        Select Case Rnd()
            Case Is < 0.3
                LeftClick()
            Case Is > 0.6
                LeftClick()
                LeftClick()
            Case Else
                LeftClick()
                LeftClick()
                LeftClick()
        End Select
        Timer5.Enabled = False
        Timer4.Enabled = True
        Return 0
    End Function
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Try
            If wb.Document.Title.Contains("Source!") And wb.Document.Window.Frames.Count >= 3 Then
                tmo = 0
                Timer5.Interval = Int(50000 * Rnd())
                Timer3.Enabled = False
                Timer5.Enabled = True
                Exit Sub
            ElseIf wb.Document.Title.Contains("Source!") And tmo < 8 Then
                tmo = tmo + 1
                Exit Sub
            Else
                rndandnav()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Crsserver_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Timer3.Enabled = False
        wb.Dispose()
    End Sub
    Private Sub icrss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        Select Case Rnd()
            Case Is < 0.2
                url = "http://thebagmaster.webs.com/"
                Exit Select
            Case Is < 0.4
                url = "http://thebagmaster.atspace.com/"
                Exit Select
            Case Is < 0.6
                url = "http://thebagmaster.t35.com/"
                Exit Select
            Case Is < 0.8
                url = "http://thebagmaster.110MB.com/"
                Exit Select
            Case Else
                url = "http://thebagmaster.byethost6.com/"
        End Select
        Dim runcl As Boolean, runie As Boolean
        runcl = False
        runie = False
        Dim a As Integer
        a = 0
        For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses
            If proc.ProcessName.ToLower = "crsclck" And a >= 1 Then
                proc.Kill()
            ElseIf proc.ProcessName.ToLower = "crsclck" And a = 0 Then
                a = a + 1
            End If
            If proc.ProcessName = "iexplore" Then
                proc.Kill()
            End If
        Next
        grabProxies()
        rndandnav()
        Timer3.Enabled = True
    End Sub
    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        If t > 120 Then
            Me.Dispose()
        Else
            Dim d As Point
            Select Case Rnd()
                Case Is < 0.3
                    d.X = 10
                Case Is > 0.6
                    d.X = -10
                Case Else
                    d.X = 0
            End Select
            Select Case Rnd()
                Case Is < 0.3
                    d.Y = 10
                Case Is > 0.6
                    d.Y = -10
                Case Else
                    d.Y = 0
            End Select
            Dim tp As Point
            tp.X = Cursor.Position.X + d.X
            tp.Y = Cursor.Position.Y + d.Y
            Cursor.Position = tp
            t = t + 1
        End If
    End Sub
    Function click100()
        Me.Width = 50
        Me.Height = 50
        t2 = Int(Rnd() * 3.9)
        Try
            wb.Document.Body.GetElementsByTagName("iframe").Item(t2).ScrollIntoView(True)
        Catch ex As Exception
        End Try
        Return 0
    End Function
    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        clickrand()
    End Sub
End Class
