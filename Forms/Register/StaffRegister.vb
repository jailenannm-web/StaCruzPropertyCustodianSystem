Imports System
Imports System.Windows.Forms

Public Class StaffRegister

    ' Register button click
    Private Sub btn_Register_Click(sender As Object, e As EventArgs) Handles btn_Register.Click
        ' TODO: Add your registration logic (e.g., save user to file/database)

        MessageBox.Show("Registration successful!")

        ' After registration, go back to StaffLogin
        Dim loginForm As New StaffLogin()
        loginForm.Show()
        Me.Close()
    End Sub

    ' Cancel button click
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Dim loginForm As New StaffLogin()
        loginForm.Show()
        Me.Close()
    End Sub

    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        Dim loginForm As New Login()
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txb_ContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txb_LastName.TextChanged

    End Sub

    Private Sub txb_Address_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txb_Password_TextChanged(sender As Object, e As EventArgs) Handles txb_DepartmentID.TextChanged

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles pa.TextChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles txb_ContactNumber.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txb_HouseNoStreet.TextChanged

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Barangay.SelectedIndexChanged

    End Sub
End Class
