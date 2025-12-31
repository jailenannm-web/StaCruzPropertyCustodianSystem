Imports System
Imports System.Data
Imports System.Linq
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class SupplyInventory
    Inherits System.Windows.Forms.UserControl

    Private originalData As DataTable
    Private isSearching As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub SupplyInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFilters()
        LoadSupplyData()
        
        ' Wire up search bar
        AddHandler supplyinventorysearchbar.TextChanged, AddressOf SupplySearch_TextChanged
    End Sub
    
    Private Sub InitializeFilters()
        ' Initialize status filter
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"Available", "Low Stock", "Out of Stock"})
        pm_cbobx_status.SelectedIndex = 0
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
        
        ' Initialize category filter
        pm_cbobx_categ.Items.Clear()
        pm_cbobx_categ.Items.Add("All Categories")
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
            ' Fallback to hardcoded categories
            If pm_cbobx_categ.Items.Count <= 1 Then
                pm_cbobx_categ.Items.AddRange(New String() {
                    "Office Supplies", "Cleaning Supplies", "Medical Supplies", "IT Supplies",
                    "Laboratory Supplies", "Maintenance Supplies", "Others"
                })
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("InitializeFilters Category Error: " & ex.Message)
            pm_cbobx_categ.Items.AddRange(New String() {
                "Office Supplies", "Cleaning Supplies", "Medical Supplies", "IT Supplies",
                "Laboratory Supplies", "Maintenance Supplies", "Others"
            })
        End Try
        pm_cbobx_categ.SelectedIndex = 0
        AddHandler pm_cbobx_categ.SelectedIndexChanged, AddressOf Filter_Changed
    End Sub
    
    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        LoadSupplyData()
        ' Reapply search if there's search text
        If Not String.IsNullOrWhiteSpace(supplyinventorysearchbar.Text) Then
            SupplySearch_TextChanged(supplyinventorysearchbar, EventArgs.Empty)
        End If
    End Sub
    
    Private Sub SupplySearch_TextChanged(sender As Object, e As EventArgs)
        If isSearching Then Return
        ApplySupplySearch(supplyinventorysearchbar.Text)
    End Sub
    
    Private Sub ApplySupplySearch(searchText As String)
        If originalData Is Nothing OrElse originalData.Rows.Count = 0 Then Return
        If isSearching Then Return
        isSearching = True
        
        Try
            Dim searchLower As String = If(String.IsNullOrWhiteSpace(searchText), String.Empty, searchText.Trim().ToLower())
            Dim categoryFilter As String = If(pm_cbobx_categ.SelectedIndex > 0, pm_cbobx_categ.SelectedItem.ToString(), String.Empty)
            Dim statusFilterValue As String = If(pm_cbobx_status.SelectedIndex > 0, pm_cbobx_status.SelectedItem.ToString(), String.Empty)
            
            Dim filteredRows As IEnumerable(Of DataRow) = originalData.AsEnumerable().Where(Function(row)
                ' Apply category filter
                If Not String.IsNullOrEmpty(categoryFilter) Then
                    Dim cat As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString(), String.Empty)
                    If Not cat.Equals(categoryFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                End If
                
                ' Apply status filter
                If Not String.IsNullOrEmpty(statusFilterValue) Then
                    Dim stockStatusValue As String = If(row.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(row("stockStatus")), row("stockStatus").ToString(), String.Empty)
                    If Not stockStatusValue.Equals(statusFilterValue, StringComparison.OrdinalIgnoreCase) Then Return False
                End If
                
                ' Apply search filter
                If String.IsNullOrEmpty(searchLower) Then Return True
                
                Dim itemName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString().ToLower(), String.Empty)
                Dim category As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString().ToLower(), String.Empty)
                Dim description As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString().ToLower(), String.Empty)
                Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString().ToLower(), String.Empty)
                
                Return itemName.Contains(searchLower) OrElse category.Contains(searchLower) OrElse description.Contains(searchLower) OrElse location.Contains(searchLower)
            End Function)
            
            propertyManagementGrid.Rows.Clear()
            
            For Each row As DataRow In filteredRows
                Dim supplyID As String = ""
                Dim itemName As String = ""
                Dim category As String = ""
                Dim description As String = ""
                Dim unitOfMeasure As String = ""
                Dim quantity As String = "0"
                Dim location As String = ""
                Dim stockStatus As String = ""
                
                Try
                    If row.Table.Columns.Contains("supplyId") AndAlso Not IsDBNull(row("supplyId")) Then
                        supplyID = row("supplyId").ToString()
                    End If
                    If row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")) Then
                        itemName = row("itemName").ToString()
                    End If
                    If row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")) Then
                        category = row("category").ToString()
                    End If
                    If row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")) Then
                        description = row("description").ToString()
                    End If
                    If row.Table.Columns.Contains("unitOfMeasure") AndAlso Not IsDBNull(row("unitOfMeasure")) Then
                        unitOfMeasure = row("unitOfMeasure").ToString()
                    End If
                    If row.Table.Columns.Contains("quantity") AndAlso Not IsDBNull(row("quantity")) Then
                        quantity = row("quantity").ToString()
                    End If
                    If row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")) Then
                        location = row("location").ToString()
                    End If
                    If row.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(row("stockStatus")) Then
                        stockStatus = row("stockStatus").ToString()
                    End If
                Catch colEx As Exception
                    System.Diagnostics.Debug.WriteLine("Column access error: " & colEx.Message)
                End Try
                
                propertyManagementGrid.Rows.Add(supplyID, itemName, category, description, unitOfMeasure, quantity, location, stockStatus)
            Next
            
            ' Update total after search/filter
            UpdateTotalSupplyCount()
        Catch ex As Exception
            MessageBox.Show("Error searching supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isSearching = False
        End Try
    End Sub
    
    ''' <summary>
    ''' Refresh button click handler
    ''' </summary>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            ' Clear search bar
            supplyinventorysearchbar.Text = ""
            
            ' Reset filters
            pm_cbobx_categ.SelectedIndex = 0
            pm_cbobx_status.SelectedIndex = 0
            
            ' Reload data
            LoadSupplyData()
            
            ' Show success message
            MessageBox.Show("Supply Inventory successfully Refreshed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            
            System.Diagnostics.Debug.WriteLine("[v0] Supply inventory refreshed successfully")
        Catch ex As Exception
            MessageBox.Show("Error refreshing supply inventory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("btnRefresh_Click Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadSupplyData()
        Try
            ' Get filters
            Dim categoryFilter As String = ""
            Dim statusFilter As String = ""
            
            If pm_cbobx_categ.SelectedIndex > 0 Then
                categoryFilter = pm_cbobx_categ.SelectedItem.ToString()
            End If
            If pm_cbobx_status.SelectedIndex > 0 Then
                statusFilter = pm_cbobx_status.SelectedItem.ToString()
            End If
            
            ' Load all available supplies from database with filters
            Dim dt As DataTable = DatabaseConnection.GetAllSupplies(categoryFilter, statusFilter)
            
            If dt Is Nothing Then
                MessageBox.Show("Unable to connect to the database. Please ensure MySQL is running and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Store original data for search
            originalData = dt.Copy()
            
            ' Clear existing data
            propertyManagementGrid.Rows.Clear()
            
            ' Add "Assigned To" column if it doesn't exist (before the last column which is stockStatus)
            If Not propertyManagementGrid.Columns.Contains("assignedTo") Then
                Dim assignedToColumn As New DataGridViewTextBoxColumn()
                assignedToColumn.Name = "assignedTo"
                assignedToColumn.HeaderText = "Assigned To"
                assignedToColumn.Width = 200
                ' Insert at index 7 (after location, before stockStatus)
                ' Columns: 0=supplyID, 1=itemName, 2=category, 3=description, 4=unitOfMeasure, 5=quantity, 6=location, 7=assignedTo, 8=stockStatus
                propertyManagementGrid.Columns.Insert(7, assignedToColumn)
                System.Diagnostics.Debug.WriteLine("[v0] Added 'Assigned To' column to SupplyInventory grid at index 7")
            End If
            
            ' Populate DataGridView
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim supplyID As String = ""
                    Dim itemName As String = ""
                    Dim category As String = ""
                    Dim description As String = ""
                    Dim unitOfMeasure As String = ""
                    Dim quantity As String = "0"
                    Dim location As String = ""
                    Dim assignedTo As String = ""
                    Dim stockStatus As String = ""
                    
                    ' Handle different possible column names
                    Try
                        If row.Table.Columns.Contains("supplyId") AndAlso Not IsDBNull(row("supplyId")) Then
                            supplyID = row("supplyId").ToString()
                        End If
                        
                        If row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")) Then
                            itemName = row("itemName").ToString()
                        End If
                        
                        If row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")) Then
                            category = row("category").ToString()
                        End If
                        
                        If row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")) Then
                            description = row("description").ToString()
                        End If
                        
                        If row.Table.Columns.Contains("unitOfMeasure") AndAlso Not IsDBNull(row("unitOfMeasure")) Then
                            unitOfMeasure = row("unitOfMeasure").ToString()
                        End If
                        
                        ' Fix quantity display - check multiple possible column names
                        If row.Table.Columns.Contains("quantity") AndAlso Not IsDBNull(row("quantity")) Then
                            quantity = row("quantity").ToString()
                        End If
                        
                        If row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")) Then
                            location = row("location").ToString()
                        End If
                        
                        ' Get assignedEmployee column (shows "Name - Dept - Location")
                        If row.Table.Columns.Contains("assignedEmployee") AndAlso Not IsDBNull(row("assignedEmployee")) Then
                            assignedTo = row("assignedEmployee").ToString()
                        End If
                        
                        If row.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(row("stockStatus")) Then
                            stockStatus = row("stockStatus").ToString()
                        End If
                    Catch colEx As Exception
                        System.Diagnostics.Debug.WriteLine("Column access error: " & colEx.Message)
                    End Try
                    
                    ' Add row with correct column order: supplyID, itemName, category, description, unitOfMeasure, quantity, location, assignedTo, stockStatus
                    propertyManagementGrid.Rows.Add(supplyID, itemName, category, description, unitOfMeasure, quantity, location, assignedTo, stockStatus)
                Next
            End If
            
            ' Auto-size columns
            propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            
            ' Update total supply count
            UpdateTotalSupplyCount()
        Catch ex As Exception
            Dim errorMsg As String = "Unable to connect to the database. Please ensure MySQL is running and try again."
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            System.Diagnostics.Debug.WriteLine("SupplyInventory LoadSupplyData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub
    
    ''' <summary>
    ''' Update the total supply count label
    ''' </summary>
    Private Sub UpdateTotalSupplyCount()
        Try
            If lblTotal IsNot Nothing Then
                Dim totalCount As Integer = propertyManagementGrid.Rows.Count
                lblTotal.Text = $"Total Supply: {totalCount}"
                System.Diagnostics.Debug.WriteLine($"[v0] Updated total supply count: {totalCount}")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("UpdateTotalSupplyCount Error: " & ex.Message)
        End Try
    End Sub
    Private Sub btnrequestsupply_Click(sender As Object, e As System.EventArgs)
        Dim addRequest As New AddSupplyRequest()
        addRequest.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addRequest)
    End Sub

    Private Sub btnrequestsupply_Click_1(sender As Object, e As System.EventArgs) Handles btnrequestsupply.Click
        ' Load AddSupplyRequest into parent dashboard
        Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddSupplyRequest())
        Else
            ' Fallback: add directly to parent
            Dim addSupplyRequest As New AddSupplyRequest()
            addSupplyRequest.Dock = DockStyle.Fill
            Me.Parent.Controls.Clear()
            Me.Parent.Controls.Add(addSupplyRequest)
        End If
    End Sub
    
    Private Sub propertyManagementGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellClick
        ' Auto-fill supply request form when clicking a row
        If e.RowIndex >= 0 AndAlso e.RowIndex < propertyManagementGrid.Rows.Count Then
            Try
                Dim selectedRow As DataGridViewRow = propertyManagementGrid.Rows(e.RowIndex)
                
                ' Column order: supplyID (0), itemName (1), category (2), description (3), unitOfMeasure (4), quantity (5), location (6), stockStatus (7)
                Dim itemNameValue As String = If(selectedRow.Cells.Count > 1 AndAlso selectedRow.Cells(1).Value IsNot Nothing, selectedRow.Cells(1).Value.ToString(), "")
                Dim categoryValue As String = If(selectedRow.Cells.Count > 2 AndAlso selectedRow.Cells(2).Value IsNot Nothing, selectedRow.Cells(2).Value.ToString(), "")
                Dim itemDescription As String = If(selectedRow.Cells.Count > 3 AndAlso selectedRow.Cells(3).Value IsNot Nothing, selectedRow.Cells(3).Value.ToString(), "")
                Dim unitOfMeasureValue As String = If(selectedRow.Cells.Count > 4 AndAlso selectedRow.Cells(4).Value IsNot Nothing, selectedRow.Cells(4).Value.ToString(), "")
                Dim availableQuantity As String = If(selectedRow.Cells.Count > 5 AndAlso selectedRow.Cells(5).Value IsNot Nothing, selectedRow.Cells(5).Value.ToString(), "0")
                Dim locationValue As String = If(selectedRow.Cells.Count > 6 AndAlso selectedRow.Cells(6).Value IsNot Nothing, selectedRow.Cells(6).Value.ToString(), "")
                
                ' Get staff profile for auto-fill
                Dim requesterName As String = ""
                Dim position As String = ""
                Dim department As String = ""
                Dim currentDate As String = Date.Now.ToString("yyyy-MM-dd")
                
                If SessionContext.CurrentUserID.HasValue Then
                    Try
                        Dim profile As Dictionary(Of String, Object) = DatabaseConnection.GetStaffProfile(SessionContext.CurrentUserID.Value)
                        If profile IsNot Nothing AndAlso profile.Count > 0 Then
                            ' Build full name
                            Dim firstName As String = If(profile.ContainsKey("firstName"), profile("firstName").ToString(), "")
                            Dim lastName As String = If(profile.ContainsKey("lastName"), profile("lastName").ToString(), "")
                            Dim middleName As String = If(profile.ContainsKey("middleName") AndAlso profile("middleName") IsNot Nothing, profile("middleName").ToString(), "")
                            requesterName = firstName & If(Not String.IsNullOrEmpty(middleName), " " & middleName, "") & " " & lastName
                            
                            ' Get position
                            If profile.ContainsKey("position") AndAlso profile("position") IsNot Nothing Then
                                position = profile("position").ToString()
                            End If
                            
                            ' Get department name
                            If profile.ContainsKey("departmentId") AndAlso profile("departmentId") IsNot Nothing AndAlso Not IsDBNull(profile("departmentId")) Then
                                Try
                                    Dim deptIDValue As Object = profile("departmentId")
                                    Dim deptID As Integer = 0
                                    If Integer.TryParse(deptIDValue.ToString(), deptID) AndAlso deptID > 0 Then
                                        Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
                                        If dt IsNot Nothing Then
                                            For Each deptRow As DataRow In dt.Rows
                                                Dim rowDeptID As Integer = 0
                                                If deptRow.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(deptRow("departmentId")) Then
                                                    Integer.TryParse(deptRow("departmentId").ToString(), rowDeptID)
                                                ElseIf deptRow.Table.Columns.Contains("department_id") AndAlso Not IsDBNull(deptRow("department_id")) Then
                                                    Integer.TryParse(deptRow("department_id").ToString(), rowDeptID)
                                                End If
                                                If rowDeptID = deptID Then
                                                    If deptRow.Table.Columns.Contains("departmentName") Then
                                                        department = deptRow("departmentName").ToString()
                                                    ElseIf deptRow.Table.Columns.Contains("department_name") Then
                                                        department = deptRow("department_name").ToString()
                                                    End If
                                                    Exit For
                                                End If
                                            Next
                                        End If
                                    End If
                                Catch
                                End Try
                            End If
                        End If
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine("GetStaffProfile Error in CellClick: " & ex.Message)
                    End Try
                End If
                
                ' Navigate to request form with pre-filled data - pass all required fields
                Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
                If parentDashboard IsNot Nothing Then
                    Dim requestForm As New AddSupplyRequest(itemNameValue, itemDescription, categoryValue, availableQuantity, locationValue, unitOfMeasureValue, requesterName, position, department, currentDate)
                    parentDashboard.LoadUserControl(requestForm)
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("SupplyInventory CellClick Error: " & ex.Message)
                MessageBox.Show("Error loading request form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class
