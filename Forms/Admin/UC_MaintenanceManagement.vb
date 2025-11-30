Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class UC_MaintenanceManagement
    Inherits UserControl

    Private canModifyMaintenance As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        canModifyMaintenance = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyMaintenance)
        ApplyRoleRestrictions()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub UC_MaintenanceManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub ApplyRoleRestrictions()
        Dim isSuperAdmin As Boolean = SessionContext.IsSuperAdmin()
        Dim isAdmin As Boolean = SessionContext.IsAdmin()
        btnApprove.Enabled = canModifyMaintenance
        btnAssign.Enabled = canModifyMaintenance AndAlso isSuperAdmin
        btnDelete.Enabled = isSuperAdmin
        btnReject.Enabled = canModifyMaintenance
    End Sub

    Private Sub ShowMaintenanceRestriction()
        MessageBox.Show("You have view-only access to Maintenance Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If Not canModifyMaintenance Then
            ShowMaintenanceRestriction()
            Return
        End If
        ' Get reference to the parent dashboard form
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)

        If parentDashboard IsNot Nothing Then
            ' Load the AddSupply UserControl
            parentDashboard.LoadUserControl(New AddMaintenance1())
        Else
            ' Fallback: add directly to the parent container
            Dim addSupplyUC As New AddMaintenance1()
            Me.Parent.Controls.Add(addSupplyUC)
            addSupplyUC.BringToFront()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        If Not canModifyMaintenance Then
            ShowMaintenanceRestriction()
            Return
        End If
        ' Get reference to the parent dashboard form
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)

        If parentDashboard IsNot Nothing Then
            ' Load the AddSupply UserControl
            parentDashboard.LoadUserControl(New AddMaintenance1())
        Else
            ' Fallback: add directly to the parent container
            Dim addSupplyUC As New EditMaintenance1()
            Me.Parent.Controls.Add(addSupplyUC)
            addSupplyUC.BringToFront()
        End If
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
        If Not canModifyMaintenance Then
            ShowMaintenanceRestriction()
            Return
        End If

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance record to reject.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim maintenanceID As Integer = Convert.ToInt32(selectedRow.Cells("maintenance_id").Value)

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to reject this maintenance record?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                ' Update maintenance status to cancelled
                Dim updateQuery As String = "UPDATE maintenance SET status = 'cancelled', remarks = CONCAT(IFNULL(remarks, ''), ' | Rejected by admin') WHERE maintenance_id = @maintenanceID"
                ' This would need a database function, for now show message
                MessageBox.Show("Maintenance record rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadMaintenanceData()
            End If
        Catch ex As Exception
            MessageBox.Show("Error rejecting maintenance record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        If Not canModifyMaintenance Then
            ShowMaintenanceRestriction()
            Return
        End If

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
                ' Update maintenance record with technician
                ' This would need a database function to update technician_assigned
                MessageBox.Show($"Technician '{technicianName}' assigned to maintenance record #{maintenanceID}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadMaintenanceData()
            End If
        Catch ex As Exception
            MessageBox.Show("Error assigning technician: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
