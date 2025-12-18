Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class frmRequest
    Private originalRequestData As DataTable
    Private isSearching As Boolean = False

    Private Sub frmRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFilters()
        LoadMyRequests()
        AddHandler myrequestssearchbar.TextChanged, AddressOf RequestSearch_TextChanged
    End Sub

    Private Sub InitializeFilters()
        ' Initialize status filter
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"Pending", "Approved", "Rejected", "Borrowed", "Returned"})
        pm_cbobx_status.SelectedIndex = 0
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed

        ' Initialize category filter (request type)
        pm_cbobx_categ.Items.Clear()
        pm_cbobx_categ.Items.Add("All Types")
        pm_cbobx_categ.Items.AddRange(New String() {"property", "supply"})
        pm_cbobx_categ.SelectedIndex = 0
        AddHandler pm_cbobx_categ.SelectedIndexChanged, AddressOf Filter_Changed
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        If Not isSearching Then
            ApplyRequestSearch(myrequestssearchbar.Text)
        End If
    End Sub

    Private Sub RequestSearch_TextChanged(sender As Object, e As EventArgs)
        ApplyRequestSearch(myrequestssearchbar.Text)
    End Sub

    Private Sub ApplyRequestSearch(searchText As String)
        If originalRequestData Is Nothing OrElse originalRequestData.Rows.Count = 0 Then Return
        If isSearching Then Return
        isSearching = True

        Try
            Dim searchLower As String = If(String.IsNullOrWhiteSpace(searchText), String.Empty, searchText.Trim().ToLower())
            Dim statusFilterValue As String = If(pm_cbobx_status.SelectedIndex > 0, pm_cbobx_status.SelectedItem.ToString(), String.Empty)
            Dim categoryFilterValue As String = If(pm_cbobx_categ.SelectedIndex > 0, pm_cbobx_categ.SelectedItem.ToString(), String.Empty)

            ' Produce a DataRow() array so For Each can iterate without type resolution issues.
            Dim filteredRows() As DataRow = originalRequestData.AsEnumerable().Where(Function(row)
                                                                                         ' Apply status filter
                                                                                         If Not String.IsNullOrEmpty(statusFilterValue) Then
                                                                                             Dim rowStatus As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), String.Empty)
                                                                                             If Not rowStatus.Equals(statusFilterValue, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                                         End If

                                                                                         ' Apply category/type filter
                                                                                         If Not String.IsNullOrEmpty(categoryFilterValue) Then
                                                                                             Dim requestType As String = If(row.Table.Columns.Contains("request_type") AndAlso Not IsDBNull(row("request_type")), row("request_type").ToString(), String.Empty)
                                                                                             If Not requestType.Equals(categoryFilterValue, StringComparison.OrdinalIgnoreCase) Then Return False
                                                                                         End If

                                                                                         ' Apply search filter
                                                                                         If String.IsNullOrEmpty(searchLower) Then Return True

                                                                                         Dim itemName As String = If(row.Table.Columns.Contains("item_name") AndAlso Not IsDBNull(row("item_name")), row("item_name").ToString().ToLower(), String.Empty)
                                                                                         Dim requestID As String = If(row.Table.Columns.Contains("request_id") AndAlso Not IsDBNull(row("request_id")), row("request_id").ToString().ToLower(), String.Empty)

                                                                                         Return itemName.Contains(searchLower) OrElse requestID.Contains(searchLower)
                                                                                     End Function).ToArray()

            DataGridView1.Rows.Clear()
            For Each row As DataRow In filteredRows
                Try
                    Dim requestID As String = ""
                    Dim requesterName As String = ""
                    Dim position As String = ""
                    Dim departmentId As String = ""
                    Dim requestDate As String = ""
                    Dim itemName As String = ""
                    Dim description As String = ""
                    Dim quantity As String = "1"
                    Dim requestStatus As String = ""
                    Dim approvedBy As String = ""
                    Dim approvedDate As String = ""
                    Dim remarks As String = ""

                    If row.Table.Columns.Contains("request_id") AndAlso Not IsDBNull(row("request_id")) Then
                        requestID = row("request_id").ToString()
                    End If
                    If row.Table.Columns.Contains("request_date") AndAlso Not IsDBNull(row("request_date")) Then
                        requestDate = Convert.ToDateTime(row("request_date")).ToString("MM/dd/yyyy")
                    End If
                    If row.Table.Columns.Contains("item_name") AndAlso Not IsDBNull(row("item_name")) Then
                        itemName = row("item_name").ToString()
                    End If
                    If row.Table.Columns.Contains("quantity") AndAlso Not IsDBNull(row("quantity")) Then
                        quantity = row("quantity").ToString()
                    End If
                    If row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")) Then
                        requestStatus = row("status").ToString()
                    End If
                    If row.Table.Columns.Contains("approval_date") AndAlso Not IsDBNull(row("approval_date")) Then
                        approvedDate = Convert.ToDateTime(row("approval_date")).ToString("MM/dd/yyyy")
                    End If
                    If row.Table.Columns.Contains("remarks") AndAlso Not IsDBNull(row("remarks")) Then
                        remarks = row("remarks").ToString()
                    End If

                    ' Match the column order in the designer: requestId, requesterName, position, departmentId, dateOfRequest, itemName, description, quantityRequested, unit, purpose, status, approvedBy, approvedDate, remarks
                    ' Note: Some columns are hidden in the designer
                    DataGridView1.Rows.Add(requestID, requesterName, position, departmentId, requestDate, itemName, description, quantity, "", "", requestStatus, approvedBy, approvedDate, remarks)
                Catch rowEx As Exception
                    System.Diagnostics.Debug.WriteLine("Error processing row in frmRequest: " & rowEx.Message)
                End Try
            Next
        Catch ex As Exception
            MessageBox.Show("Error searching requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isSearching = False
        End Try
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
            originalRequestData = dt.Copy()
            
            ' Apply current filters
            ApplyRequestSearch(myrequestssearchbar.Text)
            
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