Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic

''' <summary>
''' My Borrowed Items UserControl - Shows approved property/supply requests
''' Allows staff to request maintenance for items needing repair
''' </summary>
Public Class frmBorrowedItem
    Inherits System.Windows.Forms.UserControl
    
    Private currentUserId As Integer = 0
    
    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub
    
    Private Sub frmBorrowedItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Get current user ID from session
        If SessionContext.CurrentUserID.HasValue Then
            currentUserId = SessionContext.CurrentUserID.Value
        Else
            MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        ' Initialize form
        InitializeForm()
        LoadApprovedRequests()
    End Sub
    
    Private Sub InitializeForm()
        ' Set up DataGridView appearance
        With dgvBorrowedItems
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .EnableHeadersVisualStyles = False
            
            ' Header styling
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Padding = New Padding(5)
            .ColumnHeadersHeight = 40
            
            ' Row styling
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .RowTemplate.Height = 35
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250)
        End With
        
        ' Initialize filter combo boxes
        cboFilterStatus.Items.AddRange(New String() {"All", "Approved", "Good Condition", "Needs Repair", "Damaged"})
        cboFilterStatus.SelectedIndex = 0
        
        cboFilterType.Items.AddRange(New String() {"All", "Property", "Supply"})
        cboFilterType.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Load borrowed items from borrowed_items table (actual items staff has borrowed)
    ''' </summary>
    Private Sub LoadApprovedRequests()
        Try
            dgvBorrowedItems.Rows.Clear()

            ' Get user's name to match borrowerName in borrowed_items table
            Dim userName As String = SessionContext.CurrentFullName

            ' Load borrowed properties
            Dim dtBorrowedItems As DataTable = GetBorrowedItemsFromDatabase()
            If dtBorrowedItems IsNot Nothing Then
                For Each row As DataRow In dtBorrowedItems.Rows
                    AddBorrowedItemRowToGrid(row)
                Next
            End If

            ' Update counters
            UpdateItemCounts()

            ' Show message if no items
            If dgvBorrowedItems.Rows.Count = 0 Then
                lblNoItems.Visible = True
            Else
                lblNoItems.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading borrowed items: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Get borrowed items from borrowed_items table joined with properties/supplies
    ''' </summary>
    Private Function GetBorrowedItemsFromDatabase() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing

        Try
            conn = DatabaseConnection.GetConnection()
            If conn Is Nothing Then Return dt
            If Not DatabaseConnection.SafeOpenConnection(conn) Then Return dt

            ' Get borrowed items from borrowed_items table with property/supply details
            ' FILTER OUT RETURNED ITEMS - only show currently borrowed items
            Dim query As String = "SELECT " &
                                 "bi.borrowId, bi.requestId, bi.itemType, bi.itemId, " &
                                 "bi.borrowDate, bi.expectedReturnDate, bi.status AS borrowStatus, bi.remarks, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.itemName " &
                                 "  WHEN bi.itemType = 'supply' THEN s.itemName " &
                                 "  ELSE 'Unknown' " &
                                 "END AS itemName, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.propertyNumber " &
                                 "  ELSE NULL " &
                                 "END AS propertyNumber, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.serialNumber " &
                                 "  ELSE NULL " &
                                 "END AS serialNumber, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.condition " &
                                 "  ELSE 'N/A' " &
                                 "END AS `condition`, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.description " &
                                 "  WHEN bi.itemType = 'supply' THEN s.description " &
                                 "  ELSE '' " &
                                 "END AS description, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN '1 Unit' " &
                                 "  WHEN bi.itemType = 'supply' THEN CONCAT(s.quantity, ' ', s.unitOfMeasure) " &
                                 "  ELSE '1' " &
                                 "END AS quantity, " &
                                 "bi.itemType " &
                                 "FROM borrowed_items bi " &
                                 "LEFT JOIN properties p ON bi.itemId = p.propertyId AND bi.itemType = 'property' " &
                                 "LEFT JOIN supplies s ON bi.itemId = s.supplyId AND bi.itemType = 'supply' " &
                                 "WHERE (bi.borrowerName LIKE CONCAT((SELECT firstName FROM users WHERE userId = @userId), '%') " &
                                 "   OR bi.borrowerName = (SELECT CONCAT(firstName, ' ', lastName) FROM users WHERE userId = @userId) " &
                                 "   OR bi.borrowerName = (SELECT CONCAT(firstName, ' ', middleName, ' ', lastName) FROM users WHERE userId = @userId) " &
                                 "   OR bi.borrowerName = (SELECT fullName FROM users WHERE userId = @userId)) " &
                                 "AND bi.status != 'Returned' " &
                                 "ORDER BY bi.borrowDate DESC"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userId", currentUserId)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("GetBorrowedItemsFromDatabase Exception: " & ex.Message)
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try

        Return dt
    End Function


    ''' <summary>
    ''' Add borrowed item row to grid (from borrowed_items table)
    ''' </summary>
    Private Sub AddBorrowedItemRowToGrid(row As DataRow)
        Try
            Dim borrowId As String = If(row.IsNull("borrowId"), "", row("borrowId").ToString())
            Dim itemType As String = If(row.IsNull("itemType"), "property", row("itemType").ToString())
            Dim itemName As String = If(row.IsNull("itemName"), "", row("itemName").ToString())
            Dim propertyNumber As String = If(row.IsNull("propertyNumber"), "N/A", If(String.IsNullOrEmpty(row("propertyNumber").ToString()), "N/A", row("propertyNumber").ToString()))
            Dim serialNumber As String = If(row.IsNull("serialNumber"), "N/A", If(String.IsNullOrEmpty(row("serialNumber").ToString()), "N/A", row("serialNumber").ToString()))
            Dim quantity As String = If(row.IsNull("quantity"), "1", row("quantity").ToString())
            Dim condition As String = If(row.IsNull("condition"), "N/A", row("condition").ToString())
            Dim borrowDate As String = ""

            If Not row.IsNull("borrowDate") Then
                Try
                    borrowDate = Convert.ToDateTime(row("borrowDate")).ToString("MMM dd, yyyy")
                Catch
                    borrowDate = row("borrowDate").ToString()
                End Try
            End If

            Dim borrowStatus As String = If(row.IsNull("borrowStatus"), "", row("borrowStatus").ToString())
            Dim remarks As String = If(row.IsNull("remarks"), "", row("remarks").ToString())
            Dim itemId As String = If(row.IsNull("itemId"), "", row("itemId").ToString())

            ' Allow maintenance requests for ALL borrowed items (to report condition)
            Dim canRequestMaintenance As Boolean = (itemType.ToLower() = "property") AndAlso Not String.IsNullOrEmpty(itemId)

            dgvBorrowedItems.Rows.Add(
                borrowId,
                itemType,
                itemName,
                propertyNumber,
                serialNumber,
                quantity,
                condition,
                borrowDate,
                borrowStatus,
                remarks,
                canRequestMaintenance,
                itemId
            )

            ' Color code by condition
            Dim lastRow As DataGridViewRow = dgvBorrowedItems.Rows(dgvBorrowedItems.Rows.Count - 1)
            Select Case condition
                Case "Good"
                    lastRow.DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 245)
                Case "Needs Repair"
                    lastRow.DefaultCellStyle.BackColor = Color.FromArgb(254, 243, 199)
                Case "Damaged"
                    lastRow.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226)
                Case Else
                    ' Default for supplies or N/A
                    If itemType.ToLower() = "supply" Then
                        lastRow.DefaultCellStyle.BackColor = Color.FromArgb(239, 246, 255)
                    End If
            End Select

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("AddBorrowedItemRowToGrid Exception: " & ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' Update item count labels
    ''' </summary>
    Private Sub UpdateItemCounts()
        Dim totalItems As Integer = dgvBorrowedItems.Rows.Count
        Dim propertyCount As Integer = 0
        Dim supplyCount As Integer = 0
        Dim needsRepairCount As Integer = 0

        For Each row As DataGridViewRow In dgvBorrowedItems.Rows
            If Not row.IsNewRow Then
                Dim itemType As String = If(row.Cells("colItemType").Value?.ToString(), "")
                Dim condition As String = If(row.Cells("colCondition").Value?.ToString(), "")

                If itemType = "Property" Then
                    propertyCount += 1
                ElseIf itemType = "Supply" Then
                    supplyCount += 1
                End If

                If condition = "Needs Repair" Or condition = "Damaged" Then
                    needsRepairCount += 1
                End If
            End If
        Next

        lblTotalItems.Text = $"Total Items: {totalItems}"
        lblPropertyCount.Text = $"Properties: {propertyCount}"
        lblSupplyCount.Text = $"Supplies: {supplyCount}"
        lblNeedsRepair.Text = $"Needs Attention: {needsRepairCount}"
    End Sub

    ''' <summary>
    ''' Search functionality
    ''' </summary>
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilters()
    End Sub

    ''' <summary>
    ''' Filter by status
    ''' </summary>
    Private Sub cboFilterStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterStatus.SelectedIndexChanged
        ApplyFilters()
    End Sub

    ''' <summary>
    ''' Filter by type
    ''' </summary>
    Private Sub cboFilterType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterType.SelectedIndexChanged
        ApplyFilters()
    End Sub

    ''' <summary>
    ''' Apply all filters
    ''' </summary>
    Private Sub ApplyFilters()
        Try
            Dim searchText As String = txtSearch.Text.Trim().ToLower()
            Dim filterStatus As String = If(cboFilterStatus.SelectedItem?.ToString(), "All")
            Dim filterType As String = If(cboFilterType.SelectedItem?.ToString(), "All")

            For Each row As DataGridViewRow In dgvBorrowedItems.Rows
                If row.IsNewRow Then Continue For

                Dim itemName As String = If(row.Cells("colItemName").Value?.ToString(), "").ToLower()
                Dim propertyNumber As String = If(row.Cells("colPropertyNumber").Value?.ToString(), "").ToLower()
                Dim serialNumber As String = If(row.Cells("colSerialNumber").Value?.ToString(), "").ToLower()
                Dim itemType As String = If(row.Cells("colItemType").Value?.ToString(), "")
                Dim condition As String = If(row.Cells("colCondition").Value?.ToString(), "")

                Dim matchesSearch As Boolean = String.IsNullOrEmpty(searchText) OrElse
                                              itemName.Contains(searchText) OrElse
                                              propertyNumber.Contains(searchText) OrElse
                                              serialNumber.Contains(searchText)

                Dim matchesStatus As Boolean = filterStatus = "All" OrElse
                                              (filterStatus = "Approved") OrElse
                                              (filterStatus = condition)

                Dim matchesType As Boolean = filterType = "All" OrElse
                                            (filterType = itemType)

                row.Visible = matchesSearch AndAlso matchesStatus AndAlso matchesType
            Next

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("ApplyFilters Exception: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Refresh button
    ''' </summary>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadApprovedRequests()
    End Sub

    ''' <summary>
    ''' Request maintenance for selected item
    ''' </summary>
    Private Sub btnRequestMaintenance_Click(sender As Object, e As EventArgs) Handles btnRequestMaintenance.Click
        If dgvBorrowedItems.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to request maintenance.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvBorrowedItems.SelectedRows(0)
        Dim itemType As String = If(selectedRow.Cells("colItemType").Value?.ToString(), "")

        If itemType.ToLower() <> "property" Then
            MessageBox.Show("Maintenance requests are only available for properties, not supplies.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Allow maintenance request for ALL properties (to report condition, not just repairs)

        ' Get item details
        Dim itemName As String = If(selectedRow.Cells("colItemName").Value?.ToString(), "")
        Dim propertyNumber As String = If(selectedRow.Cells("colPropertyNumber").Value?.ToString(), "N/A")
        Dim serialNumber As String = If(selectedRow.Cells("colSerialNumber").Value?.ToString(), "N/A")
        Dim itemId As String = If(selectedRow.Cells("colPropertyId").Value?.ToString(), "")

        If String.IsNullOrEmpty(itemId) Then
            MessageBox.Show("Cannot request maintenance: Item ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open maintenance request form (UserControl)
        Try
            ' Find the parent StaffDashboard
            Dim parentControl As Control = Me.Parent
            While parentControl IsNot Nothing AndAlso Not (TypeOf parentControl Is StaffDashboard)
                parentControl = parentControl.Parent
            End While

            If TypeOf parentControl Is StaffDashboard Then
                ' Create the maintenance request user control
                Dim maintenanceForm As New MaintenanceRequestForm()

                ' Try to pre-fill item details using reflection
                Try
                    Dim formType As Type = maintenanceForm.GetType()
                    Dim setItemMethod = formType.GetMethod("SetItemDetails")

                    If setItemMethod IsNot Nothing Then
                        setItemMethod.Invoke(maintenanceForm, New Object() {itemName, propertyNumber, serialNumber, itemId})
                    End If
                Catch reflectionEx As Exception
                    System.Diagnostics.Debug.WriteLine("SetItemDetails not found: " & reflectionEx.Message)
                End Try

                ' Load the maintenance form into the dashboard
                Dim dashboard As StaffDashboard = CType(parentControl, StaffDashboard)
                Dim dashboardType As Type = dashboard.GetType()
                Dim loadMethod = dashboardType.GetMethod("loadFormIntoPanel")

                If loadMethod IsNot Nothing Then
                    loadMethod.Invoke(dashboard, New Object() {maintenanceForm})
                Else
                    ' Fallback: clear panel and add control
                    Dim panel = dashboard.Controls("pnlContent")
                    If panel IsNot Nothing Then
                        panel.Controls.Clear()
                        panel.Controls.Add(maintenanceForm)
                    End If
                End If
            Else
                MessageBox.Show("Cannot find parent dashboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening maintenance request form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("MaintenanceRequestForm error: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Return borrowed item - Update return date and condition
    ''' </summary>
    Private Sub btnReturnItem_Click(sender As Object, e As EventArgs) Handles btnReturnItem.Click
        If dgvBorrowedItems.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to return.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvBorrowedItems.SelectedRows(0)
        Dim borrowId As String = If(selectedRow.Cells("colRequestId").Value?.ToString(), "")
        Dim itemName As String = If(selectedRow.Cells("colItemName").Value?.ToString(), "")
        Dim currentStatus As String = If(selectedRow.Cells("colPurpose").Value?.ToString(), "")

        ' Check if already returned
        If currentStatus.ToLower() = "returned" Then
            MessageBox.Show("This item has already been returned.", "Already Returned", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Show return dialog
        Dim result As DialogResult = MessageBox.Show(
            $"Return Item: {itemName}{Environment.NewLine}{Environment.NewLine}" &
            $"Are you sure you want to mark this item as returned?",
            "Confirm Return",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Show condition selection dialog
            Dim conditionDialog As New Form()
            conditionDialog.Text = "Item Condition on Return"
            conditionDialog.Size = New Size(500, 250)
            conditionDialog.StartPosition = FormStartPosition.CenterParent
            conditionDialog.FormBorderStyle = FormBorderStyle.FixedDialog
            conditionDialog.MaximizeBox = False
            conditionDialog.MinimizeBox = False

            Dim lblQuestion As New Label()
            lblQuestion.Text = $"What is the condition of '{itemName}' on return?"
            lblQuestion.Location = New Point(20, 20)
            lblQuestion.Size = New Size(440, 40)
            lblQuestion.Font = New Font("Segoe UI", 10, FontStyle.Bold)

            Dim rbGood As New RadioButton()
            rbGood.Text = "✓ Good - Item is in good condition"
            rbGood.Location = New Point(40, 70)
            rbGood.Size = New Size(400, 25)
            rbGood.Checked = True

            Dim rbNeedsRepair As New RadioButton()
            rbNeedsRepair.Text = "⚠ Needs Repair - Item has minor issues"
            rbNeedsRepair.Location = New Point(40, 100)
            rbNeedsRepair.Size = New Size(400, 25)

            Dim rbDamaged As New RadioButton()
            rbDamaged.Text = "✗ Damaged - Item is significantly damaged"
            rbDamaged.Location = New Point(40, 130)
            rbDamaged.Size = New Size(400, 25)

            Dim btnOK As New Button()
            btnOK.Text = "Confirm Return"
            btnOK.Location = New Point(280, 170)
            btnOK.Size = New Size(120, 35)
            btnOK.DialogResult = DialogResult.OK

            Dim btnCancel As New Button()
            btnCancel.Text = "Cancel"
            btnCancel.Location = New Point(150, 170)
            btnCancel.Size = New Size(120, 35)
            btnCancel.DialogResult = DialogResult.Cancel

            conditionDialog.Controls.AddRange(New Control() {lblQuestion, rbGood, rbNeedsRepair, rbDamaged, btnOK, btnCancel})
            conditionDialog.AcceptButton = btnOK
            conditionDialog.CancelButton = btnCancel

            If conditionDialog.ShowDialog() = DialogResult.OK Then
                ' Determine condition
                Dim condition As String = "Good"
                If rbNeedsRepair.Checked Then
                    condition = "Needs Repair"
                ElseIf rbDamaged.Checked Then
                    condition = "Damaged"
                End If

                ' Update borrowed_items table
                If UpdateBorrowedItemReturn(borrowId, condition) Then
                    MessageBox.Show($"Item returned successfully!{Environment.NewLine}Condition: {condition}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadApprovedRequests() ' Refresh the grid
                Else
                    MessageBox.Show("Failed to update return information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Update borrowed_items table with return date and condition
    ''' Also updates the property's condition and clears assignedTo
    ''' </summary>
    Private Function UpdateBorrowedItemReturn(borrowId As String, condition As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Dim transaction As MySqlTransaction = Nothing
        
        Try
            conn = DatabaseConnection.GetConnection()
            If conn Is Nothing Then Return False
            If Not DatabaseConnection.SafeOpenConnection(conn) Then Return False

            ' Start transaction to ensure both updates succeed or fail together
            transaction = conn.BeginTransaction()

            ' First, get the item details from borrowed_items
            Dim itemId As Integer = 0
            Dim itemType As String = ""
            
            Dim selectQuery As String = "SELECT itemId, itemType FROM borrowed_items WHERE borrowId = @borrowId"
            Using selectCmd As New MySqlCommand(selectQuery, conn, transaction)
                selectCmd.Parameters.AddWithValue("@borrowId", borrowId)
                Using reader As MySqlDataReader = selectCmd.ExecuteReader()
                    If reader.Read() Then
                        itemId = Convert.ToInt32(reader("itemId"))
                        itemType = reader("itemType").ToString()
                    End If
                End Using
            End Using

            ' Update borrowed_items table
            Dim updateBorrowedQuery As String = "UPDATE borrowed_items SET " &
                                 "actualReturnDate = CURDATE(), " &
                                 "conditionOnReturn = @condition, " &
                                 "status = 'Returned', " &
                                 "updatedAt = NOW() " &
                                 "WHERE borrowId = @borrowId"

            Using cmd As New MySqlCommand(updateBorrowedQuery, conn, transaction)
                cmd.Parameters.AddWithValue("@borrowId", borrowId)
                cmd.Parameters.AddWithValue("@condition", condition)
                cmd.ExecuteNonQuery()
            End Using

            ' If it's a property, update the properties table
            If itemType.ToLower() = "property" AndAlso itemId > 0 Then
                ' Update property condition and clear assignedTo
                Dim updatePropertyQuery As String = "UPDATE properties SET " &
                                     "`condition` = @condition, " &
                                     "assignedTo = NULL, " &
                                     "status = 'Active', " &
                                     "updatedAt = NOW() " &
                                     "WHERE propertyId = @propertyId"

                Using propCmd As New MySqlCommand(updatePropertyQuery, conn, transaction)
                    propCmd.Parameters.AddWithValue("@condition", condition)
                    propCmd.Parameters.AddWithValue("@propertyId", itemId)
                    propCmd.ExecuteNonQuery()
                End Using
                
                System.Diagnostics.Debug.WriteLine($"[v0] Property {itemId} returned - assignedTo cleared, condition set to {condition}")
            End If

            ' Commit transaction
            transaction.Commit()
            System.Diagnostics.Debug.WriteLine($"[v0] Item return completed successfully - borrowId: {borrowId}")
            Return True

        Catch ex As Exception
            ' Rollback on error
            If transaction IsNot Nothing Then
                Try
                    transaction.Rollback()
                    System.Diagnostics.Debug.WriteLine("[v0] Transaction rolled back due to error")
                Catch rollbackEx As Exception
                    System.Diagnostics.Debug.WriteLine("[v0] Rollback error: " & rollbackEx.Message)
                End Try
            End If
            
            System.Diagnostics.Debug.WriteLine("UpdateBorrowedItemReturn Exception: " & ex.Message)
            MessageBox.Show("Error updating return information: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If transaction IsNot Nothing Then
                transaction.Dispose()
            End If
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' View item details
    ''' </summary>
    Private Sub dgvBorrowedItems_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBorrowedItems.CellDoubleClick
        If e.RowIndex < 0 Then Return
        
        Dim row As DataGridViewRow = dgvBorrowedItems.Rows(e.RowIndex)
        Dim itemName As String = If(row.Cells("colItemName").Value?.ToString(), "")
        Dim itemType As String = If(row.Cells("colItemType").Value?.ToString(), "")
        Dim quantity As String = If(row.Cells("colQuantity").Value?.ToString(), "")
        Dim condition As String = If(row.Cells("colCondition").Value?.ToString(), "")
        Dim approvedDate As String = If(row.Cells("colApprovedDate").Value?.ToString(), "")
        Dim purpose As String = If(row.Cells("colPurpose").Value?.ToString(), "")
        Dim remarks As String = If(row.Cells("colRemarks").Value?.ToString(), "")
        
        Dim details As String = $"Item Details:{Environment.NewLine}{Environment.NewLine}" &
                               $"Item Name: {itemName}{Environment.NewLine}" &
                               $"Type: {itemType}{Environment.NewLine}" &
                               $"Quantity: {quantity}{Environment.NewLine}" &
                               $"Condition: {condition}{Environment.NewLine}" &
                               $"Approved Date: {approvedDate}{Environment.NewLine}" &
                               $"Purpose: {purpose}{Environment.NewLine}" &
                               $"Remarks: {remarks}"
        
        MessageBox.Show(details, "Item Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub lblNoItems_Click(sender As Object, e As EventArgs) Handles lblNoItems.Click

    End Sub
End Class
