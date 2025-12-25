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
    Private originalData As DataTable
    Private isSearching As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill

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

        ' Wire search textbox if present
        Dim searchNames As String() = {"maintenanceSearch", "maintenance_search", "txtSearch", "txtbox_search", "admin_txtbox_search", "DataGridSearch"}
        For Each nm As String In searchNames
            Dim found() As Control = Me.Controls.Find(nm, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is TextBox Then
                Dim tb As TextBox = CType(found(0), TextBox)
                RemoveHandler tb.TextChanged, AddressOf MaintenanceSearch_TextChanged
                AddHandler tb.TextChanged, AddressOf MaintenanceSearch_TextChanged
                Exit For
            End If
        Next
    End Sub

    Private Sub LoadMaintenanceData()
        Try
            Dim maintenanceData As DataTable = DatabaseConnection.GetAllMaintenance()
            originalData = If(maintenanceData IsNot Nothing, maintenanceData.Copy(), Nothing)
            
            ' Configure DataGrid columns before setting DataSource
            DataGridView1.AutoGenerateColumns = False
            
            ' Map columns and set visibility
            For Each col As DataGridViewColumn In DataGridView1.Columns
                Select Case col.Name.ToLower()
                    Case "maintenanceid"
                        col.DataPropertyName = "maintenanceId"
                        col.HeaderText = "Maintenance ID"
                        col.Visible = True
                    Case "propertyitemname"
                        col.DataPropertyName = "propertyItemName"
                        col.HeaderText = "Property Item Name"
                        col.Visible = True
                    Case "location"
                        col.DataPropertyName = "location"
                        col.HeaderText = "Location"
                        col.Visible = True
                    Case "conditionbeforemaint"
                        col.DataPropertyName = "conditionBeforeMaint"
                        col.HeaderText = "Condition Before"
                        col.Visible = True
                    Case "typeofmaintenance"
                        col.DataPropertyName = "typeOfMaintenance"
                        col.HeaderText = "Type of Maintenance"
                        col.Visible = True
                    Case "assignedtechnician"
                        col.DataPropertyName = "assignedTechnician"
                        col.HeaderText = "Assigned Technician"
                        col.Visible = True
                    Case "status"
                        col.DataPropertyName = "status"
                        col.HeaderText = "Status"
                        col.Visible = True
                    Case "actiontaken"
                        col.DataPropertyName = "actionTaken"
                        col.HeaderText = "Action Taken"
                        col.Visible = True
                    Case Else
                        ' Hide all other columns
                        col.Visible = False
                End Select
            Next
            
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

    Private Sub MaintenanceSearch_TextChanged(sender As Object, e As EventArgs)
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb Is Nothing Then Return
        ApplyMaintenanceSearch(tb.Text)
    End Sub

    Private Sub ApplyMaintenanceSearch(searchText As String)
        If originalData Is Nothing Then Return
        If isSearching Then Return
        isSearching = True
        Try
            Dim searchLower As String = If(String.IsNullOrWhiteSpace(searchText), String.Empty, searchText.Trim().ToLower())

            Dim filtered = originalData.AsEnumerable().Where(Function(row)
                                                                 If String.IsNullOrEmpty(searchLower) Then Return True
                                                                 ' Check common fields: propertyItemName, maintenanceDetails, assignedTechnician, status (camelCase)
                                                                 Dim a As String = If(row.Table.Columns.Contains("propertyItemName") AndAlso Not IsDBNull(row("propertyItemName")), row("propertyItemName").ToString().ToLower(), String.Empty)
                                                                 Dim b As String = If(row.Table.Columns.Contains("maintenanceDetails") AndAlso Not IsDBNull(row("maintenanceDetails")), row("maintenanceDetails").ToString().ToLower(), String.Empty)
                                                                 Dim c As String = If(row.Table.Columns.Contains("assignedTechnician") AndAlso Not IsDBNull(row("assignedTechnician")), row("assignedTechnician").ToString().ToLower(), String.Empty)
                                                                 Dim d As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString().ToLower(), String.Empty)
                                                                 Return a.Contains(searchLower) OrElse b.Contains(searchLower) OrElse c.Contains(searchLower) OrElse d.Contains(searchLower)
                                                             End Function)

            If filtered Is Nothing Then
                DataGridView1.DataSource = Nothing
                ttlMaintenancemanagement.Text = "0"
            Else
                Dim dt As DataTable = filtered.CopyToDataTable()
                DataGridView1.DataSource = dt
                ttlMaintenancemanagement.Text = dt.Rows.Count.ToString()
            End If
        Catch ex As Exception
            ' If there are no matches CopyToDataTable will throw � handle gracefully
            If TypeOf ex Is InvalidOperationException Then
                DataGridView1.DataSource = Nothing
                ttlMaintenancemanagement.Text = "0"
            Else
                MessageBox.Show("Error searching maintenance records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            isSearching = False
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
            Dim maintenanceID As Integer = 0
            
            ' Try to get maintenanceID from the selected row - check multiple sources
            ' First, try to get from DataGridView cell directly
            If selectedRow.Cells("maintenanceId") IsNot Nothing AndAlso selectedRow.Cells("maintenanceId").Value IsNot Nothing Then
                If Not Integer.TryParse(selectedRow.Cells("maintenanceId").Value.ToString(), maintenanceID) Then
                    ' Try alternative column name
                    If selectedRow.Cells("maintenance_id") IsNot Nothing AndAlso selectedRow.Cells("maintenance_id").Value IsNot Nothing Then
                        Integer.TryParse(selectedRow.Cells("maintenance_id").Value.ToString(), maintenanceID)
                    End If
                Else
                    Integer.TryParse(selectedRow.Cells("maintenanceId").Value.ToString(), maintenanceID)
                End If
            ElseIf selectedRow.Cells("maintenance_id") IsNot Nothing AndAlso selectedRow.Cells("maintenance_id").Value IsNot Nothing Then
                Integer.TryParse(selectedRow.Cells("maintenance_id").Value.ToString(), maintenanceID)
            End If
            
            ' If still not found, try from DataSource
            If maintenanceID <= 0 Then
                Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
                If dt IsNot Nothing Then
                    Dim rowIndex As Integer = selectedRow.Index
                    If rowIndex >= 0 AndAlso rowIndex < dt.Rows.Count Then
                        Dim dataRow As DataRow = dt.Rows(rowIndex)
                        If dt.Columns.Contains("maintenanceId") AndAlso Not IsDBNull(dataRow("maintenanceId")) Then
                            Integer.TryParse(dataRow("maintenanceId").ToString(), maintenanceID)
                        ElseIf dt.Columns.Contains("maintenance_id") AndAlso Not IsDBNull(dataRow("maintenance_id")) Then
                            Integer.TryParse(dataRow("maintenance_id").ToString(), maintenanceID)
                        End If
                    End If
                End If
            End If
            
            If maintenanceID <= 0 Then
                MessageBox.Show("Invalid maintenance ID. Unable to retrieve maintenance record ID from selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Diagnostics.Debug.WriteLine("[v0] UC_MaintenanceManagement - btnApprove: Could not get maintenanceID from selected row")
                Return
            End If
            
            ' Get current status from selected row
            Dim currentStatus As String = ""
            If selectedRow.Cells("status") IsNot Nothing AndAlso selectedRow.Cells("status").Value IsNot Nothing Then
                currentStatus = selectedRow.Cells("status").Value.ToString().ToLower()
            Else
                Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
                If dt IsNot Nothing AndAlso selectedRow.Index >= 0 AndAlso selectedRow.Index < dt.Rows.Count Then
                    Dim dataRow As DataRow = dt.Rows(selectedRow.Index)
                    If dt.Columns.Contains("status") AndAlso Not IsDBNull(dataRow("status")) Then
                        currentStatus = dataRow("status").ToString().ToLower()
                    End If
                End If
            End If

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
            MessageBox.Show(errorMsg & Environment.NewLine & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Dim maintenanceID As Integer = 0
            If dt.Columns.Contains("maintenanceId") Then
                maintenanceID = Convert.ToInt32(dataRow("maintenanceId"))
            ElseIf dt.Columns.Contains("maintenance_id") Then
                maintenanceID = Convert.ToInt32(dataRow("maintenance_id"))
            End If

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this maintenance record? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                ' Delete maintenance record
                Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
                If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                    Using cmd As New MySqlCommand("DELETE FROM maintenance WHERE maintenanceId = @maintenanceID", conn)
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
            MessageBox.Show(errorMsg & Environment.NewLine & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Dim maintenanceID As Integer = 0
            If dt.Columns.Contains("maintenanceId") Then
                maintenanceID = Convert.ToInt32(dataRow("maintenanceId"))
            ElseIf dt.Columns.Contains("maintenance_id") Then
                maintenanceID = Convert.ToInt32(dataRow("maintenance_id"))
            End If

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
        Try
            ' Check SADashboard first (parent class)
            Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
            If saDashboard IsNot Nothing Then
                saDashboard.LoadUserControl(New MaintenanceManagementReport1())
                Return
            End If
            
            Dim superAdminDashboard = TryCast(Me.ParentForm, SuperAdminDashboard)
            If superAdminDashboard IsNot Nothing Then
                superAdminDashboard.LoadUserControl(New MaintenanceManagementReport1())
                Return
            End If
            
            ' Check AdminDashboard
            Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
            If parentDashboard IsNot Nothing Then
                parentDashboard.LoadUserControl(New MaintenanceManagementReport1())
            Else
                ' Fallback if the parent form isn't found or isn't AdminDashboard
                MessageBox.Show("Unable to find the Dashboard container.", "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error navigating to report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Dim maintenanceID As Integer = 0
            
            ' Try to get maintenanceID from the selected row - check multiple sources
            ' First, try to get from DataGridView cell directly
            If selectedRow.Cells("maintenanceId") IsNot Nothing AndAlso selectedRow.Cells("maintenanceId").Value IsNot Nothing Then
                If Not Integer.TryParse(selectedRow.Cells("maintenanceId").Value.ToString(), maintenanceID) Then
                    ' Try alternative column name
                    If selectedRow.Cells("maintenance_id") IsNot Nothing AndAlso selectedRow.Cells("maintenance_id").Value IsNot Nothing Then
                        Integer.TryParse(selectedRow.Cells("maintenance_id").Value.ToString(), maintenanceID)
                    End If
                Else
                    Integer.TryParse(selectedRow.Cells("maintenanceId").Value.ToString(), maintenanceID)
                End If
            ElseIf selectedRow.Cells("maintenance_id") IsNot Nothing AndAlso selectedRow.Cells("maintenance_id").Value IsNot Nothing Then
                Integer.TryParse(selectedRow.Cells("maintenance_id").Value.ToString(), maintenanceID)
            End If
            
            ' If still not found, try from DataSource
            If maintenanceID <= 0 Then
                Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
                If dt IsNot Nothing Then
                    Dim rowIndex As Integer = selectedRow.Index
                    If rowIndex >= 0 AndAlso rowIndex < dt.Rows.Count Then
                        Dim dataRow As DataRow = dt.Rows(rowIndex)
                        If dt.Columns.Contains("maintenanceId") AndAlso Not IsDBNull(dataRow("maintenanceId")) Then
                            Integer.TryParse(dataRow("maintenanceId").ToString(), maintenanceID)
                        ElseIf dt.Columns.Contains("maintenance_id") AndAlso Not IsDBNull(dataRow("maintenance_id")) Then
                            Integer.TryParse(dataRow("maintenance_id").ToString(), maintenanceID)
                        End If
                    End If
                End If
            End If
            
            If maintenanceID <= 0 Then
                MessageBox.Show("Invalid maintenance ID. Unable to retrieve maintenance record ID from selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Diagnostics.Debug.WriteLine("[v0] UC_MaintenanceManagement - btnReject: Could not get maintenanceID from selected row")
                Return
            End If

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to reject this maintenance record?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim remarks As String = InputBox("Enter rejection reason (optional):", "Reject Maintenance", "")
                Dim adminID As Integer = If(SessionContext.CurrentUserID.HasValue, SessionContext.CurrentUserID.Value, 0)

                ' Update maintenance status using DatabaseConnection - use "Rejected" status
                If DatabaseConnection.SetMaintenanceStatus(maintenanceID, "Rejected", adminID, SessionContext.CurrentUsername, SessionContext.CurrentRole, "Rejected: " & remarks) Then
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
            MessageBox.Show(errorMsg & Environment.NewLine & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
            If dt Is Nothing Then
                MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim rowIndex As Integer = selectedRow.Index
            Dim dataRow As DataRow = dt.Rows(rowIndex)
            Dim maintenanceID As Integer = 0
            If dt.Columns.Contains("maintenanceId") Then
                maintenanceID = Convert.ToInt32(dataRow("maintenanceId"))
            ElseIf dt.Columns.Contains("maintenance_id") Then
                maintenanceID = Convert.ToInt32(dataRow("maintenance_id"))
            End If

            If maintenanceID <= 0 Then
                MessageBox.Show("Invalid maintenance record selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Open AssignTechnician form
            Dim assignForm As New AssignTechnician()
            assignForm.MaintenanceID = maintenanceID
            Dim result As DialogResult = assignForm.ShowDialog()

            ' Refresh data after assignment
            If result = DialogResult.OK Then
                LoadMaintenanceData()
            End If

        Catch ex As Exception
            Dim errorMsg As String = "An error occurred while assigning the technician."
            If TypeOf ex Is MySqlException Then
                errorMsg = "Database error: Unable to assign technician. Please check your connection and try again."
            ElseIf TypeOf ex Is InvalidCastException OrElse TypeOf ex Is FormatException Then
                errorMsg = "Invalid data format. Please refresh the list and try again."
            End If
            MessageBox.Show(errorMsg & Environment.NewLine & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

