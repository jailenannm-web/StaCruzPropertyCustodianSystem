Imports System

Public Class frmReports
    Private Sub btnRequestReport_Click(sender As Object, e As System.EventArgs) Handles Essuance.Click
        Dim PropertyIssuance As New PropertyIssuance()
        PropertyIssuance.Show()
    End Sub
    
End Class