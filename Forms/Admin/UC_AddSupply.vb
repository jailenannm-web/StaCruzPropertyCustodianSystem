Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class UC_AddSupply
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles pm_as_btnSave.Click
        ' Example: Validate input
        If String.IsNullOrWhiteSpace(um_as_txtSupplyID.Text) Or String.IsNullOrWhiteSpace(pm_as_txtName.Text) Then
            MessageBox.Show("Supply ID and Name are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Example: Display the values entered
        MessageBox.Show($"Supply Added:" & vbCrLf &
                        $"ID: {um_as_txtSupplyID.Text}" & vbCrLf &
                        $"Name: {pm_as_txtName.Text}" & vbCrLf &
                        $"Category: {pm_as_cmbobxCateg.Text}" & vbCrLf &
                        $"Stock: {pm_as_numericStock.Value}" & vbCrLf &
                        $"Unit Cost: {pm_as_txtUnitCost.Text}" & vbCrLf &
                        $"Location: {pm_as_txtLocation.Text}" & vbCrLf &
                        $"Status: {pm_as_cmbobxStatus.Text}", "Added")

        ' TODO: Add logic to pass data back to PropertyManagement
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles pm_as_btnCancel.Click
        ' Close or hide the UserControl
        Me.Parent.Controls.Remove(Me)
    End Sub
End Class
