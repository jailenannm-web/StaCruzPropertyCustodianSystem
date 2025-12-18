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
                ' Populate profile fields - GetStaffProfile returns camelCase keys
                If profile.ContainsKey("firstName") Then lb_FirstName.Text = profile("firstName").ToString()
                If profile.ContainsKey("middleName") Then lb_MiddleName.Text = If(profile("middleName") IsNot Nothing, profile("middleName").ToString(), "")
                If profile.ContainsKey("lastName") Then lb_LastName.Text = profile("lastName").ToString()
                If profile.ContainsKey("suffix") Then lb_Suffix.Text = If(profile("suffix") IsNot Nothing, profile("suffix").ToString(), "")
                If profile.ContainsKey("position") Then lb_Position.Text = If(profile("position") IsNot Nothing, profile("position").ToString(), "")
                If profile.ContainsKey("email") Then lb_Email.Text = profile("email").ToString()
                If profile.ContainsKey("contactNumber") Then lb_ContactNumber.Text = If(profile("contactNumber") IsNot Nothing, profile("contactNumber").ToString(), "")
                If profile.ContainsKey("username") Then lb_UserName.Text = profile("username").ToString()
                If profile.ContainsKey("employeeId") Then lb_Employee.Text = If(profile("employeeId") IsNot Nothing, profile("employeeId").ToString(), "")
                If profile.ContainsKey("userId") Then lb_UserID.Text = profile("userId").ToString()
                
                ' Get department name if departmentId exists
                If profile.ContainsKey("departmentId") AndAlso profile("departmentId") IsNot Nothing Then
                    Try
                        Dim deptID As Integer = Convert.ToInt32(profile("departmentId"))
                        Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
                        For Each row As DataRow In dt.Rows
                            Dim rowDeptID As Integer = 0
                            If row.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(row("departmentId")) Then
                                Integer.TryParse(row("departmentId").ToString(), rowDeptID)
                            ElseIf row.Table.Columns.Contains("department_id") AndAlso Not IsDBNull(row("department_id")) Then
                                Integer.TryParse(row("department_id").ToString(), rowDeptID)
                            End If
                            If rowDeptID = deptID Then
                                If row.Table.Columns.Contains("departmentName") Then
                                    lb_Department.Text = row("departmentName").ToString()
                                ElseIf row.Table.Columns.Contains("department_name") Then
                                    lb_Department.Text = row("department_name").ToString()
                                End If
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine("frmProfile LoadDepartment Error: " & ex.Message)
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


