Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Resources.Controls
    Public Class RoundedPanel
        Inherits Panel

        Public Property CornerRadius As Integer = 20

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Using path As New GraphicsPath()
                Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
                Dim radius As Integer = CornerRadius
                If radius > Me.Width \ 2 Then radius = Me.Width \ 2
                If radius > Me.Height \ 2 Then radius = Me.Height \ 2
                path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90)
                path.AddArc(rect.Right - (radius * 2), rect.Y, radius * 2, radius * 2, 270, 90)
                path.AddArc(rect.Right - (radius * 2), rect.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90)
                path.AddArc(rect.X, rect.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90)
                path.CloseFigure()
                Me.Region = New Region(path)
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                Using pen As New Pen(Color.Gray, 1)
                    e.Graphics.DrawPath(pen, path)
                End Using
            End Using
        End Sub
    End Class
End Namespace
