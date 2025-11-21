Imports System
Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class AddDepartment
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        ' Initialize status dropdown
        status_cmbo.Items.Clear()
        status_cmbo.Items.Add("active")
        status_cmbo.Items.Add("inactive")
        status_cmbo.SelectedIndex = 0

        ' Initialize office hours dropdown with common options
        office_hours_cmbo.Items.Clear()
        office_hours_cmbo.Items.Add("8:00 AM - 5:00 PM")
        office_hours_cmbo.Items.Add("7:00 AM - 4:00 PM")
        office_hours_cmbo.Items.Add("7:30 AM - 5:30 PM")
        office_hours_cmbo.Items.Add("9:00 AM - 6:00 PM")
        office_hours_cmbo.Items.Add("24/7")
        office_hours_cmbo.Items.Add("7:00 AM - 7:00 PM")
        office_hours_cmbo.Items.Add("8:00 AM - 6:00 PM")
        office_hours_cmbo.SelectedIndex = 0

        ' Set default established date to today
        established_date_date.Value = DateTime.Now

        ' Set default number of employees to 0
        no_of_employees_numeric.Value = 0
        no_of_employees_numeric.Minimum = 0
        no_of_employees_numeric.Maximum = 10000

        ' Set default budget allocation to 0
        budget_allocation_txt.Text = "0.00"
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_DepartmentManagement())
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate required fields
        If String.IsNullOrWhiteSpace(department_name_txt.Text) Then
            MessageBox.Show("Department Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            department_name_txt.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(head_of_department_txt.Text) Then
            MessageBox.Show("Head of Department is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            head_of_department_txt.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(location_txt.Text) Then
            MessageBox.Show("Location is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            location_txt.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(department_code_Code.Text) Then
            MessageBox.Show("Department Code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            department_code_Code.Focus()
            Return
        End If

        ' Validate email format if provided
        If Not String.IsNullOrWhiteSpace(email_txt.Text) Then
            Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
            If Not Regex.IsMatch(email_txt.Text.Trim(), emailPattern) Then
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                email_txt.Focus()
                Return
            End If
        End If

        ' Validate numeric fields
        Dim noOfEmployees As Integer = CInt(no_of_employees_numeric.Value)
        Dim budgetAllocation As Decimal = 0
        If Not String.IsNullOrWhiteSpace(budget_allocation_txt.Text) Then
            If Not Decimal.TryParse(budget_allocation_txt.Text.Trim(), budgetAllocation) Then
                MessageBox.Show("Budget Allocation must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                budget_allocation_txt.Focus()
                Return
            End If
            If budgetAllocation < 0 Then
                MessageBox.Show("Budget Allocation cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                budget_allocation_txt.Focus()
                Return
            End If
        End If

        ' Validate parent department ID if provided
        Dim parentDeptID As Integer? = Nothing
        If Not String.IsNullOrWhiteSpace(parent_department_id_txt.Text) Then
            Dim parentID As Integer
            If Integer.TryParse(parent_department_id_txt.Text.Trim(), parentID) Then
                parentDeptID = parentID
            Else
                MessageBox.Show("Parent Department ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                parent_department_id_txt.Focus()
                Return
            End If
        End If

        ' Get office hours
        Dim officeHours As String = ""
        If office_hours_cmbo.SelectedIndex >= 0 Then
            officeHours = office_hours_cmbo.SelectedItem.ToString()
        End If

        ' Get status
        Dim statusValue As String = "active"
        If status_cmbo.SelectedIndex >= 0 Then
            statusValue = status_cmbo.SelectedItem.ToString()
        End If

        ' Get established date
        Dim establishedDate As Date = established_date_date.Value.Date

        Try
            ' Call the enhanced AddDepartment function with all fields
            Dim success As Boolean = DatabaseConnection.AddDepartment(
                department_name_txt.Text.Trim(),
                head_of_department_txt.Text.Trim(),
                location_txt.Text.Trim(),
                department_code_Code.Text.Trim(),
                If(String.IsNullOrWhiteSpace(contact_number_txt.Text), "", contact_number_txt.Text.Trim()),
                If(String.IsNullOrWhiteSpace(email_txt.Text), "", email_txt.Text.Trim()),
                noOfEmployees,
                budgetAllocation,
                officeHours,
                establishedDate,
                parentDeptID,
                statusValue
            )

            If success Then
                ' Clear form
                ClearForm()
                
                ' Return to department management and refresh
                Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
                If parentDashboard IsNot Nothing Then
                    Dim deptManagement As New UC_DepartmentManagement()
                    parentDashboard.LoadUserControl(deptManagement)
                    ' Refresh the data
                    deptManagement.LoadDepartmentsData()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error adding department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Add Department Error: " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub ClearForm()
        department_name_txt.Clear()
        head_of_department_txt.Clear()
        contact_number_txt.Clear()
        email_txt.Clear()
        location_txt.Clear()
        no_of_employees_numeric.Value = 0
        department_code_Code.Clear()
        office_hours_cmbo.SelectedIndex = 0
        established_date_date.Value = DateTime.Now
        parent_department_id_txt.Clear()
        status_cmbo.SelectedIndex = 0
        budget_allocation_txt.Text = "0.00"
    End Sub

End Class
