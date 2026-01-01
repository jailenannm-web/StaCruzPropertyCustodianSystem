Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Linq
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Public Class AssignSupplyManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False
    Private allAvailableSupplies As DataTable = Nothing
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

    Private Sub AssignSupplyManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureModifyPermission()
        ' Load dropdowns
        LoadCategoryDropdown()
        LoadDepartmentDropdown()
        LoadLocationDropdown()
        LoadUnitOfMeasureDropdown()
        LoadStockStatusDropdown()
        ' Load all employees initially (not filtered by department)
        LoadAllEmployees()
        ' Load available supplies
        LoadAvailableSupplies()
        EnsureSearchBox()
        ' Wire up supply ID selection change event for auto-fill
        If supplyId IsNot Nothing Then
            AddHandler supplyId.SelectedIndexChanged, AddressOf SupplyId_SelectedIndexChanged
        End If
        ' Wire up supply name selection change event for auto-fill
        If supplyName IsNot Nothing Then
            AddHandler supplyName.SelectedIndexChanged, AddressOf SupplyName_SelectedIndexChanged
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
            searchBox.Name = "assignSupplySearch"
            searchBox.Font = New Drawing.Font("Poppins", 10.0!, Drawing.FontStyle.Regular)
            searchBox.Width = 360
            searchBox.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            searchBox.TextAlign = HorizontalAlignment.Left
            ' .NET Framework TextBox has no PlaceholderText; use a simple watermark instead.
            searchBox.ForeColor = Drawing.Color.Gray
            searchBox.Text = "Search supply (name/category/supplier/status)..."
            searchBox.Location = New Drawing.Point(Me.Width - searchBox.Width - 30, 48)
            AddHandler Me.SizeChanged, Sub()
                                           If searchBox IsNot Nothing Then
                                               searchBox.Location = New Drawing.Point(Me.Width - searchBox.Width - 30, searchBox.Location.Y)
                                           End If
                                       End Sub
            AddHandler searchBox.TextChanged, AddressOf ApplySupplySearch
            AddHandler searchBox.GotFocus, Sub()
                                               If searchBox IsNot Nothing AndAlso searchBox.ForeColor = Drawing.Color.Gray Then
                                                   searchBox.Text = ""
                                                   searchBox.ForeColor = Drawing.Color.Black
                                               End If
                                           End Sub
            AddHandler searchBox.LostFocus, Sub()
                                                If searchBox IsNot Nothing AndAlso String.IsNullOrWhiteSpace(searchBox.Text) Then
                                                    searchBox.ForeColor = Drawing.Color.Gray
                                                    searchBox.Text = "Search supply (name/category/supplier/status)..."
                                                End If
                                            End Sub
            Me.Controls.Add(searchBox)
            searchBox.BringToFront()
        Catch
            ' ignore
        End Try
    End Sub

    Private Sub ApplySupplySearch(sender As Object, e As EventArgs)
        Dim q As String = ""
        If searchBox IsNot Nothing Then q = searchBox.Text
        ApplySupplySearch(q)
    End Sub

    Private Sub ApplySupplySearch(q As String)
        If allAvailableSupplies Is Nothing Then Return
        Dim searchLower As String = If(String.IsNullOrWhiteSpace(q), "", q.Trim().ToLower())
        If String.IsNullOrEmpty(searchLower) Then
            BindSuppliesToDropdowns(allAvailableSupplies)
            Return
        End If

        Try
            Dim rows = allAvailableSupplies.AsEnumerable().Where(Function(r)
                                                                     Dim itemNameVal As String = If(r.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(r("itemName")), r("itemName").ToString().ToLower(), "")
                                                                     Dim categoryVal As String = If(r.Table.Columns.Contains("category") AndAlso Not IsDBNull(r("category")), r("category").ToString().ToLower(), "")
                                                                     Dim supplierVal As String = If(r.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(r("supplier")), r("supplier").ToString().ToLower(), "")
                                                                     Dim statusVal As String = If(r.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(r("stockStatus")), r("stockStatus").ToString().ToLower(), "")
                                                                     Return itemNameVal.Contains(searchLower) OrElse categoryVal.Contains(searchLower) OrElse supplierVal.Contains(searchLower) OrElse statusVal.Contains(searchLower)
                                                                 End Function)
            If rows.Any() Then
                BindSuppliesToDropdowns(rows.CopyToDataTable())
            Else
                BindSuppliesToDropdowns(allAvailableSupplies.Clone())
            End If
        Catch
            BindSuppliesToDropdowns(allAvailableSupplies)
        End Try
    End Sub

    Private Sub BindSuppliesToDropdowns(dt As DataTable)
        If dt Is Nothing Then Return
        Try
            If supplyId IsNot Nothing Then
                supplyId.DataSource = dt.Copy()
                supplyId.DisplayMember = "supplyId"
                supplyId.ValueMember = "supplyId"
                supplyId.SelectedIndex = -1
            End If
            If supplyName IsNot Nothing Then
                supplyName.DataSource = dt.Copy()
                supplyName.DisplayMember = "itemName"
                supplyName.ValueMember = "supplyId"
                supplyName.SelectedIndex = -1
            End If
        Catch
        End Try
    End Sub

    Private Sub LoadCategoryDropdown()
        Try
            If category IsNot Nothing Then
                category.DataSource = Nothing
                category.Items.Clear()
                ' Try to load from database first
                Try
                    Dim categoriesTable As DataTable = modDB.GetCategories("supply")
                    If categoriesTable IsNot Nothing AndAlso categoriesTable.Rows.Count > 0 Then
                        category.DataSource = categoriesTable
                        If categoriesTable.Columns.Contains("categoryName") Then
                            category.DisplayMember = "categoryName"
                            category.ValueMember = "categoryName"
                        ElseIf categoriesTable.Columns.Contains("category_name") Then
                            category.DisplayMember = "category_name"
                            category.ValueMember = "category_name"
                        ElseIf categoriesTable.Columns.Count > 0 Then
                            category.DisplayMember = categoriesTable.Columns(0).ColumnName
                            category.ValueMember = categoriesTable.Columns(0).ColumnName
                        End If
                    Else
                        category.Items.AddRange(New String() {
                            "Office Supplies", "Cleaning Supplies", "Medical Supplies", "IT Supplies",
                            "Laboratory Supplies", "Maintenance Supplies", "Others"
                        })
                    End If
                Catch
                    category.Items.AddRange(New String() {
                        "Office Supplies", "Cleaning Supplies", "Medical Supplies", "IT Supplies",
                        "Laboratory Supplies", "Maintenance Supplies", "Others"
                    })
                End Try
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadCategoryDropdown Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadDepartmentDropdown()
        Try
            Dim deptTable As DataTable = modDB.GetDepartmentLookup(True)
            If deptTable IsNot Nothing AndAlso deptTable.Rows.Count > 0 AndAlso department IsNot Nothing Then
                department.DataSource = deptTable
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

    Private Sub LoadLocationDropdown()
        Try
            If location IsNot Nothing Then
                location.Items.Clear()
                Try
                    Dim locationsTable As DataTable = modDB.GetLocations()
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
                End Try
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

    Private Sub LoadUnitOfMeasureDropdown()
        Try
            If unitOfMeasure IsNot Nothing Then
                unitOfMeasure.Items.Clear()
                unitOfMeasure.Items.AddRange(New String() {
                    "Piece", "Pack", "Box", "Ream", "Bottle", "Gallon",
                    "Roll", "Set", "Bundle", "Carton", "Dozen", "Others"
                })
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadUnitOfMeasureDropdown Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadStockStatusDropdown()
        Try
            If stockStatus IsNot Nothing Then
                stockStatus.Items.Clear()
                stockStatus.Items.AddRange(New String() {"Available", "Low Stock", "Out of Stock"})
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadStockStatusDropdown Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub Department_SelectedIndexChanged(sender As Object, e As EventArgs)
        If department Is Nothing OrElse department.SelectedValue Is Nothing Then
            ' If no department selected, load all employees
            LoadAllEmployees()
            Return
        End If

        Try
            Dim deptID As Integer
            If TypeOf department.SelectedValue Is DataRowView Then
                Dim drv As DataRowView = CType(department.SelectedValue, DataRowView)
                If drv.Row.Table.Columns.Contains("departmentId") Then
                    If Not Integer.TryParse(drv.Row("departmentId").ToString(), deptID) Then
                        LoadAllEmployees()
                        Return
                    End If
                ElseIf drv.Row.Table.Columns.Contains("department_id") Then
                    If Not Integer.TryParse(drv.Row("department_id").ToString(), deptID) Then
                        LoadAllEmployees()
                        Return
                    End If
                Else
                    LoadAllEmployees()
                    Return
                End If
            ElseIf Not Integer.TryParse(department.SelectedValue.ToString(), deptID) Then
                LoadAllEmployees()
                Return
            End If

            Dim usersTable As DataTable = modDB.GetUsersByDepartment(deptID)
            If usersTable IsNot Nothing AndAlso usersTable.Rows.Count > 0 AndAlso employee IsNot Nothing Then
                employee.DataSource = usersTable
                employee.DisplayMember = "fullName"
                employee.ValueMember = "userId"
            ElseIf employee IsNot Nothing Then
                ' If no employees in department, load all employees
                LoadAllEmployees()
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Department_SelectedIndexChanged Exception: " & ex.Message)
            LoadAllEmployees()
        End Try
    End Sub
    
    Private Sub LoadAllEmployees()
        Try
            Dim allUsersTable As DataTable = modDB.GetActiveUsersForAssignment(Nothing)
            If allUsersTable IsNot Nothing AndAlso allUsersTable.Rows.Count > 0 AndAlso employee IsNot Nothing Then
                employee.DataSource = allUsersTable
                employee.DisplayMember = "fullName"
                employee.ValueMember = "userId"
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadAllEmployees Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub SupplyId_SelectedIndexChanged(sender As Object, e As EventArgs)
        If supplyId Is Nothing OrElse supplyId.SelectedValue Is Nothing Then Return

        Try
            Dim sID As Integer
            If TypeOf supplyId.SelectedValue Is DataRowView Then
                Dim drv As DataRowView = CType(supplyId.SelectedValue, DataRowView)
                If Not Integer.TryParse(drv.Row("supplyId").ToString(), sID) Then Return
            ElseIf Not Integer.TryParse(supplyId.SelectedValue.ToString(), sID) Then
                Return
            End If

            AutoFillSupplyDetails(sID)

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] SupplyId_SelectedIndexChanged Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub SupplyName_SelectedIndexChanged(sender As Object, e As EventArgs)
        If supplyName Is Nothing OrElse supplyName.SelectedValue Is Nothing Then Return

        Try
            Dim sID As Integer
            If TypeOf supplyName.SelectedValue Is DataRowView Then
                Dim drv As DataRowView = CType(supplyName.SelectedValue, DataRowView)
                If Not Integer.TryParse(drv.Row("supplyId").ToString(), sID) Then Return
            ElseIf Not Integer.TryParse(supplyName.SelectedValue.ToString(), sID) Then
                Return
            End If

            AutoFillSupplyDetails(sID)

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] SupplyName_SelectedIndexChanged Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub AutoFillSupplyDetails(sID As Integer)
        ' Get supply details from database
        Dim supplyData As DataRow = modDB.GetSupplyById(sID)
        If supplyData Is Nothing Then Return

        ' Auto-fill Supply Name dropdown (sync with Supply ID selection)
        If supplyName IsNot Nothing AndAlso supplyName.DataSource IsNot Nothing Then
            Try
                For i As Integer = 0 To supplyName.Items.Count - 1
                    Dim drv As DataRowView = TryCast(supplyName.Items(i), DataRowView)
                    If drv IsNot Nothing Then
                        Dim itemSupplyID As Integer = 0
                        If drv.Row.Table.Columns.Contains("supplyId") AndAlso Integer.TryParse(drv.Row("supplyId").ToString(), itemSupplyID) Then
                            If itemSupplyID = sID Then
                                supplyName.SelectedIndex = i
                                Exit For
                            End If
                        End If
                    End If
                Next
            Catch
            End Try
        End If

        ' Auto-fill Description
        If description IsNot Nothing Then
            Dim descVal As String = ""
            If supplyData.Table.Columns.Contains("description") AndAlso Not IsDBNull(supplyData("description")) Then
                descVal = supplyData("description").ToString()
            End If
            description.Text = descVal
        End If

        ' Auto-fill Supplier
        If supplier IsNot Nothing Then
            Dim supplierVal As String = ""
            If supplyData.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(supplyData("supplier")) Then
                supplierVal = supplyData("supplier").ToString()
            End If
            supplier.Text = supplierVal
        End If

        ' Auto-fill Category dropdown
        If category IsNot Nothing Then
            Dim categoryVal As String = ""
            If supplyData.Table.Columns.Contains("category") AndAlso Not IsDBNull(supplyData("category")) Then
                categoryVal = supplyData("category").ToString()
            End If
            If category.DataSource IsNot Nothing Then
                category.DataSource = Nothing
                If category.Items.Count = 0 Then
                    category.Items.AddRange(New String() {
                        "Office Supplies", "Cleaning Supplies", "Medical Supplies", "IT Supplies",
                        "Laboratory Supplies", "Maintenance Supplies", "Others"
                    })
                End If
            End If
            Dim categoryIndex As Integer = category.FindStringExact(categoryVal)
            If categoryIndex >= 0 Then
                category.SelectedIndex = categoryIndex
            ElseIf Not String.IsNullOrEmpty(categoryVal) Then
                category.Items.Add(categoryVal)
                category.SelectedItem = categoryVal
            End If
        End If

        ' Auto-fill Unit of Measure
        If unitOfMeasure IsNot Nothing Then
            Dim uomVal As String = ""
            If supplyData.Table.Columns.Contains("unitOfMeasure") AndAlso Not IsDBNull(supplyData("unitOfMeasure")) Then
                uomVal = supplyData("unitOfMeasure").ToString()
            End If
            Dim uomIndex As Integer = unitOfMeasure.FindStringExact(uomVal)
            If uomIndex >= 0 Then
                unitOfMeasure.SelectedIndex = uomIndex
            Else
                unitOfMeasure.Text = uomVal
            End If
        End If

        ' Auto-fill Stock Status
        If stockStatus IsNot Nothing Then
            Dim statusVal As String = ""
            If supplyData.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(supplyData("stockStatus")) Then
                statusVal = supplyData("stockStatus").ToString()
            End If
            Dim statusIndex As Integer = stockStatus.FindStringExact(statusVal)
            If statusIndex >= 0 Then
                stockStatus.SelectedIndex = statusIndex
            Else
                stockStatus.Text = statusVal
            End If
        End If

        ' Auto-fill Quantity Available
        If quantityAvailable IsNot Nothing Then
            Dim qtyVal As Integer = 0
            If supplyData.Table.Columns.Contains("quantity") AndAlso Not IsDBNull(supplyData("quantity")) Then
                Integer.TryParse(supplyData("quantity").ToString(), qtyVal)
            End If
            quantityAvailable.Value = qtyVal
        End If

        ' Auto-fill Unit Cost
        If unitCost IsNot Nothing Then
            Dim costVal As Decimal = 0
            If supplyData.Table.Columns.Contains("unitCost") AndAlso Not IsDBNull(supplyData("unitCost")) Then
                Decimal.TryParse(supplyData("unitCost").ToString(), costVal)
            End If
            unitCost.Value = costVal
        End If

        ' Auto-fill Location dropdown
        If location IsNot Nothing Then
            Dim locationVal As String = ""
            If supplyData.Table.Columns.Contains("location") AndAlso Not IsDBNull(supplyData("location")) Then
                locationVal = supplyData("location").ToString()
            End If
            Dim locIndex As Integer = location.FindStringExact(locationVal)
            If locIndex >= 0 Then
                location.SelectedIndex = locIndex
            ElseIf Not String.IsNullOrEmpty(locationVal) Then
                location.Items.Add(locationVal)
                location.SelectedItem = locationVal
            End If
        End If

    End Sub

    Private Sub LoadRequestData()
        If currentRequestID > 0 Then
            Try
                ' Try supply requests
                Dim dtSupply As DataTable = modDB.GetAllSuppliesRequests()
                Dim requestRows() As DataRow = dtSupply.Select("requestId = " & currentRequestID)
                If requestRows.Length = 0 Then
                    requestRows = dtSupply.Select("request_id = " & currentRequestID)
                End If
                If requestRows.Length > 0 Then
                    requestData = requestRows(0)
                    PopulateFormFields()
                    Return
                End If

                MessageBox.Show("Request not found. Please select a valid supply request.", "Invalid Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            ' Pre-fill quantity requested
            If quantityToAssign IsNot Nothing Then
                Dim qtyReq As Integer = 1
                If requestData.Table.Columns.Contains("quantityRequested") AndAlso Not IsDBNull(requestData("quantityRequested")) Then
                    Integer.TryParse(requestData("quantityRequested").ToString(), qtyReq)
                End If
                quantityToAssign.Value = qtyReq
            End If

            ' Pre-fill assignment purpose
            If assignmentPurpose IsNot Nothing Then
                Dim purpose As String = ""
                If requestData.Table.Columns.Contains("purpose") AndAlso Not IsDBNull(requestData("purpose")) Then
                    purpose = requestData("purpose").ToString()
                End If
                assignmentPurpose.Text = purpose
            End If

            LoadAvailableSupplies()
        Catch ex As Exception
            MessageBox.Show("Error populating form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAvailableSupplies()
        Try
            Dim suppliesTable As DataTable = modDB.GetAllSupplies()
            If suppliesTable Is Nothing OrElse suppliesTable.Rows.Count = 0 Then Return

            ' Filter for available supplies with quantity > 0
            Dim availableList = suppliesTable.AsEnumerable().Where(Function(s)
                                                                       Dim status As String = ""
                                                                       If s.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(s("stockStatus")) Then
                                                                           status = s("stockStatus").ToString().ToLower()
                                                                       End If
                                                                       Dim qty As Integer = 0
                                                                       If s.Table.Columns.Contains("quantity") AndAlso Not IsDBNull(s("quantity")) Then
                                                                           Integer.TryParse(s("quantity").ToString(), qty)
                                                                       End If
                                                                       Return (status = "available" OrElse status = "") AndAlso qty > 0
                                                                   End Function)

            Dim availableSupplies As DataTable = Nothing
            If availableList.Any() Then
                availableSupplies = availableList.CopyToDataTable()
            End If
            allAvailableSupplies = If(availableSupplies IsNot Nothing, availableSupplies.Copy(), suppliesTable.Copy())

            BindSuppliesToDropdowns(If(availableSupplies, suppliesTable))
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadAvailableSupplies Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBack()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not EnsureModifyPermission() Then
            Return
        End If

        Try
            ' Employee is required for direct assignment
            Dim selectedEmployeeID As Integer = 0
            If employee IsNot Nothing AndAlso employee.SelectedValue IsNot Nothing Then
                Integer.TryParse(employee.SelectedValue.ToString(), selectedEmployeeID)
            End If
            If selectedEmployeeID <= 0 Then
                MessageBox.Show("Please select an employee to assign the supply to.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get selected supply ID
            Dim selectedSupplyID As Integer = 0
            If supplyId IsNot Nothing AndAlso supplyId.SelectedIndex >= 0 AndAlso supplyId.SelectedValue IsNot Nothing Then
                Integer.TryParse(supplyId.SelectedValue.ToString(), selectedSupplyID)
            End If

            If selectedSupplyID <= 0 Then
                MessageBox.Show("Please select a supply to assign.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get quantity to assign
            Dim qtyToAssign As Integer = 1
            If quantityToAssign IsNot Nothing Then
                qtyToAssign = CInt(quantityToAssign.Value)
            End If

            If qtyToAssign <= 0 Then
                MessageBox.Show("Please enter a valid quantity to assign.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate status
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

            ' Get department ID
            Dim deptId As Integer? = Nothing
            If department IsNot Nothing AndAlso department.SelectedValue IsNot Nothing Then
                Dim d As Integer = 0
                If Integer.TryParse(department.SelectedValue.ToString(), d) Then deptId = d
            End If

            ' Get assignment purpose
            Dim purposeText As String = If(assignmentPurpose IsNot Nothing, assignmentPurpose.Text, "Supply assigned by admin")

            ' Use AssignSupplyToUser function which handles:
            ' 1. Quantity validation
            ' 2. Deducting from inventory
            ' 3. Setting assignedTo
            ' 4. Creating borrowed_items record automatically
            Dim success As Boolean = modDB.AssignSupplyToUser(selectedSupplyID, selectedEmployeeID, qtyToAssign, deptId, purposeText)

            If success Then
                ' If this assignment is related to a supply request, update the request status
                If currentRequestID > 0 Then
                    Try
                        Dim conn As MySqlConnection = modDB.GetConnection()
                        If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
                            Using updateCmd As New MySqlCommand("UPDATE supplies_requests SET status = 'Released', releasedBy = @adminName, releasedDate = NOW(), updatedAt = NOW() WHERE requestId = @requestID", conn)
                                updateCmd.Parameters.AddWithValue("@adminName", adminName)
                                updateCmd.Parameters.AddWithValue("@requestID", currentRequestID)
                                updateCmd.ExecuteNonQuery()
                            End Using
                            If conn.State = ConnectionState.Open Then conn.Close()
                        End If
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine("[v0] Error updating supply request status: " & ex.Message)
                        ' Don't fail the assignment if request update fails
                    End Try
                End If

                MessageBox.Show($"Supply assigned successfully to employee!{Environment.NewLine}{Environment.NewLine}The supply will now appear in their 'My Borrowed Items' page.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NavigateBack()
            Else
                MessageBox.Show("Failed to assign supply. Please check if sufficient quantity is available.", "Assignment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error assigning supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("AssignSupplyManagement btnSave_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub NavigateBack()
        ' Check for SADashboard first (Super Admin)
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            saDashboard.LoadUserControl(New UC_SupplyRequestManagement())
            Return
        End If
        
        ' Check for AdminDashboard
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_SupplyRequestManagement())
        Else
            Me.Parent?.Controls.Remove(Me)
        End If
    End Sub

    Private Function EnsureModifyPermission() As Boolean
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If hasFullAccess Then
            Return True
        End If
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyRequests)
        If Not canModifyRequests Then
            MessageBox.Show("You have view-only access to Supply Request Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
            Return False
        End If
        Return True
    End Function
End Class

