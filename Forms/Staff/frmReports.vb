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
        ' Check if a request is selected in My Request form
        Dim RequisitionIssueSlip As RequisitionIssueSlip = Nothing
        
        If frmRequest.SelectedRequestId.HasValue AndAlso Not String.IsNullOrEmpty(frmRequest.SelectedRequestType) Then
            ' Open with selected request data
            RequisitionIssueSlip = New RequisitionIssueSlip(frmRequest.SelectedRequestId.Value, frmRequest.SelectedRequestType)
        Else
            ' Open without pre-selected request (default behavior)
            RequisitionIssueSlip = New RequisitionIssueSlip()
        End If
        
        RequisitionIssueSlip.Show()
    End Sub


End Class