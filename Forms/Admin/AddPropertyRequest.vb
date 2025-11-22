Imports System
Imports System.Windows.Forms

Public Class AddPropertyRequest
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    ' Optional: Add a Back button like in EditUser
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_PropertyRequestManagement())
        End If
    End Sub

    ' Optional: Add Save button logic
    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Property Request added successfully!")
        ' Add your save logic here
    End Sub


End Class