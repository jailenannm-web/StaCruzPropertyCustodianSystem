Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class SuperAdmin_Login

    ' Added complete login functionality for SuperAdmin


    Private Sub SetPlaceholder(textBox As TextBox, placeholder As String, Optional isPassword As Boolean = False)
        If String.IsNullOrWhiteSpace(textBox.Text) Then
            textBox.ForeColor = Drawing.Color.Gray
            textBox.Text = placeholder
            If isPassword Then textBox.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub RemovePlaceholder(textBox As TextBox, placeholder As String, Optional isPassword As Boolean = False)
        If textBox.Text = placeholder Then
            textBox.Text = ""
            textBox.ForeColor = Drawing.Color.Black
            If isPassword Then textBox.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub txb_Username_GotFocus(sender As Object, e As EventArgs)
        RemovePlaceholder(txb_Username, "Username")
    End Sub

    Private Sub txb_Username_LostFocus(sender As Object, e As EventArgs)
        SetPlaceholder(txb_Username, "Username")
    End Sub

    Private Sub txb_Password_GotFocus(sender As Object, e As EventArgs)
        RemovePlaceholder(txb_Password, "Password", True)
    End Sub

    Private Sub txb_Password_LostFocus(sender As Object, e As EventArgs)
        SetPlaceholder(txb_Password, "Password", True)
    End Sub

    ' Added login button handler with database validation
    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        ' Validate input fields
        If String.IsNullOrWhiteSpace(txb_Username.Text) OrElse txb_Username.Text = "Username" Then
            MessageBox.Show("Please enter your username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_Username.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txb_Password.Text) OrElse txb_Password.Text = "Password" Then
            MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_Password.Focus()
            Return
        End If

        ' Validate super admin credentials against database
        Dim username As String = txb_Username.Text
        Dim password As String = txb_Password.Text

        Dim adminData As Dictionary(Of String, String) = DatabaseConnection.ValidateAdminLogin(username, password)

        If adminData.Count > 0 AndAlso adminData("user_type") = "SuperAdmin" Then
            ' Login successful for SuperAdmin
            My.Settings.LoggedInuser = username
            My.Settings.Save()

            MessageBox.Show("Login successful! Welcome, " & adminData("first_name") & ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Open SuperAdmin Dashboard
            Dim saDashboard As New SADashboard()
            saDashboard.Show()
            Me.Close()
        Else
            MessageBox.Show("Invalid username, password, or insufficient permissions. Only SuperAdmins can access this system.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txb_Username.Clear()
            txb_Password.Clear()
            txb_Username.Focus()
        End If
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As System.EventArgs) Handles btn_Cancel.Click
        Dim userLevelForm As New UserLevel()
        userLevelForm.Show()
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class
