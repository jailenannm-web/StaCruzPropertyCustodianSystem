Imports System
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Public Class BorrowingAndReturnSlip
    Private borrowingTable As DataTable

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

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub BorrowingAndReturnSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBorrowingAndReturnData()
    End Sub
    
    Private Sub LoadBorrowingAndReturnData()
        Try
            Dim dt As DataTable = DatabaseConnection.GetAllPropertyRequests()
            borrowingTable = BuildBorrowingTable(dt)

            If DataGridView1 IsNot Nothing Then
                DataGridView1.AutoGenerateColumns = False
                DataGridView1.DataSource = borrowingTable
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading borrowing and return data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            Dim newRow As DataRow = reportTable.NewRow()
            newRow("Column1") = If(Convert.IsDBNull(row("item_name")), "", row("item_name").ToString())
            newRow("ReturnStatus") = If(Convert.IsDBNull(row("status")), "", row("status").ToString())
            newRow("borrowerSignature") = ""
            newRow("Column2") = If(Convert.IsDBNull(row("request_id")), "", "PR-" & row("request_id").ToString())
            newRow("Column3") = If(Convert.IsDBNull(row("date_of_request")),
                                   Date.Today.ToString("yyyy-MM-dd"),
                                   Convert.ToDateTime(row("date_of_request")).ToString("yyyy-MM-dd"))
            newRow("Column4") = If(Convert.IsDBNull(row("expected_return_date")),
                                   "",
                                   Convert.ToDateTime(row("expected_return_date")).ToString("yyyy-MM-dd"))
            newRow("Column6") = If(Convert.IsDBNull(row("actual_returned_date")),
                                   "",
                                   Convert.ToDateTime(row("actual_returned_date")).ToString("yyyy-MM-dd"))
            newRow("Remarks") = If(Convert.IsDBNull(row("remarks")), "", row("remarks").ToString())
            newRow("Column7") = If(Convert.IsDBNull(row("condition_upon_return")), "", row("condition_upon_return").ToString())
            newRow("Column8") = If(Convert.IsDBNull(row("penalty")), "0.00", Convert.ToDecimal(row("penalty")).ToString("F2"))
            reportTable.Rows.Add(newRow)
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
End Class