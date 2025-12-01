Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Public Class frmProfile

    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        Dim editProfileForm As New EditProfile()
        editProfileForm.Show()
        Me.Hide()
    End Sub

    Private Sub frmProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProfileData()
    End Sub
    
    Private Sub LoadProfileData()
        Try
            If Not SessionContext.CurrentUserID.HasValue OrElse SessionContext.CurrentUserID.Value <= 0 Then
                MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            Dim profile As Dictionary(Of String, Object) = DatabaseConnection.GetStaffProfile(SessionContext.CurrentUserID.Value)
            
            If profile IsNot Nothing AndAlso profile.Count > 0 Then
                ' Populate profile fields
                If profile.ContainsKey("first_name") Then lb_FirstName.Text = profile("first_name").ToString()
                If profile.ContainsKey("middle_name") Then lb_MiddleName.Text = If(profile("middle_name") IsNot Nothing, profile("middle_name").ToString(), "")
                If profile.ContainsKey("last_name") Then lb_LastName.Text = profile("last_name").ToString()
                If profile.ContainsKey("suffix") Then lb_Suffix.Text = If(profile("suffix") IsNot Nothing, profile("suffix").ToString(), "")
                If profile.ContainsKey("position") Then lb_Position.Text = If(profile("position") IsNot Nothing, profile("position").ToString(), "")
                If profile.ContainsKey("email") Then lb_Email.Text = profile("email").ToString()
                If profile.ContainsKey("contact_number") Then lb_ContactNumber.Text = If(profile("contact_number") IsNot Nothing, profile("contact_number").ToString(), "")
                If profile.ContainsKey("username") Then lb_UserName.Text = profile("username").ToString()
                If profile.ContainsKey("employee_id") Then lb_Employee.Text = If(profile("employee_id") IsNot Nothing, profile("employee_id").ToString(), "")
                If profile.ContainsKey("user_id") Then lb_UserID.Text = profile("user_id").ToString()
                
                ' Get department name if department_id exists
                If profile.ContainsKey("department_id") AndAlso profile("department_id") IsNot Nothing Then
                    Try
                        Dim deptID As Integer = Convert.ToInt32(profile("department_id"))
                        Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
                        For Each row As DataRow In dt.Rows
                            If Convert.ToInt32(row("department_id")) = deptID Then
                                lb_Department.Text = row("department_name").ToString()
                                Exit For
                            End If
                        Next
                    Catch
                    End Try
                End If
            Else
                MessageBox.Show("Unable to load profile information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("frmProfile LoadProfileData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub
End Class


