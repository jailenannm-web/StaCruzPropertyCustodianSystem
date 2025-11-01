Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class frmProfile
    Private txtFullName As Object
    Private txtContact As Object
    Private txtEmail As Object

    Private Sub frmProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtbxName_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Make all textboxes writable
        txtFullName.ReadOnly = False
        txtContact.ReadOnly = False
        txtEmail.ReadOnly = False

        ' Use .Enabled = True for ComboBoxes
        comboPosition.Enabled = True
        comboAssigned.Enabled = True
        ' (Add any other comboboxes here, like comboAssigned)
        ' comboAssigned.Enabled = True 

        ' Focus the first box
        txtFullName.Focus()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' --- 1. Add your SQL UPDATE code here ---
        ' (Save the data from txtFullName.Text, comboPosition.Text, etc.)

        ' --- 2. Make them ReadOnly/Disabled again after saving ---
        txtFullName.ReadOnly = True
        txtContact.ReadOnly = True
        txtEmail.ReadOnly = True

        ' Use .Enabled = False to lock ComboBoxes
        comboPosition.Enabled = False
        comboAssigned.Enabled = False

        MsgBox("Profile updated successfully!")
    End Sub

    Private Sub comboAssigned_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAssigned.SelectedIndexChanged

    End Sub
End Class