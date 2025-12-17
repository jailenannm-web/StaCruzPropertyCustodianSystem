Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Public Class EditDepartment
    Inherits UserControl

    Private departmentID As Integer = 0
    Private originalDepartmentData As DataRow = Nothing

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
        End If

        ' Load Department Head dropdown from users table
        LoadDepartmentHeadDropdown()
    End Sub

    Private Sub LoadDepartmentHeadDropdown()
        Try
            Dim cbHead As ComboBox = FindControlOfType(Of ComboBox)("headOfDepartment")
            Dim tbHead As TextBox = FindControlOfType(Of TextBox)("headOfDepartment")

            Dim usersTable As DataTable = DatabaseConnection.GetActiveUsersForAssignment(Nothing)
            If cbHead IsNot Nothing Then
                If usersTable IsNot Nothing AndAlso usersTable.Rows.Count > 0 Then
                    cbHead.DataSource = usersTable
                    cbHead.DisplayMember = "fullName"
                    cbHead.ValueMember = "userId"
                Else
                    cbHead.DataSource = Nothing
                    cbHead.Items.Clear()
                    cbHead.Items.Add("No users available")
                End If
            ElseIf tbHead IsNot Nothing Then
                If usersTable IsNot Nothing AndAlso usersTable.Rows.Count > 0 Then
                    tbHead.Text = ""
                Else
                    tbHead.Text = "No users available"
                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadDepartmentHeadDropdown Exception: " & ex.Message)
        End Try
    End Sub

    Public Sub LoadDepartmentData(deptID As Integer, deptData As DataRow)
        Try
            departmentID = deptID
            originalDepartmentData = deptData

            ' Load department name
            Dim deptNameTxt As TextBox = FindControlOfType(Of TextBox)("departmentName")
            If deptNameTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("departmentName") AndAlso Not IsDBNull(deptData("departmentName")) Then
                deptNameTxt.Text = deptData("departmentName").ToString()
            End If

            ' Load department head
            Dim cbHead As ComboBox = FindControlOfType(Of ComboBox)("headOfDepartment")
            Dim tbHead As TextBox = FindControlOfType(Of TextBox)("headOfDepartment")
            If cbHead IsNot Nothing Then
                If deptData.Table.Columns.Contains("headOfDepartment") AndAlso Not IsDBNull(deptData("headOfDepartment")) Then
                    Dim headName As String = deptData("headOfDepartment").ToString()
                    ' Try to find matching user in dropdown
                    For i As Integer = 0 To cbHead.Items.Count - 1
                        If TypeOf cbHead.Items(i) Is DataRowView Then
                            Dim drv As DataRowView = CType(cbHead.Items(i), DataRowView)
                            If drv.Row.Table.Columns.Contains("fullName") AndAlso drv.Row("fullName").ToString() = headName Then
                                cbHead.SelectedIndex = i
                                Exit For
                            End If
                        End If
                    Next
                    ' If not found, set text
                    If cbHead.SelectedIndex = -1 Then
                        cbHead.Text = headName
                    End If
                End If
            ElseIf tbHead IsNot Nothing Then
                If deptData.Table.Columns.Contains("headOfDepartment") AndAlso Not IsDBNull(deptData("headOfDepartment")) Then
                    tbHead.Text = deptData("headOfDepartment").ToString()
                End If
            End If

            ' Load email
            Dim emailTxt As TextBox = FindControlOfType(Of TextBox)("email")
            If emailTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("email") AndAlso Not IsDBNull(deptData("email")) Then
                emailTxt.Text = deptData("email").ToString()
            End If

            ' Load contact number
            Dim contactTxt As TextBox = FindControlOfType(Of TextBox)("contactNumber")
            If contactTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("contactNumber") AndAlso Not IsDBNull(deptData("contactNumber")) Then
                contactTxt.Text = deptData("contactNumber").ToString()
            End If

            ' Load location
            Dim locationTxt As TextBox = FindControlOfType(Of TextBox)("location")
            If locationTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("location") AndAlso Not IsDBNull(deptData("location")) Then
                locationTxt.Text = deptData("location").ToString()
            End If

            ' Load building
            Dim buildingTxt As TextBox = FindControlOfType(Of TextBox)("building")
            If buildingTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("building") AndAlso Not IsDBNull(deptData("building")) Then
                buildingTxt.Text = deptData("building").ToString()
            End If

            ' Load floor number
            Dim floorTxt As TextBox = FindControlOfType(Of TextBox)("floorNumber")
            If floorTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("floorNumber") AndAlso Not IsDBNull(deptData("floorNumber")) Then
                floorTxt.Text = deptData("floorNumber").ToString()
            End If

            ' Load short name
            Dim shortNameTxt As TextBox = FindControlOfType(Of TextBox)("shortName")
            If shortNameTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("shortName") AndAlso Not IsDBNull(deptData("shortName")) Then
                shortNameTxt.Text = deptData("shortName").ToString()
            End If

            ' Load office code
            Dim officeCodeTxt As TextBox = FindControlOfType(Of TextBox)("officeCode")
            If officeCodeTxt IsNot Nothing AndAlso deptData.Table.Columns.Contains("officeCode") AndAlso Not IsDBNull(deptData("officeCode")) Then
                officeCodeTxt.Text = deptData("officeCode").ToString()
            End If

            ' Load description
            Dim descTxt As TextBox = FindControlOfType(Of TextBox)("description")
            If descTxt Is Nothing Then
                Dim descRich As RichTextBox = FindControlOfType(Of RichTextBox)("description")
                If descRich IsNot Nothing AndAlso deptData.Table.Columns.Contains("description") AndAlso Not IsDBNull(deptData("description")) Then
                    descRich.Text = deptData("description").ToString()
                End If
            Else
                If deptData.Table.Columns.Contains("description") AndAlso Not IsDBNull(deptData("description")) Then
                    descTxt.Text = deptData("description").ToString()
                End If
            End If

            ' Load status
            Dim statusCombo As ComboBox = FindControlOfType(Of ComboBox)("status_cmbo")
            If statusCombo IsNot Nothing AndAlso deptData.Table.Columns.Contains("status") AndAlso Not IsDBNull(deptData("status")) Then
                Dim statusVal As String = deptData("status").ToString()
                For i As Integer = 0 To statusCombo.Items.Count - 1
                    If statusCombo.Items(i).ToString().Equals(statusVal, StringComparison.OrdinalIgnoreCase) Then
                        statusCombo.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading department data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] LoadDepartmentData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
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

        ' Get Department Head value
        Dim headOfDeptString As String = ""
        Dim cbHead As ComboBox = FindControlOfType(Of ComboBox)("headOfDepartment")
        Dim tbHead As TextBox = FindControlOfType(Of TextBox)("headOfDepartment")

        If cbHead IsNot Nothing Then
            If cbHead.SelectedItem IsNot Nothing Then
                If TypeOf cbHead.SelectedItem Is DataRowView Then
                    Dim drv As DataRowView = CType(cbHead.SelectedItem, DataRowView)
                    If drv.Row.Table.Columns.Contains("fullName") AndAlso Not IsDBNull(drv.Row("fullName")) Then
                        headOfDeptString = drv.Row("fullName").ToString()
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
            Dim shortNameTxt As TextBox = FindControlOfType(Of TextBox)("shortName")

            Dim officeCodeValue As String = If(officeCodeTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(officeCodeTxt.Text), officeCodeTxt.Text.Trim(), "")
            Dim contactValue As String = If(contactTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(contactTxt.Text), contactTxt.Text.Trim(), "")
            Dim emailValue As String = If(emailTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(emailTxt.Text), emailTxt.Text.Trim(), "")
            Dim buildingValue As String = If(buildingTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(buildingTxt.Text), buildingTxt.Text.Trim(), "")
            Dim floorValue As String = If(floorTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(floorTxt.Text), floorTxt.Text.Trim(), "")
            Dim shortNameValue As String = If(shortNameTxt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(shortNameTxt.Text), shortNameTxt.Text.Trim(), "")

            Dim descTxt As TextBox = FindControlOfType(Of TextBox)("description")
            Dim descRich As RichTextBox = FindControlOfType(Of RichTextBox)("description")
            Dim descriptionValue As String = ""
            If descTxt IsNot Nothing Then
                descriptionValue = descTxt.Text.Trim()
            ElseIf descRich IsNot Nothing Then
                descriptionValue = descRich.Text.Trim()
            End If

            ' Call UpdateDepartment function - signature: (departmentID, departmentName, headOfDepartment, location, departmentCode, Optional contactNumber, Optional email, Optional noOfEmployees, Optional budgetAllocation)
            Dim success As Boolean = DatabaseConnection.UpdateDepartment(
                departmentID,
                deptName,
                headOfDeptString,
                locationStr,
                officeCodeValue,  ' departmentCode parameter
                contactValue,    ' Optional contactNumber
                emailValue,      ' Optional email
                0,               ' Optional noOfEmployees (will be recalculated)
                0                ' Optional budgetAllocation
            )

            If success Then
                MessageBox.Show("Department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                
                ' Return to department management and refresh
                Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
                If parentDashboard IsNot Nothing Then
                    Dim deptManagement As New UC_DepartmentManagement()
                    parentDashboard.LoadUserControl(deptManagement)
                    ' Refresh the data
                    Try
                        deptManagement.LoadDepartmentsData()
                    Catch
                        ' Ignore if method not available
                    End Try
                End If
            Else
                MessageBox.Show("Failed to update department. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Update Department Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub EditDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

