Imports System
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class SAPropertyManagement
    Private pnlFormLoader As Object

    Private Sub RoundedPanel4_Paint(sender As Object, e As PaintEventArgs) Handles pnlStatus.Paint

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    ' Added form load handler to display supplies in property management
    Private Sub SAPropertyManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSuppliesIntoGrid()
    End Sub

    ' Added method to load supplies data into DataGridView
    Private Sub LoadSuppliesIntoGrid()
        Try
            Dim suppliesTable As DataTable = DatabaseConnection.GetAllSupplies()
            If dgvPropertyManagement IsNot Nothing Then
                dgvPropertyManagement.DataSource = suppliesTable
                dgvPropertyManagement.AutoResizeColumns()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
