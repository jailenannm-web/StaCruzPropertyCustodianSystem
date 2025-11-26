Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports StaCruzPropertyCustodianSystem.Resources.Controls
Public Class AddUserManagement
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    ' Load user data into the fields
    Public Sub LoadUserData(userID As String,
                        firstName As String,
                        middleName As String,
                        lastName As String,
                        suffixValue As String,
                        position As String,
                        departmentID As String,
                        employeeID As String,
                        contactNumber As String,
                        email As String,
                        userRole As String,
                        provinceValue As String,
                        municipalityValue As String,
                        barangayValue As String,
                        houseNumber As String,
                        password As String,
                        dateRegistered As Date,
                        statusValue As String)

        ' Textboxes
        Me.userID.Text = userID
        Me.firstName.Text = firstName
        Me.middleName.Text = middleName
        Me.lastName.Text = lastName
        Me.departmentID.Text = departmentID
        Me.employeeID.Text = employeeID
        Me.contactNumber.Text = contactNumber
        Me.email.Text = email
        Me.houseNumber.Text = houseNumber
        Me.password.Text = password

        ' ComboBoxes / Dropdowns
        suffixAdmin.SelectedItem = suffixValue
        positionAdmin.SelectedItem = position
        ComboBox1.SelectedItem = userRole
        Me.province.SelectedItem = provinceValue
        Me.municipality.SelectedItem = municipalityValue
        Me.barangay.SelectedItem = barangayValue
        statusAdmin.SelectedItem = statusValue

        ' DatePicker
        Me.dateRegistered.Value = dateRegistered

    End Sub


    ' Save button
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles um_edituser_save.Click
        MessageBox.Show("Saved changes for: " & lastName.Text)
        ' Add actual save logic here
    End Sub

    ' Back button
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles um_edituser_backbtn.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_UserManagement())
        End If
    End Sub

    Private Sub userID_TextChanged(sender As Object, e As EventArgs) Handles userID.TextChanged

    End Sub

    Private Sub firstName_TextChanged(sender As Object, e As EventArgs) Handles firstName.TextChanged

    End Sub

    Private Sub middleName_TextChanged(sender As Object, e As EventArgs) Handles middleName.TextChanged

    End Sub

    Private Sub lastName_TextChanged(sender As Object, e As EventArgs) Handles lastName.TextChanged

    End Sub

    Private Sub suffixAdmin_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub positionAdmin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles positionAdmin.SelectedIndexChanged

    End Sub

    Private Sub departmentID_TextChanged(sender As Object, e As EventArgs) Handles departmentID.TextChanged

    End Sub

    Private Sub employeeID_TextChanged(sender As Object, e As EventArgs) Handles employeeID.TextChanged

    End Sub

    Private Sub contactNumber_TextChanged(sender As Object, e As EventArgs) Handles contactNumber.TextChanged

    End Sub

    Private Sub email_TextChanged(sender As Object, e As EventArgs) Handles email.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub province_SelectedIndexChanged(sender As Object, e As EventArgs) Handles province.SelectedIndexChanged

    End Sub

    Private Sub municipality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles municipality.SelectedIndexChanged

    End Sub

    Private Sub barangay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles barangay.SelectedIndexChanged

    End Sub

    Private Sub houseNumber_TextChanged(sender As Object, e As EventArgs) Handles houseNumber.TextChanged

    End Sub

    Private Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged

    End Sub

    Private Sub dateRegistered_ValueChanged(sender As Object, e As EventArgs) Handles dateRegistered.ValueChanged

    End Sub

    Private Sub status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles statusAdmin.SelectedIndexChanged

    End Sub
End Class
