Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Public Class DepartmentAllocationSummary_vb
    Private Sub DepartmentAllocationSummary_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        ' Initialize date pickers
        dateReport.Value = DateTime.Now
        receivedDate.Value = DateTime.Now
        issuedDate.Value = DateTime.Now

        ' Set default school name
        school.Text = "Sta. Cruz Elementary School"

        ' Load filter options
        LoadFilterOptions()

        ' Load department data
        LoadDepartmentData()
    End Sub

    Private Sub LoadFilterOptions()
        Try
            ' Load Status
            cboStatusFilter.Items.Clear()
            cboStatusFilter.Items.Add("All Status")
            cboStatusFilter.Items.Add("Active")
            cboStatusFilter.Items.Add("Inactive")
            cboStatusFilter.SelectedIndex = 0

            ' Load Departments (for filtering by specific department)
            cboDepartmentFilter.Items.Clear()
            cboDepartmentFilter.Items.Add("All Departments")

            Dim conn As MySqlConnection = Nothing
            Try
                conn = modDB.GetConnection()
                If conn IsNot Nothing Then
                    Dim query As String = "SELECT departmentName FROM departments ORDER BY departmentName"
                    Using cmd As New MySqlCommand(query, conn)
                        Using adapter As New MySqlDataAdapter(cmd)
                            Dim dt As New DataTable()
                            adapter.Fill(dt)

                            For Each row As DataRow In dt.Rows
                                cboDepartmentFilter.Items.Add(row("departmentName").ToString())
                            Next
                        End Using
                    End Using
                End If
            Finally
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
            cboDepartmentFilter.SelectedIndex = 0

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

    Private Sub LoadDepartmentData()
        Dim conn As MySqlConnection = Nothing
        Try
            ' Step 1: Get department list with basic info (fast)
            Dim query As String = "SELECT 
                d.departmentId,
                d.departmentName,
                d.headOfDepartment,
                IFNULL(d.email, '') as email,
                IFNULL(d.contactNumber, '') as contactNumber,
                d.location,
                IFNULL(d.building, '') as building,
                IFNULL(d.floorNumber, '') as floorNumber,
                IFNULL(d.shortName, '') as shortName,
                IFNULL(d.officeCode, '') as officeCode,
                IFNULL(d.description, '') as description,
                d.status,
                DATE_FORMAT(d.createdAt, '%Y-%m-%d') as createdAt,
                DATE_FORMAT(d.updatedAt, '%Y-%m-%d') as updatedAt
            FROM departments d
            WHERE 1=1"

            ' Apply filters
            Dim params As New List(Of MySqlParameter)()

            ' Status filter
            If cboStatusFilter IsNot Nothing AndAlso cboStatusFilter.SelectedIndex > 0 Then
                query &= " AND d.status = @status"
                params.Add(New MySqlParameter("@status", cboStatusFilter.SelectedItem.ToString()))
            End If

            ' Department filter
            If cboDepartmentFilter IsNot Nothing AndAlso cboDepartmentFilter.SelectedIndex > 0 Then
                query &= " AND d.departmentName = @department"
                params.Add(New MySqlParameter("@department", cboDepartmentFilter.SelectedItem.ToString()))
            End If

            ' Date filter
            If chkDateFilter IsNot Nothing AndAlso chkDateFilter.Checked Then
                query &= " AND DATE(d.createdAt) BETWEEN @dateFrom AND @dateTo"
                params.Add(New MySqlParameter("@dateFrom", dtpDateFrom.Value.Date))
                params.Add(New MySqlParameter("@dateTo", dtpDateTo.Value.Date))
            End If

            query &= " ORDER BY d.departmentName"

            ' Get connection and keep it open for entire operation
            conn = modDB.GetConnection()
            If conn Is Nothing Then
                MessageBox.Show("Unable to connect to database.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Ensure connection is open
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            Using cmd As New MySqlCommand(query, conn)
                ' Add parameters
                For Each param As MySqlParameter In params
                    cmd.Parameters.Add(param)
                Next

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    ' Clear existing rows
                    DataGridView1.Rows.Clear()

                    ' Read and populate data
                    While reader.Read()
                        Try
                            Dim deptId As Integer = If(reader.IsDBNull(reader.GetOrdinal("departmentId")), 0, reader.GetInt32("departmentId"))
                            Dim deptName As String = If(reader.IsDBNull(reader.GetOrdinal("departmentName")), "", reader.GetString("departmentName"))
                            Dim headOfDept As String = If(reader.IsDBNull(reader.GetOrdinal("headOfDepartment")), "", reader.GetString("headOfDepartment"))
                            Dim email As String = If(reader.IsDBNull(reader.GetOrdinal("email")), "", reader.GetString("email"))
                            Dim contactNumber As String = If(reader.IsDBNull(reader.GetOrdinal("contactNumber")), "", reader.GetString("contactNumber"))
                            Dim location As String = If(reader.IsDBNull(reader.GetOrdinal("location")), "", reader.GetString("location"))
                            Dim building As String = If(reader.IsDBNull(reader.GetOrdinal("building")), "", reader.GetString("building"))
                            Dim floorNumber As String = If(reader.IsDBNull(reader.GetOrdinal("floorNumber")), "", reader.GetString("floorNumber"))
                            Dim shortName As String = If(reader.IsDBNull(reader.GetOrdinal("shortName")), "", reader.GetString("shortName"))
                            Dim officeCode As String = If(reader.IsDBNull(reader.GetOrdinal("officeCode")), "", reader.GetString("officeCode"))
                            Dim description As String = If(reader.IsDBNull(reader.GetOrdinal("description")), "", reader.GetString("description"))
                            Dim status As String = If(reader.IsDBNull(reader.GetOrdinal("status")), "Active", reader.GetString("status"))
                            Dim createdAt As String = If(reader.IsDBNull(reader.GetOrdinal("createdAt")), "", reader.GetString("createdAt"))
                            Dim updatedAt As String = If(reader.IsDBNull(reader.GetOrdinal("updatedAt")), "", reader.GetString("updatedAt"))

                            ' Initialize counts to 0 - will calculate after loading all departments
                            Dim totalProps As Integer = 0
                            Dim totalSupps As Integer = 0

                            ' Add row to DataGridView - ORDER MUST MATCH DESIGNER!
                            ' Designer order: departmentID, departmentName, headOfDepartment, email, contactNumber, 
                            '                 location, totalProperties, totalSupplies, building, floorNumber, 
                            '                 shortName, officeCode, description, status, createdAt, updatedAt
                            DataGridView1.Rows.Add(
                                deptId,                 ' 0: departmentID
                                deptName,               ' 1: departmentName
                                headOfDept,             ' 2: headOfDepartment
                                email,                  ' 3: email
                                contactNumber,          ' 4: contactNumber
                                location,               ' 5: location
                                totalProps,             ' 6: totalProperties
                                totalSupps,             ' 7: totalSupplies
                                building,               ' 8: building
                                floorNumber,            ' 9: floorNumber
                                shortName,              ' 10: shortName
                                officeCode,             ' 11: officeCode
                                description,            ' 12: description
                                status,                 ' 13: status
                                createdAt,              ' 14: createdAt
                                updatedAt               ' 15: updatedAt
                            )
                        Catch rowEx As Exception
                            ' Log the row error but continue
                            System.Diagnostics.Debug.WriteLine("Error processing row: " & rowEx.Message)
                        End Try
                    End While
                End Using
            End Using

            ' Step 2: Calculate counts efficiently using bulk queries
            CalculateDepartmentCounts(conn)

        Catch ex As MySqlException
            MessageBox.Show("Error loading department data: Connection must be valid and open." & vbCrLf & vbCrLf &
                          "MySQL Error: " & ex.Message & vbCrLf &
                          "Error Code: " & ex.Number & vbCrLf & vbCrLf &
                          "Stack: " & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As InvalidOperationException
            MessageBox.Show("Connection Error: " & ex.Message & vbCrLf & vbCrLf &
                          "The database connection was closed unexpectedly." & vbCrLf &
                          "Stack: " & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error loading department data: " & ex.Message & vbCrLf & vbCrLf &
                          "Stack: " & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Always close connection in Finally block
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Dispose()
                Catch
                    ' Ignore disposal errors
                End Try
            End If
        End Try
    End Sub

    Private Sub chkDateFilter_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkDateFilter.CheckedChanged
        dtpDateFrom.Enabled = chkDateFilter.Checked
        dtpDateTo.Enabled = chkDateFilter.Checked
    End Sub

    Private Sub btnApplyFilters_Click(sender As Object, e As System.EventArgs) Handles btnApplyFilters.Click
        LoadDepartmentData()
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As System.EventArgs) Handles btnClearFilters.Click
        ' Reset all filters
        cboStatusFilter.SelectedIndex = 0
        cboDepartmentFilter.SelectedIndex = 0
        chkDateFilter.Checked = False
        dtpDateFrom.Value = DateTime.Now.AddMonths(-1)
        dtpDateTo.Value = DateTime.Now

        ' Reload data
        LoadDepartmentData()
    End Sub

    Private Sub btn_Back_Click(sender As Object, e As System.EventArgs) Handles btn_Back.Click
        Me.Close()
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As System.EventArgs) Handles btnPDF.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "PDF Files|*.pdf"
            dialog.FileName = $"Department_Allocation_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
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

    Private Sub btnCSV_Click(sender As Object, e As System.EventArgs) Handles btnCSV.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "CSV Files|*.csv"
            dialog.FileName = $"Department_Allocation_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
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
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 20, 20, 40, 40)
            Dim writer As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))

            doc.Open()
            AddPDFHeader(doc)

            Dim infoFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL)
            Dim schoolPara As New iTextSharp.text.Paragraph($"School: {school.Text}     Date: {dateReport.Value:dddd, dd MMMM yyyy}", infoFont)
            schoolPara.Alignment = iTextSharp.text.Element.ALIGN_LEFT
            schoolPara.SpacingBefore = 15
            schoolPara.SpacingAfter = 10
            doc.Add(schoolPara)

            Dim pdfTable As New iTextSharp.text.pdf.PdfPTable(9)
            pdfTable.WidthPercentage = 100
            pdfTable.SetWidths(New Single() {0.4F, 1.5F, 0.7F, 0.7F, 1.0F, 0.8F, 0.8F, 0.6F, 0.6F})

            Dim headerFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)
            Dim cellFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)

            Dim headers() As String = {"#", "Department Name", "Total Props", "Total Supplies", "Head", "Contact", "Location", "Status", "Created"}

            For Each header As String In headers
                Dim cell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(header, headerFont))
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                cell.Padding = 5
                pdfTable.AddCell(cell)
            Next

            Dim rowCount As Integer = 1
            Dim totalPropertiesSum As Integer = 0
            Dim totalSuppliesSum As Integer = 0

            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim totalProps As Integer = If(IsNumeric(row.Cells("totalProperties").Value), Convert.ToInt32(row.Cells("totalProperties").Value), 0)
                    Dim totalSupps As Integer = If(IsNumeric(row.Cells("totalSupplies").Value), Convert.ToInt32(row.Cells("totalSupplies").Value), 0)

                    totalPropertiesSum += totalProps
                    totalSuppliesSum += totalSupps

                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rowCount.ToString(), cellFont)) With {.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, .Padding = 3})
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(1).Value?.ToString(), ""), cellFont)) With {.Padding = 3}) ' departmentName
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(totalProps.ToString(), cellFont)) With {.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, .Padding = 3})
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(totalSupps.ToString(), cellFont)) With {.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, .Padding = 3})
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(2).Value?.ToString(), ""), cellFont)) With {.Padding = 3}) ' headOfDepartment
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(4).Value?.ToString(), ""), cellFont)) With {.Padding = 3}) ' contactNumber
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(5).Value?.ToString(), ""), cellFont)) With {.Padding = 3}) ' location
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(13).Value?.ToString(), ""), cellFont)) With {.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, .Padding = 3}) ' status
                    pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells(14).Value?.ToString(), ""), cellFont)) With {.Padding = 3}) ' createdAt
                    rowCount += 1
                End If
            Next

            ' Add total row
            Dim totalFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)
            Dim totalLabelCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("TOTAL:", totalFont))
            totalLabelCell.Colspan = 2
            totalLabelCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT
            totalLabelCell.Padding = 5
            totalLabelCell.BackgroundColor = New iTextSharp.text.BaseColor(220, 220, 220)
            pdfTable.AddCell(totalLabelCell)

            pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(totalPropertiesSum.ToString(), totalFont)) With {.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, .Padding = 5, .BackgroundColor = New iTextSharp.text.BaseColor(220, 220, 220)})
            pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(totalSuppliesSum.ToString(), totalFont)) With {.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, .Padding = 5, .BackgroundColor = New iTextSharp.text.BaseColor(220, 220, 220)})

            Dim emptyCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase("", cellFont))
            emptyCell.Colspan = 5
            emptyCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            emptyCell.BackgroundColor = New iTextSharp.text.BaseColor(220, 220, 220)
            pdfTable.AddCell(emptyCell)

            doc.Add(pdfTable)
            doc.Add(New iTextSharp.text.Paragraph(" "))
            doc.Add(New iTextSharp.text.Paragraph(" "))

            Dim signatureTable As New iTextSharp.text.pdf.PdfPTable(2)
            signatureTable.WidthPercentage = 100
            signatureTable.SetWidths(New Single() {1.0F, 1.0F})
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
        Catch ex As Exception
            Throw New Exception("Error generating PDF: " & ex.Message, ex)
        End Try
    End Sub

    Private Sub AddPDFHeader(doc As iTextSharp.text.Document)
        Dim headerTable As New iTextSharp.text.pdf.PdfPTable(3)
        headerTable.WidthPercentage = 100
        headerTable.SetWidths(New Single() {1.5F, 5.0F, 1.5F})

        ' Left logo - Division of Camarines Norte seal
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

        ' Right logo - DepEd seal
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

        Dim title As New iTextSharp.text.Paragraph("DEPARTMENT ALLOCATION REPORT", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD))
        title.Alignment = iTextSharp.text.Element.ALIGN_CENTER
        title.SpacingBefore = 15
        title.SpacingAfter = 10
        doc.Add(title)
    End Sub

    Private Function FindLogoPath(possibleNames() As String) As String
        Dim baseDir As String = Application.StartupPath
        Console.WriteLine($"[DeptReport] Searching for logo from base: {baseDir}")

        Dim basePaths() As String = {
            baseDir,
            Path.Combine(baseDir, "..\..\.."),
            Path.GetFullPath(Path.Combine(baseDir, "..\..\..")),
            Directory.GetCurrentDirectory()
        }

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
                            Console.WriteLine($"[DeptReport] Logo found: {fullPath}")
                            Return fullPath
                        End If
                    Catch ex As Exception
                    End Try
                Next
            Next
        Next

        Console.WriteLine($"[DeptReport] Logo NOT found for: {String.Join(", ", possibleNames)}")
        Return Nothing
    End Function

    Private Sub ExportToCSV(filePath As String)
        Using writer As New StreamWriter(filePath, False, New UTF8Encoding(True))
            writer.WriteLine("═══════════════════════════════════════════════════════════════════════════")
            writer.WriteLine("                    REPUBLIC OF THE PHILIPPINES")
            writer.WriteLine("                      DEPARTMENT OF EDUCATION")
            writer.WriteLine("                  DIVISION OF CAMARINES NORTE")
            writer.WriteLine("                          Region V - Bicol")
            writer.WriteLine("                 Sta. Cruz, Talisay, Camarines Norte")
            writer.WriteLine("═══════════════════════════════════════════════════════════════════════════")
            writer.WriteLine()
            writer.WriteLine("                  DEPARTMENT ALLOCATION REPORT")
            writer.WriteLine()
            writer.WriteLine("───────────────────────────────────────────────────────────────────────────")
            writer.WriteLine($"School:,{EscapeCSV(school.Text)}")
            writer.WriteLine($"Report Date:,{dateReport.Value:dddd dd MMMM yyyy}")
            writer.WriteLine($"Generated:,{DateTime.Now:yyyy-MM-dd HH:mm:ss}")
            writer.WriteLine($"Total Records:,{DataGridView1.Rows.Count - 1}")
            writer.WriteLine("───────────────────────────────────────────────────────────────────────────")
            writer.WriteLine()

            writer.WriteLine("DEPARTMENT ALLOCATION LISTING")
            writer.WriteLine()

            Dim headers As New List(Of String) From {
                "#", "Department ID", "Department Name", "Total Properties", "Total Supplies",
                "Head of Department", "Email", "Contact Number", "Location", "Building", "Status", "Created Date"
            }
            writer.WriteLine(String.Join(",", headers.Select(Function(h) EscapeCSV(h))))

            Dim separator As New List(Of String)
            For i As Integer = 0 To headers.Count - 1
                separator.Add("─────────────")
            Next
            writer.WriteLine(String.Join(",", separator))

            Dim rowNum As Integer = 1
            Dim totalPropertiesSum As Integer = 0
            Dim totalSuppliesSum As Integer = 0

            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim totalProps As Integer = If(IsNumeric(row.Cells("totalProperties").Value), Convert.ToInt32(row.Cells("totalProperties").Value), 0)
                    Dim totalSupps As Integer = If(IsNumeric(row.Cells("totalSupplies").Value), Convert.ToInt32(row.Cells("totalSupplies").Value), 0)

                    totalPropertiesSum += totalProps
                    totalSuppliesSum += totalSupps

                    Dim values As New List(Of String) From {
                        rowNum.ToString(),
                        EscapeCSV(row.Cells(0).Value?.ToString()),      ' departmentID
                        EscapeCSV(row.Cells(1).Value?.ToString()),      ' departmentName
                        totalProps.ToString(),                           ' totalProperties
                        totalSupps.ToString(),                           ' totalSupplies
                        EscapeCSV(row.Cells(2).Value?.ToString()),      ' headOfDepartment
                        EscapeCSV(row.Cells(3).Value?.ToString()),      ' email
                        EscapeCSV(row.Cells(4).Value?.ToString()),      ' contactNumber
                        EscapeCSV(row.Cells(5).Value?.ToString()),      ' location
                        EscapeCSV(row.Cells(8).Value?.ToString()),      ' building
                        EscapeCSV(row.Cells(13).Value?.ToString()),     ' status
                        EscapeCSV(row.Cells(14).Value?.ToString())      ' createdAt
                    }
                    writer.WriteLine(String.Join(",", values))
                    rowNum += 1
                End If
            Next

            ' Add totals row
            writer.WriteLine(String.Join(",", New String() {
                "",
                "",
                "TOTAL:",
                totalPropertiesSum.ToString(),
                totalSuppliesSum.ToString(),
                "",
                "",
                "",
                "",
                "",
                "",
                ""
            }))

            writer.WriteLine()
            writer.WriteLine("───────────────────────────────────────────────────────────────────────────")
            writer.WriteLine("SUMMARY")
            writer.WriteLine("───────────────────────────────────────────────────────────────────────────")

            Dim totalDepts As Integer = DataGridView1.Rows.Count - 1
            Dim activeDepts As Integer = 0
            Dim inactiveDepts As Integer = 0

            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim status As String = row.Cells("status").Value?.ToString()
                    If status = "Active" Then
                        activeDepts += 1
                    ElseIf status = "Inactive" Then
                        inactiveDepts += 1
                    End If
                End If
            Next

            writer.WriteLine($"Total Departments:,{totalDepts}")
            writer.WriteLine($"Active Departments:,{activeDepts}")
            writer.WriteLine($"Inactive Departments:,{inactiveDepts}")
            writer.WriteLine($"Total Properties:,{totalPropertiesSum}")
            writer.WriteLine($"Total Supplies:,{totalSuppliesSum}")

            writer.WriteLine()
            writer.WriteLine("═══════════════════════════════════════════════════════════════════════════")
            writer.WriteLine("CERTIFICATION")
            writer.WriteLine("═══════════════════════════════════════════════════════════════════════════")
            writer.WriteLine()
            writer.WriteLine("This report has been prepared and reviewed by:")
            writer.WriteLine()
            writer.WriteLine("───────────────────────────────────────────────────────────────────────────")
            writer.WriteLine("RECEIVED BY:")
            writer.WriteLine($"Name:,{EscapeCSV(receivedBy.Text)}")
            writer.WriteLine("Signature:,_________________________________")
            writer.WriteLine($"Date:,{receivedDate.Value:dddd dd MMMM yyyy}")
            writer.WriteLine()
            writer.WriteLine("───────────────────────────────────────────────────────────────────────────")
            writer.WriteLine("ISSUED BY:")
            writer.WriteLine($"Name:,{EscapeCSV(issuedBy.Text)}")
            writer.WriteLine("Signature:,_________________________________")
            writer.WriteLine($"Date:,{issuedDate.Value:dddd dd MMMM yyyy}")
            writer.WriteLine()
            writer.WriteLine("═══════════════════════════════════════════════════════════════════════════")
            writer.WriteLine()
            writer.WriteLine($"Report Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
            writer.WriteLine("System: Team Cruz Property Custodian Management System")
            writer.WriteLine("═══════════════════════════════════════════════════════════════════════════")
        End Using
    End Sub

    Private Function EscapeCSV(value As String) As String
        If String.IsNullOrEmpty(value) Then Return ""

        If value.Contains(",") OrElse value.Contains("""") OrElse value.Contains(vbCrLf) OrElse value.Contains(vbCr) OrElse value.Contains(vbLf) Then
            Return """" & value.Replace("""", """""") & """"
        End If

        Return value
    End Function

    Private Sub CalculateDepartmentCounts(conn As MySqlConnection)
        Try
            ' Get property counts for all departments in one query
            Dim propCounts As New Dictionary(Of Integer, Integer)()
            Dim propQuery As String = "SELECT departmentId, COUNT(*) as propCount FROM properties WHERE departmentId IS NOT NULL GROUP BY departmentId"

            Using cmd As New MySqlCommand(propQuery, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim deptId As Integer = reader.GetInt32("departmentId")
                        Dim count As Integer = reader.GetInt32("propCount")
                        propCounts(deptId) = count
                    End While
                End Using
            End Using

            ' Get supply counts for all departments in one query (match by location)
            Dim supplyCounts As New Dictionary(Of Integer, Integer)()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim deptId As Integer = Convert.ToInt32(row.Cells(0).Value)      ' departmentID
                    Dim deptName As String = row.Cells(1).Value?.ToString()          ' departmentName
                    Dim location As String = row.Cells(5).Value?.ToString()          ' location

                    If Not String.IsNullOrEmpty(deptName) Then
                        ' Count supplies matching this department's name or location
                        Dim supplyQuery As String = "SELECT COUNT(*) as supplyCount FROM supplies WHERE location LIKE @deptName OR location LIKE @location"
                        Using cmd As New MySqlCommand(supplyQuery, conn)
                            cmd.Parameters.AddWithValue("@deptName", "%" & deptName & "%")
                            cmd.Parameters.AddWithValue("@location", "%" & location & "%")

                            Dim count As Object = cmd.ExecuteScalar()
                            supplyCounts(deptId) = If(count IsNot Nothing AndAlso Not IsDBNull(count), Convert.ToInt32(count), 0)
                        End Using
                    End If
                End If
            Next

            ' Update DataGridView with calculated counts
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim deptId As Integer = Convert.ToInt32(row.Cells(0).Value)      ' departmentID

                    ' Update property count (column index 6)
                    If propCounts.ContainsKey(deptId) Then
                        row.Cells(6).Value = propCounts(deptId)
                    Else
                        row.Cells(6).Value = 0
                    End If

                    ' Update supply count (column index 7)
                    If supplyCounts.ContainsKey(deptId) Then
                        row.Cells(7).Value = supplyCounts(deptId)
                    Else
                        row.Cells(7).Value = 0
                    End If
                End If
            Next

            ' Auto-resize columns
            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End If

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error calculating department counts: " & ex.Message)
            MessageBox.Show("Note: Department counts may not be accurate. Error: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class