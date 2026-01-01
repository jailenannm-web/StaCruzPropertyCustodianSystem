Imports System
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class audit
    Inherits UserControl

    Private currentPage As Integer = 1
    Private pageSize As Integer = 50
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 0

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub audit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeControls()
        LoadAuditLogs()
    End Sub

    Private Sub InitializeControls()
        ' Setup DataGridView
        With dgvAuditLogs
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .RowHeadersVisible = False
            .EnableHeadersVisualStyles = False
            .AllowUserToResizeRows = False
            
            ' Column Header Style
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ColumnHeadersHeight = 40
            
            ' Alternating Row Colors
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250)
            .RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185)
            .RowsDefaultCellStyle.SelectionForeColor = Color.White
            .RowsDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9)
            .RowTemplate.Height = 35
            
            ' Clear existing columns
            .Columns.Clear()
            
            ' Add columns matching audit_logs schema
            .Columns.Add(CreateColumn("logId", "Log ID", 80))
            .Columns.Add(CreateColumn("userId", "User ID", 80))
            .Columns.Add(CreateColumn("userName", "User Name", 150))
            .Columns.Add(CreateColumn("userRole", "User Role", 110))
            .Columns.Add(CreateColumn("action", "Action", 120))
            .Columns.Add(CreateColumn("tableName", "Table", 150))
            .Columns.Add(CreateColumn("recordId", "Record ID", 90))
            .Columns.Add(CreateColumn("description", "Description", 250))
            .Columns.Add(CreateColumn("ipAddress", "IP Address", 120))
            .Columns.Add(CreateColumn("createdAt", "Date/Time", 160))
        End With
        
        ' Setup filter dropdowns
        cboAction.Items.Clear()
        cboAction.Items.Add("All Actions")
        cboAction.Items.Add("Login")
        cboAction.Items.Add("Logout")
        cboAction.Items.Add("Create")
        cboAction.Items.Add("Update")
        cboAction.Items.Add("Delete")
        cboAction.Items.Add("View")
        cboAction.Items.Add("Export")
        cboAction.SelectedIndex = 0
        
        cboTable.Items.Clear()
        cboTable.Items.Add("All Tables")
        cboTable.Items.Add("users")
        cboTable.Items.Add("properties")
        cboTable.Items.Add("supplies")
        cboTable.Items.Add("maintenance")
        cboTable.Items.Add("departments")
        cboTable.Items.Add("property_requests")
        cboTable.Items.Add("supplies_requests")
        cboTable.Items.Add("maintenance_requests")
        cboTable.SelectedIndex = 0
        
        ' Date filters
        dtpFrom.Value = DateTime.Now.AddDays(-30)
        dtpTo.Value = DateTime.Now
        
        ' Page info
        UpdatePageInfo()
    End Sub

    Private Function CreateColumn(dataPropertyName As String, headerText As String, width As Integer) As DataGridViewTextBoxColumn
        Dim col As New DataGridViewTextBoxColumn()
        col.DataPropertyName = dataPropertyName
        col.HeaderText = headerText
        col.Width = width
        col.SortMode = DataGridViewColumnSortMode.NotSortable
        Return col
    End Function

    Private Sub LoadAuditLogs()
        Try
            Cursor = Cursors.WaitCursor
            
            Dim query As String = BuildQuery()
            
            Dim conn As MySqlConnection = modDB.GetConnection()
            If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
                
                ' Get total count
                Dim countQuery As String = BuildCountQuery()
                Using countCmd As New MySqlCommand(countQuery, conn)
                    AddQueryParameters(countCmd)
                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
                End Using
                
                ' Calculate total pages
                totalPages = Math.Ceiling(totalRecords / pageSize)
                If totalPages = 0 Then totalPages = 1
                
                ' Get data for current page
                Using cmd As New MySqlCommand(query, conn)
                    AddQueryParameters(cmd)
                    cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize)
                    cmd.Parameters.AddWithValue("@limit", pageSize)
                    
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvAuditLogs.DataSource = dt
                    End Using
                End Using
                
                conn.Close()
            End If
            
            UpdatePageInfo()
            UpdateRecordCount()
            
        Catch ex As Exception
            MessageBox.Show($"Error loading audit logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function BuildQuery() As String
        Dim sql As New StringBuilder()
        sql.AppendLine("SELECT ")
        sql.AppendLine("    a.logId,")
        sql.AppendLine("    a.userId,")
        sql.AppendLine("    COALESCE(CONCAT(u.firstName, ' ', u.lastName), 'System') as userName,")
        sql.AppendLine("    a.userAgent as userRole,")
        sql.AppendLine("    a.action,")
        sql.AppendLine("    a.tableName,")
        sql.AppendLine("    a.recordId,")
        sql.AppendLine("    a.description,")
        sql.AppendLine("    a.ipAddress,")
        sql.AppendLine("    DATE_FORMAT(a.createdAt, '%Y-%m-%d %H:%i:%s') as createdAt")
        sql.AppendLine("FROM audit_logs a")
        sql.AppendLine("LEFT JOIN users u ON a.userId = u.userId")
        sql.AppendLine("WHERE 1=1")
        
        ' Add filters
        If cboAction.SelectedIndex > 0 Then
            sql.AppendLine("AND a.action = @action")
        End If
        
        If cboTable.SelectedIndex > 0 Then
            sql.AppendLine("AND a.tableName = @tableName")
        End If
        
        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            sql.AppendLine("AND (a.description LIKE @search OR a.ipAddress LIKE @search OR CONCAT(u.firstName, ' ', u.lastName) LIKE @search)")
        End If
        
        If chkDateFilter.Checked Then
            sql.AppendLine("AND DATE(a.createdAt) BETWEEN @fromDate AND @toDate")
        End If
        
        sql.AppendLine("ORDER BY a.createdAt DESC")
        sql.AppendLine("LIMIT @limit OFFSET @offset")
        
        Return sql.ToString()
    End Function

    Private Function BuildCountQuery() As String
        Dim sql As New StringBuilder()
        sql.AppendLine("SELECT COUNT(*)")
        sql.AppendLine("FROM audit_logs a")
        sql.AppendLine("LEFT JOIN users u ON a.userId = u.userId")
        sql.AppendLine("WHERE 1=1")
        
        If cboAction.SelectedIndex > 0 Then
            sql.AppendLine("AND a.action = @action")
        End If
        
        If cboTable.SelectedIndex > 0 Then
            sql.AppendLine("AND a.tableName = @tableName")
        End If
        
        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            sql.AppendLine("AND (a.description LIKE @search OR a.ipAddress LIKE @search OR CONCAT(u.firstName, ' ', u.lastName) LIKE @search)")
        End If
        
        If chkDateFilter.Checked Then
            sql.AppendLine("AND DATE(a.createdAt) BETWEEN @fromDate AND @toDate")
        End If
        
        Return sql.ToString()
    End Function

    Private Sub AddQueryParameters(cmd As MySqlCommand)
        If cboAction.SelectedIndex > 0 Then
            cmd.Parameters.AddWithValue("@action", cboAction.SelectedItem.ToString())
        End If
        
        If cboTable.SelectedIndex > 0 Then
            cmd.Parameters.AddWithValue("@tableName", cboTable.SelectedItem.ToString())
        End If
        
        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")
        End If
        
        If chkDateFilter.Checked Then
            cmd.Parameters.AddWithValue("@fromDate", dtpFrom.Value.Date)
            cmd.Parameters.AddWithValue("@toDate", dtpTo.Value.Date)
        End If
    End Sub

    Private Sub UpdatePageInfo()
        lblPageInfo.Text = $"Page {currentPage} of {totalPages}"
        btnPrevious.Enabled = currentPage > 1
        btnNext.Enabled = currentPage < totalPages
        btnFirst.Enabled = currentPage > 1
        btnLast.Enabled = currentPage < totalPages
    End Sub

    Private Sub UpdateRecordCount()
        lblRecordCount.Text = $"Showing {dgvAuditLogs.Rows.Count} of {totalRecords} records"
    End Sub

    ' Filter and Search Events
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        currentPage = 1
        LoadAuditLogs()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtSearch.Clear()
        cboAction.SelectedIndex = 0
        cboTable.SelectedIndex = 0
        chkDateFilter.Checked = False
        dtpFrom.Value = DateTime.Now.AddDays(-30)
        dtpTo.Value = DateTime.Now
        currentPage = 1
        LoadAuditLogs()
    End Sub

    Private Sub cboAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAction.SelectedIndexChanged
        If cboAction.SelectedIndex >= 0 Then
            currentPage = 1
            LoadAuditLogs()
        End If
    End Sub

    Private Sub cboTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTable.SelectedIndexChanged
        If cboTable.SelectedIndex >= 0 Then
            currentPage = 1
            LoadAuditLogs()
        End If
    End Sub

    Private Sub chkDateFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkDateFilter.CheckedChanged
        dtpFrom.Enabled = chkDateFilter.Checked
        dtpTo.Enabled = chkDateFilter.Checked
        If chkDateFilter.Checked Then
            currentPage = 1
            LoadAuditLogs()
        End If
    End Sub

    ' Pagination Events
    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        currentPage = 1
        LoadAuditLogs()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadAuditLogs()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentPage < totalPages Then
            currentPage += 1
            LoadAuditLogs()
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        currentPage = totalPages
        LoadAuditLogs()
    End Sub

    ' Refresh
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadAuditLogs()
    End Sub

    ' Export Functions
    Private Sub btnExportCSV_Click(sender As Object, e As EventArgs) Handles btnExportCSV.Click
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV Files (*.csv)|*.csv"
            saveDialog.FileName = $"AuditLogs_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            
            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportToCSV(saveDialog.FileName)
                MessageBox.Show("Audit logs exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                
                If MessageBox.Show("Do you want to open the CSV file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Process.Start(saveDialog.FileName)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error exporting to CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToCSV(filePath As String)
        Dim csv As New StringBuilder()
        
        ' Header
        csv.AppendLine("=== AUDIT LOG REPORT ===")
        csv.AppendLine($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
        csv.AppendLine($"Total Records: {totalRecords}")
        csv.AppendLine()
        
        ' Column headers
        csv.AppendLine("Log ID,User ID,User Name,User Role,Action,Table Name,Record ID,Description,IP Address,Date/Time")
        
        ' Data rows
        For Each row As DataGridViewRow In dgvAuditLogs.Rows
            Dim values As New List(Of String)
            For Each cell As DataGridViewCell In row.Cells
                Dim value As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                values.Add($"""{value.Replace("""", """""")}""")
            Next
            csv.AppendLine(String.Join(",", values))
        Next
        
        File.WriteAllText(filePath, csv.ToString())
    End Sub

    Private Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf"
            saveDialog.FileName = $"AuditLogs_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            
            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportToPDF(saveDialog.FileName)
                MessageBox.Show("Audit logs exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                
                If MessageBox.Show("Do you want to open the PDF file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Process.Start(saveDialog.FileName)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error exporting to PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToPDF(filePath As String)
        Dim doc As New Document(iTextSharp.text.PageSize.A4.Rotate(), 30, 30, 30, 30) ' Landscape for wider table
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))
        
        doc.Open()
        
        ' Fonts
        Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD)
        Dim headerFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD)
        Dim normalFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL)
        Dim smallFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.ITALIC)
        
        ' Title
        Dim title As New Paragraph("AUDIT LOG REPORT", titleFont)
        title.Alignment = Element.ALIGN_CENTER
        title.SpacingAfter = 10
        doc.Add(title)
        
        ' Metadata
        Dim metadata As New Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}  |  Total Records: {totalRecords}", smallFont)
        metadata.Alignment = Element.ALIGN_CENTER
        metadata.SpacingAfter = 15
        doc.Add(metadata)
        
        ' Create table - now 10 columns
        Dim table As New PdfPTable(10)
        table.WidthPercentage = 100
        table.SetWidths(New Single() {0.6F, 0.6F, 1.1F, 0.9F, 0.9F, 1.1F, 0.7F, 2.2F, 0.9F, 1.2F})
        
        ' Header row
        Dim grayColor As New BaseColor(52, 73, 94)
        AddPdfHeaderCell(table, "Log ID", headerFont, grayColor)
        AddPdfHeaderCell(table, "User ID", headerFont, grayColor)
        AddPdfHeaderCell(table, "User Name", headerFont, grayColor)
        AddPdfHeaderCell(table, "User Role", headerFont, grayColor)
        AddPdfHeaderCell(table, "Action", headerFont, grayColor)
        AddPdfHeaderCell(table, "Table", headerFont, grayColor)
        AddPdfHeaderCell(table, "Record ID", headerFont, grayColor)
        AddPdfHeaderCell(table, "Description", headerFont, grayColor)
        AddPdfHeaderCell(table, "IP Address", headerFont, grayColor)
        AddPdfHeaderCell(table, "Date/Time", headerFont, grayColor)
        
        ' Data rows
        Dim rowIndex As Integer = 0
        For Each row As DataGridViewRow In dgvAuditLogs.Rows
            Dim bgColor As BaseColor = If(rowIndex Mod 2 = 0, BaseColor.WHITE, New BaseColor(245, 247, 250))
            
            For Each cell As DataGridViewCell In row.Cells
                Dim value As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                AddPdfDataCell(table, value, normalFont, bgColor)
            Next
            
            rowIndex += 1
        Next
        
        doc.Add(table)
        
        doc.Close()
    End Sub

    Private Sub AddPdfHeaderCell(table As PdfPTable, text As String, font As iTextSharp.text.Font, bgColor As BaseColor)
        Dim cell As New PdfPCell(New Phrase(text, font))
        cell.BackgroundColor = bgColor
        cell.Padding = 5
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        cell.VerticalAlignment = Element.ALIGN_MIDDLE
        ' Note: PdfPCell doesn't have ForegroundColor, color is set in the font
        Dim whiteFont As New iTextSharp.text.Font(font.Family, font.Size, font.Style, BaseColor.WHITE)
        cell.Phrase = New Phrase(text, whiteFont)
        table.AddCell(cell)
    End Sub

    Private Sub AddPdfDataCell(table As PdfPTable, text As String, font As iTextSharp.text.Font, bgColor As BaseColor)
        Dim cell As New PdfPCell(New Phrase(text, font))
        cell.BackgroundColor = bgColor
        cell.Padding = 4
        cell.VerticalAlignment = Element.ALIGN_TOP
        table.AddCell(cell)
    End Sub
End Class
