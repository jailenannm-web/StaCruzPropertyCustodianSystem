Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Resources.Controls
    <ToolboxItem(True)>
    <DesignerCategory("Code")>
    Public Class RoundedButton
        Inherits Button

        Private _cornerRadius As Integer = 15
        
        <Category("Appearance")>
        <Description("The radius of the button corners")>
        <DefaultValue(15)>
        Public Property CornerRadius As Integer
            Get
                Return _cornerRadius
            End Get
            Set(value As Integer)
                _cornerRadius = value
                Me.Invalidate()
            End Set
        End Property

        Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
            ' WinForms Designer can create controls with very small (even 0x0) bounds during initialization.
            ' Guard against negative/invalid arc rectangles to prevent designer load failures.
            Dim w As Integer = Me.Width
            Dim h As Integer = Me.Height
            If w <= 1 OrElse h <= 1 Then
                MyBase.OnPaint(pevent)
                Return
            End If

            Dim radius As Integer = CornerRadius
            If radius < 0 Then radius = 0
            Dim maxRadius As Integer = System.Math.Min(w, h) \ 2
            If radius > maxRadius Then radius = maxRadius

            If radius <= 0 Then
                If Me.Region IsNot Nothing Then Me.Region = Nothing
                MyBase.OnPaint(pevent)
                Return
            End If

            Dim diameter As Integer = radius * 2
            Using path As New GraphicsPath()
                path.StartFigure()
                path.AddArc(New Rectangle(0, 0, diameter, diameter), 180, 90)
                path.AddLine(radius, 0, w - radius, 0)
                path.AddArc(New Rectangle(w - diameter, 0, diameter, diameter), 270, 90)
                path.AddLine(w, radius, w, h - radius)
                path.AddArc(New Rectangle(w - diameter, h - diameter, diameter, diameter), 0, 90)
                path.AddLine(w - radius, h, radius, h)
                path.AddArc(New Rectangle(0, h - diameter, diameter, diameter), 90, 90)
                path.CloseFigure()

                Try
                    If Me.Region IsNot Nothing Then Me.Region.Dispose()
                Catch
                End Try
                Me.Region = New Region(path)
            End Using

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            MyBase.OnPaint(pevent)
        End Sub
    End Class
End Namespace
