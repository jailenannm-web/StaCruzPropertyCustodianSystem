Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Configuration


Public Class DatabaseConnection
    ' Connection string retrieved dynamically from App.config
    Private Shared ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("MySQLConnection").ConnectionString


    ''' <summary>
    ''' Get a new MySQL connection
    ''' </summary>
    Public Shared Function GetConnection() As MySqlConnection
        Return New MySqlConnection(connectionString)
    End Function

    ''' <summary>
    ''' Test database connection
    ''' </summary>
    Public Shared Function TestConnection() As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                conn.Close()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Database connection failed: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Validate staff login credentials
    ''' </summary>
    Public Shared Function ValidateStaffLogin(username As String, password As String) As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Added debug logging to check if data is being retrieved
                Dim query As String = "SELECT COUNT(*) FROM staff_accounts WHERE username = @username AND password = @password AND status = 'Active'"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)

                    Dim count As Integer = CInt(cmd.ExecuteScalar())
                    System.Diagnostics.Debug.WriteLine("[v0] Staff Login Check - Username: " & username & ", Found: " & (count > 0))
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error during login validation: " & ex.Message)
            System.Diagnostics.Debug.WriteLine("[v0] Staff Login Error: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Validate admin/super admin login credentials
    ''' </summary>
    Public Shared Function ValidateAdminLogin(username As String, password As String) As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Query now retrieves user type for admin/superadmin
                Dim query As String = "SELECT user_id, first_name, last_name, user_type FROM users WHERE username = @username AND password = @password AND status = 'Active'"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            result("user_id") = reader("user_id").ToString()
                            result("first_name") = reader("first_name").ToString()
                            result("last_name") = reader("last_name").ToString()
                            result("user_type") = reader("user_type").ToString()
                            System.Diagnostics.Debug.WriteLine("[v0] Admin Login Success - Username: " & username & ", Type: " & result("user_type"))
                        Else
                            System.Diagnostics.Debug.WriteLine("[v0] Admin Login Failed - Invalid credentials for: " & username)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error during admin login validation: " & ex.Message)
            System.Diagnostics.Debug.WriteLine("[v0] Admin Login Error: " & ex.Message)
        End Try
        Return result
    End Function

    ''' <summary>
    ''' Register a new staff member with role-based account creation
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
                    insertAdminCmd.Parameters.AddWithValue("@password", password)
                    insertAdminCmd.Parameters.AddWithValue("@userType", userType)

                    ' Debug the parameters before execution
                    System.Diagnostics.Debug.WriteLine("[v0] Insert command parameters:")
                    System.Diagnostics.Debug.WriteLine("[v0] - firstName: " & firstName)
                    System.Diagnostics.Debug.WriteLine("[v0] - lastName: " & lastName)
                    System.Diagnostics.Debug.WriteLine("[v0] - email: " & email)
                    System.Diagnostics.Debug.WriteLine("[v0] - username: " & username)
                    System.Diagnostics.Debug.WriteLine("[v0] - userType: " & userType)

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
                    insertStaffCmd.Parameters.AddWithValue("@password", password)

                    ' Debug the parameters before execution
                    System.Diagnostics.Debug.WriteLine("[v0] Staff Insert parameters:")
                    System.Diagnostics.Debug.WriteLine("[v0] - firstName: " & firstName)
                    System.Diagnostics.Debug.WriteLine("[v0] - username: " & username)
                    System.Diagnostics.Debug.WriteLine("[v0] - contactNumber: " & contactNumber)
                    System.Diagnostics.Debug.WriteLine("[v0] - departmentID: " & If(String.IsNullOrWhiteSpace(departmentID), "NULL", departmentID))

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
End Class
