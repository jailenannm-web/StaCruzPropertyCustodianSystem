Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Public Module ReportExportHelper
    Public Sub ExportDataTableToCsv(table As DataTable, suggestedFileName As String, Optional successMessage As String = "CSV file exported successfully.", Optional isBulkExport As Boolean = False)
        If table Is Nothing OrElse table.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "CSV Files|*.csv"
            dialog.FileName = suggestedFileName
            dialog.AddExtension = True
            dialog.DefaultExt = "csv"
            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    WriteCsv(table, dialog.FileName, isBulkExport)
                    MessageBox.Show(successMessage, "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to export CSV file: " & ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Public Sub ExportDataTableToPdf(table As DataTable, suggestedFileName As String, title As String, Optional successMessage As String = "PDF file exported successfully.")
        If table Is Nothing OrElse table.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "PDF Files|*.pdf"
            dialog.FileName = suggestedFileName
            dialog.AddExtension = True
            dialog.DefaultExt = "pdf"
            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    Dim filePath = dialog.FileName
                    ' Ensure extension
                    If Not filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) Then
                        filePath = filePath & ".pdf"
                    End If

                    Dim pdfBytes = BuildSimplePdf(table, title)
                    File.WriteAllBytes(filePath, pdfBytes)
                    MessageBox.Show(successMessage, "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to export PDF file: " & ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Public Sub ExportAuditReportToPdf(auditData As DataRow, suggestedFileName As String, Optional successMessage As String = "Audit report exported successfully to PDF.")
        If auditData Is Nothing Then
            MessageBox.Show("No audit data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "PDF Files|*.pdf"
            dialog.FileName = suggestedFileName
            dialog.AddExtension = True
            dialog.DefaultExt = "pdf"
            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    Dim filePath = dialog.FileName
                    ' Ensure extension
                    If Not filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) Then
                        filePath = filePath & ".pdf"
                    End If

                    Dim pdfBytes = BuildAuditReportPdf(auditData)
                    File.WriteAllBytes(filePath, pdfBytes)
                    MessageBox.Show(successMessage, "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to export PDF file: " & ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub WriteCsv(table As DataTable, filePath As String, Optional isBulkExport As Boolean = False)
        ' Use UTF8 with BOM so Excel recognizes encoding reliably
        Using writer As New StreamWriter(filePath, False, New UTF8Encoding(True))
            ' Check if this is a key-value format (Field/Value) or table format
            Dim isKeyValueFormat As Boolean = table.Columns.Count = 2 AndAlso 
                                              table.Columns.Contains("Field") AndAlso 
                                              table.Columns.Contains("Value") AndAlso
                                              Not isBulkExport
            
            If isKeyValueFormat Then
                ' Professional key-value format for single record (Requisition, Audit, etc.)
                Dim reportTitle As String = "REPORT"
                
                ' Detect report type from first row
                If table.Rows.Count > 0 Then
                    Dim firstField As String = If(Convert.IsDBNull(table.Rows(0)("Field")), "", table.Rows(0)("Field").ToString())
                    If firstField.Contains("REQUISITION") Then
                        reportTitle = "REQUISITION ISSUE SLIP"
                    ElseIf firstField.Contains("AUDIT") Then
                        reportTitle = "AUDIT REPORT"
                    End If
                End If
                
                ' Add professional header
                writer.WriteLine(QuoteCsvValue(reportTitle))
                writer.WriteLine("")
                writer.WriteLine(QuoteCsvValue("Sta Cruz Property Custodian System"))
                writer.WriteLine(QuoteCsvValue("Generated: " & DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")))
                writer.WriteLine("")
                writer.WriteLine(QuoteCsvValue(New String("="c, 80)))
                writer.WriteLine("")
                
                ' Column headers for better readability
                writer.WriteLine(QuoteCsvValue("Field") & "," & QuoteCsvValue("Value"))
                writer.WriteLine(QuoteCsvValue(New String("-"c, 30)) & "," & QuoteCsvValue(New String("-"c, 50)))
                
                ' Write field-value pairs with proper formatting
                Dim isFirstDataRow As Boolean = True
                For Each row As DataRow In table.Rows
                    Dim fieldName As String = If(Convert.IsDBNull(row("Field")), "", Convert.ToString(row("Field")))
                    Dim fieldValue As String = If(Convert.IsDBNull(row("Value")), "", Convert.ToString(row("Value")))
                    
                    ' Skip the title row if it's already in header
                    If isFirstDataRow AndAlso (fieldName.Contains("REQUISITION") OrElse fieldName.Contains("AUDIT")) Then
                        isFirstDataRow = False
                        Continue For
                    End If
                    isFirstDataRow = False
                    
                    ' Skip empty separator rows
                    If String.IsNullOrWhiteSpace(fieldName) AndAlso String.IsNullOrWhiteSpace(fieldValue) Then
                        writer.WriteLine("")
                    ElseIf Not String.IsNullOrWhiteSpace(fieldName) Then
                        ' Format as CSV with Field and Value columns
                        writer.WriteLine(QuoteCsvValue(fieldName) & "," & QuoteCsvValue(fieldValue))
                    End If
                Next
                
                ' Add footer
                writer.WriteLine("")
                writer.WriteLine(QuoteCsvValue(New String("="c, 80)))
                writer.WriteLine(QuoteCsvValue("End of Report"))
                writer.WriteLine("")
                writer.WriteLine(QuoteCsvValue("This is an official document from Sta Cruz Property Custodian System"))
            Else
                ' Professional table format for bulk exports
                ' Add header section (as comments/metadata rows)
                writer.WriteLine(QuoteCsvValue("AUDIT LOG REPORT"))
                writer.WriteLine(QuoteCsvValue(""))
                writer.WriteLine(QuoteCsvValue("Sta Cruz Property Custodian System"))
                writer.WriteLine(QuoteCsvValue("Report Generated: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
                writer.WriteLine(QuoteCsvValue("Total Records: " & table.Rows.Count.ToString()))
                writer.WriteLine(QuoteCsvValue(""))
                writer.WriteLine(QuoteCsvValue(New String("="c, 78)))
                writer.WriteLine(QuoteCsvValue(""))
                
                ' Write column headers
                Dim headers = table.Columns.Cast(Of DataColumn)().Select(Function(c) QuoteCsvValue(c.ColumnName)).ToArray()
                writer.WriteLine(String.Join(",", headers))
                
                ' Write data rows
                For Each row As DataRow In table.Rows
                    Dim values = table.Columns.Cast(Of DataColumn)().Select(Function(col) QuoteCsvValue(Convert.ToString(row(col)))).ToArray()
                    writer.WriteLine(String.Join(",", values))
                Next
                
                ' Add footer
                writer.WriteLine(QuoteCsvValue(""))
                writer.WriteLine(QuoteCsvValue(New String("="c, 78)))
                writer.WriteLine(QuoteCsvValue("End of Report"))
            End If
        End Using
    End Sub

    Private Function QuoteCsvValue(value As String) As String
        If value Is Nothing Then value = String.Empty
        ' Replace double quote with two double quotes
        value = value.Replace("""", """""")
        Return """" & value & """"
    End Function

    Private Function BuildSimplePdf(table As DataTable, title As String) As Byte()
        Dim lines As New List(Of String)()
        
        ' Header Section
        lines.Add(title)
        lines.Add(New String("="c, Math.Min(80, Math.Max(title.Length + 5, 50))))
        lines.Add("") ' Empty line for spacing
        
        ' Check if table is in key-value format (Field/Value) or table format (multiple columns)
        Dim isKeyValueFormat As Boolean = table.Columns.Count = 2 AndAlso 
                                          table.Columns.Contains("Field") AndAlso 
                                          table.Columns.Contains("Value")
        
        If isKeyValueFormat Then
            ' Body Section - Format matching the Audit Report form layout
            Dim inHeaderSection As Boolean = True
            For Each row As DataRow In table.Rows
                Dim fieldName As String = If(Convert.IsDBNull(row("Field")), "", Convert.ToString(row("Field")))
                Dim fieldValue As String = If(Convert.IsDBNull(row("Value")), "", Convert.ToString(row("Value")))
                
                ' Skip empty separator rows in PDF
                If String.IsNullOrWhiteSpace(fieldName) AndAlso String.IsNullOrWhiteSpace(fieldValue) Then
                    lines.Add("") ' Add empty line for spacing
                    Continue For
                End If
                
                ' Handle header section
                If fieldName = "AUDIT REPORT" Then
                    lines.Add("")
                    lines.Add("AUDIT REPORT")
                    lines.Add(New String("="c, 50))
                    Continue For
                End If
                
                If String.IsNullOrWhiteSpace(fieldName) Then
                    Continue For
                End If
                
                ' Format as "Field: Value" with proper alignment (matching form layout)
                Dim displayLine As String = fieldName.PadRight(20) & ": " & fieldValue
                
                ' Wrap long lines
                If displayLine.Length > 75 Then
                    Dim fieldPart As String = fieldName.PadRight(20) & ": "
                    Dim valuePart As String = fieldValue
                    Dim words As String() = valuePart.Split(" "c)
                    Dim currentLine As New StringBuilder(fieldPart)
                    
                    For Each word As String In words
                        If (currentLine.Length + word.Length + 1) > 75 Then
                            lines.Add(currentLine.ToString().Trim())
                            currentLine.Clear()
                            currentLine.Append(New String(" "c, 22)) ' Indent continuation lines
                        End If
                        If currentLine.Length > 0 AndAlso currentLine.Length > 22 Then currentLine.Append(" ")
                        currentLine.Append(word)
                    Next
                    If currentLine.Length > 0 Then
                        lines.Add(currentLine.ToString().Trim())
                    End If
                Else
                    lines.Add(displayLine)
                End If
            Next
        Else
            ' Table format - display as tabular data (only columns with data)
            ' Calculate column widths based on content
            Dim colWidths As New Dictionary(Of String, Integer)()
            For Each col As DataColumn In table.Columns
                ' Start with column name length
                Dim maxWidth As Integer = Math.Min(col.ColumnName.Length, 20)
                ' Check data in rows
                For Each row As DataRow In table.Rows
                    Dim cellValue As String = If(Convert.IsDBNull(row(col)), "", Convert.ToString(row(col)))
                    If cellValue.Length > maxWidth Then
                        maxWidth = Math.Min(cellValue.Length, 25) ' Cap at 25 characters
                    End If
                Next
                colWidths(col.ColumnName) = Math.Max(maxWidth, 10) ' Minimum 10 characters
            Next

            ' Add column headers with proper spacing
            Dim headerLine As New StringBuilder()
            For Each col As DataColumn In table.Columns
                If headerLine.Length > 0 Then headerLine.Append(" | ")
                Dim colName As String = col.ColumnName
                Dim width As Integer = colWidths(col.ColumnName)
                If colName.Length > width Then colName = colName.Substring(0, width - 3) & "..."
                headerLine.Append(colName.PadRight(width))
            Next
            lines.Add(headerLine.ToString())
            lines.Add(New String("-"c, Math.Min(120, headerLine.Length)))
            
            ' Add data rows with proper formatting
            Dim rowCount As Integer = 0
            For Each row As DataRow In table.Rows
                rowCount += 1
                ' Limit rows per page to avoid overload
                If rowCount > 30 Then
                    lines.Add("")
                    lines.Add("... (Additional " & (table.Rows.Count - rowCount + 1).ToString() & " rows not shown to prevent overload)")
                    Exit For
                End If
                
                Dim dataLine As New StringBuilder()
                For Each col As DataColumn In table.Columns
                    If dataLine.Length > 0 Then dataLine.Append(" | ")
                    Dim cellValue As String = If(Convert.IsDBNull(row(col)), "", Convert.ToString(row(col)))
                    Dim width As Integer = colWidths(col.ColumnName)
                    If cellValue.Length > width Then cellValue = cellValue.Substring(0, width - 3) & "..."
                    dataLine.Append(cellValue.PadRight(width))
                Next
                lines.Add(dataLine.ToString())
            Next
            
            ' Add summary if rows were truncated
            If rowCount < table.Rows.Count Then
                lines.Add("")
                lines.Add("Note: Report shows first 30 rows. Total records: " & table.Rows.Count.ToString())
            End If
        End If

        Dim streamContent As String = BuildPdfContent(lines)
        Dim streamBytes = Encoding.UTF8.GetBytes(streamContent)

        Dim objects As New List(Of Byte())()
        ' Fixed object references with proper spacing
        objects.Add(Encoding.ASCII.GetBytes("1 0 obj << /Type /Catalog /Pages 2 0 R >> endobj" & Environment.NewLine))
        objects.Add(Encoding.ASCII.GetBytes("2 0 obj << /Type /Pages /Kids [3 0 R] /Count 1 >> endobj" & Environment.NewLine))
        objects.Add(Encoding.ASCII.GetBytes("3 0 obj << /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Contents 4 0 R /Resources << /Font << /F1 5 0 R >> >> >> endobj" & Environment.NewLine))

        Dim streamBuilder As New StringBuilder()
        streamBuilder.AppendLine("4 0 obj << /Length " & streamBytes.Length & " >>")
        streamBuilder.AppendLine("stream")
        streamBuilder.Append(streamContent)
        streamBuilder.AppendLine("endstream")
        streamBuilder.AppendLine("endobj")
        objects.Add(Encoding.UTF8.GetBytes(streamBuilder.ToString()))

        objects.Add(Encoding.ASCII.GetBytes("5 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Helvetica >> endobj" & Environment.NewLine))

        Using ms As New MemoryStream()
            Using bw As New BinaryWriter(ms, Encoding.ASCII, True)
                ' PDF header
                bw.Write(Encoding.ASCII.GetBytes("%PDF-1.4" & Environment.NewLine))
                Dim offsets As New List(Of Long)()
                For Each objBytes In objects
                    offsets.Add(ms.Position)
                    bw.Write(objBytes)
                Next

                Dim xrefPosition As Long = ms.Position
                bw.Write(Encoding.ASCII.GetBytes("xref" & Environment.NewLine & "0 " & (objects.Count + 1).ToString() & Environment.NewLine))
                bw.Write(Encoding.ASCII.GetBytes("0000000000 65535 f " & Environment.NewLine))
                For Each off As Long In offsets
                    bw.Write(Encoding.ASCII.GetBytes(off.ToString("D10") & " 00000 n " & Environment.NewLine))
                Next

                bw.Write(Encoding.ASCII.GetBytes("trailer" & Environment.NewLine & "<< /Size " & (objects.Count + 1).ToString() & " /Root 1 0 R >>" & Environment.NewLine))
                bw.Write(Encoding.ASCII.GetBytes("startxref" & Environment.NewLine & xrefPosition.ToString() & Environment.NewLine & "%%EOF"))
            End Using
            Return ms.ToArray()
        End Using
    End Function

    Private Function BuildPdfContent(lines As IEnumerable(Of String)) As String
        Dim builder As New StringBuilder()
        Dim currentY As Integer = 750 ' Start a bit lower for header space
        Const lineHeight As Integer = 12
        Const headerFontSize As Integer = 16
        Const bodyFontSize As Integer = 9
        Dim isFirstLine As Boolean = True
        Dim lineCount As Integer = 0

        For Each line As String In lines
            ' Check if we need to start a new page (approximately 50 lines per page)
            If currentY < 50 AndAlso lineCount > 0 Then
                ' Add page break - note: This is a simple implementation
                ' For proper multi-page support, you'd need to create multiple page objects
                builder.AppendLine("BT /F1 " & bodyFontSize & " Tf 50 50 Td (--- Continued on next page ---) Tj ET")
                ' Reset Y position for new page (simplified - in production, create new page object)
                currentY = 750
            End If
            
            Dim sanitized = EscapePdfText(line)
            Dim fontSize As Integer = If(isFirstLine, headerFontSize, bodyFontSize)
            
            ' Set font size and position
            builder.AppendLine("BT /F1 " & fontSize & " Tf 50 " & currentY.ToString() & " Td (" & sanitized & ") Tj ET")
            currentY -= If(isFirstLine, lineHeight + 4, lineHeight) ' Extra space after header
            isFirstLine = False
            lineCount += 1
        Next

        Return builder.ToString()
    End Function

    Private Function EscapePdfText(text As String) As String
        If text Is Nothing Then text = String.Empty
        Return text.Replace("\", "\\").Replace("(", "\(").Replace(")", "\)").Replace(Environment.NewLine, "\n")
    End Function

    Private Function BuildAuditReportPdf(auditData As DataRow) As Byte()
        ' Helper function to safely get column value
        Dim GetValue As Func(Of String, String) = Function(colName As String) As String
            If auditData.Table.Columns.Contains(colName) AndAlso Not Convert.IsDBNull(auditData(colName)) Then
                Return auditData(colName).ToString()
            End If
            Return ""
        End Function

        ' Extract data
        Dim createdAt As DateTime? = Nothing
        If auditData.Table.Columns.Contains("createdAt") AndAlso Not Convert.IsDBNull(auditData("createdAt")) Then
            createdAt = Convert.ToDateTime(auditData("createdAt"))
        End If

        Dim dateFrom As String = If(createdAt.HasValue, createdAt.Value.ToString("dddd, dd MMMM yyyy"), "")
        Dim dateTo As String = dateFrom
        Dim timeFrom As String = If(createdAt.HasValue, createdAt.Value.ToString("HH:mm:ss"), "")
        Dim timeTo As String = timeFrom

        Dim username As String = GetValue("username")
        If String.IsNullOrWhiteSpace(username) Then username = "System"
        
        Dim userId As String = GetValue("userId")
        Dim logId As String = GetValue("logId")
        Dim description As String = GetValue("description")
        
        ' Handle both "module" and "tableName" column names
        Dim tableName As String = GetValue("module")
        If String.IsNullOrWhiteSpace(tableName) Then
            tableName = GetValue("tableName")
        End If
        
        Dim recordId As String = GetValue("recordId")
        Dim action As String = GetValue("action")
        Dim ipAddress As String = GetValue("ipAddress")
        Dim userAgent As String = GetValue("userAgent")
        Dim status As String = "Completed" ' Default status

        ' Build PDF content
        Dim streamContent As String = BuildAuditReportPdfContent(
            dateFrom, dateTo, timeFrom, timeTo,
            username, userId, logId, description,
            tableName, recordId, action,
            ipAddress, userAgent, status
        )
        
        Dim streamBytes = Encoding.UTF8.GetBytes(streamContent)

        Dim objects As New List(Of Byte())()
        ' PDF objects
        objects.Add(Encoding.ASCII.GetBytes("1 0 obj << /Type /Catalog /Pages 2 0 R >> endobj" & Environment.NewLine))
        objects.Add(Encoding.ASCII.GetBytes("2 0 obj << /Type /Pages /Kids [3 0 R] /Count 1 >> endobj" & Environment.NewLine))
        objects.Add(Encoding.ASCII.GetBytes("3 0 obj << /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Contents 4 0 R /Resources << /Font << /F1 5 0 R /F2 6 0 R >> >> >> endobj" & Environment.NewLine))

        Dim streamBuilder As New StringBuilder()
        streamBuilder.AppendLine("4 0 obj << /Length " & streamBytes.Length & " >>")
        streamBuilder.AppendLine("stream")
        streamBuilder.Append(streamContent)
        streamBuilder.AppendLine("endstream")
        streamBuilder.AppendLine("endobj")
        objects.Add(Encoding.UTF8.GetBytes(streamBuilder.ToString()))

        objects.Add(Encoding.ASCII.GetBytes("5 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Helvetica >> endobj" & Environment.NewLine))
        objects.Add(Encoding.ASCII.GetBytes("6 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold >> endobj" & Environment.NewLine))

        Using ms As New MemoryStream()
            Using bw As New BinaryWriter(ms, Encoding.ASCII, True)
                ' PDF header
                bw.Write(Encoding.ASCII.GetBytes("%PDF-1.4" & Environment.NewLine))
                Dim offsets As New List(Of Long)()
                For Each objBytes In objects
                    offsets.Add(ms.Position)
                    bw.Write(objBytes)
                Next

                Dim xrefPosition As Long = ms.Position
                bw.Write(Encoding.ASCII.GetBytes("xref" & Environment.NewLine & "0 " & (objects.Count + 1).ToString() & Environment.NewLine))
                bw.Write(Encoding.ASCII.GetBytes("0000000000 65535 f " & Environment.NewLine))
                For Each off As Long In offsets
                    bw.Write(Encoding.ASCII.GetBytes(off.ToString("D10") & " 00000 n " & Environment.NewLine))
                Next

                bw.Write(Encoding.ASCII.GetBytes("trailer" & Environment.NewLine & "<< /Size " & (objects.Count + 1).ToString() & " /Root 1 0 R >>" & Environment.NewLine))
                bw.Write(Encoding.ASCII.GetBytes("startxref" & Environment.NewLine & xrefPosition.ToString() & Environment.NewLine & "%%EOF"))
            End Using
            Return ms.ToArray()
        End Using
    End Function

    Private Function BuildAuditReportPdfContent(
        dateFrom As String, dateTo As String, timeFrom As String, timeTo As String,
        userName As String, userId As String, logId As String, description As String,
        tableName As String, recordId As String, action As String,
        ipAddress As String, userAgent As String, status As String) As String
        
        Dim builder As New StringBuilder()
        Dim y As Integer = 740
        
        ' Draw border rectangle (outer box)
        builder.AppendLine("0.5 w") ' Line width
        builder.AppendLine("50 50 512 692 re S") ' Rectangle: x y width height
        
        ' Draw header box with background
        builder.AppendLine("0.9 g") ' Light gray fill
        builder.AppendLine("50 710 512 32 re f") ' Filled rectangle for header
        builder.AppendLine("0 g") ' Back to black
        builder.AppendLine("50 710 512 32 re S") ' Border for header
        
        ' Title - AUDIT REPORT (Bold, centered)
        builder.AppendLine("BT /F2 18 Tf 250 718 Td (AUDIT REPORT) Tj ET")
        
        y = 685
        
        ' Date range section with boxes
        ' From label and date box
        builder.AppendLine("BT /F1 10 Tf 70 " & y & " Td (From :) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 150 20 re S") ' Date box
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(dateFrom) & ") Tj ET")
        
        ' To label and date box
        builder.AppendLine("BT /F1 10 Tf 320 " & y & " Td (To :) Tj ET")
        builder.AppendLine("360 " & (y - 5) & " 150 20 re S") ' Date box
        builder.AppendLine("BT /F1 9 Tf 365 " & (y - 1) & " Td (" & EscapePdfText(dateTo) & ") Tj ET")
        
        y -= 40
        
        ' User section
        builder.AppendLine("BT /F1 10 Tf 70 " & y & " Td (User :) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 380 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(userName) & ") Tj ET")
        
        y -= 30
        
        ' User ID section
        builder.AppendLine("BT /F1 10 Tf 70 " & y & " Td (User ID :) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 380 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(userId) & ") Tj ET")
        
        y -= 30
        
        ' Log ID section
        builder.AppendLine("BT /F1 10 Tf 70 " & y & " Td (Log ID :) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 380 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(logId) & ") Tj ET")
        
        y -= 40
        
        ' Description section (larger box)
        builder.AppendLine("BT /F1 10 Tf 70 " & y & " Td (Description :) Tj ET")
        builder.AppendLine("70 " & (y - 95) & " 472 90 re S") ' Large box for description
        
        ' Word wrap description text
        Dim descLines As List(Of String) = WrapText(description, 65)
        Dim descY As Integer = y - 15
        For Each line As String In descLines.Take(5) ' Limit to 5 lines
            builder.AppendLine("BT /F1 9 Tf 75 " & descY & " Td (" & EscapePdfText(line) & ") Tj ET")
            descY -= 12
        Next
        
        y -= 110
        
        ' Two-column section
        ' Left column
        Dim leftX As Integer = 70
        Dim rightX As Integer = 320
        
        ' Table Name
        builder.AppendLine("BT /F1 10 Tf " & leftX & " " & y & " Td (table Name :) Tj ET")
        builder.AppendLine(leftX & " " & (y - 25) & " 220 20 re S")
        builder.AppendLine("BT /F1 9 Tf " & (leftX + 5) & " " & (y - 21) & " Td (" & EscapePdfText(tableName) & ") Tj ET")
        
        ' IP Address
        builder.AppendLine("BT /F1 10 Tf " & rightX & " " & y & " Td (IP Address :) Tj ET")
        builder.AppendLine(rightX & " " & (y - 25) & " 222 20 re S")
        builder.AppendLine("BT /F1 9 Tf " & (rightX + 5) & " " & (y - 21) & " Td (" & EscapePdfText(ipAddress) & ") Tj ET")
        
        y -= 40
        
        ' Record ID
        builder.AppendLine("BT /F1 10 Tf " & leftX & " " & y & " Td (Record ID :) Tj ET")
        builder.AppendLine(leftX & " " & (y - 25) & " 220 20 re S")
        builder.AppendLine("BT /F1 9 Tf " & (leftX + 5) & " " & (y - 21) & " Td (" & EscapePdfText(recordId) & ") Tj ET")
        
        ' User Agent (truncated if too long)
        Dim userAgentShort As String = If(userAgent.Length > 30, userAgent.Substring(0, 27) & "...", userAgent)
        builder.AppendLine("BT /F1 10 Tf " & rightX & " " & y & " Td (User Agent :) Tj ET")
        builder.AppendLine(rightX & " " & (y - 25) & " 222 20 re S")
        builder.AppendLine("BT /F1 9 Tf " & (rightX + 5) & " " & (y - 21) & " Td (" & EscapePdfText(userAgentShort) & ") Tj ET")
        
        y -= 40
        
        ' Action
        builder.AppendLine("BT /F1 10 Tf " & leftX & " " & y & " Td (Action :) Tj ET")
        builder.AppendLine(leftX & " " & (y - 25) & " 220 20 re S")
        builder.AppendLine("BT /F1 9 Tf " & (leftX + 5) & " " & (y - 21) & " Td (" & EscapePdfText(action) & ") Tj ET")
        
        ' Status
        builder.AppendLine("BT /F1 10 Tf " & rightX & " " & y & " Td (Status :) Tj ET")
        builder.AppendLine(rightX & " " & (y - 25) & " 222 20 re S")
        builder.AppendLine("BT /F1 9 Tf " & (rightX + 5) & " " & (y - 21) & " Td (" & EscapePdfText(status) & ") Tj ET")
        
        Return builder.ToString()
    End Function

    Private Function WrapText(text As String, maxChars As Integer) As List(Of String)
        Dim lines As New List(Of String)()
        If String.IsNullOrWhiteSpace(text) Then
            lines.Add("")
            Return lines
        End If

        Dim words As String() = text.Split(" "c)
        Dim currentLine As New StringBuilder()
        
        For Each word As String In words
            If currentLine.Length + word.Length + 1 > maxChars Then
                If currentLine.Length > 0 Then
                    lines.Add(currentLine.ToString())
                    currentLine.Clear()
                End If
            End If
            If currentLine.Length > 0 Then currentLine.Append(" ")
            currentLine.Append(word)
        Next
        
        If currentLine.Length > 0 Then
            lines.Add(currentLine.ToString())
        End If
        
        Return lines
    End Function

    ''' <summary>
    ''' Export Requisition Issue Slip to PDF with proper form layout
    ''' </summary>
    Public Sub ExportRequisitionSlipToPdf(requestData As DataRow, suggestedFileName As String)
        If requestData Is Nothing Then
            MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "PDF Files|*.pdf"
            dialog.FileName = suggestedFileName
            dialog.AddExtension = True
            dialog.DefaultExt = "pdf"
            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    Dim filePath = dialog.FileName
                    If Not filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) Then
                        filePath = filePath & ".pdf"
                    End If

                    Dim pdfBytes = BuildRequisitionSlipPdf(requestData)
                    File.WriteAllBytes(filePath, pdfBytes)
                    MessageBox.Show("Requisition Issue Slip exported successfully to PDF.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to export PDF file: " & ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Function BuildRequisitionSlipPdf(requestData As DataRow) As Byte()
        ' Helper function to safely get column value
        Dim GetValue As Func(Of String, String) = Function(colName As String) As String
            If requestData.Table.Columns.Contains(colName) AndAlso Not Convert.IsDBNull(requestData(colName)) Then
                Return requestData(colName).ToString()
            End If
            Return ""
        End Function

        Dim GetDateValue As Func(Of String, String) = Function(colName As String) As String
            If requestData.Table.Columns.Contains(colName) AndAlso Not Convert.IsDBNull(requestData(colName)) Then
                Dim dateObj = requestData(colName)
                If TypeOf dateObj Is DateTime Then
                    Return CType(dateObj, DateTime).ToString("dddd, dd MMMM yyyy")
                ElseIf TypeOf dateObj Is String Then
                    Dim parsedDate As DateTime
                    If DateTime.TryParse(CStr(dateObj), parsedDate) Then
                        Return parsedDate.ToString("dddd, dd MMMM yyyy")
                    End If
                End If
            End If
            Return ""
        End Function

        ' Extract data
        Dim requestId As String = GetValue("request_id")
        If String.IsNullOrEmpty(requestId) Then requestId = GetValue("requestId")
        
        Dim requesterName As String = GetValue("requesterName")
        If String.IsNullOrEmpty(requesterName) Then requesterName = GetValue("requester_name")
        
        Dim position As String = GetValue("position")
        Dim department As String = GetValue("departmentName")
        If String.IsNullOrEmpty(department) Then department = GetValue("department")
        
        Dim dateOfRequest As String = GetDateValue("dateOfRequest")
        If String.IsNullOrEmpty(dateOfRequest) Then dateOfRequest = GetDateValue("request_date")
        
        Dim itemName As String = GetValue("itemName")
        If String.IsNullOrEmpty(itemName) Then itemName = GetValue("item_name")
        
        Dim quantity As String = GetValue("quantityRequested")
        If String.IsNullOrEmpty(quantity) Then quantity = GetValue("quantity")
        
        Dim unit As String = GetValue("unit")
        Dim description As String = GetValue("description")
        Dim purpose As String = GetValue("purpose")
        Dim status As String = GetValue("status")
        
        Dim approvedBy As String = GetValue("approved_by_name")
        If String.IsNullOrEmpty(approvedBy) Then approvedBy = GetValue("approvedBy")
        
        Dim approvedDate As String = GetDateValue("approvedDate")
        If String.IsNullOrEmpty(approvedDate) Then approvedDate = GetDateValue("approval_date")
        
        Dim remarks As String = GetValue("remarks")
        
        Dim createdAt As String = GetDateValue("createdAt")
        If String.IsNullOrEmpty(createdAt) Then createdAt = DateTime.Now.ToString("dddd, dd MMMM yyyy")
        
        Dim updatedAt As String = GetDateValue("updatedAt")
        If String.IsNullOrEmpty(updatedAt) Then updatedAt = createdAt

        ' Build PDF content
        Dim streamContent As String = BuildRequisitionSlipPdfContent(
            requestId, requesterName, position, department,
            dateOfRequest, itemName, quantity, unit,
            description, purpose, status, approvedBy,
            approvedDate, remarks, createdAt, updatedAt
        )
        
        Dim streamBytes = Encoding.UTF8.GetBytes(streamContent)

        Dim objects As New List(Of Byte())()
        objects.Add(Encoding.ASCII.GetBytes("1 0 obj << /Type /Catalog /Pages 2 0 R >> endobj" & Environment.NewLine))
        objects.Add(Encoding.ASCII.GetBytes("2 0 obj << /Type /Pages /Kids [3 0 R] /Count 1 >> endobj" & Environment.NewLine))
        objects.Add(Encoding.ASCII.GetBytes("3 0 obj << /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Contents 4 0 R /Resources << /Font << /F1 5 0 R /F2 6 0 R >> >> >> endobj" & Environment.NewLine))

        Dim streamBuilder As New StringBuilder()
        streamBuilder.AppendLine("4 0 obj << /Length " & streamBytes.Length & " >>")
        streamBuilder.AppendLine("stream")
        streamBuilder.Append(streamContent)
        streamBuilder.AppendLine("endstream")
        streamBuilder.AppendLine("endobj")
        objects.Add(Encoding.UTF8.GetBytes(streamBuilder.ToString()))

        objects.Add(Encoding.ASCII.GetBytes("5 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Helvetica >> endobj" & Environment.NewLine))
        objects.Add(Encoding.ASCII.GetBytes("6 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold >> endobj" & Environment.NewLine))

        Using ms As New MemoryStream()
            Using bw As New BinaryWriter(ms, Encoding.ASCII, True)
                bw.Write(Encoding.ASCII.GetBytes("%PDF-1.4" & Environment.NewLine))
                Dim offsets As New List(Of Long)()
                For Each objBytes In objects
                    offsets.Add(ms.Position)
                    bw.Write(objBytes)
                Next

                Dim xrefPosition As Long = ms.Position
                bw.Write(Encoding.ASCII.GetBytes("xref" & Environment.NewLine & "0 " & (objects.Count + 1).ToString() & Environment.NewLine))
                bw.Write(Encoding.ASCII.GetBytes("0000000000 65535 f " & Environment.NewLine))
                For Each off As Long In offsets
                    bw.Write(Encoding.ASCII.GetBytes(off.ToString("D10") & " 00000 n " & Environment.NewLine))
                Next

                bw.Write(Encoding.ASCII.GetBytes("trailer" & Environment.NewLine & "<< /Size " & (objects.Count + 1).ToString() & " /Root 1 0 R >>" & Environment.NewLine))
                bw.Write(Encoding.ASCII.GetBytes("startxref" & Environment.NewLine & xrefPosition.ToString() & Environment.NewLine & "%%EOF"))
            End Using
            Return ms.ToArray()
        End Using
    End Function

    Private Function BuildRequisitionSlipPdfContent(
        requestId As String, requesterName As String, position As String, department As String,
        dateOfRequest As String, itemName As String, quantity As String, unit As String,
        description As String, purpose As String, status As String, approvedBy As String,
        approvedDate As String, remarks As String, createdAt As String, updatedAt As String) As String
        
        Dim builder As New StringBuilder()
        Dim y As Integer = 740
        
        ' Draw outer border
        builder.AppendLine("0.5 w")
        builder.AppendLine("40 40 532 712 re S")
        
        ' Draw header box with background
        builder.AppendLine("0.9 g")
        builder.AppendLine("40 720 532 32 re f")
        builder.AppendLine("0 g")
        builder.AppendLine("40 720 532 32 re S")
        
        ' Title - REQUISITION ISSUE SLIP (Bold, centered)
        builder.AppendLine("BT /F2 18 Tf 175 728 Td (REQUISITION ISSUE SLIP) Tj ET")
        
        y = 695
        
        ' First row: Request ID (right aligned)
        builder.AppendLine("BT /F1 10 Tf 380 " & y & " Td (Request ID:) Tj ET")
        builder.AppendLine("450 " & (y - 5) & " 110 20 re S")
        builder.AppendLine("BT /F1 9 Tf 455 " & (y - 1) & " Td (" & EscapePdfText(requestId) & ") Tj ET")
        
        y -= 40
        
        ' Second row: Requester Name and Position
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Requester Name:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 200 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(requesterName) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 360 " & y & " Td (Position:) Tj ET")
        builder.AppendLine("420 " & (y - 5) & " 140 20 re S")
        builder.AppendLine("BT /F1 9 Tf 425 " & (y - 1) & " Td (" & EscapePdfText(position) & ") Tj ET")
        
        y -= 30
        
        ' Third row: Department and Date of Request
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Department:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 200 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(department) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 360 " & y & " Td (Date of Request:) Tj ET")
        builder.AppendLine("455 " & (y - 5) & " 105 20 re S")
        builder.AppendLine("BT /F1 9 Tf 460 " & (y - 1) & " Td (" & EscapePdfText(dateOfRequest) & ") Tj ET")
        
        y -= 40
        
        ' Fourth row: Item Name and Quantity
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Item Name:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 200 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(itemName) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 360 " & y & " Td (Quantity:) Tj ET")
        builder.AppendLine("420 " & (y - 5) & " 60 20 re S")
        builder.AppendLine("BT /F1 9 Tf 425 " & (y - 1) & " Td (" & EscapePdfText(quantity) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 490 " & y & " Td (Unit:) Tj ET")
        builder.AppendLine("520 " & (y - 5) & " 40 20 re S")
        builder.AppendLine("BT /F1 9 Tf 525 " & (y - 1) & " Td (" & EscapePdfText(unit) & ") Tj ET")
        
        y -= 40
        
        ' Description section
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Description:) Tj ET")
        builder.AppendLine("50 " & (y - 95) & " 250 90 re S")
        Dim descLines As List(Of String) = WrapText(description, 35)
        Dim descY As Integer = y - 15
        For Each line As String In descLines.Take(5)
            builder.AppendLine("BT /F1 9 Tf 55 " & descY & " Td (" & EscapePdfText(line) & ") Tj ET")
            descY -= 12
        Next
        
        ' Purpose section
        builder.AppendLine("BT /F1 10 Tf 310 " & y & " Td (Purpose:) Tj ET")
        builder.AppendLine("310 " & (y - 95) & " 250 90 re S")
        Dim purposeLines As List(Of String) = WrapText(purpose, 35)
        Dim purposeY As Integer = y - 15
        For Each line As String In purposeLines.Take(5)
            builder.AppendLine("BT /F1 9 Tf 315 " & purposeY & " Td (" & EscapePdfText(line) & ") Tj ET")
            purposeY -= 12
        Next
        
        y -= 110
        
        ' Status row
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Status:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 200 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(status) & ") Tj ET")
        
        y -= 40
        
        ' Approved By and Approved Date
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Approved By:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 200 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(approvedBy) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 360 " & y & " Td (Approved Date:) Tj ET")
        builder.AppendLine("455 " & (y - 5) & " 105 20 re S")
        builder.AppendLine("BT /F1 9 Tf 460 " & (y - 1) & " Td (" & EscapePdfText(approvedDate) & ") Tj ET")
        
        y -= 40
        
        ' Remarks section
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Remarks:) Tj ET")
        builder.AppendLine("50 " & (y - 75) & " 510 70 re S")
        Dim remarksLines As List(Of String) = WrapText(remarks, 75)
        Dim remarksY As Integer = y - 15
        For Each line As String In remarksLines.Take(4)
            builder.AppendLine("BT /F1 9 Tf 55 " & remarksY & " Td (" & EscapePdfText(line) & ") Tj ET")
            remarksY -= 12
        Next
        
        y -= 90
        
        ' Created and Updated dates
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Created at:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 150 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(createdAt) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 360 " & y & " Td (Updated at:) Tj ET")
        builder.AppendLine("455 " & (y - 5) & " 105 20 re S")
        builder.AppendLine("BT /F1 9 Tf 460 " & (y - 1) & " Td (" & EscapePdfText(updatedAt) & ") Tj ET")
        
        Return builder.ToString()
    End Function
End Module

