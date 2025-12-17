Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Linq

Public Class UC_DepartmentManagement
    Inherits UserControl

    Private originalData As DataTable
    Private selectedDepartmentID As Integer = -1
    Private isSearching As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub UC_DepartmentManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' General settings
        admin_deptmanagement.ReadOnly = True
        admin_deptmanagement.AllowUserToAddRows = False
        admin_deptmanagement.AllowUserToDeleteRows = False
        admin_deptmanagement.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        admin_deptmanagement.MultiSelect = False
        admin_deptmanagement.RowTemplate.Height = 30
        admin_deptmanagement.EnableHeadersVisualStyles = False

        ' Font & colors
        admin_deptmanagement.DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        admin_deptmanagement.DefaultCellStyle.BackColor = Color.White
        admin_deptmanagement.DefaultCellStyle.ForeColor = Color.Black
        admin_deptmanagement.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        ' Header styling
        admin_deptmanagement.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        admin_deptmanagement.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
        admin_deptmanagement.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        admin_deptmanagement.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Column alignment
        For Each col As DataGridViewColumn In admin_deptmanagement.Columns
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        ' Auto size
        admin_deptmanagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Initialize filter dropdowns
        InitializeFilters()

        ' Load data from database
        LoadDepartmentsData()

        ' Wire up event handlers
        AddHandler admin_deptmanagement.SelectionChanged, AddressOf admin_deptmanagement_SelectionChanged
    End Sub

    Private Sub InitializeFilters()
        ' Populate status filter
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"active", "inactive"})
        pm_cbobx_status.SelectedIndex = 0

        ' Categories filter not needed for departments, but keep for consistency
        pm_cbobx_categ.Items.Clear()
        pm_cbobx_categ.Items.Add("All")
        pm_cbobx_categ.SelectedIndex = 0

        ' Wire up filter change events
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
    End Sub

    Public Sub LoadDepartmentsData()
        Try
            admin_deptmanagement.Rows.Clear()
            Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
            originalData = dt.Copy()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    ' Use safe column access - Match actual database camelCase column names
                    Dim deptID As String = If(row.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(row("departmentId")), row("departmentId").ToString(), "")
                    Dim headOfDept As String = If(row.Table.Columns.Contains("headOfDepartment") AndAlso Not IsDBNull(row("headOfDepartment")), row("headOfDepartment").ToString(), "")
                    Dim contactNum As String = If(row.Table.Columns.Contains("contactNumber") AndAlso Not IsDBNull(row("contactNumber")), row("contactNumber").ToString(), "")
                    Dim floorNum As String = If(row.Table.Columns.Contains("floorNumber") AndAlso Not IsDBNull(row("floorNumber")), row("floorNumber").ToString(), "")
                    Dim shortName As String = If(row.Table.Columns.Contains("shortName") AndAlso Not IsDBNull(row("shortName")), row("shortName").ToString(), "")
                    Dim officeCode As String = If(row.Table.Columns.Contains("officeCode") AndAlso Not IsDBNull(row("officeCode")), row("officeCode").ToString(), "")
                    Dim totalProps As String = If(row.Table.Columns.Contains("totalProperties") AndAlso Not IsDBNull(row("totalProperties")), row("totalProperties").ToString(), "0")
                    Dim totalSupplies As String = If(row.Table.Columns.Contains("totalSupplies") AndAlso Not IsDBNull(row("totalSupplies")), row("totalSupplies").ToString(), "0")
                    Dim createdAt As String = If(row.Table.Columns.Contains("createdAt") AndAlso Not IsDBNull(row("createdAt")), Convert.ToDateTime(row("createdAt")).ToString("yyyy-MM-dd"), "")
                    Dim updatedAt As String = If(row.Table.Columns.Contains("updatedAt") AndAlso Not IsDBNull(row("updatedAt")), Convert.ToDateTime(row("updatedAt")).ToString("yyyy-MM-dd"), "")
                    Dim deptName As String = If(row.Table.Columns.Contains("departmentName") AndAlso Not IsDBNull(row("departmentName")), row("departmentName").ToString(), "")

                    ' Add row matching Designer column order: departmentId, headOfDepartment, contactNumber, floorNumber, shortName, officeCode, totalProperties, totalSupplies, createdAt, updatedAt, departmentName
                    admin_deptmanagement.Rows.Add(deptID, headOfDept, contactNum, floorNum, shortName, officeCode, totalProps, totalSupplies, createdAt, updatedAt, deptName)
                Next
                ' Update total count
                If ttldepartmentmanagement IsNot Nothing Then
                    ttldepartmentmanagement.Text = dt.Rows.Count.ToString()
                End If
            End If

            ' Apply status filter if selected
            If pm_cbobx_status.SelectedIndex > 0 Then
                ApplyStatusFilter()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyStatusFilter()
        If originalData Is Nothing Then Return

        Dim statusFilter As String = pm_cbobx_status.SelectedItem.ToString()
        If statusFilter = "All Status" Then
            LoadDepartmentsData()
            Return
        End If

        Try
            admin_deptmanagement.Rows.Clear()
            Dim filteredRows = originalData.AsEnumerable().Where(Function(row)
                                                                     If Not row.Table.Columns.Contains("status") Then Return False
                                                                     Dim status As String = If(IsDBNull(row("status")), "", row("status").ToString().ToLower())
                                                                     Return status = statusFilter.ToLower()
                                                                 End Function)

            For Each row As DataRow In filteredRows
                ' Use safe column access - Match Designer column order
                Dim deptID As String = If(row.Table.Columns.Contains("department_id") AndAlso Not IsDBNull(row("department_id")), row("department_id").ToString(), "")
                Dim headOfDept As String = If(row.Table.Columns.Contains("head_of_department") AndAlso Not IsDBNull(row("head_of_department")), row("head_of_department").ToString(), "")
                Dim contactNum As String = If(row.Table.Columns.Contains("contact_number") AndAlso Not IsDBNull(row("contact_number")), row("contact_number").ToString(), "")
                Dim floorNum As String = If(row.Table.Columns.Contains("floor_number") AndAlso Not IsDBNull(row("floor_number")), row("floor_number").ToString(), "")
                Dim shortName As String = If(row.Table.Columns.Contains("short_name") AndAlso Not IsDBNull(row("short_name")), row("short_name").ToString(), "")
                Dim officeCode As String = If(row.Table.Columns.Contains("office_code") AndAlso Not IsDBNull(row("office_code")), row("office_code").ToString(), "")
                Dim totalProps As String = If(row.Table.Columns.Contains("total_properties") AndAlso Not IsDBNull(row("total_properties")), row("total_properties").ToString(), "0")
                Dim totalSupplies As String = If(row.Table.Columns.Contains("total_supplies") AndAlso Not IsDBNull(row("total_supplies")), row("total_supplies").ToString(), "0")
                Dim createdAt As String = If(row.Table.Columns.Contains("created_at") AndAlso Not IsDBNull(row("created_at")), Convert.ToDateTime(row("created_at")).ToString("yyyy-MM-dd"), "")
                Dim updatedAt As String = If(row.Table.Columns.Contains("updated_at") AndAlso Not IsDBNull(row("updated_at")), Convert.ToDateTime(row("updated_at")).ToString("yyyy-MM-dd"), "")
                Dim deptName As String = If(row.Table.Columns.Contains("department_name") AndAlso Not IsDBNull(row("department_name")), row("department_name").ToString(), "")

                admin_deptmanagement.Rows.Add(deptID, headOfDept, contactNum, floorNum, shortName, officeCode, totalProps, totalSupplies, createdAt, updatedAt, deptName)
            Next
            ' Update total count
            If ttldepartmentmanagement IsNot Nothing Then
                ttldepartmentmanagement.Text = filteredRows.Count().ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error filtering departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub admin_deptmanagement_SelectionChanged(sender As Object, e As EventArgs)
        If admin_deptmanagement.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = admin_deptmanagement.SelectedRows(0)
            ' Get department ID from the first column (index 0 - departmentId)
            ' Column order: departmentId (0), headOfDepartment (1), contactNumber (2), floorNumber (3), shortName (4), officeCode (5), totalProperties (6), totalSupplies (7), createdAt (8), updatedAt (9), departmentName (10)
            Try
                If selectedRow.Cells.Count > 0 AndAlso selectedRow.Cells(0).Value IsNot Nothing Then
                    Dim departmentIDStr As String = selectedRow.Cells(0).Value.ToString()
                    If Integer.TryParse(departmentIDStr, selectedDepartmentID) Then
                        ' Row selected, enable Edit and Delete buttons
                    End If
                End If
            Catch ex As Exception
                ' Handle any errors silently
                System.Diagnostics.Debug.WriteLine("SelectionChanged Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        ' Reload data with filters
        LoadDepartmentsData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddDepartment())
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        ' Your edit logic remains here (unchanged)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If admin_deptmanagement.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a department to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = admin_deptmanagement.SelectedRows(0)
        ' Column order: departmentId (0), headOfDepartment (1), contactNumber (2), floorNumber (3), shortName (4), officeCode (5), totalProperties (6), totalSupplies (7), createdAt (8), updatedAt (9), departmentName (10)
        If selectedRow.Cells.Count < 11 Then
            MessageBox.Show("Invalid department selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim deptIDValue As Object = Nothing
        Dim deptNameValue As Object = Nothing

        Try
            ' Use column index to avoid column name issues
            deptIDValue = selectedRow.Cells(0).Value  ' departmentId is first column
            deptNameValue = selectedRow.Cells(10).Value ' departmentName is last column
        Catch ex As Exception
            MessageBox.Show("Error accessing row data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If deptIDValue Is Nothing Then
            MessageBox.Show("Invalid department selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim departmentIDStr As String = deptIDValue.ToString()
        Dim departmentName As String = If(deptNameValue IsNot Nothing, deptNameValue.ToString(), "Unknown")

        Dim departmentID As Integer
        If Not Integer.TryParse(departmentIDStr, departmentID) Then
            MessageBox.Show("Invalid department ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Confirmation dialog
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete department '" & departmentName & "' (ID: " & departmentID.ToString() & ")?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            Try
                Dim success As Boolean = DatabaseConnection.DeleteDepartment(departmentID)
                If success Then
                    LoadDepartmentsData() ' Refresh table
                    MessageBox.Show("Department deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub admin_deptmanagement_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles admin_deptmanagement.CellContentClick

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs)
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            Dim addForm As New ViewDepartmentSupply()
            parentDashboard.LoadUserControl(addForm)
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    ' Apply a combined search + status filter and rebind the DataGrid without duplicating rows
    Private Sub ApplySearchFilter(searchText As String)
        If originalData Is Nothing Then Return
        If isSearching Then Return
        isSearching = True

        Try
            Dim searchLower As String = If(String.IsNullOrWhiteSpace(searchText), String.Empty, searchText.Trim().ToLower())
            Dim statusFilter As String = "All Status"
            If pm_cbobx_status.SelectedItem IsNot Nothing Then
                statusFilter = pm_cbobx_status.SelectedItem.ToString()
            End If

            Dim filtered = originalData.AsEnumerable().Where(Function(row)
                                                                 ' If status column exists and a specific status is selected, enforce it
                                                                 If statusFilter <> "All Status" Then
                                                                     If Not row.Table.Columns.Contains("status") Then Return False
                                                                     Dim statusVal As String = If(IsDBNull(row("status")), String.Empty, row("status").ToString().ToLower())
                                                                     If statusVal <> statusFilter.ToLower() Then Return False
                                                                 End If

                                                                 ' If no search text provided, include this row (status already checked)
                                                                 If String.IsNullOrEmpty(searchLower) Then Return True

                                                                 ' Check searchable fields: departmentName, headOfDepartment, officeCode
                                                                 Dim nameVal As String = If(row.Table.Columns.Contains("departmentName") AndAlso Not IsDBNull(row("departmentName")), row("departmentName").ToString().ToLower(), String.Empty)
                                                                 Dim headVal As String = If(row.Table.Columns.Contains("headOfDepartment") AndAlso Not IsDBNull(row("headOfDepartment")), row("headOfDepartment").ToString().ToLower(), String.Empty)
                                                                 Dim codeVal As String = If(row.Table.Columns.Contains("officeCode") AndAlso Not IsDBNull(row("officeCode")), row("officeCode").ToString().ToLower(), String.Empty)

                                                                 Return nameVal.Contains(searchLower) OrElse headVal.Contains(searchLower) OrElse codeVal.Contains(searchLower)
                                                             End Function)

            admin_deptmanagement.Rows.Clear()

            For Each row As DataRow In filtered
                Dim deptID As String = If(row.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(row("departmentId")), row("departmentId").ToString(), "")
                Dim headOfDept As String = If(row.Table.Columns.Contains("headOfDepartment") AndAlso Not IsDBNull(row("headOfDepartment")), row("headOfDepartment").ToString(), "")
                Dim contactNum As String = If(row.Table.Columns.Contains("contactNumber") AndAlso Not IsDBNull(row("contactNumber")), row("contactNumber").ToString(), "")
                Dim floorNum As String = If(row.Table.Columns.Contains("floorNumber") AndAlso Not IsDBNull(row("floorNumber")), row("floorNumber").ToString(), "")
                Dim shortName As String = If(row.Table.Columns.Contains("shortName") AndAlso Not IsDBNull(row("shortName")), row("shortName").ToString(), "")
                Dim officeCode As String = If(row.Table.Columns.Contains("officeCode") AndAlso Not IsDBNull(row("officeCode")), row("officeCode").ToString(), "")
                Dim totalProps As String = If(row.Table.Columns.Contains("totalProperties") AndAlso Not IsDBNull(row("totalProperties")), row("totalProperties").ToString(), "0")
                Dim totalSupplies As String = If(row.Table.Columns.Contains("totalSupplies") AndAlso Not IsDBNull(row("totalSupplies")), row("totalSupplies").ToString(), "0")
                Dim createdAt As String = If(row.Table.Columns.Contains("createdAt") AndAlso Not IsDBNull(row("createdAt")), Convert.ToDateTime(row("createdAt")).ToString("yyyy-MM-dd"), "")
                Dim updatedAt As String = If(row.Table.Columns.Contains("updatedAt") AndAlso Not IsDBNull(row("updatedAt")), Convert.ToDateTime(row("updatedAt")).ToString("yyyy-MM-dd"), "")
                Dim deptName As String = If(row.Table.Columns.Contains("departmentName") AndAlso Not IsDBNull(row("departmentName")), row("departmentName").ToString(), "")

                admin_deptmanagement.Rows.Add(deptID, headOfDept, contactNum, floorNum, shortName, officeCode, totalProps, totalSupplies, createdAt, updatedAt, deptName)
            Next

            If ttldepartmentmanagement IsNot Nothing Then
                ttldepartmentmanagement.Text = filtered.Count().ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error searching departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isSearching = False
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles departmentmanagementsearchbar.TextChanged
        ' Real-time search: filter the DataGrid based on entered text and selected status
        ApplySearchFilter(departmentmanagementsearchbar.Text)
    End Sub
End Class
