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
            For Each row As DataRow In dt.Rows
                Dim requestID As String = If(IsDBNull(row("request_id")), "", row("request_id").ToString())
                Dim requestDate As String = If(IsDBNull(row("request_date")), "", Convert.ToDateTime(row("request_date")).ToString("yyyy-MM-dd"))
                Dim itemName As String = If(IsDBNull(row("item_name")), "", row("item_name").ToString())
                Dim requestType As String = If(IsDBNull(row("request_type")), "", row("request_type").ToString())
                Dim quantity As String = If(IsDBNull(row("quantity")), "1", row("quantity").ToString())
                Dim status As String = If(IsDBNull(row("status")), "", row("status").ToString())
                Dim approvedBy As String = If(IsDBNull(row("approval_date")), "", Convert.ToDateTime(row("approval_date")).ToString("yyyy-MM-dd"))
                Dim releaseDate As String = If(IsDBNull(row("release_date")), "", If(IsDBNull(row("release_date")), "", Convert.ToDateTime(row("release_date")).ToString("yyyy-MM-dd")))
                Dim returnDate As String = If(IsDBNull(row("expected_return_date")), "", If(IsDBNull(row("expected_return_date")), "", Convert.ToDateTime(row("expected_return_date")).ToString("yyyy-MM-dd")))
                
                DataGridView1.Rows.Add(requestID, requestDate, itemName, requestType, quantity, status, approvedBy, releaseDate, returnDate)
            Next
            
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

End Class