Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms

Public Class PropertyIssuance
    Private propertyIssuanceTable As DataTable

    Private Sub fundCluster_Click(sender As Object, e As System.EventArgs) Handles fundCluster.Click

    End Sub

    Private Sub pcEntityName_TextChanged(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub lblName_Click(sender As Object, e As System.EventArgs) Handles lblName.Click

    End Sub

    Private Sub PropertyIssuance_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        LoadPropertyIssuanceData()
    End Sub
    
    Private Sub LoadPropertyIssuanceData()
        Try
            Dim sourceTable As DataTable = DatabaseConnection.GetAllPropertyRequests()
            propertyIssuanceTable = BuildPropertyIssuanceTable(sourceTable)

            If propertyAcknowledgement IsNot Nothing Then
                propertyAcknowledgement.AutoGenerateColumns = False
                propertyAcknowledgement.DataSource = propertyIssuanceTable
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading property issuance data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function BuildPropertyIssuanceTable(source As DataTable) As DataTable
        Dim reportTable As New DataTable()
        reportTable.Columns.Add("quantity", GetType(Integer))
        reportTable.Columns.Add("unit", GetType(String))
        reportTable.Columns.Add("description", GetType(String))
        reportTable.Columns.Add("propertyNumber", GetType(String))
        reportTable.Columns.Add("dateAcquired", GetType(String))
        reportTable.Columns.Add("amount", GetType(String))

        If source Is Nothing OrElse source.Rows.Count = 0 Then
            Return reportTable
        End If

        Dim filteredRows = source.AsEnumerable().
            Where(Function(r)
                      Dim statusValue As String = If(Convert.IsDBNull(r("status")), "", r("status").ToString().ToLower())
                      Return statusValue = "approved" OrElse statusValue = "released"
                  End Function).
            ToList()

        For Each row As DataRow In filteredRows
            Try
                Dim newRow As DataRow = reportTable.NewRow()
                newRow("quantity") = SafeGetInt(row, "quantity_requested", 1)
                newRow("unit") = "pcs"
                newRow("description") = SafeGetString(row, "item_name")
                Dim reqId As String = SafeGetString(row, "request_id")
                newRow("propertyNumber") = If(String.IsNullOrEmpty(reqId), "", "PR-" & reqId)
                newRow("dateAcquired") = SafeGetDateString(row, "date_of_request")
                newRow("amount") = "0.00"
                reportTable.Rows.Add(newRow)
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] PropertyIssuance BuildRow Error: " & ex.Message)
            End Try
        Next

        Return reportTable
    End Function

    Private Sub txtname_TextChanged(sender As Object, e As System.EventArgs) Handles entityNameTxt.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles propertyAcknowledgement.CellContentClick

    End Sub

    Private Sub Label6_Click(sender As Object, e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As System.EventArgs) Handles RoundedButton2.Click
        Dim StaffDashboard As New StaffDashboard()
        StaffDashboard.Show()
        Me.Close()
    End Sub

    Private Sub btnCSV_Click(sender As Object, e As EventArgs) Handles btnCSV.Click
        Dim fileName As String = "property_issuance_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".csv"
        ReportExportHelper.ExportDataTableToCsv(propertyIssuanceTable, fileName)
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        Dim fileName As String = "property_issuance_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".pdf"
        ReportExportHelper.ExportDataTableToPdf(propertyIssuanceTable, fileName, "Property Issuance Report")
    End Sub

    Private Function SafeGetString(row As DataRow, ParamArray names() As String) As String
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not Convert.IsDBNull(row(name)) Then
                Return row(name).ToString()
            End If
        Next
        Return ""
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

    Private Function SafeGetDateString(row As DataRow, columnName As String) As String
        If row.Table.Columns.Contains(columnName) AndAlso Not Convert.IsDBNull(row(columnName)) Then
            Dim parsedDate As Date
            If Date.TryParse(row(columnName).ToString(), parsedDate) Then
                Return parsedDate.ToString("yyyy-MM-dd")
            End If
        End If
        Return Date.Today.ToString("yyyy-MM-dd")
    End Function
End Class