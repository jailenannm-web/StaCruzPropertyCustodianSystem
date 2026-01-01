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

    ' The DataGridView column fields are defined in the designer partial class.
    ' Removed duplicate declarations here to avoid BC30260 duplicate definition errors.

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

        ' Set column alignment - headers are already set in Designer
        For Each col As DataGridViewColumn In admin_deptmanagement.Columns
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        ' Note: Column widths are set in Designer for better control
        ' AutoSizeColumnsMode is set to None to respect Designer column widths
        admin_deptmanagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        ' Initialize filter dropdowns
        InitializeFilters()

        ' Load data from database
        LoadDepartmentsData()

        ' Wire up event handlers
        AddHandler admin_deptmanagement.SelectionChanged, AddressOf admin_deptmanagement_SelectionChanged

        ' Wire up btnEdit handler dynamically if control exists (avoids WithEvents requirement)
        Try
            Dim foundEdit() As Control = Me.Controls.Find("btnEdit", True)
            If foundEdit IsNot Nothing AndAlso foundEdit.Length > 0 Then
                Dim ctrl As Control = foundEdit(0)
                RemoveHandler ctrl.Click, AddressOf btnEdit_Click
                AddHandler ctrl.Click, AddressOf btnEdit_Click
            End If
        Catch
            ' Ignore if control not found or cannot attach
        End Try
    End Sub

    Private Sub InitializeFilters()
        ' Populate status filter - match database enum values (Active, Inactive)
        pm_cbobx_status.Items.Clear()
        pm_cbobx_status.Items.Add("All Status")
        pm_cbobx_status.Items.AddRange(New String() {"Active", "Inactive"})
        pm_cbobx_status.SelectedIndex = 0

        ' Categories filter not needed for departments, but keep for consistency
        pm_cbobx_categ.Items.Clear()
        pm_cbobx_categ.Items.Add("All")
        pm_cbobx_categ.SelectedIndex = 0

        ' Wire up filter change events
        AddHandler pm_cbobx_status.SelectedIndexChanged, AddressOf Filter_Changed
        AddHandler pm_cbobx_categ.SelectedIndexChanged, AddressOf Filter_Changed
    End Sub

    Public Sub LoadDepartmentsData()
        Try
            admin_deptmanagement.Rows.Clear()
            Dim dt As DataTable = modDB.GetAllDepartments()
            originalData = dt.Copy()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    ' Use safe column access - Match actual database camelCase column names
                    ' Designer column order: departmentId, departmentName, headOfDepartment, email, contactNumber, location, building, floorNumber, shortName, officeCode, description, totalProperties, totalSupplies, status
                    Dim deptID As String = If(row.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(row("departmentId")), row("departmentId").ToString(), "")
                    Dim deptName As String = If(row.Table.Columns.Contains("departmentName") AndAlso Not IsDBNull(row("departmentName")), row("departmentName").ToString(), "")
                    Dim headOfDept As String = If(row.Table.Columns.Contains("headOfDepartment") AndAlso Not IsDBNull(row("headOfDepartment")), row("headOfDepartment").ToString(), "")
                    Dim emailVal As String = If(row.Table.Columns.Contains("email") AndAlso Not IsDBNull(row("email")), row("email").ToString(), "")
                    Dim contactNum As String = If(row.Table.Columns.Contains("contactNumber") AndAlso Not IsDBNull(row("contactNumber")), row("contactNumber").ToString(), "")
                    Dim locationVal As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), "")
                    Dim buildingVal As String = If(row.Table.Columns.Contains("building") AndAlso Not IsDBNull(row("building")), row("building").ToString(), "")
                    Dim floorNum As String = If(row.Table.Columns.Contains("floorNumber") AndAlso Not IsDBNull(row("floorNumber")), row("floorNumber").ToString(), "")
                    Dim shortName As String = If(row.Table.Columns.Contains("shortName") AndAlso Not IsDBNull(row("shortName")), row("shortName").ToString(), "")
                    Dim officeCode As String = If(row.Table.Columns.Contains("officeCode") AndAlso Not IsDBNull(row("officeCode")), row("officeCode").ToString(), "")
                    Dim descriptionVal As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString(), "")
                    Dim totalProps As String = If(row.Table.Columns.Contains("totalProperties") AndAlso Not IsDBNull(row("totalProperties")), row("totalProperties").ToString(), "0")
                    Dim totalSupplies As String = If(row.Table.Columns.Contains("totalSupplies") AndAlso Not IsDBNull(row("totalSupplies")), row("totalSupplies").ToString(), "0")
                    Dim statusVal As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), "Active")

                    ' Add row matching Designer column order exactly
                    admin_deptmanagement.Rows.Add(deptID, deptName, headOfDept, emailVal, contactNum, locationVal, buildingVal, floorNum, shortName, officeCode, descriptionVal, totalProps, totalSupplies, statusVal)
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

        Dim statusFilter As String = If(pm_cbobx_status.SelectedItem IsNot Nothing, pm_cbobx_status.SelectedItem.ToString(), "All Status")
        If statusFilter = "All Status" Then
            LoadDepartmentsData()
            Return
        End If

        Try
            admin_deptmanagement.Rows.Clear()
            Dim filteredRows = originalData.AsEnumerable().Where(Function(row)
                                                                     If Not row.Table.Columns.Contains("status") Then Return False
                                                                     Dim status As String = If(IsDBNull(row("status")), "", row("status").ToString())
                                                                     ' Case-insensitive comparison
                                                                     Return String.Equals(status, statusFilter, StringComparison.OrdinalIgnoreCase)
                                                                 End Function)

            ' Sort by createdAt DESC
            Dim sortedFiltered = filteredRows.OrderByDescending(Function(r)
                                                                    If r.Table.Columns.Contains("createdAt") AndAlso Not IsDBNull(r("createdAt")) Then
                                                                        Return Convert.ToDateTime(r("createdAt"))
                                                                    End If
                                                                    Return Date.MinValue
                                                                End Function)

            For Each row As DataRow In sortedFiltered
                ' Use safe column access - Match Designer column order with camelCase
                Dim deptID As String = If(row.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(row("departmentId")), row("departmentId").ToString(), "")
                Dim deptName As String = If(row.Table.Columns.Contains("departmentName") AndAlso Not IsDBNull(row("departmentName")), row("departmentName").ToString(), "")
                Dim headOfDept As String = If(row.Table.Columns.Contains("headOfDepartment") AndAlso Not IsDBNull(row("headOfDepartment")), row("headOfDepartment").ToString(), "")
                Dim emailVal As String = If(row.Table.Columns.Contains("email") AndAlso Not IsDBNull(row("email")), row("email").ToString(), "")
                Dim contactNum As String = If(row.Table.Columns.Contains("contactNumber") AndAlso Not IsDBNull(row("contactNumber")), row("contactNumber").ToString(), "")
                Dim locationVal As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), "")
                Dim buildingVal As String = If(row.Table.Columns.Contains("building") AndAlso Not IsDBNull(row("building")), row("building").ToString(), "")
                Dim floorNum As String = If(row.Table.Columns.Contains("floorNumber") AndAlso Not IsDBNull(row("floorNumber")), row("floorNumber").ToString(), "")
                Dim shortName As String = If(row.Table.Columns.Contains("shortName") AndAlso Not IsDBNull(row("shortName")), row("shortName").ToString(), "")
                Dim officeCode As String = If(row.Table.Columns.Contains("officeCode") AndAlso Not IsDBNull(row("officeCode")), row("officeCode").ToString(), "")
                Dim descriptionVal As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString(), "")
                Dim totalProps As String = If(row.Table.Columns.Contains("totalProperties") AndAlso Not IsDBNull(row("totalProperties")), row("totalProperties").ToString(), "0")
                Dim totalSupplies As String = If(row.Table.Columns.Contains("totalSupplies") AndAlso Not IsDBNull(row("totalSupplies")), row("totalSupplies").ToString(), "0")
                Dim statusVal As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), "Active")

                admin_deptmanagement.Rows.Add(deptID, deptName, headOfDept, emailVal, contactNum, locationVal,
                                             buildingVal, floorNum, shortName, officeCode, descriptionVal,
                                             totalProps, totalSupplies, statusVal)
            Next
            ' Update total count
            If ttldepartmentmanagement IsNot Nothing Then
                ttldepartmentmanagement.Text = sortedFiltered.Count().ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error filtering departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] ApplyStatusFilter Error: " & ex.Message)
        End Try
    End Sub

    Private Sub admin_deptmanagement_SelectionChanged(sender As Object, e As EventArgs)
        If admin_deptmanagement.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = admin_deptmanagement.SelectedRows(0)
            ' Get department ID from the first column (index 0 - departmentId)
            ' Column order: departmentId (0), departmentName (1), headOfDepartment (2), email (3), contactNumber (4), 
            ' location (5), building (6), floorNumber (7), shortName (8), officeCode (9), description (10), 
            ' totalProperties (11), totalSupplies (12), status (13)
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
        ' Apply search filter with current search text and filters
        Dim searchText As String = ""
        If departmentmanagementsearchbar IsNot Nothing Then
            searchText = departmentmanagementsearchbar.Text
        End If
        ApplySearchFilter(searchText)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_DepartmentManagement - btnAdd_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_DepartmentManagement - IsSuperAdmin: " & SessionContext.IsSuperAdmin())
        System.Diagnostics.Debug.WriteLine("[v0] UC_DepartmentManagement - ParentForm: " & If(Me.ParentForm IsNot Nothing, Me.ParentForm.GetType().Name, "NULL"))
        
        ' Check SADashboard first (parent class)
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            saDashboard.LoadUserControl(New AddDepartment())
            System.Diagnostics.Debug.WriteLine("[v0] UC_DepartmentManagement - AddDepartment loaded into SADashboard")
            Return
        End If
        
        Dim superAdminDashboard = TryCast(Me.ParentForm, SuperAdminDashboard)
        If superAdminDashboard IsNot Nothing Then
            superAdminDashboard.LoadUserControl(New AddDepartment())
            Return
        End If

        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddDepartment())
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_DepartmentManagement - btnEdit_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_DepartmentManagement - Selected Rows: " & admin_deptmanagement.SelectedRows.Count)
        
        If admin_deptmanagement.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a department to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = admin_deptmanagement.SelectedRows(0)
        ' Column order: departmentId (0), departmentName (1), headOfDepartment (2), email (3), contactNumber (4), 
        ' location (5), building (6), floorNumber (7), shortName (8), officeCode (9), description (10), 
        ' totalProperties (11), totalSupplies (12), status (13)
        If selectedRow.Cells.Count < 14 Then
            MessageBox.Show("Invalid department selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim deptIDValue As Object = selectedRow.Cells(0).Value ' departmentId is first column
        If deptIDValue Is Nothing Then
            MessageBox.Show("Invalid department selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim departmentID As Integer
        If Not Integer.TryParse(deptIDValue.ToString(), departmentID) Then
            MessageBox.Show("Invalid department ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get department data from database - use GetAllDepartments and filter
        Dim allDepts As DataTable = modDB.GetAllDepartments()
        Dim deptData As DataRow = Nothing
        If allDepts IsNot Nothing Then
            ' Use LINQ to find matching department
            Dim matchingRows = allDepts.AsEnumerable().Where(Function(r)
                                                                 If r.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(r("departmentId")) Then
                                                                     Dim id As Integer = 0
                                                                     If Integer.TryParse(r("departmentId").ToString(), id) Then
                                                                         Return id = departmentID
                                                                     End If
                                                                 End If
                                                                 Return False
                                                             End Function)

            Dim rows() As DataRow = matchingRows.ToArray()
            If rows.Length > 0 Then
                deptData = rows(0)
            End If
        End If

        If deptData Is Nothing Then
            MessageBox.Show("Department not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open EditDepartment Form directly
        Try
            Dim editForm As New EditDepartment()
            editForm.LoadDepartmentData(departmentID, deptData)

            ' Check SADashboard first (parent class)
            Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
            If saDashboard IsNot Nothing Then
                saDashboard.LoadUserControl(editForm)
                System.Diagnostics.Debug.WriteLine("[v0] UC_DepartmentManagement - EditDepartment loaded into SADashboard")
                Return
            End If
            
            Dim superAdminDashboard = TryCast(Me.ParentForm, SuperAdminDashboard)
            If superAdminDashboard IsNot Nothing Then
                superAdminDashboard.LoadUserControl(editForm)
                Return
            End If

            Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
            If parentDashboard IsNot Nothing Then
                parentDashboard.LoadUserControl(editForm)
            Else
                MessageBox.Show("Unable to open EditDepartment screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening edit form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] btnEdit_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' DEBUG: Confirm button click event fires
        System.Diagnostics.Debug.WriteLine("[v0] UC_DepartmentManagement - btnDelete_Click FIRED")
        System.Diagnostics.Debug.WriteLine("[v0] UC_DepartmentManagement - Selected Rows: " & admin_deptmanagement.SelectedRows.Count)
        
        If admin_deptmanagement.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a department to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = admin_deptmanagement.SelectedRows(0)
        ' Column order: departmentId (0), departmentName (1), headOfDepartment (2), email (3), contactNumber (4), 
        ' location (5), building (6), floorNumber (7), shortName (8), officeCode (9), description (10), 
        ' totalProperties (11), totalSupplies (12), status (13)
        If selectedRow.Cells.Count < 14 Then
            MessageBox.Show("Invalid department selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim deptIDValue As Object = Nothing
        Dim deptNameValue As Object = Nothing

        Try
            ' Use column index to avoid column name issues
            deptIDValue = selectedRow.Cells(0).Value  ' departmentId is first column
            deptNameValue = selectedRow.Cells(1).Value ' departmentName is second column
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

        ' DELETE should permanently remove - show strong warning
        Dim result As DialogResult = MessageBox.Show(
            "⚠️ WARNING: PERMANENT DELETION ⚠️" & Environment.NewLine & Environment.NewLine &
            "Are you sure you want to PERMANENTLY DELETE this department?" & Environment.NewLine &
            "Department: " & departmentName & Environment.NewLine &
            "ID: " & departmentID.ToString() & Environment.NewLine & Environment.NewLine &
            "This will COMPLETELY REMOVE all department data from the database!" & Environment.NewLine &
            "This action CANNOT BE UNDONE!" & Environment.NewLine & Environment.NewLine &
            "💡 TIP: To temporarily disable a department instead, use Edit → Change Status to Inactive.",
            "⚠️ Confirm Permanent Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            Try
                Dim success As Boolean = modDB.DeleteDepartment(departmentID)
                If success Then
                    ' Clear the grid and reload to ensure deletion is reflected
                    admin_deptmanagement.Rows.Clear()
                    originalData = Nothing
                    LoadDepartmentsData() ' Refresh table
                    MessageBox.Show("Department deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to delete department. It may be in use or already deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                                                                     Dim statusVal As String = If(IsDBNull(row("status")), String.Empty, row("status").ToString())
                                                                     If Not String.Equals(statusVal, statusFilter, StringComparison.OrdinalIgnoreCase) Then Return False
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

            ' Sort by createdAt DESC
            Dim sortedFiltered = filtered.OrderByDescending(Function(r)
                                                                If r.Table.Columns.Contains("createdAt") AndAlso Not IsDBNull(r("createdAt")) Then
                                                                    Return Convert.ToDateTime(r("createdAt"))
                                                                End If
                                                                Return Date.MinValue
                                                            End Function)

            For Each row As DataRow In sortedFiltered
                Dim deptID As String = If(row.Table.Columns.Contains("departmentId") AndAlso Not IsDBNull(row("departmentId")), row("departmentId").ToString(), "")
                Dim deptName As String = If(row.Table.Columns.Contains("departmentName") AndAlso Not IsDBNull(row("departmentName")), row("departmentName").ToString(), "")
                Dim headOfDept As String = If(row.Table.Columns.Contains("headOfDepartment") AndAlso Not IsDBNull(row("headOfDepartment")), row("headOfDepartment").ToString(), "")
                Dim emailVal As String = If(row.Table.Columns.Contains("email") AndAlso Not IsDBNull(row("email")), row("email").ToString(), "")
                Dim contactNum As String = If(row.Table.Columns.Contains("contactNumber") AndAlso Not IsDBNull(row("contactNumber")), row("contactNumber").ToString(), "")
                Dim locationVal As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), "")
                Dim buildingVal As String = If(row.Table.Columns.Contains("building") AndAlso Not IsDBNull(row("building")), row("building").ToString(), "")
                Dim floorNum As String = If(row.Table.Columns.Contains("floorNumber") AndAlso Not IsDBNull(row("floorNumber")), row("floorNumber").ToString(), "")
                Dim shortName As String = If(row.Table.Columns.Contains("shortName") AndAlso Not IsDBNull(row("shortName")), row("shortName").ToString(), "")
                Dim officeCode As String = If(row.Table.Columns.Contains("officeCode") AndAlso Not IsDBNull(row("officeCode")), row("officeCode").ToString(), "")
                Dim descriptionVal As String = If(row.Table.Columns.Contains("description") AndAlso Not IsDBNull(row("description")), row("description").ToString(), "")
                Dim totalProps As String = If(row.Table.Columns.Contains("totalProperties") AndAlso Not IsDBNull(row("totalProperties")), row("totalProperties").ToString(), "0")
                Dim totalSupplies As String = If(row.Table.Columns.Contains("totalSupplies") AndAlso Not IsDBNull(row("totalSupplies")), row("totalSupplies").ToString(), "0")
                Dim statusVal As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), "Active")

                admin_deptmanagement.Rows.Add(deptID, deptName, headOfDept, emailVal, contactNum, locationVal,
                                             buildingVal, floorNum, shortName, officeCode, descriptionVal,
                                             totalProps, totalSupplies, statusVal)
            Next

            If ttldepartmentmanagement IsNot Nothing Then
                ttldepartmentmanagement.Text = sortedFiltered.Count().ToString()
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
