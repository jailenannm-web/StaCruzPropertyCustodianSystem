Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class PropertyCard
    Inherits Form

    Private propertyData As DataRow
    Private requestData As DataRow
    Private ReadOnly propertyID As Integer
    Private ReadOnly requestID As Integer

    ' Constructor receives property details from a DataRow
    Public Sub New(row As DataRow)
        InitializeComponent()
        propertyData = row

        If propertyData IsNot Nothing AndAlso propertyData.Table IsNot Nothing Then
            If propertyData.Table.Columns.Contains("property_id") Then
                Integer.TryParse(Convert.ToString(propertyData("property_id")), propertyID)
            ElseIf propertyData.Table.Columns.Contains("propertyId") Then
                Integer.TryParse(Convert.ToString(propertyData("propertyId")), propertyID)
            End If
        End If
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
            
            Dim dt As DataTable = modDB.GetAllPropertyRequests()
            Dim requestRows() As DataRow = dt.Select($"requestId = {requestID}")
            If requestRows.Length = 0 Then
                requestRows = dt.Select($"request_id = {requestID}")
            End If
            
            If requestRows.Length > 0 Then
                requestData = requestRows(0)
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[PropertyCard] LoadRequestData error: {ex.Message}")
        End Try
    End Sub

    Private Sub PropertyCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Property Acknowledgment Receipt"
        Me.Size = New Size(650, 700)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MinimumSize = New Size(650, 700)

        EnsureFullPropertyData()

        ' Create main panel for card
        Dim panelCard As New Panel()
        panelCard.Dock = DockStyle.Fill
        panelCard.Padding = New Padding(20)
        panelCard.BackColor = Color.White
        panelCard.AutoScroll = True
        Me.Controls.Add(panelCard)

        ' Title
        Dim lblTitle As New Label()
        lblTitle.Text = "PROPERTY ACKNOWLEDGMENT RECEIPT"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Dock = DockStyle.Top
        lblTitle.Height = 50
        panelCard.Controls.Add(lblTitle)

        ' Create details panel
        Dim detailsPanel As New Panel()
        detailsPanel.Dock = DockStyle.Top
        detailsPanel.Height = 450
        detailsPanel.Top = 50
        panelCard.Controls.Add(detailsPanel)

        ' Create details labels
        Dim yPos As Integer = 10
        Dim spacing As Integer = 30

        If requestData IsNot Nothing Then
            ' Use request data for display
            AddLabel(detailsPanel, "Request ID: " & GetRequestFieldValue("requestId", "request_id"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Requester Name: " & GetRequestFieldValue("requesterName", "requester_name"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Position: " & GetRequestFieldValue("position"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Department: " & GetRequestFieldValue("department", "departmentName"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Item Name: " & GetRequestFieldValue("itemName", "item_name"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Description: " & GetRequestFieldValue("description"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Quantity: " & GetRequestFieldValue("quantityRequested", "quantity_requested"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Purpose: " & GetRequestFieldValue("purpose"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Date of Request: " & GetRequestFieldValue("dateOfRequest", "date_of_request"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Status: " & GetRequestFieldValue("status"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Date Issued: " & DateTime.Now.ToString("yyyy-MM-dd"), yPos) : yPos += spacing
        Else
            ' Use property data for display
            AddLabel(detailsPanel, "Property ID: " & GetFieldValue("propertyId", "property_id"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Property Name: " & GetFieldValue("itemName", "item_name", "property_name"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Category: " & GetFieldValue("category"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Serial Number: " & GetFieldValue("serialNumber", "serial_number"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Supplier: " & GetFieldValue("supplier", "supplier_name"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Condition: " & GetFieldValue("condition", "condition_status"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Acquisition Cost: " & GetFieldValue("acquisitionCost", "acquisition_cost"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Acquisition Date: " & GetFieldValue("acquisitionDate", "acquisition_date"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Assigned Employee: " & GetFieldValue("assignedEmployee", "assigned_employee"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Assigned Department: " & GetFieldValue("assignedDepartment", "assigned_department", "departmentName"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Location: " & GetFieldValue("location"), yPos) : yPos += spacing
            AddLabel(detailsPanel, "Status: " & GetFieldValue("status"), yPos) : yPos += spacing
        End If

        ' Create button panel
        Dim buttonPanel As New Panel()
        buttonPanel.Dock = DockStyle.Bottom
        buttonPanel.Height = 60
        buttonPanel.Padding = New Padding(20, 10, 20, 10)
        panelCard.Controls.Add(buttonPanel)

        ' Export CSV Button
        Dim btnExportCSV As New Button()
        btnExportCSV.Text = "Export CSV"
        btnExportCSV.Size = New Size(120, 35)
        btnExportCSV.Location = New Point(20, 10)
        btnExportCSV.BackColor = Color.FromArgb(27, 60, 83)
        btnExportCSV.ForeColor = Color.White
        btnExportCSV.FlatStyle = FlatStyle.Flat
        AddHandler btnExportCSV.Click, AddressOf ExportToCSV
        buttonPanel.Controls.Add(btnExportCSV)

        ' Export PDF Button
        Dim btnExportPDF As New Button()
        btnExportPDF.Text = "Export PDF"
        btnExportPDF.Size = New Size(120, 35)
        btnExportPDF.Location = New Point(150, 10)
        btnExportPDF.BackColor = Color.FromArgb(27, 60, 83)
        btnExportPDF.ForeColor = Color.White
        btnExportPDF.FlatStyle = FlatStyle.Flat
        AddHandler btnExportPDF.Click, AddressOf ExportToPDF
        buttonPanel.Controls.Add(btnExportPDF)

        ' Close Button
        Dim btnClose As New Button()
        btnClose.Text = "Close"
        btnClose.Size = New Size(120, 35)
        btnClose.Location = New Point(280, 10)
        btnClose.BackColor = Color.Gray
        btnClose.ForeColor = Color.White
        btnClose.FlatStyle = FlatStyle.Flat
        AddHandler btnClose.Click, Sub() Me.Close()
        buttonPanel.Controls.Add(btnClose)
    End Sub

    Private Sub EnsureFullPropertyData()
        If propertyData Is Nothing Then
            MessageBox.Show("Property details are unavailable.", "Property Card", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim needsRefresh As Boolean =
            Not HasColumn("supplier_name") OrElse
            Not HasColumn("assigned_employee") OrElse
            Not HasColumn("assigned_department") OrElse
            Not HasColumn("warranty_details")

        If needsRefresh AndAlso propertyID > 0 Then
            Dim detailedRow As DataRow = modDB.GetPropertyDetails(propertyID)
            If detailedRow IsNot Nothing Then
                propertyData = detailedRow
            End If
        End If
    End Sub

    Private Function HasColumn(columnName As String) As Boolean
        Return propertyData IsNot Nothing AndAlso propertyData.Table IsNot Nothing AndAlso propertyData.Table.Columns.Contains(columnName)
    End Function

    Private Function GetFieldValue(ParamArray names() As String) As String
        If propertyData Is Nothing Then Return ""
        For Each fieldName As String In names
            If HasColumn(fieldName) Then
                If Convert.IsDBNull(propertyData(fieldName)) Then
                    Return ""
                End If
                Return propertyData(fieldName).ToString()
            End If
        Next
        Return ""
    End Function

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

    Private Sub AddLabel(parent As Control, text As String, y As Integer)
        Dim lbl As New Label()
        lbl.Text = text
        lbl.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lbl.Location = New Point(20, y)
        lbl.AutoSize = True
        parent.Controls.Add(lbl)
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
            Else
                ' Export property data
                dt.Rows.Add("Property ID", GetFieldValue("propertyId", "property_id"))
                dt.Rows.Add("Property Name", GetFieldValue("itemName", "item_name", "property_name"))
                dt.Rows.Add("Category", GetFieldValue("category"))
                dt.Rows.Add("Serial Number", GetFieldValue("serialNumber", "serial_number"))
                dt.Rows.Add("Supplier", GetFieldValue("supplier", "supplier_name"))
                dt.Rows.Add("Condition", GetFieldValue("condition", "condition_status"))
                dt.Rows.Add("Acquisition Cost", GetFieldValue("acquisitionCost", "acquisition_cost"))
                dt.Rows.Add("Acquisition Date", GetFieldValue("acquisitionDate", "acquisition_date"))
                dt.Rows.Add("Assigned Employee", GetFieldValue("assignedEmployee", "assigned_employee"))
                dt.Rows.Add("Assigned Department", GetFieldValue("assignedDepartment", "assigned_department", "departmentName"))
                dt.Rows.Add("Location", GetFieldValue("location"))
                dt.Rows.Add("Status", GetFieldValue("status"))
            End If

            Dim fileName As String = $"PropertyAcknowledgment_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            ReportExportHelper.ExportDataTableToCsv(dt, fileName, "Property Acknowledgment exported successfully.")
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
            Else
                ' Export property data
                dt.Rows.Add("Property ID", GetFieldValue("propertyId", "property_id"))
                dt.Rows.Add("Property Name", GetFieldValue("itemName", "item_name", "property_name"))
                dt.Rows.Add("Category", GetFieldValue("category"))
                dt.Rows.Add("Serial Number", GetFieldValue("serialNumber", "serial_number"))
                dt.Rows.Add("Supplier", GetFieldValue("supplier", "supplier_name"))
                dt.Rows.Add("Condition", GetFieldValue("condition", "condition_status"))
                dt.Rows.Add("Acquisition Cost", GetFieldValue("acquisitionCost", "acquisition_cost"))
                dt.Rows.Add("Acquisition Date", GetFieldValue("acquisitionDate", "acquisition_date"))
                dt.Rows.Add("Assigned Employee", GetFieldValue("assignedEmployee", "assigned_employee"))
                dt.Rows.Add("Assigned Department", GetFieldValue("assignedDepartment", "assigned_department", "departmentName"))
                dt.Rows.Add("Location", GetFieldValue("location"))
                dt.Rows.Add("Status", GetFieldValue("status"))
            End If

            Dim fileName As String = $"PropertyAcknowledgment_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            ReportExportHelper.ExportDataTableToPdf(dt, fileName, "PROPERTY ACKNOWLEDGMENT RECEIPT", "Property Acknowledgment exported successfully.")
        Catch ex As Exception
            MessageBox.Show("Error exporting to PDF: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
