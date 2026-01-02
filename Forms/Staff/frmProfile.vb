Imports System
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Generic
Imports System.Drawing
Imports Microsoft.VisualBasic

Public Class frmProfile

    Private Sub frmProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProfileData()
    End Sub

    Private Sub LoadProfileData()
        Try
            ' Check if user is logged in
            If Not SessionContext.CurrentUserID.HasValue OrElse SessionContext.CurrentUserID.Value <= 0 Then
                MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get profile data from database
            Dim profile As Dictionary(Of String, Object) = modDB.GetStaffProfile(SessionContext.CurrentUserID.Value)

            If profile IsNot Nothing AndAlso profile.Count > 0 Then
                ' Personal Information
                txtUserId.Text = If(profile.ContainsKey("userId"), profile("userId").ToString(), "N/A")
                txtFirstName.Text = If(profile.ContainsKey("firstName"), profile("firstName").ToString(), "")
                txtMiddleName.Text = If(profile.ContainsKey("middleName") AndAlso profile("middleName") IsNot Nothing, profile("middleName").ToString(), "")
                txtLastName.Text = If(profile.ContainsKey("lastName"), profile("lastName").ToString(), "")
                txtSuffix.Text = If(profile.ContainsKey("suffix") AndAlso profile("suffix") IsNot Nothing, profile("suffix").ToString(), "")

                ' Work Information
                txtPosition.Text = If(profile.ContainsKey("position") AndAlso profile("position") IsNot Nothing, profile("position").ToString(), "N/A")
                txtEmployeeId.Text = If(profile.ContainsKey("employeeId") AndAlso profile("employeeId") IsNot Nothing, profile("employeeId").ToString(), "N/A")

                ' Get department name if departmentId exists
                If profile.ContainsKey("departmentId") AndAlso profile("departmentId") IsNot Nothing Then
                    Try
                        Dim deptID As Integer = Convert.ToInt32(profile("departmentId"))
                        Dim dt As DataTable = modDB.GetAllDepartments()
                        For Each row As DataRow In dt.Rows
                            Dim rowDeptID As Integer = 0
                            If row.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(row("departmentId")) Then
                                Integer.TryParse(row("departmentId").ToString(), rowDeptID)
                            ElseIf row.Table.Columns.Contains("department_id") AndAlso Not IsDBNull(row("department_id")) Then
                                Integer.TryParse(row("department_id").ToString(), rowDeptID)
                            End If
                            If rowDeptID = deptID Then
                                If row.Table.Columns.Contains("departmentName") Then
                                    txtDepartment.Text = row("departmentName").ToString()
                                ElseIf row.Table.Columns.Contains("department_name") Then
                                    txtDepartment.Text = row("department_name").ToString()
                                End If
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        txtDepartment.Text = "N/A"
                        System.Diagnostics.Debug.WriteLine("frmProfile LoadDepartment Error: " & ex.Message)
                    End Try
                Else
                    txtDepartment.Text = "N/A"
                End If

                ' Contact Information
                txtContactNumber.Text = If(profile.ContainsKey("contactNumber") AndAlso profile("contactNumber") IsNot Nothing, profile("contactNumber").ToString(), "N/A")
                txtEmail.Text = If(profile.ContainsKey("email") AndAlso profile("email") IsNot Nothing, profile("email").ToString(), "N/A")

                ' Address Information
                txtProvince.Text = If(profile.ContainsKey("province") AndAlso profile("province") IsNot Nothing AndAlso profile("province").ToString().Trim() <> "", profile("province").ToString(), "N/A")
                txtMunicipality.Text = If(profile.ContainsKey("municipal") AndAlso profile("municipal") IsNot Nothing AndAlso profile("municipal").ToString().Trim() <> "", profile("municipal").ToString(), "N/A")
                txtBarangay.Text = If(profile.ContainsKey("barangay") AndAlso profile("barangay") IsNot Nothing AndAlso profile("barangay").ToString().Trim() <> "", profile("barangay").ToString(), "N/A")
                
                ' Debug output
                System.Diagnostics.Debug.WriteLine($"Province: {If(profile.ContainsKey("province"), If(profile("province"), "NULL"), "KEY NOT FOUND")}")
                System.Diagnostics.Debug.WriteLine($"Municipal: {If(profile.ContainsKey("municipal"), If(profile("municipal"), "NULL"), "KEY NOT FOUND")}")
                System.Diagnostics.Debug.WriteLine($"Barangay: {If(profile.ContainsKey("barangay"), If(profile("barangay"), "NULL"), "KEY NOT FOUND")}")

                ' Account Information
                txtUsername.Text = If(profile.ContainsKey("username"), profile("username").ToString(), "")
                txtPassword.Text = "••••••••" ' Don't display actual password

            Else
                MessageBox.Show("Unable to load profile information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("frmProfile LoadProfileData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Open Edit Profile Form
        Dim editProfileForm As New EditProfile()
        editProfileForm.ShowDialog()
        
        ' Reload profile data after editing
        LoadProfileData()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadProfileData()
        MessageBox.Show("Profile refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
