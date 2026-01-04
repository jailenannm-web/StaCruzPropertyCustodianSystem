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

Public Class SupplyRequestSummary
    Private Sub SupplyRequestSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize date pickers
        dateReport.Value = DateTime.Now
        receivedDate.Value = DateTime.Now
        issuedDate.Value = DateTime.Now
        
        ' Set default school name
        school.Text = "Sta. Cruz Elementary School"
        
        ' Load filter options
        LoadFilterOptions()
        
        ' Load supply data automatically
        LoadSupplyData()
    End Sub

    Private Sub LoadFilterOptions()
        Try
            ' Load Categories
            cboCategoryFilter.Items.Clear()
            cboCategoryFilter.Items.Add("All Categories")
            
            ' Load Status
            cboStatusFilter.Items.Clear()
            cboStatusFilter.Items.Add("All Status")
            cboStatusFilter.Items.Add("Available")
            cboStatusFilter.Items.Add("Low Stock")
            cboStatusFilter.Items.Add("Out of Stock")
            
            ' Load categories from database
            Try
                Dim conn As MySqlConnection = modDB.GetConnection()
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    Try
                        ' Load unique categories
                        Dim dt As New DataTable()
                        Using cmd As New MySqlCommand("SELECT DISTINCT category FROM supplies WHERE category IS NOT NULL AND category <> '' ORDER BY category", conn)
                            Using adapter As New MySqlDataAdapter(cmd)
                                adapter.Fill(dt)
                            End Using
                        End Using
                        
                        For Each row As DataRow In dt.Rows
                            cboCategoryFilter.Items.Add(row("category").ToString())
                        Next
                    Finally
                        If conn.State = ConnectionState.Open Then
                            conn.Close()
                        End If
                    End Try
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("Error loading filter dropdown data: " & ex.Message)
                ' Continue with empty dropdowns if database load fails
            End Try
            
            ' Set default selections
            cboCategoryFilter.SelectedIndex = 0
            cboStatusFilter.SelectedIndex = 0
            
            ' Initialize date filters
            chkDateFilter.Checked = False
            dtpDateFrom.Value = DateTime.Now.AddMonths(-1)
            dtpDateTo.Value = DateTime.Now
            dtpDateFrom.Enabled = False
            dtpDateTo.Enabled = False
            
        Catch ex As Exception
            MessageBox.Show("Error loading filter options: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSupplyData()
        Try
            ' Build query to get all supplies with full details
            Dim query As String = "SELECT 
                s.supplyId, 
                s.itemName,
                s.category,
                s.description,
                s.quantity,
                CONCAT(COALESCE(u.firstName, ''), ' ', COALESCE(u.lastName, '')) as assignedTo,
                COALESCE(s.location, '') as location,
                COALESCE(s.stockStatus, '') as stockStatus
            FROM supplies s
            LEFT JOIN users u ON s.assignedTo = u.userId
            WHERE 1=1"
            
            ' Apply filters
            Dim params As New List(Of MySqlParameter)()
            
            ' Category filter
            If cboCategoryFilter.SelectedIndex > 0 Then
                query &= " AND s.category = @category"
                params.Add(New MySqlParameter("@category", cboCategoryFilter.SelectedItem.ToString()))
            End If
            
            ' Status filter
            If cboStatusFilter.SelectedIndex > 0 Then
                query &= " AND s.stockStatus = @status"
                params.Add(New MySqlParameter("@status", cboStatusFilter.SelectedItem.ToString()))
            End If
            
            ' Date filter (dateReceived)
            If chkDateFilter.Checked Then
                query &= " AND DATE(s.dateReceived) BETWEEN @dateFrom AND @dateTo"
                params.Add(New MySqlParameter("@dateFrom", dtpDateFrom.Value.Date))
                params.Add(New MySqlParameter("@dateTo", dtpDateTo.Value.Date))
            End If
            
            query &= " ORDER BY s.supplyId"
            
            Dim conn As MySqlConnection = Nothing
            Try
                conn = modDB.GetConnection()
                If conn IsNot Nothing Then
                    Using cmd As New MySqlCommand(query, conn)
                        ' Add parameters
                        For Each param As MySqlParameter In params
                            cmd.Parameters.Add(param)
                        Next
                        
                        Using adapter As New MySqlDataAdapter(cmd)
                            Dim dt As New DataTable()
                            adapter.Fill(dt)
                            
                            ' Clear existing rows
                            DataGridView1.Rows.Clear()
                            
                            ' Populate DataGridView with the correct columns
                            For Each row As DataRow In dt.Rows
                                DataGridView1.Rows.Add(
                                    If(row.IsNull("itemName"), "", row("itemName")),
                                    If(row.IsNull("category"), "", row("category")),
                                    If(row.IsNull("description"), "", row("description")),
                                    If(row.IsNull("quantity"), "0", row("quantity")),
                                    If(String.IsNullOrWhiteSpace(row("assignedTo").ToString()), "", row("assignedTo").ToString().Trim()),
                                    If(row.IsNull("location"), "", row("location")),
                                    If(row.IsNull("stockStatus"), "", row("stockStatus"))
                                )
                            Next
                            
                            ' Auto-resize columns
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
            MessageBox.Show("Error loading supply data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "PDF Files|*.pdf"
            dialog.FileName = $"Supply_Management_Summary_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            dialog.AddExtension = True
            dialog.DefaultExt = "pdf"
            
            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    ExportToPDF(dialog.FileName)
                    MessageBox.Show("PDF file exported successfully!", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to export PDF: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            dialog.FileName = $"Supply_Management_Summary_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            dialog.AddExtension = True
            dialog.DefaultExt = "csv"
            
            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    ExportToCSV(dialog.FileName)
                    MessageBox.Show("CSV file exported successfully!", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to export CSV: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub ExportToPDF(filePath As String)
        Try
            ' Create PDF using iTextSharp
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 20, 20, 40, 40)
            Dim writer As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))
            
            doc.Open()
            
            ' Add header
            AddPDFHeader(doc)
        
            ' Add school and date info
            Dim infoFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL)
            Dim schoolPara As New iTextSharp.text.Paragraph($"School: {school.Text}     Date: {dateReport.Value:dddd, dd MMMM yyyy}", infoFont)
            schoolPara.Alignment = iTextSharp.text.Element.ALIGN_LEFT
            schoolPara.SpacingBefore = 15
            schoolPara.SpacingAfter = 10
            doc.Add(schoolPara)
            
            ' Create table with 7 columns
            Dim pdfTable As New iTextSharp.text.pdf.PdfPTable(7)
            pdfTable.WidthPercentage = 100
            pdfTable.SetWidths(New Single() {1.8F, 1.2F, 2.0F, 0.8F, 1.5F, 1.3F, 1.0F})
            
            ' Add table headers
            Dim headerFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)
            Dim cellFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)
            
            Dim headers() As String = {"Item Name", "Category", "Description", "Quantity", "Assigned To", "Location", "Stock Status"}
            
            For Each header As String In headers
                Dim cell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(header, headerFont))
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                cell.Padding = 4
                pdfTable.AddCell(cell)
            Next
            
            ' Add data rows
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    ' Item Name
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(0).Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                    
                    ' Category
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(1).Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                    
                    ' Description
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(2).Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                    
                    ' Quantity
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(3).Value?.ToString(), "0"), cellFont)) With {.Padding = 3, .HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT})
                    
                    ' Assigned To
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(4).Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                    
                    ' Location
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(5).Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                    
                    ' Stock Status
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(6).Value?.ToString(), ""), cellFont)) With {.Padding = 3, .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER})
                End If
            Next
            
            doc.Add(pdfTable)
            
            ' Add signature section
            doc.Add(New iTextSharp.text.Paragraph(" "))
            doc.Add(New iTextSharp.text.Paragraph(" "))
            
            Dim signatureTable As New iTextSharp.text.pdf.PdfPTable(2)
            signatureTable.WidthPercentage = 100
            signatureTable.SetWidths(New Single() {1.0F, 1.0F})
            signatureTable.SpacingBefore = 20
            
            ' Received by
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
            
            ' Issued by
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
            
        Catch ex As Exception
            Throw New Exception("Error generating PDF: " & ex.Message, ex)
        End Try
    End Sub

    Private Function FindLogoPath(possibleNames() As String) As String
        ' Get base directory
        Dim baseDir As String = Application.StartupPath
        
        ' Try multiple base paths
        Dim basePaths() As String = {
            baseDir,
            Path.Combine(baseDir, "..\..\.."),
            Path.GetFullPath(Path.Combine(baseDir, "..\..\..")),
            Directory.GetCurrentDirectory()
        }
        
        ' Try each combination
        For Each basePath In basePaths
            For Each fileName In possibleNames
                Dim testPaths() As String = {
                    Path.Combine(basePath, "Resources\Images", fileName),
                    Path.Combine(basePath, "Resources", "Images", fileName),
                    Path.Combine(basePath, fileName)
                }
                
                For Each testPath In testPaths
                    Try
                        Dim fullPath As String = Path.GetFullPath(testPath)
                        If File.Exists(fullPath) Then
                            Return fullPath
                        End If
                    Catch ex As Exception
                        ' Continue
                    End Try
                Next
            Next
        Next
        
        Return Nothing
    End Function

    Private Sub AddPDFHeader(doc As iTextSharp.text.Document)
        Dim headerTable As New iTextSharp.text.pdf.PdfPTable(3)
        headerTable.WidthPercentage = 100
        headerTable.SetWidths(New Single() {1.5F, 5.0F, 1.5F})
        
        ' Left logo
        Try
            Dim leftLogoNames() As String = {
                "divisionofcamarinesnortelogo.jpg",
                "logo1-removebg-preview.png",
                "logo2-removebg-preview.png"
            }
            
            Dim leftLogoPath As String = FindLogoPath(leftLogoNames)
            
            If Not String.IsNullOrEmpty(leftLogoPath) Then
                Dim leftLogo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(leftLogoPath)
                leftLogo.ScaleToFit(60.0F, 60.0F)
                Dim logoCell As New iTextSharp.text.pdf.PdfPCell(leftLogo)
                logoCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                logoCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                logoCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                headerTable.AddCell(logoCell)
            Else
                headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell() With {.Border = iTextSharp.text.Rectangle.NO_BORDER})
            End If
        Catch ex As Exception
            headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell() With {.Border = iTextSharp.text.Rectangle.NO_BORDER})
        End Try
        
        ' Center text
        Dim centerCell As New iTextSharp.text.pdf.PdfPCell()
        centerCell.Border = iTextSharp.text.Rectangle.NO_BORDER
        centerCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
        centerCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
        
        Dim headerPara As New iTextSharp.text.Paragraph()
        headerPara.Add(New iTextSharp.text.Chunk("Republic of the Philippines" & vbCrLf, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL)))
        headerPara.Add(New iTextSharp.text.Chunk("Department of Education" & vbCrLf, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL)))
        headerPara.Add(New iTextSharp.text.Chunk("DIVISION OF CAMARINES NORTE" & vbCrLf, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD)))
        headerPara.Add(New iTextSharp.text.Chunk("Region V - Bicol" & vbCrLf, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL)))
        headerPara.Add(New iTextSharp.text.Chunk("Sta. Cruz, Talisay, Camarines Norte", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL)))
        headerPara.Alignment = iTextSharp.text.Element.ALIGN_CENTER
        centerCell.AddElement(headerPara)
        headerTable.AddCell(centerCell)
        
        ' Right logo
        Try
            Dim rightLogoNames() As String = {
                "574641165_841620561884149_5934190666791988971_n-removebg-preview (1)1.png",
                "574641165_841620561884149_5934190666791988971_n-removebg-preview (1).png"
            }
            
            Dim rightLogoPath As String = FindLogoPath(rightLogoNames)
            
            If Not String.IsNullOrEmpty(rightLogoPath) Then
                Dim rightLogo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(rightLogoPath)
                rightLogo.ScaleToFit(60.0F, 60.0F)
                Dim logoCell As New iTextSharp.text.pdf.PdfPCell(rightLogo)
                logoCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                logoCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                logoCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                headerTable.AddCell(logoCell)
            Else
                headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell() With {.Border = iTextSharp.text.Rectangle.NO_BORDER})
            End If
        Catch ex As Exception
            headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell() With {.Border = iTextSharp.text.Rectangle.NO_BORDER})
        End Try
        
        doc.Add(headerTable)
        
        ' Add title
        Dim title As New iTextSharp.text.Paragraph("SUPPLY MANAGEMENT SUMMARY", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD))
        title.Alignment = iTextSharp.text.Element.ALIGN_CENTER
        title.SpacingBefore = 15
        title.SpacingAfter = 10
        doc.Add(title)
    End Sub

    Private Sub ExportToCSV(filePath As String)
        Using writer As New StreamWriter(filePath, False, New UTF8Encoding(True))
            ' Clean professional header
            writer.WriteLine("REPUBLIC OF THE PHILIPPINES")
            writer.WriteLine("DEPARTMENT OF EDUCATION")
            writer.WriteLine("DIVISION OF CAMARINES NORTE")
            writer.WriteLine("Region V - Bicol")
            writer.WriteLine("Sta. Cruz, Talisay, Camarines Norte")
            writer.WriteLine()
            writer.WriteLine("SUPPLY MANAGEMENT SUMMARY")
            writer.WriteLine()
            writer.WriteLine($"School: {school.Text}")
            writer.WriteLine($"Report Date: {dateReport.Value:dddd, dd MMMM yyyy}")
            writer.WriteLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
            writer.WriteLine($"Total Records: {DataGridView1.Rows.Count}")
            writer.WriteLine()
            writer.WriteLine("=" & New String("="c, 120))
            writer.WriteLine()
            
            ' Write headers
            Dim headers As New List(Of String) From {
                "Item Name", "Category", "Description", "Quantity", 
                "Assigned To", "Location", "Stock Status"
            }
            writer.WriteLine(String.Join(",", headers))
            
            ' Write data
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim values As New List(Of String) From {
                        EscapeCSV(row.Cells(0).Value?.ToString()),
                        EscapeCSV(row.Cells(1).Value?.ToString()),
                        EscapeCSV(row.Cells(2).Value?.ToString()),
                        EscapeCSV(row.Cells(3).Value?.ToString()),
                        EscapeCSV(row.Cells(4).Value?.ToString()),
                        EscapeCSV(row.Cells(5).Value?.ToString()),
                        EscapeCSV(row.Cells(6).Value?.ToString())
                    }
                    writer.WriteLine(String.Join(",", values))
                End If
            Next
            
            ' Signature section
            writer.WriteLine()
            writer.WriteLine("=" & New String("="c, 120))
            writer.WriteLine()
            writer.WriteLine("CERTIFICATION")
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
            writer.WriteLine()
            writer.WriteLine("=" & New String("="c, 120))
            writer.WriteLine()
            writer.WriteLine("End of Report")
        End Using
    End Sub

    Private Function EscapeCSV(value As String) As String
        If String.IsNullOrEmpty(value) Then Return ""
        
        If value.Contains(",") OrElse value.Contains("""") OrElse value.Contains(vbCrLf) OrElse value.Contains(vbCr) OrElse value.Contains(vbLf) Then
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
        LoadSupplyData()
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        ' Reset all filters
        cboCategoryFilter.SelectedIndex = 0
        cboStatusFilter.SelectedIndex = 0
        chkDateFilter.Checked = False
        dtpDateFrom.Value = DateTime.Now.AddMonths(-1)
        dtpDateTo.Value = DateTime.Now
        
        ' Reload data
        LoadSupplyData()
    End Sub
End Class