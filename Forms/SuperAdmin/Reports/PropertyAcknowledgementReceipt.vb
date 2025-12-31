Imports System
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Diagnostics
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Partial Class PropertyAcknowledgementReceipt
    Private currentRequestID As Integer?
    Private currentRequestType As String
    Private requestData As DataRow = Nothing

    ' Default constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Constructor with property ID (single integer parameter)
    Public Sub New(propertyID As Integer)
        InitializeComponent()
        ' Load property data directly from properties table
        LoadPropertyData(propertyID)
    End Sub
    
    ' Constructor with request ID and type (two parameters)
    Public Sub New(requestID As Integer, requestType As String)
        InitializeComponent()
        currentRequestID = requestID
        currentRequestType = requestType
        LoadRequestData(requestID, requestType)
    End Sub

    Private Sub LoadPropertyData(propertyID As Integer)
        Try
            System.Diagnostics.Debug.WriteLine($"[PropertyAcknowledgementReceipt] Loading property ID: {propertyID}")
            
            ' Get property data directly from properties table
            requestData = DatabaseConnection.GetPropertyById(propertyID)
            
            If requestData Is Nothing Then
                MessageBox.Show("Property data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            
            ' Store property ID for reference
            currentRequestID = propertyID
            currentRequestType = "property"
            
            ' Populate form fields
            PopulateFormFields()
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[PropertyAcknowledgementReceipt] Error loading property: {ex.Message}")
            MessageBox.Show($"Error loading property data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadRequestData(requestID As Integer, requestType As String)
        Try
            System.Diagnostics.Debug.WriteLine($"[PropertyAcknowledgementReceipt] Loading request ID: {requestID}, Type: {requestType}")
            
            ' Get request data from database
            requestData = DatabaseConnection.GetRequestById(requestID, requestType)
            
            If requestData Is Nothing Then
                MessageBox.Show("Request data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            
            ' Populate form fields
            PopulateFormFields()
            
        Catch ex As System.Exception
            System.Diagnostics.Debug.WriteLine($"[PropertyAcknowledgementReceipt] Error loading request: {ex.Message}")
            MessageBox.Show($"Error loading request data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateFormFields()
        Try
            If requestData Is Nothing Then Return

            ' Request Information - Use propertyId as request_id for properties
            Dim reqId As String = SafeGetValue(requestData, "request_id", "requestId", "propertyId")
            If Not String.IsNullOrEmpty(reqId) Then
                requestID.Text = reqId
            End If
            
            ' Requester Name - use assigned user or "N/A" if not assigned
            Dim requesterValue As String = SafeGetValue(requestData, "requesterName", "requester_name")
            If String.IsNullOrEmpty(requesterValue) Then
                requesterValue = "Not Assigned"
            End If
            requesterName.Text = requesterValue
            
            ' Position - set as textbox value or combobox
            Dim posValue As String = SafeGetValue(requestData, "position", "requester_position")
            If String.IsNullOrEmpty(posValue) Then
                posValue = "N/A"
            End If
            If Not String.IsNullOrEmpty(posValue) Then
                If position.Items.Count = 0 Then
                    position.Items.Add(posValue)
                End If
                position.Text = posValue
                If position.Items.Contains(posValue) Then
                    position.SelectedItem = posValue
                End If
            End If
            
            ' Department - set as combobox
            Dim deptValue As String = SafeGetValue(requestData, "departmentName", "department")
            If String.IsNullOrEmpty(deptValue) Then
                deptValue = "N/A"
            End If
            If Not String.IsNullOrEmpty(deptValue) Then
                If department.Items.Count = 0 Then
                    department.Items.Add(deptValue)
                End If
                department.Text = deptValue
                If department.Items.Contains(deptValue) Then
                    department.SelectedItem = deptValue
                End If
            End If
            
            ' Set Date of Request - use acquisitionDate for properties
            Dim requestDate As String = SafeGetValue(requestData, "request_date", "dateOfRequest", "acquisitionDate")
            If Not String.IsNullOrEmpty(requestDate) Then
                Dim parsedDate As DateTime
                If DateTime.TryParse(requestDate, parsedDate) Then
                    dateOfRequest.Value = parsedDate
                Else
                    dateOfRequest.Value = DateTime.Now
                End If
            Else
                dateOfRequest.Value = DateTime.Now
            End If

            ' Item Details
            itemName.Text = SafeGetValue(requestData, "item_name", "itemName")
            description.Text = SafeGetValue(requestData, "description")
            
            ' Purpose - use default if empty
            Dim purposeValue As String = SafeGetValue(requestData, "purpose")
            If String.IsNullOrEmpty(purposeValue) Then
                purposeValue = "Property issued for use"
            End If
            purpose.Text = purposeValue
            
            ' Quantity and Unit
            Dim quantityValue As String = SafeGetValue(requestData, "quantity", "quantityRequested")
            If String.IsNullOrEmpty(quantityValue) Then
                quantityValue = "1"
            End If
            If Not String.IsNullOrEmpty(quantityValue) Then
                If quantityRequesteed.Items.Count = 0 Then
                    quantityRequesteed.Items.Add(quantityValue)
                End If
                quantityRequesteed.Text = quantityValue
                If quantityRequesteed.Items.Contains(quantityValue) Then
                    quantityRequesteed.SelectedItem = quantityValue
                End If
            End If
            
            Dim unitValue As String = SafeGetValue(requestData, "unit", "unitOfMeasure")
            If String.IsNullOrEmpty(unitValue) Then
                unitValue = "pc"
            End If
            If Not String.IsNullOrEmpty(unitValue) Then
                If unit.Items.Count = 0 Then
                    unit.Items.Add(unitValue)
                End If
                unit.Text = unitValue
                If unit.Items.Contains(unitValue) Then
                    unit.SelectedItem = unitValue
                End If
            End If

            ' Status and Approval
            Dim statusValue As String = SafeGetValue(requestData, "status")
            If String.IsNullOrEmpty(statusValue) Then
                statusValue = "Active"
            End If
            If Not String.IsNullOrEmpty(statusValue) Then
                If status.Items.Count = 0 Then
                    status.Items.Add(statusValue)
                End If
                status.Text = statusValue
                If status.Items.Contains(statusValue) Then
                    status.SelectedItem = statusValue
                End If
            End If
            
            Dim approvedByValue As String = SafeGetValue(requestData, "approved_by_name", "approvedBy")
            If String.IsNullOrEmpty(approvedByValue) Then
                approvedByValue = "Administrator"
            End If
            If Not String.IsNullOrEmpty(approvedByValue) Then
                If approvedBy.Items.Count = 0 Then
                    approvedBy.Items.Add(approvedByValue)
                End If
                approvedBy.Text = approvedByValue
                If approvedBy.Items.Contains(approvedByValue) Then
                    approvedBy.SelectedItem = approvedByValue
                End If
            End If
            
            ' Set Approved Date
            Dim approvalDate As String = SafeGetValue(requestData, "approval_date", "approvedDate", "createdAt")
            If Not String.IsNullOrEmpty(approvalDate) Then
                Dim parsedDate As DateTime
                If DateTime.TryParse(approvalDate, parsedDate) Then
                    approvedDate.Value = parsedDate
                Else
                    approvedDate.Value = DateTime.Now
                End If
            Else
                approvedDate.Value = DateTime.Now
            End If

            ' Remarks
            Dim remarksValue As String = SafeGetValue(requestData, "remarks")
            If String.IsNullOrEmpty(remarksValue) Then
                remarksValue = "Property Acknowledgement Receipt"
            End If
            remarks.Text = remarksValue

            ' Set Created/Updated dates from data or current date
            Dim createdValue As String = SafeGetValue(requestData, "createdAt")
            If Not String.IsNullOrEmpty(createdValue) Then
                Dim parsedDate As DateTime
                If DateTime.TryParse(createdValue, parsedDate) Then
                    DateTimePicker1.Value = parsedDate
                Else
                    DateTimePicker1.Value = DateTime.Now
                End If
            Else
                DateTimePicker1.Value = DateTime.Now
            End If
            
            Dim updatedValue As String = SafeGetValue(requestData, "updatedAt")
            If Not String.IsNullOrEmpty(updatedValue) Then
                Dim parsedDate As DateTime
                If DateTime.TryParse(updatedValue, parsedDate) Then
                    DateTimePicker2.Value = parsedDate
                Else
                    DateTimePicker2.Value = DateTime.Now
                End If
            Else
                DateTimePicker2.Value = DateTime.Now
            End If
            
            System.Diagnostics.Debug.WriteLine("[PropertyAcknowledgementReceipt] Form populated successfully")
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[PropertyAcknowledgementReceipt] Error populating form: {ex.Message}")
            MessageBox.Show($"Error populating form fields: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function SafeGetValue(row As DataRow, ParamArray names() As String) As String
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not Convert.IsDBNull(row(name)) Then
                Return row(name).ToString()
            End If
        Next
        Return ""
    End Function

    Private Sub position_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles position.SelectedIndexChanged

    End Sub

    Private Sub Panel11_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel11.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub approvedDate_ValueChanged(sender As Object, e As System.EventArgs) Handles approvedDate.ValueChanged

    End Sub

    Private Sub lblPropertyCard_Click(sender As Object, e As System.EventArgs) Handles lblPropertyCard.Click

    End Sub

    Private Sub btnCSV_Click(sender As Object, e As System.EventArgs) Handles btnCSV.Click
        ExportToCSV()
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As System.EventArgs) Handles btnPDF.Click
        ExportToPDF()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As System.EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    Private Sub ExportToCSV()
        Try
            If requestData Is Nothing Then
                MessageBox.Show("No data to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Create CSV data table with professional formatting
            Dim csvTable As New DataTable()
            csvTable.Columns.Add("Field", GetType(String))
            csvTable.Columns.Add("Value", GetType(String))

            ' Header
            csvTable.Rows.Add("PROPERTY ACKNOWLEDGEMENT RECEIPT", "")
            csvTable.Rows.Add("", "")
            csvTable.Rows.Add("Sta Cruz Property Custodian System", "")
            csvTable.Rows.Add("Generated: " & DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"), "")
            csvTable.Rows.Add("", "")
            csvTable.Rows.Add("================================================================================", "")
            csvTable.Rows.Add("", "")

            ' Request Information Section
            csvTable.Rows.Add("=== REQUEST INFORMATION ===", "")
            csvTable.Rows.Add("Request ID", requestID.Text)
            csvTable.Rows.Add("Date of Request", dateOfRequest.Value.ToString("dddd, dd MMMM yyyy"))
            csvTable.Rows.Add("Status", If(status.SelectedItem?.ToString(), ""))
            csvTable.Rows.Add("", "")

            ' Requester Details Section
            csvTable.Rows.Add("=== REQUESTER DETAILS ===", "")
            csvTable.Rows.Add("Requester Name", requesterName.Text)
            csvTable.Rows.Add("Position", If(position.SelectedItem?.ToString(), ""))
            csvTable.Rows.Add("Department", If(department.SelectedItem?.ToString(), ""))
            csvTable.Rows.Add("", "")

            ' Item Details Section
            csvTable.Rows.Add("=== ITEM DETAILS ===", "")
            csvTable.Rows.Add("Item Name", itemName.Text)
            csvTable.Rows.Add("Quantity", If(quantityRequesteed.SelectedItem?.ToString(), ""))
            csvTable.Rows.Add("Unit of Measure", If(unit.SelectedItem?.ToString(), ""))
            csvTable.Rows.Add("Description", description.Text)
            csvTable.Rows.Add("Purpose", purpose.Text)
            csvTable.Rows.Add("", "")

            ' Approval Information Section
            csvTable.Rows.Add("=== APPROVAL INFORMATION ===", "")
            csvTable.Rows.Add("Approved By", If(approvedBy.SelectedItem?.ToString(), ""))
            csvTable.Rows.Add("Approved Date", approvedDate.Value.ToString("dddd, dd MMMM yyyy HH:mm:ss"))
            csvTable.Rows.Add("Remarks", remarks.Text)
            csvTable.Rows.Add("", "")

            ' Footer
            csvTable.Rows.Add("================================================================================", "")
            csvTable.Rows.Add("Created at", DateTimePicker1.Value.ToString("dddd, dd MMMM yyyy"))
            csvTable.Rows.Add("Updated at", DateTimePicker2.Value.ToString("dddd, dd MMMM yyyy"))
            csvTable.Rows.Add("", "")
            csvTable.Rows.Add("End of Report", "")

            ' Export using ReportExportHelper
            Dim fileName As String = $"PropertyAcknowledgementReceipt_{requestID.Text}_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            ReportExportHelper.ExportDataTableToCsv(csvTable, fileName, "Property Acknowledgement Receipt exported successfully to CSV!")

        Catch ex As Exception
            MessageBox.Show($"Error exporting to CSV: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine($"[PropertyAcknowledgementReceipt] CSV Export Error: {ex.Message}")
        End Try
    End Sub

    Private Sub ExportToPDF()
        Try
            If requestData Is Nothing Then
                MessageBox.Show("No data to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Use the existing ReportExportHelper for PDF generation
            Dim fileName As String = $"PropertyAcknowledgementReceipt_{requestID.Text}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            
            ' Call the existing PDF export helper
            Using saveDialog As New SaveFileDialog()
                saveDialog.Filter = "PDF Files (*.pdf)|*.pdf"
                saveDialog.Title = "Save Property Acknowledgement Receipt as PDF"
                saveDialog.FileName = fileName

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    Try
                        Dim filePath As String = saveDialog.FileName
                        If Not filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) Then
                            filePath = filePath & ".pdf"
                        End If

                        ' Build PDF using custom method
                        Dim pdfBytes As Byte() = BuildPropertyAcknowledgementPdf()
                        System.IO.File.WriteAllBytes(filePath, pdfBytes)
                        
                        MessageBox.Show("Property Acknowledgement Receipt exported successfully to PDF!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        
                        ' Ask if user wants to open the file
                        Dim result As DialogResult = MessageBox.Show("Would you like to open the PDF file?", "Open PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If result = DialogResult.Yes Then
                            Process.Start(filePath)
                        End If
                    Catch ex As Exception
                        MessageBox.Show($"Failed to export PDF file: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error exporting to PDF: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine($"[PropertyAcknowledgementReceipt] PDF Export Error: {ex.Message}")
        End Try
    End Sub

    Private Function BuildPropertyAcknowledgementPdf() As Byte()
        ' Build PDF content similar to RequisitionIssueSlip
        Dim streamContent As String = BuildPropertyAcknowledgementPdfContent()
        Dim streamBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(streamContent)

        Dim objects As New List(Of Byte())()
        objects.Add(System.Text.Encoding.ASCII.GetBytes("1 0 obj << /Type /Catalog /Pages 2 0 R >> endobj" & Environment.NewLine))
        objects.Add(System.Text.Encoding.ASCII.GetBytes("2 0 obj << /Type /Pages /Kids [3 0 R] /Count 1 >> endobj" & Environment.NewLine))
        objects.Add(System.Text.Encoding.ASCII.GetBytes("3 0 obj << /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Contents 4 0 R /Resources << /Font << /F1 5 0 R /F2 6 0 R >> >> >> endobj" & Environment.NewLine))

        Dim streamBuilder As New System.Text.StringBuilder()
        streamBuilder.AppendLine("4 0 obj << /Length " & streamBytes.Length & " >>")
        streamBuilder.AppendLine("stream")
        streamBuilder.Append(streamContent)
        streamBuilder.AppendLine("endstream")
        streamBuilder.AppendLine("endobj")
        objects.Add(System.Text.Encoding.UTF8.GetBytes(streamBuilder.ToString()))

        objects.Add(System.Text.Encoding.ASCII.GetBytes("5 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Helvetica >> endobj" & Environment.NewLine))
        objects.Add(System.Text.Encoding.ASCII.GetBytes("6 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold >> endobj" & Environment.NewLine))

        Using ms As New MemoryStream()
            Using bw As New BinaryWriter(ms, System.Text.Encoding.ASCII, True)
                bw.Write(System.Text.Encoding.ASCII.GetBytes("%PDF-1.4" & Environment.NewLine))
                Dim offsets As New List(Of Long)()
                For Each objBytes In objects
                    offsets.Add(ms.Position)
                    bw.Write(objBytes)
                Next

                Dim xrefPosition As Long = ms.Position
                bw.Write(System.Text.Encoding.ASCII.GetBytes("xref" & Environment.NewLine & "0 " & (objects.Count + 1).ToString() & Environment.NewLine))
                bw.Write(System.Text.Encoding.ASCII.GetBytes("0000000000 65535 f " & Environment.NewLine))
                For Each off As Long In offsets
                    bw.Write(System.Text.Encoding.ASCII.GetBytes(off.ToString("D10") & " 00000 n " & Environment.NewLine))
                Next

                bw.Write(System.Text.Encoding.ASCII.GetBytes("trailer" & Environment.NewLine & "<< /Size " & (objects.Count + 1).ToString() & " /Root 1 0 R >>" & Environment.NewLine))
                bw.Write(System.Text.Encoding.ASCII.GetBytes("startxref" & Environment.NewLine & xrefPosition.ToString() & Environment.NewLine & "%%EOF"))
            End Using
            Return ms.ToArray()
        End Using
    End Function

    Private Function BuildPropertyAcknowledgementPdfContent() As String
        Dim builder As New System.Text.StringBuilder()
        Dim y As Integer = 740
        
        ' Helper function to escape PDF text
        Dim EscapePdfText As Func(Of String, String) = Function(text As String) As String
            If text Is Nothing Then text = String.Empty
            Return text.Replace("\", "\\").Replace("(", "\(").Replace(")", "\)").Replace(vbCr, " ").Replace(vbLf, " ")
        End Function
        
        ' Helper to draw multi-line text in a box
        Dim DrawMultiLineText As Action(Of Integer, Integer, Integer, Integer, String) = Sub(x As Integer, yPos As Integer, width As Integer, height As Integer, text As String)
            ' Draw box
            builder.AppendLine($"{x} {yPos - height} {width} {height} re S")
            
            ' Draw text inside box (simplified - just first line for now)
            Dim textY As Integer = yPos - 15
            Dim escapedText As String = EscapePdfText(text)
            
            ' Split into lines if too long
            Dim maxChars As Integer = If(width > 300, 60, 30)
            If escapedText.Length > maxChars Then
                escapedText = escapedText.Substring(0, maxChars) & "..."
            End If
            
            builder.AppendLine($"BT /F1 8 Tf {x + 5} {textY} Td ({escapedText}) Tj ET")
        End Sub
        
        ' Draw outer border
        builder.AppendLine("0.5 w")
        builder.AppendLine("40 40 532 712 re S")
        
        ' Draw header box with background
        builder.AppendLine("0.9 g")
        builder.AppendLine("40 720 532 32 re f")
        builder.AppendLine("0 g")
        builder.AppendLine("40 720 532 32 re S")
        
        ' Title - PROPERTY ACKNOWLEDGEMENT RECEIPT (Bold, centered)
        builder.AppendLine("BT /F2 16 Tf 120 728 Td (PROPERTY ACKNOWLEDGEMENT RECEIPT) Tj ET")
        
        y = 695
        
        ' First row: Request ID (right aligned)
        builder.AppendLine("BT /F1 10 Tf 380 " & y & " Td (Request ID:) Tj ET")
        builder.AppendLine("450 " & (y - 5) & " 110 20 re S")
        builder.AppendLine("BT /F1 9 Tf 455 " & (y - 1) & " Td (" & EscapePdfText(requestID.Text) & ") Tj ET")
        
        y -= 40
        
        ' Second row: Requester Name and Position
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Requester Name:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 200 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(requesterName.Text) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 360 " & y & " Td (Position:) Tj ET")
        builder.AppendLine("420 " & (y - 5) & " 140 20 re S")
        builder.AppendLine("BT /F1 9 Tf 425 " & (y - 1) & " Td (" & EscapePdfText(If(position.SelectedItem?.ToString(), "")) & ") Tj ET")
        
        y -= 30
        
        ' Third row: Department and Date of Request
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Department:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 200 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(If(department.SelectedItem?.ToString(), "")) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 360 " & y & " Td (Date of Request:) Tj ET")
        builder.AppendLine("455 " & (y - 5) & " 105 20 re S")
        builder.AppendLine("BT /F1 9 Tf 460 " & (y - 1) & " Td (" & EscapePdfText(dateOfRequest.Value.ToString("dd/MM/yyyy")) & ") Tj ET")
        
        y -= 40
        
        ' Fourth row: Item Name and Quantity
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Item Name:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 200 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(itemName.Text) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 360 " & y & " Td (Quantity:) Tj ET")
        builder.AppendLine("420 " & (y - 5) & " 60 20 re S")
        builder.AppendLine("BT /F1 9 Tf 425 " & (y - 1) & " Td (" & EscapePdfText(If(quantityRequesteed.SelectedItem?.ToString(), "")) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 490 " & y & " Td (Unit:) Tj ET")
        builder.AppendLine("520 " & (y - 5) & " 40 20 re S")
        builder.AppendLine("BT /F1 9 Tf 525 " & (y - 1) & " Td (" & EscapePdfText(If(unit.SelectedItem?.ToString(), "")) & ") Tj ET")
        
        y -= 40
        
        ' Description section (left side)
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Description:) Tj ET")
        DrawMultiLineText(50, y - 10, 250, 90, description.Text)
        
        ' Purpose section (right side)
        builder.AppendLine("BT /F1 10 Tf 310 " & y & " Td (Purpose:) Tj ET")
        DrawMultiLineText(310, y - 10, 250, 90, purpose.Text)
        
        y -= 110
        
        ' Status row
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Status:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 200 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(If(status.SelectedItem?.ToString(), "")) & ") Tj ET")
        
        y -= 40
        
        ' Approved By and Approved Date
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Approved By:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 200 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(If(approvedBy.SelectedItem?.ToString(), "")) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 360 " & y & " Td (Approved Date:) Tj ET")
        builder.AppendLine("455 " & (y - 5) & " 105 20 re S")
        builder.AppendLine("BT /F1 9 Tf 460 " & (y - 1) & " Td (" & EscapePdfText(approvedDate.Value.ToString("dd/MM/yyyy")) & ") Tj ET")
        
        y -= 40
        
        ' Remarks section
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Remarks:) Tj ET")
        DrawMultiLineText(50, y - 10, 510, 70, remarks.Text)
        
        y -= 90
        
        ' Created and Updated dates
        builder.AppendLine("BT /F1 10 Tf 50 " & y & " Td (Created at:) Tj ET")
        builder.AppendLine("145 " & (y - 5) & " 150 20 re S")
        builder.AppendLine("BT /F1 9 Tf 150 " & (y - 1) & " Td (" & EscapePdfText(DateTimePicker1.Value.ToString("dd/MM/yyyy")) & ") Tj ET")
        
        builder.AppendLine("BT /F1 10 Tf 360 " & y & " Td (Updated at:) Tj ET")
        builder.AppendLine("455 " & (y - 5) & " 105 20 re S")
        builder.AppendLine("BT /F1 9 Tf 460 " & (y - 1) & " Td (" & EscapePdfText(DateTimePicker2.Value.ToString("dd/MM/yyyy")) & ") Tj ET")
        
        Return builder.ToString()
    End Function

    Private Sub PropertyAcknowledgementReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class