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
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Try
                        Dim itemName As String = ""
                        Dim serialNo As String = ""
                        Dim location As String = ""
                        Dim department As String = ""
                        Dim conditionBefore As String = ""
                        Dim typeOfIssue As String = ""
                        Dim problemDesc As String = ""
                        Dim maintenanceDate As String = ""
                        Dim status As String = ""
                        
                        ' Safely access columns
                        If dt.Columns.Contains("item_name") AndAlso Not IsDBNull(row("item_name")) Then
                            itemName = row("item_name").ToString()
                        End If
                        If dt.Columns.Contains("serial_number") AndAlso Not IsDBNull(row("serial_number")) Then
                            serialNo = row("serial_number").ToString()
                        End If
                        If dt.Columns.Contains("location") AndAlso Not IsDBNull(row("location")) Then
                            location = row("location").ToString()
                        End If
                        If dt.Columns.Contains("department_name") AndAlso Not IsDBNull(row("department_name")) Then
                            department = row("department_name").ToString()
                        End If
                        If dt.Columns.Contains("condition_before") AndAlso Not IsDBNull(row("condition_before")) Then
                            conditionBefore = row("condition_before").ToString()
                        End If
                        If dt.Columns.Contains("type_of_issue") AndAlso Not IsDBNull(row("type_of_issue")) Then
                            typeOfIssue = row("type_of_issue").ToString()
                        End If
                        If dt.Columns.Contains("problem_description") AndAlso Not IsDBNull(row("problem_description")) Then
                            problemDesc = row("problem_description").ToString()
                        End If
                        If dt.Columns.Contains("date_requested") AndAlso Not IsDBNull(row("date_requested")) Then
                            maintenanceDate = Convert.ToDateTime(row("date_requested")).ToString("yyyy-MM-dd")
                        End If
                        If dt.Columns.Contains("status") AndAlso Not IsDBNull(row("status")) Then
                            status = row("status").ToString()
                        End If

                        DataGridView1.Rows.Add(itemName, serialNo, location, department, conditionBefore, typeOfIssue, problemDesc, maintenanceDate, status)
                    Catch rowEx As Exception
                        System.Diagnostics.Debug.WriteLine("Error processing row in MaintenanceRequest: " & rowEx.Message)
                    End Try
                Next
            End If

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
