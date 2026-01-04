Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Linq


Public Class UC_PropertyRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyRequests)
    End Sub

    Private Sub prm_table1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles prm_table1.CellContentClick
        If e.RowIndex >= 0 AndAlso prm_table1.Columns.Contains("action_edit") AndAlso
           e.ColumnIndex = prm_table1.Columns("action_edit").Index Then

            Dim reqIDValue As Object = prm_table1.Rows(e.RowIndex).Cells("request_id").Value
            Dim reqID As String = If(reqIDValue IsNot Nothing, reqIDValue.ToString(), "")
            MessageBox.Show("Edit Request: " & reqID, "Action", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Example: open edit request UC
            ' Dim uc As New UC_EditRequest()
            ' uc.LoadRequestData(reqID)
            ' Me.Parent.Controls.Add(uc) : uc.BringToFront()
        End If
    End Sub



    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        ' No restrictions for Super Admin, Admin, and Custodian

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddPropertyRequest())
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        ' No restrictions for Super Admin, Admin, and Custodian

        MessageBox.Show("Delete request functionality here")
    End Sub

    Private Sub Assign_Click(sender As Object, e As EventArgs)
        ' No restrictions for Super Admin, Admin, and Custodian
        ' Validate that a request is selected
        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property request to assign.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = prm_table1.SelectedRows(0)
        Dim dt As DataTable = TryCast(prm_table1.DataSource, DataTable)
        
        ' Get request ID from DataTable source (more reliable than DataGridView cells)
        Dim requestIDValue As Object = Nothing
        If dt IsNot Nothing Then
            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            ' Try both camelCase and snake_case column names
            If dt.Columns.Contains("requestId") Then
                requestIDValue = dataRow("requestId")
            ElseIf dt.Columns.Contains("request_id") Then
                requestIDValue = dataRow("request_id")
            End If
        End If
        
        ' Fallback to DataGridView cells if DataTable not available
        If requestIDValue Is Nothing Then
            If prm_table1.Columns.Contains("request_id") Then
                requestIDValue = selectedRow.Cells("request_id").Value
            ElseIf prm_table1.Columns.Contains("RequestID") Then
                requestIDValue = selectedRow.Cells("RequestID").Value
            ElseIf prm_table1.Columns.Count > 0 Then
                requestIDValue = selectedRow.Cells(0).Value
            End If
        End If

        If requestIDValue Is Nothing OrElse IsDBNull(requestIDValue) OrElse String.IsNullOrEmpty(requestIDValue.ToString()) Then
            MessageBox.Show("Invalid request selected. Please select a valid property request.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get request status to validate - prefer DataTable source
        Dim requestStatus As String = ""
        If dt IsNot Nothing Then
            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            If dt.Columns.Contains("status") AndAlso Not IsDBNull(dataRow("status")) Then
                requestStatus = dataRow("status").ToString()
            End If
        Else
            ' Fallback to DataGridView cells
            If prm_table1.Columns.Contains("status") Then
                requestStatus = If(selectedRow.Cells("status").Value IsNot Nothing, selectedRow.Cells("status").Value.ToString(), "")
            ElseIf prm_table1.Columns.Contains("Status") Then
                requestStatus = If(selectedRow.Cells("Status").Value IsNot Nothing, selectedRow.Cells("Status").Value.ToString(), "")
            End If
        End If

        ' Only allow assigning approved or pending requests
        If Not String.IsNullOrEmpty(requestStatus) AndAlso requestStatus.ToLower() = "rejected" Then
            MessageBox.Show("Cannot assign a rejected request. Please select an approved or pending request.", "Invalid Request Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check for SADashboard first (Super Admin)
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            Dim assignForm As New AssignRequestManagement()
            Dim requestID As Integer = 0
            If Integer.TryParse(requestIDValue.ToString(), requestID) Then
                assignForm.RequestID = requestID
            End If
            saDashboard.LoadUserControl(assignForm)
            Return
        End If
        
        ' Check for AdminDashboard
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            Dim assignForm As New AssignRequestManagement()
            Dim requestID As Integer = 0
            If Integer.TryParse(requestIDValue.ToString(), requestID) Then
                assignForm.RequestID = requestID
            End If
            parentDashboard.LoadUserControl(assignForm)
        Else
            MessageBox.Show("Unable to open assignment form. Parent dashboard not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub UC_PropertyRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFilters()
        LoadRequestData()
        ApplyPermissionState()

        ' Wire up search textbox - use maintenancemanagementsearchbar from designer
        If maintenancemanagementsearchbar IsNot Nothing Then
            RemoveHandler maintenancemanagementsearchbar.TextChanged, AddressOf PropertyRequestSearch_TextChanged
            AddHandler maintenancemanagementsearchbar.TextChanged, AddressOf PropertyRequestSearch_TextChanged
        End If
    End Sub
    
    Private Sub InitializeFilters()
        ' Initialize status filter if it exists
        Dim statusFilterNames() As String = {"pm_cbobx_status", "statusFilter", "cbStatus", "filter"}
        For Each nm As String In statusFilterNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                Dim statusCb As ComboBox = CType(found(0), ComboBox)
                statusCb.Items.Clear()
                statusCb.Items.Add("All Status")
                statusCb.Items.AddRange(New String() {"Pending", "Approved", "Rejected", "Assigned"})
                statusCb.SelectedIndex = 0
                AddHandler statusCb.SelectedIndexChanged, AddressOf Filter_Changed
                Exit For
            End If
        Next
        
        ' Initialize category filter if it exists
        Dim categoryFilterNames() As String = {"pm_cbobx_categ", "categoryFilter", "cbCategory"}
        For Each nm As String In categoryFilterNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                Dim categoryCb As ComboBox = CType(found(0), ComboBox)
                categoryCb.Items.Clear()
                categoryCb.Items.Add("All Categories")
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
                            If Not String.IsNullOrEmpty(categoryName) AndAlso Not categoryCb.Items.Contains(categoryName) Then
                                categoryCb.Items.Add(categoryName)
                            End If
                        Next
                    End If
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] InitializeFilters Category Exception: " & ex.Message)
                End Try
                categoryCb.SelectedIndex = 0
                AddHandler categoryCb.SelectedIndexChanged, AddressOf Filter_Changed
                Exit For
            End If
        Next
    End Sub
    
    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        ' Reload data with filters
        Dim searchText As String = ""
        If maintenancemanagementsearchbar IsNot Nothing Then
            searchText = maintenancemanagementsearchbar.Text
        End If
        ApplyPropertyRequestSearch(searchText)
    End Sub

    Private originalRequestData As DataTable = Nothing
    Private isSearchingRequests As Boolean = False

    Private Sub PropertyRequestSearch_TextChanged(sender As Object, e As EventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb Is Nothing Then Return
        ApplyPropertyRequestSearch(tb.Text)
    End Sub

    Private Sub ApplyPropertyRequestSearch(searchText As String)
        If originalRequestData Is Nothing Then
            Try
                Dim dt As DataTable = modDB.GetAllPropertyRequests()
                If dt IsNot Nothing Then
                    originalRequestData = dt.Copy()
                End If
            Catch
                Return
            End Try
        End If

        If originalRequestData Is Nothing Then Return
        If isSearchingRequests Then Return
        isSearchingRequests = True

        Try
            Dim searchLower As String = If(String.IsNullOrWhiteSpace(searchText), String.Empty, searchText.Trim().ToLower())
            
            ' Get filter values
            Dim statusFilter As String = String.Empty
            Dim statusFilterNames() As String = {"pm_cbobx_status", "statusFilter", "cbStatus", "filter"}
            For Each nm As String In statusFilterNames
                Dim found() As Control = Me.Controls.Find(nm, True)
                If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                    Dim cb As ComboBox = CType(found(0), ComboBox)
                    If cb.SelectedIndex > 0 Then
                        statusFilter = cb.SelectedItem.ToString()
                    End If
                    Exit For
                End If
            Next
            
            Dim categoryFilter As String = String.Empty
            Dim categoryFilterNames() As String = {"pm_cbobx_categ", "categoryFilter", "cbCategory"}
            For Each nm As String In categoryFilterNames
                Dim found() As Control = Me.Controls.Find(nm, True)
                If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                    Dim cb As ComboBox = CType(found(0), ComboBox)
                    If cb.SelectedIndex > 0 Then
                        categoryFilter = cb.SelectedItem.ToString()
                    End If
                    Exit For
                End If
            Next

            Dim filtered = originalRequestData.AsEnumerable().Where(Function(row)
                ' Apply status filter
                If Not String.IsNullOrEmpty(statusFilter) Then
                    Dim rowStatus As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), String.Empty)
                    If Not String.Equals(rowStatus, statusFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                End If
                
                ' Apply category filter (if category column exists)
                If Not String.IsNullOrEmpty(categoryFilter) Then
                    Dim rowCategory As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString(), String.Empty)
                    If Not String.Equals(rowCategory, categoryFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                End If
                
                ' Apply search filter
                If String.IsNullOrEmpty(searchLower) Then Return True
                
                Dim requester As String = If(row.Table.Columns.Contains("requesterName") AndAlso Not IsDBNull(row("requesterName")), row("requesterName").ToString().ToLower(), String.Empty)
                Dim dept As String = If(row.Table.Columns.Contains("department") AndAlso Not IsDBNull(row("department")), row("department").ToString().ToLower(), String.Empty)
                Dim itemName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString().ToLower(), String.Empty)
                Dim purpose As String = If(row.Table.Columns.Contains("purpose") AndAlso Not IsDBNull(row("purpose")), row("purpose").ToString().ToLower(), String.Empty)
                Dim status As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString().ToLower(), String.Empty)
                Dim position As String = If(row.Table.Columns.Contains("position") AndAlso Not IsDBNull(row("position")), row("position").ToString().ToLower(), String.Empty)
                Dim description As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString().ToLower(), String.Empty)
                
                Return requester.Contains(searchLower) OrElse dept.Contains(searchLower) OrElse itemName.Contains(searchLower) OrElse purpose.Contains(searchLower) OrElse status.Contains(searchLower) OrElse position.Contains(searchLower) OrElse description.Contains(searchLower)
            End Function)

            If filtered Is Nothing OrElse Not filtered.Any() Then
                prm_table1.DataSource = Nothing
                Dim totalLabel As Label = Nothing
                Dim foundControls() As Control = Me.Controls.Find("ttlpropertyrequestmanagement", True)
                If foundControls.Length > 0 Then totalLabel = TryCast(foundControls(0), Label)
                If totalLabel IsNot Nothing Then totalLabel.Text = "0"
            Else
                Dim dt As DataTable = filtered.CopyToDataTable()
                prm_table1.DataSource = dt
                Dim totalLabel As Label = Nothing
                Dim foundControls() As Control = Me.Controls.Find("ttlpropertyrequestmanagement", True)
                If foundControls.Length > 0 Then totalLabel = TryCast(foundControls(0), Label)
                If totalLabel IsNot Nothing Then totalLabel.Text = dt.Rows.Count.ToString()
            End If
        Catch ex As Exception
            If TypeOf ex Is InvalidOperationException Then
                prm_table1.DataSource = Nothing
                Dim totalLabel As Label = Nothing
                Dim foundControls() As Control = Me.Controls.Find("ttlpropertyrequestmanagement", True)
                If foundControls.Length > 0 Then totalLabel = TryCast(foundControls(0), Label)
                If totalLabel IsNot Nothing Then totalLabel.Text = "0"
            Else
                MessageBox.Show("Error searching property requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            isSearchingRequests = False
        End Try
    End Sub

    Private Sub ApplyPermissionState()
        ' Super Admin, Admin, and Custodian have full access - ALL buttons enabled
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If btnApprove IsNot Nothing Then btnApprove.Enabled = hasFullAccess
        If btnReject IsNot Nothing Then btnReject.Enabled = hasFullAccess
        If assign IsNot Nothing Then assign.Enabled = hasFullAccess

        ' prm_btn_update control may not exist in the designer for this UC; lookup safely by name and wire handler
        Try
            Dim found() As Control = Me.Controls.Find("prm_btn_update", True)
            If found IsNot Nothing AndAlso found.Length > 0 Then
                Dim btn As Button = TryCast(found(0), Button)
                If btn IsNot Nothing Then
                    btn.Enabled = hasFullAccess
                    ' ensure click handler is wired
                    RemoveHandler btn.Click, AddressOf prm_btn_update_Click
                    AddHandler btn.Click, AddressOf prm_btn_update_Click
                End If
            End If
        Catch
            ' ignore errors
        End Try

    End Sub

    Private Sub LoadRequestData()
        Try
            Dim dt As DataTable = modDB.GetAllPropertyRequests()

            If dt Is Nothing Then
                MessageBox.Show("Unable to load property requests. Please check your database connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Store original data for search
            originalRequestData = dt.Copy()

            ' Prevent auto-generated duplicate columns and bind to the existing designer columns
            prm_table1.AutoGenerateColumns = False
            prm_table1.DataSource = Nothing

            ' Map designer columns to data properties (camelCase from DB)
            ' Show only: Requester Name, Position, Item Name, Description, Purpose, Quantity Requested, Date of Request, Status
            For Each col As DataGridViewColumn In prm_table1.Columns
                Select Case col.Name.ToLower()
                    Case "requestid", "request_id"
                        col.DataPropertyName = "requestId"
                        col.Visible = False
                    Case "requestername", "requester_name"
                        col.DataPropertyName = "requesterName"
                        col.HeaderText = "Requester Name"
                        col.Visible = True
                    Case "position"
                        col.DataPropertyName = "position"
                        col.HeaderText = "Position"
                        col.Visible = True
                    Case "itemname", "item_name"
                        col.DataPropertyName = "itemName"
                        col.HeaderText = "Item Name"
                        col.Visible = True
                    Case "description"
                        col.DataPropertyName = "description"
                        col.HeaderText = "Description"
                        col.Visible = True
                    Case "purpose"
                        col.DataPropertyName = "purpose"
                        col.HeaderText = "Purpose"
                        col.Visible = True
                    Case "quantityrequested", "quantity_requested"
                        col.DataPropertyName = "quantityRequested"
                        col.HeaderText = "Quantity Requested"
                        col.Visible = True
                    Case "dateofrequest", "dateofreques", "date_of_request"
                        col.DataPropertyName = "dateOfRequest"
                        col.HeaderText = "Date of Request"
                        col.Visible = True
                    Case "status"
                        col.DataPropertyName = "status"
                        col.HeaderText = "Status"
                        col.Visible = True
                    Case Else
                        ' Hide all other columns (departmentId, createdAt, updatedAt, approvedBy, etc.)
                        col.Visible = False
                End Select
            Next

            prm_table1.DataSource = dt
            prm_table1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            prm_table1.ReadOnly = True
            prm_table1.AllowUserToAddRows = False
            prm_table1.AllowUserToDeleteRows = False
            prm_table1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            ' Update total count
            Dim totalLabel As Label = Nothing
            Dim foundControls() As Control = Me.Controls.Find("ttlpropertyrequestmanagement", True)
            If foundControls.Length > 0 Then
                totalLabel = TryCast(foundControls(0), Label)
            End If
            If totalLabel IsNot Nothing Then
                totalLabel.Text = If(dt.Rows.Count > 0, dt.Rows.Count.ToString(), "0")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading property requests: " & GetUserFriendlyErrorMessage(ex, "load property requests"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("LoadRequestData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function GetUserFriendlyErrorMessage(ex As Exception, action As String) As String
        If ex Is Nothing Then Return "An unexpected error occurred."
        If ex.Message.Contains("SupplyID") OrElse ex.Message.Contains("Column named") Then
            Return "Data structure error. Please contact system administrator."
        End If
        Return "Unable to " & action & ". " & ex.Message
    End Function



    ' ----------------------------------------------------------------------
    ' PRINT PAR LOGIC — FULLY CONNECTED TO PROPERTYCARD
    ' ----------------------------------------------------------------------
    Private Sub printPAR_Click(sender As Object, e As EventArgs) Handles printPAR.Click
        ' Validate selection
        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property request to print PAR/ICS.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = prm_table1.SelectedRows(0)
            Dim dt As DataTable = TryCast(prm_table1.DataSource, DataTable)
            
            ' Get request ID from DataTable
            Dim requestId As Integer = 0
            If dt IsNot Nothing Then
                Dim rowIndex As Integer = selectedRow.Index
                Dim dataRow As DataRow = dt.Rows(rowIndex)
                If dt.Columns.Contains("requestId") Then
                    requestId = Convert.ToInt32(dataRow("requestId"))
                ElseIf dt.Columns.Contains("request_id") Then
                    requestId = Convert.ToInt32(dataRow("request_id"))
                End If
            End If
            
            System.Diagnostics.Debug.WriteLine($"[v0] UC_PropertyRequestManagement - Opening PAR/ICS for requestId: {requestId}")
            
            ' Open InventoryCustodianSlip form with requestId for autofill
            Dim icsForm As New InventoryCustodianSlip(requestId)
            icsForm.Show()
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[v0] UC_PropertyRequestManagement - Print PAR/ICS error: {ex.Message}")
            MessageBox.Show($"Error opening PAR/ICS form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub issuePropertyCard_Click(sender As Object, e As EventArgs) Handles issuePropertyCard.Click
        ' Validate selection
        If prm_table1.SelectedRows.Count = 0 AndAlso prm_table1.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a property request to issue acknowledgment.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim row As DataGridViewRow = If(prm_table1.SelectedRows.Count > 0, prm_table1.SelectedRows(0), prm_table1.CurrentRow)
            Dim dt As DataTable = CType(prm_table1.DataSource, DataTable)
            Dim dataRow As DataRow = dt.Rows(row.Index)
            
            ' Get request ID for better tracking
            Dim requestId As Integer = 0
            If dt.Columns.Contains("requestId") Then
                requestId = Convert.ToInt32(dataRow("requestId"))
            ElseIf dt.Columns.Contains("request_id") Then
                requestId = Convert.ToInt32(dataRow("request_id"))
            End If
            
            System.Diagnostics.Debug.WriteLine($"[v0] UC_PropertyRequestManagement - Opening Property Card for requestId: {requestId}")

            ' Open PropertyCard form with autofilled data
            Dim cardForm As New PropertyCard(dataRow)
            cardForm.Show()
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[v0] UC_PropertyRequestManagement - Issue property card error: {ex.Message}")
            MessageBox.Show($"Error opening property card: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to approve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = prm_table1.SelectedRows(0)
            Dim dt As DataTable = TryCast(prm_table1.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            ' Accept both camelCase and snake_case
            Dim requestIDValue As Object = Nothing
            If dt.Columns.Contains("requestId") Then
                requestIDValue = dataRow("requestId")
            ElseIf dt.Columns.Contains("request_id") Then
                requestIDValue = dataRow("request_id")
            End If
            Dim requestIDStr As String = If(requestIDValue IsNot Nothing AndAlso Not IsDBNull(requestIDValue), requestIDValue.ToString(), "")
            If String.IsNullOrEmpty(requestIDStr) OrElse Not Integer.TryParse(requestIDStr, Nothing) Then
                MessageBox.Show("Invalid request selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim requestID As Integer = Integer.Parse(requestIDStr)
            Dim statusValue As Object = If(dt.Columns.Contains("status"), dataRow("status"), Nothing)
            Dim currentStatus As String = If(statusValue IsNot Nothing AndAlso Not IsDBNull(statusValue), statusValue.ToString().ToLower(), "")

            If currentStatus = "approved" Then
                MessageBox.Show("This request is already approved.", "Already Approved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If currentStatus = "rejected" Then
                MessageBox.Show("This request has been rejected and cannot be approved.", "Request Rejected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Ask for approval remarks using professional dialog
            Dim remarks As String = ""
            Using remarksDialog As New RemarksDialog("Approval Remarks", "Approve Request", "Enter any remarks for this property request approval (optional)")
                If remarksDialog.ShowDialog() = DialogResult.OK Then
                    remarks = remarksDialog.Remarks
                End If
            End Using
            
            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

            If modDB.ApprovePropertyRequest(requestID, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, remarks:=remarks) Then
                MessageBox.Show("Request approved successfully. The property has been assigned to the requester.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadRequestData()
                
                ' Notify UC_PropertyManagement1 to refresh if it exists
                Try
                    Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
                    If saDashboard IsNot Nothing Then
                        ' Find UC_PropertyManagement1 in the dashboard panel and refresh it
                        For Each ctrl As Control In saDashboard.pnlFormLoader.Controls
                            If TypeOf ctrl Is UC_PropertyManagement1 Then
                                Dim propMgmt As UC_PropertyManagement1 = DirectCast(ctrl, UC_PropertyManagement1)
                                propMgmt.LoadPropertiesData()
                                System.Diagnostics.Debug.WriteLine("[v0] Refreshed UC_PropertyManagement1 after approval")
                                Exit For
                            End If
                        Next
                    End If
                Catch refreshEx As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Could not refresh UC_PropertyManagement1: " & refreshEx.Message)
                End Try
            Else
                MessageBox.Show("Failed to approve request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error approving request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to reject.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = prm_table1.SelectedRows(0)
            Dim dt As DataTable = TryCast(prm_table1.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            ' Try both camelCase and snake_case column names
            Dim requestIDValue As Object = Nothing
            If dt.Columns.Contains("requestId") Then
                requestIDValue = dataRow("requestId")
            ElseIf dt.Columns.Contains("request_id") Then
                requestIDValue = dataRow("request_id")
            End If
            Dim requestIDStr As String = If(requestIDValue IsNot Nothing AndAlso Not IsDBNull(requestIDValue), requestIDValue.ToString(), "")
            If String.IsNullOrEmpty(requestIDStr) OrElse Not Integer.TryParse(requestIDStr, Nothing) Then
                MessageBox.Show("Invalid request selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim requestID As Integer = Integer.Parse(requestIDStr)
            Dim statusValue As Object = If(dt.Columns.Contains("status"), dataRow("status"), Nothing)
            Dim currentStatus As String = If(statusValue IsNot Nothing AndAlso Not IsDBNull(statusValue), statusValue.ToString().ToLower(), "")

            If currentStatus = "rejected" Then
                MessageBox.Show("This request is already rejected.", "Already Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If currentStatus = "approved" Then
                Dim result As DialogResult = MessageBox.Show("This request is already approved. Do you want to reject it anyway?", "Request Already Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result <> DialogResult.Yes Then
                    Return
                End If
            End If

            ' Ask for rejection reason using professional dialog
            Dim remarks As String = ""
            Using remarksDialog As New RemarksDialog("Rejection Reason", "Reject Request", "Please provide a reason for rejecting this property request (required)")
                If remarksDialog.ShowDialog() <> DialogResult.OK Then
                    Return ' User cancelled
                End If
                remarks = remarksDialog.Remarks
                If String.IsNullOrWhiteSpace(remarks) Then
                    MessageBox.Show("Rejection reason is required.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End Using

            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

            If modDB.RejectPropertyRequest(requestID, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, remarks) Then
                MessageBox.Show("Request rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadRequestData()
            Else
                MessageBox.Show("Failed to reject request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error rejecting request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Changed to NOT use Handles to avoid compile error when control not present in designer
    Private Sub prm_btn_update_Click(sender As Object, e As EventArgs)
        ' Allow all users to refresh (not just SuperAdmin)
        Try
            LoadRequestData()
            MessageBox.Show("Property request list refreshed successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error refreshing property request list: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        ' Validate that a request is selected
        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property request to assign.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = prm_table1.SelectedRows(0)
            Dim dt As DataTable = TryCast(prm_table1.DataSource, DataTable)
            
            ' Get request ID from DataTable source
            Dim requestIDValue As Object = Nothing
            If dt IsNot Nothing Then
                Dim rowIndex As Integer = selectedRow.Index
                Dim dataRow As DataRow = dt.Rows(rowIndex)
                If dt.Columns.Contains("requestId") Then
                    requestIDValue = dataRow("requestId")
                ElseIf dt.Columns.Contains("request_id") Then
                    requestIDValue = dataRow("request_id")
                End If
            End If

            ' Fallback to DataGridView cells
            If requestIDValue Is Nothing OrElse IsDBNull(requestIDValue) Then
                If prm_table1.Columns.Contains("request_id") Then
                    requestIDValue = selectedRow.Cells("request_id").Value
                ElseIf prm_table1.Columns.Contains("RequestID") Then
                    requestIDValue = selectedRow.Cells("RequestID").Value
                ElseIf prm_table1.Columns.Count > 0 Then
                    requestIDValue = selectedRow.Cells(0).Value
                End If
            End If

            If requestIDValue Is Nothing OrElse IsDBNull(requestIDValue) OrElse String.IsNullOrEmpty(requestIDValue.ToString()) Then
                MessageBox.Show("Invalid request selected. Please select a valid property request.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim requestID As Integer = 0
            If Not Integer.TryParse(requestIDValue.ToString(), requestID) Then
                MessageBox.Show("Invalid request ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Check for SADashboard first (Super Admin)
            Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
            If saDashboard IsNot Nothing Then
                Dim assignForm As New AssignRequestManagement()
                assignForm.RequestID = requestID
                saDashboard.LoadUserControl(assignForm)
                Return
            End If

            ' Check for AdminDashboard
            Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
            If parentDashboard IsNot Nothing Then
                Dim assignForm As New AssignRequestManagement()
                assignForm.RequestID = requestID
                parentDashboard.LoadUserControl(assignForm)
            Else
                MessageBox.Show("Unable to open assignment form. Parent dashboard not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error assigning request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("btnAssign_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub issueRequisition_Click(sender As Object, e As EventArgs) Handles issueRequisition.Click
        ' Validate that a request is selected
        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property request to issue RIS.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = prm_table1.SelectedRows(0)
        Dim dt As DataTable = TryCast(prm_table1.DataSource, DataTable)

        ' Get request ID from DataTable source
        Dim requestIDValue As Object = Nothing
        If dt IsNot Nothing Then
            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            If dt.Columns.Contains("requestId") Then
                requestIDValue = dataRow("requestId")
            ElseIf dt.Columns.Contains("request_id") Then
                requestIDValue = dataRow("request_id")
            End If
        End If

        ' Fallback to DataGridView cells
        If requestIDValue Is Nothing OrElse IsDBNull(requestIDValue) Then
            If prm_table1.Columns.Contains("request_id") Then
                requestIDValue = selectedRow.Cells("request_id").Value
            ElseIf prm_table1.Columns.Contains("RequestID") Then
                requestIDValue = selectedRow.Cells("RequestID").Value
            ElseIf prm_table1.Columns.Count > 0 Then
                requestIDValue = selectedRow.Cells(0).Value
            End If
        End If

        If requestIDValue Is Nothing OrElse IsDBNull(requestIDValue) OrElse String.IsNullOrEmpty(requestIDValue.ToString()) Then
            MessageBox.Show("Invalid request selected. Please select a valid supply request.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim requestID As Integer = 0
        If Not Integer.TryParse(requestIDValue.ToString(), requestID) Then
            MessageBox.Show("Invalid request ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open RequisitionIssueSlip form with request ID
        Try
            Dim risForm As New RequisitionIssueSlip(requestID, "properties")
            risForm.Show()
        Catch ex As Exception
            MessageBox.Show("Error opening Requisition Issue Slip: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
