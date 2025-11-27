Imports System
Imports System.Windows.Forms

Public Class EditMaintenance1
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    ' Optional: Add a Back button like in EditUser
    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_PropertyManagement1())
        End If
    End Sub

    ' Optional: Add Save button logic
    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Department added successfully!")
        ' Add your save logic here
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub AddSupply_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub admin_label_DepartmentManagement_Click(sender As Object, e As EventArgs) Handles admin_label_DepartmentManagement.Click

    End Sub

    Private Sub propertyLocation_TextChanged(sender As Object, e As EventArgs) Handles propertyLocation.TextChanged

    End Sub

    Private Sub SAAddM_NextSched_Click(sender As Object, e As EventArgs) Handles SAAddM_NextSched.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
