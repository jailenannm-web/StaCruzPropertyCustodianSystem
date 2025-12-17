Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class MaintenanceRequestForm
    Inherits System.Windows.Forms.UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        InitializeForm()
    End Sub

    ' Helper: find control by name and cast to expected type
    Private Function FindControlOfType(Of T As Control)(name As String) As T
        Dim matches = Me.Controls.Find(name, True)
        If matches Is Nothing OrElse matches.Length = 0 Then Return Nothing
        Return TryCast(matches(0), T)
    End Function

    Private Sub InitializeForm()
        ' Populate condition status combo
        Dim condCombo As ComboBox = FindControlOfType(Of ComboBox)("conditionBefore")
        If condCombo IsNot Nothing Then
            condCombo.Items.Clear()
            condCombo.Items.AddRange(New String() {"Good", "Needs Repair", "Damaged"})
            condCombo.SelectedIndex = 0
        End If

        ' Populate type of issue combo (named 'department' in designer)
        Dim issueTypeCombo As ComboBox = FindControlOfType(Of ComboBox)("department")
        If issueTypeCombo IsNot Nothing Then
            issueTypeCombo.Items.Clear()
            issueTypeCombo.Items.AddRange(New String() {"Repair", "Replace", "Servicing"})
            issueTypeCombo.SelectedIndex = 0
        End If

        ' Load departments into typesOfIssue (ComboBox4 in your description)
        Dim typesCombo As ComboBox = FindControlOfType(Of ComboBox)("typesOfIssue")
        Try
            Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
            If typesCombo IsNot Nothing Then
                typesCombo.Items.Clear()
                typesCombo.Items.Add("Select Department")
                If dt IsNot Nothing Then
                    For Each row As DataRow In dt.Rows
                        If dt.Columns.Contains("departmentName") Then
                            typesCombo.Items.Add(row("departmentName").ToString())
                        ElseIf dt.Columns.Contains("department_name") Then
                            typesCombo.Items.Add(row("department_name").ToString())
                        End If
                    Next
                End If
                typesCombo.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Find relevant controls (designer names may vary - update strings if different)
        Dim propNameTxt As TextBox = FindControlOfType(Of TextBox)("propertyNameTxt")
        Dim probDescTxt As TextBox = FindControlOfType(Of TextBox)("problemDescription")
        Dim deptIssueCombo As ComboBox = FindControlOfType(Of ComboBox)("department")
        Dim typesCombo As ComboBox = FindControlOfType(Of ComboBox)("typesOfIssue")
        Dim condCombo As ComboBox = FindControlOfType(Of ComboBox)("conditionBefore")
        Dim serialTxt As TextBox = FindControlOfType(Of TextBox)("serialNumber")
        Dim locationTxt As TextBox = FindControlOfType(Of TextBox)("user") ' location control named 'user' in original code
        Dim targetPicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("targetDate")

        ' Validate required fields
        If propNameTxt Is Nothing OrElse String.IsNullOrWhiteSpace(propNameTxt.Text) Then
            MessageBox.Show("Please enter the item/property name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If propNameTxt IsNot Nothing Then propNameTxt.Focus()
            Return
        End If

        If probDescTxt Is Nothing OrElse String.IsNullOrWhiteSpace(probDescTxt.Text) Then
            MessageBox.Show("Please enter the problem description.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If probDescTxt IsNot Nothing Then probDescTxt.Focus()
            Return
        End If

        If deptIssueCombo Is Nothing OrElse deptIssueCombo.SelectedIndex < 0 Then
            MessageBox.Show("Please select the type of issue.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If deptIssueCombo IsNot Nothing Then deptIssueCombo.Focus()
            Return
        End If

        If Not SessionContext.CurrentUserID.HasValue Then
            MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get department ID if selected
        Dim departmentID As Integer? = Nothing
        If typesCombo IsNot Nothing AndAlso typesCombo.SelectedIndex > 0 Then
            Try
                Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
                If dt IsNot Nothing AndAlso typesCombo.SelectedIndex - 1 < dt.Rows.Count Then
                    If dt.Columns.Contains("departmentId") Then
                        departmentID = Convert.ToInt32(dt.Rows(typesCombo.SelectedIndex - 1)("departmentId"))
                    ElseIf dt.Columns.Contains("department_id") Then
                        departmentID = Convert.ToInt32(dt.Rows(typesCombo.SelectedIndex - 1)("department_id"))
                    End If
                End If
            Catch
            End Try
        End If

        ' Get condition and type of issue safely
        Dim conditionBeforeValue As String = "Good"
        If condCombo IsNot Nothing AndAlso condCombo.SelectedItem IsNot Nothing Then
            conditionBeforeValue = condCombo.SelectedItem.ToString()
        End If

        Dim typeOfIssue As String = "Repair"
        If deptIssueCombo IsNot Nothing AndAlso deptIssueCombo.SelectedItem IsNot Nothing Then
            typeOfIssue = deptIssueCombo.SelectedItem.ToString()
        End If

        ' Get target date safely
        Dim targetDateValue As Date? = Nothing
        If targetPicker IsNot Nothing AndAlso targetPicker.Value > Date.Today Then
            targetDateValue = targetPicker.Value
        End If

        ' Submit maintenance request - use safe null coalescing for optional controls
        Dim success As Boolean = DatabaseConnection.SubmitMaintenanceRequest(
            SessionContext.CurrentUserID.Value,
            propNameTxt.Text.Trim(),
            "", ' property number - optional
            If(serialTxt IsNot Nothing, serialTxt.Text.Trim(), ""),
            departmentID,
            If(locationTxt IsNot Nothing, locationTxt.Text.Trim(), ""), ' location
            conditionBeforeValue,
            typeOfIssue,
            probDescTxt.Text.Trim(), ' problem description
            targetDateValue
        )

        If success Then
            MessageBox.Show("Maintenance request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Navigate back to maintenance request list
            Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
            If parentDashboard IsNot Nothing Then
                parentDashboard.LoadUserControl(New MaintenanceRequest())
            Else
                ' If not in dashboard, try to close/remove this control
                Dim parentForm = TryCast(Me.Parent, Form)
                If parentForm IsNot Nothing Then
                    parentForm.Close()
                ElseIf Me.Parent IsNot Nothing Then
                    Me.Parent.Controls.Remove(Me)
                End If
            End If
        Else
            MessageBox.Show("Unable to submit maintenance request. Please verify all required fields are filled and try again.", "Request Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        ' Navigate back to maintenance request list
        Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New MaintenanceRequest())
        Else
            ' If not in dashboard, try to close/remove this control
            If Me.Parent IsNot Nothing Then
                Me.Parent.Controls.Remove(Me)
            End If
        End If
    End Sub
End Class
