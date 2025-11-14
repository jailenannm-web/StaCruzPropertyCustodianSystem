Imports System
Imports System.Configuration
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class frmConfig
    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        Try
            ' Get connection string from App.config
            Dim connStr As String = ConfigurationManager.ConnectionStrings("MySQLConnection").ConnectionString

            ' Try to open the connection
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                MessageBox.Show("Connected to teamcruzim successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

        Catch ex As Exception
            MessageBox.Show("❌ Connection Failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
