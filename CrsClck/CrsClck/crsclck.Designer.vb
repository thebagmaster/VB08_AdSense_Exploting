<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crsclck
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.wb = New System.Windows.Forms.WebBrowser
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer5 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Timer3
        '
        Me.Timer3.Interval = 2000
        '
        'wb
        '
        Me.wb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wb.Location = New System.Drawing.Point(0, 0)
        Me.wb.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wb.Name = "wb"
        Me.wb.ScriptErrorsSuppressed = True
        Me.wb.ScrollBarsEnabled = False
        Me.wb.Size = New System.Drawing.Size(768, 600)
        Me.wb.TabIndex = 0
        '
        'Timer4
        '
        Me.Timer4.Interval = 250
        '
        'Timer5
        '
        Me.Timer5.Interval = 60000
        '
        'crsclck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 600)
        Me.Controls.Add(Me.wb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "crsclck"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "crsclck"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents wb As System.Windows.Forms.WebBrowser
    Friend WithEvents Timer4 As System.Windows.Forms.Timer
    Friend WithEvents Timer5 As System.Windows.Forms.Timer

End Class
