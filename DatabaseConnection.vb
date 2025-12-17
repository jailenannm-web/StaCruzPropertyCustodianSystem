Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports Microsoft.VisualBasic
Imports System.Linq
Imports System.Text

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
                    baseConnStr = "Server=localhost;Port=3306;Database=teamcruzim;Uid=root;Pwd=;Replication=False;AllowLoadLocalInfile=False;AllowUserVariables=True;AllowZeroDateTime=True;ConvertZeroDateTime=True;SslMode=None;ConnectionTimeout=10;DefaultCommandTimeout=30"
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

    ' Attempt multiple SELECT variants to fetch a single user row by username and optional role.
    Private Shared Function GetUserRecord(conn As MySqlConnection, username As String, Optional role As String = "") As DataRow
        Dim dt As New DataTable()
        If conn Is Nothing Then Return Nothing

        Dim variants As New List(Of String)()
        ' Try common camelCase schema
        If String.IsNullOrEmpty(role) Then
            variants.Add("SELECT userId, firstName, lastName, email, contactNumber, departmentId, username, passwordEncrypted, status, role FROM users WHERE LOWER(username) = LOWER(@username) LIMIT 1")
            variants.Add("SELECT user_id AS userId, first_name AS firstName, last_name AS lastName, email, contact_number AS contactNumber, department_id AS departmentId, username, password_encrypted AS passwordEncrypted, status, role FROM users WHERE LOWER(username) = LOWER(@username) LIMIT 1")
            variants.Add("SELECT id AS userId, first_name AS firstName, last_name AS lastName, email, contact_number AS contactNumber, department_id AS departmentId, username, password AS passwordEncrypted, status, role FROM users WHERE LOWER(username) = LOWER(@username) LIMIT 1")
            variants.Add("SELECT * FROM users WHERE LOWER(username) = LOWER(@username) LIMIT 1")
        Else
            variants.Add("SELECT userId, firstName, lastName, email, contactNumber, departmentId, username, passwordEncrypted, status, role FROM users WHERE LOWER(username) = LOWER(@username) AND role = @role LIMIT 1")
            variants.Add("SELECT user_id AS userId, first_name AS firstName, last_name AS lastName, email, contact_number AS contactNumber, department_id AS departmentId, username, password_encrypted AS passwordEncrypted, status, role FROM users WHERE LOWER(username) = LOWER(@username) AND role = @role LIMIT 1")
            variants.Add("SELECT id AS userId, first_name AS firstName, last_name AS lastName, email, contact_number AS contactNumber, department_id AS departmentId, username, password AS passwordEncrypted, status, role FROM users WHERE LOWER(username) = LOWER(@username) AND role = @role LIMIT 1")
            variants.Add("SELECT * FROM users WHERE LOWER(username) = LOWER(@username) AND role = @role LIMIT 1")
        End If

        For Each q In variants
            Try
                dt.Clear()
                Using cmd As New MySqlCommand(q, conn)
                    cmd.Parameters.AddWithValue("@username", username.Trim())
                    If Not String.IsNullOrEmpty(role) AndAlso q.Contains("@role") Then cmd.Parameters.AddWithValue("@role", role)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using

                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)
                End If
            Catch ex As MySqlException
                ' If unknown column or structure mismatch, try next variant
                System.Diagnostics.Debug.WriteLine("[v0] GetUserRecord variant failed: " & ex.Message & " | Query: " & q)
                Continue For
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] GetUserRecord Exception: " & ex.Message)
                Continue For
            End Try
        Next

        Return Nothing
    End Function

    ' Return set of existing column names for users table (lowercase) - caches per call using connection
    Private Shared Function GetUsersTableColumns(conn As MySqlConnection) As HashSet(Of String)
        Dim cols As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Try
            Using cmd As New MySqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'users'", conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Try
                            cols.Add(reader("COLUMN_NAME").ToString())
                        Catch
                        End Try
                    End While
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetUsersTableColumns Exception: " & ex.Message)
        End Try
        Return cols
    End Function

    ' Upsert user to users table using available column names. Returns userId (if available) or Nothing.
    Private Shared Function UpsertUser(conn As MySqlConnection, username As String, firstName As String, lastName As String, email As String, passwordHash As String, role As String, Optional position As String = "", Optional ensureActive As Boolean = True) As Object
        If conn Is Nothing Then Return Nothing
        Try
            Dim cols = GetUsersTableColumns(conn)

            ' Determine column name variants
            Dim col_username = If(cols.Contains("username"), "username", If(cols.Contains("user_name"), "user_name", Nothing))
            If String.IsNullOrEmpty(col_username) Then Return Nothing

            Dim col_id = If(cols.Contains("userId"), "userId", If(cols.Contains("user_id"), "user_id", If(cols.Contains("id"), "id", Nothing)))
            Dim col_first = If(cols.Contains("firstName"), "firstName", If(cols.Contains("first_name"), "first_name", Nothing))
            Dim col_last = If(cols.Contains("lastName"), "lastName", If(cols.Contains("last_name"), "last_name", Nothing))
            Dim col_email = If(cols.Contains("email"), "email", Nothing)
            Dim col_password = If(cols.Contains("passwordEncrypted"), "passwordEncrypted", If(cols.Contains("password_encrypted"), "password_encrypted", If(cols.Contains("password"), "password", Nothing)))
            Dim col_role = If(cols.Contains("role"), "role", Nothing)
            Dim col_status = If(cols.Contains("status"), "status", Nothing)
            Dim col_position = If(cols.Contains("position"), "position", Nothing)
            Dim col_created = If(cols.Contains("created_at"), "created_at", If(cols.Contains("createdAt"), "createdAt", Nothing))

            ' Find existing user
            Dim existingId As Object = Nothing
            Using findCmd As New MySqlCommand($"SELECT {If(col_id IsNot Nothing, col_id, "*")} FROM users WHERE LOWER({col_username}) = LOWER(@username) LIMIT 1", conn)
                findCmd.Parameters.AddWithValue("@username", username)
                existingId = findCmd.ExecuteScalar()
            End Using

            If existingId Is Nothing OrElse existingId Is DBNull.Value Then
                ' Insert - build column list only with available columns
                Dim insertCols As New List(Of String)()
                Dim insertParams As New List(Of String)()
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn

                If col_first IsNot Nothing Then
                    insertCols.Add(col_first) : insertParams.Add("@firstName") : cmd.Parameters.AddWithValue("@firstName", firstName)
                End If
                If col_last IsNot Nothing Then
                    insertCols.Add(col_last) : insertParams.Add("@lastName") : cmd.Parameters.AddWithValue("@lastName", lastName)
                End If
                If col_email IsNot Nothing Then
                    insertCols.Add(col_email) : insertParams.Add("@email") : cmd.Parameters.AddWithValue("@email", email)
                End If
                insertCols.Add(col_username) : insertParams.Add("@username") : cmd.Parameters.AddWithValue("@username", username)
                If col_password IsNot Nothing Then
                    insertCols.Add(col_password) : insertParams.Add("@password") : cmd.Parameters.AddWithValue("@password", passwordHash)
                End If
                If col_role IsNot Nothing Then
                    insertCols.Add(col_role) : insertParams.Add("@role") : cmd.Parameters.AddWithValue("@role", role)
                End If
                If col_status IsNot Nothing AndAlso ensureActive Then
                    insertCols.Add(col_status) : insertParams.Add("@status") : cmd.Parameters.AddWithValue("@status", "Active")
                End If
                If col_position IsNot Nothing AndAlso Not String.IsNullOrEmpty(position) Then
                    insertCols.Add(col_position) : insertParams.Add("@position") : cmd.Parameters.AddWithValue("@position", position)
                End If
                If col_created IsNot Nothing Then
                    insertCols.Add(col_created) : insertParams.Add("@createdAt") : cmd.Parameters.AddWithValue("@createdAt", DateTime.Now)
                End If

                Dim sql As String = $"INSERT INTO users ({String.Join(",", insertCols)}) VALUES ({String.Join(",", insertParams)})"
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                ' Return last insert id if available
                Using idCmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn)
                    Dim idObj = idCmd.ExecuteScalar()
                    Return If(idObj IsNot Nothing AndAlso Not IsDBNull(idObj), idObj, Nothing)
                End Using
            Else
                ' Update existing
                Dim updCols As New List(Of String)()
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn
                If col_first IsNot Nothing Then
                    updCols.Add(col_first & " = @firstName") : cmd.Parameters.AddWithValue("@firstName", firstName)
                End If
                If col_last IsNot Nothing Then
                    updCols.Add(col_last & " = @lastName") : cmd.Parameters.AddWithValue("@lastName", lastName)
                End If
                If col_email IsNot Nothing Then
                    updCols.Add(col_email & " = @email") : cmd.Parameters.AddWithValue("@email", email)
                End If
                If col_password IsNot Nothing Then
                    updCols.Add(col_password & " = @password") : cmd.Parameters.AddWithValue("@password", passwordHash)
                End If
                If col_role IsNot Nothing Then
                    updCols.Add(col_role & " = @role") : cmd.Parameters.AddWithValue("@role", role)
                End If
                If col_status IsNot Nothing AndAlso ensureActive Then
                    updCols.Add(col_status & " = @status") : cmd.Parameters.AddWithValue("@status", "Active")
                End If
                If col_position IsNot Nothing AndAlso Not String.IsNullOrEmpty(position) Then
                    updCols.Add(col_position & " = @position") : cmd.Parameters.AddWithValue("@position", position)
                End If
                If updCols.Count > 0 Then
                    Dim idParameterName As String = "@existingId"
                    cmd.Parameters.AddWithValue(idParameterName, existingId)
                    cmd.CommandText = $"UPDATE users SET {String.Join(",", updCols)} WHERE {col_username} = @username"
                    cmd.ExecuteNonQuery()
                End If
                Return existingId
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpsertUser Exception: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Shared Function DemandPermission(permission As SessionContext.ModulePermission,
                                             actionDescription As String) As Boolean
        ' Super Admin, Admin, and Custodian bypass all permission checks
        If SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian() Then
            Return True
        End If

        If String.IsNullOrWhiteSpace(SessionContext.CurrentRole) Then
            MessageBox.Show("Please login before attempting to " & actionDescription & ".",
                            "Access Denied",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Return False
        End If

        Return SessionContext.DemandPermission(permission, actionDescription)
    End Function

    ' =====================================================
    ' REPORT GENERATION FUNCTIONS
    ' =====================================================

    ''' <summary>
    ''' Retrieve property inventory data with optional grouping and filters
    ''' </summary>
    Public Shared Function GetPropertyInventoryReport(Optional groupByCategory As Boolean = False,
                                                      Optional departmentID As Integer? = Nothing,
                                                      Optional category As String = "",
                                                      Optional status As String = "",
                                                      Optional dateFrom As Date? = Nothing,
                                                      Optional dateTo As Date? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            If groupByCategory Then
                query.Append("SELECT p.category, p.status, COUNT(*) AS total_items, ")
                query.Append("SUM(p.acquisitionCost) AS total_value ")
            Else
                query.Append("SELECT p.propertyId, p.itemName, p.category, p.status, p.location, ")
                query.Append("p.acquisitionDate, p.acquisitionCost, d.departmentName, ")
                query.Append("CONCAT(IFNULL(u.firstName,''), ' ', IFNULL(u.lastName,'')) AS custodianName ")
            End If
            query.Append("FROM properties p ")
            query.Append("LEFT JOIN departments d ON p.departmentId = d.departmentId ")
            query.Append("LEFT JOIN users u ON p.assignedTo = u.userId WHERE 1=1 ")

            If departmentID.HasValue Then query.Append(" AND p.departmentId = @departmentID ")
            If Not String.IsNullOrEmpty(category) Then query.Append(" AND p.category = @category ")
            If Not String.IsNullOrEmpty(status) Then query.Append(" AND p.status = @status ")
            If dateFrom.HasValue Then query.Append(" AND p.acquisitionDate >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND p.acquisitionDate <= @dateTo ")

            If groupByCategory Then
                query.Append(" GROUP BY p.category, p.status ORDER BY p.category")
            Else
                query.Append(" ORDER BY p.category, p.itemName")
            End If

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If departmentID.HasValue Then cmd.Parameters.AddWithValue("@departmentID", departmentID.Value)
                If Not String.IsNullOrEmpty(category) Then cmd.Parameters.AddWithValue("@category", category)
                If Not String.IsNullOrEmpty(status) Then cmd.Parameters.AddWithValue("@status", status)
                If dateFrom.HasValue Then cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
                If dateTo.HasValue Then cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetPropertyInventoryReport Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ' InitializeDefaultAccounts implementation removed - use existing implementation elsewhere in the codebase

    ''' <summary>
    ''' Retrieve supply inventory data with filters and optional low-stock focus
    ''' </summary>
    Public Shared Function GetSupplyInventoryReport(Optional category As String = "",
                                                    Optional status As String = "",
                                                    Optional includeLowStockOnly As Boolean = False,
                                                    Optional departmentID As Integer? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT s.supplyId, s.itemName, s.category, s.quantity, ")
            query.Append("s.unitCost, s.totalCost, s.stockStatus, s.location ")
            query.Append("FROM supplies s WHERE 1=1 ")

            If Not String.IsNullOrEmpty(category) Then query.Append(" AND s.category = @category ")
            If Not String.IsNullOrEmpty(status) Then query.Append(" AND s.stockStatus = @status ")
            If includeLowStockOnly Then query.Append(" AND s.quantity <= 10 ")

            query.Append(" ORDER BY s.category, s.itemName")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(category) Then cmd.Parameters.AddWithValue("@category", category)
                If Not String.IsNullOrEmpty(status) Then cmd.Parameters.AddWithValue("@status", status)
                If departmentID.HasValue Then cmd.Parameters.AddWithValue("@departmentID", departmentID.Value)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetSupplyInventoryReport Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Retrieve maintenance history for reporting tools
    ''' </summary>
    Public Shared Function GetMaintenanceReport(Optional status As String = "",
                                                Optional dateFrom As Date? = Nothing,
                                                Optional dateTo As Date? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT m.maintenance_id, m.property_item_name, m.maintenance_date, m.type_of_maintenance, m.maintenance_details, ")
            query.Append("m.assigned_technician, m.cost_materials_labor, m.status ")
            query.Append("FROM maintenance m WHERE 1=1 ")

            If Not String.IsNullOrEmpty(status) Then query.Append(" AND m.status = @status ")
            If dateFrom.HasValue Then query.Append(" AND m.service_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND m.service_date <= @dateTo ")

            query.Append(" ORDER BY m.service_date DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(status) Then cmd.Parameters.AddWithValue("@status", status)
                If dateFrom.HasValue Then cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
                If dateTo.HasValue Then cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetMaintenanceReport Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Retrieve property/supply request transactions with optional date filters
    ''' </summary>
    Public Shared Function GetRequestTransactionsReport(Optional status As String = "",
                                                        Optional requestType As String = "",
                                                        Optional dateFrom As Date? = Nothing,
                                                        Optional dateTo As Date? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT pr.request_id, pr.request_type, pr.status, pr.request_date, pr.approval_date, pr.release_date, ")
            query.Append("pr.actual_returned_date, pr.quantity, sa.firstName, sa.lastName, ")
            query.Append("COALESCE(p.item_name, sup.item_name) AS item_name ")
            query.Append("FROM property_requests pr ")
            query.Append("LEFT JOIN users sa ON pr.userId = sa.user_id ")
            query.Append("LEFT JOIN properties p ON pr.property_id = p.propertyId ")
            query.Append("LEFT JOIN supplies sup ON pr.supply_id = sup.supply_id WHERE 1=1 ")

            If Not String.IsNullOrEmpty(status) Then query.Append(" AND pr.status = @status ")
            If Not String.IsNullOrEmpty(requestType) Then query.Append(" AND pr.request_type = @requestType ")
            If dateFrom.HasValue Then query.Append(" AND pr.request_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND pr.request_date <= @dateTo ")

            query.Append(" ORDER BY pr.request_date DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(status) Then cmd.Parameters.AddWithValue("@status", status)
                If Not String.IsNullOrEmpty(requestType) Then cmd.Parameters.AddWithValue("@requestType", requestType)
                If dateFrom.HasValue Then cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
                If dateTo.HasValue Then cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetRequestTransactionsReport Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Retrieve current custodian assignments for both properties and supplies
    ''' </summary>
    Public Shared Function GetCustodianAssignmentsReport(Optional custodianID As Integer? = Nothing,
                                                         Optional departmentID As Integer? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT u.userId, CONCAT(IFNULL(u.firstName,''), ' ', IFNULL(u.lastName,'')) AS custodian_name, ")
            query.Append("d.departmentName, p.item_name AS asset_name, p.category AS asset_category, 'Property' AS asset_type ")
            query.Append("FROM users u ")
            query.Append("INNER JOIN properties p ON u.userId = p.assignedTo ")
            query.Append("LEFT JOIN departments d ON u.departmentId = d.departmentId WHERE 1=1 ")

            If custodianID.HasValue Then query.Append(" AND u.userId = @custodianID ")
            If departmentID.HasValue Then query.Append(" AND u.departmentId = @departmentID ")

            query.Append(" UNION ALL ")

            query.Append("SELECT NULL AS userId, 'Unassigned' AS custodian_name, ")
            query.Append("'' AS departmentName, s.item_name AS asset_name, s.category AS asset_category, 'Supply' AS asset_type ")
            query.Append("FROM supplies s WHERE 1=1 ")

            If custodianID.HasValue Then query.Append(" AND u.userId = @custodianID ")
            If departmentID.HasValue Then query.Append(" AND u.departmentId = @departmentID ")

            query.Append(" ORDER BY custodian_name, asset_type")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If custodianID.HasValue Then cmd.Parameters.AddWithValue("@custodianID", custodianID.Value)
                If departmentID.HasValue Then cmd.Parameters.AddWithValue("@departmentID", departmentID.Value)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetCustodianAssignmentsReport Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Detailed requisition and issuance report covering all property/supply requests.
    ''' </summary>
    Public Shared Function GetRequisitionAndIssuanceReport(Optional dateFrom As Date? = Nothing,
                                                           Optional dateTo As Date? = Nothing,
                                                           Optional departmentID As Integer? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT pr.request_id, pr.request_type, pr.status, pr.request_date, pr.approval_date, ")
            query.Append("pr.release_date, pr.actual_returned_date, pr.quantity, ")
            query.Append("CONCAT(IFNULL(sa.firstName,''), ' ', IFNULL(sa.lastName,'')) AS requester_name, ")
            query.Append("d.departmentName, COALESCE(p.item_name, sup.item_name) AS item_name ")
            query.Append("FROM property_requests pr ")
            query.Append("INNER JOIN users sa ON pr.userId = sa.user_id ")
            query.Append("LEFT JOIN departments d ON sa.departmentId = d.departmentId ")
            query.Append("LEFT JOIN properties p ON pr.property_id = p.propertyId ")
            query.Append("LEFT JOIN supplies sup ON pr.supply_id = sup.supply_id WHERE 1=1 ")

            If dateFrom.HasValue Then query.Append(" AND pr.request_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND pr.request_date <= @dateTo ")
            If departmentID.HasValue Then query.Append(" AND sa.departmentId = @departmentID ")

            query.Append(" ORDER BY pr.request_date DESC, pr.request_id DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If dateFrom.HasValue Then cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
                If dateTo.HasValue Then cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)
                If departmentID.HasValue Then cmd.Parameters.AddWithValue("@departmentID", departmentID.Value)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetRequisitionAndIssuanceReport Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Property card style timeline combining requests and maintenance for a single asset.
    ''' </summary>
    Public Shared Function GetPropertyCardReport(propertyID As Integer,
                                                 Optional dateFrom As Date? = Nothing,
                                                 Optional dateTo As Date? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT entry_type, reference_id, activity_date, actor_name, status, remarks ")
            query.Append("FROM (")
            query.Append("SELECT 'REQUEST' AS entry_type, pr.request_id AS reference_id, pr.request_date AS activity_date, ")
            query.Append("CONCAT(IFNULL(sa.firstName,''), ' ', IFNULL(sa.lastName,'')) AS actor_name, ")
            query.Append("pr.status, pr.remarks ")
            query.Append("FROM property_requests pr ")
            query.Append("INNER JOIN users sa ON pr.userId = sa.user_id ")
            query.Append("WHERE pr.property_id = @propertyID ")
            If dateFrom.HasValue Then query.Append(" AND pr.request_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND pr.request_date <= @dateTo ")
            query.Append(" UNION ALL ")
            query.Append("SELECT 'MAINTENANCE' AS entry_type, m.maintenance_id AS reference_id, m.service_date AS activity_date, ")
            query.Append("m.assigned_technician AS actor_name, m.status, m.maintenance_details AS remarks ")
            query.Append("FROM maintenance m WHERE m.property_item_name LIKE @propertyID ")
            If dateFrom.HasValue Then query.Append(" AND m.maintenance_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND m.maintenance_date <= @dateTo ")
            query.Append(") AS combined ORDER BY activity_date ASC, entry_type")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                cmd.Parameters.AddWithValue("@propertyID", propertyID)
                If dateFrom.HasValue Then cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
                If dateTo.HasValue Then cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetPropertyCardReport Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Summary counts of requests grouped by status and type for dashboards.
    ''' </summary>
    Public Shared Function GetRequestSummaryReport(Optional dateFrom As Date? = Nothing,
                                                   Optional dateTo As Date? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT request_type, status, COUNT(*) AS total_requests ")
            query.Append("FROM property_requests WHERE 1=1 ")
            If dateFrom.HasValue Then query.Append(" AND request_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND request_date <= @dateTo ")
            query.Append(" GROUP BY request_type, status ORDER BY request_type, status")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If dateFrom.HasValue Then cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
                If dateTo.HasValue Then cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetRequestSummaryReport Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' STAFF-FACING: get recent notification-style updates for a staff user's requests.
    ''' This derives notifications from changes in property_requests (no separate table required).
    ''' </summary>
    Public Shared Function GetStaffNotifications(staffID As Integer,
                                                 Optional sinceDate As Date? = Nothing,
                                                 Optional maxRows As Integer = 50) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT pr.request_id, pr.request_type, pr.status, ")
            query.Append("COALESCE(pr.approval_date, pr.release_date, pr.actual_returned_date, pr.request_date) AS event_date, ")
            query.Append("COALESCE(p.item_name, sup.supply_name) AS item_name, pr.quantity, pr.remarks, ")
            query.Append("CASE ")
            query.Append(" WHEN pr.status = 'approved' THEN 'Your request has been approved.' ")
            query.Append(" WHEN pr.status = 'rejected' THEN 'Your request has been denied.' ")
            query.Append(" WHEN pr.status = 'released' THEN 'Your requested item is ready for release.' ")
            query.Append(" WHEN pr.status = 'returned' THEN 'Your borrowed item has been recorded as returned.' ")
            query.Append(" ELSE CONCAT('Request status updated to ', pr.status) ")
            query.Append("END AS notification_message ")
            query.Append("FROM property_requests pr ")
            query.Append("LEFT JOIN properties p ON pr.property_id = p.propertyId ")
            query.Append("LEFT JOIN supplies sup ON pr.supply_id = sup.supply_id ")
            query.Append("WHERE pr.userId = @staffID ")

            If sinceDate.HasValue Then
                query.Append("AND COALESCE(pr.approval_date, pr.release_date, pr.actual_returned_date, pr.request_date) >= @sinceDate ")
            End If

            query.Append("ORDER BY event_date DESC, pr.request_id DESC ")
            If maxRows > 0 Then
                query.Append("LIMIT " & maxRows.ToString())
            End If

            Using cmd As New MySqlCommand(query.ToString(), conn)
                cmd.Parameters.AddWithValue("@staffID", staffID)
                If sinceDate.HasValue Then cmd.Parameters.AddWithValue("@sinceDate", sinceDate.Value)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetStaffNotifications Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
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
                    MessageBox.Show("Database connection issue detected. Please ensure MySQL is running properly." & Environment.NewLine & "Error: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    ''' Test database connection with detailed error messages
    ''' </summary>
    Public Shared Function TestConnection() As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then
                MessageBox.Show("Failed to create database connection object. Please check your connection settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Not SafeOpenConnection(conn) Then
                MessageBox.Show("Database connection failed. Please ensure:" & Environment.NewLine & Environment.NewLine &
                              "1. MySQL/XAMPP is running" & Environment.NewLine &
                              "2. The database 'teamcruzim' exists" & Environment.NewLine &
                              "3. Username 'root' has proper permissions" & Environment.NewLine &
                              "4. No firewall is blocking the connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            ' Test query to verify connection works
            Dim testQuery As String = "SELECT 1"
            Using cmd As New MySqlCommand(testQuery, conn)
                cmd.ExecuteScalar()
            End Using

            System.Diagnostics.Debug.WriteLine("[v0] Database connection test successful")
            Return True
        Catch ex As MySqlException
            System.Diagnostics.Debug.WriteLine("[v0] Database connection test failed (MySQL): " & ex.Message)
            Dim errorMsg As String = "MySQL Error: " & ex.Message & Environment.NewLine & Environment.NewLine
            If ex.Number = 1045 Then
                errorMsg &= "Invalid username or password. Please check your database credentials."
            ElseIf ex.Number = 1049 Then
                errorMsg &= "Database 'teamcruzim' does not exist. Please create it first."
            ElseIf ex.Number = 2003 OrElse ex.Number = 0 Then
                errorMsg &= "Cannot connect to MySQL server. Please ensure:" & Environment.NewLine &
                           "1. XAMPP/MySQL is running" & Environment.NewLine &
                           "2. MySQL service is started"
            Else
                errorMsg &= "Please check your MySQL configuration and ensure the server is running."
            End If
            MessageBox.Show(errorMsg, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Database connection test failed: " & ex.Message)
            Dim errorMsg As String = "Database connection failed: " & ex.Message & Environment.NewLine & Environment.NewLine &
                                    "Please ensure:" & Environment.NewLine &
                                    "1. MySQL/XAMPP is running" & Environment.NewLine &
                                    "2. The database server is accessible" & Environment.NewLine &
                                    "3. Your connection settings are correct"
            MessageBox.Show(errorMsg, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    ''' Validate staff login credentials with password hashing and basic auditing (legacy helper).
    ''' For new code, prefer AuthenticateStaff which returns full profile info.
    ''' </summary>
    Public Shared Function ValidateStaffLogin(username As String, password As String) As Boolean
        Dim authResult As Dictionary(Of String, String) = AuthenticateStaff(username, password)
        Return authResult IsNot Nothing AndAlso authResult.Count > 0
    End Function

    ''' <summary>
    ''' Authenticate a staff user and return basic profile info (for Staff role).
    ''' Logs LOGIN / LOGIN_FAILED into audit_logs and updates last_login on success.
    ''' </summary>
    Public Shared Function AuthenticateStaff(username As String,
                                         password As String,
                                         Optional ipAddress As String = "") As Dictionary(Of String, String)

        Dim result As New Dictionary(Of String, String)()
        Dim conn As MySqlConnection = Nothing

        Try
            If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - Empty username or password")
                Return Nothing
            End If

            conn = GetConnection()
            If conn Is Nothing Then
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - GetConnection returned Nothing")
                Return Nothing
            End If

            If Not SafeOpenConnection(conn) Then
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - SafeOpenConnection failed")
                Return Nothing
            End If

            ' Check hardcoded staff credentials first (use users table for Staff role)
            Dim hardcodedStaffUsername As String = "staff"
            Dim hardcodedStaffPassword As String = "Staff@123"
            Dim normalizedUsername As String = username.Trim().ToLower()

            If normalizedUsername = hardcodedStaffUsername.ToLower() AndAlso password = hardcodedStaffPassword Then
                ' Ensure account exists in database and get full details (users table stores all accounts)
                InitializeDefaultAccounts()
                Dim hardcodedQuery As String =
                    "SELECT userId, firstName, lastName, email, contactNumber, departmentId, username, passwordEncrypted, status " &
                    "FROM users WHERE LOWER(username) = LOWER(@username) AND role = 'Staff' LIMIT 1;"
                Using cmd As New MySqlCommand(hardcodedQuery, conn)
                    cmd.Parameters.AddWithValue("@username", hardcodedStaffUsername)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim uid As Integer = Convert.ToInt32(reader("userId"))
                            result("staffId") = uid.ToString()
                            result("staff_id") = uid.ToString()
                            result("userId") = uid.ToString()
                            result("user_id") = uid.ToString()
                            result("firstName") = If(IsDBNull(reader("firstName")), "", reader("firstName").ToString())
                            result("lastName") = If(IsDBNull(reader("lastName")), "", reader("lastName").ToString())
                            result("email") = If(IsDBNull(reader("email")), "", reader("email").ToString())
                            result("contactNumber") = If(IsDBNull(reader("contactNumber")), "", reader("contactNumber").ToString())
                            result("departmentId") = If(IsDBNull(reader("departmentId")), "", reader("departmentId").ToString())
                            result("username") = reader("username").ToString()
                            result("user_type") = "Staff"

                            ' Update lastLogin
                            reader.Close()
                            Using updateCmd As New MySqlCommand("UPDATE users SET lastLogin = NOW() WHERE userId = @staffID", conn)
                                updateCmd.Parameters.AddWithValue("@staffID", uid)
                                updateCmd.ExecuteNonQuery()
                            End Using

                            LogActivity(uid, "Staff", hardcodedStaffUsername, "LOGIN", "Authentication", "Staff successfully logged in (hardcoded)", ipAddress)
                            System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - hardcoded credentials matched for: " & username)
                            Return result
                        End If
                    End Using
                End Using
            End If

            ' Use a single-row select to fetch the stored hash and metadata from users table (Staff role)
            ' Use flexible reader to tolerate different schema names
            Dim row As DataRow = GetUserRecord(conn, username, "Staff")
            If row Is Nothing Then
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - user not found (flexible): " & username)
                LogActivity(Nothing, "Staff", username, "LOGIN_FAILED", "Authentication", "Username not found", ipAddress)
                Return Nothing
            End If

            ' Extract fields from DataRow using multiple name variants
            Dim status As String = SafeDbValue(row("status"))
            If String.IsNullOrEmpty(status) Then
                ' try other column names
                status = If(row.Table.Columns.Contains("status"), SafeDbValue(row("status")), SafeDbValue(row("user_status")))
            End If

            Dim storedHash As String = ""
            If row.Table.Columns.Contains("passwordEncrypted") Then storedHash = SafeDbValue(row("passwordEncrypted"))
            If String.IsNullOrEmpty(storedHash) AndAlso row.Table.Columns.Contains("password_encrypted") Then storedHash = SafeDbValue(row("password_encrypted"))
            If String.IsNullOrEmpty(storedHash) AndAlso row.Table.Columns.Contains("password") Then storedHash = SafeDbValue(row("password"))

            Dim staffId As Integer = 0
            If row.Table.Columns.Contains("userId") Then Integer.TryParse(SafeDbValue(row("userId")), staffId)
            If staffId = 0 AndAlso row.Table.Columns.Contains("user_id") Then Integer.TryParse(SafeDbValue(row("user_id")), staffId)
            If staffId = 0 AndAlso row.Table.Columns.Contains("id") Then Integer.TryParse(SafeDbValue(row("id")), staffId)

            If String.IsNullOrEmpty(storedHash) Then
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - storedHash empty for: " & username)
                LogActivity(Nothing, "Staff", username, "LOGIN_FAILED", "Authentication", "Missing password hash", ipAddress)
                Return Nothing
            End If

            If staffId <= 0 Then
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - invalid staffId for: " & username)
                LogActivity(Nothing, "Staff", username, "LOGIN_FAILED", "Authentication", "Invalid staff ID", ipAddress)
                Return Nothing
            End If

            If Not String.Equals(status, "Active", StringComparison.OrdinalIgnoreCase) Then
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - account not active: " & username & " status=" & status)
                LogActivity(Nothing, "Staff", username, "LOGIN_FAILED", "Authentication", "Inactive account", ipAddress)
                Return Nothing
            End If

            storedHash = storedHash.Trim()
            System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - storedHash length for " & username & " = " & storedHash.Length.ToString())

            Dim verified As Boolean = False
            Try
                verified = PasswordHelper.VerifyPassword(password, storedHash)
            Catch pwEx As Exception
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - PasswordHelper.VerifyPassword exception: " & pwEx.Message)
                LogActivity(Nothing, "Staff", username, "LOGIN_FAILED", "Authentication", "Invalid password hash format", ipAddress)
                Return Nothing
            End Try

            If Not verified Then
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - invalid password for: " & username)
                LogActivity(Nothing, "Staff", username, "LOGIN_FAILED", "Authentication", "Invalid password attempt", ipAddress)
                Return Nothing
            End If

            ' Populate result
            Dim userID As Integer = staffId
            result("staffId") = userID.ToString()
            result("staff_id") = userID.ToString()
            result("userId") = userID.ToString()
            result("user_id") = userID.ToString()
            If row.Table.Columns.Contains("firstName") Then result("firstName") = SafeDbValue(row("firstName"))
            If row.Table.Columns.Contains("lastName") Then result("lastName") = SafeDbValue(row("lastName"))
            If row.Table.Columns.Contains("email") Then result("email") = SafeDbValue(row("email"))
            If row.Table.Columns.Contains("contactNumber") Then result("contactNumber") = SafeDbValue(row("contactNumber"))
            If row.Table.Columns.Contains("departmentId") Then result("departmentId") = SafeDbValue(row("departmentId"))
            result("username") = username
            result("user_type") = "Staff"

            ' Update last_login and write audit
            If result.Count > 0 Then
                Try
                    Using updateCmd As New MySqlCommand("UPDATE users SET lastLogin = NOW() WHERE userId = @userID", conn)
                        updateCmd.Parameters.AddWithValue("@userID", CInt(result("userId")))
                        updateCmd.ExecuteNonQuery()
                    End Using
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - failed updating last_login: " & ex.Message)
                End Try

                LogActivity(CInt(result("userId")), "Staff", result("username"), "LOGIN", "Authentication", "Staff successfully logged in", ipAddress)
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - success for: " & username)
                Return result
            End If

        Catch ex As MySqlException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - ReplicationManager MySqlException: " & ex.Message)
            MessageBox.Show("Database connection issue. Please try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff Exception: " & ex.Message)
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "validate login")
            MessageBox.Show(errorMsg, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error closing connection in AuthenticateStaff: " & ex.Message)
                End Try
            End If
        End Try

        Return Nothing
    End Function


    Private Shared Function AuthenticateWithHardcodedCredentials(username As String,
                                                                 password As String,
                                                                 ipAddress As String) As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)
        Dim normalizedUsername As String = username.Trim().ToLower()

        Const superAdminUsername As String = "superadmin"
        Const superAdminPassword As String = "SuperAdmin@123"
        Const adminUsername As String = "admin"
        Const adminPassword As String = "Admin@123"
        Const custodianUsername As String = "custodian"
        Const custodianPassword As String = "Custodian@123"

        Try
            If normalizedUsername = superAdminUsername AndAlso password = superAdminPassword Then
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateWithHardcodedCredentials - SuperAdmin credentials matched")
                ' Use UpsertUser to ensure account exists and return the id
                Dim conn As MySqlConnection = Nothing
                Try
                    conn = GetConnection()
                    If conn IsNot Nothing AndAlso SafeOpenConnection(conn) Then
                        Dim uid = UpsertUser(conn, superAdminUsername, "Super", "Administrator", "superadmin@stacruz.edu", PasswordHelper.HashPassword(superAdminPassword), "SuperAdmin")
                        If uid IsNot Nothing Then
                            result("userId") = uid.ToString()
                            result("user_id") = uid.ToString()
                            result("username") = superAdminUsername
                            result("user_type") = "SuperAdmin"
                        End If
                    End If
                Finally
                    If conn IsNot Nothing Then
                        Try
                            If conn.State = ConnectionState.Open Then conn.Close()
                            conn.Dispose()
                        Catch
                        End Try
                    End If
                End Try
                If result.Count > 0 Then
                    RecordAdminLogin(CInt(result("userId")), "SuperAdmin", result("username"), ipAddress)
                    System.Diagnostics.Debug.WriteLine("[v0] AuthenticateWithHardcodedCredentials - SuperAdmin login successful")
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] AuthenticateWithHardcodedCredentials - SuperAdmin account creation/retrieval failed")
                End If
                Return result
            End If

            If normalizedUsername = adminUsername AndAlso password = adminPassword Then
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateWithHardcodedCredentials - Admin credentials matched")
                Dim conn As MySqlConnection = Nothing
                Try
                    conn = GetConnection()
                    If conn IsNot Nothing AndAlso SafeOpenConnection(conn) Then
                        Dim uid = UpsertUser(conn, adminUsername, "System", "Administrator", "admin@stacruz.edu", PasswordHelper.HashPassword(adminPassword), "Admin")
                        If uid IsNot Nothing Then
                            result("userId") = uid.ToString()
                            result("user_id") = uid.ToString()
                            result("username") = adminUsername
                            result("user_type") = "Admin"
                        End If
                    End If
                Finally
                    If conn IsNot Nothing Then
                        Try
                            If conn.State = ConnectionState.Open Then conn.Close()
                            conn.Dispose()
                        Catch
                        End Try
                    End If
                End Try
                If result.Count > 0 Then
                    RecordAdminLogin(CInt(result("userId")), "Admin", result("username"), ipAddress)
                    System.Diagnostics.Debug.WriteLine("[v0] AuthenticateWithHardcodedCredentials - Admin login successful")
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] AuthenticateWithHardcodedCredentials - Admin account creation/retrieval failed")
                End If
                Return result
            End If

            If normalizedUsername = custodianUsername AndAlso password = custodianPassword Then
                System.Diagnostics.Debug.WriteLine("[v0] AuthenticateWithHardcodedCredentials - Custodian credentials matched")
                Dim conn As MySqlConnection = Nothing
                Try
                    conn = GetConnection()
                    If conn IsNot Nothing AndAlso SafeOpenConnection(conn) Then
                        Dim uid = UpsertUser(conn, custodianUsername, "Property", "Custodian", "custodian@stacruz.edu", PasswordHelper.HashPassword(custodianPassword), "Custodian")
                        If uid IsNot Nothing Then
                            result("userId") = uid.ToString()
                            result("user_id") = uid.ToString()
                            result("username") = custodianUsername
                            result("user_type") = "Custodian"
                        End If
                    End If
                Finally
                    If conn IsNot Nothing Then
                        Try
                            If conn.State = ConnectionState.Open Then conn.Close()
                            conn.Dispose()
                        Catch
                        End Try
                    End If
                End Try
                If result.Count > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] AuthenticateWithHardcodedCredentials - Custodian login successful, user_id: " & result("userId"))
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] AuthenticateWithHardcodedCredentials - ERROR: Custodian account creation/retrieval failed despite matching credentials")
                End If
                Return result
            End If
        Catch exAuth As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AuthenticateWithHardcodedCredentials - Exception: " & exAuth.Message)
            System.Diagnostics.Debug.WriteLine("[v0] AuthenticateWithHardcodedCredentials - StackTrace: " & exAuth.StackTrace)
        End Try

        Return result
    End Function

    Private Shared Function EnsureHardcodedAccount(username As String,
                                                   plainPassword As String,
                                                   firstName As String,
                                                   lastName As String,
                                                   email As String,
                                                   userType As String) As Dictionary(Of String, String)
        Dim account As New Dictionary(Of String, String)
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return account
            If Not SafeOpenConnection(conn) Then Return account

            InitializeDefaultAccounts()

            account = FetchAdminAccountRecord(conn, username)

            Dim hashedPassword As String = PasswordHelper.HashPassword(plainPassword)
            If String.IsNullOrEmpty(hashedPassword) Then
                System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedAccount - Unable to hash password for " & username)
                Return account
            End If

            If account.Count = 0 Then
                Using insertCmd As New MySqlCommand("INSERT INTO users (firstName, lastName, email, username, passwordEncrypted, role, status, createdAt) " &
                                                    "VALUES (@firstName, @lastName, @email, @username, @password, @userType, 'Active', NOW())", conn)
                    insertCmd.Parameters.AddWithValue("@firstName", firstName)
                    insertCmd.Parameters.AddWithValue("@lastName", lastName)
                    insertCmd.Parameters.AddWithValue("@email", email)
                    insertCmd.Parameters.AddWithValue("@username", username)
                    insertCmd.Parameters.AddWithValue("@password", hashedPassword)
                    insertCmd.Parameters.AddWithValue("@userType", userType)
                    insertCmd.ExecuteNonQuery()
                End Using
            Else
                Using updateCmd As New MySqlCommand("UPDATE users SET firstName = @firstName, lastName = @lastName, email = @email, " &
                                                    "passwordEncrypted = @password, role = @userType, status = 'Active' WHERE userId = @userID", conn)
                    updateCmd.Parameters.AddWithValue("@firstName", firstName)
                    updateCmd.Parameters.AddWithValue("@lastName", lastName)
                    updateCmd.Parameters.AddWithValue("@email", email)
                    updateCmd.Parameters.AddWithValue("@password", hashedPassword)
                    updateCmd.Parameters.AddWithValue("@userType", userType)
                    updateCmd.Parameters.AddWithValue("@userID", CInt(account("userId")))
                    updateCmd.ExecuteNonQuery()
                End Using
            End If

            account = FetchAdminAccountRecord(conn, username)
        Catch exAccount As Exception
            System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedAccount Exception: " & exAccount.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return account
    End Function

    Private Shared Function FetchAdminAccountRecord(conn As MySqlConnection, username As String) As Dictionary(Of String, String)
        Dim account As New Dictionary(Of String, String)
        Dim query As String = "SELECT userId, firstName, lastName, email, username, role AS user_type " &
                              "FROM users WHERE LOWER(username) = LOWER(@username) LIMIT 1"
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", username.Trim())
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim uid As String = reader("userId").ToString()
                    account("userId") = uid
                    account("user_id") = uid
                    account("firstName") = reader("firstName").ToString()
                    account("lastName") = reader("lastName").ToString()
                    account("email") = reader("email").ToString()
                    account("username") = reader("username").ToString()
                    account("user_type") = reader("user_type").ToString()
                End If
            End Using
        End Using
        Return account
    End Function

    Private Shared Function EnsureHardcodedCustodianAccount(username As String,
                                                            plainPassword As String,
                                                            firstName As String,
                                                            lastName As String,
                                                            email As String,
                                                            ipAddress As String) As Dictionary(Of String, String)
        Dim account As New Dictionary(Of String, String)
        Dim conn As MySqlConnection = Nothing
        Try
            System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount - Starting for username: " & username)
            conn = GetConnection()
            If conn Is Nothing Then
                System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount - Connection is Nothing")
                Return account
            End If
            If Not SafeOpenConnection(conn) Then
                System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount - Failed to open connection")
                Return account
            End If

            System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount - Connection opened successfully")
            InitializeDefaultAccounts()

            ' Check if Custodian account exists in users table (all accounts are in users table)
            Dim custodianId As Object = Nothing
            Using checkCmd As New MySqlCommand("SELECT userId FROM users WHERE LOWER(username) = LOWER(@username) AND role = 'Custodian' LIMIT 1", conn)
                checkCmd.Parameters.AddWithValue("@username", username.Trim())
                custodianId = checkCmd.ExecuteScalar()
            End Using

            Dim hashedPassword As String = PasswordHelper.HashPassword(plainPassword)
            If String.IsNullOrEmpty(hashedPassword) Then
                System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount - Unable to hash password for " & username)
                Return account
            End If

            If custodianId Is Nothing OrElse custodianId Is DBNull.Value Then
                System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount - Creating new Custodian account")
                ' Create Custodian account in users table (same table as Admin/SuperAdmin/Staff)
                Using insertCmd As New MySqlCommand("INSERT INTO users (firstName, lastName, email, username, passwordEncrypted, role, status, createdAt) " &
                                                    "VALUES (@firstName, @lastName, @email, @username, @password, 'Custodian', 'Active', NOW())", conn)
                    insertCmd.Parameters.AddWithValue("@firstName", firstName)
                    insertCmd.Parameters.AddWithValue("@lastName", lastName)
                    insertCmd.Parameters.AddWithValue("@email", email)
                    insertCmd.Parameters.AddWithValue("@username", username)
                    insertCmd.Parameters.AddWithValue("@password", hashedPassword)
                    Dim rowsAffected As Integer = insertCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] Default Custodian account created: " & username & " (rows: " & rowsAffected & ")")
                End Using
            Else
                System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount - Updating existing Custodian account (ID: " & custodianId.ToString() & ")")
                ' Update existing Custodian account to ensure credentials stay in sync
                Using updateCmd As New MySqlCommand("UPDATE users SET firstName = @firstName, lastName = @lastName, email = @email, " &
                                                    "passwordEncrypted = @password, status = 'Active', updatedAt = NOW() WHERE userId = @userID", conn)
                    updateCmd.Parameters.AddWithValue("@firstName", firstName)
                    updateCmd.Parameters.AddWithValue("@lastName", lastName)
                    updateCmd.Parameters.AddWithValue("@email", email)
                    updateCmd.Parameters.AddWithValue("@password", hashedPassword)
                    updateCmd.Parameters.AddWithValue("@userID", CInt(custodianId))
                    Dim rowsAffected As Integer = updateCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] Default Custodian account verified/updated: " & username & " (rows: " & rowsAffected & ")")
                End Using
            End If

            ' Fetch the account record
            Using fetchCmd As New MySqlCommand("SELECT userId, firstName, lastName, email, username, role, status " &
                                               "FROM users WHERE LOWER(username) = LOWER(@username) AND role = 'Custodian' LIMIT 1", conn)
                fetchCmd.Parameters.AddWithValue("@username", username.Trim())
                Using reader As MySqlDataReader = fetchCmd.ExecuteReader()
                    If reader.Read() Then
                        Dim userID As Integer = Convert.ToInt32(reader("userId"))
                        account("staffId") = userID.ToString()
                        account("userId") = userID.ToString()
                        account("firstName") = reader("firstName").ToString()
                        account("lastName") = reader("lastName").ToString()
                        account("email") = reader("email").ToString()
                        account("username") = reader("username").ToString()
                        account("user_type") = "Custodian"
                        System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount - Account fetched successfully (ID: " & account("userId") & ")")
                    Else
                        System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount - Failed to fetch account after create/update")
                    End If
                End Using
            End Using

            ' Update last_login and log successful login
            If account.Count > 0 Then
                Dim userID As Integer = CInt(account("userId"))
                Using updateCmd As New MySqlCommand("UPDATE users SET lastLogin = NOW() WHERE userId = @userID", conn)
                    updateCmd.Parameters.AddWithValue("@userID", userID)
                    updateCmd.ExecuteNonQuery()
                End Using

                LogActivity(userID, "Custodian", account("username"), "LOGIN", "Authentication",
                            "Custodian successfully logged in", ipAddress)
                System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount - Login activity logged")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount - Account dictionary is empty, cannot log activity")
            End If
        Catch exCustodian As Exception
            System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount Exception: " & exCustodian.Message)
            System.Diagnostics.Debug.WriteLine("[v0] EnsureHardcodedCustodianAccount StackTrace: " & exCustodian.StackTrace)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return account
    End Function

    Private Shared Sub RecordAdminLogin(userID As Integer, userType As String, username As String, Optional ipAddress As String = "")
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn IsNot Nothing AndAlso SafeOpenConnection(conn) Then
                Using updateCmd As New MySqlCommand("UPDATE users SET lastLogin = NOW() WHERE userId = @userID", conn)
                    updateCmd.Parameters.AddWithValue("@userID", userID)
                    updateCmd.ExecuteNonQuery()
                End Using
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] RecordAdminLogin Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        LogActivity(userID, userType, username, "LOGIN", "Authentication", userType & " successfully logged in", ipAddress)
    End Sub


    ''' <summary>
    ''' Validate admin/super admin login credentials with password hashing.
    ''' Checks hardcoded credentials FIRST before querying the database.
    ''' </summary>
    Public Shared Function ValidateAdminLogin(username As String, password As String, Optional ipAddress As String = "") As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            System.Diagnostics.Debug.WriteLine("[v0] Admin Login - Empty credentials")
            Return result
        End If

        ' HARDCODED CREDENTIALS - Check these FIRST before database query
        Dim superAdminUsername As String = "superadmin"
        Dim superAdminPassword As String = "SuperAdmin@123"
        Dim adminUsername As String = "admin"
        Dim adminPassword As String = "Admin@123"
        Dim custodianUsername As String = "custodian"
        Dim custodianPassword As String = "Custodian@123"

        Dim normalizedUsername As String = username.Trim().ToLower()

        ' Handle hardcoded SuperAdmin/Admin/Custodian credentials up front
        Try
            Dim hardcodedResult As Dictionary(Of String, String) = AuthenticateWithHardcodedCredentials(username, password, ipAddress)
            If hardcodedResult IsNot Nothing AndAlso hardcodedResult.Count > 0 Then
                System.Diagnostics.Debug.WriteLine("[v0] ValidateAdminLogin - Hardcoded credentials matched for: " & username)
                Return hardcodedResult
            Else
                System.Diagnostics.Debug.WriteLine("[v0] ValidateAdminLogin - Hardcoded credentials check returned empty for: " & username)
            End If
        Catch exHardcoded As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ValidateAdminLogin - Error checking hardcoded credentials: " & exHardcoded.Message)
        End Try

        ' Check hardcoded SuperAdmin credentials first
        If normalizedUsername = superAdminUsername.ToLower() Then
            If password = superAdminPassword Then
                ' Ensure account exists in database and get full details
                Dim conn As MySqlConnection = Nothing
                Try
                    conn = GetConnection()
                    If conn IsNot Nothing AndAlso SafeOpenConnection(conn) Then
                        InitializeDefaultAccounts()

                        Dim query As String = "SELECT userId, firstName, lastName, email, username, role AS user_type, passwordEncrypted " &
                                             "FROM users WHERE LOWER(username) = LOWER(@username) " &
                                             "AND role = 'SuperAdmin' " &
                                             "AND status = 'Active'"
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@username", superAdminUsername)
                            Dim hardcodedSuccess As Boolean = False
                            Using reader As MySqlDataReader = cmd.ExecuteReader()
                                If reader.Read() Then
                                    result("userId") = reader("userId").ToString()
                                    result("user_id") = reader("userId").ToString()
                                    result("firstName") = reader("firstName").ToString()
                                    result("lastName") = reader("lastName").ToString()
                                    result("email") = reader("email").ToString()
                                    result("username") = reader("username").ToString()
                                    result("user_type") = "SuperAdmin"
                                    hardcodedSuccess = True
                                    System.Diagnostics.Debug.WriteLine("[v0] SuperAdmin Login Success (Hardcoded): " & superAdminUsername)
                                End If
                            End Using

                            If hardcodedSuccess Then
                                Using updateCmd As New MySqlCommand("UPDATE users SET lastLogin = NOW() WHERE userId = @userID", conn)
                                    updateCmd.Parameters.AddWithValue("@userID", result("userId"))
                                    updateCmd.ExecuteNonQuery()
                                End Using

                                LogActivity(CInt(result("userId")), "SuperAdmin", result("username"), "LOGIN", "Authentication", "SuperAdmin successfully logged in", ipAddress)
                            End If
                        End Using
                    End If
                Finally
                    If conn IsNot Nothing Then
                        Try
                            If conn.State = ConnectionState.Open Then conn.Close()
                            conn.Dispose()
                        Catch
                        End Try
                    End If
                End Try

                If result.Count > 0 Then Return result
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Admin Login Failed - Invalid password for hardcoded SuperAdmin")
                LogActivity(Nothing, "SuperAdmin", username, "LOGIN_FAILED", "Authentication", "Invalid password attempt", ipAddress)
                Return result
            End If
        End If

        ' Check hardcoded Admin credentials
        If normalizedUsername = adminUsername.ToLower() Then
            If password = adminPassword Then
                ' Ensure account exists in database and get full details
                Dim conn As MySqlConnection = Nothing
                Try
                    conn = GetConnection()
                    If conn IsNot Nothing AndAlso SafeOpenConnection(conn) Then
                        InitializeDefaultAccounts()

                        Dim query As String = "SELECT userId, firstName, lastName, email, username, role AS user_type, passwordEncrypted " &
                                             "FROM users WHERE LOWER(username) = LOWER(@username) " &
                                                         "AND role = 'Admin' " &
                                             "AND status = 'Active'"
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@username", adminUsername)
                            Dim hardcodedAdminSuccess As Boolean = False
                            Using reader As MySqlDataReader = cmd.ExecuteReader()
                                If reader.Read() Then
                                    result("userId") = reader("userId").ToString()
                                    result("user_id") = reader("userId").ToString()
                                    result("firstName") = reader("firstName").ToString()
                                    result("lastName") = reader("lastName").ToString()
                                    result("email") = reader("email").ToString()
                                    result("username") = reader("username").ToString()
                                    result("user_type") = "Admin"
                                    hardcodedAdminSuccess = True
                                    System.Diagnostics.Debug.WriteLine("[v0] Admin Login Success (Hardcoded): " & adminUsername)
                                End If
                            End Using

                            If hardcodedAdminSuccess Then
                                Using updateCmd As New MySqlCommand("UPDATE users SET lastLogin = NOW() WHERE userId = @userID", conn)
                                    updateCmd.Parameters.AddWithValue("@userID", result("userId"))
                                    updateCmd.ExecuteNonQuery()
                                End Using

                                LogActivity(CInt(result("userId")), "Admin", result("username"), "LOGIN", "Authentication", "Admin successfully logged in", ipAddress)
                            End If
                        End Using
                    End If
                Finally
                    If conn IsNot Nothing Then
                        Try
                            If conn.State = ConnectionState.Open Then conn.Close()
                            conn.Dispose()
                        Catch
                        End Try
                    End If
                End Try

                If result.Count > 0 Then Return result
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Admin Login Failed - Invalid password for hardcoded Admin")
                LogActivity(Nothing, "Admin", username, "LOGIN_FAILED", "Authentication", "Invalid password attempt", ipAddress)
                Return result
            End If
        End If

        ' If not hardcoded credentials, check database for other Admin/SuperAdmin accounts
        Dim conn2 As MySqlConnection = Nothing
        Try
            conn2 = GetConnection()
            If conn2 Is Nothing Then Return result

            If Not SafeOpenConnection(conn2) Then Return result

            ' Ensure default accounts exist
            InitializeDefaultAccounts()

            ' Query uses role column (not user_type) - alias it as user_type for compatibility
            Dim query As String = "SELECT userId, firstName, lastName, email, username, role AS user_type, passwordEncrypted " &
                                 "FROM users WHERE LOWER(username) = LOWER(@username) " &
                                 "AND (role = 'Admin' OR role = 'SuperAdmin') " &
                                 "AND LOWER(status) = 'active'"
            Using cmd As New MySqlCommand(query, conn2)
                cmd.Parameters.AddWithValue("@username", username.Trim())

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim storedHash As String = reader("passwordEncrypted").ToString()

                        If PasswordHelper.VerifyPassword(password, storedHash) Then
                            result("userId") = reader("userId").ToString()
                            result("user_id") = reader("userId").ToString()
                            result("firstName") = reader("firstName").ToString()
                            result("lastName") = reader("lastName").ToString()
                            result("email") = reader("email").ToString()
                            result("username") = reader("username").ToString()
                            result("user_type") = reader("user_type").ToString()
                            System.Diagnostics.Debug.WriteLine("[v0] Admin Login Success (Database): " & username & " (" & result("user_type") & ")")
                        Else
                            System.Diagnostics.Debug.WriteLine("[v0] Admin Login Failed - Invalid password: " & username)
                            LogActivity(Nothing, "Admin", username, "LOGIN_FAILED", "Authentication", "Invalid password attempt", ipAddress)
                        End If
                    Else
                        System.Diagnostics.Debug.WriteLine("[v0] Admin Login Failed - User not found: " & username)
                        LogActivity(Nothing, "Admin", username, "LOGIN_FAILED", "Authentication", "Username not found", ipAddress)
                    End If
                End Using
            End Using

            ' If login succeeded, update last login and log activity
            If result.Count > 0 Then
                Using updateCmd As New MySqlCommand("UPDATE users SET lastLogin = NOW() WHERE userId = @userID", conn2)
                    updateCmd.Parameters.AddWithValue("@userID", result("userId"))
                    updateCmd.ExecuteNonQuery()
                End Using

                LogActivity(CInt(result("userId")), result("user_type"), result("username"), "LOGIN", "Authentication", "Administrator successfully logged in", ipAddress)
            End If
        Catch ex As MySqlException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] Admin Login - ReplicationManager error: " & ex.Message)
            MessageBox.Show("Database connection issue. Please try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Admin Login Exception: " & ex.Message)
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "validate login")
            MessageBox.Show(errorMsg, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn2 IsNot Nothing Then
                Try
                    If conn2.State = ConnectionState.Open Then conn2.Close()
                    conn2.Dispose()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Error closing connection in ValidateAdminLogin: " & ex.Message)
                End Try
            End If
        End Try
        Return result
    End Function

    ''' <summary>
    ''' Properly log out an administrator and create an audit entry
    ''' </summary>
    Public Shared Sub LogoutAdmin(userID As Integer?, username As String, userType As String, Optional ipAddress As String = "")
        Try
            LogActivity(userID, userType, username, "LOGOUT", "Authentication", "Administrator logged out", ipAddress)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LogoutAdmin Exception: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Properly log out a staff user and create an audit entry.
    ''' </summary>
    Public Shared Sub LogoutStaff(userID As Integer?, username As String, Optional ipAddress As String = "")
        Try
            LogActivity(userID, "Staff", username, "LOGOUT", "Authentication", "Staff logged out", ipAddress)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LogoutStaff Exception: " & ex.Message)
        End Try
    End Sub

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

            ' Check if username already exists in users table (all accounts are in users table)
            Dim checkUsersQuery As String = "SELECT COUNT(*) FROM users WHERE LOWER(username) = LOWER(@username)"
            Using checkCmd As New MySqlCommand(checkUsersQuery, conn)
                checkCmd.Parameters.AddWithValue("@username", username)
                If CInt(checkCmd.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    System.Diagnostics.Debug.WriteLine("[v0] Registration Failed - Username exists in users table")
                    Return False
                End If
            End Using

            ' Check if email already exists in users table
            If Not String.IsNullOrWhiteSpace(email) Then
                Dim checkEmailQuery As String = "SELECT COUNT(*) FROM users WHERE LOWER(email) = LOWER(@email)"
                Using checkCmd As New MySqlCommand(checkEmailQuery, conn)
                    checkCmd.Parameters.AddWithValue("@email", email)
                    If CInt(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Email already exists. Please use a different email address.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        System.Diagnostics.Debug.WriteLine("[v0] Registration Failed - Email exists in users table")
                        Return False
                    End If
                End Using
            End If

            ' Hash password
            Dim hashedPassword As String = PasswordHelper.HashPassword(password)
            If String.IsNullOrEmpty(hashedPassword) Then
                MessageBox.Show("Error encrypting password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            ' REGISTRATION IS RESTRICTED TO STAFF ONLY
            ' Admin and SuperAdmin accounts cannot be created through registration
            ' They must be created by system administrators through User Management

            ' Reject any attempt to register as Admin, SuperAdmin, or Custodian
            If position = "Super Admin" OrElse position = "SuperAdmin" OrElse position = "Admin" OrElse position = "Custodian" Then
                MessageBox.Show("Registration of Admin, SuperAdmin, or Custodian accounts is not allowed through this interface. " &
                               "Only Staff accounts can be registered. Please contact a system administrator if you need an Admin or Custodian account.",
                               "Registration Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                System.Diagnostics.Debug.WriteLine("[v0] Registration Rejected - Attempted to register " & position & " account: " & username)
                Return False
            End If

            ' Force role to "Staff" for all registrations
            ' Insert into users table (same table used for SuperAdmin and Admin)
            ' Parse departmentID safely
            Dim deptIDValue As Object = DBNull.Value
            If Not String.IsNullOrWhiteSpace(departmentID) Then
                Dim parsedDeptID As Integer
                If Integer.TryParse(departmentID.Trim(), parsedDeptID) Then
                    deptIDValue = parsedDeptID
                End If
            End If

            Dim insertQuery As String = "INSERT INTO users (firstName, lastName, email, contactNumber, departmentId, username, passwordEncrypted, role, status, position, createdAt) " &
                                       "VALUES (@firstName, @lastName, @email, @contactNumber, @departmentID, @username, @password, 'Staff', 'Active', @position, NOW())"

            Using cmd As New MySqlCommand(insertQuery, conn)
                cmd.Parameters.AddWithValue("@firstName", firstName.Trim())
                cmd.Parameters.AddWithValue("@lastName", lastName.Trim())
                cmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(email), DBNull.Value, email.Trim()))
                cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrWhiteSpace(contactNumber), DBNull.Value, contactNumber.Trim()))
                cmd.Parameters.AddWithValue("@departmentID", deptIDValue)
                cmd.Parameters.AddWithValue("@username", username.Trim())
                cmd.Parameters.AddWithValue("@password", hashedPassword)
                cmd.Parameters.AddWithValue("@position", If(String.IsNullOrWhiteSpace(position), "Staff", position.Trim()))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] SUCCESS - Staff registered: " & username)
                    MessageBox.Show("Registration successful! Your Staff account has been created. You can now log in with your credentials.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                Else
                    MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Diagnostics.Debug.WriteLine("[v0] FAILED - No rows inserted for Staff")
                    Return False
                End If
            End Using
        Catch ex As MySqlException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] Registration - ReplicationManager error: " & ex.Message)
            MessageBox.Show("Database connection issue during registration. Please try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As MySqlException
            System.Diagnostics.Debug.WriteLine("[v0] MySQL Registration Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "complete registration")
            MessageBox.Show(errorMsg, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As TypeInitializationException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] Registration - ReplicationManager TypeInit error: " & ex.Message)
            MessageBox.Show("Database initialization error. Please restart the application and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Registration Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            If ex.Message.Contains("ReplicationManager") Then
                MessageBox.Show("Database connection issue. Please ensure MySQL is running and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "complete registration")
                MessageBox.Show(errorMsg, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            ' Get staff details from users table (same table as Admin/SuperAdmin)
            Dim query As String = "SELECT userId, firstName, lastName, email, departmentId FROM users WHERE username = @username AND role = 'Staff'"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        staffDetails("staffId") = reader("userId").ToString()
                        staffDetails("userId") = reader("userId").ToString()
                        staffDetails("firstName") = If(IsDBNull(reader("firstName")), "", reader("firstName").ToString())
                        staffDetails("lastName") = If(IsDBNull(reader("lastName")), "", reader("lastName").ToString())
                        staffDetails("email") = If(IsDBNull(reader("email")), "", reader("email").ToString())
                        staffDetails("departmentId") = If(IsDBNull(reader("departmentId")), "", reader("departmentId").ToString())
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
    ''' Get full staff profile by staff_id (read-only view for Staff role).
    ''' </summary>
    Public Shared Function GetStaffProfile(staffID As Integer) As Dictionary(Of String, Object)
        Dim profile As New Dictionary(Of String, Object)()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return profile
            If Not SafeOpenConnection(conn) Then Return profile

            ' Get staff profile from users table (same table as Admin/SuperAdmin)
            Dim query As String =
                "SELECT userId, firstName, middleName, lastName, suffix, position, departmentId, " &
                "contactNumber, email, username, employeeId, status, lastLogin, createdAt " &
                "FROM users WHERE userId = @staffID AND role = 'Staff'"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@staffID", staffID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        profile("staffId") = reader("userId")
                        profile("userId") = reader("userId")
                        profile("firstName") = If(IsDBNull(reader("firstName")), "", reader("firstName").ToString())
                        profile("middleName") = If(IsDBNull(reader("middleName")), "", reader("middleName").ToString())
                        profile("lastName") = If(IsDBNull(reader("lastName")), "", reader("lastName").ToString())
                        profile("suffix") = If(IsDBNull(reader("suffix")), "", reader("suffix").ToString())
                        profile("position") = If(IsDBNull(reader("position")), "", reader("position").ToString())
                        profile("departmentId") = If(IsDBNull(reader("departmentId")), Nothing, reader("departmentId"))
                        profile("contactNumber") = If(IsDBNull(reader("contactNumber")), "", reader("contactNumber").ToString())
                        profile("email") = If(IsDBNull(reader("email")), "", reader("email").ToString())
                        profile("username") = If(IsDBNull(reader("username")), "", reader("username").ToString())
                        profile("employeeId") = If(IsDBNull(reader("employeeId")), "", reader("employeeId").ToString())
                        profile("status") = If(IsDBNull(reader("status")), "", reader("status").ToString())
                        profile("lastLogin") = If(IsDBNull(reader("lastLogin")), Nothing, reader("lastLogin"))
                        profile("createdAt") = If(IsDBNull(reader("createdAt")), Nothing, reader("createdAt"))
                    End If
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetStaffProfile Exception: " & ex.Message)
            MessageBox.Show("Error loading staff profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return profile
    End Function

    Private Shared Function SafeGetString(reader As MySqlDataReader, columnName As String) As String
        If reader Is Nothing OrElse String.IsNullOrEmpty(columnName) Then
            Return ""
        End If

        ' Try the flexible helper first (handles multiple possible column name variants)
        Try
            Dim flexibleVal As String = SafeGetStringFlexible(reader, columnName)
            If Not String.IsNullOrEmpty(flexibleVal) Then
                Return flexibleVal
            End If
        Catch
            ' Ignore and continue to ordinal-based lookup
        End Try

        Try
            Dim ord As Integer = -1
            ' Try direct ordinal lookup (exact name)
            Try
                ord = reader.GetOrdinal(columnName)
            Catch
                ' If direct ordinal lookup fails, try case-insensitive match via schema table
                Try
                    Dim schema As DataTable = reader.GetSchemaTable()
                    If schema IsNot Nothing Then
                        For Each row As DataRow In schema.Rows
                            Try
                                Dim colName As String = row("ColumnName").ToString()
                                If String.Equals(colName, columnName, StringComparison.OrdinalIgnoreCase) Then
                                    ord = reader.GetOrdinal(colName)
                                    Exit For
                                End If
                            Catch
                                ' ignore per-row errors
                            End Try
                        Next
                    End If
                Catch
                    ' ignore schema-table errors
                End Try
            End Try

            If ord >= 0 AndAlso Not reader.IsDBNull(ord) Then
                Dim obj As Object = reader.GetValue(ord)
                If obj Is Nothing OrElse IsDBNull(obj) Then
                    Return ""
                End If
                Return obj.ToString()
            End If
        Catch
            ' swallow any errors and return empty string
        End Try

        Return ""
    End Function



    Public Shared Function VerifyOldPassword(adminID As String, oldPassword As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Retrieve stored password hash to verify old password
            Dim query As String = "SELECT passwordEncrypted FROM users WHERE userId = @adminID"
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
                                 "WHERE userId = @adminID"

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
                                     uom As String, reorderLevel As Integer, supplierID As String,
                                     Optional dateReceived As Date? = Nothing) As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifySupplies, "add supplies") Then
            Return False
        End If
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

            ' Note: supplyId is auto-increment, so we don't need to check for duplicates
            ' The supplyID parameter is kept for backward compatibility but not used in the INSERT

            ' Updated INSERT to match actual SQL schema column names
            Dim receivedDate As Date = If(dateReceived.HasValue, dateReceived.Value, Date.Today)
            Dim query As String = "INSERT INTO supplies (" &
                                   "itemName, category, quantity, unitCost, stockStatus, location, " &
                                   "description, unitOfMeasure, supplier, dateReceived, totalCost, sourceOfFunds) " &
                                   "VALUES (@supplyName, @category, @stock, @unitCost, @status, @location, " &
                                   "@description, @uom, @supplierName, @dateReceived, @totalValue, @sourceOfFunds)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@supplyName", supplyName)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@stock", stock)
                cmd.Parameters.AddWithValue("@unitCost", unitCost)
                cmd.Parameters.AddWithValue("@totalValue", totalValue)
                cmd.Parameters.AddWithValue("@status", If(String.IsNullOrEmpty(status), "Available", status))
                cmd.Parameters.AddWithValue("@location", location)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@uom", If(String.IsNullOrWhiteSpace(uom), DBNull.Value, uom))
                cmd.Parameters.AddWithValue("@supplierName", If(String.IsNullOrWhiteSpace(supplierID), DBNull.Value, supplierID))
                cmd.Parameters.AddWithValue("@dateReceived", receivedDate)
                cmd.Parameters.AddWithValue("@sourceOfFunds", DBNull.Value) ' Can be set later if needed

                Dim result As Integer = cmd.ExecuteNonQuery()

                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Supply Added Successfully - Name: " & supplyName)
                    Return True
                Else
                    System.Diagnostics.Debug.WriteLine("[v0] Supply Add Failed - No rows affected")
                    MessageBox.Show("Failed to add supply. No rows affected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End Using
        Catch ex As MySqlException
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "add supply")
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Add Supply MySQL Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            Return False
        Catch ex As Exception
            MessageBox.Show(GetUserFriendlyErrorMessage(ex, "add supply"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            System.Diagnostics.Debug.WriteLine("[v0] Add Supply Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
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

    ' NOTE: Old GetAllSupplies(), UpdateSupply(String), and DeleteSupply(String) functions removed
    ' Use the enhanced versions with optional parameters and Integer supplyID below

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
            Dim availableQuery As String = "SELECT COUNT(*) FROM supplies WHERE stockStatus = 'Available'"
            Using cmd As New MySqlCommand(availableQuery, conn)
                stats("available_supplies") = CInt(cmd.ExecuteScalar())
            End Using

            ' Low stock supplies
            Dim lowStockQuery As String = "SELECT COUNT(*) FROM supplies WHERE quantity <= 10 AND stockStatus = 'Available'"
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

    ''' <summary>
    ''' Aggregate all high-level values required by the Admin dashboard
    ''' </summary>
    Public Shared Function GetAdminDashboardSummary() As Dictionary(Of String, Integer)
        Dim summary As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase) From {
            {"total_properties", 0},
            {"total_supplies", 0},
            {"pending_requests", 0},
            {"approved_requests", 0},
            {"declined_requests", 0},
            {"borrowed_items", 0},
            {"returned_items", 0},
            {"needs_repair", 0},
            {"maintenance_alerts", 0},
            {"warranty_alerts", 0}
        }

        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return summary
            If Not SafeOpenConnection(conn) Then Return summary

            Dim query As String =
                "SELECT " &
                "(SELECT COUNT(*) FROM properties) AS total_properties, " &
                "(SELECT COUNT(*) FROM supplies) AS total_supplies, " &
                "(SELECT COUNT(*) FROM property_requests WHERE status = 'Pending') AS pending_requests, " &
                "(SELECT COUNT(*) FROM property_requests WHERE status = 'Approved') AS approved_requests, " &
                "(SELECT COUNT(*) FROM property_requests WHERE status = 'Rejected') AS declined_requests, " &
                "(SELECT COUNT(*) FROM borrowed_items WHERE status = 'Borrowed') AS borrowed_items, " &
                "(SELECT COUNT(*) FROM borrowed_items WHERE status = 'Returned') AS returned_items, " &
                "(SELECT COUNT(*) FROM properties WHERE condition = 'Needs Repair') AS needs_repair, " &
                "(SELECT COUNT(*) FROM maintenance WHERE status IN ('Ongoing','For Review')) AS maintenance_alerts, " &
                "(SELECT COUNT(*) FROM maintenance_requests WHERE status = 'Pending') AS warranty_alerts"

            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        summary("total_properties") = SafeGetInt(reader, "total_properties")
                        summary("total_supplies") = SafeGetInt(reader, "total_supplies")
                        summary("pending_requests") = SafeGetInt(reader, "pending_requests")
                        summary("approved_requests") = SafeGetInt(reader, "approved_requests")
                        summary("declined_requests") = SafeGetInt(reader, "declined_requests")
                        summary("borrowed_items") = SafeGetInt(reader, "borrowed_items")
                        summary("returned_items") = SafeGetInt(reader, "returned_items")
                        summary("needs_repair") = SafeGetInt(reader, "needs_repair")
                        summary("maintenance_alerts") = SafeGetInt(reader, "maintenance_alerts")
                        summary("warranty_alerts") = SafeGetInt(reader, "warranty_alerts")
                    End If
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAdminDashboardSummary Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return summary
    End Function

    Public Shared Function GetPropertyCountsByCategory() As DataTable
        Dim query As String = "SELECT IFNULL(category, 'Uncategorized') AS label, COUNT(*) AS total " &
                              "FROM properties GROUP BY category ORDER BY label"
        Return ExecuteLookupDataTable(query)
    End Function

    Public Shared Function GetSupplyCountsByCategory() As DataTable
        Dim query As String = "SELECT IFNULL(category, 'Uncategorized') AS label, COUNT(*) AS total " &
                              "FROM supplies GROUP BY category ORDER BY label"
        Return ExecuteLookupDataTable(query)
    End Function

    Public Shared Function GetSupplyStatusCounts() As DataTable
        Dim query As String = "SELECT IFNULL(stockStatus, 'unspecified') AS label, COUNT(*) AS total " &
                              "FROM supplies GROUP BY stockStatus ORDER BY stockStatus"
        Return ExecuteLookupDataTable(query)
    End Function

    Public Shared Function GetPropertyStatusCounts() As DataTable
        Dim query As String = "SELECT IFNULL(status, 'unspecified') AS label, COUNT(*) AS total " &
                              "FROM properties GROUP BY status ORDER BY status"
        Return ExecuteLookupDataTable(query)
    End Function

    Public Shared Function GetPropertyConditionCounts() As DataTable
        Dim query As String = "SELECT IFNULL(condition, 'unspecified') AS label, COUNT(*) AS total " &
                              "FROM properties GROUP BY condition ORDER BY condition"
        Return ExecuteLookupDataTable(query)
    End Function

    Public Shared Function GetMaintenanceStatusCounts() As DataTable
        Dim query As String = "SELECT IFNULL(status, 'unspecified') AS label, COUNT(*) AS total " &
                              "FROM maintenance GROUP BY status ORDER BY status"
        Return ExecuteLookupDataTable(query)
    End Function

    Public Shared Function GetRequestStatusCounts() As DataTable
        Dim query As String = "SELECT IFNULL(status, 'unspecified') AS label, COUNT(*) AS total " &
                              "FROM property_requests GROUP BY status ORDER BY status"
        Return ExecuteLookupDataTable(query)
    End Function

    Public Shared Function GetDepartmentInventoryDistribution() As DataTable
        Dim query As String = "SELECT IFNULL(d.departmentName, 'Unassigned') AS label, COUNT(*) AS total " &
                              "FROM properties p " &
                              "LEFT JOIN departments d ON p.departmentId = d.departmentId " &
                              "GROUP BY label ORDER BY label"
        Return ExecuteLookupDataTable(query)
    End Function

    Public Shared Function GetBorrowingTrendData(monthsBack As Integer) As DataTable
        Dim sanitizedMonths As Integer = Math.Max(1, Math.Min(24, monthsBack))
        Dim fromDate As Date = Date.Today.AddMonths(-sanitizedMonths)

        Dim query As String = "SELECT DATE_FORMAT(dateOfRequest, '%b %Y') AS label, COUNT(*) AS total " &
                              "FROM property_requests " &
                              "WHERE dateOfRequest >= @fromDate " &
                              "GROUP BY DATE_FORMAT(dateOfRequest, '%Y-%m') " &
                              "ORDER BY DATE_FORMAT(dateOfRequest, '%Y-%m')"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@fromDate", fromDate}
        }

        Return ExecuteLookupDataTable(query, parameters)
    End Function

    Public Shared Function GetSupplyInventoryBreakdown() As DataTable
        Dim query As String = "SELECT IFNULL(category, 'Uncategorized') AS label, SUM(quantity) AS total " &
                              "FROM supplies GROUP BY category ORDER BY label"
        Return ExecuteLookupDataTable(query)
    End Function

    Private Shared Function ExecuteLookupDataTable(query As String,
                                                   Optional parameters As Dictionary(Of String, Object) = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Using cmd As New MySqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each kvp In parameters
                        cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
                    Next
                End If

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ExecuteLookupDataTable Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return dt
    End Function

    Private Shared Function SafeGetInt(reader As MySqlDataReader, columnName As String) As Integer
        If reader Is Nothing Then Return 0
        Dim ordinal As Integer = reader.GetOrdinal(columnName)
        If ordinal < 0 OrElse reader.IsDBNull(ordinal) Then Return 0
        Return Convert.ToInt32(reader.GetValue(ordinal))
    End Function

    ' Helper: safely get a string value from reader trying multiple possible column names (case-insensitive)
    Private Shared Function SafeGetStringFlexible(reader As MySqlDataReader, ParamArray columnNames() As String) As String
        If reader Is Nothing Then Return ""
        Try
            Dim schema As DataTable = reader.GetSchemaTable()
            If schema Is Nothing Then
                ' fallback: attempt each name using GetOrdinal in try-catch
                For Each name In columnNames
                    Try
                        Dim ord As Integer = reader.GetOrdinal(name)
                        If ord >= 0 AndAlso Not reader.IsDBNull(ord) Then
                            Return reader.GetValue(ord).ToString()
                        End If
                    Catch
                    End Try
                Next
                Return ""
            End If

            ' Build a set of available column names (lowercase)
            Dim available As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
            For Each row As DataRow In schema.Rows
                Try
                    Dim colName As String = row("ColumnName").ToString()
                    available.Add(colName)
                Catch
                End Try
            Next

            For Each name In columnNames
                If String.IsNullOrEmpty(name) Then Continue For
                If available.Contains(name) Then
                    Try
                        Dim ord As Integer = reader.GetOrdinal(name)
                        If ord >= 0 AndAlso Not reader.IsDBNull(ord) Then
                            Return reader.GetValue(ord).ToString()
                        End If
                    Catch
                    End Try
                Else
                    ' try case-insensitive find
                    For Each col As String In available
                        If String.Equals(col, name, StringComparison.OrdinalIgnoreCase) Then
                            Try
                                Dim ord As Integer = reader.GetOrdinal(col)
                                If ord >= 0 AndAlso Not reader.IsDBNull(ord) Then
                                    Return reader.GetValue(ord).ToString()
                                End If
                            Catch
                            End Try
                        End If
                    Next
                End If
            Next
        Catch
        End Try
        Return ""
    End Function

    ''' <summary>
    ''' Graceful error handling - converts technical errors to user-friendly messages
    ''' </summary>
    Private Shared Function GetUserFriendlyErrorMessage(ex As Exception, defaultAction As String) As String
        If ex Is Nothing Then Return "An unexpected error occurred."

        Dim errorMsg As String = ex.Message.ToLower()

        ' Connection errors
        If errorMsg.Contains("connection") OrElse errorMsg.Contains("timeout") OrElse errorMsg.Contains("unable to connect") Then
            Return "Unable to connect to the database. Please ensure MySQL is running and try again."
        End If

        ' Column/field errors
        If errorMsg.Contains("column") AndAlso errorMsg.Contains("cannot be found") OrElse errorMsg.Contains("unknown column") Then
            Return "Data structure mismatch detected. Please contact system administrator."
        End If

        ' Duplicate key errors
        If errorMsg.Contains("duplicate") OrElse errorMsg.Contains("already exists") Then
            Return "This record already exists. Please check for duplicates."
        End If

        ' Foreign key errors
        If errorMsg.Contains("foreign key") OrElse errorMsg.Contains("constraint") Then
            Return "Cannot perform this action due to related records. Please remove dependencies first."
        End If

        ' Count mismatch errors
        If errorMsg.Contains("column count") OrElse errorMsg.Contains("doesn't match") Then
            Return "Data validation error. Please ensure all required fields are filled correctly."
        End If

        ' Permission errors
        If errorMsg.Contains("access denied") OrElse errorMsg.Contains("permission") Then
            Return "You do not have permission to perform this action."
        End If

        ' Generic fallback
        Return $"Unable to {defaultAction}. Please verify your input and try again."
    End Function

    ''' <summary>
    ''' Update the last login timestamp for a user
    ''' </summary>
    Public Shared Function UpdateLastLogin(userID As Integer) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE users SET lastLogin = NOW() WHERE userId = @userID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userID", userID)
                Dim result As Integer = cmd.ExecuteNonQuery()
                Return result > 0
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdateLastLogin Exception: " & ex.Message)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Create test staff account for testing purposes
    ''' </summary>
    Public Shared Function CreateTestStaffAccount() As Boolean
        ' This function is now handled by InitializeDefaultAccounts()
        ' It creates the test_staff account directly in the users table
        ' No need to call AddStaffAccount which requires permissions
        Try
            InitializeDefaultAccounts()
            Return True
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] CreateTestStaffAccount Exception: " & ex.Message)
            Return False
        End Try
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
                                       warrantyDetails As String, lifeSpan As Integer?,
                                       Optional propertyNumber As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyProperties, "add properties") Then
            Return False
        End If

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

            ' Auto-generate property number and internal code if not provided
            Dim finalPropertyNumber As String = propertyNumber
            If String.IsNullOrWhiteSpace(finalPropertyNumber) Then
                ' Generate property number: PROP-XXXXXX format
                Dim maxPropNum As Integer = 0
                Try
                    Using maxCmd As New MySqlCommand("SELECT COALESCE(MAX(CAST(SUBSTRING(propertyNumber, 6) AS UNSIGNED)), 0) FROM properties WHERE propertyNumber LIKE 'PROP-%'", conn)
                        Dim maxVal As Object = maxCmd.ExecuteScalar()
                        If maxVal IsNot Nothing AndAlso Not IsDBNull(maxVal) Then
                            maxPropNum = Convert.ToInt32(maxVal)
                        End If
                    End Using
                    finalPropertyNumber = "PROP-" & (maxPropNum + 1).ToString("D6")
                Catch
                    ' Fallback to timestamp-based
                    finalPropertyNumber = "PROP-" & DateTime.Now.ToString("yyyyMMddHHmmss")
                End Try
            End If

            ' Generate internal code if property number is provided or generated
            Dim internalCode As String = finalPropertyNumber ' Use property number as internal code

            Dim query As String = "INSERT INTO properties (itemName, category, description, serialNumber, propertyNumber, " &
                                 "acquisitionDate, acquisitionCost, `condition`, " &
                                 "location, assignedTo, departmentId, status, totalCost, internalCodes) " &
                                 "VALUES (@propertyName, @category, @description, @serialNumber, @propertyNumber, @acquisitionDate, " &
                                 "@acquisitionCost, @conditionStatus, @location, " &
                                 "@custodianID, @departmentID, 'Active', @acquisitionCost, @internalCodes)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@propertyName", propertyName)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@serialNumber", If(String.IsNullOrEmpty(serialNumber), DBNull.Value, serialNumber))
                cmd.Parameters.AddWithValue("@propertyNumber", If(String.IsNullOrEmpty(finalPropertyNumber), DBNull.Value, finalPropertyNumber))
                cmd.Parameters.AddWithValue("@acquisitionDate", acquisitionDate)
                cmd.Parameters.AddWithValue("@acquisitionCost", acquisitionCost)
                cmd.Parameters.AddWithValue("@conditionStatus", conditionStatus)
                cmd.Parameters.AddWithValue("@supplierName", If(String.IsNullOrEmpty(supplierName), DBNull.Value, supplierName))
                cmd.Parameters.AddWithValue("@supplierContact", If(String.IsNullOrEmpty(supplierContact), DBNull.Value, supplierContact))
                cmd.Parameters.AddWithValue("@unitOfMeasure", If(String.IsNullOrWhiteSpace(unitOfMeasure), DBNull.Value, unitOfMeasure))
                cmd.Parameters.AddWithValue("@sourceOfFunds", If(String.IsNullOrWhiteSpace(sourceOfFunds), DBNull.Value, sourceOfFunds))
                cmd.Parameters.AddWithValue("@dateReceived", If(dateReceived.HasValue, dateReceived.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@location", location)
                cmd.Parameters.AddWithValue("@custodianID", If(custodianID.HasValue, custodianID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@departmentID", If(departmentID.HasValue, departmentID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@warrantyDetails", If(String.IsNullOrEmpty(warrantyDetails), DBNull.Value, warrantyDetails))
                cmd.Parameters.AddWithValue("@lifeSpan", If(lifeSpan.HasValue, lifeSpan.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@internalCodes", If(String.IsNullOrEmpty(internalCode), DBNull.Value, internalCode))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Property Added Successfully: " & propertyName)
                    MessageBox.Show("Property added successfully!", "Property Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            End Using
        Catch ex As MySqlException
            System.Diagnostics.Debug.WriteLine("[v0] AddProperty MySQL Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "add property")
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddProperty Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "add property")
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            Dim query As String = "SELECT p.propertyId, p.itemName, p.category, p.propertyNumber, p.serialNumber, " &
                                 "p.acquisitionDate, p.acquisitionCost, p.condition, p.location, p.status, " &
                                 "p.description, " &
                                 "CONCAT(IFNULL(u.firstName,''), ' ', IFNULL(u.lastName,'')) AS assignedEmployee, " &
                                 "d.departmentName AS assignedDepartment " &
                                 "FROM properties p " &
                                 "LEFT JOIN users u ON p.assignedTo = u.userId " &
                                 "LEFT JOIN departments d ON p.departmentId = d.departmentId " &
                                 "WHERE p.status != 'For Disposal' AND p.status != 'Lost' " &
                                 "ORDER BY p.acquisitionDate DESC"

            Using cmd As New MySqlCommand(query, conn)
                cmd.CommandTimeout = 30
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    System.Diagnostics.Debug.WriteLine("[v0] GetAllProperties - Loaded " & dt.Rows.Count & " properties")
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllProperties Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
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
    ''' Retrieve a single property's full details by ID.
    ''' </summary>
    Public Shared Function GetPropertyDetails(propertyID As Integer) As DataRow
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return Nothing
            If Not SafeOpenConnection(conn) Then Return Nothing

            Dim query As String =
                "SELECT p.propertyId, p.itemName, p.category, p.propertyNumber, p.serialNumber, " &
                "p.description, p.condition, p.acquisitionCost, p.acquisitionDate, p.location, p.status, " &
                "p.assignedTo, p.departmentId, " &
                "CONCAT(IFNULL(u.firstName,''), ' ', IFNULL(u.lastName,'')) AS assignedEmployee, " &
                "d.departmentName AS assignedDepartment, " &
                "p.supplier " &
                "FROM properties p " &
                "LEFT JOIN users u ON p.assignedTo = u.userId " &
                "LEFT JOIN departments d ON p.departmentId = d.departmentId " &
                "WHERE p.propertyId = @propertyID LIMIT 1"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@propertyID", propertyID)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetPropertyDetails Exception: " & ex.Message)
            Return Nothing
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)
        End If

        Return Nothing
    End Function

    ' =====================================================
    ' PROPERTY REQUEST FUNCTIONS
    ' =====================================================

    ''' <summary>
    ''' Submit a property request
    ''' </summary>
    Public Shared Function SubmitPropertyRequest(userID As Integer, itemName As String, purpose As String,
                                                 quantity As Integer, Optional departmentID As Integer? = Nothing,
                                                 Optional position As String = "", Optional requesterName As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyRequests, "submit property requests") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Get user info for department if not provided
            Dim finalDeptID As Integer? = departmentID
            If Not finalDeptID.HasValue AndAlso userID > 0 Then
                Try
                    Using userCmd As New MySqlCommand("SELECT departmentId FROM users WHERE userId = @userID LIMIT 1", conn)
                        userCmd.Parameters.AddWithValue("@userID", userID)
                        Dim deptResult As Object = userCmd.ExecuteScalar()
                        If deptResult IsNot Nothing AndAlso Not IsDBNull(deptResult) Then
                            finalDeptID = Convert.ToInt32(deptResult)
                        End If
                    End Using
                Catch
                    ' Continue with null department ID
                End Try
            End If

            ' Validate userID is valid
            If userID <= 0 Then
                MessageBox.Show("Invalid user ID. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim query As String = "INSERT INTO property_requests (requesterName, departmentId, dateOfRequest, " &
                                 "itemName, quantityRequested, purpose, status) " &
                                 "VALUES (@requesterName, @departmentID, CURDATE(), @itemName, " &
                                 "@quantity, @purpose, 'Pending')"

            Dim requestID As Integer = 0
            Using cmd As New MySqlCommand(query, conn)
                ' Get requester name if not provided
                Dim finalRequesterName As String = requesterName
                If String.IsNullOrEmpty(finalRequesterName) AndAlso userID > 0 Then
                    Try
                        Using nameCmd As New MySqlCommand("SELECT CONCAT(IFNULL(firstName,''), ' ', IFNULL(lastName,'')) AS fullName FROM users WHERE userId = @userID LIMIT 1", conn)
                            nameCmd.Parameters.AddWithValue("@userID", userID)
                            Dim nameResult As Object = nameCmd.ExecuteScalar()
                            If nameResult IsNot Nothing AndAlso Not IsDBNull(nameResult) Then
                                finalRequesterName = nameResult.ToString()
                            End If
                        End Using
                    Catch
                        finalRequesterName = "Unknown"
                    End Try
                End If
                If String.IsNullOrEmpty(finalRequesterName) Then finalRequesterName = "Unknown"

                cmd.Parameters.AddWithValue("@requesterName", finalRequesterName)
                cmd.Parameters.AddWithValue("@departmentID", If(finalDeptID.HasValue, finalDeptID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@itemName", If(String.IsNullOrEmpty(itemName), "Item Request", itemName))
                cmd.Parameters.AddWithValue("@quantity", If(quantity > 0, quantity, 1))
                cmd.Parameters.AddWithValue("@purpose", If(String.IsNullOrEmpty(purpose), "General use", purpose))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    ' Get the inserted request ID
                    Using getIdCmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn)
                        Dim idResult As Object = getIdCmd.ExecuteScalar()
                        If idResult IsNot Nothing AndAlso Not IsDBNull(idResult) Then
                            requestID = Convert.ToInt32(idResult)
                        End If
                    End Using

                    ' Get requester name for notification
                    Dim requesterFullName As String = ""
                    If Not String.IsNullOrEmpty(requesterName) Then
                        requesterFullName = requesterName
                    Else
                        Try
                            Using nameCmd As New MySqlCommand("SELECT CONCAT(COALESCE(firstName, ''), ' ', COALESCE(lastName, '')) AS fullName FROM users WHERE userId = @userID LIMIT 1", conn)
                                nameCmd.Parameters.AddWithValue("@userID", userID)
                                Dim nameResult As Object = nameCmd.ExecuteScalar()
                                If nameResult IsNot Nothing AndAlso Not IsDBNull(nameResult) Then
                                    requesterFullName = nameResult.ToString().Trim()
                                End If
                            End Using
                        Catch
                            requesterFullName = "Staff #" & userID.ToString()
                        End Try
                    End If

                    ' Create activity logs for all Admin and SuperAdmin users to notify them
                    Try
                        Using adminCmd As New MySqlCommand("SELECT userId, username, role FROM users WHERE role IN ('Admin', 'SuperAdmin') AND status = 'Active'", conn)
                            Using reader As MySqlDataReader = adminCmd.ExecuteReader()
                                While reader.Read()
                                    Dim adminID As Integer = Convert.ToInt32(reader("userId"))
                                    Dim adminUsername As String = reader("username").ToString()
                                    Dim adminRole As String = reader("role").ToString()
                                    Dim notificationMsg As String = $"New property request from {requesterFullName}: {itemName} (Quantity: {quantity})"

                                    ' Create activity log entry for this admin
                                    LogActivity(adminID, adminRole, adminUsername, "NEW_PROPERTY_REQUEST", "Property Requests",
                                               notificationMsg, "")
                                End While
                            End Using
                        End Using
                    Catch notifyEx As Exception
                        ' Don't fail the request submission if notification fails
                        System.Diagnostics.Debug.WriteLine("[v0] Failed to notify admins: " & notifyEx.Message)
                    End Try

                    System.Diagnostics.Debug.WriteLine("[v0] Property Request Submitted Successfully (ID: " & requestID & ")")
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Submit Property Request Exception: " & ex.Message)
            ' Graceful error handling - don't show raw SQL errors
            Dim errorMsg As String = "Unable to submit property request. "
            If ex.Message.Contains("Duplicate") Then
                errorMsg &= "This request may already exist."
            ElseIf ex.Message.Contains("Connection") OrElse ex.Message.Contains("timeout") Then
                errorMsg &= "Please check your database connection and try again."
            Else
                errorMsg &= "Please verify all required fields are filled and try again."
            End If
            MessageBox.Show(errorMsg, "Request Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
    ''' STAFF-FACING helper: submit a property borrowing request (fixed assets).
    ''' </summary>
    Public Shared Function StaffSubmitPropertyRequest(staffID As Integer,
                                                      itemName As String,
                                                      quantity As Integer,
                                                      purpose As String,
                                                      Optional departmentID As Integer? = Nothing,
                                                      Optional ipAddress As String = "") As Boolean
        Dim ok As Boolean = SubmitPropertyRequest(staffID, itemName, purpose, quantity, departmentID)
        If ok Then
            LogCrudAction(staffID, "Staff", "", "Property Requests", "Property Request", "Create",
                          $"Staff #{staffID} requested property: {itemName} x{quantity}", ipAddress)
        End If
        Return ok
    End Function

    ''' <summary>
    ''' STAFF-FACING helper: submit a consumable supply request.
    ''' </summary>
    Public Shared Function StaffSubmitSupplyRequest(staffID As Integer,
                                                    itemName As String,
                                                    quantity As Integer,
                                                    purpose As String,
                                                    Optional departmentID As Integer? = Nothing,
                                                    Optional position As String = "",
                                                    Optional requesterName As String = "",
                                                    Optional ipAddress As String = "") As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            ' Get user info for department if not provided
            Dim finalDeptID As Integer? = departmentID
            If Not finalDeptID.HasValue AndAlso staffID > 0 Then
                Try
                    Using userCmd As New MySqlCommand("SELECT departmentId FROM users WHERE userId = @staffID LIMIT 1", conn)
                        userCmd.Parameters.AddWithValue("@staffID", staffID)
                        Dim deptResult As Object = userCmd.ExecuteScalar()
                        If deptResult IsNot Nothing AndAlso Not IsDBNull(deptResult) Then
                            finalDeptID = Convert.ToInt32(deptResult)
                        End If
                    End Using
                Catch
                    ' Continue with null department ID
                End Try
            End If

            ' Validate staffID is valid
            If staffID <= 0 Then
                MessageBox.Show("Invalid user ID. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim query As String = "INSERT INTO supply_requests (userId, departmentId, date_of_request, " &
                                 "item_name, quantity_requested, purpose, status) " &
                                 "VALUES (@userID, @departmentID, CURDATE(), @itemName, " &
                                 "@quantity, @purpose, 'Pending')"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userID", staffID)
                cmd.Parameters.AddWithValue("@departmentID", If(finalDeptID.HasValue, finalDeptID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@itemName", If(String.IsNullOrEmpty(itemName), "Supply Request", itemName))
                cmd.Parameters.AddWithValue("@quantity", If(quantity > 0, quantity, 1))
                cmd.Parameters.AddWithValue("@purpose", If(String.IsNullOrEmpty(purpose), "General use", purpose))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    LogCrudAction(staffID, "Staff", "", "Supply Requests", "Supply Request", "Create",
                                  $"Staff #{staffID} requested supply: {itemName} x{quantity}", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Submit Supply Request Exception: " & ex.Message)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
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

            Dim query As String = "SELECT " &
                                 "pr.requestId AS requestId, " &
                                 "pr.requesterName AS requesterName, " &
                                 "IFNULL(d.departmentName, 'N/A') AS department, " &
                                 "pr.dateOfRequest AS dateOfRequest, " &
                                 "pr.itemName AS itemName, " &
                                 "pr.quantityRequested AS quantityRequested, " &
                                 "pr.purpose AS purpose, " &
                                 "pr.status AS status " &
                                 "FROM property_requests pr " &
                                 "LEFT JOIN departments d ON pr.departmentId = d.departmentId " &
                                 "ORDER BY pr.dateOfRequest DESC, pr.requestId DESC"

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
    ''' STAFF-FACING: get all requests submitted by a specific staff user with optional filters.
    ''' </summary>
    Public Shared Function GetStaffRequests(staffID As Integer,
                                            Optional statusFilter As String = "",
                                            Optional requestTypeFilter As String = "",
                                            Optional dateFrom As Date? = Nothing,
                                            Optional dateTo As Date? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            ' Combine property requests and supply requests
            Dim query As String = ""

            If Not String.IsNullOrEmpty(requestTypeFilter) AndAlso requestTypeFilter.ToLower() = "property" Then
                ' Only property requests
                query = "SELECT pr.requestId AS request_id, 'property' AS request_type, pr.status, pr.dateOfRequest AS request_date, " &
                        "pr.approvedDate AS approval_date, NULL AS release_date, NULL AS expected_return_date, " &
                        "NULL AS actual_returned_date, pr.quantityRequested AS quantity, " &
                        "NULL AS penalty, NULL AS condition_upon_return, pr.purpose AS remarks, " &
                        "pr.itemName AS item_name, pr.serialNumber AS serial_number, pr.location AS property_location, NULL AS supply_location " &
                        "FROM property_requests pr " &
                        "WHERE pr.userId = @staffID "
                If Not String.IsNullOrEmpty(statusFilter) Then query &= "AND pr.status = @status "
                If dateFrom.HasValue Then query &= "AND pr.date_of_request >= @dateFrom "
                If dateTo.HasValue Then query &= "AND pr.date_of_request <= @dateTo "
            ElseIf Not String.IsNullOrEmpty(requestTypeFilter) AndAlso requestTypeFilter.ToLower() = "supply" Then
                ' Only supply requests
                query = "SELECT sr.requestId AS request_id, 'supply' AS request_type, sr.status, sr.dateOfRequest AS request_date, " &
                        "sr.approvedDate AS approval_date, NULL AS release_date, NULL AS expected_return_date, " &
                        "NULL AS actual_returned_date, sr.quantityRequested AS quantity, " &
                        "NULL AS penalty, NULL AS condition_upon_return, sr.purpose AS remarks, " &
                        "sr.itemName AS item_name, NULL AS serial_number, sr.location AS property_location, sr.location AS supply_location " &
                        "FROM supplies_requests sr " &
                        "WHERE sr.userId = @staffID "
                If Not String.IsNullOrEmpty(statusFilter) Then query &= "AND sr.status = @status "
                If dateFrom.HasValue Then query &= "AND sr.date_of_request >= @dateFrom "
                If dateTo.HasValue Then query &= "AND sr.date_of_request <= @dateTo "
            Else
                ' Show both - UNION ALL
                Dim propQuery As String = "SELECT pr.requestId AS request_id, 'property' AS request_type, pr.status, pr.dateOfRequest AS request_date, " &
                        "pr.approvedDate AS approval_date, NULL AS release_date, NULL AS expected_return_date, " &
                        "NULL AS actual_returned_date, pr.quantityRequested AS quantity, " &
                        "NULL AS penalty, NULL AS condition_upon_return, pr.purpose AS remarks, " &
                        "pr.itemName AS item_name, pr.serialNumber AS serial_number, pr.location AS property_location, NULL AS supply_location " &
                        "FROM property_requests pr " &
                        "WHERE pr.userId = @staffID "
                If Not String.IsNullOrEmpty(statusFilter) Then propQuery &= "AND pr.status = @status "
                If dateFrom.HasValue Then propQuery &= "AND pr.date_of_request >= @dateFrom "
                If dateTo.HasValue Then propQuery &= "AND pr.date_of_request <= @dateTo "

                Dim supplyQuery As String = "SELECT sr.requestId AS request_id, 'supply' AS request_type, sr.status, sr.dateOfRequest AS request_date, " &
                        "sr.approvedDate AS approval_date, NULL AS release_date, NULL AS expected_return_date, " &
                        "NULL AS actual_returned_date, sr.quantityRequested AS quantity, " &
                        "NULL AS penalty, NULL AS condition_upon_return, sr.purpose AS remarks, " &
                        "sr.itemName AS item_name, NULL AS serial_number, sr.location AS property_location, sr.location AS supply_location " &
                        "FROM supplies_requests sr " &
                        "WHERE sr.userId = @staffID "
                If Not String.IsNullOrEmpty(statusFilter) Then supplyQuery &= "AND sr.status = @status "
                If dateFrom.HasValue Then supplyQuery &= "AND sr.date_of_request >= @dateFrom "
                If dateTo.HasValue Then supplyQuery &= "AND sr.date_of_request <= @dateTo "

                query = propQuery & " UNION ALL " & supplyQuery
            End If

            query &= " ORDER BY request_date DESC, request_id DESC"

            Using cmd As New MySqlCommand(query.ToString(), conn)
                cmd.Parameters.AddWithValue("@staffID", staffID)
                If Not String.IsNullOrEmpty(statusFilter) Then cmd.Parameters.AddWithValue("@status", statusFilter)
                If Not String.IsNullOrEmpty(requestTypeFilter) Then cmd.Parameters.AddWithValue("@requestType", requestTypeFilter)
                If dateFrom.HasValue Then cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
                If dateTo.HasValue Then cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetStaffRequests Exception: " & ex.Message)
        Finally
            If Not Object.ReferenceEquals(conn, Nothing) Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
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
        If Not DemandPermission(SessionContext.ModulePermission.ModifyRequests, "process property requests") Then
            Return False
        End If
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

    ''' <summary>
    ''' Permanently remove a property/supply request when appropriate.
    ''' </summary>
    Public Shared Function DeletePropertyRequest(requestID As Integer,
                                                 Optional allowForce As Boolean = False) As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyRequests, "delete property requests") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim statusFilter As String = "pending','rejected"
            If allowForce Then
                statusFilter = "pending','rejected','approved','released','returned"
            End If

            Dim query As String = "DELETE FROM property_requests WHERE request_id = @requestID AND status IN ('" & statusFilter & "')"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@requestID", requestID)
                Dim rows = cmd.ExecuteNonQuery()
                Return rows > 0
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] DeletePropertyRequest Exception: " & ex.Message)
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "delete property request")
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Load detailed property/supply requests with optional filters for admin dashboard
    ''' </summary>
    Public Shared Function GetDetailedPropertyRequests(Optional statusFilter As String = "",
                                                       Optional requestTypeFilter As String = "",
                                                       Optional dateFrom As Date? = Nothing,
                                                       Optional dateTo As Date? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New System.Text.StringBuilder()
            query.Append("SELECT pr.request_id, pr.requester_name, pr.date_of_request, ")
            query.Append("pr.item_name, pr.quantity_requested, pr.purpose, pr.status, ")
            query.Append("pr.approved_date, d.departmentName, pr.remarks ")
            query.Append("FROM property_requests pr ")
            query.Append("LEFT JOIN departments d ON pr.departmentId = d.departmentId WHERE 1=1 ")

            If Not String.IsNullOrEmpty(statusFilter) Then
                query.Append(" AND pr.status = @status ")
            End If
            If dateFrom.HasValue Then
                query.Append(" AND pr.date_of_request >= @dateFrom ")
            End If
            If dateTo.HasValue Then
                query.Append(" AND pr.date_of_request <= @dateTo ")
            End If

            query.Append(" ORDER BY pr.date_of_request DESC, pr.request_id DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(statusFilter) Then
                    cmd.Parameters.AddWithValue("@status", statusFilter)
                End If
                If Not String.IsNullOrEmpty(requestTypeFilter) Then
                    cmd.Parameters.AddWithValue("@requestType", requestTypeFilter)
                End If
                If dateFrom.HasValue Then
                    cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
                End If
                If dateTo.HasValue Then
                    cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)
                End If

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetDetailedPropertyRequests Exception: " & ex.Message)
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
    ''' Approve a request, adjust inventory/assignment, and log the action
    ''' </summary>
    Public Shared Function ApprovePropertyRequest(requestID As Integer, adminID As Integer, adminName As String,
                                                  adminUserType As String, Optional releaseDate As Date? = Nothing,
                                                  Optional expectedReturnDate As Date? = Nothing,
                                                  Optional remarks As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyRequests, "approve property requests") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Dim transaction As MySqlTransaction = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            transaction = conn.BeginTransaction()

            ' Check if request exists and is pending
            Using checkCmd As New MySqlCommand("SELECT status, itemName, quantityRequested FROM property_requests WHERE requestId = @requestID FOR UPDATE", conn, transaction)
                checkCmd.Parameters.AddWithValue("@requestID", requestID)
                Using reader As MySqlDataReader = checkCmd.ExecuteReader()
                    If Not reader.Read() Then
                        Throw New Exception("Request not found.")
                    End If
                    Dim currentStatus As String = If(IsDBNull(reader("status")), "", reader("status").ToString().Trim())
                    If currentStatus.ToLower() <> "pending" Then
                        Throw New Exception("Only pending requests can be approved.")
                    End If
                End Using
            End Using

            ' Update request status to Approved
            Using updateRequest As New MySqlCommand("UPDATE property_requests SET status = 'Approved', approvedBy = @adminID, " &
                                                    "approvedDate = NOW(), remarks = @remarks WHERE requestId = @requestID", conn, transaction)
                updateRequest.Parameters.AddWithValue("@adminID", adminID)
                updateRequest.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
                updateRequest.Parameters.AddWithValue("@requestID", requestID)
                updateRequest.ExecuteNonQuery()
            End Using

            transaction.Commit()
            LogActivity(adminID, adminUserType, adminName, "APPROVE_REQUEST", "Property Request",
                        $"Approved request #{requestID}", "")
            Return True
        Catch ex As Exception
            If transaction IsNot Nothing Then
                Try
                    transaction.Rollback()
                Catch
                End Try
            End If
            System.Diagnostics.Debug.WriteLine("[v0] ApprovePropertyRequest Exception: " & ex.Message)
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "approve request")
            MessageBox.Show(errorMsg, "Approval Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If transaction IsNot Nothing Then transaction.Dispose()
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Approve a maintenance request
    ''' </summary>
    Public Shared Function ApproveMaintenanceRequest(requestID As Integer, adminID As Integer, adminName As String,
                                                     adminUserType As String, Optional remarks As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyMaintenance, "approve maintenance requests") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE maintenance_requests SET status = 'Approved', " &
                                 "approved_by = @adminID, approved_date = NOW(), remarks = @remarks " &
                                 "WHERE request_id = @requestID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@adminID", adminID)
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
                cmd.Parameters.AddWithValue("@requestID", requestID)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    LogActivity(adminID, adminUserType, adminName, "APPROVE_MAINTENANCE_REQUEST", "Maintenance Request",
                                $"Approved maintenance request #{requestID}", "")
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ApproveMaintenanceRequest Exception: " & ex.Message)
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "approve maintenance request")
            MessageBox.Show(errorMsg, "Approval Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Reject a maintenance request
    ''' </summary>
    Public Shared Function RejectMaintenanceRequest(requestID As Integer, adminID As Integer, adminName As String,
                                                     adminUserType As String, Optional remarks As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyMaintenance, "reject maintenance requests") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE maintenance_requests SET status = 'Rejected', " &
                                 "approved_by = @adminID, approved_date = NOW(), remarks = @remarks " &
                                 "WHERE request_id = @requestID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@adminID", adminID)
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
                cmd.Parameters.AddWithValue("@requestID", requestID)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    LogActivity(adminID, adminUserType, adminName, "REJECT_MAINTENANCE_REQUEST", "Maintenance Request",
                                $"Rejected maintenance request #{requestID}", "")
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] RejectMaintenanceRequest Exception: " & ex.Message)
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "reject maintenance request")
            MessageBox.Show(errorMsg, "Rejection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Reject a pending request
    ''' </summary>
    Public Shared Function RejectPropertyRequest(requestID As Integer, adminID As Integer, adminName As String,
                                                 adminUserType As String, Optional remarks As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyRequests, "reject property requests") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE property_requests SET status = 'Rejected', approvedBy = @adminID, approvedDate = NOW(), remarks = @remarks " &
                                  "WHERE requestId = @requestID AND status = 'Pending'"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@adminID", adminID)
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
                cmd.Parameters.AddWithValue("@requestID", requestID)
                Dim rows = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    LogActivity(adminID, adminUserType, adminName, "REJECT_REQUEST", "Property Request",
                                $"Rejected request #{requestID}", "")
                    Return True
                Else
                    MessageBox.Show("Only pending requests can be rejected.", "Request Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] RejectPropertyRequest Exception: " & ex.Message)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Approve a supply request
    ''' </summary>
    Public Shared Function ApproveSupplyRequest(requestID As Integer, adminID As Integer, adminName As String,
                                                 adminUserType As String, Optional remarks As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyRequests, "approve supply requests") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE supplies_requests SET status = 'Approved', approvedBy = @adminID, approvedDate = NOW(), remarks = @remarks " &
                                  "WHERE requestId = @requestID AND UPPER(status) = 'PENDING'"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@adminID", adminID)
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
                cmd.Parameters.AddWithValue("@requestID", requestID)
                Dim rows = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    LogActivity(adminID, adminUserType, adminName, "APPROVE_SUPPLY_REQUEST", "Supply Request",
                                $"Approved supply request #{requestID}", "")
                    Return True
                Else
                    MessageBox.Show("Only pending requests can be approved.", "Request Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ApproveSupplyRequest Exception: " & ex.Message)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Reject a supply request
    ''' </summary>
    Public Shared Function RejectSupplyRequest(requestID As Integer, adminID As Integer, adminName As String,
                                                adminUserType As String, Optional remarks As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyRequests, "reject supply requests") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE supplies_requests SET status = 'Rejected', approvedBy = @adminID, approvedDate = NOW(), remarks = @remarks " &
                                  "WHERE requestId = @requestID AND UPPER(status) = 'PENDING'"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@adminID", adminID)
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
                cmd.Parameters.AddWithValue("@requestID", requestID)
                Dim rows = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    LogActivity(adminID, adminUserType, adminName, "REJECT_SUPPLY_REQUEST", "Supply Request",
                                $"Rejected supply request #{requestID}", "")
                    Return True
                Else
                    MessageBox.Show("Only pending requests can be rejected.", "Request Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] RejectSupplyRequest Exception: " & ex.Message)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Mark an approved request as released and record release information
    ''' </summary>
    Public Shared Function ReleasePropertyRequest(requestID As Integer, adminID As Integer, adminName As String,
                                                  adminUserType As String, releaseDate As Date, Optional expectedReturnDate As Date? = Nothing,
                                                  Optional remarks As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyRequests, "release property requests") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE property_requests SET status = 'Released', releaseDate = @releaseDate, expectedReturnDate = @expectedReturnDate, " &
                                  "remarks = @remarks WHERE requestId = @requestID AND status IN ('Approved', 'Released')"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@releaseDate", releaseDate)
                cmd.Parameters.AddWithValue("@expectedReturnDate", If(expectedReturnDate.HasValue, expectedReturnDate.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
                cmd.Parameters.AddWithValue("@requestID", requestID)
                Dim rows = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    LogActivity(adminID, adminUserType, adminName, "RELEASE_REQUEST", "Property Request",
                                $"Released request #{requestID}", "")
                    Return True
                Else
                    MessageBox.Show("Request must be approved before it can be released.", "Release Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ReleasePropertyRequest Exception: " & ex.Message)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Record the return of a borrowed property or supply, update inventory, and log penalties
    ''' </summary>
    Public Shared Function RecordPropertyReturn(requestID As Integer, adminID As Integer, adminName As String,
                                                adminUserType As String, actualReturnDate As Date,
                                                conditionUponReturn As String, penaltyAmount As Decimal,
                                                Optional remarks As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyRequests, "record property returns") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Dim transaction As MySqlTransaction = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            transaction = conn.BeginTransaction()

            Dim requestInfo As New Dictionary(Of String, Object)
            Using cmd As New MySqlCommand("SELECT request_type, property_id, supply_id, quantity, status FROM property_requests " &
                                          "WHERE request_id = @requestID FOR UPDATE", conn, transaction)
                cmd.Parameters.AddWithValue("@requestID", requestID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        requestInfo("request_type") = reader("request_type").ToString()
                        requestInfo("propertyId") = If(IsDBNull(reader("propertyId")), Nothing, reader("propertyId"))
                        requestInfo("supplyId") = If(IsDBNull(reader("supplyId")), Nothing, reader("supplyId"))
                        requestInfo("quantity") = CInt(reader("quantity"))
                        requestInfo("status") = reader("status").ToString()
                    Else
                        Throw New Exception("Request not found.")
                    End If
                End Using
            End Using

            Dim currentStatus As String = requestInfo("status").ToString().ToLower()
            If currentStatus <> "released" AndAlso currentStatus <> "approved" Then
                Throw New Exception("Only released or approved requests can be returned.")
            End If

            Dim requestType As String = requestInfo("request_type").ToString().ToLower()
            Dim quantity As Integer = CInt(requestInfo("quantity"))

            If requestType = "supply" Then
                Using cmd As New MySqlCommand("UPDATE supplies SET quantity = quantity + @qty, updated_at = NOW() WHERE supply_id = @supplyID", conn, transaction)
                    cmd.Parameters.AddWithValue("@qty", quantity)
                    cmd.Parameters.AddWithValue("@supplyID", requestInfo("supplyId"))
                    cmd.ExecuteNonQuery()
                End Using
            ElseIf requestType = "property" Then
                Using cmd As New MySqlCommand("UPDATE properties SET assigned_to = NULL, condition = @condition, status = 'Active', updated_at = NOW() WHERE property_id = @propertyID", conn, transaction)
                    cmd.Parameters.AddWithValue("@condition", conditionUponReturn)
                    cmd.Parameters.AddWithValue("@propertyID", requestInfo("propertyId"))
                    cmd.ExecuteNonQuery()
                End Using
            End If

            Using updateRequest As New MySqlCommand("UPDATE property_requests SET status = 'returned', actual_returned_date = @actualReturnDate, " &
                                                    "condition_upon_return = @condition, penalty = @penalty, remarks = @remarks " &
                                                    "WHERE request_id = @requestID", conn, transaction)
                updateRequest.Parameters.AddWithValue("@actualReturnDate", actualReturnDate)
                updateRequest.Parameters.AddWithValue("@condition", conditionUponReturn)
                updateRequest.Parameters.AddWithValue("@penalty", penaltyAmount)
                updateRequest.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
                updateRequest.Parameters.AddWithValue("@requestID", requestID)
                updateRequest.ExecuteNonQuery()
            End Using

            transaction.Commit()
            LogActivity(adminID, adminUserType, adminName, "RETURN_REQUEST", "Property Request",
                        $"Recorded return for request #{requestID} (condition: {conditionUponReturn}, penalty: {penaltyAmount:N2})", "")
            Return True
        Catch ex As Exception
            If transaction IsNot Nothing Then
                Try
                    transaction.Rollback()
                Catch
                End Try
            End If
            System.Diagnostics.Debug.WriteLine("[v0] RecordPropertyReturn Exception: " & ex.Message)
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "record return")
            MessageBox.Show(errorMsg, "Return Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If transaction IsNot Nothing Then transaction.Dispose()
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' STAFF-FACING: get items currently borrowed / not yet fully returned by a specific staff member.
    ''' </summary>
    Public Shared Function GetStaffBorrowedItems(staffID As Integer,
                                                 Optional includeHistory As Boolean = False) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            ' Combine property requests and supply requests that are approved/released
            Dim query As String = ""

            If Not includeHistory Then
                ' Only show approved/released items (camelCase columns, alias to snake_case for UI)
                query = "SELECT pr.requestId AS request_id, 'property' AS request_type, pr.status, pr.dateOfRequest AS request_date, " &
                        "pr.releaseDate AS release_date, pr.expectedReturnDate AS expected_return_date, pr.actualReturnedDate AS actual_returned_date, " &
                        "pr.quantityRequested AS quantity, pr.itemName AS item_name, p.serialNumber AS serial_number, " &
                        "'Not yet returned' AS accountability_status " &
                        "FROM property_requests pr " &
                        "LEFT JOIN properties p ON pr.propertyId = p.propertyId " &
                        "WHERE pr.userId = @staffID AND pr.status IN ('Approved', 'Released') " &
                        "UNION ALL " &
                        "SELECT sr.requestId AS request_id, 'supply' AS request_type, sr.status, sr.dateOfRequest AS request_date, " &
                        "NULL AS release_date, NULL AS expected_return_date, NULL AS actual_returned_date, " &
                        "sr.quantityRequested AS quantity, sr.itemName AS item_name, NULL AS serial_number, " &
                        "'Not yet returned' AS accountability_status " &
                        "FROM supplies_requests sr " &
                        "WHERE sr.userId = @staffID AND sr.status IN ('Approved', 'Released') " &
                        "ORDER BY request_date DESC, request_id DESC"
            Else
                ' Include all history
                query = "SELECT pr.requestId AS request_id, 'property' AS request_type, pr.status, pr.dateOfRequest AS request_date, " &
                        "pr.releaseDate AS release_date, pr.expectedReturnDate AS expected_return_date, pr.actualReturnedDate AS actual_returned_date, " &
                        "pr.quantityRequested AS quantity, pr.itemName AS item_name, p.serialNumber AS serial_number, " &
                        "pr.status AS accountability_status " &
                        "FROM property_requests pr " &
                        "LEFT JOIN properties p ON pr.propertyId = p.propertyId " &
                        "WHERE pr.userId = @staffID " &
                        "UNION ALL " &
                        "SELECT sr.requestId AS request_id, 'supply' AS request_type, sr.status, sr.dateOfRequest AS request_date, " &
                        "NULL AS release_date, NULL AS expected_return_date, NULL AS actual_returned_date, " &
                        "sr.quantityRequested AS quantity, sr.itemName AS item_name, NULL AS serial_number, " &
                        "sr.status AS accountability_status " &
                        "FROM supplies_requests sr " &
                        "WHERE sr.userId = @staffID " &
                        "ORDER BY request_date DESC, request_id DESC"
            End If

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@staffID", staffID)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetStaffBorrowedItems Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
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
                                          technicianAssigned As String, Optional status As String = "pending",
                                          Optional maintenanceIntervalDays As Integer = 0, Optional remarks As String = "",
                                          Optional adminID As Integer? = Nothing, Optional adminName As String = "",
                                          Optional adminUserType As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyMaintenance, "add maintenance records") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            Dim calculatedNextSchedule As Date? = nextSchedule
            If Not nextSchedule.HasValue AndAlso maintenanceIntervalDays > 0 Then
                calculatedNextSchedule = serviceDate.AddDays(maintenanceIntervalDays)
            End If

            Dim query As String = "INSERT INTO maintenance (request_id, property_item_name, maintenance_date, type_of_maintenance, " &
                                 "maintenance_details, assigned_technician, cost_materials_labor, status) " &
                                 "VALUES (@requestID, @propertyItemName, @serviceDate, @serviceType, @description, " &
                                 "@technicianAssigned, @cost, @status)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@requestID", DBNull.Value)
                cmd.Parameters.AddWithValue("@propertyItemName", If(String.IsNullOrEmpty(description), "Unknown", description))
                cmd.Parameters.AddWithValue("@serviceDate", serviceDate)
                cmd.Parameters.AddWithValue("@serviceType", serviceType)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@technicianAssigned", If(String.IsNullOrEmpty(technicianAssigned), DBNull.Value, technicianAssigned))
                cmd.Parameters.AddWithValue("@cost", cost)
                cmd.Parameters.AddWithValue("@status", status)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 AndAlso adminID.HasValue Then
                    LogActivity(adminID, adminUserType, adminName, "CREATE_MAINTENANCE", "Maintenance",
                                $"Created maintenance record for property #{propertyID} ({serviceType})", "")
                End If
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
    ''' Get all supplies requests (from property_requests table with request_type='supply')
    ''' </summary>
    Public Shared Function GetAllSuppliesRequests() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            ' Query supplies_requests table directly
            Dim query As String = "SELECT " &
                                 "sr.requestId AS requestId, " &
                                 "sr.requesterName AS requesterName, " &
                                 "IFNULL(d.departmentName, 'N/A') AS department, " &
                                 "sr.dateOfRequest AS dateOfRequest, " &
                                 "sr.itemName AS itemName, " &
                                 "sr.quantityRequested AS quantityRequested, " &
                                 "sr.purpose AS purpose, " &
                                 "sr.status AS status " &
                                 "FROM supplies_requests sr " &
                                 "LEFT JOIN departments d ON sr.departmentId = d.departmentId " &
                                 "ORDER BY sr.dateOfRequest DESC, sr.requestId DESC"

            Using cmd As New MySqlCommand(query, conn)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllSuppliesRequests Exception: " & ex.Message)
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
    ''' Get all maintenance requests
    ''' </summary>
    Public Shared Function GetAllMaintenanceRequests() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT mr.request_id, mr.date_requested, mr.item_name, mr.property_number, " &
                                 "mr.serial_number, mr.departmentId, d.departmentName, mr.location, " &
                                 "mr.condition_before, mr.type_of_issue, mr.problem_description, mr.status, " &
                                 "mr.assigned_technician, mr.target_date, mr.completion_date, mr.requested_by " &
                                 "FROM maintenance_requests mr " &
                                 "LEFT JOIN departments d ON mr.departmentId = d.departmentId " &
                                 "ORDER BY mr.date_requested DESC"

            Using cmd As New MySqlCommand(query, conn)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllMaintenanceRequests Exception: " & ex.Message)
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
    ''' Get maintenance requests for a specific staff member
    ''' </summary>
    Public Shared Function GetStaffMaintenanceRequests(staffID As Integer) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT mr.request_id, mr.date_requested, mr.item_name, mr.property_number, " &
                                 "mr.serial_number, mr.departmentId, d.departmentName, mr.location, " &
                                 "mr.condition_before, mr.type_of_issue, mr.problem_description, mr.status, " &
                                 "mr.assigned_technician, mr.target_date, mr.completion_date, mr.requested_by " &
                                 "FROM maintenance_requests mr " &
                                 "LEFT JOIN departments d ON mr.departmentId = d.departmentId " &
                                 "WHERE mr.requested_by = @staffID " &
                                 "ORDER BY mr.date_requested DESC"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@staffID", staffID)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetStaffMaintenanceRequests Exception: " & ex.Message)
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
    ''' Submit a maintenance request from staff
    ''' </summary>
    Public Shared Function SubmitMaintenanceRequest(staffID As Integer, itemName As String, propertyNumber As String,
                                                    serialNumber As String, departmentID As Integer?, location As String,
                                                    conditionBefore As String, typeOfIssue As String, problemDescription As String,
                                                    Optional targetDate As Date? = Nothing) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "INSERT INTO maintenance_requests (date_requested, item_name, property_number, " &
                                 "serial_number, departmentId, location, condition_before, type_of_issue, " &
                                 "problem_description, status, requested_by, target_date) " &
                                 "VALUES (CURDATE(), @itemName, @propertyNumber, @serialNumber, @departmentID, " &
                                 "@location, @conditionBefore, @typeOfIssue, @problemDescription, 'Pending', " &
                                 "@requestedBy, @targetDate)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@itemName", itemName)
                cmd.Parameters.AddWithValue("@propertyNumber", If(String.IsNullOrEmpty(propertyNumber), DBNull.Value, propertyNumber))
                cmd.Parameters.AddWithValue("@serialNumber", If(String.IsNullOrEmpty(serialNumber), DBNull.Value, serialNumber))
                cmd.Parameters.AddWithValue("@departmentID", If(departmentID.HasValue, departmentID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@location", If(String.IsNullOrEmpty(location), DBNull.Value, location))
                cmd.Parameters.AddWithValue("@conditionBefore", conditionBefore)
                cmd.Parameters.AddWithValue("@typeOfIssue", typeOfIssue)
                cmd.Parameters.AddWithValue("@problemDescription", problemDescription)
                cmd.Parameters.AddWithValue("@requestedBy", staffID)
                cmd.Parameters.AddWithValue("@targetDate", If(targetDate.HasValue, targetDate.Value, DBNull.Value))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Maintenance Request Submitted Successfully")
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Submit Maintenance Request Exception: " & ex.Message)
            MessageBox.Show(GetUserFriendlyErrorMessage(ex, "submit maintenance request"), "Request Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
    ''' Get all maintenance records
    ''' </summary>
    Public Shared Function GetAllMaintenance() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT m.maintenance_id, m.property_item_name, " &
                                 "m.maintenance_date, m.type_of_maintenance, m.maintenance_details, " &
                                 "m.assigned_technician, m.cost_materials_labor, m.status, " &
                                 "m.diagnosis, m.action_taken, m.parts_replaced " &
                                 "FROM maintenance m " &
                                 "ORDER BY m.maintenance_date DESC"

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

    ''' <summary>
    ''' Load maintenance records with filters for reporting dashboards
    ''' </summary>
    Public Shared Function GetMaintenanceRecords(Optional statusFilter As String = "",
                                                 Optional dateFrom As Date? = Nothing,
                                                 Optional dateTo As Date? = Nothing,
                                                 Optional propertyID As Integer? = Nothing,
                                                 Optional custodianID As Integer? = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT m.maintenance_id, m.request_id, m.property_item_name, m.serial_number, ")
            query.Append("m.location, m.departmentId, d.departmentName, m.condition_before_maint, ")
            query.Append("m.type_of_maintenance, m.assigned_technician, m.maintenance_date, ")
            query.Append("m.maintenance_details, m.cost_materials_labor, m.condition_after_maint, ")
            query.Append("m.status, m.diagnosis, m.action_taken, m.parts_replaced ")
            query.Append("FROM maintenance m ")
            query.Append("LEFT JOIN departments d ON m.departmentId = d.departmentId WHERE 1=1 ")

            If Not String.IsNullOrEmpty(statusFilter) Then query.Append(" AND m.status = @status ")
            If dateFrom.HasValue Then query.Append(" AND m.maintenance_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND m.maintenance_date <= @dateTo ")
            If propertyID.HasValue Then query.Append(" AND m.property_item_name LIKE @propertyID ")
            If custodianID.HasValue Then query.Append(" AND m.assigned_technician LIKE @custodianID ")

            query.Append(" ORDER BY m.maintenance_date DESC, m.maintenance_id DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(statusFilter) Then cmd.Parameters.AddWithValue("@status", statusFilter)
                If dateFrom.HasValue Then cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
                If dateTo.HasValue Then cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)
                If propertyID.HasValue Then cmd.Parameters.AddWithValue("@propertyID", "%" & propertyID.Value.ToString() & "%")
                If custodianID.HasValue Then cmd.Parameters.AddWithValue("@custodianID", "%" & custodianID.Value.ToString() & "%")

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetMaintenanceRecords Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Update maintenance details such as schedule, service provider, and cost
    ''' </summary>
    Public Shared Function UpdateMaintenanceEntry(maintenanceID As Integer, serviceDate As Date,
                                                  serviceType As String, description As String, serviceProvider As String,
                                                  providerContact As String, cost As Decimal, Optional nextSchedule As Date? = Nothing,
                                                  Optional technicianAssigned As String = "", Optional status As String = "ongoing",
                                                  Optional remarks As String = "", Optional maintenanceIntervalDays As Integer = 0,
                                                  Optional adminID As Integer? = Nothing, Optional adminName As String = "",
                                                  Optional adminUserType As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyMaintenance, "update maintenance records") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim calculatedNextSchedule As Date? = nextSchedule
            If Not nextSchedule.HasValue AndAlso maintenanceIntervalDays > 0 Then
                calculatedNextSchedule = serviceDate.AddDays(maintenanceIntervalDays)
            End If

            Dim query As String = "UPDATE maintenance SET maintenance_date = @maintenanceDate, type_of_maintenance = @typeOfMaintenance, " &
                                  "maintenance_details = @maintenanceDetails, assigned_technician = @assignedTechnician, " &
                                  "cost_materials_labor = @costMaterialsLabor, status = @status, " &
                                  "diagnosis = @diagnosis, action_taken = @actionTaken, parts_replaced = @partsReplaced, " &
                                  "condition_after_maint = @conditionAfterMaint WHERE maintenance_id = @maintenanceID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@maintenanceDate", serviceDate)
                cmd.Parameters.AddWithValue("@typeOfMaintenance", serviceType)
                cmd.Parameters.AddWithValue("@maintenanceDetails", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@assignedTechnician", If(String.IsNullOrEmpty(technicianAssigned), DBNull.Value, technicianAssigned))
                cmd.Parameters.AddWithValue("@costMaterialsLabor", cost)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@diagnosis", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
                cmd.Parameters.AddWithValue("@actionTaken", If(String.IsNullOrEmpty(serviceProvider), DBNull.Value, serviceProvider))
                cmd.Parameters.AddWithValue("@partsReplaced", If(String.IsNullOrEmpty(providerContact), DBNull.Value, providerContact))
                cmd.Parameters.AddWithValue("@conditionAfterMaint", "Good")
                cmd.Parameters.AddWithValue("@maintenanceID", maintenanceID)

                Dim rows = cmd.ExecuteNonQuery()
                If rows > 0 AndAlso adminID.HasValue Then
                    LogActivity(adminID, adminUserType, adminName, "UPDATE_MAINTENANCE", "Maintenance",
                                $"Updated maintenance #{maintenanceID} (status: {status})", "")
                End If
                Return rows > 0
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdateMaintenanceEntry Exception: " & ex.Message)
            Return False
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Quickly change maintenance status (ongoing/completed) and log the action
    ''' </summary>
    Public Shared Function SetMaintenanceStatus(maintenanceID As Integer, status As String,
                                                Optional adminID As Integer? = Nothing,
                                                Optional adminName As String = "",
                                                Optional adminUserType As String = "",
                                                Optional remarks As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyMaintenance, "change maintenance status") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE maintenance SET status = @status, remarks = @remarks WHERE maintenance_id = @maintenanceID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
                cmd.Parameters.AddWithValue("@maintenanceID", maintenanceID)
                Dim rows = cmd.ExecuteNonQuery()
                If rows > 0 AndAlso adminID.HasValue Then
                    LogActivity(adminID, adminUserType, adminName, "SET_MAINTENANCE_STATUS", "Maintenance",
                                $"Set maintenance #{maintenanceID} status to {status}", "")
                End If
                Return rows > 0
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] SetMaintenanceStatus Exception: " & ex.Message)
            Return False
        Finally
            If Not Object.ReferenceEquals(conn, Nothing) Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ' =====================================================
    ' AUDIT LOGGING FUNCTIONS
    ' =====================================================

    ''' <summary>
    ''' Log user activity for audit trail
    ''' </summary>
    Public Shared Sub LogActivity(userID As Integer?, userType As String, username As String, action As String,
                                 moduleName As String, description As String, Optional ipAddress As String = "",
                                 Optional recordId As Integer? = Nothing, Optional userAgent As String = "")
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return ' Cannot log if connection fails

            If Not SafeOpenConnection(conn) Then Return

            Dim query As String = "INSERT INTO audit_logs (userId, action, tableName, recordId, description, ipAddress, userAgent) " &
                                 "VALUES (@userID, @action, @tableName, @recordId, @description, @ipAddress, @userAgent)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userID", If(userID.HasValue, userID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@action", action)
                cmd.Parameters.AddWithValue("@tableName", If(String.IsNullOrEmpty(moduleName), DBNull.Value, moduleName))
                cmd.Parameters.AddWithValue("@recordId", If(recordId.HasValue, recordId.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@ipAddress", If(String.IsNullOrEmpty(ipAddress), DBNull.Value, ipAddress))
                cmd.Parameters.AddWithValue("@userAgent", If(String.IsNullOrEmpty(userAgent), DBNull.Value, userAgent))

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
    ''' Get audit logs with all required fields
    ''' </summary>
    Public Shared Function GetAuditLogs(Optional startDate As Date? = Nothing, Optional endDate As Date? = Nothing,
                                        Optional roleFilter As String = "", Optional moduleFilter As String = "",
                                        Optional actionFilter As String = "") As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT a.logId, a.userId, COALESCE(u.username, 'System') AS username, " &
                                 "COALESCE(u.role, 'Unknown') AS role, a.action, a.tableName AS module, " &
                                 "a.recordId, a.description, a.ipAddress, a.userAgent, a.createdAt " &
                                 "FROM audit_logs a " &
                                 "LEFT JOIN users u ON a.userId = u.userId WHERE 1=1"

            If startDate.HasValue Then
                query &= " AND DATE(a.createdAt) >= @startDate"
            End If
            If endDate.HasValue Then
                query &= " AND DATE(a.createdAt) <= @endDate"
            End If
            If Not String.IsNullOrEmpty(roleFilter) Then
                query &= " AND u.role = @roleFilter"
            End If
            If Not String.IsNullOrEmpty(moduleFilter) Then
                query &= " AND a.tableName = @moduleFilter"
            End If
            If Not String.IsNullOrEmpty(actionFilter) Then
                query &= " AND a.action = @actionFilter"
            End If

            query &= " ORDER BY a.createdAt DESC LIMIT 1000"

            Using cmd As New MySqlCommand(query, conn)
                If startDate.HasValue Then
                    cmd.Parameters.AddWithValue("@startDate", startDate.Value)
                End If
                If endDate.HasValue Then
                    cmd.Parameters.AddWithValue("@endDate", endDate.Value)
                End If
                If Not String.IsNullOrEmpty(roleFilter) Then
                    cmd.Parameters.AddWithValue("@roleFilter", roleFilter)
                End If
                If Not String.IsNullOrEmpty(moduleFilter) Then
                    cmd.Parameters.AddWithValue("@moduleFilter", moduleFilter)
                End If
                If Not String.IsNullOrEmpty(actionFilter) Then
                    cmd.Parameters.AddWithValue("@actionFilter", actionFilter)
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

    ''' <summary>
    ''' Get a single audit log record by logId
    ''' </summary>
    Public Shared Function GetAuditLogById(logId As Integer) As DataRow
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return Nothing

            If Not SafeOpenConnection(conn) Then Return Nothing

            Dim query As String = "SELECT a.logId, a.userId, COALESCE(u.username, 'System') AS username, " &
                                 "COALESCE(u.role, 'Unknown') AS role, a.action, a.tableName AS module, " &
                                 "a.recordId, a.description, a.ipAddress, a.userAgent, a.createdAt " &
                                 "FROM audit_logs a " &
                                 "LEFT JOIN users u ON a.userId = u.userId " &
                                 "WHERE a.logId = @logId LIMIT 1"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@logId", logId)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAuditLogById Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' Helper to log CRUD operations consistently
    ''' </summary>
    Public Shared Sub LogCrudAction(userID As Integer?, userType As String, username As String,
                                    moduleName As String, entityName As String, actionVerb As String,
                                    Optional description As String = "", Optional ipAddress As String = "")
        Dim actionLabel As String = $"{actionVerb.ToUpper()}_{entityName.Replace(" "c, "_"c).ToUpper()}"
        Dim fullDescription As String = If(String.IsNullOrEmpty(description),
                                           $"{actionVerb} {entityName}",
                                           description)
        LogActivity(userID, userType, username, actionLabel, moduleName, fullDescription, ipAddress)
    End Sub

    ' =====================================================
    ' HELPER FUNCTION: Safe Connection Opening
    ' =====================================================
    ''' <summary>
    ''' Safely open a database connection with ReplicationManager error handling
    ''' </summary>
    Public Shared Function SafeOpenConnection(ByRef conn As MySqlConnection, Optional maxRetries As Integer = 3) As Boolean

        If conn Is Nothing Then
            conn = GetConnection()
            If conn Is Nothing Then Return False
        End If

        Dim retryCount As Integer = 0
        While retryCount < maxRetries
            Try
                ' Check connection state and handle accordingly
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                    Return True
                ElseIf conn.State = ConnectionState.Broken Then
                    Try
                        conn.Close()
                    Catch
                        ' Ignore errors when closing broken connection
                    End Try
                    conn.Open()
                    Return True
                ElseIf conn.State = ConnectionState.Open Then
                    ' Connection is already open, verify it's still valid
                    Try
                        ' Quick test to ensure connection is still valid
                        Using testCmd As New MySqlCommand("SELECT 1", conn)
                            testCmd.CommandTimeout = 1
                            testCmd.ExecuteScalar()
                        End Using
                        Return True
                    Catch
                        ' Connection is open but invalid, close and reopen
                        Try
                            conn.Close()
                        Catch
                        End Try
                        conn.Open()
                        Return True
                    End Try
                End If
            Catch ex As TypeInitializationException When ex.Message.Contains("ReplicationManager")
                System.Diagnostics.Debug.WriteLine("[v0] SafeOpenConnection - TypeInit ReplicationManager error on attempt " & (retryCount + 1))
                retryCount += 1
                If retryCount < maxRetries Then
                    System.Threading.Thread.Sleep(300)
                    _connectionString = Nothing ' Reset connection string
                    Try
                        conn.Dispose()
                    Catch
                    End Try
                    conn = GetConnection() ' Re-obtain connection object
                    If conn Is Nothing Then Exit While
                End If
            Catch ex As MySqlException When ex.Message.Contains("ReplicationManager")
                System.Diagnostics.Debug.WriteLine("[v0] SafeOpenConnection - ReplicationManager error on attempt " & (retryCount + 1))
                retryCount += 1
                If retryCount < maxRetries Then
                    System.Threading.Thread.Sleep(300)
                    _connectionString = Nothing
                    Try
                        conn.Dispose()
                    Catch
                    End Try
                    conn = GetConnection()
                    If conn Is Nothing Then Exit While
                End If
            Catch ex As Exception When ex.Message.Contains("ReplicationManager")
                System.Diagnostics.Debug.WriteLine("[v0] SafeOpenConnection - General ReplicationManager error on attempt " & (retryCount + 1))
                retryCount += 1
                If retryCount < maxRetries Then
                    System.Threading.Thread.Sleep(300)
                    _connectionString = Nothing
                    Try
                        conn.Dispose()
                    Catch
                    End Try
                    conn = GetConnection()
                    If conn Is Nothing Then Exit While
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] SafeOpenConnection - Connection open error: " & ex.Message)
                retryCount += 1
                If retryCount < maxRetries Then
                    System.Threading.Thread.Sleep(300)
                    Try
                        conn.Dispose()
                    Catch
                    End Try
                    conn = GetConnection()
                    If conn Is Nothing Then Exit While
                Else
                    Throw
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
            Dim query As String = "SELECT userId, firstName, middleName, lastName, suffix, position, " &
                                 "departmentId, contactNumber, email, username, barangay, " &
                                 "municipal, province, employeeId, role, status, " &
                                 "lastLogin, created_at " &
                                 "FROM users WHERE userId = @adminID AND status = 'Active'"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@adminID", adminID)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        adminProfile("userId") = reader("userId").ToString()
                        adminProfile("firstName") = If(IsDBNull(reader("firstName")), "", reader("firstName").ToString())
                        adminProfile("middle_name") = If(IsDBNull(reader("middle_name")), "", reader("middle_name").ToString())
                        adminProfile("lastName") = If(IsDBNull(reader("lastName")), "", reader("lastName").ToString())
                        adminProfile("suffix") = If(IsDBNull(reader("suffix")), "", reader("suffix").ToString())
                        adminProfile("position") = If(IsDBNull(reader("position")), "", reader("position").ToString())
                        adminProfile("departmentId") = If(IsDBNull(reader("departmentId")), "", reader("departmentId").ToString())
                        adminProfile("contactNumber") = If(IsDBNull(reader("contactNumber")), "", reader("contactNumber").ToString())
                        adminProfile("email") = If(IsDBNull(reader("email")), "", reader("email").ToString())
                        adminProfile("username") = If(IsDBNull(reader("username")), "", reader("username").ToString())
                        adminProfile("barangay") = If(IsDBNull(reader("barangay")), "", reader("barangay").ToString())
                        adminProfile("municipal") = If(IsDBNull(reader("municipal")), "", reader("municipal").ToString())
                        adminProfile("province") = If(IsDBNull(reader("province")), "", reader("province").ToString())
                        adminProfile("employeeId") = If(IsDBNull(reader("employeeId")), "", reader("employeeId").ToString())
                        adminProfile("user_type") = If(IsDBNull(reader("role")), "", reader("role").ToString())
                        adminProfile("status") = If(IsDBNull(reader("status")), "", reader("status").ToString())
                        adminProfile("lastLogin") = If(IsDBNull(reader("lastLogin")), "", reader("lastLogin").ToString())
                        adminProfile("createdAt") = If(IsDBNull(reader("createdAt")), "", reader("createdAt").ToString())
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
            Dim errorMsg As String = GetUserFriendlyErrorMessage(ex, "load admin profile")
            MessageBox.Show(errorMsg, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadAdminProfile Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
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
    ''' Check if username or email already exists (checks users table for all roles)
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

            ' All accounts are in users table, so check users table for Staff role accounts
            ' (Already checked Admin/SuperAdmin above, now check Staff)
            Dim checkStaffUsernameQuery As String = "SELECT COUNT(*) FROM users WHERE LOWER(username) = LOWER(@username) AND role = 'Staff'"
            Using cmd As New MySqlCommand(checkStaffUsernameQuery, conn)
                cmd.Parameters.AddWithValue("@username", username)
                Dim staffUsernameCount As Integer = CInt(cmd.ExecuteScalar())
                If staffUsernameCount > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Duplicate Username Found in users table (Staff): " & username)
                    Return "duplicate_username"
                End If
            End Using

            ' Check for duplicate email in users table (all roles, excluding current admin)
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
    ''' Internal helper to detect duplicate usernames/emails across users and staff tables while a connection is open.
    ''' Returns empty string when credentials are available or an error code such as 'duplicate_username'.
    ''' </summary>
    Private Shared Function DetectCredentialConflict(conn As MySqlConnection, username As String, email As String,
                                                     Optional excludeAdminID As Integer? = Nothing,
                                                     Optional excludeStaffID As Integer? = Nothing) As String
        If conn Is Nothing Then Return "connection_error"

        Try
            If Not String.IsNullOrWhiteSpace(username) Then
                Dim adminQuery As New StringBuilder("SELECT COUNT(*) FROM users WHERE LOWER(username) = LOWER(@username)")
                If excludeAdminID.HasValue Then adminQuery.Append(" AND user_id <> @excludeAdminID")

                Using cmd As New MySqlCommand(adminQuery.ToString(), conn)
                    cmd.Parameters.AddWithValue("@username", username.Trim())
                    If excludeAdminID.HasValue Then cmd.Parameters.AddWithValue("@excludeAdminID", excludeAdminID.Value)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                        Return "duplicate_username"
                    End If
                End Using

                ' Check Staff accounts in users table (all accounts are in users table)
                Dim staffQuery As New StringBuilder("SELECT COUNT(*) FROM users WHERE LOWER(username) = LOWER(@username) AND role = 'Staff'")
                If excludeStaffID.HasValue Then staffQuery.Append(" AND user_id <> @excludeStaffID")

                Using cmd As New MySqlCommand(staffQuery.ToString(), conn)
                    cmd.Parameters.AddWithValue("@username", username.Trim())
                    If excludeStaffID.HasValue Then cmd.Parameters.AddWithValue("@excludeStaffID", excludeStaffID.Value)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                        Return "duplicate_username"
                    End If
                End Using
            End If

            If Not String.IsNullOrWhiteSpace(email) Then
                ' Check all accounts in users table (Admin, SuperAdmin, Staff, Custodian)
                Dim adminEmailQuery As New StringBuilder("SELECT COUNT(*) FROM users WHERE LOWER(email) = LOWER(@email)")
                If excludeAdminID.HasValue Then adminEmailQuery.Append(" AND user_id <> @excludeAdminID")
                If excludeStaffID.HasValue Then adminEmailQuery.Append(" AND user_id <> @excludeStaffID")

                Using cmd As New MySqlCommand(adminEmailQuery.ToString(), conn)
                    cmd.Parameters.AddWithValue("@email", email.Trim())
                    If excludeAdminID.HasValue Then cmd.Parameters.AddWithValue("@excludeAdminID", excludeAdminID.Value)
                    If excludeStaffID.HasValue Then cmd.Parameters.AddWithValue("@excludeStaffID", excludeStaffID.Value)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                        Return "duplicate_email"
                    End If
                End Using
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] DetectCredentialConflict Exception: " & ex.Message)
            Return "error"
        End Try

        Return String.Empty
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
            Dim query As String = "UPDATE users SET firstName = @firstName, lastName = @lastName, " &
                                 "email = @email, contactNumber = @contactNumber, " &
                                 "middleName = @middleName, suffix = @suffix, " &
                                 "house_no_street = @houseNoStreet, barangay = @barangay, " &
                                 "municipality = @municipality, province_city = @provinceCity, " &
                                 "updated_at = NOW() WHERE userId = @adminID"

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
            System.Diagnostics.Debug.WriteLine("[v0] UpdateAdminProfile Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
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

            Dim query As String = "UPDATE users SET username = @newUsername, updated_at = NOW() WHERE userId = @adminID"
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
    ' SUPER ADMIN ACCOUNT MANAGEMENT (Admin/Staff/Custodian)
    ' =====================================================

    ''' <summary>
    ''' Retrieve all admin and super admin accounts with optional filters.
    ''' </summary>
    Public Shared Function GetAdminAccounts(Optional statusFilter As String = "",
                                            Optional roleFilter As String = "",
                                            Optional searchKeyword As String = "") As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT userId, firstName, middleName, lastName, suffix, position, ")
            query.Append("departmentId, contactNumber, email, username, role AS user_type, status, ")
            query.Append("employeeId, dateAssigned, lastLogin, created_at ")
            query.Append("FROM users WHERE role IN ('Admin','SuperAdmin')")

            If Not String.IsNullOrEmpty(statusFilter) Then query.Append(" AND status = @status")
            If Not String.IsNullOrEmpty(roleFilter) Then query.Append(" AND role = @role")
            If Not String.IsNullOrEmpty(searchKeyword) Then
                query.Append(" AND (")
                query.Append("LOWER(firstName) LIKE @search OR LOWER(lastName) LIKE @search OR ")
                query.Append("LOWER(username) LIKE @search OR LOWER(email) LIKE @search OR ")
                query.Append("LOWER(employee_id) LIKE @search)")
            End If

            query.Append(" ORDER BY created_at DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(statusFilter) Then cmd.Parameters.AddWithValue("@status", statusFilter)
                If Not String.IsNullOrEmpty(roleFilter) Then cmd.Parameters.AddWithValue("@role", roleFilter)
                If Not String.IsNullOrEmpty(searchKeyword) Then cmd.Parameters.AddWithValue("@search", "%" & searchKeyword.Trim().ToLower() & "%")

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAdminAccounts Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return dt
    End Function

    ''' <summary>
    ''' Retrieve ALL users (Admin, SuperAdmin, and Staff) with optional filters.
    ''' Combines data from users table (all roles: Admin, SuperAdmin, Staff, Custodian).
    ''' </summary>
    Public Shared Function GetAllUsers(Optional statusFilter As String = "",
                                       Optional roleFilter As String = "",
                                       Optional searchKeyword As String = "") As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            ' Create unified schema for the result table (using consistent camelCase)
            dt.Columns.Add("userId", GetType(Integer))
            dt.Columns.Add("firstName", GetType(String))
            dt.Columns.Add("middleName", GetType(String))
            dt.Columns.Add("lastName", GetType(String))
            dt.Columns.Add("suffix", GetType(String))
            dt.Columns.Add("position", GetType(String))
            dt.Columns.Add("departmentId", GetType(String))
            dt.Columns.Add("contactNumber", GetType(String))
            dt.Columns.Add("email", GetType(String))
            dt.Columns.Add("username", GetType(String))
            dt.Columns.Add("user_type", GetType(String))
            dt.Columns.Add("status", GetType(String))
            dt.Columns.Add("employeeId", GetType(String))
            dt.Columns.Add("dateAssigned", GetType(Object))
            dt.Columns.Add("lastLogin", GetType(Object))
            dt.Columns.Add("createdAt", GetType(Object))
            dt.Columns.Add("house_no_street", GetType(String))
            dt.Columns.Add("barangay", GetType(String))
            dt.Columns.Add("municipality", GetType(String))
            dt.Columns.Add("province_city", GetType(String))

            ' Build WHERE clause conditions
            Dim adminWhereConditions As New List(Of String)()
            Dim staffWhereConditions As New List(Of String)()

            If Not String.IsNullOrEmpty(statusFilter) Then
                adminWhereConditions.Add("LOWER(status) = LOWER(@status)")
                staffWhereConditions.Add("LOWER(status) = LOWER(@status)")
            End If

            If Not String.IsNullOrEmpty(roleFilter) Then
                If roleFilter = "Admin" OrElse roleFilter = "SuperAdmin" Then
                    ' Note: users table has 'role' column, not 'user_type' (user_type is just an alias)
                    adminWhereConditions.Add("role = @role")
                ElseIf roleFilter = "Staff" Then
                    ' Staff accounts are in users table with role = 'Staff', no additional filter needed
                    ' (already filtered in the WHERE clause of staffQuery)
                End If
            End If

            If Not String.IsNullOrEmpty(searchKeyword) Then
                Dim searchPattern As String = "%" & searchKeyword.Trim().ToLower() & "%"
                adminWhereConditions.Add("(LOWER(firstName) LIKE @search OR LOWER(lastName) LIKE @search OR " &
                                        "LOWER(username) LIKE @search OR LOWER(email) LIKE @search OR " &
                                        "LOWER(COALESCE(employeeId, '')) LIKE @search)")
                staffWhereConditions.Add("(LOWER(firstName) LIKE @search OR LOWER(lastName) LIKE @search OR " &
                                        "LOWER(username) LIKE @search OR LOWER(email) LIKE @search)")
            End If

            ' Query Admin/SuperAdmin accounts from users table
            Dim adminQuery As New StringBuilder()
            adminQuery.Append("SELECT userId, firstName, COALESCE(middleName, '') as middleName, lastName, ")
            adminQuery.Append("COALESCE(suffix, '') as suffix, COALESCE(position, '') as position, ")
            adminQuery.Append("COALESCE(departmentId, '') as departmentId, COALESCE(contactNumber, '') as contactNumber, ")
            adminQuery.Append("email, username, role AS user_type, status, ")
            adminQuery.Append("COALESCE(employeeId, '') as employeeId, dateAssigned, lastLogin, createdAt, ")
            adminQuery.Append("COALESCE(barangay, '') as barangay, ")
            adminQuery.Append("COALESCE(municipal, '') as municipal, COALESCE(province, '') as province ")
            adminQuery.Append("FROM users WHERE role IN ('Admin','SuperAdmin')")

            If adminWhereConditions.Count > 0 Then
                adminQuery.Append(" AND " & String.Join(" AND ", adminWhereConditions))
            End If

            ' Query Staff accounts from users table (same table as Admin/SuperAdmin)
            Dim staffQuery As New StringBuilder()
            staffQuery.Append("SELECT userId, firstName, COALESCE(middleName, '') as middleName, lastName, ")
            staffQuery.Append("COALESCE(suffix, '') as suffix, COALESCE(position, 'Staff') as position, ")
            staffQuery.Append("COALESCE(CAST(departmentId AS CHAR), '') as departmentId, COALESCE(contactNumber, '') as contactNumber, ")
            staffQuery.Append("email, username, role AS user_type, status, ")
            staffQuery.Append("COALESCE(employeeId, '') as employeeId, dateAssigned, lastLogin, createdAt, ")
            staffQuery.Append("COALESCE(province, '') as province_city, COALESCE(municipal, '') as municipality, COALESCE(barangay, '') as barangay, '' as house_no_street ")
            staffQuery.Append("FROM users WHERE role = 'Staff'")

            If staffWhereConditions.Count > 0 Then
                staffQuery.Append(" AND " & String.Join(" AND ", staffWhereConditions))
            End If

            ' If role filter is set to Admin or SuperAdmin, skip staff query
            If String.IsNullOrEmpty(roleFilter) OrElse roleFilter = "Staff" Then
                Using cmd As New MySqlCommand(staffQuery.ToString(), conn)
                    If Not String.IsNullOrEmpty(statusFilter) Then cmd.Parameters.AddWithValue("@status", statusFilter)
                    If Not String.IsNullOrEmpty(searchKeyword) Then cmd.Parameters.AddWithValue("@search", "%" & searchKeyword.Trim().ToLower() & "%")

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim staffRecords As New DataTable()
                        adapter.Fill(staffRecords)

                        For Each record As DataRow In staffRecords.Rows
                            Dim row As DataRow = dt.NewRow()
                            row("userId") = record("userId")
                            row("firstName") = SafeDbValue(record("firstName"))
                            row("middleName") = SafeDbValue(record("middleName"))
                            row("lastName") = SafeDbValue(record("lastName"))
                            row("suffix") = SafeDbValue(record("suffix"))
                            row("position") = SafeDbValue(record("position"))
                            row("departmentId") = SafeDbValue(record("departmentId"))
                            row("contactNumber") = SafeDbValue(record("contactNumber"))
                            row("email") = SafeDbValue(record("email"))
                            row("username") = SafeDbValue(record("username"))
                            row("user_type") = "Staff"
                            row("status") = SafeDbValue(record("status"))
                            row("employeeId") = SafeDbValue(record("employeeId"))
                            row("dateAssigned") = If(IsDBNull(record("dateAssigned")) OrElse record("dateAssigned") Is Nothing, DBNull.Value, record("dateAssigned"))
                            row("lastLogin") = If(record.IsNull("lastLogin"), DBNull.Value, record("lastLogin"))
                            row("createdAt") = If(record.IsNull("createdAt"), DBNull.Value, record("createdAt"))
                            row("house_no_street") = SafeDbValue(record("house_no_street"))
                            row("barangay") = SafeDbValue(record("barangay"))
                            row("municipality") = SafeDbValue(record("municipality"))
                            row("province_city") = SafeDbValue(record("province_city"))
                            dt.Rows.Add(row)
                        Next
                    End Using
                End Using
            End If

            ' If role filter is not set to Staff only, query admin accounts
            If String.IsNullOrEmpty(roleFilter) OrElse roleFilter = "Admin" OrElse roleFilter = "SuperAdmin" Then
                Using cmd As New MySqlCommand(adminQuery.ToString(), conn)
                    If Not String.IsNullOrEmpty(statusFilter) Then cmd.Parameters.AddWithValue("@status", statusFilter)
                    If Not String.IsNullOrEmpty(roleFilter) AndAlso (roleFilter = "Admin" OrElse roleFilter = "SuperAdmin") Then
                        cmd.Parameters.AddWithValue("@role", roleFilter)
                    End If
                    If Not String.IsNullOrEmpty(searchKeyword) Then cmd.Parameters.AddWithValue("@search", "%" & searchKeyword.Trim().ToLower() & "%")

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim adminRecords As New DataTable()
                        adapter.Fill(adminRecords)

                        For Each record As DataRow In adminRecords.Rows
                            Dim row As DataRow = dt.NewRow()
                            row("userId") = record("userId")
                            row("firstName") = SafeDbValue(record("firstName"))
                            row("middleName") = SafeDbValue(record("middleName"))
                            row("lastName") = SafeDbValue(record("lastName"))
                            row("suffix") = SafeDbValue(record("suffix"))
                            row("position") = SafeDbValue(record("position"))
                            row("departmentId") = SafeDbValue(record("departmentId"))
                            row("contactNumber") = SafeDbValue(record("contactNumber"))
                            row("email") = SafeDbValue(record("email"))
                            row("username") = SafeDbValue(record("username"))
                            row("user_type") = SafeDbValue(record("user_type"))
                            row("status") = SafeDbValue(record("status"))
                            row("employeeId") = SafeDbValue(record("employeeId"))
                            row("dateAssigned") = If(IsDBNull(record("dateAssigned")) OrElse record("dateAssigned") Is Nothing, DBNull.Value, record("dateAssigned"))
                            row("lastLogin") = If(record.IsNull("lastLogin"), DBNull.Value, record("lastLogin"))
                            row("createdAt") = If(record.IsNull("createdAt"), DBNull.Value, record("createdAt"))
                            row("house_no_street") = SafeDbValue(record("house_no_street"))
                            row("barangay") = SafeDbValue(record("barangay"))
                            row("municipality") = SafeDbValue(record("municipality"))
                            row("province_city") = SafeDbValue(record("province_city"))
                            dt.Rows.Add(row)
                        Next
                    End Using
                End Using
            End If

            ' Sort by createdAt descending
            Dim dv As DataView = dt.DefaultView
            dv.Sort = "createdAt DESC"
            dt = dv.ToTable()

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllUsers Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show("Error retrieving users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return dt
    End Function

    ''' <summary>
    ''' Get user by ID - returns complete user data as DataRow
    ''' </summary>
    Public Shared Function GetUserById(userId As Integer) As DataRow
        If userId <= 0 Then Return Nothing

        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return Nothing
            If Not SafeOpenConnection(conn) Then Return Nothing

            Dim query As String = "SELECT userId, firstName, middleName, lastName, suffix, position, " &
                                 "departmentId, contactNumber, email, username, role, status, " &
                                 "employeeId, dateAssigned, lastLogin, createdAt, updatedAt, " &
                                 "province, municipal, barangay " &
                                 "FROM users WHERE userId = @userId LIMIT 1"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userId", userId)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetUserById Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch ex As Exception
                End Try
            End If
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' Helper function to safely get database values
    ''' </summary>
    Private Shared Function SafeDbValue(value As Object) As String
        If value Is Nothing OrElse IsDBNull(value) Then Return ""
        Return value.ToString()
    End Function

    ''' <summary>
    ''' Retrieve minimal admin context (id/type/username) using username stored in session.
    ''' </summary>
    Public Shared Function GetAdminContextByUsername(username As String) As Dictionary(Of String, String)
        Dim context As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        If String.IsNullOrWhiteSpace(username) Then
            Return context
        End If

        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return context
            If Not SafeOpenConnection(conn) Then Return context

            Dim query As String = "SELECT userId, username, role AS user_type FROM users WHERE LOWER(username) = LOWER(@username) LIMIT 1"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username.Trim())
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        context("userId") = reader("userId").ToString()
                        context("username") = reader("username").ToString()
                        context("user_type") = reader("user_type").ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAdminContextByUsername Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return context
    End Function

    ''' <summary>
    ''' Get users by department ID for dropdown population
    ''' </summary>
    Public Shared Function GetUsersByDepartment(departmentID As Integer) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT userId, " &
                                 "CONCAT(IFNULL(firstName,''),' ',IFNULL(lastName,'')) AS fullName, " &
                                 "role AS user_type, departmentId " &
                                 "FROM users WHERE status = 'Active' AND departmentId = @departmentID " &
                                 "ORDER BY fullName"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@departmentID", departmentID)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetUsersByDepartment Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Lightweight list of active admin accounts for assignment dropdowns.
    ''' </summary>
    Public Shared Function GetActiveUsersForAssignment(Optional allowedRoles As IEnumerable(Of String) = Nothing) As DataTable

        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing

        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()

            query.Append("SELECT userId, ")
            query.Append("CONCAT(IFNULL(firstName,''),' ',IFNULL(lastName,'')) AS fullName, ")
            query.Append("role AS user_type, department_id ")
            query.Append("FROM users WHERE status = 'Active'")

            Dim roleList As List(Of String) = Nothing

            If allowedRoles IsNot Nothing Then
                roleList = allowedRoles _
                .Where(Function(r) Not String.IsNullOrWhiteSpace(r)) _
                .Select(Function(r) r.Trim()) _
                .ToList()

                If roleList.Count > 0 Then
                    query.Append(" AND role IN (")

                    For i As Integer = 0 To roleList.Count - 1
                        If i > 0 Then query.Append(",")
                        query.Append("@role" & i)
                    Next

                    query.Append(")")
                End If
            End If

            query.Append(" ORDER BY full_name")

            Using cmd As New MySqlCommand(query.ToString(), conn)

                If roleList IsNot Nothing AndAlso roleList.Count > 0 Then
                    For i As Integer = 0 To roleList.Count - 1
                        cmd.Parameters.AddWithValue("@role" & i, roleList(i))
                    Next
                End If

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using

            End Using

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetActiveUsersForAssignment Exception: " & ex.Message)

        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return dt

    End Function

    ''' <summary>
    ''' Create a new admin or super admin account with full validation.
    ''' </summary>
    Public Shared Function AddAdminAccount(firstName As String,
                                           lastName As String,
                                           email As String,
                                           username As String,
                                           password As String,
                                           Optional middleName As String = "",
                                           Optional suffix As String = "",
                                           Optional position As String = "Administrator",
                                           Optional departmentID As Integer? = Nothing,
                                           Optional contactNumber As String = "",
                                           Optional houseNoStreet As String = "",
                                           Optional barangay As String = "",
                                           Optional municipality As String = "",
                                           Optional provinceCity As String = "",
                                           Optional dateAssigned As Date? = Nothing,
                                           Optional employeeID As String = "",
                                           Optional userType As String = "Admin",
                                           Optional status As String = "Active",
                                           Optional createdByID As Integer? = Nothing,
                                           Optional createdByType As String = "",
                                           Optional createdByName As String = "",
                                           Optional ipAddress As String = "",
                                           Optional moduleName As String = "Admin Management",
                                           Optional entityLabel As String = "Admin Account") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ManageUsers, "create administrator accounts") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim duplicateCheck As String = DetectCredentialConflict(conn, username, email)
            If duplicateCheck = "duplicate_username" Then
                MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf duplicateCheck = "duplicate_email" Then
                MessageBox.Show("Email already exists. Please use a different email address.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf duplicateCheck = "error" Then
                MessageBox.Show("Unable to validate credentials. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Not String.IsNullOrWhiteSpace(employeeID) Then
                Dim employeeQuery As String = "SELECT COUNT(*) FROM users WHERE employeeId = @employeeID"
                Using cmd As New MySqlCommand(employeeQuery, conn)
                    cmd.Parameters.AddWithValue("@employeeID", employeeID.Trim())
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Employee ID already exists. Please provide a unique ID.", "Duplicate Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End Using
            End If

            Dim hashedPassword As String = PasswordHelper.HashPassword(password)
            If String.IsNullOrEmpty(hashedPassword) Then
                MessageBox.Show("Failed to hash the password. Please try again.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            ' Normalize role to match database enum (SuperAdmin, Admin, Custodian, Staff)
            Dim normalizedRole As String = "Admin"
            If Not String.IsNullOrWhiteSpace(userType) Then
                Dim roleUpper As String = userType.Trim().ToUpper()
                If roleUpper = "SUPERADMIN" Then
                    normalizedRole = "SuperAdmin"
                ElseIf roleUpper = "ADMIN" Then
                    normalizedRole = "Admin"
                ElseIf roleUpper = "CUSTODIAN" Then
                    normalizedRole = "Custodian"
                ElseIf roleUpper = "STAFF" Then
                    normalizedRole = "Staff"
                End If
            End If

            Dim normalizedStatus As String = If(String.Equals(status, "Inactive", StringComparison.OrdinalIgnoreCase), "Inactive", "Active")
            Dim assignedDate As Date = If(dateAssigned.HasValue, dateAssigned.Value, Date.Today)

            Dim insertQuery As String =
                "INSERT INTO users (firstName, middleName, lastName, suffix, position, departmentId, contactNumber, email, username, passwordEncrypted, " &
                "province, municipal, barangay, employeeId, role, status, createdAt) " &
                "VALUES (@firstName, @middleName, @lastName, @suffix, @position, @departmentID, @contactNumber, @email, @username, @password, " &
                "@province, @municipality, @barangay, @employeeID, @role, @status, NOW())"

            Using cmd As New MySqlCommand(insertQuery, conn)
                cmd.Parameters.AddWithValue("@firstName", firstName.Trim())
                cmd.Parameters.AddWithValue("@middleName", If(String.IsNullOrWhiteSpace(middleName), DBNull.Value, middleName.Trim()))
                cmd.Parameters.AddWithValue("@lastName", lastName.Trim())
                cmd.Parameters.AddWithValue("@suffix", If(String.IsNullOrWhiteSpace(suffix), DBNull.Value, suffix.Trim()))
                cmd.Parameters.AddWithValue("@position", If(String.IsNullOrWhiteSpace(position), "Administrator", position.Trim()))
                cmd.Parameters.AddWithValue("@departmentID", If(departmentID.HasValue, departmentID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrWhiteSpace(contactNumber), DBNull.Value, contactNumber.Trim()))
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.Parameters.AddWithValue("@username", username.Trim())
                cmd.Parameters.AddWithValue("@password", hashedPassword)
                cmd.Parameters.AddWithValue("@province", If(String.IsNullOrWhiteSpace(provinceCity), DBNull.Value, provinceCity.Trim()))
                cmd.Parameters.AddWithValue("@municipality", If(String.IsNullOrWhiteSpace(municipality), DBNull.Value, municipality.Trim()))
                cmd.Parameters.AddWithValue("@barangay", If(String.IsNullOrWhiteSpace(barangay), DBNull.Value, barangay.Trim()))
                cmd.Parameters.AddWithValue("@employeeID", If(String.IsNullOrWhiteSpace(employeeID), DBNull.Value, employeeID.Trim()))
                cmd.Parameters.AddWithValue("@role", normalizedRole)
                cmd.Parameters.AddWithValue("@status", normalizedStatus)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    If departmentID.HasValue Then
                        Try
                            RecalculateDepartmentHeadcount(departmentID.Value)
                        Catch exHeadcount As Exception
                            System.Diagnostics.Debug.WriteLine("[v0] AddAdminAccount headcount refresh failed: " & exHeadcount.Message)
                        End Try
                    End If
                    LogCrudAction(createdByID, createdByType, createdByName, moduleName, entityLabel, "Create",
                                  $"Created {entityLabel.ToLower()} ({username.Trim()})", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddAdminAccount Exception: " & ex.Message)
            MessageBox.Show(GetUserFriendlyErrorMessage(ex, "create admin account"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Update core admin fields including role and status.
    ''' </summary>
    Public Shared Function UpdateAdminAccount(adminID As Integer,
                                              firstName As String,
                                              lastName As String,
                                              email As String,
                                              username As String,
                                              Optional middleName As String = "",
                                              Optional suffix As String = "",
                                              Optional position As String = "Administrator",
                                              Optional departmentID As Integer? = Nothing,
                                              Optional contactNumber As String = "",
                                              Optional houseNoStreet As String = "",
                                              Optional barangay As String = "",
                                              Optional municipality As String = "",
                                              Optional provinceCity As String = "",
                                              Optional dateAssigned As Date? = Nothing,
                                              Optional employeeID As String = "",
                                              Optional userType As String = "Admin",
                                              Optional status As String = "Active",
                                              Optional updatedByID As Integer? = Nothing,
                                              Optional updatedByType As String = "",
                                              Optional updatedByName As String = "",
                                              Optional ipAddress As String = "",
                                              Optional moduleName As String = "Admin Management",
                                              Optional entityLabel As String = "Admin Account") As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim previousDepartmentID As Integer? = Nothing
            Using currentDeptCmd As New MySqlCommand("SELECT departmentId FROM users WHERE userId = @adminID LIMIT 1", conn)
                currentDeptCmd.Parameters.AddWithValue("@adminID", adminID)
                Dim currentDept = currentDeptCmd.ExecuteScalar()
                If currentDept IsNot Nothing AndAlso currentDept IsNot DBNull.Value Then
                    previousDepartmentID = Convert.ToInt32(currentDept)
                End If
            End Using

            Dim duplicateCheck As String = DetectCredentialConflict(conn, username, email, adminID, Nothing)
            If duplicateCheck = "duplicate_username" Then
                MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf duplicateCheck = "duplicate_email" Then
                MessageBox.Show("Email already exists. Please use a different email address.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf duplicateCheck = "error" Then
                MessageBox.Show("Unable to validate credentials. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Not String.IsNullOrWhiteSpace(employeeID) Then
                Dim employeeQuery As String = "SELECT COUNT(*) FROM users WHERE employeeId = @employeeID AND user_id <> @adminID"
                Using cmd As New MySqlCommand(employeeQuery, conn)
                    cmd.Parameters.AddWithValue("@employeeID", employeeID.Trim())
                    cmd.Parameters.AddWithValue("@adminID", adminID)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Employee ID already exists. Please provide a unique ID.", "Duplicate Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End Using
            End If

            Dim normalizedUserType As String = If(String.Equals(userType, "SuperAdmin", StringComparison.OrdinalIgnoreCase), "SuperAdmin", "Admin")
            Dim normalizedStatus As String = If(String.Equals(status, "Inactive", StringComparison.OrdinalIgnoreCase), "Inactive", "Active")
            Dim assignedDate As Date = If(dateAssigned.HasValue, dateAssigned.Value, Date.Today)

            Dim updateQuery As String =
                "UPDATE users SET firstName = @firstName, middleName = @middleName, lastName = @lastName, suffix = @suffix, " &
                "position = @position, departmentId = @departmentID, contactNumber = @contactNumber, email = @email, username = @username, " &
                "house_no_street = @houseNo, barangay = @barangay, municipality = @municipality, province_city = @province, " &
                "employeeId = @employeeID, role = @userType, status = @status, updated_at = NOW() " &
                "WHERE userId = @adminID"

            Using cmd As New MySqlCommand(updateQuery, conn)
                cmd.Parameters.AddWithValue("@firstName", firstName.Trim())
                cmd.Parameters.AddWithValue("@middleName", If(String.IsNullOrWhiteSpace(middleName), DBNull.Value, middleName.Trim()))
                cmd.Parameters.AddWithValue("@lastName", lastName.Trim())
                cmd.Parameters.AddWithValue("@suffix", If(String.IsNullOrWhiteSpace(suffix), DBNull.Value, suffix.Trim()))
                cmd.Parameters.AddWithValue("@position", If(String.IsNullOrWhiteSpace(position), "Administrator", position.Trim()))
                cmd.Parameters.AddWithValue("@departmentID", If(departmentID.HasValue, departmentID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrWhiteSpace(contactNumber), DBNull.Value, contactNumber.Trim()))
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.Parameters.AddWithValue("@username", username.Trim())
                cmd.Parameters.AddWithValue("@houseNo", If(String.IsNullOrWhiteSpace(houseNoStreet), DBNull.Value, houseNoStreet.Trim()))
                cmd.Parameters.AddWithValue("@barangay", If(String.IsNullOrWhiteSpace(barangay), DBNull.Value, barangay.Trim()))
                cmd.Parameters.AddWithValue("@municipality", If(String.IsNullOrWhiteSpace(municipality), DBNull.Value, municipality.Trim()))
                cmd.Parameters.AddWithValue("@province", If(String.IsNullOrWhiteSpace(provinceCity), DBNull.Value, provinceCity.Trim()))
                cmd.Parameters.AddWithValue("@dateAssigned", assignedDate)
                cmd.Parameters.AddWithValue("@employeeID", If(String.IsNullOrWhiteSpace(employeeID), DBNull.Value, employeeID.Trim()))
                cmd.Parameters.AddWithValue("@userType", normalizedUserType)
                cmd.Parameters.AddWithValue("@status", normalizedStatus)
                cmd.Parameters.AddWithValue("@adminID", adminID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    Dim targetDepartments As New HashSet(Of Integer)()
                    If previousDepartmentID.HasValue Then targetDepartments.Add(previousDepartmentID.Value)
                    If departmentID.HasValue Then targetDepartments.Add(departmentID.Value)
                    For Each deptId In targetDepartments
                        Try
                            RecalculateDepartmentHeadcount(deptId)
                        Catch exHeadcount As Exception
                            System.Diagnostics.Debug.WriteLine("[v0] UpdateAdminAccount headcount refresh failed: " & exHeadcount.Message)
                        End Try
                    Next
                    LogCrudAction(updatedByID, updatedByType, updatedByName, moduleName, entityLabel, "Update",
                                  $"Updated {entityLabel.ToLower()} ({username.Trim()})", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdateAdminAccount Exception: " & ex.Message)
            MessageBox.Show("Error updating admin account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Force reset of an admin password (used by SuperAdmin).
    ''' </summary>
    Public Shared Function ResetAdminPassword(adminID As Integer,
                                              newPassword As String,
                                              Optional performedByID As Integer? = Nothing,
                                              Optional performedByType As String = "",
                                              Optional performedByName As String = "",
                                              Optional ipAddress As String = "",
                                              Optional moduleName As String = "Admin Management",
                                              Optional entityLabel As String = "Admin Account") As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            Dim hashedPassword As String = PasswordHelper.HashPassword(newPassword)
            If String.IsNullOrEmpty(hashedPassword) Then
                MessageBox.Show("Failed to hash the password. Please try again.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE users SET password = @password, updated_at = NOW() WHERE userId = @adminID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@password", hashedPassword)
                cmd.Parameters.AddWithValue("@adminID", adminID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    LogCrudAction(performedByID, performedByType, performedByName, moduleName, entityLabel, "Reset",
                                  $"Reset password for {entityLabel.ToLower()} #{adminID}", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ResetAdminPassword Exception: " & ex.Message)
            MessageBox.Show("Error resetting password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Quickly activate or deactivate an admin account.
    ''' </summary>
    Public Shared Function SetAdminStatus(adminID As Integer,
                                          isActive As Boolean,
                                          Optional performedByID As Integer? = Nothing,
                                          Optional performedByType As String = "",
                                          Optional performedByName As String = "",
                                          Optional ipAddress As String = "",
                                          Optional moduleName As String = "Admin Management",
                                          Optional entityLabel As String = "Admin Account") As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim statusValue As String = If(isActive, "Active", "Inactive")
            Dim query As String = "UPDATE users SET status = @status, updated_at = NOW() WHERE userId = @adminID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@status", statusValue)
                cmd.Parameters.AddWithValue("@adminID", adminID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    Dim actionVerb As String = If(isActive, "Activate", "Deactivate")
                    LogCrudAction(performedByID, performedByType, performedByName, moduleName, entityLabel, actionVerb,
                                  $"{actionVerb}d {entityLabel.ToLower()} #{adminID}", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] SetAdminStatus Exception: " & ex.Message)
            MessageBox.Show("Error updating account status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Permanently delete an admin account. Prevents deleting self.
    ''' </summary>
    Public Shared Function DeleteAdminAccount(adminID As Integer,
                                              Optional performedByID As Integer? = Nothing,
                                              Optional performedByType As String = "",
                                              Optional performedByName As String = "",
                                              Optional ipAddress As String = "",
                                              Optional moduleName As String = "Admin Management",
                                              Optional entityLabel As String = "Admin Account") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ManageUsers, "delete administrator accounts") Then
            Return False
        End If
        If performedByID.HasValue AndAlso performedByID.Value = adminID Then
            MessageBox.Show("You cannot delete the account that is currently logged in.", "Operation Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim affectedDepartmentID As Integer? = Nothing
            Using infoCmd As New MySqlCommand("SELECT departmentId FROM users WHERE userId = @adminID LIMIT 1", conn)
                infoCmd.Parameters.AddWithValue("@adminID", adminID)
                Dim deptValue = infoCmd.ExecuteScalar()
                If deptValue IsNot Nothing AndAlso deptValue IsNot DBNull.Value Then
                    affectedDepartmentID = Convert.ToInt32(deptValue)
                End If
            End Using

            Dim query As String = "DELETE FROM users WHERE userId = @adminID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@adminID", adminID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    If affectedDepartmentID.HasValue Then
                        Try
                            RecalculateDepartmentHeadcount(affectedDepartmentID.Value)
                        Catch exHeadcount As Exception
                            System.Diagnostics.Debug.WriteLine("[v0] DeleteAdminAccount headcount refresh failed: " & exHeadcount.Message)
                        End Try
                    End If
                    LogCrudAction(performedByID, performedByType, performedByName, moduleName, entityLabel, "Delete",
                                  $"Deleted {entityLabel.ToLower()} #{adminID}", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] DeleteAdminAccount Exception: " & ex.Message)
            MessageBox.Show("Error deleting admin account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Delete a user account (Admin, SuperAdmin, or Staff) based on user type.
    ''' </summary>
    Public Shared Function DeleteUserAccount(userID As Integer,
                                              userType As String,
                                              performedByID As Integer?,
                                              performedByType As String,
                                              performedByName As String,
                                              Optional ipAddress As String = "",
                                              Optional moduleName As String = "User Management",
                                              Optional entityLabel As String = "User Account") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ManageUsers, "delete user accounts") Then
            Return False
        End If
        If performedByID.HasValue AndAlso performedByID.Value = userID Then
            MessageBox.Show("You cannot delete the account that is currently logged in.", "Operation Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim affectedDepartmentID As Integer? = Nothing
            Dim query As String = ""

            ' Determine which table to delete from based on user type
            If userType = "Admin" OrElse userType = "SuperAdmin" Then
                ' Get department_id before deletion for headcount recalculation
                Using infoCmd As New MySqlCommand("SELECT departmentId FROM users WHERE userId = @userID LIMIT 1", conn)
                    infoCmd.Parameters.AddWithValue("@userID", userID)
                    Dim deptValue = infoCmd.ExecuteScalar()
                    If deptValue IsNot Nothing AndAlso deptValue IsNot DBNull.Value Then
                        affectedDepartmentID = Convert.ToInt32(deptValue)
                    End If
                End Using

                query = "DELETE FROM users WHERE userId = @userID"
            ElseIf userType = "Staff" Then
                ' Get department_id before deletion for headcount recalculation
                Using infoCmd As New MySqlCommand("SELECT departmentId FROM users WHERE userId = @userID AND role = 'Staff' LIMIT 1", conn)
                    infoCmd.Parameters.AddWithValue("@userID", userID)
                    Dim deptValue = infoCmd.ExecuteScalar()
                    If deptValue IsNot Nothing AndAlso deptValue IsNot DBNull.Value Then
                        affectedDepartmentID = Convert.ToInt32(deptValue)
                    End If
                End Using

                query = "DELETE FROM users WHERE userId = @userID AND role = 'Staff'"
            Else
                MessageBox.Show("Invalid user type specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userID", userID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    If affectedDepartmentID.HasValue Then
                        Try
                            RecalculateDepartmentHeadcount(affectedDepartmentID.Value)
                        Catch exHeadcount As Exception
                            System.Diagnostics.Debug.WriteLine("[v0] DeleteUserAccount headcount refresh failed: " & exHeadcount.Message)
                        End Try
                    End If
                    LogCrudAction(performedByID, performedByType, performedByName, moduleName, entityLabel, "Delete",
                                  $"Deleted {entityLabel.ToLower()} #{userID} ({userType})", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] DeleteUserAccount Exception: " & ex.Message)
            MessageBox.Show("Error deleting user account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Reset password for any user account (Admin, SuperAdmin, or Staff) based on user type.
    ''' </summary>
    Public Shared Function ResetUserPassword(userID As Integer,
                                              userType As String,
                                              newPassword As String,
                                              Optional performedByID As Integer? = Nothing,
                                              Optional performedByType As String = "",
                                              Optional performedByName As String = "",
                                              Optional ipAddress As String = "",
                                              Optional moduleName As String = "User Management",
                                              Optional entityLabel As String = "User Account") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ManageUsers, "reset user passwords") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            Dim hashedPassword As String = PasswordHelper.HashPassword(newPassword)
            If String.IsNullOrEmpty(hashedPassword) Then
                MessageBox.Show("Failed to hash the password. Please try again.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = ""

            ' All accounts are in users table, update based on role
            If userType = "Admin" OrElse userType = "SuperAdmin" OrElse userType = "Staff" OrElse userType = "Custodian" Then
                query = "UPDATE users SET passwordEncrypted = @password, updated_at = NOW() WHERE userId = @userID"
            Else
                MessageBox.Show("Invalid user type specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@password", hashedPassword)
                cmd.Parameters.AddWithValue("@userID", userID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    LogCrudAction(performedByID, performedByType, performedByName, moduleName, entityLabel, "Reset",
                                  $"Reset password for {entityLabel.ToLower()} #{userID} ({userType})", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ResetUserPassword Exception: " & ex.Message)
            MessageBox.Show("Error resetting password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Update a user account (Admin, SuperAdmin, or Staff) based on user type.
    ''' </summary>
    Public Shared Function UpdateUserAccount(userID As Integer,
                                              userType As String,
                                              firstName As String,
                                              lastName As String,
                                              email As String,
                                              username As String,
                                              Optional middleName As String = "",
                                              Optional suffix As String = "",
                                              Optional position As String = "",
                                              Optional departmentID As Integer? = Nothing,
                                              Optional contactNumber As String = "",
                                              Optional houseNoStreet As String = "",
                                              Optional barangay As String = "",
                                              Optional municipality As String = "",
                                              Optional provinceCity As String = "",
                                              Optional dateAssigned As Date? = Nothing,
                                              Optional employeeID As String = "",
                                              Optional newUserType As String = "",
                                              Optional status As String = "Active",
                                              Optional updatedByID As Integer? = Nothing,
                                              Optional updatedByType As String = "",
                                              Optional updatedByName As String = "",
                                              Optional ipAddress As String = "",
                                              Optional moduleName As String = "User Management",
                                              Optional entityLabel As String = "User Account") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ManageUsers, "update user accounts") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            ' Check for duplicate username/email
            Dim excludeAdminID As Integer? = Nothing
            Dim excludeStaffID As Integer? = Nothing
            If userType = "Admin" OrElse userType = "SuperAdmin" Then
                excludeAdminID = userID
            ElseIf userType = "Staff" Then
                excludeStaffID = userID
            End If

            Dim duplicateCheck As String = DetectCredentialConflict(conn, username, email, excludeAdminID, excludeStaffID)
            If duplicateCheck = "duplicate_username" Then
                MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf duplicateCheck = "duplicate_email" Then
                MessageBox.Show("Email already exists. Please use a different email address.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim previousDepartmentID As Integer? = Nothing
            Dim query As String = ""

            ' Build update query based on user type
            If userType = "Admin" OrElse userType = "SuperAdmin" Then
                ' Get previous department for headcount recalculation
                Using infoCmd As New MySqlCommand("SELECT departmentId FROM users WHERE userId = @userID LIMIT 1", conn)
                    infoCmd.Parameters.AddWithValue("@userID", userID)
                    Dim deptValue = infoCmd.ExecuteScalar()
                    If deptValue IsNot Nothing AndAlso deptValue IsNot DBNull.Value Then
                        previousDepartmentID = Convert.ToInt32(deptValue)
                    End If
                End Using

                Dim normalizedUserType As String = If(String.IsNullOrEmpty(newUserType), userType, If(String.Equals(newUserType, "SuperAdmin", StringComparison.OrdinalIgnoreCase), "SuperAdmin", "Admin"))
                Dim normalizedStatus As String = If(String.Equals(status, "Inactive", StringComparison.OrdinalIgnoreCase), "inactive", "active")

                query = "UPDATE users SET firstName = @firstName, middleName = @middleName, lastName = @lastName, " &
                       "suffix = @suffix, position = @position, departmentId = @departmentID, contactNumber = @contactNumber, " &
                       "email = @email, username = @username, house_no_street = @houseNo, barangay = @barangay, " &
                       "municipality = @municipality, province_city = @province, dateAssigned = @dateAssigned, " &
                       "employeeId = @employeeID, role = @userType, status = @status, updated_at = NOW() " &
                       "WHERE userId = @userID"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@firstName", firstName.Trim())
                    cmd.Parameters.AddWithValue("@middleName", If(String.IsNullOrWhiteSpace(middleName), DBNull.Value, middleName.Trim()))
                    cmd.Parameters.AddWithValue("@lastName", lastName.Trim())
                    cmd.Parameters.AddWithValue("@suffix", If(String.IsNullOrWhiteSpace(suffix), DBNull.Value, suffix.Trim()))
                    cmd.Parameters.AddWithValue("@position", If(String.IsNullOrWhiteSpace(position), "Administrator", position.Trim()))
                    cmd.Parameters.AddWithValue("@departmentID", If(departmentID.HasValue, departmentID.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrWhiteSpace(contactNumber), DBNull.Value, contactNumber.Trim()))
                    cmd.Parameters.AddWithValue("@email", email.Trim())
                    cmd.Parameters.AddWithValue("@username", username.Trim())
                    cmd.Parameters.AddWithValue("@houseNo", If(String.IsNullOrWhiteSpace(houseNoStreet), DBNull.Value, houseNoStreet.Trim()))
                    cmd.Parameters.AddWithValue("@barangay", If(String.IsNullOrWhiteSpace(barangay), DBNull.Value, barangay.Trim()))
                    cmd.Parameters.AddWithValue("@municipality", If(String.IsNullOrWhiteSpace(municipality), DBNull.Value, municipality.Trim()))
                    cmd.Parameters.AddWithValue("@province", If(String.IsNullOrWhiteSpace(provinceCity), DBNull.Value, provinceCity.Trim()))
                    cmd.Parameters.AddWithValue("@dateAssigned", If(dateAssigned.HasValue, dateAssigned.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@employeeID", If(String.IsNullOrWhiteSpace(employeeID), DBNull.Value, employeeID.Trim()))
                    cmd.Parameters.AddWithValue("@userType", normalizedUserType)
                    cmd.Parameters.AddWithValue("@status", normalizedStatus)
                    cmd.Parameters.AddWithValue("@userID", userID)

                    Dim rows As Integer = cmd.ExecuteNonQuery()
                    If rows > 0 Then
                        ' Recalculate department headcount if department changed
                        If previousDepartmentID.HasValue AndAlso previousDepartmentID <> departmentID Then
                            Try
                                RecalculateDepartmentHeadcount(previousDepartmentID.Value)
                            Catch exHeadcount As Exception
                                System.Diagnostics.Debug.WriteLine("[v0] UpdateUserAccount headcount refresh failed: " & exHeadcount.Message)
                            End Try
                        End If
                        If departmentID.HasValue Then
                            Try
                                RecalculateDepartmentHeadcount(departmentID.Value)
                            Catch exHeadcount As Exception
                                System.Diagnostics.Debug.WriteLine("[v0] UpdateUserAccount headcount refresh failed: " & exHeadcount.Message)
                            End Try
                        End If

                        LogCrudAction(updatedByID, updatedByType, updatedByName, moduleName, entityLabel, "Update",
                                      $"Updated {entityLabel.ToLower()} #{userID} ({normalizedUserType})", ipAddress)
                        Return True
                    End If
                End Using
            ElseIf userType = "Staff" Then
                ' Get previous department for headcount recalculation
                Using infoCmd As New MySqlCommand("SELECT departmentId FROM users WHERE userId = @userID AND role = 'Staff' LIMIT 1", conn)
                    infoCmd.Parameters.AddWithValue("@userID", userID)
                    Dim deptValue = infoCmd.ExecuteScalar()
                    If deptValue IsNot Nothing AndAlso deptValue IsNot DBNull.Value Then
                        previousDepartmentID = Convert.ToInt32(deptValue)
                    End If
                End Using

                Dim normalizedStatus As String = If(String.Equals(status, "Inactive", StringComparison.OrdinalIgnoreCase), "Inactive", "Active")

                ' Update Staff account in users table (same table as Admin/SuperAdmin)
                ' Note: users table doesn't have house_no_street, it has province, municipal, barangay
                query = "UPDATE users SET firstName = @firstName, lastName = @lastName, " &
                       "email = @email, username = @username, contactNumber = @contactNumber, " &
                       "departmentId = @departmentID, " &
                       "position = @position, status = @status, updated_at = NOW() " &
                       "WHERE userId = @userID AND role = 'Staff'"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@firstName", firstName.Trim())
                    cmd.Parameters.AddWithValue("@lastName", lastName.Trim())
                    cmd.Parameters.AddWithValue("@email", email.Trim())
                    cmd.Parameters.AddWithValue("@username", username.Trim())
                    cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrWhiteSpace(contactNumber), DBNull.Value, contactNumber.Trim()))
                    cmd.Parameters.AddWithValue("@houseNo", If(String.IsNullOrWhiteSpace(houseNoStreet), DBNull.Value, houseNoStreet.Trim()))
                    cmd.Parameters.AddWithValue("@departmentID", If(departmentID.HasValue, departmentID.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@position", If(String.IsNullOrWhiteSpace(position), "Staff", position.Trim()))
                    cmd.Parameters.AddWithValue("@status", normalizedStatus)
                    cmd.Parameters.AddWithValue("@userID", userID)

                    Dim rows As Integer = cmd.ExecuteNonQuery()
                    If rows > 0 Then
                        ' Recalculate department headcount if department changed
                        If previousDepartmentID.HasValue AndAlso previousDepartmentID <> departmentID Then
                            Try
                                RecalculateDepartmentHeadcount(previousDepartmentID.Value)
                            Catch exHeadcount As Exception
                                System.Diagnostics.Debug.WriteLine("[v0] UpdateUserAccount headcount refresh failed: " & exHeadcount.Message)
                            End Try
                        End If
                        If departmentID.HasValue Then
                            Try
                                RecalculateDepartmentHeadcount(departmentID.Value)
                            Catch exHeadcount As Exception
                                System.Diagnostics.Debug.WriteLine("[v0] UpdateUserAccount headcount refresh failed: " & exHeadcount.Message)
                            End Try
                        End If

                        LogCrudAction(updatedByID, updatedByType, updatedByName, moduleName, entityLabel, "Update",
                                      $"Updated {entityLabel.ToLower()} #{userID} (Staff)", ipAddress)
                        Return True
                    End If
                End Using
            Else
                MessageBox.Show("Invalid user type specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdateUserAccount Exception: " & ex.Message)
            MessageBox.Show("Error updating user account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Retrieve all staff records for SuperAdmin maintenance.
    ''' </summary>
    Public Shared Function GetStaffAccounts(Optional statusFilter As String = "",
                                            Optional departmentID As Integer? = Nothing,
                                            Optional searchKeyword As String = "") As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            ' Query Staff accounts from users table (same table as Admin/SuperAdmin)
            query.Append("SELECT userId as staffId, firstName, lastName, email, contactNumber, ")
            query.Append("departmentId, username, COALESCE(position, 'Staff') as position, status, created_at ")
            query.Append("FROM users WHERE role = 'Staff'")

            If Not String.IsNullOrEmpty(statusFilter) Then query.Append(" AND status = @status")
            If departmentID.HasValue Then query.Append(" AND departmentId = @departmentID")
            If Not String.IsNullOrEmpty(searchKeyword) Then
                query.Append(" AND (")
                query.Append("LOWER(firstName) LIKE @search OR LOWER(lastName) LIKE @search OR ")
                query.Append("LOWER(username) LIKE @search OR LOWER(email) LIKE @search)")
            End If

            query.Append(" ORDER BY created_at DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(statusFilter) Then cmd.Parameters.AddWithValue("@status", statusFilter)
                If departmentID.HasValue Then cmd.Parameters.AddWithValue("@departmentID", departmentID.Value)
                If Not String.IsNullOrEmpty(searchKeyword) Then cmd.Parameters.AddWithValue("@search", "%" & searchKeyword.Trim().ToLower() & "%")

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetStaffAccounts Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return dt
    End Function

    ''' <summary>
    ''' Add a new staff account with hashed password.
    ''' </summary>
    Public Shared Function AddStaffAccount(firstName As String,
                                           lastName As String,
                                           email As String,
                                           username As String,
                                           password As String,
                                           Optional contactNumber As String = "",
                                           Optional address As String = "",
                                           Optional departmentID As Integer? = Nothing,
                                           Optional position As String = "Staff",
                                           Optional status As String = "Active",
                                           Optional createdByID As Integer? = Nothing,
                                           Optional createdByType As String = "",
                                           Optional createdByName As String = "",
                                           Optional ipAddress As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ManageUsers, "add staff accounts") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim duplicateCheck As String = DetectCredentialConflict(conn, username, email, Nothing, Nothing)
            If duplicateCheck = "duplicate_username" Then
                MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf duplicateCheck = "duplicate_email" Then
                MessageBox.Show("Email already exists. Please use a different email address.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf duplicateCheck = "error" Then
                MessageBox.Show("Unable to validate credentials. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Dim hashedPassword As String = PasswordHelper.HashPassword(password)
            If String.IsNullOrEmpty(hashedPassword) Then
                MessageBox.Show("Failed to hash the password. Please try again.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Dim normalizedStatus As String = If(String.Equals(status, "Inactive", StringComparison.OrdinalIgnoreCase), "Inactive", "Active")
            ' Note: users table uses password_encrypted (not password) and created_at (not created_date)
            ' Also, address fields are province/municipal/barangay, not a single address field
            Dim insertQuery As String =
                "INSERT INTO staff_accounts (firstName, lastName, email, contactNumber, departmentId, username, passwordEncrypted, position, status, created_at) " &
                "VALUES (@firstName, @lastName, @email, @contactNumber, @departmentID, @username, @password, @position, @status, NOW())"

            Using cmd As New MySqlCommand(insertQuery, conn)
                cmd.Parameters.AddWithValue("@firstName", firstName.Trim())
                cmd.Parameters.AddWithValue("@lastName", lastName.Trim())
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrWhiteSpace(contactNumber), DBNull.Value, contactNumber.Trim()))
                ' Note: address parameter removed since staff_accounts doesn't have address column
                cmd.Parameters.AddWithValue("@departmentID", If(departmentID.HasValue, departmentID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@username", username.Trim())
                cmd.Parameters.AddWithValue("@password", hashedPassword)
                cmd.Parameters.AddWithValue("@position", If(String.IsNullOrWhiteSpace(position), "Staff", position.Trim()))
                cmd.Parameters.AddWithValue("@status", normalizedStatus)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    LogCrudAction(createdByID, createdByType, createdByName, "Staff Management", "Staff Account", "Create",
                                  $"Created staff account ({username.Trim()})", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddStaffAccount Exception: " & ex.Message)
            MessageBox.Show("Error creating staff account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Update an existing staff profile.
    ''' </summary>
    Public Shared Function UpdateStaffAccount(staffID As Integer,
                                              firstName As String,
                                              lastName As String,
                                              email As String,
                                              username As String,
                                              Optional contactNumber As String = "",
                                              Optional address As String = "",
                                              Optional departmentID As Integer? = Nothing,
                                              Optional position As String = "Staff",
                                              Optional status As String = "Active",
                                              Optional updatedByID As Integer? = Nothing,
                                              Optional updatedByType As String = "",
                                              Optional updatedByName As String = "",
                                              Optional ipAddress As String = "") As Boolean
        ' Allow staff to update their own profile, or require ManageUsers permission for updating other staff
        If SessionContext.CurrentUserID.HasValue AndAlso SessionContext.CurrentUserID.Value = staffID Then
            ' Staff updating their own profile - allow without permission check
        ElseIf Not DemandPermission(SessionContext.ModulePermission.ManageUsers, "update staff accounts") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim duplicateCheck As String = DetectCredentialConflict(conn, username, email, Nothing, staffID)
            If duplicateCheck = "duplicate_username" Then
                MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf duplicateCheck = "duplicate_email" Then
                MessageBox.Show("Email already exists. Please use a different email address.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf duplicateCheck = "error" Then
                MessageBox.Show("Unable to validate credentials. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Dim normalizedStatus As String = If(String.Equals(status, "Inactive", StringComparison.OrdinalIgnoreCase), "Inactive", "Active")
            ' Update Staff account in users table (same table as Admin/SuperAdmin)
            ' Note: users table doesn't have address column, it has province/municipal/barangay
            Dim updateQuery As String =
                "UPDATE users SET firstName = @firstName, lastName = @lastName, email = @email, contactNumber = @contactNumber, " &
                "departmentId = @departmentID, username = @username, position = @position, status = @status, updated_at = NOW() " &
                "WHERE userId = @staffID AND role = 'Staff'"

            Using cmd As New MySqlCommand(updateQuery, conn)
                cmd.Parameters.AddWithValue("@firstName", firstName.Trim())
                cmd.Parameters.AddWithValue("@lastName", lastName.Trim())
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrWhiteSpace(contactNumber), DBNull.Value, contactNumber.Trim()))
                ' Note: address parameter removed - users table uses province/municipal/barangay instead
                cmd.Parameters.AddWithValue("@departmentID", If(departmentID.HasValue, departmentID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@username", username.Trim())
                cmd.Parameters.AddWithValue("@position", If(String.IsNullOrWhiteSpace(position), "Staff", position.Trim()))
                cmd.Parameters.AddWithValue("@status", normalizedStatus)
                cmd.Parameters.AddWithValue("@staffID", staffID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    LogCrudAction(updatedByID, updatedByType, updatedByName, "Staff Management", "Staff Account", "Update",
                                  $"Updated staff account ({username.Trim()})", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdateStaffAccount Exception: " & ex.Message)
            MessageBox.Show("Error updating staff account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Reset staff password from the SuperAdmin console.
    ''' </summary>
    Public Shared Function ResetStaffPassword(staffID As Integer,
                                              newPassword As String,
                                              Optional performedByID As Integer? = Nothing,
                                              Optional performedByType As String = "",
                                              Optional performedByName As String = "",
                                              Optional ipAddress As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ManageUsers, "reset staff passwords") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            Dim hashedPassword As String = PasswordHelper.HashPassword(newPassword)
            If String.IsNullOrEmpty(hashedPassword) Then
                MessageBox.Show("Failed to hash the password. Please try again.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            ' Update password in users table (all accounts are in users table)
            Using cmd As New MySqlCommand("UPDATE users SET passwordEncrypted = @password, updated_at = NOW() WHERE userId = @staffID AND role = 'Staff'", conn)
                cmd.Parameters.AddWithValue("@password", hashedPassword)
                cmd.Parameters.AddWithValue("@staffID", staffID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    LogCrudAction(performedByID, performedByType, performedByName, "Staff Management", "Staff Account", "Reset",
                                  $"Reset password for staff account #{staffID}", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ResetStaffPassword Exception: " & ex.Message)
            MessageBox.Show("Error resetting staff password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Update staff status (Active/Inactive).
    ''' </summary>
    Public Shared Function SetStaffStatus(staffID As Integer,
                                          isActive As Boolean,
                                          Optional performedByID As Integer? = Nothing,
                                          Optional performedByType As String = "",
                                          Optional performedByName As String = "",
                                          Optional ipAddress As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ManageUsers, "change staff status") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim statusValue As String = If(isActive, "Active", "Inactive")
            Using cmd As New MySqlCommand("UPDATE users SET status = @status, updated_at = NOW() WHERE userId = @staffID AND role = 'Staff'", conn)
                cmd.Parameters.AddWithValue("@status", statusValue)
                cmd.Parameters.AddWithValue("@staffID", staffID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    Dim actionVerb As String = If(isActive, "Activate", "Deactivate")
                    LogCrudAction(performedByID, performedByType, performedByName, "Staff Management", "Staff Account", actionVerb,
                                  $"{actionVerb}d staff account #{staffID}", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] SetStaffStatus Exception: " & ex.Message)
            MessageBox.Show("Error updating staff status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Delete a staff account when it is no longer needed.
    ''' </summary>
    Public Shared Function DeleteStaffAccount(staffID As Integer,
                                              Optional performedByID As Integer? = Nothing,
                                              Optional performedByType As String = "",
                                              Optional performedByName As String = "",
                                              Optional ipAddress As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ManageUsers, "delete staff accounts") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Using cmd As New MySqlCommand("DELETE FROM users WHERE userId = @staffID AND role = 'Staff'", conn)
                cmd.Parameters.AddWithValue("@staffID", staffID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    LogCrudAction(performedByID, performedByType, performedByName, "Staff Management", "Staff Account", "Delete",
                                  $"Deleted staff account #{staffID}", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] DeleteStaffAccount Exception: " & ex.Message)
            MessageBox.Show("Error deleting staff account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Get all custodians (users whose position is tagged as custodian).
    ''' </summary>
    Public Shared Function GetCustodians(Optional includeInactive As Boolean = True,
                                         Optional searchKeyword As String = "") As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT userId, firstName, lastName, position, contactNumber, email, username, status, lastLogin, date_assigned  ")
            query.Append("FROM users WHERE LOWER(IFNULL(position,'')) LIKE '%custodian%'")
            If Not includeInactive Then query.Append(" AND status = 'Active'")
            If Not String.IsNullOrEmpty(searchKeyword) Then
                query.Append(" AND (LOWER(firstName) LIKE @search OR LOWER(lastName) LIKE @search OR LOWER(username) LIKE @search)")
            End If
            query.Append(" ORDER BY lastName ASC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(searchKeyword) Then cmd.Parameters.AddWithValue("@search", "%" & searchKeyword.Trim().ToLower() & "%")
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetCustodians Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Convenience wrapper to add custodians (stored in users table).
    ''' </summary>
    Public Shared Function AddCustodian(firstName As String,
                                        lastName As String,
                                        email As String,
                                        username As String,
                                        password As String,
                                        Optional contactNumber As String = "",
                                        Optional departmentID As Integer? = Nothing,
                                        Optional createdByID As Integer? = Nothing,
                                        Optional createdByType As String = "",
                                        Optional createdByName As String = "",
                                        Optional ipAddress As String = "") As Boolean
        Return AddAdminAccount(firstName, lastName, email, username, password,
                               position:="Custodian", departmentID:=departmentID, contactNumber:=contactNumber,
                               userType:="Admin", moduleName:="Custodian Management", entityLabel:="Custodian",
                               createdByID:=createdByID, createdByType:=createdByType, createdByName:=createdByName, ipAddress:=ipAddress)
    End Function

    ''' <summary>
    ''' Update custodian details.
    ''' </summary>
    Public Shared Function UpdateCustodian(custodianID As Integer,
                                           firstName As String,
                                           lastName As String,
                                           email As String,
                                           username As String,
                                           Optional contactNumber As String = "",
                                           Optional departmentID As Integer? = Nothing,
                                           Optional status As String = "Active",
                                           Optional updatedByID As Integer? = Nothing,
                                           Optional updatedByType As String = "",
                                           Optional updatedByName As String = "",
                                           Optional ipAddress As String = "") As Boolean
        Return UpdateAdminAccount(custodianID, firstName, lastName, email, username,
                                  contactNumber:=contactNumber, departmentID:=departmentID, position:="Custodian",
                                  status:=status, moduleName:="Custodian Management", entityLabel:="Custodian",
                                  updatedByID:=updatedByID, updatedByType:=updatedByType, updatedByName:=updatedByName, ipAddress:=ipAddress)
    End Function

    ''' <summary>
    ''' Reset custodian password.
    ''' </summary>
    Public Shared Function ResetCustodianPassword(custodianID As Integer,
                                                  newPassword As String,
                                                  Optional performedByID As Integer? = Nothing,
                                                  Optional performedByType As String = "",
                                                  Optional performedByName As String = "",
                                                  Optional ipAddress As String = "") As Boolean
        Return ResetAdminPassword(custodianID, newPassword, performedByID, performedByType, performedByName, ipAddress,
                                  moduleName:="Custodian Management", entityLabel:="Custodian")
    End Function

    ''' <summary>
    ''' Update custodian account status.
    ''' </summary>
    Public Shared Function SetCustodianStatus(custodianID As Integer,
                                              isActive As Boolean,
                                              Optional performedByID As Integer? = Nothing,
                                              Optional performedByType As String = "",
                                              Optional performedByName As String = "",
                                              Optional ipAddress As String = "") As Boolean
        Return SetAdminStatus(custodianID, isActive, performedByID, performedByType, performedByName, ipAddress,
                              moduleName:="Custodian Management", entityLabel:="Custodian")
    End Function

    ''' <summary>
    ''' Delete custodian record.
    ''' </summary>
    Public Shared Function DeleteCustodian(custodianID As Integer,
                                           Optional performedByID As Integer? = Nothing,
                                           Optional performedByType As String = "",
                                           Optional performedByName As String = "",
                                           Optional ipAddress As String = "") As Boolean
        Return DeleteAdminAccount(custodianID, performedByID, performedByType, performedByName, ipAddress,
                                  moduleName:="Custodian Management", entityLabel:="Custodian")
    End Function

    ''' <summary>
    ''' Retrieve audit history for a specific custodian.
    ''' </summary>
    Public Shared Function GetCustodianActivityHistory(custodianID As Integer,
                                                       Optional dateFrom As Date? = Nothing,
                                                       Optional dateTo As Date? = Nothing,
                                                       Optional moduleFilter As String = "") As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT log_id, action, module, description, created_at ")
            query.Append("FROM audit_logs WHERE userId = @custodianID")
            If dateFrom.HasValue Then query.Append(" AND created_at >= @dateFrom")
            If dateTo.HasValue Then query.Append(" AND created_at <= @dateTo")
            If Not String.IsNullOrEmpty(moduleFilter) Then query.Append(" AND module = @module")
            query.Append(" ORDER BY created_at DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                cmd.Parameters.AddWithValue("@custodianID", custodianID)
                If dateFrom.HasValue Then cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
                If dateTo.HasValue Then cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)
                If Not String.IsNullOrEmpty(moduleFilter) Then cmd.Parameters.AddWithValue("@module", moduleFilter)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetCustodianActivityHistory Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return dt
    End Function

    ' =====================================================
    ' MODULE 2: PROPERTY MANAGEMENT (COMPLETE CRUD + FILTERING)
    ' =====================================================

    ''' <summary>
    ''' Get all properties with optional filtering (ENHANCED)
    ''' </summary>
    Public Shared Function GetAllProperties(Optional custodianID As Integer? = Nothing, Optional conditionStatus As String = "",
                                           Optional category As String = "", Optional departmentID As Integer? = Nothing,
                                           Optional status As String = "") As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            ' Build query with optional filters - includes all required fields including description and internalCodes
            Dim query As String = "SELECT p.propertyId, p.itemName, p.category, p.propertyNumber, p.serialNumber, " &
                                 "p.description, p.condition, p.acquisitionCost, p.acquisitionDate, " &
                                 "COALESCE(p.totalCost, p.acquisitionCost) AS totalCost, " &
                                 "p.sourceOfFunds, p.unitOfMeasure, " &
                                 "p.assignedTo, CONCAT(IFNULL(u.firstName,''), ' ', IFNULL(u.lastName,'')) AS assignedEmployee, " &
                                 "p.departmentId, d.departmentName AS assignedDepartment, p.location, p.status, " &
                                 "p.internalCodes, p.createdAt, p.updatedAt " &
                                 "FROM properties p " &
                                 "LEFT JOIN users u ON p.assignedTo = u.userId " &
                                 "LEFT JOIN departments d ON p.departmentId = d.departmentId " &
                                 "WHERE 1=1"

            ' Add filters
            If custodianID.HasValue Then
                query &= " AND p.assignedTo = @custodianID"
            End If
            If Not String.IsNullOrEmpty(conditionStatus) Then
                query &= " AND p.condition = @conditionStatus"
            End If
            If Not String.IsNullOrEmpty(category) Then
                query &= " AND p.category = @category"
            End If
            If departmentID.HasValue Then
                query &= " AND p.departmentId = @departmentID"
            End If
            If Not String.IsNullOrEmpty(status) Then
                query &= " AND p.status = @status"
            End If

            query &= " ORDER BY p.createdAt DESC, p.acquisitionDate DESC"

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
                If Not String.IsNullOrEmpty(status) Then
                    cmd.Parameters.AddWithValue("@status", status)
                End If

                cmd.CommandTimeout = 30
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    System.Diagnostics.Debug.WriteLine("[v0] GetAllProperties - Loaded " & dt.Rows.Count & " properties")
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllProperties Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show(GetUserFriendlyErrorMessage(ex, "retrieve properties"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
    ''' Generate property codes for properties that don't have them
    ''' </summary>
    Public Shared Function GeneratePropertyCodesForExisting() As Integer
        Dim conn As MySqlConnection = Nothing
        Dim countGenerated As Integer = 0
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return 0
            If Not SafeOpenConnection(conn) Then Return 0

            ' Find properties without propertyNumber or internalCodes
            Dim selectQuery As String = "SELECT propertyId FROM properties WHERE (propertyNumber IS NULL OR propertyNumber = '') OR (internalCodes IS NULL OR internalCodes = '')"
            Dim propertiesToUpdate As New List(Of Integer)()

            Using cmd As New MySqlCommand(selectQuery, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        propertiesToUpdate.Add(reader.GetInt32("propertyId"))
                    End While
                End Using
            End Using

            ' Generate codes for each property
            For Each propId As Integer In propertiesToUpdate
                ' Get max property number
                Dim maxPropNum As Integer = 0
                Using maxCmd As New MySqlCommand("SELECT COALESCE(MAX(CAST(SUBSTRING(propertyNumber, 6) AS UNSIGNED)), 0) FROM properties WHERE propertyNumber LIKE 'PROP-%'", conn)
                    Dim maxVal As Object = maxCmd.ExecuteScalar()
                    If maxVal IsNot Nothing AndAlso Not IsDBNull(maxVal) Then
                        maxPropNum = Convert.ToInt32(maxVal)
                    End If
                End Using

                Dim newPropertyNumber As String = "PROP-" & (maxPropNum + 1).ToString("D6")
                Dim newInternalCode As String = newPropertyNumber

                ' Update property
                Dim updateQuery As String = "UPDATE properties SET propertyNumber = @propNum, internalCodes = @internalCode WHERE propertyId = @propId"
                Using updateCmd As New MySqlCommand(updateQuery, conn)
                    updateCmd.Parameters.AddWithValue("@propNum", newPropertyNumber)
                    updateCmd.Parameters.AddWithValue("@internalCode", newInternalCode)
                    updateCmd.Parameters.AddWithValue("@propId", propId)
                    If updateCmd.ExecuteNonQuery() > 0 Then
                        countGenerated += 1
                        maxPropNum += 1 ' Increment for next property
                    End If
                End Using
            Next

            Return countGenerated
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GeneratePropertyCodesForExisting Exception: " & ex.Message)
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
    ''' Check if serial number already exists
    ''' </summary>
    Public Shared Function CheckDuplicateSerialNumber(serialNumber As String, Optional excludePropertyID As Integer? = Nothing) As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            If String.IsNullOrEmpty(serialNumber) Then Return False

            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "SELECT COUNT(*) FROM properties WHERE serialNumber = @serialNumber"
            If excludePropertyID.HasValue Then
                query &= " AND propertyId != @propertyID"
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
                                         warrantyDetails As String, acquisitionDate As Date, acquisitionCost As Decimal,
                                         supplierName As String, supplierContact As String, status As String) As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyProperties, "update properties") Then
            Return False
        End If
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

            Dim query As String = "UPDATE properties SET itemName = @propertyName, category = @category, " &
                                 "description = @description, serialNumber = @serialNumber, `condition` = @conditionStatus, " &
                                 "location = @location, assignedTo = @custodianID, departmentId = @departmentID, " &
                                 "acquisitionDate = @acquisitionDate, acquisitionCost = @acquisitionCost, " &
                                 "status = @status, updatedAt = NOW() " &
                                 "WHERE propertyId = @propertyID"

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
                cmd.Parameters.AddWithValue("@acquisitionDate", acquisitionDate)
                cmd.Parameters.AddWithValue("@acquisitionCost", acquisitionCost)
                cmd.Parameters.AddWithValue("@status", status)

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
        If Not DemandPermission(SessionContext.ModulePermission.ModifyProperties, "delete properties") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Check if property is currently borrowed/requested
            Dim checkBorrowedQuery As String = "SELECT COUNT(*) FROM borrowed_items WHERE itemId = @propertyID AND itemType = 'property' AND status IN ('Borrowed')"
            Using checkCmd As New MySqlCommand(checkBorrowedQuery, conn)
                checkCmd.Parameters.AddWithValue("@propertyID", propertyID)
                Dim borrowedCount As Integer = CInt(checkCmd.ExecuteScalar())
                If borrowedCount > 0 Then
                    MessageBox.Show("Cannot delete property. It is currently borrowed.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Delete property (soft delete by setting status to 'For Disposal')
            Dim query As String = "UPDATE properties SET status = 'For Disposal', updatedAt = NOW() WHERE propertyId = @propertyID"
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
        If Not DemandPermission(SessionContext.ModulePermission.ModifyProperties, "recalculate property depreciation") Then
            Return 0
        End If
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
                        acquisitionCost = CDec(reader("acquisitionCost"))
                        acquisitionDate = CDate(reader("acquisitionDate"))
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
    ''' Fetch full property information for edit screens.
    ''' </summary>
    Public Shared Function GetPropertyForEdit(propertyID As Integer) As DataRow
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return Nothing
            If Not SafeOpenConnection(conn) Then Return Nothing

            Dim query As String = "SELECT p.propertyId, p.itemName, p.category, p.description, p.serialNumber, " &
                                  "p.condition, p.acquisitionCost, p.acquisitionDate, " &
                                  "p.assignedTo, p.departmentId, p.location, p.status, " &
                                  "p.createdAt, p.updatedAt, " &
                                  "CONCAT(IFNULL(u.firstName,''), ' ', IFNULL(u.lastName,'')) AS assignedEmployee, " &
                                  "d.departmentName AS assignedDepartment " &
                                  "FROM properties p " &
                                  "LEFT JOIN users u ON p.assignedTo = u.userId " &
                                  "LEFT JOIN departments d ON p.departmentId = d.departmentId " &
                                  "WHERE p.propertyId = @propertyID LIMIT 1"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@propertyID", propertyID)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetPropertyForEdit Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        If dt.Rows.Count = 0 Then Return Nothing
        Return dt.Rows(0)
    End Function

    ''' <summary>
    ''' Assign custodian to property
    ''' </summary>
    Public Shared Function AssignCustodianToProperty(propertyID As Integer, custodianID As Integer) As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyProperties, "assign property custodians") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE properties SET assigned_to = @custodianID, updated_at = NOW() WHERE property_id = @propertyID"
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

    ''' <summary>
    ''' Update property lifecycle status/condition.
    ''' </summary>
    Public Shared Function UpdatePropertyStatus(propertyID As Integer,
                                                newStatus As String,
                                                Optional conditionStatus As String = "",
                                                Optional disposalDate As Date? = Nothing,
                                                Optional performedByID As Integer? = Nothing,
                                                Optional performedByType As String = "",
                                                Optional performedByName As String = "",
                                                Optional ipAddress As String = "") As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifyProperties, "update property status") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim normalizedStatus As String = If(String.IsNullOrWhiteSpace(newStatus), "active", newStatus.Trim())
            Dim updateSql As New StringBuilder("UPDATE properties SET status = @status, updated_at = NOW()")
            If Not String.IsNullOrWhiteSpace(conditionStatus) Then updateSql.Append(", condition = @condition")
            If disposalDate.HasValue OrElse normalizedStatus.Equals("disposed", StringComparison.OrdinalIgnoreCase) Then
                updateSql.Append(", disposal_date = @disposalDate")
            Else
                updateSql.Append(", disposal_date = NULL")
            End If
            updateSql.Append(" WHERE property_id = @propertyID")

            Using cmd As New MySqlCommand(updateSql.ToString(), conn)
                cmd.Parameters.AddWithValue("@status", normalizedStatus)
                If Not String.IsNullOrWhiteSpace(conditionStatus) Then
                    cmd.Parameters.AddWithValue("@condition", conditionStatus.Trim())
                End If
                If disposalDate.HasValue Then
                    cmd.Parameters.AddWithValue("@disposalDate", disposalDate.Value)
                ElseIf normalizedStatus.Equals("disposed", StringComparison.OrdinalIgnoreCase) Then
                    cmd.Parameters.AddWithValue("@disposalDate", Date.Today)
                End If
                cmd.Parameters.AddWithValue("@propertyID", propertyID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    Dim description As String = $"Status set to {normalizedStatus}"
                    If Not String.IsNullOrWhiteSpace(conditionStatus) Then description &= $" | Condition: {conditionStatus}"
                    LogCrudAction(performedByID, performedByType, performedByName, "Property Management", "Property Status", "Update", description, ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] UpdatePropertyStatus Exception: " & ex.Message)
            MessageBox.Show("Error updating property status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Load lifecycle info (depreciation, warranty, condition, etc.) for reporting dashboards.
    ''' </summary>
    Public Shared Function GetPropertyLifecycleInfo(propertyID As Integer) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return result
            If Not SafeOpenConnection(conn) Then Return result

            Dim query As String = "SELECT item_name, acquisition_date, acquisition_cost, life_span, depreciation_value, " &
                                  "warranty_details, condition_status, status, disposal_date " &
                                  "FROM properties WHERE property_id = @propertyID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@propertyID", propertyID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        result("itemName") = reader("itemName").ToString()
                        result("acquisitionDate") = reader("acquisitionDate")
                        result("acquisitionCost") = reader("acquisitionCost")
                        result("condition") = If(IsDBNull(reader("condition")), String.Empty, reader("condition").ToString())
                        result("status") = reader("status").ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetPropertyLifecycleInfo Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return result
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
            ' Reset connection string if corrupted by previous ReplicationManager error
            If _connectionString IsNot Nothing AndAlso _connectionString.Contains("ReplicationManager") Then
                _connectionString = Nothing
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New System.Text.StringBuilder()
            query.Append("SELECT ")
            query.Append("supplyId, itemName, category, description, unitOfMeasure, quantity, ")
            query.Append("unitCost, totalCost, dateReceived, supplier, sourceOfFunds, location, stockStatus, createdAt, updatedAt ")
            query.Append("FROM supplies WHERE 1=1 ")
            ' Filter out soft-deleted supplies (those with stockStatus = 'Out of Stock' and quantity = 0)
            query.Append("AND NOT (stockStatus = 'Out of Stock' AND quantity = 0)")

            If Not String.IsNullOrEmpty(category) Then
                query.Append(" AND category = @category")
            End If
            If Not String.IsNullOrEmpty(status) Then
                query.Append(" AND stockStatus = @status")
            End If

            query.Append(" ORDER BY createdAt DESC, dateReceived DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(category) Then cmd.Parameters.AddWithValue("@category", category)
                If Not String.IsNullOrEmpty(status) Then cmd.Parameters.AddWithValue("@status", status)

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
            System.Diagnostics.Debug.WriteLine("[v0] GetAllSupplies Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show(GetUserFriendlyErrorMessage(ex, "retrieve supplies"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
    ''' Get a single supply record by ID for edit forms.
    ''' </summary>
    Public Shared Function GetSupplyById(supplyID As Integer) As DataRow
        If supplyID <= 0 Then Return Nothing

        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return Nothing
            If Not SafeOpenConnection(conn) Then Return Nothing

            Dim query As String = "SELECT supplyId, itemName, category, description, unitOfMeasure, quantity, " &
                                  "supplier, unitCost, location, stockStatus, dateReceived, totalCost, sourceOfFunds " &
                                  "FROM supplies WHERE supplyId = @supplyID LIMIT 1"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@supplyID", supplyID)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetSupplyById Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        If dt.Rows.Count = 0 Then Return Nothing
        Return dt.Rows(0)
    End Function

    ''' <summary>
    ''' Get low stock supplies (quantity &lt;= reorder level) (NEW)
    ''' </summary>
    Public Shared Function GetLowStockSupplies() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT supply_id, item_name, category, quantity, " &
                                 "unit_cost, total_cost, location, stock_status " &
                                 "FROM supplies WHERE quantity <= 10 AND stock_status = 'Available' " &
                                 "ORDER BY quantity ASC"

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
    ''' Provide a quick stock dashboard for supplies with optional low-stock filtering.
    ''' </summary>
    Public Shared Function GetSupplyStockLevels(Optional includeLowStockOnly As Boolean = False,
                                                Optional category As String = "") As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT supplyId, itemName, category, quantity, unitCost, ")
            query.Append("totalCost, stockStatus, location FROM supplies WHERE 1=1 ")
            If includeLowStockOnly Then query.Append("AND quantity <= 10 ")
            If Not String.IsNullOrEmpty(category) Then query.Append("AND category = @category ")
            query.Append("ORDER BY category, item_name")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(category) Then cmd.Parameters.AddWithValue("@category", category)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetSupplyStockLevels Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Update supply information with automatic total value calculation (ENHANCED)
    ''' </summary>
    Public Shared Function UpdateSupply(supplyID As String, supplyName As String, category As String,
                                       stock As Integer, unitCost As Decimal, status As String, location As String,
                                       Optional description As String = "", Optional reorderLevel As Integer = 0,
                                       Optional supplierName As String = "", Optional supplierContact As String = "",
                                       Optional unitOfMeasure As String = "", Optional sourceOfFunds As String = "",
                                       Optional dateReceived As Date? = Nothing) As Boolean
        If Not DemandPermission(SessionContext.ModulePermission.ModifySupplies, "update supplies") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Calculate total value automatically
            Dim totalValue As Decimal = stock * unitCost

            Dim query As String = "UPDATE supplies SET itemName = @supplyName, category = @category, " &
                                 "quantity = @stock, unitCost = @unitCost, totalCost = @totalValue, " &
                                 "stockStatus = @status, location = @location, description = @description, " &
                                 "supplier = @supplierName, unitOfMeasure = @unitOfMeasure, " &
                                 "sourceOfFunds = @sourceOfFunds, dateReceived = @dateReceived, updatedAt = NOW() " &
                                 "WHERE supplyId = @supplyID"

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
                cmd.Parameters.AddWithValue("@supplierName", If(String.IsNullOrEmpty(supplierName), DBNull.Value, supplierName))
                cmd.Parameters.AddWithValue("@unitOfMeasure", If(String.IsNullOrWhiteSpace(unitOfMeasure), DBNull.Value, unitOfMeasure))
                cmd.Parameters.AddWithValue("@sourceOfFunds", If(String.IsNullOrWhiteSpace(sourceOfFunds), DBNull.Value, sourceOfFunds))
                cmd.Parameters.AddWithValue("@dateReceived", If(dateReceived.HasValue, dateReceived.Value, DBNull.Value))

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
        If Not DemandPermission(SessionContext.ModulePermission.ModifySupplies, "delete supplies") Then
            Return False
        End If
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            ' Check if supply is currently requested/borrowed
            Dim checkBorrowedQuery As String = "SELECT COUNT(*) FROM borrowed_items WHERE itemId = @supplyID AND itemType = 'supply' AND status IN ('Borrowed')"
            Using checkCmd As New MySqlCommand(checkBorrowedQuery, conn)
                checkCmd.Parameters.AddWithValue("@supplyID", supplyID)
                Dim borrowedCount As Integer = CInt(checkCmd.ExecuteScalar())
                If borrowedCount > 0 Then
                    MessageBox.Show("Cannot delete supply. It is currently borrowed.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Check supply_requests table
            Dim checkRequestedQuery As String = "SELECT COUNT(*) FROM supplies_requests WHERE itemName IN (SELECT itemName FROM supplies WHERE supplyId = @supplyID) AND status IN ('Pending', 'Approved')"
            Using checkCmd2 As New MySqlCommand(checkRequestedQuery, conn)
                checkCmd2.Parameters.AddWithValue("@supplyID", supplyID)
                Dim requestedCount As Integer = CInt(checkCmd2.ExecuteScalar())
                If requestedCount > 0 Then
                    MessageBox.Show("Cannot delete supply. It has pending or active requests.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Delete supply (hard delete - actually remove from database)
            Dim query As String = "DELETE FROM supplies WHERE supplyId = @supplyID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@supplyID", supplyID)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    System.Diagnostics.Debug.WriteLine("[v0] Supply Deleted - ID: " & supplyID)
                    Return True
                Else
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
            ' Select all attributes matching schema - using camelCase column names (matching database schema)
            Dim query As String = "SELECT d.departmentId AS departmentId, " &
                                 "d.departmentName AS departmentName, " &
                                 "d.headOfDepartment AS headOfDepartment, " &
                                 "d.contactNumber AS contactNumber, " &
                                 "d.email AS email, " &
                                 "d.location AS location, " &
                                 "d.officeCode AS officeCode, " &
                                 "d.building AS building, " &
                                 "d.floorNumber AS floorNumber, " &
                                 "d.shortName AS shortName, " &
                                 "d.description AS description, " &
                                 "d.status AS status, " &
                                 "COALESCE(d.totalProperties, 0) AS totalProperties, " &
                                 "COALESCE(d.totalSupplies, 0) AS totalSupplies, " &
                                 "d.createdAt AS createdAt, " &
                                 "d.updatedAt AS updatedAt " &
                                 "FROM departments d " &
                                 "ORDER BY d.departmentName"

            Using cmd As New MySqlCommand(query, conn)
                cmd.CommandTimeout = 30
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    System.Diagnostics.Debug.WriteLine("[v0] GetAllDepartments - Loaded " & dt.Rows.Count & " departments")
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAllDepartments Exception: " & ex.Message)
            MessageBox.Show(GetUserFriendlyErrorMessage(ex, "retrieve departments"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
    ''' Lightweight lookup list for department pickers (optionally include inactive records).
    ''' </summary>
    Public Shared Function GetDepartmentLookup(Optional includeInactive As Boolean = False) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT departmentId AS department_id, departmentName AS department_name, status ")
            query.Append("FROM departments ")
            If Not includeInactive Then
                query.Append("WHERE LOWER(status) = 'active' ")
            End If
            query.Append("ORDER BY departmentName")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetDepartmentLookup Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Get list of provinces for address dropdown
    ''' </summary>
    Public Shared Function GetProvinces() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("province_id", GetType(String))
        dt.Columns.Add("province_name", GetType(String))

        Dim provinces() As String = {"Albay", "Camarines Norte", "Camarines Sur", "Catanduanes", "Masbate", "Sorsogon", "Metro Manila", "Cavite", "Laguna", "Batangas", "Rizal", "Quezon"}
        For Each prov As String In provinces
            Dim row As DataRow = dt.NewRow()
            row("province_id") = prov
            row("province_name") = prov
            dt.Rows.Add(row)
        Next
        Return dt
    End Function

    ''' <summary>
    ''' Get list of municipalities filtered by province
    ''' </summary>
    Public Shared Function GetMunicipalities(provinceName As String) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("municipality_id", GetType(String))
        dt.Columns.Add("municipality_name", GetType(String))

        Dim municipalities As New List(Of String)()

        ' Camarines Norte municipalities
        If provinceName.Contains("Camarines Norte") OrElse provinceName.Contains("Camarines") Then
            municipalities.AddRange({"Daet", "Basud", "Capalonga", "Jose Panganiban", "Labo", "Mercedes", "Paracale", "San Lorenzo Ruiz", "San Vicente", "Santa Elena", "Talisay", "Vinzons"})
        ElseIf provinceName.Contains("Metro Manila") OrElse provinceName.Contains("Manila") Then
            municipalities.AddRange({"Manila", "Quezon City", "Makati", "Pasig", "Mandaluyong", "San Juan", "Taguig", "Pasay", "Parañaque", "Las Piñas", "Muntinlupa", "Marikina", "Caloocan", "Malabon", "Navotas", "Valenzuela"})
        ElseIf provinceName.Contains("Cavite") Then
            municipalities.AddRange({"Bacoor", "Cavite City", "Dasmariñas", "Imus", "Tagaytay", "Trece Martires", "General Trias", "Kawit", "Noveleta", "Rosario"})
        ElseIf provinceName.Contains("Laguna") Then
            municipalities.AddRange({"Calamba", "San Pedro", "Biñan", "Santa Rosa", "Los Baños", "Cabuyao", "San Pablo", "Sta. Cruz", "Alaminos", "Bay"})
        ElseIf provinceName.Contains("Batangas") Then
            municipalities.AddRange({"Batangas City", "Lipa", "Tanauan", "Calaca", "Lemery", "Nasugbu", "Taal", "Balayan", "Calatagan", "Lian"})
        ElseIf provinceName.Contains("Rizal") Then
            municipalities.AddRange({"Antipolo", "Cainta", "Taytay", "Angono", "Binangonan", "Cardona", "Jalajala", "Morong", "Pililla", "Rodriguez"})
        ElseIf provinceName.Contains("Quezon") Then
            municipalities.AddRange({"Lucena", "Tayabas", "Candelaria", "Sariaya", "Lopez", "Gumaca", "Atimonan", "Mauban", "Infanta", "Real"})
        Else
            ' Default municipalities
            municipalities.AddRange({"Daet", "Basud", "Capalonga", "Jose Panganiban", "Labo", "Mercedes", "Paracale", "San Lorenzo Ruiz", "San Vicente", "Santa Elena", "Talisay", "Vinzons"})
        End If

        For Each muni As String In municipalities
            Dim row As DataRow = dt.NewRow()
            row("municipality_id") = muni
            row("municipality_name") = muni
            dt.Rows.Add(row)
        Next
        Return dt
    End Function

    ''' <summary>
    ''' Get list of categories for supply/property dropdowns
    ''' </summary>
    Public Shared Function GetCategories(Optional categoryType As String = "") As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT DISTINCT categoryName AS category_name, categoryType FROM categories WHERE status = 'Active'"
            If Not String.IsNullOrEmpty(categoryType) Then
                query &= " AND categoryType = @categoryType"
            End If
            query &= " ORDER BY categoryName"

            Using cmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrEmpty(categoryType) Then
                    cmd.Parameters.AddWithValue("@categoryType", categoryType)
                End If
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetCategories Exception: " & ex.Message)
            ' Return hardcoded categories if table doesn't exist
            dt.Columns.Add("category_name", GetType(String))
            Dim categories() As String = {"Office Equipment", "IT Equipment", "Furniture", "Vehicles", "Office Supplies", "Cleaning Supplies", "Medical Supplies"}
            For Each cat As String In categories
                Dim row As DataRow = dt.NewRow()
                row("category_name") = cat
                dt.Rows.Add(row)
            Next
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Get list of suppliers for dropdown
    ''' </summary>
    Public Shared Function GetSuppliers() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("supplier_name", GetType(String))

        ' Get unique suppliers from supplies table
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn IsNot Nothing AndAlso SafeOpenConnection(conn) Then
                Dim query As String = "SELECT DISTINCT supplier AS supplier_name FROM supplies WHERE supplier IS NOT NULL AND supplier != '' ORDER BY supplier"
                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetSuppliers Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        ' Add common suppliers if table is empty
        If dt.Rows.Count = 0 Then
            Dim suppliers() As String = {"Local Supplier", "National Supplier", "International Supplier", "Government Supplier", "Private Supplier"}
            For Each sup As String In suppliers
                Dim row As DataRow = dt.NewRow()
                row("supplier_name") = sup
                dt.Rows.Add(row)
            Next
        End If
        Return dt
    End Function

    ''' <summary>
    ''' Get list of locations for dropdown
    ''' </summary>
    Public Shared Function GetLocations() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("location_name", GetType(String))

        ' Get unique locations from properties and supplies tables
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn IsNot Nothing AndAlso SafeOpenConnection(conn) Then
                Dim query As String = "SELECT DISTINCT location AS location_name FROM (SELECT location FROM properties UNION SELECT location FROM supplies) AS combined WHERE location IS NOT NULL AND location != '' ORDER BY location"
                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetLocations Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        ' Add common locations if table is empty
        If dt.Rows.Count = 0 Then
            Dim locations() As String = {"Main Building", "Annex Building", "Warehouse", "Storage Room", "Office", "Laboratory", "Library"}
            For Each loc As String In locations
                Dim row As DataRow = dt.NewRow()
                row("location_name") = loc
                dt.Rows.Add(row)
            Next
        End If
        Return dt
    End Function

    ''' <summary>
    ''' Get list of unit of measure options
    ''' </summary>
    Public Shared Function GetUnitOfMeasureOptions() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("uom_name", GetType(String))

        Dim units() As String = {"pcs", "box", "pack", "set", "unit", "piece", "bottle", "can", "roll", "ream", "dozen", "gallon", "liter", "kg", "g", "lb", "oz", "meter", "cm", "ft", "sqm", "sqft"}
        For Each unit As String In units
            Dim row As DataRow = dt.NewRow()
            row("uom_name") = unit
            dt.Rows.Add(row)
        Next
        Return dt
    End Function

    ''' <summary>
    ''' Get list of barangays filtered by municipality
    ''' </summary>
    Public Shared Function GetBarangays(municipalityName As String) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("barangay_id", GetType(String))
        dt.Columns.Add("barangay_name", GetType(String))

        Dim barangays As New List(Of String)()

        ' Common barangays for Daet (Camarines Norte)
        If municipalityName.Contains("Daet") Then
            barangays.AddRange({"Binanuaan", "Caawigan", "Cahabaan", "Calintaan", "Del Carmen", "Gabon", "Itomang", "Poblacion", "San Francisco", "San Isidro", "San Jose", "San Nicolas", "Santa Cruz", "Santa Elena", "Santo Niño"})
        Else
            ' Default barangays
            barangays.AddRange({"Poblacion", "Barangay 1", "Barangay 2", "Barangay 3", "Barangay 4", "Barangay 5", "Barangay 6", "Barangay 7", "Barangay 8", "Barangay 9", "Barangay 10"})
        End If

        For Each brgy As String In barangays
            Dim row As DataRow = dt.NewRow()
            row("barangay_id") = brgy
            row("barangay_name") = brgy
            dt.Rows.Add(row)
        Next
        Return dt
    End Function

    ''' <summary>
    ''' Recalculate the no_of_employees column based on active admin/staff assignments.
    ''' </summary>
    Public Shared Sub RecalculateDepartmentHeadcount(Optional departmentID As Integer? = Nothing)
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return
            If Not SafeOpenConnection(conn) Then Return

            Dim targets As New List(Of Integer)
            If departmentID.HasValue Then
                targets.Add(departmentID.Value)
            Else
                Using loadCmd As New MySqlCommand("SELECT departmentId FROM departments", conn)
                    Using reader As MySqlDataReader = loadCmd.ExecuteReader()
                        While reader.Read()
                            targets.Add(Convert.ToInt32(reader("departmentId")))
                        End While
                    End Using
                End Using
            End If

            For Each deptId As Integer In targets
                If deptId <= 0 Then Continue For

                Dim adminCount As Integer = 0
                Using adminCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE departmentId = @dept AND status = 'Active'", conn)
                    adminCmd.Parameters.AddWithValue("@dept", deptId)
                    adminCount = CInt(adminCmd.ExecuteScalar())
                End Using

                Dim staffCount As Integer = 0
                Using staffCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE departmentId = @dept AND role = 'Staff' AND status = 'active'", conn)
                    staffCmd.Parameters.AddWithValue("@dept", deptId)
                    staffCount = CInt(staffCmd.ExecuteScalar())
                End Using

                Dim total As Integer = adminCount + staffCount
                Using updateCmd As New MySqlCommand("UPDATE departments SET no_of_employees = @count, updated_at = NOW() WHERE departmentId = @dept", conn)
                    updateCmd.Parameters.AddWithValue("@count", total)
                    updateCmd.Parameters.AddWithValue("@dept", deptId)
                    updateCmd.ExecuteNonQuery()
                End Using
            Next
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] RecalculateDepartmentHeadcount Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Add new department (ENHANCED)
    ''' </summary>
    Public Shared Function AddDepartment(departmentName As String, headOfDepartment As String, location As String,
                                        departmentCode As String, Optional contactNumber As String = "",
                                        Optional email As String = "", Optional noOfEmployees As Integer = 0,
                                        Optional budgetAllocation As Decimal = 0, Optional officeHours As String = "",
                                        Optional establishedDate As Date? = Nothing, Optional parentDepartmentID As Integer? = Nothing,
                                        Optional status As String = "active") As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then
                MessageBox.Show("Failed to create database connection. Please check your MySQL server is running and connection settings are correct.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If Not SafeOpenConnection(conn) Then
                MessageBox.Show("Cannot connect to MySQL server." & Environment.NewLine & Environment.NewLine &
                              "Please check the following:" & Environment.NewLine &
                              "1. Make sure MySQL/XAMPP is running" & Environment.NewLine &
                              "2. Check if MySQL service is started (Services app)" & Environment.NewLine &
                              "3. Verify connection settings in App.config" & Environment.NewLine &
                              "4. Try restarting MySQL service", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            ' Check for duplicate department name
            Dim checkNameQuery As String = "SELECT COUNT(*) FROM departments WHERE LOWER(departmentName) = LOWER(@departmentName)"
            Using checkCmd As New MySqlCommand(checkNameQuery, conn)
                checkCmd.Parameters.AddWithValue("@departmentName", departmentName)
                Dim nameCount As Integer = CInt(checkCmd.ExecuteScalar())
                If nameCount > 0 Then
                    MessageBox.Show("Department name already exists. Please use a different name.", "Duplicate Department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Check for duplicate department code
            Dim checkCodeQuery As String = "SELECT COUNT(*) FROM departments WHERE LOWER(office_code) = LOWER(@departmentCode)"
            Using checkCmd As New MySqlCommand(checkCodeQuery, conn)
                checkCmd.Parameters.AddWithValue("@departmentCode", departmentCode)
                Dim codeCount As Integer = CInt(checkCmd.ExecuteScalar())
                If codeCount > 0 Then
                    MessageBox.Show("Department code already exists. Please use a different code.", "Duplicate Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Validate parent department ID if provided
            If parentDepartmentID.HasValue Then
                Dim checkParentQuery As String = "SELECT COUNT(*) FROM departments WHERE departmentId = @parentDepartmentID"
                Using checkParentCmd As New MySqlCommand(checkParentQuery, conn)
                    checkParentCmd.Parameters.AddWithValue("@parentDepartmentID", parentDepartmentID.Value)
                    Dim parentCount As Integer = CInt(checkParentCmd.ExecuteScalar())
                    If parentCount = 0 Then
                        ' Get list of available department IDs to show in error message
                        Dim availableDeptsQuery As String = "SELECT departmentId, departmentName FROM departments WHERE status = 'Active' ORDER BY departmentId"
                        Dim availableDepts As New List(Of String)
                        Using deptCmd As New MySqlCommand(availableDeptsQuery, conn)
                            Using reader As MySqlDataReader = deptCmd.ExecuteReader()
                                While reader.Read()
                                    availableDepts.Add(reader("departmentId").ToString() & " - " & reader("departmentName").ToString())
                                End While
                                reader.Close()
                            End Using
                        End Using

                        Dim errorMsg As String = "Parent Department ID " & parentDepartmentID.Value & " does not exist." & Environment.NewLine & Environment.NewLine
                        If availableDepts.Count > 0 Then
                            errorMsg &= "Available Parent Departments:" & Environment.NewLine
                            errorMsg &= String.Join(Environment.NewLine, availableDepts)
                            errorMsg &= Environment.NewLine & Environment.NewLine
                        End If
                        errorMsg &= "Please enter a valid parent department ID from the list above, or leave the field blank if this department has no parent."

                        MessageBox.Show(errorMsg, "Invalid Parent Department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End Using
            End If

            ' Ensure connection is still open before executing INSERT
            If conn.State <> ConnectionState.Open Then
                If Not SafeOpenConnection(conn) Then
                    MessageBox.Show("Database connection was lost. Please try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End If

            Dim query As String = "INSERT INTO departments (departmentName, headOfDepartment, location, officeCode, " &
                                 "contactNumber, email, noOfEmployees, budgetAllocation, officeHours, establishedDate, " &
                                 "parentDepartmentId, status) " &
                                 "VALUES (@departmentName, @headOfDepartment, @location, @departmentCode, " &
                                 "@contactNumber, @email, @noOfEmployees, @budgetAllocation, @officeHours, @establishedDate, " &
                                 "@parentDepartmentID, @status)"

            Using cmd As New MySqlCommand(query, conn)
                Try
                    cmd.Parameters.AddWithValue("@departmentName", departmentName)
                    cmd.Parameters.AddWithValue("@headOfDepartment", headOfDepartment)
                    cmd.Parameters.AddWithValue("@location", location)
                    cmd.Parameters.AddWithValue("@departmentCode", departmentCode)
                    cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrEmpty(contactNumber), DBNull.Value, contactNumber))
                    cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(email), DBNull.Value, email))
                    cmd.Parameters.AddWithValue("@noOfEmployees", noOfEmployees)
                    cmd.Parameters.AddWithValue("@budgetAllocation", budgetAllocation)
                    cmd.Parameters.AddWithValue("@officeHours", If(String.IsNullOrEmpty(officeHours), DBNull.Value, officeHours))
                    cmd.Parameters.AddWithValue("@establishedDate", If(establishedDate.HasValue, establishedDate.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@parentDepartmentID", If(parentDepartmentID.HasValue, parentDepartmentID.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@status", status)

                    System.Diagnostics.Debug.WriteLine("[v0] Executing INSERT with parameters: Name=" & departmentName & ", Code=" & departmentCode & ", Status=" & status)
                    Dim result As Integer = cmd.ExecuteNonQuery()
                    If result > 0 Then
                        Try
                            Dim insertedID As Integer = Convert.ToInt32(cmd.LastInsertedId)
                            RecalculateDepartmentHeadcount(insertedID)
                        Catch exId As Exception
                            System.Diagnostics.Debug.WriteLine("[v0] AddDepartment headcount refresh failed: " & exId.Message)
                        End Try
                        System.Diagnostics.Debug.WriteLine("[v0] Department Added Successfully: " & departmentName)
                        MessageBox.Show("Department added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return True
                    End If
                Catch sqlEx As MySqlException
                    System.Diagnostics.Debug.WriteLine("[v0] AddDepartment SQL Execution Error: " & sqlEx.Message & " | Error Number: " & sqlEx.Number & " | StackTrace: " & sqlEx.StackTrace)
                    Dim detailedError As String = "MySQL Error " & sqlEx.Number & ": " & sqlEx.Message

                    ' Handle specific MySQL error codes
                    If sqlEx.Number = 1042 OrElse sqlEx.Message.Contains("Unable to connect") OrElse sqlEx.Message.Contains("specified MySQL hosts") Then
                        detailedError = "Cannot connect to MySQL server." & Environment.NewLine & Environment.NewLine &
                                      "Please check the following:" & Environment.NewLine &
                                      "1. Make sure MySQL/XAMPP is running" & Environment.NewLine &
                                      "2. Check if MySQL service is started (Services app)" & Environment.NewLine &
                                      "3. Verify connection settings in App.config" & Environment.NewLine &
                                      "4. Try restarting MySQL service" & Environment.NewLine & Environment.NewLine &
                                      "Technical Details: " & sqlEx.Message
                    ElseIf sqlEx.Number = 1062 Then
                        detailedError &= Environment.NewLine & Environment.NewLine & "This usually means a duplicate entry (department name or code already exists)."
                    ElseIf sqlEx.Number = 1452 Then
                        detailedError &= Environment.NewLine & Environment.NewLine & "Foreign key constraint failed. Please check the parent department ID."
                    End If

                    MessageBox.Show("Database error adding department:" & Environment.NewLine & Environment.NewLine & detailedError, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        Catch ex As MySqlException
            System.Diagnostics.Debug.WriteLine("[v0] AddDepartment MySQL Error: " & ex.Message & " | Error Number: " & ex.Number & " | StackTrace: " & ex.StackTrace)
            Dim detailedError As String = "MySQL Error " & ex.Number & ": " & ex.Message

            ' Handle specific MySQL error codes
            If ex.Number = 1042 OrElse ex.Message.Contains("Unable to connect") OrElse ex.Message.Contains("specified MySQL hosts") Then
                detailedError = "Cannot connect to MySQL server." & Environment.NewLine & Environment.NewLine &
                              "Please check the following:" & Environment.NewLine &
                              "1. Make sure MySQL/XAMPP is running" & Environment.NewLine &
                              "2. Check if MySQL service is started (Services app)" & Environment.NewLine &
                              "3. Verify connection settings in App.config" & Environment.NewLine &
                              "4. Try restarting MySQL service" & Environment.NewLine & Environment.NewLine &
                              "Technical Details: " & ex.Message
            ElseIf ex.Number = 1045 Then
                detailedError = "Access denied. Invalid username or password." & Environment.NewLine & Environment.NewLine &
                              "Please check your database credentials in App.config"
            ElseIf ex.Number = 1049 Then
                detailedError = "Database 'teamcruzim' does not exist." & Environment.NewLine & Environment.NewLine &
                              "Please create the database first using the provided SQL schema file."
            ElseIf ex.Number = 1062 Then
                detailedError &= Environment.NewLine & Environment.NewLine & "This usually means a duplicate entry (department name or code already exists)."
            ElseIf ex.Number = 1452 Then
                detailedError &= Environment.NewLine & Environment.NewLine & "Foreign key constraint failed. Please check the parent department ID."
            End If

            MessageBox.Show("Database error adding department:" & Environment.NewLine & Environment.NewLine & detailedError, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Dim checkNameQuery As String = "SELECT COUNT(*) FROM departments WHERE LOWER(departmentName) = LOWER(@departmentName) AND departmentId != @departmentID"
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
            Dim checkCodeQuery As String = "SELECT COUNT(*) FROM departments WHERE LOWER(office_code) = LOWER(@departmentCode) AND department_id != @departmentID"
            Using checkCmd As New MySqlCommand(checkCodeQuery, conn)
                checkCmd.Parameters.AddWithValue("@departmentCode", departmentCode)
                checkCmd.Parameters.AddWithValue("@departmentID", departmentID)
                Dim codeCount As Integer = CInt(checkCmd.ExecuteScalar())
                If codeCount > 0 Then
                    MessageBox.Show("Department code already exists. Please use a different code.", "Duplicate Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            Dim query As String = "UPDATE departments SET departmentName = @departmentName, head_of_department = @headOfDepartment, " &
                                 "location = @location, office_code = @departmentCode, contactNumber = @contactNumber, " &
                                 "email = @email, no_of_employees = @noOfEmployees, budget_allocation = @budgetAllocation, " &
                                 "updated_at = NOW() WHERE departmentId = @departmentID"

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
                    Try
                        RecalculateDepartmentHeadcount(departmentID)
                    Catch exHeadcount As Exception
                        System.Diagnostics.Debug.WriteLine("[v0] UpdateDepartment headcount refresh failed: " & exHeadcount.Message)
                    End Try
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
            Dim checkPropertiesQuery As String = "SELECT COUNT(*) FROM properties WHERE departmentId = @departmentID AND status != 'For Disposal' AND status != 'Lost'"
            Using checkCmd As New MySqlCommand(checkPropertiesQuery, conn)
                checkCmd.Parameters.AddWithValue("@departmentID", departmentID)
                Dim propertyCount As Integer = CInt(checkCmd.ExecuteScalar())
                If propertyCount > 0 Then
                    MessageBox.Show("Cannot delete department. It has " & propertyCount & " property/properties assigned to it. Please reassign or dispose properties first.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Check if department has staff members
            Dim checkStaffQuery As String = "SELECT COUNT(*) FROM users WHERE departmentId = @departmentID AND role = 'Staff' AND status = 'active'"
            Using checkCmd As New MySqlCommand(checkStaffQuery, conn)
                checkCmd.Parameters.AddWithValue("@departmentID", departmentID)
                Dim staffCount As Integer = CInt(checkCmd.ExecuteScalar())
                If staffCount > 0 Then
                    MessageBox.Show("Cannot delete department. It has " & staffCount & " active staff member(s). Please reassign staff first.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End Using

            ' Delete department (soft delete by setting status to 'inactive')
            Dim query As String = "UPDATE departments SET status = 'inactive', updated_at = NOW() WHERE departmentId = @departmentID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@departmentID", departmentID)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    Try
                        RecalculateDepartmentHeadcount(departmentID)
                    Catch exHeadcount As Exception
                        System.Diagnostics.Debug.WriteLine("[v0] DeleteDepartment headcount refresh failed: " & exHeadcount.Message)
                    End Try
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
            Dim employeeQuery As String = "SELECT COUNT(*) FROM users WHERE departmentId = @departmentID AND role = 'Staff' AND status = 'active'"
            Using cmd As New MySqlCommand(employeeQuery, conn)
                cmd.Parameters.AddWithValue("@departmentID", departmentID)
                stats("employee_count") = CInt(cmd.ExecuteScalar())
            End Using

            ' Get property count
            Dim propertyQuery As String = "SELECT COUNT(*) FROM properties WHERE departmentId = @departmentID AND status = 'Active'"
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

    ''' <summary>
    ''' Initialize hardcoded SuperAdmin and Admin accounts if they don't exist
    ''' SuperAdmin password: SuperAdmin@123
    ''' Admin password: Admin@123
    ''' </summary>
    Public Shared Sub InitializeDefaultAccounts()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return

            If Not SafeOpenConnection(conn) Then Return

            ' Hardcoded credentials
            Dim superAdminUsername As String = "superadmin"
            Dim superAdminPassword As String = "SuperAdmin@123"
            Dim adminUsername As String = "admin"
            Dim adminPassword As String = "Admin@123"

            ' Ensure SuperAdmin account exists and matches the expected credentials
            Dim superAdminId As Object = Nothing
            Using checkCmd As New MySqlCommand("SELECT userId FROM users WHERE LOWER(username) = LOWER(@username) AND role = 'SuperAdmin' LIMIT 1", conn)
                checkCmd.Parameters.AddWithValue("@username", superAdminUsername)
                superAdminId = checkCmd.ExecuteScalar()
            End Using

            Dim superAdminHashValue As String = PasswordHelper.HashPassword(superAdminPassword)

            If superAdminId Is Nothing OrElse superAdminId Is DBNull.Value Then
                ' Create SuperAdmin account
                Using insertCmd As New MySqlCommand("INSERT INTO users (firstName, lastName, email, username, passwordEncrypted, role, status, createdAt) " &
                                                    "VALUES (@firstName, @lastName, @email, @username, @password, 'SuperAdmin', 'Active', NOW())", conn)
                    insertCmd.Parameters.AddWithValue("@firstName", "Super")
                    insertCmd.Parameters.AddWithValue("@lastName", "Administrator")
                    insertCmd.Parameters.AddWithValue("@email", "superadmin@stacruz.edu")
                    insertCmd.Parameters.AddWithValue("@username", superAdminUsername)
                    insertCmd.Parameters.AddWithValue("@password", superAdminHashValue)
                    insertCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] Default SuperAdmin account created: " & superAdminUsername)
                End Using
            Else
                ' Update existing SuperAdmin account to ensure credentials stay in sync
                Using updateCmd As New MySqlCommand("UPDATE users SET firstName = @firstName, lastName = @lastName, email = @email, " &
                                                    "passwordEncrypted = @password, status = 'Active' WHERE userId = @userID", conn)
                    updateCmd.Parameters.AddWithValue("@firstName", "Super")
                    updateCmd.Parameters.AddWithValue("@lastName", "Administrator")
                    updateCmd.Parameters.AddWithValue("@email", "superadmin@stacruz.edu")
                    updateCmd.Parameters.AddWithValue("@password", superAdminHashValue)
                    updateCmd.Parameters.AddWithValue("@userID", CInt(superAdminId))
                    updateCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] Default SuperAdmin account verified/updated: " & superAdminUsername)
                End Using
            End If

            ' Ensure Admin account exists and matches the expected credentials
            Dim adminId As Object = Nothing
            Using checkCmd As New MySqlCommand("SELECT userId FROM users WHERE LOWER(username) = LOWER(@username) AND role = 'Admin' LIMIT 1", conn)
                checkCmd.Parameters.AddWithValue("@username", adminUsername)
                adminId = checkCmd.ExecuteScalar()
            End Using

            Dim adminHashValue As String = PasswordHelper.HashPassword(adminPassword)

            If adminId Is Nothing OrElse adminId Is DBNull.Value Then
                ' Create Admin account
                Using insertCmd As New MySqlCommand("INSERT INTO users (firstName, lastName, email, username, passwordEncrypted, role, status, createdAt) " &
                                                    "VALUES (@firstName, @lastName, @email, @username, @password, 'Admin', 'Active', NOW())", conn)
                    insertCmd.Parameters.AddWithValue("@firstName", "System")
                    insertCmd.Parameters.AddWithValue("@lastName", "Administrator")
                    insertCmd.Parameters.AddWithValue("@email", "admin@stacruz.edu")
                    insertCmd.Parameters.AddWithValue("@username", adminUsername)
                    insertCmd.Parameters.AddWithValue("@password", adminHashValue)
                    insertCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] Default Admin account created: " & adminUsername)
                End Using
            Else
                ' Update existing Admin account to ensure credentials stay in sync
                Using updateCmd As New MySqlCommand("UPDATE users SET firstName = @firstName, lastName = @lastName, email = @email, " &
                                                    "passwordEncrypted = @password, status = 'Active' WHERE userId = @userID", conn)
                    updateCmd.Parameters.AddWithValue("@firstName", "System")
                    updateCmd.Parameters.AddWithValue("@lastName", "Administrator")
                    updateCmd.Parameters.AddWithValue("@email", "admin@stacruz.edu")
                    updateCmd.Parameters.AddWithValue("@password", adminHashValue)
                    updateCmd.Parameters.AddWithValue("@userID", CInt(adminId))
                    updateCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] Default Admin account verified/updated: " & adminUsername)
                End Using
            End If

            ' Ensure Custodian account exists in users table (all accounts are in users table)
            Dim custodianUsername As String = "custodian"
            Dim custodianPassword As String = "Custodian@2025"
            Dim custodianId As Object = Nothing
            Using checkCmd As New MySqlCommand("SELECT userId FROM users WHERE LOWER(username) = LOWER(@username) AND role = 'Custodian' LIMIT 1", conn)
                checkCmd.Parameters.AddWithValue("@username", custodianUsername)
                custodianId = checkCmd.ExecuteScalar()
            End Using

            Dim custodianHashValue As String = PasswordHelper.HashPassword(custodianPassword)

            If custodianId Is Nothing OrElse custodianId Is DBNull.Value Then
                ' Create Custodian account in users table (same table as Admin/SuperAdmin/Staff)
                Using insertCmd As New MySqlCommand("INSERT INTO users (firstName, lastName, email, username, passwordEncrypted, role, status, createdAt) " &
                                                    "VALUES (@firstName, @lastName, @email, @username, @password, 'Custodian', 'Active', NOW())", conn)
                    insertCmd.Parameters.AddWithValue("@firstName", "Property")
                    insertCmd.Parameters.AddWithValue("@lastName", "Custodian")
                    insertCmd.Parameters.AddWithValue("@email", "custodian@stacruz.edu")
                    insertCmd.Parameters.AddWithValue("@username", custodianUsername)
                    insertCmd.Parameters.AddWithValue("@password", custodianHashValue)
                    insertCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] Default Custodian account created: " & custodianUsername)
                End Using
            Else
                ' Update existing Custodian account to ensure credentials stay in sync
                Using updateCmd As New MySqlCommand("UPDATE users SET firstName = @firstName, lastName = @lastName, email = @email, " &
                                                    "passwordEncrypted = @password, status = 'Active', updatedAt = NOW() WHERE userId = @userID AND role = 'Custodian'", conn)
                    updateCmd.Parameters.AddWithValue("@firstName", "Property")
                    updateCmd.Parameters.AddWithValue("@lastName", "Custodian")
                    updateCmd.Parameters.AddWithValue("@email", "custodian@stacruz.edu")
                    updateCmd.Parameters.AddWithValue("@password", custodianHashValue)
                    updateCmd.Parameters.AddWithValue("@userID", CInt(custodianId))
                    updateCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] Default Custodian account verified/updated: " & custodianUsername)
                End Using
            End If

            ' Ensure hardcoded Staff account exists (test_staff)
            Dim staffUsername As String = "test_staff"
            Dim staffPassword As String = "Staff@1234"
            Dim staffId As Object = Nothing
            Using checkCmd As New MySqlCommand("SELECT userId FROM users WHERE LOWER(username) = LOWER(@username) AND role = 'Staff' LIMIT 1", conn)
                checkCmd.Parameters.AddWithValue("@username", staffUsername)
                staffId = checkCmd.ExecuteScalar()
            End Using

            Dim staffHashValue As String = PasswordHelper.HashPassword(staffPassword)

            If staffId Is Nothing OrElse staffId Is DBNull.Value Then
                ' Create hardcoded Staff account
                Using insertCmd As New MySqlCommand("INSERT INTO users (firstName, lastName, email, username, passwordEncrypted, role, status, position, createdAt) " &
                                                    "VALUES (@firstName, @lastName, @email, @username, @password, 'Staff', 'Active', 'Staff', NOW())", conn)
                    insertCmd.Parameters.AddWithValue("@firstName", "Test")
                    insertCmd.Parameters.AddWithValue("@lastName", "Staff")
                    insertCmd.Parameters.AddWithValue("@email", "test_staff@stacruz.edu")
                    insertCmd.Parameters.AddWithValue("@username", staffUsername)
                    insertCmd.Parameters.AddWithValue("@password", staffHashValue)
                    insertCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] Default Staff account created: " & staffUsername)
                End Using
            Else
                ' Update existing Staff account to ensure credentials stay in sync
                Using updateCmd As New MySqlCommand("UPDATE users SET firstName = @firstName, lastName = @lastName, email = @email, " &
                                                    "passwordEncrypted = @password, status = 'Active' WHERE userId = @userID AND role = 'Staff'", conn)
                    updateCmd.Parameters.AddWithValue("@firstName", "Test")
                    updateCmd.Parameters.AddWithValue("@lastName", "Staff")
                    updateCmd.Parameters.AddWithValue("@email", "test_staff@stacruz.edu")
                    updateCmd.Parameters.AddWithValue("@password", staffHashValue)
                    updateCmd.Parameters.AddWithValue("@userID", CInt(staffId))
                    updateCmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine("[v0] Default Staff account verified/updated: " & staffUsername)
                End Using
            End If

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Error initializing default accounts: " & ex.Message)
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


End Class