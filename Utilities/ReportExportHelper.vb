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
            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    Dim pdfBytes = BuildSimplePdf(table, title)
                    File.WriteAllBytes(dialog.FileName, pdfBytes)
                    MessageBox.Show(successMessage, "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to export PDF file: " & ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub WriteCsv(table As DataTable, filePath As String)
        Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
            Dim headers = table.Columns.Cast(Of DataColumn)().Select(Function(c) QuoteCsvValue(c.ColumnName))
            writer.WriteLine(String.Join(",", headers))
            For Each row As DataRow In table.Rows
                Dim values = table.Columns.Cast(Of DataColumn)().
                    Select(Function(col) QuoteCsvValue(Convert.ToString(row(col))))
                writer.WriteLine(String.Join(",", values))
            Next
        End Using
    End Sub

    Private Function QuoteCsvValue(value As String) As String
        If value Is Nothing Then value = String.Empty
        value = value.Replace("""", """""")
        Return """" & value & """"
    End Function

    Private Function BuildSimplePdf(table As DataTable, title As String) As Byte()
        Dim lines As New List(Of String) From {
            title,
            New String("-"c, Math.Min(120, Math.Max(title.Length + 10, 60))),
            String.Join(" | ", table.Columns.Cast(Of DataColumn)().Select(Function(c) c.ColumnName))
        }

        For Each row As DataRow In table.Rows
            Dim values = table.Columns.Cast(Of DataColumn)().
                Select(Function(col) Convert.ToString(row(col)))
            lines.Add(String.Join(" | ", values))
        Next

        Dim streamContent As String = BuildPdfContent(lines)
        Dim streamBytes = Encoding.UTF8.GetBytes(streamContent)

        Dim objects As New List(Of Byte())
        objects.Add(Encoding.ASCII.GetBytes("1 0 obj << /Type /Catalog /Pages 2 0 R >> endobj" & Environment.NewLine))
        objects.Add(Encoding.ASCII.GetBytes("2 0 obj << /Type /Pages /Kids [3 0 R] /Count 1 >> endobj" & Environment.NewLine))
        objects.Add(Encoding.ASCII.GetBytes("3 0 obj << /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Contents 4 0 R /Resources << /Font << /F1 5 0 R >> >> >> endobj" & Environment.NewLine))

        Dim streamBuilder As New StringBuilder()
        streamBuilder.AppendLine($"4 0 obj << /Length {streamBytes.Length} >>")
        streamBuilder.AppendLine("stream")
        streamBuilder.Append(streamContent)
        streamBuilder.AppendLine("endstream")
        streamBuilder.AppendLine("endobj")
        objects.Add(Encoding.UTF8.GetBytes(streamBuilder.ToString()))

        objects.Add(Encoding.ASCII.GetBytes("5 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Helvetica >> endobj" & Environment.NewLine))

        Using ms As New MemoryStream()
            Using writer As New BinaryWriter(ms, Encoding.ASCII, True)
                writer.Write(Encoding.ASCII.GetBytes("%PDF-1.4" & Environment.NewLine))
                Dim offsets As New List(Of Long)
                For Each obj In objects
                    offsets.Add(ms.Position)
                    writer.Write(obj)
                Next

                Dim xrefPosition = ms.Position
                writer.Write(Encoding.ASCII.GetBytes($"xref{Environment.NewLine}0 {objects.Count + 1}{Environment.NewLine}"))
                writer.Write(Encoding.ASCII.GetBytes("0000000000 65535 f " & Environment.NewLine))
                For Each offset In offsets
                    writer.Write(Encoding.ASCII.GetBytes(offset.ToString("0000000000") & " 00000 n " & Environment.NewLine))
                Next

                writer.Write(Encoding.ASCII.GetBytes("trailer" & Environment.NewLine & $"<< /Size {objects.Count + 1} /Root 1 0 R >>" & Environment.NewLine))
                writer.Write(Encoding.ASCII.GetBytes("startxref" & Environment.NewLine & xrefPosition.ToString() & Environment.NewLine & "%%EOF"))
            End Using
            Return ms.ToArray()
        End Using
    End Function

    Private Function BuildPdfContent(lines As IEnumerable(Of String)) As String
        Dim builder As New StringBuilder()
        Dim currentY As Integer = 780
        Const lineHeight As Integer = 14

        For Each line As String In lines
            If currentY < 36 Then Exit For
            Dim sanitized = EscapePdfText(line)
            builder.AppendLine($"BT /F1 10 Tf 36 {currentY} Td ({sanitized}) Tj ET")
            currentY -= lineHeight
        Next

        Return builder.ToString()
    End Function

    Private Function EscapePdfText(text As String) As String
        If text Is Nothing Then text = String.Empty
        Return text.Replace("\", "\\").Replace("(", "\(").Replace(")", "\)").Replace(Environment.NewLine, "\n")
    End Function
End Module

