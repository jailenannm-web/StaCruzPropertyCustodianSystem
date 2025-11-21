Imports System
Imports System.Windows.Forms

Public Class StaffLogin

    ' Click on "Don't have account yet" label to go to StaffRegister
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim registerForm As New StaffRegister()
        registerForm.Show()   ' Show the register form
        Me.Hide()            ' Hide current login form instead of closing it
    End Sub

    ' Login button click
    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        ' Validate input fields
        If String.IsNullOrWhiteSpace(txb_Username.Text) Then
            MessageBox.Show("Please enter your username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_Username.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txb_Password.Text) Then
            MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_Password.Focus()
            Return
        End If

        ' Updated to use ValidateStaffLogin for proper database lookup
        Dim username As String = txb_Username.Text
        Dim password As String = txb_Password.Text

        If DatabaseConnection.ValidateStaffLogin(username, password) Then
            ' Login successful - store username and open dashboard
            My.Settings.LoggedInuser = username
            My.Settings.Save()

            MessageBox.Show("Login successful! Welcome, " & username & ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim staffDashboard As New StaffDashboard()
            staffDashboard.Show()
            Me.Close()
        Else
            MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txb_Username.Clear()
            txb_Password.Clear()
            txb_Username.Focus()
        End If
    End Sub

    ' Cancel button click


    Private Sub txb_Password_TextChanged(sender As Object, e As EventArgs) Handles txb_Password.TextChanged

    End Sub
End Class
