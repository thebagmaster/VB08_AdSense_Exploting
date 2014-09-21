Module click
    Public Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)
    Public Declare Function SetCursorPos Lib "user32" (ByVal x As Long, ByVal y As Long) As Long
    Public Const MOUSEEVENTF_LEFTDOWN = &H2
    Public Const MOUSEEVENTF_LEFTUP = &H4
    Public Const MOUSEEVENTF_MIDDLEDOWN = &H20
    Public Const MOUSEEVENTF_MIDDLEUP = &H40
    Public Const MOUSEEVENTF_RIGHTDOWN = &H8
    Public Const MOUSEEVENTF_RIGHTUP = &H10
    Public Const MOUSEEVENTF_MOVE = &H1
    Public Declare Function GetPixel Lib "gdi32.dll" (ByVal hdc As Integer, ByVal x As Integer, ByVal y As Integer) As Integer
    Public Declare Function GetWindowDC Lib "user32.dll" (ByVal hwnd As Integer) As Integer
    Public Declare Function GetDesktopWindow Lib "user32.dll" () As Integer
    Public t As Integer
    Public Sub LeftClick()
        LeftDown()
        LeftUp()
    End Sub
    Public Sub LeftDown()
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
    End Sub
    Public Sub LeftUp()
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
    End Sub
    Public Sub MiddleClick()
        MiddleDown()
        MiddleUp()
    End Sub
    Public Sub MiddleDown()
        mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0)
    End Sub
    Public Sub MiddleUp()
        mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0)
    End Sub
    Public Sub RightClick()
        RightDown()
        RightUp()
    End Sub
    Public Sub RightDown()
        mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0)
    End Sub
    Public Sub RightUp()
        mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0)
    End Sub
    Public Function getcolorcoords(ByRef pos As Point)
        pos = Point.Empty
        Dim winDc = GetWindowDC(GetDesktopWindow)
        Dim d As Point
        Dim r As Point
        d = Point.Empty
        r = Point.Empty
        Dim color
        Select Case Rnd()
            Case Is < 0.3
                d.X = 1
            Case Is > 0.6
                d.X = -1
            Case Else
                d.X = 0
        End Select
        Select Case Rnd()
            Case Is < 0.3
                d.Y = 1
            Case Is > 0.6
                d.Y = -1
            Case Else
                d.Y = 0
        End Select
        If d.X = 0 And d.Y = 0 Then
            d.X = 1
            d.Y = -1
        End If
        r.X = Int(Rnd() * crsclck.Width)
        r.Y = Int(Rnd() * crsclck.Height)
        color = GetPixel(winDc, r.X, r.Y).ToString
        Do Until (color = 16711680)
            color = GetPixel(winDc, r.X, r.Y).ToString
            If r.X <= 0 Or r.X >= crsclck.Width Or r.Y <= 0 Or r.Y >= crsclck.Height Then
                If t < 6 Then
                    t = t + 1
                    getcolorcoords(pos)
                    Return 1
                    Exit Function
                Else
                    crsclck.click100()
                    pos.X = Int(Rnd() * 50)
                    pos.Y = Int(Rnd() * 50)
                    Return 2
                    Exit Function
                End If
            End If
            r.X = r.X + d.X
            r.Y = r.Y + d.Y
            Application.DoEvents()
        Loop
        pos.X = r.X
        pos.Y = r.Y
        Return 0
    End Function
End Module
