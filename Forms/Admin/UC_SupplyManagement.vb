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
                    Dim categories As DataTable = modDB.GetCategories("supply")
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
                            Dim conn = modDB.GetConnection()
                            If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
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
        pm_table.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        pm_table.DefaultCellStyle.BackColor = Color.White
        pm_table.DefaultCellStyle.ForeColor = Color.Black
        pm_table.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        pm_table.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        ' Header styling
        pm_table.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        pm_table.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        pm_table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        pm_table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Configure column widths to show full content
        pm_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        
        ' Set specific column widths - optimized for important columns only
        If pm_table.Columns.Count >= 16 Then
            pm_table.Columns(0).Width = 50   ' supplyId (HIDDEN)
            pm_table.Columns(1).Width = 150  ' itemName (wider since we hide some columns)
            pm_table.Columns(2).Width = 120  ' category (wider)
            pm_table.Columns(3).Width = 200  ' description (much wider)
            pm_table.Columns(4).Width = 80   ' quantity
            pm_table.Columns(5).Width = 100  ' supplier (HIDDEN)
            pm_table.Columns(6).Width = 150  ' assignedTo (wider)
            pm_table.Columns(7).Width = 120  ' location (wider)
            pm_table.Columns(8).Width = 100  ' stockStatus
            pm_table.Columns(9).Width = 100  ' unitOfMeasure (Unit)
            pm_table.Columns(10).Width = 90  ' dateReceived (hidden)
            pm_table.Columns(11).Width = 80  ' unitCost (HIDDEN)
            pm_table.Columns(12).Width = 100 ' totalCost (Total Cost)
            pm_table.Columns(13).Width = 110 ' sourceOfFunds (HIDDEN)
            pm_table.Columns(14).Width = 100 ' createdAt (hidden)
            pm_table.Columns(15).Width = 100 ' updatedAt (hidden)
            
            ' Hide requested columns: supplyId, unitCost, supplier, sourceOfFunds
            pm_table.Columns(0).Visible = False  ' supplyId - HIDDEN per request
            pm_table.Columns(1).Visible = True   ' itemName
            pm_table.Columns(2).Visible = True   ' category
            pm_table.Columns(3).Visible = True   ' description
            pm_table.Columns(4).Visible = True   ' quantity
            pm_table.Columns(5).Visible = False  ' supplier - HIDDEN per request
            pm_table.Columns(6).Visible = True   ' assignedTo
            pm_table.Columns(7).Visible = True   ' location
            pm_table.Columns(8).Visible = True   ' stockStatus
            pm_table.Columns(9).Visible = True   ' unitOfMeasure (Unit)
            pm_table.Columns(10).Visible = False ' dateReceived
            pm_table.Columns(11).Visible = False ' unitCost - HIDDEN per request
            pm_table.Columns(12).Visible = True  ' totalCost (Total Cost - still visible)
            pm_table.Columns(13).Visible = False ' sourceOfFunds - HIDDEN per request
            pm_table.Columns(14).Visible = False ' createdAt
            pm_table.Columns(15).Visible = False ' updatedAt
        End If
        
        ' Column alignment
        For Each col As DataGridViewColumn In pm_table.Columns
            If col.Index = 1 OrElse col.Index = 3 Then ' itemName, description
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            ElseIf col.Index = 4 OrElse col.Index = 11 OrElse col.Index = 12 Then ' quantity, costs
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Else
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next

        ' No restrictions - all buttons enabled for Super Admin, Admin, and Custodian
        ApplyRolePermissions()

        ' Initialize filter dropdowns
        InitializeFilters()

        ' Load data from database
        LoadSuppliesData()

        ' Wire up event handlers
        AddHandler pm_table.SelectionChanged, AddressOf pm_table_SelectionChanged

        ' Wire up search textbox - make it visible and functional
        If supplymanagementsearchbar IsNot Nothing Then
            ' Make search field visible and properly configured
            supplymanagementsearchbar.Visible = True
            supplymanagementsearchbar.BringToFront()
            
            ' Set initial placeholder WITHOUT triggering events
            RemoveHandler supplymanagementsearchbar.TextChanged, AddressOf SupplySearch_TextChanged
            supplymanagementsearchbar.Text = "Search supplies..."
            supplymanagementsearchbar.ForeColor = Drawing.Color.Gray
            
            ' Add placeholder text handling
            AddHandler supplymanagementsearchbar.GotFocus, Sub()
                                                               If supplymanagementsearchbar.ForeColor = Drawing.Color.Gray Then
                                                                   supplymanagementsearchbar.Text = ""
                                                                   supplymanagementsearchbar.ForeColor = Drawing.Color.Black
                                                               End If
                                                           End Sub
            AddHandler supplymanagementsearchbar.LostFocus, Sub()
                                                                If String.IsNullOrWhiteSpace(supplymanagementsearchbar.Text) Then
                                                                    supplymanagementsearchbar.ForeColor = Drawing.Color.Gray
                                                                    supplymanagementsearchbar.Text = "Search supplies..."
                                                                End If
                                                            End Sub
            
            ' Wire up search handler AFTER setting placeholder
            AddHandler supplymanagementsearchbar.TextChanged, AddressOf SupplySearch_TextChanged
            System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - Wired search handler (placeholder set first)")
        End If
        
        ' Also try to find search field by name as fallback
        Dim searchNames As String() = {"pm_search", "pm_searchbar", "supplysearch", "txtSearch", "txtbox_search", "searchBox", "admin_txtbox_search"}
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
    End Sub

    ' Added method to load supplies from database
    Public Sub LoadSuppliesData()
        Try
            ' Clear existing rows
            pm_table.Rows.Clear()
            System.Diagnostics.Debug.WriteLine("[v0] LoadSuppliesData - Table cleared")
            
            Dim categoryFilter As String = ""
            Dim statusFilter As String = ""

            ' Get filter values - exclude "All" and similar default options
            If pm_cbobx_categ IsNot Nothing AndAlso pm_cbobx_categ.SelectedIndex > 0 Then
                Dim selectedCat As String = pm_cbobx_categ.SelectedItem.ToString()
                If Not selectedCat.Equals("All", StringComparison.OrdinalIgnoreCase) AndAlso 
                   Not selectedCat.Equals("All Categories", StringComparison.OrdinalIgnoreCase) AndAlso
                   Not selectedCat.Equals("Categories", StringComparison.OrdinalIgnoreCase) Then
                    categoryFilter = selectedCat
                End If
            End If
            
            If pm_cbobx_status IsNot Nothing AndAlso pm_cbobx_status.SelectedIndex > 0 Then
                Dim selectedStatus As String = pm_cbobx_status.SelectedItem.ToString()
                If Not selectedStatus.Equals("All Status", StringComparison.OrdinalIgnoreCase) AndAlso
                   Not selectedStatus.Equals("All", StringComparison.OrdinalIgnoreCase) AndAlso
                   Not selectedStatus.Equals("Status", StringComparison.OrdinalIgnoreCase) Then
                    statusFilter = selectedStatus
                End If
            End If

            System.Diagnostics.Debug.WriteLine($"[v0] LoadSuppliesData - Category Filter: '{categoryFilter}', Status Filter: '{statusFilter}'")
            Dim dt As DataTable = modDB.GetAllSupplies(categoryFilter, statusFilter)
            System.Diagnostics.Debug.WriteLine($"[v0] LoadSuppliesData - Received {If(dt IsNot Nothing, dt.Rows.Count, 0)} rows from database")
            If dt Is Nothing Then
                originalData = Nothing
                Return
            End If
            originalData = dt.Copy()

            System.Diagnostics.Debug.WriteLine($"[v0] LoadSuppliesData - Starting to populate {dt.Rows.Count} rows into table")
            
            If dt.Rows.Count > 0 Then
                Dim rowsAdded As Integer = 0
                For Each row As DataRow In dt.Rows
                    ' Use safe column access with correct camelCase column names from database
                    ' Designer column order: supplyId, itemName, category, description, quantity, supplier, location, stockStatus, unitOfMeasure, dateReceived, unitCost, totalCost, sourceOfFunds, createdAt, updatedAt
                    Dim supplyID As String = If(row.Table.Columns.Contains("supplyId") AndAlso Not IsDBNull(row("supplyId")), row("supplyId").ToString(), "")
                    Dim supplyName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString(), "")
                    Dim categoryVal As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString(), "")
                    Dim descriptionVal As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString(), "")
                    Dim quantityVal As String = If(row.Table.Columns.Contains("quantity") AndAlso Not IsDBNull(row("quantity")), row("quantity").ToString(), "0")
                    Dim supplierVal As String = If(row.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(row("supplier")), row("supplier").ToString(), "")
                    Dim locationVal As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), "")
                    Dim status As String = If(row.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(row("stockStatus")), row("stockStatus").ToString(), "")
                    
                    ' Hidden columns
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
                    ' Get assigned user name if exists - now using assignedEmployee column from query
                    Dim assignedToName As String = ""
                    If row.Table.Columns.Contains("assignedEmployee") AndAlso Not IsDBNull(row("assignedEmployee")) Then
                        assignedToName = row("assignedEmployee").ToString()
                    End If
                    
                    Dim createdAt As String = If(row.Table.Columns.Contains("createdAt") AndAlso Not IsDBNull(row("createdAt")), Convert.ToDateTime(row("createdAt")).ToString("yyyy-MM-dd"), "")
                    Dim updatedAt As String = If(row.Table.Columns.Contains("updatedAt") AndAlso Not IsDBNull(row("updatedAt")), Convert.ToDateTime(row("updatedAt")).ToString("yyyy-MM-dd"), "")

                    ' Add row matching Designer column order: supplyId, itemName, category, description, quantity, supplier, assignedTo, location, stockStatus, unitOfMeasure, dateReceived, unitCost, totalCost, sourceOfFunds, createdAt, updatedAt
                    Dim rowIndex As Integer = pm_table.Rows.Add(supplyID, supplyName, categoryVal, descriptionVal, quantityVal, supplierVal, assignedToName, locationVal, status, unitOfMeasure, acqDate, unitCost, totalCost, sourceOfFunds, createdAt, updatedAt)
                    rowsAdded += 1
                Next

                System.Diagnostics.Debug.WriteLine($"[v0] LoadSuppliesData - Successfully added {rowsAdded} rows to table")
                System.Diagnostics.Debug.WriteLine($"[v0] LoadSuppliesData - Table now has {pm_table.Rows.Count} rows")
                
                ' Update total count
                If ttlSupplymanagement IsNot Nothing Then
                    ttlSupplymanagement.Text = dt.Rows.Count.ToString()
                    System.Diagnostics.Debug.WriteLine($"[v0] LoadSuppliesData - Updated count label to: {dt.Rows.Count}")
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] LoadSuppliesData - WARNING: ttlSupplymanagement label is Nothing!")
                End If
                
                ' Force UI refresh
                pm_table.Refresh()
                Me.Refresh()
                
                System.Diagnostics.Debug.WriteLine("[v0] Supply Management - Loaded " & dt.Rows.Count & " supplies")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Supply Management - No supplies found")
                If ttlSupplymanagement IsNot Nothing Then
                    ttlSupplymanagement.Text = "0"
                End If
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
            
            ' Get filter values - exclude "All" variations
            Dim categoryFilter As String = String.Empty
            If pm_cbobx_categ IsNot Nothing AndAlso pm_cbobx_categ.SelectedIndex > 0 Then
                Dim selectedCat As String = pm_cbobx_categ.SelectedItem.ToString()
                If Not selectedCat.Equals("All", StringComparison.OrdinalIgnoreCase) AndAlso 
                   Not selectedCat.Equals("All Categories", StringComparison.OrdinalIgnoreCase) Then
                    categoryFilter = selectedCat
                End If
            End If
            
            Dim statusFilter As String = String.Empty
            If pm_cbobx_status IsNot Nothing AndAlso pm_cbobx_status.SelectedIndex > 0 Then
                Dim selectedStatus As String = pm_cbobx_status.SelectedItem.ToString()
                If Not selectedStatus.Equals("All Status", StringComparison.OrdinalIgnoreCase) AndAlso
                   Not selectedStatus.Equals("All", StringComparison.OrdinalIgnoreCase) Then
                    statusFilter = selectedStatus
                End If
            End If

            Dim filtered = originalData.AsEnumerable().Where(Function(row)
                                                                 ' Apply category filter
                                                                 If Not String.IsNullOrEmpty(categoryFilter) Then
                                                                     If Not row.Table.Columns.Contains("category") Then Return False
                                                                     Dim cat As String = If(Not IsDBNull(row("category")), row("category").ToString(), String.Empty)
                                                                     If Not String.Equals(cat, categoryFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                 End If
                                                                 
                                                                 ' Apply status filter
                                                                 If Not String.IsNullOrEmpty(statusFilter) Then
                                                                     If Not row.Table.Columns.Contains("stockStatus") Then Return False
                                                                     Dim st As String = If(Not IsDBNull(row("stockStatus")), row("stockStatus").ToString(), String.Empty)
                                                                     If Not String.Equals(st, statusFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                 End If
                                                                 
                                                                 ' Apply search filter
                                                                 If String.IsNullOrEmpty(searchLower) Then Return True
                                                                 
                                                                 ' Searchable fields: itemName, category, description, supplier, sourceOfFunds, unitOfMeasure, location, stockStatus, assignedEmployee
                                                                 Dim itemName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString().ToLower(), String.Empty)
                                                                 Dim catVal As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString().ToLower(), String.Empty)
                                                                 Dim desc As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString().ToLower(), String.Empty)
                                                                 Dim supplier As String = If(row.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(row("supplier")), row("supplier").ToString().ToLower(), String.Empty)
                                                                 Dim sourceOfFunds As String = If(row.Table.Columns.Contains("sourceOfFunds") AndAlso Not IsDBNull(row("sourceOfFunds")), row("sourceOfFunds").ToString().ToLower(), String.Empty)
                                                                 Dim uom As String = If(row.Table.Columns.Contains("unitOfMeasure") AndAlso Not IsDBNull(row("unitOfMeasure")), row("unitOfMeasure").ToString().ToLower(), String.Empty)
                                                                 Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString().ToLower(), String.Empty)
                                                                 Dim stockSt As String = If(row.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(row("stockStatus")), row("stockStatus").ToString().ToLower(), String.Empty)
                                                                 Dim assignedEmp As String = If(row.Table.Columns.Contains("assignedEmployee") AndAlso Not IsDBNull(row("assignedEmployee")), row("assignedEmployee").ToString().ToLower(), String.Empty)
                                                                 
                                                                 Return itemName.Contains(searchLower) OrElse catVal.Contains(searchLower) OrElse desc.Contains(searchLower) OrElse supplier.Contains(searchLower) OrElse sourceOfFunds.Contains(searchLower) OrElse uom.Contains(searchLower) OrElse location.Contains(searchLower) OrElse stockSt.Contains(searchLower) OrElse assignedEmp.Contains(searchLower)
                                                             End Function)

            pm_table.Rows.Clear()
            For Each row As DataRow In filtered
                Dim supplyID As String = If(row.Table.Columns.Contains("supplyId") AndAlso Not IsDBNull(row("supplyId")), row("supplyId").ToString(), "")
                Dim supplyName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString(), "")
                Dim categoryVal As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString(), "")
                Dim descriptionVal As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString(), "")
                Dim quantityVal As String = If(row.Table.Columns.Contains("quantity") AndAlso Not IsDBNull(row("quantity")), row("quantity").ToString(), "0")
                Dim supplierVal As String = If(row.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(row("supplier")), row("supplier").ToString(), "")
                Dim locationVal As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), "")
                Dim status As String = If(row.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(row("stockStatus")), row("stockStatus").ToString(), "")
                
                ' Hidden columns
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
                ' Get assigned user name if exists - now using assignedEmployee column from query
                Dim assignedToName As String = ""
                If row.Table.Columns.Contains("assignedEmployee") AndAlso Not IsDBNull(row("assignedEmployee")) Then
                    assignedToName = row("assignedEmployee").ToString()
                End If
                
                Dim sourceOfFunds As String = If(row.Table.Columns.Contains("sourceOfFunds") AndAlso Not IsDBNull(row("sourceOfFunds")), row("sourceOfFunds").ToString(), "")
                Dim createdAt As String = If(row.Table.Columns.Contains("createdAt") AndAlso Not IsDBNull(row("createdAt")), Convert.ToDateTime(row("createdAt")).ToString("yyyy-MM-dd"), "")
                Dim updatedAt As String = If(row.Table.Columns.Contains("updatedAt") AndAlso Not IsDBNull(row("updatedAt")), Convert.ToDateTime(row("updatedAt")).ToString("yyyy-MM-dd"), "")

                pm_table.Rows.Add(supplyID, supplyName, categoryVal, descriptionVal, quantityVal, supplierVal, assignedToName, locationVal, status, unitOfMeasure, acqDate, unitCost, totalCost, sourceOfFunds, createdAt, updatedAt)
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
        System.Diagnostics.Debug.WriteLine("[v0] Filter_Changed - Event triggered")
        
        ' Reload data with filters
        LoadSuppliesData()
        
        ' DON'T reapply search automatically - it causes the table to clear
        ' The search will be applied when user types in the search box
        System.Diagnostics.Debug.WriteLine("[v0] Filter_Changed - Completed, table should now show filtered data")
    End Sub
    ' Super Admin bypasses all restrictions

    Private Sub SupplySearch_TextChanged(sender As Object, e As EventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb Is Nothing Then Return
        
        System.Diagnostics.Debug.WriteLine($"[v0] SupplySearch_TextChanged - Text: '{tb.Text}', ForeColor: {tb.ForeColor.Name}")
        
        ' Skip placeholder text - DON'T trigger search
        If tb.ForeColor = Drawing.Color.Gray OrElse tb.Text = "Search supplies..." Then
            System.Diagnostics.Debug.WriteLine("[v0] SupplySearch_TextChanged - Skipping placeholder text")
            Return
        End If
        
        ' Only apply search if there's actual text
        If String.IsNullOrWhiteSpace(tb.Text) Then
            System.Diagnostics.Debug.WriteLine("[v0] SupplySearch_TextChanged - Empty search, ignoring")
            Return
        End If
        
        System.Diagnostics.Debug.WriteLine($"[v0] SupplySearch_TextChanged - Applying search for: '{tb.Text}'")
        ApplySupplySearch(tb.Text)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - btnAdd_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - IsSuperAdmin: " & SessionContext.IsSuperAdmin())
        System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - ParentForm: " & If(Me.ParentForm IsNot Nothing, Me.ParentForm.GetType().Name, "NULL"))
        
        ' Super Admin bypasses all restrictions

        ' Check SADashboard first (parent class)
        Dim superAdmin = TryCast(Me.ParentForm, SADashboard)
        If superAdmin IsNot Nothing Then
            superAdmin.LoadUserControl(New AddSupply())
            System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - AddSupply loaded into SADashboard")
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
        Dim supplyData As DataRow = modDB.GetSupplyById(supplyID)
        If supplyData Is Nothing Then
            MessageBox.Show("Supply not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open EditSupply Form
        Dim editForm As New EditSupply()
        
        ' Extract data from DataRow with proper type conversion
        Dim itemName As String = If(IsDBNull(supplyData("itemName")), "", supplyData("itemName").ToString())
        Dim category As String = If(IsDBNull(supplyData("category")), "", supplyData("category").ToString())
        Dim description As String = If(IsDBNull(supplyData("description")), "", supplyData("description").ToString())
        Dim unitOfMeasure As String = If(IsDBNull(supplyData("unitOfMeasure")), "", supplyData("unitOfMeasure").ToString())
        Dim quantity As Integer = If(IsDBNull(supplyData("quantity")), 0, CInt(supplyData("quantity")))
        Dim dateReceived As Date = If(IsDBNull(supplyData("dateReceived")), Date.Today, CDate(supplyData("dateReceived")))
        Dim unitCost As Decimal = If(IsDBNull(supplyData("unitCost")), 0D, CDec(supplyData("unitCost")))
        Dim totalCost As Decimal = If(IsDBNull(supplyData("totalCost")), 0D, CDec(supplyData("totalCost")))
        Dim supplier As String = If(IsDBNull(supplyData("supplier")), "", supplyData("supplier").ToString())
        Dim sourceOfFunds As String = If(IsDBNull(supplyData("sourceOfFunds")), "", supplyData("sourceOfFunds").ToString())
        Dim location As String = If(IsDBNull(supplyData("location")), "", supplyData("location").ToString())
        Dim stockStatus As String = If(IsDBNull(supplyData("stockStatus")), "Available", supplyData("stockStatus").ToString())
        
        ' Get assignedTo if it exists in the data
        Dim assignedToUserId As Integer? = Nothing
        If supplyData.Table.Columns.Contains("assignedTo") AndAlso Not IsDBNull(supplyData("assignedTo")) Then
            assignedToUserId = CInt(supplyData("assignedTo"))
        End If
        
        editForm.LoadSupplyData(supplyID, itemName, category, description, unitOfMeasure, quantity, 
                               dateReceived, unitCost, totalCost, supplier, sourceOfFunds, location, stockStatus, assignedToUserId)

        ' Navigate into Dashboard - Check SADashboard first
        Dim superAdmin = TryCast(Me.ParentForm, SADashboard)
        If superAdmin IsNot Nothing Then
            superAdmin.LoadUserControl(editForm)
            System.Diagnostics.Debug.WriteLine("[v0] UC_SupplyManagement - EditSupply loaded into SADashboard")
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
                Dim success As Boolean = modDB.DeleteSupply(supplyID)
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
