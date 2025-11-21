Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class UC_DepartmentManagement
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub admin_btn_properties_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Find the parent form (AdminDashboard)
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            ' Load AddDepartment UserControl
            parentDashboard.LoadUserControl(New AddDepartment())
        End If
    End Sub


    Private Sub admin_deptmanagement_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles admin_deptmanagement.CellContentClick

    End Sub
End Class
