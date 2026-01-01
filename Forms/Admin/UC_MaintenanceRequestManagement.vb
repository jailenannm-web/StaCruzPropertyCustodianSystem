Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient
Imports System.Linq

Public Class UC_MaintenanceRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False
    Private originalData As DataTable
    Private isSearching As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyMaintenance)
    End Sub

    Private Sub UC_MaintenanceRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFilters()
        LoadMaintenanceRequestData()
        ApplyPermissionState()

        ' Wire search textbox - check maintenancerequestmanagementsearchbar first
        If maintenancerequestmanagementsearchbar IsNot Nothing Then
            RemoveHandler maintenancerequestmanagementsearchbar.TextChanged, AddressOf RequestSearch_TextChanged
            AddHandler maintenancerequestmanagementsearchbar.TextChanged, AddressOf RequestSearch_TextChanged
        Else
            ' Fallback: search for other possible control names
            Dim searchNames As String() = {"prm_search", "maintenanceRequestSearch", "txtSearch", "txtbox_search", "admin_txtbox_search"}
            For Each nm As String In searchNames
                Dim found() As Control = Me.Controls.Find(nm, True)
                If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is TextBox Then
                    Dim tb As TextBox = CType(found(0), TextBox)
                    RemoveHandler tb.TextChanged, AddressOf RequestSearch_TextChanged
                    AddHandler tb.TextChanged, AddressOf RequestSearch_TextChanged
                    Exit For
                End If
            Next
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
                statusCb.Items.AddRange(New String() {"Pending", "Approved", "In Progress", "Completed", "Rejected"})
                statusCb.SelectedIndex = 0
                AddHandler statusCb.SelectedIndexChanged, AddressOf Filter_Changed
                Exit For
            End If
        Next
        
        ' Initialize maintenance type filter if it exists
        Dim typeFilterNames() As String = {"pm_cbobx_categ", "categoryFilter", "cbCategory", "typeFilter"}
        For Each nm As String In typeFilterNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                Dim typeCb As ComboBox = CType(found(0), ComboBox)
                typeCb.Items.Clear()
                typeCb.Items.Add("All Types")
                typeCb.Items.AddRange(New String() {"Preventive", "Corrective", "Emergency", "Routine"})
                typeCb.SelectedIndex = 0
                AddHandler typeCb.SelectedIndexChanged, AddressOf Filter_Changed
                Exit For
            End If
        Next
    End Sub
    
    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        ' Reload search with filters
        Dim searchText As String = ""
        
        ' Check maintenancerequestmanagementsearchbar first
        If maintenancerequestmanagementsearchbar IsNot Nothing Then
            searchText = maintenancerequestmanagementsearchbar.Text
        Else
            ' Fallback: search for other possible control names
            Dim searchNames As String() = {"prm_search", "maintenanceRequestSearch", "txtSearch", "txtbox_search", "admin_txtbox_search"}
            For Each nm As String In searchNames
                Dim found() As Control = Me.Controls.Find(nm, True)
                If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is TextBox Then
                    searchText = CType(found(0), TextBox).Text
                    Exit For
                End If
            Next
        End If
        
        ApplyRequestSearch(searchText)
    End Sub

    Private Sub LoadMaintenanceRequestData()
        Try
            Dim dt As DataTable = modDB.GetAllMaintenanceRequests()

            If propertyManagementGrid IsNot Nothing Then
                propertyManagementGrid.AutoGenerateColumns = False
                propertyManagementGrid.DataSource = Nothing
            End If

            If dt Is Nothing Then
                MessageBox.Show("Unable to load maintenance requests. Please check your database connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                originalData = Nothing
                If ttlpropertymanagement IsNot Nothing Then ttlpropertymanagement.Text = "0"
                Return
            End If
            originalData = dt.Copy()

            ' Map designer columns to data properties if grid exists
            If propertyManagementGrid IsNot Nothing Then
                For Each col As DataGridViewColumn In propertyManagementGrid.Columns
                    Select Case col.Name.ToLower()
                        Case "requestid", "request_id"
                            col.DataPropertyName = "requestId"
                            col.HeaderText = "Request ID"
                            col.Visible = True
                        Case "itemname", "item_name"
                            col.DataPropertyName = "itemName"
                            col.HeaderText = "Property / Item Name"
                            col.Visible = True
                        Case "serialnumber", "serial_number"
                            col.DataPropertyName = "serialNumber"
                            col.HeaderText = "Serial Number"
                            col.Visible = True
                        Case "location"
                            col.DataPropertyName = "location"
                            col.HeaderText = "Location"
                            col.Visible = True
                        Case "department", "departmentid", "department_id", "departmentname", "department_name"
                            col.DataPropertyName = "departmentName"
                            col.HeaderText = "Department"
                            col.Visible = True
                        Case "conditionbefore", "condition_before"
                            col.DataPropertyName = "conditionBefore"
                            col.HeaderText = "Condition Before"
                            col.Visible = True
                        Case "typeofissue", "type_of_issue", "typeofmaintenance"
                            col.DataPropertyName = "typeOfIssue"
                            col.HeaderText = "Type of Issue"
                            col.Visible = True
                        Case "problemdescription", "problem_description"
                            col.DataPropertyName = "problemDescription"
                            col.HeaderText = "Problem Description"
                            col.Visible = True
                        Case "daterequested", "date_requested", "maintenancedate", "maintenance_date"
                            col.DataPropertyName = "dateRequested"
                            col.HeaderText = "Date Requested"
                            col.Visible = True
                            col.DefaultCellStyle.Format = "yyyy-MM-dd"
                        Case "propertynumber", "property_number"
                            col.DataPropertyName = "propertyNumber"
                            col.HeaderText = "Property Number"
                            col.Visible = False ' Hide by default
                        Case "targetdate", "target_date"
                            col.DataPropertyName = "targetDate"
                            col.HeaderText = "Target Date"
                            col.Visible = False ' Hide by default
                            col.DefaultCellStyle.Format = "yyyy-MM-dd"
                        Case "completiondate", "completion_date"
                            col.DataPropertyName = "completionDate"
                            col.HeaderText = "Completion Date"
                            col.Visible = False ' Hide by default
                            col.DefaultCellStyle.Format = "yyyy-MM-dd"
                        Case "status"
                            col.DataPropertyName = "status"
                            col.HeaderText = "Status"
                            col.Visible = True
                        Case "requestername", "requester_name", "requestedby", "requested_by"
                            col.DataPropertyName = "requesterName"
                            col.HeaderText = "Requested By"
                            col.Visible = True
                        Case "assignedtechnician", "assigned_technician"
                            col.DataPropertyName = "assignedTechnician"
                            col.HeaderText = "Assigned Technician"
                            col.Visible = True
                        Case Else
                            ' Hide columns that don't need to be shown by default
                            If col.Name.ToLower().Contains("action") OrElse col.Name.ToLower().Contains("created") OrElse col.Name.ToLower().Contains("updated") Then
                                col.Visible = False
                            End If
                    End Select
                Next
                
                System.Diagnostics.Debug.WriteLine($"[v0] Mapped {propertyManagementGrid.Columns.Count} columns for maintenance requests")

                propertyManagementGrid.DataSource = dt
                propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                propertyManagementGrid.ReadOnly = True
                propertyManagementGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End If

            If ttlpropertymanagement IsNot Nothing Then
                ttlpropertymanagement.Text = If(dt.Rows.Count > 0, dt.Rows.Count.ToString(), "0")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading maintenance requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If ttlpropertymanagement IsNot Nothing Then ttlpropertymanagement.Text = "0"
        End Try
    End Sub

    Private Sub RequestSearch_TextChanged(sender As Object, e As EventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb Is Nothing Then Return
        ApplyRequestSearch(tb.Text)
    End Sub

    Private Sub ApplyRequestSearch(searchText As String)
        If originalData Is Nothing Then Return
        If isSearching Then Return
        isSearching = True
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
            
            Dim typeFilter As String = String.Empty
            Dim typeFilterNames() As String = {"pm_cbobx_categ", "categoryFilter", "cbCategory", "typeFilter"}
            For Each nm As String In typeFilterNames
                Dim found() As Control = Me.Controls.Find(nm, True)
                If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is ComboBox Then
                    Dim cb As ComboBox = CType(found(0), ComboBox)
                    If cb.SelectedIndex > 0 Then
                        typeFilter = cb.SelectedItem.ToString()
                    End If
                    Exit For
                End If
            Next

            Dim filtered = originalData.AsEnumerable().Where(Function(row)
                                                                 ' Apply status filter
                                                                 If Not String.IsNullOrEmpty(statusFilter) Then
                                                                     Dim rowStatus As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), String.Empty)
                                                                     If Not String.Equals(rowStatus, statusFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                 End If
                                                                 
                                                                 ' Apply type filter (check multiple possible column names)
                                                                 If Not String.IsNullOrEmpty(typeFilter) Then
                                                                     Dim rowType As String = String.Empty
                                                                     If row.Table.Columns.Contains("typeOfIssue") AndAlso Not IsDBNull(row("typeOfIssue")) Then
                                                                         rowType = row("typeOfIssue").ToString()
                                                                     ElseIf row.Table.Columns.Contains("typeOfMaintenance") AndAlso Not IsDBNull(row("typeOfMaintenance")) Then
                                                                         rowType = row("typeOfMaintenance").ToString()
                                                                     End If
                                                                     If Not String.Equals(rowType, typeFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                 End If
                                                                 
                                                                 ' Apply search filter
                                                                 If String.IsNullOrEmpty(searchLower) Then Return True
                                                                 
                                                                 Dim itemName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString().ToLower(), String.Empty)
                                                                 Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString().ToLower(), String.Empty)
                                                                 Dim maintType As String = If(row.Table.Columns.Contains("typeOfMaintenance") AndAlso Not IsDBNull(row("typeOfMaintenance")), row("typeOfMaintenance").ToString().ToLower(), String.Empty)
                                                                 Dim issueType As String = If(row.Table.Columns.Contains("typeOfIssue") AndAlso Not IsDBNull(row("typeOfIssue")), row("typeOfIssue").ToString().ToLower(), String.Empty)
                                                                 Dim status As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString().ToLower(), String.Empty)
                                                                 Dim serialNum As String = If(row.Table.Columns.Contains("serialNumber") AndAlso Not IsDBNull(row("serialNumber")), row("serialNumber").ToString().ToLower(), String.Empty)
                                                                 Dim propNum As String = If(row.Table.Columns.Contains("propertyNumber") AndAlso Not IsDBNull(row("propertyNumber")), row("propertyNumber").ToString().ToLower(), String.Empty)
                                                                 Dim dept As String = If(row.Table.Columns.Contains("departmentName") AndAlso Not IsDBNull(row("departmentName")), row("departmentName").ToString().ToLower(), String.Empty)
                                                                 Dim requester As String = If(row.Table.Columns.Contains("requesterName") AndAlso Not IsDBNull(row("requesterName")), row("requesterName").ToString().ToLower(), String.Empty)
                                                                 Dim technician As String = If(row.Table.Columns.Contains("assignedTechnician") AndAlso Not IsDBNull(row("assignedTechnician")), row("assignedTechnician").ToString().ToLower(), String.Empty)
                                                                 Dim problem As String = If(row.Table.Columns.Contains("problemDescription") AndAlso Not IsDBNull(row("problemDescription")), row("problemDescription").ToString().ToLower(), String.Empty)
                                                                 Dim condition As String = If(row.Table.Columns.Contains("conditionBefore") AndAlso Not IsDBNull(row("conditionBefore")), row("conditionBefore").ToString().ToLower(), String.Empty)
                                                                 
                                                                 Return itemName.Contains(searchLower) OrElse location.Contains(searchLower) OrElse maintType.Contains(searchLower) OrElse issueType.Contains(searchLower) OrElse status.Contains(searchLower) OrElse serialNum.Contains(searchLower) OrElse propNum.Contains(searchLower) OrElse dept.Contains(searchLower) OrElse requester.Contains(searchLower) OrElse technician.Contains(searchLower) OrElse problem.Contains(searchLower) OrElse condition.Contains(searchLower)
                                                             End Function)

            Dim filteredList = filtered.ToList()
            If filteredList Is Nothing OrElse filteredList.Count = 0 Then
                If propertyManagementGrid IsNot Nothing Then propertyManagementGrid.DataSource = Nothing
                If ttlpropertymanagement IsNot Nothing Then ttlpropertymanagement.Text = "0"
            Else
                Dim dt As DataTable = filteredList.CopyToDataTable()
                If propertyManagementGrid IsNot Nothing Then propertyManagementGrid.DataSource = dt
                If ttlpropertymanagement IsNot Nothing Then ttlpropertymanagement.Text = dt.Rows.Count.ToString()
            End If
        Catch ex As Exception
            If TypeOf ex Is InvalidOperationException Then
                If propertyManagementGrid IsNot Nothing Then propertyManagementGrid.DataSource = Nothing
                If ttlpropertymanagement IsNot Nothing Then ttlpropertymanagement.Text = "0"
            Else
                MessageBox.Show("Error searching maintenance requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            isSearching = False
        End Try
    End Sub

    Private Sub propertyManagementGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellContentClick
        If e.RowIndex >= 0 AndAlso propertyManagementGrid.Columns.Contains("action_edit") AndAlso
           e.ColumnIndex = propertyManagementGrid.Columns("action_edit").Index Then

            ' Use camelCase to match database schema
            Dim reqIDValue As Object = Nothing
            If propertyManagementGrid.Columns.Contains("requestId") Then
                reqIDValue = propertyManagementGrid.Rows(e.RowIndex).Cells("requestId").Value
            ElseIf propertyManagementGrid.Columns.Contains("request_id") Then
                reqIDValue = propertyManagementGrid.Rows(e.RowIndex).Cells("request_id").Value
            End If
            Dim reqID As String = If(reqIDValue IsNot Nothing, reqIDValue.ToString(), "")
            MessageBox.Show("Edit Request: " & reqID, "Action", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Example: open edit request UC
            ' Dim uc As New UC_EditRequest()
            ' uc.LoadRequestData(reqID)
            ' Me.Parent.Controls.Add(uc) : uc.BringToFront()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        ' Check SADashboard first (parent class)
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            saDashboard.LoadUserControl(New EditMaintenance1())
            Return
        End If
        
        Dim superAdminDashboard = TryCast(Me.ParentForm, SADashboard)
        If superAdminDashboard IsNot Nothing Then
            superAdminDashboard.LoadUserControl(New EditMaintenance1())
            Return
        End If

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            ' Open EditMaintenance1 form for adding/editing maintenance
            parentDashboard.LoadUserControl(New EditMaintenance1())
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        If Not isSuperAdmin Then

            Return
        End If

        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance request to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Dim requestID As Integer = 0
            If dt.Columns.Contains("requestId") Then
                requestID = Convert.ToInt32(dataRow("requestId"))
            ElseIf dt.Columns.Contains("request_id") Then
                requestID = Convert.ToInt32(dataRow("request_id"))
            End If

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this maintenance request? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                ' Delete maintenance request using modDB
                Dim conn As MySqlConnection = modDB.GetConnection()
                If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
                    Using cmd As New MySqlCommand("DELETE FROM maintenance_requests WHERE requestId = @requestID", conn)
                        cmd.Parameters.AddWithValue("@requestID", requestID)
                        If cmd.ExecuteNonQuery() > 0 Then
                            MessageBox.Show("Maintenance request deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadMaintenanceRequestData()
                        Else
                            MessageBox.Show("Failed to delete maintenance request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                    If conn.State = ConnectionState.Open Then conn.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting maintenance request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Assign_Click(sender As Object, e As EventArgs)
        ' No restrictions for Super Admin, Admin, and Custodian

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AssignRequestManagement())
        End If
    End Sub

    Private Sub ApplyPermissionState()
        ' Super Admin, Admin, and Custodian have full access - ALL buttons enabled
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If btnApprove IsNot Nothing Then btnApprove.Enabled = hasFullAccess
        If btnReject IsNot Nothing Then btnReject.Enabled = hasFullAccess
        If prm_btn_update IsNot Nothing Then prm_btn_update.Enabled = hasFullAccess
        If btnAdd IsNot Nothing Then btnAdd.Enabled = hasFullAccess
        If Delete IsNot Nothing Then Delete.Enabled = hasFullAccess
    End Sub


    ' ----------------------------------------------------------------------
    ' PRINT PAR LOGIC � FULLY CONNECTED TO PROPERTYCARD
    ' ----------------------------------------------------------------------
    Private Sub printPAR_Click(sender As Object, e As EventArgs) Handles printPAR.Click
        ' Validate that a request is selected
        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance request to print PAR/ICS.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
        Dim dt As DataTable = TryCast(propertyManagementGrid.DataSource, DataTable)
        
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
            If propertyManagementGrid.Columns.Contains("request_id") Then
                requestIDValue = selectedRow.Cells("request_id").Value
            ElseIf propertyManagementGrid.Columns.Contains("RequestID") Then
                requestIDValue = selectedRow.Cells("RequestID").Value
            ElseIf propertyManagementGrid.Columns.Count > 0 Then
                requestIDValue = selectedRow.Cells(0).Value
            End If
        End If

        If requestIDValue Is Nothing OrElse IsDBNull(requestIDValue) OrElse String.IsNullOrEmpty(requestIDValue.ToString()) Then
            MessageBox.Show("Invalid request selected. Please select a valid maintenance request.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim requestID As Integer = 0
        If Not Integer.TryParse(requestIDValue.ToString(), requestID) Then
            MessageBox.Show("Invalid request ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open InventoryCustodianSlip form with request ID
        Try
            Dim icsForm As New InventoryCustodianSlip(requestID)
            icsForm.Show()
        Catch ex As Exception
            MessageBox.Show("Error opening Inventory Custodian Slip: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance request to approve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Dim requestID As Integer = 0
            If dt.Columns.Contains("requestId") Then
                requestID = Convert.ToInt32(dataRow("requestId"))
            ElseIf dt.Columns.Contains("request_id") Then
                requestID = Convert.ToInt32(dataRow("request_id"))
            End If
            Dim currentStatus As String = If(IsDBNull(dataRow("status")), "", dataRow("status").ToString().ToLower())

            If currentStatus = "completed" OrElse currentStatus = "approved" OrElse currentStatus = "in progress" Then
                MessageBox.Show("This maintenance request is already processed.", "Already Processed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Ask for technician assignment using professional dialog
            Using techDialog As New AssignTechnicianDialog()
                If techDialog.ShowDialog() <> DialogResult.OK Then
                    Return ' User cancelled
                End If
                
                Dim assignedTechnician As String = techDialog.TechnicianName
                Dim targetDate As Date = techDialog.TargetDate
                
                If String.IsNullOrWhiteSpace(assignedTechnician) Then
                    MessageBox.Show("Technician assignment is required to approve the maintenance request.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' Ask for approval remarks using professional dialog
                Dim remarks As String = ""
                Using remarksDialog As New RemarksDialog("Approval Remarks", "Approve", "Enter any remarks for this approval (optional)")
                    If remarksDialog.ShowDialog() = DialogResult.OK Then
                        remarks = remarksDialog.Remarks
                    End If
                End Using
                
                Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)
                Dim condition As String = If(IsDBNull(dataRow("conditionBefore")), "Needs Repair", dataRow("conditionBefore").ToString())

                ' Update maintenance request status to approved with assigned technician
                ' Parameters: requestID, assignedTechnician, targetDate, adminID, remarks, conditionBefore
                If modDB.ApproveMaintenanceRequest(requestID, assignedTechnician, targetDate, adminID, remarks, condition) Then
                    MessageBox.Show("Maintenance request approved successfully and assigned to " & assignedTechnician & " for " & targetDate.ToString("yyyy-MM-dd") & ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadMaintenanceRequestData()
                Else
                    MessageBox.Show("Failed to approve maintenance request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            Dim errorMsg As String = "An error occurred while approving the maintenance request."
            If TypeOf ex Is MySqlException Then
                errorMsg = "Database error: Unable to approve the maintenance request. Please check your connection and try again."
            ElseIf TypeOf ex Is InvalidCastException OrElse TypeOf ex Is FormatException Then
                errorMsg = "Invalid data format. Please refresh the list and try again."
            End If
            MessageBox.Show(errorMsg & Environment.NewLine & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance request to reject.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Dim requestID As Integer = 0
            If dt.Columns.Contains("requestId") Then
                requestID = Convert.ToInt32(dataRow("requestId"))
            ElseIf dt.Columns.Contains("request_id") Then
                requestID = Convert.ToInt32(dataRow("request_id"))
            End If
            Dim currentStatus As String = If(IsDBNull(dataRow("status")), "", dataRow("status").ToString().ToLower())

            If currentStatus = "rejected" Then
                MessageBox.Show("This maintenance request is already rejected.", "Already Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Ask for rejection reason using professional dialog
            Dim remarks As String = ""
            Using remarksDialog As New RemarksDialog("Rejection Reason", "Reject Request", "Please provide a reason for rejecting this maintenance request (required)")
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

            ' Update maintenance request status to rejected
            If modDB.RejectMaintenanceRequest(requestID, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, remarks) Then
                MessageBox.Show("Maintenance request rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadMaintenanceRequestData()
            Else
                MessageBox.Show("Failed to reject maintenance request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Dim errorMsg As String = "An error occurred while rejecting the maintenance request."
            If TypeOf ex Is MySqlException Then
                errorMsg = "Database error: Unable to reject the maintenance request. Please check your connection and try again."
            ElseIf TypeOf ex Is InvalidCastException OrElse TypeOf ex Is FormatException Then
                errorMsg = "Invalid data format. Please refresh the list and try again."
            End If
            MessageBox.Show(errorMsg & Environment.NewLine & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub prm_btn_update_Click(sender As Object, e As EventArgs)
        ' No restrictions for Super Admin, Admin, and Custodian

        LoadMaintenanceRequestData()
        MessageBox.Show("Maintenance request list refreshed.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub admin_label_DepartmentManagement_Click(sender As Object, e As EventArgs) Handles admin_label_DepartmentManagement.Click

    End Sub

    Private Sub issuePropertySlip_Click(sender As Object, e As EventArgs)
        If propertyManagementGrid Is Nothing OrElse propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance request first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            ' Get request ID
            Dim requestID As Integer = 0
            If dt.Columns.Contains("requestId") Then
                requestID = Convert.ToInt32(dataRow("requestId"))
            ElseIf dt.Columns.Contains("request_id") Then
                requestID = Convert.ToInt32(dataRow("request_id"))
            End If

            ' Open Property Issuance Slip with maintenance request data
            Dim propertyAcknowledgement As New PropertyAcknowledgementReceipt()
            ' TODO: If PropertyAcknowledgementReceipt accepts maintenance request data, pass it here
            propertyAcknowledgement.Show()
        Catch ex As Exception
            MessageBox.Show("Error opening property slip: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

