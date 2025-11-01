Imports System
Imports System.Windows.Forms

Public Class DashBoard

    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This is the single, primary subroutine that runs when the form loads.

        ' --- Button Styling Consolidation ---

        ' Dashboard Button
        btn_DashBoard.FlatStyle = FlatStyle.Flat
        btn_DashBoard.FlatAppearance.BorderSize = 0

        ' User Management Button
        btn_UserManagement.FlatStyle = FlatStyle.Flat
        btn_UserManagement.FlatAppearance.BorderSize = 0

        ' Property Management Button
        btn_PropertyManagement.FlatStyle = FlatStyle.Flat
        btn_PropertyManagement.FlatAppearance.BorderSize = 0

        ' Supplies Management Button
        btn_SuppliesManagement.FlatStyle = FlatStyle.Flat
        btn_SuppliesManagement.FlatAppearance.BorderSize = 0

        ' Department Management Button
        btn_DepartmentManagement.FlatStyle = FlatStyle.Flat
        btn_DepartmentManagement.FlatAppearance.BorderSize = 0

        ' Property Request Management Button
        btn_PropertyRequestManagement.FlatStyle = FlatStyle.Flat
        btn_PropertyRequestManagement.FlatAppearance.BorderSize = 0

        ' Maintenance Management Button
        btn_MaintenanceManagement.FlatStyle = FlatStyle.Flat
        btn_MaintenanceManagement.FlatAppearance.BorderSize = 0

        ' Reports Button
        btn_Reports.FlatStyle = FlatStyle.Flat
        btn_Reports.FlatAppearance.BorderSize = 0

        ' System Configuration Button
        btn_SystemConfiguration.FlatStyle = FlatStyle.Flat
        btn_SystemConfiguration.FlatAppearance.BorderSize = 0

        ' Logout Button
        btn_Logout.FlatStyle = FlatStyle.Flat
        btn_Logout.FlatAppearance.BorderSize = 0

        ' --- End Button Styling ---

    End Sub

End Class