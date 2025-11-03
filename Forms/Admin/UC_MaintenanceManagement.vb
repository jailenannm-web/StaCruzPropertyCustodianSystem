Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class UC_MaintenanceManagement
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        SetupGrid()
        LoadSampleData()
    End Sub

    '===================== GRID SETUP ====================='
    Private Sub SetupGrid()
        With mm_table1
            .Columns.Clear()
            .AllowUserToAddRows = False
            .ReadOnly = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .Columns.Add("LogID", "Log ID")
            .Columns.Add("Property", "Property")
            .Columns.Add("Description", "Repair Description")
            .Columns.Add("DateReported", "Date Reported")
            .Columns.Add("Warranty", "Warranty")
            .Columns.Add("Status", "Status")

            Dim btn As New DataGridViewButtonColumn()
            btn.HeaderText = "Action"
            btn.Text = "Update"
            btn.UseColumnTextForButtonValue = True
            btn.Width = 80
            .Columns.Add(btn)
        End With
    End Sub

    '=============== SAMPLE DATA (REMOVE LATER) ==============='
    Private Sub LoadSampleData()
        mm_table1.Rows.Add("M-001", "Laptop", "Broken screen", "2025-11-01", "Yes", "Pending")
        mm_table1.Rows.Add("M-002", "Printer", "Paper jam", "2025-11-02", "No", "In Progress")
        mm_table1.Rows.Add("M-003", "Projector", "No display", "2025-11-03", "Yes", "Completed")
    End Sub

    '=============== BUTTON CLICK HANDLER ====================='
    Private Sub mm_table1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles mm_table1.CellContentClick
        If e.RowIndex >= 0 AndAlso TypeOf mm_table1.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
            Dim logID As String = mm_table1.Rows(e.RowIndex).Cells("LogID").Value.ToString()
            MessageBox.Show("Update clicked for Log ID: " & logID,
                            "Maintenance Update",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            ' You can open another form here:
            ' Dim frm As New UpdateMaintenanceForm(logID)
            ' frm.ShowDialog()
        End If
    End Sub

End Class
