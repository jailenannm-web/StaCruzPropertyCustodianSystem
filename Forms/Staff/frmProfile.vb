Imports StaCruzPropertyCustodianSystem.Resources.Controls



Public Class frmProfile
    Inherits System.Windows.Forms.Form

    Private txtFullName As TextBox
    Private txtContact As TextBox
    Private txtEmail As TextBox

    Private Sub frmProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtbxName_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Make all textboxes writable
        txtFullName.ReadOnly = False
        txtContact.ReadOnly = False
        txtEmail.ReadOnly = False

        ' Enable ComboBoxes
        comboPosition.Enabled = True
        comboAssigned.Enabled = True

        txtFullName.Focus()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' --- 1. Add SQL UPDATE logic here later ---

        ' --- 2. Lock inputs again ---
        txtFullName.ReadOnly = True
        txtContact.ReadOnly = True
        txtEmail.ReadOnly = True
        comboPosition.Enabled = False
        comboAssigned.Enabled = False

        MsgBox("Profile updated successfully!")
    End Sub

    Private Sub comboAssigned_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAssigned.SelectedIndexChanged

    End Sub
End Class
