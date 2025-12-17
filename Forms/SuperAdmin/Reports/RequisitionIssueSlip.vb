Imports System
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Partial Public Class RequisitionIssueSlip
    Private requisitionTable As DataTable

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub admin_label_Reports_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub divisionName_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs)

    End Sub





    Private Function BuildRequisitionTable(source As DataTable) As DataTable
        Dim reportTable As New DataTable()
        reportTable.Columns.Add("requisitionName", GetType(String))
        reportTable.Columns.Add("requisitionUnit", GetType(String))
        reportTable.Columns.Add("requisitionParticulars", GetType(String))
        reportTable.Columns.Add("requisitionQuantity1", GetType(Integer))
        reportTable.Columns.Add("requisitionYes", GetType(String))
        reportTable.Columns.Add("requisitionNo", GetType(String))
        reportTable.Columns.Add("requisitionQuantity2", GetType(Integer))
        reportTable.Columns.Add("requisitionRemarks", GetType(String))

        If source Is Nothing Then
            Return reportTable
        End If

        Dim filteredRows = source.AsEnumerable().
            Where(Function(r)
                      Dim statusValue As String = If(Convert.IsDBNull(r("status")), "", r("status").ToString().ToLower())
                      Return statusValue = "approved"
                  End Function).
            ToList()

        For Each row As DataRow In filteredRows
            Try
                Dim quantityRequested As Integer = SafeGetInt(row, "quantity_requested", 1)
                Dim newRow As DataRow = reportTable.NewRow()
                newRow("requisitionName") = SafeGetString(row, "item_name")
                newRow("requisitionUnit") = SafeGetString(row, "unit", "Unit")
                newRow("requisitionParticulars") = SafeGetString(row, "description")
                newRow("requisitionQuantity1") = quantityRequested
                newRow("requisitionYes") = "Yes"
                newRow("requisitionNo") = ""
                newRow("requisitionQuantity2") = quantityRequested
                newRow("requisitionRemarks") = SafeGetString(row, "remarks", "No remarks")
                reportTable.Rows.Add(newRow)
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] RequisitionIssueSlip BuildRow Error: " & ex.Message)
            End Try
        Next

        Return reportTable
    End Function

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel23_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel24_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel25_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub btn_Back_Click(sender As Object, e As EventArgs) Handles btn_Back.Click
        Dim StaffDashboard As New StaffDashboard()
        StaffDashboard.Show()
        Me.Hide()
    End Sub

    Private Sub btnCSV_Click(sender As Object, e As EventArgs) Handles btnCSV.Click
        Dim fileName As String = "requisition_issue_slip_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".csv"
        ReportExportHelper.ExportDataTableToCsv(requisitionTable, fileName)
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        Dim fileName As String = "requisition_issue_slip_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".pdf"
        ReportExportHelper.ExportDataTableToPdf(requisitionTable, fileName, "Requisition and Issue Slip")
    End Sub

    Private Function SafeGetString(row As DataRow, columnName As String, Optional fallback As String = "") As String
        If row.Table.Columns.Contains(columnName) AndAlso Not Convert.IsDBNull(row(columnName)) Then
            Return row(columnName).ToString()
        End If
        Return fallback
    End Function

    Private Function SafeGetInt(row As DataRow, columnName As String, Optional fallback As Integer = 0) As Integer
        If row.Table.Columns.Contains(columnName) AndAlso Not Convert.IsDBNull(row(columnName)) Then
            Dim value As Integer
            If Integer.TryParse(row(columnName).ToString(), value) Then
                Return value
            End If
        End If
        Return fallback
    End Function

    Private Sub entityName_Click(sender As Object, e As EventArgs) Handles entityName.Click

    End Sub

    Private Sub fundCluster_Click(sender As Object, e As EventArgs) Handles fundCluster.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblPropertyCard_Click(sender As Object, e As EventArgs) Handles lblPropertyCard.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub departmentId_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub unit_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub departmentId_TextChanged_1(sender As Object, e As EventArgs) Handles departmentId.TextChanged

    End Sub

    Private Sub position_TextChanged(sender As Object, e As EventArgs) Handles position.TextChanged

    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class