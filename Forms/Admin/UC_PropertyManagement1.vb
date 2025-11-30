Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Linq

Public Class UC_PropertyManagement1
    Inherits UserControl

    Private originalData As DataTable
    Private selectedPropertyID As Integer = -1
    Private canModifyProperties As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub UC_PropertyManagement1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' No restrictions - all buttons enabled for Super Admin, Admin, and Custodian
        ApplyRolePermissions()

        ' General settings
        propertyManagementGrid.ReadOnly = True
        propertyManagementGrid.AllowUserToAddRows = False
        propertyManagementGrid.AllowUserToDeleteRows = False
        propertyManagementGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        propertyManagementGrid.MultiSelect = False
        propertyManagementGrid.RowTemplate.Height = 30
        propertyManagementGrid.EnableHeadersVisualStyles = False

        ' Font & colors
        propertyManagementGrid.DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        propertyManagementGrid.DefaultCellStyle.BackColor = Color.White
        propertyManagementGrid.DefaultCellStyle.ForeColor = Color.Black
        propertyManagementGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        ' Header styling
        propertyManagementGrid.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        propertyManagementGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        propertyManagementGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        propertyManagementGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Column alignment
        For Each col As DataGridViewColumn In propertyManagementGrid.Columns
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        ' Auto size
        propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Initialize filter dropdowns
        InitializeFilters()

        ' Load data from database
        LoadPropertiesData()

        ' Wire up event handlers
        AddHandler propertyManagementGrid.SelectionChanged, AddressOf propertyManagementGrid_SelectionChanged
    End Sub

    Private Sub InitializeFilters()
        ' Populate status filter
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"Active", "For Disposal", "Lost", "Borrowed"})
        pm_cbobx_status.SelectedIndex = 0

        ' Wire up filter change events
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
    End Sub

    Public Sub LoadPropertiesData()
        Try
            propertyManagementGrid.Rows.Clear()
            Dim categoryFilter As String = ""
            Dim statusFilter As String = ""

            Dim dt As DataTable = DatabaseConnection.GetAllProperties(Nothing, "", categoryFilter, Nothing)
            originalData = dt.Copy()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    ' Use safe column access
                    Dim itemName As String = If(row.Table.Columns.Contains("item_name") AndAlso Not IsDBNull(row("item_name")), row("item_name").ToString(), "")
                    Dim category As String = If(row.Table.Columns.Contains("category") AndAlso Not IsDBNull(row("category")), row("category").ToString(), "")
                    Dim propNumber As String = If(row.Table.Columns.Contains("property_number") AndAlso Not IsDBNull(row("property_number")), row("property_number").ToString(), "")
                    Dim serialNumber As String = If(row.Table.Columns.Contains("serial_number") AndAlso Not IsDBNull(row("serial_number")), row("serial_number").ToString(), "")
                    Dim acqDate As String = ""
                    If row.Table.Columns.Contains("acquisition_date") AndAlso Not IsDBNull(row("acquisition_date")) Then
                        Dim parsedDate As Date
                        If Date.TryParse(row("acquisition_date").ToString(), parsedDate) Then
                            acqDate = parsedDate.ToString("yyyy-MM-dd")
                        End If
                    End If
                    Dim acqCost As String = "0.00"
                    If row.Table.Columns.Contains("acquisition_cost") AndAlso Not IsDBNull(row("acquisition_cost")) Then
                        Dim cost As Decimal
                        If Decimal.TryParse(row("acquisition_cost").ToString(), cost) Then
                            acqCost = Format(cost, "0.00")
                        End If
                    End If
                    Dim assignedEmp As String = If(row.Table.Columns.Contains("assigned_employee") AndAlso Not IsDBNull(row("assigned_employee")), row("assigned_employee").ToString(), "")
                    Dim assignedDept As String = If(row.Table.Columns.Contains("assigned_department") AndAlso Not IsDBNull(row("assigned_department")), row("assigned_department").ToString(), "")
                    Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), "")
                    Dim condition As String = If(row.Table.Columns.Contains("condition") AndAlso Not IsDBNull(row("condition")), row("condition").ToString(), "")
                    Dim status As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), "")
                    Dim propID As Object = If(row.Table.Columns.Contains("property_id") AndAlso Not IsDBNull(row("property_id")), row("property_id"), Nothing)

                    Dim rowIndex As Integer = propertyManagementGrid.Rows.Add(
                        itemName, category, propNumber, serialNumber, acqDate, acqCost,
                        assignedEmp, assignedDept, location, condition, status
                    )
                    ' Store property_id in row Tag for easy access
                    propertyManagementGrid.Rows(rowIndex).Tag = propID
                Next
                ' Update total count
                If ttlpropertymanagement IsNot Nothing Then
                    ttlpropertymanagement.Text = dt.Rows.Count.ToString()
                End If
                Debug.WriteLine("[v0] Property Management - Loaded " & dt.Rows.Count & " properties")
            Else
                Debug.WriteLine("[v0] Property Management - No properties found")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading properties: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine("[v0] Load Properties Error: " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub propertyManagementGrid_SelectionChanged(sender As Object, e As EventArgs)
        If propertyManagementGrid.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
            If selectedRow.Tag IsNot Nothing Then
                If Integer.TryParse(selectedRow.Tag.ToString(), selectedPropertyID) Then
                    ' Row selected, enable Edit and Delete buttons
                End If
            End If
        End If
    End Sub




    Private Sub ApplyRolePermissions()
        ' Super Admin, Admin, and Custodian have full access - all buttons enabled
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If btnAdd IsNot Nothing Then btnAdd.Enabled = hasFullAccess
        If btnEdit IsNot Nothing Then btnEdit.Enabled = hasFullAccess
        If btnDelete IsNot Nothing Then btnDelete.Enabled = hasFullAccess
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        ' Reload data with filters
        LoadPropertiesData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Super Admin bypasses all restrictions

        Dim addRequest As New AddProperty()
        addRequest.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addRequest)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Super Admin bypasses all restrictions


        Dim row As DataGridViewRow = propertyManagementGrid.SelectedRows(0)

        ' Validate property ID from Tag
        Dim propertyID As Integer
        If row.Tag Is Nothing OrElse Not Integer.TryParse(row.Tag.ToString(), propertyID) Then
            MessageBox.Show("Invalid Property ID.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Create the EDIT USER CONTROL
        Dim editForm As New EditPropertyManagement()

        ' Load selected data into edit form using correct column names from DataGridView
        ' Use the originalData DataTable to get full property details
        Dim propertyRow As DataRow = Nothing
        If originalData IsNot Nothing Then
            Dim rows() As DataRow = originalData.Select("property_id = " & propertyID)
            If rows.Length > 0 Then
                propertyRow = rows(0)
            End If
        End If

        ' If we have the property row, use it; otherwise use DataGridView cells
        If propertyRow IsNot Nothing Then
            editForm.LoadPropertyData(
                propertyID,
                If(propertyRow.Table.Columns.Contains("item_name") AndAlso Not IsDBNull(propertyRow("item_name")), propertyRow("item_name").ToString(), If(row.Cells("itemName").Value IsNot Nothing, row.Cells("itemName").Value.ToString(), "")),
                If(propertyRow.Table.Columns.Contains("category") AndAlso Not IsDBNull(propertyRow("category")), propertyRow("category").ToString(), If(row.Cells("category").Value IsNot Nothing, row.Cells("category").Value.ToString(), "")),
                If(propertyRow.Table.Columns.Contains("serial_number") AndAlso Not IsDBNull(propertyRow("serial_number")), propertyRow("serial_number").ToString(), If(row.Cells("serialNumber").Value IsNot Nothing, row.Cells("serialNumber").Value.ToString(), "")),
                If(propertyRow.Table.Columns.Contains("supplier_name") AndAlso Not IsDBNull(propertyRow("supplier_name")), propertyRow("supplier_name").ToString(), ""),
                If(propertyRow.Table.Columns.Contains("condition") AndAlso Not IsDBNull(propertyRow("condition")), propertyRow("condition").ToString(), If(row.Cells("condition").Value IsNot Nothing, row.Cells("condition").Value.ToString(), "")),
                If(propertyRow.Table.Columns.Contains("acquisition_cost") AndAlso Not IsDBNull(propertyRow("acquisition_cost")), Decimal.Parse(propertyRow("acquisition_cost").ToString()), If(row.Cells("acquisitionCost").Value IsNot Nothing, Decimal.Parse(row.Cells("acquisitionCost").Value.ToString()), 0)),
                If(propertyRow.Table.Columns.Contains("acquisition_date") AndAlso Not IsDBNull(propertyRow("acquisition_date")), ParseDateCell(propertyRow("acquisition_date")), If(row.Cells("acquisitionDate").Value IsNot Nothing, ParseDateCell(row.Cells("acquisitionDate").Value), Date.Today)),
                Date.Today.AddYears(1), ' Warranty expiration - not in grid, use default
                If(propertyRow.Table.Columns.Contains("assigned_employee") AndAlso Not IsDBNull(propertyRow("assigned_employee")), propertyRow("assigned_employee").ToString(), If(row.Cells("assignedTo").Value IsNot Nothing, row.Cells("assignedTo").Value.ToString(), "")),
                If(propertyRow.Table.Columns.Contains("assigned_department") AndAlso Not IsDBNull(propertyRow("assigned_department")), propertyRow("assigned_department").ToString(), If(row.Cells("department").Value IsNot Nothing, row.Cells("department").Value.ToString(), "")),
                If(propertyRow.Table.Columns.Contains("location") AndAlso Not IsDBNull(propertyRow("location")), propertyRow("location").ToString(), If(row.Cells("location").Value IsNot Nothing, row.Cells("location").Value.ToString(), "")),
                If(propertyRow.Table.Columns.Contains("status") AndAlso Not IsDBNull(propertyRow("status")), propertyRow("status").ToString(), If(row.Cells("status").Value IsNot Nothing, row.Cells("status").Value.ToString(), "")),
                If(propertyRow.Table.Columns.Contains("created_at") AndAlso Not IsDBNull(propertyRow("created_at")), ParseDateCell(propertyRow("created_at")), Date.Now),
                If(propertyRow.Table.Columns.Contains("updated_at") AndAlso Not IsDBNull(propertyRow("updated_at")), ParseDateCell(propertyRow("updated_at")), Date.Now)
            )
        Else
            ' Fallback to DataGridView cells if originalData is not available
            editForm.LoadPropertyData(
                propertyID,
                If(row.Cells("itemName").Value IsNot Nothing, row.Cells("itemName").Value.ToString(), ""),
                If(row.Cells("category").Value IsNot Nothing, row.Cells("category").Value.ToString(), ""),
                If(row.Cells("serialNumber").Value IsNot Nothing, row.Cells("serialNumber").Value.ToString(), ""),
                "", ' Supplier not in grid
                If(row.Cells("condition").Value IsNot Nothing, row.Cells("condition").Value.ToString(), ""),
                If(row.Cells("acquisitionCost").Value IsNot Nothing, Decimal.Parse(row.Cells("acquisitionCost").Value.ToString()), 0),
                If(row.Cells("acquisitionDate").Value IsNot Nothing, ParseDateCell(row.Cells("acquisitionDate").Value), Date.Today),
                Date.Today.AddYears(1),
                If(row.Cells("assignedTo").Value IsNot Nothing, row.Cells("assignedTo").Value.ToString(), ""),
                If(row.Cells("department").Value IsNot Nothing, row.Cells("department").Value.ToString(), ""),
                If(row.Cells("location").Value IsNot Nothing, row.Cells("location").Value.ToString(), ""),
                If(row.Cells("status").Value IsNot Nothing, row.Cells("status").Value.ToString(), ""),
                Date.Now,
                Date.Now
            )
        End If

        ' LOAD THE USER CONTROL TO DASHBOARD
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(editForm)
        Else
            MessageBox.Show("Error: Dashboard not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Super Admin bypasses all restrictions


        Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
        If selectedRow.Tag Is Nothing Then
            MessageBox.Show("Invalid property selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim propertyIDStr As String = selectedRow.Tag.ToString()
        ' Try multiple possible column names for property name
        Dim propertyName As String = "Unknown"
        If propertyManagementGrid.Columns.Contains("itemName") AndAlso selectedRow.Cells("itemName").Value IsNot Nothing Then
            propertyName = selectedRow.Cells("itemName").Value.ToString()
        ElseIf propertyManagementGrid.Columns.Contains("ItemName") AndAlso selectedRow.Cells("ItemName").Value IsNot Nothing Then
            propertyName = selectedRow.Cells("ItemName").Value.ToString()
        ElseIf selectedRow.Cells.Count > 0 AndAlso selectedRow.Cells(0).Value IsNot Nothing Then
            propertyName = selectedRow.Cells(0).Value.ToString()
        End If

        Dim propertyID As Integer
        If Not Integer.TryParse(propertyIDStr, propertyID) Then
            MessageBox.Show("Invalid property ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Confirmation dialog
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete property '" & propertyName & "' (ID: " & propertyID.ToString() & ")?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            Try
                Dim success As Boolean = DatabaseConnection.DeleteProperty(propertyID)
                If success Then
                    LoadPropertiesData() ' Refresh table
                    MessageBox.Show("Property deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting property: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function ParseDateCell(cellValue As Object, Optional fallback As Date? = Nothing) As Date
        Dim parsed As Date
        If cellValue IsNot Nothing Then
            Dim stringValue As String = cellValue.ToString().Trim()
            If Not String.IsNullOrEmpty(stringValue) AndAlso Date.TryParse(stringValue, parsed) Then
                Return parsed
            End If
        End If

        Return If(fallback.HasValue, fallback.Value, Date.Today)
    End Function

    Private Function GetCellValueOrNothing(row As DataGridViewRow, columnName As String) As Object
        If propertyManagementGrid.Columns.Contains(columnName) Then
            Return row.Cells(columnName).Value
        End If
        Return Nothing
    End Function

    Private Sub propertyManagementGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellClick
        ' Check if colMenu column exists before accessing it
        If e.RowIndex >= 0 AndAlso propertyManagementGrid.Columns.Contains("colMenu") AndAlso e.ColumnIndex = propertyManagementGrid.Columns("colMenu").Index Then
            If cmsActions IsNot Nothing Then
                cmsActions.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub generatePropertyCard_Click(sender As Object, e As EventArgs) Handles generatePropertyCard.Click
        ' Check if a row is selected
        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRowGrid As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
        Dim propertyID As Integer
        If selectedRowGrid.Tag Is Nothing OrElse Not Integer.TryParse(selectedRowGrid.Tag.ToString(), propertyID) Then
            MessageBox.Show("Invalid Property ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Find the DataRow in originalData
        Dim rows() As DataRow = originalData.Select("property_id = " & propertyID)
        If rows.Length = 0 Then
            MessageBox.Show("Property data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim selectedRow As DataRow = rows(0)

        ' Open PropertyCard with the selected row
        Dim frm As New PropertyCard(selectedRow)
        frm.Show()
    End Sub

    Private Sub propertyManagementGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellContentClick

    End Sub

    Private Sub mnuAssign_Click(sender As Object, e As EventArgs) _
    Handles msuAssign.Click

        MessageBox.Show("Assign Property clicked!")
    End Sub

    Private Sub mnuDispose_Click(sender As Object, e As EventArgs) _
    Handles mnuDispose.Click

        MessageBox.Show("Dispose clicked!")
    End Sub

    Private Sub mnuLostDamaged_Click(sender As Object, e As EventArgs) _
    Handles mnuLostDamaged.Click

        MessageBox.Show("Mark Lost/Damaged clicked!")
    End Sub

    Private Sub mnuViewDetails_Click(sender As Object, e As EventArgs) _
    Handles mnuViewDetails.Click

        MessageBox.Show("View Details clicked!")
    End Sub

    Private Sub mnuPrintPARICS_Click(sender As Object, e As EventArgs) _
    Handles mnuPrintPARICS.Click

        MessageBox.Show("Print PAR/ICS clicked!")
    End Sub

End Class
