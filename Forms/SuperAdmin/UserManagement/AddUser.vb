Imports System
Imports System.Windows.Forms

Public Class AddUser
    Inherits Form
    
    Private Sub AddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize form
    End Sub
    
    ' Handle form closing to return to User Management
    Private Sub AddUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' If opened from SADashboard, reload User Management
        Try
            Dim saDashboard As SADashboard = Nothing
            
            ' Try to find SADashboard in open forms
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is SADashboard Then
                    saDashboard = CType(frm, SADashboard)
                    Exit For
                End If
            Next
            
            If saDashboard IsNot Nothing Then
                ' Load User Management back into dashboard
                Dim userMgmt As New UC_UserManagement()
                saDashboard.LoadUserControl(userMgmt)
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[AddUser] FormClosing Error: " & ex.Message)
        End Try
    End Sub
    
    ' If there's a Back button in the designer, handle it here
    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        ' Close the form - FormClosing event will handle the rest
        Me.Close()
    End Sub
End Class