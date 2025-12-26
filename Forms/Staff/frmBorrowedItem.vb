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
    ''' Load approved property and supply requests for current user
    ''' </summary>
    Private Sub LoadApprovedRequests()
        Try
            dgvBorrowedItems.Rows.Clear()
            
            ' Load approved property requests
            Dim dtProperties As DataTable = GetApprovedPropertyRequests()
            If dtProperties IsNot Nothing Then
                For Each row As DataRow In dtProperties.Rows
                    AddPropertyRowToGrid(row)
                Next
            End If
            
            ' Load approved supply requests
            Dim dtSupplies As DataTable = GetApprovedSupplyRequests()
            If dtSupplies IsNot Nothing Then
                For Each row As DataRow In dtSupplies.Rows
                    AddSupplyRowToGrid(row)
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
    ''' Get approved property requests for current user
    ''' </summary>
    Private Function GetApprovedPropertyRequests() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        
        Try
            conn = DatabaseConnection.GetConnection()
            If conn Is Nothing Then Return dt
            If Not DatabaseConnection.SafeOpenConnection(conn) Then Return dt
            
            ' Query only from property_requests - don't join with properties table to avoid duplicates
            Dim query As String = "SELECT pr.requestId, pr.itemName, pr.description, pr.quantityRequested, " &
                                 "pr.unit, pr.dateOfRequest, pr.approvedDate, pr.purpose, pr.remarks, pr.requesterName " &
                                 "FROM property_requests pr " &
                                 "WHERE pr.status = 'Approved' " &
                                 "AND (pr.requesterName LIKE CONCAT((SELECT firstName FROM users WHERE userId = @userId), '%') " &
                                 "     OR pr.requesterName = (SELECT CONCAT(firstName, ' ', lastName) FROM users WHERE userId = @userId) " &
                                 "     OR pr.requesterName = (SELECT CONCAT(firstName, ' ', middleName, ' ', lastName) FROM users WHERE userId = @userId) " &
                                 "     OR pr.requesterName = (SELECT fullName FROM users WHERE userId = @userId)) " &
                                 "ORDER BY pr.approvedDate DESC"
            
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userId", currentUserId)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("GetApprovedPropertyRequests Exception: " & ex.Message)
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
    ''' Get approved supply requests for current user
    ''' </summary>
    Private Function GetApprovedSupplyRequests() As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        
        Try
            conn = DatabaseConnection.GetConnection()
            If conn Is Nothing Then Return dt
            If Not DatabaseConnection.SafeOpenConnection(conn) Then Return dt
            
            ' Query only from supplies_requests - don't join with supplies table to avoid duplicates
            Dim query As String = "SELECT sr.requestId, sr.itemName, sr.description, sr.quantityRequested, " &
                                 "sr.unit, sr.dateOfRequest, sr.approvedDate, sr.purpose, sr.remarks, sr.requesterName " &
                                 "FROM supplies_requests sr " &
                                 "WHERE sr.status = 'Approved' " &
                                 "AND (sr.requesterName LIKE CONCAT((SELECT firstName FROM users WHERE userId = @userId), '%') " &
                                 "     OR sr.requesterName = (SELECT CONCAT(firstName, ' ', lastName) FROM users WHERE userId = @userId) " &
                                 "     OR sr.requesterName = (SELECT CONCAT(firstName, ' ', middleName, ' ', lastName) FROM users WHERE userId = @userId) " &
                                 "     OR sr.requesterName = (SELECT fullName FROM users WHERE userId = @userId)) " &
                                 "ORDER BY sr.approvedDate DESC"
            
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userId", currentUserId)
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("GetApprovedSupplyRequests Exception: " & ex.Message)
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
    ''' Add property request row to grid
    ''' </summary>
    Private Sub AddPropertyRowToGrid(row As DataRow)
        Try
            Dim requestId As String = If(row.IsNull("requestId"), "", row("requestId").ToString())
            Dim itemType As String = "Property"
            Dim itemName As String = If(row.IsNull("itemName"), "", row("itemName").ToString())
            Dim propertyNumber As String = "N/A" ' Not available from request table
            Dim serialNumber As String = "N/A" ' Not available from request table
            Dim quantity As String = If(row.IsNull("quantityRequested"), "1", row("quantityRequested").ToString())
            Dim unit As String = If(row.IsNull("unit"), "", row("unit").ToString())
            Dim condition As String = "N/A" ' Not available from request table
            Dim approvedDate As String = ""
            
            If Not row.IsNull("approvedDate") Then
                Try
                    approvedDate = Convert.ToDateTime(row("approvedDate")).ToString("MMM dd, yyyy")
                Catch
                    approvedDate = row("approvedDate").ToString()
                End Try
            End If
            
            Dim purpose As String = If(row.IsNull("purpose"), "", row("purpose").ToString())
            Dim remarks As String = If(row.IsNull("remarks"), "", row("remarks").ToString())
            Dim propertyId As String = "" ' Not available from request table
            
            ' Maintenance requests not available for requests (only for actual assigned properties)
            Dim canRequestMaintenance As Boolean = False
            
            dgvBorrowedItems.Rows.Add(
                requestId,
                itemType,
                itemName,
                propertyNumber,
                serialNumber,
                quantity & " " & unit,
                condition,
                approvedDate,
                purpose,
                remarks,
                canRequestMaintenance,
                propertyId
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
            End Select
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("AddPropertyRowToGrid Exception: " & ex.Message)
        End Try
    End Sub
    
    ''' <summary>
    ''' Add supply request row to grid
    ''' </summary>
    Private Sub AddSupplyRowToGrid(row As DataRow)
        Try
            Dim requestId As String = If(row.IsNull("requestId"), "", row("requestId").ToString())
            Dim itemType As String = "Supply"
            Dim itemName As String = If(row.IsNull("itemName"), "", row("itemName").ToString())
            Dim quantity As String = If(row.IsNull("quantityRequested"), "1", row("quantityRequested").ToString())
            Dim unit As String = If(row.IsNull("unit"), "", row("unit").ToString())
            Dim approvedDate As String = ""
            
            If Not row.IsNull("approvedDate") Then
                Try
                    approvedDate = Convert.ToDateTime(row("approvedDate")).ToString("MMM dd, yyyy")
                Catch
                    approvedDate = row("approvedDate").ToString()
                End Try
            End If
            
            Dim purpose As String = If(row.IsNull("purpose"), "", row("purpose").ToString())
            Dim remarks As String = If(row.IsNull("remarks"), "", row("remarks").ToString())
            
            dgvBorrowedItems.Rows.Add(
                requestId,
                itemType,
                itemName,
                "N/A",        ' Property Number
                "N/A",        ' Serial Number
                quantity & " " & unit,
                "N/A",        ' Condition (supplies don't have condition)
                approvedDate,
                purpose,
                remarks,
                False,        ' Can't request maintenance for supplies
                ""            ' Property ID
            )
            
            ' Light blue background for supplies
            Dim lastRow As DataGridViewRow = dgvBorrowedItems.Rows(dgvBorrowedItems.Rows.Count - 1)
            lastRow.DefaultCellStyle.BackColor = Color.FromArgb(239, 246, 255)
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("AddSupplyRowToGrid Exception: " & ex.Message)
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
        Dim canRequestMaintenance As Boolean = CBool(If(selectedRow.Cells("colCanMaintenance").Value, False))
        Dim itemType As String = If(selectedRow.Cells("colItemType").Value?.ToString(), "")
        
        If itemType <> "Property" Then
            MessageBox.Show("Maintenance requests are only available for properties, not supplies.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        
        If Not canRequestMaintenance Then
            MessageBox.Show("This item is in good condition and doesn't require maintenance.", "Maintenance Not Needed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        
        ' Get item details
        Dim itemName As String = If(selectedRow.Cells("colItemName").Value?.ToString(), "")
        Dim propertyNumber As String = If(selectedRow.Cells("colPropertyNumber").Value?.ToString(), "")
        Dim serialNumber As String = If(selectedRow.Cells("colSerialNumber").Value?.ToString(), "")
        Dim propertyId As String = If(selectedRow.Cells("colPropertyId").Value?.ToString(), "")
        
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
                        setItemMethod.Invoke(maintenanceForm, New Object() {itemName, propertyNumber, serialNumber, propertyId})
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
    
End Class
