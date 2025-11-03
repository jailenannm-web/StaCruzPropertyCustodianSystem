Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports StaCruzPropertyCustodianSystem.Resources.Controls
Public Class EditUser
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    ' Load user data into the fields
    Public Sub LoadUserData(fullName As String, position As String, email As String,
                            username As String, password As String, address As String,
                            assignment As String, employeeID As String, status As String,
                            login As String, created As String)
        um_edituser_txtboxfull.Text = fullName
        um_edituser_txtboxPosition.Text = position
        um_edituser_email.Text = email
        um_edituser_Username.Text = username
        um_edituser_txtboxPassword.Text = password
        um_edituser_txtboxUserAddress.Text = address
        um_edituser_txtboxAssignment.Text = assignment
        um_edituser_EmployeeID.Text = employeeID
        um_edituser_txtboxStatus.Text = status
        um_edituser_txtboxLogin.Text = login
        um_edituser_txtboxCreated.Text = created
    End Sub

    ' Save button
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles um_edituser_save.Click
        MessageBox.Show("Saved changes for: " & um_edituser_txtboxfull.Text)
        ' Add actual save logic here
    End Sub

    ' Back button
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles um_edituser_backbtn.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_UserManagement())
        End If
    End Sub
End Class
