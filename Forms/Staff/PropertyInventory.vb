Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Collections.Generic

Public Class PropertyInventory
    Private originalData As DataTable
    Private isSearching As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub PropertyInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFilters()
        LoadPropertiesData()
        
        ' Wire up events
        AddHandler txtSearch.TextChanged, AddressOf TxtSearch_TextChanged
        AddHandler cboCategory.SelectedIndexChanged, AddressOf Filter_Changed
        AddHandler cboCondition.SelectedIndexChanged, AddressOf Filter_Changed
        AddHandler cboStatus.SelectedIndexChanged, AddressOf Filter_Changed
        AddHandler dgvProperties.CellDoubleClick, AddressOf DgvProperties_CellDoubleClick
    End Sub

    Private Sub InitializeFilters()
        ' Initialize Category filter - Load from database to ensure consistency
        cboCategory.Items.Clear()
        cboCategory.Items.Add("All Categories")
        
        Try
            ' Load categories from database
            Dim categoriesTable As DataTable = modDB.GetCategories("property")
            If categoriesTable IsNot Nothing AndAlso categoriesTable.Rows.Count > 0 Then
                For Each row As DataRow In categoriesTable.Rows
                    Dim catName As String = ""
                    If row.Table.Columns.Contains("categoryName") AndAlso Not row.IsNull("categoryName") Then
                        catName = row("categoryName").ToString()
                    ElseIf row.Table.Columns.Contains("category_name") AndAlso Not row.IsNull("category_name") Then
                        catName = row("category_name").ToString()
                    End If
                    
                    If Not String.IsNullOrEmpty(catName) AndAlso Not cboCategory.Items.Contains(catName) Then
                        cboCategory.Items.Add(catName)
                    End If
                Next
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[PropertyInventory] Error loading categories: " & ex.Message)
        End Try
        
        ' Add fallback categories if none were loaded from database
        If cboCategory.Items.Count = 1 Then
            cboCategory.Items.AddRange(New String() {
                "Office Equipment", "IT Equipment", "Furniture", "Vehicles",
                "Laboratory Apparatus", "Books and Publications",
                "Building and Fixtures", "Tools and Instruments", "Others"
            })
        End If
        
        cboCategory.SelectedIndex = 0

        ' Initialize Condition filter
        cboCondition.Items.Clear()
        cboCondition.Items.Add("All Conditions")
        cboCondition.Items.AddRange(New String() {"Good", "Needs Repair", "Damaged"})
        cboCondition.SelectedIndex = 0

        ' Initialize Status filter
        cboStatus.Items.Clear()
        cboStatus.Items.Add("All Status")
        cboStatus.Items.AddRange(New String() {"Active", "Borrowed", "For Disposal", "Lost", "Cost"})
        cboStatus.SelectedIndex = 0
    End Sub

    Private Sub LoadPropertiesData()
        Try
            dgvProperties.Rows.Clear()
            
            ' Get filter values
            Dim categoryFilter As String = If(cboCategory.SelectedIndex > 0, cboCategory.SelectedItem.ToString(), "")
            Dim conditionFilter As String = If(cboCondition.SelectedIndex > 0, cboCondition.SelectedItem.ToString(), "")
            Dim statusFilter As String = If(cboStatus.SelectedIndex > 0, cboStatus.SelectedItem.ToString(), "")

            ' Load properties from database - using the same function as UC_PropertyManagement1
            Dim dt As DataTable = modDB.GetAllProperties(Nothing, conditionFilter, categoryFilter, Nothing, statusFilter)
            
            If dt Is Nothing Then
                MessageBox.Show("Unable to connect to database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Store original data for search
            originalData = dt.Copy()

            ' Populate DataGridView
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    ' Extract all fields from database
                    Dim propertyId As String = If(row.IsNull("propertyId"), "", row("propertyId").ToString())
                    Dim itemName As String = If(row.IsNull("itemName"), "", row("itemName").ToString())
                    Dim category As String = If(row.IsNull("category"), "", row("category").ToString())
                    Dim description As String = If(row.IsNull("description"), "", row("description").ToString())
                    Dim propertyNumber As String = If(row.IsNull("propertyNumber"), "", row("propertyNumber").ToString())
                    Dim serialNumber As String = If(row.IsNull("serialNumber"), "", row("serialNumber").ToString())
                    Dim location As String = If(row.IsNull("location"), "", row("location").ToString())
                    Dim condition As String = If(row.IsNull("condition"), "Good", row("condition").ToString())
                    Dim status As String = If(row.IsNull("status"), "Active", row("status").ToString())
                    
                    ' Get assigned employee name
                    Dim assignedTo As String = ""
                    If row.Table.Columns.Contains("assignedEmployee") AndAlso Not row.IsNull("assignedEmployee") Then
                        assignedTo = row("assignedEmployee").ToString()
                    ElseIf row.Table.Columns.Contains("assignedTo") AndAlso Not row.IsNull("assignedTo") Then
                        assignedTo = row("assignedTo").ToString()
                    End If
                    
                    ' Get department name
                    Dim department As String = ""
                    If row.Table.Columns.Contains("departmentName") AndAlso Not row.IsNull("departmentName") Then
                        department = row("departmentName").ToString()
                    ElseIf row.Table.Columns.Contains("assignedDepartment") AndAlso Not row.IsNull("assignedDepartment") Then
                        department = row("assignedDepartment").ToString()
                    End If
                    
                    ' Hidden fields (for internal use)
                    Dim acquisitionDate As String = ""
                    If row.Table.Columns.Contains("acquisitionDate") AndAlso Not row.IsNull("acquisitionDate") Then
                        acquisitionDate = Convert.ToDateTime(row("acquisitionDate")).ToString("yyyy-MM-dd")
                    End If
                    
                    Dim acquisitionCost As String = ""
                    If row.Table.Columns.Contains("acquisitionCost") AndAlso Not row.IsNull("acquisitionCost") Then
                        acquisitionCost = Convert.ToDecimal(row("acquisitionCost")).ToString("N2")
                    End If
                    
                    Dim sourceOfFunds As String = If(row.IsNull("sourceOfFunds"), "", row("sourceOfFunds").ToString())

                    ' Add row to DataGridView
                    dgvProperties.Rows.Add(
                        propertyId,
                        itemName,
                        category,
                        description,
                        propertyNumber,
                        serialNumber,
                        location,
                        condition,
                        status,
                        assignedTo,
                        department,
                        acquisitionDate,
                        acquisitionCost,
                        sourceOfFunds
                    )
                Next
            End If

            ' Update total count
            lblTotal.Text = "Total Properties: " & dgvProperties.Rows.Count.ToString()

        Catch ex As Exception
            MessageBox.Show("Error loading properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("PropertyInventory LoadPropertiesData Error: " & ex.Message)
        End Try
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs)
        If isSearching Then Return
        ApplySearch()
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        LoadPropertiesData()
        ' Reapply search if there's search text
        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            ApplySearch()
        End If
    End Sub

    Private Sub ApplySearch()
        If originalData Is Nothing OrElse originalData.Rows.Count = 0 Then Return
        If isSearching Then Return
        
        isSearching = True
        
        Try
            Dim searchText As String = txtSearch.Text.Trim().ToLower()
            
            dgvProperties.Rows.Clear()
            
            Dim filteredRows As IEnumerable(Of DataRow) = originalData.AsEnumerable()
            
            ' Apply search filter
            If Not String.IsNullOrWhiteSpace(searchText) Then
                filteredRows = filteredRows.Where(Function(row)
                    Dim itemName As String = If(row.IsNull("itemName"), "", row("itemName").ToString().ToLower())
                    Dim category As String = If(row.IsNull("category"), "", row("category").ToString().ToLower())
                    Dim description As String = If(row.IsNull("description"), "", row("description").ToString().ToLower())
                    Dim location As String = If(row.IsNull("location"), "", row("location").ToString().ToLower())
                    Dim propertyNumber As String = If(row.IsNull("propertyNumber"), "", row("propertyNumber").ToString().ToLower())
                    Dim serialNumber As String = If(row.IsNull("serialNumber"), "", row("serialNumber").ToString().ToLower())
                    
                    Return itemName.Contains(searchText) OrElse 
                           category.Contains(searchText) OrElse 
                           description.Contains(searchText) OrElse 
                           location.Contains(searchText) OrElse 
                           propertyNumber.Contains(searchText) OrElse 
                           serialNumber.Contains(searchText)
                End Function)
            End If
            
            ' Populate filtered results
            For Each row As DataRow In filteredRows
                Dim propertyId As String = If(row.IsNull("propertyId"), "", row("propertyId").ToString())
                Dim itemName As String = If(row.IsNull("itemName"), "", row("itemName").ToString())
                Dim category As String = If(row.IsNull("category"), "", row("category").ToString())
                Dim description As String = If(row.IsNull("description"), "", row("description").ToString())
                Dim propertyNumber As String = If(row.IsNull("propertyNumber"), "", row("propertyNumber").ToString())
                Dim serialNumber As String = If(row.IsNull("serialNumber"), "", row("serialNumber").ToString())
                Dim location As String = If(row.IsNull("location"), "", row("location").ToString())
                Dim condition As String = If(row.IsNull("condition"), "Good", row("condition").ToString())
                Dim status As String = If(row.IsNull("status"), "Active", row("status").ToString())
                
                Dim assignedTo As String = ""
                If row.Table.Columns.Contains("assignedEmployee") AndAlso Not row.IsNull("assignedEmployee") Then
                    assignedTo = row("assignedEmployee").ToString()
                ElseIf row.Table.Columns.Contains("assignedTo") AndAlso Not row.IsNull("assignedTo") Then
                    assignedTo = row("assignedTo").ToString()
                End If
                
                Dim department As String = ""
                If row.Table.Columns.Contains("departmentName") AndAlso Not row.IsNull("departmentName") Then
                    department = row("departmentName").ToString()
                ElseIf row.Table.Columns.Contains("assignedDepartment") AndAlso Not row.IsNull("assignedDepartment") Then
                    department = row("assignedDepartment").ToString()
                End If
                
                Dim acquisitionDate As String = ""
                If row.Table.Columns.Contains("acquisitionDate") AndAlso Not row.IsNull("acquisitionDate") Then
                    acquisitionDate = Convert.ToDateTime(row("acquisitionDate")).ToString("yyyy-MM-dd")
                End If
                
                Dim acquisitionCost As String = ""
                If row.Table.Columns.Contains("acquisitionCost") AndAlso Not row.IsNull("acquisitionCost") Then
                    acquisitionCost = Convert.ToDecimal(row("acquisitionCost")).ToString("N2")
                End If
                
                Dim sourceOfFunds As String = If(row.IsNull("sourceOfFunds"), "", row("sourceOfFunds").ToString())

                dgvProperties.Rows.Add(
                    propertyId,
                    itemName,
                    category,
                    description,
                    propertyNumber,
                    serialNumber,
                    location,
                    condition,
                    status,
                    assignedTo,
                    department,
                    acquisitionDate,
                    acquisitionCost,
                    sourceOfFunds
                )
            Next
            
            lblTotal.Text = "Total Properties: " & dgvProperties.Rows.Count.ToString()
            
        Finally
            isSearching = False
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadPropertiesData()
        txtSearch.Clear()
        MessageBox.Show("Property inventory refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnRequest_Click(sender As Object, e As EventArgs) Handles btnRequest.Click
        ' Open request form without pre-filled data
        Dim parentDashboard = TryCast(Me.FindForm(), StaffDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddPropertyRequest())
        End If
    End Sub

    Private Sub DgvProperties_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProperties.CellDoubleClick
        ' When user double-clicks a property, open request form with pre-filled data
        If e.RowIndex < 0 Then Return
        
        Try
            Dim row As DataGridViewRow = dgvProperties.Rows(e.RowIndex)
            Dim propertyId As String = If(row.Cells("colPropertyId").Value IsNot Nothing, row.Cells("colPropertyId").Value.ToString(), "")
            Dim itemName As String = If(row.Cells("colItemName").Value IsNot Nothing, row.Cells("colItemName").Value.ToString(), "")
            Dim description As String = If(row.Cells("colDescription").Value IsNot Nothing, row.Cells("colDescription").Value.ToString(), "")
            Dim departmentName As String = If(row.Cells("colDepartment").Value IsNot Nothing, row.Cells("colDepartment").Value.ToString(), "")
            Dim assignedTo As String = If(row.Cells("colAssignedTo").Value IsNot Nothing, row.Cells("colAssignedTo").Value.ToString(), "")
            Dim status As String = If(row.Cells("colStatus").Value IsNot Nothing, row.Cells("colStatus").Value.ToString(), "")
            
            ' Check if property is already assigned
            If Not String.IsNullOrWhiteSpace(assignedTo) OrElse status = "Borrowed" Then
                MessageBox.Show("This property is already assigned to someone. You cannot request an assigned property.", _
                               "Property Already Assigned", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Check if property is available
            If status <> "Active" Then
                MessageBox.Show("This property is not available for request. Current status: " & status, _
                               "Property Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Navigate to request form with pre-filled data (itemName, description, quantity)
            Dim parentDashboard = TryCast(Me.FindForm(), StaffDashboard)
            If parentDashboard IsNot Nothing Then
                Dim requestForm As New AddPropertyRequest(itemName, description, 1)
                parentDashboard.LoadUserControl(requestForm)
            End If
            
        Catch ex As Exception
            MessageBox.Show("Error loading request form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
