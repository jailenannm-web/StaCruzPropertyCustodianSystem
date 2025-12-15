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

    Private Sub InitializeForm()
        ' Populate condition status combo
        conditionStatusCmbo.Items.AddRange(New String() {"Good", "Needs Repair", "Damaged"})
        conditionStatusCmbo.SelectedIndex = 0
        
        ' Populate type of issue combo (ComboBox3)
        ComboBox3.Items.AddRange(New String() {"Repair", "Replace", "Servicing"})
        ComboBox3.SelectedIndex = 0
        
        ' Load departments into ComboBox4
        Try
            Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
            ComboBox4.Items.Clear()
            ComboBox4.Items.Add("Select Department")
            For Each row As DataRow In dt.Rows
                ' Use camelCase column name to match database
                If dt.Columns.Contains("departmentName") Then
                    ComboBox4.Items.Add(row("departmentName").ToString())
                ElseIf dt.Columns.Contains("department_name") Then
                    ComboBox4.Items.Add(row("department_name").ToString())
                End If
            Next
            ComboBox4.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate required fields
        If String.IsNullOrWhiteSpace(propertyNameTxt.Text) Then
            MessageBox.Show("Please enter the item/property name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            propertyNameTxt.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please enter the problem description.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox1.Focus()
            Return
        End If

        If ComboBox3.SelectedIndex < 0 Then
            MessageBox.Show("Please select the type of issue.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBox3.Focus()
            Return
        End If

        If Not SessionContext.CurrentUserID.HasValue Then
            MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get department ID if selected
        Dim departmentID As Integer? = Nothing
        If ComboBox4.SelectedIndex > 0 Then
            Try
                Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
                If ComboBox4.SelectedIndex <= dt.Rows.Count Then
                    ' Use camelCase column name to match database
                    If dt.Columns.Contains("departmentId") Then
                        departmentID = Convert.ToInt32(dt.Rows(ComboBox4.SelectedIndex - 1)("departmentId"))
                    ElseIf dt.Columns.Contains("department_id") Then
                        departmentID = Convert.ToInt32(dt.Rows(ComboBox4.SelectedIndex - 1)("department_id"))
                    End If
                End If
            Catch
            End Try
        End If

        ' Get condition and type of issue safely
        Dim conditionBefore As String = "Good"
        If conditionStatusCmbo.SelectedItem IsNot Nothing Then
            conditionBefore = conditionStatusCmbo.SelectedItem.ToString()
        End If
        
        Dim typeOfIssue As String = "Repair"
        If ComboBox3.SelectedItem IsNot Nothing Then
            typeOfIssue = ComboBox3.SelectedItem.ToString()
        End If
        
        ' Get target date safely
        Dim targetDate As Date? = Nothing
        If DateTimePicker1.Value > Date.Today Then
            targetDate = DateTimePicker1.Value
        End If
        
        ' Submit maintenance request
        Dim success As Boolean = DatabaseConnection.SubmitMaintenanceRequest(
            SessionContext.CurrentUserID.Value,
            propertyNameTxt.Text.Trim(),
            "", ' property number - optional
            serialNumberTxt.Text.Trim(),
            departmentID,
            TextBox2.Text.Trim(), ' location
            conditionBefore,
            typeOfIssue,
            TextBox1.Text.Trim(), ' problem description
            targetDate
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
                Else
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
            Me.Parent.Controls.Remove(Me)
        End If
    End Sub
End Class
