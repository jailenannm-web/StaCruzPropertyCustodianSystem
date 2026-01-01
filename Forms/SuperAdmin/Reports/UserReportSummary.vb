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

Public Class UserReportSummary
    Private Sub UserReportSummary_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        ' Initialize date pickers
        dateReport.Value = DateTime.Now
        receivedDate.Value = DateTime.Now
        issuedDate.Value = DateTime.Now
        
        ' Set default school name
        school.Text = "Sta. Cruz Elementary School"
        
        ' Load filter dropdowns
        LoadFilterOptions()
        
        ' Load user data
        LoadUserData()
    End Sub

    Private Sub LoadFilterOptions()
        Try
            ' Load Roles
            cboRoleFilter.Items.Clear()
            cboRoleFilter.Items.Add("All Roles")
            cboRoleFilter.Items.Add("SuperAdmin")
            cboRoleFilter.Items.Add("Admin")
            cboRoleFilter.Items.Add("Custodian")
            cboRoleFilter.Items.Add("Staff")
            cboRoleFilter.SelectedIndex = 0
            
            ' Load Status
            cboStatusFilter.Items.Clear()
            cboStatusFilter.Items.Add("All Status")
            cboStatusFilter.Items.Add("Active")
            cboStatusFilter.Items.Add("Inactive")
            cboStatusFilter.SelectedIndex = 0
            
            ' Load Departments
            cboDepartmentFilter.Items.Clear()
            cboDepartmentFilter.Items.Add("All Departments")
            
            Dim conn As MySqlConnection = Nothing
            Try
                conn = modDB.GetConnection()
                If conn IsNot Nothing Then
                    Dim query As String = "SELECT departmentName FROM departments WHERE status = 'Active' ORDER BY departmentName"
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

    Private Sub LoadUserData()
        Try
            ' Build query with filters
            Dim query As String = "SELECT 
                u.userId, 
                u.fullName,
                u.position,
                u.employeeId,
                COALESCE(d.departmentName, 'N/A') as departmentName,
                u.email,
                u.contactNumber,
                u.username,
                CONCAT(
                    COALESCE(u.barangay, ''), 
                    IF(u.barangay IS NOT NULL AND u.barangay <> '', ', ', ''),
                    COALESCE(u.municipal, ''),
                    IF(u.municipal IS NOT NULL AND u.municipal <> '', ', ', ''),
                    COALESCE(u.province, '')
                ) as address,
                u.role,
                u.status,
                DATE_FORMAT(u.createdAt, '%Y-%m-%d') as createdAt,
                DATE_FORMAT(u.updatedAt, '%Y-%m-%d') as updatedAt,
                DATE_FORMAT(u.lastLogin, '%Y-%m-%d %H:%i:%s') as lastLogin
            FROM users u
            LEFT JOIN departments d ON u.departmentId = d.departmentId
            WHERE 1=1"
            
            ' Apply filters
            Dim params As New List(Of MySqlParameter)()
            
            ' Role filter
            If cboRoleFilter.SelectedIndex > 0 Then
                query &= " AND u.role = @role"
                params.Add(New MySqlParameter("@role", cboRoleFilter.SelectedItem.ToString()))
            End If
            
            ' Status filter
            If cboStatusFilter.SelectedIndex > 0 Then
                query &= " AND u.status = @status"
                params.Add(New MySqlParameter("@status", cboStatusFilter.SelectedItem.ToString()))
            End If
            
            ' Department filter
            If cboDepartmentFilter.SelectedIndex > 0 Then
                query &= " AND d.departmentName = @department"
                params.Add(New MySqlParameter("@department", cboDepartmentFilter.SelectedItem.ToString()))
            End If
            
            ' Date filter
            If chkDateFilter.Checked Then
                query &= " AND DATE(u.createdAt) BETWEEN @dateFrom AND @dateTo"
                params.Add(New MySqlParameter("@dateFrom", dtpDateFrom.Value.Date))
                params.Add(New MySqlParameter("@dateTo", dtpDateTo.Value.Date))
            End If
            
            query &= " ORDER BY u.userId"

            ' Execute query with parameters
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
                            
                            ' Populate DataGridView
                            For Each row As DataRow In dt.Rows
                                DataGridView1.Rows.Add(
                                    row("userId"),
                                    row("fullName"),
                                    If(row.IsNull("position"), "", row("position")),
                                    If(row.IsNull("employeeId"), "", row("employeeId")),
                                    row("departmentName"),
                                    If(row.IsNull("email"), "", row("email")),
                                    If(row.IsNull("contactNumber"), "", row("contactNumber")),
                                    row("username"),
                                    If(row.IsNull("address"), "", row("address")),
                                    row("role"),
                                    row("status"),
                                    row("createdAt"),
                                    row("updatedAt"),
                                    If(row.IsNull("lastLogin"), "Never", row("lastLogin"))
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
            MessageBox.Show("Error loading user data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As System.EventArgs) Handles btnPDF.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "PDF Files|*.pdf"
            dialog.FileName = $"User_Management_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
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
            dialog.FileName = $"User_Management_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
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
        
        ' Create table
        Dim pdfTable As New iTextSharp.text.pdf.PdfPTable(10) ' Adjust column count
        pdfTable.WidthPercentage = 100
        pdfTable.SetWidths(New Single() {0.6F, 1.2F, 0.9F, 0.9F, 1.0F, 1.2F, 1.0F, 0.9F, 1.2F, 0.8F})
        
        ' Add table headers
        Dim headerFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD)
        Dim cellFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 8, iTextSharp.text.Font.NORMAL)
        
        Dim headers() As String = {"User ID", "Full Name", "Position", "Employee ID", "Department", "Email", "Contact Number", "Username", "Address", "Role"}
        
        For Each header As String In headers
            Dim cell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(header, headerFont))
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
            cell.Padding = 5
            pdfTable.AddCell(cell)
        Next
        
        ' Add data rows
        Dim rowCount As Integer = 1
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                ' User ID
                pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(rowCount.ToString(), cellFont)) With {.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, .Padding = 3})
                
                ' Full Name
                pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells("fullName").Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                
                ' Position
                pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells("position").Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                
                ' Employee ID
                pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells("employeeID").Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                
                ' Department
                pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells("departmentID").Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                
                ' Email
                pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells("email").Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                
                ' Contact Number
                pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells("contactNumber").Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                
                ' Username
                pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells("username").Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                
                ' Address
                pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells("Address").Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                
                ' Role
                pdfTable.AddCell(New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(If(row.Cells("role").Value?.ToString(), ""), cellFont)) With {.Padding = 3})
                
                rowCount += 1
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
        ' Get base directory (where the .exe or project is)
        Dim baseDir As String = Application.StartupPath
        
        ' Debug: Log search paths
        Console.WriteLine($"[UserReport] Searching for logo from base: {baseDir}")
        
        ' Try multiple base paths
        Dim basePaths() As String = {
            baseDir,
            Path.Combine(baseDir, "..\..\.."),
            Path.GetFullPath(Path.Combine(baseDir, "..\..\..")),
            Directory.GetCurrentDirectory()
        }
        
        ' Try each combination of base path and file name
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
                            Console.WriteLine($"[UserReport] Logo found: {fullPath}")
                            Return fullPath
                        End If
                    Catch ex As Exception
                        ' Continue to next path
                    End Try
                Next
            Next
        Next
        
        Console.WriteLine($"[UserReport] Logo NOT found for: {String.Join(", ", possibleNames)}")
        Return Nothing
    End Function

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
                ' Empty cell if logo not found
                headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell() With {.Border = iTextSharp.text.Rectangle.NO_BORDER})
            End If
        Catch ex As Exception
            ' Empty cell on error
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
                ' Empty cell if logo not found
                headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell() With {.Border = iTextSharp.text.Rectangle.NO_BORDER})
            End If
        Catch ex As Exception
            ' Empty cell on error
            headerTable.AddCell(New iTextSharp.text.pdf.PdfPCell() With {.Border = iTextSharp.text.Rectangle.NO_BORDER})
        End Try
        
        doc.Add(headerTable)
        
        ' Add title
        Dim title As New iTextSharp.text.Paragraph("USER MANAGEMENT REPORT", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD))
        title.Alignment = iTextSharp.text.Element.ALIGN_CENTER
        title.SpacingBefore = 15
        title.SpacingAfter = 10
        doc.Add(title)
    End Sub

    Private Sub ExportToCSV(filePath As String)
        Using writer As New StreamWriter(filePath, False, New UTF8Encoding(True))
            ' ========================================
            ' HEADER SECTION
            ' ========================================
            writer.WriteLine("═══════════════════════════════════════════════════════════════════════════")
            writer.WriteLine("                    REPUBLIC OF THE PHILIPPINES")
            writer.WriteLine("                      DEPARTMENT OF EDUCATION")
            writer.WriteLine("                  DIVISION OF CAMARINES NORTE")
            writer.WriteLine("                          Region V - Bicol")
            writer.WriteLine("                 Sta. Cruz, Talisay, Camarines Norte")
            writer.WriteLine("═══════════════════════════════════════════════════════════════════════════")
            writer.WriteLine()
            writer.WriteLine("                      USER MANAGEMENT REPORT")
            writer.WriteLine()
            writer.WriteLine("───────────────────────────────────────────────────────────────────────────")
            writer.WriteLine($"School:,{EscapeCSV(school.Text)}")
            writer.WriteLine($"Report Date:,{dateReport.Value:dddd dd MMMM yyyy}")
            writer.WriteLine($"Generated:,{DateTime.Now:yyyy-MM-dd HH:mm:ss}")
            writer.WriteLine($"Total Records:,{DataGridView1.Rows.Count - 1}")
            writer.WriteLine("───────────────────────────────────────────────────────────────────────────")
            writer.WriteLine()
            
            ' ========================================
            ' DATA TABLE SECTION
            ' ========================================
            writer.WriteLine("USER ACCOUNTS LISTING")
            writer.WriteLine()
            
            ' Write column headers with better formatting
            Dim headers As New List(Of String) From {
                "#", "User ID", "Full Name", "Position", "Employee ID", 
                "Department", "Email", "Contact Number", "Username", "Address", "Role", "Status"
            }
            writer.WriteLine(String.Join(",", headers.Select(Function(h) EscapeCSV(h))))
            
            ' Write separator line
            Dim separator As New List(Of String)
            For i As Integer = 0 To headers.Count - 1
                separator.Add("─────────────")
            Next
            writer.WriteLine(String.Join(",", separator))
            
            ' Write data rows
            Dim rowNum As Integer = 1
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim values As New List(Of String) From {
                        rowNum.ToString(),
                        EscapeCSV(row.Cells("userID").Value?.ToString()),
                        EscapeCSV(row.Cells("fullName").Value?.ToString()),
                        EscapeCSV(row.Cells("position").Value?.ToString()),
                        EscapeCSV(row.Cells("employeeID").Value?.ToString()),
                        EscapeCSV(row.Cells("departmentID").Value?.ToString()),
                        EscapeCSV(row.Cells("email").Value?.ToString()),
                        EscapeCSV(row.Cells("contactNumber").Value?.ToString()),
                        EscapeCSV(row.Cells("username").Value?.ToString()),
                        EscapeCSV(row.Cells("Address").Value?.ToString()),
                        EscapeCSV(row.Cells("role").Value?.ToString()),
                        EscapeCSV(row.Cells("status").Value?.ToString())
                    }
                    writer.WriteLine(String.Join(",", values))
                    rowNum += 1
                End If
            Next
            
            ' ========================================
            ' SUMMARY SECTION
            ' ========================================
            writer.WriteLine()
            writer.WriteLine("───────────────────────────────────────────────────────────────────────────")
            writer.WriteLine("SUMMARY")
            writer.WriteLine("───────────────────────────────────────────────────────────────────────────")
            
            ' Count users by role
            Dim roleCounts As New Dictionary(Of String, Integer)()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim role As String = row.Cells("role").Value?.ToString()
                    If Not String.IsNullOrEmpty(role) Then
                        If roleCounts.ContainsKey(role) Then
                            roleCounts(role) += 1
                        Else
                            roleCounts.Add(role, 1)
                        End If
                    End If
                End If
            Next
            
            writer.WriteLine($"Total Users:,{DataGridView1.Rows.Count - 1}")
            For Each kvp In roleCounts.OrderBy(Function(x) x.Key)
                writer.WriteLine($"{kvp.Key} Users:,{kvp.Value}")
            Next
            
            ' Count users by status
            Dim activeCount As Integer = 0
            Dim inactiveCount As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim status As String = row.Cells("status").Value?.ToString()
                    If status = "Active" Then
                        activeCount += 1
                    ElseIf status = "Inactive" Then
                        inactiveCount += 1
                    End If
                End If
            Next
            writer.WriteLine($"Active Users:,{activeCount}")
            writer.WriteLine($"Inactive Users:,{inactiveCount}")
            
            ' ========================================
            ' SIGNATURE SECTION
            ' ========================================
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

    Private Sub btn_Back_Click(sender As Object, e As System.EventArgs) Handles btn_Back.Click
        Me.Close()
    End Sub

    Private Sub chkDateFilter_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkDateFilter.CheckedChanged
        dtpDateFrom.Enabled = chkDateFilter.Checked
        dtpDateTo.Enabled = chkDateFilter.Checked
    End Sub

    Private Sub btnApplyFilters_Click(sender As Object, e As System.EventArgs) Handles btnApplyFilters.Click
        LoadUserData()
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As System.EventArgs) Handles btnClearFilters.Click
        ' Reset all filters
        cboRoleFilter.SelectedIndex = 0
        cboStatusFilter.SelectedIndex = 0
        cboDepartmentFilter.SelectedIndex = 0
        chkDateFilter.Checked = False
        dtpDateFrom.Value = DateTime.Now.AddMonths(-1)
        dtpDateTo.Value = DateTime.Now
        
        ' Reload data
        LoadUserData()
    End Sub
End Class