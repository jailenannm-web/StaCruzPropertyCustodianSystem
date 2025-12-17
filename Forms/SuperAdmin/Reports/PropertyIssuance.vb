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

    Private Sub txtname_TextChanged(sender As Object, e As System.EventArgs) Handles entityNameTxt.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

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

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class