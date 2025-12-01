Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Linq
Imports Microsoft.VisualBasic

Public Class AssignRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private currentRequestID As Integer = -1
    Private requestData As DataRow = Nothing

    ' Public property to receive RequestID
    Public Property RequestID As Integer
        Get
            Return currentRequestID
        End Get
        Set(value As Integer)
            currentRequestID = value
            If Me.IsHandleCreated Then
                LoadRequestData()
            End If
        End Set
    End Property

    Private Sub AssignRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureModifyPermission()
        ' Load available properties/supplies even if no request
        LoadAvailableProperties()
        LoadAvailableSupplies()
        ' Load request data if RequestID is set
        If currentRequestID > 0 Then
            LoadRequestData()
        End If
    End Sub

    Private Sub LoadRequestData()
        ' Load request data from both property and supply requests
        If currentRequestID > 0 Then
            Try
                ' Try property requests first
                Dim dtProperty As DataTable = DatabaseConnection.GetAllPropertyRequests()
                Dim requestRows() As DataRow = dtProperty.Select("request_id = " & currentRequestID)
                If requestRows.Length > 0 Then
                    requestData = requestRows(0)
                    PopulateFormFields()
                    Return
                End If
                
                ' Try supply requests
                Dim dtSupply As DataTable = DatabaseConnection.GetAllSuppliesRequests()
                requestRows = dtSupply.Select("request_id = " & currentRequestID)
                If requestRows.Length > 0 Then
                    requestData = requestRows(0)
                    PopulateFormFields()
                    Return
                End If
                
                ' If no request found, show error
                MessageBox.Show("Request not found. Please select a valid request.", "Invalid Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                NavigateBack()
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] LoadRequestData Exception: " & ex.Message)
                MessageBox.Show("Error loading request data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' No request ID - allow manual assignment but warn user
            MessageBox.Show("No request selected. You can still assign items manually, but this is not recommended.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PopulateFormFields()
        If requestData Is Nothing Then Return

        Try
            ' Populate form fields with request data
            If requestData.Table.Columns.Contains("item_name") AndAlso Not IsDBNull(requestData("item_name")) Then
                btn_PropertyName.Text = requestData("item_name").ToString()
            End If

            ' Load available properties that match the request
            LoadAvailableProperties()
        Catch ex As Exception
            MessageBox.Show("Error populating form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAvailableProperties()
        ' Load properties that are available (can assign even without request)
        Try
            Dim propertiesTable As DataTable = DatabaseConnection.GetAllProperties()
            ' Filter for available properties (status = 'Active' or 'Available')
            Dim availableProperties = propertiesTable.AsEnumerable().Where(Function(p)
                                                                                Dim status As String = If(IsDBNull(p("status")), "", p("status").ToString().ToLower())
                                                                                Return status = "active" OrElse status = "available"
                                                                            End Function).CopyToDataTable()

            ' Populate ComboBox with available properties
            If ComboBox1 IsNot Nothing Then
                ComboBox1.DataSource = availableProperties
                ComboBox1.DisplayMember = "item_name"
                ComboBox1.ValueMember = "property_id"
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadAvailableProperties Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadAvailableSupplies()
        ' Load supplies that are available (can assign even without request)
        Try
            Dim suppliesTable As DataTable = DatabaseConnection.GetAllSupplies()
            ' Filter for available supplies
            Dim availableSupplies = suppliesTable.AsEnumerable().Where(Function(s)
                                                                                Dim status As String = If(IsDBNull(s("Status")), "", s("Status").ToString().ToLower())
                                                                                Dim qty As Integer = 0
                                                                                If s.Table.Columns.Contains("QuantityInStock") AndAlso Not IsDBNull(s("QuantityInStock")) Then
                                                                                    Integer.TryParse(s("QuantityInStock").ToString(), qty)
                                                                                End If
                                                                                Return (status = "available" OrElse status = "") AndAlso qty > 0
                                                                            End Function).CopyToDataTable()

            ' Populate ComboBox with available supplies
            If ComboBox2 IsNot Nothing Then
                ComboBox2.DataSource = availableSupplies
                ComboBox2.DisplayMember = "SupplyName"
                ComboBox2.ValueMember = "SupplyID"
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadAvailableSupplies Exception: " & ex.Message)
        End Try
    End Sub

    Public Sub SetRequestID(requestID As Integer)
        currentRequestID = requestID
        If Me.IsHandleCreated Then
            LoadRequestData()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBack()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not EnsureModifyPermission() Then
            Return
        End If
        
        ' Validate that a request exists
        If currentRequestID <= 0 Then
            Dim result As DialogResult = MessageBox.Show("No request is selected. Do you want to assign an item without a request? This is not recommended.", "No Request Selected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.No Then
                Return
            End If
        End If
        
        Try
            ' Determine if assigning property or supply
            Dim isProperty As Boolean = False
            Dim isSupply As Boolean = False
            Dim selectedPropertyID As Integer = 0
            Dim selectedSupplyID As Integer = 0
            
            ' Check which ComboBox has a selection
            ' ComboBox1 is for properties, ComboBox2 is for supplies
            If ComboBox1 IsNot Nothing AndAlso ComboBox1.SelectedIndex >= 0 AndAlso ComboBox1.SelectedValue IsNot Nothing Then
                isProperty = True
                Integer.TryParse(ComboBox1.SelectedValue.ToString(), selectedPropertyID)
            End If
            
            If ComboBox2 IsNot Nothing AndAlso ComboBox2.SelectedIndex >= 0 AndAlso ComboBox2.SelectedValue IsNot Nothing Then
                isSupply = True
                Integer.TryParse(ComboBox2.SelectedValue.ToString(), selectedSupplyID)
            End If
            
            If Not isProperty AndAlso Not isSupply Then
                MessageBox.Show("Please select a property or supply to assign.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            If isProperty AndAlso isSupply Then
                MessageBox.Show("Please select either a property OR a supply, not both.", "Multiple Selections", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' If we have a request ID, validate it exists and is approved/pending
            If currentRequestID > 0 Then
                Dim requestStatus As String = ""
                If requestData IsNot Nothing AndAlso requestData.Table.Columns.Contains("status") Then
                    requestStatus = If(IsDBNull(requestData("status")), "", requestData("status").ToString().ToLower())
                End If
                
                If Not String.IsNullOrEmpty(requestStatus) AndAlso requestStatus = "rejected" Then
                    MessageBox.Show("Cannot assign items to a rejected request.", "Invalid Request Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If
            
            ' Get admin info
            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)
            Dim adminName As String = SessionContext.CurrentUsername
            Dim adminUserType As String = SessionContext.CurrentRole
            
            ' Assign the item
            If isProperty AndAlso selectedPropertyID > 0 Then
                ' Use ReleasePropertyRequest to assign property
                If currentRequestID > 0 Then
                    Dim releaseDate As Date = Date.Today
                    Dim expectedReturnDate As Date? = Nothing
                    If DateTimePicker1 IsNot Nothing AndAlso DateTimePicker1.Value > Date.Today Then
                        expectedReturnDate = DateTimePicker1.Value
                    End If
                    
                    ' First approve if pending, then release
                    If requestData IsNot Nothing AndAlso requestData.Table.Columns.Contains("status") Then
                        Dim status As String = If(IsDBNull(requestData("status")), "", requestData("status").ToString())
                        If status.ToLower() = "pending" Then
                            If Not DatabaseConnection.ApprovePropertyRequest(currentRequestID, adminID, adminName, adminUserType) Then
                                MessageBox.Show("Failed to approve request before assignment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If
                        End If
                    End If
                    
                    If DatabaseConnection.ReleasePropertyRequest(currentRequestID, adminID, adminName, adminUserType, releaseDate, expectedReturnDate) Then
                        ' Update property assignment
                        Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
                        If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                            Using cmd As New MySqlCommand("UPDATE properties SET assigned_to = (SELECT user_id FROM property_requests WHERE request_id = @requestID LIMIT 1), status = 'Assigned', updated_at = NOW() WHERE property_id = @propertyID", conn)
                                cmd.Parameters.AddWithValue("@requestID", currentRequestID)
                                cmd.Parameters.AddWithValue("@propertyID", selectedPropertyID)
                                cmd.ExecuteNonQuery()
                            End Using
                            If conn.State = ConnectionState.Open Then conn.Close()
                        End If
                        
                        MessageBox.Show("Property assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        NavigateBack()
                    Else
                        MessageBox.Show("Failed to assign property. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Cannot assign property without a valid request. Please select a request first.", "No Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            ElseIf isSupply AndAlso selectedSupplyID > 0 Then
                ' For supply requests, we need to update the supply_requests table
                If currentRequestID > 0 Then
                    ' Approve supply request first if pending
                    Dim requestStatus As String = ""
                    If requestData IsNot Nothing AndAlso requestData.Table.Columns.Contains("status") Then
                        requestStatus = If(IsDBNull(requestData("status")), "", requestData("status").ToString())
                        If requestStatus.ToLower() = "pending" Then
                            If Not DatabaseConnection.ApproveSupplyRequest(currentRequestID, adminID, adminName, adminUserType) Then
                                MessageBox.Show("Failed to approve supply request before assignment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If
                        End If
                    End If
                    
                    ' Update supply quantity (deduct from inventory)
                    Dim quantityRequested As Integer = 1
                    If requestData IsNot Nothing AndAlso requestData.Table.Columns.Contains("quantity_requested") AndAlso Not IsDBNull(requestData("quantity_requested")) Then
                        Integer.TryParse(requestData("quantity_requested").ToString(), quantityRequested)
                    End If
                    
                    Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
                    If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                        Using cmd As New MySqlCommand("UPDATE supplies SET quantity = quantity - @qty, updated_at = NOW() WHERE supply_id = @supplyID AND quantity >= @qty", conn)
                            cmd.Parameters.AddWithValue("@qty", quantityRequested)
                            cmd.Parameters.AddWithValue("@supplyID", selectedSupplyID)
                            If cmd.ExecuteNonQuery() > 0 Then
                                MessageBox.Show("Supply assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                NavigateBack()
                            Else
                                MessageBox.Show("Insufficient supply quantity or supply not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End Using
                        If conn.State = ConnectionState.Open Then conn.Close()
                    End If
                Else
                    MessageBox.Show("Cannot assign supply without a valid request. Please select a request first.", "No Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error assigning item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("AssignRequestManagement btnSave_Click Error: " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub RoundedPanel3_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel3.Paint
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
    End Sub

    Private Sub NavigateBack()
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_PropertyRequestManagement())
        Else
            Me.Parent?.Controls.Remove(Me)
        End If
    End Sub

    Private Function EnsureModifyPermission() As Boolean
        ' No restrictions for Super Admin, Admin, and Custodian
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If hasFullAccess Then
            Return True
        End If
        ' For other roles, check permission
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyRequests)
        If Not canModifyRequests Then
            MessageBox.Show("You have view-only access to Property Request Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
            Return False
        End If
        Return True
    End Function
End Class

