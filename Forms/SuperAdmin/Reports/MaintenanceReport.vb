Imports System.Windows.Forms
Imports System.Linq
Imports System
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Partial Public Class MaintenanceReport
    Private maintenanceData As DataRow = Nothing
    Private currentMaintenanceID As Integer? = Nothing

    ' Parameterless constructor for preview/new reports
    Public Sub New()
        ' This must be called first
        InitializeComponent()
        ' Don't load data - this creates an empty form for preview
        currentMaintenanceID = Nothing
    End Sub

    ' Constructor with maintenance ID
    Public Sub New(maintenanceId As Integer)
        ' This must be called first
        InitializeComponent()
        LoadMaintenanceData(maintenanceId)
    End Sub

    Private Sub MaintenanceReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize form
        If maintenanceData Is Nothing Then
            ' Set default values for empty form
            DateTimePicker1.Value = DateTime.Now
            DateTimePicker2.Value = DateTime.Now
            DateTimePicker4.Value = DateTime.Now
        End If
    End Sub

    ''' <summary>
    ''' Load maintenance data and populate form fields
    ''' </summary>
    Private Sub LoadMaintenanceData(maintenanceId As Integer)
        Try
            System.Diagnostics.Debug.WriteLine($"[MaintenanceReport] Loading maintenance ID: {maintenanceId}")
            
            ' Get maintenance data from database
            maintenanceData = modDB.GetMaintenanceById(maintenanceId)
            
            If maintenanceData Is Nothing Then
                MessageBox.Show("Maintenance record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            
            ' Store maintenance ID
            currentMaintenanceID = maintenanceId
            
            ' Populate form fields
            PopulateFormFields()
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[MaintenanceReport] Error loading maintenance: {ex.Message}")
            MessageBox.Show($"Error loading maintenance data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Populate all form fields with maintenance data
    ''' </summary>
    Private Sub PopulateFormFields()
        Try
            If maintenanceData Is Nothing Then Return

            ' Maintenance ID and Request ID
            If maintenanceData.Table.Columns.Contains("maintenanceId") AndAlso Not IsDBNull(maintenanceData("maintenanceId")) Then
                ' Store in a hidden field or label if you have one
                ' For now, we'll use it for reference
                currentMaintenanceID = Convert.ToInt32(maintenanceData("maintenanceId"))
            End If

            If maintenanceData.Table.Columns.Contains("requestId") AndAlso Not IsDBNull(maintenanceData("requestId")) Then
                ' Set request ID if you have a field for it
                ' TextBoxRequestID.Text = maintenanceData("requestId").ToString()
            End If

            ' Property Item Name
            If maintenanceData.Table.Columns.Contains("propertyItemName") AndAlso Not IsDBNull(maintenanceData("propertyItemName")) Then
                systemname.Text = maintenanceData("propertyItemName").ToString()
            End If

            ' Serial Number
            If maintenanceData.Table.Columns.Contains("serialNumber") AndAlso Not IsDBNull(maintenanceData("serialNumber")) Then
                serialNumber.Text = maintenanceData("serialNumber").ToString()
            End If

            ' Location
            If maintenanceData.Table.Columns.Contains("location") AndAlso Not IsDBNull(maintenanceData("location")) Then
                TextBox7.Text = maintenanceData("location").ToString()
            End If

            ' Department
            If maintenanceData.Table.Columns.Contains("departmentName") AndAlso Not IsDBNull(maintenanceData("departmentName")) Then
                ' Assuming you have a department field - adjust as needed
                ' TextBoxDepartment.Text = maintenanceData("departmentName").ToString()
            End If

            ' Type of Maintenance
            If maintenanceData.Table.Columns.Contains("typeOfMaintenance") AndAlso Not IsDBNull(maintenanceData("typeOfMaintenance")) Then
                Dim maintenanceType As String = maintenanceData("typeOfMaintenance").ToString()
                ComboBox1.Items.Clear()
                ComboBox1.Items.Add(maintenanceType)
                ComboBox1.SelectedIndex = 0
            End If

            ' Assigned Technician
            If maintenanceData.Table.Columns.Contains("assignedTechnician") AndAlso Not IsDBNull(maintenanceData("assignedTechnician")) Then
                mechanicname.Text = maintenanceData("assignedTechnician").ToString()
            End If

            ' Condition Before Maintenance
            If maintenanceData.Table.Columns.Contains("conditionBeforeMaint") AndAlso Not IsDBNull(maintenanceData("conditionBeforeMaint")) Then
                shutdownmaintenance.Text = maintenanceData("conditionBeforeMaint").ToString()
            End If

            ' Maintenance Details
            If maintenanceData.Table.Columns.Contains("maintenanceDetails") AndAlso Not IsDBNull(maintenanceData("maintenanceDetails")) Then
                maintenancedescription.Text = maintenanceData("maintenanceDetails").ToString()
            End If

            ' Maintenance Date
            If maintenanceData.Table.Columns.Contains("maintenanceDate") AndAlso Not IsDBNull(maintenanceData("maintenanceDate")) Then
                Dim maintDate As DateTime
                If DateTime.TryParse(maintenanceData("maintenanceDate").ToString(), maintDate) Then
                    DateTimePicker1.Value = maintDate
                End If
            End If

            ' Cost Materials Labor
            If maintenanceData.Table.Columns.Contains("costMaterialsLabor") AndAlso Not IsDBNull(maintenanceData("costMaterialsLabor")) Then
                TextBox11.Text = maintenanceData("costMaterialsLabor").ToString()
            End If

            ' Condition After Maintenance
            If maintenanceData.Table.Columns.Contains("conditionAfterMaint") AndAlso Not IsDBNull(maintenanceData("conditionAfterMaint")) Then
                maintenanceinspection.Text = maintenanceData("conditionAfterMaint").ToString()
            End If

            ' Status
            If maintenanceData.Table.Columns.Contains("status") AndAlso Not IsDBNull(maintenanceData("status")) Then
                status.Text = maintenanceData("status").ToString()
            End If

            ' Diagnosis
            If maintenanceData.Table.Columns.Contains("diagnosis") AndAlso Not IsDBNull(maintenanceData("diagnosis")) Then
                systemfailure.Text = maintenanceData("diagnosis").ToString()
            End If

            ' Action Taken
            If maintenanceData.Table.Columns.Contains("actionTaken") AndAlso Not IsDBNull(maintenanceData("actionTaken")) Then
                preventivemaintenance.Text = maintenanceData("actionTaken").ToString()
            End If

            ' Parts Replaced
            If maintenanceData.Table.Columns.Contains("partsReplaced") AndAlso Not IsDBNull(maintenanceData("partsReplaced")) Then
                ' Set parts replaced field if available
                ' TextBoxPartsReplaced.Text = maintenanceData("partsReplaced").ToString()
            End If

            ' Created/Updated dates
            If maintenanceData.Table.Columns.Contains("createdAt") AndAlso Not IsDBNull(maintenanceData("createdAt")) Then
                Dim createdDate As DateTime
                If DateTime.TryParse(maintenanceData("createdAt").ToString(), createdDate) Then
                    DateTimePicker2.Value = createdDate
                End If
            End If

            If maintenanceData.Table.Columns.Contains("updatedAt") AndAlso Not IsDBNull(maintenanceData("updatedAt")) Then
                Dim updatedDate As DateTime
                If DateTime.TryParse(maintenanceData("updatedAt").ToString(), updatedDate) Then
                    DateTimePicker4.Value = updatedDate
                End If
            End If

            System.Diagnostics.Debug.WriteLine("[MaintenanceReport] Form populated successfully")
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[MaintenanceReport] Error populating form: {ex.Message}")
            MessageBox.Show($"Error populating form fields: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Keep existing event handlers
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles nationalboardno.TextChanged
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles systemfailure.TextChanged
    End Sub

    ' ================================================================
    ' PDF EXPORT
    ' ================================================================
    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        ExportToPDF()
    End Sub

    Private Sub ExportToPDF()
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf"
            saveDialog.FileName = $"MaintenanceReport_{If(currentMaintenanceID.HasValue, currentMaintenanceID.Value.ToString(), DateTime.Now.ToString("yyyyMMdd"))}.pdf"
            
            If saveDialog.ShowDialog() = DialogResult.OK Then
                ' Create bitmap of the form
                Dim bmp As New Bitmap(Me.Width, Me.Height)
                Me.DrawToBitmap(bmp, New Rectangle(0, 0, Me.Width, Me.Height))
                
                ' Save as PDF using basic image-to-PDF conversion
                Dim pdfPath As String = saveDialog.FileName
                
                ' For now, save as image-based PDF
                ' You can enhance this with a proper PDF library like iTextSharp if needed
                Using doc As New Printing.PrintDocument()
                    AddHandler doc.PrintPage, Sub(s, ev)
                                                  ' Calculate scaling to fit page
                                                  Dim scaleX As Single = ev.PageBounds.Width / bmp.Width
                                                  Dim scaleY As Single = ev.PageBounds.Height / bmp.Height
                                                  Dim scale As Single = Math.Min(scaleX, scaleY)
                                                  
                                                  Dim newWidth As Integer = CInt(bmp.Width * scale)
                                                  Dim newHeight As Integer = CInt(bmp.Height * scale)
                                                  
                                                  ev.Graphics.DrawImage(bmp, 0, 0, newWidth, newHeight)
                                              End Sub
                    
                    ' Print to PDF
                    doc.PrinterSettings.PrinterName = "Microsoft Print to PDF"
                    doc.PrinterSettings.PrintToFile = True
                    doc.PrinterSettings.PrintFileName = pdfPath
                    
                    Try
                        doc.Print()
                        MessageBox.Show($"PDF exported successfully to:{vbCrLf}{pdfPath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        ' Fallback: Save as image if PDF printer not available
                        Dim imagePath As String = Path.ChangeExtension(pdfPath, ".png")
                        bmp.Save(imagePath, Imaging.ImageFormat.Png)
                        MessageBox.Show($"PDF printer not available. Saved as image:{vbCrLf}{imagePath}", "Export as Image", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End Using
                
                bmp.Dispose()
            End If
            
        Catch ex As Exception
            MessageBox.Show($"Error exporting to PDF: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================================
    ' CSV EXPORT
    ' ================================================================
    Private Sub btnCSV_Click(sender As Object, e As EventArgs) Handles btnCSV.Click
        ExportToCSV()
    End Sub

    Private Sub ExportToCSV()
        Try
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV Files (*.csv)|*.csv"
            saveDialog.FileName = $"MaintenanceReport_{If(currentMaintenanceID.HasValue, currentMaintenanceID.Value.ToString(), DateTime.Now.ToString("yyyyMMdd"))}.csv"
            
            If saveDialog.ShowDialog() = DialogResult.OK Then
                Using writer As New StreamWriter(saveDialog.FileName, False, Encoding.UTF8)
                    ' ================================================================
                    ' HEADER SECTION - Professional Title
                    ' ================================================================
                    writer.WriteLine("╔════════════════════════════════════════════════════════════════════════════╗")
                    writer.WriteLine("║             MAINTENANCE MANAGEMENT REPORT - DETAILED VIEW                 ║")
                    writer.WriteLine("║        Property Custodian System - Division of Camarines Norte            ║")
                    writer.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝")
                    writer.WriteLine()
                    
                    ' Report metadata
                    writer.WriteLine($"Report Generated: {DateTime.Now.ToString("MMMM dd, yyyy - hh:mm:ss tt")}")
                    writer.WriteLine($"Maintenance ID: {If(currentMaintenanceID.HasValue, "MNT-" & currentMaintenanceID.Value.ToString().PadLeft(6, "0"c), "N/A")}")
                    writer.WriteLine($"Status: {GetTextBoxValue(status)}")
                    writer.WriteLine()
                    writer.WriteLine("─────────────────────────────────────────────────────────────────────────────")
                    writer.WriteLine()
                    
                    ' ================================================================
                    ' SECTION 1: PROPERTY INFORMATION
                    ' ================================================================
                    writer.WriteLine("┌─────────────────────────────────────────────────────────────────────────┐")
                    writer.WriteLine("│  SECTION 1: PROPERTY INFORMATION                                        │")
                    writer.WriteLine("└─────────────────────────────────────────────────────────────────────────┘")
                    writer.WriteLine()
                    writer.WriteLine($"  Property Name        : {GetTextBoxValue(systemname)}")
                    writer.WriteLine($"  Serial Number        : {GetTextBoxValue(serialNumber)}")
                    writer.WriteLine($"  Manufacturer         : {GetTextBoxValue(manufacturer)}")
                    writer.WriteLine($"  National Board No.   : {GetTextBoxValue(nationalboardno)}")
                    writer.WriteLine($"  Location             : {GetTextBoxValue(TextBox7)}")
                    writer.WriteLine($"  Department ID        : {GetFieldValue("departmentId")}")
                    writer.WriteLine()
                    
                    ' ================================================================
                    ' SECTION 2: MAINTENANCE DETAILS
                    ' ================================================================
                    writer.WriteLine("┌─────────────────────────────────────────────────────────────────────────┐")
                    writer.WriteLine("│  SECTION 2: MAINTENANCE DETAILS                                         │")
                    writer.WriteLine("└─────────────────────────────────────────────────────────────────────────┘")
                    writer.WriteLine()
                    writer.WriteLine($"  Request ID                : {GetFieldValue("requestId")}")
                    writer.WriteLine($"  Type of Maintenance       : {GetComboBoxValue(ComboBox1)}")
                    writer.WriteLine($"  Maintenance Date          : {DateTimePicker1.Value.ToString("MMMM dd, yyyy")}")
                    writer.WriteLine($"  Assigned Technician       : {GetTextBoxValue(mechanicname)}")
                    writer.WriteLine($"  Technician Contact        : {GetTextBoxValue(mechanicnumber)}")
                    writer.WriteLine($"  Cost (Materials & Labor)  : {FormatCurrency(GetTextBoxValue(TextBox11))}")
                    writer.WriteLine()
                    
                    ' ================================================================
                    ' SECTION 3: CONDITION ASSESSMENT
                    ' ================================================================
                    writer.WriteLine("┌─────────────────────────────────────────────────────────────────────────┐")
                    writer.WriteLine("│  SECTION 3: CONDITION ASSESSMENT                                        │")
                    writer.WriteLine("└─────────────────────────────────────────────────────────────────────────┘")
                    writer.WriteLine()
                    writer.WriteLine($"  Condition Before Maintenance  : {GetTextBoxValue(shutdownmaintenance)}")
                    writer.WriteLine($"  Condition After Maintenance   : {GetTextBoxValue(maintenanceinspection)}")
                    writer.WriteLine($"  Pressure Test Result          : {GetTextBoxValue(pressuretest)}")
                    writer.WriteLine()
                    
                    ' ================================================================
                    ' SECTION 4: TECHNICAL INFORMATION
                    ' ================================================================
                    writer.WriteLine("┌─────────────────────────────────────────────────────────────────────────┐")
                    writer.WriteLine("│  SECTION 4: TECHNICAL INFORMATION                                       │")
                    writer.WriteLine("└─────────────────────────────────────────────────────────────────────────┘")
                    writer.WriteLine()
                    writer.WriteLine("  DIAGNOSIS / SYSTEM FAILURE:")
                    writer.WriteLine($"  {WrapText(GetTextBoxValue(systemfailure), 70)}")
                    writer.WriteLine()
                    writer.WriteLine("  ACTION TAKEN / PREVENTIVE MAINTENANCE:")
                    writer.WriteLine($"  {WrapText(GetTextBoxValue(preventivemaintenance), 70)}")
                    writer.WriteLine()
                    writer.WriteLine("  MAINTENANCE DESCRIPTION:")
                    writer.WriteLine($"  {WrapText(GetTextBoxValue(maintenancedescription), 70)}")
                    writer.WriteLine()
                    
                    ' ================================================================
                    ' SECTION 5: CUSTODIAN INFORMATION
                    ' ================================================================
                    writer.WriteLine("┌─────────────────────────────────────────────────────────────────────────┐")
                    writer.WriteLine("│  SECTION 5: CUSTODIAN INFORMATION                                       │")
                    writer.WriteLine("└─────────────────────────────────────────────────────────────────────────┘")
                    writer.WriteLine()
                    writer.WriteLine($"  Custodian Name       : {GetTextBoxValue(custodianname)}")
                    writer.WriteLine($"  Custodian Contact    : {GetTextBoxValue(custodiannumber)}")
                    writer.WriteLine()
                    
                    ' ================================================================
                    ' SECTION 6: TIMELINE & STATUS
                    ' ================================================================
                    writer.WriteLine("┌─────────────────────────────────────────────────────────────────────────┐")
                    writer.WriteLine("│  SECTION 6: TIMELINE & STATUS                                           │")
                    writer.WriteLine("└─────────────────────────────────────────────────────────────────────────┘")
                    writer.WriteLine()
                    writer.WriteLine($"  Current Status       : {GetTextBoxValue(status)}")
                    writer.WriteLine($"  Record Created       : {DateTimePicker2.Value.ToString("MMMM dd, yyyy - hh:mm:ss tt")}")
                    writer.WriteLine($"  Last Updated         : {DateTimePicker4.Value.ToString("MMMM dd, yyyy - hh:mm:ss tt")}")
                    writer.WriteLine()
                    
                    ' ================================================================
                    ' FOOTER
                    ' ================================================================
                    writer.WriteLine("─────────────────────────────────────────────────────────────────────────────")
                    writer.WriteLine()
                    writer.WriteLine("                          *** END OF REPORT ***")
                    writer.WriteLine()
                    writer.WriteLine($"This report was automatically generated by the Property Custodian System")
                    writer.WriteLine($"Generated by: {Environment.UserName}")
                    writer.WriteLine($"Export Date: {DateTime.Now.ToString("MMMM dd, yyyy - hh:mm:ss tt")}")
                    writer.WriteLine()
                    writer.WriteLine("For questions or concerns, please contact the Property Management Office.")
                    writer.WriteLine("─────────────────────────────────────────────────────────────────────────────")
                End Using
                
                MessageBox.Show($"Professional CSV report exported successfully!{vbCrLf}{vbCrLf}File: {saveDialog.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            
        Catch ex As Exception
            MessageBox.Show($"Error exporting to CSV: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Helper methods for CSV export
    Private Function GetTextBoxValue(textBox As TextBox) As String
        If textBox IsNot Nothing AndAlso Not String.IsNullOrEmpty(textBox.Text) Then
            ' Escape commas and quotes for CSV
            Dim value As String = textBox.Text.Replace("""", """""")
            If value.Contains(",") OrElse value.Contains("""") OrElse value.Contains(vbCrLf) Then
                Return $"""{value}"""
            End If
            Return value
        End If
        Return "N/A"
    End Function

    Private Function GetComboBoxValue(comboBox As ComboBox) As String
        If comboBox IsNot Nothing AndAlso comboBox.SelectedItem IsNot Nothing Then
            Return comboBox.SelectedItem.ToString()
        ElseIf comboBox IsNot Nothing AndAlso Not String.IsNullOrEmpty(comboBox.Text) Then
            Return comboBox.Text
        End If
        Return "N/A"
    End Function

    Private Function GetFieldValue(fieldName As String) As String
        Try
            If maintenanceData IsNot Nothing AndAlso maintenanceData.Table.Columns.Contains(fieldName) AndAlso Not IsDBNull(maintenanceData(fieldName)) Then
                Return maintenanceData(fieldName).ToString()
            End If
        Catch ex As Exception
        End Try
        Return "N/A"
    End Function
    
    ' Helper function to wrap long text
    Private Function WrapText(text As String, maxWidth As Integer) As String
        If String.IsNullOrEmpty(text) OrElse text = "N/A" Then
            Return "N/A"
        End If
        
        Dim lines As New List(Of String)()
        Dim words() As String = text.Split(" "c)
        Dim currentLine As String = ""
        
        For Each word As String In words
            If (currentLine.Length + word.Length + 1) <= maxWidth Then
                If currentLine.Length > 0 Then
                    currentLine &= " " & word
                Else
                    currentLine = word
                End If
            Else
                If currentLine.Length > 0 Then
                    lines.Add(currentLine)
                End If
                currentLine = word
            End If
        Next
        
        If currentLine.Length > 0 Then
            lines.Add(currentLine)
        End If
        
        ' Join lines with proper indentation
        Return String.Join(vbCrLf & "  ", lines)
    End Function
    
    ' Helper function to format currency
    Private Function FormatCurrency(value As String) As String
        If String.IsNullOrEmpty(value) OrElse value = "N/A" Then
            Return "₱ 0.00"
        End If
        
        Try
            Dim amount As Decimal
            If Decimal.TryParse(value.Replace("₱", "").Replace(",", "").Trim(), amount) Then
                Return "₱ " & amount.ToString("N2")
            End If
        Catch ex As Exception
            ' If parsing fails, return as-is with peso sign
        End Try
        
        Return "₱ " & value
    End Function
End Class