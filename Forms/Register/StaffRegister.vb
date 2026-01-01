Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Data

Public Class StaffRegister

    ' Register button click
    Private Sub btn_Register_Click(sender As Object, e As EventArgs) Handles btn_Register.Click
        ' Validate all required fields
        If String.IsNullOrWhiteSpace(txb_FirstName.Text) Then
            MessageBox.Show("Please enter your first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_FirstName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txb_LastName.Text) Then
            MessageBox.Show("Please enter your last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_LastName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txb_Email.Text) Then
            MessageBox.Show("Please enter your email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_Email.Focus()
            Return
        End If

        ' Validate email format
        If Not txb_Email.Text.Contains("@") OrElse Not txb_Email.Text.Contains(".") Then
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_Email.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txb_ContactNumber.Text) Then
            MessageBox.Show("Please enter your contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_ContactNumber.Focus()
            Return
        End If





        If String.IsNullOrWhiteSpace(txb_UserName.Text) Then
            MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_UserName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Txb_Password.Text) Then
            MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Txb_Password.Focus()
            Return
        End If

        ' Validate password strength
        If Txb_Password.Text.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Attempt registration
        Dim firstName As String = txb_FirstName.Text.Trim()
        Dim middleName As String = txb_MiddleName.Text.Trim()
        Dim lastName As String = txb_LastName.Text.Trim()
        Dim suffix As String = If(cb_Suffix.SelectedItem IsNot Nothing, cb_Suffix.SelectedItem.ToString().Trim(), "")
        Dim email As String = txb_Email.Text.Trim()
        Dim contactNumber As String = txb_ContactNumber.Text.Trim()
        
        ' Get department ID from selected department
        Dim departmentID As String = ""
        If cb_Department.SelectedItem IsNot Nothing AndAlso Not String.IsNullOrEmpty(cb_Department.SelectedItem.ToString()) Then
            Dim selectedDept As Object = cb_Department.SelectedItem
            If TypeOf selectedDept Is DepartmentItem Then
                Dim deptItem As DepartmentItem = CType(selectedDept, DepartmentItem)
                departmentID = deptItem.Id.ToString()
            End If
        End If
        Dim employeeId As String = txb_EmployeeID.Text.Trim()
        Dim username As String = txb_UserName.Text.Trim()
        Dim password As String = Txb_Password.Text
        Dim position As String = If(String.IsNullOrWhiteSpace(txb_Position.Text), "Staff", txb_Position.Text.Trim())

        ' Get location values from dropdowns
        Dim province As String = If(cb_Province.SelectedItem IsNot Nothing, cb_Province.SelectedItem.ToString(), "")
        Dim municipal As String = If(cb_Municipality.SelectedItem IsNot Nothing, cb_Municipality.SelectedItem.ToString(), "")
        Dim barangay As String = If(cb_Barangay.SelectedItem IsNot Nothing, cb_Barangay.SelectedItem.ToString(), "")

        ' Compose address string from location controls (for backward compatibility)
        Dim addressParts As New List(Of String)()
        If Not String.IsNullOrWhiteSpace(province) Then addressParts.Add(province)
        If Not String.IsNullOrWhiteSpace(municipal) Then addressParts.Add(municipal)
        If Not String.IsNullOrWhiteSpace(barangay) Then addressParts.Add(barangay)
        Dim address As String = String.Join(", ", addressParts)

        ' Add debug logging before database call
        System.Diagnostics.Debug.WriteLine("[v0] Registration Attempt - Position: " & position & ", Username: " & username)

        ' Pass all parameters to RegisterStaff function
        If modDB.RegisterStaff(firstName, lastName, email, contactNumber, address, departmentID, username, password, position, middleName, suffix, employeeId, province, municipal, barangay) Then
            MessageBox.Show("Registration successful! You can now login with your new account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim staffLogin As New StaffLogin()
            staffLogin.Show()
            Me.Close()
        Else
            ' Registration failed, keep form open so user can try again
            System.Diagnostics.Debug.WriteLine("[v0] Registration failed - form remains open")
        End If

    End Sub

    ' Cancel button click
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Dim loginForm As New StaffLogin()
        loginForm.Show()
        Me.Close()
    End Sub


    Private Sub txb_FirstName_TextChanged(sender As Object, e As EventArgs) Handles txb_FirstName.TextChanged

    End Sub

    Private Sub txb_ContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txb_ContactNumber.TextChanged

    End Sub

    Private Sub txb_Email_TextChanged(sender As Object, e As EventArgs) Handles txb_Email.TextChanged

    End Sub

    Private Sub StaffRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDepartments()
    End Sub

    ' Show/Hide password toggle
    Private Sub btn_ShowPassword_Click(sender As Object, e As EventArgs) Handles btn_ShowPassword.Click
        If Txb_Password.PasswordChar = "*"c Then
            Txb_Password.PasswordChar = Char.MinValue
            btn_ShowPassword.Text = "Hide"
        Else
            Txb_Password.PasswordChar = "*"c
            btn_ShowPassword.Text = "Show"
        End If
    End Sub
    
    ' Load departments into dropdown
    Private Sub LoadDepartments()
        Try
            Dim departments As DataTable = modDB.GetAllDepartments()
            cb_Department.Items.Clear()
            cb_Department.Items.Add("")
            
            ' Filter only active departments and add to dropdown
            For Each row As DataRow In departments.Rows
                If row("status").ToString().Equals("Active", StringComparison.OrdinalIgnoreCase) Then
                    Dim deptId As Integer = Convert.ToInt32(row("departmentId"))
                    Dim deptName As String = row("departmentName").ToString()
                    cb_Department.Items.Add(New DepartmentItem(deptId, deptName))
                End If
            Next
            
            cb_Department.DisplayMember = "Name"
            cb_Department.ValueMember = "Id"
            If cb_Department.Items.Count > 0 Then
                cb_Department.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

' Helper class for department dropdown
Public Class DepartmentItem
    Public Property Id As Integer
    Public Property Name As String
    
    Public Sub New(id As Integer, name As String)
        Me.Id = id
        Me.Name = name
    End Sub
    
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
