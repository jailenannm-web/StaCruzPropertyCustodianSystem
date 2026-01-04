Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Public Class MaintenanceRequestSummaryReport
    Private Sub MaintenanceRequestSummaryReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dateReport.Value = DateTime.Now
        receivedDate.Value = DateTime.Now
        issuedDate.Value = DateTime.Now
        school.Text = "Sta. Cruz Elementary School"
        LoadFilterOptions()
        LoadMaintenanceData()
    End Sub

    Private Sub LoadFilterOptions()
        Try
            cboStatusFilter.Items.Clear()
            cboStatusFilter.Items.Add("All Status")
            cboStatusFilter.Items.Add("Pending")
            cboStatusFilter.Items.Add("In Progress")
            cboStatusFilter.Items.Add("Completed")
            cboStatusFilter.Items.Add("Cancelled")
            cboStatusFilter.SelectedIndex = 0
            
            cboTypeFilter.Items.Clear()
            cboTypeFilter.Items.Add("All Types")
            cboTypeFilter.Items.Add("Repair")
            cboTypeFilter.Items.Add("Replace")
            cboTypeFilter.Items.Add("Servicing")
            cboTypeFilter.SelectedIndex = 0
            
            chkDateFilter.Checked = False
            dtpDateFrom.Value = DateTime.Now.AddMonths(-1)
            dtpDateTo.Value = DateTime.Now
            dtpDateFrom.Enabled = False
            dtpDateTo.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Error loading filter options: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMaintenanceData()
        Try
            Dim query As String = "SELECT 
                m.maintenanceId,
                m.requestId,
                m.propertyItemName,
                m.serialNumber,
                m.location,
                COALESCE(d.departmentName, '') as departmentName,
                COALESCE(m.conditionBeforeMaint, '') as initialCondition,
                COALESCE(m.typeOfMaintenance, '') as maintenanceType
            FROM maintenance m
            LEFT JOIN departments d ON m.departmentId = d.departmentId
            WHERE 1=1"
            
            Dim params As New List(Of MySqlParameter)()
            
            If cboStatusFilter.SelectedIndex > 0 Then
                query &= " AND m.status = @status"
                params.Add(New MySqlParameter("@status", cboStatusFilter.SelectedItem.ToString()))
            End If
            
            If cboTypeFilter.SelectedIndex > 0 Then
                query &= " AND m.typeOfMaintenance = @type"
                params.Add(New MySqlParameter("@type", cboTypeFilter.SelectedItem.ToString()))
            End If
            
            If chkDateFilter.Checked Then
                query &= " AND DATE(m.maintenanceDate) BETWEEN @dateFrom AND @dateTo"
                params.Add(New MySqlParameter("@dateFrom", dtpDateFrom.Value.Date))
                params.Add(New MySqlParameter("@dateTo", dtpDateTo.Value.Date))
            End If
            
            query &= " ORDER BY m.maintenanceId"
            
            Dim conn As MySqlConnection = Nothing
            Try
                conn = modDB.GetConnection()
                If conn IsNot Nothing Then
                    Using cmd As New MySqlCommand(query, conn)
                        For Each param As MySqlParameter In params
                            cmd.Parameters.Add(param)
                        Next
                        
                        Using adapter As New MySqlDataAdapter(cmd)
                            Dim dt As New DataTable()
                            adapter.Fill(dt)
                            DataGridView1.Rows.Clear()
                            
                            For Each row As DataRow In dt.Rows
                                DataGridView1.Rows.Add(
                                    If(row.IsNull("maintenanceId"), "", row("maintenanceId")),
                                    If(row.IsNull("requestId"), "", row("requestId")),
                                    If(row.IsNull("propertyItemName"), "", row("propertyItemName")),
                                    If(row.IsNull("serialNumber"), "", row("serialNumber")),
                                    If(row.IsNull("location"), "", row("location")),
                                    If(row.IsNull("departmentName"), "", row("departmentName")),
                                    If(row.IsNull("initialCondition"), "", row("initialCondition")),
                                    If(row.IsNull("maintenanceType"), "", row("maintenanceType"))
                                )
                            Next
                            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                        End Using
                    End Using
                End If
            Finally
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        Catch ex As Exception
            MessageBox.Show("Error loading maintenance data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "PDF Files|*.pdf"
            dialog.FileName = $"Maintenance_Management_Summary_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    ExportToPDF(dialog.FileName)
                    MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to export PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub btnCSV_Click(sender As Object, e As EventArgs) Handles btnCSV.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "CSV Files|*.csv"
            dialog.FileName = $"Maintenance_Management_Summary_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    ExportToCSV(dialog.FileName)
                    MessageBox.Show("CSV exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to export CSV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub ExportToPDF(filePath As String)
        Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 20, 20, 40, 40)
        Dim writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))
        doc.Open()
        
        AddPDFHeader(doc)
        
        Dim infoFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL)
        Dim schoolPara As New iTextSharp.text.Paragraph($"School: {school.Text}     Date: {dateReport.Value:dddd, dd MMMM yyyy}", infoFont)
        schoolPara.Alignment = iTextSharp.text.Element.ALIGN_LEFT
        schoolPara.SpacingBefore = 15
        schoolPara.SpacingAfter = 10
        doc.Add(schoolPara)
        
        Dim pdfTable As New iTextSharp.text.pdf.PdfPTable(8)
        pdfTable.WidthPercentage = 100
        pdfTable.SetWidths(New Single() {0.8F, 0.8F, 1.5F, 1.2F, 1.2F, 1.0F, 1.2F, 1.0F})
        
        Dim headerFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8, iTextSharp.text.Font.BOLD)
        Dim cellFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7, iTextSharp.text.Font.NORMAL)
        
        Dim headers() As String = {"Maintenance ID", "Request ID", "Property Item Name", "Serial Number", "Location", "Department ID", "Condition Before Maintenance", "Type of Maintenance"}
        For Each header In headers
            Dim cell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(header, headerFont))
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            cell.Padding = 4
            pdfTable.AddCell(cell)
        Next
        
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                For i = 0 To 7
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(i).Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                Next
            End If
        Next
        
        doc.Add(pdfTable)
        doc.Add(New iTextSharp.text.Paragraph(" "))
        
        Dim signatureTable As New iTextSharp.text.pdf.PdfPTable(2)
        signatureTable.WidthPercentage = 100
        signatureTable.SpacingBefore = 20
        
        Dim receivedCell As New iTextSharp.text.pdf.PdfPCell()
        receivedCell.Border = iTextSharp.text.Rectangle.BOX
        receivedCell.Padding = 10
        Dim receivedPara As New iTextSharp.text.Paragraph()
        receivedPara.Add(New iTextSharp.text.Phrase("Received by:" & vbCrLf, infoFont))
        receivedPara.Add(New iTextSharp.text.Phrase(vbCrLf & receivedBy.Text & vbCrLf, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD)))
        receivedPara.Add(New iTextSharp.text.Phrase("Signature over Printed Name" & vbCrLf & vbCrLf, infoFont))
        receivedPara.Add(New iTextSharp.text.Phrase($"Date: {receivedDate.Value:dddd, dd MMMM yyyy}", infoFont))
        receivedCell.AddElement(receivedPara)
        signatureTable.AddCell(receivedCell)
        
        Dim issuedCell As New iTextSharp.text.pdf.PdfPCell()
        issuedCell.Border = iTextSharp.text.Rectangle.BOX
        issuedCell.Padding = 10
        Dim issuedPara As New iTextSharp.text.Paragraph()
        issuedPara.Add(New iTextSharp.text.Phrase("Issued by:" & vbCrLf, infoFont))
        issuedPara.Add(New iTextSharp.text.Phrase(vbCrLf & issuedBy.Text & vbCrLf, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD)))
        issuedPara.Add(New iTextSharp.text.Phrase("Signature over Printed Name" & vbCrLf & vbCrLf, infoFont))
        issuedPara.Add(New iTextSharp.text.Phrase($"Date: {issuedDate.Value:dddd, dd MMMM yyyy}", infoFont))
        issuedCell.AddElement(issuedPara)
        signatureTable.AddCell(issuedCell)
        
        doc.Add(signatureTable)
        doc.Close()
    End Sub

    Private Sub AddPDFHeader(doc As iTextSharp.text.Document)
        Dim headerTable As New iTextSharp.text.pdf.PdfPTable(3)
        headerTable.WidthPercentage = 100
        headerTable.SetWidths(New Single() {1.5F, 5.0F, 1.5F})
        
        Try
            Dim leftLogoPath = FindLogoPath({"divisionofcamarinesnortelogo.jpg", "logo1-removebg-preview.png"})
            If Not String.IsNullOrEmpty(leftLogoPath) Then
                Dim leftLogo = iTextSharp.text.Image.GetInstance(leftLogoPath)
                leftLogo.ScaleToFit(60F, 60F)
                headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell(leftLogo) With {.Border = 0, .HorizontalAlignment = 1})
            Else
                headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell() With {.Border = 0})
            End If
        Catch
            headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell() With {.Border = 0})
        End Try
        
        Dim centerCell As New iTextSharp.text.pdf.PdfPCell() With {.Border = 0, .HorizontalAlignment = 1}
        Dim headerPara As New iTextSharp.text.Paragraph()
        headerPara.Add(New iTextSharp.text.Chunk("Republic of the Philippines" & vbCrLf, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL)))
        headerPara.Add(New iTextSharp.text.Chunk("Department of Education" & vbCrLf, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL)))
        headerPara.Add(New iTextSharp.text.Chunk("DIVISION OF CAMARINES NORTE" & vbCrLf, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD)))
        headerPara.Add(New iTextSharp.text.Chunk("Region V - Bicol" & vbCrLf, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL)))
        headerPara.Add(New iTextSharp.text.Chunk("Sta. Cruz, Talisay, Camarines Norte", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL)))
        headerPara.Alignment = 1
        centerCell.AddElement(headerPara)
        headerTable.AddCell(centerCell)
        
        Try
            Dim rightLogoPath = FindLogoPath({"574641165_841620561884149_5934190666791988971_n-removebg-preview (1)1.png", "574641165_841620561884149_5934190666791988971_n-removebg-preview (1).png"})
            If Not String.IsNullOrEmpty(rightLogoPath) Then
                Dim rightLogo = iTextSharp.text.Image.GetInstance(rightLogoPath)
                rightLogo.ScaleToFit(60F, 60F)
                headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell(rightLogo) With {.Border = 0, .HorizontalAlignment = 1})
            Else
                headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell() With {.Border = 0})
            End If
        Catch
            headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell() With {.Border = 0})
        End Try
        
        doc.Add(headerTable)
        
        Dim title As New iTextSharp.text.Paragraph("MAINTENANCE MANAGEMENT SUMMARY", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD))
        title.Alignment = 1
        title.SpacingBefore = 15
        title.SpacingAfter = 10
        doc.Add(title)
    End Sub

    Private Function FindLogoPath(possibleNames() As String) As String
        Dim baseDir = Application.StartupPath
        Dim basePaths() = {baseDir, Path.Combine(baseDir, "..\..\.."), Path.GetFullPath(Path.Combine(baseDir, "..\..\.."))}
        For Each basePath In basePaths
            For Each fileName In possibleNames
                Dim testPaths() = {Path.Combine(basePath, "Resources\Images", fileName), Path.Combine(basePath, "Resources", "Images", fileName)}
                For Each testPath In testPaths
                    Try
                        If File.Exists(Path.GetFullPath(testPath)) Then Return Path.GetFullPath(testPath)
                    Catch
                    End Try
                Next
            Next
        Next
        Return Nothing
    End Function

    Private Sub ExportToCSV(filePath As String)
        Using writer As New StreamWriter(filePath, False, New UTF8Encoding(True))
            writer.WriteLine("REPUBLIC OF THE PHILIPPINES")
            writer.WriteLine("DEPARTMENT OF EDUCATION")
            writer.WriteLine("DIVISION OF CAMARINES NORTE")
            writer.WriteLine("Region V - Bicol")
            writer.WriteLine("Sta. Cruz, Talisay, Camarines Norte")
            writer.WriteLine()
            writer.WriteLine("MAINTENANCE MANAGEMENT SUMMARY")
            writer.WriteLine()
            writer.WriteLine($"School: {school.Text}")
            writer.WriteLine($"Report Date: {dateReport.Value:dddd, dd MMMM yyyy}")
            writer.WriteLine($"Total Records: {DataGridView1.Rows.Count}")
            writer.WriteLine()
            writer.WriteLine("=" & New String("="c, 120))
            writer.WriteLine()
            
            Dim headers = {"Maintenance ID", "Request ID", "Property Item Name", "Serial Number", "Location", "Department ID", "Condition Before Maintenance", "Type of Maintenance"}
            writer.WriteLine(String.Join(",", headers))
            
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim values As New List(Of String)
                    For i = 0 To 7
                        values.Add(EscapeCSV(row.Cells(i).Value?.ToString()))
                    Next
                    writer.WriteLine(String.Join(",", values))
                End If
            Next
            
            writer.WriteLine()
            writer.WriteLine("=" & New String("="c, 120))
            writer.WriteLine()
            writer.WriteLine("RECEIVED BY:")
            writer.WriteLine($"Name: {receivedBy.Text}")
            writer.WriteLine("Signature: ___________________________________")
            writer.WriteLine($"Date: {receivedDate.Value:dddd, dd MMMM yyyy}")
            writer.WriteLine()
            writer.WriteLine("ISSUED BY:")
            writer.WriteLine($"Name: {issuedBy.Text}")
            writer.WriteLine("Signature: ___________________________________")
            writer.WriteLine($"Date: {issuedDate.Value:dddd, dd MMMM yyyy}")
        End Using
    End Sub

    Private Function EscapeCSV(value As String) As String
        If String.IsNullOrEmpty(value) Then Return ""
        If value.Contains(",") OrElse value.Contains("""") OrElse value.Contains(vbCrLf) Then
            Return """" & value.Replace("""", """""") & """"
        End If
        Return value
    End Function

    Private Sub btn_Back_Click(sender As Object, e As EventArgs) Handles btn_Back.Click
        Me.Close()
    End Sub

    Private Sub chkDateFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkDateFilter.CheckedChanged
        dtpDateFrom.Enabled = chkDateFilter.Checked
        dtpDateTo.Enabled = chkDateFilter.Checked
    End Sub

    Private Sub btnApplyFilters_Click(sender As Object, e As EventArgs) Handles btnApplyFilters.Click
        LoadMaintenanceData()
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        cboStatusFilter.SelectedIndex = 0
        cboTypeFilter.SelectedIndex = 0
        chkDateFilter.Checked = False
        dtpDateFrom.Value = DateTime.Now.AddMonths(-1)
        dtpDateTo.Value = DateTime.Now
        LoadMaintenanceData()
    End Sub
End Class