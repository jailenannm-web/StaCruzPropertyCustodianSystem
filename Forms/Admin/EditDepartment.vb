Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Public Class EditDepartment
    Inherits UserControl

    Private currentDepartmentId As Integer = 0

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        InitializeForm()
    End Sub

    ' Helper to find a control by name and cast to expected type
    Private Function FindControlOfType(Of T As Control)(name As String) As T
        Dim matches = Me.Controls.Find(name, True)
        If matches Is Nothing OrElse matches.Length = 0 Then
            Return Nothing
        End If
        Return TryCast(matches(0), T)
    End Function

    Private Sub InitializeForm()
        ' Initialize status dropdown
        Dim statusCombo As ComboBox = FindControlOfType(Of ComboBox)("status_cmbo")
        If statusCombo IsNot Nothing Then
            statusCombo.Items.Clear()
            statusCombo.Items.Add("Active")
            statusCombo.Items.Add("Inactive")
            statusCombo.SelectedIndex = 0
        End If

        ' Initialize office hours dropdown with common options
        Dim officeHoursCombo As ComboBox = FindControlOfType(Of ComboBox)("office_hours_cmbo")
        If officeHoursCombo IsNot Nothing Then
            officeHoursCombo.Items.Clear()
            officeHoursCombo.Items.Add("8:00 AM - 5:00 PM")
            officeHoursCombo.Items.Add("7:00 AM - 4:00 PM")
            officeHoursCombo.Items.Add("7:30 AM - 5:30 PM")
            officeHoursCombo.Items.Add("9:00 AM - 6:00 PM")
            officeHoursCombo.Items.Add("24/7")
            officeHoursCombo.Items.Add("7:00 AM - 7:00 PM")
            officeHoursCombo.Items.Add("8:00 AM - 6:00 PM")
            officeHoursCombo.SelectedIndex = 0
        End If

        ' Set default established date to today
        Dim estDate As DateTimePicker = FindControlOfType(Of DateTimePicker)("established_date_date")
        If estDate IsNot Nothing Then
            estDate.Value = System.DateTime.Now
        End If

        ' Load Department Head dropdown from users table
        LoadDepartmentHeadDropdown()
    End Sub

    Private Sub LoadDepartmentHeadDropdown()
        Try
            Dim cbHead As ComboBox = FindControlOfType(Of ComboBox)("departmentHead")

            Dim usersTable As DataTable = modDB.GetActiveUsersForAssignment(Nothing)
            If cbHead IsNot Nothing Then
                If usersTable IsNot Nothing AndAlso usersTable.Rows.Count > 0 Then
                    cbHead.DataSource = usersTable
                    cbHead.DisplayMember = "fullName"
                    cbHead.ValueMember = "userId"
                    cbHead.SelectedIndex = -1
                    
                    ' Wire up event handler for auto-fill
                    AddHandler cbHead.SelectedIndexChanged, AddressOf DepartmentHead_SelectedIndexChanged
                Else
                    cbHead.DataSource = Nothing
                    cbHead.Items.Clear()
                    cbHead.Items.Add("No users available")
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadDepartmentHeadDropdown Exception: " & ex.Message)
            Dim cbHead As ComboBox = FindControlOfType(Of ComboBox)("departmentHead")
            If cbHead IsNot Nothing Then
                cbHead.DataSource = Nothing
                cbHead.Items.Clear()
                cbHead.Items.Add("Error loading users")
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Load department data into the form for editing
    ''' </summary>
    Public Sub LoadDepartmentData(departmentId As Integer, deptData As DataRow)
        currentDepartmentId = departmentId

        Try
            ' Department ID (display only, should be read-only)
            Dim deptIdTxt As TextBox = FindControlOfType(Of TextBox)("departmentId")
            If deptIdTxt IsNot Nothing Then
                deptIdTxt.Text = departmentId.ToString()
                deptIdTxt.ReadOnly = True  ' Make it read-only so users can't change it
            End If

            ' Department Name
            Dim deptNameTxt As TextBox = FindControlOfType(Of TextBox)("departmentName")
            If deptNameTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("departmentName") Then
                deptNameTxt.Text = If(IsDBNull(deptData("departmentName")), "", deptData("departmentName").ToString())
            End If

            ' Email
            Dim emailTxt As TextBox = FindControlOfType(Of TextBox)("email")
            If emailTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("email") Then
                emailTxt.Text = If(IsDBNull(deptData("email")), "", deptData("email").ToString())
            End If

            ' Contact Number
            Dim contactTxt As TextBox = FindControlOfType(Of TextBox)("contactNumber")
            If contactTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("contactNumber") Then
                contactTxt.Text = If(IsDBNull(deptData("contactNumber")), "", deptData("contactNumber").ToString())
            End If

            ' Location
            Dim locationTxt As TextBox = FindControlOfType(Of TextBox)("location")
            If locationTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("location") Then
                locationTxt.Text = If(IsDBNull(deptData("location")), "", deptData("location").ToString())
            End If

            ' Building
            Dim buildingTxt As TextBox = FindControlOfType(Of TextBox)("building")
            If buildingTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("building") Then
                buildingTxt.Text = If(IsDBNull(deptData("building")), "", deptData("building").ToString())
            End If

            ' Floor Number
            Dim floorTxt As TextBox = FindControlOfType(Of TextBox)("floorNumber")
            If floorTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("floorNumber") Then
                floorTxt.Text = If(IsDBNull(deptData("floorNumber")), "", deptData("floorNumber").ToString())
            End If

            ' Office Code
            Dim officeCodeTxt As TextBox = FindControlOfType(Of TextBox)("officeCode")
            If officeCodeTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("officeCode") Then
                officeCodeTxt.Text = If(IsDBNull(deptData("officeCode")), "", deptData("officeCode").ToString())
            End If

            ' Short Name (use the actual shortName TextBox from designer)
            Dim shortNameTxt As TextBox = FindControlOfType(Of TextBox)("shortName")
            If shortNameTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("shortName") Then
                shortNameTxt.Text = If(IsDBNull(deptData("shortName")), "", deptData("shortName").ToString())
            End If
            
            ' Description
            Dim descriptionTxt As TextBox = FindControlOfType(Of TextBox)("description")
            If descriptionTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("description") Then
                descriptionTxt.Text = If(IsDBNull(deptData("description")), "", deptData("description").ToString())
            End If

            ' Established Date
            Dim estDatePicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("established_date_date")
            If estDatePicker IsNot Nothing AndAlso deptData.Table.Columns.Contains("establishedDate") Then
                If Not IsDBNull(deptData("establishedDate")) Then
                    Try
                        estDatePicker.Value = Convert.ToDateTime(deptData("establishedDate"))
                    Catch
                        estDatePicker.Value = DateTime.Now
                    End Try
                End If
            End If

            ' Status
            Dim statusCombo As ComboBox = FindControlOfType(Of ComboBox)("status_cmbo")
            If statusCombo IsNot Nothing AndAlso deptData.Table.Columns.Contains("status") Then
                Dim statusVal As String = If(IsDBNull(deptData("status")), "Active", deptData("status").ToString())
                Dim statusIdx As Integer = statusCombo.FindStringExact(statusVal)
                If statusIdx >= 0 Then
                    statusCombo.SelectedIndex = statusIdx
                Else
                    statusCombo.SelectedIndex = 0
                End If
            End If

            ' Department Head - select in ComboBox
            Dim cbHead As ComboBox = FindControlOfType(Of ComboBox)("departmentHead")
            If cbHead IsNot Nothing AndAlso deptData.Table.Columns.Contains("headOfDepartment") Then
                Dim headVal As String = If(IsDBNull(deptData("headOfDepartment")), "", deptData("headOfDepartment").ToString())
                If Not String.IsNullOrEmpty(headVal) Then
                    ' Try to find by display name
                    Dim found As Boolean = False
                    If cbHead.DataSource IsNot Nothing AndAlso TypeOf cbHead.DataSource Is DataTable Then
                        Dim dt As DataTable = CType(cbHead.DataSource, DataTable)
                        For i As Integer = 0 To dt.Rows.Count - 1
                            Dim fullName As String = ""
                            If dt.Columns.Contains("fullName") AndAlso Not IsDBNull(dt.Rows(i)("fullName")) Then
                                fullName = dt.Rows(i)("fullName").ToString()
                            End If
                            If String.Equals(fullName, headVal, StringComparison.OrdinalIgnoreCase) Then
                                cbHead.SelectedIndex = i
                                found = True
                                Exit For
                            End If
                        Next
                    End If
                    If Not found Then
                        cbHead.Text = headVal
                    End If
                End If
            End If

            ' Update label to indicate editing
            Dim titleLabel As Label = FindControlOfType(Of Label)("admin_label_DepartmentManagement")
            If titleLabel IsNot Nothing Then
                titleLabel.Text = "Edit Department"
            End If

            ' Update instructions
            Dim instructionsLabel As Label = FindControlOfType(Of Label)("instructions")
            If instructionsLabel IsNot Nothing Then
                instructionsLabel.Text = "Update the department information below."
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading department data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] LoadDepartmentData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Check SADashboard first (parent class)
        Dim superAdmin = TryCast(Me.ParentForm, SADashboard)
        If superAdmin IsNot Nothing Then
            superAdmin.LoadUserControl(New UC_DepartmentManagement())
            Return
        End If
        
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_DepartmentManagement())
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate department ID
        If currentDepartmentId <= 0 Then
            MessageBox.Show("Invalid department ID. Cannot update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validate required fields
        Dim deptNameTxt As TextBox = FindControlOfType(Of TextBox)("departmentName")
        If deptNameTxt Is Nothing OrElse String.IsNullOrWhiteSpace(deptNameTxt.Text) Then
            MessageBox.Show("Department Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If deptNameTxt IsNot Nothing Then deptNameTxt.Focus()
            Return
        End If

        ' Get Department Head value
        Dim headOfDeptString As String = ""
        Dim cbHead As ComboBox = FindControlOfType(Of ComboBox)("departmentHead")

        If cbHead IsNot Nothing Then
            If cbHead.SelectedItem IsNot Nothing Then
                If TypeOf cbHead.SelectedItem Is DataRowView Then
                    Dim drv As DataRowView = CType(cbHead.SelectedItem, DataRowView)
                    If drv.Row.Table.Columns.Contains("fullName") AndAlso Not IsDBNull(drv.Row("fullName")) Then
                        headOfDeptString = drv.Row("fullName").ToString()
                    ElseIf drv.Row.Table.Columns.Contains("userId") AndAlso Not IsDBNull(drv.Row("userId")) Then
                        headOfDeptString = drv.Row("userId").ToString()
                    End If
                Else
                    headOfDeptString = cbHead.Text
                End If
            Else
                headOfDeptString = cbHead.Text
            End If
        End If

        If String.IsNullOrWhiteSpace(headOfDeptString) Then
            MessageBox.Show("Please select or enter a Department Head.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If cbHead IsNot Nothing Then cbHead.Focus()
            Return
        End If

        ' Validate location
        Dim locationTxt As TextBox = FindControlOfType(Of TextBox)("location")
        If locationTxt Is Nothing OrElse String.IsNullOrWhiteSpace(locationTxt.Text) Then
            MessageBox.Show("Location is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If locationTxt IsNot Nothing Then locationTxt.Focus()
            Return
        End If

        ' Get status
        Dim statusCombo As ComboBox = FindControlOfType(Of ComboBox)("status_cmbo")
        Dim statusValue As String = "Active"
        If statusCombo IsNot Nothing AndAlso statusCombo.SelectedIndex >= 0 Then
            statusValue = statusCombo.SelectedItem.ToString()
        End If

        Try
            ' Prepare parameters
            Dim deptName As String = deptNameTxt.Text.Trim()
            Dim locationStr As String = locationTxt.Text.Trim()
            Dim officeCodeTxt As TextBox = FindControlOfType(Of TextBox)("officeCode")
            Dim contactTxt As TextBox = FindControlOfType(Of TextBox)("contactNumber")
            Dim emailTxt As TextBox = FindControlOfType(Of TextBox)("email")
            Dim buildingTxt As TextBox = FindControlOfType(Of TextBox)("building")
            Dim floorTxt As TextBox = FindControlOfType(Of TextBox)("floorNumber")

            Dim officeCodeValue As String = If(officeCodeTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(officeCodeTxt.Text), officeCodeTxt.Text.Trim(), "")
            Dim contactValue As String = If(contactTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(contactTxt.Text), contactTxt.Text.Trim(), "")
            Dim emailValue As String = If(emailTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(emailTxt.Text), emailTxt.Text.Trim(), "")
            Dim buildingValue As String = If(buildingTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(buildingTxt.Text), buildingTxt.Text.Trim(), "")
            Dim floorValue As String = If(floorTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(floorTxt.Text), floorTxt.Text.Trim(), "")

            ' Get established date
            Dim estPicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("established_date_date")
            Dim establishedDate As Date? = Nothing
            If estPicker IsNot Nothing Then
                establishedDate = estPicker.Value.Date
            End If

            ' Get short name value (use the actual shortName TextBox from designer)
            Dim shortNameTxt As TextBox = FindControlOfType(Of TextBox)("shortName")
            Dim shortNameValue As String = If(shortNameTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(shortNameTxt.Text), shortNameTxt.Text.Trim(), "")
            
            ' Get description value
            Dim descriptionTxt As TextBox = FindControlOfType(Of TextBox)("description")
            Dim descriptionValue As String = If(descriptionTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(descriptionTxt.Text), descriptionTxt.Text.Trim(), "")
            
            ' Get status value
            Dim deptStatusValue As String = "Active"
            If statusCombo IsNot Nothing AndAlso statusCombo.SelectedIndex >= 0 Then
                deptStatusValue = statusCombo.SelectedItem.ToString()
            End If
            
            ' Call the UpdateDepartment function with all parameters including floorNumber, shortName, description, status
            Dim success As Boolean = modDB.UpdateDepartment(
                currentDepartmentId,
                deptName,
                headOfDeptString,
                locationStr,
                officeCodeValue,
                contactValue,
                emailValue,
                buildingValue,
                floorValue,
                shortNameValue,
                descriptionValue,  ' description from form
                deptStatusValue    ' status from form
            )

            If success Then
                MessageBox.Show("Department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Return to department management and refresh
                ' Check SADashboard first (parent class)
                Dim superAdmin = TryCast(Me.ParentForm, SADashboard)
                If superAdmin IsNot Nothing Then
                    Dim deptManagement As New UC_DepartmentManagement()
                    superAdmin.LoadUserControl(deptManagement)
                    ' Refresh the table after loading
                    deptManagement.LoadDepartmentsData()
                    Return
                End If
                
                Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
                If parentDashboard IsNot Nothing Then
                    Dim deptManagement As New UC_DepartmentManagement()
                    parentDashboard.LoadUserControl(deptManagement)
                    ' Refresh the table after loading
                    deptManagement.LoadDepartmentsData()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Update Department Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub EditDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub description_TextChanged(sender As Object, e As EventArgs) Handles description.TextChanged

    End Sub

    ''' <summary>
    ''' Auto-fill email and contact number when department head is selected
    ''' </summary>
    Private Sub DepartmentHead_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim cbHead As ComboBox = TryCast(sender, ComboBox)
            If cbHead Is Nothing OrElse cbHead.SelectedIndex < 0 Then Return
            
            ' Get the selected user's data
            If TypeOf cbHead.SelectedItem Is DataRowView Then
                Dim drv As DataRowView = CType(cbHead.SelectedItem, DataRowView)
                
                ' Auto-fill email if available
                If drv.Row.Table.Columns.Contains("email") AndAlso Not IsDBNull(drv.Row("email")) Then
                    Dim emailTxt As TextBox = FindControlOfType(Of TextBox)("email")
                    If emailTxt IsNot Nothing Then
                        emailTxt.Text = drv.Row("email").ToString()
                    End If
                End If
                
                ' Auto-fill contact number if available
                If drv.Row.Table.Columns.Contains("contactNumber") AndAlso Not IsDBNull(drv.Row("contactNumber")) Then
                    Dim contactTxt As TextBox = FindControlOfType(Of TextBox)("contactNumber")
                    If contactTxt IsNot Nothing Then
                        contactTxt.Text = drv.Row("contactNumber").ToString()
                    End If
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] DepartmentHead_SelectedIndexChanged Exception: " & ex.Message)
        End Try
    End Sub
End Class
