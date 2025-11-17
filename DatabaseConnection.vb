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
                query.Append("SUM(p.acquisition_cost) AS total_value ")
            Else
                query.Append("SELECT p.property_id, p.property_name, p.category, p.status, p.location, ")
                query.Append("p.acquisition_date, p.acquisition_cost, d.department_name, ")
                query.Append("CONCAT(IFNULL(u.first_name,''), ' ', IFNULL(u.last_name,'')) AS custodian_name ")
            End If
            query.Append("FROM properties p ")
            query.Append("LEFT JOIN departments d ON p.department_id = d.department_id ")
            query.Append("LEFT JOIN users u ON p.custodian_id = u.user_id WHERE 1=1 ")

            If departmentID.HasValue Then query.Append(" AND p.department_id = @departmentID ")
            If Not String.IsNullOrEmpty(category) Then query.Append(" AND p.category = @category ")
            If Not String.IsNullOrEmpty(status) Then query.Append(" AND p.status = @status ")
            If dateFrom.HasValue Then query.Append(" AND p.acquisition_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND p.acquisition_date <= @dateTo ")

            If groupByCategory Then
                query.Append(" GROUP BY p.category, p.status ORDER BY p.category")
            Else
                query.Append(" ORDER BY p.category, p.property_name")
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
            query.Append("SELECT s.supply_id, s.supply_name, s.category, s.quantity_in_stock, s.reorder_level, ")
            query.Append("s.unit_cost, s.total_value, s.status, s.location, d.department_name ")
            query.Append("FROM supplies s ")
            query.Append("LEFT JOIN departments d ON s.department_id = d.department_id WHERE 1=1 ")

            If Not String.IsNullOrEmpty(category) Then query.Append(" AND s.category = @category ")
            If Not String.IsNullOrEmpty(status) Then query.Append(" AND s.status = @status ")
            If includeLowStockOnly Then query.Append(" AND s.quantity_in_stock <= s.reorder_level ")
            If departmentID.HasValue Then query.Append(" AND s.department_id = @departmentID ")

            query.Append(" ORDER BY s.category, s.supply_name")

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
            query.Append("SELECT m.maintenance_id, p.property_name, m.service_date, m.service_type, m.description, ")
            query.Append("m.service_provider, m.cost, m.status, m.next_schedule, m.technician_assigned ")
            query.Append("FROM maintenance m INNER JOIN properties p ON m.property_id = p.property_id WHERE 1=1 ")

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
            query.Append("pr.actual_returned_date, pr.quantity, sa.first_name, sa.last_name, ")
            query.Append("COALESCE(p.property_name, sup.supply_name) AS item_name ")
            query.Append("FROM property_requests pr ")
            query.Append("LEFT JOIN staff_accounts sa ON pr.user_id = sa.staff_id ")
            query.Append("LEFT JOIN properties p ON pr.property_id = p.property_id ")
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
            query.Append("SELECT u.user_id, CONCAT(IFNULL(u.first_name,''), ' ', IFNULL(u.last_name,'')) AS custodian_name, ")
            query.Append("d.department_name, p.property_name AS asset_name, p.category AS asset_category, 'Property' AS asset_type ")
            query.Append("FROM users u ")
            query.Append("INNER JOIN properties p ON u.user_id = p.custodian_id ")
            query.Append("LEFT JOIN departments d ON u.department_id = d.department_id WHERE 1=1 ")

            If custodianID.HasValue Then query.Append(" AND u.user_id = @custodianID ")
            If departmentID.HasValue Then query.Append(" AND u.department_id = @departmentID ")

            query.Append(" UNION ALL ")

            query.Append("SELECT u.user_id, CONCAT(IFNULL(u.first_name,''), ' ', IFNULL(u.last_name,'')) AS custodian_name, ")
            query.Append("d.department_name, s.supply_name AS asset_name, s.category AS asset_category, 'Supply' AS asset_type ")
            query.Append("FROM users u ")
            query.Append("INNER JOIN supplies s ON u.user_id = s.custodian_id ")
            query.Append("LEFT JOIN departments d ON u.department_id = d.department_id WHERE 1=1 ")

            If custodianID.HasValue Then query.Append(" AND u.user_id = @custodianID ")
            If departmentID.HasValue Then query.Append(" AND u.department_id = @departmentID ")

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
            query.Append("CONCAT(IFNULL(sa.first_name,''), ' ', IFNULL(sa.last_name,'')) AS requester_name, ")
            query.Append("d.department_name, COALESCE(p.property_name, sup.supply_name) AS item_name ")
            query.Append("FROM property_requests pr ")
            query.Append("INNER JOIN staff_accounts sa ON pr.user_id = sa.staff_id ")
            query.Append("LEFT JOIN departments d ON sa.department_id = d.department_id ")
            query.Append("LEFT JOIN properties p ON pr.property_id = p.property_id ")
            query.Append("LEFT JOIN supplies sup ON pr.supply_id = sup.supply_id WHERE 1=1 ")

            If dateFrom.HasValue Then query.Append(" AND pr.request_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND pr.request_date <= @dateTo ")
            If departmentID.HasValue Then query.Append(" AND sa.department_id = @departmentID ")

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
            query.Append("CONCAT(IFNULL(sa.first_name,''), ' ', IFNULL(sa.last_name,'')) AS actor_name, ")
            query.Append("pr.status, pr.remarks ")
            query.Append("FROM property_requests pr ")
            query.Append("INNER JOIN staff_accounts sa ON pr.user_id = sa.staff_id ")
            query.Append("WHERE pr.property_id = @propertyID ")
            If dateFrom.HasValue Then query.Append(" AND pr.request_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND pr.request_date <= @dateTo ")
            query.Append(" UNION ALL ")
            query.Append("SELECT 'MAINTENANCE' AS entry_type, m.maintenance_id AS reference_id, m.service_date AS activity_date, ")
            query.Append("COALESCE(m.service_provider, m.technician_assigned) AS actor_name, m.status, m.description AS remarks ")
            query.Append("FROM maintenance m WHERE m.property_id = @propertyID ")
            If dateFrom.HasValue Then query.Append(" AND m.service_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND m.service_date <= @dateTo ")
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
            query.Append("COALESCE(p.property_name, sup.supply_name) AS item_name, pr.quantity, pr.remarks, ")
            query.Append("CASE ")
            query.Append(" WHEN pr.status = 'approved' THEN 'Your request has been approved.' ")
            query.Append(" WHEN pr.status = 'rejected' THEN 'Your request has been denied.' ")
            query.Append(" WHEN pr.status = 'released' THEN 'Your requested item is ready for release.' ")
            query.Append(" WHEN pr.status = 'returned' THEN 'Your borrowed item has been recorded as returned.' ")
            query.Append(" ELSE CONCAT('Request status updated to ', pr.status) ")
            query.Append("END AS notification_message ")
            query.Append("FROM property_requests pr ")
            query.Append("LEFT JOIN properties p ON pr.property_id = p.property_id ")
            query.Append("LEFT JOIN supplies sup ON pr.supply_id = sup.supply_id ")
            query.Append("WHERE pr.user_id = @staffID ")

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
                MessageBox.Show("Database connection failed. Please ensure:" & vbCrLf & vbCrLf &
                              "1. MySQL/XAMPP is running" & vbCrLf &
                              "2. The database 'teamcruzim' exists" & vbCrLf &
                              "3. Username 'root' has proper permissions" & vbCrLf &
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
            Dim errorMsg As String = "MySQL Error: " & ex.Message & vbCrLf & vbCrLf
            If ex.Number = 1045 Then
                errorMsg &= "Invalid username or password. Please check your database credentials."
            ElseIf ex.Number = 1049 Then
                errorMsg &= "Database 'teamcruzim' does not exist. Please create it first."
            ElseIf ex.Number = 2003 OrElse ex.Number = 0 Then
                errorMsg &= "Cannot connect to MySQL server. Please ensure:" & vbCrLf &
                           "1. XAMPP/MySQL is running" & vbCrLf &
                           "2. MySQL service is started"
            Else
                errorMsg &= "Please check your MySQL configuration and ensure the server is running."
            End If
            MessageBox.Show(errorMsg, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Database connection test failed: " & ex.Message)
            Dim errorMsg As String = "Database connection failed: " & ex.Message & vbCrLf & vbCrLf &
                                    "Please ensure:" & vbCrLf &
                                    "1. MySQL/XAMPP is running" & vbCrLf &
                                    "2. The database server is accessible" & vbCrLf &
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
                System.Diagnostics.Debug.WriteLine("[v0] Staff Login - Empty credentials")
                Return result
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return result
            If Not SafeOpenConnection(conn) Then Return result

            Dim query As String =
                "SELECT staff_id, first_name, last_name, email, contact_number, department_id, username, password, status " &
                "FROM staff_accounts WHERE LOWER(username) = LOWER(@username)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username.Trim())

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If Not reader.Read() Then
                        System.Diagnostics.Debug.WriteLine("[v0] Staff Login Failed - User not found: " & username)
                        LogActivity(Nothing, "Staff", username, "LOGIN_FAILED", "Authentication", "Username not found", ipAddress)
                        Return result
                    End If

                    Dim status As String = reader("status").ToString()
                    Dim storedHash As String = reader("password").ToString()

                    If Not String.Equals(status, "Active", StringComparison.OrdinalIgnoreCase) Then
                        System.Diagnostics.Debug.WriteLine("[v0] Staff Login Failed - Inactive account: " & username)
                        LogActivity(Nothing, "Staff", username, "LOGIN_FAILED", "Authentication", "Inactive staff account", ipAddress)
                        Return result
                    End If

                    If Not PasswordHelper.VerifyPassword(password, storedHash) Then
                        System.Diagnostics.Debug.WriteLine("[v0] Staff Login Failed - Invalid password: " & username)
                        LogActivity(Nothing, "Staff", username, "LOGIN_FAILED", "Authentication", "Invalid password attempt", ipAddress)
                        Return result
                    End If

                    ' Successful authentication: populate profile dictionary
                    result("staff_id") = reader("staff_id").ToString()
                    result("first_name") = reader("first_name").ToString()
                    result("last_name") = reader("last_name").ToString()
                    result("email") = reader("email").ToString()
                    result("contact_number") = reader("contact_number").ToString()
                    result("department_id") = reader("department_id").ToString()
                    result("username") = reader("username").ToString()
                    result("user_type") = "Staff"
                End Using
            End Using

            ' Update last_login and log successful login
            If result.Count > 0 Then
                Using updateCmd As New MySqlCommand("UPDATE staff_accounts SET last_login = NOW() WHERE staff_id = @staffID", conn)
                    updateCmd.Parameters.AddWithValue("@staffID", CInt(result("staff_id")))
                    updateCmd.ExecuteNonQuery()
                End Using

                LogActivity(CInt(result("staff_id")), "Staff", result("username"), "LOGIN", "Authentication",
                            "Staff successfully logged in", ipAddress)
                System.Diagnostics.Debug.WriteLine("[v0] Staff Login Success: " & username)
            End If
        Catch ex As MySqlException When ex.Message.Contains("ReplicationManager")
            System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff - ReplicationManager error: " & ex.Message)
            MessageBox.Show("Database connection issue. Please try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AuthenticateStaff Exception: " & ex.Message)
            MessageBox.Show("Error validating staff login: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        Return result
    End Function


    ''' <summary>
    ''' Validate admin/super admin login credentials with password hashing
    ''' </summary>
    Public Shared Function ValidateAdminLogin(username As String, password As String, Optional ipAddress As String = "") As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)
        Dim conn As MySqlConnection = Nothing
        Try
            If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
                System.Diagnostics.Debug.WriteLine("[v0] Admin Login - Empty credentials")
                Return result
            End If

            conn = GetConnection()
            If conn Is Nothing Then Return result

            If Not SafeOpenConnection(conn) Then Return result

            ' Query admin/superadmin from users table
            Dim query As String = "SELECT user_id, first_name, last_name, email, username, user_type, password " &
                                 "FROM users WHERE LOWER(username) = LOWER(@username) AND (user_type = 'Admin' OR user_type = 'SuperAdmin') AND status = 'Active'"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", username.Trim())

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
                Using updateCmd As New MySqlCommand("UPDATE users SET last_login = NOW() WHERE user_id = @userID", conn)
                    updateCmd.Parameters.AddWithValue("@userID", result("user_id"))
                    updateCmd.ExecuteNonQuery()
                End Using

                LogActivity(CInt(result("user_id")), result("user_type"), result("username"), "LOGIN", "Authentication", "Administrator successfully logged in", ipAddress)
            End If
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
    ''' Get full staff profile by staff_id (read-only view for Staff role).
    ''' </summary>
    Public Shared Function GetStaffProfile(staffID As Integer) As Dictionary(Of String, Object)
        Dim profile As New Dictionary(Of String, Object)()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return profile
            If Not SafeOpenConnection(conn) Then Return profile

            Dim query As String =
                "SELECT staff_id, first_name, middle_name, last_name, suffix, position, department_id, " &
                "contact_number, email, username, date_assigned, employee_id, status, last_login, created_at " &
                "FROM staff_accounts WHERE staff_id = @staffID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@staffID", staffID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        profile("staff_id") = reader("staff_id")
                        profile("first_name") = reader("first_name").ToString()
                        profile("middle_name") = If(IsDBNull(reader("middle_name")), "", reader("middle_name").ToString())
                        profile("last_name") = reader("last_name").ToString()
                        profile("suffix") = If(IsDBNull(reader("suffix")), "", reader("suffix").ToString())
                        profile("position") = If(IsDBNull(reader("position")), "", reader("position").ToString())
                        profile("department_id") = If(IsDBNull(reader("department_id")), Nothing, reader("department_id"))
                        profile("contact_number") = If(IsDBNull(reader("contact_number")), "", reader("contact_number").ToString())
                        profile("email") = reader("email").ToString()
                        profile("username") = reader("username").ToString()
                        profile("date_assigned") = If(IsDBNull(reader("date_assigned")), Nothing, reader("date_assigned"))
                        profile("employee_id") = If(IsDBNull(reader("employee_id")), "", reader("employee_id").ToString())
                        profile("status") = reader("status").ToString()
                        profile("last_login") = If(IsDBNull(reader("last_login")), Nothing, reader("last_login"))
                        profile("created_at") = reader("created_at")
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
    ''' STAFF-FACING helper: submit a property borrowing request (fixed assets).
    ''' </summary>
    Public Shared Function StaffSubmitPropertyRequest(staffID As Integer,
                                                      propertyID As Integer,
                                                      quantity As Integer,
                                                      purpose As String,
                                                      Optional expectedReturnDate As Date? = Nothing,
                                                      Optional ipAddress As String = "") As Boolean
        Dim ok As Boolean = SubmitPropertyRequest(staffID, propertyID, Nothing, "property", purpose, quantity, expectedReturnDate)
        If ok Then
            LogCrudAction(staffID, "Staff", "", "Property Requests", "Property Request", "Create",
                          $"Staff #{staffID} requested property #{propertyID} x{quantity}", ipAddress)
        End If
        Return ok
    End Function

    ''' <summary>
    ''' STAFF-FACING helper: submit a consumable supply request.
    ''' </summary>
    Public Shared Function StaffSubmitSupplyRequest(staffID As Integer,
                                                    supplyID As Integer,
                                                    quantity As Integer,
                                                    purpose As String,
                                                    Optional expectedReturnDate As Date? = Nothing,
                                                    Optional ipAddress As String = "") As Boolean
        Dim ok As Boolean = SubmitPropertyRequest(staffID, Nothing, supplyID, "supply", purpose, quantity, expectedReturnDate)
        If ok Then
            LogCrudAction(staffID, "Staff", "", "Supply Requests", "Supply Request", "Create",
                          $"Staff #{staffID} requested supply #{supplyID} x{quantity}", ipAddress)
        End If
        Return ok
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

            Dim query As New StringBuilder()
            query.Append("SELECT pr.request_id, pr.request_type, pr.status, pr.request_date, pr.approval_date, ")
            query.Append("pr.release_date, pr.expected_return_date, pr.actual_returned_date, pr.quantity, ")
            query.Append("pr.penalty, pr.condition_upon_return, pr.remarks, ")
            query.Append("COALESCE(p.property_name, sup.supply_name) AS item_name, ")
            query.Append("p.serial_number, p.location AS property_location, sup.location AS supply_location ")
            query.Append("FROM property_requests pr ")
            query.Append("LEFT JOIN properties p ON pr.property_id = p.property_id ")
            query.Append("LEFT JOIN supplies sup ON pr.supply_id = sup.supply_id ")
            query.Append("WHERE pr.user_id = @staffID ")

            If Not String.IsNullOrEmpty(statusFilter) Then query.Append("AND pr.status = @status ")
            If Not String.IsNullOrEmpty(requestTypeFilter) Then query.Append("AND pr.request_type = @requestType ")
            If dateFrom.HasValue Then query.Append("AND pr.request_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append("AND pr.request_date <= @dateTo ")

            query.Append("ORDER BY pr.request_date DESC, pr.request_id DESC")

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
            query.Append("SELECT pr.request_id, pr.request_type, pr.status, pr.request_date, pr.approval_date, ")
            query.Append("pr.release_date, pr.expected_return_date, pr.actual_returned_date, pr.quantity, pr.penalty, ")
            query.Append("pr.condition_upon_return, pr.remarks, ")
            query.Append("CONCAT(sa.first_name, ' ', sa.last_name) AS requester_name, sa.department_id, ")
            query.Append("COALESCE(p.property_name, sup.supply_name) AS item_name, ")
            query.Append("p.serial_number, p.location AS property_location, sup.location AS supply_location ")
            query.Append("FROM property_requests pr ")
            query.Append("LEFT JOIN staff_accounts sa ON pr.user_id = sa.staff_id ")
            query.Append("LEFT JOIN properties p ON pr.property_id = p.property_id ")
            query.Append("LEFT JOIN supplies sup ON pr.supply_id = sup.supply_id WHERE 1=1 ")

            If Not String.IsNullOrEmpty(statusFilter) Then
                query.Append(" AND pr.status = @status ")
            End If
            If Not String.IsNullOrEmpty(requestTypeFilter) Then
                query.Append(" AND pr.request_type = @requestType ")
            End If
            If dateFrom.HasValue Then
                query.Append(" AND pr.request_date >= @dateFrom ")
            End If
            If dateTo.HasValue Then
                query.Append(" AND pr.request_date <= @dateTo ")
            End If

            query.Append(" ORDER BY pr.request_date DESC, pr.request_id DESC")

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
        Dim conn As MySqlConnection = Nothing
        Dim transaction As MySqlTransaction = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            transaction = conn.BeginTransaction()

            Dim requestInfo As New Dictionary(Of String, Object)
            Using cmd As New MySqlCommand("SELECT request_type, property_id, supply_id, quantity, user_id, status " &
                                          "FROM property_requests WHERE request_id = @requestID FOR UPDATE", conn, transaction)
                cmd.Parameters.AddWithValue("@requestID", requestID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        requestInfo("request_type") = reader("request_type").ToString()
                        requestInfo("property_id") = If(IsDBNull(reader("property_id")), Nothing, reader("property_id"))
                        requestInfo("supply_id") = If(IsDBNull(reader("supply_id")), Nothing, reader("supply_id"))
                        requestInfo("quantity") = CInt(reader("quantity"))
                        requestInfo("user_id") = CInt(reader("user_id"))
                        requestInfo("status") = reader("status").ToString()
                    Else
                        Throw New Exception("Request not found.")
                    End If
                End Using
            End Using

            If requestInfo("status").ToString().ToLower() <> "pending" Then
                Throw New Exception("Only pending requests can be approved.")
            End If

            Dim requestType As String = requestInfo("request_type").ToString().ToLower()
            Dim quantity As Integer = CInt(requestInfo("quantity"))
            Dim borrowerID As Integer = CInt(requestInfo("user_id"))

            If requestType = "supply" Then
                Using updateSupply As New MySqlCommand("UPDATE supplies SET quantity_in_stock = quantity_in_stock - @qty, updated_at = NOW() " &
                                                      "WHERE supply_id = @supplyID AND quantity_in_stock >= @qty", conn, transaction)
                    updateSupply.Parameters.AddWithValue("@qty", quantity)
                    updateSupply.Parameters.AddWithValue("@supplyID", requestInfo("supply_id"))
                    Dim rows = updateSupply.ExecuteNonQuery()
                    If rows = 0 Then
                        Throw New Exception("Insufficient stock to approve the request.")
                    End If
                End Using
            ElseIf requestType = "property" Then
                Using assignProperty As New MySqlCommand("UPDATE properties SET custodian_id = @custodianID, updated_at = NOW() " &
                                                        "WHERE property_id = @propertyID", conn, transaction)
                    assignProperty.Parameters.AddWithValue("@custodianID", borrowerID)
                    assignProperty.Parameters.AddWithValue("@propertyID", requestInfo("property_id"))
                    If assignProperty.ExecuteNonQuery() = 0 Then
                        Throw New Exception("Failed to update property assignment.")
                    End If
                End Using
            End If

            Using updateRequest As New MySqlCommand("UPDATE property_requests SET status = 'approved', approved_by = @adminID, " &
                                                    "approval_date = NOW(), release_date = @releaseDate, expected_return_date = @expectedReturnDate, " &
                                                    "remarks = @remarks WHERE request_id = @requestID", conn, transaction)
                updateRequest.Parameters.AddWithValue("@adminID", adminID)
                updateRequest.Parameters.AddWithValue("@releaseDate", If(releaseDate.HasValue, releaseDate.Value, DBNull.Value))
                updateRequest.Parameters.AddWithValue("@expectedReturnDate", If(expectedReturnDate.HasValue, expectedReturnDate.Value, DBNull.Value))
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
            MessageBox.Show("Error approving request: " & ex.Message, "Approval Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    ''' Reject a pending request
    ''' </summary>
    Public Shared Function RejectPropertyRequest(requestID As Integer, adminID As Integer, adminName As String,
                                                 adminUserType As String, Optional remarks As String = "") As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE property_requests SET status = 'rejected', approved_by = @adminID, approval_date = NOW(), remarks = @remarks " &
                                  "WHERE request_id = @requestID AND status = 'pending'"
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
    ''' Mark an approved request as released and record release information
    ''' </summary>
    Public Shared Function ReleasePropertyRequest(requestID As Integer, adminID As Integer, adminName As String,
                                                  adminUserType As String, releaseDate As Date, Optional expectedReturnDate As Date? = Nothing,
                                                  Optional remarks As String = "") As Boolean
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "UPDATE property_requests SET status = 'released', release_date = @releaseDate, expected_return_date = @expectedReturnDate, " &
                                  "remarks = @remarks WHERE request_id = @requestID AND status IN ('approved', 'released')"
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
                        requestInfo("property_id") = If(IsDBNull(reader("property_id")), Nothing, reader("property_id"))
                        requestInfo("supply_id") = If(IsDBNull(reader("supply_id")), Nothing, reader("supply_id"))
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
                Using cmd As New MySqlCommand("UPDATE supplies SET quantity_in_stock = quantity_in_stock + @qty, updated_at = NOW() WHERE supply_id = @supplyID", conn, transaction)
                    cmd.Parameters.AddWithValue("@qty", quantity)
                    cmd.Parameters.AddWithValue("@supplyID", requestInfo("supply_id"))
                    cmd.ExecuteNonQuery()
                End Using
            ElseIf requestType = "property" Then
                Using cmd As New MySqlCommand("UPDATE properties SET custodian_id = NULL, condition_status = @condition, status = 'active', updated_at = NOW() WHERE property_id = @propertyID", conn, transaction)
                    cmd.Parameters.AddWithValue("@condition", conditionUponReturn)
                    cmd.Parameters.AddWithValue("@propertyID", requestInfo("property_id"))
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
            MessageBox.Show("Error recording return: " & ex.Message, "Return Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            Dim query As New StringBuilder()
            query.Append("SELECT pr.request_id, pr.request_type, pr.status, pr.request_date, ")
            query.Append("pr.release_date, pr.expected_return_date, pr.actual_returned_date, pr.quantity, ")
            query.Append("COALESCE(p.property_name, sup.supply_name) AS item_name, ")
            query.Append("p.serial_number, ")
            query.Append("CASE ")
            query.Append(" WHEN pr.status IN ('approved','released') AND pr.actual_returned_date IS NULL ")
            query.Append("      AND pr.expected_return_date IS NOT NULL AND pr.expected_return_date < CURDATE() THEN 'Overdue' ")
            query.Append(" WHEN pr.status IN ('approved','released') AND pr.actual_returned_date IS NULL THEN 'Not yet returned' ")
            query.Append(" WHEN pr.status = 'returned' THEN 'Returned' ")
            query.Append(" ELSE pr.status ")
            query.Append("END AS accountability_status ")
            query.Append("FROM property_requests pr ")
            query.Append("LEFT JOIN properties p ON pr.property_id = p.property_id ")
            query.Append("LEFT JOIN supplies sup ON pr.supply_id = sup.supply_id ")
            query.Append("WHERE pr.user_id = @staffID ")

            If Not includeHistory Then
                query.Append("AND pr.status IN ('approved','released') ")
            End If

            query.Append("ORDER BY pr.request_date DESC, pr.request_id DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
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
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False

            If Not SafeOpenConnection(conn) Then Return False

            Dim calculatedNextSchedule As Date? = nextSchedule
            If Not nextSchedule.HasValue AndAlso maintenanceIntervalDays > 0 Then
                calculatedNextSchedule = serviceDate.AddDays(maintenanceIntervalDays)
            End If

            Dim query As String = "INSERT INTO maintenance (property_id, custodian_id, service_date, service_type, " &
                                 "description, service_provider, provider_contact, cost, next_schedule, " &
                                 "technician_assigned, status, remarks) " &
                                 "VALUES (@propertyID, @custodianID, @serviceDate, @serviceType, @description, " &
                                 "@serviceProvider, @providerContact, @cost, @nextSchedule, @technicianAssigned, @status, @remarks)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@propertyID", propertyID)
                cmd.Parameters.AddWithValue("@custodianID", If(custodianID.HasValue, custodianID.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@serviceDate", serviceDate)
                cmd.Parameters.AddWithValue("@serviceType", serviceType)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@serviceProvider", If(String.IsNullOrEmpty(serviceProvider), DBNull.Value, serviceProvider))
                cmd.Parameters.AddWithValue("@providerContact", If(String.IsNullOrEmpty(providerContact), DBNull.Value, providerContact))
                cmd.Parameters.AddWithValue("@cost", cost)
                cmd.Parameters.AddWithValue("@nextSchedule", If(calculatedNextSchedule.HasValue, calculatedNextSchedule.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@technicianAssigned", If(String.IsNullOrEmpty(technicianAssigned), DBNull.Value, technicianAssigned))
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))

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
    ''' Get all maintenance records
    ''' </summary>
    Public Shared Function GetAllMaintenance() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt

            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As String = "SELECT m.maintenance_id, p.property_name, " &
                                 "CONCAT(IFNULL(u.first_name,''), ' ', IFNULL(u.last_name,'')) AS custodian_name, " &
                                 "m.service_date, m.service_type, m.description, m.service_provider, m.cost, m.status, " &
                                 "m.next_schedule, m.technician_assigned, m.remarks " &
                                 "FROM maintenance m " &
                                 "INNER JOIN properties p ON m.property_id = p.property_id " &
                                 "LEFT JOIN users u ON m.custodian_id = u.user_id " &
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
            query.Append("SELECT m.maintenance_id, m.property_id, p.property_name, m.custodian_id, ")
            query.Append("CONCAT(IFNULL(u.first_name,''), ' ', IFNULL(u.last_name,'')) AS custodian_name, ")
            query.Append("m.service_date, m.service_type, m.description, m.service_provider, m.provider_contact, ")
            query.Append("m.cost, m.status, m.next_schedule, m.technician_assigned, m.remarks ")
            query.Append("FROM maintenance m ")
            query.Append("INNER JOIN properties p ON m.property_id = p.property_id ")
            query.Append("LEFT JOIN users u ON m.custodian_id = u.user_id WHERE 1=1 ")

            If Not String.IsNullOrEmpty(statusFilter) Then query.Append(" AND m.status = @status ")
            If dateFrom.HasValue Then query.Append(" AND m.service_date >= @dateFrom ")
            If dateTo.HasValue Then query.Append(" AND m.service_date <= @dateTo ")
            If propertyID.HasValue Then query.Append(" AND m.property_id = @propertyID ")
            If custodianID.HasValue Then query.Append(" AND m.custodian_id = @custodianID ")

            query.Append(" ORDER BY m.service_date DESC, m.maintenance_id DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(statusFilter) Then cmd.Parameters.AddWithValue("@status", statusFilter)
                If dateFrom.HasValue Then cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value)
                If dateTo.HasValue Then cmd.Parameters.AddWithValue("@dateTo", dateTo.Value)
                If propertyID.HasValue Then cmd.Parameters.AddWithValue("@propertyID", propertyID.Value)
                If custodianID.HasValue Then cmd.Parameters.AddWithValue("@custodianID", custodianID.Value)

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
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim calculatedNextSchedule As Date? = nextSchedule
            If Not nextSchedule.HasValue AndAlso maintenanceIntervalDays > 0 Then
                calculatedNextSchedule = serviceDate.AddDays(maintenanceIntervalDays)
            End If

            Dim query As String = "UPDATE maintenance SET service_date = @serviceDate, service_type = @serviceType, " &
                                  "description = @description, service_provider = @serviceProvider, provider_contact = @providerContact, " &
                                  "cost = @cost, next_schedule = @nextSchedule, technician_assigned = @technicianAssigned, " &
                                  "status = @status, remarks = @remarks WHERE maintenance_id = @maintenanceID"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@serviceDate", serviceDate)
                cmd.Parameters.AddWithValue("@serviceType", serviceType)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@serviceProvider", If(String.IsNullOrEmpty(serviceProvider), DBNull.Value, serviceProvider))
                cmd.Parameters.AddWithValue("@providerContact", If(String.IsNullOrEmpty(providerContact), DBNull.Value, providerContact))
                cmd.Parameters.AddWithValue("@cost", cost)
                cmd.Parameters.AddWithValue("@nextSchedule", If(calculatedNextSchedule.HasValue, calculatedNextSchedule.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@technicianAssigned", If(String.IsNullOrEmpty(technicianAssigned), DBNull.Value, technicianAssigned))
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))
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

    ''' <summary>
    ''' Retrieve audit logs filtered by user, module, or user type
    ''' </summary>
    Public Shared Function GetAuditLogsFiltered(Optional startDate As Date? = Nothing,
                                                Optional endDate As Date? = Nothing,
                                                Optional username As String = "",
                                                Optional moduleName As String = "",
                                                Optional userType As String = "") As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return dt
            If Not SafeOpenConnection(conn) Then Return dt

            Dim query As New StringBuilder()
            query.Append("SELECT log_id, user_id, username, user_type, action, module, description, created_at ")
            query.Append("FROM audit_logs WHERE 1=1 ")

            If startDate.HasValue Then query.Append(" AND DATE(created_at) >= @startDate ")
            If endDate.HasValue Then query.Append(" AND DATE(created_at) <= @endDate ")
            If Not String.IsNullOrEmpty(username) Then query.Append(" AND username = @username ")
            If Not String.IsNullOrEmpty(moduleName) Then query.Append(" AND module = @module ")
            If Not String.IsNullOrEmpty(userType) Then query.Append(" AND user_type = @userType ")

            query.Append(" ORDER BY created_at DESC")

            Using cmd As New MySqlCommand(query.ToString(), conn)
                If startDate.HasValue Then cmd.Parameters.AddWithValue("@startDate", startDate.Value)
                If endDate.HasValue Then cmd.Parameters.AddWithValue("@endDate", endDate.Value)
                If Not String.IsNullOrEmpty(username) Then cmd.Parameters.AddWithValue("@username", username)
                If Not String.IsNullOrEmpty(moduleName) Then cmd.Parameters.AddWithValue("@module", moduleName)
                If Not String.IsNullOrEmpty(userType) Then cmd.Parameters.AddWithValue("@userType", userType)

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetAuditLogsFiltered Exception: " & ex.Message)
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
    Private Shared Function SafeOpenConnection(ByRef conn As MySqlConnection, Optional maxRetries As Integer = 3) As Boolean
        If conn Is Nothing Then
            conn = GetConnection()
            If conn Is Nothing Then Return False
        End If

        Dim retryCount As Integer = 0
        While retryCount < maxRetries
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                    Return True
                ElseIf conn.State = ConnectionState.Broken Then
                    conn.Close()
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

                Dim staffQuery As New StringBuilder("SELECT COUNT(*) FROM staff_accounts WHERE LOWER(username) = LOWER(@username)")
                If excludeStaffID.HasValue Then staffQuery.Append(" AND staff_id <> @excludeStaffID")

                Using cmd As New MySqlCommand(staffQuery.ToString(), conn)
                    cmd.Parameters.AddWithValue("@username", username.Trim())
                    If excludeStaffID.HasValue Then cmd.Parameters.AddWithValue("@excludeStaffID", excludeStaffID.Value)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                        Return "duplicate_username"
                    End If
                End Using
            End If

            If Not String.IsNullOrWhiteSpace(email) Then
                Dim adminEmailQuery As New StringBuilder("SELECT COUNT(*) FROM users WHERE LOWER(email) = LOWER(@email)")
                If excludeAdminID.HasValue Then adminEmailQuery.Append(" AND user_id <> @excludeAdminID")

                Using cmd As New MySqlCommand(adminEmailQuery.ToString(), conn)
                    cmd.Parameters.AddWithValue("@email", email.Trim())
                    If excludeAdminID.HasValue Then cmd.Parameters.AddWithValue("@excludeAdminID", excludeAdminID.Value)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                        Return "duplicate_email"
                    End If
                End Using

                Dim staffEmailQuery As New StringBuilder("SELECT COUNT(*) FROM staff_accounts WHERE LOWER(email) = LOWER(@email)")
                If excludeStaffID.HasValue Then staffEmailQuery.Append(" AND staff_id <> @excludeStaffID")

                Using cmd As New MySqlCommand(staffEmailQuery.ToString(), conn)
                    cmd.Parameters.AddWithValue("@email", email.Trim())
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
            query.Append("SELECT user_id, first_name, middle_name, last_name, suffix, position, ")
            query.Append("department_id, contact_number, email, username, user_type, status, ")
            query.Append("employee_id, date_assigned, last_login, created_at ")
            query.Append("FROM users WHERE user_type IN ('Admin','SuperAdmin')")

            If Not String.IsNullOrEmpty(statusFilter) Then query.Append(" AND status = @status")
            If Not String.IsNullOrEmpty(roleFilter) Then query.Append(" AND user_type = @role")
            If Not String.IsNullOrEmpty(searchKeyword) Then
                query.Append(" AND (")
                query.Append("LOWER(first_name) LIKE @search OR LOWER(last_name) LIKE @search OR ")
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
                Dim employeeQuery As String = "SELECT COUNT(*) FROM users WHERE employee_id = @employeeID"
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

            Dim normalizedUserType As String = If(String.Equals(userType, "SuperAdmin", StringComparison.OrdinalIgnoreCase), "SuperAdmin", "Admin")
            Dim normalizedStatus As String = If(String.Equals(status, "Inactive", StringComparison.OrdinalIgnoreCase), "Inactive", "Active")
            Dim assignedDate As Date = If(dateAssigned.HasValue, dateAssigned.Value, Date.Today)

            Dim insertQuery As String =
                "INSERT INTO users (first_name, middle_name, last_name, suffix, position, department_id, contact_number, email, username, password, " &
                "house_no_street, barangay, municipality, province_city, date_assigned, employee_id, user_type, status, created_at) " &
                "VALUES (@firstName, @middleName, @lastName, @suffix, @position, @departmentID, @contactNumber, @email, @username, @password, " &
                "@houseNo, @barangay, @municipality, @province, @dateAssigned, @employeeID, @userType, @status, NOW())"

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
                cmd.Parameters.AddWithValue("@houseNo", If(String.IsNullOrWhiteSpace(houseNoStreet), DBNull.Value, houseNoStreet.Trim()))
                cmd.Parameters.AddWithValue("@barangay", If(String.IsNullOrWhiteSpace(barangay), DBNull.Value, barangay.Trim()))
                cmd.Parameters.AddWithValue("@municipality", If(String.IsNullOrWhiteSpace(municipality), DBNull.Value, municipality.Trim()))
                cmd.Parameters.AddWithValue("@province", If(String.IsNullOrWhiteSpace(provinceCity), DBNull.Value, provinceCity.Trim()))
                cmd.Parameters.AddWithValue("@dateAssigned", assignedDate)
                cmd.Parameters.AddWithValue("@employeeID", If(String.IsNullOrWhiteSpace(employeeID), DBNull.Value, employeeID.Trim()))
                cmd.Parameters.AddWithValue("@userType", normalizedUserType)
                cmd.Parameters.AddWithValue("@status", normalizedStatus)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    LogCrudAction(createdByID, createdByType, createdByName, moduleName, entityLabel, "Create",
                                  $"Created {entityLabel.ToLower()} ({username.Trim()})", ipAddress)
                    Return True
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddAdminAccount Exception: " & ex.Message)
            MessageBox.Show("Error creating admin account: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                Dim employeeQuery As String = "SELECT COUNT(*) FROM users WHERE employee_id = @employeeID AND user_id <> @adminID"
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
                "UPDATE users SET first_name = @firstName, middle_name = @middleName, last_name = @lastName, suffix = @suffix, " &
                "position = @position, department_id = @departmentID, contact_number = @contactNumber, email = @email, username = @username, " &
                "house_no_street = @houseNo, barangay = @barangay, municipality = @municipality, province_city = @province, " &
                "date_assigned = @dateAssigned, employee_id = @employeeID, user_type = @userType, status = @status, updated_at = NOW() " &
                "WHERE user_id = @adminID"

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

            Dim query As String = "UPDATE users SET password = @password, updated_at = NOW() WHERE user_id = @adminID"
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
            Dim query As String = "UPDATE users SET status = @status, updated_at = NOW() WHERE user_id = @adminID"

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
        If performedByID.HasValue AndAlso performedByID.Value = adminID Then
            MessageBox.Show("You cannot delete the account that is currently logged in.", "Operation Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim query As String = "DELETE FROM users WHERE user_id = @adminID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@adminID", adminID)

                Dim rows As Integer = cmd.ExecuteNonQuery()
                If rows > 0 Then
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
            query.Append("SELECT staff_id, first_name, last_name, email, contact_number, address, ")
            query.Append("department_id, username, position, status, created_date ")
            query.Append("FROM staff_accounts WHERE 1=1")

            If Not String.IsNullOrEmpty(statusFilter) Then query.Append(" AND status = @status")
            If departmentID.HasValue Then query.Append(" AND department_id = @departmentID")
            If Not String.IsNullOrEmpty(searchKeyword) Then
                query.Append(" AND (")
                query.Append("LOWER(first_name) LIKE @search OR LOWER(last_name) LIKE @search OR ")
                query.Append("LOWER(username) LIKE @search OR LOWER(email) LIKE @search)")
            End If

            query.Append(" ORDER BY created_date DESC")

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
            Dim insertQuery As String =
                "INSERT INTO staff_accounts (first_name, last_name, email, contact_number, address, department_id, username, password, position, status, created_date) " &
                "VALUES (@firstName, @lastName, @email, @contactNumber, @address, @departmentID, @username, @password, @position, @status, NOW())"

            Using cmd As New MySqlCommand(insertQuery, conn)
                cmd.Parameters.AddWithValue("@firstName", firstName.Trim())
                cmd.Parameters.AddWithValue("@lastName", lastName.Trim())
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrWhiteSpace(contactNumber), DBNull.Value, contactNumber.Trim()))
                cmd.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(address), DBNull.Value, address.Trim()))
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
            Dim updateQuery As String =
                "UPDATE staff_accounts SET first_name = @firstName, last_name = @lastName, email = @email, contact_number = @contactNumber, " &
                "address = @address, department_id = @departmentID, username = @username, position = @position, status = @status " &
                "WHERE staff_id = @staffID"

            Using cmd As New MySqlCommand(updateQuery, conn)
                cmd.Parameters.AddWithValue("@firstName", firstName.Trim())
                cmd.Parameters.AddWithValue("@lastName", lastName.Trim())
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.Parameters.AddWithValue("@contactNumber", If(String.IsNullOrWhiteSpace(contactNumber), DBNull.Value, contactNumber.Trim()))
                cmd.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(address), DBNull.Value, address.Trim()))
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

            Using cmd As New MySqlCommand("UPDATE staff_accounts SET password = @password WHERE staff_id = @staffID", conn)
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
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim statusValue As String = If(isActive, "Active", "Inactive")
            Using cmd As New MySqlCommand("UPDATE staff_accounts SET status = @status WHERE staff_id = @staffID", conn)
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
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Using cmd As New MySqlCommand("DELETE FROM staff_accounts WHERE staff_id = @staffID", conn)
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
            query.Append("SELECT user_id, first_name, last_name, position, contact_number, email, username, status, last_login ")
            query.Append("FROM users WHERE LOWER(IFNULL(position,'')) LIKE '%custodian%'")
            If Not includeInactive Then query.Append(" AND status = 'Active'")
            If Not String.IsNullOrEmpty(searchKeyword) Then
                query.Append(" AND (LOWER(first_name) LIKE @search OR LOWER(last_name) LIKE @search OR LOWER(username) LIKE @search)")
            End If
            query.Append(" ORDER BY last_name ASC")

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
            query.Append("FROM audit_logs WHERE user_id = @custodianID")
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
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False

            Dim normalizedStatus As String = If(String.IsNullOrWhiteSpace(newStatus), "active", newStatus.Trim())
            Dim updateSql As New StringBuilder("UPDATE properties SET status = @status, updated_at = NOW()")
            If Not String.IsNullOrWhiteSpace(conditionStatus) Then updateSql.Append(", condition_status = @condition")
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

            Dim query As String = "SELECT property_name, acquisition_date, acquisition_cost, life_span, depreciation_value, " &
                                  "warranty_details, condition_status, status, disposal_date " &
                                  "FROM properties WHERE property_id = @propertyID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@propertyID", propertyID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        result("property_name") = reader("property_name").ToString()
                        result("acquisition_date") = reader("acquisition_date")
                        result("acquisition_cost") = reader("acquisition_cost")
                        result("life_span") = If(IsDBNull(reader("life_span")), 0, CInt(reader("life_span")))
                        result("depreciation_value") = If(IsDBNull(reader("depreciation_value")), 0D, CDec(reader("depreciation_value")))
                        result("warranty_details") = If(IsDBNull(reader("warranty_details")), String.Empty, reader("warranty_details").ToString())
                        result("condition_status") = If(IsDBNull(reader("condition_status")), String.Empty, reader("condition_status").ToString())
                        result("status") = reader("status").ToString()
                        result("disposal_date") = If(IsDBNull(reader("disposal_date")), Nothing, reader("disposal_date"))
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
    ''' Get low stock supplies (quantity &lt;= reorder level) (NEW)
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
            query.Append("SELECT supply_id, supply_name, category, quantity_in_stock, reorder_level, unit_cost, ")
            query.Append("total_value, status, location FROM supplies WHERE 1=1 ")
            If includeLowStockOnly Then query.Append("AND quantity_in_stock <= reorder_level ")
            If Not String.IsNullOrEmpty(category) Then query.Append("AND category = @category ")
            query.Append("ORDER BY category, supply_name")

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
