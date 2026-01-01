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
            Dim dt As DataTable = modDB.GetStaffMaintenanceRequests(SessionContext.CurrentUserID.Value)

            ' Use DataBinding instead of manual row addition for correct data mapping
            DataGridView1.AutoGenerateColumns = False
            DataGridView1.DataSource = Nothing
            
            ' Map DataGridView columns to database columns using DataPropertyName
            ' This ensures data appears in correct columns
            For Each col As DataGridViewColumn In DataGridView1.Columns
                Select Case col.Index
                    Case 0 ' PropertID column -> Property/Item Name
                        col.DataPropertyName = "itemName"
                        col.HeaderText = "Property/Item Name"
                    Case 1 ' PropertyName column -> Serial No.
                        col.DataPropertyName = "serialNumber"
                        col.HeaderText = "Serial No."
                    Case 2 ' Category column -> Location
                        col.DataPropertyName = "location"
                        col.HeaderText = "Location"
                    Case 3 ' Description column -> Department
                        col.DataPropertyName = "department"
                        col.HeaderText = "Department"
                    Case 4 ' SerialNumber column -> Condition Before
                        col.DataPropertyName = "conditionBefore"
                        col.HeaderText = "Condition Before"
                    Case 5 ' AcquisitionDate column -> Type of Issue
                        col.DataPropertyName = "typeOfIssue"
                        col.HeaderText = "Type of Issue"
                    Case 6 ' AcquisitionCost column -> Problem Description
                        col.DataPropertyName = "problemDescription"
                        col.HeaderText = "Problem Description"
                    Case 7 ' Supplier column -> Date Requested
                        col.DataPropertyName = "dateOfRequest"
                        col.HeaderText = "Date Requested"
                        col.DefaultCellStyle.Format = "yyyy-MM-dd"
                    Case 8 ' ConditionStatus column -> Status
                        col.DataPropertyName = "status"
                        col.HeaderText = "Status"
                End Select
            Next

            ' Bind data source AFTER column mapping
            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.ReadOnly = True
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            
            System.Diagnostics.Debug.WriteLine($"[v0] Loaded {dt.Rows.Count} maintenance requests for staff")
        Catch ex As Exception
            Dim errorMsg As String = "Unable to load maintenance requests. "
            If ex.Message.Contains("Connection") OrElse ex.Message.Contains("timeout") Then
                errorMsg &= "Please check your database connection."
            Else
                errorMsg &= "Please try again."
            End If
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            System.Diagnostics.Debug.WriteLine("[v0] LoadMaintenanceRequests Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
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
