Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Linq
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

        ' Column alignment
        For Each col As DataGridViewColumn In propertyManagementGrid.Columns
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        ' Auto size
        propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

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

    Private Sub InitializeFilters()
        ' Populate status filter
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"Active", "For Disposal", "Lost", "Borrowed"})
        pm_cbobx_status.SelectedIndex = 0

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
                Dim categories As DataTable = DatabaseConnection.GetCategories("property")
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
                Dim locations As DataTable = DatabaseConnection.GetLocations()
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

        ' Wire up filter change events
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
    End Sub

    Public Sub LoadPropertiesData()
        Try
            propertyManagementGrid.Rows.Clear()
            Dim categoryFilter As String = ""
            Dim statusFilter As String = ""
            Dim locationFilter As String = ""
            Dim conditionFilter As String = ""

            ' Get status filter from dropdown
            If pm_cbobx_status.SelectedIndex > 0 Then
                statusFilter = pm_cbobx_status.SelectedItem.ToString()
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

            Dim dt As DataTable = DatabaseConnection.GetAllProperties(Nothing, conditionFilter, categoryFilter, Nothing, statusFilter)
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

            ' Show only required columns: propertyId, itemName, category, description, assignedTo, location, condition, status
            If propertyManagementGrid.Columns.Contains("propertyId") Then propertyManagementGrid.Columns("propertyId").Visible = True
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
                    ' Store propertyId in row Tag for easy access
                    propertyManagementGrid.Rows(rowIndex).Tag = propID
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
        Catch ex As Exception
            MessageBox.Show("Error loading properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine("[v0] Load Properties Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
            If ttlpropertymanagement IsNot Nothing Then
                ttlpropertymanagement.Text = "0"
            End If
        End Try
    End Sub

    Private Sub propertyManagementGrid_SelectionChanged(sender As Object, e As EventArgs)
        If propertyManagementGrid.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
            If selectedRow.Tag IsNot Nothing Then
                If Integer.TryParse(selectedRow.Tag.ToString(), selectedPropertyID) Then
                    ' Row selected, enable Edit and Delete buttons
                End If
            End If
        End If
    End Sub




    Private Sub ApplyRolePermissions()
        ' Super Admin, Admin, and Custodian have full access - all buttons enabled
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If btnAdd IsNot Nothing Then btnAdd.Enabled = hasFullAccess
        If btnEdit IsNot Nothing Then btnEdit.Enabled = hasFullAccess
        If btnDelete IsNot Nothing Then btnDelete.Enabled = hasFullAccess
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
            Dim statusFilter As String = If(pm_cbobx_status.SelectedIndex > 0, pm_cbobx_status.SelectedItem.ToString(), String.Empty)

            Dim filtered = originalData.AsEnumerable().Where(Function(row)
                ' Apply status filter
                If Not String.IsNullOrEmpty(statusFilter) Then
                    Dim status As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString().ToLower(), String.Empty)
                    If status <> statusFilter.ToLower() Then Return False
                End If

                ' Apply search filter
                If String.IsNullOrEmpty(searchLower) Then Return True

                Dim itemName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString().ToLower(), String.Empty)
                Dim category As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString().ToLower(), String.Empty)
                Dim description As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString().ToLower(), String.Empty)
                Dim assignedEmployee As String = If(row.Table.Columns.Contains("assignedEmployee") AndAlso Not IsDBNull(row("assignedEmployee")), row("assignedEmployee").ToString().ToLower(), String.Empty)
                Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString().ToLower(), String.Empty)
                Dim condition As String = If(row.Table.Columns.Contains("condition") AndAlso Not IsDBNull(row("condition")), row("condition").ToString().ToLower(), String.Empty)
                Dim status As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString().ToLower(), String.Empty)

                Return itemName.Contains(searchLower) OrElse category.Contains(searchLower) OrElse description.Contains(searchLower) OrElse assignedEmployee.Contains(searchLower) OrElse location.Contains(searchLower) OrElse condition.Contains(searchLower) OrElse status.Contains(searchLower)
            End Function)

            propertyManagementGrid.Rows.Clear()
            For Each row As DataRow In filtered
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
                ttlpropertymanagement.Text = filtered.Count().ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error searching properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isSearchingProperties = False
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Super Admin bypasses all restrictions

        Dim addRequest As New AddProperty()
        addRequest.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addRequest)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Super Admin bypasses all restrictions


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

            editForm.LoadPropertyData(
                propertyID,
                propName,
                propCategory,
                propSerial,
                propSupplier,
                propCondition,
                cost,
                datePurchased,
                warrantyExp,
                assignedEmployee,
                assignedDepartment,
                loc,
                st,
                createdAt,
                updatedAt
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

            editForm.LoadPropertyData(
                propertyID,
                propName,
                propCategory,
                propSerial,
                "", ' Supplier not in grid
                propCondition,
                cost,
                datePurchased,
                warrantyExp,
                assignedEmployee,
                assignedDepartment,
                loc,
                st,
                Date.Now,
                Date.Now
            )
        End If

        ' LOAD THE USER CONTROL TO DASHBOARD
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(editForm)
        Else
            MessageBox.Show("Error: Dashboard not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
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
                Dim countGenerated As Integer = DatabaseConnection.GeneratePropertyCodesForExisting()
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

        MessageBox.Show("Print PAR/ICS clicked!")
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
End Class