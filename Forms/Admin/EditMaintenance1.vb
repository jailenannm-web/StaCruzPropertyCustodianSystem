Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class EditMaintenance1
    Inherits UserControl

    Private canModifyMaintenance As Boolean = False
    Private _maintenanceID As Integer = 0

    Public Property MaintenanceID As Integer
        Get
            Return _maintenanceID
        End Get
        Set(value As Integer)
            _maintenanceID = value
            If _maintenanceID > 0 Then
                LoadMaintenanceData()
            End If
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub EditMaintenance1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureModifyPermission()
        If _maintenanceID > 0 Then
            LoadMaintenanceData()
        End If
    End Sub

    Private Sub LoadMaintenanceData()
        Try
            If _maintenanceID <= 0 Then Return

            Dim dt As DataTable = DatabaseConnection.GetAllMaintenance()
            For Each row As DataRow In dt.Rows
                If Convert.ToInt32(row("maintenance_id")) = _maintenanceID Then
                    ' Load data into form fields
                    ' Note: Adjust field names based on actual form controls
                    Try
                        If dt.Columns.Contains("property_item_name") AndAlso Not IsDBNull(row("property_item_name")) Then
                            ' propertyNameTxt.Text = row("property_item_name").ToString()
                        End If
                        If dt.Columns.Contains("maintenance_date") AndAlso Not IsDBNull(row("maintenance_date")) Then
                            ' DateTimePicker1.Value = Convert.ToDateTime(row("maintenance_date"))
                        End If
                        If dt.Columns.Contains("type_of_maintenance") AndAlso Not IsDBNull(row("type_of_maintenance")) Then
                            ' ComboBox3.SelectedItem = row("type_of_maintenance").ToString()
                        End If
                        If dt.Columns.Contains("maintenance_details") AndAlso Not IsDBNull(row("maintenance_details")) Then
                            ' TextBox1.Text = row("maintenance_details").ToString()
                        End If
                        If dt.Columns.Contains("assigned_technician") AndAlso Not IsDBNull(row("assigned_technician")) Then
                            ' assignedEmployeeTxt.Text = row("assigned_technician").ToString()
                        End If
                        If dt.Columns.Contains("cost_materials_labor") AndAlso Not IsDBNull(row("cost_materials_labor")) Then
                            ' Label3.Text = row("cost_materials_labor").ToString()
                        End If
                    Catch
                    End Try
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error loading maintenance data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        NavigateBack()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not EnsureModifyPermission() Then
            Return
        End If
        
        If _maintenanceID <= 0 Then
            MessageBox.Show("No maintenance record selected for editing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        
        Try
            ' Validate required fields
            ' Note: Adjust field names based on actual form controls
            ' For now, using placeholder logic
            
            ' Get service date (assuming DateTimePicker1 exists)
            Dim serviceDate As Date = Date.Today
            ' If DateTimePicker1 IsNot Nothing Then serviceDate = DateTimePicker1.Value
            
            ' Get service type (assuming ComboBox3 exists)
            Dim serviceType As String = "Repair"
            ' If ComboBox3.SelectedIndex >= 0 Then serviceType = ComboBox3.SelectedItem.ToString()
            
            ' Get description (assuming TextBox1 exists)
            Dim description As String = ""
            ' If TextBox1 IsNot Nothing Then description = TextBox1.Text.Trim()
            
            ' Get service provider (assuming TextBox2 exists)
            Dim serviceProvider As String = ""
            ' If TextBox2 IsNot Nothing Then serviceProvider = TextBox2.Text.Trim()
            
            ' Get provider contact (assuming TextBox3 exists)
            Dim providerContact As String = ""
            ' If TextBox3 IsNot Nothing Then providerContact = TextBox3.Text.Trim()
            
            ' Get cost (assuming Label3 or TextBox exists)
            Dim cost As Decimal = 0
            ' If Label3 IsNot Nothing Then Decimal.TryParse(Label3.Text, cost)
            
            ' Get technician assigned (assuming assignedEmployeeTxt exists)
            Dim technicianAssigned As String = ""
            ' If assignedEmployeeTxt IsNot Nothing Then technicianAssigned = assignedEmployeeTxt.Text.Trim()
            
            ' Get status (assuming conditionStatusCmbo exists)
            Dim status As String = "Ongoing"
            ' If conditionStatusCmbo.SelectedIndex >= 0 Then status = conditionStatusCmbo.SelectedItem.ToString()
            
            ' Get admin info
            Dim adminID As Integer? = Nothing
            Dim adminName As String = ""
            Dim adminUserType As String = ""
            If SessionContext.CurrentUserID.HasValue Then
                adminID = SessionContext.CurrentUserID.Value
                adminName = SessionContext.CurrentUsername
                adminUserType = SessionContext.CurrentRole
            End If
            
            ' Update maintenance record
            Dim success As Boolean = DatabaseConnection.UpdateMaintenanceEntry(
                _maintenanceID,
                serviceDate,
                serviceType,
                description,
                serviceProvider,
                providerContact,
                cost,
                Nothing, ' nextSchedule
                technicianAssigned,
                status,
                "", ' remarks
                0, ' maintenanceIntervalDays
                adminID,
                adminName,
                adminUserType
            )
            
            If success Then
                MessageBox.Show("Maintenance record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NavigateBack()
            Else
                MessageBox.Show("Failed to update maintenance record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating maintenance record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("EditMaintenance1 btnSave_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBack()
    End Sub

    Private Sub NavigateBack()
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_MaintenanceManagement())
        Else
            Me.Parent?.Controls.Remove(Me)
        End If
    End Sub

    Private Function EnsureModifyPermission() As Boolean
        ' No restrictions for Super Admin, Admin, and Custodian
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If hasFullAccess Then
            Return True
        End If
        ' For other roles, check permission
        canModifyMaintenance = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyMaintenance)
        If Not canModifyMaintenance Then
            MessageBox.Show("You have view-only access to Maintenance Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
            Return False
        End If
        Return True
    End Function
End Class

