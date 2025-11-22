Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Linq

Public Class UC_PropertyManagement1
    Inherits UserControl

    Private originalData As DataTable
    Private selectedPropertyID As Integer = -1

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub UC_PropertyManagement1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' General settings
        propertyManagementGrid.ReadOnly = True
        propertyManagementGrid.AllowUserToAddRows = False
        propertyManagementGrid.AllowUserToDeleteRows = False
        propertyManagementGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        propertyManagementGrid.MultiSelect = False
        propertyManagementGrid.RowTemplate.Height = 30
        propertyManagementGrid.EnableHeadersVisualStyles = False

        ' Font & colors
        propertyManagementGrid.DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        propertyManagementGrid.DefaultCellStyle.BackColor = Color.White
        propertyManagementGrid.DefaultCellStyle.ForeColor = Color.Black
        propertyManagementGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        ' Header styling
        propertyManagementGrid.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        propertyManagementGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        propertyManagementGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        propertyManagementGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Column alignment
        For Each col As DataGridViewColumn In propertyManagementGrid.Columns
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        ' Auto size
        propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Initialize search placeholder
        AddHandler pm_txtbox_search.GotFocus, AddressOf SearchTextBox_GotFocus
        AddHandler pm_txtbox_search.LostFocus, AddressOf SearchTextBox_LostFocus
        pm_txtbox_search.Text = "Search"

        ' Initialize filter dropdowns
        InitializeFilters()

        ' Load data from database
        LoadPropertiesData()

        ' Wire up event handlers
        AddHandler propertyManagementGrid.SelectionChanged, AddressOf propertyManagementGrid_SelectionChanged
    End Sub

    Private Sub InitializeFilters()
        ' Populate category filter
        pm_cbobx_categ.Items.Clear()
        pm_cbobx_categ.Items.Add("All Categories")
        pm_cbobx_categ.Items.AddRange(New String() {"Furniture", "Equipment", "Office Supplies", "IT Equipment", 
                                                    "Laboratory Apparatus", "Books and Publications", 
                                                    "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"})
        pm_cbobx_categ.SelectedIndex = 0

        ' Populate status filter
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"active", "disposed", "lost", "damaged"})
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

    Public Sub LoadPropertiesData()
        Try
            propertyManagementGrid.Rows.Clear()
            Dim categoryFilter As String = ""
            Dim statusFilter As String = ""

            ' Get filter values
            If pm_cbobx_categ.SelectedIndex > 0 Then
                categoryFilter = pm_cbobx_categ.SelectedItem.ToString()
            End If
            If pm_cbobx_status.SelectedIndex > 0 Then
                statusFilter = pm_cbobx_status.SelectedItem.ToString()
            End If

            Dim dt As DataTable = DatabaseConnection.GetAllProperties(Nothing, "", categoryFilter, Nothing)
            originalData = dt.Copy()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    ' Map database columns to grid columns
                    Dim warrantyExp As String = ""
                    If Not IsDBNull(row("warranty_details")) AndAlso Not String.IsNullOrEmpty(row("warranty_details").ToString()) Then
                        warrantyExp = row("warranty_details").ToString()
                    End If

                    propertyManagementGrid.Rows.Add(
                        If(IsDBNull(row("property_id")), "", row("property_id").ToString()),
                        If(IsDBNull(row("property_name")), "", row("property_name").ToString()),
                        If(IsDBNull(row("category")), "", row("category").ToString()),
                        If(IsDBNull(row("serial_number")), "", row("serial_number").ToString()),
                        If(IsDBNull(row("supplier_name")), "", row("supplier_name").ToString()),
                        If(IsDBNull(row("condition_status")), "", row("condition_status").ToString()),
                        If(IsDBNull(row("acquisition_cost")), "0.00", Format(CDec(row("acquisition_cost")), "0.00")),
                        If(IsDBNull(row("acquisition_date")), "", CDate(row("acquisition_date")).ToString("yyyy-MM-dd")),
                        warrantyExp,
                        If(IsDBNull(row("assigned_employee")), "", row("assigned_employee").ToString()),
                        If(IsDBNull(row("assigned_department")), "", row("assigned_department").ToString()),
                        If(IsDBNull(row("location")), "", row("location").ToString()),
                        If(IsDBNull(row("status")), "", row("status").ToString())
                    )
                Next
                System.Diagnostics.Debug.WriteLine("[v0] Property Management - Loaded " & dt.Rows.Count & " properties")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Property Management - No properties found")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Load Properties Error: " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub propertyManagementGrid_SelectionChanged(sender As Object, e As EventArgs)
        If propertyManagementGrid.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
            If selectedRow.Cells("propertyID").Value IsNot Nothing Then
                Dim propertyIDStr As String = selectedRow.Cells("propertyID").Value.ToString()
                If Integer.TryParse(propertyIDStr, selectedPropertyID) Then
                    ' Row selected, enable Edit and Delete buttons
                End If
            End If
        End If
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        ' Reload data with filters
        LoadPropertiesData()
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
            LoadPropertiesData()
            Return
        End If

        Try
            propertyManagementGrid.Rows.Clear()
            Dim filteredRows = originalData.AsEnumerable().Where(Function(row)
                Dim name As String = If(IsDBNull(row("property_name")), "", row("property_name").ToString().ToLower())
                Dim category As String = If(IsDBNull(row("category")), "", row("category").ToString().ToLower())
                Dim status As String = If(IsDBNull(row("status")), "", row("status").ToString().ToLower())
                Return name.Contains(searchText) OrElse category.Contains(searchText) OrElse status.Contains(searchText)
            End Function)

            For Each row As DataRow In filteredRows
                Dim warrantyExp As String = ""
                If Not IsDBNull(row("warranty_details")) AndAlso Not String.IsNullOrEmpty(row("warranty_details").ToString()) Then
                    warrantyExp = row("warranty_details").ToString()
                End If

                propertyManagementGrid.Rows.Add(
                    If(IsDBNull(row("property_id")), "", row("property_id").ToString()),
                    If(IsDBNull(row("property_name")), "", row("property_name").ToString()),
                    If(IsDBNull(row("category")), "", row("category").ToString()),
                    If(IsDBNull(row("serial_number")), "", row("serial_number").ToString()),
                    If(IsDBNull(row("supplier_name")), "", row("supplier_name").ToString()),
                    If(IsDBNull(row("condition_status")), "", row("condition_status").ToString()),
                    If(IsDBNull(row("acquisition_cost")), "0.00", Format(CDec(row("acquisition_cost")), "0.00")),
                    If(IsDBNull(row("acquisition_date")), "", CDate(row("acquisition_date")).ToString("yyyy-MM-dd")),
                    warrantyExp,
                    If(IsDBNull(row("assigned_employee")), "", row("assigned_employee").ToString()),
                    If(IsDBNull(row("assigned_department")), "", row("assigned_department").ToString()),
                    If(IsDBNull(row("location")), "", row("location").ToString()),
                    If(IsDBNull(row("status")), "", row("status").ToString())
                )
            Next
        Catch ex As Exception
            MessageBox.Show("Error searching properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddProperty())
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
        If selectedRow.Cells("propertyID").Value Is Nothing Then
            MessageBox.Show("Invalid property selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim propertyIDStr As String = selectedRow.Cells("propertyID").Value.ToString()
        Dim propertyID As Integer
        If Not Integer.TryParse(propertyIDStr, propertyID) Then
            MessageBox.Show("Invalid property ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open edit form (you'll need to create UC_EditProperty or modify AddProperty to support edit mode)
        MessageBox.Show("Edit functionality - Property ID: " & propertyID.ToString(), "Edit Property", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' TODO: Implement edit form
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
        If selectedRow.Cells("propertyID").Value Is Nothing Then
            MessageBox.Show("Invalid property selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim propertyIDStr As String = selectedRow.Cells("propertyID").Value.ToString()
        Dim propertyName As String = If(selectedRow.Cells("propertyName").Value IsNot Nothing, selectedRow.Cells("propertyName").Value.ToString(), "Unknown")

        Dim propertyID As Integer
        If Not Integer.TryParse(propertyIDStr, propertyID) Then
            MessageBox.Show("Invalid property ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Confirmation dialog
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete property '" & propertyName & "' (ID: " & propertyID.ToString() & ")?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            Try
                Dim success As Boolean = DatabaseConnection.DeleteProperty(propertyID)
                If success Then
                    LoadPropertiesData() ' Refresh table
                    MessageBox.Show("Property deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting property: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class
