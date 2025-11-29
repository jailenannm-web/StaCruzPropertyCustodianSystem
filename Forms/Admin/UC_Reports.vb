Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class UC_Reports
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    '==============================
    ' SEARCH BAR
    '==============================
    Private Sub adminreports_txtbox_search_TextChanged(sender As Object, e As EventArgs) Handles adminreports_txtbox_search.TextChanged
        Dim keyword As String = adminreports_txtbox_search.Text.Trim.ToLower

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Panel AndAlso ctrl.Name.ToLower.StartsWith("reports_") Then
                ctrl.Visible = ctrl.Name.ToLower.Contains(keyword)
            End If
        Next
    End Sub


    '==============================
    ' PREVIEW BUTTON EVENTS
    '==============================
    Private Sub reports_prevbtn_RequisitionSlip_Click(sender As Object, e As EventArgs) Handles reports_prevbtn_RequisitionSlip.Click
        PreviewReport("Requisition and Issue Slip")
        Dim addForm As New RequisitionIssueSlip()
        addForm.Show()


    End Sub

    Private Sub reports_prevbtn_MaintenanceRepair_Click(sender As Object, e As EventArgs) Handles reports_prevbtn_MaintenanceRepair.Click
        PreviewReport("Maintenance and Repair Report")
        Dim addForm As New MaintenanceReport()
        addForm.Show()
    End Sub

    Private Sub reports_prevbtn_PropertyCard_Click(sender As Object, e As EventArgs) Handles reports_prevbtn_PropertyCard.Click
        PreviewReport("Property Card")

        ' Get a sample DataRow to pass
        Dim dt As DataTable = DatabaseConnection.GetAllProperties(Nothing, "", "", Nothing)
        If dt.Rows.Count = 0 Then
            MessageBox.Show("No properties available to preview.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim sampleRow As DataRow = dt.Rows(0) ' pick the first property as example

        Dim addForm As New PropertyCard(sampleRow)
        addForm.Show()
    End Sub

    Private Sub reports_prevbtn_InventoryCustodianSlip_Click(sender As Object, e As EventArgs) Handles reports_prevbtn_InventoryCustodianSip.Click
        PreviewReport("Inventory Custodian Slip")
        Dim addForm As New InventoryCustodianSlip()
        addForm.Show()
    End Sub

    Private Sub reports_prevbtn_InventorySummary_Click(sender As Object, e As EventArgs) Handles reports_prevbtn_InventorySummary.Click
        PreviewReport("Official Inventory Summary Report")
        Dim addForm As New InventoryReport()
        addForm.Show()
    End Sub

    Private Sub reports_prevbtn_BorrowingReturnSlip_Click(sender As Object, e As EventArgs) Handles reports_prevbtn_BorrowingReturnSlip.Click
        PreviewReport("Borrowing and Return Slip")
        Dim addForm As New BorrowingAndReturnSlip()
        addForm.Show()
    End Sub

    Private Sub reports_prevbtn_LostDamage_Click(sender As Object, e As EventArgs) Handles reports_prevbtn_LostDamage.Click
        PreviewReport("Lost/Damaged Property Certificate")
        Dim addForm As New LostStolenDamaged()
        addForm.Show()
    End Sub

    Private Sub reports_prevbtn_DeptAllocation_Click(sender As Object, e As EventArgs) Handles reports_prevbtn_DeptAllocation.Click
        PreviewReport("Department Allocation Report")
        Dim addForm As New DepartmentAllocation()
        addForm.Show()
    End Sub

    Private Sub reports_prevbtn_AnnualProperty_Click(sender As Object, e As EventArgs) Handles reports_prevbtn_AnnualProperty.Click
        PreviewReport("Annual Property Custodian Report")
        Dim addForm As New AuditReport()
        addForm.Show()
    End Sub


    '==============================
    ' GENERATE BUTTON EVENTS
    '==============================
    Private Sub rpt_genbtn_RequisitionSlip_Click(sender As Object, e As EventArgs) Handles rpt_genbtn_RequisitionSlip.Click
        GenerateReport("Requisition and Issue Slip")
    End Sub

    Private Sub rpt_genbtn_MaintenanceRepair_Click(sender As Object, e As EventArgs) Handles rpt_genbtn_MaintenanceRepair.Click
        GenerateReport("Maintenance and Repair Report")
    End Sub

    Private Sub rpt_genbtn_PropertyCard_Click(sender As Object, e As EventArgs) Handles rpt_genbtn_PropertyCard.Click
        GenerateReport("Property Card")
    End Sub

    Private Sub rpt_genbtn_InventoryCustodianSlip_Click(sender As Object, e As EventArgs) Handles rpt_genbtn_InventoryCustodianSlip.Click
        GenerateReport("Inventory Custodian Slip")
    End Sub

    Private Sub rpt_genbtn_InventorySummary_Click(sender As Object, e As EventArgs) Handles rpt_genbtn_InventorySummary.Click
        GenerateReport("Official Inventory Summary Report")
    End Sub

    Private Sub rpt_genbtn_BorrowingReturnSlip_Click(sender As Object, e As EventArgs) Handles rpt_genbtn_BorrowingReturnSlip.Click
        GenerateReport("Borrowing and Return Slip")
    End Sub

    Private Sub rpt_genbtn_LostDamage_Click(sender As Object, e As EventArgs) Handles rpt_genbtn_LostDamage.Click
        GenerateReport("Lost/Damaged Property Certificate")
    End Sub

    Private Sub rpt_genbtn_DeptAllocation_Click(sender As Object, e As EventArgs) Handles rpt_genbtn_DeptAllocation.Click
        GenerateReport("Department Allocation Report")
    End Sub

    Private Sub rpt_genbtn_AnnualProperty_Click(sender As Object, e As EventArgs) Handles rpt_genbtn_AnnualProperty.Click
        GenerateReport("Annual Property Custodian Report")
    End Sub


    '==============================
    ' REUSABLE METHODS
    '==============================
    Private Sub PreviewReport(reportName As String)
        MsgBox("Previewing: " & reportName, vbInformation)
    End Sub

    Private Sub GenerateReport(reportName As String)
        MsgBox("Generating: " & reportName, vbInformation)
    End Sub

    Private Sub UC_Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
