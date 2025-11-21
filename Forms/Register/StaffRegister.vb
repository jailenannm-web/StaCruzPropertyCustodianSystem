Imports System
Imports System.Windows.Forms

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

        If String.IsNullOrWhiteSpace(txb_ContactNumber.Text) Then
            MessageBox.Show("Please enter your contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_ContactNumber.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txb_HouseNoStreet.Text) Then
            MessageBox.Show("Please enter your address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_HouseNoStreet.Focus()
            Return
        End If

        ' Validate position selection
        If cb_Position.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(cb_Position.Text) Then
            MessageBox.Show("Please select a position (Super Admin, Admin, or Staff).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cb_Position.Focus()
            Return
        End If

        ' Only validate department ID for Staff position
        If cb_Position.Text = "Staff" AndAlso String.IsNullOrWhiteSpace(txb_DepartmentID.Text) Then
            MessageBox.Show("Please enter your department ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_DepartmentID.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txb_UserName.Text) Then
            MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txb_UserName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(pa.Text) Then
            MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            pa.Focus()
            Return
        End If

        ' Validate password strength
        If pa.Text.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Attempt registration
        Dim firstName As String = txb_FirstName.Text
        Dim lastName As String = txb_LastName.Text
        Dim email As String = txb_Email.Text
        Dim contactNumber As String = txb_ContactNumber.Text
        Dim address As String = txb_HouseNoStreet.Text
        Dim departmentID As String = txb_DepartmentID.Text
        Dim username As String = txb_UserName.Text
        Dim password As String = pa.Text
        Dim position As String = cb_Position.Text

        ' Add debug logging before database call
        System.Diagnostics.Debug.WriteLine("[v0] Registration Attempt - Position: " & position & ", Username: " & username)

        ' Pass position parameter to RegisterStaff function
        If DatabaseConnection.RegisterStaff(firstName, lastName, email, contactNumber, address, departmentID, username, password, position) Then
            MessageBox.Show("Registration successful! You can now login with your new account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Dim staffLogin As New StaffLogin()
                staffLogin.Show()
            End If
            Me.Close()

    End Sub

    ' Cancel button click
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Dim loginForm As New StaffLogin()
        loginForm.Show()
        Me.Close()
    End Sub

    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        Dim StaffForm As New StaffLogin()
        StaffLogin.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txb_ContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txb_ContactNumber.TextChanged

    End Sub

    Private Sub txb_Address_TextChanged(sender As Object, e As EventArgs) Handles txb_HouseNoStreet.TextChanged

    End Sub

    Private Sub txb_Password_TextChanged(sender As Object, e As EventArgs) Handles pa.TextChanged

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Position.SelectedIndexChanged

    End Sub

    Private Sub cb_Barangay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Barangay.SelectedIndexChanged

    End Sub

    Private Sub cb_Municipality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Municipality.SelectedIndexChanged

    End Sub

    Private Sub cb_Province_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Province.SelectedIndexChanged

    End Sub

    Private Sub txb_EmployeeID_TextChanged(sender As Object, e As EventArgs) Handles txb_EmployeeID.TextChanged

    End Sub

    Private Sub txb_UserName_TextChanged(sender As Object, e As EventArgs) Handles txb_UserName.TextChanged

    End Sub

    Private Sub txb_Email_TextChanged(sender As Object, e As EventArgs) Handles txb_Email.TextChanged

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub txb_DepartmentID_TextChanged(sender As Object, e As EventArgs) Handles txb_DepartmentID.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub txb_Suffix_TextChanged(sender As Object, e As EventArgs) Handles txb_Suffix.TextChanged

    End Sub

    Private Sub txb_LastName_TextChanged(sender As Object, e As EventArgs) Handles txb_LastName.TextChanged

    End Sub

    Private Sub txb_MiddleName_TextChanged(sender As Object, e As EventArgs) Handles txb_MiddleName.TextChanged

    End Sub

    Private Sub txb_FirstName_TextChanged(sender As Object, e As EventArgs) Handles txb_FirstName.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
