Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class EditProfile

    Private Sub btn_Cancel_Click(sender As Object, e As System.EventArgs) Handles btn_Cancel.Click
        Me.Close()
    End Sub
    
    Private Sub EditProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProfileData()
    End Sub
    
    Private Sub LoadProfileData()
        Try
            If Not SessionContext.CurrentUserID.HasValue OrElse SessionContext.CurrentUserID.Value <= 0 Then
                MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Return
            End If
            
            Dim profile As Dictionary(Of String, Object) = DatabaseConnection.GetStaffProfile(SessionContext.CurrentUserID.Value)
            
            If profile IsNot Nothing AndAlso profile.Count > 0 Then
                ' Populate edit fields
                If profile.ContainsKey("user_id") Then txb_UserID.Text = profile("user_id").ToString()
                If profile.ContainsKey("first_name") Then txb_FirstName.Text = profile("first_name").ToString()
                If profile.ContainsKey("middle_name") Then txb_MiddleName.Text = If(profile("middle_name") IsNot Nothing, profile("middle_name").ToString(), "")
                If profile.ContainsKey("last_name") Then txb_LastName.Text = profile("last_name").ToString()
                If profile.ContainsKey("suffix") Then txb_Suffix.Text = If(profile("suffix") IsNot Nothing, profile("suffix").ToString(), "")
                If profile.ContainsKey("position") Then txb_Position.Text = If(profile("position") IsNot Nothing, profile("position").ToString(), "")
                If profile.ContainsKey("email") Then txb_Email.Text = profile("email").ToString()
                If profile.ContainsKey("contact_number") Then txb_ContactNumber.Text = If(profile("contact_number") IsNot Nothing, profile("contact_number").ToString(), "")
                If profile.ContainsKey("username") Then txb_UserName.Text = profile("username").ToString()
                If profile.ContainsKey("employee_id") Then txb_EmployeeID.Text = If(profile("employee_id") IsNot Nothing, profile("employee_id").ToString(), "")
                If profile.ContainsKey("department_id") AndAlso profile("department_id") IsNot Nothing Then
                    txb_DepartmentID.Text = profile("department_id").ToString()
                End If
            Else
                MessageBox.Show("Unable to load profile information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        ' Save profile changes
        Try
            If Not SessionContext.CurrentUserID.HasValue OrElse SessionContext.CurrentUserID.Value <= 0 Then
                MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Validate required fields
            If String.IsNullOrWhiteSpace(txb_FirstName.Text) Then
                MessageBox.Show("First name is required.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txb_FirstName.Focus()
                Return
            End If
            
            If String.IsNullOrWhiteSpace(txb_LastName.Text) Then
                MessageBox.Show("Last name is required.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txb_LastName.Focus()
                Return
            End If
            
            If String.IsNullOrWhiteSpace(txb_Email.Text) Then
                MessageBox.Show("Email is required.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txb_Email.Focus()
                Return
            End If
            
            If String.IsNullOrWhiteSpace(txb_UserName.Text) Then
                MessageBox.Show("Username is required.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txb_UserName.Focus()
                Return
            End If
            
            ' Get department ID if provided
            Dim deptID As Integer? = Nothing
            If Not String.IsNullOrWhiteSpace(txb_DepartmentID.Text) Then
                Integer.TryParse(txb_DepartmentID.Text, deptID)
            End If
            
            ' Update profile using UpdateStaffAccount (staff can update their own profile)
            Dim success As Boolean = DatabaseConnection.UpdateStaffAccount(
                SessionContext.CurrentUserID.Value,
                txb_FirstName.Text.Trim(),
                txb_LastName.Text.Trim(),
                txb_Email.Text.Trim(),
                txb_UserName.Text.Trim(),
                txb_ContactNumber.Text.Trim(),
                "", ' address - not used in users table
                deptID,
                txb_Position.Text.Trim(),
                "Active", ' status
                SessionContext.CurrentUserID.Value, ' updated by
                "Staff", ' updated by type
                "", ' updated by name
                "" ' ip address
            )
            
            If success Then
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("Failed to update profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class