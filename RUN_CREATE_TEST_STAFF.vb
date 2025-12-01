' Quick script to create test staff account
' Add this to a button click or form load event to create the test account

Imports System
Imports System.Windows.Forms

Public Module CreateTestStaffHelper
    Public Sub CreateTestStaffAccountNow()
        Try
            Dim success As Boolean = DatabaseConnection.CreateTestStaffAccount()
            If success Then
                MessageBox.Show("Test staff account created successfully!" & Environment.NewLine &
                              "Username: test_staff" & Environment.NewLine &
                              "Password: Staff@1234" & Environment.NewLine &
                              "Role: Staff",
                              "Test Account Created",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to create test staff account. It may already exist or there was a database error.",
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

