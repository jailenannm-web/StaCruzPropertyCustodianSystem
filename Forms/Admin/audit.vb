Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class audit
    Private selectedLogId As Integer? = Nothing

    Private Sub audit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize date pickers - default to last 30 days for better data visibility
        dtFrom.Value = Date.Today.AddDays(-30)
        dtTo.Value = Date.Today

        ' Initialize filter combobox
        LoadFilterOptions()

        ' Load audit logs
        LoadAuditLogs()

        ' Initially disable Export button
        btnSave.Enabled = True
        btnSave.Text = "Export / View Audit"

        ' Configure DataGridView
        ConfigureDataGridView()
    End Sub

    Private Sub ConfigureDataGridView()
        ' Set selection mode
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub LoadFilterOptions()
        ' Load Role filter options
        cmbLogType.Items.Clear()
        cmbLogType.Items.Add("All Roles")
        cmbLogType.Items.Add("Super Admin")
        cmbLogType.Items.Add("Admin")
        cmbLogType.Items.Add("Staff")
        cmbLogType.SelectedIndex = 0
    End Sub

    Private Sub LoadAuditLogs()
        Try
            ' Validate date range
            If dtTo.Value < dtFrom.Value Then
                MessageBox.Show("End date cannot be earlier than start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtTo.Value = dtFrom.Value
                Return
            End If

            Dim startDate As Date? = dtFrom.Value.Date
            Dim endDate As Date? = dtTo.Value.Date
            Dim roleFilter As String = ""
            Dim moduleFilter As String = ""
            Dim actionFilter As String = ""

            ' Get role filter - map display names to database values
            If cmbLogType.SelectedIndex > 0 Then
                Dim displayRole As String = cmbLogType.Text
                ' Map display names to database role values
                Select Case displayRole
                    Case "Super Admin"
                        roleFilter = "SuperAdmin"
                    Case "Admin"
                        roleFilter = "Admin"
                    Case "Staff"
                        roleFilter = "Staff"
                    Case Else
                        roleFilter = displayRole
                End Select
            End If

            ' Get audit logs with filters
            Dim dt As DataTable = DatabaseConnection.GetAuditLogs(startDate, endDate, roleFilter, moduleFilter, actionFilter)

            ' Clear existing data
            DataGridView1.DataSource = Nothing
            DataGridView1.Rows.Clear()

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ' Create a new DataTable with required columns for display
                Dim displayTable As New DataTable()
                displayTable.Columns.Add("Log ID", GetType(Integer))
                displayTable.Columns.Add("User Name", GetType(String))
                displayTable.Columns.Add("Role", GetType(String))
                displayTable.Columns.Add("Action", GetType(String))
                displayTable.Columns.Add("Module", GetType(String))
                displayTable.Columns.Add("Description", GetType(String))
                displayTable.Columns.Add("Date & Time", GetType(DateTime))
                displayTable.Columns.Add("User ID", GetType(Integer))
                displayTable.Columns.Add("Record ID", GetType(Integer))
                displayTable.Columns.Add("IP Address", GetType(String))
                displayTable.Columns.Add("User Agent", GetType(String))

                ' Populate display table with improved NULL handling
                For Each row As DataRow In dt.Rows
                    Dim newRow As DataRow = displayTable.NewRow()
                    newRow("Log ID") = If(Convert.IsDBNull(row("logId")), 0, Convert.ToInt32(row("logId")))
                    newRow("User Name") = If(Convert.IsDBNull(row("username")) OrElse String.IsNullOrWhiteSpace(row("username").ToString()), "System", row("username").ToString())
                    newRow("Role") = If(Convert.IsDBNull(row("role")) OrElse String.IsNullOrWhiteSpace(row("role").ToString()), "Unknown", row("role").ToString())
                    newRow("Action") = If(Convert.IsDBNull(row("action")) OrElse String.IsNullOrWhiteSpace(row("action").ToString()), "N/A", row("action").ToString())
                    newRow("Module") = If(Convert.IsDBNull(row("module")) OrElse String.IsNullOrWhiteSpace(row("module").ToString()), "N/A", row("module").ToString())
                    newRow("Description") = If(Convert.IsDBNull(row("description")) OrElse String.IsNullOrWhiteSpace(row("description").ToString()), "No description available", row("description").ToString())
                    newRow("Date & Time") = If(Convert.IsDBNull(row("createdAt")), Date.Now, Convert.ToDateTime(row("createdAt")))
                    newRow("User ID") = If(Convert.IsDBNull(row("userId")), 0, Convert.ToInt32(row("userId")))
                    newRow("Record ID") = If(Convert.IsDBNull(row("recordId")), 0, Convert.ToInt32(row("recordId")))
                    newRow("IP Address") = If(Convert.IsDBNull(row("ipAddress")) OrElse String.IsNullOrWhiteSpace(row("ipAddress").ToString()), "N/A", row("ipAddress").ToString())
                    newRow("User Agent") = If(Convert.IsDBNull(row("userAgent")) OrElse String.IsNullOrWhiteSpace(row("userAgent").ToString()), "N/A", row("userAgent").ToString())
                    displayTable.Rows.Add(newRow)
                Next

                ' Bind to DataGridView
                DataGridView1.DataSource = displayTable

                ' Configure column visibility - show required columns including Description
                ' Required display columns: User Name, Role, Action, Module, Description, Date & Time
                Dim columnOrder As New List(Of String) From {"User Name", "Role", "Action", "Module", "Description", "Date & Time"}

                ' Hide technical columns but keep them for data access
                If DataGridView1.Columns.Contains("Log ID") Then DataGridView1.Columns("Log ID").Visible = False
                If DataGridView1.Columns.Contains("User ID") Then DataGridView1.Columns("User ID").Visible = False
                If DataGridView1.Columns.Contains("Record ID") Then DataGridView1.Columns("Record ID").Visible = False
                If DataGridView1.Columns.Contains("IP Address") Then DataGridView1.Columns("IP Address").Visible = False
                If DataGridView1.Columns.Contains("User Agent") Then DataGridView1.Columns("User Agent").Visible = False

                ' Reorder columns to match requirements
                Dim displayIndex As Integer = 0
                For Each colName As String In columnOrder
                    If DataGridView1.Columns.Contains(colName) Then
                        DataGridView1.Columns(colName).DisplayIndex = displayIndex
                        displayIndex += 1
                    End If
                Next

                ' Enable sorting
                For Each column As DataGridViewColumn In DataGridView1.Columns
                    column.SortMode = DataGridViewColumnSortMode.Automatic
                Next

                ' Format Date & Time column
                If DataGridView1.Columns.Contains("Date & Time") Then
                    DataGridView1.Columns("Date & Time").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"
                    DataGridView1.Columns("Date & Time").Width = 180
                End If

                ' Set column widths for better display
                If DataGridView1.Columns.Contains("User Name") Then DataGridView1.Columns("User Name").Width = 150
                If DataGridView1.Columns.Contains("Role") Then DataGridView1.Columns("Role").Width = 120
                If DataGridView1.Columns.Contains("Action") Then DataGridView1.Columns("Action").Width = 150
                If DataGridView1.Columns.Contains("Module") Then DataGridView1.Columns("Module").Width = 150
                If DataGridView1.Columns.Contains("Description") Then
                    DataGridView1.Columns("Description").Width = 300
                    DataGridView1.Columns("Description").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                End If
            Else
                ' Show message if no records found
                DataGridView1.DataSource = Nothing
                DataGridView1.Rows.Clear()
                MessageBox.Show("No audit records found for the selected criteria.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading audit logs: " & ex.Message & Environment.NewLine & 
                          "Please check your database connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[Audit] LoadAuditLogs Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
                If selectedRow IsNot Nothing AndAlso selectedRow.Cells("Log ID").Value IsNot Nothing AndAlso Not Convert.IsDBNull(selectedRow.Cells("Log ID").Value) Then
                    selectedLogId = Convert.ToInt32(selectedRow.Cells("Log ID").Value)
                    btnSave.Enabled = True
                Else
                    selectedLogId = Nothing
                    btnSave.Enabled = False
                End If
            Else
                selectedLogId = Nothing
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            selectedLogId = Nothing
            btnSave.Enabled = False
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If e.RowIndex >= 0 AndAlso e.RowIndex < DataGridView1.Rows.Count Then
                Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                If selectedRow IsNot Nothing AndAlso selectedRow.Cells("Log ID").Value IsNot Nothing AndAlso Not Convert.IsDBNull(selectedRow.Cells("Log ID").Value) Then
                    selectedLogId = Convert.ToInt32(selectedRow.Cells("Log ID").Value)
                    btnSave.Enabled = True
                Else
                    selectedLogId = Nothing
                    btnSave.Enabled = False
                End If
            End If
        Catch ex As Exception
            selectedLogId = Nothing
            btnSave.Enabled = False
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Check if DataGridView has data
            If DataGridView1.DataSource Is Nothing OrElse DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("No audit records available to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Check if a single record is selected
            If selectedLogId.HasValue Then
                ' Single record selected - show export options
                Dim result As DialogResult = MessageBox.Show(
                    "Single record selected. Choose export option:" & Environment.NewLine & Environment.NewLine &
                    "Yes - Export to CSV" & Environment.NewLine &
                    "No - Export to PDF (Detailed Format)" & Environment.NewLine &
                    "Cancel - View details or cancel",
                    "Export Audit Record",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    ' Export single record to CSV
                    ExportSingleRecordToCsv(selectedLogId.Value)
                ElseIf result = DialogResult.No Then
                    ' Export single record to PDF in detailed format
                    ExportSingleRecordToPdf(selectedLogId.Value)
                ElseIf result = DialogResult.Cancel Then
                    ' View selected record details
                    Dim auditReportForm As New AuditReportAdmin()
                    auditReportForm.LoadAuditRecord(selectedLogId.Value)
                    auditReportForm.ShowDialog()
                End If
            Else
                ' No selection - show bulk export options
                Dim result As DialogResult = MessageBox.Show(
                    "Export all visible audit records:" & Environment.NewLine & Environment.NewLine &
                    "Yes - Export to CSV" & Environment.NewLine &
                    "No - Export to PDF" & Environment.NewLine &
                    "Cancel - Cancel operation",
                    "Export Audit Logs",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    ' Export all to CSV
                    ExportAllAuditLogs(True)
                ElseIf result = DialogResult.No Then
                    ' Export all to PDF
                    ExportAllAuditLogs(False)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportSingleRecordToCsv(logId As Integer)
        Try
            Dim auditData As DataRow = DatabaseConnection.GetAuditLogById(logId)
            If auditData Is Nothing Then
                MessageBox.Show("Audit record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Create detailed export table
            Dim exportTable As DataTable = AuditReportAdmin.CreateExportTableFromDataRow(auditData)
            Dim logIdStr As String = If(Convert.IsDBNull(auditData("logId")), DateTime.Now.ToString("yyyyMMdd_HHmmss"), auditData("logId").ToString())
            Dim fileName As String = "audit_report_" & logIdStr & ".csv"

            ReportExportHelper.ExportDataTableToCsv(exportTable, fileName, 
                "Audit report exported successfully to CSV.", False)
        Catch ex As Exception
            MessageBox.Show("Error exporting CSV: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportSingleRecordToPdf(logId As Integer)
        Try
            Dim auditData As DataRow = DatabaseConnection.GetAuditLogById(logId)
            If auditData Is Nothing Then
                MessageBox.Show("Audit record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Create detailed export table
            Dim exportTable As DataTable = AuditReportAdmin.CreateExportTableFromDataRow(auditData)
            Dim logIdStr As String = If(Convert.IsDBNull(auditData("logId")), DateTime.Now.ToString("yyyyMMdd_HHmmss"), auditData("logId").ToString())
            Dim fileName As String = "audit_report_" & logIdStr & ".pdf"

            ReportExportHelper.ExportDataTableToPdf(exportTable, fileName, 
                "Sta Cruz Property Custodian System - Audit Report", 
                "Audit report exported successfully to PDF.")
        Catch ex As Exception
            MessageBox.Show("Error exporting PDF: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportAllAuditLogs(exportToCsv As Boolean)
        Try
            ' Get the DataTable from DataGridView
            Dim sourceTable As DataTable = TryCast(DataGridView1.DataSource, DataTable)
            If sourceTable Is Nothing OrElse sourceTable.Rows.Count = 0 Then
                MessageBox.Show("No audit records available to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Create export table with only columns that have data
            Dim exportTable As DataTable = CreateBulkExportTable(sourceTable, Not exportToCsv)

            If exportToCsv Then
                ' Export to CSV
                Dim fileName As String = "audit_logs_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
                ReportExportHelper.ExportDataTableToCsv(exportTable, fileName, 
                    $"Successfully exported {sourceTable.Rows.Count} audit record(s) to CSV.", True)
            Else
                ' Export to PDF
                Dim fileName As String = "audit_logs_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".pdf"
                ReportExportHelper.ExportDataTableToPdf(exportTable, fileName, 
                    "Sta Cruz Property Custodian System - Audit Log Report",
                    $"Successfully exported {sourceTable.Rows.Count} audit record(s) to PDF.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting audit logs: " & ex.Message & Environment.NewLine & 
                          "Stack Trace: " & ex.StackTrace, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CreateBulkExportTable(sourceTable As DataTable, filterEmptyColumns As Boolean) As DataTable
        Dim exportTable As New DataTable()
        exportTable.TableName = "Audit Logs"

        Try
            ' Build a list of visible columns with their mappings
            ' Use a dictionary to track unique column names and handle duplicates
            Dim visibleColumnInfo As New List(Of Tuple(Of String, String, Type))() ' (sourceColumnName, exportColumnName, dataType)
            Dim headerTextCount As New Dictionary(Of String, Integer)() ' Tracks how many times each header text appears
            Dim usedColumnNames As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) ' Track used column names to prevent duplicates
            
            ' First, collect all visible columns from DataGridView
            For Each col As DataGridViewColumn In DataGridView1.Columns
                If col.Visible Then
                    Dim colName As String = col.Name
                    Dim headerText As String = col.HeaderText
                    
                    ' Skip if source table doesn't have this column
                    If Not sourceTable.Columns.Contains(colName) Then Continue For
                    
                    Dim dataType As Type = sourceTable.Columns(colName).DataType
                    
                    ' Create unique column name for export
                    Dim uniqueColumnName As String = headerText
                    
                    ' Check for duplicate header texts
                    If headerTextCount.ContainsKey(headerText) Then
                        headerTextCount(headerText) += 1
                        uniqueColumnName = headerText & "_" & headerTextCount(headerText).ToString()
                    Else
                        headerTextCount(headerText) = 1
                    End If
                    
                    ' Ensure the column name is unique (case-insensitive check)
                    Dim finalColumnName As String = uniqueColumnName
                    Dim counter As Integer = 1
                    While usedColumnNames.Contains(finalColumnName)
                        finalColumnName = uniqueColumnName & "_" & counter.ToString()
                        counter += 1
                    End While
                    usedColumnNames.Add(finalColumnName)
                    
                    ' Store the mapping
                    visibleColumnInfo.Add(New Tuple(Of String, String, Type)(colName, finalColumnName, dataType))
                End If
            Next

            ' If filtering empty columns, check which columns have data
            Dim columnsWithData As New HashSet(Of String)()
            If filterEmptyColumns Then
                ' Check each column to see if it has any non-empty data
                For Each colInfo In visibleColumnInfo
                    Dim sourceColName As String = colInfo.Item1
                    Dim hasData As Boolean = False
                    
                    For Each sourceRow As DataRow In sourceTable.Rows
                        If sourceTable.Columns.Contains(sourceColName) Then
                            Dim value As Object = sourceRow(sourceColName)
                            If Not Convert.IsDBNull(value) Then
                                Dim strValue As String = value.ToString()
                                If Not String.IsNullOrWhiteSpace(strValue) AndAlso strValue <> "0" AndAlso strValue <> "N/A" Then
                                    hasData = True
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                    
                    If hasData Then
                        columnsWithData.Add(colInfo.Item2)
                    End If
                Next
            Else
                ' Include all columns
                For Each colInfo In visibleColumnInfo
                    columnsWithData.Add(colInfo.Item2)
                Next
            End If

            ' Add only columns with data to export table
            For Each colInfo In visibleColumnInfo
                If columnsWithData.Contains(colInfo.Item2) Then
                    exportTable.Columns.Add(colInfo.Item2, colInfo.Item3)
                End If
            Next

            ' Add rows from source table
            For Each sourceRow As DataRow In sourceTable.Rows
                Dim newRow As DataRow = exportTable.NewRow()
                
                For Each colInfo In visibleColumnInfo
                    ' Only process columns that are in the export table
                    If Not columnsWithData.Contains(colInfo.Item2) Then Continue For
                    
                    Dim sourceColName As String = colInfo.Item1
                    Dim exportColName As String = colInfo.Item2
                    
                    If sourceTable.Columns.Contains(sourceColName) Then
                        Dim value As Object = sourceRow(sourceColName)
                        If Convert.IsDBNull(value) Then
                            newRow(exportColName) = ""
                        Else
                            ' Format DateTime values properly
                            If TypeOf value Is DateTime Then
                                newRow(exportColName) = Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss")
                            Else
                                newRow(exportColName) = value.ToString()
                            End If
                        End If
                    Else
                        newRow(exportColName) = ""
                    End If
                Next
                
                exportTable.Rows.Add(newRow)
            Next
        Catch ex As Exception
            MessageBox.Show("Error creating export table: " & ex.Message & Environment.NewLine & 
                          "Please ensure the DataGrid is properly configured.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw
        End Try

        Return exportTable
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Return to previous view or close
        Me.Parent?.Controls.Remove(Me)
    End Sub

    Private Sub dtFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtFrom.ValueChanged
        LoadAuditLogs()
    End Sub

    Private Sub dtTo_ValueChanged(sender As Object, e As EventArgs) Handles dtTo.ValueChanged
        LoadAuditLogs()
    End Sub

    Private Sub cmbLogType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLogType.SelectedIndexChanged
        LoadAuditLogs()
    End Sub
End Class
