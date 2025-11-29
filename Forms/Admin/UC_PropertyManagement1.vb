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

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub UC_PropertyManagement1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        ' Populate category filter
        SADashboard.Items.Clear()
        SADashboard.Items.Add("All Categories")
        SADashboard.Items.AddRange(New String() {"Furniture", "Equipment", "Office Supplies", "IT Equipment",
                                                    "Laboratory Apparatus", "Books and Publications",
                                                    "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"})
        SADashboard.SelectedIndex = 0

        ' Populate status filter
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"active", "disposed", "lost", "damaged"})
        pm_cbobx_status.SelectedIndex = 0

        ' Wire up filter change events
        AddHandler SADashboard.SelectedIndexChanged, AddressOf Filter_Changed
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
    End Sub

    Public Sub LoadPropertiesData()
        Try
            propertyManagementGrid.Rows.Clear()
            Dim categoryFilter As String = ""
            Dim statusFilter As String = ""

            ' Get filter values
            If SADashboard.SelectedIndex > 0 Then
                categoryFilter = SADashboard.SelectedItem.ToString()
            End If
            If pm_cbobx_status.SelectedIndex > 0 Then
                statusFilter = pm_cbobx_status.SelectedItem.ToString()
            End If

            Dim dt As DataTable = DatabaseConnection.GetAllProperties(Nothing, "", categoryFilter, Nothing)
            originalData = dt.Copy()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim warrantyExp As String = ""
                    If Not IsDBNull(row("warranty_details")) AndAlso Not String.IsNullOrEmpty(row("warranty_details").ToString()) Then
                        warrantyExp = row("warranty_details").ToString()
                    End If

                    propertyManagementGrid.Rows.Add(
                        If(IsDBNull(row("property_id")), "", row("property_id").ToString()),
                        If(IsDBNull(row("property_name")), "", row("property_name").ToString()),
                        If(IsDBNull(row("category")), "", row("category").ToString()),
                        If(IsDBNull(row("serial_number")), "", row("serial_number").ToString()),
                        If(IsDBNull(row("supplier_name")), "", row("supplier_name").ToString()),
                        If(IsDBNull(row("condition_status")), "", row("condition_status").ToString()),
                        If(IsDBNull(row("acquisition_cost")), "0.00", Format(CDec(row("acquisition_cost")), "0.00")),
                        If(IsDBNull(row("acquisition_date")), "", CDate(row("acquisition_date")).ToString("yyyy-MM-dd")),
                        warrantyExp,
                        If(IsDBNull(row("assigned_employee")), "", row("assigned_employee").ToString()),
                        If(IsDBNull(row("assigned_department")), "", row("assigned_department").ToString()),
                        If(IsDBNull(row("location")), "", row("location").ToString()),
                        If(IsDBNull(row("status")), "", row("status").ToString())
                    )
                Next
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
            If selectedRow.Cells("propertyID").Value IsNot Nothing Then
                Dim propertyIDStr As String = selectedRow.Cells("propertyID").Value.ToString()
                If Integer.TryParse(propertyIDStr, selectedPropertyID) Then
                    ' Row selected, enable Edit and Delete buttons
                End If
            End If
        End If
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        ' Reload data with filters
        LoadPropertiesData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddProperty())
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property to edit.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = propertyManagementGrid.SelectedRows(0)

        ' Validate property ID
        Dim propertyID As Integer
        If Not Integer.TryParse(row.Cells("propertyID").Value.ToString(), propertyID) Then
            MessageBox.Show("Invalid Property ID.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Create the EDIT USER CONTROL
        Dim editForm As New EditPropertyManagement()

        ' Load selected data into edit form
        editForm.LoadPropertyData(
            propertyID,
            row.Cells("propertyName").Value.ToString(),
            row.Cells("category").Value.ToString(),
            row.Cells("serialNumber").Value.ToString(),
            row.Cells("supplier").Value.ToString(),
            row.Cells("condition_status").Value.ToString(),
            Decimal.Parse(row.Cells("cost").Value.ToString()),
            ParseDateCell(row.Cells("datePurchased").Value),
            ParseDateCell(row.Cells("warrantyExpiration").Value, Date.Today.AddYears(1)),
            row.Cells("assignedEmployee").Value.ToString(),
            row.Cells("assignedDepartment").Value.ToString(),
            row.Cells("location").Value.ToString(),
            row.Cells("status").Value.ToString(),
            ParseDateCell(GetCellValueOrNothing(row, "dateCreated"), Date.Now),
            ParseDateCell(GetCellValueOrNothing(row, "dateUpdated"), Date.Now)
        )

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
        If propertyManagementGrid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a property to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = propertyManagementGrid.SelectedRows(0)
        If selectedRow.Cells("propertyID").Value Is Nothing Then
            MessageBox.Show("Invalid property selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim propertyIDStr As String = selectedRow.Cells("propertyID").Value.ToString()
        Dim propertyName As String = If(selectedRow.Cells("propertyName").Value IsNot Nothing, selectedRow.Cells("propertyName").Value.ToString(), "Unknown")

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

    Private Sub propertyManagementGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellContentClick

    End Sub
End Class
