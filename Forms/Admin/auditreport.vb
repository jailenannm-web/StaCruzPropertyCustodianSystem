Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class AuditReportAdmin
    Private auditData As DataRow = Nothing
    Private auditTable As DataTable = Nothing

    Public Sub LoadAuditRecord(logId As Integer)
        Try
            auditData = modDB.GetAuditLogById(logId)

            If auditData Is Nothing Then
                MessageBox.Show("Audit record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If

            ' Populate all fields
            PopulateFields()

            ' Enable export buttons
            btnGeneratePDF.Enabled = True
            btnGenerateCSV.Enabled = True

            ' Ensure handlers
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

    Private Sub AuditReportAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initially disable export buttons
        btnGeneratePDF.Enabled = False
        btnGenerateCSV.Enabled = False
        ' Ensure handlers attached so clicking works even if LoadAuditRecord wasn't called yet
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
    End Sub

    Private Sub btnGenerateCSV_Click(sender As Object, e As EventArgs)
        If auditData Is Nothing Then
            MessageBox.Show("No audit record loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim exportTable As DataTable = CreateExportTableFromDataRow(auditData)
            Dim logIdStr As String = If(Convert.IsDBNull(auditData("logId")), DateTime.Now.ToString("yyyyMMdd_HHmmss"), auditData("logId").ToString())
            Dim fileName As String = "audit_report_" & logIdStr & ".csv"
            ReportExportHelper.ExportDataTableToCsv(exportTable, fileName, "Audit report exported successfully to CSV.")
        Catch ex As Exception
            MessageBox.Show("Error exporting CSV file: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGeneratePDF_Click(sender As Object, e As EventArgs)
        If auditData Is Nothing Then
            MessageBox.Show("No audit record loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim exportTable As DataTable = CreateExportTableFromDataRow(auditData)
            Dim logIdStr As String = If(Convert.IsDBNull(auditData("logId")), DateTime.Now.ToString("yyyyMMdd_HHmmss"), auditData("logId").ToString())
            Dim fileName As String = "audit_report_" & logIdStr & ".pdf"
            ReportExportHelper.ExportDataTableToPdf(exportTable, fileName, "Sta Cruz Property Custodian System - Audit Report", "Audit report exported successfully to PDF.")
        Catch ex As Exception
            MessageBox.Show("Error exporting PDF file: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
