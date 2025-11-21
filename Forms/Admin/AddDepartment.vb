Imports System
Imports System.Windows.Forms

Public Class AddDepartment
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    ' Optional: Add a Back button like in EditUser
    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_DepartmentManagement())
        End If
    End Sub

    ' Optional: Add Save button logic
    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Department added successfully!")
        ' Add your save logic here
    End Sub


End Class
