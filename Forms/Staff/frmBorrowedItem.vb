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
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Try
                        ' Column order in designer: borrowedId, requestID, itemType, itemId, borrowerName, borrowerPosition, departmentId, borrowDate, expectedReturnDate, actualReturnDate, conditionOnReturn, status, remarks
                        Dim borrowedId As String = ""
                        Dim requestIDVal As String = ""
                        Dim itemType As String = ""
                        Dim itemId As String = ""
                        Dim borrowerName As String = ""
                        Dim borrowerPosition As String = ""
                        Dim departmentId As String = ""
                        Dim borrowDate As String = ""
                        Dim expectedReturn As String = ""
                        Dim actualReturn As String = ""
                        Dim conditionReturn As String = ""
                        Dim statusVal As String = ""
                        Dim remarks As String = ""
                        
                        ' Safely access columns - get borrowId first
                        If row.Table.Columns.Contains("borrowId") AndAlso Not IsDBNull(row("borrowId")) Then
                            borrowedId = row("borrowId").ToString()
                        End If
                        If row.Table.Columns.Contains("request_id") AndAlso Not IsDBNull(row("request_id")) Then
                            requestIDVal = row("request_id").ToString()
                        End If
                        If row.Table.Columns.Contains("request_type") AndAlso Not IsDBNull(row("request_type")) Then
                            itemType = row("request_type").ToString()
                        End If
                        If row.Table.Columns.Contains("item_name") AndAlso Not IsDBNull(row("item_name")) Then
                            itemId = row("item_name").ToString()
                        ElseIf row.Table.Columns.Contains("serial_number") AndAlso Not IsDBNull(row("serial_number")) Then
                            itemId = row("serial_number").ToString()
                        End If
                        If row.Table.Columns.Contains("borrowerName") AndAlso Not IsDBNull(row("borrowerName")) Then
                            borrowerName = row("borrowerName").ToString()
                        End If
                        If row.Table.Columns.Contains("borrowerPosition") AndAlso Not IsDBNull(row("borrowerPosition")) Then
                            borrowerPosition = row("borrowerPosition").ToString()
                        End If
                        If row.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(row("departmentId")) Then
                            departmentId = row("departmentId").ToString()
                        End If
                        If row.Table.Columns.Contains("request_date") AndAlso Not IsDBNull(row("request_date")) Then
                            Try
                                borrowDate = Convert.ToDateTime(row("request_date")).ToString("MM/dd/yyyy")
                            Catch
                                borrowDate = row("request_date").ToString()
                            End Try
                        End If
                        If row.Table.Columns.Contains("expected_return_date") AndAlso Not IsDBNull(row("expected_return_date")) Then
                            Try
                                expectedReturn = Convert.ToDateTime(row("expected_return_date")).ToString("MM/dd/yyyy")
                            Catch
                            End Try
                        End If
                        If row.Table.Columns.Contains("actual_returned_date") AndAlso Not IsDBNull(row("actual_returned_date")) Then
                            Try
                                actualReturn = Convert.ToDateTime(row("actual_returned_date")).ToString("MM/dd/yyyy")
                            Catch
                            End Try
                        End If
                        If row.Table.Columns.Contains("condition_upon_return") AndAlso Not IsDBNull(row("condition_upon_return")) Then
                            conditionReturn = row("condition_upon_return").ToString()
                        End If
                        If row.Table.Columns.Contains("accountability_status") AndAlso Not IsDBNull(row("accountability_status")) Then
                            statusVal = row("accountability_status").ToString()
                        ElseIf row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")) Then
                            statusVal = row("status").ToString()
                        End If
                        If row.Table.Columns.Contains("remarks") AndAlso Not IsDBNull(row("remarks")) Then
                            remarks = row("remarks").ToString()
                        End If
                        
                        DataGridView1.Rows.Add(borrowedId, requestIDVal, itemType, itemId, borrowerName, borrowerPosition, departmentId, borrowDate, expectedReturn, actualReturn, conditionReturn, statusVal, remarks)
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