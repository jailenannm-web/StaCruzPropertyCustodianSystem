Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class PropertyIssuance
    Private propertyIssuanceTable As DataTable
    Private currentPropertyID As Integer = -1
    Private currentPropertyNumber As String = ""
    Private currentPropertyData As DataRow = Nothing

    ' Constructor to accept propertyID and optional propertyNumber
    Public Sub New(Optional propertyID As Integer = -1, Optional propertyNumber As String = "")
        InitializeComponent()
        currentPropertyID = propertyID
        currentPropertyNumber = propertyNumber
    End Sub

    Private Sub PropertyIssuance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate dropdowns first
        PopulateDropdowns()

        ' Load property data if propertyID is provided
        If currentPropertyID > 0 Then
            System.Diagnostics.Debug.WriteLine("[PropertyIssuance] Loading property ID: " & currentPropertyID.ToString() & " | propertyNumber: " & currentPropertyNumber)
            LoadPropertyData(currentPropertyID, currentPropertyNumber)
        Else
            System.Diagnostics.Debug.WriteLine("[PropertyIssuance] No property ID provided, loading default data")
            LoadPropertyIssuanceData()
        End If
    End Sub

    Private Sub PopulateDropdowns()
        Try
            ' Populate Department dropdown (ComboBox1 - Received by Position/Office)
            ComboBox1.Items.Clear()
            ComboBox1.Items.Add("Select Department")
            Dim departments As DataTable = DatabaseConnection.GetAllDepartments()
            If departments IsNot Nothing Then
                For Each row As DataRow In departments.Rows
                    Dim deptName As String = ""
                    If departments.Columns.Contains("departmentName") AndAlso Not IsDBNull(row("departmentName")) Then
                        deptName = row("departmentName").ToString()
                    End If
                    If Not String.IsNullOrEmpty(deptName) Then
                        ComboBox1.Items.Add(deptName)
                    End If
                Next
            End If

            ' Populate Employee dropdown (ComboBox2 - Issued by Position/Office)
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Select Employee")
            Dim users As DataTable = DatabaseConnection.GetAllUsers("", "", "")
            If users IsNot Nothing Then
                For Each row As DataRow In users.Rows
                    Dim empName As String = ""
                    If users.Columns.Contains("firstName") AndAlso Not IsDBNull(row("firstName")) Then
                        empName = row("firstName").ToString()
                    End If
                    If users.Columns.Contains("lastName") AndAlso Not IsDBNull(row("lastName")) Then
                        If Not String.IsNullOrEmpty(empName) Then
                            empName &= " "
                        End If
                        empName &= row("lastName").ToString()
                    End If
                    If Not String.IsNullOrEmpty(empName) Then
                        ComboBox2.Items.Add(empName)
                    End If
                Next
            End If

            ' Set default dates
            DateTimePicker1.Value = DateTime.Now
            DateTimePicker2.Value = DateTime.Now

        Catch ex As Exception
            MessageBox.Show("Error populating dropdowns: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPropertyData(propertyID As Integer, Optional propertyNumberValue As String = "")
        Try
            System.Diagnostics.Debug.WriteLine("[PropertyIssuance] GetPropertyDetails called with ID: " & propertyID.ToString() & " | propNumber: " & propertyNumberValue)
            currentPropertyData = DatabaseConnection.GetPropertyDetails(propertyID, propertyNumberValue)

            If currentPropertyData Is Nothing Then
                System.Diagnostics.Debug.WriteLine("[PropertyIssuance] GetPropertyDetails returned Nothing. Trying fallback values.")
                ' Show minimal info using provided IDs so user can still generate a slip
                numberPAR.Text = "PAR-" & DateTime.Now.ToString("yyyyMMdd") & "-" & propertyID.ToString("D6")
                propertyNumber.Text = If(String.IsNullOrWhiteSpace(propertyNumberValue), propertyID.ToString(), propertyNumberValue)
                entityNameTxt.Text = "Sta. Cruz Property Custodian System"
                description.Text = "(Property not found in records)"
                quantity.Text = "1"
                TextBox4.Text = "pcs"
                dateAcquired.Value = DateTime.Now
                amount.Text = "0.00"
                BuildPropertyIssuanceTableFromProperty()
                MessageBox.Show("Property not found in database. Using fallback data for export." & Environment.NewLine &
                                "Property ID: " & propertyID.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            System.Diagnostics.Debug.WriteLine("[PropertyIssuance] Property data loaded successfully")

            ' Auto-fill all fields from property data
            entityNameTxt.Text = "Sta. Cruz Property Custodian System"
            numberPAR.Text = "PAR-" & DateTime.Now.ToString("yyyyMMdd") & "-" & propertyID.ToString("D6")

            ' Property Details
            propertyNumber.Text = SafeGetString(currentPropertyData, "propertyNumber", "")

            ' Description: Build comprehensive description with all available details
            Dim descParts As New List(Of String)

            ' Start with itemName or description
            Dim itemName As String = SafeGetString(currentPropertyData, "itemName", "")
            Dim baseDesc As String = SafeGetString(currentPropertyData, "description", "")
            If Not String.IsNullOrEmpty(baseDesc) Then
                descParts.Add(baseDesc)
            ElseIf Not String.IsNullOrEmpty(itemName) Then
                descParts.Add(itemName)
            End If

            ' Add category if available
            Dim category As String = SafeGetString(currentPropertyData, "category", "")
            If Not String.IsNullOrEmpty(category) Then
                descParts.Add("Category: " & category)
            End If

            ' Add serial number if available
            Dim serialNum As String = SafeGetString(currentPropertyData, "serialNumber", "")
            If Not String.IsNullOrEmpty(serialNum) Then
                descParts.Add("Serial: " & serialNum)
            End If

            ' Add supplier if available
            Dim supplier As String = SafeGetString(currentPropertyData, "supplier", "")
            If Not String.IsNullOrEmpty(supplier) Then
                descParts.Add("Supplier: " & supplier)
            End If

            ' Add condition if available
            Dim condition As String = SafeGetString(currentPropertyData, "condition", "")
            If Not String.IsNullOrEmpty(condition) Then
                descParts.Add("Condition: " & condition)
            End If

            ' Add location if available
            Dim location As String = SafeGetString(currentPropertyData, "location", "")
            If Not String.IsNullOrEmpty(location) Then
                descParts.Add("Location: " & location)
            End If

            ' Combine all parts
            If descParts.Count > 0 Then
                description.Text = String.Join(" | ", descParts)
            Else
                description.Text = "No description available"
            End If

            quantity.Text = "1"

            ' Unit: Try unitOfMeasure, then check if there's a unit column
            Dim unitValue As String = SafeGetString(currentPropertyData, "unitOfMeasure", "unit", "")
            If String.IsNullOrEmpty(unitValue) Then
                unitValue = "pcs" ' Default unit
            End If
            TextBox4.Text = unitValue

            ' Amount and Date Acquired
            Dim costValue As Decimal = 0D
            If currentPropertyData.Table.Columns.Contains("acquisitionCost") AndAlso Not IsDBNull(currentPropertyData("acquisitionCost")) Then
                If Decimal.TryParse(currentPropertyData("acquisitionCost").ToString(), costValue) Then
                    amount.Text = costValue.ToString("N2")
                End If
            End If
            If String.IsNullOrEmpty(amount.Text) Then
                amount.Text = "0.00"
            End If

            If currentPropertyData.Table.Columns.Contains("acquisitionDate") AndAlso Not IsDBNull(currentPropertyData("acquisitionDate")) Then
                Try
                    Dim acqDate As Date
                    If Date.TryParse(currentPropertyData("acquisitionDate").ToString(), acqDate) Then
                        dateAcquired.Value = acqDate
                    Else
                        dateAcquired.Value = DateTime.Now
                    End If
                Catch
                    dateAcquired.Value = DateTime.Now
                End Try
            Else
                dateAcquired.Value = DateTime.Now
            End If

            ' Received By (Employee assignment)
            Dim assignedEmployee As String = SafeGetString(currentPropertyData, "assignedEmployee", "")
            If Not String.IsNullOrEmpty(assignedEmployee) Then
                TextBox1.Text = assignedEmployee.Trim()

                ' Try to select in ComboBox1 (Department dropdown for Position/Office)
                Dim assignedDept As String = SafeGetString(currentPropertyData, "assignedDepartment", "departmentName", "")
                If Not String.IsNullOrEmpty(assignedDept) Then
                    For i As Integer = 0 To ComboBox1.Items.Count - 1
                        If StringComparer.OrdinalIgnoreCase.Equals(ComboBox1.Items(i).ToString(), assignedDept.Trim()) Then
                            ComboBox1.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            Else
                ' If no employee assigned, leave TextBox1 empty but still try to set department
                Dim assignedDept As String = SafeGetString(currentPropertyData, "assignedDepartment", "departmentName", "")
                If Not String.IsNullOrEmpty(assignedDept) Then
                    For i As Integer = 0 To ComboBox1.Items.Count - 1
                        If StringComparer.OrdinalIgnoreCase.Equals(ComboBox1.Items(i).ToString(), assignedDept.Trim()) Then
                            ComboBox1.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            End If

            ' Issued By (Property Custodian - current admin/superadmin)
            Dim currentUser As String = ""
            Try
                If SessionContext.CurrentUsername IsNot Nothing Then
                    currentUser = SessionContext.CurrentUsername
                End If
            Catch
            End Try

            If String.IsNullOrEmpty(currentUser) Then
                ' Try to get full name from current user context
                Try
                    If SessionContext.CurrentUserID.HasValue Then
                        Dim userDt As DataTable = DatabaseConnection.GetAllUsers("", "", "")
                        If userDt IsNot Nothing Then
                            For Each row As DataRow In userDt.Rows
                                If userDt.Columns.Contains("userId") AndAlso Not IsDBNull(row("userId")) Then
                                    If Convert.ToInt32(row("userId")) = SessionContext.CurrentUserID.Value Then
                                        Dim firstName As String = If(userDt.Columns.Contains("firstName") AndAlso Not IsDBNull(row("firstName")), row("firstName").ToString(), "")
                                        Dim lastName As String = If(userDt.Columns.Contains("lastName") AndAlso Not IsDBNull(row("lastName")), row("lastName").ToString(), "")
                                        currentUser = (firstName & " " & lastName).Trim()
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    End If
                Catch
                End Try
            End If

            If String.IsNullOrEmpty(currentUser) Then
                currentUser = "Property Custodian"
            End If
            TextBox2.Text = currentUser

            ' Set Position/Office for Issued By (ComboBox2)
            ' Try to find current user's position
            Try
                If SessionContext.CurrentUserID.HasValue Then
                    Dim userDt As DataTable = DatabaseConnection.GetAllUsers("", "", "")
                    If userDt IsNot Nothing Then
                        For Each row As DataRow In userDt.Rows
                            If userDt.Columns.Contains("userId") AndAlso Not IsDBNull(row("userId")) Then
                                If Convert.ToInt32(row("userId")) = SessionContext.CurrentUserID.Value Then
                                    Dim position As String = If(userDt.Columns.Contains("position") AndAlso Not IsDBNull(row("position")), row("position").ToString(), "")
                                    If Not String.IsNullOrEmpty(position) Then
                                        ' Try to find in ComboBox2
                                        For i As Integer = 0 To ComboBox2.Items.Count - 1
                                            If ComboBox2.Items(i).ToString().ToUpper().Contains(position.ToUpper()) Then
                                                ComboBox2.SelectedIndex = i
                                                Exit For
                                            End If
                                        Next
                                    End If
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                End If
            Catch
            End Try

            ' Set dates
            DateTimePicker1.Value = DateTime.Now ' Date received
            DateTimePicker2.Value = DateTime.Now ' Date issued

            ' Build property issuance table for export
            BuildPropertyIssuanceTableFromProperty()

            System.Diagnostics.Debug.WriteLine("[PropertyIssuance] All fields auto-filled successfully")

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[PropertyIssuance] LoadPropertyData Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show("Error loading property data: " & ex.Message & Environment.NewLine & "Property ID: " & propertyID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPropertyIssuanceData()
        Try
            ' Load property requests that have been approved/issued
            Dim dt As DataTable = DatabaseConnection.GetAllPropertyRequests()
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                propertyIssuanceTable = New DataTable()
                Return
            End If

            ' Build property issuance table
            propertyIssuanceTable = BuildPropertyIssuanceTable(dt)

            ' Populate form fields with first record or default values
            If propertyIssuanceTable.Rows.Count > 0 Then
                Dim firstRow As DataRow = propertyIssuanceTable.Rows(0)
                entityNameTxt.Text = SafeGetString(firstRow, "entityName", "Sta. Cruz Property Custodian System")
                numberPAR.Text = SafeGetString(firstRow, "parNumber", "PAR-" & DateTime.Now.ToString("yyyyMMdd"))
                If propertyIssuanceTable.Columns.Contains("dateIssued") AndAlso Not Convert.IsDBNull(firstRow("dateIssued")) Then
                    DateTimePicker1.Value = Convert.ToDateTime(firstRow("dateIssued"))
                End If
            Else
                ' Set default values
                entityNameTxt.Text = "Sta. Cruz Property Custodian System"
                numberPAR.Text = "PAR-" & DateTime.Now.ToString("yyyyMMdd")
                DateTimePicker1.Value = DateTime.Now
            End If

            ' Populate property details if available
            If dt.Rows.Count > 0 Then
                Dim firstRequest As DataRow = dt.Rows(0)
                propertyNumber.Text = SafeGetString(firstRequest, "propertyNumber", "propertyId", "")
                description.Text = SafeGetString(firstRequest, "description", "itemDescription", "")
                quantity.Text = SafeGetString(firstRequest, "quantity", "1")
                If dt.Columns.Contains("acquisitionCost") AndAlso Not Convert.IsDBNull(firstRequest("acquisitionCost")) Then
                    amount.Text = Convert.ToDecimal(firstRequest("acquisitionCost")).ToString("N2")
                End If
                If dt.Columns.Contains("acquisitionDate") AndAlso Not Convert.IsDBNull(firstRequest("acquisitionDate")) Then
                    dateAcquired.Value = Convert.ToDateTime(firstRequest("acquisitionDate"))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading property issuance data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            propertyIssuanceTable = New DataTable()
        End Try
    End Sub

    Private Sub BuildPropertyIssuanceTableFromProperty()
        Try
            propertyIssuanceTable = New DataTable()
            propertyIssuanceTable.Columns.Add("entityName", GetType(String))
            propertyIssuanceTable.Columns.Add("parNumber", GetType(String))
            propertyIssuanceTable.Columns.Add("dateIssued", GetType(DateTime))
            propertyIssuanceTable.Columns.Add("propertyNumber", GetType(String))
            propertyIssuanceTable.Columns.Add("description", GetType(String))
            propertyIssuanceTable.Columns.Add("quantity", GetType(Integer))
            propertyIssuanceTable.Columns.Add("unit", GetType(String))
            propertyIssuanceTable.Columns.Add("amount", GetType(Decimal))
            propertyIssuanceTable.Columns.Add("dateAcquired", GetType(DateTime))
            propertyIssuanceTable.Columns.Add("receivedBy", GetType(String))
            propertyIssuanceTable.Columns.Add("receivedByPosition", GetType(String))
            propertyIssuanceTable.Columns.Add("receivedDate", GetType(DateTime))
            propertyIssuanceTable.Columns.Add("issuedBy", GetType(String))
            propertyIssuanceTable.Columns.Add("issuedByPosition", GetType(String))
            propertyIssuanceTable.Columns.Add("issuedDate", GetType(DateTime))

            Dim newRow As DataRow = propertyIssuanceTable.NewRow()
            newRow("entityName") = entityNameTxt.Text
            newRow("parNumber") = numberPAR.Text
            newRow("dateIssued") = DateTimePicker1.Value
            newRow("propertyNumber") = propertyNumber.Text
            newRow("description") = description.Text
            newRow("quantity") = If(String.IsNullOrEmpty(quantity.Text), 1, Integer.Parse(quantity.Text))
            newRow("unit") = TextBox4.Text
            Dim amtValue As Decimal = 0D
            If Decimal.TryParse(amount.Text.Replace(",", ""), amtValue) Then
                newRow("amount") = amtValue
            Else
                newRow("amount") = 0D
            End If
            newRow("dateAcquired") = dateAcquired.Value
            newRow("receivedBy") = TextBox1.Text
            newRow("receivedByPosition") = If(ComboBox1.SelectedIndex > 0, ComboBox1.SelectedItem.ToString(), "")
            newRow("receivedDate") = DateTimePicker1.Value
            newRow("issuedBy") = TextBox2.Text
            newRow("issuedByPosition") = If(ComboBox2.SelectedIndex > 0, ComboBox2.SelectedItem.ToString(), "")
            newRow("issuedDate") = DateTimePicker2.Value

            propertyIssuanceTable.Rows.Add(newRow)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[PropertyIssuance] BuildPropertyIssuanceTableFromProperty Error: " & ex.Message)
            propertyIssuanceTable = New DataTable()
        End Try
    End Sub

    Private Function BuildPropertyIssuanceTable(source As DataTable) As DataTable
        Dim reportTable As New DataTable()
        reportTable.Columns.Add("entityName", GetType(String))
        reportTable.Columns.Add("parNumber", GetType(String))
        reportTable.Columns.Add("dateIssued", GetType(DateTime))
        reportTable.Columns.Add("propertyNumber", GetType(String))
        reportTable.Columns.Add("description", GetType(String))
        reportTable.Columns.Add("quantity", GetType(Integer))
        reportTable.Columns.Add("amount", GetType(Decimal))
        reportTable.Columns.Add("dateAcquired", GetType(DateTime))

        If source Is Nothing Then Return reportTable

        For Each row As DataRow In source.Rows
            Try
                Dim statusValue As String = If(Convert.IsDBNull(row("status")), "", row("status").ToString().ToLower())
                If statusValue = "approved" OrElse statusValue = "borrowed" Then
                    Dim newRow As DataRow = reportTable.NewRow()
                    newRow("entityName") = "Sta. Cruz Property Custodian System"
                    newRow("parNumber") = "PAR-" & SafeGetString(row, "requestId", "request_id", "")
                    newRow("dateIssued") = SafeGetDate(row, "approvedDate", "approval_date", DateTime.Now)
                    newRow("propertyNumber") = SafeGetString(row, "propertyNumber", "propertyId", "")
                    newRow("description") = SafeGetString(row, "description", "itemDescription", "itemName", "")
                    newRow("quantity") = SafeGetInt(row, "quantity", 1)
                    newRow("amount") = SafeGetDecimal(row, "acquisitionCost", "totalCost", 0D)
                    newRow("dateAcquired") = SafeGetDate(row, "acquisitionDate", DateTime.Now)
                    reportTable.Rows.Add(newRow)
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[PropertyIssuance] BuildRow Error: " & ex.Message)
            End Try
        Next

        Return reportTable
    End Function

    Private Sub SavePropertyAssignment()
        If currentPropertyID <= 0 OrElse currentPropertyData Is Nothing Then
            Return
        End If

        Try
            ' Get selected department ID
            Dim departmentID As Integer? = Nothing
            If ComboBox1.SelectedIndex > 0 Then
                Dim selectedDeptName As String = ComboBox1.SelectedItem.ToString()
                Dim departments As DataTable = DatabaseConnection.GetAllDepartments()
                If departments IsNot Nothing Then
                    For Each row As DataRow In departments.Rows
                        If departments.Columns.Contains("departmentName") AndAlso Not IsDBNull(row("departmentName")) Then
                            If StringComparer.OrdinalIgnoreCase.Equals(row("departmentName").ToString(), selectedDeptName) Then
                                If departments.Columns.Contains("departmentId") AndAlso Not IsDBNull(row("departmentId")) Then
                                    departmentID = Convert.ToInt32(row("departmentId"))
                                End If
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            ' Get selected employee ID
            Dim employeeID As Integer? = Nothing
            If Not String.IsNullOrEmpty(TextBox1.Text) Then
                Dim selectedEmpName As String = TextBox1.Text
                Dim users As DataTable = DatabaseConnection.GetAllUsers("", "", "")
                If users IsNot Nothing Then
                    For Each row As DataRow In users.Rows
                        Dim empName As String = ""
                        If users.Columns.Contains("firstName") AndAlso Not IsDBNull(row("firstName")) Then
                            empName = row("firstName").ToString()
                        End If
                        If users.Columns.Contains("lastName") AndAlso Not IsDBNull(row("lastName")) Then
                            If Not String.IsNullOrEmpty(empName) Then empName &= " "
                            empName &= row("lastName").ToString()
                        End If
                        If StringComparer.OrdinalIgnoreCase.Equals(empName, selectedEmpName) Then
                            If users.Columns.Contains("userId") AndAlso Not IsDBNull(row("userId")) Then
                                employeeID = Convert.ToInt32(row("userId"))
                            End If
                            Exit For
                        End If
                    Next
                End If
            End If

            ' Update property assignment in database
            Dim success As Boolean = DatabaseConnection.AssignPropertyToEmployee(currentPropertyID, employeeID, departmentID)
            If success Then
                MessageBox.Show("Property assignment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Rebuild issuance table
                BuildPropertyIssuanceTableFromProperty()
            Else
                MessageBox.Show("Failed to save property assignment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving property assignment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function SafeGetDate(row As DataRow, ParamArray names() As String) As DateTime
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not Convert.IsDBNull(row(name)) Then
                Dim parsedDate As Date
                If Date.TryParse(row(name).ToString(), parsedDate) Then
                    Return parsedDate
                End If
            End If
        Next
        Return DateTime.Now
    End Function

    Private Function SafeGetDecimal(row As DataRow, ParamArray names() As String) As Decimal
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not Convert.IsDBNull(row(name)) Then
                Dim value As Decimal
                If Decimal.TryParse(row(name).ToString(), value) Then
                    Return value
                End If
            End If
        Next
        Return 0D
    End Function

    Private Sub fundCluster_Click(sender As Object, e As System.EventArgs) Handles fundCluster.Click

    End Sub

    Private Sub pcEntityName_TextChanged(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub lblName_Click(sender As Object, e As System.EventArgs) Handles lblName.Click

    End Sub

    Private Sub txtname_TextChanged(sender As Object, e As System.EventArgs) Handles entityNameTxt.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As System.EventArgs) Handles RoundedButton2.Click
        Me.Close()
    End Sub

    Private Sub btnCSV_Click(sender As Object, e As EventArgs) Handles btnCSV.Click
        Try
            ' Rebuild table from current form data
            BuildPropertyIssuanceTableFromProperty()

            If propertyIssuanceTable Is Nothing OrElse propertyIssuanceTable.Rows.Count = 0 Then
                MessageBox.Show("No data to export. Please ensure all fields are filled.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Export to CSV in Property Acknowledgement Receipt format
            Dim fileName As String = "property_acknowledgement_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            ExportPropertyAcknowledgementToCsv(fileName)
        Catch ex As Exception
            MessageBox.Show("Error exporting CSV: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        Try
            ' Rebuild table from current form data
            BuildPropertyIssuanceTableFromProperty()

            If propertyIssuanceTable Is Nothing OrElse propertyIssuanceTable.Rows.Count = 0 Then
                MessageBox.Show("No data to export. Please ensure all fields are filled.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Export to PDF in Property Acknowledgement Receipt format
            Dim fileName As String = "property_acknowledgement_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".pdf"
            ExportPropertyAcknowledgementToPdf(fileName)
        Catch ex As Exception
            MessageBox.Show("Error exporting PDF: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportPropertyAcknowledgementToCsv(fileName As String)
        Try
            Using dialog As New SaveFileDialog()
                dialog.Filter = "CSV Files|*.csv"
                dialog.FileName = fileName
                dialog.AddExtension = True
                dialog.DefaultExt = "csv"

                If dialog.ShowDialog() = DialogResult.OK Then
                    Using writer As New StreamWriter(dialog.FileName, False, New UTF8Encoding(True))
                        ' Write header
                        writer.WriteLine("PROPERTY ACKNOWLEDGEMENT RECEIPT")
                        writer.WriteLine("")
                        writer.WriteLine("Entity Name," & QuoteCsvValue(entityNameTxt.Text))
                        writer.WriteLine("PAR No.," & QuoteCsvValue(numberPAR.Text))
                        writer.WriteLine("")
                        writer.WriteLine("PROPERTY DETAILS")
                        writer.WriteLine("Property Number," & QuoteCsvValue(propertyNumber.Text))
                        writer.WriteLine("Description," & QuoteCsvValue(description.Text))
                        writer.WriteLine("Quantity," & QuoteCsvValue(quantity.Text))
                        writer.WriteLine("Unit," & QuoteCsvValue(TextBox4.Text))
                        writer.WriteLine("Date Acquired," & QuoteCsvValue(dateAcquired.Value.ToString("dddd, MMMM dd, yyyy")))
                        writer.WriteLine("Amount," & QuoteCsvValue(amount.Text))
                        writer.WriteLine("")
                        writer.WriteLine("RECEIVED BY")
                        writer.WriteLine("Name," & QuoteCsvValue(TextBox1.Text))
                        writer.WriteLine("Position/Office," & QuoteCsvValue(If(ComboBox1.SelectedIndex > 0, ComboBox1.SelectedItem.ToString(), "")))
                        writer.WriteLine("Date," & QuoteCsvValue(DateTimePicker1.Value.ToString("dddd, MMMM dd, yyyy")))
                        writer.WriteLine("")
                        writer.WriteLine("ISSUED BY")
                        writer.WriteLine("Name," & QuoteCsvValue(TextBox2.Text))
                        writer.WriteLine("Position/Office," & QuoteCsvValue(If(ComboBox2.SelectedIndex > 0, ComboBox2.SelectedItem.ToString(), "")))
                        writer.WriteLine("Date," & QuoteCsvValue(DateTimePicker2.Value.ToString("dddd, MMMM dd, yyyy")))
                    End Using

                    MessageBox.Show("Property Acknowledgement Receipt exported successfully to CSV.", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error exporting CSV: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportPropertyAcknowledgementToPdf(fileName As String)
        Try
            Using dialog As New SaveFileDialog()
                dialog.Filter = "PDF Files|*.pdf"
                dialog.FileName = fileName
                dialog.AddExtension = True
                dialog.DefaultExt = "pdf"

                If dialog.ShowDialog() = DialogResult.OK Then
                    ' Create a formated PDF export
                    Dim pdfTable As New DataTable()
                    pdfTable.Columns.Add("Field", GetType(String))
                    pdfTable.Columns.Add("Value", GetType(String))

                    ' Add all form data to table
                    pdfTable.Rows.Add("PROPERTY ACKNOWLEDGEMENT RECEIPT", "")
                    pdfTable.Rows.Add("", "")
                    pdfTable.Rows.Add("Entity Name", entityNameTxt.Text)
                    pdfTable.Rows.Add("PAR No.", numberPAR.Text)
                    pdfTable.Rows.Add("", "")
                    pdfTable.Rows.Add("PROPERTY DETAILS", "")
                    pdfTable.Rows.Add("Property Number", propertyNumber.Text)
                    pdfTable.Rows.Add("Description", description.Text)
                    pdfTable.Rows.Add("Quantity", quantity.Text)
                    pdfTable.Rows.Add("Unit", TextBox4.Text)
                    pdfTable.Rows.Add("Date Acquired", dateAcquired.Value.ToString("dddd, MMMM dd, yyyy"))
                    pdfTable.Rows.Add("Amount", amount.Text)
                    pdfTable.Rows.Add("", "")
                    pdfTable.Rows.Add("RECEIVED BY", "")
                    pdfTable.Rows.Add("Signature over Printed Name of End User", TextBox1.Text)
                    pdfTable.Rows.Add("Position/Office", If(ComboBox1.SelectedIndex > 0, ComboBox1.SelectedItem.ToString(), ""))
                    pdfTable.Rows.Add("Date", DateTimePicker1.Value.ToString("dddd, MMMM dd, yyyy"))
                    pdfTable.Rows.Add("", "")
                    pdfTable.Rows.Add("ISSUED BY", "")
                    pdfTable.Rows.Add("Signature Printed Name of Supply and/or Property Custodian", TextBox2.Text)
                    pdfTable.Rows.Add("Position/Office", If(ComboBox2.SelectedIndex > 0, ComboBox2.SelectedItem.ToString(), ""))
                    pdfTable.Rows.Add("Date", DateTimePicker2.Value.ToString("dddd, MMMM dd, yyyy"))

                    ReportExportHelper.ExportDataTableToPdf(pdfTable, dialog.FileName, "Property Acknowledgement Receipt", "Property Acknowledgement Receipt exported successfully to PDF.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error exporting PDF: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function QuoteCsvValue(value As String) As String
        If String.IsNullOrEmpty(value) Then Return ""
        ' Escape quotes and wrap in quotes if contains comma, quote, or newline
        If value.Contains(",") OrElse value.Contains("""") OrElse value.Contains(vbCrLf) OrElse value.Contains(vbLf) Then
            Return """" & value.Replace("""", """""") & """"
        End If
        Return value
    End Function

    Private Function SafeGetString(row As DataRow, ParamArray names() As String) As String
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not Convert.IsDBNull(row(name)) Then
                Return row(name).ToString()
            End If
        Next
        Return ""
    End Function

    Private Function SafeGetInt(row As DataRow, columnName As String, Optional fallback As Integer = 0) As Integer
        If row.Table.Columns.Contains(columnName) AndAlso Not Convert.IsDBNull(row(columnName)) Then
            Dim value As Integer
            If Integer.TryParse(row(columnName).ToString(), value) Then
                Return value
            End If
        End If
        Return fallback
    End Function

    Private Function SafeGetDateString(row As DataRow, columnName As String) As String
        If row.Table.Columns.Contains(columnName) AndAlso Not Convert.IsDBNull(row(columnName)) Then
            Dim parsedDate As Date
            If Date.TryParse(row(columnName).ToString(), parsedDate) Then
                Return parsedDate.ToString("yyyy-MM-dd")
            End If
        End If
        Return Date.Today.ToString("yyyy-MM-dd")
    End Function

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    ' Save button functionality (if needed - can be added to form)
    Private Sub SaveButton_Click(sender As Object, e As EventArgs)
        SavePropertyAssignment()
    End Sub

    ' Auto-save when dropdowns change
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If currentPropertyID > 0 Then
            BuildPropertyIssuanceTableFromProperty()
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If currentPropertyID > 0 Then
            BuildPropertyIssuanceTableFromProperty()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If currentPropertyID > 0 Then
            BuildPropertyIssuanceTableFromProperty()
        End If
    End Sub
End Class
