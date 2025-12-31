Imports System
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic

Public Class BorrowingAndReturnSlip
    Private borrowingTable As DataTable
    Private currentBorrowId As Integer?
    Private currentItemName As String

    ' Default constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Constructor with borrowId and itemName
    Public Sub New(borrowId As Integer, itemName As String)
        InitializeComponent()
        currentBorrowId = borrowId
        currentItemName = itemName
    End Sub

    Private Sub BorrowingAndReturnSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If currentBorrowId.HasValue Then
            LoadBorrowingDataForItem(currentBorrowId.Value)
        Else
            LoadBorrowingData()
        End If
    End Sub

    ''' <summary>
    ''' Load borrowing data for a specific borrowed item
    ''' </summary>
    Private Sub LoadBorrowingDataForItem(borrowId As Integer)
        Try
            Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
            If conn Is Nothing Then Return
            If Not DatabaseConnection.SafeOpenConnection(conn) Then Return

            ' Get the borrowed item record with all transaction details
            Dim query As String = "SELECT bi.*, " &
                                 "p.itemName, p.propertyNumber, p.serialNumber, p.category, " &
                                 "p.description, p.location, p.condition, " &
                                 "d.departmentName, " &
                                 "u.fullName AS approvedByName " &
                                 "FROM borrowed_items bi " &
                                 "LEFT JOIN properties p ON bi.itemId = p.propertyId AND bi.itemType = 'property' " &
                                 "LEFT JOIN departments d ON bi.departmentId = d.departmentId " &
                                 "LEFT JOIN property_requests pr ON bi.requestId = pr.requestId " &
                                 "LEFT JOIN users u ON pr.approvedBy = u.userId " &
                                 "WHERE bi.borrowId = @borrowId"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@borrowId", borrowId)
                Using adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    If dt.Rows.Count > 0 Then
                        Dim row As DataRow = dt.Rows(0)
                        
                        ' Populate form fields
                        borrowedId.Text = borrowId.ToString()
                        itemType.Text = SafeGetString(row, "itemType", "property")
                        requestId.Text = SafeGetString(row, "requestId", "")
                        itemID.Text = SafeGetString(row, "itemId", "")
                        borrowedName.Text = SafeGetString(row, "borrowerName", "")
                        borrowerPosition.Text = SafeGetString(row, "borrowerPosition", "")
                        departmentId.Text = SafeGetString(row, "departmentName", "")
                        status.Text = SafeGetString(row, "status", "")
                        conditionOnReturn.Text = SafeGetString(row, "conditionOnReturn", "N/A")
                        remarks.Text = SafeGetString(row, "remarks", "")
                        
                        ' Set dates
                        If Not row.IsNull("borrowDate") Then
                            borrowerDate.Value = Convert.ToDateTime(row("borrowDate"))
                        End If
                        
                        ' Note: expectedReturnDate column was removed and replaced with returnReason
                        ' Set a default expected return date (30 days from borrow date) if needed
                        If Not row.IsNull("borrowDate") Then
                            expectedReturnDate.Value = Convert.ToDateTime(row("borrowDate")).AddDays(30)
                        End If
                        
                        If Not row.IsNull("actualReturnDate") Then
                            actualReturnDate.Value = Convert.ToDateTime(row("actualReturnDate"))
                        End If
                    End If
                End Using
            End Using

            If conn.State = ConnectionState.Open Then conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading borrowing data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[BorrowingAndReturnSlip] Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadBorrowingData()
        Try
            ' Load property requests that have been approved/borrowed/returned
            Dim dt As DataTable = DatabaseConnection.GetAllPropertyRequests()
            If dt Is Nothing Then
                borrowingTable = New DataTable()
                Return
            End If

            ' Build borrowing table
            borrowingTable = BuildBorrowingTable(dt)

            ' Populate form fields with first record if available
            If dt.Rows.Count > 0 Then
                Dim firstRow As DataRow = dt.Rows(0)
                itemType.Text = SafeGetString(firstRow, "request_type", "property")
                status.Text = SafeGetString(firstRow, "status", "Pending")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading borrowing data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            borrowingTable = New DataTable()
        End Try
    End Sub

    Private Sub Label16_Click(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles RoundedButton3.Click
        ExportToCSV()
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles RoundedButton2.Click
        ExportToPDF()
    End Sub

    Private Sub RoundedButton4_Click(sender As Object, e As EventArgs) Handles RoundedButton4.Click
        Me.Close()
    End Sub

    Private Sub ExportToCSV()
        Try
            If Not currentBorrowId.HasValue Then
                MessageBox.Show("No borrow record loaded.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Create clean CSV structure
            Using saveDialog As New SaveFileDialog()
                saveDialog.Filter = "CSV Files (*.csv)|*.csv"
                saveDialog.Title = "Save Borrowing and Return Slip as CSV"
                saveDialog.FileName = "BorrowingAndReturnSlip_" & borrowedId.Text & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    Dim filePath As String = saveDialog.FileName
                    If Not filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) Then
                        filePath = filePath & ".csv"
                    End If

                    ' Build professional CSV content
                    Dim csv As New System.Text.StringBuilder()

                    ' Header
                    csv.AppendLine("BORROWING AND RETURN SLIP")
                    csv.AppendLine("")
                    csv.AppendLine("Sta Cruz Property Custodian System")
                    csv.AppendLine("Generated: " & DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"))
                    csv.AppendLine("")
                    csv.AppendLine("=" & New String("="c, 80))
                    csv.AppendLine("")

                    ' Request Information (Single Row)
                    csv.AppendLine("IDENTIFICATION")
                    csv.AppendLine("""Request ID"",""" & requestId.Text & """")
                    csv.AppendLine("""Item Type"",""" & itemType.Text & """")
                    csv.AppendLine("""Item ID"",""" & itemID.Text & """")
                    csv.AppendLine("")

                    ' Borrower Details
                    csv.AppendLine("BORROWER INFORMATION")
                    csv.AppendLine("""Borrowed Name"",""" & borrowedName.Text & """")
                    Dim posValue As String = If(borrowerPosition.SelectedItem IsNot Nothing, borrowerPosition.SelectedItem.ToString(), borrowerPosition.Text)
                    csv.AppendLine("""Borrower Position"",""" & posValue & """")
                    csv.AppendLine("""Department ID"",""" & departmentId.Text & """")
                    csv.AppendLine("")

                    ' Transaction Dates
                    csv.AppendLine("TRANSACTION DATES")
                    csv.AppendLine("""Borrower Date"",""" & borrowerDate.Value.ToString("dddd, dd MMMM yyyy") & """")
                    csv.AppendLine("""Expected Return Date"",""" & expectedReturnDate.Value.ToString("dddd, dd MMMM yyyy") & """")
                    csv.AppendLine("""Actual Return Date"",""" & actualReturnDate.Value.ToString("dddd, dd MMMM yyyy") & """")
                    csv.AppendLine("")

                    ' Status and Condition
                    csv.AppendLine("STATUS INFORMATION")
                    csv.AppendLine("""Condition on Return"",""" & conditionOnReturn.Text & """")
                    Dim statusValue As String = If(status.SelectedItem IsNot Nothing, status.SelectedItem.ToString(), status.Text)
                    csv.AppendLine("""Status"",""" & statusValue & """")
                    csv.AppendLine("""Remarks"",""" & remarks.Text.Replace("""", """""") & """")
                    csv.AppendLine("")

                    ' Footer
                    csv.AppendLine("=" & New String("="c, 80))
                    csv.AppendLine("Report generated by: " & Environment.UserName)
                    csv.AppendLine("System: Sta Cruz Property Custodian Management System")

                    ' Write to file
                    System.IO.File.WriteAllText(filePath, csv.ToString())

                    MessageBox.Show("Borrowing and Return Slip exported successfully to CSV!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Ask if user wants to open the file
                    Dim result As DialogResult = MessageBox.Show("Would you like to open the CSV file?", "Open CSV", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        System.Diagnostics.Process.Start(filePath)
                    End If
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error exporting to CSV: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[BorrowingAndReturnSlip] CSV Export Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ExportToPDF()
        Try
            If Not currentBorrowId.HasValue Then
                MessageBox.Show("No borrow record loaded.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Use the existing ReportExportHelper for PDF generation
            Dim fileName As String = "BorrowingAndReturnSlip_" & borrowedId.Text & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".pdf"

            Using saveDialog As New SaveFileDialog()
                saveDialog.Filter = "PDF Files (*.pdf)|*.pdf"
                saveDialog.Title = "Save Borrowing and Return Slip as PDF"
                saveDialog.FileName = fileName

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    Try
                        Dim filePath As String = saveDialog.FileName
                        If Not filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) Then
                            filePath = filePath & ".pdf"
                        End If

                        ' Build PDF using custom method
                        Dim pdfBytes As Byte() = BuildBorrowingSlipPdf()
                        System.IO.File.WriteAllBytes(filePath, pdfBytes)

                        MessageBox.Show("Borrowing and Return Slip exported successfully to PDF!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Ask if user wants to open the file
                        Dim result As DialogResult = MessageBox.Show("Would you like to open the PDF file?", "Open PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If result = DialogResult.Yes Then
                            System.Diagnostics.Process.Start(filePath)
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Failed to export PDF file: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error exporting to PDF: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[BorrowingAndReturnSlip] PDF Export Error: " & ex.Message)
        End Try
    End Sub

    Private Function BuildBorrowingSlipPdf() As Byte()
        ' Build PDF content
        Dim streamContent As String = BuildBorrowingSlipPdfContent()
        Dim streamBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(streamContent)

        Dim objects As New System.Collections.Generic.List(Of Byte())()
        objects.Add(System.Text.Encoding.ASCII.GetBytes("1 0 obj << /Type /Catalog /Pages 2 0 R >> endobj" & Environment.NewLine))
        objects.Add(System.Text.Encoding.ASCII.GetBytes("2 0 obj << /Type /Pages /Kids [3 0 R] /Count 1 >> endobj" & Environment.NewLine))
        objects.Add(System.Text.Encoding.ASCII.GetBytes("3 0 obj << /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Contents 4 0 R /Resources << /Font << /F1 5 0 R /F2 6 0 R >> >> >> endobj" & Environment.NewLine))

        Dim streamBuilder As New System.Text.StringBuilder()
        streamBuilder.AppendLine("4 0 obj << /Length " & streamBytes.Length & " >>")
        streamBuilder.AppendLine("stream")
        streamBuilder.Append(streamContent)
        streamBuilder.AppendLine("endstream")
        streamBuilder.AppendLine("endobj")
        objects.Add(System.Text.Encoding.UTF8.GetBytes(streamBuilder.ToString()))

        objects.Add(System.Text.Encoding.ASCII.GetBytes("5 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Helvetica >> endobj" & Environment.NewLine))
        objects.Add(System.Text.Encoding.ASCII.GetBytes("6 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold >> endobj" & Environment.NewLine))

        Using ms As New System.IO.MemoryStream()
            Using bw As New System.IO.BinaryWriter(ms, System.Text.Encoding.ASCII, True)
                bw.Write(System.Text.Encoding.ASCII.GetBytes("%PDF-1.4" & Environment.NewLine))
                Dim offsets As New System.Collections.Generic.List(Of Long)()
                For Each objBytes In objects
                    offsets.Add(ms.Position)
                    bw.Write(objBytes)
                Next

                Dim xrefPosition As Long = ms.Position
                bw.Write(System.Text.Encoding.ASCII.GetBytes("xref" & Environment.NewLine & "0 " & (objects.Count + 1).ToString() & Environment.NewLine))
                bw.Write(System.Text.Encoding.ASCII.GetBytes("0000000000 65535 f " & Environment.NewLine))
                For Each off As Long In offsets
                    bw.Write(System.Text.Encoding.ASCII.GetBytes(off.ToString("D10") & " 00000 n " & Environment.NewLine))
                Next

                bw.Write(System.Text.Encoding.ASCII.GetBytes("trailer" & Environment.NewLine & "<< /Size " & (objects.Count + 1).ToString() & " /Root 1 0 R >>" & Environment.NewLine))
                bw.Write(System.Text.Encoding.ASCII.GetBytes("startxref" & Environment.NewLine & xrefPosition.ToString() & Environment.NewLine & "%%EOF"))
            End Using
            Return ms.ToArray()
        End Using
    End Function

    Private Function BuildBorrowingSlipPdfContent() As String
        Dim builder As New System.Text.StringBuilder()

        ' Get values safely
        Dim reqId As String = EscapePdfText(requestId.Text)
        Dim itmType As String = EscapePdfText(itemType.Text)
        Dim itmId As String = EscapePdfText(itemID.Text)
        Dim borName As String = EscapePdfText(borrowedName.Text)
        Dim borPosValue As String = If(borrowerPosition.SelectedItem IsNot Nothing, borrowerPosition.SelectedItem.ToString(), borrowerPosition.Text)
        Dim borPos As String = EscapePdfText(borPosValue)
        Dim deptId As String = EscapePdfText(departmentId.Text)
        Dim borDate As String = EscapePdfText(borrowerDate.Value.ToString("dddd, dd MMMM yyyy"))
        Dim expDate As String = EscapePdfText(expectedReturnDate.Value.ToString("dddd, dd MMMM yyyy"))
        Dim actDate As String = EscapePdfText(actualReturnDate.Value.ToString("dddd, dd MMMM yyyy"))
        Dim condRet As String = EscapePdfText(conditionOnReturn.Text)
        Dim statValue As String = If(status.SelectedItem IsNot Nothing, status.SelectedItem.ToString(), status.Text)
        Dim stat As String = EscapePdfText(statValue)
        Dim remarksText As String = EscapePdfText(remarks.Text)

        ' PDF dimensions (A4 = 595x842 points)
        Dim pageWidth As Integer = 595
        Dim pageHeight As Integer = 842
        Dim margin As Integer = 75
        Dim contentWidth As Integer = pageWidth - (2 * margin)

        ' Set line width for borders
        builder.AppendLine("1 w")

        ' ===== OUTER BORDER =====
        builder.AppendLine($"{margin} {margin} {contentWidth} {pageHeight - (2 * margin)} re S")

        ' ===== TITLE HEADER =====
        Dim titleY As Integer = pageHeight - 100
        Dim titleHeight As Integer = 50
        builder.AppendLine($"{margin} {titleY} {contentWidth} {titleHeight} re S")
        builder.AppendLine($"BT /F2 18 Tf {pageWidth / 2 - 150} {titleY + 15} Td (BORROWING AND RETURN SLIP) Tj ET")

        ' ===== FIRST ROW: Request ID, Item Type, Item ID =====
        Dim row1Y As Integer = titleY - 70
        Dim row1Height As Integer = 70
        Dim col1Width As Integer = CInt(contentWidth / 3)
        
        ' Draw outer box for row
        builder.AppendLine($"{margin} {row1Y} {contentWidth} {row1Height} re S")
        ' Vertical dividers
        builder.AppendLine($"{margin + col1Width} {row1Y} m {margin + col1Width} {row1Y + row1Height} l S")
        builder.AppendLine($"{margin + (2 * col1Width)} {row1Y} m {margin + (2 * col1Width)} {row1Y + row1Height} l S")
        
        ' Request ID - Label and value on same line
        builder.AppendLine($"BT /F2 10 Tf {margin + 8} {row1Y + 40} Td (Request ID:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + 15} {row1Y + 20} Td ({reqId}) Tj ET")
        
        ' Item Type - Label and value on same line
        builder.AppendLine($"BT /F2 10 Tf {margin + col1Width + 8} {row1Y + 40} Td (Item Type:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + col1Width + 15} {row1Y + 20} Td ({itmType}) Tj ET")
        
        ' Item ID - Label and value on same line
        builder.AppendLine($"BT /F2 10 Tf {margin + (2 * col1Width) + 8} {row1Y + 40} Td (Item ID:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + (2 * col1Width) + 15} {row1Y + 20} Td ({itmId}) Tj ET")

        ' ===== SECOND ROW: Borrower Date and Return Dates =====
        Dim row2Y As Integer = row1Y - 120
        Dim row2Height As Integer = 120
        Dim leftColWidth As Integer = CInt(contentWidth / 2)
        
        ' Draw outer box
        builder.AppendLine($"{margin} {row2Y} {contentWidth} {row2Height} re S")
        ' Vertical divider
        builder.AppendLine($"{margin + leftColWidth} {row2Y} m {margin + leftColWidth} {row2Y + row2Height} l S")
        ' Horizontal divider in right column
        builder.AppendLine($"{margin + leftColWidth} {row2Y + 60} m {margin + contentWidth} {row2Y + 60} l S")
        
        ' Borrower Date (left side)
        builder.AppendLine($"BT /F2 10 Tf {margin + 15} {row2Y + 90} Td (Borrower Date:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + 25} {row2Y + 50} Td ({borDate}) Tj ET")
        
        ' Expected Return Date (top right)
        builder.AppendLine($"BT /F2 10 Tf {margin + leftColWidth + 15} {row2Y + 90} Td (Expected Return Date:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + leftColWidth + 25} {row2Y + 70} Td ({expDate}) Tj ET")
        
        ' Actual Return Date (bottom right)
        builder.AppendLine($"BT /F2 10 Tf {margin + leftColWidth + 15} {row2Y + 40} Td (Actual Return Date:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + leftColWidth + 25} {row2Y + 20} Td ({actDate}) Tj ET")

        ' ===== REMAINING ROWS =====
        Dim rowHeight As Integer = 50
        Dim currentY As Integer = row2Y - rowHeight

        ' Borrowed Name
        builder.AppendLine($"{margin} {currentY} {contentWidth} {rowHeight} re S")
        builder.AppendLine($"BT /F2 10 Tf {margin + 15} {currentY + 25} Td (Borrowed Name:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + 150} {currentY + 25} Td ({borName}) Tj ET")
        currentY -= rowHeight

        ' Borrower Position
        builder.AppendLine($"{margin} {currentY} {contentWidth} {rowHeight} re S")
        builder.AppendLine($"BT /F2 10 Tf {margin + 15} {currentY + 25} Td (Borrower Position:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + 150} {currentY + 25} Td ({borPos}) Tj ET")
        currentY -= rowHeight

        ' Department ID
        builder.AppendLine($"{margin} {currentY} {contentWidth} {rowHeight} re S")
        builder.AppendLine($"BT /F2 10 Tf {margin + 15} {currentY + 25} Td (Department ID:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + 150} {currentY + 25} Td ({deptId}) Tj ET")
        currentY -= rowHeight

        ' Condition on Return
        builder.AppendLine($"{margin} {currentY} {contentWidth} {rowHeight} re S")
        builder.AppendLine($"BT /F2 10 Tf {margin + 15} {currentY + 25} Td (Condition on Return:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + 160} {currentY + 25} Td ({condRet}) Tj ET")
        currentY -= rowHeight

        ' Status
        builder.AppendLine($"{margin} {currentY} {contentWidth} {rowHeight} re S")
        builder.AppendLine($"BT /F2 10 Tf {margin + 15} {currentY + 25} Td (Status:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + 150} {currentY + 25} Td ({stat}) Tj ET")
        currentY -= rowHeight

        ' Remarks
        builder.AppendLine($"{margin} {currentY} {contentWidth} {rowHeight} re S")
        builder.AppendLine($"BT /F2 10 Tf {margin + 15} {currentY + 25} Td (Remarks:) Tj ET")
        builder.AppendLine($"BT /F1 10 Tf {margin + 150} {currentY + 25} Td ({remarksText}) Tj ET")

        Return builder.ToString()
    End Function

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Label13_Click(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub




    Private Function BuildBorrowingTable(source As DataTable) As DataTable
        Dim reportTable As New DataTable()
        reportTable.Columns.Add("Column1", GetType(String))
        reportTable.Columns.Add("ReturnStatus", GetType(String))
        reportTable.Columns.Add("borrowerSignature", GetType(String))
        reportTable.Columns.Add("Column2", GetType(String))
        reportTable.Columns.Add("Column3", GetType(String))
        reportTable.Columns.Add("Column4", GetType(String))
        reportTable.Columns.Add("Column6", GetType(String))
        reportTable.Columns.Add("Remarks", GetType(String))
        reportTable.Columns.Add("Column7", GetType(String))
        reportTable.Columns.Add("Column8", GetType(String))

        If source Is Nothing Then
            Return reportTable
        End If

        Dim filteredRows = source.AsEnumerable().
            Where(Function(r) As Boolean
                      Dim statusValue As String = If(Convert.IsDBNull(r("status")), "", r("status").ToString().ToLower())
                      Return statusValue = "approved" OrElse statusValue = "released" OrElse statusValue = "returned"
                  End Function).
            ToList()

        For Each row As DataRow In filteredRows
            Try
                Dim newRow As DataRow = reportTable.NewRow()
                newRow("Column1") = SafeGetString(row, "item_name")
                newRow("ReturnStatus") = SafeGetString(row, "status")
                newRow("borrowerSignature") = ""
                Dim reqId As String = SafeGetString(row, "request_id")
                newRow("Column2") = If(String.IsNullOrEmpty(reqId), "", "PR-" & reqId)
                newRow("Column3") = SafeGetDateString(row, "date_of_request")
                newRow("Column4") = SafeGetDateString(row, "expected_return_date", "", allowEmpty:=True)
                newRow("Column6") = SafeGetDateString(row, "actual_returned_date", "", allowEmpty:=True)
                newRow("Remarks") = SafeGetString(row, "remarks")
                newRow("Column7") = SafeGetString(row, "condition_upon_return", "N/A")
                newRow("Column8") = SafeGetDecimalString(row, "penalty", "0.00")
                reportTable.Rows.Add(newRow)
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] BorrowingAndReturnSlip BuildRow Error: " & ex.Message)
            End Try
        Next

        Return reportTable
    End Function

    Private Sub btnCSV_Click(sender As Object, e As EventArgs) Handles btnCSV.Click
        Dim fileName As String = "borrowing_return_slip_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".csv"
        ReportExportHelper.ExportDataTableToCsv(borrowingTable, fileName)
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        Dim fileName As String = "borrowing_return_slip_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".pdf"
        ReportExportHelper.ExportDataTableToPdf(borrowingTable, fileName, "Borrowing and Return Slip")
    End Sub

    Private Function SafeGetString(row As DataRow, columnName As String, Optional fallback As String = "") As String
        If row.Table.Columns.Contains(columnName) AndAlso Not Convert.IsDBNull(row(columnName)) Then
            Return row(columnName).ToString()
        End If
        Return fallback
    End Function

    Private Function SafeGetDateString(row As DataRow, columnName As String, Optional fallback As String = "yyyy-MM-dd", Optional allowEmpty As Boolean = False) As String
        If row.Table.Columns.Contains(columnName) AndAlso Not Convert.IsDBNull(row(columnName)) Then
            Dim parsedDate As Date
            If Date.TryParse(row(columnName).ToString(), parsedDate) Then
                Return parsedDate.ToString("yyyy-MM-dd")
            End If
        End If
        If allowEmpty Then Return ""
        Return Date.Today.ToString("yyyy-MM-dd")
    End Function

    Private Function SafeGetDecimalString(row As DataRow, columnName As String, Optional fallback As String = "0.00") As String
        If row.Table.Columns.Contains(columnName) AndAlso Not Convert.IsDBNull(row(columnName)) Then
            Dim value As Decimal
            If Decimal.TryParse(row(columnName).ToString(), value) Then
                Return value.ToString("F2")
            End If
        End If
        Return fallback
    End Function

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles itemType.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click

    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click

    End Sub

    Private Sub status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles status.SelectedIndexChanged

    End Sub

    ' Helper function to escape PDF text
    Private Function EscapePdfText(text As String) As String
        If text Is Nothing Then text = String.Empty
        ' Escape special PDF characters: backslash, parentheses
        text = text.Replace("\", "\\")
        text = text.Replace("(", "\(")
        text = text.Replace(")", "\)")
        text = text.Replace(vbCr, " ")
        text = text.Replace(vbLf, " ")
        Return text
    End Function

End Class