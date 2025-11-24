Imports System
Imports System.Windows.Forms

Public Class StaffRegister

    ' Register button click
    Private Sub btn_Register_Click(sender As Object, e As EventArgs) Handles btn_Register.Click
        ' Validate all required fields
        If String.IsNullOrWhiteSpace(txb_FirstName.Text) Then
            MessageBox.Show("Please enter your first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_FirstName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txb_LastName.Text) Then
            MessageBox.Show("Please enter your last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_LastName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txb_Email.Text) Then
            MessageBox.Show("Please enter your email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_Email.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txb_ContactNumber.Text) Then
            MessageBox.Show("Please enter your contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_ContactNumber.Focus()
            Return
        End If





        If String.IsNullOrWhiteSpace(txb_UserName.Text) Then
            MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_UserName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Txb_Password.Text) Then
            MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Txb_Password.Focus()
            Return
        End If

        ' Validate password strength
        If Txb_Password.Text.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Attempt registration
        Dim firstName As String = txb_FirstName.Text
        Dim lastName As String = txb_LastName.Text
        Dim email As String = txb_Email.Text
        Dim contactNumber As String = txb_ContactNumber.Text
        Dim departmentID As String = txb_DepartmentID.Text
        Dim username As String = txb_UserName.Text
        Dim password As String = Txb_Password.Text
        Dim position As String = txb_Position.Text

        ' Add debug logging before database call
        System.Diagnostics.Debug.WriteLine("[v0] Registration Attempt - Position: " & position & ", Username: " & username)

        ' Pass position parameter to RegisterStaff function
        If DatabaseConnection.RegisterStaff(firstName, lastName, email, contactNumber, departmentID, username, password, position) Then
            MessageBox.Show("Registration successful! You can now login with your new account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim staffLogin As New StaffLogin()
            staffLogin.Show()
        End If
        Me.Close()

    End Sub

    ' Cancel button click
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Dim loginForm As New StaffLogin()
        loginForm.Show()
        Me.Close()
    End Sub

    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        btn_Login.FlatStyle = FlatStyle.Flat ' Validate input fields
        btn_Login.FlatAppearance.BorderSize = 0

        Dim StaffForm As New StaffLogin()
        StaffLogin.Show()
        Me.Hide()
    End Sub

    Private Sub txb_FirstName_TextChanged(sender As Object, e As EventArgs) Handles txb_FirstName.TextChanged

    End Sub

    Private Sub txb_ContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txb_ContactNumber.TextChanged

    End Sub

    Private Sub txb_Email_TextChanged(sender As Object, e As EventArgs) Handles txb_Email.TextChanged

    End Sub

    Private Sub StaffRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
