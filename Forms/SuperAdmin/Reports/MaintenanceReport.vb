Imports System.Windows.Forms
Imports System.Linq
Imports System
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Text
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
                Dim csv As New StringBuilder()
                
                ' Header
                csv.AppendLine("MAINTENANCE MANAGEMENT REPORT")
                csv.AppendLine("")
                
                ' Basic Information Section
                csv.AppendLine("=== BASIC INFORMATION ===")
                csv.AppendLine($"Maintenance ID,{If(currentMaintenanceID.HasValue, currentMaintenanceID.Value.ToString(), "N/A")}")
                csv.AppendLine($"Request ID,{GetFieldValue("requestId")}")
                csv.AppendLine($"Property Item Name,{GetTextBoxValue(systemname)}")
                csv.AppendLine($"Serial Number,{GetTextBoxValue(serialNumber)}")
                csv.AppendLine($"Location,{GetTextBoxValue(TextBox7)}")
                csv.AppendLine($"Department ID,{GetFieldValue("departmentId")}")
                csv.AppendLine("")
                
                ' Maintenance Details Section
                csv.AppendLine("=== MAINTENANCE DETAILS ===")
                csv.AppendLine($"Type of Maintenance,{GetComboBoxValue(ComboBox1)}")
                csv.AppendLine($"Assigned Technician,{GetTextBoxValue(mechanicname)}")
                csv.AppendLine($"Maintenance Date,{DateTimePicker1.Value.ToString("yyyy-MM-dd")}")
                csv.AppendLine($"Condition Before Maintenance,{GetTextBoxValue(shutdownmaintenance)}")
                csv.AppendLine($"Condition After Maintenance,{GetTextBoxValue(maintenanceinspection)}")
                csv.AppendLine("")
                
                ' Technical Information Section
                csv.AppendLine("=== TECHNICAL INFORMATION ===")
                csv.AppendLine($"Diagnosis/System Failure,{GetTextBoxValue(systemfailure)}")
                csv.AppendLine($"Action Taken/Preventive Maintenance,{GetTextBoxValue(preventivemaintenance)}")
                csv.AppendLine($"Maintenance Description,{GetTextBoxValue(maintenancedescription)}")
                csv.AppendLine($"Cost Materials Labor,{GetTextBoxValue(TextBox11)}")
                csv.AppendLine("")
                
                ' Status Section
                csv.AppendLine("=== STATUS ===")
                csv.AppendLine($"Status,{GetTextBoxValue(status)}")
                csv.AppendLine($"Created At,{DateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss")}")
                csv.AppendLine($"Updated At,{DateTimePicker4.Value.ToString("yyyy-MM-dd HH:mm:ss")}")
                csv.AppendLine("")
                
                ' Additional Fields Section
                csv.AppendLine("=== ADDITIONAL INFORMATION ===")
                csv.AppendLine($"Custodian Name,{GetTextBoxValue(custodianname)}")
                csv.AppendLine($"Custodian Number,{GetTextBoxValue(custodiannumber)}")
                csv.AppendLine($"Mechanic Number,{GetTextBoxValue(mechanicnumber)}")
                csv.AppendLine($"Manufacturer,{GetTextBoxValue(manufacturer)}")
                csv.AppendLine($"National Board No,{GetTextBoxValue(nationalboardno)}")
                csv.AppendLine($"Pressure Test,{GetTextBoxValue(pressuretest)}")
                csv.AppendLine("")
                
                csv.AppendLine("=== END OF REPORT ===")
                csv.AppendLine($"Generated on: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}")
                
                ' Write to file
                File.WriteAllText(saveDialog.FileName, csv.ToString(), Encoding.UTF8)
                
                MessageBox.Show($"CSV exported successfully to:{vbCrLf}{saveDialog.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
End Class