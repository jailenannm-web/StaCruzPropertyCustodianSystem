Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports Microsoft.VisualBasic
Imports PasswordHelper
Imports System.Linq

Public Class DatabaseConnection
    ' Fixed the UnhandledException event handler syntax - removed incorrect += operator usage
    Shared Sub New()
        ' Suppress ReplicationManager initialization errors at application level
        Try
            AddHandler AppDomain.CurrentDomain.UnhandledException, Sub(s, e)
                                                                       Try
                                                                           Dim exMsg As String = e.ExceptionObject.ToString()
                                                                           If exMsg.Contains("ReplicationManager") OrElse exMsg.Contains("Replication") Then
                                                                               System.Diagnostics.Debug.WriteLine("[v0] ReplicationManager error suppressed at startup")
                                                                               ' Suppress the error - don't crash
                                                                           End If
                                                                       Catch
                                                                           ' Ignore errors in error handler
                                                                       End Try
                                                                   End Sub
        Catch
            ' Ignore if handler can't be added
        End Try
    End Sub

    ' Lazy initialization of connection string to prevent ReplicationManager errors
    Private Shared _connectionString As String = Nothing

    ''' <summary>
    ''' Get connection string with proper error handling and fix for MySql.Data 8.0.33 compatibility
    ''' </summary>
    Private Shared Function GetConnectionString() As String
        If _connectionString Is Nothing Then
            Try
                ' Try to get connection string from App.config
                Dim baseConnStr As String = Nothing
                Try
                    If ConfigurationManager.ConnectionStrings("MySQLConnection") IsNot Nothing Then
                        baseConnStr = ConfigurationManager.ConnectionStrings("MySQLConnection").ConnectionString
                    End If
                Catch configEx As ConfigurationErrorsException
                    System.Diagnostics.Debug.WriteLine("[v0] ConfigurationManager Error: " & configEx.Message)
                    ' Configuration system failed, use fallback
                    baseConnStr = Nothing
                Catch configEx As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Configuration Error: " & configEx.Message)
                    baseConnStr = Nothing
                End Try

                ' If configuration failed or connection string is empty, use default fallback
                If String.IsNullOrEmpty(baseConnStr) Then
                    System.Diagnostics.Debug.WriteLine("[v0] Using fallback connection string (ConfigurationManager unavailable)")
                    baseConnStr = "Server=localhost;Database=teamcruzim;Uid=root;Pwd=;AllowZeroDateTime=true;SslMode=None;ConnectionTimeout=10;DefaultCommandTimeout=30"
                End If

                ' Build connection string manually to avoid ReplicationManager initialization issues
                ' Parse the base connection string and rebuild it with all necessary parameters
                Dim connParts As New List(Of String)

                ' Extract key-value pairs from base connection string
                Dim separator() As Char = {";"c}
                Dim parts() As String = baseConnStr.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                For Each part As String In parts
                    Dim trimmedPart As String = part.Trim()
                    If Not String.IsNullOrEmpty(trimmedPart) Then
                        Dim equalSeparator() As Char = {"="c}
                        Dim keyValue() As String = trimmedPart.Split(equalSeparator, 2, StringSplitOptions.None)
                        If keyValue.Length = 2 Then
                            Dim key As String = keyValue(0).Trim().ToLower()
                            Dim value As String = keyValue(1).Trim()

                            ' Skip replication-related keys to rebuild them
                            If key <> "replication" Then
                                connParts.Add(keyValue(0).Trim() & "=" & value)
                            End If
                        End If
                    End If
                Next

                ' Add critical parameters to prevent ReplicationManager issues
                connParts.Add("Replication=False")
                connParts.Add("AllowLoadLocalInfile=False")
                connParts.Add("AllowUserVariables=True")
                connParts.Add("AllowZeroDateTime=True")
                connParts.Add("ConvertZeroDateTime=True")

                ' Build final connection string
                _connectionString = String.Join(";", connParts)
                System.Diagnostics.Debug.WriteLine("[v0] Connection String Built: " & _connectionString.Replace("Pwd=", "Pwd=***"))
            Catch ex As TypeInitializationException
                ' If ReplicationManager initialization fails, use hardcoded fallback
                System.Diagnostics.Debug.WriteLine("[v0] TypeInit Error - Using hardcoded connection string")
                _connectionString = "Server=localhost;Database=teamcruzim;Uid=root;Pwd=;Replication=False;AllowLoadLocalInfile=False;AllowUserVariables=True;AllowZeroDateTime=True;ConvertZeroDateTime=True;SslMode=None;ConnectionTimeout=10;DefaultCommandTimeout=30"
            Catch ex As ConfigurationErrorsException
                ' Configuration system failed, use hardcoded fallback
                System.Diagnostics.Debug.WriteLine("[v0] Configuration System Error - Using hardcoded connection string: " & ex.Message)
                _connectionString = "Server=localhost;Database=teamcruzim;Uid=root;Pwd=;Replication=False;AllowLoadLocalInfile=False;AllowUserVariables=True;AllowZeroDateTime=True;ConvertZeroDateTime=True;SslMode=None;ConnectionTimeout=10;DefaultCommandTimeout=30"
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] Connection String Error: " & ex.Message)
                ' Use hardcoded fallback as last resort
                System.Diagnostics.Debug.WriteLine("[v0] Using hardcoded fallback connection string")
                _connectionString = "Server=localhost;Database=teamcruzim;Uid=root;Pwd=;Replication=False;AllowLoadLocalInfile=False;AllowUserVariables=True;AllowZeroDateTime=True;ConvertZeroDateTime=True;SslMode=None;ConnectionTimeout=10;DefaultCommandTimeout=30"
            End Try
        End If
        Return _connectionString
    End Function

    ''' <summary>
    ''' Get a new MySQL connection with exception handling for ReplicationManager issues
    ''' </summary>
    Public Shared Function GetConnection() As MySqlConnection
        Dim retryCount As Integer = 0
        Dim maxRetries As Integer = 2

        While retryCount < maxRetries
            Try
                ' Retrieve connection string safely
                Dim connStr As String = GetConnectionString()

                ' Validate connection string is not empty
                If String.IsNullOrEmpty(connStr) Then
                    Throw New Exception("Connection string is empty")
                End If

                ' Create connection without triggering replication manager initialization
                ' Wrap in try-catch to handle TypeInitializationException
                Dim conn As MySqlConnection = Nothing
                Try
                    conn = New MySqlConnection(connStr)
                Catch ex As TypeInitializationException When ex.Message.Contains("ReplicationManager")
                    System.Diagnostics.Debug.WriteLine("[v0] GetConnection - TypeInit ReplicationManager error, using fallback")
                    ' Force rebuild connection string and try again
                    _connectionString = Nothing
                    connStr = GetConnectionString()
                    conn = New MySqlConnection(connStr)
                End Try

                ' Validate connection can be created
                Return conn
            Catch ex As MySqlException
                System.Diagnostics.Debug.WriteLine("[v0] MySQL Connection Error: " & ex.Message)
                If ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1 Then
                    ' Retry with a fresh connection string
                    _connectionString = Nothing
                    retryCount += 1
                    System.Threading.Thread.Sleep(100)
                    Continue While
                ElseIf ex.Message.Contains("ReplicationManager") Then
                    MessageBox.Show("Database connection issue detected. Please ensure MySQL is running properly." & vbCrLf & "Error: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Throw
                Else
                    MessageBox.Show("Database connection error: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Throw
                End If
            Catch ex As ArgumentException
                ' Handle the "allowloadinguserdefinedunsafeserializabletypes" error specifically
                If (ex.Message.Contains("allowloadinguserdefinedunsafeserializabletypes") OrElse ex.ParamName = "allowloadinguserdefinedunsafeserializabletypes") AndAlso retryCount < maxRetries - 1 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Connection String Parameter Error: " & ex.Message & " - Retrying...")
                    ' Reset connection string and retry
                    _connectionString = Nothing
                    retryCount += 1
                    System.Threading.Thread.Sleep(100)
                    Continue While
                ElseIf ex.Message.Contains("allowloadinguserdefinedunsafeserializabletypes") OrElse ex.ParamName = "allowloadinguserdefinedunsafeserializabletypes" Then
                    System.Diagnostics.Debug.WriteLine("[v0] Connection String Parameter Error: " & ex.Message)
                    ' Reset connection string and retry with manual build
                    _connectionString = Nothing
                    If retryCount < maxRetries - 1 Then
                        retryCount += 1
                        System.Threading.Thread.Sleep(100)
                        Continue While
                    Else
                        Throw New Exception("Failed to create database connection: " & ex.Message, ex)
                    End If
                Else
                    Throw
                End If
            Catch ex As TypeInitializationException
                ' Handle ReplicationManager type initialization errors
                If ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1 Then
                    System.Diagnostics.Debug.WriteLine("[v0] ReplicationManager TypeInit Error - Retrying: " & ex.Message)
                    _connectionString = Nothing
                    retryCount += 1
                    System.Threading.Thread.Sleep(200)
                    Continue While
                Else
                    Throw New Exception("Database connection failed due to initialization error. Please restart the application.", ex)
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] Connection Creation Error: " & ex.Message)
                ' Check if it's the specific parameter error
                If ex.Message.Contains("allowloadinguserdefinedunsafeserializabletypes") OrElse ex.Message.Contains("Option not supported") Then
                    If retryCount < maxRetries - 1 Then
                        _connectionString = Nothing
                        retryCount += 1
                        System.Threading.Thread.Sleep(100)
                        Continue While
                    Else
                        Throw New Exception("Failed to create database connection: Option not supported. Please check your MySQL connector version compatibility.", ex)
                    End If
                ElseIf ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1 Then
                    _connectionString = Nothing
                    retryCount += 1
                    System.Threading.Thread.Sleep(200)
                    Continue While
                Else
                    Throw New Exception("Failed to create database connection: " & ex.Message, ex)
                End If
            End Try
        End While

        ' Should never reach here, but just in case
        Throw New Exception("Failed to create database connection after multiple retries")
    End Function

    ''' <summary>
    ''' Test database connection
    ''' </summary>
    Public Shared Function TestConnection() As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                conn.Close()
                System.Diagnostics.Debug.WriteLine("[v0] Database connection test successful")
                Return True
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Database connection test failed: " & ex.Message)
            MessageBox.Show("Database connection failed: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Validate staff login credentials with password hashing
    ''' </summary>
    Public Shared Function ValidateStaffLogin(username As String, password As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
                System.Diagnostics.Debug.WriteLine("[v0] Staff Login - Empty credentials")
                Return False
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return False

            ' Added retry logic for ReplicationManager errors specifically
            Dim retryCount As Integer = 0
            Dim maxRetries As Integer = 3
            Dim connectionOpened As Boolean = False

            While retryCount < maxRetries AndAlso Not connectionOpened
                Try
                    conn.Open()
                    connectionOpened = True
                Catch ex As MySqlException When ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1
                    System.Diagnostics.Debug.WriteLine("[v0] ReplicationManager error on login attempt " & (retryCount + 1) & ", retrying...")
                    retryCount += 1
                    System.Threading.Thread.Sleep(500) ' Wait before retry
                    conn.Dispose()
                    conn = GetConnection()
                End Try
            End While

            If Not connectionOpened Then
                System.Diagnostics.Debug.WriteLine("[v0] Failed to open connection after " & maxRetries & " retries")
                Return False
            End If

            ' Query staff from staff_accounts table
            Dim query As String = "SELECT password FROM staff_accounts WHERE LOWER(username) = LOWER(@username) AND status = 'Active'"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)

                Dim storedHashObj As Object = cmd.ExecuteScalar()

                If storedHashObj Is Nothing OrElse IsDBNull(storedHashObj) Then
                    System.Diagnostics.Debug.WriteLine("[v0] Staff Login Failed - User not found: " & username)
                    Return False
                End If

                Dim storedHash As String = CStr(storedHashObj)

                If PasswordHelper.VerifyPassword(password, storedHash) Then
                    System.Diagnostics.Debug.WriteLine("[v0] Staff Login Success: " & username)
                    Return True
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] Staff Login Failed - Invalid password: " & username)
                    Return False
                End If
            End Using
        Catch ex As MySqlException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] Staff Login - ReplicationManager error: " & ex.Message)
            MessageBox.Show("Database connection issue. Please try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Staff Login Exception: " & ex.Message)
            MessageBox.Show("Error validating login: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error closing connection in ValidateStaffLogin: " & ex.Message)
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Validate admin/super admin login credentials with password hashing
    ''' </summary>
    Public Shared Function ValidateAdminLogin(username As String, password As String) As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)
        Dim conn As MySqlConnection = Nothing
        Try
            If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
                System.Diagnostics.Debug.WriteLine("[v0] Admin Login - Empty credentials")
                Return result
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return result

            ' Added retry logic for ReplicationManager errors on admin login too
            Dim retryCount As Integer = 0
            Dim maxRetries As Integer = 3
            Dim connectionOpened As Boolean = False

            While retryCount < maxRetries AndAlso Not connectionOpened
                Try
                    conn.Open()
                    connectionOpened = True
                Catch ex As MySqlException When ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1
                    System.Diagnostics.Debug.WriteLine("[v0] ReplicationManager error on admin login attempt " & (retryCount + 1) & ", retrying...")
                    retryCount += 1
                    System.Threading.Thread.Sleep(500)
                    conn.Dispose()
                    conn = GetConnection()
                End Try
            End While

            If Not connectionOpened Then
                System.Diagnostics.Debug.WriteLine("[v0] Failed to open connection for admin login after " & maxRetries & " retries")
                Return result
            End If

            ' Query admin/superadmin from users table
            Dim query As String = "SELECT user_id, first_name, last_name, email, username, user_type, password " &
                                 "FROM users WHERE LOWER(username) = LOWER(@username) AND (user_type = 'Admin' OR user_type = 'SuperAdmin') AND status = 'Active'"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim storedHash As String = reader("password").ToString()

                        If PasswordHelper.VerifyPassword(password, storedHash) Then
                            result("user_id") = reader("user_id").ToString()
                            result("first_name") = reader("first_name").ToString()
                            result("last_name") = reader("last_name").ToString()
                            result("email") = reader("email").ToString()
                            result("username") = reader("username").ToString()
                            result("user_type") = reader("user_type").ToString()
                            System.Diagnostics.Debug.WriteLine("[v0] Admin Login Success: " & username & " (" & result("user_type") & ")")
                        Else
                            System.Diagnostics.Debug.WriteLine("[v0] Admin Login Failed - Invalid password: " & username)
                        End If
                    Else
                        System.Diagnostics.Debug.WriteLine("[v0] Admin Login Failed - User not found: " & username)
                    End If
                End Using
            End Using
        Catch ex As MySqlException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] Admin Login - ReplicationManager error: " & ex.Message)
            MessageBox.Show("Database connection issue. Please try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Admin Login Exception: " & ex.Message)
            MessageBox.Show("Error validating login: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error closing connection in ValidateAdminLogin: " & ex.Message)
                End Try
            End If
        End Try
        Return result
    End Function

    ''' <summary>
    ''' Register a new staff member with password encryption
    ''' </summary>
    Public Shared Function RegisterStaff(firstName As String, lastName As String, email As String,
                                         contactNumber As String, address As String, departmentID As String,
                                         username As String, password As String,
                                         Optional position As String = "Staff") As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then
                MessageBox.Show("Cannot connect to database. Please check your connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            ' Added retry logic for ReplicationManager errors on registration
            Dim retryCount As Integer = 0
            Dim maxRetries As Integer = 3
            Dim connectionOpened As Boolean = False

            While retryCount < maxRetries AndAlso Not connectionOpened
                Try
                    conn.Open()
                    connectionOpened = True
                Catch ex As MySqlException When ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1
                    System.Diagnostics.Debug.WriteLine("[v0] ReplicationManager error on registration attempt " & (retryCount + 1) & ", retrying...")
                    retryCount += 1
                    System.Threading.Thread.Sleep(500)
                    conn.Dispose()
                    conn = GetConnection()
                Catch ex As TypeInitializationException When ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1
                    System.Diagnostics.Debug.WriteLine("[v0] ReplicationManager TypeInit error on registration attempt " & (retryCount + 1) & ", retrying...")
                    retryCount += 1
                    System.Threading.Thread.Sleep(500)
                    conn.Dispose()
                    conn = GetConnection()
                End Try
            End While

            If Not connectionOpened Then
                System.Diagnostics.Debug.WriteLine("[v0] Failed to open connection for registration after " & maxRetries & " retries")
                MessageBox.Show("Failed to connect to database. Please ensure MySQL is running and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            System.Diagnostics.Debug.WriteLine("[v0] === REGISTRATION START === Position: " & position & ", Username: " & username & ", Email: " & email)

            ' Validate inputs
            If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
                MessageBox.Show("Username and password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Check if username already exists in staff_accounts
            Dim checkStaffQuery As String = "SELECT COUNT(*) FROM staff_accounts WHERE LOWER(username) = LOWER(@username)"
            Using checkCmd As New MySqlCommand(checkStaffQuery, conn)
                checkCmd.Parameters.AddWithValue("@username", username)
                If CInt(checkCmd.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    System.Diagnostics.Debug.WriteLine("[v0] Registration Failed - Username exists in staff_accounts")
                    Return False
                End If
            End Using

            ' Check if username already exists in users table
            Dim checkUsersQuery As String = "SELECT COUNT(*) FROM users WHERE LOWER(username) = LOWER(@username)"
            Using checkCmd As New MySqlCommand(checkUsersQuery, conn)
                checkCmd.Parameters.AddWithValue("@username", username)
                If CInt(checkCmd.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    System.Diagnostics.Debug.WriteLine("[v0] Registration Failed - Username exists in users")
                    Return False
                End If
            End Using

            ' Hash password
            Dim hashedPassword As String = PasswordHelper.HashPassword(password)
            If String.IsNullOrEmpty(hashedPassword) Then
                MessageBox.Show("Error encrypting password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            ' Insert based on position
            If position = "Super Admin" OrElse position = "Admin" Then
                ' Insert into users table for Admin accounts
                Dim userType As String = If(position = "Super Admin", "SuperAdmin", "Admin")
                Dim insertQuery As String = "INSERT INTO users (first_name, last_name, email, username, password, user_type, status, created_date) " &
                                           "VALUES (@firstName, @lastName, @email, @username, @password, @userType, 'Active', NOW())"

                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@firstName", firstName)
                    cmd.Parameters.AddWithValue("@lastName", lastName)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", hashedPassword)
                    cmd.Parameters.AddWithValue("@userType", userType)

                    Dim result As Integer = cmd.ExecuteNonQuery()
                    If result > 0 Then
                        System.Diagnostics.Debug.WriteLine("[v0] SUCCESS - " & userType & " registered: " & username)
                        MessageBox.Show("Registration successful! Your " & userType & " account has been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    Else
                        MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        System.Diagnostics.Debug.WriteLine("[v0] FAILED - No rows inserted for " & userType)
                        Return False
                    End If
                End Using
            Else
                ' Insert into staff_accounts table for Staff
                Dim insertQuery As String = "INSERT INTO staff_accounts (first_name, last_name, email, contact_number, address, department_id, username, password, status, created_date) " &
                                           "VALUES (@firstName, @lastName, @email, @contactNumber, @address, @departmentID, @username, @password, 'Active', NOW())"

                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@firstName", firstName)
                    cmd.Parameters.AddWithValue("@lastName", lastName)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue("@contactNumber", contactNumber)
                    cmd.Parameters.AddWithValue("@address", address)
                    cmd.Parameters.AddWithValue("@departmentID", If(String.IsNullOrEmpty(departmentID), DBNull.Value, departmentID))
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", hashedPassword)

                    Dim result As Integer = cmd.ExecuteNonQuery()
                    If result > 0 Then
                        System.Diagnostics.Debug.WriteLine("[v0] SUCCESS - Staff registered: " & username)
                        MessageBox.Show("Registration successful! Your Staff account has been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    Else
                        MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        System.Diagnostics.Debug.WriteLine("[v0] FAILED - No rows inserted for Staff")
                        Return False
                    End If
                End Using
            End If
        Catch ex As MySqlException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] Registration - ReplicationManager error: " & ex.Message)
            MessageBox.Show("Database connection issue during registration. Please try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As MySqlException
            System.Diagnostics.Debug.WriteLine("[v0] MySQL Registration Error: " & ex.Message & vbCrLf & ex.StackTrace)
            MessageBox.Show("Database error during registration: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As TypeInitializationException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] Registration - ReplicationManager TypeInit error: " & ex.Message)
            MessageBox.Show("Database initialization error. Please restart the application and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Registration Exception: " & ex.Message & vbCrLf & ex.StackTrace)
            If ex.Message.Contains("ReplicationManager") Then
                MessageBox.Show("Database connection issue. Please ensure MySQL is running and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Error during registration: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error closing connection: " & ex.Message)
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Get staff member details by username
    ''' </summary>
    Public Shared Function GetStaffDetails(username As String) As Dictionary(Of String, String)
        Dim staffDetails As New Dictionary(Of String, String)
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return staffDetails

            If Not SafeOpenConnection(conn) Then Return staffDetails

            Dim query As String = "SELECT staff_id, first_name, last_name, email, department_id FROM staff_accounts WHERE username = @username"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        staffDetails("staff_id") = reader("staff_id").ToString()
                        staffDetails("first_name") = reader("first_name").ToString()
                        staffDetails("last_name") = reader("last_name").ToString()
                        staffDetails("email") = reader("email").ToString()
                        staffDetails("department_id") = reader("department_id").ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetStaffDetails Exception: " & ex.Message)
            MessageBox.Show("Error retrieving staff details: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return staffDetails
    End Function


    ''' <summary>
    ''' Verify old password before allowing password change
    ''' </summary>
    Public Shared Function VerifyOldPassword(adminID As String, oldPassword As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Retrieve stored password hash to verify old password
            Dim query As String = "SELECT password FROM users WHERE user_id = @adminID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@adminID", adminID)

                Dim storedHashObj As Object = cmd.ExecuteScalar()

                If storedHashObj Is Nothing OrElse IsDBNull(storedHashObj) Then
                    System.Diagnostics.Debug.WriteLine("[v0] Old Password Verification Failed - No password found")
                    Return False
                End If

                Dim storedHash As String = CStr(storedHashObj)

                If PasswordHelper.VerifyPassword(oldPassword, storedHash) Then
                    System.Diagnostics.Debug.WriteLine("[v0] Old Password Verified Successfully")
                    Return True
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] Old Password Verification Failed - Password mismatch")
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Verify Old Password Exception: " & ex.Message)
            MessageBox.Show("Error verifying old password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Update admin password with SHA256 hashing (after old password verification)
    ''' </summary>
    Public Shared Function UpdateAdminPassword(adminID As String, newPassword As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            ' Hash the new password before storing
            Dim hashedPassword As String = PasswordHelper.HashPassword(newPassword)

            If String.IsNullOrEmpty(hashedPassword) Then
                MessageBox.Show("Error encrypting new password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Diagnostics.Debug.WriteLine("[v0] Password Update Failed - Hashing error")
                Return False
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Update password with timestamp
            Dim query As String = "UPDATE users SET password = @password, updated_at = NOW() " &
                                 "WHERE user_id = @adminID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@password", hashedPassword)
                cmd.Parameters.AddWithValue("@adminID", adminID)

                Dim result As Integer = cmd.ExecuteNonQuery()

                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Admin Password Updated Successfully - ID: " & adminID)
                    Return True
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] Admin Password Update Failed - No rows affected")
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Update Admin Password Exception: " & ex.Message)
            MessageBox.Show("Error updating admin password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Add new supply to database - FIXED FOR REPLICATION MANAGER
    ''' </summary>
    Public Shared Function AddSupply(supplyID As String, supplyName As String, category As String,
                                     stock As Integer, unitCost As Decimal, totalValue As Decimal,
                                     status As String, location As String, description As String,
                                     uom As String, reorderLevel As Integer, supplierID As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            ' Wrapped connection creation in try-catch to handle ReplicationManager errors gracefully
            conn = GetConnection()

            If conn Is Nothing Then
                MessageBox.Show("Failed to create database connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Diagnostics.Debug.WriteLine("[v0] AddSupply - Connection object is null")
                Return False
            End If

            ' Open connection with retry logic for ReplicationManager issues
            Dim retryCount As Integer = 0
            Dim maxRetries As Integer = 3

            While retryCount < maxRetries
                Try
                    conn.Open()
                    Exit While
                Catch ex As MySqlException When ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1
                    System.Diagnostics.Debug.WriteLine("[v0] ReplicationManager error on attempt " & (retryCount + 1) & ", retrying...")
                    retryCount += 1
                    System.Threading.Thread.Sleep(500) ' Wait before retry
                    conn.Dispose()
                    conn = GetConnection()
                End Try
            End While

            ' Check if supply ID already exists
            Dim checkQuery As String = "SELECT COUNT(*) FROM supplies WHERE SupplyID = @supplyID"
            Using checkCmd As New MySqlCommand(checkQuery, conn)
                checkCmd.Parameters.AddWithValue("@supplyID", supplyID)
                Dim count As Integer = CInt(checkCmd.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("Supply ID already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    System.Diagnostics.Debug.WriteLine("[v0] Supply Add Failed - Duplicate ID: " & supplyID)
                    Return False
                End If
            End Using

            ' Updated INSERT to match actual SQL schema column names
            Dim query As String = "INSERT INTO supplies (SupplyID, SupplyName, Category, QuantityInStock, UnitCost, " &
                                 "TotalValue, Status, Location, Description, UnitOfMeasure, ReorderLevel, Supplier, AcquisitionDate) " &
                                 "VALUES (@supplyID, @supplyName, @category, @stock, @unitCost, @totalValue, @status, " &
                                 "@location, @description, @uom, @reorderLevel, @supplier, NOW())"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@supplyID", supplyID)
                cmd.Parameters.AddWithValue("@supplyName", supplyName)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@stock", stock)
                cmd.Parameters.AddWithValue("@unitCost", unitCost)
                cmd.Parameters.AddWithValue("@totalValue", totalValue)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@location", location)
                cmd.Parameters.AddWithValue("@description", description)
                cmd.Parameters.AddWithValue("@uom", uom)
                cmd.Parameters.AddWithValue("@reorderLevel", reorderLevel)
                cmd.Parameters.AddWithValue("@supplier", supplierID)

                Dim result As Integer = cmd.ExecuteNonQuery()

                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Supply Added Successfully - ID: " & supplyID)
                    MessageBox.Show("Supply added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] Supply Add Failed - No rows affected")
                    MessageBox.Show("Failed to add supply. No rows affected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error adding supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Add Supply MySQL Exception: " & ex.Message & vbCrLf & ex.StackTrace)
            Return False
        Catch ex As Exception
            MessageBox.Show("Error adding supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Add Supply Exception: " & ex.Message & vbCrLf & ex.StackTrace)
            Return False
        Finally
            ' Ensure connection is always properly closed and disposed
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Dispose()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error closing connection in AddSupply: " & ex.Message)
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Get all supplies from database - FIXED FOR REPLICATION MANAGER
    ''' </summary>
    Public Shared Function GetAllSupplies() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            ' Reset connection string to force rebuild if there was a previous error
            If _connectionString IsNot Nothing AndAlso _connectionString.Contains("ReplicationManager") Then
                _connectionString = Nothing
            End If

            ' Added retry logic for ReplicationManager initialization failures
            conn = GetConnection()

            If conn Is Nothing Then
                System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - Connection is null")
                MessageBox.Show("Failed to establish database connection. Please check your database configuration.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return dt
            End If

            ' Open connection with retry logic
            Dim retryCount As Integer = 0
            Dim maxRetries As Integer = 3
            Dim connectionOpened As Boolean = False

            While retryCount < maxRetries AndAlso Not connectionOpened
                Try
                    conn.Open()
                    connectionOpened = True
                Catch ex As TypeInitializationException When ex.Message.Contains("ReplicationManager")
                    System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - TypeInit ReplicationManager error, resetting connection string")
                    _connectionString = Nothing ' Force rebuild connection string
                    retryCount += 1
                    If retryCount < maxRetries Then
                        System.Threading.Thread.Sleep(500)
                        conn.Dispose()
                        conn = GetConnection()
                    End If
                Catch ex As MySqlException When ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1
                    System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - ReplicationManager error on attempt " & (retryCount + 1))
                    _connectionString = Nothing ' Force rebuild connection string
                    retryCount += 1
                    System.Threading.Thread.Sleep(500)
                    conn.Dispose()
                    conn = GetConnection()
                Catch ex As Exception When ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1
                    System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - General ReplicationManager error on attempt " & (retryCount + 1))
                    _connectionString = Nothing
                    retryCount += 1
                    System.Threading.Thread.Sleep(500)
                    conn.Dispose()
                    conn = GetConnection()
                End Try
            End While

            If Not connectionOpened Then
                System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - Failed to open connection after retries")
                MessageBox.Show("Database connection failed. Please ensure MySQL is running and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return dt
            End If

            ' Updated column names to match actual SQL schema
            Dim query As String = "SELECT SupplyID, SupplyName, Category, QuantityInStock, UnitCost, TotalValue, Status, Location " &
                                 "FROM supplies ORDER BY AcquisitionDate DESC"
            Using cmd As New MySqlCommand(query, conn)
                cmd.CommandTimeout = 30
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - Loaded " & dt.Rows.Count & " supplies")
                End Using
            End Using
        Catch ex As TypeInitializationException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - TypeInit ReplicationManager error: " & ex.Message)
            MessageBox.Show("Database initialization error. Please restart the application.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As MySqlException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - ReplicationManager error: " & ex.Message)
            MessageBox.Show("Database connection issue. Please try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies Exception: " & ex.Message & vbCrLf & ex.StackTrace)
            If ex.Message.Contains("ReplicationManager") Then
                MessageBox.Show("Database connection error. Please restart the application and ensure MySQL is running.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Error retrieving supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error closing connection in GetAllSupplies: " & ex.Message)
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Update supply information
    ''' </summary>
    Public Shared Function UpdateSupply(supplyID As String, supplyName As String, category As String,
                                       stock As Integer, unitCost As Decimal, totalValue As Decimal,
                                       status As String, location As String) As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Dim query As String = "UPDATE supplies SET SupplyName = @supplyName, Category = @category, " &
                                     "QuantityInStock = @stock, UnitCost = @unitCost, TotalValue = @totalValue, " &
                                     "Status = @status, Location = @location WHERE SupplyID = @supplyID"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@supplyName", supplyName)
                    cmd.Parameters.AddWithValue("@category", category)
                    cmd.Parameters.AddWithValue("@stock", stock)
                    cmd.Parameters.AddWithValue("@unitCost", unitCost)
                    cmd.Parameters.AddWithValue("@totalValue", totalValue)
                    cmd.Parameters.AddWithValue("@status", status)
                    cmd.Parameters.AddWithValue("@location", location)
                    cmd.Parameters.AddWithValue("@supplyID", supplyID)

                    Dim result As Integer = cmd.ExecuteNonQuery()
                    If result > 0 Then
                        System.Diagnostics.Debug.WriteLine("[v0] Supply Updated - ID: " & supplyID)
                        Return True
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating supply: " & ex.Message)
            System.Diagnostics.Debug.WriteLine("[v0] Update Supply Exception: " & ex.Message)
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Delete supply from database
    ''' </summary>
    Public Shared Function DeleteSupply(supplyID As String) As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Dim query As String = "DELETE FROM supplies WHERE SupplyID = @supplyID"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@supplyID", supplyID)

                    Dim result As Integer = cmd.ExecuteNonQuery()
                    If result > 0 Then
                        System.Diagnostics.Debug.WriteLine("[v0] Supply Deleted - ID: " & supplyID)
                        Return True
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting supply: " & ex.Message)
            System.Diagnostics.Debug.WriteLine("[v0] Delete Supply Exception: " & ex.Message)
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Get dashboard statistics for supplies
    ''' </summary>
    Public Shared Function GetSupplyDashboardStats() As Dictionary(Of String, Integer)
        Dim stats As New Dictionary(Of String, Integer)
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return stats

            If Not SafeOpenConnection(conn) Then Return stats

            ' Total supplies
            Dim totalQuery As String = "SELECT COUNT(*) FROM supplies"
            Using cmd As New MySqlCommand(totalQuery, conn)
                stats("total_supplies") = CInt(cmd.ExecuteScalar())
            End Using

            ' Available supplies
            Dim availableQuery As String = "SELECT COUNT(*) FROM supplies WHERE Status = 'Available'"
            Using cmd As New MySqlCommand(availableQuery, conn)
                stats("available_supplies") = CInt(cmd.ExecuteScalar())
            End Using

            ' Low stock supplies
            Dim lowStockQuery As String = "SELECT COUNT(*) FROM supplies WHERE QuantityInStock <= ReorderLevel"
            Using cmd As New MySqlCommand(lowStockQuery, conn)
                stats("low_stock_supplies") = CInt(cmd.ExecuteScalar())
            End Using

            System.Diagnostics.Debug.WriteLine("[v0] Dashboard Stats - Total: " & stats("total_supplies") &
                                             ", Available: " & stats("available_supplies") &
                                             ", Low Stock: " & stats("low_stock_supplies"))
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetSupplyDashboardStats Exception: " & ex.Message)
            MessageBox.Show("Error loading dashboard statistics: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return stats
    End Function

    ' =====================================================
    ' PROPERTY MANAGEMENT FUNCTIONS (Fixed Assets)
    ' =====================================================

    ''' <summary>
    ''' Add new property to database
    ''' </summary>
    Public Shared Function AddProperty(propertyName As String, category As String, description As String,
                                       serialNumber As String, acquisitionDate As Date, acquisitionCost As Decimal,
                                       supplierName As String, supplierContact As String, conditionStatus As String,
                                       location As String, custodianID As Integer?, departmentID As Integer?,
                                       warrantyDetails As String, lifeSpan As Integer?) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            ' Validate serial number uniqueness
            If Not String.IsNullOrEmpty(serialNumber) Then
                If CheckDuplicateSerialNumber(serialNumber) Then
                    MessageBox.Show("Serial number already exists. Please use a different serial number.", "Duplicate Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Calculate depreciation value if life span is provided
            Dim depreciationValue As Decimal = 0
            If lifeSpan.HasValue AndAlso lifeSpan.Value > 0 AndAlso acquisitionCost > 0 Then
                ' Simple straight-line depreciation: (acquisition_cost / life_span) * years_used
                ' For new property, years_used = 0, so depreciation = 0 initially
                depreciationValue = 0
            End If

            Dim query As String = "INSERT INTO properties (property_name, category, description, serial_number, " &
                                 "acquisition_date, acquisition_cost, supplier_name, supplier_contact, condition_status, " &
                                 "location, custodian_id, department_id, warranty_details, life_span, depreciation_value, status) " &
                                 "VALUES (@propertyName, @category, @description, @serialNumber, @acquisitionDate, " &
                                 "@acquisitionCost, @supplierName, @supplierContact, @conditionStatus, @location, " &
                                 "@custodianID, @departmentID, @warrantyDetails, @lifeSpan, @depreciationValue, 'active')"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@propertyName", propertyName)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@serialNumber", If(String.IsNullOrEmpty(serialNumber), DBNull.Value, serialNumber))
                cmd.Parameters.AddWithValue("@acquisitionDate", acquisitionDate)
                cmd.Parameters.AddWithValue("@acquisitionCost", acquisitionCost)
                cmd.Parameters.AddWithValue("@supplierName", supplierName)
                cmd.Parameters.AddWithValue("@supplierContact", If(String.IsNullOrEmpty(supplierContact), DBNull.Value, supplierContact))
                cmd.Parameters.AddWithValue("@conditionStatus", conditionStatus)
                cmd.Parameters.AddWithValue("@location", location)
                cmd.Parameters.AddWithValue("@custodianID", If(custodianID.HasValue, custodianID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@departmentID", If(departmentID.HasValue, departmentID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@warrantyDetails", If(String.IsNullOrEmpty(warrantyDetails), DBNull.Value, warrantyDetails))
                cmd.Parameters.AddWithValue("@lifeSpan", If(lifeSpan.HasValue, lifeSpan.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@depreciationValue", depreciationValue)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Property Added Successfully: " & propertyName)
                    MessageBox.Show("Property added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            End Using
        Catch ex As MySqlException
            System.Diagnostics.Debug.WriteLine("[v0] AddProperty MySQL Error: " & ex.Message)
            MessageBox.Show("Database error adding property: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddProperty Exception: " & ex.Message & vbCrLf & ex.StackTrace)
            MessageBox.Show("Error adding property: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Get all properties from database
    ''' </summary>
    Public Shared Function GetAllProperties() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            Dim retryCount As Integer = 0
            Dim maxRetries As Integer = 3

            While retryCount < maxRetries
                Try
                    conn.Open()
                    Exit While
                Catch ex As MySqlException When ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1
                    retryCount += 1
                    System.Threading.Thread.Sleep(500)
                    conn.Dispose()
                    conn = GetConnection()
                End Try
            End While

            Dim query As String = "SELECT property_id, property_name, category, serial_number, acquisition_date, " &
                                 "acquisition_cost, condition_status, location, status " &
                                 "FROM properties WHERE status != 'disposed' ORDER BY acquisition_date DESC"

            Using cmd As New MySqlCommand(query, conn)
                cmd.CommandTimeout = 30
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    System.Diagnostics.Debug.WriteLine("[v0] GetAllProperties - Loaded " & dt.Rows.Count & " properties")
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllProperties Exception: " & ex.Message)
            MessageBox.Show("Error retrieving properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return dt
    End Function

    ' =====================================================
    ' PROPERTY REQUEST FUNCTIONS
    ' =====================================================

    ''' <summary>
    ''' Submit a property request
    ''' </summary>
    Public Shared Function SubmitPropertyRequest(userID As Integer, propertyID As Integer?, supplyID As Integer?,
                                                 requestType As String, purpose As String, quantity As Integer,
                                                 expectedReturnDate As Date?) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "INSERT INTO property_requests (user_id, property_id, supply_id, request_type, " &
                                 "request_date, purpose, quantity, status, expected_return_date) " &
                                 "VALUES (@userID, @propertyID, @supplyID, @requestType, CURDATE(), @purpose, " &
                                 "@quantity, 'pending', @expectedReturnDate)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userID", userID)
                cmd.Parameters.AddWithValue("@propertyID", If(propertyID.HasValue, propertyID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@supplyID", If(supplyID.HasValue, supplyID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@requestType", requestType)
                cmd.Parameters.AddWithValue("@purpose", purpose)
                cmd.Parameters.AddWithValue("@quantity", quantity)
                cmd.Parameters.AddWithValue("@expectedReturnDate", If(expectedReturnDate.HasValue, expectedReturnDate.Value, DBNull.Value))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Property Request Submitted Successfully")
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Submit Property Request Exception: " & ex.Message)
            MessageBox.Show("Error submitting request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Get all property requests
    ''' </summary>
    Public Shared Function GetAllPropertyRequests() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT pr.request_id, CONCAT(sa.first_name, ' ', sa.last_name) AS requester_name, " &
                                 "COALESCE(p.property_name, sup.supply_name) AS item_name, pr.request_type, " &
                                 "pr.request_date, pr.purpose, pr.quantity, pr.status, pr.expected_return_date " &
                                 "FROM property_requests pr " &
                                 "LEFT JOIN staff_accounts sa ON pr.user_id = sa.staff_id " &
                                 "LEFT JOIN properties p ON pr.property_id = p.property_id " &
                                 "LEFT JOIN supplies sup ON pr.supply_id = sup.supply_id " &
                                 "ORDER BY pr.request_date DESC"

            Using cmd As New MySqlCommand(query, conn)
                cmd.CommandTimeout = 30
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllPropertyRequests Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Approve or reject a property request
    ''' </summary>
    Public Shared Function ProcessPropertyRequest(requestID As Integer, approvedBy As Integer, status As String,
                                                  remarks As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE property_requests SET status = @status, approved_by = @approvedBy, " &
                                 "approval_date = CURDATE(), remarks = @remarks " &
                                 "WHERE request_id = @requestID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@approvedBy", approvedBy)
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
                cmd.Parameters.AddWithValue("@requestID", requestID)

                Dim result As Integer = cmd.ExecuteNonQuery()
                Return result > 0
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Process Property Request Exception: " & ex.Message)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ' =====================================================
    ' MAINTENANCE FUNCTIONS
    ' =====================================================

    ''' <summary>
    ''' Add maintenance record
    ''' </summary>
    Public Shared Function AddMaintenance(propertyID As Integer, custodianID As Integer?, serviceDate As Date,
                                          serviceType As String, description As String, serviceProvider As String,
                                          providerContact As String, cost As Decimal, nextSchedule As Date?,
                                          technicianAssigned As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "INSERT INTO maintenance (property_id, custodian_id, service_date, service_type, " &
                                 "description, service_provider, provider_contact, cost, next_schedule, " &
                                 "technician_assigned, status) " &
                                 "VALUES (@propertyID, @custodianID, @serviceDate, @serviceType, @description, " &
                                 "@serviceProvider, @providerContact, @cost, @nextSchedule, @technicianAssigned, 'completed')"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@propertyID", propertyID)
                cmd.Parameters.AddWithValue("@custodianID", If(custodianID.HasValue, custodianID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@serviceDate", serviceDate)
                cmd.Parameters.AddWithValue("@serviceType", serviceType)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@serviceProvider", If(String.IsNullOrEmpty(serviceProvider), DBNull.Value, serviceProvider))
                cmd.Parameters.AddWithValue("@providerContact", If(String.IsNullOrEmpty(providerContact), DBNull.Value, providerContact))
                cmd.Parameters.AddWithValue("@cost", cost)
                cmd.Parameters.AddWithValue("@nextSchedule", If(nextSchedule.HasValue, nextSchedule.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@technicianAssigned", If(String.IsNullOrEmpty(technicianAssigned), DBNull.Value, technicianAssigned))

                Dim result As Integer = cmd.ExecuteNonQuery()
                Return result > 0
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Add Maintenance Exception: " & ex.Message)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Get all maintenance records
    ''' </summary>
    Public Shared Function GetAllMaintenance() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT m.maintenance_id, p.property_name, m.service_date, m.service_type, " &
                                 "m.description, m.service_provider, m.cost, m.status, m.next_schedule " &
                                 "FROM maintenance m " &
                                 "INNER JOIN properties p ON m.property_id = p.property_id " &
                                 "ORDER BY m.service_date DESC"

            Using cmd As New MySqlCommand(query, conn)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllMaintenance Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return dt
    End Function

    ' =====================================================
    ' AUDIT LOGGING FUNCTIONS
    ' =====================================================

    ''' <summary>
    ''' Log user activity for audit trail
    ''' </summary>
    Public Shared Sub LogActivity(userID As Integer?, userType As String, username As String, action As String,
                                 moduleName As String, description As String, Optional ipAddress As String = "")
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return ' Cannot log if connection fails

            If Not SafeOpenConnection(conn) Then Return

            Dim query As String = "INSERT INTO audit_logs (user_id, user_type, username, action, module, description, ip_address) " &
                                 "VALUES (@userID, @userType, @username, @action, @module, @description, @ipAddress)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userID", If(userID.HasValue, userID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@userType", userType)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@action", action)
                cmd.Parameters.AddWithValue("@module", moduleName)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@ipAddress", If(String.IsNullOrEmpty(ipAddress), DBNull.Value, ipAddress))

                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ' Don't show error for audit logging failures to avoid disrupting user workflow
            System.Diagnostics.Debug.WriteLine("[v0] Audit Log Error: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Get audit logs
    ''' </summary>
    Public Shared Function GetAuditLogs(Optional startDate As Date? = Nothing, Optional endDate As Date? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT log_id, username, user_type, action, module, description, created_at " &
                                 "FROM audit_logs WHERE 1=1"

            If startDate.HasValue Then
                query &= " AND DATE(created_at) >= @startDate"
            End If
            If endDate.HasValue Then
                query &= " AND DATE(created_at) <= @endDate"
            End If

            query &= " ORDER BY created_at DESC LIMIT 1000"

            Using cmd As New MySqlCommand(query, conn)
                If startDate.HasValue Then
                    cmd.Parameters.AddWithValue("@startDate", startDate.Value)
                End If
                If endDate.HasValue Then
                    cmd.Parameters.AddWithValue("@endDate", endDate.Value)
                End If

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAuditLogs Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return dt
    End Function

    ' =====================================================
    ' HELPER FUNCTION: Safe Connection Opening
    ' =====================================================
    ''' <summary>
    ''' Safely open a database connection with ReplicationManager error handling
    ''' </summary>
    Private Shared Function SafeOpenConnection(conn As MySqlConnection, Optional maxRetries As Integer = 3) As Boolean
        Dim retryCount As Integer = 0
        While retryCount < maxRetries
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                    Return True
                ElseIf conn.State = ConnectionState.Open Then
                    Return True
                End If
            Catch ex As TypeInitializationException When ex.Message.Contains("ReplicationManager")
                System.Diagnostics.Debug.WriteLine("[v0] SafeOpenConnection - TypeInit ReplicationManager error on attempt " & (retryCount + 1))
                retryCount += 1
                If retryCount < maxRetries Then
                    System.Threading.Thread.Sleep(300)
                    _connectionString = Nothing ' Reset connection string
                    conn.Dispose()
                    conn = GetConnection() ' Re-obtain connection object
                End If
            Catch ex As MySqlException When ex.Message.Contains("ReplicationManager")
                System.Diagnostics.Debug.WriteLine("[v0] SafeOpenConnection - ReplicationManager error on attempt " & (retryCount + 1))
                retryCount += 1
                If retryCount < maxRetries Then
                    System.Threading.Thread.Sleep(300)
                    _connectionString = Nothing
                    conn.Dispose()
                    conn = GetConnection()
                End If
            Catch ex As Exception When ex.Message.Contains("ReplicationManager")
                System.Diagnostics.Debug.WriteLine("[v0] SafeOpenConnection - General ReplicationManager error on attempt " & (retryCount + 1))
                retryCount += 1
                If retryCount < maxRetries Then
                    System.Threading.Thread.Sleep(300)
                    _connectionString = Nothing
                    conn.Dispose()
                    conn = GetConnection()
                End If
            End Try
        End While
        Return False
    End Function

    ' =====================================================
    ' MODULE 1: ADMIN PERSONAL PROFILE MANAGEMENT
    ' =====================================================

    ''' <summary>
    ''' Load logged-in admin's profile information from users table (ENHANCED)
    ''' </summary>
    Public Shared Function LoadAdminProfile(adminID As String) As Dictionary(Of String, Object)
        Dim adminProfile As New Dictionary(Of String, Object)
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then
                MessageBox.Show("Failed to establish database connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return adminProfile
            End If

            If Not SafeOpenConnection(conn) Then
                MessageBox.Show("Failed to open database connection. Please ensure MySQL is running.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return adminProfile
            End If

            ' Query to load admin profile data by admin ID - includes all fields from users table
            Dim query As String = "SELECT user_id, first_name, middle_name, last_name, suffix, position, " &
                                 "department_id, contact_number, email, username, house_no_street, barangay, " &
                                 "municipality, province_city, date_assigned, employee_id, user_type, status, " &
                                 "last_login, created_at " &
                                 "FROM users WHERE user_id = @adminID AND status = 'active'"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@adminID", adminID)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        adminProfile("user_id") = reader("user_id").ToString()
                        adminProfile("first_name") = If(IsDBNull(reader("first_name")), "", reader("first_name").ToString())
                        adminProfile("middle_name") = If(IsDBNull(reader("middle_name")), "", reader("middle_name").ToString())
                        adminProfile("last_name") = If(IsDBNull(reader("last_name")), "", reader("last_name").ToString())
                        adminProfile("suffix") = If(IsDBNull(reader("suffix")), "", reader("suffix").ToString())
                        adminProfile("position") = If(IsDBNull(reader("position")), "", reader("position").ToString())
                        adminProfile("department_id") = If(IsDBNull(reader("department_id")), "", reader("department_id").ToString())
                        adminProfile("contact_number") = If(IsDBNull(reader("contact_number")), "", reader("contact_number").ToString())
                        adminProfile("email") = If(IsDBNull(reader("email")), "", reader("email").ToString())
                        adminProfile("username") = If(IsDBNull(reader("username")), "", reader("username").ToString())
                        adminProfile("house_no_street") = If(IsDBNull(reader("house_no_street")), "", reader("house_no_street").ToString())
                        adminProfile("barangay") = If(IsDBNull(reader("barangay")), "", reader("barangay").ToString())
                        adminProfile("municipality") = If(IsDBNull(reader("municipality")), "", reader("municipality").ToString())
                        adminProfile("province_city") = If(IsDBNull(reader("province_city")), "", reader("province_city").ToString())
                        adminProfile("date_assigned") = If(IsDBNull(reader("date_assigned")), "", reader("date_assigned").ToString())
                        adminProfile("employee_id") = If(IsDBNull(reader("employee_id")), "", reader("employee_id").ToString())
                        adminProfile("user_type") = If(IsDBNull(reader("user_type")), "", reader("user_type").ToString())
                        adminProfile("status") = If(IsDBNull(reader("status")), "", reader("status").ToString())
                        adminProfile("last_login") = If(IsDBNull(reader("last_login")), "", reader("last_login").ToString())
                        adminProfile("created_at") = If(IsDBNull(reader("created_at")), "", reader("created_at").ToString())
                        System.Diagnostics.Debug.WriteLine("[v0] Admin Profile Loaded Successfully - ID: " & adminID)
                    Else
                        System.Diagnostics.Debug.WriteLine("[v0] Admin Profile Not Found - ID: " & adminID)
                        MessageBox.Show("Admin profile not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As TypeInitializationException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] LoadAdminProfile - ReplicationManager TypeInit Error: " & ex.Message)
            MessageBox.Show("Database initialization error. Please restart the application.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As MySqlException
            System.Diagnostics.Debug.WriteLine("[v0] LoadAdminProfile MySQL Error: " & ex.Message)
            MessageBox.Show("Database error loading admin profile: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadAdminProfile Exception: " & ex.Message & vbCrLf & ex.StackTrace)
            MessageBox.Show("Error loading admin profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error closing connection in LoadAdminProfile: " & ex.Message)
                End Try
            End If
        End Try
        Return adminProfile
    End Function

    ''' <summary>
    ''' Check if username or email already exists (ENHANCED - checks both users and staff_accounts)
    ''' </summary>
    Public Shared Function CheckDuplicateCredentials(username As String, email As String, currentAdminID As String) As String
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return "error"

            If Not SafeOpenConnection(conn) Then Return "error"

            ' Check for duplicate username in users table (excluding current admin)
            Dim checkUsernameQuery As String = "SELECT COUNT(*) FROM users WHERE LOWER(username) = LOWER(@username) AND user_id != @adminID"
            Using cmd As New MySqlCommand(checkUsernameQuery, conn)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@adminID", currentAdminID)
                Dim usernameCount As Integer = CInt(cmd.ExecuteScalar())
                If usernameCount > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Duplicate Username Found in users table: " & username)
                    Return "duplicate_username"
                End If
            End Using

            ' Check for duplicate username in staff_accounts table
            Dim checkStaffUsernameQuery As String = "SELECT COUNT(*) FROM staff_accounts WHERE LOWER(username) = LOWER(@username)"
            Using cmd As New MySqlCommand(checkStaffUsernameQuery, conn)
                cmd.Parameters.AddWithValue("@username", username)
                Dim staffUsernameCount As Integer = CInt(cmd.ExecuteScalar())
                If staffUsernameCount > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Duplicate Username Found in staff_accounts table: " & username)
                    Return "duplicate_username"
                End If
            End Using

            ' Check for duplicate email in users table (excluding current admin)
            Dim checkEmailQuery As String = "SELECT COUNT(*) FROM users WHERE LOWER(email) = LOWER(@email) AND user_id != @adminID"
            Using cmd As New MySqlCommand(checkEmailQuery, conn)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@adminID", currentAdminID)
                Dim emailCount As Integer = CInt(cmd.ExecuteScalar())
                If emailCount > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Duplicate Email Found in users table: " & email)
                    Return "duplicate_email"
                End If
            End Using

            ' Check for duplicate email in staff_accounts table
            Dim checkStaffEmailQuery As String = "SELECT COUNT(*) FROM staff_accounts WHERE LOWER(email) = LOWER(@email)"
            Using cmd As New MySqlCommand(checkStaffEmailQuery, conn)
                cmd.Parameters.AddWithValue("@email", email)
                Dim staffEmailCount As Integer = CInt(cmd.ExecuteScalar())
                If staffEmailCount > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Duplicate Email Found in staff_accounts table: " & email)
                    Return "duplicate_email"
                End If
            End Using

            Return "valid"
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] CheckDuplicateCredentials Exception: " & ex.Message)
            MessageBox.Show("Error checking credentials: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "error"
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Update admin profile information including all personal details (ENHANCED)
    ''' </summary>
    Public Shared Function UpdateAdminProfile(adminID As String, firstName As String, lastName As String,
                                              email As String, contactNumber As String, Optional middleName As String = "",
                                              Optional suffix As String = "", Optional houseNoStreet As String = "",
                                              Optional barangay As String = "", Optional municipality As String = "",
                                              Optional provinceCity As String = "") As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Update personal details - includes all address fields
            Dim query As String = "UPDATE users SET first_name = @firstName, last_name = @lastName, " &
                                 "email = @email, contact_number = @contactNumber, " &
                                 "middle_name = @middleName, suffix = @suffix, " &
                                 "house_no_street = @houseNoStreet, barangay = @barangay, " &
                                 "municipality = @municipality, province_city = @provinceCity, " &
                                 "updated_at = NOW() WHERE user_id = @adminID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@firstName", firstName)
                cmd.Parameters.AddWithValue("@lastName", lastName)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrEmpty(contactNumber), DBNull.Value, contactNumber))
                cmd.Parameters.AddWithValue("@middleName", If(String.IsNullOrEmpty(middleName), DBNull.Value, middleName))
                cmd.Parameters.AddWithValue("@suffix", If(String.IsNullOrEmpty(suffix), DBNull.Value, suffix))
                cmd.Parameters.AddWithValue("@houseNoStreet", If(String.IsNullOrEmpty(houseNoStreet), DBNull.Value, houseNoStreet))
                cmd.Parameters.AddWithValue("@barangay", If(String.IsNullOrEmpty(barangay), DBNull.Value, barangay))
                cmd.Parameters.AddWithValue("@municipality", If(String.IsNullOrEmpty(municipality), DBNull.Value, municipality))
                cmd.Parameters.AddWithValue("@provinceCity", If(String.IsNullOrEmpty(provinceCity), DBNull.Value, provinceCity))
                cmd.Parameters.AddWithValue("@adminID", adminID)

                Dim result As Integer = cmd.ExecuteNonQuery()

                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Admin Profile Updated Successfully - ID: " & adminID)
                    Return True
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] Admin Profile Update Failed - No rows affected")
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdateAdminProfile Exception: " & ex.Message & vbCrLf & ex.StackTrace)
            MessageBox.Show("Error updating admin profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Update admin username (with duplicate check)
    ''' </summary>
    Public Shared Function UpdateAdminUsername(adminID As String, newUsername As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            ' Check for duplicates first
            Dim duplicateCheck As String = CheckDuplicateCredentials(newUsername, "", adminID)
            If duplicateCheck = "duplicate_username" Then
                MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE users SET username = @newUsername, updated_at = NOW() WHERE user_id = @adminID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@newUsername", newUsername)
                cmd.Parameters.AddWithValue("@adminID", adminID)

                Dim result As Integer = cmd.ExecuteNonQuery()
                Return result > 0
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdateAdminUsername Exception: " & ex.Message)
            MessageBox.Show("Error updating username: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ' =====================================================
    ' MODULE 2: PROPERTY MANAGEMENT (COMPLETE CRUD + FILTERING)
    ' =====================================================

    ''' <summary>
    ''' Get all properties with optional filtering (ENHANCED)
    ''' </summary>
    Public Shared Function GetAllProperties(Optional custodianID As Integer? = Nothing, Optional conditionStatus As String = "",
                                           Optional category As String = "", Optional departmentID As Integer? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            ' Build query with optional filters
            Dim query As String = "SELECT p.property_id, p.property_name, p.category, p.serial_number, " &
                                 "p.acquisition_date, p.acquisition_cost, p.condition_status, p.location, " &
                                 "p.status, p.depreciation_value, p.life_span, " &
                                 "CONCAT(u.first_name, ' ', u.last_name) AS custodian_name, " &
                                 "d.department_name " &
                                 "FROM properties p " &
                                 "LEFT JOIN users u ON p.custodian_id = u.user_id " &
                                 "LEFT JOIN departments d ON p.department_id = d.department_id " &
                                 "WHERE p.status != 'disposed'"

            ' Add filters
            If custodianID.HasValue Then
                query &= " AND p.custodian_id = @custodianID"
            End If
            If Not String.IsNullOrEmpty(conditionStatus) Then
                query &= " AND p.condition_status = @conditionStatus"
            End If
            If Not String.IsNullOrEmpty(category) Then
                query &= " AND p.category = @category"
            End If
            If departmentID.HasValue Then
                query &= " AND p.department_id = @departmentID"
            End If

            query &= " ORDER BY p.acquisition_date DESC"

            Using cmd As New MySqlCommand(query, conn)
                If custodianID.HasValue Then
                    cmd.Parameters.AddWithValue("@custodianID", custodianID.Value)
                End If
                If Not String.IsNullOrEmpty(conditionStatus) Then
                    cmd.Parameters.AddWithValue("@conditionStatus", conditionStatus)
                End If
                If Not String.IsNullOrEmpty(category) Then
                    cmd.Parameters.AddWithValue("@category", category)
                End If
                If departmentID.HasValue Then
                    cmd.Parameters.AddWithValue("@departmentID", departmentID.Value)
                End If

                cmd.CommandTimeout = 30
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    System.Diagnostics.Debug.WriteLine("[v0] GetAllProperties - Loaded " & dt.Rows.Count & " properties")
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllProperties Exception: " & ex.Message & vbCrLf & ex.StackTrace)
            MessageBox.Show("Error retrieving properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Check if serial number already exists
    ''' </summary>
    Public Shared Function CheckDuplicateSerialNumber(serialNumber As String, Optional excludePropertyID As Integer? = Nothing) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            If String.IsNullOrEmpty(serialNumber) Then Return False

            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "SELECT COUNT(*) FROM properties WHERE serial_number = @serialNumber"
            If excludePropertyID.HasValue Then
                query &= " AND property_id != @propertyID"
            End If

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@serialNumber", serialNumber)
                If excludePropertyID.HasValue Then
                    cmd.Parameters.AddWithValue("@propertyID", excludePropertyID.Value)
                End If

                Dim count As Integer = CInt(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] CheckDuplicateSerialNumber Exception: " & ex.Message)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function



    ''' <summary>
    ''' Update existing property (ENHANCED)
    ''' </summary>
    Public Shared Function UpdateProperty(propertyID As Integer, propertyName As String, category As String,
                                         description As String, serialNumber As String, conditionStatus As String,
                                         location As String, custodianID As Integer?, departmentID As Integer?,
                                         warrantyDetails As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            ' Validate serial number uniqueness (excluding current property)
            If Not String.IsNullOrEmpty(serialNumber) Then
                If CheckDuplicateSerialNumber(serialNumber, propertyID) Then
                    MessageBox.Show("Serial number already exists. Please use a different serial number.", "Duplicate Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE properties SET property_name = @propertyName, category = @category, " &
                                 "description = @description, serial_number = @serialNumber, condition_status = @conditionStatus, " &
                                 "location = @location, custodian_id = @custodianID, department_id = @departmentID, " &
                                 "warranty_details = @warrantyDetails, updated_at = NOW() " &
                                 "WHERE property_id = @propertyID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@propertyID", propertyID)
                cmd.Parameters.AddWithValue("@propertyName", propertyName)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@serialNumber", If(String.IsNullOrEmpty(serialNumber), DBNull.Value, serialNumber))
                cmd.Parameters.AddWithValue("@conditionStatus", conditionStatus)
                cmd.Parameters.AddWithValue("@location", location)
                cmd.Parameters.AddWithValue("@custodianID", If(custodianID.HasValue, custodianID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@departmentID", If(departmentID.HasValue, departmentID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@warrantyDetails", If(String.IsNullOrEmpty(warrantyDetails), DBNull.Value, warrantyDetails))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Property Updated Successfully - ID: " & propertyID)
                    MessageBox.Show("Property updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Else
                    MessageBox.Show("No changes were made. Property may not exist.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdateProperty Exception: " & ex.Message)
            MessageBox.Show("Error updating property: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Delete property (with validation)
    ''' </summary>
    Public Shared Function DeleteProperty(propertyID As Integer) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Check if property is currently borrowed/requested
            Dim checkBorrowedQuery As String = "SELECT COUNT(*) FROM property_requests WHERE property_id = @propertyID AND status IN ('pending', 'approved', 'released')"
            Using checkCmd As New MySqlCommand(checkBorrowedQuery, conn)
                checkCmd.Parameters.AddWithValue("@propertyID", propertyID)
                Dim borrowedCount As Integer = CInt(checkCmd.ExecuteScalar())
                If borrowedCount > 0 Then
                    MessageBox.Show("Cannot delete property. It is currently borrowed or has pending requests.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Delete property (soft delete by setting status to 'disposed')
            Dim query As String = "UPDATE properties SET status = 'disposed', disposal_date = CURDATE(), updated_at = NOW() WHERE property_id = @propertyID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@propertyID", propertyID)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Property Deleted (Disposed) - ID: " & propertyID)
                    MessageBox.Show("Property deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Else
                    MessageBox.Show("Property not found or already deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] DeleteProperty Exception: " & ex.Message)
            MessageBox.Show("Error deleting property: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Calculate and update depreciation value for a property
    ''' </summary>
    Public Shared Function CalculateDepreciation(propertyID As Integer) As Decimal
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return 0

            If Not SafeOpenConnection(conn) Then Return 0

            ' Get property details
            Dim getPropertyQuery As String = "SELECT acquisition_cost, acquisition_date, life_span FROM properties WHERE property_id = @propertyID"
            Dim acquisitionCost As Decimal = 0
            Dim acquisitionDate As Date = Date.MinValue
            Dim lifeSpan As Integer = 0

            Using cmd As New MySqlCommand(getPropertyQuery, conn)
                cmd.Parameters.AddWithValue("@propertyID", propertyID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        acquisitionCost = CDec(reader("acquisition_cost"))
                        acquisitionDate = CDate(reader("acquisition_date"))
                        lifeSpan = If(IsDBNull(reader("life_span")), 0, CInt(reader("life_span")))
                    End If
                End Using
            End Using

            ' Calculate depreciation using straight-line method
            If lifeSpan > 0 AndAlso acquisitionCost > 0 Then
                Dim yearsUsed As Integer = DateDiff(DateInterval.Year, acquisitionDate, Date.Now)
                If yearsUsed > 0 Then
                    Dim annualDepreciation As Decimal = acquisitionCost / lifeSpan
                    Dim totalDepreciation As Decimal = annualDepreciation * yearsUsed

                    ' Update depreciation value in database
                    Dim updateQuery As String = "UPDATE properties SET depreciation_value = @depreciationValue, updated_at = NOW() WHERE property_id = @propertyID"
                    Using updateCmd As New MySqlCommand(updateQuery, conn)
                        updateCmd.Parameters.AddWithValue("@depreciationValue", totalDepreciation)
                        updateCmd.Parameters.AddWithValue("@propertyID", propertyID)
                        updateCmd.ExecuteNonQuery()
                    End Using

                    Return totalDepreciation
                End If
            End If

            Return 0
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] CalculateDepreciation Exception: " & ex.Message)
            Return 0
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Assign custodian to property
    ''' </summary>
    Public Shared Function AssignCustodianToProperty(propertyID As Integer, custodianID As Integer) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE properties SET custodian_id = @custodianID, updated_at = NOW() WHERE property_id = @propertyID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@custodianID", custodianID)
                cmd.Parameters.AddWithValue("@propertyID", propertyID)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Custodian Assigned to Property - Property ID: " & propertyID & ", Custodian ID: " & custodianID)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AssignCustodianToProperty Exception: " & ex.Message)
            MessageBox.Show("Error assigning custodian: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return False
    End Function

    ' =====================================================
    ' MODULE 3: SUPPLY MANAGEMENT (COMPLETE CRUD + FILTERING)
    ' =====================================================

    ''' <summary>
    ''' Get all supplies with optional filtering (ENHANCED)
    ''' </summary>
    Public Shared Function GetAllSupplies(Optional category As String = "", Optional status As String = "") As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            ' Reset connection string to force rebuild if there was a previous error
            If _connectionString IsNot Nothing AndAlso _connectionString.Contains("ReplicationManager") Then
                _connectionString = Nothing
            End If

            conn = GetConnection()
            If conn Is Nothing Then
                System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - Connection is null")
                MessageBox.Show("Failed to establish database connection. Please check your database configuration.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return dt
            End If

            If Not SafeOpenConnection(conn) Then
                System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - Failed to open connection")
                MessageBox.Show("Database connection failed. Please ensure MySQL is running and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return dt
            End If

            ' Build query with optional filters
            Dim query As String = "SELECT supply_id, supply_name, category, description, unit_of_measure, " &
                                 "quantity_in_stock, reorder_level, supplier_name, supplier_contact, unit_cost, " &
                                 "total_value, acquisition_date, expiration_date, location, status " &
                                 "FROM supplies WHERE 1=1"

            If Not String.IsNullOrEmpty(category) Then
                query &= " AND category = @category"
            End If
            If Not String.IsNullOrEmpty(status) Then
                query &= " AND status = @status"
            End If

            query &= " ORDER BY acquisition_date DESC"

            Using cmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrEmpty(category) Then
                    cmd.Parameters.AddWithValue("@category", category)
                End If
                If Not String.IsNullOrEmpty(status) Then
                    cmd.Parameters.AddWithValue("@status", status)
                End If

                cmd.CommandTimeout = 30
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - Loaded " & dt.Rows.Count & " supplies")
                End Using
            End Using
        Catch ex As TypeInitializationException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - TypeInit ReplicationManager error: " & ex.Message)
            MessageBox.Show("Database initialization error. Please restart the application.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As MySqlException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies - ReplicationManager error: " & ex.Message)
            MessageBox.Show("Database connection issue. Please try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies Exception: " & ex.Message & vbCrLf & ex.StackTrace)
            If ex.Message.Contains("ReplicationManager") Then
                MessageBox.Show("Database connection error. Please restart the application and ensure MySQL is running.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Error retrieving supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error closing connection in GetAllSupplies: " & ex.Message)
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Get low stock supplies (quantity <= reorder level) (NEW)
    ''' </summary>
    Public Shared Function GetLowStockSupplies() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT supply_id, supply_name, category, quantity_in_stock, reorder_level, " &
                                 "unit_cost, total_value, location, status " &
                                 "FROM supplies WHERE quantity_in_stock <= reorder_level AND status = 'active' " &
                                 "ORDER BY (quantity_in_stock - reorder_level) ASC"

            Using cmd As New MySqlCommand(query, conn)
                cmd.CommandTimeout = 30
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    System.Diagnostics.Debug.WriteLine("[v0] GetLowStockSupplies - Found " & dt.Rows.Count & " low stock items")
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetLowStockSupplies Exception: " & ex.Message)
            MessageBox.Show("Error retrieving low stock supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Update supply information with automatic total value calculation (ENHANCED)
    ''' </summary>
    Public Shared Function UpdateSupply(supplyID As Integer, supplyName As String, category As String,
                                       stock As Integer, unitCost As Decimal, status As String, location As String,
                                       Optional description As String = "", Optional reorderLevel As Integer = 0,
                                       Optional supplierName As String = "", Optional supplierContact As String = "") As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Calculate total value automatically
            Dim totalValue As Decimal = stock * unitCost

            Dim query As String = "UPDATE supplies SET supply_name = @supplyName, category = @category, " &
                                 "quantity_in_stock = @stock, unit_cost = @unitCost, total_value = @totalValue, " &
                                 "status = @status, location = @location, description = @description, " &
                                 "reorder_level = @reorderLevel, supplier_name = @supplierName, " &
                                 "supplier_contact = @supplierContact, updated_at = NOW() " &
                                 "WHERE supply_id = @supplyID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@supplyID", supplyID)
                cmd.Parameters.AddWithValue("@supplyName", supplyName)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@stock", stock)
                cmd.Parameters.AddWithValue("@unitCost", unitCost)
                cmd.Parameters.AddWithValue("@totalValue", totalValue)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@location", location)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@reorderLevel", reorderLevel)
                cmd.Parameters.AddWithValue("@supplierName", If(String.IsNullOrEmpty(supplierName), DBNull.Value, supplierName))
                cmd.Parameters.AddWithValue("@supplierContact", If(String.IsNullOrEmpty(supplierContact), DBNull.Value, supplierContact))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Supply Updated Successfully - ID: " & supplyID)
                    MessageBox.Show("Supply updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Else
                    MessageBox.Show("No changes were made. Supply may not exist.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdateSupply Exception: " & ex.Message)
            MessageBox.Show("Error updating supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Delete supply (ENHANCED)
    ''' </summary>
    Public Shared Function DeleteSupply(supplyID As Integer) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Check if supply is currently requested/borrowed
            Dim checkRequestedQuery As String = "SELECT COUNT(*) FROM property_requests WHERE supply_id = @supplyID AND status IN ('pending', 'approved', 'released')"
            Using checkCmd As New MySqlCommand(checkRequestedQuery, conn)
                checkCmd.Parameters.AddWithValue("@supplyID", supplyID)
                Dim requestedCount As Integer = CInt(checkCmd.ExecuteScalar())
                If requestedCount > 0 Then
                    MessageBox.Show("Cannot delete supply. It has pending or active requests.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Delete supply (soft delete by setting status to 'used')
            Dim query As String = "UPDATE supplies SET status = 'used', updated_at = NOW() WHERE supply_id = @supplyID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@supplyID", supplyID)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Supply Deleted - ID: " & supplyID)
                    MessageBox.Show("Supply deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Else
                    MessageBox.Show("Supply not found or already deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] DeleteSupply Exception: " & ex.Message)
            MessageBox.Show("Error deleting supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ' =====================================================
    ' MODULE 4: DEPARTMENT MANAGEMENT (COMPLETE CRUD + VALIDATION)
    ' =====================================================

    ''' <summary>
    ''' Get all departments with employee and property counts (ENHANCED)
    ''' </summary>
    Public Shared Function GetAllDepartments() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT d.department_id, d.department_name, d.head_of_department, " &
                                 "d.contact_number, d.email, d.location, d.department_code, " &
                                 "d.no_of_employees, d.budget_allocation, d.status, " &
                                 "COUNT(DISTINCT sa.staff_id) AS actual_employee_count, " &
                                 "COUNT(DISTINCT p.property_id) AS property_count " &
                                 "FROM departments d " &
                                 "LEFT JOIN staff_accounts sa ON d.department_id = sa.department_id AND sa.status = 'active' " &
                                 "LEFT JOIN properties p ON d.department_id = p.department_id AND p.status = 'active' " &
                                 "GROUP BY d.department_id, d.department_name, d.head_of_department, " &
                                 "d.contact_number, d.email, d.location, d.department_code, " &
                                 "d.no_of_employees, d.budget_allocation, d.status " &
                                 "ORDER BY d.department_name"

            Using cmd As New MySqlCommand(query, conn)
                cmd.CommandTimeout = 30
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    System.Diagnostics.Debug.WriteLine("[v0] GetAllDepartments - Loaded " & dt.Rows.Count & " departments")
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllDepartments Exception: " & ex.Message)
            MessageBox.Show("Error retrieving departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Add new department (ENHANCED)
    ''' </summary>
    Public Shared Function AddDepartment(departmentName As String, headOfDepartment As String, location As String,
                                        departmentCode As String, Optional contactNumber As String = "",
                                        Optional email As String = "", Optional noOfEmployees As Integer = 0,
                                        Optional budgetAllocation As Decimal = 0) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Check for duplicate department name
            Dim checkNameQuery As String = "SELECT COUNT(*) FROM departments WHERE LOWER(department_name) = LOWER(@departmentName)"
            Using checkCmd As New MySqlCommand(checkNameQuery, conn)
                checkCmd.Parameters.AddWithValue("@departmentName", departmentName)
                Dim nameCount As Integer = CInt(checkCmd.ExecuteScalar())
                If nameCount > 0 Then
                    MessageBox.Show("Department name already exists. Please use a different name.", "Duplicate Department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Check for duplicate department code
            Dim checkCodeQuery As String = "SELECT COUNT(*) FROM departments WHERE LOWER(department_code) = LOWER(@departmentCode)"
            Using checkCmd As New MySqlCommand(checkCodeQuery, conn)
                checkCmd.Parameters.AddWithValue("@departmentCode", departmentCode)
                Dim codeCount As Integer = CInt(checkCmd.ExecuteScalar())
                If codeCount > 0 Then
                    MessageBox.Show("Department code already exists. Please use a different code.", "Duplicate Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            Dim query As String = "INSERT INTO departments (department_name, head_of_department, location, department_code, " &
                                 "contact_number, email, no_of_employees, budget_allocation, status) " &
                                 "VALUES (@departmentName, @headOfDepartment, @location, @departmentCode, " &
                                 "@contactNumber, @email, @noOfEmployees, @budgetAllocation, 'active')"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@departmentName", departmentName)
                cmd.Parameters.AddWithValue("@headOfDepartment", headOfDepartment)
                cmd.Parameters.AddWithValue("@location", location)
                cmd.Parameters.AddWithValue("@departmentCode", departmentCode)
                cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrEmpty(contactNumber), DBNull.Value, contactNumber))
                cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(email), DBNull.Value, email))
                cmd.Parameters.AddWithValue("@noOfEmployees", noOfEmployees)
                cmd.Parameters.AddWithValue("@budgetAllocation", budgetAllocation)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Department Added Successfully: " & departmentName)
                    MessageBox.Show("Department added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            End Using
        Catch ex As MySqlException
            System.Diagnostics.Debug.WriteLine("[v0] AddDepartment MySQL Error: " & ex.Message)
            MessageBox.Show("Database error adding department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddDepartment Exception: " & ex.Message)
            MessageBox.Show("Error adding department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Update department information (ENHANCED)
    ''' </summary>
    Public Shared Function UpdateDepartment(departmentID As Integer, departmentName As String, headOfDepartment As String,
                                           location As String, departmentCode As String, Optional contactNumber As String = "",
                                           Optional email As String = "", Optional noOfEmployees As Integer = 0,
                                           Optional budgetAllocation As Decimal = 0) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Check for duplicate department name (excluding current department)
            Dim checkNameQuery As String = "SELECT COUNT(*) FROM departments WHERE LOWER(department_name) = LOWER(@departmentName) AND department_id != @departmentID"
            Using checkCmd As New MySqlCommand(checkNameQuery, conn)
                checkCmd.Parameters.AddWithValue("@departmentName", departmentName)
                checkCmd.Parameters.AddWithValue("@departmentID", departmentID)
                Dim nameCount As Integer = CInt(checkCmd.ExecuteScalar())
                If nameCount > 0 Then
                    MessageBox.Show("Department name already exists. Please use a different name.", "Duplicate Department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Check for duplicate department code (excluding current department)
            Dim checkCodeQuery As String = "SELECT COUNT(*) FROM departments WHERE LOWER(department_code) = LOWER(@departmentCode) AND department_id != @departmentID"
            Using checkCmd As New MySqlCommand(checkCodeQuery, conn)
                checkCmd.Parameters.AddWithValue("@departmentCode", departmentCode)
                checkCmd.Parameters.AddWithValue("@departmentID", departmentID)
                Dim codeCount As Integer = CInt(checkCmd.ExecuteScalar())
                If codeCount > 0 Then
                    MessageBox.Show("Department code already exists. Please use a different code.", "Duplicate Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            Dim query As String = "UPDATE departments SET department_name = @departmentName, head_of_department = @headOfDepartment, " &
                                 "location = @location, department_code = @departmentCode, contact_number = @contactNumber, " &
                                 "email = @email, no_of_employees = @noOfEmployees, budget_allocation = @budgetAllocation, " &
                                 "updated_at = NOW() WHERE department_id = @departmentID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@departmentID", departmentID)
                cmd.Parameters.AddWithValue("@departmentName", departmentName)
                cmd.Parameters.AddWithValue("@headOfDepartment", headOfDepartment)
                cmd.Parameters.AddWithValue("@location", location)
                cmd.Parameters.AddWithValue("@departmentCode", departmentCode)
                cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrEmpty(contactNumber), DBNull.Value, contactNumber))
                cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(email), DBNull.Value, email))
                cmd.Parameters.AddWithValue("@noOfEmployees", noOfEmployees)
                cmd.Parameters.AddWithValue("@budgetAllocation", budgetAllocation)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Department Updated Successfully - ID: " & departmentID)
                    MessageBox.Show("Department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Else
                    MessageBox.Show("No changes were made. Department may not exist.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdateDepartment Exception: " & ex.Message)
            MessageBox.Show("Error updating department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Delete department only if no properties are linked to it (ENHANCED)
    ''' </summary>
    Public Shared Function DeleteDepartment(departmentID As Integer) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Check if department has linked properties
            Dim checkPropertiesQuery As String = "SELECT COUNT(*) FROM properties WHERE department_id = @departmentID AND status != 'disposed'"
            Using checkCmd As New MySqlCommand(checkPropertiesQuery, conn)
                checkCmd.Parameters.AddWithValue("@departmentID", departmentID)
                Dim propertyCount As Integer = CInt(checkCmd.ExecuteScalar())
                If propertyCount > 0 Then
                    MessageBox.Show("Cannot delete department. It has " & propertyCount & " property/properties assigned to it. Please reassign or dispose properties first.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Check if department has staff members
            Dim checkStaffQuery As String = "SELECT COUNT(*) FROM staff_accounts WHERE department_id = @departmentID AND status = 'active'"
            Using checkCmd As New MySqlCommand(checkStaffQuery, conn)
                checkCmd.Parameters.AddWithValue("@departmentID", departmentID)
                Dim staffCount As Integer = CInt(checkCmd.ExecuteScalar())
                If staffCount > 0 Then
                    MessageBox.Show("Cannot delete department. It has " & staffCount & " active staff member(s). Please reassign staff first.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Delete department (soft delete by setting status to 'inactive')
            Dim query As String = "UPDATE departments SET status = 'inactive', updated_at = NOW() WHERE department_id = @departmentID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@departmentID", departmentID)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Department Deleted (Inactivated) - ID: " & departmentID)
                    MessageBox.Show("Department deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Else
                    MessageBox.Show("Department not found or already deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] DeleteDepartment Exception: " & ex.Message)
            MessageBox.Show("Error deleting department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Get department statistics (employee count and property count)
    ''' </summary>
    Public Shared Function GetDepartmentStats(departmentID As Integer) As Dictionary(Of String, Integer)
        Dim stats As New Dictionary(Of String, Integer)
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then
                stats("employee_count") = 0
                stats("property_count") = 0
                Return stats
            End If

            If Not SafeOpenConnection(conn) Then
                stats("employee_count") = 0
                stats("property_count") = 0
                Return stats
            End If

            ' Get employee count
            Dim employeeQuery As String = "SELECT COUNT(*) FROM staff_accounts WHERE department_id = @departmentID AND status = 'active'"
            Using cmd As New MySqlCommand(employeeQuery, conn)
                cmd.Parameters.AddWithValue("@departmentID", departmentID)
                stats("employee_count") = CInt(cmd.ExecuteScalar())
            End Using

            ' Get property count
            Dim propertyQuery As String = "SELECT COUNT(*) FROM properties WHERE department_id = @departmentID AND status = 'active'"
            Using cmd As New MySqlCommand(propertyQuery, conn)
                cmd.Parameters.AddWithValue("@departmentID", departmentID)
                stats("property_count") = CInt(cmd.ExecuteScalar())
            End Using

            System.Diagnostics.Debug.WriteLine("[v0] Department Stats - ID: " & departmentID & ", Employees: " & stats("employee_count") & ", Properties: " & stats("property_count"))
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetDepartmentStats Exception: " & ex.Message)
            stats("employee_count") = 0
            stats("property_count") = 0
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return stats
    End Function

End Class
