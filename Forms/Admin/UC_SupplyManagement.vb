Imports System
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class UC_SupplyManagement
    Inherits UserControl

    Private originalData As DataTable
    Private selectedSupplyID As Integer = -1
    Private canModifySupplies As Boolean = False
    Private isSearching As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    ' Ensure role-based UI and filters are initialized
    Private Sub ApplyRolePermissions()
        ' SUPER ADMIN HAS UNRESTRICTED ACCESS - NO LIMITATIONS
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If btnAdd IsNot Nothing Then btnAdd.Enabled = hasFullAccess
        If btnEdit IsNot Nothing Then btnEdit.Enabled = hasFullAccess
        If btnDelete IsNot Nothing Then btnDelete.Enabled = hasFullAccess
        
        ' Debug output
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - IsSuperAdmin: " & SessionContext.IsSuperAdmin())
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - hasFullAccess: " & hasFullAccess)
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - All buttons enabled: " & hasFullAccess)
        ' btnRefresh may not be present in this designer - avoid referencing undefined controls
    End Sub

    Private Sub InitializeFilters()
        ' Initialize category and status comboboxes if present
        Try
            If pm_cbobx_categ IsNot Nothing Then
                pm_cbobx_categ.Items.Clear()
                pm_cbobx_categ.Items.Add("All")

                ' Load categories from database - get unique categories from supplies table
                Try
                    Dim categories As DataTable = DatabaseConnection.GetCategories("supply")
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
                            If Not String.IsNullOrEmpty(categoryName) AndAlso Not pm_cbobx_categ.Items.Contains(categoryName) Then
                                pm_cbobx_categ.Items.Add(categoryName)
                            End If
                        Next
                    End If
                    ' Also get unique categories directly from supplies table as fallback
                    If pm_cbobx_categ.Items.Count <= 1 Then ' Only "All" item
                        Try
                            Dim conn = DatabaseConnection.GetConnection()
                            If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                                Dim query As String = "SELECT DISTINCT category FROM supplies WHERE category IS NOT NULL AND category != '' ORDER BY category"
                                Using cmd As New MySql.Data.MySqlClient.MySqlCommand(query, conn)
                                    Using reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                                        While reader.Read()
                                            Dim catName As String = reader("category").ToString()
                                            If Not String.IsNullOrEmpty(catName) AndAlso Not pm_cbobx_categ.Items.Contains(catName) Then
                                                pm_cbobx_categ.Items.Add(catName)
                                            End If
                                        End While
                                    End Using
                                End Using
                                conn.Close()
                            End If
                        Catch
                            ' Fallback to common categories
                            If pm_cbobx_categ.Items.Count <= 1 Then
                                pm_cbobx_categ.Items.AddRange(New String() {"Office Supplies", "Cleaning Materials", "Medical Supplies", "IT Supplies", "Stationery", "Electronics", "Furniture", "Equipment"})
                            End If
                        End Try
                    End If
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error loading categories: " & ex.Message)
                    ' Fallback to common categories
                    pm_cbobx_categ.Items.AddRange(New String() {"Office Supplies", "Cleaning Materials", "Medical Supplies", "IT Supplies", "Stationery", "Electronics", "Furniture", "Equipment"})
                End Try

                pm_cbobx_categ.SelectedIndex = 0
                AddHandler pm_cbobx_categ.SelectedIndexChanged, AddressOf Filter_Changed
            End If

            If pm_cbobx_status IsNot Nothing Then
                pm_cbobx_status.Items.Clear()
                pm_cbobx_status.Items.Add("All Status")
                ' Match database enum values: 'Available', 'Low Stock', 'Out of Stock'
                pm_cbobx_status.Items.AddRange(New String() {"Available", "Low Stock", "Out of Stock"})
                pm_cbobx_status.SelectedIndex = 0
                AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] InitializeFilters Error: " & ex.Message)
        End Try
    End Sub

    Private Sub UC_SupplyManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Add null check for PictureBox2 to prevent crashes
        Try
            If PictureBox2 Is Nothing Then
                System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - PictureBox2 is Nothing, skipping initialization")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - Error checking PictureBox2: " & ex.Message)
        End Try

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

        ' Wire up search textbox if present (try common names)
        Dim searchNames As String() = {"supplymanagementsearchbar", "pm_search", "pm_searchbar", "supplysearch", "txtSearch", "txtbox_search", "searchBox", "admin_txtbox_search"}
        For Each nm As String In searchNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is TextBox Then
                Dim tb As TextBox = CType(found(0), TextBox)
                RemoveHandler tb.TextChanged, AddressOf SupplySearch_TextChanged
                AddHandler tb.TextChanged, AddressOf SupplySearch_TextChanged
                System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - Wired search handler to: " & nm)
                Exit For
            End If
        Next
        
        ' Also try direct access if control exists
        If supplymanagementsearchbar IsNot Nothing Then
            RemoveHandler supplymanagementsearchbar.TextChanged, AddressOf SupplySearch_TextChanged
            AddHandler supplymanagementsearchbar.TextChanged, AddressOf SupplySearch_TextChanged
            System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - Wired search handler directly to supplymanagementsearchbar")
        End If
    End Sub

    ' Added method to load supplies from database
    Public Sub LoadSuppliesData()
        Try
            pm_table.Rows.Clear()
            Dim categoryFilter As String = ""
            Dim statusFilter As String = ""

            ' Get filter values
            If pm_cbobx_categ IsNot Nothing AndAlso pm_cbobx_categ.SelectedIndex > 0 Then
                categoryFilter = pm_cbobx_categ.SelectedItem.ToString()
            End If
            If pm_cbobx_status IsNot Nothing AndAlso pm_cbobx_status.SelectedIndex > 0 Then
                statusFilter = pm_cbobx_status.SelectedItem.ToString()
            End If

            Dim dt As DataTable = DatabaseConnection.GetAllSupplies(categoryFilter, statusFilter)
            If dt Is Nothing Then
                originalData = Nothing
                Return
            End If
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

    ' Apply search filter that works with existing category and status filters
    Private Sub ApplySupplySearch(searchText As String)
        If originalData Is Nothing Then Return
        If isSearching Then Return
        isSearching = True
        Try
            Dim searchLower As String = If(String.IsNullOrWhiteSpace(searchText), String.Empty, searchText.Trim().ToLower())
            Dim categoryFilter As String = If(pm_cbobx_categ IsNot Nothing AndAlso pm_cbobx_categ.SelectedIndex > 0, pm_cbobx_categ.SelectedItem.ToString(), String.Empty)
            Dim statusFilter As String = If(pm_cbobx_status IsNot Nothing AndAlso pm_cbobx_status.SelectedIndex > 0, pm_cbobx_status.SelectedItem.ToString(), String.Empty)

            Dim filtered = originalData.AsEnumerable().Where(Function(row)
                                                                 ' category
                                                                 If Not String.IsNullOrEmpty(categoryFilter) Then
                                                                     If Not row.Table.Columns.Contains("category") Then Return False
                                                                     Dim cat As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString(), String.Empty)
                                                                     If Not cat.Equals(categoryFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                 End If
                                                                 ' status
                                                                 If Not String.IsNullOrEmpty(statusFilter) Then
                                                                     If Not row.Table.Columns.Contains("stockStatus") Then Return False
                                                                     Dim st As String = If(row.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(row("stockStatus")), row("stockStatus").ToString(), String.Empty)
                                                                     If Not st.Equals(statusFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                 End If
                                                                 If String.IsNullOrEmpty(searchLower) Then Return True
                                                                 ' searchable fields: itemName, category, description, supplier/sourceOfFunds, unitOfMeasure, location, stockStatus
                                                                 Dim itemName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString().ToLower(), String.Empty)
                                                                 Dim catVal As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString().ToLower(), String.Empty)
                                                                 Dim desc As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString().ToLower(), String.Empty)
                                                                 Dim supplier As String = If(row.Table.Columns.Contains("sourceOfFunds") AndAlso Not IsDBNull(row("sourceOfFunds")), row("sourceOfFunds").ToString().ToLower(), String.Empty)
                                                                 Dim uom As String = If(row.Table.Columns.Contains("unitOfMeasure") AndAlso Not IsDBNull(row("unitOfMeasure")), row("unitOfMeasure").ToString().ToLower(), String.Empty)
                                                                 Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString().ToLower(), String.Empty)
                                                                 Dim stockSt As String = If(row.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(row("stockStatus")), row("stockStatus").ToString().ToLower(), String.Empty)
                                                                 Return itemName.Contains(searchLower) OrElse catVal.Contains(searchLower) OrElse desc.Contains(searchLower) OrElse supplier.Contains(searchLower) OrElse uom.Contains(searchLower) OrElse location.Contains(searchLower) OrElse stockSt.Contains(searchLower)
                                                             End Function)

            pm_table.Rows.Clear()
            For Each row As DataRow In filtered
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

                pm_table.Rows.Add(supplyID, supplyName, unitOfMeasure, acqDate, unitCost, totalCost, sourceOfFunds, status, createdAt, updatedAt)
            Next

            If ttlSupplymanagement IsNot Nothing Then
                ttlSupplymanagement.Text = filtered.Count().ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error searching supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isSearching = False
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
        ' find any search textbox and reapply
        Dim searchNames As String() = {"pm_search", "pm_searchbar", "supplysearch", "supplymanagementsearchbar", "txtSearch", "txtbox_search", "searchBox", "admin_txtbox_search"}
        For Each nm As String In searchNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is TextBox Then
                Dim tb As TextBox = CType(found(0), TextBox)
                If Not String.IsNullOrWhiteSpace(tb.Text) Then
                    ApplySupplySearch(tb.Text)
                End If
                Exit For
            End If
        Next
    End Sub
    ' Super Admin bypasses all restrictions

    Private Sub SupplySearch_TextChanged(sender As Object, e As EventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb Is Nothing Then Return
        ApplySupplySearch(tb.Text)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - btnAdd_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - IsSuperAdmin: " & SessionContext.IsSuperAdmin())
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - ParentForm: " & If(Me.ParentForm IsNot Nothing, Me.ParentForm.GetType().Name, "NULL"))
        
        ' Super Admin bypasses all restrictions

        ' Check SADashboard first (parent class)
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            saDashboard.LoadUserControl(New AddSupply())
            System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - AddSupply loaded into SADashboard")
            Return
        End If
        
        Dim superAdminDashboard = TryCast(Me.ParentForm, SuperAdminDashboard)
        If superAdminDashboard IsNot Nothing Then
            superAdminDashboard.LoadUserControl(New AddSupply())
            Return
        End If

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
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - btnEdit_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - Selected Rows: " & pm_table.SelectedRows.Count)

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

        ' Navigate into Dashboard - Check SADashboard first
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            saDashboard.LoadUserControl(editForm)
            System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - EditSupply loaded into SADashboard")
            Return
        End If
        
        Dim superAdminDashboard = TryCast(Me.ParentForm, SuperAdminDashboard)
        If superAdminDashboard IsNot Nothing Then
            superAdminDashboard.LoadUserControl(editForm)
            Return
        End If

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(editForm)
        Else
            MessageBox.Show("Unable to open EditSupply screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - btnDelete_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - Selected Rows: " & pm_table.SelectedRows.Count)
        
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
                    ' Refresh table to show updated data
                    LoadSuppliesData()
                    ' Success message is already shown by DeleteSupply function
                Else
                    MessageBox.Show("Failed to delete supply. It may be in use or already deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Diagnostics.Debug.WriteLine("[v0] btnDelete_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
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
