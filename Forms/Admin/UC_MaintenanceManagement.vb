Imports System
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic

''' <summary>
''' Maintenance Management User Control
''' Displays and manages maintenance records with proper database alignment
''' </summary>
Public Class UC_MaintenanceManagement
    Inherits UserControl

    ' ================================================================
    ' PRIVATE FIELDS
    ' ================================================================
    Private originalData As DataTable
    Private isSearching As Boolean = False
    Private isFiltering As Boolean = False
    Private currentFilter As String = ""

    ' ================================================================
    ' CONSTRUCTOR
    ' ================================================================
    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    ' ================================================================
    ' LOAD EVENT - Initialize the control
    ' ================================================================
    Private Sub UC_MaintenanceManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Configure DataGridView appearance
            ConfigureDataGridView()
            
            ' Initialize filters
            InitializeFilters()
            
            ' Load maintenance data from database
            LoadMaintenanceData()
            
            ' Wire up search functionality
            SetupSearchFunctionality()
            
            ' Apply permission-based button states
            ApplyPermissions()
        Catch ex As Exception
            MessageBox.Show("Error initializing Maintenance Management: " & ex.Message, "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================================
    ' DATAGRIDVIEW CONFIGURATION
    ' ================================================================
    Private Sub ConfigureDataGridView()
        With DataGridView1
            .AutoGenerateColumns = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = True
            .RowHeadersWidth = 50
            .EnableHeadersVisualStyles = False
            .BackgroundColor = Color.FromArgb(248, 249, 250)
            .GridColor = Color.FromArgb(222, 226, 230)
            .BorderStyle = BorderStyle.None
            
            ' Column header styling - Modern professional look
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 37, 41) ' Dark gray-black
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Poppins", 9, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ColumnHeadersDefaultCellStyle.Padding = New Padding(10, 0, 0, 0)
            .ColumnHeadersHeight = 45
            
            ' Row styling - Clean and modern
            .DefaultCellStyle.Font = New Font("Poppins", 9)
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 110, 253) ' Bootstrap primary blue
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.Padding = New Padding(10, 5, 10, 5)
            .RowTemplate.Height = 40
            
            ' Alternating row colors for better readability
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250)
            .AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 110, 253)
        End With
        
        ' Map columns to database fields (using camelCase to match schema)
        MapDataGridColumns()
    End Sub

    ' ================================================================
    ' MAP DATAGRIDVIEW COLUMNS TO DATABASE FIELDS
    ' ================================================================
    Private Sub MapDataGridColumns()
        ' Column mapping based on maintenance table schema
        Dim columnMappings As New Dictionary(Of String, String) From {
            {"maintenanceId", "maintenanceId"},
            {"requestId", "requestId"},
            {"propertyItemName", "propertyItemName"},
            {"serialNumber", "serialNumber"},
            {"location", "location"},
            {"departmentId", "departmentName"},
            {"conditionBeforeMaint", "conditionBeforeMaint"},
            {"typeOfMaintenance", "typeOfMaintenance"},
            {"assignedTechnician", "assignedTechnician"},
            {"maintenanceDate", "maintenanceDate"},
            {"maintenanceDetail", "maintenanceDetails"},
            {"costMaterialsLabor", "costMaterialsLabor"},
            {"conditionAfterMaint", "conditionAfterMaint"},
            {"status", "status"},
            {"diagnosis", "diagnosis"},
            {"actionTaken", "actionTaken"},
            {"partsReplaced", "partsReplaced"}
        }
        
        ' Apply mappings and configure visibility
        For Each col As DataGridViewColumn In DataGridView1.Columns
            Dim colNameLower As String = col.Name.ToLower()
            
            ' Set DataPropertyName based on mapping
            For Each mapping In columnMappings
                If mapping.Key.ToLower() = colNameLower Then
                    col.DataPropertyName = mapping.Value
                    Exit For
                End If
            Next
            
            ' Configure column visibility and appearance - Optimized for database structure
            Select Case colNameLower
                Case "maintenanceid"
                    col.HeaderText = "ID"
                    col.Visible = True
                    col.Width = 60
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    col.DefaultCellStyle.Font = New Font("Poppins", 9, FontStyle.Bold)
                    
                Case "requestid"
                    col.HeaderText = "Req ID"
                    col.Visible = True
                    col.Width = 70
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    col.DefaultCellStyle.ForeColor = Color.FromArgb(13, 110, 253) ' Blue for links
                    
                Case "propertyitemname"
                    col.HeaderText = "Property Item"
                    col.Visible = True
                    col.MinimumWidth = 180
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    col.DefaultCellStyle.Font = New Font("Poppins", 9, FontStyle.Bold)
                    
                Case "serialnumber"
                    col.HeaderText = "Serial Number"
                    col.Visible = True
                    col.Width = 110
                    col.DefaultCellStyle.Font = New Font("Consolas", 9) ' Monospace for serial numbers
                    
                Case "location"
                    col.HeaderText = "Location"
                    col.Visible = True
                    col.Width = 140
                    
                Case "departmentid"
                    col.HeaderText = "Department"
                    col.Visible = True
                    col.Width = 140
                    
                Case "conditionbeforemaint"
                    col.HeaderText = "Initial Condition"
                    col.Visible = True
                    col.Width = 130
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    
                Case "typeofmaintenance"
                    col.HeaderText = "Type"
                    col.Visible = True
                    col.Width = 90
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    col.DefaultCellStyle.Font = New Font("Poppins", 9, FontStyle.Bold)
                    
                Case "assignedtechnician"
                    col.HeaderText = "Technician"
                    col.Visible = True
                    col.Width = 150
                    col.DefaultCellStyle.ForeColor = Color.FromArgb(111, 66, 193) ' Purple for people
                    
                Case "maintenancedate"
                    col.HeaderText = "Date"
                    col.Visible = True
                    col.Width = 110
                    col.DefaultCellStyle.Format = "MMM dd, yyyy"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    
                Case "maintenancedetail"
                    col.HeaderText = "Details"
                    col.Visible = False ' Hide by default, too long for grid
                    
                Case "costmaterialslabor"
                    col.HeaderText = "Cost (₱)"
                    col.Visible = True
                    col.Width = 110
                    col.DefaultCellStyle.Format = "#,##0.00"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Font = New Font("Poppins", 9, FontStyle.Bold)
                    col.DefaultCellStyle.ForeColor = Color.FromArgb(220, 53, 69) ' Red for cost
                    
                Case "conditionaftermaint"
                    col.HeaderText = "After Condition"
                    col.Visible = True
                    col.Width = 130
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    
                Case "status"
                    col.HeaderText = "Status"
                    col.Visible = True
                    col.Width = 110
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    col.DefaultCellStyle.Font = New Font("Poppins", 9, FontStyle.Bold)
                    
                Case "diagnosis"
                    col.HeaderText = "Diagnosis"
                    col.Visible = False ' Too detailed for main view
                    
                Case "actiontaken"
                    col.HeaderText = "Action Taken"
                    col.Visible = False ' Show in detail view
                    
                Case "partsreplaced"
                    col.HeaderText = "Parts Replaced"
                    col.Visible = False ' Show in detail view
                    
                Case Else
                    col.Visible = False
            End Select
        Next
    End Sub

    ' ================================================================
    ' LOAD MAINTENANCE DATA FROM DATABASE
    ' ================================================================
    Private Sub LoadMaintenanceData()
        Try
            ' Get maintenance data using modDB
            Dim maintenanceData As DataTable = modDB.GetAllMaintenance()
            
            If maintenanceData Is Nothing Then
                MessageBox.Show("Unable to load maintenance records. Please check your database connection.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                originalData = Nothing
                DataGridView1.DataSource = Nothing
                ttlMaintenancemanagement.Text = "0"
                Return
            End If
            
            ' Store original data for filtering
            originalData = maintenanceData.Copy()
            
            ' Bind to DataGridView
            DataGridView1.DataSource = maintenanceData
            
            ' Update total count
            ttlMaintenancemanagement.Text = maintenanceData.Rows.Count.ToString()
            
            ' Apply status-based row coloring
            ApplyStatusColoring()
            
            System.Diagnostics.Debug.WriteLine($"[UC_MaintenanceManagement] Loaded {maintenanceData.Rows.Count} maintenance records")
            
        Catch ex As Exception
            MessageBox.Show("Error loading maintenance data: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ttlMaintenancemanagement.Text = "0"
        End Try
    End Sub

    ' ================================================================
    ' APPLY STATUS-BASED ROW COLORING - Modern Professional Design
    ' ================================================================
    Private Sub ApplyStatusColoring()
        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells("status").Value IsNot Nothing Then
                    Dim status As String = row.Cells("status").Value.ToString().ToLower()
                    
                    Select Case status
                        Case "ongoing"
                            ' Modern yellow/amber - In Progress
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205) ' Soft yellow
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(102, 77, 3) ' Dark amber text
                            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 193, 7) ' Bootstrap warning
                            row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 37, 41)
                            
                        Case "completed"
                            ' Modern green - Success
                            row.DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 218) ' Soft green
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(21, 87, 36) ' Dark green text
                            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(25, 135, 84) ' Bootstrap success
                            row.DefaultCellStyle.SelectionForeColor = Color.White
                            
                        Case "for review"
                            ' Modern red - Needs Attention
                            row.DefaultCellStyle.BackColor = Color.FromArgb(248, 215, 218) ' Soft red
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(114, 28, 36) ' Dark red text
                            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 53, 69) ' Bootstrap danger
                            row.DefaultCellStyle.SelectionForeColor = Color.White
                    End Select
                    
                    ' Add status badge indicator in the status cell
                    If row.Cells("status").Style IsNot Nothing Then
                        row.Cells("status").Style.Font = New Font("Poppins", 9, FontStyle.Bold)
                        row.Cells("status").Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End If
                End If
            Next
        Catch ex As Exception
            ' Silently fail on coloring errors
            System.Diagnostics.Debug.WriteLine($"[UC_MaintenanceManagement] Status coloring error: {ex.Message}")
        End Try
    End Sub

    ' ================================================================
    ' INITIALIZE FILTERS
    ' ================================================================
    Private Sub InitializeFilters()
        Try
            ' Set default filter values
            If cmbStatusFilter IsNot Nothing Then
                cmbStatusFilter.SelectedIndex = 0 ' "All Status"
            End If
            
            If cmbTypeFilter IsNot Nothing Then
                cmbTypeFilter.SelectedIndex = 0 ' "All Types"
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[UC_MaintenanceManagement] InitializeFilters error: {ex.Message}")
        End Try
    End Sub

    ' ================================================================
    ' SEARCH FUNCTIONALITY
    ' ================================================================
    Private Sub SetupSearchFunctionality()
        ' Wire up the search textbox
        If maintenancemanagementsearchbar IsNot Nothing Then
            AddHandler maintenancemanagementsearchbar.TextChanged, AddressOf SearchTextChanged
        End If
    End Sub

    Private Sub SearchTextChanged(sender As Object, e As EventArgs)
        ApplyFilters()
    End Sub

    ' ================================================================
    ' FILTER EVENT HANDLERS
    ' ================================================================
    Private Sub cmbStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatusFilter.SelectedIndexChanged
        If Not isFiltering Then
            ApplyFilters()
        End If
    End Sub

    Private Sub cmbTypeFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeFilter.SelectedIndexChanged
        If Not isFiltering Then
            ApplyFilters()
        End If
    End Sub

    ' ================================================================
    ' APPLY ALL FILTERS (Search, Status, Type)
    ' ================================================================
    Private Sub ApplyFilters()
        If isSearching OrElse isFiltering Then Return
        
        Try
            isSearching = True
            isFiltering = True
            
            ' Get filter values
            Dim searchText As String = If(maintenancemanagementsearchbar IsNot Nothing, maintenancemanagementsearchbar.Text.Trim().ToLower(), "")
            Dim statusFilter As String = If(cmbStatusFilter IsNot Nothing AndAlso cmbStatusFilter.SelectedIndex > 0, cmbStatusFilter.SelectedItem.ToString(), "")
            Dim typeFilter As String = If(cmbTypeFilter IsNot Nothing AndAlso cmbTypeFilter.SelectedIndex > 0, cmbTypeFilter.SelectedItem.ToString(), "")
            
            ' Start with original data
            If originalData Is Nothing OrElse originalData.Rows.Count = 0 Then
                DataGridView1.DataSource = Nothing
                ttlMaintenancemanagement.Text = "0"
                Return
            End If
            
            ' Apply filters
            Dim filteredData = originalData.AsEnumerable().Where(Function(row)
                ' Search filter
                Dim matchesSearch As Boolean = True
                If Not String.IsNullOrEmpty(searchText) Then
                    Dim itemName As String = If(row.Table.Columns.Contains("propertyItemName") AndAlso Not IsDBNull(row("propertyItemName")), row("propertyItemName").ToString().ToLower(), "")
                    Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString().ToLower(), "")
                    Dim technician As String = If(row.Table.Columns.Contains("assignedTechnician") AndAlso Not IsDBNull(row("assignedTechnician")), row("assignedTechnician").ToString().ToLower(), "")
                    Dim status As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString().ToLower(), "")
                    Dim typeOfMaint As String = If(row.Table.Columns.Contains("typeOfMaintenance") AndAlso Not IsDBNull(row("typeOfMaintenance")), row("typeOfMaintenance").ToString().ToLower(), "")
                    Dim serialNum As String = If(row.Table.Columns.Contains("serialNumber") AndAlso Not IsDBNull(row("serialNumber")), row("serialNumber").ToString().ToLower(), "")
                    
                    matchesSearch = itemName.Contains(searchText) OrElse 
                                   location.Contains(searchText) OrElse 
                                   technician.Contains(searchText) OrElse 
                                   status.Contains(searchText) OrElse 
                                   typeOfMaint.Contains(searchText) OrElse
                                   serialNum.Contains(searchText)
                End If
                
                ' Status filter
                Dim matchesStatus As Boolean = True
                If Not String.IsNullOrEmpty(statusFilter) Then
                    Dim rowStatus As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), "")
                    matchesStatus = rowStatus.Equals(statusFilter, StringComparison.OrdinalIgnoreCase)
                End If
                
                ' Type filter
                Dim matchesType As Boolean = True
                If Not String.IsNullOrEmpty(typeFilter) Then
                    Dim rowType As String = If(row.Table.Columns.Contains("typeOfMaintenance") AndAlso Not IsDBNull(row("typeOfMaintenance")), row("typeOfMaintenance").ToString(), "")
                    matchesType = rowType.Equals(typeFilter, StringComparison.OrdinalIgnoreCase)
                End If
                
                Return matchesSearch AndAlso matchesStatus AndAlso matchesType
            End Function).ToList()
            
            ' Update DataGridView
            If filteredData.Count > 0 Then
                Dim filteredTable As DataTable = filteredData.CopyToDataTable()
                DataGridView1.DataSource = filteredTable
                ttlMaintenancemanagement.Text = filteredTable.Rows.Count.ToString()
            Else
                DataGridView1.DataSource = Nothing
                ttlMaintenancemanagement.Text = "0"
            End If
            
            ApplyStatusColoring()
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[UC_MaintenanceManagement] ApplyFilters error: {ex.Message}")
        Finally
            isSearching = False
            isFiltering = False
        End Try
    End Sub

    ' ================================================================
    ' PERMISSION-BASED BUTTON STATES
    ' ================================================================
    Private Sub ApplyPermissions()
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse 
                                       SessionContext.IsAdmin() OrElse 
                                       SessionContext.IsCustodian()
        
        btnDelete.Visible = SessionContext.IsSuperAdmin() ' Only SuperAdmin can delete
        btnDelete.Enabled = hasFullAccess
        
        btnEdit.Visible = True
        btnEdit.Enabled = hasFullAccess ' Admin/SuperAdmin/Custodian can edit
        
        btnRefresh.Visible = True
        btnRefresh.Enabled = True ' Everyone can refresh
        
        btnGenerateMaintenance.Visible = True
        btnGenerateMaintenance.Enabled = True ' Everyone can view reports
    End Sub

    ' ================================================================
    ' BUTTON CLICK HANDLERS - Aligned with Maintenance Management Purpose
    ' ================================================================
    
    ''' <summary>
    ''' Add Maintenance - Open form to add new maintenance record
    ''' </summary>
    Private Sub btnAddMaintenance_Click(sender As Object, e As EventArgs) Handles btnAddMaintenance.Click
        Try
            ' Navigate to add maintenance form
            Dim adminDashboard = TryCast(Me.ParentForm, AdminDashboard)
            If adminDashboard IsNot Nothing Then
                Dim addForm As New AddMaintenance()
                adminDashboard.LoadUserControl(addForm)
                Return
            End If
            
            Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
            If saDashboard IsNot Nothing Then
                Dim addForm As New AddMaintenance()
                saDashboard.LoadUserControl(addForm)
                Return
            End If
            
            MessageBox.Show("Unable to open add form. Please try again.", "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error opening add maintenance form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Edit - Open edit form for selected maintenance record
    ''' </summary>
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance record to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim maintenanceID As Integer = GetSelectedMaintenanceID()
            If maintenanceID <= 0 Then Return
            
            ' Navigate to edit form
            Dim adminDashboard = TryCast(Me.ParentForm, AdminDashboard)
            If adminDashboard IsNot Nothing Then
                Dim editForm As New EditMaintenance1()
                editForm.MaintenanceID = maintenanceID
                adminDashboard.LoadUserControl(editForm)
                Return
            End If
            
            Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
            If saDashboard IsNot Nothing Then
                Dim editForm As New EditMaintenance1()
                editForm.MaintenanceID = maintenanceID
                saDashboard.LoadUserControl(editForm)
                Return
            End If
            
            MessageBox.Show("Unable to open edit form. Please try again.", "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
        Catch ex As Exception
            MessageBox.Show("Error opening edit form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Refresh - Reload maintenance data from database
    ''' </summary>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadMaintenanceData()
        MessageBox.Show("Maintenance records refreshed successfully.", "Refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Delete - Remove maintenance record (SuperAdmin only)
    ''' </summary>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not SessionContext.IsSuperAdmin() Then
            MessageBox.Show("Only Super Admins can delete maintenance records.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a maintenance record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim maintenanceID As Integer = GetSelectedMaintenanceID()
            If maintenanceID <= 0 Then Return

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this maintenance record? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result <> DialogResult.Yes Then Return

            ' Delete from database
            Dim conn As MySqlConnection = modDB.GetConnection()
            If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
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
        Catch ex As Exception
            MessageBox.Show("Error deleting maintenance: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Generate Maintenance Report
    ''' </summary>
    Private Sub btnGenerateMaintenance_Click(sender As Object, e As EventArgs) Handles btnGenerateMaintenance.Click

        Try
            ' Get selected maintenance ID
            If DataGridView1.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a maintenance record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim maintenanceID As Integer = GetSelectedMaintenanceID()
            If maintenanceID <= 0 Then
                MessageBox.Show("Invalid maintenance record selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            System.Diagnostics.Debug.WriteLine($"[GenerateMaintenanceReport] Opening report for maintenance ID: {maintenanceID}")

            ' Open detailed maintenance report with selected record in a new form
            Dim reportForm As New Form()
            reportForm.Text = "Maintenance Management Report"
            reportForm.Size = New Size(1200, 900)
            reportForm.StartPosition = FormStartPosition.CenterScreen

            Dim reportControl As New MaintenanceManagementReport1(maintenanceID)
            reportControl.Dock = DockStyle.Fill
            reportForm.Controls.Add(reportControl)

            reportForm.ShowDialog()

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[GenerateMaintenanceReport] Error: {ex.Message}")
            MessageBox.Show("Error opening maintenance report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================================
    ' HELPER METHODS
    ' ================================================================
    
    Private Function GetSelectedMaintenanceID() As Integer
        Try
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim maintenanceID As Integer = 0
            
            ' Try to get from cell
            If selectedRow.Cells("maintenanceId") IsNot Nothing AndAlso selectedRow.Cells("maintenanceId").Value IsNot Nothing Then
                Integer.TryParse(selectedRow.Cells("maintenanceId").Value.ToString(), maintenanceID)
            End If
            
            ' Try from DataSource if not found
            If maintenanceID <= 0 Then
                Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
                If dt IsNot Nothing AndAlso selectedRow.Index < dt.Rows.Count Then
                    Dim dataRow As DataRow = dt.Rows(selectedRow.Index)
                    If dt.Columns.Contains("maintenanceId") AndAlso Not IsDBNull(dataRow("maintenanceId")) Then
                        Integer.TryParse(dataRow("maintenanceId").ToString(), maintenanceID)
                    End If
                End If
            End If
            
            If maintenanceID <= 0 Then
                MessageBox.Show("Invalid maintenance ID. Unable to retrieve record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            
            Return maintenanceID
        Catch ex As Exception
            MessageBox.Show("Error getting maintenance ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function
    
    Private Function GetSelectedCellValue(columnName As String) As Object
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
                If selectedRow.Cells(columnName) IsNot Nothing Then
                    Return selectedRow.Cells(columnName).Value
                End If
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ' ================================================================
    ' DATAGRIDVIEW EVENTS - Main Interaction for Maintenance Management
    ' ================================================================
    
    ''' <summary>
    ''' Double-click to edit maintenance record
    ''' This is where technicians/admins update:
    ''' - diagnosis, actionTaken, partsReplaced
    ''' - costMaterialsLabor, conditionAfterMaint
    ''' - status (Ongoing -> Completed or For Review)
    ''' </summary>
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then Return ' Ignore header clicks
        
        Try
            Dim maintenanceID As Integer = GetSelectedMaintenanceID()
            If maintenanceID <= 0 Then Return
            
            ' Get maintenance details for editing
            Dim maintenanceData As DataRow = GetMaintenanceDetails(maintenanceID)
            If maintenanceData Is Nothing Then
                MessageBox.Show("Unable to load maintenance details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            
            ' Navigate to edit form
            Dim adminDashboard = TryCast(Me.ParentForm, AdminDashboard)
            If adminDashboard IsNot Nothing Then
                Dim editForm As New EditMaintenance1()
                editForm.MaintenanceID = maintenanceID
                adminDashboard.LoadUserControl(editForm)
                Return
            End If
            
            Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
            If saDashboard IsNot Nothing Then
                Dim editForm As New EditMaintenance1()
                editForm.MaintenanceID = maintenanceID
                saDashboard.LoadUserControl(editForm)
                Return
            End If
            
            MessageBox.Show("Unable to open edit form. Please try again.", "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            
        Catch ex As Exception
            MessageBox.Show("Error opening maintenance details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    ''' <summary>
    ''' Get full maintenance details for editing
    ''' </summary>
    Private Function GetMaintenanceDetails(maintenanceID As Integer) As DataRow
        Try
            Dim conn As MySqlConnection = modDB.GetConnection()
            If conn Is Nothing Then Return Nothing
            
            If Not modDB.SafeOpenConnection(conn) Then Return Nothing
            
            Dim query As String = "SELECT m.*, d.departmentName " &
                                 "FROM maintenance m " &
                                 "LEFT JOIN departments d ON m.departmentId = d.departmentId " &
                                 "WHERE m.maintenanceId = @maintenanceID"
            
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@maintenanceID", maintenanceID)
                
                Using adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    
                    If dt.Rows.Count > 0 Then
                        Return dt.Rows(0)
                    End If
                End Using
            End Using
            
            If conn.State = ConnectionState.Open Then conn.Close()
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[UC_MaintenanceManagement] GetMaintenanceDetails error: {ex.Message}")
        End Try
        
        Return Nothing
    End Function

    Private Sub btnSummary_Click(sender As Object, e As EventArgs) Handles btnSummary.Click
        Try
            Dim summaryReport As New MaintenanceRequestSummaryReport()
            summaryReport.StartPosition = FormStartPosition.CenterScreen
            summaryReport.ShowDialog() ' Use Show() if you want non-modal
        Catch ex As Exception
            MessageBox.Show("Unable to open Maintenance Summary Report: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        End Try
    End Sub

End Class
