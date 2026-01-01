Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class AddPropertyRequest
    Private currentUserId As Integer

    ' Default constructor
    Public Sub New()
        InitializeComponent()
        InitializeForm()
    End Sub

    ' Constructor with pre-filled data (called from PropertyInventory)
    Public Sub New(itemName As String, Optional description As String = "", Optional quantity As Integer = 1)
        InitializeComponent()
        InitializeForm()
        
        ' Pre-fill the request details
        If Not String.IsNullOrWhiteSpace(itemName) Then
            txtItemName.Text = itemName
        End If
        
        If Not String.IsNullOrWhiteSpace(description) Then
            txtDescription.Text = description
        End If
        
        If quantity > 0 Then
            numQuantity.Value = quantity
        End If
        
        ' Set focus to purpose field since other fields are filled
        txtPurpose.Focus()
    End Sub

    Private Sub InitializeForm()
        ' Set default date to today
        dtpDateOfRequest.Value = Date.Today
        dtpDateOfRequest.Enabled = False ' Read-only

        ' Load current user information
        LoadUserInformation()

        ' Load departments
        LoadDepartments()
        
        ' Add event handler for item name text changed to auto-fill unit
        AddHandler txtItemName.TextChanged, AddressOf txtItemName_TextChanged

        ' Set focus to item name (first editable field)
        txtItemName.Focus()
    End Sub

    Private Sub LoadUserInformation()
        Try
            ' Get current user ID from session
            If SessionContext.CurrentUserID.HasValue Then
                currentUserId = SessionContext.CurrentUserID.Value
            Else
                MessageBox.Show("User session not found. Please login again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Load user details from database using direct query
            Dim conn As MySqlConnection = Nothing
            Try
                conn = modDB.GetConnection()
                If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
                    Dim query As String = "SELECT firstName, middleName, lastName, suffix, position, departmentId FROM users WHERE userId = @userId LIMIT 1"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@userId", currentUserId)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                ' Populate requester name
                                Dim firstName As String = If(reader.IsDBNull(reader.GetOrdinal("firstName")), "", reader("firstName").ToString())
                                Dim middleName As String = If(reader.IsDBNull(reader.GetOrdinal("middleName")), "", reader("middleName").ToString())
                                Dim lastName As String = If(reader.IsDBNull(reader.GetOrdinal("lastName")), "", reader("lastName").ToString())
                                Dim suffix As String = If(reader.IsDBNull(reader.GetOrdinal("suffix")), "", reader("suffix").ToString())

                                ' Build full name
                                Dim fullName As String = firstName
                                If Not String.IsNullOrWhiteSpace(middleName) Then fullName &= " " & middleName
                                fullName &= " " & lastName
                                If Not String.IsNullOrWhiteSpace(suffix) Then fullName &= " " & suffix

                                txtRequesterName.Text = fullName.Trim()

                                ' Populate position
                                txtPosition.Text = If(reader.IsDBNull(reader.GetOrdinal("position")), "Staff", reader("position").ToString())

                                ' Populate and lock department for staff users
                                If Not reader.IsDBNull(reader.GetOrdinal("departmentId")) Then
                                    Dim deptId As Integer = CInt(reader("departmentId"))
                                    ' Wait for departments to load, then select
                                    System.Windows.Forms.Application.DoEvents()
                                    SelectDepartmentById(deptId)
                                    
                                    ' Lock department field for staff (they can only request for their own department)
                                    If SessionContext.CurrentRole = "Staff" Then
                                        cboDepartment.Enabled = False
                                    End If
                                End If
                            Else
                                MessageBox.Show("Could not load user information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End Using
                    End Using
                End If
            Finally
                If conn IsNot Nothing Then
                    Try
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Dispose()
                    Catch
                    End Try
                End If
            End Try

        Catch ex As Exception
            MessageBox.Show("Error loading user information: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDepartments()
        Try
            Dim dt As DataTable = modDB.GetAllDepartments()
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                cboDepartment.Items.Clear()
                cboDepartment.Items.Add("-- Select Department --")

                For Each row As DataRow In dt.Rows
                    Dim deptItem As New DepartmentItem() With {
                        .DepartmentId = CInt(row("departmentId")),
                        .DepartmentName = row("departmentName").ToString()
                    }
                    cboDepartment.Items.Add(deptItem)
                Next

                ' Safely set selected index only if items exist
                If cboDepartment.Items.Count > 0 Then
                    cboDepartment.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("LoadDepartments Error: " & ex.Message)
        End Try
    End Sub

    Private Sub SelectDepartmentById(departmentId As Integer)
        Try
            ' Make sure we have items before trying to select
            If cboDepartment.Items.Count <= 1 Then
                Return
            End If
            
            For i As Integer = 1 To cboDepartment.Items.Count - 1
                If TypeOf cboDepartment.Items(i) Is DepartmentItem Then
                    Dim deptItem As DepartmentItem = CType(cboDepartment.Items(i), DepartmentItem)
                    If deptItem.DepartmentId = departmentId Then
                        cboDepartment.SelectedIndex = i
                        Return
                    End If
                End If
            Next
            
            ' If not found, select first item safely
            If cboDepartment.Items.Count > 0 Then
                cboDepartment.SelectedIndex = 0
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("SelectDepartmentById Error: " & ex.Message)
            ' Fail silently - not critical
        End Try
    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs)
        ' Auto-fill unit of measure based on existing property with the same item name
        Try
            Dim itemName As String = txtItemName.Text.Trim()
            
            ' Only search if item name is not empty and has at least 3 characters
            If String.IsNullOrWhiteSpace(itemName) OrElse itemName.Length < 3 Then
                Return
            End If
            
            ' Query database for existing property with this item name
            Dim conn As MySqlConnection = Nothing
            Try
                conn = modDB.GetConnection()
                If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
                    ' Search for property with matching item name (case-insensitive)
                    Dim query As String = "SELECT unitOfMeasure FROM properties WHERE LOWER(itemName) = LOWER(@itemName) AND unitOfMeasure IS NOT NULL LIMIT 1"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@itemName", itemName)
                        Dim result = cmd.ExecuteScalar()
                        
                        If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                            Dim unitOfMeasure As String = result.ToString()
                            If Not String.IsNullOrWhiteSpace(unitOfMeasure) Then
                                ' Auto-fill the unit combobox
                                cboUnit.Text = unitOfMeasure
                            End If
                        End If
                    End Using
                End If
            Finally
                If conn IsNot Nothing Then
                    Try
                        If conn.State = ConnectionState.Open Then conn.Close()
                        conn.Dispose()
                    Catch
                    End Try
                End If
            End Try
            
        Catch ex As Exception
            ' Fail silently - this is just a convenience feature
            System.Diagnostics.Debug.WriteLine("txtItemName_TextChanged Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Validate required fields
        If String.IsNullOrWhiteSpace(txtRequesterName.Text) Then
            MessageBox.Show("Requester name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRequesterName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtItemName.Text) Then
            MessageBox.Show("Item name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtItemName.Focus()
            Return
        End If

        If numQuantity.Value <= 0 Then
            MessageBox.Show("Quantity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numQuantity.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPurpose.Text) Then
            MessageBox.Show("Purpose is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPurpose.Focus()
            Return
        End If

        ' Get department ID
        Dim departmentId As Integer? = Nothing
        If cboDepartment.SelectedIndex > 0 AndAlso TypeOf cboDepartment.SelectedItem Is DepartmentItem Then
            Dim selectedDept As DepartmentItem = CType(cboDepartment.SelectedItem, DepartmentItem)
            departmentId = selectedDept.DepartmentId
        End If

        Try
            ' Prepare data
            Dim requesterName As String = txtRequesterName.Text.Trim()
            Dim position As String = If(String.IsNullOrWhiteSpace(txtPosition.Text), Nothing, txtPosition.Text.Trim())
            Dim dateOfRequest As Date = dtpDateOfRequest.Value.Date
            Dim itemName As String = txtItemName.Text.Trim()
            Dim description As String = If(String.IsNullOrWhiteSpace(txtDescription.Text), Nothing, txtDescription.Text.Trim())
            Dim quantityRequested As Integer = CInt(numQuantity.Value)
            Dim unit As String = If(String.IsNullOrWhiteSpace(cboUnit.Text), Nothing, cboUnit.Text.Trim())
            Dim purpose As String = txtPurpose.Text.Trim()

            ' Submit request
            ' Function signature: SubmitPropertyRequest(userID, itemName, purpose, quantity, departmentID, position, requesterName, description, unit)
            Dim success As Boolean = modDB.SubmitPropertyRequest(
                currentUserId,
                itemName,
                purpose,
                quantityRequested,
                departmentId,
                position,
                requesterName,
                description,
                unit
            )

            If success Then
                MessageBox.Show("Property request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearForm()
                NavigateBackToList()
            Else
                MessageBox.Show("Failed to submit property request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error submitting request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel? All unsaved changes will be lost.", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            NavigateBackToList()
        End If
    End Sub

    Private Sub ClearForm()
        txtItemName.Clear()
        txtDescription.Clear()
        numQuantity.Value = 1
        cboUnit.SelectedIndex = -1
        txtPurpose.Clear()
        txtItemName.Focus()
    End Sub

    Private Sub NavigateBackToList()
        ' Navigate back to Property Request Management
        Dim parentForm = Me.FindForm()
        If TypeOf parentForm Is SADashboard Then
            Dim dashboard = CType(parentForm, SADashboard)
            dashboard.LoadUserControl(New UC_PropertyRequestManagement())
        ElseIf TypeOf parentForm Is AdminDashboard Then
            Dim dashboard = CType(parentForm, AdminDashboard)
            dashboard.LoadUserControl(New UC_PropertyRequestManagement())
        ElseIf TypeOf parentForm Is StaffDashboard Then
            Dim dashboard = CType(parentForm, StaffDashboard)
            ' Staff dashboard might have a different control - adjust as needed
            ' For now, close this form
            Me.Dispose()
        End If
    End Sub

    ' Helper class to store department information
    Private Class DepartmentItem
        Public Property DepartmentId As Integer
        Public Property DepartmentName As String

        Public Overrides Function ToString() As String
            Return DepartmentName
        End Function
    End Class
End Class
