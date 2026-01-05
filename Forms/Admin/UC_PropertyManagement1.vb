Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Linq
Imports System.Collections.Generic
Imports System.Globalization

Public Class UC_PropertyManagement1
    Inherits UserControl

    Private originalData As DataTable
    Private selectedPropertyID As Integer = -1
    Private canModifyProperties As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub UC_PropertyManagement1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' No restrictions - all buttons enabled for Super Admin, Admin, and Custodian
        ApplyRolePermissions()

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

        ' Column alignment - Left align text columns for better readability
        For Each col As DataGridViewColumn In propertyManagementGrid.Columns
            ' Left align text columns, center align shorter columns
            If col.Name = "propertyId" OrElse col.Name = "propertyNumber" OrElse col.Name = "serialNumber" OrElse _
               col.Name = "condition" OrElse col.Name = "status" Then
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Else
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If
            
            ' Enable word wrap for description and location columns
            If col.Name = "description" OrElse col.Name = "location" OrElse col.Name = "assignedTo" Then
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End If
        Next

        ' Auto size columns to display all content properly
        propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        
        ' Set specific column widths for better display
        ConfigureColumnWidths()

        ' Initialize filter dropdowns
        InitializeFilters()

        ' Load data from database
        LoadPropertiesData()

        ' Wire up event handlers
        AddHandler propertyManagementGrid.SelectionChanged, AddressOf propertyManagementGrid_SelectionChanged

        ' Wire up search textbox if present
        Dim searchNames As String() = {"pm_search", "propertymanagementsearchbar", "txtSearch", "txtbox_search", "admin_txtbox_search", "searchBox"}
        For Each nm As String In searchNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is TextBox Then
                Dim tb As TextBox = CType(found(0), TextBox)
                RemoveHandler tb.TextChanged, AddressOf PropertySearch_TextChanged
                AddHandler tb.TextChanged, AddressOf PropertySearch_TextChanged
                Exit For
            End If
        Next
    End Sub

    Private Function FindStatusComboBox() As ComboBox
        ' Designer uses "filter" as the Status combo in this UC
        Dim names() As String = {"pm_cbobx_status", "statusFilter", "cbStatus", "filter"}
        For Each nm As String In names
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                Return CType(found(0), ComboBox)
            End If
        Next
        Return Nothing
    End Function

    Private Sub ConfigureColumnWidths()
        ' Set specific widths for each column to ensure all data is visible
        Try
            If propertyManagementGrid.Columns.Count = 0 Then Return
            
            ' Set column widths based on content type
            For Each col As DataGridViewColumn In propertyManagementGrid.Columns
                Select Case col.Name
                    Case "propertyId"
                        col.Width = 80
                        col.MinimumWidth = 80
                    Case "itemName"
                        col.Width = 150
                        col.MinimumWidth = 120
                    Case "category"
                        col.Width = 130
                        col.MinimumWidth = 100
                    Case "description"
                        col.Width = 200
                        col.MinimumWidth = 150
                    Case "unitOfMeasure"
                        col.Width = 80
                        col.MinimumWidth = 80
                    Case "propertyNumber"
                        col.Width = 100
                        col.MinimumWidth = 100
                    Case "serialNumber"
                        col.Width = 120
                        col.MinimumWidth = 100
                    Case "acquisitionDate"
                        col.Width = 100
                        col.MinimumWidth = 100
                    Case "acqusitionCost"
                        col.Width = 100
                        col.MinimumWidth = 100
                    Case "totalCost"
                        col.Width = 100
                        col.MinimumWidth = 100
                    Case "sourceOfFunds"
                        col.Width = 150
                        col.MinimumWidth = 120
                    Case "assignedTo"
                        col.Width = 180
                        col.MinimumWidth = 150
                    Case "departmentId"
                        col.Width = 180
                        col.MinimumWidth = 150
                    Case "location"
                        col.Width = 200
                        col.MinimumWidth = 150
                    Case "condition"
                        col.Width = 110
                        col.MinimumWidth = 100
                    Case "status"
                        col.Width = 100
                        col.MinimumWidth = 90
                    Case Else
                        ' Default width for any other columns
                        col.Width = 120
                        col.MinimumWidth = 100
                End Select
            Next
            
            ' Enable horizontal scrollbar for better navigation
            propertyManagementGrid.ScrollBars = ScrollBars.Both
            propertyManagementGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ConfigureColumnWidths Error: " & ex.Message)
        End Try
    End Sub

    Private Sub InitializeFilters()
        ' Populate status filter using dynamic lookup
        Dim statusCb As ComboBox = FindStatusComboBox()
        If statusCb IsNot Nothing Then
            statusCb.Items.Clear()
            statusCb.Items.Add("All Status")
            statusCb.Items.AddRange(New String() {"Active", "For Disposal", "Lost", "Borrowed"})
            statusCb.SelectedIndex = 0
        End If

        ' Populate category filter
        Dim categoryFilter As ComboBox = Nothing
        Dim categoryNames() As String = {"pm_cbobx_categ", "categoryFilter", "cbCategory"}
        For Each nm As String In categoryNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                categoryFilter = CType(found(0), ComboBox)
                Exit For
            End If
        Next
        If categoryFilter IsNot Nothing Then
            categoryFilter.Items.Clear()
            categoryFilter.Items.Add("All Categories")
            Try
                Dim categories As DataTable = modDB.GetCategories("property")
                If categories IsNot Nothing AndAlso categories.Rows.Count > 0 Then
                    For Each row As DataRow In categories.Rows
                        Dim categoryName As String = ""
                        If row.Table.Columns.Contains("category_name") AndAlso Not IsDBNull(row("category_name")) Then
                            categoryName = row("category_name").ToString()
                        ElseIf row.Table.Columns.Contains("categoryName") AndAlso Not IsDBNull(row("categoryName")) Then
                            categoryName = row("categoryName").ToString()
                        ElseIf row.Table.Columns.Count > 0 AndAlso Not IsDBNull(row(0)) Then
                            categoryName = row(0).ToString()
                        End If
                        If Not String.IsNullOrEmpty(categoryName) AndAlso Not categoryFilter.Items.Contains(categoryName) Then
                            categoryFilter.Items.Add(categoryName)
                        End If
                    Next
                End If
                ' Fallback to hardcoded categories
                If categoryFilter.Items.Count <= 1 Then
                    categoryFilter.Items.AddRange(New String() {
                        "Furniture", "Equipment", "Office Supplies", "IT Equipment",
                        "Laboratory Apparatus", "Books and Publications",
                        "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
                    })
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] InitializeFilters Category Exception: " & ex.Message)
                categoryFilter.Items.AddRange(New String() {
                    "Furniture", "Equipment", "Office Supplies", "IT Equipment",
                    "Laboratory Apparatus", "Books and Publications",
                    "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
                })
            End Try
            categoryFilter.SelectedIndex = 0
            AddHandler categoryFilter.SelectedIndexChanged, AddressOf Filter_Changed
        End If

        ' Populate location filter (get unique locations from database)
        Dim locationFilter As ComboBox = Nothing
        Dim locationNames() As String = {"pm_cbobx_location", "locationFilter", "cbLocation"}
        For Each nm As String In locationNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                locationFilter = CType(found(0), ComboBox)
                Exit For
            End If
        Next
        If locationFilter IsNot Nothing Then
            locationFilter.Items.Clear()
            locationFilter.Items.Add("All Locations")
            Try
                Dim locations As DataTable = modDB.GetLocations()
                If locations IsNot Nothing AndAlso locations.Rows.Count > 0 Then
                    For Each row As DataRow In locations.Rows
                        Dim locationName As String = ""
                        If row.Table.Columns.Contains("location_name") AndAlso Not IsDBNull(row("location_name")) Then
                            locationName = row("location_name").ToString()
                        ElseIf row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")) Then
                            locationName = row("location").ToString()
                        ElseIf row.Table.Columns.Count > 0 AndAlso Not IsDBNull(row(0)) Then
                            locationName = row(0).ToString()
                        End If
                        If Not String.IsNullOrEmpty(locationName) AndAlso Not locationFilter.Items.Contains(locationName) Then
                            locationFilter.Items.Add(locationName)
                        End If
                    Next
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] InitializeFilters Location Exception: " & ex.Message)
            End Try
            locationFilter.SelectedIndex = 0
            AddHandler locationFilter.SelectedIndexChanged, AddressOf Filter_Changed
        End If

        ' Populate condition filter
        Dim conditionFilter As ComboBox = Nothing
        Dim conditionNames() As String = {"pm_cbobx_condition", "conditionFilter", "cbCondition"}
        For Each nm As String In conditionNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                conditionFilter = CType(found(0), ComboBox)
                Exit For
            End If
        Next
        If conditionFilter IsNot Nothing Then
            conditionFilter.Items.Clear()
            conditionFilter.Items.Add("All Conditions")
            conditionFilter.Items.AddRange(New String() {"Good", "Needs Repair", "Damaged"})
            conditionFilter.SelectedIndex = 0
            AddHandler conditionFilter.SelectedIndexChanged, AddressOf Filter_Changed
        End If

        ' Wire up filter change events for status control if found
        If statusCb IsNot Nothing Then
            AddHandler statusCb.SelectedIndexChanged, AddressOf Filter_Changed
        End If
    End Sub

    Public Sub LoadPropertiesData()
        Try
            ' PERFORMANCE FIX: Suspend layout and disable auto-refresh during bulk operations
            propertyManagementGrid.SuspendLayout()
            propertyManagementGrid.Rows.Clear()
            
            Dim categoryFilter As String = ""
            Dim statusFilter As String = ""
            Dim locationFilter As String = ""
            Dim conditionFilter As String = ""

            ' Get status filter from dropdown
            Dim statusCb As ComboBox = FindStatusComboBox()
            If statusCb IsNot Nothing AndAlso statusCb.SelectedIndex > 0 Then
                statusFilter = statusCb.SelectedItem.ToString()
            End If

            ' Get category filter
            Dim categoryFilterCb As ComboBox = Nothing
            Dim categoryNames() As String = {"pm_cbobx_categ", "categoryFilter", "cbCategory"}
            For Each nm As String In categoryNames
                Dim found() As Control = Me.Controls.Find(nm, True)
                If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                    categoryFilterCb = CType(found(0), ComboBox)
                    If categoryFilterCb.SelectedIndex > 0 Then
                        categoryFilter = categoryFilterCb.SelectedItem.ToString()
                    End If
                    Exit For
                End If
            Next

            ' Get location filter
            Dim locationFilterCb As ComboBox = Nothing
            Dim locationNames() As String = {"pm_cbobx_location", "locationFilter", "cbLocation"}
            For Each nm As String In locationNames
                Dim found() As Control = Me.Controls.Find(nm, True)
                If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                    locationFilterCb = CType(found(0), ComboBox)
                    If locationFilterCb.SelectedIndex > 0 Then
                        locationFilter = locationFilterCb.SelectedItem.ToString()
                    End If
                    Exit For
                End If
            Next

            ' Get condition filter
            Dim conditionFilterCb As ComboBox = Nothing
            Dim conditionNames() As String = {"pm_cbobx_condition", "conditionFilter", "cbCondition"}
            For Each nm As String In conditionNames
                Dim found() As Control = Me.Controls.Find(nm, True)
                If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                    conditionFilterCb = CType(found(0), ComboBox)
                    If conditionFilterCb.SelectedIndex > 0 Then
                        conditionFilter = conditionFilterCb.SelectedItem.ToString()
                    End If
                    Exit For
                End If
            Next

            ' PERFORMANCE: Load limited dataset (1000 records) with pagination support
            Dim dt As DataTable = modDB.GetAllProperties(Nothing, conditionFilter, categoryFilter, Nothing, statusFilter, 1000, 0)
            originalData = dt.Copy()

            ' Hide columns that should not be visible
            If propertyManagementGrid.Columns.Contains("unitOfMeasure") Then propertyManagementGrid.Columns("unitOfMeasure").Visible = False
            If propertyManagementGrid.Columns.Contains("propertyNumber") Then propertyManagementGrid.Columns("propertyNumber").Visible = False
            If propertyManagementGrid.Columns.Contains("serialNumber") Then propertyManagementGrid.Columns("serialNumber").Visible = False
            If propertyManagementGrid.Columns.Contains("acquisitionDate") Then propertyManagementGrid.Columns("acquisitionDate").Visible = False
            If propertyManagementGrid.Columns.Contains("acqusitionCost") Then propertyManagementGrid.Columns("acqusitionCost").Visible = False
            If propertyManagementGrid.Columns.Contains("acquisitionCost") Then propertyManagementGrid.Columns("acquisitionCost").Visible = False
            If propertyManagementGrid.Columns.Contains("totalCost") Then propertyManagementGrid.Columns("totalCost").Visible = False
            If propertyManagementGrid.Columns.Contains("sourceOfFunds") Then propertyManagementGrid.Columns("sourceOfFunds").Visible = False
            If propertyManagementGrid.Columns.Contains("departmentId") Then propertyManagementGrid.Columns("departmentId").Visible = False
            If propertyManagementGrid.Columns.Contains("internalCodes") Then propertyManagementGrid.Columns("internalCodes").Visible = False
            If propertyManagementGrid.Columns.Contains("createdAt") Then propertyManagementGrid.Columns("createdAt").Visible = False
            If propertyManagementGrid.Columns.Contains("updatedAt") Then propertyManagementGrid.Columns("updatedAt").Visible = False

            ' Show only required columns: itemName, category, description, assignedTo, location, condition, status
            If propertyManagementGrid.Columns.Contains("propertyId") Then propertyManagementGrid.Columns("propertyId").Visible = False
            If propertyManagementGrid.Columns.Contains("itemName") Then propertyManagementGrid.Columns("itemName").Visible = True
            If propertyManagementGrid.Columns.Contains("category") Then propertyManagementGrid.Columns("category").Visible = True
            If propertyManagementGrid.Columns.Contains("description") Then propertyManagementGrid.Columns("description").Visible = True
            If propertyManagementGrid.Columns.Contains("assignedTo") Then propertyManagementGrid.Columns("assignedTo").Visible = True
            If propertyManagementGrid.Columns.Contains("location") Then propertyManagementGrid.Columns("location").Visible = True
            If propertyManagementGrid.Columns.Contains("condition") Then propertyManagementGrid.Columns("condition").Visible = True
            If propertyManagementGrid.Columns.Contains("status") Then propertyManagementGrid.Columns("status").Visible = True

            ' Apply location filter if specified
            If Not String.IsNullOrEmpty(locationFilter) Then
                Dim filteredRows = dt.AsEnumerable().Where(Function(r)
                                                               Dim loc As String = If(r.Table.Columns.Contains("location") AndAlso Not IsDBNull(r("location")), r("location").ToString(), "")
                                                               Return loc = locationFilter
                                                           End Function)
                dt = filteredRows.CopyToDataTable()
            End If

            If dt.Rows.Count > 0 Then
                ' PERFORMANCE FIX: Use AddRange instead of individual Add() calls
                Dim rowsToAdd As New List(Of Object())
                
                For Each row As DataRow In dt.Rows
                    ' Extract propertyId first
                    Dim propID As Integer = 0
                    If row.Table.Columns.Contains("propertyId") AndAlso Not IsDBNull(row("propertyId")) Then
                        Integer.TryParse(row("propertyId").ToString(), propID)
                    End If

                    ' Extract only required fields: propertyId, itemName, category, description, assignedTo, location, condition, status
                    Dim itemName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString(), "")
                    Dim category As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString(), "")
                    Dim description As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString(), "")
                    ' assignedTo should show employee name, not ID
                    Dim assignedTo As String = If(row.Table.Columns.Contains("assignedEmployee") AndAlso Not IsDBNull(row("assignedEmployee")), row("assignedEmployee").ToString(), If(row.Table.Columns.Contains("assignedTo") AndAlso Not IsDBNull(row("assignedTo")), row("assignedTo").ToString(), ""))
                    Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), "")
                    Dim condition As String = If(row.Table.Columns.Contains("condition") AndAlso Not IsDBNull(row("condition")), row("condition").ToString(), "")
                    Dim status As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), "")

                    ' Build row array for batch insert
                    rowsToAdd.Add(New Object() {
                        propID.ToString(),        ' propertyId
                        itemName,                ' itemName
                        category,                ' category
                        description,             ' description
                        "",                      ' unitOfMeasure (hidden)
                        "",                      ' propertyNumber (hidden)
                        "",                      ' serialNumber (hidden)
                        "",                      ' acquisitionDate (hidden)
                        "",                      ' acquisitionCost (hidden)
                        "",                      ' totalCost (hidden)
                        "",                      ' sourceOfFunds (hidden)
                        assignedTo,              ' assignedTo
                        "",                      ' departmentId (hidden)
                        location,                ' location
                        condition,               ' condition
                        status                   ' status
                    })
                Next
                
                ' PERFORMANCE: Batch add all rows at once
                For i As Integer = 0 To rowsToAdd.Count - 1
                    Dim rowIndex As Integer = propertyManagementGrid.Rows.Add(rowsToAdd(i))
                    ' Store propertyId in row Tag
                    If rowIndex >= 0 AndAlso rowIndex < propertyManagementGrid.Rows.Count Then
                        Integer.TryParse(rowsToAdd(i)(0).ToString(), propertyManagementGrid.Rows(rowIndex).Tag)
                    End If
                Next
                
                ' Update total count
                If ttlpropertymanagement IsNot Nothing Then
                    ttlpropertymanagement.Text = dt.Rows.Count.ToString()
                End If
                Debug.WriteLine("[v0] Property Management - Loaded " & dt.Rows.Count & " properties")
            Else
                Debug.WriteLine("[v0] Property Management - No properties found")
                If ttlpropertymanagement IsNot Nothing Then
                    ttlpropertymanagement.Text = "0"
                End If
            End If
            
            ' Resume layout updates
            propertyManagementGrid.ResumeLayout()
            
            ' Reapply column widths after loading data
            ConfigureColumnWidths()
        Catch ex As Exception
            MessageBox.Show("Error loading properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine("[v0] Load Properties Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
            If ttlpropertymanagement IsNot Nothing Then
                ttlpropertymanagement.Text = "0"
            End If
        Finally
            ' Ensure layout is resumed even if error occurs
            Try
                propertyManagementGrid.ResumeLayout()
            Catch
            End Try
        End Try
    End Sub

    Private Sub propertyManagementGrid_SelectionChanged(sender As Object, e As EventArgs)
        Dim hasSelection As Boolean = False
        selectedPropertyID = -1

        If propertyManagementGrid IsNot Nothing AndAlso propertyManagementGrid.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
            If selectedRow IsNot Nothing AndAlso selectedRow.Tag IsNot Nothing Then
                hasSelection = Integer.TryParse(selectedRow.Tag.ToString(), selectedPropertyID) AndAlso selectedPropertyID > 0
            Else
                ' Try to get propertyID from cells if Tag is not set
                If propertyManagementGrid.Columns.Contains("propertyId") AndAlso selectedRow.Cells("propertyId").Value IsNot Nothing Then
                    hasSelection = Integer.TryParse(selectedRow.Cells("propertyId").Value.ToString(), selectedPropertyID) AndAlso selectedPropertyID > 0
                ElseIf selectedRow.Cells.Count > 0 AndAlso selectedRow.Cells(0).Value IsNot Nothing Then
                    ' Try first cell
                    hasSelection = Integer.TryParse(selectedRow.Cells(0).Value.ToString(), selectedPropertyID) AndAlso selectedPropertyID > 0
                End If
            End If
        End If

        ' SUPER ADMIN HAS UNRESTRICTED ACCESS - buttons always enabled
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        
        ' For Super Admin: buttons are always enabled (no selection check)
        ' For others: require selection
        If btnEdit IsNot Nothing Then btnEdit.Enabled = hasFullAccess
        If btnDelete IsNot Nothing Then btnDelete.Enabled = hasFullAccess
    End Sub




    Private Sub ApplyRolePermissions()
        ' SUPER ADMIN HAS UNRESTRICTED ACCESS - NO LIMITATIONS
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        canModifyProperties = hasFullAccess

        ' Enable all buttons for Super Admin immediately (no selection required)
        If btnAdd IsNot Nothing Then btnAdd.Enabled = hasFullAccess
        If btnEdit IsNot Nothing Then btnEdit.Enabled = hasFullAccess
        If btnDelete IsNot Nothing Then btnDelete.Enabled = hasFullAccess
        
        ' Also enable issuePropertySlip button if it exists
        Try
            Dim issueSlipBtn = Me.Controls.Find("issuePropertySlip", True)
            If issueSlipBtn IsNot Nothing AndAlso issueSlipBtn.Length > 0 Then
                issueSlipBtn(0).Enabled = hasFullAccess
            End If
        Catch
        End Try
        
        ' Debug output
        System.Diagnostics.Debug.WriteLine("[v0] ApplyRolePermissions - IsSuperAdmin: " & SessionContext.IsSuperAdmin())
        System.Diagnostics.Debug.WriteLine("[v0] ApplyRolePermissions - IsAdmin: " & SessionContext.IsAdmin())
        System.Diagnostics.Debug.WriteLine("[v0] ApplyRolePermissions - hasFullAccess: " & hasFullAccess)
        System.Diagnostics.Debug.WriteLine("[v0] ApplyRolePermissions - btnAdd.Enabled: " & If(btnAdd IsNot Nothing, btnAdd.Enabled.ToString(), "NULL"))
        System.Diagnostics.Debug.WriteLine("[v0] ApplyRolePermissions - btnEdit.Enabled: " & If(btnEdit IsNot Nothing, btnEdit.Enabled.ToString(), "NULL"))
        System.Diagnostics.Debug.WriteLine("[v0] ApplyRolePermissions - btnDelete.Enabled: " & If(btnDelete IsNot Nothing, btnDelete.Enabled.ToString(), "NULL"))
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        ' Reload data with filters
        LoadPropertiesData()
        ' Reapply search if there's search text
        Dim searchNames As String() = {"pm_search", "propertymanagementsearchbar", "txtSearch", "txtbox_search", "admin_txtbox_search", "searchBox"}
        For Each nm As String In searchNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is TextBox Then
                Dim tb As TextBox = CType(found(0), TextBox)
                If Not String.IsNullOrWhiteSpace(tb.Text) Then
                    PropertySearch_TextChanged(tb, EventArgs.Empty)
                End If
                Exit For
            End If
        Next
    End Sub

    Private isSearchingProperties As Boolean = False

    Private Sub PropertySearch_TextChanged(sender As Object, e As EventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb Is Nothing Then Return
        ApplyPropertySearch(tb.Text)
    End Sub

    Private Sub ApplyPropertySearch(searchText As String)
        If originalData Is Nothing Then Return
        If isSearchingProperties Then Return
        isSearchingProperties = True

        Try
            Dim searchLower As String = If(String.IsNullOrWhiteSpace(searchText), String.Empty, searchText.Trim().ToLower())
            
            ' Get all filter values
            Dim statusCb As ComboBox = FindStatusComboBox()
            Dim statusFilter As String = If(statusCb IsNot Nothing AndAlso statusCb.SelectedIndex > 0, statusCb.SelectedItem.ToString(), String.Empty)
            
            ' Get category filter
            Dim categoryFilter As String = String.Empty
            Dim categoryNames() As String = {"pm_cbobx_categ", "categoryFilter", "cbCategory"}
            For Each nm As String In categoryNames
                Dim found() As Control = Me.Controls.Find(nm, True)
                If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                    Dim cb As ComboBox = CType(found(0), ComboBox)
                    If cb.SelectedIndex > 0 Then
                        categoryFilter = cb.SelectedItem.ToString()
                    End If
                    Exit For
                End If
            Next
            
            ' Get location filter
            Dim locationFilter As String = String.Empty
            Dim locationNames() As String = {"pm_cbobx_location", "locationFilter", "cbLocation"}
            For Each nm As String In locationNames
                Dim found() As Control = Me.Controls.Find(nm, True)
                If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                    Dim cb As ComboBox = CType(found(0), ComboBox)
                    If cb.SelectedIndex > 0 Then
                        locationFilter = cb.SelectedItem.ToString()
                    End If
                    Exit For
                End If
            Next
            
            ' Get condition filter
            Dim conditionFilter As String = String.Empty
            Dim conditionNames() As String = {"pm_cbobx_condition", "conditionFilter", "cbCondition"}
            For Each nm As String In conditionNames
                Dim found() As Control = Me.Controls.Find(nm, True)
                If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                    Dim cb As ComboBox = CType(found(0), ComboBox)
                    If cb.SelectedIndex > 0 Then
                        conditionFilter = cb.SelectedItem.ToString()
                    End If
                    Exit For
                End If
            Next

            Dim filteredRows As IEnumerable(Of DataRow) = originalData.AsEnumerable().Where(Function(row)
                                                                                                ' Apply status filter
                                                                                                If Not String.IsNullOrEmpty(statusFilter) Then
                                                                                                    Dim rowStatusValue As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), String.Empty)
                                                                                                    If Not String.Equals(rowStatusValue, statusFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                                                End If
                                                                                                
                                                                                                ' Apply category filter
                                                                                                If Not String.IsNullOrEmpty(categoryFilter) Then
                                                                                                    Dim rowCategoryValue As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString(), String.Empty)
                                                                                                    If Not String.Equals(rowCategoryValue, categoryFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                                                End If
                                                                                                
                                                                                                ' Apply location filter
                                                                                                If Not String.IsNullOrEmpty(locationFilter) Then
                                                                                                    Dim rowLocationValue As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), String.Empty)
                                                                                                    If Not String.Equals(rowLocationValue, locationFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                                                End If
                                                                                                
                                                                                                ' Apply condition filter
                                                                                                If Not String.IsNullOrEmpty(conditionFilter) Then
                                                                                                    Dim rowConditionValue As String = If(row.Table.Columns.Contains("condition") AndAlso Not IsDBNull(row("condition")), row("condition").ToString(), String.Empty)
                                                                                                    If Not String.Equals(rowConditionValue, conditionFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                                                End If

                                                                                                ' Apply search filter
                                                                                                If String.IsNullOrEmpty(searchLower) Then Return True

                                                                                                Dim itemName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString().ToLower(), String.Empty)
                                                                                                Dim category As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString().ToLower(), String.Empty)
                                                                                                Dim description As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString().ToLower(), String.Empty)
                                                                                                Dim assignedEmployee As String = If(row.Table.Columns.Contains("assignedEmployee") AndAlso Not IsDBNull(row("assignedEmployee")), row("assignedEmployee").ToString().ToLower(), String.Empty)
                                                                                                Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString().ToLower(), String.Empty)
                                                                                                Dim condition As String = If(row.Table.Columns.Contains("condition") AndAlso Not IsDBNull(row("condition")), row("condition").ToString().ToLower(), String.Empty)
                                                                                                Dim rowStatus As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString().ToLower(), String.Empty)
                                                                                                Dim propertyNum As String = If(row.Table.Columns.Contains("propertyNumber") AndAlso Not IsDBNull(row("propertyNumber")), row("propertyNumber").ToString().ToLower(), String.Empty)
                                                                                                Dim serialNum As String = If(row.Table.Columns.Contains("serialNumber") AndAlso Not IsDBNull(row("serialNumber")), row("serialNumber").ToString().ToLower(), String.Empty)

                                                                                                Return itemName.Contains(searchLower) OrElse category.Contains(searchLower) OrElse description.Contains(searchLower) OrElse assignedEmployee.Contains(searchLower) OrElse location.Contains(searchLower) OrElse condition.Contains(searchLower) OrElse rowStatus.Contains(searchLower) OrElse propertyNum.Contains(searchLower) OrElse serialNum.Contains(searchLower)
                                                                                            End Function)

            propertyManagementGrid.Rows.Clear()
            For Each row As DataRow In filteredRows
                ' Extract propertyId first
                Dim propID As Integer = 0
                If row.Table.Columns.Contains("propertyId") AndAlso Not IsDBNull(row("propertyId")) Then
                    Integer.TryParse(row("propertyId").ToString(), propID)
                End If

                ' Extract only required fields: propertyId, itemName, category, description, assignedTo, location, condition, status
                Dim itemName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString(), "")
                Dim category As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString(), "")
                Dim description As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString(), "")
                ' assignedTo should show employee name, not ID
                Dim assignedTo As String = If(row.Table.Columns.Contains("assignedEmployee") AndAlso Not IsDBNull(row("assignedEmployee")), row("assignedEmployee").ToString(), If(row.Table.Columns.Contains("assignedTo") AndAlso Not IsDBNull(row("assignedTo")), row("assignedTo").ToString(), ""))
                Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), "")
                Dim condition As String = If(row.Table.Columns.Contains("condition") AndAlso Not IsDBNull(row("condition")), row("condition").ToString(), "")
                Dim status As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), "")

                ' Add row in correct column order matching Designer (all columns, but some will be hidden)
                Dim rowIndex As Integer = propertyManagementGrid.Rows.Add(
                    propID.ToString(),        ' propertyId
                    itemName,                ' itemName
                    category,                ' category
                    description,             ' description
                    "",                      ' unitOfMeasure (hidden)
                    "",                      ' propertyNumber (hidden)
                    "",                      ' serialNumber (hidden)
                    "",                      ' acquisitionDate (hidden)
                    "",                      ' acquisitionCost (hidden)
                    "",                      ' totalCost (hidden)
                    "",                      ' sourceOfFunds (hidden)
                    assignedTo,              ' assignedTo
                    "",                      ' departmentId (hidden)
                    location,                ' location
                    condition,               ' condition
                    status                   ' status
                )
                propertyManagementGrid.Rows(rowIndex).Tag = propID
            Next

            If ttlpropertymanagement IsNot Nothing Then
                ttlpropertymanagement.Text = filteredRows.Count().ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error searching properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isSearchingProperties = False
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_PropertyManagement - btnAdd_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_PropertyManagement - IsSuperAdmin: " & SessionContext.IsSuperAdmin())
        System.Diagnostics.Debug.WriteLine("[v0] UC_PropertyManagement - Opening AddProperty control")
        
        ' Load AddProperty UserControl in parent dashboard
        Dim parentForm = Me.FindForm()
        If TypeOf parentForm Is SADashboard Then
            Dim dashboard = CType(parentForm, SADashboard)
            dashboard.LoadUserControl(New AddProperty())
        ElseIf TypeOf parentForm Is AdminDashboard Then
            Dim dashboard = CType(parentForm, AdminDashboard)
            dashboard.LoadUserControl(New AddProperty())
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_PropertyManagement - btnEdit_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_PropertyManagement - Selected Rows: " & If(propertyManagementGrid IsNot Nothing, propertyManagementGrid.SelectedRows.Count, 0))
        
        ' Super Admin bypasses all restrictions
        If propertyManagementGrid Is Nothing OrElse propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = propertyManagementGrid.SelectedRows(0)

        ' Validate property ID from Tag
        Dim propertyID As Integer
        If row.Tag Is Nothing OrElse Not Integer.TryParse(row.Tag.ToString(), propertyID) Then
            MessageBox.Show("Invalid Property ID.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Create the EDIT USER CONTROL
        Dim editForm As New EditPropertyManagement()

        ' Load selected data into edit form using correct column names from DataGridView
        ' Use the originalData DataTable to get full property details
        Dim propertyRow As DataRow = Nothing
        If originalData IsNot Nothing Then
            Dim rows() As DataRow = originalData.Select("propertyId = " & propertyID)
            If rows.Length > 0 Then
                propertyRow = rows(0)
            End If
        End If

        ' If we have the property row, use it; otherwise use DataGridView cells
        If propertyRow IsNot Nothing Then
            ' Read values defensively using helpers that tolerate multiple column name variants and cultures
            Dim propName As String = If(propertyRow.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(propertyRow("itemName")), propertyRow("itemName").ToString(), If(propertyManagementGrid.Columns.Contains("itemName") AndAlso row.Cells("itemName").Value IsNot Nothing, row.Cells("itemName").Value.ToString(), ""))
            Dim propCategory As String = If(propertyRow.Table.Columns.Contains("category") AndAlso Not IsDBNull(propertyRow("category")), propertyRow("category").ToString(), If(propertyManagementGrid.Columns.Contains("category") AndAlso row.Cells("category").Value IsNot Nothing, row.Cells("category").Value.ToString(), ""))
            Dim propSerial As String = If(propertyRow.Table.Columns.Contains("serialNumber") AndAlso Not IsDBNull(propertyRow("serialNumber")), propertyRow("serialNumber").ToString(), If(propertyManagementGrid.Columns.Contains("serialNumber") AndAlso row.Cells("serialNumber").Value IsNot Nothing, row.Cells("serialNumber").Value.ToString(), ""))
            Dim propSupplier As String = If(propertyRow.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(propertyRow("supplier")), propertyRow("supplier").ToString(), "")
            Dim propCondition As String = If(propertyRow.Table.Columns.Contains("condition") AndAlso Not IsDBNull(propertyRow("condition")), propertyRow("condition").ToString(), If(propertyManagementGrid.Columns.Contains("condition") AndAlso row.Cells("condition").Value IsNot Nothing, row.Cells("condition").Value.ToString(), ""))

            Dim cost As Decimal = ReadDecimalFromRow(propertyRow, New String() {"acquisitionCost", "acquisition_cost"})
            Dim datePurchased As Date = ParseDateCell(If(propertyRow.Table.Columns.Contains("acquisitionDate"), propertyRow("acquisitionDate"), If(propertyRow.Table.Columns.Contains("acquisition_date"), propertyRow("acquisition_date"), Nothing)), Date.Today)
            Dim warrantyExp As Date = Date.Today.AddYears(1)
            Dim assignedEmployee As String = If(propertyRow.Table.Columns.Contains("assignedTo") AndAlso Not IsDBNull(propertyRow("assignedTo")), propertyRow("assignedTo").ToString(), If(propertyManagementGrid.Columns.Contains("assignedTo") AndAlso row.Cells("assignedTo").Value IsNot Nothing, row.Cells("assignedTo").Value.ToString(), ""))
            Dim assignedDepartment As String = If(propertyRow.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(propertyRow("departmentId")), propertyRow("departmentId").ToString(), If(propertyManagementGrid.Columns.Contains("department") AndAlso row.Cells("department").Value IsNot Nothing, row.Cells("department").Value.ToString(), ""))
            Dim loc As String = If(propertyRow.Table.Columns.Contains("location") AndAlso Not IsDBNull(propertyRow("location")), propertyRow("location").ToString(), If(propertyManagementGrid.Columns.Contains("location") AndAlso row.Cells("location").Value IsNot Nothing, row.Cells("location").Value.ToString(), ""))
            Dim st As String = If(propertyRow.Table.Columns.Contains("status") AndAlso Not IsDBNull(propertyRow("status")), propertyRow("status").ToString(), If(propertyManagementGrid.Columns.Contains("status") AndAlso row.Cells("status").Value IsNot Nothing, row.Cells("status").Value.ToString(), ""))
            Dim createdAt As Date = ParseDateCell(If(propertyRow.Table.Columns.Contains("createdAt"), propertyRow("createdAt"), If(propertyRow.Table.Columns.Contains("created_at"), propertyRow("created_at"), Nothing)), Date.Now)
            Dim updatedAt As Date = ParseDateCell(If(propertyRow.Table.Columns.Contains("updatedAt"), propertyRow("updatedAt"), If(propertyRow.Table.Columns.Contains("updated_at"), propertyRow("updated_at"), Nothing)), Date.Now)

            ' Get additional fields from data
            Dim description As String = If(propertyRow.Table.Columns.Contains("description") AndAlso Not IsDBNull(propertyRow("description")), propertyRow("description").ToString(), "")
            Dim unitOfMeasure As String = If(propertyRow.Table.Columns.Contains("unitOfMeasure") AndAlso Not IsDBNull(propertyRow("unitOfMeasure")), propertyRow("unitOfMeasure").ToString(), "")
            Dim propertyNumber As String = If(propertyRow.Table.Columns.Contains("propertyNumber") AndAlso Not IsDBNull(propertyRow("propertyNumber")), propertyRow("propertyNumber").ToString(), "")
            Dim internalCodes As String = If(propertyRow.Table.Columns.Contains("internalCodes") AndAlso Not IsDBNull(propertyRow("internalCodes")), propertyRow("internalCodes").ToString(), "")
            Dim totalCost As Decimal = If(propertyRow.Table.Columns.Contains("totalCost") AndAlso Not IsDBNull(propertyRow("totalCost")), Convert.ToDecimal(propertyRow("totalCost")), cost)
            Dim sourceOfFunds As String = If(propertyRow.Table.Columns.Contains("sourceOfFunds") AndAlso Not IsDBNull(propertyRow("sourceOfFunds")), propertyRow("sourceOfFunds").ToString(), "")
            
            ' Get departmentId
            Dim departmentIDValueForEdit As Integer? = Nothing
            If propertyRow.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(propertyRow("departmentId")) Then
                Dim tempDeptID As Integer
                If Integer.TryParse(propertyRow("departmentId").ToString(), tempDeptID) Then
                    departmentIDValueForEdit = tempDeptID
                End If
            End If
            
            ' Get assignedTo userId (not the employee name)
            Dim assignedToUserId As Integer? = Nothing
            If propertyRow.Table.Columns.Contains("assignedTo") AndAlso Not IsDBNull(propertyRow("assignedTo")) Then
                Dim tempUserId As Integer
                If Integer.TryParse(propertyRow("assignedTo").ToString(), tempUserId) Then
                    assignedToUserId = tempUserId
                End If
            End If
            
            editForm.LoadPropertyData(
                propertyID,
                propName,
                propCategory,
                propSerial,
                description,
                unitOfMeasure,
                propCondition,
                cost,
                datePurchased,
                departmentIDValueForEdit,
                loc,
                st,
                propertyNumber,
                internalCodes,
                totalCost,
                sourceOfFunds,
                assignedToUserId
            )
        Else
            ' Fallback to DataGridView cells if originalData is not available
            Dim propName As String = If(propertyManagementGrid.Columns.Contains("itemName") AndAlso row.Cells("itemName").Value IsNot Nothing, row.Cells("itemName").Value.ToString(), "")
            Dim propCategory As String = If(propertyManagementGrid.Columns.Contains("category") AndAlso row.Cells("category").Value IsNot Nothing, row.Cells("category").Value.ToString(), "")
            Dim propSerial As String = If(propertyManagementGrid.Columns.Contains("serialNumber") AndAlso row.Cells("serialNumber").Value IsNot Nothing, row.Cells("serialNumber").Value.ToString(), "")
            Dim propCondition As String = If(propertyManagementGrid.Columns.Contains("condition") AndAlso row.Cells("condition").Value IsNot Nothing, row.Cells("condition").Value.ToString(), "")
            Dim cost As Decimal = ReadDecimalFromGridCell(row, "acquisitionCost")
            Dim datePurchased As Date = ParseDateCell(GetCellValueOrNothing(row, "acquisitionDate"), Date.Today)
            Dim warrantyExp As Date = Date.Today.AddYears(1)
            Dim assignedEmployee As String = If(propertyManagementGrid.Columns.Contains("assignedTo") AndAlso row.Cells("assignedTo").Value IsNot Nothing, row.Cells("assignedTo").Value.ToString(), "")
            Dim assignedDepartment As String = If(propertyManagementGrid.Columns.Contains("department") AndAlso row.Cells("department").Value IsNot Nothing, row.Cells("department").Value.ToString(), "")
            Dim loc As String = If(propertyManagementGrid.Columns.Contains("location") AndAlso row.Cells("location").Value IsNot Nothing, row.Cells("location").Value.ToString(), "")
            Dim st As String = If(propertyManagementGrid.Columns.Contains("status") AndAlso row.Cells("status").Value IsNot Nothing, row.Cells("status").Value.ToString(), "")

            ' Get additional fields from grid
            Dim description As String = If(propertyManagementGrid.Columns.Contains("description") AndAlso row.Cells("description").Value IsNot Nothing, row.Cells("description").Value.ToString(), "")
            Dim unitOfMeasure As String = If(propertyManagementGrid.Columns.Contains("unitOfMeasure") AndAlso row.Cells("unitOfMeasure").Value IsNot Nothing, row.Cells("unitOfMeasure").Value.ToString(), "")
            Dim propertyNumber As String = If(propertyManagementGrid.Columns.Contains("propertyNumber") AndAlso row.Cells("propertyNumber").Value IsNot Nothing, row.Cells("propertyNumber").Value.ToString(), "")
            Dim internalCodes As String = If(propertyManagementGrid.Columns.Contains("internalCodes") AndAlso row.Cells("internalCodes").Value IsNot Nothing, row.Cells("internalCodes").Value.ToString(), "")
            Dim totalCost As Decimal = If(propertyManagementGrid.Columns.Contains("totalCost") AndAlso row.Cells("totalCost").Value IsNot Nothing, Convert.ToDecimal(row.Cells("totalCost").Value), cost)
            Dim sourceOfFunds As String = If(propertyManagementGrid.Columns.Contains("sourceOfFunds") AndAlso row.Cells("sourceOfFunds").Value IsNot Nothing, row.Cells("sourceOfFunds").Value.ToString(), "")
            Dim departmentIDValue As Integer? = Nothing
            
            editForm.LoadPropertyData(
                propertyID,
                propName,
                propCategory,
                propSerial,
                description,
                unitOfMeasure,
                propCondition,
                cost,
                datePurchased,
                departmentIDValue,
                loc,
                st,
                propertyNumber,
                internalCodes,
                totalCost,
                sourceOfFunds
            )
        End If

        ' LOAD THE USER CONTROL TO DASHBOARD - Check SADashboard first
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            saDashboard.LoadUserControl(editForm)
            System.Diagnostics.Debug.WriteLine("[v0] UC_PropertyManagement - EditProperty loaded into SADashboard")
            Return
        End If
        
        Dim superAdminDashboard = TryCast(Me.ParentForm, SADashboard)
        If superAdminDashboard IsNot Nothing Then
            superAdminDashboard.LoadUserControl(editForm)
            Return
        End If

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(editForm)
        Else
            MessageBox.Show("Error: Dashboard not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_PropertyManagement - btnDelete_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_PropertyManagement - Selected Rows: " & propertyManagementGrid.SelectedRows.Count)
        
        ' Super Admin bypasses all restrictions

        ' Check if a row is selected
        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
        If selectedRow.Tag Is Nothing Then
            MessageBox.Show("Invalid property selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim propertyIDStr As String = selectedRow.Tag.ToString()
        ' Try multiple possible column names for property name
        Dim propertyName As String = "Unknown"
        If propertyManagementGrid.Columns.Contains("itemName") AndAlso selectedRow.Cells("itemName").Value IsNot Nothing Then
            propertyName = selectedRow.Cells("itemName").Value.ToString()
        ElseIf propertyManagementGrid.Columns.Contains("ItemName") AndAlso selectedRow.Cells("ItemName").Value IsNot Nothing Then
            propertyName = selectedRow.Cells("ItemName").Value.ToString()
        ElseIf selectedRow.Cells.Count > 1 AndAlso selectedRow.Cells("itemName").Value IsNot Nothing Then
            propertyName = selectedRow.Cells("itemName").Value.ToString()
        End If

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
                Dim success As Boolean = modDB.DeleteProperty(propertyID)
                If success Then
                    LoadPropertiesData() ' Refresh table
                    MessageBox.Show("Property deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting property: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function ParseDateCell(cellValue As Object, Optional fallback As Date? = Nothing) As Date
        Dim parsed As Date
        If cellValue IsNot Nothing Then
            Dim stringValue As String = cellValue.ToString().Trim()
            If Not String.IsNullOrEmpty(stringValue) AndAlso Date.TryParse(stringValue, parsed) Then
                Return parsed
            End If
            ' If the object is already a Date type, return it
            If TypeOf cellValue Is Date Then
                Return CType(cellValue, Date)
            End If
        End If

        Return If(fallback.HasValue, fallback.Value, Date.Today)
    End Function

    Private Function GetCellValueOrNothing(row As DataGridViewRow, columnName As String) As Object
        If propertyManagementGrid.Columns.Contains(columnName) Then
            Return row.Cells(columnName).Value
        End If
        Return Nothing
    End Function

    Private Sub propertyManagementGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellClick
        ' Check if colMenu column exists before accessing it
        If e.RowIndex >= 0 AndAlso propertyManagementGrid.Columns.Contains("colMenu") AndAlso e.ColumnIndex = propertyManagementGrid.Columns("colMenu").Index Then
            If cmsActions IsNot Nothing Then
                cmsActions.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub generatePropertyCard_Click(sender As Object, e As EventArgs) Handles generatePropertyCard.Click
        ' This button generates property codes for existing properties that don't have them
        Try
            Dim result As DialogResult = MessageBox.Show(
                "This will generate property codes (PROP-XXXXXX) for all properties that don't have them. Continue?",
                "Generate Property Codes",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

            If result = DialogResult.Yes Then
                Dim countGenerated As Integer = modDB.GeneratePropertyCodesForExisting()
                If countGenerated > 0 Then
                    MessageBox.Show($"Successfully generated property codes for {countGenerated} property/properties.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' Refresh the grid to show new codes
                    LoadPropertiesData()
                Else
                    MessageBox.Show("All properties already have property codes, or no properties were found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error generating property codes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub propertyManagementGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellContentClick

    End Sub

    Private Sub mnuAssign_Click(sender As Object, e As EventArgs) _
    Handles msuAssign.Click

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
        ' Open Property Issuance for selected property
        If propertyManagementGrid Is Nothing OrElse propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
            Dim dt As DataTable = TryCast(propertyManagementGrid.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)

            ' Get property ID
            Dim propertyID As Integer = 0
            If dt.Columns.Contains("propertyId") AndAlso Not IsDBNull(dataRow("propertyId")) Then
                propertyID = Convert.ToInt32(dataRow("propertyId"))
            ElseIf selectedRow.Tag IsNot Nothing AndAlso Integer.TryParse(selectedRow.Tag.ToString(), propertyID) Then
                ' Use Tag if available
            Else
                MessageBox.Show("Unable to identify property.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If propertyID > 0 Then
                Dim propertyAcknowledgement As New PropertyAcknowledgementReceipt(propertyID)
                propertyAcknowledgement.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening property slip: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ReadDecimalFromRow(row As DataRow, colNames As String()) As Decimal
        For Each n In colNames
            If row.Table.Columns.Contains(n) AndAlso Not IsDBNull(row(n)) Then
                Dim obj = row(n)
                If TypeOf obj Is Decimal OrElse TypeOf obj Is Double OrElse TypeOf obj Is Single Then
                    Return Convert.ToDecimal(obj)
                End If
                Dim s = obj.ToString().Trim()
                Dim d As Decimal
                If Decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, d) Then Return d
                If Decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, d) Then Return d
            End If
        Next
        Return 0D
    End Function

    Private Function ReadDecimalFromGridCell(row As DataGridViewRow, columnName As String) As Decimal
        If row Is Nothing Then Return 0D
        If Not propertyManagementGrid.Columns.Contains(columnName) Then
            ' Try common alternate column name used in the UI (acqCost)
            If propertyManagementGrid.Columns.Contains("acqCost") Then columnName = "acqCost" Else Return 0D
        End If

        Dim obj = row.Cells(columnName).Value
        If obj Is Nothing OrElse IsDBNull(obj) Then Return 0D
        If TypeOf obj Is Decimal OrElse TypeOf obj Is Double OrElse TypeOf obj Is Single Then
            Return Convert.ToDecimal(obj)
        End If

        Dim s = obj.ToString().Trim()
        Dim d As Decimal
        If Decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, d) Then Return d
        If Decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, d) Then Return d

        Return 0D
    End Function

    Private Sub issuePropertySlip_Click(sender As Object, e As EventArgs) Handles issuePropertySlip.Click
        If propertyManagementGrid Is Nothing OrElse propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
            
            ' Get property ID - try multiple methods
            Dim propertyID As Integer = 0
            Dim debugInfo As String = ""
            
            ' Method 1: Try Tag (stored when rows are manually added)
            If selectedRow.Tag IsNot Nothing Then
                debugInfo &= "Tag found: " & selectedRow.Tag.ToString() & "; "
                If Integer.TryParse(selectedRow.Tag.ToString(), propertyID) AndAlso propertyID > 0 Then
                    debugInfo &= "PropertyID from Tag: " & propertyID.ToString()
                    System.Diagnostics.Debug.WriteLine("[IssuePropertySlip] " & debugInfo)
                End If
            End If
            
            ' Method 2: Try cell value directly (propertyId column)
            If propertyID <= 0 AndAlso propertyManagementGrid.Columns.Contains("propertyId") Then
                Dim cellValue As Object = selectedRow.Cells("propertyId").Value
                debugInfo &= "Cell(propertyId) value: " & If(cellValue IsNot Nothing, cellValue.ToString(), "Nothing") & "; "
                If cellValue IsNot Nothing AndAlso Not IsDBNull(cellValue) Then
                    If Integer.TryParse(cellValue.ToString(), propertyID) AndAlso propertyID > 0 Then
                        debugInfo &= "PropertyID from cell: " & propertyID.ToString()
                        System.Diagnostics.Debug.WriteLine("[IssuePropertySlip] " & debugInfo)
                    End If
                End If
            End If
            
            ' Method 3: Try first cell (if propertyId is first column)
            If propertyID <= 0 AndAlso selectedRow.Cells.Count > 0 Then
                Dim firstCell As Object = selectedRow.Cells(0).Value
                debugInfo &= "Cell(0) value: " & If(firstCell IsNot Nothing, firstCell.ToString(), "Nothing") & "; "
                If firstCell IsNot Nothing AndAlso Not IsDBNull(firstCell) Then
                    If Integer.TryParse(firstCell.ToString(), propertyID) AndAlso propertyID > 0 Then
                        debugInfo &= "PropertyID from first cell: " & propertyID.ToString()
                        System.Diagnostics.Debug.WriteLine("[IssuePropertySlip] " & debugInfo)
                    End If
                End If
            End If
            
            ' Method 4: Try DataSource binding (if using data binding)
            If propertyID <= 0 Then
                Dim dt As DataTable = TryCast(propertyManagementGrid.DataSource, DataTable)
                If dt IsNot Nothing AndAlso selectedRow.Index >= 0 AndAlso selectedRow.Index < dt.Rows.Count Then
                    Dim dataRow As DataRow = dt.Rows(selectedRow.Index)
                    If dt.Columns.Contains("propertyId") AndAlso Not IsDBNull(dataRow("propertyId")) Then
                        If Integer.TryParse(dataRow("propertyId").ToString(), propertyID) AndAlso propertyID > 0 Then
                            debugInfo &= "PropertyID from DataSource: " & propertyID.ToString()
                            System.Diagnostics.Debug.WriteLine("[IssuePropertySlip] " & debugInfo)
                        End If
                    End If
                End If
            End If

            If propertyID <= 0 Then
                System.Diagnostics.Debug.WriteLine("[IssuePropertySlip] Failed to get PropertyID. Debug info: " & debugInfo)
                MessageBox.Show("Unable to identify property. Please try selecting the property again." & Environment.NewLine & "Debug: " & debugInfo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            System.Diagnostics.Debug.WriteLine("[IssuePropertySlip] Opening PropertyAcknowledgementReceipt with PropertyID: " & propertyID.ToString())

            ' Get propertyNumber if available
            Dim propNumber As String = ""
            If propertyManagementGrid.Columns.Contains("propertyNumber") Then
                Dim cellVal = selectedRow.Cells("propertyNumber").Value
                If cellVal IsNot Nothing AndAlso Not IsDBNull(cellVal) Then
                    propNumber = cellVal.ToString()
                End If
            End If

            ' Verify property exists in originalData before opening
            Dim propertyExists As Boolean = False
            If originalData IsNot Nothing Then
                Dim matchingRows = originalData.AsEnumerable().Where(Function(r)
                    If r.Table.Columns.Contains("propertyId") AndAlso Not IsDBNull(r("propertyId")) Then
                        Dim id As Integer = 0
                        If Integer.TryParse(r("propertyId").ToString(), id) Then
                            Return id = propertyID
                        End If
                    End If
                    Return False
                End Function)
                propertyExists = matchingRows.Any()
            End If
            
            If Not propertyExists Then
                Dim result As DialogResult = MessageBox.Show(
                    "Property ID " & propertyID.ToString() & " may not exist in the database." & Environment.NewLine &
                    "Do you want to continue with fallback data?", 
                    "Property Not Found", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning)
                If result = DialogResult.No Then
                    Return
                End If
            End If
            
            ' Open Property Issuance Slip with property data
            Dim propertyAcknowledgement As New PropertyAcknowledgementReceipt(propertyID)
            propertyAcknowledgement.ShowDialog()
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[IssuePropertySlip] Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show("Error opening property slip: " & ex.Message & Environment.NewLine & "Stack Trace: " & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub propertyManagementGrid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellDoubleClick
        ' Open Property Issuance when double-clicking a property row
        If e.RowIndex < 0 Then Return

        Try
            Dim selectedRow As DataGridViewRow = propertyManagementGrid.Rows(e.RowIndex)
            
            ' Get property ID - try multiple methods
            Dim propertyID As Integer = 0
            
            ' Method 1: Try Tag (stored when rows are manually added)
            If selectedRow.Tag IsNot Nothing AndAlso Integer.TryParse(selectedRow.Tag.ToString(), propertyID) AndAlso propertyID > 0 Then
                ' Success - use this propertyID
            Else
                ' Method 2: Try DataSource binding
                Dim dt As DataTable = TryCast(propertyManagementGrid.DataSource, DataTable)
                If dt IsNot Nothing AndAlso e.RowIndex >= 0 AndAlso e.RowIndex < dt.Rows.Count Then
                    Dim dataRow As DataRow = dt.Rows(e.RowIndex)
                    If dt.Columns.Contains("propertyId") AndAlso Not IsDBNull(dataRow("propertyId")) Then
                        Integer.TryParse(dataRow("propertyId").ToString(), propertyID)
                    End If
                End If
                
                ' Method 3: Try cell value directly
                If propertyID <= 0 AndAlso propertyManagementGrid.Columns.Contains("propertyId") Then
                    Dim cellValue As Object = selectedRow.Cells("propertyId").Value
                    If cellValue IsNot Nothing AndAlso Not IsDBNull(cellValue) Then
                        Integer.TryParse(cellValue.ToString(), propertyID)
                    End If
                End If
                
                ' Method 4: Try first visible cell if it's propertyId column
                If propertyID <= 0 AndAlso selectedRow.Cells.Count > 0 Then
                    Dim firstCell As Object = selectedRow.Cells(0).Value
                    If firstCell IsNot Nothing AndAlso Not IsDBNull(firstCell) Then
                        Integer.TryParse(firstCell.ToString(), propertyID)
                    End If
                End If
            End If

            If propertyID > 0 Then
                ' Get propertyNumber if available
                Dim propNumber As String = ""
                If propertyManagementGrid.Columns.Contains("propertyNumber") Then
                    Dim cellVal = selectedRow.Cells("propertyNumber").Value
                    If cellVal IsNot Nothing AndAlso Not IsDBNull(cellVal) Then
                        propNumber = cellVal.ToString()
                    End If
                End If

                ' Open Property Issuance Slip with property data
                Dim propertyAcknowledgement As New PropertyAcknowledgementReceipt(propertyID)
                propertyAcknowledgement.ShowDialog()
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error opening property slip on double-click: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSummary_Click(sender As Object, e As EventArgs) Handles btnSummary.Click
        Try
            Dim summaryForm As New PropertySummaryReport()
            summaryForm.StartPosition = FormStartPosition.CenterScreen
            summaryForm.ShowDialog()   ' Recommended for summary/report forms
            ' summaryForm.Show()       ' Use this if you want non-modal
        Catch ex As Exception
            MessageBox.Show("Unable to open Property Request Summary: " & ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ttlpropertymanagement_Click(sender As Object, e As EventArgs) Handles ttlpropertymanagement.Click

    End Sub
End Class