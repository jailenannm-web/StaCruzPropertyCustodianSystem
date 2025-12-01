Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class AddMaintenance1
    Inherits UserControl

    Private canModifyMaintenance As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub AddMaintenance1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureModifyPermission()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        NavigateBack()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not EnsureModifyPermission() Then
            Return
        End If
        
        Try
            ' Validate required fields
            If String.IsNullOrWhiteSpace(propertyNameTxt.Text) Then
                MessageBox.Show("Please enter the property/item name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                propertyNameTxt.Focus()
                Return
            End If
            
            If ComboBox3.SelectedIndex < 0 Then
                MessageBox.Show("Please select a service type.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ComboBox3.Focus()
                Return
            End If
            
            If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                MessageBox.Show("Please enter maintenance description.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                Return
            End If
            
            ' Get property ID (try to parse from propertyNameTxt or use 0 if not found)
            Dim propertyID As Integer = 0
            If Not String.IsNullOrWhiteSpace(propertyNameTxt.Text) Then
                ' Try to find property by name
                Try
                    Dim dt As DataTable = DatabaseConnection.GetAllProperties()
                    For Each row As DataRow In dt.Rows
                        If row("item_name").ToString().Equals(propertyNameTxt.Text.Trim(), StringComparison.OrdinalIgnoreCase) Then
                            propertyID = Convert.ToInt32(row("property_id"))
                            Exit For
                        End If
                    Next
                Catch
                End Try
            End If
            
            ' Get custodian ID if provided
            Dim custodianID As Integer? = Nothing
            If Not String.IsNullOrWhiteSpace(assignedEmployeeTxt.Text) Then
                ' Try to find custodian by name or ID
                Try
                    Dim dt As DataTable = DatabaseConnection.GetAllUsers("Custodian")
                    For Each row As DataRow In dt.Rows
                        Dim fullName As String = row("first_name").ToString() & " " & row("last_name").ToString()
                        If fullName.Equals(assignedEmployeeTxt.Text.Trim(), StringComparison.OrdinalIgnoreCase) Then
                            custodianID = Convert.ToInt32(row("user_id"))
                            Exit For
                        End If
                    Next
                Catch
                End Try
            End If
            
            ' Get service date
            Dim serviceDate As Date = DateTimePicker1.Value
            
            ' Get service type
            Dim serviceType As String = ComboBox3.SelectedItem.ToString()
            
            ' Get description
            Dim description As String = TextBox1.Text.Trim()
            
            ' Get service provider
            Dim serviceProvider As String = TextBox2.Text.Trim()
            
            ' Get provider contact
            Dim providerContact As String = TextBox3.Text.Trim()
            
            ' Get cost
            Dim cost As Decimal = 0
            If Not String.IsNullOrWhiteSpace(Label3.Text) Then
                Decimal.TryParse(Label3.Text, cost)
            End If
            
            ' Get next schedule
            Dim nextSchedule As Date? = Nothing
            If established_date_date.Value > Date.Today Then
                nextSchedule = established_date_date.Value
            End If
            
            ' Get technician assigned
            Dim technicianAssigned As String = assignedEmployeeTxt.Text.Trim()
            
            ' Get status
            Dim status As String = "Pending"
            If conditionStatusCmbo.SelectedIndex >= 0 Then
                status = conditionStatusCmbo.SelectedItem.ToString()
            End If
            
            ' Get admin info
            Dim adminID As Integer? = Nothing
            Dim adminName As String = ""
            Dim adminUserType As String = ""
            If SessionContext.CurrentUserID.HasValue Then
                adminID = SessionContext.CurrentUserID.Value
                adminName = SessionContext.CurrentUsername
                adminUserType = SessionContext.CurrentRole
            End If
            
            ' Save maintenance record
            Dim success As Boolean = DatabaseConnection.AddMaintenance(
                propertyID,
                custodianID,
                serviceDate,
                serviceType,
                description,
                serviceProvider,
                providerContact,
                cost,
                nextSchedule,
                technicianAssigned,
                status,
                0, ' maintenanceIntervalDays
                "", ' remarks
                adminID,
                adminName,
                adminUserType
            )
            
            If success Then
                MessageBox.Show("Maintenance record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NavigateBack()
            Else
                MessageBox.Show("Failed to save maintenance record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving maintenance record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("AddMaintenance1 btnSave_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub



    Private Sub admin_label_DepartmentManagement_Click(sender As Object, e As EventArgs) Handles admin_label_DepartmentManagement.Click
    End Sub

    Private Sub propertyLocation_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub SAAddM_NextSched_Click(sender As Object, e As EventArgs) Handles SAAddM_NextSched.Click
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
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

