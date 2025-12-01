Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class UC_MaintenanceManagement
    Inherits UserControl

    Private canModifyMaintenance As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        ApplyRoleRestrictions()
    End Sub

    Private Sub ApplyRoleRestrictions()
        ' Super Admin, Admin, and Custodian have full access - ALL buttons enabled
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If btnApprove IsNot Nothing Then btnApprove.Enabled = hasFullAccess
        If btnAssign IsNot Nothing Then btnAssign.Enabled = hasFullAccess
        If btnDelete IsNot Nothing Then btnDelete.Enabled = hasFullAccess
        If btnReject IsNot Nothing Then btnReject.Enabled = hasFullAccess

        If btnRefresh IsNot Nothing Then btnRefresh.Enabled = True ' Always enabled
        If btnGenerateMaintenance IsNot Nothing Then btnGenerateMaintenance.Enabled = hasFullAccess
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        ' Allow editing by double-clicking a row
        If e.RowIndex >= 0 Then
            btnEdit_Click(sender, e)
        End If
    End Sub

    Private Sub UC_MaintenanceManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make grid read-only
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        LoadMaintenanceData()
    End Sub

    Private Sub LoadMaintenanceData()
        Try
            Dim maintenanceData As DataTable = DatabaseConnection.GetAllMaintenance()
            If maintenanceData IsNot Nothing AndAlso maintenanceData.Rows.Count > 0 Then
                DataGridView1.DataSource = maintenanceData
                ttlMaintenancemanagement.Text = maintenanceData.Rows.Count.ToString()
            Else
                DataGridView1.DataSource = Nothing
                ttlMaintenancemanagement.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading maintenance data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ttlMaintenancemanagement.Text = "0"
        End Try
    End Sub





    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance record to approve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            Dim maintenanceID As Integer = Convert.ToInt32(dataRow("maintenance_id"))
            Dim currentStatus As String = If(IsDBNull(dataRow("status")), "", dataRow("status").ToString().ToLower())

            If currentStatus = "completed" OrElse currentStatus = "approved" Then
                MessageBox.Show("This maintenance record is already approved/completed.", "Already Processed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Update maintenance status to approved/completed using SetMaintenanceStatus
            Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)
            If DatabaseConnection.SetMaintenanceStatus(maintenanceID, "Completed", adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, "Approved by " & SessionContext.CurrentRole) Then
                MessageBox.Show("Maintenance record approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadMaintenanceData()
            Else
                MessageBox.Show("Failed to approve maintenance record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Dim errorMsg As String = "An error occurred while approving the maintenance record."
            If TypeOf ex Is MySqlException Then
                errorMsg = "Database error: Unable to approve the maintenance record. Please check your connection and try again."
            ElseIf TypeOf ex Is InvalidCastException OrElse TypeOf ex Is FormatException Then
                errorMsg = "Invalid data format. Please refresh the list and try again."
            End If
            MessageBox.Show(errorMsg & vbCrLf & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            Dim maintenanceID As Integer = Convert.ToInt32(dataRow("maintenance_id"))

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this maintenance record? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                ' Delete maintenance record
                Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
                If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                    Using cmd As New MySqlCommand("DELETE FROM maintenance WHERE maintenance_id = @maintenanceID", conn)
                        cmd.Parameters.AddWithValue("@maintenanceID", maintenanceID)
                        If cmd.ExecuteNonQuery() > 0 Then
                            MessageBox.Show("Maintenance record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadMaintenanceData()
                        Else
                            MessageBox.Show("Failed to delete maintenance record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                    If conn.State = ConnectionState.Open Then conn.Close()
                End If
            End If
        Catch ex As Exception
            Dim errorMsg As String = "An error occurred while deleting the maintenance record."
            If TypeOf ex Is MySqlException Then
                errorMsg = "Database error: Unable to delete the maintenance record. Please check your connection and try again."
            ElseIf TypeOf ex Is InvalidCastException OrElse TypeOf ex Is FormatException Then
                errorMsg = "Invalid data format. Please refresh the list and try again."
            End If
            MessageBox.Show(errorMsg & vbCrLf & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        ' No restrictions for Super Admin, Admin, and Custodian

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance record to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            Dim maintenanceID As Integer = Convert.ToInt32(dataRow("maintenance_id"))

            ' Get reference to the parent dashboard form
            Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)

            If parentDashboard IsNot Nothing Then
                ' Load EditMaintenance1 with maintenance ID
                Dim editForm As New EditMaintenance1()
                editForm.MaintenanceID = maintenanceID
                parentDashboard.LoadUserControl(editForm)
            Else
                ' Fallback: add directly to the parent container
                Dim editForm As New EditMaintenance1()
                editForm.MaintenanceID = maintenanceID
                Me.Parent.Controls.Add(editForm)
                editForm.BringToFront()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading maintenance record for editing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadMaintenanceData()
    End Sub

    Private Sub btnGenerateMaintenance_Click(sender As Object, e As EventArgs) Handles btnGenerateMaintenance.Click
        ' Generate maintenance report
        Try
            ' TODO: Implement maintenance report generation
            MessageBox.Show("Maintenance report generation feature will be implemented.", "Feature Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error generating report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance record to reject.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim maintenanceID As Integer = Convert.ToInt32(selectedRow.Cells("maintenance_id").Value)

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to reject this maintenance record?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim remarks As String = InputBox("Enter rejection reason (optional):", "Reject Maintenance", "")
                Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

                ' Update maintenance status using DatabaseConnection
                If DatabaseConnection.SetMaintenanceStatus(maintenanceID, "For Review", adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, "Rejected: " & remarks) Then
                    MessageBox.Show("Maintenance record rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadMaintenanceData()
                Else
                    MessageBox.Show("Failed to reject maintenance record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            Dim errorMsg As String = "An error occurred while rejecting the maintenance record."
            If TypeOf ex Is MySqlException Then
                errorMsg = "Database error: Unable to reject the maintenance record. Please check your connection and try again."
            ElseIf TypeOf ex Is InvalidCastException OrElse TypeOf ex Is FormatException Then
                errorMsg = "Invalid data format. Please refresh the list and try again."
            End If
            MessageBox.Show(errorMsg & vbCrLf & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        ' No restrictions for Super Admin, Admin, and Custodian

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance record to assign a technician.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim maintenanceID As Integer = Convert.ToInt32(selectedRow.Cells("maintenance_id").Value)

            ' Prompt for technician name
            Dim technicianName As String = InputBox("Enter technician name to assign:", "Assign Technician", "")
            If Not String.IsNullOrEmpty(technicianName) Then
                ' Update maintenance record with technician using DatabaseConnection
                Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
                If dt IsNot Nothing Then
                    Dim rowIndex As Integer = selectedRow.Index
                    Dim dataRow As DataRow = dt.Rows(rowIndex)
                    Dim serviceDate As Date = If(IsDBNull(dataRow("maintenance_date")), Date.Today, CDate(dataRow("maintenance_date")))
                    Dim serviceType As String = If(IsDBNull(dataRow("type_of_maintenance")), "Repair", dataRow("type_of_maintenance").ToString())
                    Dim description As String = If(IsDBNull(dataRow("maintenance_details")), "", dataRow("maintenance_details").ToString())
                    Dim currentStatus As String = If(IsDBNull(dataRow("status")), "Ongoing", dataRow("status").ToString())
                    Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

                    ' Use UpdateMaintenanceEntry to assign technician
                    Dim cost As Decimal = 0
                    If Not IsDBNull(dataRow("cost_materials_labor")) Then
                        Decimal.TryParse(dataRow("cost_materials_labor").ToString(), cost)
                    End If
                    If DatabaseConnection.UpdateMaintenanceEntry(maintenanceID, serviceDate, serviceType, description, "", "", cost, Nothing, technicianName, currentStatus, "", 0, adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole) Then
                        MessageBox.Show($"Technician '{technicianName}' assigned to maintenance record #{maintenanceID}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadMaintenanceData()
                    Else
                        MessageBox.Show("Failed to assign technician. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            Dim errorMsg As String = "An error occurred while assigning the technician."
            If TypeOf ex Is MySqlException Then
                errorMsg = "Database error: Unable to assign technician. Please check your connection and try again."
            ElseIf TypeOf ex Is InvalidCastException OrElse TypeOf ex Is FormatException Then
                errorMsg = "Invalid data format. Please refresh the list and try again."
            End If
            MessageBox.Show(errorMsg & vbCrLf & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
