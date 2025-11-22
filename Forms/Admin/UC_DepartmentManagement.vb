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

        ' Initialize search placeholder
        AddHandler pm_txtbox_search.GotFocus, AddressOf SearchTextBox_GotFocus
        AddHandler pm_txtbox_search.LostFocus, AddressOf SearchTextBox_LostFocus
        pm_txtbox_search.Text = "Search"

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

    Private Sub SearchTextBox_GotFocus(sender As Object, e As EventArgs)
        If pm_txtbox_search.Text = "Search" Then
            pm_txtbox_search.Text = ""
            pm_txtbox_search.ForeColor = Color.White
        End If
    End Sub

    Private Sub SearchTextBox_LostFocus(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(pm_txtbox_search.Text) Then
            pm_txtbox_search.Text = "Search"
            pm_txtbox_search.ForeColor = Color.White
        End If
    End Sub

    Public Sub LoadDepartmentsData()
        Try
            admin_deptmanagement.Rows.Clear()
            Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
            originalData = dt.Copy()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    ' Display all 15 attributes
                    admin_deptmanagement.Rows.Add(
                        If(IsDBNull(row("department_id")), "", row("department_id").ToString()),
                        If(IsDBNull(row("department_name")), "", row("department_name").ToString()),
                        If(IsDBNull(row("head_of_department")), "", row("head_of_department").ToString()),
                        If(IsDBNull(row("contact_number")), "", row("contact_number").ToString()),
                        If(IsDBNull(row("email")), "", row("email").ToString()),
                        If(IsDBNull(row("location")), "", row("location").ToString()),
                        If(IsDBNull(row("no_of_employees")), "0", row("no_of_employees").ToString()),
                        If(IsDBNull(row("department_code")), "", row("department_code").ToString()),
                        If(IsDBNull(row("office_hours")), "", row("office_hours").ToString()),
                        If(IsDBNull(row("established_date")), "", If(IsDBNull(row("established_date")), "", CDate(row("established_date")).ToString("yyyy-MM-dd"))),
                        If(IsDBNull(row("parent_department_id")), "", If(IsDBNull(row("parent_department_id")), "", row("parent_department_id").ToString())),
                        If(IsDBNull(row("status")), "", row("status").ToString()),
                        If(IsDBNull(row("budget_allocation")), "0.00", Format(CDec(row("budget_allocation")), "0.00")),
                        If(IsDBNull(row("created_at")), "", If(IsDBNull(row("created_at")), "", CDate(row("created_at")).ToString("yyyy-MM-dd HH:mm"))),
                        If(IsDBNull(row("updated_at")), "", If(IsDBNull(row("updated_at")), "", CDate(row("updated_at")).ToString("yyyy-MM-dd HH:mm")))
                    )
                Next
                System.Diagnostics.Debug.WriteLine("[v0] Department Management - Loaded " & dt.Rows.Count & " departments")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Department Management - No departments found")
            End If

            ' Apply status filter if selected
            If pm_cbobx_status.SelectedIndex > 0 Then
                ApplyStatusFilter()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Load Departments Error: " & ex.Message & vbCrLf & ex.StackTrace)
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
                                                                     Dim status As String = If(IsDBNull(row("status")), "", row("status").ToString().ToLower())
                                                                     Return status = statusFilter.ToLower()
                                                                 End Function)

            For Each row As DataRow In filteredRows
                admin_deptmanagement.Rows.Add(
                    If(IsDBNull(row("department_id")), "", row("department_id").ToString()),
                    If(IsDBNull(row("department_name")), "", row("department_name").ToString()),
                    If(IsDBNull(row("head_of_department")), "", row("head_of_department").ToString()),
                    If(IsDBNull(row("contact_number")), "", row("contact_number").ToString()),
                    If(IsDBNull(row("email")), "", row("email").ToString()),
                    If(IsDBNull(row("location")), "", row("location").ToString()),
                    If(IsDBNull(row("no_of_employees")), "0", row("no_of_employees").ToString()),
                    If(IsDBNull(row("department_code")), "", row("department_code").ToString()),
                    If(IsDBNull(row("office_hours")), "", row("office_hours").ToString()),
                    If(IsDBNull(row("established_date")), "", If(IsDBNull(row("established_date")), "", CDate(row("established_date")).ToString("yyyy-MM-dd"))),
                    If(IsDBNull(row("parent_department_id")), "", If(IsDBNull(row("parent_department_id")), "", row("parent_department_id").ToString())),
                    If(IsDBNull(row("status")), "", row("status").ToString()),
                    If(IsDBNull(row("budget_allocation")), "0.00", Format(CDec(row("budget_allocation")), "0.00")),
                    If(IsDBNull(row("created_at")), "", If(IsDBNull(row("created_at")), "", CDate(row("created_at")).ToString("yyyy-MM-dd HH:mm"))),
                    If(IsDBNull(row("updated_at")), "", If(IsDBNull(row("updated_at")), "", CDate(row("updated_at")).ToString("yyyy-MM-dd HH:mm")))
                )
            Next
        Catch ex As Exception
            MessageBox.Show("Error filtering departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub admin_deptmanagement_SelectionChanged(sender As Object, e As EventArgs)
        If admin_deptmanagement.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = admin_deptmanagement.SelectedRows(0)
            If selectedRow.Cells("department_id").Value IsNot Nothing Then
                Dim departmentIDStr As String = selectedRow.Cells("department_id").Value.ToString()
                If Integer.TryParse(departmentIDStr, selectedDepartmentID) Then
                    ' Row selected, enable Edit and Delete buttons
                End If
            End If
        End If
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs)
        ' Reload data with filters
        LoadDepartmentsData()
        ' Reapply search if there's search text
        If pm_txtbox_search.Text <> "Search" AndAlso Not String.IsNullOrWhiteSpace(pm_txtbox_search.Text) Then
            ApplySearch()
        End If
    End Sub

    Private Sub pm_txtbox_search_TextChanged(sender As Object, e As EventArgs) Handles pm_txtbox_search.TextChanged
        If pm_txtbox_search.Text <> "Search" Then
            ApplySearch()
        End If
    End Sub

    Private Sub ApplySearch()
        If originalData Is Nothing Then Return

        Dim searchText As String = pm_txtbox_search.Text.Trim().ToLower()
        If String.IsNullOrEmpty(searchText) OrElse searchText = "search" Then
            LoadDepartmentsData()
            Return
        End If

        Try
            admin_deptmanagement.Rows.Clear()
            Dim filteredRows = originalData.AsEnumerable().Where(Function(row)
                                                                     Dim name As String = If(IsDBNull(row("department_name")), "", row("department_name").ToString().ToLower())
                                                                     Dim code As String = If(IsDBNull(row("department_code")), "", row("department_code").ToString().ToLower())
                                                                     Dim head As String = If(IsDBNull(row("head_of_department")), "", row("head_of_department").ToString().ToLower())
                                                                     Return name.Contains(searchText) OrElse code.Contains(searchText) OrElse head.Contains(searchText)
                                                                 End Function)

            For Each row As DataRow In filteredRows
                admin_deptmanagement.Rows.Add(
                    If(IsDBNull(row("department_id")), "", row("department_id").ToString()),
                    If(IsDBNull(row("department_name")), "", row("department_name").ToString()),
                    If(IsDBNull(row("head_of_department")), "", row("head_of_department").ToString()),
                    If(IsDBNull(row("contact_number")), "", row("contact_number").ToString()),
                    If(IsDBNull(row("email")), "", row("email").ToString()),
                    If(IsDBNull(row("location")), "", row("location").ToString()),
                    If(IsDBNull(row("no_of_employees")), "0", row("no_of_employees").ToString()),
                    If(IsDBNull(row("department_code")), "", row("department_code").ToString()),
                    If(IsDBNull(row("office_hours")), "", row("office_hours").ToString()),
                    If(IsDBNull(row("established_date")), "", If(IsDBNull(row("established_date")), "", CDate(row("established_date")).ToString("yyyy-MM-dd"))),
                    If(IsDBNull(row("parent_department_id")), "", If(IsDBNull(row("parent_department_id")), "", row("parent_department_id").ToString())),
                    If(IsDBNull(row("status")), "", row("status").ToString()),
                    If(IsDBNull(row("budget_allocation")), "0.00", Format(CDec(row("budget_allocation")), "0.00")),
                    If(IsDBNull(row("created_at")), "", If(IsDBNull(row("created_at")), "", CDate(row("created_at")).ToString("yyyy-MM-dd HH:mm"))),
                    If(IsDBNull(row("updated_at")), "", If(IsDBNull(row("updated_at")), "", CDate(row("updated_at")).ToString("yyyy-MM-dd HH:mm")))
                )
            Next
        Catch ex As Exception
            MessageBox.Show("Error searching departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddDepartment())
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) 
        If admin_deptmanagement.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a department to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = admin_deptmanagement.SelectedRows(0)
        If selectedRow.Cells("department_id").Value Is Nothing Then
            MessageBox.Show("Invalid department selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim departmentIDStr As String = selectedRow.Cells("department_id").Value.ToString()
        Dim departmentID As Integer
        If Not Integer.TryParse(departmentIDStr, departmentID) Then
            MessageBox.Show("Invalid department ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open edit form (you'll need to create UC_EditDepartment or modify AddDepartment to support edit mode)
        MessageBox.Show("Edit functionality - Department ID: " & departmentID.ToString(), "Edit Department", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' TODO: Implement edit form
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If admin_deptmanagement.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a department to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = admin_deptmanagement.SelectedRows(0)
        If selectedRow.Cells("department_id").Value Is Nothing Then
            MessageBox.Show("Invalid department selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim departmentIDStr As String = selectedRow.Cells("department_id").Value.ToString()
        Dim departmentName As String = If(selectedRow.Cells("department_name").Value IsNot Nothing, selectedRow.Cells("department_name").Value.ToString(), "Unknown")

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
End Class
