Imports System

Public Class frmReports
    Private Sub btnRequestReport_Click(sender As Object, e As System.EventArgs) Handles Essuance.Click
        Dim PropertyIssuance As New PropertyIssuance()
        PropertyIssuance.Show()
    End Sub



    Private Sub btnBorrowReturn_Click(sender As Object, e As System.EventArgs) Handles btnBorrowReturn.Click
        Dim BorrowingAndReturnSlip As New BorrowingAndReturnSlip()
        BorrowingAndReturnSlip.Show()
    End Sub


    Private Sub btnRequisitionSlip_Click(sender As Object, e As System.EventArgs) Handles btnRequisitionSlip.Click
        Dim RequisitionIssueSlip As New RequisitionIssueSlip()
        RequisitionIssueSlip.Show()
    End Sub


End Class