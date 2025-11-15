Imports System
Imports System.Configuration
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class frmConfig
    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        Try
            ' Use DatabaseConnection.GetConnection() to ensure proper connection string handling
            ' This fixes compatibility issues with MySql.Data 8.0.33
            Using conn As MySqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                MessageBox.Show("Connected to teamcruzim successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

        Catch ex As Exception
            MessageBox.Show("❌ Connection Failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
