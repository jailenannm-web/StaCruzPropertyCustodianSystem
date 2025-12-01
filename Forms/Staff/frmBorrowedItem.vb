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
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Try
                        Dim requestID As String = ""
                        Dim propertyNo As String = ""
                        Dim itemName As String = ""
                        Dim requestType As String = ""
                        Dim borrowDate As String = ""
                        Dim expectedReturn As String = ""
                        Dim status As String = ""
                        Dim actualReturn As String = ""
                        Dim conditionReturn As String = ""
                        Dim quantity As String = "1"
                        
                        ' Safely access columns
                        If dt.Columns.Contains("request_id") AndAlso Not IsDBNull(row("request_id")) Then
                            requestID = row("request_id").ToString()
                        End If
                        If dt.Columns.Contains("serial_number") AndAlso Not IsDBNull(row("serial_number")) Then
                            propertyNo = row("serial_number").ToString()
                        End If
                        If dt.Columns.Contains("item_name") AndAlso Not IsDBNull(row("item_name")) Then
                            itemName = row("item_name").ToString()
                        End If
                        If dt.Columns.Contains("request_type") AndAlso Not IsDBNull(row("request_type")) Then
                            requestType = row("request_type").ToString()
                        End If
                        If dt.Columns.Contains("request_date") AndAlso Not IsDBNull(row("request_date")) Then
                            borrowDate = Convert.ToDateTime(row("request_date")).ToString("yyyy-MM-dd")
                        End If
                        If dt.Columns.Contains("expected_return_date") AndAlso Not IsDBNull(row("expected_return_date")) Then
                            expectedReturn = Convert.ToDateTime(row("expected_return_date")).ToString("yyyy-MM-dd")
                        End If
                        If dt.Columns.Contains("accountability_status") AndAlso Not IsDBNull(row("accountability_status")) Then
                            status = row("accountability_status").ToString()
                        End If
                        If dt.Columns.Contains("actual_returned_date") AndAlso Not IsDBNull(row("actual_returned_date")) Then
                            actualReturn = Convert.ToDateTime(row("actual_returned_date")).ToString("yyyy-MM-dd")
                        End If
                        If dt.Columns.Contains("condition_upon_return") AndAlso Not IsDBNull(row("condition_upon_return")) Then
                            conditionReturn = row("condition_upon_return").ToString()
                        End If
                        If dt.Columns.Contains("quantity") AndAlso Not IsDBNull(row("quantity")) Then
                            quantity = row("quantity").ToString()
                        End If
                        
                        DataGridView1.Rows.Add(requestID, propertyNo, itemName, requestType, quantity, borrowDate, expectedReturn, status, "", actualReturn, conditionReturn)
                    Catch rowEx As Exception
                        System.Diagnostics.Debug.WriteLine("Error processing row in frmBorrowedItem: " & rowEx.Message)
                    End Try
                Next
            End If
            
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