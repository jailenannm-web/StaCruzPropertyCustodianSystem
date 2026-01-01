Imports System
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class MaintenanceManagementReport1
    Inherits UserControl

    Private currentMaintenanceID As Integer? = Nothing
    Private maintenanceData As DataRow = Nothing

    ' Parameterless constructor for UserControl
    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        InitializeForm()
    End Sub

    ' Constructor with maintenanceId to load specific record
    Public Sub New(maintenanceId As Integer)
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        InitializeForm()
        LoadMaintenanceData(maintenanceId)
    End Sub

    Private Sub InitializeForm()
        ' Populate dropdowns
        PopulateComboBoxes()
        
        ' Set up event handlers
        AddHandler btnPDF.Click, AddressOf btnPDF_Click
        AddHandler btnCSV.Click, AddressOf btnCSV_Click
        AddHandler btnBack.Click, AddressOf btnBack_Click
    End Sub

    Private Sub PopulateComboBoxes()
        ' Type of Maintenance
        typeOfMaintenance.Items.Clear()
        typeOfMaintenance.Items.AddRange(New String() {"Repair", "Replace", "Servicing"})
        
        ' Status
        status.Items.Clear()
        status.Items.AddRange(New String() {"Completed", "Ongoing", "For Review"})
        
        ' Action Taken
        actionTaken.Items.Clear()
        actionTaken.Items.AddRange(New String() {"Repaired", "Replaced", "Serviced", "Parts Replaced"})
        
        ' Assigned Technician - Load from database
        LoadTechnicians()
    End Sub

    Private Sub LoadTechnicians()
        Try
            Dim conn As MySqlConnection = modDB.GetConnection()
            If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
                Dim query As String = "SELECT DISTINCT assignedTechnician FROM maintenance WHERE assignedTechnician IS NOT NULL AND assignedTechnician <> '' ORDER BY assignedTechnician"
                
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        assignedTechnician.Items.Clear()
                        While reader.Read()
                            assignedTechnician.Items.Add(reader("assignedTechnician").ToString())
                        End While
                    End Using
                End Using
                conn.Close()
            End If
        Catch ex As Exception
            Debug.WriteLine("Error loading technicians: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadMaintenanceData(maintenanceId As Integer)
        Try
            currentMaintenanceID = maintenanceId
            Debug.WriteLine($"[MaintenanceManagementReport1] Loading data for ID: {maintenanceId}")
            
            Dim conn As MySqlConnection = modDB.GetConnection()
            If conn IsNot Nothing AndAlso modDB.SafeOpenConnection(conn) Then
                Dim query As String = "SELECT m.*, d.departmentName " &
                                     "FROM maintenance m " &
                                     "LEFT JOIN departments d ON m.departmentId = d.departmentId " &
                                     "WHERE m.maintenanceId = @maintenanceId"
                
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@maintenanceId", maintenanceId)
                    
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        
                        If dt.Rows.Count > 0 Then
                            maintenanceData = dt.Rows(0)
                            Debug.WriteLine("[MaintenanceManagementReport1] Data loaded successfully")
                            PopulateFormFields()
                        Else
                            MessageBox.Show("Maintenance record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
                conn.Close()
            End If
        Catch ex As Exception
            Debug.WriteLine($"[MaintenanceManagementReport1] Error: {ex.Message}")
            MessageBox.Show("Error loading maintenance data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateFormFields()
        If maintenanceData Is Nothing Then Return
        
        Try
            Debug.WriteLine("[MaintenanceManagementReport1] Populating form fields...")
            
            ' Basic Info
            maintenanceId.Text = SafeGetValue("maintenanceId")
            requestId.Text = SafeGetValue("requestId")
            propertyItemName.Text = SafeGetValue("propertyItemName")
            serialId.Text = SafeGetValue("serialNumber")
            location.Text = SafeGetValue("location")
            departmentId.Text = SafeGetValue("departmentId")
            
            ' Maintenance Details
            Dim maintType = SafeGetValue("typeOfMaintenance")
            If Not String.IsNullOrEmpty(maintType) Then
                typeOfMaintenance.SelectedItem = maintType
            End If
            
            Dim techName = SafeGetValue("assignedTechnician")
            If Not String.IsNullOrEmpty(techName) Then
                assignedTechnician.Text = techName
            End If
            
            conditionBeforeMaintenance.Text = SafeGetValue("conditionBeforeMaint")
            maintenanceDetail.Text = SafeGetValue("maintenanceDetails")
            
            If Not Information.IsDBNull(maintenanceData("maintenanceDate")) Then
                maintenanceDate.Value = Convert.ToDateTime(maintenanceData("maintenanceDate"))
            End If
            
            costMaterialsLabor.Text = SafeGetValue("costMaterialsLabor")
            conditionAfterMaintenance.Text = SafeGetValue("conditionAfterMaint")
            
            ' Status and Additional Fields
            Dim statusValue = SafeGetValue("status")
            If Not String.IsNullOrEmpty(statusValue) Then
                status.SelectedItem = statusValue
            End If
            
            diagnosis.Text = SafeGetValue("diagnosis")
            
            Dim actionValue = SafeGetValue("actionTaken")
            If Not String.IsNullOrEmpty(actionValue) Then
                actionTaken.Text = actionValue
            End If
            
            partsReplaced.Text = SafeGetValue("partsReplaced")
            
            Debug.WriteLine("[MaintenanceManagementReport1] Form populated successfully")
        Catch ex As Exception
            Debug.WriteLine($"[MaintenanceManagementReport1] Error populating fields: {ex.Message}")
            MessageBox.Show("Error populating form fields: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function SafeGetValue(fieldName As String) As String
        Try
            If maintenanceData IsNot Nothing AndAlso Not Information.IsDBNull(maintenanceData(fieldName)) Then
                Return maintenanceData(fieldName).ToString()
            End If
        Catch ex As Exception
            Debug.WriteLine($"Error getting field {fieldName}: {ex.Message}")
        End Try
        Return ""
    End Function

    ' Export to PDF
    Private Sub btnPDF_Click(sender As Object, e As EventArgs)
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf"
            saveDialog.FileName = $"MaintenanceReport_{maintenanceId.Text}_{DateTime.Now:yyyyMMdd}.pdf"
            
            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportToPDF(saveDialog.FileName)
                MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                
                ' Ask if user wants to open the file
                If MessageBox.Show("Do you want to open the PDF file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Process.Start(saveDialog.FileName)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting to PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToPDF(filePath As String)
        ' Create PDF document
        Dim doc As New Document(PageSize.A4, 50, 50, 50, 50)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))
        
        doc.Open()
        
        ' Define fonts
        Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD)
        Dim headerFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD)
        Dim normalFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)
        Dim smallFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.ITALIC)
        
        ' Gray color for label background
        Dim grayColor As New BaseColor(245, 245, 245)
        
        ' Title
        Dim title As New Paragraph("MAINTENANCE MANAGEMENT REPORT", titleFont)
        title.Alignment = Element.ALIGN_CENTER
        title.SpacingAfter = 20
        doc.Add(title)
        
        ' Section 1: Basic Information
        Dim table1 As New PdfPTable(4)
        table1.WidthPercentage = 100
        table1.SetWidths(New Single() {1.5F, 2.5F, 1.5F, 2.5F})
        table1.SpacingBefore = 0
        table1.SpacingAfter = 10
        
        AddPdfCell(table1, "Maintenance ID:", headerFont, grayColor)
        AddPdfCell(table1, maintenanceId.Text, normalFont, BaseColor.WHITE)
        AddPdfCell(table1, "Request ID:", headerFont, grayColor)
        AddPdfCell(table1, requestId.Text, normalFont, BaseColor.WHITE)
        
        AddPdfCell(table1, "Property Item Name:", headerFont, grayColor)
        AddPdfCell(table1, propertyItemName.Text, normalFont, BaseColor.WHITE)
        AddPdfCell(table1, "Serial Number:", headerFont, grayColor)
        AddPdfCell(table1, serialId.Text, normalFont, BaseColor.WHITE)
        
        AddPdfCell(table1, "Location:", headerFont, grayColor)
        AddPdfCell(table1, location.Text, normalFont, BaseColor.WHITE)
        AddPdfCell(table1, "Department ID:", headerFont, grayColor)
        AddPdfCell(table1, departmentId.Text, normalFont, BaseColor.WHITE)
        
        doc.Add(table1)
        
        ' Section 2: Type and Technician
        Dim table2 As New PdfPTable(4)
        table2.WidthPercentage = 100
        table2.SetWidths(New Single() {1.8F, 2.2F, 1.8F, 2.2F})
        table2.SpacingBefore = 0
        table2.SpacingAfter = 10
        
        AddPdfCell(table2, "Type of Maintenance:", headerFont, grayColor)
        AddPdfCell(table2, typeOfMaintenance.Text, normalFont, BaseColor.WHITE)
        AddPdfCell(table2, "Assigned Technician:", headerFont, grayColor)
        AddPdfCell(table2, assignedTechnician.Text, normalFont, BaseColor.WHITE)
        
        doc.Add(table2)
        
        ' Section 3: Condition Before Maintenance
        Dim table3 As New PdfPTable(1)
        table3.WidthPercentage = 100
        table3.SpacingBefore = 0
        table3.SpacingAfter = 10
        
        AddPdfCell(table3, "Condition Before Maintenance:", headerFont, grayColor)
        AddPdfCellMultiline(table3, conditionBeforeMaintenance.Text, normalFont, BaseColor.WHITE)
        
        doc.Add(table3)
        
        ' Section 4: Maintenance Detail
        Dim table4 As New PdfPTable(1)
        table4.WidthPercentage = 100
        table4.SpacingBefore = 0
        table4.SpacingAfter = 10
        
        AddPdfCell(table4, "Maintenance Detail:", headerFont, grayColor)
        AddPdfCellMultiline(table4, maintenanceDetail.Text, normalFont, BaseColor.WHITE)
        
        doc.Add(table4)
        
        ' Section 5: Date and Cost
        Dim table5 As New PdfPTable(4)
        table5.WidthPercentage = 100
        table5.SetWidths(New Single() {1.5F, 2.5F, 1.8F, 2.2F})
        table5.SpacingBefore = 0
        table5.SpacingAfter = 10
        
        AddPdfCell(table5, "Maintenance Date:", headerFont, grayColor)
        AddPdfCell(table5, maintenanceDate.Value.ToString("dddd, dd MMMM yyyy"), normalFont, BaseColor.WHITE)
        AddPdfCell(table5, "Cost Materials Labor:", headerFont, grayColor)
        AddPdfCell(table5, costMaterialsLabor.Text, normalFont, BaseColor.WHITE)
        
        doc.Add(table5)
        
        ' Section 6: Condition After Maintenance
        Dim table6 As New PdfPTable(1)
        table6.WidthPercentage = 100
        table6.SpacingBefore = 0
        table6.SpacingAfter = 10
        
        AddPdfCell(table6, "Condition After Maintenance:", headerFont, grayColor)
        AddPdfCellMultiline(table6, conditionAfterMaintenance.Text, normalFont, BaseColor.WHITE)
        
        doc.Add(table6)
        
        ' Section 7: Status and Details
        Dim table7 As New PdfPTable(4)
        table7.WidthPercentage = 100
        table7.SetWidths(New Single() {1.5F, 2.5F, 1.5F, 2.5F})
        table7.SpacingBefore = 0
        table7.SpacingAfter = 10
        
        AddPdfCell(table7, "Status:", headerFont, grayColor)
        AddPdfCell(table7, status.Text, normalFont, BaseColor.WHITE)
        AddPdfCell(table7, "Diagnosis:", headerFont, grayColor)
        AddPdfCell(table7, diagnosis.Text, normalFont, BaseColor.WHITE)
        
        AddPdfCell(table7, "Action Taken:", headerFont, grayColor)
        AddPdfCell(table7, actionTaken.Text, normalFont, BaseColor.WHITE)
        AddPdfCell(table7, "Parts Replaced:", headerFont, grayColor)
        AddPdfCell(table7, partsReplaced.Text, normalFont, BaseColor.WHITE)
        
        doc.Add(table7)
        
        ' Footer
        Dim footer As New Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", smallFont)
        footer.Alignment = Element.ALIGN_RIGHT
        footer.SpacingBefore = 20
        doc.Add(footer)
        
        doc.Close()
    End Sub
    
    Private Sub AddPdfCell(table As PdfPTable, text As String, font As iTextSharp.text.Font, bgColor As BaseColor)
        Dim cell As New PdfPCell(New Phrase(text, font))
        cell.BackgroundColor = bgColor
        cell.Padding = 5
        cell.Border = iTextSharp.text.Rectangle.BOX
        cell.BorderWidth = 1
        cell.BorderColor = BaseColor.BLACK
        cell.VerticalAlignment = Element.ALIGN_TOP
        table.AddCell(cell)
    End Sub
    
    Private Sub AddPdfCellMultiline(table As PdfPTable, text As String, font As iTextSharp.text.Font, bgColor As BaseColor)
        Dim cell As New PdfPCell(New Phrase(text, font))
        cell.BackgroundColor = bgColor
        cell.Padding = 5
        cell.Border = iTextSharp.text.Rectangle.BOX
        cell.BorderWidth = 1
        cell.BorderColor = BaseColor.BLACK
        cell.VerticalAlignment = Element.ALIGN_TOP
        cell.MinimumHeight = 60
        table.AddCell(cell)
    End Sub

    ' Export to CSV
    Private Sub btnCSV_Click(sender As Object, e As EventArgs)
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV Files (*.csv)|*.csv"
            saveDialog.FileName = $"MaintenanceReport_{maintenanceId.Text}_{DateTime.Now:yyyyMMdd}.csv"
            
            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportToCSV(saveDialog.FileName)
                MessageBox.Show("CSV exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                
                ' Ask if user wants to open the file
                If MessageBox.Show("Do you want to open the CSV file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Process.Start(saveDialog.FileName)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting to CSV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToCSV(filePath As String)
        Dim csv As New StringBuilder()
        
        ' Header
        csv.AppendLine("=== MAINTENANCE MANAGEMENT REPORT ===")
        csv.AppendLine($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
        csv.AppendLine("")
        
        ' Section Headers
        csv.AppendLine("BASIC INFORMATION")
        csv.AppendLine("Field,Value")
        csv.AppendLine($"""Maintenance ID"",""{EscapeCSV(maintenanceId.Text)}""")
        csv.AppendLine($"""Request ID"",""{EscapeCSV(requestId.Text)}""")
        csv.AppendLine($"""Property Item Name"",""{EscapeCSV(propertyItemName.Text)}""")
        csv.AppendLine($"""Serial Number"",""{EscapeCSV(serialId.Text)}""")
        csv.AppendLine($"""Location"",""{EscapeCSV(location.Text)}""")
        csv.AppendLine($"""Department ID"",""{EscapeCSV(departmentId.Text)}""")
        csv.AppendLine("")
        
        ' Maintenance Details
        csv.AppendLine("MAINTENANCE DETAILS")
        csv.AppendLine("Field,Value")
        csv.AppendLine($"""Type of Maintenance"",""{EscapeCSV(typeOfMaintenance.Text)}""")
        csv.AppendLine($"""Assigned Technician"",""{EscapeCSV(assignedTechnician.Text)}""")
        csv.AppendLine($"""Condition Before Maintenance"",""{EscapeCSV(conditionBeforeMaintenance.Text)}""")
        csv.AppendLine($"""Maintenance Detail"",""{EscapeCSV(maintenanceDetail.Text)}""")
        csv.AppendLine($"""Maintenance Date"",""{maintenanceDate.Value:dddd, dd MMMM yyyy}""")
        csv.AppendLine($"""Cost Materials Labor"",""{EscapeCSV(costMaterialsLabor.Text)}""")
        csv.AppendLine($"""Condition After Maintenance"",""{EscapeCSV(conditionAfterMaintenance.Text)}""")
        csv.AppendLine("")
        
        ' Status and Final Details
        csv.AppendLine("STATUS AND FINAL DETAILS")
        csv.AppendLine("Field,Value")
        csv.AppendLine($"""Status"",""{EscapeCSV(status.Text)}""")
        csv.AppendLine($"""Diagnosis"",""{EscapeCSV(diagnosis.Text)}""")
        csv.AppendLine($"""Action Taken"",""{EscapeCSV(actionTaken.Text)}""")
        csv.AppendLine($"""Parts Replaced"",""{EscapeCSV(partsReplaced.Text)}""")
        
        File.WriteAllText(filePath, csv.ToString())
    End Sub

    Private Function EscapeCSV(value As String) As String
        If String.IsNullOrEmpty(value) Then Return ""
        ' Escape quotes by doubling them and handle line breaks
        Return value.Replace("""", """""").Replace(vbCrLf, " ").Replace(vbLf, " ").Replace(vbCr, " ")
    End Function

    ' Back button handler
    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        ' Close the form
        Dim parentForm = Me.FindForm()
        If parentForm IsNot Nothing Then
            parentForm.Close()
        End If
    End Sub

    Private Sub MaintenanceManagementReport1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Form load event
    End Sub
End Class
