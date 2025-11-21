Imports System
Imports System.Windows.Forms

Public Class UC_PropertyManagement1
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Find the parent form (AdminDashboard)
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            ' Load AddDepartment UserControl
            parentDashboard.LoadUserControl(New AddProperty())
        End If
    End Sub

End Class
