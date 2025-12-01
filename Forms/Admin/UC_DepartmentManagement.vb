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
                ' Use safe column access
                Dim deptName As String = If(row.Table.Columns.Contains("department_name") AndAlso Not IsDBNull(row("department_name")), row("department_name").ToString(), "")
                Dim headOfDept As String = If(row.Table.Columns.Contains("head_of_department") AndAlso Not IsDBNull(row("head_of_department")), row("head_of_department").ToString(), "")
                Dim deptID As String = If(row.Table.Columns.Contains("department_id") AndAlso Not IsDBNull(row("department_id")), row("department_id").ToString(), "")
                Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), "")
                Dim totalProps As String = If(row.Table.Columns.Contains("total_properties") AndAlso Not IsDBNull(row("total_properties")), row("total_properties").ToString(), "0")
                Dim totalSupplies As String = If(row.Table.Columns.Contains("total_supplies") AndAlso Not IsDBNull(row("total_supplies")), row("total_supplies").ToString(), "0")
                Dim status As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), "")
                
                admin_deptmanagement.Rows.Add(deptName, headOfDept, deptID, location, totalProps, totalSupplies, status)
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
                ' Use safe column access
                Dim deptName As String = If(row.Table.Columns.Contains("department_name") AndAlso Not IsDBNull(row("department_name")), row("department_name").ToString(), "")
                Dim headOfDept As String = If(row.Table.Columns.Contains("head_of_department") AndAlso Not IsDBNull(row("head_of_department")), row("head_of_department").ToString(), "")
                Dim deptID As String = If(row.Table.Columns.Contains("department_id") AndAlso Not IsDBNull(row("department_id")), row("department_id").ToString(), "")
                Dim location As String = If(row.Table.Columns.Contains("location") AndAlso Not IsDBNull(row("location")), row("location").ToString(), "")
                Dim totalProps As String = If(row.Table.Columns.Contains("total_properties") AndAlso Not IsDBNull(row("total_properties")), row("total_properties").ToString(), "0")
                Dim totalSupplies As String = If(row.Table.Columns.Contains("total_supplies") AndAlso Not IsDBNull(row("total_supplies")), row("total_supplies").ToString(), "0")
                Dim status As String = If(row.Table.Columns.Contains("status") AndAlso Not IsDBNull(row("status")), row("status").ToString(), "")
                
                admin_deptmanagement.Rows.Add(deptName, headOfDept, deptID, location, totalProps, totalSupplies, status)
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
            ' Get department ID from the DepartmentID column (index 2 based on column order)
            ' Column order: DepartmentName (0), DepartmentHead (1), DepartmentID (2), Location (3), TotalProperties (4), TotalSupplies (5), Status (6)
            Try
                If selectedRow.Cells.Count > 2 AndAlso selectedRow.Cells(2).Value IsNot Nothing Then
                    Dim departmentIDStr As String = selectedRow.Cells(2).Value.ToString()
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
        ' Column order: DepartmentName (0), DepartmentHead (1), DepartmentID (2), Location (3), TotalProperties (4), TotalSupplies (5), Status (6)
        If selectedRow.Cells.Count < 3 Then
            MessageBox.Show("Invalid department selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim deptIDValue As Object = Nothing
        Dim deptNameValue As Object = Nothing
        
        Try
            ' Use column index to avoid column name issues
            deptIDValue = selectedRow.Cells(2).Value
            deptNameValue = selectedRow.Cells(0).Value
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
End Class
