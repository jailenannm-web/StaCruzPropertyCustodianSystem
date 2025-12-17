Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Text.RegularExpressions
Imports System.Linq

Public Class UC_SupplyManagement
    Inherits UserControl

    Private originalData As DataTable
    Private selectedSupplyID As Integer = -1
    Private canModifySupplies As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub UC_SupplyManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        ' No restrictions - all buttons enabled for Super Admin, Admin, and Custodian
        ApplyRolePermissions()

        ' Initialize filter dropdowns
        InitializeFilters()

        ' Load data from database
        LoadSuppliesData()

        ' Wire up event handlers
        AddHandler pm_table.SelectionChanged, AddressOf pm_table_SelectionChanged
    End Sub

    Private Sub ApplyRolePermissions()
        ' Super Admin, Admin, and Custodian have full access - all buttons enabled
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        btnAdd.Enabled = hasFullAccess
        btnEdit.Enabled = hasFullAccess
        btnDelete.Enabled = hasFullAccess
    End Sub


    Private Sub InitializeFilters()
        ' Populate category filter from database
        pm_cbobx_categ.Items.Clear()
        pm_cbobx_categ.Items.Add("All Categories")
        Try
            Dim categoriesTable As DataTable = DatabaseConnection.GetCategories("supply")
            If categoriesTable IsNot Nothing AndAlso categoriesTable.Rows.Count > 0 Then
                For Each row As DataRow In categoriesTable.Rows
                    pm_cbobx_categ.Items.Add(row("category_name").ToString())
                Next
            Else
                ' Fallback to hardcoded categories if database query fails
                pm_cbobx_categ.Items.AddRange(New String() {"Office Supplies", "Cleaning Supplies", "Medical Supplies", "Stationery", "Electronics", "Furniture", "Equipment", "Other"})
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] InitializeFilters Exception: " & ex.Message)
            ' Fallback to hardcoded categories
            pm_cbobx_categ.Items.AddRange(New String() {"Office Supplies", "Cleaning Supplies", "Medical Supplies", "Stationery", "Electronics", "Furniture", "Equipment", "Other"})
        End Try
        pm_cbobx_categ.SelectedIndex = 0

        ' Populate status filter
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"Available", "Low Stock", "Out of Stock"})
        pm_cbobx_status.SelectedIndex = 0

        ' Wire up filter change events
        AddHandler pm_cbobx_categ.SelectedIndexChanged, AddressOf Filter_Changed
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
    End Sub

    ' Added method to load supplies from database
    Public Sub LoadSuppliesData()
        Try
            pm_table.Rows.Clear()
            Dim categoryFilter As String = ""
            Dim statusFilter As String = ""

            ' Get filter values
            If pm_cbobx_categ.SelectedIndex > 0 Then
                categoryFilter = pm_cbobx_categ.SelectedItem.ToString()
            End If
            If pm_cbobx_status.SelectedIndex > 0 Then
                statusFilter = pm_cbobx_status.SelectedItem.ToString()
            End If

            Dim dt As DataTable = DatabaseConnection.GetAllSupplies(categoryFilter, statusFilter)
            originalData = dt.Copy()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    ' Use safe column access with correct camelCase column names from database
                    ' Designer column order: supplyId, itemName, unitOfMeasure, dateReceived, unitCost, totalCost, sourceOfFunds, stockStatus, createdAt, updatedAt
                    Dim supplyID As String = If(row.Table.Columns.Contains("supplyId") AndAlso Not IsDBNull(row("supplyId")), row("supplyId").ToString(), "")
                    Dim supplyName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString(), "")
                    Dim unitOfMeasure As String = If(row.Table.Columns.Contains("unitOfMeasure") AndAlso Not IsDBNull(row("unitOfMeasure")), row("unitOfMeasure").ToString(), "")
                    Dim acqDate As String = ""
                    If row.Table.Columns.Contains("dateReceived") AndAlso Not IsDBNull(row("dateReceived")) Then
                        Dim parsedDate As Date
                        If Date.TryParse(row("dateReceived").ToString(), parsedDate) Then
                            acqDate = parsedDate.ToString("yyyy-MM-dd")
                        End If
                    End If
                    Dim unitCost As String = "0.00"
                    If row.Table.Columns.Contains("unitCost") AndAlso Not IsDBNull(row("unitCost")) Then
                        Dim cost As Decimal
                        If Decimal.TryParse(row("unitCost").ToString(), cost) Then
                            unitCost = Format(cost, "0.00")
                        End If
                    End If
                    Dim totalCost As String = "0.00"
                    If row.Table.Columns.Contains("totalCost") AndAlso Not IsDBNull(row("totalCost")) Then
                        Dim cost As Decimal
                        If Decimal.TryParse(row("totalCost").ToString(), cost) Then
                            totalCost = Format(cost, "0.00")
                        End If
                    End If
                    Dim sourceOfFunds As String = If(row.Table.Columns.Contains("sourceOfFunds") AndAlso Not IsDBNull(row("sourceOfFunds")), row("sourceOfFunds").ToString(), "")
                    Dim status As String = If(row.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(row("stockStatus")), row("stockStatus").ToString(), "")
                    Dim createdAt As String = If(row.Table.Columns.Contains("createdAt") AndAlso Not IsDBNull(row("createdAt")), Convert.ToDateTime(row("createdAt")).ToString("yyyy-MM-dd"), "")
                    Dim updatedAt As String = If(row.Table.Columns.Contains("updatedAt") AndAlso Not IsDBNull(row("updatedAt")), Convert.ToDateTime(row("updatedAt")).ToString("yyyy-MM-dd"), "")

                    ' Add row matching Designer column order: supplyId, itemName, unitOfMeasure, dateReceived, unitCost, totalCost, sourceOfFunds, stockStatus, createdAt, updatedAt
                    Dim rowIndex As Integer = pm_table.Rows.Add(supplyID, supplyName, unitOfMeasure, acqDate, unitCost, totalCost, sourceOfFunds, status, createdAt, updatedAt)
                Next

                ' Update total count
                If ttlSupplymanagement IsNot Nothing Then
                    ttlSupplymanagement.Text = dt.Rows.Count.ToString()
                End If
                System.Diagnostics.Debug.WriteLine("[v0] Supply Management - Loaded " & dt.Rows.Count & " supplies")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Supply Management - No supplies found")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Load Supplies Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub pm_table_SelectionChanged(sender As Object, e As EventArgs)
        If pm_table.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = pm_table.SelectedRows(0)
            ' Get SupplyID from first column (index 0 - supplyId)
            ' Column order: supplyId (0), itemName (1), unitOfMeasure (2), dateReceived (3), unitCost (4), totalCost (5), sourceOfFunds (6), stockStatus (7), createdAt (8), updatedAt (9)
            Try
                If selectedRow.Cells.Count > 0 AndAlso selectedRow.Cells(0).Value IsNot Nothing Then
                    Dim supplyIDStr As String = selectedRow.Cells(0).Value.ToString()
                    If Integer.TryParse(supplyIDStr, selectedSupplyID) Then
                        ' Row selected, enable Edit and Delete buttons
                    End If
                End If
            Catch ex As Exception
                ' Handle any errors silently
                System.Diagnostics.Debug.WriteLine("SelectionChanged Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        ' Reload data with filters
        LoadSuppliesData()
        ' Reapply search if there's search text
    End Sub
    ' Super Admin bypasses all restrictions


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Super Admin bypasses all restrictions

        ' Get reference to the parent dashboard form
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)

        If parentDashboard IsNot Nothing Then
            ' Load the AddSupply UserControl
            parentDashboard.LoadUserControl(New AddSupply())
        Else
            ' Fallback: add directly to the parent container
            Dim addSupplyUC As New AddSupply()
            Me.Parent.Controls.Add(addSupplyUC)
            addSupplyUC.BringToFront()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If pm_table.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a supply to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = pm_table.SelectedRows(0)

        ' Read supply_id from first column (index 0)
        If selectedRow.Cells.Count = 0 OrElse selectedRow.Cells(0).Value Is Nothing Then
            MessageBox.Show("Invalid supply selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim supplyID As Integer
        If Not Integer.TryParse(selectedRow.Cells(0).Value.ToString(), supplyID) Then
            MessageBox.Show("Invalid supply ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get supply data from DB
        Dim supplyData As DataRow = DatabaseConnection.GetSupplyById(supplyID)
        If supplyData Is Nothing Then
            MessageBox.Show("Supply not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open EditSupply Form
        Dim editForm As New EditSupply()
        editForm.LoadSupplyData(supplyID, supplyData)

        ' Navigate into Admin Dashboard
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(editForm)
        Else
            MessageBox.Show("Unable to open EditSupply screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Super Admin bypasses all restrictions

        If pm_table.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a supply to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = pm_table.SelectedRows(0)
        ' Get SupplyID from first column (index 0)
        If selectedRow.Cells.Count = 0 OrElse selectedRow.Cells(0).Value Is Nothing Then
            MessageBox.Show("Invalid supply selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim supplyIDStr As String = selectedRow.Cells(0).Value.ToString()
        
        If String.IsNullOrEmpty(supplyIDStr) Then
            MessageBox.Show("Invalid supply selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get supply name from second column (index 1 - itemName)
        Dim supplyName As String = If(selectedRow.Cells(1).Value IsNot Nothing, selectedRow.Cells(1).Value.ToString(), "Unknown")

        Dim supplyID As Integer
        If Not Integer.TryParse(supplyIDStr, supplyID) Then
            MessageBox.Show("Invalid supply ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Confirmation dialog
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete supply '" & supplyName & "' (ID: " & supplyID.ToString() & ")?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            Try
                Dim success As Boolean = DatabaseConnection.DeleteSupply(supplyID)
                If success Then
                    LoadSuppliesData() ' Refresh table
                    MessageBox.Show("Supply deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub admin_label_PM_Click(sender As Object, e As EventArgs) Handles admin_label_PM.Click

    End Sub

    Private Sub pm_table_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
    Handles pm_table.CellClick
        ' Check if colMenu column exists before accessing it
        If e.RowIndex >= 0 AndAlso pm_table.Columns.Contains("colMenu") AndAlso e.ColumnIndex = pm_table.Columns("colMenu").Index Then
            If cmsActions IsNot Nothing Then
                cmsActions.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub mnuAssign_Click(sender As Object, e As EventArgs) _
    Handles mnuAssign.Click

        MessageBox.Show("Assign Property clicked!")
    End Sub

    Private Sub mnuDispose_Click(sender As Object, e As EventArgs) _
    Handles mnuDispose.Click

        MessageBox.Show("Dispose clicked!")
    End Sub

    Private Sub mnuLostDamaged_Click(sender As Object, e As EventArgs) _
    Handles mnuLostDamaged.Click

        MessageBox.Show("Mark Lost/Damaged clicked!")
    End Sub

    Private Sub mnuViewDetails_Click(sender As Object, e As EventArgs) _
    Handles mnuViewDetails.Click

        MessageBox.Show("View Details clicked!")
    End Sub

    Private Sub mnuPrintPARICS_Click(sender As Object, e As EventArgs) _
    Handles mnuPrintPARICS.Click

        MessageBox.Show("Print PAR/ICS clicked!")
    End Sub
End Class
