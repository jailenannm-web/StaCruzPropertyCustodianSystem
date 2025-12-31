Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class StaffLogin
    ' Keyboard shortcut tracking for S+A+P combination
    Private keyS_Pressed As Boolean = False
    Private keyA_Pressed As Boolean = False
    Private keyP_Pressed As Boolean = False

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
                
                ' Check both userId and user_id for compatibility
                If adminResult.ContainsKey("userId") Then
                    Integer.TryParse(adminResult("userId"), userIDValue)
                ElseIf adminResult.ContainsKey("user_id") Then
                    Integer.TryParse(adminResult("user_id"), userIDValue)
                End If

                If userIDValue > 0 AndAlso Not String.IsNullOrEmpty(userType) Then
                    SessionContext.SetCurrentUser(userIDValue, username, userType)
                    My.Settings.LoggedInuser = username
                    My.Settings.Save()
                    
                    ' Log successful login to audit_logs
                    AuditLogger.LogLogin(userIDValue, username, userType, True)

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
                    
                    ' Log successful login to audit_logs
                    AuditLogger.LogLogin(staffID, username, "Staff", True)

                    MessageBox.Show("Login successful! Welcome, " & username & " (Staff).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    OpenDashboard(New StaffDashboard())
                Else
                    MessageBox.Show("Failed to retrieve user ID. Please contact administrator.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ' Log failed login attempt
                AuditLogger.LogLogin(0, username, "Unknown", False)
                
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
        ' Initialize default accounts (including hardcoded staff account)
        ' This is done silently without permission checks since no user is logged in yet
        Try
            DatabaseConnection.InitializeDefaultAccounts()
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Error initializing default accounts: " & ex.Message)
            Logger.LogError("Error initializing default accounts", ex)
            ' Don't show error to user during initialization - it's handled silently
        End Try

        ' Early connectivity check to surface DB misconfiguration with friendly guidance
        Try
            Dim testConn = DatabaseConnection.GetConnection()
            If testConn IsNot Nothing Then
                If Not DatabaseConnection.SafeOpenConnection(testConn) Then
                    Throw New Exception("Unable to open a database connection using the current settings.")
                End If
                ' Close after successful ping
                If testConn.State = Data.ConnectionState.Open Then testConn.Close()
                testConn.Dispose()
            Else
                Throw New Exception("DatabaseConnection.GetConnection returned Nothing.")
            End If
        Catch ex As Exception
            Logger.LogError("Startup connectivity check failed", ex)
            MessageBox.Show("Unable to connect to the database. Please ensure MySQL is running and connection settings are correct. The configuration screen will open now.", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Try
                Dim cfg As New SASystemConfiguration()
                cfg.Show()
            Catch ex2 As Exception
                Logger.LogError("Failed to open configuration screen", ex2)
            End Try
        End Try

        ' Enable keyboard shortcut handling for S+A+P combination
        Me.KeyPreview = True
    End Sub
    
    ''' <summary>
    ''' Handle KeyDown event to track S, A, P keys being pressed simultaneously
    ''' </summary>
    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        
        ' Don't process if user is typing in username or password fields
        If txb_Username.Focused OrElse txb_Password.Focused Then
            Return
        End If
        
        ' Track which keys are currently pressed
        Select Case e.KeyCode
            Case Keys.S
                keyS_Pressed = True
            Case Keys.A
                keyA_Pressed = True
            Case Keys.P
                keyP_Pressed = True
        End Select
        
        ' Check if all three keys are pressed simultaneously
        If keyS_Pressed AndAlso keyA_Pressed AndAlso keyP_Pressed Then
            ' Open System Configuration
            OpenSystemConfiguration()
            ' Reset key states
            ResetKeyStates()
            e.Handled = True
        End If
    End Sub
    
    ''' <summary>
    ''' Handle KeyUp event to reset key states when released
    ''' </summary>
    Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
        MyBase.OnKeyUp(e)
        
        ' Reset key states when released
        Select Case e.KeyCode
            Case Keys.S
                keyS_Pressed = False
            Case Keys.A
                keyA_Pressed = False
            Case Keys.P
                keyP_Pressed = False
        End Select
    End Sub
    
    ''' <summary>
    ''' Reset all keyboard shortcut states
    ''' </summary>
    Private Sub ResetKeyStates()
        keyS_Pressed = False
        keyA_Pressed = False
        keyP_Pressed = False
    End Sub
    
    ''' <summary>
    ''' Open System Configuration (hidden access via S+A+P shortcut)
    ''' </summary>
    Private Sub OpenSystemConfiguration()
        Try
            Dim cfg As New SASystemConfiguration()
            cfg.Show()
            System.Diagnostics.Debug.WriteLine("[v0] System Configuration opened via keyboard shortcut")
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Error opening System Configuration: " & ex.Message)
            MessageBox.Show("Unable to open System Configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Register link click - navigate to registration form
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim registerForm As New StaffRegister()
        registerForm.Show()
        Me.Hide()
    End Sub

    ' Show/Hide password toggle for login form
    Private Sub btn_ShowPasswordLogin_Click(sender As Object, e As EventArgs) Handles btn_ShowPasswordLogin.Click
        If txb_Password.PasswordChar = "*"c Then
            txb_Password.PasswordChar = Char.MinValue
            btn_ShowPasswordLogin.Text = "Hide"
        Else
            txb_Password.PasswordChar = "*"c
            btn_ShowPasswordLogin.Text = "Show"
        End If
    End Sub


End Class
