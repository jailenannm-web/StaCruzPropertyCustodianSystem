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

        ' Initialize search placeholder
        AddHandler pm_txtbox_search.GotFocus, AddressOf SearchTextBox_GotFocus
        AddHandler pm_txtbox_search.LostFocus, AddressOf SearchTextBox_LostFocus
        pm_txtbox_search.Text = "Search"

        ' Initialize filter dropdowns
        InitializeFilters()

        ' Load data from database
        LoadSuppliesData()

        ' Wire up event handlers
        AddHandler pm_table.SelectionChanged, AddressOf pm_table_SelectionChanged
    End Sub

    Private Sub InitializeFilters()
        ' Populate category filter
        pm_cbobx_categ.Items.Clear()
        pm_cbobx_categ.Items.Add("All Categories")
        pm_cbobx_categ.Items.AddRange(New String() {"Stationery", "Electronics", "Furniture", "Equipment", "Other"})
        pm_cbobx_categ.SelectedIndex = 0

        ' Populate status filter
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"active", "inactive", "low_stock", "out_of_stock", "used"})
        pm_cbobx_status.SelectedIndex = 0

        ' Wire up filter change events
        AddHandler pm_cbobx_categ.SelectedIndexChanged, AddressOf Filter_Changed
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
    End Sub

    Private Sub SearchTextBox_GotFocus(sender As Object, e As EventArgs)
        If pm_txtbox_search.Text = "Search" Then
            pm_txtbox_search.Text = ""
            pm_txtbox_search.ForeColor = Color.White
        End If
    End Sub

    Private Sub SearchTextBox_LostFocus(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(pm_txtbox_search.Text) Then
            pm_txtbox_search.Text = "Search"
            pm_txtbox_search.ForeColor = Color.White
        End If
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
                    ' Use correct column names from GetAllSupplies (SupplyID, SupplyName, Category, etc.)
                    pm_table.Rows.Add(
                        If(IsDBNull(row("SupplyID")), "", row("SupplyID").ToString()),
                        If(IsDBNull(row("SupplyName")), "", row("SupplyName").ToString()),
                        If(IsDBNull(row("Category")), "", row("Category").ToString()),
                        If(IsDBNull(row("QuantityInStock")), "0", row("QuantityInStock").ToString()),
                        If(IsDBNull(row("UnitCost")), "0.00", Format(CDec(row("UnitCost")), "0.00")),
                        If(IsDBNull(row("TotalValue")), "0.00", Format(CDec(row("TotalValue")), "0.00")),
                        If(IsDBNull(row("Status")), "", row("Status").ToString()),
                        If(IsDBNull(row("Location")), "", row("Location").ToString()),
                        "Edit"
                    )
                Next
                System.Diagnostics.Debug.WriteLine("[v0] Supply Management - Loaded " & dt.Rows.Count & " supplies")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Supply Management - No supplies found")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Load Supplies Error: " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub pm_table_SelectionChanged(sender As Object, e As EventArgs)
        If pm_table.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = pm_table.SelectedRows(0)
            If selectedRow.Cells("SupplyID").Value IsNot Nothing Then
                Dim supplyIDStr As String = selectedRow.Cells("SupplyID").Value.ToString()
                If Integer.TryParse(supplyIDStr, selectedSupplyID) Then
                    ' Row selected, enable Edit and Delete buttons
                End If
            End If
        End If
    End Sub

    Private Sub pm_table_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pm_table.CellContentClick
        ' Optional for future clickable cells
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        ' Reload data with filters
        LoadSuppliesData()
        ' Reapply search if there's search text
        If pm_txtbox_search.Text <> "Search" AndAlso Not String.IsNullOrWhiteSpace(pm_txtbox_search.Text) Then
            ApplySearch()
        End If
    End Sub

    Private Sub pm_txtbox_search_TextChanged(sender As Object, e As EventArgs) Handles pm_txtbox_search.TextChanged
        If pm_txtbox_search.Text <> "Search" Then
            ApplySearch()
        End If
    End Sub

    Private Sub ApplySearch()
        If originalData Is Nothing Then Return

        Dim searchText As String = pm_txtbox_search.Text.Trim().ToLower()
        If String.IsNullOrEmpty(searchText) OrElse searchText = "search" Then
            LoadSuppliesData()
            Return
        End If

        Try
            pm_table.Rows.Clear()
            Dim filteredRows = originalData.AsEnumerable().Where(Function(row)
                Dim name As String = If(IsDBNull(row("SupplyName")), "", row("SupplyName").ToString().ToLower())
                Dim category As String = If(IsDBNull(row("Category")), "", row("Category").ToString().ToLower())
                Dim status As String = If(IsDBNull(row("Status")), "", row("Status").ToString().ToLower())
                Return name.Contains(searchText) OrElse category.Contains(searchText) OrElse status.Contains(searchText)
            End Function)

            For Each row As DataRow In filteredRows
                pm_table.Rows.Add(
                    If(IsDBNull(row("SupplyID")), "", row("SupplyID").ToString()),
                    If(IsDBNull(row("SupplyName")), "", row("SupplyName").ToString()),
                    If(IsDBNull(row("Category")), "", row("Category").ToString()),
                    If(IsDBNull(row("QuantityInStock")), "0", row("QuantityInStock").ToString()),
                    If(IsDBNull(row("UnitCost")), "0.00", Format(CDec(row("UnitCost")), "0.00")),
                    If(IsDBNull(row("TotalValue")), "0.00", Format(CDec(row("TotalValue")), "0.00")),
                    If(IsDBNull(row("Status")), "", row("Status").ToString()),
                    If(IsDBNull(row("Location")), "", row("Location").ToString()),
                    "Edit"
                )
            Next
        Catch ex As Exception
            MessageBox.Show("Error searching supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_AddSupply())
        Else
            ' Fallback: try to add to parent control
            Dim addSupplyUC As New UC_AddSupply()
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
        If selectedRow.Cells("SupplyID").Value Is Nothing Then
            MessageBox.Show("Invalid supply selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim supplyIDStr As String = selectedRow.Cells("SupplyID").Value.ToString()
        Dim supplyID As Integer
        If Not Integer.TryParse(supplyIDStr, supplyID) Then
            MessageBox.Show("Invalid supply ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open edit form (you'll need to create UC_EditSupply or modify UC_AddSupply to support edit mode)
        MessageBox.Show("Edit functionality - Supply ID: " & supplyID.ToString(), "Edit Supply", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' TODO: Implement edit form
        ' Dim editSupplyUC As New UC_EditSupply(supplyID)
        ' parentDashboard.LoadUserControl(editSupplyUC)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If pm_table.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a supply to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = pm_table.SelectedRows(0)
        If selectedRow.Cells("SupplyID").Value Is Nothing Then
            MessageBox.Show("Invalid supply selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim supplyIDStr As String = selectedRow.Cells("SupplyID").Value.ToString()
        Dim supplyName As String = If(selectedRow.Cells("colName").Value IsNot Nothing, selectedRow.Cells("colName").Value.ToString(), "Unknown")

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
End Class
