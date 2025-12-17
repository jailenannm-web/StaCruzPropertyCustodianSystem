Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Linq
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

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

    ' Helper to find a control by name and cast to expected type
    Private Function FindControlOfType(Of T As Control)(name As String) As T
        Dim matches = Me.Controls.Find(name, True)
        If matches Is Nothing OrElse matches.Length = 0 Then
            Return Nothing
        End If
        Return TryCast(matches(0), T)
    End Function

    Private Sub AssignRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureModifyPermission()
        ' Load dropdowns
        LoadCategoryDropdown()
        LoadDepartmentDropdown()
        LoadConditionDropdown()
        ' Load available properties/supplies even if no request
        LoadAvailableProperties()
        LoadAvailableSupplies()
        ' Wire up property selection change event for auto-fill
        Dim propCombo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox1")
        If propCombo IsNot Nothing Then
            AddHandler propCombo.SelectedIndexChanged, AddressOf ComboBox1_SelectedIndexChanged
        End If
        ' Wire up department change for cascading employee dropdown
        Dim deptCombo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox2")
        If deptCombo IsNot Nothing Then
            AddHandler deptCombo.SelectedIndexChanged, AddressOf ComboBox2_SelectedIndexChanged
        End If
        ' Wire up employee change if needed
        Dim empCombo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox4")
        If empCombo IsNot Nothing Then
            AddHandler empCombo.SelectedIndexChanged, AddressOf ComboBox4_SelectedIndexChanged
        End If
        ' Load request data if RequestID is set
        If currentRequestID > 0 Then
            LoadRequestData()
        End If
    End Sub

    Private Sub LoadCategoryDropdown()
        Try
            Dim combo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox3")
            If combo IsNot Nothing Then
                combo.Items.Clear()
                combo.Items.AddRange(New String() {
                    "Furniture", "Equipment", "Office Supplies", "IT Equipment",
                    "Laboratory Apparatus", "Books and Publications",
                    "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
                })
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadCategoryDropdown Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadDepartmentDropdown()
        Try
            Dim deptTable As DataTable = DatabaseConnection.GetDepartmentLookup(True)
            Dim combo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox2")
            If deptTable IsNot Nothing AndAlso deptTable.Rows.Count > 0 AndAlso combo IsNot Nothing Then
                combo.DataSource = deptTable
                combo.DisplayMember = "department_name"
                combo.ValueMember = "department_id"
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadDepartmentDropdown Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadConditionDropdown()
        Try
            Dim combo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox11")
            If combo IsNot Nothing Then
                combo.Items.Clear()
                combo.Items.AddRange(New String() {"New", "Good", "Fair", "Damaged", "For Repair"})
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadConditionDropdown Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Load employees when department changes
        Dim combo As ComboBox = TryCast(sender, ComboBox)
        If combo Is Nothing Then combo = FindControlOfType(Of ComboBox)("ComboBox2")
        If combo Is Nothing OrElse combo.SelectedValue Is Nothing Then Return

        Try
            Dim deptID As Integer
            If TypeOf combo.SelectedValue Is DataRowView Then
                Dim drv As DataRowView = CType(combo.SelectedValue, DataRowView)
                If Not Integer.TryParse(drv.Row("department_id").ToString(), deptID) Then Return
            ElseIf Not Integer.TryParse(combo.SelectedValue.ToString(), deptID) Then
                Return
            End If

            Dim usersTable As DataTable = DatabaseConnection.GetUsersByDepartment(deptID)
            Dim empCombo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox4")
            If usersTable IsNot Nothing AndAlso usersTable.Rows.Count > 0 AndAlso empCombo IsNot Nothing Then
                empCombo.DataSource = usersTable
                empCombo.DisplayMember = "fullName"
                empCombo.ValueMember = "userId"
            ElseIf empCombo IsNot Nothing Then
                empCombo.DataSource = Nothing
                empCombo.Items.Clear()
                empCombo.Items.Add("No employees in this department")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ComboBox2_SelectedIndexChanged Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Auto-fill all fields when a property is selected
        Dim combo As ComboBox = TryCast(sender, ComboBox)
        If combo Is Nothing Then combo = FindControlOfType(Of ComboBox)("ComboBox1")
        If combo Is Nothing OrElse combo.SelectedValue Is Nothing Then Return

        Try
            Dim propertyID As Integer
            If TypeOf combo.SelectedValue Is DataRowView Then
                Dim drv As DataRowView = CType(combo.SelectedValue, DataRowView)
                If Not Integer.TryParse(drv.Row("propertyId").ToString(), propertyID) Then Return
            ElseIf Not Integer.TryParse(combo.SelectedValue.ToString(), propertyID) Then
                Return
            End If

            ' Get property details from database
            Dim propertyData As DataRow = DatabaseConnection.GetPropertyDetails(propertyID)
            If propertyData Is Nothing Then Return

            ' Auto-fill Property ID
            Dim propIdCtl As Control = FindControlOfType(Of Control)("Property_ID")
            If propIdCtl IsNot Nothing Then
                If TypeOf propIdCtl Is TextBox Then
                    CType(propIdCtl, TextBox).Text = propertyID.ToString()
                ElseIf TypeOf propIdCtl Is Label Then
                    CType(propIdCtl, Label).Text = propertyID.ToString()
                End If
            End If

            ' Auto-fill Property Name
            Dim btnProp As Control = FindControlOfType(Of Control)("btn_PropertyName")
            If btnProp IsNot Nothing Then
                Dim itemName As String = ""
                If propertyData.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(propertyData("itemName")) Then
                    itemName = propertyData("itemName").ToString()
                End If
                If TypeOf btnProp Is Button Then
                    CType(btnProp, Button).Text = itemName
                ElseIf TypeOf btnProp Is Label Then
                    CType(btnProp, Label).Text = itemName
                End If
            End If

            ' Auto-fill Category
            Dim catCombo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox3")
            If catCombo IsNot Nothing Then
                Dim category As String = ""
                If propertyData.Table.Columns.Contains("category") AndAlso Not IsDBNull(propertyData("category")) Then
                    category = propertyData("category").ToString()
                End If
                Dim categoryIndex As Integer = catCombo.FindStringExact(category)
                If categoryIndex >= 0 Then
                    catCombo.SelectedIndex = categoryIndex
                Else
                    catCombo.Text = category
                End If
            End If

            ' Auto-fill Serial Number
            Dim serialTxt As TextBox = FindControlOfType(Of TextBox)("txb_SerialNumber")
            If serialTxt IsNot Nothing Then
                Dim serialNumber As String = ""
                If propertyData.Table.Columns.Contains("serialNumber") AndAlso Not IsDBNull(propertyData("serialNumber")) Then
                    serialNumber = propertyData("serialNumber").ToString()
                End If
                serialTxt.Text = serialNumber
            End If

            ' Auto-fill Supplier
            Dim btnSupplier As Control = FindControlOfType(Of Control)("btn_Suppier")
            If btnSupplier IsNot Nothing Then
                Dim supplier As String = ""
                If propertyData.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(propertyData("supplier")) Then
                    supplier = propertyData("supplier").ToString()
                End If
                If TypeOf btnSupplier Is Button Then
                    CType(btnSupplier, Button).Text = supplier
                ElseIf TypeOf btnSupplier Is Label Then
                    CType(btnSupplier, Label).Text = supplier
                End If
            End If

            ' Auto-fill Condition
            Dim condCombo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox11")
            If condCombo IsNot Nothing Then
                Dim condition As String = ""
                If propertyData.Table.Columns.Contains("condition") AndAlso Not IsDBNull(propertyData("condition")) Then
                    condition = propertyData("condition").ToString()
                End If
                Dim conditionIndex As Integer = condCombo.FindStringExact(condition)
                If conditionIndex >= 0 Then
                    condCombo.SelectedIndex = conditionIndex
                Else
                    condCombo.Text = condition
                End If
            End If

            ' Auto-fill Cost
            Dim costTxt As TextBox = FindControlOfType(Of TextBox)("txb_Cost")
            If costTxt IsNot Nothing Then
                Dim cost As Decimal = 0
                If propertyData.Table.Columns.Contains("acquisitionCost") AndAlso Not IsDBNull(propertyData("acquisitionCost")) Then
                    Decimal.TryParse(propertyData("acquisitionCost").ToString(), cost)
                End If
                costTxt.Text = cost.ToString("0.00")
            End If

            ' Auto-fill Department
            Dim deptCombo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox2")
            If deptCombo IsNot Nothing Then
                Dim deptName As String = ""
                If propertyData.Table.Columns.Contains("assignedDepartment") AndAlso Not IsDBNull(propertyData("assignedDepartment")) Then
                    deptName = propertyData("assignedDepartment").ToString()
                ElseIf propertyData.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(propertyData("departmentId")) Then
                    deptName = propertyData("departmentId").ToString()
                End If
                If Not String.IsNullOrEmpty(deptName) Then
                    Dim deptIndex As Integer = deptCombo.FindStringExact(deptName)
                    If deptIndex >= 0 Then
                        deptCombo.SelectedIndex = deptIndex
                    Else
                        deptCombo.Text = deptName
                    End If
                End If
            End If

            ' Auto-fill Employee
            Dim empCombo2 As ComboBox = FindControlOfType(Of ComboBox)("ComboBox4")
            If empCombo2 IsNot Nothing Then
                Dim employeeName As String = ""
                If propertyData.Table.Columns.Contains("assignedEmployee") AndAlso Not IsDBNull(propertyData("assignedEmployee")) Then
                    employeeName = propertyData("assignedEmployee").ToString()
                End If
                If Not String.IsNullOrEmpty(employeeName) Then
                    Dim empIndex As Integer = empCombo2.FindStringExact(employeeName)
                    If empIndex >= 0 Then
                        empCombo2.SelectedIndex = empIndex
                    End If
                End If
            End If

            ' Auto-fill Location
            Dim locTxt As TextBox = FindControlOfType(Of TextBox)("TextBox2")
            If locTxt IsNot Nothing Then
                Dim location As String = ""
                If propertyData.Table.Columns.Contains("location") AndAlso Not IsDBNull(propertyData("location")) Then
                    location = propertyData("location").ToString()
                End If
                locTxt.Text = location
            End If

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ComboBox1_SelectedIndexChanged Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadRequestData()
        ' Load request data from both property and supply requests
        If currentRequestID > 0 Then
            Try
                ' Try property requests first
                Dim dtProperty As DataTable = DatabaseConnection.GetAllPropertyRequests()
                Dim requestRows() As DataRow = dtProperty.Select("requestId = " & currentRequestID)
                If requestRows.Length = 0 Then
                    ' Try snake_case column name as fallback
                    requestRows = dtProperty.Select("request_id = " & currentRequestID)
                End If
                If requestRows.Length > 0 Then
                    requestData = requestRows(0)
                    PopulateFormFields()
                    Return
                End If

                ' Try supply requests
                Dim dtSupply As DataTable = DatabaseConnection.GetAllSuppliesRequests()
                requestRows = dtSupply.Select("requestId = " & currentRequestID)
                If requestRows.Length = 0 Then
                    ' Try snake_case column name as fallback
                    requestRows = dtSupply.Select("request_id = " & currentRequestID)
                End If
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
            ' No request ID - show warning that assignment requires a request
            MessageBox.Show("No request selected. Assignment requires a valid request. Please select a request from Property Request Management or Supply Request Management first.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub PopulateFormFields()
        If requestData Is Nothing Then Return

        Try
            ' Populate form fields with request data
            Dim itemNameValue As String = ""
            If requestData.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(requestData("itemName")) Then
                itemNameValue = requestData("itemName").ToString()
            ElseIf requestData.Table.Columns.Contains("item_name") AndAlso Not IsDBNull(requestData("item_name")) Then
                itemNameValue = requestData("item_name").ToString()
            End If
            Dim btnProp As Control = FindControlOfType(Of Control)("btn_PropertyName")
            If btnProp IsNot Nothing Then
                If TypeOf btnProp Is Button Then
                    CType(btnProp, Button).Text = itemNameValue
                ElseIf TypeOf btnProp Is Label Then
                    CType(btnProp, Label).Text = itemNameValue
                End If
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
            If propertiesTable Is Nothing OrElse propertiesTable.Rows.Count = 0 Then Return

            ' Filter for available properties (status = 'Active' or 'Available')
            Dim availableList = propertiesTable.AsEnumerable().Where(Function(p)
                                                                         Dim status As String = If(IsDBNull(p("status")), "", p("status").ToString().ToLower())
                                                                         Return status = "active" OrElse status = "available"
                                                                     End Function)

            Dim availableProperties As DataTable = Nothing
            If availableList.Any() Then
                availableProperties = availableList.CopyToDataTable()
            End If

            ' Populate ComboBox with available properties
            Dim combo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox1")
            If combo IsNot Nothing Then
                combo.DataSource = Nothing
                If availableProperties IsNot Nothing Then
                    combo.DataSource = availableProperties
                    combo.DisplayMember = "itemName"
                    combo.ValueMember = "propertyId"
                Else
                    combo.Items.Clear()
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadAvailableProperties Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadAvailableSupplies()
        ' Load supplies that are available (can assign even without request)
        Try
            Dim suppliesTable As DataTable = DatabaseConnection.GetAllSupplies()
            If suppliesTable Is Nothing OrElse suppliesTable.Rows.Count = 0 Then Return

            ' Filter for available supplies
            Dim availableList = suppliesTable.AsEnumerable().Where(Function(s)
                                                                       Dim status As String = ""
                                                                       If s.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(s("stockStatus")) Then
                                                                           status = s("stockStatus").ToString().ToLower()
                                                                       ElseIf s.Table.Columns.Contains("Status") AndAlso Not IsDBNull(s("Status")) Then
                                                                           status = s("Status").ToString().ToLower()
                                                                       End If
                                                                       Dim qty As Integer = 0
                                                                       If s.Table.Columns.Contains("quantity") AndAlso Not IsDBNull(s("quantity")) Then
                                                                           Integer.TryParse(s("quantity").ToString(), qty)
                                                                       ElseIf s.Table.Columns.Contains("QuantityInStock") AndAlso Not IsDBNull(s("QuantityInStock")) Then
                                                                           Integer.TryParse(s("QuantityInStock").ToString(), qty)
                                                                       End If
                                                                       Return (status = "available" OrElse status = "") AndAlso qty > 0
                                                                   End Function)

            Dim availableSupplies As DataTable = Nothing
            If availableList.Any() Then
                availableSupplies = availableList.CopyToDataTable()
            End If

            ' Populate ComboBox with available supplies
            Dim combo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox2")
            If combo IsNot Nothing Then
                combo.DataSource = Nothing
                If availableSupplies IsNot Nothing Then
                    combo.DataSource = availableSupplies
                    combo.DisplayMember = "itemName"
                    combo.ValueMember = If(availableSupplies.Columns.Contains("supplyId"), "supplyId", "supply_id")
                Else
                    combo.Items.Clear()
                End If
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

        ' Validate that a request exists - REQUIRED for assignment
        If currentRequestID <= 0 Then
            MessageBox.Show("Cannot assign items without a valid request. Please select a request from Property Request Management or Supply Request Management first.", "No Request Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Determine if assigning property or supply
            Dim isProperty As Boolean = False
            Dim isSupply As Boolean = False
            Dim selectedPropertyID As Integer = 0
            Dim selectedSupplyID As Integer = 0

            Dim propCombo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox1")
            Dim supCombo As ComboBox = FindControlOfType(Of ComboBox)("ComboBox2")

            If propCombo IsNot Nothing AndAlso propCombo.SelectedIndex >= 0 AndAlso propCombo.SelectedValue IsNot Nothing Then
                isProperty = True
                Integer.TryParse(propCombo.SelectedValue.ToString(), selectedPropertyID)
            End If

            If supCombo IsNot Nothing AndAlso supCombo.SelectedIndex >= 0 AndAlso supCombo.SelectedValue IsNot Nothing Then
                isSupply = True
                Integer.TryParse(supCombo.SelectedValue.ToString(), selectedSupplyID)
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
                    Dim dtPicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("DateTimePicker1")
                    If dtPicker IsNot Nothing AndAlso dtPicker.Value > Date.Today Then
                        expectedReturnDate = dtPicker.Value
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
                        ' Update property assignment - use assigned_to column (or assigned_to_custodian if that's the column name)
                        Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
                        If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                            ' Get requester info from request (requesterName sometimes stored)
                            Dim requesterNameObj As Object = Nothing
                            Using getUserCmd As New MySqlCommand("SELECT requesterName, departmentId FROM property_requests WHERE requestId = @requestID LIMIT 1", conn)
                                getUserCmd.Parameters.AddWithValue("@requestID", currentRequestID)
                                Using reader = getUserCmd.ExecuteReader()
                                    If reader.Read() Then
                                        requesterNameObj = If(IsDBNull(reader("requesterName")), Nothing, reader("requesterName"))
                                    End If
                                End Using
                            End Using

                            ' Update property with assignment (note: using requesterName as assigned_to may be schema mismatch; using DBNull if not numeric)
                            Using cmd As New MySqlCommand("UPDATE properties SET assigned_to = @userID, status = 'Assigned', updated_at = NOW() WHERE property_id = @propertyID", conn)
                                Dim userIdParam As Object = DBNull.Value
                                ' If requesterNameObj is numeric user id, use it; otherwise leave null
                                Dim parsedUserId As Integer = 0
                                If requesterNameObj IsNot Nothing AndAlso Integer.TryParse(requesterNameObj.ToString(), parsedUserId) Then
                                    userIdParam = parsedUserId
                                End If
                                cmd.Parameters.AddWithValue("@userID", userIdParam)
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
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error assigning item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("AssignRequestManagement btnSave_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub RoundedPanel3_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel3.Paint
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' intentionally left blank — wired dynamically
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