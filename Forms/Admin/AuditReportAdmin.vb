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

 ' Date and Time
 If Not Convert.IsDBNull(auditData("createdAt")) Then
 dtpFrom.Value = Convert.ToDateTime(auditData("createdAt"))
 dtpTo.Value = Convert.ToDateTime(auditData("createdAt"))
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

 ' Module (Table Name)
 txtTableName.Text = If(Convert.IsDBNull(auditData("module")), "", auditData("module").ToString())

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

 ' Header Section
 exportTable.Rows.Add("System Title", "Sta Cruz Property Custodian System")
 exportTable.Rows.Add("Report Title", "Audit Report")
 exportTable.Rows.Add("Date Generated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
 exportTable.Rows.Add("", "") ' spacing

 ' Audit Details
 exportTable.Rows.Add("Audit ID (Log ID)", If(Convert.IsDBNull(auditRow("logId")), "N/A", auditRow("logId").ToString()))
 exportTable.Rows.Add("User ID", If(Convert.IsDBNull(auditRow("userId")) OrElse auditRow("userId").ToString() = "0", "N/A", auditRow("userId").ToString()))
 exportTable.Rows.Add("User Name", If(Convert.IsDBNull(auditRow("username")) OrElse String.IsNullOrWhiteSpace(auditRow("username").ToString()), "System", auditRow("username").ToString()))
 exportTable.Rows.Add("User Role", If(Convert.IsDBNull(auditRow("role")) OrElse String.IsNullOrWhiteSpace(auditRow("role").ToString()), "Unknown", auditRow("role").ToString()))
 exportTable.Rows.Add("Action Performed", If(Convert.IsDBNull(auditRow("action")) OrElse String.IsNullOrWhiteSpace(auditRow("action").ToString()), "N/A", auditRow("action").ToString()))
 exportTable.Rows.Add("Module Affected", If(Convert.IsDBNull(auditRow("module")) OrElse String.IsNullOrWhiteSpace(auditRow("module").ToString()), "N/A", auditRow("module").ToString()))
 exportTable.Rows.Add("Affected Record ID", If(Convert.IsDBNull(auditRow("recordId")) OrElse auditRow("recordId").ToString() = "0", "N/A", auditRow("recordId").ToString()))
 exportTable.Rows.Add("Description / Remarks", If(Convert.IsDBNull(auditRow("description")) OrElse String.IsNullOrWhiteSpace(auditRow("description").ToString()), "N/A", auditRow("description").ToString()))
 exportTable.Rows.Add("IP Address", If(Convert.IsDBNull(auditRow("ipAddress")) OrElse String.IsNullOrWhiteSpace(auditRow("ipAddress").ToString()), "N/A", auditRow("ipAddress").ToString()))
 exportTable.Rows.Add("User Agent", If(Convert.IsDBNull(auditRow("userAgent")) OrElse String.IsNullOrWhiteSpace(auditRow("userAgent").ToString()), "N/A", auditRow("userAgent").ToString()))
 exportTable.Rows.Add("Date & Time of Action", If(Convert.IsDBNull(auditRow("createdAt")), "N/A", Convert.ToDateTime(auditRow("createdAt")).ToString("yyyy-MM-dd HH:mm:ss")))

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
 Dim exportTable As DataTable = CreateExportTableFromDataRow(auditData)
 Dim logIdStr As String = If(Convert.IsDBNull(auditData("logId")), DateTime.Now.ToString("yyyyMMdd_HHmmss"), auditData("logId").ToString())
 Dim fileName As String = "audit_report_" & logIdStr & ".pdf"

 ReportExportHelper.ExportDataTableToPdf(exportTable, fileName, "Sta Cruz Property Custodian System - Audit Report", "Audit report exported successfully to PDF.")
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
