Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class PropertyIssuance
    Private propertyIssuanceTable As DataTable
    Private currentPropertyID As Integer = -1
    Private currentPropertyData As DataRow = Nothing

    ' Constructor to accept propertyID
    Public Sub New(Optional propertyID As Integer = -1)
        InitializeComponent()
        currentPropertyID = propertyID
    End Sub

    Private Sub PropertyIssuance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate dropdowns first
        PopulateDropdowns()

        ' Load property data if propertyID is provided
        If currentPropertyID > 0 Then
            LoadPropertyData(currentPropertyID)
        Else
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

    Private Sub LoadPropertyData(propertyID As Integer)
        Try
            currentPropertyData = DatabaseConnection.GetPropertyDetails(propertyID)
            If currentPropertyData Is Nothing Then
                MessageBox.Show("Property not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Auto-fill all fields from property data
            entityNameTxt.Text = "Sta. Cruz Property Custodian System"
            numberPAR.Text = "PAR-" & DateTime.Now.ToString("yyyyMMdd") & "-" & propertyID.ToString("D6")

            ' Property Details
            propertyNumber.Text = SafeGetString(currentPropertyData, "propertyNumber", "")
            description.Text = SafeGetString(currentPropertyData, "description", "itemName", "")
            quantity.Text = "1"
            TextBox4.Text = SafeGetString(currentPropertyData, "unitOfMeasure", "unit", "")

            ' Amount and Date Acquired
            If currentPropertyData.Table.Columns.Contains("acquisitionCost") AndAlso Not IsDBNull(currentPropertyData("acquisitionCost")) Then
                Dim cost As Decimal = 0D
                If Decimal.TryParse(currentPropertyData("acquisitionCost").ToString(), cost) Then
                    amount.Text = cost.ToString("N2")
                End If
            End If

            If currentPropertyData.Table.Columns.Contains("acquisitionDate") AndAlso Not IsDBNull(currentPropertyData("acquisitionDate")) Then
                Dim acqDate As Date
                If Date.TryParse(currentPropertyData("acquisitionDate").ToString(), acqDate) Then
                    dateAcquired.Value = acqDate
                End If
            End If

            ' Received By (Employee assignment)
            Dim assignedEmployee As String = SafeGetString(currentPropertyData, "assignedEmployee", "")
            If Not String.IsNullOrEmpty(assignedEmployee) Then
                TextBox1.Text = assignedEmployee
                ' Try to select in ComboBox1
                For i As Integer = 0 To ComboBox1.Items.Count - 1
                    If ComboBox1.Items(i).ToString().Equals(assignedEmployee, StringComparison.OrdinalIgnoreCase) Then
                        ComboBox1.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If

            ' Department
            Dim assignedDept As String = SafeGetString(currentPropertyData, "assignedDepartment", "departmentName", "")
            If Not String.IsNullOrEmpty(assignedDept) Then
                ' Try to select in ComboBox1 if it's a department name
                For i As Integer = 0 To ComboBox1.Items.Count - 1
                    If ComboBox1.Items(i).ToString().Equals(assignedDept, StringComparison.OrdinalIgnoreCase) Then
                        ComboBox1.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If

            ' Issued By (Property Custodian - current admin/superadmin)
            Dim currentUser As String = ""
            If SessionContext.CurrentUsername IsNot Nothing Then
                currentUser = SessionContext.CurrentUsername
            End If
            If String.IsNullOrEmpty(currentUser) Then
                currentUser = "Property Custodian"
            End If
            TextBox2.Text = currentUser

            ' Set dates
            DateTimePicker1.Value = DateTime.Now ' Date received
            DateTimePicker2.Value = DateTime.Now ' Date issued

            ' Build property issuance table for export
            BuildPropertyIssuanceTableFromProperty()

        Catch ex As Exception
            MessageBox.Show("Error loading property data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                            If row("departmentName").ToString().Equals(selectedDeptName, StringComparison.OrdinalIgnoreCase) Then
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
                        If empName.Equals(selectedEmpName, StringComparison.OrdinalIgnoreCase) Then
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

            Dim fileName As String = "property_acknowledgement_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            ReportExportHelper.ExportDataTableToCsv(propertyIssuanceTable, fileName, "Property Acknowledgement Receipt exported successfully to CSV.")
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

            Dim fileName As String = "property_acknowledgement_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".pdf"
            ReportExportHelper.ExportDataTableToPdf(propertyIssuanceTable, fileName, "Property Acknowledgement Receipt")
        Catch ex As Exception
            MessageBox.Show("Error exporting PDF: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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
