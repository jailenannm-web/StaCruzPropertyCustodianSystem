Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Public Module ReportExportHelper
    Public Sub ExportDataTableToCsv(table As DataTable, suggestedFileName As String, Optional successMessage As String = "CSV file exported successfully.")
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
                    WriteCsv(table, dialog.FileName)
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

    Private Sub WriteCsv(table As DataTable, filePath As String)
        ' Use UTF8 with BOM so Excel recognizes encoding reliably
        Using writer As New StreamWriter(filePath, False, New UTF8Encoding(True))
            Dim headers = table.Columns.Cast(Of DataColumn)().Select(Function(c) QuoteCsvValue(c.ColumnName)).ToArray()
            writer.WriteLine(String.Join(",", headers))
            For Each row As DataRow In table.Rows
                Dim values = table.Columns.Cast(Of DataColumn)().Select(Function(col) QuoteCsvValue(Convert.ToString(row(col)))).ToArray()
                writer.WriteLine(String.Join(",", values))
            Next
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
        
        ' Body Section - Format as key-value pairs for better readability
        For Each row As DataRow In table.Rows
            Dim fieldName As String = If(Convert.IsDBNull(row("Field")), "", Convert.ToString(row("Field")))
            Dim fieldValue As String = If(Convert.IsDBNull(row("Value")), "", Convert.ToString(row("Value")))
            
            ' Skip empty separator rows in PDF
            If String.IsNullOrWhiteSpace(fieldName) AndAlso String.IsNullOrWhiteSpace(fieldValue) Then
                lines.Add("") ' Add empty line for spacing
            ElseIf Not String.IsNullOrWhiteSpace(fieldName) Then
                ' Format as "Field: Value" for better readability
                Dim displayLine As String = fieldName & ": " & fieldValue
                ' Wrap long lines
                If displayLine.Length > 80 Then
                    Dim words As String() = displayLine.Split(" "c)
                    Dim currentLine As New StringBuilder()
                    For Each word As String In words
                        If (currentLine.Length + word.Length + 1) > 80 Then
                            lines.Add(currentLine.ToString().Trim())
                            currentLine.Clear()
                        End If
                        If currentLine.Length > 0 Then currentLine.Append(" ")
                        currentLine.Append(word)
                    Next
                    If currentLine.Length > 0 Then
                        lines.Add(currentLine.ToString().Trim())
                    End If
                Else
                    lines.Add(displayLine)
                End If
            End If
        Next

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
        Const lineHeight As Integer = 14
        Const headerFontSize As Integer = 16
        Const bodyFontSize As Integer = 10
        Dim isFirstLine As Boolean = True

        For Each line As String In lines
            If currentY < 50 Then Exit For ' Stop before bottom margin
            
            Dim sanitized = EscapePdfText(line)
            Dim fontSize As Integer = If(isFirstLine, headerFontSize, bodyFontSize)
            
            ' Set font size and position
            builder.AppendLine("BT /F1 " & fontSize & " Tf 50 " & currentY.ToString() & " Td (" & sanitized & ") Tj ET")
            currentY -= If(isFirstLine, lineHeight + 4, lineHeight) ' Extra space after header
            isFirstLine = False
        Next

        Return builder.ToString()
    End Function

    Private Function EscapePdfText(text As String) As String
        If text Is Nothing Then text = String.Empty
        Return text.Replace("\", "\\").Replace("(", "\(").Replace(")", "\)").Replace(Environment.NewLine, "\n")
    End Function
End Module

