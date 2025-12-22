Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Linq
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Public Class AssignRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False
    Private allAvailableProperties As DataTable = Nothing
    Private searchBox As TextBox = Nothing

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
        LoadLocationDropdown()
        ' Load available properties/supplies even if no request
        LoadAvailableProperties()
        EnsureSearchBox()
        ' Wire up property ID selection change event for auto-fill
        If propertyId IsNot Nothing Then
            AddHandler propertyId.SelectedIndexChanged, AddressOf PropertyId_SelectedIndexChanged
        End If
        ' Wire up property name selection change event for auto-fill
        If propertyName IsNot Nothing Then
            AddHandler propertyName.SelectedIndexChanged, AddressOf PropertyName_SelectedIndexChanged
        End If
        ' Wire up department change for cascading employee dropdown
        If department IsNot Nothing Then
            AddHandler department.SelectedIndexChanged, AddressOf Department_SelectedIndexChanged
        End If
        ' Load request data if RequestID is set
        If currentRequestID > 0 Then
            LoadRequestData()
        End If
    End Sub

    Private Sub EnsureSearchBox()
        If searchBox IsNot Nothing Then Return
        Try
            searchBox = New TextBox()
            searchBox.Name = "assignPropertySearch"
            searchBox.Font = New Drawing.Font("Poppins", 10.0!, Drawing.FontStyle.Regular)
            searchBox.Width = 360
            searchBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            ' .NET Framework TextBox has no PlaceholderText; use a simple watermark instead.
            searchBox.ForeColor = Drawing.Color.Gray
            searchBox.Text = "Search property (name/category/supplier/status)..."
            searchBox.Location = New Drawing.Point(Me.Width - searchBox.Width - 30, 48)
            AddHandler Me.SizeChanged, Sub()
                                           If searchBox IsNot Nothing Then
                                               searchBox.Location = New Drawing.Point(Me.Width - searchBox.Width - 30, searchBox.Location.Y)
                                           End If
                                       End Sub
            AddHandler searchBox.TextChanged, AddressOf ApplyPropertySearch
            AddHandler searchBox.GotFocus, Sub()
                                               If searchBox IsNot Nothing AndAlso searchBox.ForeColor = Drawing.Color.Gray Then
                                                   searchBox.Text = ""
                                                   searchBox.ForeColor = Drawing.Color.Black
                                               End If
                                           End Sub
            AddHandler searchBox.LostFocus, Sub()
                                                If searchBox IsNot Nothing AndAlso String.IsNullOrWhiteSpace(searchBox.Text) Then
                                                    searchBox.ForeColor = Drawing.Color.Gray
                                                    searchBox.Text = "Search property (name/category/supplier/status)..."
                                                End If
                                            End Sub
            Me.Controls.Add(searchBox)
            searchBox.BringToFront()
        Catch
            ' ignore
        End Try
    End Sub

    Private Sub ApplyPropertySearch(sender As Object, e As EventArgs)
        Dim q As String = ""
        If searchBox IsNot Nothing Then q = searchBox.Text
        ApplyPropertySearch(q)
    End Sub

    Private Sub ApplyPropertySearch(q As String)
        If allAvailableProperties Is Nothing Then Return
        Dim searchLower As String = If(String.IsNullOrWhiteSpace(q), "", q.Trim().ToLower())
        If String.IsNullOrEmpty(searchLower) Then
            BindPropertiesToDropdowns(allAvailableProperties)
            Return
        End If

        Try
            Dim rows = allAvailableProperties.AsEnumerable().Where(Function(r)
                                                                       Dim itemNameVal As String = If(r.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(r("itemName")), r("itemName").ToString().ToLower(), "")
                                                                       Dim categoryVal As String = If(r.Table.Columns.Contains("category") AndAlso Not IsDBNull(r("category")), r("category").ToString().ToLower(), "")
                                                                       Dim supplierVal As String = If(r.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(r("supplier")), r("supplier").ToString().ToLower(), "")
                                                                       Dim statusVal As String = If(r.Table.Columns.Contains("status") AndAlso Not IsDBNull(r("status")), r("status").ToString().ToLower(), "")
                                                                       Return itemNameVal.Contains(searchLower) OrElse categoryVal.Contains(searchLower) OrElse supplierVal.Contains(searchLower) OrElse statusVal.Contains(searchLower)
                                                                   End Function)
            If rows.Any() Then
                BindPropertiesToDropdowns(rows.CopyToDataTable())
            Else
                BindPropertiesToDropdowns(allAvailableProperties.Clone())
            End If
        Catch
            BindPropertiesToDropdowns(allAvailableProperties)
        End Try
    End Sub

    Private Sub BindPropertiesToDropdowns(dt As DataTable)
        If dt Is Nothing Then Return
        Try
            If propertyId IsNot Nothing Then
                propertyId.DataSource = dt.Copy()
                propertyId.DisplayMember = "propertyId"
                propertyId.ValueMember = "propertyId"
                propertyId.SelectedIndex = -1
            End If
            If propertyName IsNot Nothing Then
                propertyName.DataSource = dt.Copy()
                propertyName.DisplayMember = "itemName"
                propertyName.ValueMember = "propertyId"
                propertyName.SelectedIndex = -1
            End If
        Catch
        End Try
    End Sub

    Private Sub LoadCategoryDropdown()
        Try
            ' ComboBox1 is the category dropdown based on designer
            If ComboBox1 IsNot Nothing Then
                ' Clear any DataSource binding first
                ComboBox1.DataSource = Nothing
                ComboBox1.Items.Clear()
                ' Try to load from database first
                Try
                    Dim categoriesTable As DataTable = DatabaseConnection.GetCategories("property")
                    If categoriesTable IsNot Nothing AndAlso categoriesTable.Rows.Count > 0 Then
                        ' Use DataSource with proper DisplayMember
                        ComboBox1.DataSource = categoriesTable
                        If categoriesTable.Columns.Contains("categoryName") Then
                            ComboBox1.DisplayMember = "categoryName"
                            ComboBox1.ValueMember = "categoryName"
                        ElseIf categoriesTable.Columns.Contains("category_name") Then
                            ComboBox1.DisplayMember = "category_name"
                            ComboBox1.ValueMember = "category_name"
                        ElseIf categoriesTable.Columns.Count > 0 Then
                            ComboBox1.DisplayMember = categoriesTable.Columns(0).ColumnName
                            ComboBox1.ValueMember = categoriesTable.Columns(0).ColumnName
                        End If
                    Else
                        ' Fallback to hardcoded list
                        ComboBox1.Items.AddRange(New String() {
                            "Furniture", "Equipment", "Office Supplies", "IT Equipment",
                            "Laboratory Apparatus", "Books and Publications",
                            "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
                        })
                    End If
                Catch
                    ' Fallback to hardcoded list if database load fails
                    ComboBox1.Items.AddRange(New String() {
                        "Furniture", "Equipment", "Office Supplies", "IT Equipment",
                        "Laboratory Apparatus", "Books and Publications",
                        "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
                    })
                End Try
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadCategoryDropdown Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadDepartmentDropdown()
        Try
            Dim deptTable As DataTable = DatabaseConnection.GetDepartmentLookup(True)
            If deptTable IsNot Nothing AndAlso deptTable.Rows.Count > 0 AndAlso department IsNot Nothing Then
                department.DataSource = deptTable
                ' Use camelCase column names if available, fallback to snake_case
                If deptTable.Columns.Contains("departmentName") Then
                    department.DisplayMember = "departmentName"
                    department.ValueMember = "departmentId"
                ElseIf deptTable.Columns.Contains("department_name") Then
                    department.DisplayMember = "department_name"
                    department.ValueMember = "department_id"
                ElseIf deptTable.Columns.Count >= 2 Then
                    department.DisplayMember = deptTable.Columns(1).ColumnName
                    department.ValueMember = deptTable.Columns(0).ColumnName
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadDepartmentDropdown Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadConditionDropdown()
        Try
            If condition IsNot Nothing Then
                condition.Items.Clear()
                condition.Items.AddRange(New String() {"New", "Good", "Fair", "Damaged", "For Repair"})
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadConditionDropdown Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadLocationDropdown()
        Try
            If location IsNot Nothing Then
                location.Items.Clear()
                ' Try to load from database first
                Try
                    Dim locationsTable As DataTable = DatabaseConnection.GetLocations()
                    If locationsTable IsNot Nothing AndAlso locationsTable.Rows.Count > 0 Then
                        For Each row As DataRow In locationsTable.Rows
                            Dim locName As String = ""
                            If row.Table.Columns.Contains("locationName") AndAlso Not IsDBNull(row("locationName")) Then
                                locName = row("locationName").ToString()
                            ElseIf row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")) Then
                                locName = row("location").ToString()
                            ElseIf row.Table.Columns.Count > 0 AndAlso Not IsDBNull(row(0)) Then
                                locName = row(0).ToString()
                            End If
                            If Not String.IsNullOrEmpty(locName) AndAlso Not location.Items.Contains(locName) Then
                                location.Items.Add(locName)
                            End If
                        Next
                    End If
                Catch
                    ' Fallback to hardcoded
                End Try
                ' Fallback to hardcoded list
                If location.Items.Count = 0 Then
                    location.Items.AddRange(New String() {
                        "Main Building", "Annex Building", "Storage Room", "Office 1", "Office 2",
                        "Conference Room", "Laboratory", "Library", "Gymnasium", "Cafeteria"
                    })
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadLocationDropdown Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub Department_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Load employees when department changes
        If department Is Nothing OrElse department.SelectedValue Is Nothing Then Return

        Try
            Dim deptID As Integer
            If TypeOf department.SelectedValue Is DataRowView Then
                Dim drv As DataRowView = CType(department.SelectedValue, DataRowView)
                ' Try both camelCase and snake_case column names
                If drv.Row.Table.Columns.Contains("departmentId") Then
                    If Not Integer.TryParse(drv.Row("departmentId").ToString(), deptID) Then Return
                ElseIf drv.Row.Table.Columns.Contains("department_id") Then
                    If Not Integer.TryParse(drv.Row("department_id").ToString(), deptID) Then Return
                Else
                    Return
                End If
            ElseIf Not Integer.TryParse(department.SelectedValue.ToString(), deptID) Then
                Return
            End If

            Dim usersTable As DataTable = DatabaseConnection.GetUsersByDepartment(deptID)
            If usersTable IsNot Nothing AndAlso usersTable.Rows.Count > 0 AndAlso employee IsNot Nothing Then
                employee.DataSource = usersTable
                employee.DisplayMember = "fullName"
                employee.ValueMember = "userId"
            ElseIf employee IsNot Nothing Then
                employee.DataSource = Nothing
                employee.Items.Clear()
                employee.Items.Add("No employees in this department")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Department_SelectedIndexChanged Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub PropertyId_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Auto-fill all fields when a property ID is selected
        If propertyId Is Nothing OrElse propertyId.SelectedValue Is Nothing Then Return

        Try
            Dim propID As Integer
            If TypeOf propertyId.SelectedValue Is DataRowView Then
                Dim drv As DataRowView = CType(propertyId.SelectedValue, DataRowView)
                If Not Integer.TryParse(drv.Row("propertyId").ToString(), propID) Then Return
            ElseIf Not Integer.TryParse(propertyId.SelectedValue.ToString(), propID) Then
                Return
            End If

            AutoFillPropertyDetails(propID)

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] PropertyId_SelectedIndexChanged Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub PropertyName_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Auto-fill all fields when a property name is selected
        If propertyName Is Nothing OrElse propertyName.SelectedValue Is Nothing Then Return

        Try
            Dim propID As Integer
            If TypeOf propertyName.SelectedValue Is DataRowView Then
                Dim drv As DataRowView = CType(propertyName.SelectedValue, DataRowView)
                If Not Integer.TryParse(drv.Row("propertyId").ToString(), propID) Then Return
            ElseIf Not Integer.TryParse(propertyName.SelectedValue.ToString(), propID) Then
                Return
            End If

            AutoFillPropertyDetails(propID)

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] PropertyName_SelectedIndexChanged Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub AutoFillPropertyDetails(propID As Integer)
        ' Get property details from database
        Dim propertyData As DataRow = DatabaseConnection.GetPropertyDetails(propID)
        If propertyData Is Nothing Then Return

        ' Auto-fill Property Name dropdown (sync with Property ID selection)
        If propertyName IsNot Nothing AndAlso propertyName.DataSource IsNot Nothing Then
            Try
                For i As Integer = 0 To propertyName.Items.Count - 1
                    Dim drv As DataRowView = TryCast(propertyName.Items(i), DataRowView)
                    If drv IsNot Nothing Then
                        Dim itemPropID As Integer = 0
                        If drv.Row.Table.Columns.Contains("propertyId") AndAlso Integer.TryParse(drv.Row("propertyId").ToString(), itemPropID) Then
                            If itemPropID = propID Then
                                propertyName.SelectedIndex = i
                                Exit For
                            End If
                        End If
                    End If
                Next
            Catch
            End Try
        End If

        ' Auto-fill Serial Number
        If serialNumber IsNot Nothing Then
            Dim serialNum As String = ""
            If propertyData.Table.Columns.Contains("serialNumber") AndAlso Not IsDBNull(propertyData("serialNumber")) Then
                serialNum = propertyData("serialNumber").ToString()
            End If
            serialNumber.Text = serialNum
        End If

        ' Auto-fill Supplier
        If suppier IsNot Nothing Then
            Dim supplierVal As String = ""
            If propertyData.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(propertyData("supplier")) Then
                supplierVal = propertyData("supplier").ToString()
            End If
            suppier.Text = supplierVal
        End If

        ' Auto-fill Category dropdown
        If ComboBox1 IsNot Nothing Then
            Dim categoryVal As String = ""
            If propertyData.Table.Columns.Contains("category") AndAlso Not IsDBNull(propertyData("category")) Then
                categoryVal = propertyData("category").ToString()
            End If
            ' Clear DataSource if bound to prevent DataRowView display issue
            If ComboBox1.DataSource IsNot Nothing Then
                ComboBox1.DataSource = Nothing
                If ComboBox1.Items.Count = 0 Then
                    ComboBox1.Items.AddRange(New String() {
                        "Furniture", "Equipment", "Office Supplies", "IT Equipment",
                        "Laboratory Apparatus", "Books and Publications",
                        "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
                    })
                End If
            End If
            Dim categoryIndex As Integer = ComboBox1.FindStringExact(categoryVal)
            If categoryIndex >= 0 Then
                ComboBox1.SelectedIndex = categoryIndex
            ElseIf Not String.IsNullOrEmpty(categoryVal) Then
                ComboBox1.Items.Add(categoryVal)
                ComboBox1.SelectedItem = categoryVal
            End If
        End If

        ' Auto-fill Condition
        If condition IsNot Nothing Then
            Dim conditionVal As String = ""
            If propertyData.Table.Columns.Contains("condition") AndAlso Not IsDBNull(propertyData("condition")) Then
                conditionVal = propertyData("condition").ToString()
            End If
            Dim conditionIndex As Integer = condition.FindStringExact(conditionVal)
            If conditionIndex >= 0 Then
                condition.SelectedIndex = conditionIndex
            Else
                condition.Text = conditionVal
            End If
        End If

        ' Auto-fill Cost
        If cost IsNot Nothing Then
            Dim costVal As Decimal = 0
            If propertyData.Table.Columns.Contains("acquisitionCost") AndAlso Not IsDBNull(propertyData("acquisitionCost")) Then
                Decimal.TryParse(propertyData("acquisitionCost").ToString(), costVal)
            End If
            cost.Value = costVal
        End If

        ' Auto-fill Location dropdown
        If location IsNot Nothing Then
            Dim locationVal As String = ""
            If propertyData.Table.Columns.Contains("location") AndAlso Not IsDBNull(propertyData("location")) Then
                locationVal = propertyData("location").ToString()
            End If
            Dim locIndex As Integer = location.FindStringExact(locationVal)
            If locIndex >= 0 Then
                location.SelectedIndex = locIndex
            ElseIf Not String.IsNullOrEmpty(locationVal) Then
                location.Items.Add(locationVal)
                location.SelectedItem = locationVal
            End If
        End If

        ' Auto-fill Department
        If department IsNot Nothing Then
            Dim deptName As String = ""
            If propertyData.Table.Columns.Contains("assignedDepartment") AndAlso Not IsDBNull(propertyData("assignedDepartment")) Then
                deptName = propertyData("assignedDepartment").ToString()
            End If
            If Not String.IsNullOrEmpty(deptName) Then
                Dim deptIndex As Integer = department.FindStringExact(deptName)
                If deptIndex >= 0 Then
                    department.SelectedIndex = deptIndex
                Else
                    department.Text = deptName
                End If
            End If
        End If

        ' Auto-fill Employee
        If employee IsNot Nothing Then
            Dim employeeName As String = ""
            If propertyData.Table.Columns.Contains("assignedEmployee") AndAlso Not IsDBNull(propertyData("assignedEmployee")) Then
                employeeName = propertyData("assignedEmployee").ToString()
            End If
            If Not String.IsNullOrEmpty(employeeName) Then
                Dim empIndex As Integer = employee.FindStringExact(employeeName)
                If empIndex >= 0 Then
                    employee.SelectedIndex = empIndex
                End If
            End If
        End If

        ' Auto-fill Date Purchased
        If datePurchased IsNot Nothing Then
            If propertyData.Table.Columns.Contains("acquisitionDate") AndAlso Not IsDBNull(propertyData("acquisitionDate")) Then
                Try
                    datePurchased.Value = Convert.ToDateTime(propertyData("acquisitionDate"))
                Catch
                End Try
            End If
        End If

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
            ' Do not block navigation; allow opening the assignment panel even without a pre-selected request.
            ' RequestID can be provided later by navigating from the Request Management grid.
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
            allAvailableProperties = If(availableProperties IsNot Nothing, availableProperties.Copy(), propertiesTable.Copy())

            BindPropertiesToDropdowns(If(availableProperties, propertiesTable))
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadAvailableProperties Exception: " & ex.Message)
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

        Try
            ' Determine if assigning property
            Dim selectedPropertyID As Integer = 0

            If propertyId IsNot Nothing AndAlso propertyId.SelectedIndex >= 0 AndAlso propertyId.SelectedValue IsNot Nothing Then
                Integer.TryParse(propertyId.SelectedValue.ToString(), selectedPropertyID)
            End If

            ' Validate that a property is selected - check both ComboBoxes with improved logic
            If propertyId IsNot Nothing AndAlso propertyId.SelectedIndex >= 0 Then
                If propertyId.SelectedValue IsNot Nothing Then
                    Integer.TryParse(propertyId.SelectedValue.ToString(), selectedPropertyID)
                    System.Diagnostics.Debug.WriteLine($"[v0] AssignRequestManagement - Property selected from propertyId (SelectedValue): {selectedPropertyID}")
                ElseIf propertyId.SelectedItem IsNot Nothing Then
                    ' Try to get from SelectedItem if DataRowView
                    Dim drv As DataRowView = TryCast(propertyId.SelectedItem, DataRowView)
                    If drv IsNot Nothing AndAlso drv.Row.Table.Columns.Contains("propertyId") Then
                        Integer.TryParse(drv.Row("propertyId").ToString(), selectedPropertyID)
                        System.Diagnostics.Debug.WriteLine($"[v0] AssignRequestManagement - Property selected from propertyId (DataRowView): {selectedPropertyID}")
                    End If
                End If
            End If
            
            ' If still not found, check propertyName ComboBox
            If selectedPropertyID <= 0 AndAlso propertyName IsNot Nothing AndAlso propertyName.SelectedIndex >= 0 Then
                If propertyName.SelectedValue IsNot Nothing Then
                    Integer.TryParse(propertyName.SelectedValue.ToString(), selectedPropertyID)
                    System.Diagnostics.Debug.WriteLine($"[v0] AssignRequestManagement - Property selected from propertyName (SelectedValue): {selectedPropertyID}")
                ElseIf propertyName.SelectedItem IsNot Nothing Then
                    ' Try to get from SelectedItem if DataRowView
                    Dim drv As DataRowView = TryCast(propertyName.SelectedItem, DataRowView)
                    If drv IsNot Nothing AndAlso drv.Row.Table.Columns.Contains("propertyId") Then
                        Integer.TryParse(drv.Row("propertyId").ToString(), selectedPropertyID)
                        System.Diagnostics.Debug.WriteLine($"[v0] AssignRequestManagement - Property selected from propertyName (DataRowView): {selectedPropertyID}")
                    End If
                End If
            End If
            
            If selectedPropertyID <= 0 Then
                MessageBox.Show("Please select a property to assign from the Property ID or Property Name dropdown.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                System.Diagnostics.Debug.WriteLine("[v0] AssignRequestManagement - Validation failed: No property selected")
                Return
            End If

            ' Validate employee selection
            Dim selectedEmployeeID As Integer = 0
            If employee IsNot Nothing AndAlso employee.SelectedValue IsNot Nothing Then
                Integer.TryParse(employee.SelectedValue.ToString(), selectedEmployeeID)
            End If
            If selectedEmployeeID <= 0 Then
                MessageBox.Show("Please select an employee to assign the property to.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' If we have a request ID, validate it exists and is approved/pending
            If currentRequestID > 0 Then
                Dim requestStatus As String = ""
                If requestData IsNot Nothing AndAlso requestData.Table.Columns.Contains("status") Then
                    requestStatus = If(IsDBNull(requestData("status")), "", requestData("status").ToString().ToLower())
                End If

                ' Allow assignment even if rejected (admin direct assignment allowed)
            End If

            ' Get admin info
            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)
            Dim adminName As String = SessionContext.CurrentUsername
            Dim adminUserType As String = SessionContext.CurrentRole

            ' Flexible assignment:
            ' - Always allow direct property assignment (request is optional).
            ' - If request exists, we will attempt to mark it Released, but we do NOT block if it fails.

            Dim deptIdOpt As Integer? = Nothing
            If department IsNot Nothing AndAlso department.SelectedValue IsNot Nothing Then
                Dim parsedDeptId As Integer = 0
                If Integer.TryParse(department.SelectedValue.ToString(), parsedDeptId) Then
                    deptIdOpt = parsedDeptId
                End If
            End If

            Dim locationVal As String = ""
            If location IsNot Nothing Then
                locationVal = If(location.SelectedItem IsNot Nothing, location.SelectedItem.ToString(), location.Text)
            End If

            Dim purposeText As String = If(assignmentPurpose IsNot Nothing, assignmentPurpose.Text, "")

            ' Update property with assignment
            Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
            If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                Using cmd As New MySqlCommand("UPDATE properties SET assignedTo = @userID, departmentId = @deptID, location = @location, status = 'Assigned', updatedAt = NOW() WHERE propertyId = @propertyID", conn)
                    cmd.Parameters.AddWithValue("@userID", selectedEmployeeID)
                    cmd.Parameters.AddWithValue("@deptID", If(deptIdOpt.HasValue, deptIdOpt.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@location", If(String.IsNullOrEmpty(locationVal), DBNull.Value, locationVal))
                    cmd.Parameters.AddWithValue("@propertyID", selectedPropertyID)
                    cmd.ExecuteNonQuery()
                End Using

                ' If there is an existing request, try to mark it Released but do not block if it doesn't update.
                If currentRequestID > 0 Then
                    Try
                        DatabaseConnection.ReleasePropertyRequest(currentRequestID, adminID, adminName, adminUserType, Date.Today, Nothing)
                    Catch
                    End Try
                End If

                ' Ensure a Released request record exists for My Borrowed Items view.
                DatabaseConnection.CreateDirectPropertyRelease(selectedEmployeeID, selectedPropertyID, deptIdOpt,
                                                              If(propertyName IsNot Nothing, propertyName.Text, ""),
                                                              1, purposeText, adminName, Date.Today)

                If conn.State = ConnectionState.Open Then conn.Close()
            End If

            MessageBox.Show("Property assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
        Catch ex As Exception
            MessageBox.Show("Error assigning item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("AssignRequestManagement btnSave_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub RoundedPanel3_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel3.Paint
    End Sub

    Private Sub NavigateBack()
        ' Check for SADashboard first (Super Admin)
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            saDashboard.LoadUserControl(New UC_PropertyRequestManagement())
            Return
        End If
        
        ' Check for AdminDashboard
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