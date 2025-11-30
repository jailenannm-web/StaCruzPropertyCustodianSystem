Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class frmBorrowedItem
    Private Sub frmBorrowedItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBorrowedItems()
    End Sub

    Private Sub LoadBorrowedItems()
        Try
            ' Check session and try to restore if needed
            If Not SessionContext.CurrentUserID.HasValue OrElse SessionContext.CurrentUserID.Value <= 0 Then
                MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Load borrowed items for the current staff member (approved/released requests)
            Dim dt As DataTable = DatabaseConnection.GetStaffBorrowedItems(SessionContext.CurrentUserID.Value, False)
            
            ' Clear existing data
            DataGridView1.Rows.Clear()
            
            ' Populate DataGridView
            For Each row As DataRow In dt.Rows
                Dim requestID As String = If(IsDBNull(row("request_id")), "", row("request_id").ToString())
                Dim propertyNo As String = If(IsDBNull(row("serial_number")), "", row("serial_number").ToString())
                Dim itemName As String = If(IsDBNull(row("item_name")), "", row("item_name").ToString())
                Dim requestType As String = If(IsDBNull(row("request_type")), "", row("request_type").ToString())
                Dim borrowDate As String = If(IsDBNull(row("request_date")), "", Convert.ToDateTime(row("request_date")).ToString("yyyy-MM-dd"))
                Dim expectedReturn As String = If(IsDBNull(row("expected_return_date")), "", If(IsDBNull(row("expected_return_date")), "", Convert.ToDateTime(row("expected_return_date")).ToString("yyyy-MM-dd")))
                Dim status As String = If(IsDBNull(row("accountability_status")), "", row("accountability_status").ToString())
                Dim actualReturn As String = If(IsDBNull(row("actual_returned_date")), "", If(IsDBNull(row("actual_returned_date")), "", Convert.ToDateTime(row("actual_returned_date")).ToString("yyyy-MM-dd")))
                Dim conditionReturn As String = If(IsDBNull(row("condition_upon_return")), "", row("condition_upon_return").ToString())
                Dim quantity As String = If(IsDBNull(row("quantity")), "1", row("quantity").ToString())
                
                DataGridView1.Rows.Add(requestID, propertyNo, itemName, requestType, quantity, borrowDate, expectedReturn, status, "", actualReturn, conditionReturn)
            Next
            
            ' Auto-size columns
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            MessageBox.Show("Error loading borrowed items: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pnlSidebar_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class