Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class UC_PropertyRequestManagement
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub UC_PropertyRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupTable()
        LoadSampleData()
    End Sub

    Private Sub SetupTable()
        With prm_table1
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowTemplate.Height = 30
            .EnableHeadersVisualStyles = False

            .Columns.Clear()
            .Columns.Add("request_id", "Request ID")
            .Columns.Add("name", "Name")
            .Columns.Add("property", "Property")
            .Columns.Add("request_date", "Request Date")
            .Columns.Add("status", "Status")

            Dim editButton As New DataGridViewButtonColumn()
            editButton.HeaderText = "Action"
            editButton.Name = "action_edit"
            editButton.Text = "Edit"
            editButton.UseColumnTextForButtonValue = True
            .Columns.Add(editButton)

            For Each col As DataGridViewColumn In .Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With
    End Sub

    Private Sub LoadSampleData()
        prm_table1.Rows.Clear()
        prm_table1.Rows.Add("REQ001", "Juan Dela Cruz", "Laptop", "11/02/2025", "Pending")
        prm_table1.Rows.Add("REQ002", "Mark Garcia", "Projector", "11/01/2025", "Approved")
        prm_table1.Rows.Add("REQ003", "Pedro Santos", "Printer", "10/30/2025", "Denied")
    End Sub

    Private Sub prm_table1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles prm_table1.CellContentClick
        If e.RowIndex >= 0 AndAlso prm_table1.Columns.Contains("action_edit") AndAlso e.ColumnIndex = prm_table1.Columns("action_edit").Index Then
            Dim reqID As String = prm_table1.Rows(e.RowIndex).Cells("request_id").Value?.ToString()
            MessageBox.Show("Edit Request: " & reqID, "Action", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Example to load edit UC
            ' Dim uc As New UC_EditRequest()
            ' uc.LoadRequestData(reqID)
            ' Me.Parent.Controls.Add(uc) : uc.BringToFront()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddPropertyRequest())
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        MessageBox.Show("Delete request functionality here")
    End Sub
End Class
