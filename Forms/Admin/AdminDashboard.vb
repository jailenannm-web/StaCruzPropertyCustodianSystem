Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports StaCruzPropertyCustodianSystem.Resources.Controls


Public Class AdminDashboard
    ' Currently loaded UserControl
    Private currentUC As UserControl = Nothing

    ' ----------------------
    ' Form Load
    ' ----------------------
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make profile picture circular
        MakeProfileCircular()
    End Sub

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

    ' ----------------------
    ' Button Click Handlers
    ' ----------------------

    ' User Management
    Private Sub admin_btn_UserManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_UserManagement.Click
        LoadUserControl(New UC_UserManagement())
    End Sub

    ' Property Request Management
    Private Sub admin_btn_PropertyRequestManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_PropertyRequestManagement.Click
        admin_btn_PropertyRequestManagement.Text = "Property Request" & vbCrLf & "Management"
        LoadUserControl(New UC_PropertyRequestManagement())
    End Sub

    ' Dashboard Button (optional example)
    Private Sub admin_btn_dashboard_Click(sender As Object, e As EventArgs) Handles admin_btn_dashboard.Click
        ' Load the dashboard UserControl if you have one
        ' LoadUserControl(New UC_Dashboard())
    End Sub

    ' Properties Button
    Private Sub admin_btn_properties_Click(sender As Object, e As EventArgs) Handles admin_btn_properties.Click
        ' Load your properties UserControl
        ' LoadUserControl(New UC_Properties())
    End Sub

    ' Pending Requests Button
    Private Sub admin_btn_PendingRequests_Click(sender As Object, e As EventArgs) Handles admin_btn_PendingRequests.Click
        ' Load your pending requests UserControl
        ' LoadUserControl(New UC_PendingRequests())
    End Sub

    ' Search TextBox
    Private Sub admin_txtbox_search_TextChanged(sender As Object, e As EventArgs) Handles admin_txtbox_search.TextChanged
        ' Optional: Add search filtering logic here
    End Sub

    ' Profile Picture Click
    Private Sub admin_picProfile_Click(sender As Object, e As EventArgs) Handles admin_picProfile.Click
        ' Optional: Open profile settings
    End Sub

    ' Profile Title Click
    Private Sub admin_TitleProfile_Click(sender As Object, e As EventArgs) Handles admin_TitleProfile.Click
        ' Optional: Open profile details
    End Sub

    ' Dashboard Label Click
    Private Sub admin_label_Dashboard_Click(sender As Object, e As EventArgs) Handles admin_label_Dashboard.Click
        ' Optional: navigate to dashboard
    End Sub

    ' Quick Access Label Click
    Private Sub admin_label_quickaccess_Click(sender As Object, e As EventArgs) Handles admin_label_quickaccess.Click
        ' Optional: open quick access panel
    End Sub

    Private Sub admin_btn_PropertyManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_PropertyManagement.Click
        LoadUserControl(New UC_PropertyManagement())
    End Sub

    Private Sub admin_btn_DepartmentManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_DepartmentManagement.Click
        LoadUserControl(New UC_DepartmentManagement())
    End Sub

    Private Sub admin_PanelMain_Paint(sender As Object, e As PaintEventArgs) Handles admin_PanelMain.Paint

    End Sub

    Private Sub admin_btn_MaintenanceManagement_Click(sender As Object, e As EventArgs) Handles admin_btn_MaintenanceManagement.Click
        LoadUserControl(New UC_MaintenanceManagement())
    End Sub

    Private Sub admin_btn_reports_Click(sender As Object, e As EventArgs) Handles admin_btn_reports.Click
        LoadUserControl(New UC_Reports())
    End Sub

    ' Other controls (PictureBoxes, Panels, etc.) can be added similarly

End Class
