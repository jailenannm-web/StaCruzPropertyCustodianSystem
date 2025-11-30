Imports System

Public Class AddSupplyRequest
    Inherits System.Windows.Forms.UserControl

    Private Sub employeeID_Click(sender As Object, e As System.EventArgs) Handles sqr_employeeID.Click

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Dim StaffDashboard As New StaffDashboard()
        StaffDashboard.Show()
        Me.Hide()
    End Sub

End Class
