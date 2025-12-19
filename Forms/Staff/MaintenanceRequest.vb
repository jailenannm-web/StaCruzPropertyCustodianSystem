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
            ' Note: Column order must match the designer column order:
            ' PropertID (Property/Item Name), PropertyName (Serial No.), Category (Location), 
            ' Description (Department), SerialNumber (Condition Before), AcquisitionDate (Type of Issue),
            ' AcquisitionCost (Problem Description), Supplier (Maintenance Date), ConditionStatus (Status)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Try
                        Dim itemName As String = ""
                        Dim serialNo As String = ""
                        Dim locationValue As String = ""
                        Dim department As String = ""
                        Dim conditionBefore As String = ""
                        Dim typeOfIssue As String = ""
                        Dim problemDesc As String = ""
                        Dim maintenanceDate As String = ""
                        Dim status As String = ""
                        
                        ' Safely access columns - use camelCase to match query results
                        If dt.Columns.Contains("itemName") AndAlso Not IsDBNull(row("itemName")) Then
                            itemName = row("itemName").ToString()
                        End If
                        If dt.Columns.Contains("serialNumber") AndAlso Not IsDBNull(row("serialNumber")) Then
                            serialNo = row("serialNumber").ToString()
                        End If
                        If dt.Columns.Contains("location") AndAlso Not IsDBNull(row("location")) Then
                            locationValue = row("location").ToString()
                        End If
                        If dt.Columns.Contains("department") AndAlso Not IsDBNull(row("department")) Then
                            department = row("department").ToString()
                        ElseIf dt.Columns.Contains("departmentName") AndAlso Not IsDBNull(row("departmentName")) Then
                            department = row("departmentName").ToString()
                        End If
                        If dt.Columns.Contains("conditionBefore") AndAlso Not IsDBNull(row("conditionBefore")) Then
                            conditionBefore = row("conditionBefore").ToString()
                        End If
                        If dt.Columns.Contains("typeOfIssue") AndAlso Not IsDBNull(row("typeOfIssue")) Then
                            typeOfIssue = row("typeOfIssue").ToString()
                        End If
                        If dt.Columns.Contains("problemDescription") AndAlso Not IsDBNull(row("problemDescription")) Then
                            problemDesc = row("problemDescription").ToString()
                        End If
                        If dt.Columns.Contains("dateOfRequest") AndAlso Not IsDBNull(row("dateOfRequest")) Then
                            Try
                                maintenanceDate = Convert.ToDateTime(row("dateOfRequest")).ToString("yyyy-MM-dd")
                            Catch
                                maintenanceDate = row("dateOfRequest").ToString()
                            End Try
                        ElseIf dt.Columns.Contains("dateRequested") AndAlso Not IsDBNull(row("dateRequested")) Then
                            Try
                                maintenanceDate = Convert.ToDateTime(row("dateRequested")).ToString("yyyy-MM-dd")
                            Catch
                                maintenanceDate = row("dateRequested").ToString()
                            End Try
                        End If
                        If dt.Columns.Contains("status") AndAlso Not IsDBNull(row("status")) Then
                            status = row("status").ToString()
                        End If

                        ' Add data in the correct column order matching the designer:
                        ' Column 0: PropertID (shows as "Property/Item Name") -> itemName
                        ' Column 1: PropertyName (shows as "Serial No.") -> serialNo
                        ' Column 2: Category (shows as "Location") -> locationValue
                        ' Column 3: Description -> department
                        ' Column 4: SerialNumber -> conditionBefore
                        ' Column 5: AcquisitionDate -> typeOfIssue
                        ' Column 6: AcquisitionCost -> problemDesc
                        ' Column 7: Supplier -> maintenanceDate
                        ' Column 8: ConditionStatus -> status
                        DataGridView1.Rows.Add(itemName, serialNo, locationValue, department, conditionBefore, typeOfIssue, problemDesc, maintenanceDate, status)
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
