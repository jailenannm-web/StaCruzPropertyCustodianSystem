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
        
        ' Add selection changed handler to enable/disable buttons based on item type
        AddHandler dgvBorrowedItems.SelectionChanged, AddressOf dgvBorrowedItems_SelectionChanged
    End Sub
    
    ''' <summary>
    ''' Handle row selection to enable/disable buttons based on item type
    ''' Properties: All buttons enabled
    ''' Supplies: Only Return Item enabled, others disabled
    ''' </summary>
    Private Sub dgvBorrowedItems_SelectionChanged(sender As Object, e As EventArgs)
        Try
            If dgvBorrowedItems.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvBorrowedItems.SelectedRows(0)
                Dim itemType As String = If(selectedRow.Cells("colItemType").Value?.ToString(), "").ToLower()
                
                ' Enable/disable buttons based on item type
                Dim isProperty As Boolean = (itemType = "property")
                
                ' Request Maintenance - Only for properties
                If btnRequestMaintenance IsNot Nothing Then
                    btnRequestMaintenance.Enabled = isProperty
                End If
                
                ' Borrow and Return Slip - Only for properties
                If btnBorrowReturn IsNot Nothing Then
                    btnBorrowReturn.Enabled = isProperty
                End If
                
                ' Property Acknowledgement Receipt (Essuance) - Only for properties
                If Essuance IsNot Nothing Then
                    Essuance.Enabled = isProperty
                End If
                
                ' Return Item - Always enabled for both types
                If btnReturnItem IsNot Nothing Then
                    btnReturnItem.Enabled = True
                End If
                
                System.Diagnostics.Debug.WriteLine($"[v0] Selection changed - Type: {itemType}, IsProperty: {isProperty}")
            Else
                ' No selection - disable all buttons
                If btnRequestMaintenance IsNot Nothing Then btnRequestMaintenance.Enabled = False
                If btnBorrowReturn IsNot Nothing Then btnBorrowReturn.Enabled = False
                If Essuance IsNot Nothing Then Essuance.Enabled = False
                If btnReturnItem IsNot Nothing Then btnReturnItem.Enabled = False
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] SelectionChanged Error: " & ex.Message)
        End Try
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
    ''' Returns proper columns based on item type
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
            ' Include all relevant columns for both properties and supplies
            Dim query As String = "SELECT " &
                                 "bi.borrowId, bi.requestId, bi.itemType, bi.itemId, " &
                                 "bi.borrowDate, bi.returnReason, bi.status AS borrowStatus, bi.remarks, " &
                                 "bi.borrowerName, bi.departmentId, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.itemName " &
                                 "  WHEN bi.itemType = 'supply' THEN s.itemName " &
                                 "  ELSE 'Unknown' " &
                                 "END AS itemName, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.category " &
                                 "  WHEN bi.itemType = 'supply' THEN s.category " &
                                 "  ELSE NULL " &
                                 "END AS category, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.description " &
                                 "  WHEN bi.itemType = 'supply' THEN s.description " &
                                 "  ELSE NULL " &
                                 "END AS description, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.propertyNumber " &
                                 "  ELSE NULL " &
                                 "END AS propertyNumber, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.serialNumber " &
                                 "  ELSE NULL " &
                                 "END AS serialNumber, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.acquisitionDate " &
                                 "  WHEN bi.itemType = 'supply' THEN s.dateReceived " &
                                 "  ELSE NULL " &
                                 "END AS acquisitionDate, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.acquisitionCost " &
                                 "  WHEN bi.itemType = 'supply' THEN s.unitCost " &
                                 "  ELSE NULL " &
                                 "END AS unitCost, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.totalCost " &
                                 "  WHEN bi.itemType = 'supply' THEN s.totalCost " &
                                 "  ELSE NULL " &
                                 "END AS totalCost, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.sourceOfFunds " &
                                 "  WHEN bi.itemType = 'supply' THEN s.sourceOfFunds " &
                                 "  ELSE NULL " &
                                 "END AS sourceOfFunds, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.location " &
                                 "  WHEN bi.itemType = 'supply' THEN s.location " &
                                 "  ELSE NULL " &
                                 "END AS location, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.condition " &
                                 "  ELSE 'N/A' " &
                                 "END AS `condition`, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'property' THEN p.status " &
                                 "  WHEN bi.itemType = 'supply' THEN s.stockStatus " &
                                 "  ELSE NULL " &
                                 "END AS itemStatus, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'supply' THEN s.unitOfMeasure " &
                                 "  ELSE NULL " &
                                 "END AS unitOfMeasure, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'supply' THEN s.quantity " &
                                 "  ELSE 1 " &
                                 "END AS quantity, " &
                                 "CASE " &
                                 "  WHEN bi.itemType = 'supply' THEN s.supplier " &
                                 "  ELSE NULL " &
                                 "END AS supplier, " &
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
    ''' Displays different columns based on item type (property vs supply)
    ''' </summary>
    Private Sub AddBorrowedItemRowToGrid(row As DataRow)
        Try
            Dim borrowId As String = If(row.IsNull("borrowId"), "", row("borrowId").ToString())
            Dim itemType As String = If(row.IsNull("itemType"), "property", row("itemType").ToString()).ToLower()
            Dim itemName As String = If(row.IsNull("itemName"), "", row("itemName").ToString())
            
            ' Common fields for both types
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
            
            ' Property-specific fields
            Dim propertyNumber As String = "N/A"
            Dim serialNumber As String = "N/A"
            Dim condition As String = "N/A"
            Dim quantity As String = "1 Unit"
            
            ' Supply-specific fields
            Dim unitOfMeasure As String = ""
            Dim supplier As String = ""
            
            If itemType = "property" Then
                ' Property fields
                propertyNumber = If(row.IsNull("propertyNumber"), "N/A", If(String.IsNullOrEmpty(row("propertyNumber").ToString()), "N/A", row("propertyNumber").ToString()))
                serialNumber = If(row.IsNull("serialNumber"), "N/A", If(String.IsNullOrEmpty(row("serialNumber").ToString()), "N/A", row("serialNumber").ToString()))
                condition = If(row.IsNull("condition"), "Good", row("condition").ToString())
                quantity = "1 Unit"
            ElseIf itemType = "supply" Then
                ' Supply fields
                Dim qtyValue As Integer = If(row.IsNull("quantity"), 1, Convert.ToInt32(row("quantity")))
                unitOfMeasure = If(row.IsNull("unitOfMeasure"), "Unit", row("unitOfMeasure").ToString())
                quantity = qtyValue.ToString() & " " & unitOfMeasure
                supplier = If(row.IsNull("supplier"), "N/A", If(String.IsNullOrEmpty(row("supplier").ToString()), "N/A", row("supplier").ToString()))
                propertyNumber = "N/A"  ' Supplies don't have property numbers
                serialNumber = "N/A"    ' Supplies don't have serial numbers
                condition = "N/A"       ' Supplies don't have condition (use stockStatus instead)
            End If

            ' Allow maintenance requests only for properties
            Dim canRequestMaintenance As Boolean = (itemType = "property") AndAlso Not String.IsNullOrEmpty(itemId)

            ' Format display type
            Dim displayType As String = If(itemType = "property", "Property", "Supply")
            
            ' Get category from database row
            Dim category As String = If(row.IsNull("category"), "", row("category").ToString())
            
            ' Format purpose (use borrowStatus as purpose display)
            Dim purpose As String = borrowStatus
            
            ' Add row with new column structure: BorrowId (hidden), Type, ItemName, Category, Quantity, Condition, Purpose, Remarks, ItemId (hidden)
            dgvBorrowedItems.Rows.Add(
                borrowId,          ' colBorrowId (hidden)
                displayType,       ' colItemType (Type)
                itemName,          ' colItemName (Item Name)
                category,          ' colCategory (Category)
                quantity,          ' colQuantity (Quantity)
                condition,         ' colCondition (Condition)
                purpose,           ' colPurpose (Purpose)
                remarks,           ' colRemarks (Remarks)
                itemId            ' colItemId (hidden)
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
                Dim category As String = If(row.Cells("colCategory").Value?.ToString(), "").ToLower()
                Dim remarks As String = If(row.Cells("colRemarks").Value?.ToString(), "").ToLower()
                Dim itemType As String = If(row.Cells("colItemType").Value?.ToString(), "")
                Dim condition As String = If(row.Cells("colCondition").Value?.ToString(), "")

                Dim matchesSearch As Boolean = String.IsNullOrEmpty(searchText) OrElse
                                              itemName.Contains(searchText) OrElse
                                              category.Contains(searchText) OrElse
                                              remarks.Contains(searchText)

                Dim matchesStatus As Boolean = filterStatus = "All" OrElse
                                              (filterStatus = "Approved") OrElse
                                              (filterStatus = "Needs Repair" AndAlso (condition = "Needs Repair" Or condition = "Damaged")) OrElse
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
        Dim itemId As String = If(selectedRow.Cells("colItemId").Value?.ToString(), "")

        If String.IsNullOrEmpty(itemId) Then
            MessageBox.Show("Cannot request maintenance: Item ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get property details from database (propertyNumber and serialNumber not in grid anymore)
        Dim propertyNumber As String = "N/A"
        Dim serialNumber As String = "N/A"
        
        Try
            Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
            If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                Using cmd As New MySqlCommand("SELECT propertyNumber, serialNumber FROM properties WHERE propertyId = @propertyId", conn)
                    cmd.Parameters.AddWithValue("@propertyId", itemId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            propertyNumber = If(reader.IsDBNull(reader.GetOrdinal("propertyNumber")), "N/A", reader("propertyNumber").ToString())
                            serialNumber = If(reader.IsDBNull(reader.GetOrdinal("serialNumber")), "N/A", reader("serialNumber").ToString())
                        End If
                    End Using
                End Using
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
        Catch dbEx As Exception
            System.Diagnostics.Debug.WriteLine("Error retrieving property details: " & dbEx.Message)
        End Try

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
        Dim borrowId As String = If(selectedRow.Cells("colBorrowId").Value?.ToString(), "")
        Dim itemName As String = If(selectedRow.Cells("colItemName").Value?.ToString(), "")
        Dim itemType As String = If(selectedRow.Cells("colItemType").Value?.ToString(), "").ToLower()
        Dim currentStatus As String = If(selectedRow.Cells("colPurpose").Value?.ToString(), "")

        ' Check if already returned
        If currentStatus.ToLower() = "returned" Then
            MessageBox.Show("This item has already been returned.", "Already Returned", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Show return dialog - different for properties vs supplies
        Dim itemTypeLabel As String = If(itemType = "property", "property", "supply")
        Dim result As DialogResult = MessageBox.Show(
            $"Return {itemTypeLabel}: {itemName}{Environment.NewLine}{Environment.NewLine}" &
            $"Are you sure you want to mark this {itemTypeLabel} as returned?",
            "Confirm Return",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' For properties: Show condition selection dialog
            ' For supplies: Show return reason dialog
            If itemType = "property" Then
                ' Show condition selection dialog for properties
            Dim conditionDialog As New Form()
            conditionDialog.Text = "Item Condition on Return"
            conditionDialog.Size = New Size(500, 350)
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

            Dim lblReasonLabel As New Label()
            lblReasonLabel.Text = "Return Reason:"
            lblReasonLabel.Location = New Point(20, 170)
            lblReasonLabel.Size = New Size(120, 25)
            lblReasonLabel.Font = New Font("Segoe UI", 9)

            Dim txtReturnReason As New TextBox()
            txtReturnReason.Location = New Point(140, 170)
            txtReturnReason.Size = New Size(320, 25)
            txtReturnReason.ForeColor = System.Drawing.SystemColors.WindowText

            Dim lblRemarksLabel As New Label()
            lblRemarksLabel.Text = "Additional Remarks:"
            lblRemarksLabel.Location = New Point(20, 205)
            lblRemarksLabel.Size = New Size(150, 25)
            lblRemarksLabel.Font = New Font("Segoe UI", 9)

            Dim txtRemarks As New TextBox()
            txtRemarks.Location = New Point(20, 230)
            txtRemarks.Size = New Size(440, 50)
            txtRemarks.Multiline = True
            txtRemarks.ScrollBars = ScrollBars.Vertical

            Dim btnOK As New Button()
            btnOK.Text = "Confirm Return"
            btnOK.Location = New Point(280, 290)
            btnOK.Size = New Size(120, 35)
            btnOK.DialogResult = DialogResult.OK

            Dim btnCancel As New Button()
            btnCancel.Text = "Cancel"
            btnCancel.Location = New Point(150, 290)
            btnCancel.Size = New Size(120, 35)
            btnCancel.DialogResult = DialogResult.Cancel

            conditionDialog.Controls.AddRange(New Control() {lblQuestion, rbGood, rbNeedsRepair, rbDamaged, lblReasonLabel, txtReturnReason, lblRemarksLabel, txtRemarks, btnOK, btnCancel})
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

                ' Get return reason and remarks
                Dim returnReason As String = txtReturnReason.Text.Trim()
                Dim remarks As String = txtRemarks.Text.Trim()

                ' Update borrowed_items table with condition, return reason, and remarks separately
                Try
                    Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
                    If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                        Dim query As String = "UPDATE borrowed_items SET status = 'Returned', actualReturnDate = NOW(), conditionOnReturn = @condition, returnReason = @returnReason, remarks = @remarks, updatedAt = NOW() WHERE borrowId = @borrowId"
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@borrowId", borrowId)
                            cmd.Parameters.AddWithValue("@condition", condition)
                            cmd.Parameters.AddWithValue("@returnReason", If(String.IsNullOrEmpty(returnReason), DBNull.Value, CObj(returnReason)))
                            cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, CObj(remarks)))
                            
                            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                            If rowsAffected > 0 Then
                                MessageBox.Show($"Property '{itemName}' returned successfully!{Environment.NewLine}Condition: {condition}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                LoadApprovedRequests() ' Refresh the grid
                            Else
                                MessageBox.Show("No record was updated. Please try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End Using
                        If conn.State = ConnectionState.Open Then conn.Close()
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Failed to return property. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Diagnostics.Debug.WriteLine("[v0] Property return error: " & ex.Message)
                End Try
            End If
            Else
                ' Supply return - show reason dialog
                Dim reasonDialog As New Form()
                reasonDialog.Text = "Supply Return Reason"
                reasonDialog.Size = New Size(500, 300)
                reasonDialog.StartPosition = FormStartPosition.CenterParent
                reasonDialog.FormBorderStyle = FormBorderStyle.FixedDialog
                reasonDialog.MaximizeBox = False
                reasonDialog.MinimizeBox = False

                Dim lblQuestion As New Label()
                lblQuestion.Text = $"Why are you returning '{itemName}'?"
                lblQuestion.Location = New Point(20, 20)
                lblQuestion.Size = New Size(440, 40)
                lblQuestion.Font = New Font("Segoe UI", 10, FontStyle.Bold)

                Dim lblReasonLabel As New Label()
                lblReasonLabel.Text = "Return Reason:"
                lblReasonLabel.Location = New Point(20, 70)
                lblReasonLabel.Size = New Size(120, 25)
                lblReasonLabel.Font = New Font("Segoe UI", 9)

                Dim cboReason As New ComboBox()
                cboReason.Location = New Point(140, 70)
                cboReason.Size = New Size(320, 25)
                cboReason.DropDownStyle = ComboBoxStyle.DropDownList
                cboReason.Items.AddRange(New String() {
                    "Completed usage",
                    "No longer needed",
                    "Defective/Damaged",
                    "Wrong item received",
                    "Excess quantity",
                    "Project completed",
                    "Other"
                })
                cboReason.SelectedIndex = 0

                Dim lblRemarksLabel As New Label()
                lblRemarksLabel.Text = "Additional Remarks:"
                lblRemarksLabel.Location = New Point(20, 110)
                lblRemarksLabel.Size = New Size(150, 25)
                lblRemarksLabel.Font = New Font("Segoe UI", 9)

                Dim txtRemarks As New TextBox()
                txtRemarks.Location = New Point(20, 135)
                txtRemarks.Size = New Size(440, 80)
                txtRemarks.Multiline = True
                txtRemarks.ScrollBars = ScrollBars.Vertical

                Dim btnOK As New Button()
                btnOK.Text = "Confirm Return"
                btnOK.Location = New Point(280, 225)
                btnOK.Size = New Size(120, 35)
                btnOK.DialogResult = DialogResult.OK

                Dim btnCancel As New Button()
                btnCancel.Text = "Cancel"
                btnCancel.Location = New Point(150, 225)
                btnCancel.Size = New Size(120, 35)
                btnCancel.DialogResult = DialogResult.Cancel

                reasonDialog.Controls.AddRange(New Control() {lblQuestion, lblReasonLabel, cboReason, lblRemarksLabel, txtRemarks, btnOK, btnCancel})
                reasonDialog.AcceptButton = btnOK
                reasonDialog.CancelButton = btnCancel

                If reasonDialog.ShowDialog() = DialogResult.OK Then
                    ' Get return reason and remarks
                    Dim returnReason As String = cboReason.SelectedItem.ToString()
                    Dim remarks As String = txtRemarks.Text.Trim()

                    ' Update borrowed_items record for supply (save return reason and remarks separately)
                    Try
                        Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
                        If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                            Dim query As String = "UPDATE borrowed_items SET status = 'Returned', actualReturnDate = NOW(), returnReason = @returnReason, remarks = @remarks, updatedAt = NOW() WHERE borrowId = @borrowId"
                            Using cmd As New MySqlCommand(query, conn)
                                cmd.Parameters.AddWithValue("@borrowId", borrowId)
                                cmd.Parameters.AddWithValue("@returnReason", returnReason)
                                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, CObj(remarks)))
                                
                                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                                If rowsAffected > 0 Then
                                    MessageBox.Show($"Supply '{itemName}' returned successfully!{Environment.NewLine}{Environment.NewLine}Reason: {returnReason}", "Return Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    LoadApprovedRequests() ' Refresh the list
                                Else
                                    MessageBox.Show("No record was updated. Please try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End Using
                            If conn.State = ConnectionState.Open Then conn.Close()
                        End If
                    Catch ex As Exception
                        MessageBox.Show($"Failed to return supply. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        System.Diagnostics.Debug.WriteLine("[v0] Supply return error: " & ex.Message)
                    End Try
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

    ''' <summary>
    ''' Click on Total Items label to show all items
    ''' </summary>
    Private Sub lblTotalItems_Click(sender As Object, e As EventArgs) Handles lblTotalItems.Click
        ' Reset filters to show all items
        cboFilterType.SelectedIndex = 0 ' All
        cboFilterStatus.SelectedIndex = 0 ' All
        txtSearch.Text = ""
        
        ' Visual feedback
        HighlightLabel(lblTotalItems)
    End Sub

    ''' <summary>
    ''' Click on Properties label to filter properties only
    ''' </summary>
    Private Sub lblPropertyCount_Click(sender As Object, e As EventArgs) Handles lblPropertyCount.Click
        ' Set filter to show only properties
        cboFilterType.SelectedIndex = 1 ' Property
        cboFilterStatus.SelectedIndex = 0 ' All
        
        ' Visual feedback
        HighlightLabel(lblPropertyCount)
    End Sub

    ''' <summary>
    ''' Click on Supplies label to filter supplies only
    ''' </summary>
    Private Sub lblSupplyCount_Click(sender As Object, e As EventArgs) Handles lblSupplyCount.Click
        ' Set filter to show only supplies
        cboFilterType.SelectedIndex = 2 ' Supply
        cboFilterStatus.SelectedIndex = 0 ' All
        
        ' Visual feedback
        HighlightLabel(lblSupplyCount)
    End Sub

    ''' <summary>
    ''' Click on Needs Attention label to filter items needing repair
    ''' </summary>
    Private Sub lblNeedsRepair_Click(sender As Object, e As EventArgs) Handles lblNeedsRepair.Click
        ' Set filter to show only items needing attention (Needs Repair or Damaged)
        cboFilterType.SelectedIndex = 0 ' All
        cboFilterStatus.SelectedIndex = 3 ' Needs Repair (Index 3 in combo box: All, Approved, Good Condition, Needs Repair, Damaged)
        
        ' Visual feedback
        HighlightLabel(lblNeedsRepair)
    End Sub

    ''' <summary>
    ''' Provide visual feedback when label is clicked
    ''' </summary>
    Private Sub HighlightLabel(clickedLabel As Label)
        ' Flash the label to show it was clicked
        Dim originalFont = clickedLabel.Font
        clickedLabel.Font = New Font(originalFont.FontFamily, originalFont.Size, FontStyle.Bold Or FontStyle.Underline)
        
        ' Reset after short delay
        Dim timer As New Timer()
        timer.Interval = 200
        AddHandler timer.Tick, Sub(s, e)
                                   clickedLabel.Font = originalFont
                                   timer.Stop()
                                   timer.Dispose()
                               End Sub
        timer.Start()
    End Sub

    Private Sub btnBorrowReturn_Click(sender As Object, e As EventArgs) Handles btnBorrowReturn.Click
        Dim BorrowingAndReturnSlip As New BorrowingAndReturnSlip()
        BorrowingAndReturnSlip.Show()
    End Sub

    Private Sub Essuance_Click(sender As Object, e As EventArgs) Handles Essuance.Click
        Dim propertyAcknowledgement As New PropertyAcknowledgementReceipt()
        propertyAcknowledgement.Show()
    End Sub
End Class
