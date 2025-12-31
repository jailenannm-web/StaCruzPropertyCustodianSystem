Imports System
Imports System.Data
Imports System.Net
Imports System.Net.Sockets
Imports System.Management
Imports MySql.Data.MySqlClient

Public Class AuditLogger
    ''' <summary>
    ''' Logs an action to the audit_logs table with all required fields
    ''' </summary>
    ''' <param name="userId">ID of the user performing the action</param>
    ''' <param name="action">Action being performed (Login, Logout, Create, Update, Delete, View, Export)</param>
    ''' <param name="tableName">Name of the table being affected</param>
    ''' <param name="recordId">ID of the record being affected (optional)</param>
    ''' <param name="description">Detailed description of the action</param>
    ''' <param name="userRole">Role of the user (SuperAdmin, Admin, Custodian, Staff)</param>
    Public Shared Sub LogAction(userId As Integer?, action As String, tableName As String, recordId As Integer?, description As String, userRole As String)
        Try
            Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
            If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                
                ' Get IP Address
                Dim ipAddress As String = GetLocalIPAddress()
                
                ' Use userRole as userAgent field
                Dim userAgent As String = If(String.IsNullOrEmpty(userRole), "Unknown", userRole)
                
                Dim query As String = "INSERT INTO audit_logs " &
                                     "(userId, action, tableName, recordId, description, ipAddress, userAgent, createdAt) " &
                                     "VALUES (@userId, @action, @tableName, @recordId, @description, @ipAddress, @userAgent, NOW())"
                
                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters with proper null handling
                    If userId.HasValue Then
                        cmd.Parameters.AddWithValue("@userId", userId.Value)
                    Else
                        cmd.Parameters.AddWithValue("@userId", DBNull.Value)
                    End If
                    
                    cmd.Parameters.AddWithValue("@action", action)
                    
                    If String.IsNullOrEmpty(tableName) Then
                        cmd.Parameters.AddWithValue("@tableName", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@tableName", tableName)
                    End If
                    
                    If recordId.HasValue Then
                        cmd.Parameters.AddWithValue("@recordId", recordId.Value)
                    Else
                        cmd.Parameters.AddWithValue("@recordId", DBNull.Value)
                    End If
                    
                    If String.IsNullOrEmpty(description) Then
                        cmd.Parameters.AddWithValue("@description", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@description", description)
                    End If
                    
                    cmd.Parameters.AddWithValue("@ipAddress", ipAddress)
                    cmd.Parameters.AddWithValue("@userAgent", userAgent)
                    
                    cmd.ExecuteNonQuery()
                    
                    System.Diagnostics.Debug.WriteLine($"[AuditLogger] Logged: {action} by {userRole} (User {userId}) on {tableName} record {recordId}")
                End Using
                
                conn.Close()
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[AuditLogger] Error logging audit: {ex.Message}")
            ' Don't throw exception - audit logging should not break the application
        End Try
    End Sub
    
    ''' <summary>
    ''' Overload for actions without a specific record ID
    ''' </summary>
    Public Shared Sub LogAction(userId As Integer?, action As String, tableName As String, description As String, userRole As String)
        LogAction(userId, action, tableName, Nothing, description, userRole)
    End Sub
    
    ''' <summary>
    ''' Gets the local IP address of the computer
    ''' </summary>
    Private Shared Function GetLocalIPAddress() As String
        Try
            ' Try to get the local network IP
            Dim host As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
            
            For Each ip As IPAddress In host.AddressList
                ' Get IPv4 address that is not loopback
                If ip.AddressFamily = AddressFamily.InterNetwork AndAlso Not IPAddress.IsLoopback(ip) Then
                    Return ip.ToString()
                End If
            Next
            
            ' If no network IP found, return localhost
            Return "127.0.0.1"
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[AuditLogger] Error getting IP: {ex.Message}")
            Return "Unknown"
        End Try
    End Function
    
    ''' <summary>
    ''' Log user login
    ''' </summary>
    Public Shared Sub LogLogin(userId As Integer, username As String, userRole As String, success As Boolean)
        Dim action As String = If(success, "Login", "Login Failed")
        Dim description As String = If(success, 
            $"User '{username}' logged in successfully as {userRole}",
            $"Failed login attempt for user '{username}'")
        
        ' Login events don't have table or record ID
        LogAction(userId, action, Nothing, Nothing, description, userRole)
    End Sub
    
    ''' <summary>
    ''' Log user logout
    ''' </summary>
    Public Shared Sub LogLogout(userId As Integer, username As String, userRole As String)
        Dim description As String = $"User '{username}' logged out"
        ' Logout events don't have table or record ID
        LogAction(userId, "Logout", Nothing, Nothing, description, userRole)
    End Sub
    
    ''' <summary>
    ''' Log record creation
    ''' </summary>
    Public Shared Sub LogCreate(userId As Integer, tableName As String, recordId As Integer, description As String, userRole As String)
        LogAction(userId, "Create", tableName, recordId, description, userRole)
    End Sub
    
    ''' <summary>
    ''' Log record update
    ''' </summary>
    Public Shared Sub LogUpdate(userId As Integer, tableName As String, recordId As Integer, description As String, userRole As String)
        LogAction(userId, "Update", tableName, recordId, description, userRole)
    End Sub
    
    ''' <summary>
    ''' Log record deletion
    ''' </summary>
    Public Shared Sub LogDelete(userId As Integer, tableName As String, recordId As Integer, description As String, userRole As String)
        LogAction(userId, "Delete", tableName, recordId, description, userRole)
    End Sub
    
    ''' <summary>
    ''' Log record view/access
    ''' </summary>
    Public Shared Sub LogView(userId As Integer, tableName As String, recordId As Integer?, description As String, userRole As String)
        LogAction(userId, "View", tableName, recordId, description, userRole)
    End Sub
    
    ''' <summary>
    ''' Log data export
    ''' </summary>
    Public Shared Sub LogExport(userId As Integer, exportType As String, description As String, userRole As String)
        LogAction(userId, "Export", Nothing, Nothing, $"{exportType} export: {description}", userRole)
    End Sub
End Class
