Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports StaCruzPropertyCustodianSystem.Resources.Controls

Public Class AdminDashboard
    '--- Load Event ---
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make profile picture circular
        Dim gp As New System.Drawing.Drawing2D.GraphicsPath()
        gp.AddEllipse(0, 0, admin_picProfile.Width - 1, admin_picProfile.Height - 1)
        admin_picProfile.Region = New Region(gp)
    End Sub

    '--- Sidebar Paint ---
    Private Sub PanelSidebar_Paint(sender As Object, e As PaintEventArgs) Handles admin_PanelSidebar.Paint
    End Sub

    '--- Profile Picture Click ---
    Private Sub admin_picProfile_Click(sender As Object, e As EventArgs) Handles admin_picProfile.Click
    End Sub

    '--- Profile Title Click ---
    Private Sub admin_TitleProfile_Click(sender As Object, e As EventArgs) Handles admin_TitleProfile.Click
    End Sub

    '--- Dashboard Button Click ---
    Private Sub admin_btn_dashboard_Click(sender As Object, e As EventArgs) Handles admin_btn_dashboard.Click
    End Sub

    '--- Property Request Management Button Click ---
    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles admin_btn_PropertyRequestManagement.Click
        admin_btn_PropertyRequestManagement.Text = "Property Request" & vbCrLf & "Management"
    End Sub

    '--- Search Text Changed ---
    Private Sub admin_txtbox_search_TextChanged(sender As Object, e As EventArgs) Handles admin_txtbox_search.TextChanged
    End Sub

    '--- Main Panel Paint ---
    Private Sub admin_PanelMain_Paint(sender As Object, e As PaintEventArgs) Handles admin_PanelMain.Paint
    End Sub

    '--- PictureBox Click ---
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
    End Sub

    '--- Properties Button Click ---
    Private Sub admin_btn_properties_Click(sender As Object, e As EventArgs) Handles admin_btn_properties.Click
    End Sub

    '--- Pending Requests Button Click ---
    Private Sub admin_btn_PendingRequests_Click(sender As Object, e As EventArgs) Handles admin_btn_PendingRequests.Click
    End Sub

    '--- Table Layout Paint ---
    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint
    End Sub


End Class
