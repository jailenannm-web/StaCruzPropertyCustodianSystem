Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Resources.Controls
    Public Class RoundedButton
        Inherits Button

        Public Property CornerRadius As Integer = 15

        Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
            Dim path As New GraphicsPath()
            path.StartFigure()
            path.AddArc(New Rectangle(0, 0, CornerRadius, CornerRadius), 180, 90)
            path.AddLine(CornerRadius, 0, Width - CornerRadius, 0)
            path.AddArc(New Rectangle(Width - CornerRadius, 0, CornerRadius, CornerRadius), -90, 90)
            path.AddLine(Width, CornerRadius, Width, Height - CornerRadius)
            path.AddArc(New Rectangle(Width - CornerRadius, Height - CornerRadius, CornerRadius, CornerRadius), 0, 90)
            path.AddLine(Width - CornerRadius, Height, CornerRadius, Height)
            path.AddArc(New Rectangle(0, Height - CornerRadius, CornerRadius, CornerRadius), 90, 90)
            path.CloseFigure()
            Me.Region = New Region(path)
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            MyBase.OnPaint(pevent)
        End Sub
    End Class
End Namespace
