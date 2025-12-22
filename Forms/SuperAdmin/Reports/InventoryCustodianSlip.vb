Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq
Imports Microsoft.VisualBasic

Public Class InventoryCustodianSlip
    Inherits Form

    Private requestData As DataRow
    Private ReadOnly requestID As Integer

    ' Default constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Constructor receives requestId for autofill from request data
    Public Sub New(reqId As Integer)
        InitializeComponent()
        requestID = reqId
        LoadRequestData()
    End Sub

    Private Sub LoadRequestData()
        Try
            If requestID <= 0 Then Return
            
            Dim dt As DataTable = DatabaseConnection.GetAllPropertyRequests()
            Dim requestRows() As DataRow = dt.Select($"requestId = {requestID}")
            If requestRows.Length = 0 Then
                requestRows = dt.Select($"request_id = {requestID}")
            End If
            
            If requestRows.Length > 0 Then
                requestData = requestRows(0)
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[InventoryCustodianSlip] LoadRequestData error: {ex.Message}")
        End Try
    End Sub

    Private Sub InventoryCustodianSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Autofill form fields if request data is available
        If requestData IsNot Nothing Then
            AutoFillFields()
        End If
        
        ' Wire up export buttons
        WireUpExportButtons()
    End Sub

    Private Sub AutoFillFields()
        Try
            ' Find and populate controls by name
            SetTextBoxValue("txtRequestId", GetRequestFieldValue("requestId", "request_id"))
            SetTextBoxValue("txtRequesterName", GetRequestFieldValue("requesterName", "requester_name"))
            SetTextBoxValue("txtPosition", GetRequestFieldValue("position"))
            SetTextBoxValue("txtDepartment", GetRequestFieldValue("department", "departmentName"))
            SetTextBoxValue("txtItemName", GetRequestFieldValue("itemName", "item_name"))
            SetTextBoxValue("txtDescription", GetRequestFieldValue("description"))
            SetTextBoxValue("txtQuantity", GetRequestFieldValue("quantityRequested", "quantity_requested"))
            SetTextBoxValue("txtPurpose", GetRequestFieldValue("purpose"))
            SetTextBoxValue("txtDateRequest", GetRequestFieldValue("dateOfRequest", "date_of_request"))
            SetTextBoxValue("txtStatus", GetRequestFieldValue("status"))
            SetTextBoxValue("txtDateIssued", DateTime.Now.ToString("yyyy-MM-dd"))
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[InventoryCustodianSlip] AutoFillFields error: {ex.Message}")
        End Try
    End Sub

    Private Sub SetTextBoxValue(controlName As String, value As String)
        Try
            Dim controls() As Control = Me.Controls.Find(controlName, True)
            If controls IsNot Nothing AndAlso controls.Length > 0 AndAlso TypeOf controls(0) Is TextBox Then
                Dim textBox As TextBox = CType(controls(0), TextBox)
                textBox.Text = value
            End If
        Catch
            ' Ignore if control not found
        End Try
    End Sub

    Private Function GetRequestFieldValue(ParamArray names() As String) As String
        If requestData Is Nothing Then Return ""
        For Each fieldName As String In names
            If requestData.Table IsNot Nothing AndAlso requestData.Table.Columns.Contains(fieldName) Then
                If Convert.IsDBNull(requestData(fieldName)) Then
                    Return ""
                End If
                Return requestData(fieldName).ToString()
            End If
        Next
        Return ""
    End Function

    Private Sub WireUpExportButtons()
        ' Find and wire up CSV button
        Dim btnCSVControls() As Control = Me.Controls.Find("btnCSV", True)
        If btnCSVControls Is Nothing OrElse btnCSVControls.Length = 0 Then
            btnCSVControls = Me.Controls.Find("btnExportCSV", True)
        End If
        If btnCSVControls IsNot Nothing AndAlso btnCSVControls.Length > 0 AndAlso TypeOf btnCSVControls(0) Is Button Then
            Dim btnCSV As Button = CType(btnCSVControls(0), Button)
            RemoveHandler btnCSV.Click, AddressOf ExportToCSV
            AddHandler btnCSV.Click, AddressOf ExportToCSV
        End If

        ' Find and wire up PDF button
        Dim btnPDFControls() As Control = Me.Controls.Find("btnPDF", True)
        If btnPDFControls Is Nothing OrElse btnPDFControls.Length = 0 Then
            btnPDFControls = Me.Controls.Find("btnExportPDF", True)
        End If
        If btnPDFControls IsNot Nothing AndAlso btnPDFControls.Length > 0 AndAlso TypeOf btnPDFControls(0) Is Button Then
            Dim btnPDF As Button = CType(btnPDFControls(0), Button)
            RemoveHandler btnPDF.Click, AddressOf ExportToPDF
            AddHandler btnPDF.Click, AddressOf ExportToPDF
        End If
    End Sub

    Private Sub ExportToCSV(sender As Object, e As EventArgs)
        Try
            Dim dt As New DataTable()
            dt.Columns.Add("Field", GetType(String))
            dt.Columns.Add("Value", GetType(String))

            If requestData IsNot Nothing Then
                ' Export request data
                dt.Rows.Add("Request ID", GetRequestFieldValue("requestId", "request_id"))
                dt.Rows.Add("Requester Name", GetRequestFieldValue("requesterName", "requester_name"))
                dt.Rows.Add("Position", GetRequestFieldValue("position"))
                dt.Rows.Add("Department", GetRequestFieldValue("department", "departmentName"))
                dt.Rows.Add("Item Name", GetRequestFieldValue("itemName", "item_name"))
                dt.Rows.Add("Description", GetRequestFieldValue("description"))
                dt.Rows.Add("Quantity", GetRequestFieldValue("quantityRequested", "quantity_requested"))
                dt.Rows.Add("Purpose", GetRequestFieldValue("purpose"))
                dt.Rows.Add("Date of Request", GetRequestFieldValue("dateOfRequest", "date_of_request"))
                dt.Rows.Add("Status", GetRequestFieldValue("status"))
                dt.Rows.Add("Date Issued", DateTime.Now.ToString("yyyy-MM-dd"))
            End If

            Dim fileName As String = $"PAR_ICS_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            ReportExportHelper.ExportDataTableToCsv(dt, fileName, "PAR/ICS exported successfully.")
        Catch ex As Exception
            MessageBox.Show("Error exporting to CSV: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToPDF(sender As Object, e As EventArgs)
        Try
            Dim dt As New DataTable()
            dt.Columns.Add("Field", GetType(String))
            dt.Columns.Add("Value", GetType(String))

            If requestData IsNot Nothing Then
                ' Export request data
                dt.Rows.Add("Request ID", GetRequestFieldValue("requestId", "request_id"))
                dt.Rows.Add("Requester Name", GetRequestFieldValue("requesterName", "requester_name"))
                dt.Rows.Add("Position", GetRequestFieldValue("position"))
                dt.Rows.Add("Department", GetRequestFieldValue("department", "departmentName"))
                dt.Rows.Add("Item Name", GetRequestFieldValue("itemName", "item_name"))
                dt.Rows.Add("Description", GetRequestFieldValue("description"))
                dt.Rows.Add("Quantity", GetRequestFieldValue("quantityRequested", "quantity_requested"))
                dt.Rows.Add("Purpose", GetRequestFieldValue("purpose"))
                dt.Rows.Add("Date of Request", GetRequestFieldValue("dateOfRequest", "date_of_request"))
                dt.Rows.Add("Status", GetRequestFieldValue("status"))
                dt.Rows.Add("Date Issued", DateTime.Now.ToString("yyyy-MM-dd"))
            End If

            Dim fileName As String = $"PAR_ICS_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            ReportExportHelper.ExportDataTableToPdf(dt, fileName, "PROPERTY ACKNOWLEDGMENT RECEIPT / INVENTORY CUSTODIAN SLIP", "PAR/ICS exported successfully.")
        Catch ex As Exception
            MessageBox.Show("Error exporting to PDF: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class