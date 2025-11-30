Imports System
Imports System.Windows.Forms

Public Module SessionContext
    Public Property CurrentUserID As Integer?
    Public Property CurrentUsername As String = ""
    Public Property CurrentRole As String = ""

    Public Enum ModulePermission
        ManageUsers
        ModifyProperties
        ModifySupplies
        ModifyRequests
        ModifyMaintenance
    End Enum

    Public Sub SetCurrentUser(userID As Integer?, username As String, role As String)
        CurrentUserID = userID
        CurrentUsername = If(username, "")
        CurrentRole = If(role, "").Trim()
    End Sub

    Public Sub Reset()
        CurrentUserID = Nothing
        CurrentUsername = ""
        CurrentRole = ""
    End Sub

    Public Function IsSuperAdmin() As Boolean
        Return String.Equals(CurrentRole, "SuperAdmin", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function IsAdmin() As Boolean
        Return String.Equals(CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function IsCustodianAdmin() As Boolean
        Return String.Equals(CurrentRole, "Custodian", StringComparison.OrdinalIgnoreCase) _
            OrElse String.Equals(CurrentRole, "CustodianAdmin", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function IsCustodian() As Boolean
        Return String.Equals(CurrentRole, "Custodian", StringComparison.OrdinalIgnoreCase) _
            OrElse String.Equals(CurrentRole, "Staff", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function IsStaff() As Boolean
        Return String.Equals(CurrentRole, "Staff", StringComparison.OrdinalIgnoreCase)
    End Function

    ''' <summary>
    ''' Check if user has permission based on role requirements:
    ''' - Super Admin: Full access to everything
    ''' - Admin: Can manage requests, view inventories (NO add/edit/delete properties/supplies)
    ''' - Custodian Admin: Full access to inventory/maintenance (NO user management)
    ''' </summary>
    Public Function HasPermission(permission As ModulePermission) As Boolean
        Select Case permission
            Case ModulePermission.ManageUsers
                ' Only Super Admin can manage users
                Return IsSuperAdmin()
            Case ModulePermission.ModifyProperties
                ' Super Admin and Custodian Admin can modify properties
                ' Admin can only VIEW (returns False here)
                Return IsSuperAdmin() OrElse IsCustodianAdmin()
            Case ModulePermission.ModifySupplies
                ' Super Admin and Custodian Admin can modify supplies
                ' Admin can only VIEW (returns False here)
                Return IsSuperAdmin() OrElse IsCustodianAdmin()
            Case ModulePermission.ModifyRequests
                ' Super Admin, Admin, and Custodian Admin can manage requests
                Return IsSuperAdmin() OrElse IsAdmin() OrElse IsCustodianAdmin()
            Case ModulePermission.ModifyMaintenance
                ' Super Admin, Admin, and Custodian Admin can manage maintenance
                Return IsSuperAdmin() OrElse IsAdmin() OrElse IsCustodianAdmin()
            Case Else
                Return False
        End Select
    End Function

    ''' <summary>
    ''' Check if user can VIEW (read-only access) to a module
    ''' </summary>
    Public Function CanView(moduleName As String) As Boolean
        Select Case moduleName.ToLower()
            Case "properties", "property"
                Return IsSuperAdmin() OrElse IsAdmin() OrElse IsCustodianAdmin()
            Case "supplies", "supply"
                Return IsSuperAdmin() OrElse IsAdmin() OrElse IsCustodianAdmin()
            Case "requests", "request"
                Return IsSuperAdmin() OrElse IsAdmin() OrElse IsCustodianAdmin() OrElse IsStaff()
            Case "maintenance"
                Return IsSuperAdmin() OrElse IsAdmin() OrElse IsCustodianAdmin() OrElse IsStaff()
            Case "users", "user"
                Return IsSuperAdmin() OrElse IsAdmin()
            Case Else
                Return False
        End Select
    End Function

    Public Function DemandPermission(permission As ModulePermission, actionDescription As String) As Boolean
        If HasPermission(permission) Then
            Return True
        End If

        MessageBox.Show("You do not have permission to perform this action (" & actionDescription & ")." &
                        Environment.NewLine & "Please contact a Super Admin if you believe this is a mistake.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
        Return False
    End Function
End Module
