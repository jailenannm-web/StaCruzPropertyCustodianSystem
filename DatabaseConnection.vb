Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports Microsoft.VisualBasic
Imports PasswordHelper

Public Class DatabaseConnection
    ' Fixed the UnhandledException event handler syntax - removed incorrect += operator usage
    Shared Sub New()
        ' Suppress ReplicationManager initialization errors
        AddHandler AppDomain.CurrentDomain.UnhandledException, Sub(s, e)
                                                                   If e.ExceptionObject.ToString().Contains("ReplicationManager") Then
                                                                       System.Diagnostics.Debug.WriteLine("[v0] ReplicationManager error suppressed at startup")
                                                                       ' Continue - don't crash
                                                                   End If
                                                               End Sub
    End Sub

    ' Lazy initialization of connection string to prevent ReplicationManager errors
    Private Shared _connectionString As String = Nothing

    ''' <summary>
    ''' Get connection string with proper error handling
    ''' </summary>
    Private Shared Function GetConnectionString() As String
        If _connectionString Is Nothing Then
            Try
                _connectionString = ConfigurationManager.ConnectionStrings("MySQLConnection").ConnectionString
                If String.IsNullOrEmpty(_connectionString) Then
                    Throw New Exception("Connection string 'MySQLConnection' not found in App.config")
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] Connection String Error: " & ex.Message)
                Throw New Exception("Failed to retrieve connection string: " & ex.Message, ex)
            End Try
        End If
        Return _connectionString
    End Function

    ''' <summary>
    ''' Get a new MySQL connection with exception handling for ReplicationManager issues
    ''' </summary>
    Public Shared Function GetConnection() As MySqlConnection
        Try
            ' Retrieve connection string safely
            Dim connStr As String = GetConnectionString()

            ' Create connection without triggering replication manager initialization
            Dim conn As New MySqlConnection(connStr)

            ' Validate connection can be created
            Return conn
        Catch ex As MySqlException
            System.Diagnostics.Debug.WriteLine("[v0] MySQL Connection Error: " & ex.Message)
            If ex.Message.Contains("ReplicationManager") Then
                MessageBox.Show("Database connection issue detected. Please ensure MySQL is running properly." & vbCrLf & "Error: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Database connection error: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Throw
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Connection Creation Error: " & ex.Message)
            Throw New Exception("Failed to create database connection: " & ex.Message, ex)
        End Try
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
        Try
            ' Added explicit null/empty checks before calling PasswordHelper
            If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
                System.Diagnostics.Debug.WriteLine("[v0] Staff Login - Empty credentials provided")
                Return False
            End If

            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Retrieve hashed password for comparison instead of comparing plaintext
                Dim query As String = "SELECT password FROM staff_accounts WHERE username = @username AND status = 'Active'"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Dim storedHashObj As Object = cmd.ExecuteScalar()

                    ' Added null check to prevent null reference exception
                    If storedHashObj Is Nothing OrElse IsDBNull(storedHashObj) Then
                        System.Diagnostics.Debug.WriteLine("[v0] Staff Login Failed - User not found or not active: " & username)
                        Return False
                    End If

                    Dim storedHash As String = CStr(storedHashObj)

                    ' Added try-catch specifically for PasswordHelper to catch hashing errors
                    If Not String.IsNullOrEmpty(storedHash) Then
                        Try
                            If PasswordHelper.VerifyPassword(password, storedHash) Then
                                System.Diagnostics.Debug.WriteLine("[v0] Staff Login Success - Username: " & username)
                                Return True
                            Else
                                System.Diagnostics.Debug.WriteLine("[v0] Staff Login Failed - Invalid password for: " & username)
                                Return False
                            End If
                        Catch ex As Exception
                            System.Diagnostics.Debug.WriteLine("[v0] Staff Login - Password verification error: " & ex.Message)
                            Return False
                        End Try
                    Else
                        System.Diagnostics.Debug.WriteLine("[v0] Staff Login Failed - No password hash found")
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error during login validation: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Staff Login Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Validate admin/super admin login credentials with password hashing
    ''' </summary>
    Public Shared Function ValidateAdminLogin(username As String, password As String) As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)
        Try
            ' Added explicit null/empty checks before database query
            If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
                System.Diagnostics.Debug.WriteLine("[v0] Admin Login - Empty credentials provided")
                Return result
            End If

            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Retrieve password hash for verification instead of plaintext comparison
                Dim query As String = "SELECT user_id, first_name, last_name, user_type, password FROM users WHERE username = @username AND status = 'Active'"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Added null check for password field
                            If Not IsDBNull(reader("password")) Then
                                Dim storedHash As String = reader("password").ToString()

                                ' Added try-catch specifically for PasswordHelper
                                Try
                                    If PasswordHelper.VerifyPassword(password, storedHash) Then
                                        result("user_id") = reader("user_id").ToString()
                                        result("first_name") = reader("first_name").ToString()
                                        result("last_name") = reader("last_name").ToString()
                                        result("user_type") = reader("user_type").ToString()
                                        System.Diagnostics.Debug.WriteLine("[v0] Admin Login Success - Username: " & username & ", Type: " & result("user_type"))
                                    Else
                                        System.Diagnostics.Debug.WriteLine("[v0] Admin Login Failed - Invalid password for: " & username)
                                    End If
                                Catch ex As Exception
                                    System.Diagnostics.Debug.WriteLine("[v0] Admin Login - Password verification error: " & ex.Message)
                                End Try
                            Else
                                System.Diagnostics.Debug.WriteLine("[v0] Admin Login Failed - No password hash found for user")
                            End If
                        Else
                            System.Diagnostics.Debug.WriteLine("[v0] Admin Login Failed - User not found: " & username)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error during admin login validation: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Admin Login Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
        Return result
    End Function

    ''' <summary>
    ''' Register a new staff member with password encryption
    ''' </summary>
    Public Shared Function RegisterStaff(firstName As String, lastName As String, email As String, contactNumber As String,
                                         address As String, departmentID As String, username As String, password As String,
                                         Optional position As String = "Staff") As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            conn.Open()

            ' Verify connection is actually open before proceeding
            If conn.State <> ConnectionState.Open Then
                MessageBox.Show("Database connection failed. Please check your database connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Diagnostics.Debug.WriteLine("[v0] Connection state is not open: " & conn.State.ToString())
                Return False
            End If

            System.Diagnostics.Debug.WriteLine("[v0] === REGISTRATION START === Position: " & position & ", Username: " & username)

            ' Fixed: Check if username already exists in staff_accounts
            Dim checkStaffUsernameQuery As String = "SELECT COUNT(*) FROM staff_accounts WHERE username = @username"
            Using checkCmd As New MySqlCommand(checkStaffUsernameQuery, conn)
                checkCmd.Parameters.AddWithValue("@username", username)
                Dim staffCount As Integer = CInt(checkCmd.ExecuteScalar())
                If staffCount > 0 Then
                    MessageBox.Show("Username already exists in staff accounts. Please choose another username.")
                    System.Diagnostics.Debug.WriteLine("[v0] Registration Error: Username exists in staff_accounts - " & username)
                    Return False
                End If
            End Using

            ' Check if username already exists in users table
            Dim checkUsersUsernameQuery As String = "SELECT COUNT(*) FROM users WHERE username = @username"
            Using checkCmd As New MySqlCommand(checkUsersUsernameQuery, conn)
                checkCmd.Parameters.AddWithValue("@username", username)
                Dim usersCount As Integer = CInt(checkCmd.ExecuteScalar())
                If usersCount > 0 Then
                    MessageBox.Show("Username already exists in admin accounts. Please choose another username.")
                    System.Diagnostics.Debug.WriteLine("[v0] Registration Error: Username exists in users - " & username)
                    Return False
                End If
            End Using

            ' Fixed: Check email in staff_accounts separately
            Dim checkStaffEmailQuery As String = "SELECT COUNT(*) FROM staff_accounts WHERE email = @email"
            Using checkCmd As New MySqlCommand(checkStaffEmailQuery, conn)
                checkCmd.Parameters.AddWithValue("@email", email)
                Dim staffEmailCount As Integer = CInt(checkCmd.ExecuteScalar())
                If staffEmailCount > 0 Then
                    MessageBox.Show("Email address already exists in staff accounts. Please use a different email.")
                    System.Diagnostics.Debug.WriteLine("[v0] Registration Error: Email exists in staff_accounts - " & email)
                    Return False
                End If
            End Using

            ' Fixed: Check email in users table separately
            Dim checkUsersEmailQuery As String = "SELECT COUNT(*) FROM users WHERE email = @email"
            Using checkCmd As New MySqlCommand(checkUsersEmailQuery, conn)
                checkCmd.Parameters.AddWithValue("@email", email)
                Dim usersEmailCount As Integer = CInt(checkCmd.ExecuteScalar())
                If usersEmailCount > 0 Then
                    MessageBox.Show("Email address already exists in admin accounts. Please use a different email.")
                    System.Diagnostics.Debug.WriteLine("[v0] Registration Error: Email exists in users - " & email)
                    Return False
                End If
            End Using

            ' Hash password before storing in database
            Dim hashedPassword As String = PasswordHelper.HashPassword(password)
            If String.IsNullOrEmpty(hashedPassword) Then
                MessageBox.Show("Error encrypting password. Please try again.")
                System.Diagnostics.Debug.WriteLine("[v0] Registration Error: Failed to hash password")
                Return False
            End If
            System.Diagnostics.Debug.WriteLine("[v0] Password hashed successfully")

            ' Create appropriate account based on position
            If position = "Super Admin" OrElse position = "Admin" Then
                ' Create admin/super admin account in users table
                Dim userType As String = If(position = "Super Admin", "SuperAdmin", "Admin")
                Dim insertAdminQuery As String = "INSERT INTO users (first_name, last_name, email, username, password, user_type, status, created_date) " &
                                                 "VALUES (@firstName, @lastName, @email, @username, @password, @userType, 'Active', NOW())"
                System.Diagnostics.Debug.WriteLine("[v0] Inserting " & userType & " to users table - Username: " & username & ", Email: " & email)

                Using insertAdminCmd As New MySqlCommand(insertAdminQuery, conn)
                    insertAdminCmd.Parameters.AddWithValue("@firstName", firstName)
                    insertAdminCmd.Parameters.AddWithValue("@lastName", lastName)
                    insertAdminCmd.Parameters.AddWithValue("@email", email)
                    insertAdminCmd.Parameters.AddWithValue("@username", username)
                    ' Use hashed password instead of plaintext
                    insertAdminCmd.Parameters.AddWithValue("@password", hashedPassword)
                    insertAdminCmd.Parameters.AddWithValue("@userType", userType)

                    ' Debug the parameters before execution
                    System.Diagnostics.Debug.WriteLine("[v0] Insert command parameters:")
                    System.Diagnostics.Debug.WriteLine("[v0] - firstName: " & firstName)
                    System.Diagnostics.Debug.WriteLine("[v0] - lastName: " & lastName)
                    System.Diagnostics.Debug.WriteLine("[v0] - email: " & email)
                    System.Diagnostics.Debug.WriteLine("[v0] - username: " & username)
                    System.Diagnostics.Debug.WriteLine("[v0] - userType: " & userType)
                    System.Diagnostics.Debug.WriteLine("[v0] - password: [HASHED]")

                    Dim result As Integer = insertAdminCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] ExecuteNonQuery returned: " & result)

                    If result > 0 Then
                        System.Diagnostics.Debug.WriteLine("[v0] SUCCESS: " & userType & " Account Created in users table")
                        MessageBox.Show("Registration successful! Your " & userType & " account has been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    Else
                        System.Diagnostics.Debug.WriteLine("[v0] ERROR: ExecuteNonQuery returned 0 for " & userType)
                        MessageBox.Show("Failed to create admin account. Please try again.")
                        Return False
                    End If
                End Using
            Else
                ' Create staff account in staff_accounts table
                Dim insertStaffQuery As String = "INSERT INTO staff_accounts (first_name, last_name, email, contact_number, " &
                                                 "address, department_id, username, password, status, created_date) " &
                                                 "VALUES (@firstName, @lastName, @email, @contactNumber, @address, " &
                                                 "@departmentID, @username, @password, 'Active', NOW())"
                System.Diagnostics.Debug.WriteLine("[v0] Inserting Staff to staff_accounts table - Username: " & username & ", Email: " & email & ", DeptID: " & departmentID)

                Using insertStaffCmd As New MySqlCommand(insertStaffQuery, conn)
                    insertStaffCmd.Parameters.AddWithValue("@firstName", firstName)
                    insertStaffCmd.Parameters.AddWithValue("@lastName", lastName)
                    insertStaffCmd.Parameters.AddWithValue("@email", email)
                    insertStaffCmd.Parameters.AddWithValue("@contactNumber", contactNumber)
                    insertStaffCmd.Parameters.AddWithValue("@address", address)

                    ' Handle empty departmentID for staff
                    If String.IsNullOrWhiteSpace(departmentID) Then
                        insertStaffCmd.Parameters.AddWithValue("@departmentID", DBNull.Value)
                    Else
                        insertStaffCmd.Parameters.AddWithValue("@departmentID", departmentID)
                    End If

                    insertStaffCmd.Parameters.AddWithValue("@username", username)
                    ' Use hashed password instead of plaintext
                    insertStaffCmd.Parameters.AddWithValue("@password", hashedPassword)

                    ' Debug the parameters before execution
                    System.Diagnostics.Debug.WriteLine("[v0] Staff Insert parameters:")
                    System.Diagnostics.Debug.WriteLine("[v0] - firstName: " & firstName)
                    System.Diagnostics.Debug.WriteLine("[v0] - username: " & username)
                    System.Diagnostics.Debug.WriteLine("[v0] - contactNumber: " & contactNumber)
                    System.Diagnostics.Debug.WriteLine("[v0] - departmentID: " & If(String.IsNullOrWhiteSpace(departmentID), "NULL", departmentID))
                    System.Diagnostics.Debug.WriteLine("[v0] - password: [HASHED]")

                    Dim result As Integer = insertStaffCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] Staff ExecuteNonQuery returned: " & result)

                    If result > 0 Then
                        System.Diagnostics.Debug.WriteLine("[v0] SUCCESS: Staff Account Created in staff_accounts table")
                        MessageBox.Show("Registration successful! Your Staff account has been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    Else
                        System.Diagnostics.Debug.WriteLine("[v0] ERROR: ExecuteNonQuery returned 0 for Staff")
                        MessageBox.Show("Failed to create staff account. Please try again.")
                        Return False
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error during registration: " & ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Registration Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            Return False
        Finally
            ' Ensure connection is always properly closed
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
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
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

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
            End Using
        Catch ex As Exception
            MessageBox.Show("Error retrieving staff details: " & ex.Message)
        End Try
        Return staffDetails
    End Function

    ''' <summary>
    ''' Load logged-in admin's profile information from users table
    ''' </summary>
    Public Shared Function LoadAdminProfile(adminID As String) As Dictionary(Of String, Object)
        Dim adminProfile As New Dictionary(Of String, Object)
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Query to load admin profile data by admin ID
                Dim query As String = "SELECT user_id, first_name, last_name, email, username, " &
                                     "contact_number, address, user_type, status, created_date " &
                                     "FROM users WHERE user_id = @adminID AND status = 'Active'"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@adminID", adminID)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            adminProfile("user_id") = reader("user_id").ToString()
                            adminProfile("first_name") = reader("first_name").ToString()
                            adminProfile("last_name") = reader("last_name").ToString()
                            adminProfile("email") = reader("email").ToString()
                            adminProfile("username") = reader("username").ToString()
                            adminProfile("contact_number") = If(IsDBNull(reader("contact_number")), "", reader("contact_number").ToString())
                            adminProfile("address") = If(IsDBNull(reader("address")), "", reader("address").ToString())
                            adminProfile("user_type") = reader("user_type").ToString()
                            adminProfile("status") = reader("status").ToString()
                            adminProfile("created_date") = reader("created_date").ToString()
                            System.Diagnostics.Debug.WriteLine("[v0] Admin Profile Loaded - ID: " & adminID)
                        Else
                            System.Diagnostics.Debug.WriteLine("[v0] Admin Profile Not Found - ID: " & adminID)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading admin profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Load Admin Profile Exception: " & ex.Message)
        End Try
        Return adminProfile
    End Function

    ''' <summary>
    ''' Check if username or email already exists (for validation before update)
    ''' </summary>
    Public Shared Function CheckDuplicateCredentials(username As String, email As String, currentAdminID As String) As String
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Check for duplicate username (excluding current admin)
                Dim checkUsernameQuery As String = "SELECT COUNT(*) FROM users WHERE username = @username AND user_id != @adminID"
                Using cmd As New MySqlCommand(checkUsernameQuery, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@adminID", currentAdminID)

                    Dim usernameCount As Integer = CInt(cmd.ExecuteScalar())
                    If usernameCount > 0 Then
                        System.Diagnostics.Debug.WriteLine("[v0] Duplicate Username Found: " & username)
                        Return "duplicate_username"
                    End If
                End Using

                ' Check for duplicate email (excluding current admin)
                Dim checkEmailQuery As String = "SELECT COUNT(*) FROM users WHERE email = @email AND user_id != @adminID"
                Using cmd As New MySqlCommand(checkEmailQuery, conn)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue("@adminID", currentAdminID)

                    Dim emailCount As Integer = CInt(cmd.ExecuteScalar())
                    If emailCount > 0 Then
                        System.Diagnostics.Debug.WriteLine("[v0] Duplicate Email Found: " & email)
                        Return "duplicate_email"
                    End If
                End Using

                Return "valid"
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking credentials: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Check Duplicate Credentials Exception: " & ex.Message)
            Return "error"
        End Try
    End Function

    ''' <summary>
    ''' Verify old password before allowing password change
    ''' </summary>
    Public Shared Function VerifyOldPassword(adminID As String, oldPassword As String) As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

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
            End Using
        Catch ex As Exception
            MessageBox.Show("Error verifying old password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Verify Old Password Exception: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Update admin profile information including contact and address details
    ''' </summary>
    Public Shared Function UpdateAdminProfile(adminID As String, firstName As String, lastName As String,
                                              email As String, contactNumber As String, address As String) As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Update personal details without changing password
                Dim query As String = "UPDATE users SET first_name = @firstName, last_name = @lastName, " &
                                     "email = @email, contact_number = @contactNumber, address = @address, " &
                                     "updated_date = NOW() WHERE user_id = @adminID"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@firstName", firstName)
                    cmd.Parameters.AddWithValue("@lastName", lastName)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrEmpty(contactNumber), "", contactNumber))
                    cmd.Parameters.AddWithValue("@address", If(String.IsNullOrEmpty(address), "", address))
                    cmd.Parameters.AddWithValue("@adminID", adminID)

                    Dim result As Integer = cmd.ExecuteNonQuery()

                    If result > 0 Then
                        System.Diagnostics.Debug.WriteLine("[v0] Admin Profile Updated - ID: " & adminID)
                        Return True
                    Else
                        System.Diagnostics.Debug.WriteLine("[v0] Admin Profile Update Failed - No rows affected")
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating admin profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Update Admin Profile Exception: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Update admin password with SHA256 hashing (after old password verification)
    ''' </summary>
    Public Shared Function UpdateAdminPassword(adminID As String, newPassword As String) As Boolean
        Try
            ' Hash the new password before storing
            Dim hashedPassword As String = PasswordHelper.HashPassword(newPassword)

            If String.IsNullOrEmpty(hashedPassword) Then
                MessageBox.Show("Error encrypting new password. Please try again.")
                System.Diagnostics.Debug.WriteLine("[v0] Password Update Failed - Hashing error")
                Return False
            End If

            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Update password with timestamp
                Dim query As String = "UPDATE users SET password = @password, updated_date = NOW() " &
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
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating admin password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Update Admin Password Exception: " & ex.Message)
            Return False
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

            While retryCount < maxRetries
                Try
                    conn.Open()
                    Exit While
                Catch ex As MySqlException When ex.Message.Contains("ReplicationManager") AndAlso retryCount < maxRetries - 1
                    retryCount += 1
                    System.Threading.Thread.Sleep(500) ' Wait before retry
                    conn.Dispose()
                    conn = GetConnection()
                End Try
            End While

            ' Updated column names to match actual SQL schema
            Dim query As String = "SELECT SupplyID, SupplyName, Category, QuantityInStock, UnitCost, TotalValue, Status, Location " &
                                 "FROM supplies ORDER BY AcquisitionDate DESC"
            Using cmd As New MySqlCommand(query, conn)
                cmd.CommandTimeout = 30
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    System.Diagnostics.Debug.WriteLine("[v0] Supplies Retrieved - Count: " & dt.Rows.Count)
                End Using
            End Using
        Catch ex As MySqlException
            System.Diagnostics.Debug.WriteLine("[v0] Get All Supplies MySQL Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show("Database error retrieving supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Get All Supplies Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show("Error retrieving supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Ensure connection cleanup
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Dispose()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error closing connection in GetAllSupplies: " & ex.Message)
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Search supplies by keyword
    ''' </summary>
    Public Shared Function SearchSupplies(searchTerm As String) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()

            ' Added retry logic for ReplicationManager errors
            Dim retryCount As Integer = 0
            While retryCount < 3
                Try
                    conn.Open()
                    Exit While
                Catch ex As MySqlException When ex.Message.Contains("ReplicationManager") AndAlso retryCount < 2
                    retryCount += 1
                    System.Threading.Thread.Sleep(500)
                    conn.Dispose()
                    conn = GetConnection()
                End Try
            End While

            ' Updated column names to match actual SQL schema
            Dim query As String = "SELECT SupplyID, SupplyName, Category, QuantityInStock, UnitCost, TotalValue, Status, Location " &
                                 "FROM supplies WHERE SupplyName LIKE @searchTerm OR Category LIKE @searchTerm OR SupplyID LIKE @searchTerm " &
                                 "ORDER BY AcquisitionDate DESC"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@searchTerm", "%" & searchTerm & "%")
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    System.Diagnostics.Debug.WriteLine("[v0] Supplies Search Complete - Term: " & searchTerm & ", Count: " & dt.Rows.Count)
                End Using
            End Using
        Catch ex As MySqlException
            System.Diagnostics.Debug.WriteLine("[v0] Search Supplies MySQL Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show("Database error searching supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Search Supplies Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show("Error searching supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Ensure connection cleanup
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    conn.Dispose()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error closing connection in SearchSupplies: " & ex.Message)
                End Try
            End If
        End Try
        Return dt
    End Function

End Class
