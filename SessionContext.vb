Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class SessionContext
    ' ============================================================================
    ' SESSION CONTEXT MANAGEMENT
    ' ============================================================================
    ' This class manages user session information and permissions
    ' ============================================================================

    ' ============================================================================
    ' ENUMS
    ' ============================================================================

    Public Enum ModulePermission
        ViewDashboard = 1
        ManageUsers = 2
        ModifyProperties = 3
        ModifySupplies = 4
        ModifyRequests = 5
        ModifyMaintenance = 6
        ViewReports = 7
        SystemConfiguration = 8
    End Enum

    ' ============================================================================
    ' SHARED PROPERTIES
    ' ============================================================================

    Private Shared _currentUserID As Integer? = Nothing
    Private Shared _currentUsername As String = ""
    Private Shared _currentRole As String = ""
    Private Shared _currentFullName As String = ""
    Private Shared _currentDepartment As String = ""
    Private Shared _isLoggedIn As Boolean = False

    ' ============================================================================
    ' SHARED PROPERTY ACCESSORS
    ' ============================================================================

    Public Shared Property CurrentUserID As Integer?
        Get
            Return _currentUserID
        End Get
        Set(value As Integer?)
            _currentUserID = value
        End Set
    End Property

    Public Shared Property CurrentUsername As String
        Get
            Return _currentUsername
        End Get
        Set(value As String)
            _currentUsername = value
        End Set
    End Property

    Public Shared Property CurrentRole As String
        Get
            Return _currentRole
        End Get
        Set(value As String)
            _currentRole = value
        End Set
    End Property

    Public Shared Property CurrentFullName As String
        Get
            Return _currentFullName
        End Get
        Set(value As String)
            _currentFullName = value
        End Set
    End Property

    Public Shared Property CurrentDepartment As String
        Get
            Return _currentDepartment
        End Get
        Set(value As String)
            _currentDepartment = value
        End Set
    End Property

    Public Shared Property IsLoggedIn As Boolean
        Get
            Return _isLoggedIn
        End Get
        Set(value As Boolean)
            _isLoggedIn = value
        End Set
    End Property

    ' ============================================================================
    ' SESSION MANAGEMENT METHODS
    ' ============================================================================

    Public Shared Sub Login(userID As Integer, username As String, role As String, fullName As String, Optional department As String = "")
        _currentUserID = userID
        _currentUsername = username
        _currentRole = role
        _currentFullName = fullName
        _currentDepartment = department
        _isLoggedIn = True

        ' Update last login in database
        DatabaseConnection.UpdateLastLogin(userID)
    End Sub

    Public Shared Sub Logout()
        _currentUserID = Nothing
        _currentUsername = ""
        _currentRole = ""
        _currentFullName = ""
        _currentDepartment = ""
        _isLoggedIn = False
    End Sub

    ''' <summary>
    ''' Legacy method for backward compatibility - sets current user with minimal info
    ''' </summary>
    Public Shared Sub SetCurrentUser(userID As Integer, username As String, role As String)
        _currentUserID = userID
        _currentUsername = username
        _currentRole = role
        _currentFullName = username ' Use username as fallback for full name
        _currentDepartment = ""
        _isLoggedIn = True

        ' Update last login in database
        DatabaseConnection.UpdateLastLogin(userID)
    End Sub

    ''' <summary>
    ''' Legacy method for backward compatibility - resets session (same as Logout)
    ''' </summary>
    Public Shared Sub Reset()
        Logout()
    End Sub

    ' ============================================================================
    ' ROLE CHECK METHODS
    ' ============================================================================

    Public Shared Function IsSuperAdmin() As Boolean
        Return _currentRole = "SuperAdmin"
    End Function

    Public Shared Function IsAdmin() As Boolean
        Return _currentRole = "Admin"
    End Function

    Public Shared Function IsCustodian() As Boolean
        Return _currentRole = "Custodian"
    End Function

    Public Shared Function IsCustodianAdmin() As Boolean
        Return IsAdmin() OrElse IsSuperAdmin()
    End Function

    Public Shared Function IsStaff() As Boolean
        Return _currentRole = "Staff"
    End Function

    ' ============================================================================
    ' PERMISSION CHECK METHODS
    ' ============================================================================

    Public Shared Function DemandPermission(permission As ModulePermission, actionDescription As String) As Boolean
        ' Super Admin has all permissions
        If IsSuperAdmin() Then
            Return True
        End If

        ' Admin has most permissions except system configuration
        If IsAdmin() Then
            Select Case permission
                Case ModulePermission.SystemConfiguration
                    Return False
                Case Else
                    Return True
            End Select
        End If

        ' Custodian permissions
        If IsCustodian() Then
            Select Case permission
                Case ModulePermission.ViewDashboard,
                     ModulePermission.ModifyProperties,
                     ModulePermission.ModifySupplies,
                     ModulePermission.ModifyRequests,
                     ModulePermission.ModifyMaintenance,
                     ModulePermission.ViewReports
                    Return True
                Case Else
                    Return False
            End Select
        End If

        ' Staff permissions
        If IsStaff() Then
            Select Case permission
                Case ModulePermission.ViewDashboard,
                     ModulePermission.ModifyRequests,
                     ModulePermission.ViewReports
                    Return True
                Case Else
                    Return False
            End Select
        End If

        ' Default deny
        Return False
    End Function

    ' ============================================================================
    ' UTILITY METHODS
    ' ============================================================================

    Public Shared Function GetCurrentUserInfo() As Dictionary(Of String, Object)
        Dim info As New Dictionary(Of String, Object)()
        info.Add("userID", _currentUserID)
        info.Add("username", _currentUsername)
        info.Add("role", _currentRole)
        info.Add("fullName", _currentFullName)
        info.Add("department", _currentDepartment)
        info.Add("isLoggedIn", _isLoggedIn)
        Return info
    End Function

    Public Shared Function HasPermission(permission As ModulePermission) As Boolean
        Return DemandPermission(permission, "")
    End Function

    ' ============================================================================
    ' VALIDATION METHODS
    ' ============================================================================

    Public Shared Function ValidateSession() As Boolean
        Return _isLoggedIn AndAlso _currentUserID.HasValue AndAlso _currentUserID.Value > 0 AndAlso Not String.IsNullOrEmpty(_currentRole)
    End Function

    Public Shared Function RequireLogin(Optional redirectToLogin As Boolean = True) As Boolean
        If Not ValidateSession() Then
            If redirectToLogin Then
                MessageBox.Show("Please login to access this feature.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Note: Form navigation would be handled by the calling form
            End If
            Return False
        End If
        Return True
    End Function

End Class
