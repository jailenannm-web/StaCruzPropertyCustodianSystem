Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make form full screen but not covering taskbar
        Me.Bounds = Screen.FromHandle(Me.Handle).WorkingArea


    End Sub

    ' === Placeholder setup ===
    Private Sub SetPlaceholder(textBox As TextBox, placeholder As String, Optional isPassword As Boolean = False)
        If String.IsNullOrWhiteSpace(textBox.Text) Then
            textBox.ForeColor = Color.Gray
            textBox.Text = placeholder
            If isPassword Then textBox.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub RemovePlaceholder(textBox As TextBox, placeholder As String, Optional isPassword As Boolean = False)
        If textBox.Text = placeholder Then
            textBox.Text = ""
            textBox.ForeColor = Color.Black
            If isPassword Then textBox.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub PanelCard_Paint(sender As Object, e As Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

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

    ' Added login button click handler with database validation
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

        ' Validate admin credentials against database
        Dim username As String = txb_Username.Text
        Dim password As String = txb_Password.Text

        Dim adminData As Dictionary(Of String, String) = DatabaseConnection.ValidateAdminLogin(username, password)

        If adminData.Count > 0 Then
            ' Login successful
            My.Settings.LoggedInuser = username
            My.Settings.Save()

            MessageBox.Show("Login successful! Welcome, " & adminData("first_name") & ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Open Admin Dashboard
            Dim adminDashboard As New AdminDashboard()
            adminDashboard.Show()
            Me.Close()
        Else
            MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txb_Username.Clear()
            txb_Password.Clear()
            txb_Username.Focus()
        End If
    End Sub

    ' Added cancel button handler
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Dim userLevelForm As New UserLevel()
        userLevelForm.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class
