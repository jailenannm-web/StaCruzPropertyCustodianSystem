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

    Private Sub WriteCsv(table As DataTable, filePath As String, Optional isBulkExport As Boolean = False)
        ' Use UTF8 with BOM so Excel recognizes encoding reliably
        Using writer As New StreamWriter(filePath, False, New UTF8Encoding(True))
            ' Check if this is a key-value format (Field/Value) or table format
            Dim isKeyValueFormat As Boolean = table.Columns.Count = 2 AndAlso 
                                              table.Columns.Contains("Field") AndAlso 
                                              table.Columns.Contains("Value") AndAlso
                                              Not isBulkExport
            
            If isKeyValueFormat Then
                ' Professional key-value format for single audit record
                ' Add header section
                writer.WriteLine(QuoteCsvValue("AUDIT REPORT"))
                writer.WriteLine("")
                writer.WriteLine(QuoteCsvValue("Sta Cruz Property Custodian System"))
                writer.WriteLine(QuoteCsvValue("Report Generated: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
                writer.WriteLine("")
                writer.WriteLine(QuoteCsvValue(New String("="c, 78)))
                writer.WriteLine("")
                
                ' Write field-value pairs with proper formatting
                For Each row As DataRow In table.Rows
                    Dim fieldName As String = If(Convert.IsDBNull(row("Field")), "", Convert.ToString(row("Field")))
                    Dim fieldValue As String = If(Convert.IsDBNull(row("Value")), "", Convert.ToString(row("Value")))
                    
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
                writer.WriteLine(QuoteCsvValue(New String("="c, 78)))
                writer.WriteLine(QuoteCsvValue("End of Report"))
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
End Module

