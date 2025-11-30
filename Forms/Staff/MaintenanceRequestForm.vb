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
                ComboBox4.Items.Add(row("department_name").ToString())
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
                    departmentID = Convert.ToInt32(dt.Rows(ComboBox4.SelectedIndex - 1)("department_id"))
                End If
            Catch
            End Try
        End If

        ' Submit maintenance request
        Dim success As Boolean = DatabaseConnection.SubmitMaintenanceRequest(
            SessionContext.CurrentUserID.Value,
            propertyNameTxt.Text.Trim(),
            "", ' property number - optional
            serialNumberTxt.Text.Trim(),
            departmentID,
            TextBox2.Text.Trim(), ' location
            conditionStatusCmbo.SelectedItem.ToString(),
            ComboBox3.SelectedItem.ToString(), ' type of issue
            TextBox1.Text.Trim(), ' problem description
            If(DateTimePicker1.Value > Date.Today, DateTimePicker1.Value, Nothing) ' target date
        )

        If success Then
            MessageBox.Show("Maintenance request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Navigate back to maintenance request list
            Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
            If parentDashboard IsNot Nothing Then
                parentDashboard.LoadUserControl(New MaintenanceRequest())
            Else
                ' If not in dashboard, try to close/remove this control
                Me.Parent.Controls.Remove(Me)
            End If
        Else
            MessageBox.Show("Failed to submit maintenance request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
