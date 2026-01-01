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
            
            Dim profile As Dictionary(Of String, Object) = modDB.GetStaffProfile(SessionContext.CurrentUserID.Value)
            
            If profile IsNot Nothing AndAlso profile.Count > 0 Then
                ' Populate edit fields - use camelCase to match database
                If profile.ContainsKey("userId") Then txb_UserID.Text = profile("userId").ToString()
                If profile.ContainsKey("firstName") Then txb_FirstName.Text = profile("firstName").ToString()
                If profile.ContainsKey("middleName") Then txb_MiddleName.Text = If(profile("middleName") IsNot Nothing, profile("middleName").ToString(), "")
                If profile.ContainsKey("lastName") Then txb_LastName.Text = profile("lastName").ToString()
                If profile.ContainsKey("suffix") Then txb_Suffix.Text = If(profile("suffix") IsNot Nothing, profile("suffix").ToString(), "")
                If profile.ContainsKey("position") Then txb_Position.Text = If(profile("position") IsNot Nothing, profile("position").ToString(), "")
                If profile.ContainsKey("email") Then txb_Email.Text = profile("email").ToString()
                If profile.ContainsKey("contactNumber") Then txb_ContactNumber.Text = If(profile("contactNumber") IsNot Nothing, profile("contactNumber").ToString(), "")
                If profile.ContainsKey("username") Then txb_UserName.Text = profile("username").ToString()
                If profile.ContainsKey("employeeId") Then txb_EmployeeID.Text = If(profile("employeeId") IsNot Nothing, profile("employeeId").ToString(), "")
                If profile.ContainsKey("departmentId") AndAlso profile("departmentId") IsNot Nothing Then
                    txb_DepartmentID.Text = profile("departmentId").ToString()
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
            
            ' Get department ID if provided - ensure it's a valid integer or Nothing
            Dim deptID As Integer? = Nothing
            If Not String.IsNullOrWhiteSpace(txb_DepartmentID.Text) Then
                Dim parsedDeptID As Integer
                If Integer.TryParse(txb_DepartmentID.Text.Trim(), parsedDeptID) AndAlso parsedDeptID > 0 Then
                    deptID = parsedDeptID
                End If
            End If
            
            ' Ensure all required fields have values
            Dim firstName As String = If(String.IsNullOrWhiteSpace(txb_FirstName.Text), "", txb_FirstName.Text.Trim())
            Dim lastName As String = If(String.IsNullOrWhiteSpace(txb_LastName.Text), "", txb_LastName.Text.Trim())
            Dim email As String = If(String.IsNullOrWhiteSpace(txb_Email.Text), "", txb_Email.Text.Trim())
            Dim username As String = If(String.IsNullOrWhiteSpace(txb_UserName.Text), "", txb_UserName.Text.Trim())
            Dim contactNumber As String = If(String.IsNullOrWhiteSpace(txb_ContactNumber.Text), "", txb_ContactNumber.Text.Trim())
            Dim position As String = If(String.IsNullOrWhiteSpace(txb_Position.Text), "Staff", txb_Position.Text.Trim())
            
            ' Update profile using UpdateStaffAccount (staff can update their own profile)
            Dim success As Boolean = modDB.UpdateStaffAccount(
                SessionContext.CurrentUserID.Value,
                firstName,
                lastName,
                email,
                username,
                contactNumber,
                "", ' address - not used in users table
                deptID,
                position,
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

    Private Sub position_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class