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
        btnSave.Enabled = False
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

            ' Get role filter
            If cmbLogType.SelectedIndex > 0 Then
                roleFilter = cmbLogType.Text
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
                displayTable.Columns.Add("Date & Time", GetType(DateTime))
                displayTable.Columns.Add("User ID", GetType(Integer))
                displayTable.Columns.Add("Record ID", GetType(Integer))
                displayTable.Columns.Add("Description", GetType(String))
                displayTable.Columns.Add("IP Address", GetType(String))
                displayTable.Columns.Add("User Agent", GetType(String))

                ' Populate display table
                For Each row As DataRow In dt.Rows
                    Dim newRow As DataRow = displayTable.NewRow()
                    newRow("Log ID") = If(Convert.IsDBNull(row("logId")), 0, Convert.ToInt32(row("logId")))
                    newRow("User Name") = If(Convert.IsDBNull(row("username")), "System", row("username").ToString())
                    newRow("Role") = If(Convert.IsDBNull(row("role")), "Unknown", row("role").ToString())
                    newRow("Action") = If(Convert.IsDBNull(row("action")), "", row("action").ToString())
                    newRow("Module") = If(Convert.IsDBNull(row("module")), "", row("module").ToString())
                    newRow("Date & Time") = If(Convert.IsDBNull(row("createdAt")), Date.Now, Convert.ToDateTime(row("createdAt")))
                    newRow("User ID") = If(Convert.IsDBNull(row("userId")), 0, Convert.ToInt32(row("userId")))
                    newRow("Record ID") = If(Convert.IsDBNull(row("recordId")), 0, Convert.ToInt32(row("recordId")))
                    newRow("Description") = If(Convert.IsDBNull(row("description")), "", row("description").ToString())
                    newRow("IP Address") = If(Convert.IsDBNull(row("ipAddress")), "", row("ipAddress").ToString())
                    newRow("User Agent") = If(Convert.IsDBNull(row("userAgent")), "", row("userAgent").ToString())
                    displayTable.Rows.Add(newRow)
                Next

                ' Bind to DataGridView
                DataGridView1.DataSource = displayTable

                ' Configure column visibility - show only required columns in correct order
                ' Required display columns: User Name, Role, Action, Module, Date & Time
                Dim columnOrder As New List(Of String) From {"User Name", "Role", "Action", "Module", "Date & Time"}

                ' Hide technical columns but keep them for data access
                If DataGridView1.Columns.Contains("Log ID") Then DataGridView1.Columns("Log ID").Visible = False
                If DataGridView1.Columns.Contains("User ID") Then DataGridView1.Columns("User ID").Visible = False
                If DataGridView1.Columns.Contains("Record ID") Then DataGridView1.Columns("Record ID").Visible = False
                If DataGridView1.Columns.Contains("Description") Then DataGridView1.Columns("Description").Visible = False
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
            Else
                ' Don't show message if it's just an empty result - user might be filtering
                ' Only show if it's the initial load with no filters
                If cmbLogType.SelectedIndex = 0 AndAlso dtFrom.Value.Date = Date.Today.AddDays(-30).Date AndAlso dtTo.Value.Date = Date.Today.Date Then
                    ' This is likely the initial load
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading audit logs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        If Not selectedLogId.HasValue Then
            MessageBox.Show("Please select an audit record to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' Open audit report form with selected log ID
            Dim auditReportForm As New AuditReportAdmin()
            auditReportForm.LoadAuditRecord(selectedLogId.Value)
            auditReportForm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error opening audit report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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
