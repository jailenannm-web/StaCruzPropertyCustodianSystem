' Script to create test staff account
' Run this from the application or execute the SQL directly
' Username: test_staff
' Password: Staff@1234
' Role: Staff

Imports System
Imports System.Data

Public Module CreateTestStaffAccount
    Public Sub CreateTestStaff()
        Try
            ' Get first department for assignment
            Dim deptTable As DataTable = DatabaseConnection.GetDepartmentLookup(True)
            Dim deptID As Integer? = Nothing
            If deptTable.Rows.Count > 0 Then
                deptID = Convert.ToInt32(deptTable.Rows(0)("department_id"))
            End If

            ' Create the test staff account
            Dim success As Boolean = DatabaseConnection.AddStaffAccount(
                firstName:="Test",
                lastName:="Staff",
                email:="test_staff@stacruz.edu",
                username:="test_staff",
                password:="Staff@1234",
                contactNumber:="",
                address:="",
                departmentID:=deptID,
                position:="Staff",
                status:="Active",
                createdByID:=Nothing,
                createdByType:="System",
                createdByName:="System",
                ipAddress:="127.0.0.1"
            )

            If success Then
                MessageBox.Show("Test staff account created successfully!" & vbCrLf &
                              "Username: test_staff" & vbCrLf &
                              "Password: Staff@1234" & vbCrLf &
                              "Role: Staff",
                              "Test Account Created",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to create test staff account. It may already exist.",
                              "Account Creation Failed",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error creating test staff account: " & ex.Message,
                          "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End Try
    End Sub
End Module

