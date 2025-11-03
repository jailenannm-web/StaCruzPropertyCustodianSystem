Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class UC_PropertyManagement
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub UC_PropertyManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' General settings
        pm_table.ReadOnly = True
        pm_table.AllowUserToAddRows = False
        pm_table.AllowUserToDeleteRows = False
        pm_table.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        pm_table.MultiSelect = False
        pm_table.RowTemplate.Height = 30
        pm_table.EnableHeadersVisualStyles = False

        ' Font & colors
        pm_table.DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        pm_table.DefaultCellStyle.BackColor = Color.White
        pm_table.DefaultCellStyle.ForeColor = Color.Black
        pm_table.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        ' Header styling
        pm_table.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        pm_table.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        pm_table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        pm_table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Column alignment
        For Each col As DataGridViewColumn In pm_table.Columns
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        ' Auto size
        pm_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Sample rows
        pm_table.Rows.Clear()
        pm_table.Rows.Add("SUP001", "Pencils", "Stationery", 100, 5, 500, "Available", "Warehouse", "Edit")
        pm_table.Rows.Add("SUP002", "Notebooks", "Stationery", 50, 20, 1000, "Available", "Warehouse", "Edit")
        pm_table.Rows.Add("SUP003", "Printer Ink", "Electronics", 20, 150, 3000, "Available", "Warehouse", "Edit")
    End Sub

    Private Sub pm_table_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pm_table.CellContentClick
        ' Optional for future clickable cells
    End Sub

    Private Sub pm_btn_Update_Click(sender As Object, e As EventArgs) Handles pm_btn_Update.Click
        MessageBox.Show("Update button clicked - refresh data here.")
    End Sub

    Private Sub pm_btn_AddSupply_Click(sender As Object, e As EventArgs) Handles pm_btn_AddSupply.Click
        Dim addSupplyUC As New UC_AddSupply()
        Me.Parent.Controls.Add(addSupplyUC)
        addSupplyUC.BringToFront()
    End Sub
End Class
