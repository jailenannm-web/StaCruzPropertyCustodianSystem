Imports System
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Linq


Public Class UC_SupplyRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False
    Private originalData As DataTable
    Private isSearching As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyRequests)
    End Sub

    Private Sub UC_SupplyRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSupplyRequestData()
        ApplyPermissionState()

        ' Wire up search textbox if present
        Dim searchNames As String() = {"prm_search", "supplyRequestSearch", "txtSearch", "txtbox_search", "admin_txtbox_search"}
        For Each nm As String In searchNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is TextBox Then
                Dim tb As TextBox = CType(found(0), TextBox)
                RemoveHandler tb.TextChanged, AddressOf SupplyRequestSearch_TextChanged
                AddHandler tb.TextChanged, AddressOf SupplyRequestSearch_TextChanged
                Exit For
            End If
        Next
    End Sub

    Private Sub LoadSupplyRequestData()
        Try
            Dim dt As DataTable = DatabaseConnection.GetAllSuppliesRequests()

            If dt Is Nothing Then
                MessageBox.Show("Unable to load supply requests. Please check your database connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                originalData = Nothing
                Return
            End If
            originalData = dt.Copy()

            If prm_table1 IsNot Nothing Then
                ' Prevent auto-generated duplicate columns
                prm_table1.AutoGenerateColumns = False
                prm_table1.DataSource = Nothing
                prm_table1.ReadOnly = True
                prm_table1.AllowUserToAddRows = False
                prm_table1.AllowUserToDeleteRows = False
                prm_table1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                prm_table1.MultiSelect = False

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
                        Case "dateofrequest", "date_of_request"
                            col.DataPropertyName = "dateOfRequest"
                            col.HeaderText = "Date of Request"
                            col.Visible = True
                        Case "status"
                            col.DataPropertyName = "status"
                            col.HeaderText = "Status"
                            col.Visible = True
                        Case Else
                            ' Hide all other columns (departmentId, createdAt, updatedAt, approvedBy, approvedDate, etc.)
                            col.Visible = False
                    End Select
                Next

                ' Bind data source AFTER column mapping
                prm_table1.DataSource = dt
                prm_table1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                ' Update total count
                Dim totalLabel As Label = Nothing
                Dim foundControls() As Control = Me.Controls.Find("ttlpropertyrequestmanagement", True)
                If foundControls.Length > 0 Then
                    totalLabel = TryCast(foundControls(0), Label)
                End If
                If totalLabel IsNot Nothing Then
                    totalLabel.Text = If(dt.Rows.Count > 0, dt.Rows.Count.ToString(), "0")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading supply requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("LoadSupplyRequestData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function TryGetSelectedRequestId() As Integer
        Try
            If prm_table1 Is Nothing Then Return -1

            Dim row As DataGridViewRow = Nothing
            If prm_table1.SelectedRows IsNot Nothing AndAlso prm_table1.SelectedRows.Count > 0 Then
                row = prm_table1.SelectedRows(0)
            ElseIf prm_table1.CurrentRow IsNot Nothing Then
                row = prm_table1.CurrentRow
            End If

            If row Is Nothing Then Return -1

            ' Prefer DataSource -> DataRow for accuracy
            Dim dt As DataTable = TryCast(prm_table1.DataSource, DataTable)
            If dt IsNot Nothing AndAlso row.Index >= 0 AndAlso row.Index < dt.Rows.Count Then
                Dim dr As DataRow = dt.Rows(row.Index)
                If dt.Columns.Contains("requestId") AndAlso Not IsDBNull(dr("requestId")) Then
                    Dim v As Integer = 0
                    If Integer.TryParse(dr("requestId").ToString(), v) Then Return v
                End If
                If dt.Columns.Contains("request_id") AndAlso Not IsDBNull(dr("request_id")) Then
                    Dim v As Integer = 0
                    If Integer.TryParse(dr("request_id").ToString(), v) Then Return v
                End If
            End If

            ' Fallback to hidden grid column
            If prm_table1.Columns.Contains("requestId") AndAlso row.Cells("requestId").Value IsNot Nothing Then
                Dim v As Integer = 0
                If Integer.TryParse(row.Cells("requestId").Value.ToString(), v) Then Return v
            End If
            If prm_table1.Columns.Contains("request_id") AndAlso row.Cells("request_id").Value IsNot Nothing Then
                Dim v As Integer = 0
                If Integer.TryParse(row.Cells("request_id").Value.ToString(), v) Then Return v
            End If
            If row.Cells.Count > 0 AndAlso row.Cells(0).Value IsNot Nothing Then
                Dim v As Integer = 0
                If Integer.TryParse(row.Cells(0).Value.ToString(), v) Then Return v
            End If
        Catch
        End Try

        Return -1
    End Function

    Private Sub ApplyPermissionState()
        ' Super Admin, Admin, and Custodian have full access - ALL buttons enabled
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If btnApprove IsNot Nothing Then btnApprove.Enabled = hasFullAccess
        If btnReject IsNot Nothing Then btnReject.Enabled = hasFullAccess
        If issueRequisition IsNot Nothing Then issueRequisition.Enabled = hasFullAccess
        If printPAR IsNot Nothing Then printPAR.Enabled = hasFullAccess
        
        ' Wire up Update button if it exists in the designer
        Try
            Dim found() As Control = Me.Controls.Find("btnUpdate", True)
            If found IsNot Nothing AndAlso found.Length > 0 Then
                Dim btn As Button = TryCast(found(0), Button)
                If btn IsNot Nothing Then
                    btn.Enabled = hasFullAccess
                    ' Ensure click handler is wired
                    RemoveHandler btn.Click, AddressOf btnUpdate_Click
                    AddHandler btn.Click, AddressOf btnUpdate_Click
                End If
            End If
        Catch
            ' Ignore errors if button doesn't exist
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

            Dim remarks As String = InputBox("Enter rejection reason (required):", "Reject Supply Request", "")
            If String.IsNullOrWhiteSpace(remarks) Then
                MessageBox.Show("Rejection reason is required.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

            If DatabaseConnection.RejectSupplyRequest(requestID, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, remarks) Then
                MessageBox.Show("Supply request rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadSupplyRequestData()
            Else
                MessageBox.Show("Failed to reject supply request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error rejecting supply request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            If currentStatus = "approved" Then
                MessageBox.Show("This request is already approved.", "Already Approved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If currentStatus = "rejected" Then
                MessageBox.Show("This request has been rejected and cannot be approved.", "Request Rejected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim remarks As String = InputBox("Enter approval remarks (optional):", "Approve Supply Request", "")
            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

            If DatabaseConnection.ApproveSupplyRequest(requestID, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, remarks) Then
                MessageBox.Show("Supply request approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadSupplyRequestData()
            Else
                MessageBox.Show("Failed to approve supply request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error approving supply request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub issueRequisition_Click(sender As Object, e As EventArgs) Handles issueRequisition.Click
        ' Validate that a request is selected
        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a supply request to issue RIS.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            Dim risForm As New RequisitionIssueSlip(requestID, "supply")
            risForm.Show()
        Catch ex As Exception
            MessageBox.Show("Error opening Requisition Issue Slip: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub printPAR_Click(sender As Object, e As EventArgs) Handles printPAR.Click
        ' Validate that a request is selected
        If prm_table1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a supply request to print PAR/ICS.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        ' Open InventoryCustodianSlip form with request ID
        Try
            Dim icsForm As New InventoryCustodianSlip(requestID)
            icsForm.Show()
        Catch ex As Exception
            MessageBox.Show("Error opening Inventory Custodian Slip: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAssignSupply_Click(sender As Object, e As EventArgs) Handles btnAssignSupply.Click
        ' Always redirect to Assign panel; pass RequestID when available.
        Dim requestID As Integer = TryGetSelectedRequestId()

        ' Check for SADashboard first (Super Admin)
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            Dim assignForm As New AssignSupplyManagement()
            If requestID > 0 Then assignForm.RequestID = requestID
            saDashboard.LoadUserControl(assignForm)
            Return
        End If
        
        ' Check for AdminDashboard
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            Dim assignForm As New AssignSupplyManagement()
            If requestID > 0 Then assignForm.RequestID = requestID
            parentDashboard.LoadUserControl(assignForm)
        Else
            MessageBox.Show("Unable to open assignment form. Parent dashboard not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    
    ''' <summary>
    ''' Update button to refresh the supply request list
    ''' </summary>
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
        LoadSupplyRequestData()
        MessageBox.Show("Supply request list refreshed successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub prm_table1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles prm_table1.CellContentClick

    End Sub

    Private Sub SupplyRequestSearch_TextChanged(sender As Object, e As EventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb Is Nothing Then Return
        ApplySupplyRequestSearch(tb.Text)
    End Sub

    Private Sub ApplySupplyRequestSearch(searchText As String)
        If originalData Is Nothing Then Return
        If isSearching Then Return
        isSearching = True
        Try
            Dim searchLower As String = If(String.IsNullOrWhiteSpace(searchText), String.Empty, searchText.Trim().ToLower())
            If String.IsNullOrEmpty(searchLower) Then
                prm_table1.DataSource = originalData.Copy()
                Dim totalLabel As Label = Nothing
                Dim foundControls() As Control = Me.Controls.Find("ttlpropertyrequestmanagement", True)
                If foundControls.Length > 0 Then totalLabel = TryCast(foundControls(0), Label)
                If totalLabel IsNot Nothing Then totalLabel.Text = originalData.Rows.Count.ToString()
                isSearching = False
                Return
            End If

            Dim filtered = originalData.AsEnumerable().Where(Function(row)
                                                                 Dim requester As String = If(row.Table.Columns.Contains("requesterName") AndAlso Not IsDBNull(row("requesterName")), row("requesterName").ToString().ToLower(), String.Empty)
                                                                 Dim dept As String = If(row.Table.Columns.Contains("department") AndAlso Not IsDBNull(row("department")), row("department").ToString().ToLower(), String.Empty)
                                                                 Dim itemName As String = If(row.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")), row("itemName").ToString().ToLower(), String.Empty)
                                                                 Dim purpose As String = If(row.Table.Columns.Contains("purpose") AndAlso Not IsDBNull(row("purpose")), row("purpose").ToString().ToLower(), String.Empty)
                                                                 Dim status As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString().ToLower(), String.Empty)
                                                                 Return requester.Contains(searchLower) OrElse dept.Contains(searchLower) OrElse itemName.Contains(searchLower) OrElse purpose.Contains(searchLower) OrElse status.Contains(searchLower)
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
                MessageBox.Show("Error searching supply requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            isSearching = False
        End Try
    End Sub
End Class
