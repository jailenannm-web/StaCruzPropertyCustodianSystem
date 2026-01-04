Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Partial Public Class MaintenanceRequest
    Inherits UserControl
    Private allMaintenanceData As DataTable ' Store all data for filtering
    
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub MaintenanceRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize comboboxes with filter options
        InitializeFilters()
        ' Load all maintenance requests
        LoadMaintenanceRequests()
    End Sub

    Private Sub InitializeFilters()
        Try
            ' Initialize Status filter
            pm_cbobx_status.Items.Clear()
            pm_cbobx_status.Items.Add("All")
            pm_cbobx_status.Items.Add("Pending")
            pm_cbobx_status.Items.Add("In Progress")
            pm_cbobx_status.Items.Add("Completed")
            pm_cbobx_status.Items.Add("Cancelled")
            pm_cbobx_status.SelectedIndex = 0

            ' Initialize Category filter
            pm_cbobx_categ.Items.Clear()
            pm_cbobx_categ.Items.Add("All")
            pm_cbobx_categ.Items.Add("Repair")
            pm_cbobx_categ.Items.Add("Replacement")
            pm_cbobx_categ.Items.Add("Maintenance")
            pm_cbobx_categ.Items.Add("Servicing")
            pm_cbobx_categ.SelectedIndex = 0
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] InitializeFilters Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadMaintenanceRequests()
        Try
            ' Check session and try to restore if needed
            If Not SessionContext.CurrentUserID.HasValue OrElse SessionContext.CurrentUserID.Value <= 0 Then
                MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Load maintenance requests for the current staff member
            allMaintenanceData = modDB.GetStaffMaintenanceRequests(SessionContext.CurrentUserID.Value)

            ' Use DataBinding instead of manual row addition for correct data mapping
            DataGridView1.AutoGenerateColumns = False
            DataGridView1.DataSource = Nothing
            
            ' Map DataGridView columns to database columns using DataPropertyName
            ' This ensures data appears in correct columns
            For Each col As DataGridViewColumn In DataGridView1.Columns
                Select Case col.Index
                    Case 0 ' PropertID column -> Property/Item Name
                        col.DataPropertyName = "itemName"
                        col.HeaderText = "Property/Item Name"
                    Case 1 ' PropertyName column -> Serial No.
                        col.DataPropertyName = "serialNumber"
                        col.HeaderText = "Serial No."
                    Case 2 ' Category column -> Location
                        col.DataPropertyName = "location"
                        col.HeaderText = "Location"
                    Case 3 ' Description column -> Department
                        col.DataPropertyName = "department"
                        col.HeaderText = "Department"
                    Case 4 ' SerialNumber column -> Condition Before
                        col.DataPropertyName = "conditionBefore"
                        col.HeaderText = "Condition Before"
                    Case 5 ' AcquisitionDate column -> Type of Issue
                        col.DataPropertyName = "typeOfIssue"
                        col.HeaderText = "Type of Issue"
                    Case 6 ' AcquisitionCost column -> Problem Description
                        col.DataPropertyName = "problemDescription"
                        col.HeaderText = "Problem Description"
                    Case 7 ' Supplier column -> Date Requested
                        col.DataPropertyName = "dateOfRequest"
                        col.HeaderText = "Date Requested"
                        col.DefaultCellStyle.Format = "yyyy-MM-dd"
                    Case 8 ' ConditionStatus column -> Status
                        col.DataPropertyName = "status"
                        col.HeaderText = "Status"
                End Select
            Next

            ' Bind data source AFTER column mapping
            DataGridView1.DataSource = allMaintenanceData
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.ReadOnly = True
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            
            System.Diagnostics.Debug.WriteLine($"[v0] Loaded {allMaintenanceData.Rows.Count} maintenance requests for staff")
        Catch ex As Exception
            Dim errorMsg As String = "Unable to load maintenance requests. "
            If ex.Message.Contains("Connection") OrElse ex.Message.Contains("timeout") Then
                errorMsg &= "Please check your database connection."
            Else
                errorMsg &= "Please try again."
            End If
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            System.Diagnostics.Debug.WriteLine("[v0] LoadMaintenanceRequests Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' Apply search and filter to the data
    ''' </summary>
    Private Sub ApplySearchAndFilter()
        Try
            If allMaintenanceData Is Nothing OrElse allMaintenanceData.Rows.Count = 0 Then
                Return
            End If

            ' Get search term
            Dim searchTerm As String = maintenancerequestssearchbar.Text.Trim().ToLower()
            
            ' Get filter values
            Dim statusFilter As String = If(pm_cbobx_status.SelectedIndex >= 0, pm_cbobx_status.SelectedItem.ToString(), "All")
            Dim categoryFilter As String = If(pm_cbobx_categ.SelectedIndex >= 0, pm_cbobx_categ.SelectedItem.ToString(), "All")

            ' Create a DataView to filter the data
            Dim dv As New DataView(allMaintenanceData)

            ' Build filter expression
            Dim filterExpression As String = ""

            ' Add status filter
            If statusFilter <> "All" Then
                filterExpression &= "[status] = '" & statusFilter.Replace("'", "''") & "'"
            End If

            ' Add category filter (Type of Issue)
            If categoryFilter <> "All" Then
                If filterExpression <> "" Then
                    filterExpression &= " AND "
                End If
                filterExpression &= "[typeOfIssue] = '" & categoryFilter.Replace("'", "''") & "'"
            End If

            ' Apply filter expression
            If filterExpression <> "" Then
                dv.RowFilter = filterExpression
            End If

            ' If search term is provided, further filter the results
            If searchTerm <> "" Then
                Dim filteredTable As DataTable = dv.ToTable()
                Dim searchResults As New DataTable()
                searchResults = filteredTable.Clone()

                ' Search across multiple columns
                For Each row As DataRow In filteredTable.Rows
                    If SearchRowMatches(row, searchTerm) Then
                        searchResults.ImportRow(row)
                    End If
                Next

                DataGridView1.DataSource = searchResults
            Else
                ' No search term, just apply filter
                DataGridView1.DataSource = dv.ToTable()
            End If

            System.Diagnostics.Debug.WriteLine($"[v0] Applied filter: Status={statusFilter}, Category={categoryFilter}, Search={searchTerm}. Results: {DirectCast(DataGridView1.DataSource, DataTable).Rows.Count}")
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ApplySearchAndFilter Error: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Check if a row matches the search term across searchable columns
    ''' </summary>
    Private Function SearchRowMatches(row As DataRow, searchTerm As String) As Boolean
        Try
            ' Search in these columns
            Dim searchableColumns As String() = {"itemName", "serialNumber", "location", "department", "problemDescription", "status", "typeOfIssue"}

            For Each colName In searchableColumns
                If row.Table.Columns.Contains(colName) Then
                    Dim value As String = row(colName).ToString().ToLower()
                    If value.Contains(searchTerm) Then
                        Return True
                    End If
                End If
            Next

            Return False
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] SearchRowMatches Error: " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub maintenancerequestssearchbar_TextChanged(sender As Object, e As EventArgs) Handles maintenancerequestssearchbar.TextChanged
        ApplySearchAndFilter()
    End Sub

    Private Sub pm_cbobx_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pm_cbobx_status.SelectedIndexChanged
        ApplySearchAndFilter()
    End Sub

    Private Sub pm_cbobx_categ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pm_cbobx_categ.SelectedIndexChanged
        ApplySearchAndFilter()
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        ' Open form to add new maintenance request
        Dim wrapper As New Form()
        wrapper.Text = "Add Maintenance Request"
        wrapper.StartPosition = FormStartPosition.CenterScreen
        wrapper.Size = New Size(900, 600)
        wrapper.FormBorderStyle = FormBorderStyle.FixedDialog

        Dim addMaintenanceForm As New MaintenanceRequestForm()
        addMaintenanceForm.Dock = DockStyle.Fill
        wrapper.Controls.Add(addMaintenanceForm)

        wrapper.ShowDialog()

        ' Refresh data after adding request
        LoadMaintenanceRequests()
        ' Clear filters to show all
        pm_cbobx_status.SelectedIndex = 0
        pm_cbobx_categ.SelectedIndex = 0
        maintenancerequestssearchbar.Clear()
    End Sub
    
    ''' <summary>
    ''' Generate Maintenance Report - Right-click or button handler
    ''' Based on UC_MaintenanceManagement implementation
    ''' </summary>
    Private Sub GenerateMaintenanceReport()
        Try
            System.Diagnostics.Debug.WriteLine("[v0] GenerateMaintenanceReport called")
            
            ' Get selected row
            If DataGridView1.SelectedRows.Count = 0 Then
                System.Diagnostics.Debug.WriteLine("[v0] No row selected")
                MessageBox.Show("Please select a maintenance request first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            System.Diagnostics.Debug.WriteLine($"[v0] Selected row count: {DataGridView1.SelectedRows.Count}")

            ' Get the maintenance request ID from the selected row
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
            
            System.Diagnostics.Debug.WriteLine($"[v0] DataSource type: {If(dt IsNot Nothing, dt.GetType().Name, "NULL")}")
            
            If dt Is Nothing OrElse selectedRow.Index >= dt.Rows.Count Then
                System.Diagnostics.Debug.WriteLine("[v0] DataTable is null or index out of range")
                MessageBox.Show("Unable to retrieve maintenance request data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            
            System.Diagnostics.Debug.WriteLine($"[v0] DataTable has {dt.Rows.Count} rows, selected index: {selectedRow.Index}")
            ' List all column names
            Dim colNames As New System.Collections.Generic.List(Of String)
            For Each col As DataColumn In dt.Columns
                colNames.Add(col.ColumnName)
            Next
            System.Diagnostics.Debug.WriteLine($"[v0] DataTable columns: {String.Join(", ", colNames)}")
            
            Dim dataRow As DataRow = dt.Rows(selectedRow.Index)
            
            ' Get requestId from the data row
            Dim requestId As Integer = 0
            If dt.Columns.Contains("requestId") AndAlso Not IsDBNull(dataRow("requestId")) Then
                Integer.TryParse(dataRow("requestId").ToString(), requestId)
                System.Diagnostics.Debug.WriteLine($"[v0] Found requestId: {requestId}")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] requestId column not found or is NULL")
                ' Try to show what columns we have
                For Each col As DataColumn In dt.Columns
                    System.Diagnostics.Debug.WriteLine($"[v0] Available column: {col.ColumnName} = {If(IsDBNull(dataRow(col.ColumnName)), "NULL", dataRow(col.ColumnName).ToString())}")
                Next
            End If
            
            If requestId <= 0 Then
                System.Diagnostics.Debug.WriteLine("[v0] Invalid requestId")
                MessageBox.Show("Invalid maintenance request ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            System.Diagnostics.Debug.WriteLine($"[v0] Opening report for request ID: {requestId}")

            ' Check if this request has been converted to maintenance
            Dim maintenanceId As Integer = GetMaintenanceIdFromRequest(requestId)
            
            System.Diagnostics.Debug.WriteLine($"[v0] Found maintenanceId: {maintenanceId}")
            
            If maintenanceId > 0 Then
                ' Open detailed maintenance report with the maintenance record
                System.Diagnostics.Debug.WriteLine("[v0] Opening MaintenanceManagementReport1")
                Dim reportForm As New Form()
                reportForm.Text = "Maintenance Management Report"
                reportForm.Size = New Size(1200, 900)
                reportForm.StartPosition = FormStartPosition.CenterScreen
                
                Dim reportControl As New MaintenanceManagementReport1(maintenanceId)
                reportControl.Dock = DockStyle.Fill
                reportForm.Controls.Add(reportControl)
                
                reportForm.ShowDialog()
            Else
                ' No maintenance record yet, show message
                System.Diagnostics.Debug.WriteLine("[v0] No maintenance record found for this request")
                MessageBox.Show("This maintenance request has not been processed yet. A maintenance record must be created first before generating a report.", 
                               "No Maintenance Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[v0] GenerateMaintenanceReport Error: {ex.Message}")
            System.Diagnostics.Debug.WriteLine($"[v0] Stack trace: {ex.StackTrace}")
            MessageBox.Show("Error opening maintenance report: " & ex.Message & Environment.NewLine & Environment.NewLine & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    ''' <summary>
    ''' Get maintenance ID from request ID
    ''' </summary>
    Private Function GetMaintenanceIdFromRequest(requestId As Integer) As Integer
        Try
            Dim conn As MySql.Data.MySqlClient.MySqlConnection = modDB.GetConnection()
            If conn Is Nothing Then Return 0
            
            If Not modDB.SafeOpenConnection(conn) Then Return 0
            
            Dim query As String = "SELECT maintenanceId FROM maintenance WHERE requestId = @requestId LIMIT 1"
            
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@requestId", requestId)
                
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    Dim maintenanceId As Integer = 0
                    If Integer.TryParse(result.ToString(), maintenanceId) Then
                        Return maintenanceId
                    End If
                End If
            End Using
            
            If conn.State = ConnectionState.Open Then conn.Close()
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[GetMaintenanceIdFromRequest] Error: {ex.Message}")
        End Try
        
        Return 0
    End Function
    
    ''' <summary>
    ''' Handle double-click to generate report
    ''' </summary>
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        System.Diagnostics.Debug.WriteLine($"[v0] DataGridView1_CellDoubleClick fired - RowIndex: {e.RowIndex}, ColumnIndex: {e.ColumnIndex}")
        If e.RowIndex < 0 Then
            System.Diagnostics.Debug.WriteLine("[v0] Header clicked, ignoring")
            Return ' Ignore header clicks
        End If
        GenerateMaintenanceReport()
    End Sub
End Class
