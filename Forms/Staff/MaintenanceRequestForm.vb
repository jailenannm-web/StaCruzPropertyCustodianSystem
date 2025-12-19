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

        ' Populate location ComboBox with common locations
        Dim locationCombo As ComboBox = FindControlOfType(Of ComboBox)("location")
        If locationCombo IsNot Nothing Then
            locationCombo.Items.Clear()
            locationCombo.Items.AddRange(New String() {"Main Building", "Annex Building", "Warehouse", "Storage Room", "Office", "Laboratory", "Classroom", "Other"})
            If locationCombo.Items.Count > 0 Then locationCombo.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Find relevant controls - itemName is a ComboBox, not TextBox
        Dim itemNameCombo As ComboBox = FindControlOfType(Of ComboBox)("itemName")
        Dim probDescTxt As TextBox = FindControlOfType(Of TextBox)("problemDescription")
        Dim deptIssueCombo As ComboBox = FindControlOfType(Of ComboBox)("department")
        Dim typesCombo As ComboBox = FindControlOfType(Of ComboBox)("typesOfIssue")
        Dim condCombo As ComboBox = FindControlOfType(Of ComboBox)("conditionBefore")
        Dim serialTxt As TextBox = FindControlOfType(Of TextBox)("serialNumber")
        Dim locationCombo As ComboBox = FindControlOfType(Of ComboBox)("location") ' location is a ComboBox
        Dim targetPicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("targetDate")

        ' Validate required fields - itemName is a ComboBox
        Dim itemNameValue As String = ""
        If itemNameCombo IsNot Nothing Then
            If itemNameCombo.SelectedItem IsNot Nothing Then
                itemNameValue = itemNameCombo.SelectedItem.ToString()
            ElseIf Not String.IsNullOrWhiteSpace(itemNameCombo.Text) Then
                itemNameValue = itemNameCombo.Text.Trim()
            End If
        End If

        If String.IsNullOrWhiteSpace(itemNameValue) Then
            MessageBox.Show("Please enter item name/property name", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If itemNameCombo IsNot Nothing Then itemNameCombo.Focus()
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

        ' Get location value from ComboBox
        Dim locationValue As String = ""
        If locationCombo IsNot Nothing Then
            If locationCombo.SelectedItem IsNot Nothing Then
                locationValue = locationCombo.SelectedItem.ToString()
            ElseIf Not String.IsNullOrWhiteSpace(locationCombo.Text) Then
                locationValue = locationCombo.Text.Trim()
            End If
        End If

        ' Submit maintenance request - use safe null coalescing for optional controls
        Dim success As Boolean = DatabaseConnection.SubmitMaintenanceRequest(
            SessionContext.CurrentUserID.Value,
            itemNameValue, ' Use the validated itemNameValue
            "", ' property number - optional
            If(serialTxt IsNot Nothing, serialTxt.Text.Trim(), ""),
            departmentID,
            locationValue, ' location from ComboBox
            conditionBeforeValue,
            typeOfIssue,
            If(probDescTxt IsNot Nothing, probDescTxt.Text.Trim(), ""), ' problem description
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

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
