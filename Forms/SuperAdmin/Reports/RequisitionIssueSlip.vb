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

    Private Sub RequisitionIssueSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRequisitionData()
    End Sub

    Private Sub LoadRequisitionData()
        Try
            ' Load supply requests using DatabaseConnection function
            Dim dt As DataTable = DatabaseConnection.GetAllSuppliesRequests()
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                requisitionTable = New DataTable()
                Return
            End If

            ' Build requisition table
            requisitionTable = BuildRequisitionTable(dt)

            ' Populate form fields with first record if available
            If dt.Rows.Count > 0 Then
                Dim firstRow As DataRow = dt.Rows(0)
                ' Populate any form fields if needed
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading requisition data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            requisitionTable = New DataTable()
        End Try
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
                Dim quantityRequested As Integer = SafeGetInt(row, "quantityRequested", "quantity_requested", 1)
                Dim newRow As DataRow = reportTable.NewRow()
                newRow("requisitionName") = SafeGetString(row, "itemName", "item_name")
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

    Private Function SafeGetString(row As DataRow, ParamArray names() As String) As String
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not Convert.IsDBNull(row(name)) Then
                Return row(name).ToString()
            End If
        Next
        ' If no match found and last parameter is not a column name, use it as fallback
        If names.Length > 0 AndAlso Not row.Table.Columns.Contains(names(names.Length - 1)) Then
            Return names(names.Length - 1)
        End If
        Return ""
    End Function

    Private Function SafeGetInt(row As DataRow, ParamArray names() As String) As Integer
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not Convert.IsDBNull(row(name)) Then
                Dim value As Integer
                If Integer.TryParse(row(name).ToString(), value) Then
                    Return value
                End If
            End If
        Next
        ' If no match found and last parameter is numeric, use it as fallback
        If names.Length > 0 Then
            Dim lastParam As String = names(names.Length - 1)
            If Not row.Table.Columns.Contains(lastParam) Then
                Dim fallbackValue As Integer
                If Integer.TryParse(lastParam, fallbackValue) Then
                    Return fallbackValue
                End If
            End If
        End If
        Return 0
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