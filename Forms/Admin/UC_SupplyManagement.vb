Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Text.RegularExpressions
Imports System.Linq

Public Class UC_SupplyManagement
    Inherits UserControl

    Private originalData As DataTable
    Private selectedSupplyID As Integer = -1
    Private canModifySupplies As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub UC_SupplyManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' General settings
        pm_table.ReadOnly = True
        pm_table.AllowUserToAddRows = False
        pm_table.AllowUserToDeleteRows = False
        pm_table.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        pm_table.MultiSelect = False
        pm_table.RowTemplate.Height = 30
        pm_table.EnableHeadersVisualStyles = False

        ' Font & colors
        pm_table.DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        pm_table.DefaultCellStyle.BackColor = Color.White
        pm_table.DefaultCellStyle.ForeColor = Color.Black
        pm_table.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        ' Header styling
        pm_table.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        pm_table.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        pm_table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        pm_table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Column alignment
        For Each col As DataGridViewColumn In pm_table.Columns
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        ' Auto size
        pm_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' No restrictions - all buttons enabled for Super Admin, Admin, and Custodian
        ApplyRolePermissions()

        ' Initialize filter dropdowns
        InitializeFilters()

        ' Load data from database
        LoadSuppliesData()

        ' Wire up event handlers
        AddHandler pm_table.SelectionChanged, AddressOf pm_table_SelectionChanged
    End Sub

    Private Sub ApplyRolePermissions()
        ' Super Admin, Admin, and Custodian have full access - all buttons enabled
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        btnAdd.Enabled = hasFullAccess
        btnEdit.Enabled = hasFullAccess
        btnDelete.Enabled = hasFullAccess
    End Sub


    Private Sub InitializeFilters()
        ' Populate category filter
        pm_cbobx_categ.Items.Clear()
        pm_cbobx_categ.Items.Add("All Categories")
        pm_cbobx_categ.Items.AddRange(New String() {"Stationery", "Electronics", "Furniture", "Equipment", "Other"})
        pm_cbobx_categ.SelectedIndex = 0

        ' Populate status filter
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"Available", "Low Stock", "Out of Stock"})
        pm_cbobx_status.SelectedIndex = 0

        ' Wire up filter change events
        AddHandler pm_cbobx_categ.SelectedIndexChanged, AddressOf Filter_Changed
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
    End Sub

    ' Added method to load supplies from database
    Public Sub LoadSuppliesData()
        Try
            pm_table.Rows.Clear()
            Dim categoryFilter As String = ""
            Dim statusFilter As String = ""

            ' Get filter values
            If pm_cbobx_categ.SelectedIndex > 0 Then
                categoryFilter = pm_cbobx_categ.SelectedItem.ToString()
            End If
            If pm_cbobx_status.SelectedIndex > 0 Then
                statusFilter = pm_cbobx_status.SelectedItem.ToString()
            End If

            Dim dt As DataTable = DatabaseConnection.GetAllSupplies(categoryFilter, statusFilter)
            originalData = dt.Copy()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    ' Use safe column access with correct column names from GetAllSupplies
                    Dim supplyID As String = If(row.Table.Columns.Contains("SupplyID") AndAlso Not IsDBNull(row("SupplyID")), row("SupplyID").ToString(), "")
                    Dim supplyName As String = If(row.Table.Columns.Contains("SupplyName") AndAlso Not IsDBNull(row("SupplyName")), row("SupplyName").ToString(), "")
                    Dim category As String = If(row.Table.Columns.Contains("Category") AndAlso Not IsDBNull(row("Category")), row("Category").ToString(), "")
                    Dim unitOfMeasure As String = If(row.Table.Columns.Contains("UnitOfMeasure") AndAlso Not IsDBNull(row("UnitOfMeasure")), row("UnitOfMeasure").ToString(), "")
                    Dim quantity As String = If(row.Table.Columns.Contains("QuantityInStock") AndAlso Not IsDBNull(row("QuantityInStock")), row("QuantityInStock").ToString(), "0")
                    Dim acqDate As String = ""
                    If row.Table.Columns.Contains("AcquisitionDate") AndAlso Not IsDBNull(row("AcquisitionDate")) Then
                        Dim parsedDate As Date
                        If Date.TryParse(row("AcquisitionDate").ToString(), parsedDate) Then
                            acqDate = parsedDate.ToString("yyyy-MM-dd")
                        End If
                    End If
                    Dim unitCost As String = "0.00"
                    If row.Table.Columns.Contains("UnitCost") AndAlso Not IsDBNull(row("UnitCost")) Then
                        Dim cost As Decimal
                        If Decimal.TryParse(row("UnitCost").ToString(), cost) Then
                            unitCost = Format(cost, "0.00")
                        End If
                    End If
                    Dim location As String = If(row.Table.Columns.Contains("Location") AndAlso Not IsDBNull(row("Location")), row("Location").ToString(), "")
                    Dim supplierName As String = If(row.Table.Columns.Contains("SupplierName") AndAlso Not IsDBNull(row("SupplierName")), row("SupplierName").ToString(), "")
                    Dim status As String = If(row.Table.Columns.Contains("Status") AndAlso Not IsDBNull(row("Status")), row("Status").ToString(), "")

                    ' Add row with SupplyID as first column (stored in Tag for easy access)
                    Dim rowIndex As Integer = pm_table.Rows.Add(supplyName, category, unitOfMeasure, quantity, acqDate, unitCost, location, supplierName, status)
                    ' Store SupplyID in row Tag for easy access
                    If Not String.IsNullOrEmpty(supplyID) AndAlso Integer.TryParse(supplyID, Nothing) Then
                        pm_table.Rows(rowIndex).Tag = supplyID
                    End If
                Next

                ' Update total count
                If ttlSupplymanagement IsNot Nothing Then
                    ttlSupplymanagement.Text = dt.Rows.Count.ToString()
                End If
                System.Diagnostics.Debug.WriteLine("[v0] Supply Management - Loaded " & dt.Rows.Count & " supplies")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Supply Management - No supplies found")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading supplies: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Load Supplies Error: " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub pm_table_SelectionChanged(sender As Object, e As EventArgs)
        If pm_table.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = pm_table.SelectedRows(0)
            ' Get SupplyID from row Tag (stored when loading data)
            If selectedRow.Tag IsNot Nothing Then
                Dim supplyIDStr As String = selectedRow.Tag.ToString()
                If Integer.TryParse(supplyIDStr, selectedSupplyID) Then
                    ' Row selected, enable Edit and Delete buttons
                End If
            End If
        End If
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        ' Reload data with filters
        LoadSuppliesData()
        ' Reapply search if there's search text
    End Sub
    ' Super Admin bypasses all restrictions


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Super Admin bypasses all restrictions

        ' Get reference to the parent dashboard form
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)

        If parentDashboard IsNot Nothing Then
            ' Load the AddSupply UserControl
            parentDashboard.LoadUserControl(New AddSupply())
        Else
            ' Fallback: add directly to the parent container
            Dim addSupplyUC As New AddSupply()
            Me.Parent.Controls.Add(addSupplyUC)
            addSupplyUC.BringToFront()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Super Admin bypasses all restrictions
        If pm_table.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a supply to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = pm_table.SelectedRows(0)
        ' Get SupplyID from row Tag
        Dim supplyIDStr As String = ""
        If selectedRow.Tag IsNot Nothing Then
            supplyIDStr = selectedRow.Tag.ToString()
        End If

        If String.IsNullOrEmpty(supplyIDStr) Then
            MessageBox.Show("Invalid supply selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim supplyID As Integer
        If Not Integer.TryParse(supplyIDStr, supplyID) Then
            MessageBox.Show("Invalid supply ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get supply data from database
        Dim supplyData As DataRow = DatabaseConnection.GetSupplyById(supplyIDStr)
        If supplyData Is Nothing Then
            MessageBox.Show("Supply not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if EditSupply form exists, otherwise show message
        Try
            ' Try to create EditSupply form using reflection
            Dim editSupplyType As Type = Type.GetType("StaCruzPropertyCustodianSystem.Forms.Admin.EditSupply")
            If editSupplyType IsNot Nothing Then
                Dim editForm As Object = Activator.CreateInstance(editSupplyType)
                ' Load supply data into edit form if it has a LoadSupplyData method
                Dim loadMethod = editSupplyType.GetMethod("LoadSupplyData")
                If loadMethod IsNot Nothing Then
                    loadMethod.Invoke(editForm, New Object() {supplyID, supplyData})
                End If
                ' Navigate to edit form
                Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
                If parentDashboard IsNot Nothing Then
                    parentDashboard.LoadUserControl(TryCast(editForm, UserControl))
                End If
            Else
                MessageBox.Show("Edit form for supplies is not yet implemented. Supply ID: " & supplyID.ToString(), "Edit Supply", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Edit functionality for Supply ID: " & supplyID.ToString() & " - Edit form needs to be implemented. Error: " & ex.Message, "Edit Supply", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Super Admin bypasses all restrictions


        Dim selectedRow As DataGridViewRow = pm_table.SelectedRows(0)
        ' Get SupplyID from row Tag
        Dim supplyIDStr As String = ""
        If selectedRow.Tag IsNot Nothing Then
            supplyIDStr = selectedRow.Tag.ToString()
        End If

        If String.IsNullOrEmpty(supplyIDStr) Then
            MessageBox.Show("Invalid supply selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim supplyName As String = If(selectedRow.Cells("itemName").Value IsNot Nothing, selectedRow.Cells("itemName").Value.ToString(), "Unknown")

        Dim supplyID As Integer
        If Not Integer.TryParse(supplyIDStr, supplyID) Then
            MessageBox.Show("Invalid supply ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Confirmation dialog
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete supply '" & supplyName & "' (ID: " & supplyID.ToString() & ")?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            Try
                Dim success As Boolean = DatabaseConnection.DeleteSupply(supplyID)
                If success Then
                    LoadSuppliesData() ' Refresh table
                    MessageBox.Show("Supply deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub admin_label_PM_Click(sender As Object, e As EventArgs) Handles admin_label_PM.Click

    End Sub

    Private Sub pm_table_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
    Handles pm_table.CellClick
        ' Check if colMenu column exists before accessing it
        If e.RowIndex >= 0 AndAlso pm_table.Columns.Contains("colMenu") AndAlso e.ColumnIndex = pm_table.Columns("colMenu").Index Then
            If cmsActions IsNot Nothing Then
                cmsActions.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub mnuAssign_Click(sender As Object, e As EventArgs) _
    Handles mnuAssign.Click

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
