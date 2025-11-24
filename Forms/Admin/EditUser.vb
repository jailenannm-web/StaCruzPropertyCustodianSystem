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

    Private Sub um_edituser_fullname_Click(sender As Object, e As EventArgs) Handles um_edituser_fullname.Click

    End Sub

    Private Sub um_edituser_txtboxfirst_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_txtboxfirst.TextChanged

    End Sub

    Private Sub um_edituser_Password_Click(sender As Object, e As EventArgs) Handles um_edituser_Password.Click

    End Sub

    Private Sub um_edituser_txtboxPassword_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_txtboxPassword.TextChanged

    End Sub

    Private Sub um_edituser_lastname_Click(sender As Object, e As EventArgs) Handles um_edituser_lastname.Click

    End Sub

    Private Sub um_edituser_txtboxfull_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_txtboxfull.TextChanged

    End Sub

    Private Sub um_useredit_txtboxposition_Click(sender As Object, e As EventArgs) Handles um_useredit_txtboxposition.Click

    End Sub

    Private Sub um_edituser_txtboxPosition_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_txtboxPosition.TextChanged

    End Sub

    Private Sub um_edituser_txtboxdepartment_Click(sender As Object, e As EventArgs) Handles um_edituser_txtboxdepartment.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub um_edituser_txtboxcontact_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_txtboxcontact.TextChanged

    End Sub

    Private Sub um_edituser_txtboxEmail_Click(sender As Object, e As EventArgs) Handles um_edituser_txtboxEmail.Click

    End Sub

    Private Sub um_edituser_email_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_email.TextChanged

    End Sub

    Private Sub um_edituser_txtboxUsername_Click(sender As Object, e As EventArgs) Handles um_edituser_txtboxUsername.Click

    End Sub

    Private Sub um_edituser_Username_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_Username.TextChanged

    End Sub

    Private Sub um_edituser_txtboxAddress_Click(sender As Object, e As EventArgs) Handles um_edituser_txtboxAddress.Click

    End Sub

    Private Sub um_edituser_txtboxUserAddress_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_txtboxUserAddress.TextChanged

    End Sub

    Private Sub um_edituser_txtboxAssignment_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_txtboxAssignment.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub um_edituser_txtboxID_Click(sender As Object, e As EventArgs) Handles um_edituser_txtboxID.Click

    End Sub

    Private Sub um_edituser_EmployeeID_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_EmployeeID.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub um_edituser_txtboxStatus_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_txtboxStatus.TextChanged

    End Sub

    Private Sub um_edituser_txtStatus_Click(sender As Object, e As EventArgs) Handles um_edituser_txtStatus.Click

    End Sub

    Private Sub um_edituser_txtboxLogin_TextChanged(sender As Object, e As EventArgs) Handles um_edituser_txtboxLogin.TextChanged

    End Sub

    Private Sub uc_um_edituser_Paint(sender As Object, e As PaintEventArgs) Handles uc_um_edituser.Paint

    End Sub
End Class
