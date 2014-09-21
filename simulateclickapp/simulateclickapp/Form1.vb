Public Class Form1
    Public Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)
    Public Declare Function SetCursorPos Lib "user32" (ByVal x As Long, ByVal y As Long) As Long
    Public Const MOUSEEVENTF_LEFTDOWN = &H2
    Public Const MOUSEEVENTF_LEFTUP = &H4
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
    Public Function GetX() As Long
        Dim n As Point
        n = Cursor.Position
        GetX = n.X
    End Function
    Public Function GetY() As Long
        Dim n As Point
        n = Cursor.Position
        GetY = n.Y
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        Dim r As Point, p As Point
        r.X = 50
        r.Y = 150
        p.Y = GetY()
        p.X = GetX()
        Do While Not p.Equals(r)
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
            SetCursorPos(p.X, p.Y)
            System.Threading.Thread.Sleep(1)
        Loop
        LeftClick()
    End Sub
End Class
