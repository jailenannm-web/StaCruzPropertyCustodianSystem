Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms

Public Class PropertyIssuance
    Private propertyIssuanceTable As DataTable

    Private Sub PropertyIssuance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPropertyIssuanceData()
    End Sub

    Private Sub LoadPropertyIssuanceData()
        Try
            ' Load property requests that have been approved/issued
            Dim dt As DataTable = DatabaseConnection.GetAllPropertyRequests()
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                propertyIssuanceTable = New DataTable()
                Return
            End If

            ' Build property issuance table
            propertyIssuanceTable = BuildPropertyIssuanceTable(dt)

            ' Populate form fields with first record or default values
            If propertyIssuanceTable.Rows.Count > 0 Then
                Dim firstRow As DataRow = propertyIssuanceTable.Rows(0)
                entityNameTxt.Text = SafeGetString(firstRow, "entityName", "Sta. Cruz Property Custodian System")
                numberPAR.Text = SafeGetString(firstRow, "parNumber", "PAR-" & DateTime.Now.ToString("yyyyMMdd"))
                If propertyIssuanceTable.Columns.Contains("dateIssued") AndAlso Not IsDBNull(firstRow("dateIssued")) Then
                    DateTimePicker1.Value = Convert.ToDateTime(firstRow("dateIssued"))
                End If
            Else
                ' Set default values
                entityNameTxt.Text = "Sta. Cruz Property Custodian System"
                numberPAR.Text = "PAR-" & DateTime.Now.ToString("yyyyMMdd")
                DateTimePicker1.Value = DateTime.Now
            End If

            ' Populate property details if available
            If dt.Rows.Count > 0 Then
                Dim firstRequest As DataRow = dt.Rows(0)
                propertyNumber.Text = SafeGetString(firstRequest, "propertyNumber", "propertyId", "")
                description.Text = SafeGetString(firstRequest, "description", "itemDescription", "")
                quantity.Text = SafeGetString(firstRequest, "quantity", "1")
                If dt.Columns.Contains("acquisitionCost") AndAlso Not IsDBNull(firstRequest("acquisitionCost")) Then
                    amount.Text = Convert.ToDecimal(firstRequest("acquisitionCost")).ToString("N2")
                End If
                If dt.Columns.Contains("acquisitionDate") AndAlso Not IsDBNull(firstRequest("acquisitionDate")) Then
                    dateAcquired.Value = Convert.ToDateTime(firstRequest("acquisitionDate"))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading property issuance data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            propertyIssuanceTable = New DataTable()
        End Try
    End Sub

    Private Function BuildPropertyIssuanceTable(source As DataTable) As DataTable
        Dim reportTable As New DataTable()
        reportTable.Columns.Add("entityName", GetType(String))
        reportTable.Columns.Add("parNumber", GetType(String))
        reportTable.Columns.Add("dateIssued", GetType(DateTime))
        reportTable.Columns.Add("propertyNumber", GetType(String))
        reportTable.Columns.Add("description", GetType(String))
        reportTable.Columns.Add("quantity", GetType(Integer))
        reportTable.Columns.Add("amount", GetType(Decimal))
        reportTable.Columns.Add("dateAcquired", GetType(DateTime))

        If source Is Nothing Then Return reportTable

        For Each row As DataRow In source.Rows
            Try
                Dim statusValue As String = If(Convert.IsDBNull(row("status")), "", row("status").ToString().ToLower())
                If statusValue = "approved" OrElse statusValue = "borrowed" Then
                    Dim newRow As DataRow = reportTable.NewRow()
                    newRow("entityName") = "Sta. Cruz Property Custodian System"
                    newRow("parNumber") = "PAR-" & SafeGetString(row, "requestId", "request_id", "")
                    newRow("dateIssued") = SafeGetDate(row, "approvedDate", "approval_date", DateTime.Now)
                    newRow("propertyNumber") = SafeGetString(row, "propertyNumber", "propertyId", "")
                    newRow("description") = SafeGetString(row, "description", "itemDescription", "itemName", "")
                    newRow("quantity") = SafeGetInt(row, "quantity", 1)
                    newRow("amount") = SafeGetDecimal(row, "acquisitionCost", "totalCost", 0)
                    newRow("dateAcquired") = SafeGetDate(row, "acquisitionDate", DateTime.Now)
                    reportTable.Rows.Add(newRow)
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[PropertyIssuance] BuildRow Error: " & ex.Message)
            End Try
        Next

        Return reportTable
    End Function

    Private Function SafeGetDate(row As DataRow, ParamArray names() As String) As DateTime
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not Convert.IsDBNull(row(name)) Then
                Dim parsedDate As Date
                If Date.TryParse(row(name).ToString(), parsedDate) Then
                    Return parsedDate
                End If
            End If
        Next
        Return DateTime.Now
    End Function

    Private Function SafeGetDecimal(row As DataRow, ParamArray names() As String) As Decimal
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not Convert.IsDBNull(row(name)) Then
                Dim value As Decimal
                If Decimal.TryParse(row(name).ToString(), value) Then
                    Return value
                End If
            End If
        Next
        Return 0
    End Function

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