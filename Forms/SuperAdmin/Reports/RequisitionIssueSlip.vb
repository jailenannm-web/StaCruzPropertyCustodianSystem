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

    Private Sub RequisitionIssueSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRequisitionData()
    End Sub
    
    Private Sub LoadRequisitionData()
        Try
            Dim dt As DataTable = DatabaseConnection.GetAllSuppliesRequests()
            requisitionTable = BuildRequisitionTable(dt)

            If requisitionDataGrid1 IsNot Nothing Then
                requisitionDataGrid1.AutoGenerateColumns = False
                requisitionDataGrid1.DataSource = requisitionTable
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading requisition data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            Dim newRow As DataRow = reportTable.NewRow()
            newRow("requisitionName") = If(Convert.IsDBNull(row("item_name")), "", row("item_name").ToString())
            newRow("requisitionUnit") = If(Convert.IsDBNull(row("unit")), "pcs", row("unit").ToString())
            newRow("requisitionParticulars") = If(Convert.IsDBNull(row("description")), "", row("description").ToString())
            Dim quantityRequested As Integer = If(Convert.IsDBNull(row("quantity_requested")), 1, Convert.ToInt32(row("quantity_requested")))
            newRow("requisitionQuantity1") = quantityRequested
            newRow("requisitionYes") = "Yes"
            newRow("requisitionNo") = ""
            newRow("requisitionQuantity2") = quantityRequested
            newRow("requisitionRemarks") = If(Convert.IsDBNull(row("remarks")), "", row("remarks").ToString())
            reportTable.Rows.Add(newRow)
        Next

        Return reportTable
    End Function

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles requisitionDataGrid1.CellContentClick

    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel23_Paint(sender As Object, e As PaintEventArgs) Handles Panel23.Paint

    End Sub

    Private Sub Panel24_Paint(sender As Object, e As PaintEventArgs) Handles Panel24.Paint

    End Sub

    Private Sub Panel25_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

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
End Class