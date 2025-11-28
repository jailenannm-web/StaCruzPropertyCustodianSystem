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

    Public Function IsCustodian() As Boolean
        Return String.Equals(CurrentRole, "Custodian", StringComparison.OrdinalIgnoreCase) _
            OrElse String.Equals(CurrentRole, "Staff", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function HasPermission(permission As ModulePermission) As Boolean
        Select Case permission
            Case ModulePermission.ManageUsers
                Return IsSuperAdmin() OrElse IsAdmin()
            Case ModulePermission.ModifyProperties
                Return IsSuperAdmin() OrElse IsAdmin() OrElse IsCustodian()
            Case ModulePermission.ModifySupplies
                Return IsSuperAdmin() OrElse IsAdmin() OrElse IsCustodian()
            Case ModulePermission.ModifyRequests
                Return IsSuperAdmin() OrElse IsAdmin() OrElse IsCustodian()
            Case ModulePermission.ModifyMaintenance
                Return IsSuperAdmin() OrElse IsAdmin() OrElse IsCustodian()
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
