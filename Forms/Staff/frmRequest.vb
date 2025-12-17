Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class frmRequest
    Private Sub frmRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMyRequests()
    End Sub

    Private Sub LoadMyRequests()
        Try
            ' Check session and try to restore if needed
            If Not SessionContext.CurrentUserID.HasValue OrElse SessionContext.CurrentUserID.Value <= 0 Then
                ' Try to get user ID from settings or redirect to login
                MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Load all requests for the current staff member
            Dim dt As DataTable = DatabaseConnection.GetStaffRequests(SessionContext.CurrentUserID.Value)
            
            ' Clear existing data
            DataGridView1.Rows.Clear()
            
            ' Populate DataGridView
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Try
                        Dim requestID As String = ""
                        Dim requestDate As String = ""
                        Dim itemName As String = ""
                        Dim requestType As String = ""
                        Dim quantity As String = "1"
                        Dim status As String = ""
                        Dim approvedBy As String = ""
                        Dim releaseDate As String = ""
                        Dim returnDate As String = ""
                        
                        ' Safely access columns
                        If dt.Columns.Contains("request_id") AndAlso Not IsDBNull(row("request_id")) Then
                            requestID = row("request_id").ToString()
                        End If
                        If dt.Columns.Contains("request_date") AndAlso Not IsDBNull(row("request_date")) Then
                            requestDate = Convert.ToDateTime(row("request_date")).ToString("yyyy-MM-dd")
                        End If
                        If dt.Columns.Contains("item_name") AndAlso Not IsDBNull(row("item_name")) Then
                            itemName = row("item_name").ToString()
                        End If
                        If dt.Columns.Contains("request_type") AndAlso Not IsDBNull(row("request_type")) Then
                            requestType = row("request_type").ToString()
                        End If
                        If dt.Columns.Contains("quantity") AndAlso Not IsDBNull(row("quantity")) Then
                            quantity = row("quantity").ToString()
                        End If
                        If dt.Columns.Contains("status") AndAlso Not IsDBNull(row("status")) Then
                            status = row("status").ToString()
                        End If
                        If dt.Columns.Contains("approval_date") AndAlso Not IsDBNull(row("approval_date")) Then
                            approvedBy = Convert.ToDateTime(row("approval_date")).ToString("yyyy-MM-dd")
                        End If
                        If dt.Columns.Contains("release_date") AndAlso Not IsDBNull(row("release_date")) Then
                            releaseDate = Convert.ToDateTime(row("release_date")).ToString("yyyy-MM-dd")
                        End If
                        If dt.Columns.Contains("expected_return_date") AndAlso Not IsDBNull(row("expected_return_date")) Then
                            returnDate = Convert.ToDateTime(row("expected_return_date")).ToString("yyyy-MM-dd")
                        End If
                        
                        DataGridView1.Rows.Add(requestID, requestDate, itemName, requestType, quantity, status, approvedBy, releaseDate, returnDate)
                    Catch rowEx As Exception
                        System.Diagnostics.Debug.WriteLine("Error processing row in frmRequest: " & rowEx.Message)
                    End Try
                Next
            End If
            
            ' Auto-size columns
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            MessageBox.Show("Error loading requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lblRequest_Click(sender As Object, e As EventArgs) Handles lblRequest.Click

    End Sub

    Private Sub btn_AddRequest_Click(sender As Object, e As EventArgs) 

        Dim addUserForm As New frmPropertyRequest()

        addUserForm.ShowDialog()
        
        ' Refresh data after adding request
        LoadMyRequests()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class