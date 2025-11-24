Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class StaffLogin

    ' Click on "Don't have account yet" label to go to StaffRegister
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim registerForm As New StaffRegister()
        registerForm.Show()   ' Show the register form
        Me.Hide()            ' Hide current login form instead of closing it
    End Sub

    ' Login button click - Unified login for SuperAdmin, Admin, and Staff
    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        btn_Login.FlatStyle = FlatStyle.Flat ' Validate input fields
        btn_Login.FlatAppearance.BorderSize = 0

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

        Dim username As String = txb_Username.Text.Trim()
        Dim password As String = txb_Password.Text

        ' Try to authenticate as Admin/SuperAdmin first
        Dim adminResult As Dictionary(Of String, String) = DatabaseConnection.ValidateAdminLogin(username, password)

        If adminResult IsNot Nothing AndAlso adminResult.Count > 0 Then
            Dim userType As String = adminResult("user_type")
            My.Settings.LoggedInuser = username
            My.Settings.Save()

            MessageBox.Show("Login successful! Welcome, " & username & " (" & userType & ").", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If userType = "SuperAdmin" Then
                OpenDashboard(New SADashboard())
            ElseIf userType = "Admin" Then
                OpenDashboard(New AdminDashboard())
            End If
            Return
        End If

        ' Try to authenticate as Staff
        If DatabaseConnection.ValidateStaffLogin(username, password) Then
            My.Settings.LoggedInuser = username
            My.Settings.Save()

            MessageBox.Show("Login successful! Welcome, " & username & ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            OpenDashboard(New StaffDashboard())
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

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub StaffLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize default and Admin accounts if they don't exist
        Try
            DatabaseConnection.InitializeDefaultAccounts()
        Catch ex As Exception
            ' Silently fail - accounts may already exist
            System.Diagnostics.Debug.WriteLine("[v0] Error initializing default accounts: " & ex.Message)
        End Try
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)

    End Sub

    ''' <summary>
    ''' Shows the target dashboard form and hides the login while it's open.
    ''' When the dashboard closes, the login form is shown again (allowing log out without closing the app).
    ''' </summary>
    ''' <param name="dashboard">Dashboard form to show.</param>
    Private Sub OpenDashboard(dashboard As Form)
        AddHandler dashboard.FormClosed,
            Sub(sender As Object, args As FormClosedEventArgs)
                ' When dashboard closes, show the login form again
                Me.Show()
                txb_Password.Clear()
                txb_Username.Clear()
                txb_Username.Focus()
            End Sub

        dashboard.Show()
        Me.Hide()
    End Sub
End Class
