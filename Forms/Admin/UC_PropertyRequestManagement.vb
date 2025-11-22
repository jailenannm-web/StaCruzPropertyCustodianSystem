Imports System.Drawing.Drawing2D
Imports System.Diagnostics
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
        ' Ensure the controls exist (designer must have prm_table1 and prm_btn_update)
        If prm_table1 Is Nothing Then
            MessageBox.Show("prm_table1 not found on this UserControl. Check the designer name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Setup table and sample data
        SetupTable()
        LoadSampleData()

        ' Attach handlers at runtime (avoids the WithEvents/Handles issue)
        AddHandler prm_table1.CellContentClick, AddressOf prm_table1_CellContentClick

        If Me.Controls.ContainsKey("prm_btn_update") Then
            ' prm_btn_update may be from designer; attach if present
            AddHandler prm_btn_update.Click, AddressOf prm_btn_update_Click
        End If
    End Sub

    '=======================================
    ' SETUP THE DATAGRIDVIEW
    '=======================================
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

            ' Header style
            .ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGreen
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Clear existing if reloaded
            .Columns.Clear()

            ' Add columns
            .Columns.Add("request_id", "Request ID")
            .Columns.Add("name", "Name")
            .Columns.Add("property", "Property")
            .Columns.Add("request_date", "Request Date")
            .Columns.Add("status", "Status")

            ' Add Action Button
            Dim editButton As New DataGridViewButtonColumn()
            editButton.HeaderText = "Action"
            editButton.Name = "action_edit"
            editButton.Text = "Edit"
            editButton.UseColumnTextForButtonValue = True
            .Columns.Add(editButton)

            ' Column alignment
            For Each col As DataGridViewColumn In .Columns
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With
    End Sub

    '=======================================
    ' LOAD SAMPLE DATA (TEMPORARY)
    '=======================================
    Private Sub LoadSampleData()
        prm_table1.Rows.Clear()
        prm_table1.Rows.Add("REQ001", "Juan Dela Cruz", "Laptop", "11/02/2025", "Pending")
        prm_table1.Rows.Add("REQ002", "Mark Garcia", "Projector", "11/01/2025", "Approved")
        prm_table1.Rows.Add("REQ003", "Pedro Santos", "Printer", "10/30/2025", "Denied")
    End Sub

    '=======================================
    ' HANDLE EDIT BUTTON CLICK (no Handles clause)
    '=======================================
    Private Sub prm_table1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso prm_table1.Columns.Contains("action_edit") AndAlso e.ColumnIndex = prm_table1.Columns("action_edit").Index Then
            Dim reqID As String = prm_table1.Rows(e.RowIndex).Cells("request_id").Value?.ToString()
            MessageBox.Show("Edit Request: " & reqID,
                            "Action",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            ' TODO: Load your EditRequest UserControl and pass the row data
            ' Example:
            ' Dim uc As New UC_EditRequest()
            ' uc.LoadRequestData( ... )
            ' Me.Parent.Controls.Add(uc) : uc.BringToFront()
        End If
    End Sub

    '=======================================
    ' OPTIONAL UPDATE BUTTON CLICK (no Handles clause)
    '=======================================
    Private Sub prm_btn_update_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Request List Updated!")
        ' Put refresh logic here (reload from file/db)
    End Sub

    Private Sub prm_btn_update_Click_1(sender As Object, e As EventArgs) Handles prm_btn_update.Click

    End Sub

    Private Sub prm_table1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles prm_table1.CellContentClick

    End Sub
End Class
