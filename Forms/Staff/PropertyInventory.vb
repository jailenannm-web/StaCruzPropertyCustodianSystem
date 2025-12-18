Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class PropertyInventory
    Inherits System.Windows.Forms.UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private originalData As DataTable
    Private isSearching As Boolean = False

    Private Sub PropertyInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFilters()
        LoadPropertyData()
        
        ' Wire up search bar
        AddHandler propertyinventorysearchbar.TextChanged, AddressOf PropertySearch_TextChanged
    End Sub
    
    Private Sub InitializeFilters()
        ' Initialize status filter
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"Active", "For Disposal", "Lost", "Borrowed"})
        pm_cbobx_status.SelectedIndex = 0
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
        
        ' Initialize category filter
        pm_cbobx_categ.Items.Clear()
        pm_cbobx_categ.Items.Add("All Categories")
        Try
            Dim categories As DataTable = DatabaseConnection.GetCategories("property")
            If categories IsNot Nothing AndAlso categories.Rows.Count > 0 Then
                For Each row As DataRow In categories.Rows
                    Dim categoryName As String = ""
                    If row.Table.Columns.Contains("category_name") AndAlso Not Convert.IsDBNull(row("category_name")) Then
                        categoryName = row("category_name").ToString()
                    ElseIf row.Table.Columns.Contains("categoryName") AndAlso Not Convert.IsDBNull(row("categoryName")) Then
                        categoryName = row("categoryName").ToString()
                    ElseIf row.Table.Columns.Count > 0 AndAlso Not Convert.IsDBNull(row(0)) Then
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
                    "Furniture", "Equipment", "Office Supplies", "IT Equipment",
                    "Laboratory Apparatus", "Books and Publications",
                    "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
                })
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("InitializeFilters Category Error: " & ex.Message)
            pm_cbobx_categ.Items.AddRange(New String() {
                "Furniture", "Equipment", "Office Supplies", "IT Equipment",
                "Laboratory Apparatus", "Books and Publications",
                "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
            })
        End Try
        pm_cbobx_categ.SelectedIndex = 0
        AddHandler pm_cbobx_categ.SelectedIndexChanged, AddressOf Filter_Changed
    End Sub
    
    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        LoadPropertyData()
        ' Reapply search if there's search text
        If Not String.IsNullOrWhiteSpace(propertyinventorysearchbar.Text) Then
            PropertySearch_TextChanged(propertyinventorysearchbar, EventArgs.Empty)
        End If
    End Sub
    
    Private Sub PropertySearch_TextChanged(sender As Object, e As EventArgs)
        If isSearching Then Return
        ApplyPropertySearch(propertyinventorysearchbar.Text)
    End Sub
    
    Private Sub ApplyPropertySearch(searchText As String)
        If originalData Is Nothing OrElse originalData.Rows.Count = 0 Then Return
        If isSearching Then Return
        isSearching = True
        
        Try
            Dim searchLower As String = If(String.IsNullOrWhiteSpace(searchText), String.Empty, searchText.Trim().ToLower())
            Dim categoryFilter As String = If(pm_cbobx_categ.SelectedIndex > 0, pm_cbobx_categ.SelectedItem.ToString(), String.Empty)
            Dim statusFilterValue As String = If(pm_cbobx_status.SelectedIndex > 0, pm_cbobx_status.SelectedItem.ToString(), String.Empty)
            
            Dim filteredRows() As DataRow = originalData.AsEnumerable().Where(Function(row)
                ' Apply category filter
                If Not String.IsNullOrEmpty(categoryFilter) Then
                    Dim cat As String = If(row.Table.Columns.Contains("category") AndAlso Not Convert.IsDBNull(row("category")), row("category").ToString(), String.Empty)
                    If Not cat.Equals(categoryFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                End If
                
                ' Apply status filter - use statusFilterValue to avoid conflict with Designer field 'status'
                If Not String.IsNullOrEmpty(statusFilterValue) Then
                    Dim rowStatus As String = If(row.Table.Columns.Contains("status") AndAlso Not Convert.IsDBNull(row("status")), row("status").ToString(), String.Empty)
                    If Not rowStatus.Equals(statusFilterValue, StringComparison.OrdinalIgnoreCase) Then Return False
                End If
                
                ' Apply search filter
                If String.IsNullOrEmpty(searchLower) Then Return True
                
                Dim itemName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not Convert.IsDBNull(row("itemName")), row("itemName").ToString().ToLower(), String.Empty)
                Dim category As String = If(row.Table.Columns.Contains("category") AndAlso Not Convert.IsDBNull(row("category")), row("category").ToString().ToLower(), String.Empty)
                Dim description As String = If(row.Table.Columns.Contains("description") AndAlso Not Convert.IsDBNull(row("description")), row("description").ToString().ToLower(), String.Empty)
                Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not Convert.IsDBNull(row("location")), row("location").ToString().ToLower(), String.Empty)
                
                Return itemName.Contains(searchLower) OrElse category.Contains(searchLower) OrElse description.Contains(searchLower) OrElse location.Contains(searchLower)
            End Function).ToArray()
            
            propertyManagementGrid.Rows.Clear()
            For Each row As DataRow In filteredRows
                Dim propertyNo As String = ""
                Dim itemName As String = ""
                Dim category As String = ""
                Dim description As String = ""
                Dim location As String = ""
                Dim department As String = ""
                Dim condition As String = ""
                Dim propertyStatus As String = ""
                
                Try
                    If row.Table.Columns.Contains("propertyNumber") AndAlso Not Convert.IsDBNull(row("propertyNumber")) Then
                        propertyNo = row("propertyNumber").ToString()
                    ElseIf row.Table.Columns.Contains("propertyId") AndAlso Not Convert.IsDBNull(row("propertyId")) Then
                        propertyNo = row("propertyId").ToString()
                    End If
                    If row.Table.Columns.Contains("itemName") AndAlso Not Convert.IsDBNull(row("itemName")) Then
                        itemName = row("itemName").ToString()
                    End If
                    If row.Table.Columns.Contains("category") AndAlso Not Convert.IsDBNull(row("category")) Then
                        category = row("category").ToString()
                    End If
                    If row.Table.Columns.Contains("description") AndAlso Not Convert.IsDBNull(row("description")) Then
                        description = row("description").ToString()
                    End If
                    If row.Table.Columns.Contains("location") AndAlso Not Convert.IsDBNull(row("location")) Then
                        location = row("location").ToString()
                    End If
                    If row.Table.Columns.Contains("assignedDepartment") AndAlso Not Convert.IsDBNull(row("assignedDepartment")) Then
                        department = row("assignedDepartment").ToString()
                    End If
                    If row.Table.Columns.Contains("condition") AndAlso Not Convert.IsDBNull(row("condition")) Then
                        condition = row("condition").ToString()
                    End If
                    If row.Table.Columns.Contains("status") AndAlso Not Convert.IsDBNull(row("status")) Then
                        propertyStatus = row("status").ToString()
                    End If
                Catch colEx As Exception
                    System.Diagnostics.Debug.WriteLine("Column access error: " & colEx.Message)
                End Try
                
                Dim quantity As Integer = 1 ' Properties are typically 1 per item
                
                propertyManagementGrid.Rows.Add(propertyNo, itemName, category, description, location, department, condition, propertyStatus, quantity)
            Next
        Catch ex As Exception
            MessageBox.Show("Error searching properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isSearching = False
        End Try
    End Sub

    Private Sub LoadPropertyData()
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
            
            ' Load all available properties from database with filters
            Dim dt As DataTable = DatabaseConnection.GetAllProperties(Nothing, "", categoryFilter, Nothing, statusFilter)
            
            If dt Is Nothing Then
                MessageBox.Show("Unable to connect to the database. Please ensure MySQL is running and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Store original data for search
            originalData = dt.Copy()
            
            ' Clear existing data
            propertyManagementGrid.Rows.Clear()
            
            ' Populate DataGridView
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim propertyNo As String = ""
                    Dim itemName As String = ""
                    Dim category As String = ""
                    Dim description As String = ""
                    Dim location As String = ""
                    Dim department As String = ""
                    Dim condition As String = ""
                    Dim propertyStatus As String = ""
                    
                    ' Handle different possible column names
                    Try
                        If row.Table.Columns.Contains("propertyNumber") AndAlso Not Convert.IsDBNull(row("propertyNumber")) Then
                            propertyNo = row("propertyNumber").ToString()
                        ElseIf row.Table.Columns.Contains("propertyId") AndAlso Not Convert.IsDBNull(row("propertyId")) Then
                            propertyNo = row("propertyId").ToString()
                        End If
                        If row.Table.Columns.Contains("itemName") AndAlso Not Convert.IsDBNull(row("itemName")) Then
                            itemName = row("itemName").ToString()
                        End If
                        If row.Table.Columns.Contains("category") AndAlso Not Convert.IsDBNull(row("category")) Then
                            category = row("category").ToString()
                        End If
                        If row.Table.Columns.Contains("description") AndAlso Not Convert.IsDBNull(row("description")) Then
                            description = row("description").ToString()
                        End If
                        If row.Table.Columns.Contains("location") AndAlso Not Convert.IsDBNull(row("location")) Then
                            location = row("location").ToString()
                        End If
                        If row.Table.Columns.Contains("assignedDepartment") AndAlso Not Convert.IsDBNull(row("assignedDepartment")) Then
                            department = row("assignedDepartment").ToString()
                        End If
                        If row.Table.Columns.Contains("condition") AndAlso Not Convert.IsDBNull(row("condition")) Then
                            condition = row("condition").ToString()
                        End If
                        If row.Table.Columns.Contains("status") AndAlso Not Convert.IsDBNull(row("status")) Then
                            propertyStatus = row("status").ToString()
                        End If
                    Catch colEx As Exception
                        ' Handle column access errors gracefully
                        System.Diagnostics.Debug.WriteLine("Column access error: " & colEx.Message)
                    End Try
                    
                    Dim quantity As Integer = 1 ' Properties are typically 1 per item
                    
                    propertyManagementGrid.Rows.Add(propertyNo, itemName, category, description, location, department, condition, propertyStatus, quantity)
                Next
            End If
            
            ' Auto-size columns
            propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            Dim errorMsg As String = "Unable to connect to the database. Please ensure MySQL is running and try again."
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            System.Diagnostics.Debug.WriteLine("PropertyInventory LoadPropertyData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnrequestproperty_Click(sender As Object, e As System.EventArgs)
        Dim addRequest As New AddPropertyRequest()
        addRequest.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addRequest)
    End Sub

    Private Sub btnrequestproperty_Click_1(sender As Object, e As System.EventArgs) Handles btnrequestproperty.Click
        ' Load AddPropertyRequest into parent dashboard
        Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddPropertyRequest())
        Else
            ' Fallback: add directly to parent
            Dim addPropertyRequest As New AddPropertyRequest()
            addPropertyRequest.Dock = DockStyle.Fill
            Me.Parent.Controls.Clear()
            Me.Parent.Controls.Add(addPropertyRequest)
        End If
    End Sub
    
    Private Sub propertyManagementGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellClick
        ' Auto-fill property request form when clicking a row
        If e.RowIndex >= 0 AndAlso e.RowIndex < propertyManagementGrid.Rows.Count Then
            Try
                Dim selectedRow As DataGridViewRow = propertyManagementGrid.Rows(e.RowIndex)
                
                ' Column order: propertyNo (0), itemName (1), category (2), description (3), location (4), department (5), condition (6), status (7), quantity (8)
                Dim itemName As String = If(selectedRow.Cells.Count > 1 AndAlso selectedRow.Cells(1).Value IsNot Nothing, selectedRow.Cells(1).Value.ToString(), "")
                Dim itemDescription As String = If(selectedRow.Cells.Count > 3 AndAlso selectedRow.Cells(3).Value IsNot Nothing, selectedRow.Cells(3).Value.ToString(), "")
                
                ' Get staff profile for auto-fill
                Dim requesterName As String = ""
                Dim position As String = ""
                Dim department As String = ""
                Dim currentDate As String = Date.Now.ToString("yyyy-MM-dd")
                
                If SessionContext.CurrentUserID.HasValue Then
                    Try
                        Dim profile As System.Collections.Generic.Dictionary(Of String, Object) = DatabaseConnection.GetStaffProfile(SessionContext.CurrentUserID.Value)
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
                            If profile.ContainsKey("departmentId") AndAlso profile("departmentId") IsNot Nothing Then
                                Try
                                    Dim deptID As Integer = Convert.ToInt32(profile("departmentId"))
                                    Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
                                    For Each row As DataRow In dt.Rows
                                        Dim rowDeptID As Integer = 0
                                        If row.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(row("departmentId")) Then
                                            Integer.TryParse(row("departmentId").ToString(), rowDeptID)
                                        ElseIf row.Table.Columns.Contains("department_id") AndAlso Not IsDBNull(row("department_id")) Then
                                            Integer.TryParse(row("department_id").ToString(), rowDeptID)
                                        End If
                                        If rowDeptID = deptID Then
                                            If row.Table.Columns.Contains("departmentName") Then
                                                department = row("departmentName").ToString()
                                            ElseIf row.Table.Columns.Contains("department_name") Then
                                                department = row("department_name").ToString()
                                            End If
                                            Exit For
                                        End If
                                    Next
                                Catch
                                End Try
                            End If
                        End If
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine("GetStaffProfile Error in CellClick: " & ex.Message)
                    End Try
                End If
                
                ' Navigate to request form with pre-filled data
                Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
                If parentDashboard IsNot Nothing Then
                    Dim requestForm As New AddPropertyRequest(itemName, itemDescription, requesterName, position, department, currentDate)
                    parentDashboard.LoadUserControl(requestForm)
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("PropertyInventory CellClick Error: " & ex.Message)
                MessageBox.Show("Error loading request form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
