Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class StaffLogin

    ' Click on "Don't have account yet" label to go to StaffRegister


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
        SessionContext.Reset()

        Try
            ' Try to authenticate as Admin/SuperAdmin/Custodian first (checks hardcoded credentials first)
            Dim adminResult As Dictionary(Of String, String) = Nothing
            Try
                adminResult = DatabaseConnection.ValidateAdminLogin(username, password)
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] StaffLogin - ValidateAdminLogin Exception: " & ex.Message)
                System.Diagnostics.Debug.WriteLine("[v0] StaffLogin - ValidateAdminLogin StackTrace: " & ex.StackTrace)
                ' Continue to try Staff authentication
            End Try

            If adminResult IsNot Nothing AndAlso adminResult.Count > 0 Then
                Dim userType As String = ""
                Dim userIDValue As Integer = 0
                
                If adminResult.ContainsKey("user_type") Then
                    userType = adminResult("user_type")
                End If
                
                If adminResult.ContainsKey("user_id") Then
                    Integer.TryParse(adminResult("user_id"), userIDValue)
                End If

                If userIDValue > 0 AndAlso Not String.IsNullOrEmpty(userType) Then
                    SessionContext.SetCurrentUser(userIDValue, username, userType)
                    My.Settings.LoggedInuser = username
                    My.Settings.Save()

                    MessageBox.Show("Login successful! Welcome, " & username & " (" & userType & ").", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If userType = "SuperAdmin" Then
                        OpenDashboard(New SADashboard())
                    ElseIf userType = "Admin" Then
                        OpenDashboard(New AdminDashboard())
                    ElseIf userType = "Custodian" Then
                        ' Custodian has their own dashboard
                        OpenDashboard(New CustodianDashboard())
                    End If
                    Return
                End If
            End If

            ' Try to authenticate as Staff (registered accounts only, not hardcoded Custodian)
            Dim staffResult As Dictionary(Of String, String) = Nothing
            Try
                staffResult = DatabaseConnection.AuthenticateStaff(username, password)
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] StaffLogin - AuthenticateStaff Exception: " & ex.Message)
                System.Diagnostics.Debug.WriteLine("[v0] StaffLogin - AuthenticateStaff StackTrace: " & ex.StackTrace)
                MessageBox.Show("Error during authentication. Please check your database connection and try again.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            If staffResult IsNot Nothing AndAlso staffResult.Count > 0 Then
                Dim staffID As Integer = 0
                If staffResult.ContainsKey("user_id") Then
                    If Not Integer.TryParse(staffResult("user_id"), staffID) Then
                        ' Try staff_id if user_id parsing fails
                        If staffResult.ContainsKey("staff_id") Then
                            Integer.TryParse(staffResult("staff_id"), staffID)
                        End If
                    End If
                ElseIf staffResult.ContainsKey("staff_id") Then
                    Integer.TryParse(staffResult("staff_id"), staffID)
                End If
                
                If staffID > 0 Then
                    SessionContext.SetCurrentUser(staffID, username, "Staff")
                    My.Settings.LoggedInuser = username
                    My.Settings.Save()

                    MessageBox.Show("Login successful! Welcome, " & username & " (Staff).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    OpenDashboard(New StaffDashboard())
                Else
                    MessageBox.Show("Failed to retrieve user ID. Please contact administrator.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ' Show generic error message - detailed checking would require accessing private methods
                MessageBox.Show("Invalid username or password. Please check your credentials and try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txb_Password.Clear()
                txb_Username.Focus()
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] StaffLogin - General Exception: " & ex.Message)
            System.Diagnostics.Debug.WriteLine("[v0] StaffLogin - General Exception StackTrace: " & ex.StackTrace)
            MessageBox.Show("An unexpected error occurred during login. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Sub StaffLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize default accounts
        Try
            DatabaseConnection.InitializeDefaultAccounts()
            ' Create test staff account if it doesn't exist
            DatabaseConnection.CreateTestStaffAccount()
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Error initializing default accounts: " & ex.Message)
        End Try

        ' SECRET BUTTON HIDDEN SETTINGS
        btnSecretConfig.Width = 20
        btnSecretConfig.Height = 20
        btnSecretConfig.FlatStyle = FlatStyle.Flat
        btnSecretConfig.FlatAppearance.BorderSize = 0
        btnSecretConfig.BackColor = Me.BackColor
        btnSecretConfig.ForeColor = Me.BackColor
        btnSecretConfig.Text = ""
        btnSecretConfig.TabStop = False
    End Sub
    Private Sub btnSecretConfig_Click(sender As Object, e As EventArgs) Handles btnSecretConfig.Click
        Dim cfg As New SASystemConfiguration()
        cfg.Show()
    End Sub


End Class
