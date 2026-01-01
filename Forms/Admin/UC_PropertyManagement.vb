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
    Public Sub LoadSuppliesData()
        Try
            pm_table.Rows.Clear()
            Dim dt As DataTable = modDB.GetAllProperties()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    ' Use correct column names from GetAllProperties query
                    ' Query returns: propertyId, itemName, category, propertyNumber, serialNumber, 
                    ' acquisitionDate, acquisitionCost, condition, location, status, description, 
                    ' assignedEmployee, assignedDepartment
                    pm_table.Rows.Add(
                        If(IsDBNull(row("propertyId")), "", row("propertyId").ToString()),
                        If(IsDBNull(row("propertyNumber")), "", row("propertyNumber").ToString()),
                        If(IsDBNull(row("itemName")), "", row("itemName").ToString()),
                        If(IsDBNull(row("category")), "", row("category").ToString()),
                        If(IsDBNull(row("serialNumber")), "", row("serialNumber").ToString()),
                        If(IsDBNull(row("acquisitionCost")), "0.00", row("acquisitionCost").ToString()),
                        If(IsDBNull(row("location")), "", row("location").ToString()),
                        If(IsDBNull(row("status")), "", row("status").ToString()),
                        If(IsDBNull(row("condition")), "", row("condition").ToString()),
                        If(IsDBNull(row("assignedDepartment")), "", row("assignedDepartment").ToString())
                    )
                Next
                System.Diagnostics.Debug.WriteLine("[v0] Property Management - Loaded " & dt.Rows.Count & " properties")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Property Management - No properties found")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Load Supplies Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub pm_table_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pm_table.CellContentClick
        ' Optional for future clickable cells
    End Sub

    Private Sub pm_btn_Update_Click(sender As Object, e As EventArgs)
        ' Refresh data from database
        LoadSuppliesData()
        MessageBox.Show("Data refreshed from database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub pm_btn_AddSupply_Click(sender As Object, e As EventArgs)
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

    Private Sub admin_label_PM_Click(sender As Object, e As EventArgs) Handles admin_label_PM.Click

    End Sub
End Class
