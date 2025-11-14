Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
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

        ' Load data from database instead of hardcoded sample data
        LoadSuppliesData()
    End Sub

    ' Added method to load supplies from database
    Private Sub LoadSuppliesData()
        Try
            pm_table.Rows.Clear()
            Dim dt As DataTable = DatabaseConnection.GetAllSupplies()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    pm_table.Rows.Add(
                        row("supply_id").ToString(),
                        row("name").ToString(),
                        row("category").ToString(),
                        row("stock").ToString(),
                        row("unit_cost").ToString(),
                        row("total_value").ToString(),
                        row("status").ToString(),
                        row("location").ToString(),
                        "Edit"
                    )
                Next
                System.Diagnostics.Debug.WriteLine("[v0] Property Management - Loaded " & dt.Rows.Count & " supplies")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Property Management - No supplies found")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Load Supplies Error: " & ex.Message)
        End Try
    End Sub

    Private Sub pm_table_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pm_table.CellContentClick
        ' Optional for future clickable cells
    End Sub

    Private Sub pm_btn_Update_Click(sender As Object, e As EventArgs) Handles pm_btn_Update.Click
        ' Refresh data from database
        LoadSuppliesData()
        MessageBox.Show("Data refreshed from database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub pm_btn_AddSupply_Click(sender As Object, e As EventArgs) Handles pm_btn_AddSupply.Click
        Dim addSupplyUC As New UC_AddSupply()
        Me.Parent.Controls.Add(addSupplyUC)
        addSupplyUC.BringToFront()

        ' Refresh data after adding supply (when form is closed)
        ' Use a timer to check if the control was removed
        Dim timer As New Timer()
        timer.Interval = 500
        AddHandler timer.Tick, Sub()
                                   If Not Me.Parent.Controls.Contains(addSupplyUC) Then
                                       LoadSuppliesData()
                                       timer.Stop()
                                       timer.Dispose()
                                   End If
                               End Sub
        timer.Start()
    End Sub
End Class
