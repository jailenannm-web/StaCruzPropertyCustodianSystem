Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.VisualBasic
Imports StaCruzPropertyCustodianSystem.Resources.Controls


Public Class CustodianDashboard
    ' Currently loaded UserControl
    Private currentUC As UserControl = Nothing
    Private _isDashboardLoading As Boolean

    ' ----------------------
    ' Form Load
    ' ----------------------
    Private Sub MakeProfileCircular()
        If admin_picProfile.Width > 0 AndAlso admin_picProfile.Height > 0 Then
            Dim gp As New GraphicsPath()
            gp.AddEllipse(0, 0, admin_picProfile.Width - 1, admin_picProfile.Height - 1)
            admin_picProfile.Region = New Region(gp)
        End If
    End Sub

    ' ----------------------
    ' Load UserControl into Main Panel
    ' ----------------------
    Public Sub LoadUserControl(uc As UserControl)
        Try
            ' Clear previous controls
            admin_PanelMain.Controls.Clear()
            currentUC = uc

            ' Add new UserControl
            admin_PanelMain.Controls.Add(uc)
            uc.Dock = DockStyle.Fill
            uc.BringToFront()
            uc.Focus()

            ' Debug info (optional)
            Debug.WriteLine("Loaded UC: " & uc.Name)
            Debug.WriteLine("Panel Size: " & admin_PanelMain.ClientSize.ToString())
            Debug.WriteLine("UC Size: " & uc.Size.ToString())

        Catch ex As Exception
            MessageBox.Show("Error loading UserControl: " & ex.Message)
        End Try
    End Sub

    ' ----------------------
    ' Handle Form Resize
    ' ----------------------
    Private Sub Dashboard_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ' DockStyle.Fill ensures UC resizes automatically
        currentUC?.Refresh()
    End Sub

    Private Sub admin_btn_PropertyManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_PropertyManagement.Click
        LoadUserControl(New UC_PropertyManagement1())
    End Sub

    Private Sub admin_btn_SuppliesManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_SuppliesManagement.Click
        LoadUserControl(New UC_SupplyManagement())
    End Sub

    Private Sub admin_btn_PropertyRequestManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_PropertyRequestManagement.Click
        LoadUserControl(New UC_PropertyRequestManagement())
    End Sub

    Private Sub admin_btn_MaintenanceManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_MaintenanceManagement.Click
        LoadUserControl(New UC_MaintenanceManagement())
    End Sub

    Private Sub admin_btn_reports_Click(sender As Object, e As EventArgs) Handles admin_btn_reports.Click
        LoadUserControl(New UC_Reports())
    End Sub
End Class
