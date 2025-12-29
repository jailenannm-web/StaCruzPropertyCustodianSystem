Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class AuditReportAdmin
 Private auditData As DataRow = Nothing
 Private auditTable As DataTable = Nothing

 Public Sub LoadAuditRecord(logId As Integer)
 Try
 auditData = DatabaseConnection.GetAuditLogById(logId)

 If auditData Is Nothing Then
 MessageBox.Show("Audit record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
 Me.Close()
 Return
 End If

 ' Populate all fields
 PopulateFields()

 ' Enable export buttons and ensure handlers wired
 btnGeneratePDF.Enabled = True
 btnGenerateCSV.Enabled = True
 btnGenerateCSV.Visible = True
 btnGeneratePDF.Visible = True
 btnGenerateCSV.BringToFront()
 btnGeneratePDF.BringToFront()

 ' Wire handlers explicitly to ensure clicks are handled (safe even if already wired)
 Try
 RemoveHandler btnGenerateCSV.Click, AddressOf btnGenerateCSV_Click
 Catch
 End Try
 AddHandler btnGenerateCSV.Click, AddressOf btnGenerateCSV_Click

 Try
 RemoveHandler btnGeneratePDF.Click, AddressOf btnGeneratePDF_Click
 Catch
 End Try
 AddHandler btnGeneratePDF.Click, AddressOf btnGeneratePDF_Click

 Catch ex As Exception
 MessageBox.Show("Error loading audit record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
 Me.Close()
 End Try
 End Sub

 Private Sub PopulateFields()
 Try
 If auditData Is Nothing Then Return

 ' Date and Time (show date in first picker, time in second picker)
 If Not Convert.IsDBNull(auditData("createdAt")) Then
 Dim createdDateTime As DateTime = Convert.ToDateTime(auditData("createdAt"))
 dtpFrom.Value = createdDateTime
 dtpFrom.Format = DateTimePickerFormat.Short ' Show date only
 dtpTo.Value = createdDateTime
 dtpTo.Format = DateTimePickerFormat.Time ' Show time only
 End If

 ' User Name
 txtUserName.Text = If(Convert.IsDBNull(auditData("username")), "System", auditData("username").ToString())

 ' User Role
 txtUserRole.Text = If(Convert.IsDBNull(auditData("role")), "Unknown", auditData("role").ToString())

 ' User ID
 txtUserID.Text = If(Convert.IsDBNull(auditData("userId")), "", auditData("userId").ToString())

 ' Log ID
 txtLogID.Text = If(Convert.IsDBNull(auditData("logId")), "", auditData("logId").ToString())

 ' Action
 txtAction.Text = If(Convert.IsDBNull(auditData("action")), "", auditData("action").ToString())

            ' Module (Table Name) - handle both "module" and "tableName" column names
            Dim moduleValue As String = ""
            If Not Convert.IsDBNull(auditData("module")) Then
                moduleValue = auditData("module").ToString()
            ElseIf auditData.Table.Columns.Contains("tableName") AndAlso Not Convert.IsDBNull(auditData("tableName")) Then
                moduleValue = auditData("tableName").ToString()
            End If
            txtTableName.Text = If(String.IsNullOrWhiteSpace(moduleValue), "N/A", moduleValue)

 ' Record ID
 txtRecordID.Text = If(Convert.IsDBNull(auditData("recordId")), "", auditData("recordId").ToString())

 ' Description
 txtDescription.Text = If(Convert.IsDBNull(auditData("description")), "", auditData("description").ToString())

 ' IP Address
 txtIPAddress.Text = If(Convert.IsDBNull(auditData("ipAddress")), "", auditData("ipAddress").ToString())

 ' User Agent
 txtUserAgent.Text = If(Convert.IsDBNull(auditData("userAgent")), "", auditData("userAgent").ToString())

 ' Make all fields read-only
 MakeFieldsReadOnly()
 Catch ex As Exception
 MessageBox.Show("Error populating fields: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
 End Try
 End Sub

 Private Sub MakeFieldsReadOnly()
 dtpFrom.Enabled = False
 dtpTo.Enabled = False
 txtUserName.ReadOnly = True
 txtUserRole.ReadOnly = True
 txtUserID.ReadOnly = True
 txtLogID.ReadOnly = True
 txtAction.ReadOnly = True
 txtTableName.ReadOnly = True
 txtRecordID.ReadOnly = True
 txtDescription.ReadOnly = True
 txtIPAddress.ReadOnly = True
 txtUserAgent.ReadOnly = True
 End Sub

 Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
 Me.Close()
 End Sub

    ' Public helper so other forms can build the same export DataTable from a DataRow
    Public Shared Function CreateExportTableFromDataRow(auditRow As DataRow) As DataTable
        Dim exportTable As New DataTable()
        exportTable.TableName = "Audit Report"
        exportTable.Columns.Add("Field", GetType(String))
        exportTable.Columns.Add("Value", GetType(String))

        If auditRow Is Nothing Then Return exportTable

        Try
            ' Header Section - Match the Audit Report form format
            exportTable.Rows.Add("AUDIT REPORT", "")
            exportTable.Rows.Add("", "")
            exportTable.Rows.Add("System", "Sta Cruz Property Custodian System")
            exportTable.Rows.Add("Report Generated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            exportTable.Rows.Add("", "") ' spacing

            ' Helper function to safely get column value
            Dim GetValue As Func(Of String, String) = Function(colName As String) As String
                                                            If auditRow.Table.Columns.Contains(colName) AndAlso Not Convert.IsDBNull(auditRow(colName)) Then
                                                                Return auditRow(colName).ToString()
                                                            End If
                                                            Return Nothing
                                                        End Function

            ' Date Range Section (matching form format)
            Dim createdAt As String = Nothing
            If auditRow.Table.Columns.Contains("createdAt") AndAlso Not Convert.IsDBNull(auditRow("createdAt")) Then
                createdAt = Convert.ToDateTime(auditRow("createdAt")).ToString("yyyy-MM-dd HH:mm:ss")
            End If
            ' Split date and time for better readability
            Dim dateOnly As String = "N/A"
            Dim timeOnly As String = "N/A"
            If Not String.IsNullOrWhiteSpace(createdAt) Then
                Dim dt As DateTime = Convert.ToDateTime(auditRow("createdAt"))
                dateOnly = dt.ToString("yyyy-MM-dd")
                timeOnly = dt.ToString("HH:mm:ss")
            End If
            exportTable.Rows.Add("Date Created", dateOnly)
            exportTable.Rows.Add("Time", timeOnly)
            exportTable.Rows.Add("", "") ' spacing

            ' Audit Details - Match exact form field labels
            Dim username As String = GetValue("username")
            exportTable.Rows.Add("User", If(String.IsNullOrWhiteSpace(username), "System", username))

            Dim role As String = GetValue("role")
            exportTable.Rows.Add("Role", If(String.IsNullOrWhiteSpace(role), "Unknown", role))

            Dim userId As String = GetValue("userId")
            exportTable.Rows.Add("User ID", If(String.IsNullOrWhiteSpace(userId) OrElse userId = "0", "N/A", userId))

            Dim logId As String = GetValue("logId")
            exportTable.Rows.Add("Log ID", If(String.IsNullOrWhiteSpace(logId), "N/A", logId))

            Dim action As String = GetValue("action")
            exportTable.Rows.Add("Action", If(String.IsNullOrWhiteSpace(action), "N/A", action))

            ' Handle both "module" and "tableName" column names
            Dim moduleValue As String = GetValue("module")
            If String.IsNullOrWhiteSpace(moduleValue) Then
                moduleValue = GetValue("tableName")
            End If
            exportTable.Rows.Add("Table Name", If(String.IsNullOrWhiteSpace(moduleValue), "N/A", moduleValue))

            Dim recordId As String = GetValue("recordId")
            exportTable.Rows.Add("Record ID", If(String.IsNullOrWhiteSpace(recordId) OrElse recordId = "0", "N/A", recordId))

            Dim description As String = GetValue("description")
            exportTable.Rows.Add("Description", If(String.IsNullOrWhiteSpace(description), "No description available", description))

            Dim ipAddress As String = GetValue("ipAddress")
            exportTable.Rows.Add("IP Address", If(String.IsNullOrWhiteSpace(ipAddress), "N/A", ipAddress))

            Dim userAgent As String = GetValue("userAgent")
            exportTable.Rows.Add("User Agent", If(String.IsNullOrWhiteSpace(userAgent), "N/A", userAgent))
        Catch ex As Exception
            ' Add error information to export table
            exportTable.Rows.Add("Error", "Error processing audit data: " & ex.Message)
        End Try

        Return exportTable
    End Function

 Private Sub btnGenerateCSV_Click(sender As Object, e As EventArgs) Handles btnGenerateCSV.Click
 If auditData Is Nothing Then
 MessageBox.Show("No audit record loaded. Please select an audit record first.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
 Return
 End If

 Try
 Dim exportTable As DataTable = CreateExportTableFromDataRow(auditData)
 Dim logIdStr As String = If(Convert.IsDBNull(auditData("logId")), DateTime.Now.ToString("yyyyMMdd_HHmmss"), auditData("logId").ToString())
 Dim fileName As String = "audit_report_" & logIdStr & ".csv"

 ReportExportHelper.ExportDataTableToCsv(exportTable, fileName, "Audit report exported successfully to CSV.")
 Catch ex As Exception
 MessageBox.Show("Error exporting CSV file: " & ex.Message & Environment.NewLine & "Stack Trace: " & ex.StackTrace, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
 End Try
 End Sub

 Private Sub btnGeneratePDF_Click(sender As Object, e As EventArgs) Handles btnGeneratePDF.Click
 If auditData Is Nothing Then
 MessageBox.Show("No audit record loaded. Please select an audit record first.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
 Return
 End If

 Try
 Dim logIdStr As String = If(Convert.IsDBNull(auditData("logId")), DateTime.Now.ToString("yyyyMMdd_HHmmss"), auditData("logId").ToString())
 Dim fileName As String = "audit_report_" & logIdStr & ".pdf"

 ' Use the specialized audit report PDF export
 ReportExportHelper.ExportAuditReportToPdf(auditData, fileName, "Audit report exported successfully to PDF.")
 Catch ex As Exception
 MessageBox.Show("Error exporting PDF file: " & ex.Message & Environment.NewLine & "Stack Trace: " & ex.StackTrace, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
 End Try
 End Sub

 Private Sub AuditReportAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
 ' Initially disable export buttons
 btnGeneratePDF.Enabled = False
 btnGenerateCSV.Enabled = False
 End Sub
End Class
