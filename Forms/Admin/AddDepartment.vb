Imports System
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
        established_date_date.Value = System.DateTime.Now

        ' Set default values - these fields don't exist in the current schema
        ' no_of_employees_numeric and budget_allocation_txt removed from schema
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_DepartmentManagement())
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate required fields
        If String.IsNullOrWhiteSpace(departmentName.Text) Then
            MessageBox.Show("Department Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            departmentName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(headOfDepartment.Text) Then
            MessageBox.Show("Head of Department is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            headOfDepartment.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(location.Text) Then
            MessageBox.Show("Location is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            location.Focus()
            Return
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

        ' Get established date (make it nullable to match function signature)
        Dim establishedDate As Date? = established_date_date.Value.Date

        Try
            ' Call the enhanced AddDepartment function with all fields matching schema
            Dim success As Boolean = DatabaseConnection.AddDepartment(
                departmentName.Text.Trim(),
                headOfDepartment.Text.Trim(),
                location.Text.Trim(),
                If(String.IsNullOrWhiteSpace(officeCode.Text), "", officeCode.Text.Trim()),
                If(String.IsNullOrWhiteSpace(contactNumber.Text), "", contactNumber.Text.Trim()),
                If(String.IsNullOrWhiteSpace(email.Text), "", email.Text.Trim()),
                0, ' no_of_employees - not in schema
                0, ' budget_allocation - not in schema  
                "", ' office_hours - not in schema
                Nothing, ' established_date - not in schema
                Nothing, ' parent_department_id - not in schema
                If(status_cmbo.SelectedIndex >= 0, status_cmbo.SelectedItem.ToString(), "Active")
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
            System.Diagnostics.Debug.WriteLine("[v0] Add Department Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub ClearForm()
        departmentName.Clear()
        headOfDepartment.Clear()
        contactNumber.Clear()
        email.Clear()
        location.Clear()
        officeCode.Clear()
        office_hours_cmbo.SelectedIndex = 0
        established_date_date.Value = System.DateTime.Now
        status_cmbo.SelectedIndex = 0
    End Sub

End Class
