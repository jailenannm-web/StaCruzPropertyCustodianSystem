Imports System
Imports System.Windows.Forms

Public Class AssignRequestManagement
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    ' Optional: Add a Back button like in EditUser
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    ' Optional: Add Save button logic
    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Property Request added successfully!")
        ' Add your save logic here
    End Sub

    Private Sub RoundedPanel3_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel3.Paint

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub
End Class