Imports System
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Public Class BorrowingAndReturnSlip
    Private borrowingTable As DataTable

    Private Sub BorrowingAndReturnSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBorrowingData()
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
            Where(Function(r)
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

    Private Sub RoundedButton4_Click(sender As Object, e As EventArgs) Handles RoundedButton4.Click
        Dim StaffDashboard As New StaffDashboard()
        StaffDashboard.Show()
        Me.Close()
    End Sub

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

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles status.TextChanged

    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub
End Class