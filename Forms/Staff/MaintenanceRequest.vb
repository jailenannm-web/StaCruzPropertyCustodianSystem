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
End Class
