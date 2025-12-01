Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Partial Public Class MaintenanceRequest
    Inherits UserControl
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub MaintenanceRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMaintenanceRequests()
    End Sub

    Private Sub LoadMaintenanceRequests()
        Try
            ' Check session and try to restore if needed
            If Not SessionContext.CurrentUserID.HasValue OrElse SessionContext.CurrentUserID.Value <= 0 Then
                MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Load maintenance requests for the current staff member
            Dim dt As DataTable = DatabaseConnection.GetStaffMaintenanceRequests(SessionContext.CurrentUserID.Value)

            ' Clear existing data
            DataGridView1.Rows.Clear()

            ' Populate DataGridView
            For Each row As DataRow In dt.Rows
                Dim itemName As String = If(IsDBNull(row("item_name")), "", row("item_name").ToString())
                Dim serialNo As String = If(IsDBNull(row("serial_number")), "", row("serial_number").ToString())
                Dim location As String = If(IsDBNull(row("location")), "", row("location").ToString())
                Dim department As String = If(IsDBNull(row("department_name")), "", row("department_name").ToString())
                Dim conditionBefore As String = If(IsDBNull(row("condition_before")), "", row("condition_before").ToString())
                Dim typeOfIssue As String = If(IsDBNull(row("type_of_issue")), "", row("type_of_issue").ToString())
                Dim problemDesc As String = If(IsDBNull(row("problem_description")), "", row("problem_description").ToString())
                Dim maintenanceDate As String = If(IsDBNull(row("date_requested")), "", Convert.ToDateTime(row("date_requested")).ToString("yyyy-MM-dd"))
                Dim status As String = If(IsDBNull(row("status")), "", row("status").ToString())

                DataGridView1.Rows.Add(itemName, serialNo, location, department, conditionBefore, typeOfIssue, problemDesc, maintenanceDate, status)
            Next

            ' Auto-size columns
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            Dim errorMsg As String = "Unable to load maintenance requests. "
            If ex.Message.Contains("Connection") OrElse ex.Message.Contains("timeout") Then
                errorMsg &= "Please check your database connection."
            Else
                errorMsg &= "Please try again."
            End If
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        ' Open form to add new maintenance request
        Dim wrapper As New Form()
        wrapper.Text = "Add Maintenance Request"
        wrapper.StartPosition = FormStartPosition.CenterScreen
        wrapper.Size = New Size(900, 600)
        wrapper.FormBorderStyle = FormBorderStyle.FixedDialog

        Dim addMaintenanceForm As New MaintenanceRequestForm()
        addMaintenanceForm.Dock = DockStyle.Fill
        wrapper.Controls.Add(addMaintenanceForm)

        wrapper.ShowDialog()


        ' Refresh data after adding request
        LoadMaintenanceRequests()
    End Sub
End Class
