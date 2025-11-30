Imports System
Imports System.Windows.Forms

Public Class MaintenanceRequestForm
    Inherits System.Windows.Forms.UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        ' Navigate back to staff dashboard
        Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
        If parentDashboard IsNot Nothing Then
            ' Handle navigation within dashboard
        End If
    End Sub
End Class
