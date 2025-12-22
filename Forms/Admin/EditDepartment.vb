Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Public Class EditDepartment
    Inherits UserControl

    Private _departmentId As Integer = 0

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

            Dim usersTable As DataTable = DatabaseConnection.GetActiveUsersForAssignment(Nothing)
            If cbHead IsNot Nothing Then
                If usersTable IsNot Nothing AndAlso usersTable.Rows.Count > 0 Then
                    cbHead.DataSource = usersTable
                    cbHead.DisplayMember = "fullName"
                    cbHead.ValueMember = "userId"
                    cbHead.SelectedIndex = -1
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
        _departmentId = departmentId

        Try
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

            ' Short Name (office_hours_cmbo is actually used for short name based on designer)
            Dim shortNameCombo As ComboBox = FindControlOfType(Of ComboBox)("office_hours_cmbo")
            If shortNameCombo IsNot Nothing AndAlso deptData.Table.Columns.Contains("shortName") Then
                Dim shortNameVal As String = If(IsDBNull(deptData("shortName")), "", deptData("shortName").ToString())
                ' Try to find and select the value, otherwise add it
                Dim idx As Integer = shortNameCombo.FindStringExact(shortNameVal)
                If idx >= 0 Then
                    shortNameCombo.SelectedIndex = idx
                Else
                    shortNameCombo.Text = shortNameVal
                End If
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
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            saDashboard.LoadUserControl(New UC_DepartmentManagement())
            Return
        End If
        
        Dim superAdminDashboard = TryCast(Me.ParentForm, SuperAdminDashboard)
        If superAdminDashboard IsNot Nothing Then
            superAdminDashboard.LoadUserControl(New UC_DepartmentManagement())
            Return
        End If
        
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_DepartmentManagement())
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate department ID
        If _departmentId <= 0 Then
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

            ' Get short name value
            Dim shortNameCombo As ComboBox = FindControlOfType(Of ComboBox)("office_hours_cmbo")
            Dim shortNameValue As String = If(shortNameCombo IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(shortNameCombo.Text), shortNameCombo.Text.Trim(), "")
            
            ' Get status value
            Dim deptStatusValue As String = "Active"
            If statusCombo IsNot Nothing AndAlso statusCombo.SelectedIndex >= 0 Then
                deptStatusValue = statusCombo.SelectedItem.ToString()
            End If
            
            ' Call the UpdateDepartment function with standard parameters only
            Dim success As Boolean = DatabaseConnection.UpdateDepartment(
                _departmentId,
                deptName,
                headOfDeptString,
                locationStr,
                officeCodeValue,
                contactValue,
                emailValue
            )

            If success Then
                MessageBox.Show("Department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Return to department management and refresh
                ' Check SADashboard first (parent class)
                Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
                If saDashboard IsNot Nothing Then
                    Dim deptManagement As New UC_DepartmentManagement()
                    saDashboard.LoadUserControl(deptManagement)
                    Return
                End If
                
                Dim superAdminDashboard = TryCast(Me.ParentForm, SuperAdminDashboard)
                If superAdminDashboard IsNot Nothing Then
                    Dim deptManagement As New UC_DepartmentManagement()
                    superAdminDashboard.LoadUserControl(deptManagement)
                    Return
                End If
                
                Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
                If parentDashboard IsNot Nothing Then
                    Dim deptManagement As New UC_DepartmentManagement()
                    parentDashboard.LoadUserControl(deptManagement)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Update Department Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub EditDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
