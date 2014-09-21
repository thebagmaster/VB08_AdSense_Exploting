Imports System.Runtime.InteropServices
Imports System.IO
Public Class icrss
    <Runtime.InteropServices.DllImport("wininet.dll", SetLastError:=True)> Private Shared Function InternetSetOption(ByVal hInternet As IntPtr, ByVal dwOption As Integer, ByVal lpBuffer As IntPtr, ByVal lpdwBufferLength As Integer) As Boolean
    End Function
    Dim rp As Integer
    Dim tmo As Integer
    Dim pxycnt As Integer
    Dim pxy(1111) As String
    Public Function RemoveTag(ByVal InpData As String) As String
        Dim intStart, intEnd As Integer
        Dim strExtract, strInput As String
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
        wb.Navigate("http://thebagmaster.webs.com/")
        tmo = 0
        Return 0
    End Function
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Try
            If wb.Document.Title.Contains("Source!") And wb.Document.Window.Frames.Count >= 3 Then
                rndandnav()
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
        grabProxies()
        rndandnav()
        Timer3.Enabled = True
    End Sub
    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        Me.Dispose()
    End Sub
End Class
