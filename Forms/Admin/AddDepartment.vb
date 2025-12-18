Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Public Class AddDepartment
    Inherits UserControl

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

        ' Load Department Head dropdown from users table (only if control is a ComboBox)
        LoadDepartmentHeadDropdown()

        ' Set default values - these fields don't exist in the current schema
        ' no_of_employees_numeric and budget_allocation_txt removed from schema
    End Sub

    Private Sub LoadDepartmentHeadDropdown()
        Try
            Dim cbHead As ComboBox = FindControlOfType(Of ComboBox)("departmentHead")
            Dim tbHead As TextBox = FindControlOfType(Of TextBox)("departmentHead")

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
            ElseIf tbHead IsNot Nothing Then
                ' If designer has a TextBox instead of ComboBox, populate its Text with placeholder
                If usersTable IsNot Nothing AndAlso usersTable.Rows.Count > 0 Then
                    tbHead.Text = "" ' leave blank for user to type or paste a name
                Else
                    tbHead.Text = "No users available"
                End If
            Else
                ' control not found - nothing to do
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadDepartmentHeadDropdown Exception: " & ex.Message)
            Dim cbHead As ComboBox = FindControlOfType(Of ComboBox)("departmentHead")
            Dim tbHead As TextBox = FindControlOfType(Of TextBox)("departmentHead")
            If cbHead IsNot Nothing Then
                cbHead.DataSource = Nothing
                cbHead.Items.Clear()
                cbHead.Items.Add("Error loading users")
            ElseIf tbHead IsNot Nothing Then
                tbHead.Text = "Error loading users"
            End If
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_DepartmentManagement())
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate required fields
        Dim deptNameTxt As TextBox = FindControlOfType(Of TextBox)("departmentName")
        If deptNameTxt Is Nothing OrElse String.IsNullOrWhiteSpace(deptNameTxt.Text) Then
            MessageBox.Show("Department Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If deptNameTxt IsNot Nothing Then deptNameTxt.Focus()
            Return
        End If

        ' Get Department Head value (accept ComboBox selection or TextBox text)
        Dim headOfDeptString As String = ""
        Dim cbHead As ComboBox = FindControlOfType(Of ComboBox)("departmentHead")
        Dim tbHead As TextBox = FindControlOfType(Of TextBox)("departmentHead")

        If cbHead IsNot Nothing Then
            ' Prefer display name if available
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
        ElseIf tbHead IsNot Nothing Then
            headOfDeptString = tbHead.Text.Trim()
        End If

        If String.IsNullOrWhiteSpace(headOfDeptString) Then
            MessageBox.Show("Please select or enter a Department Head.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If cbHead IsNot Nothing Then cbHead.Focus() Else
            If tbHead IsNot Nothing Then tbHead.Focus()
            Return
        End If

        ' Validate location
        Dim locationTxt As TextBox = FindControlOfType(Of TextBox)("location")
        If locationTxt Is Nothing OrElse String.IsNullOrWhiteSpace(locationTxt.Text) Then
            MessageBox.Show("Location is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If locationTxt IsNot Nothing Then locationTxt.Focus()
            Return
        End If

        ' Get office hours
        Dim officeHoursCombo As ComboBox = FindControlOfType(Of ComboBox)("office_hours_cmbo")
        Dim officeHours As String = ""
        If officeHoursCombo IsNot Nothing AndAlso officeHoursCombo.SelectedIndex >= 0 Then
            officeHours = officeHoursCombo.SelectedItem.ToString()
        End If

        ' Get status
        Dim statusCombo As ComboBox = FindControlOfType(Of ComboBox)("status_cmbo")
        Dim statusValue As String = "active"
        If statusCombo IsNot Nothing AndAlso statusCombo.SelectedIndex >= 0 Then
            statusValue = statusCombo.SelectedItem.ToString()
        End If

        ' Get established date (nullable)
        Dim estPicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("established_date_date")
        Dim establishedDate As Date? = Nothing
        If estPicker IsNot Nothing Then
            establishedDate = estPicker.Value.Date
        End If

        Try
            ' Prepare parameters
            Dim deptName As String = deptNameTxt.Text.Trim()
            Dim locationStr As String = locationTxt.Text.Trim()
            Dim officeCodeTxt As TextBox = FindControlOfType(Of TextBox)("officeCode")
            Dim contactTxt As TextBox = FindControlOfType(Of TextBox)("contactNumber")
            Dim emailTxt As TextBox = FindControlOfType(Of TextBox)("email")

            Dim officeCodeValue As String = If(officeCodeTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(officeCodeTxt.Text), officeCodeTxt.Text.Trim(), "")
            Dim contactValue As String = If(contactTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(contactTxt.Text), contactTxt.Text.Trim(), "")
            Dim emailValue As String = If(emailTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(emailTxt.Text), emailTxt.Text.Trim(), "")

            ' Call the enhanced AddDepartment function with all fields matching schema
            Dim success As Boolean = DatabaseConnection.AddDepartment(
                deptName,
                headOfDeptString,                                   ' headOfDepartment (string)
                locationStr,
                officeCodeValue,
                contactValue,
                emailValue,
                0,                                                  ' noOfEmployees - will be calculated
                0,                                                  ' budgetAllocation - optional
                officeHours,                                        ' officeHours
                establishedDate,                                    ' establishedDate
                Nothing,                                            ' parentDepartmentId - optional
                If(statusCombo IsNot Nothing AndAlso statusCombo.SelectedIndex >= 0, statusCombo.SelectedItem.ToString(), "Active")
            )

            If success Then
                ' Clear form
                ClearForm()

                ' Return to department management and refresh
                Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
                If parentDashboard IsNot Nothing Then
                    Dim deptManagement As New UC_DepartmentManagement()
                    parentDashboard.LoadUserControl(deptManagement)
                    ' Refresh the data - call method if it exists
                    Try
                        deptManagement.LoadDepartmentsData()
                    Catch
                        ' Ignore if method not available
                    End Try
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error adding department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Add Department Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub ClearForm()
        Dim deptNameTxt As TextBox = FindControlOfType(Of TextBox)("departmentName")
        If deptNameTxt IsNot Nothing Then deptNameTxt.Clear()

        Dim cbHead As ComboBox = FindControlOfType(Of ComboBox)("departmentHead")
        Dim tbHead As TextBox = FindControlOfType(Of TextBox)("departmentHead")
        If cbHead IsNot Nothing Then
            cbHead.DataSource = Nothing
            cbHead.Items.Clear()
            cbHead.SelectedIndex = -1
        ElseIf tbHead IsNot Nothing Then
            tbHead.Clear()
        End If

        Dim contactTxt As TextBox = FindControlOfType(Of TextBox)("contactNumber")
        If contactTxt IsNot Nothing Then contactTxt.Clear()
        Dim emailTxt As TextBox = FindControlOfType(Of TextBox)("email")
        If emailTxt IsNot Nothing Then emailTxt.Clear()
        Dim locationTxt As TextBox = FindControlOfType(Of TextBox)("location")
        If locationTxt IsNot Nothing Then locationTxt.Clear()
        Dim officeCodeTxt As TextBox = FindControlOfType(Of TextBox)("officeCode")
        If officeCodeTxt IsNot Nothing Then officeCodeTxt.Clear()

        Dim officeHoursCombo As ComboBox = FindControlOfType(Of ComboBox)("office_hours_cmbo")
        If officeHoursCombo IsNot Nothing AndAlso officeHoursCombo.Items.Count > 0 Then officeHoursCombo.SelectedIndex = 0

        Dim estPicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("established_date_date")
        If estPicker IsNot Nothing Then estPicker.Value = System.DateTime.Now

        Dim statusCombo As ComboBox = FindControlOfType(Of ComboBox)("status_cmbo")
        If statusCombo IsNot Nothing AndAlso statusCombo.Items.Count > 0 Then statusCombo.SelectedIndex = 0
    End Sub

    Private Sub AddDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
