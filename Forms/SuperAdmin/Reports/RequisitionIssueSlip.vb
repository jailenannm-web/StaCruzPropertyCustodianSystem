Imports System
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Partial Public Class RequisitionIssueSlip
    Private requisitionTable As DataTable
    Private selectedRequestId As Integer? = Nothing
    Private selectedRequestType As String = ""

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(requestId As Integer, requestType As String)
        InitializeComponent()
        selectedRequestId = requestId
        selectedRequestType = requestType
    End Sub

    Private Sub RequisitionIssueSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' If a specific request was selected, load and populate it
        If selectedRequestId.HasValue AndAlso Not String.IsNullOrEmpty(selectedRequestType) Then
            LoadSelectedRequest()
        Else
            LoadRequisitionData()
        End If
    End Sub

    Private Sub LoadSelectedRequest()
        Try
            Dim requestData As DataRow = modDB.GetRequestById(selectedRequestId.Value, selectedRequestType)
            If requestData IsNot Nothing Then
                ' Debug: Log all columns and values
                System.Diagnostics.Debug.WriteLine("[v0] ===== Request Data Loaded =====")
                For Each col As DataColumn In requestData.Table.Columns
                    Dim value As String = If(Convert.IsDBNull(requestData(col.ColumnName)), "NULL", requestData(col.ColumnName).ToString())
                    System.Diagnostics.Debug.WriteLine($"[v0] {col.ColumnName} = {value}")
                Next
                System.Diagnostics.Debug.WriteLine("[v0] =================================")
                ' Populate form fields
                requestId.Text = SafeGetValue(requestData, "request_id")
                requesterName.Text = SafeGetValue(requestData, "requesterName", "requester_name")
                position.Text = SafeGetValue(requestData, "position")
                ' Try to get department name first, fall back to department ID
                Dim deptName As String = SafeGetValue(requestData, "departmentName", "department")
                If String.IsNullOrEmpty(deptName) Then
                    deptName = SafeGetValue(requestData, "departmentId", "department_id")
                End If
                ' Always set the text, whether it's in the dropdown or not
                If department IsNot Nothing Then
                    If department.Items.Count > 0 Then
                        Dim deptIndex As Integer = department.Items.IndexOf(deptName)
                        If deptIndex >= 0 Then
                            department.SelectedIndex = deptIndex
                        Else
                            ' Add the department to items if not exists, then select it
                            If Not String.IsNullOrEmpty(deptName) Then
                                department.Items.Add(deptName)
                                department.SelectedItem = deptName
                            End If
                        End If
                    Else
                        ' No items in ComboBox, just set text directly
                        If Not String.IsNullOrEmpty(deptName) Then
                            department.Items.Add(deptName)
                            department.SelectedItem = deptName
                        End If
                    End If
                End If
                ' Handle dateOfRequest properly
                If dateOfRequest IsNot Nothing Then
                    Try
                        Dim dateObj As Object = Nothing
                        If requestData.Table.Columns.Contains("request_date") AndAlso Not Convert.IsDBNull(requestData("request_date")) Then
                            dateObj = requestData("request_date")
                        ElseIf requestData.Table.Columns.Contains("dateOfRequest") AndAlso Not Convert.IsDBNull(requestData("dateOfRequest")) Then
                            dateObj = requestData("dateOfRequest")
                        End If

                        System.Diagnostics.Debug.WriteLine($"[v0] dateOfRequest dateObj type: {If(dateObj IsNot Nothing, dateObj.GetType().Name, "NULL")}, value: {If(dateObj IsNot Nothing, dateObj.ToString(), "NULL")}")

                        If dateObj IsNot Nothing Then
                            Dim parsedDate As DateTime
                            ' Try to parse regardless of type
                            If TypeOf dateObj Is DateTime Then
                                parsedDate = CType(dateObj, DateTime)
                                dateOfRequest.Value = parsedDate
                                dateOfRequest.Format = DateTimePickerFormat.Custom
                                dateOfRequest.CustomFormat = "dddd, dd MMMM yyyy"
                                dateOfRequest.ShowCheckBox = False
                                System.Diagnostics.Debug.WriteLine($"[v0] Set dateOfRequest from DateTime: {parsedDate}")
                            ElseIf dateObj.GetType().Name = "MySqlDateTime" OrElse dateObj.GetType().FullName.Contains("MySqlDateTime") Then
                                ' Handle MySqlDateTime type - use reflection to be safe
                                Try
                                    Dim typeObj = dateObj.GetType()
                                    Dim isValidMethod = typeObj.GetProperty("IsValidDateTime")
                                    Dim getDateTimeMethod = typeObj.GetMethod("GetDateTime")
                                    
                                    If isValidMethod IsNot Nothing AndAlso getDateTimeMethod IsNot Nothing Then
                                        Dim isValid As Boolean = CBool(isValidMethod.GetValue(dateObj))
                                        System.Diagnostics.Debug.WriteLine($"[v0] MySqlDateTime IsValid: {isValid}")
                                        
                                        If isValid Then
                                            parsedDate = CType(getDateTimeMethod.Invoke(dateObj, Nothing), DateTime)
                                            ' Set format BEFORE setting value
                                            dateOfRequest.Format = DateTimePickerFormat.Custom
                                            dateOfRequest.CustomFormat = "dddd, dd MMMM yyyy"
                                            dateOfRequest.ShowCheckBox = False
                                            dateOfRequest.Value = parsedDate
                                            dateOfRequest.Refresh() ' Force refresh to update display
                                            System.Diagnostics.Debug.WriteLine($"[v0] Set dateOfRequest from MySqlDateTime: {parsedDate} -> Display: {dateOfRequest.Text}")
                                        End If
                                    End If
                                Catch ex As Exception
                                    System.Diagnostics.Debug.WriteLine($"[v0] MySqlDateTime conversion error: {ex.Message}")
                                    System.Diagnostics.Debug.WriteLine($"[v0] Stack: {ex.StackTrace}")
                                End Try
                            ElseIf DateTime.TryParse(dateObj.ToString(), parsedDate) Then
                                dateOfRequest.Value = parsedDate
                                dateOfRequest.Format = DateTimePickerFormat.Custom
                                dateOfRequest.CustomFormat = "dddd, dd MMMM yyyy"
                                dateOfRequest.ShowCheckBox = False
                                System.Diagnostics.Debug.WriteLine($"[v0] Set dateOfRequest from parsed string: {parsedDate}")
                            Else
                                System.Diagnostics.Debug.WriteLine("[v0] Could not parse date of request")
                            End If
                        Else
                            System.Diagnostics.Debug.WriteLine("[v0] No date of request found")
                        End If
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine("[v0] Date of request parsing error: " & ex.Message & " - " & ex.StackTrace)
                    End Try
                End If
                itemName.Text = SafeGetValue(requestData, "item_name", "itemName")
                description.Text = SafeGetValue(requestData, "description")
                quantityRequesteed.Text = SafeGetValue(requestData, "quantity", "quantityRequested")
                unit.Text = SafeGetValue(requestData, "unit")
                purpose.Text = SafeGetValue(requestData, "remarks", "purpose")
                status.Text = SafeGetValue(requestData, "status")
                remarks.Text = SafeGetValue(requestData, "remarks")

                ' Populate approved date and approved by
                If approvedDate IsNot Nothing Then
                    Try
                        ' Try to get the date value directly from the DataRow
                        Dim approvedDateObj As Object = Nothing
                        If requestData.Table.Columns.Contains("approval_date") AndAlso Not Convert.IsDBNull(requestData("approval_date")) Then
                            approvedDateObj = requestData("approval_date")
                        ElseIf requestData.Table.Columns.Contains("approvedDate") AndAlso Not Convert.IsDBNull(requestData("approvedDate")) Then
                            approvedDateObj = requestData("approvedDate")
                        End If

                        System.Diagnostics.Debug.WriteLine($"[v0] approvedDate dateObj type: {If(approvedDateObj IsNot Nothing, approvedDateObj.GetType().Name, "NULL")}, value: {If(approvedDateObj IsNot Nothing, approvedDateObj.ToString(), "NULL")}")

                        If approvedDateObj IsNot Nothing Then
                            Dim parsedDate As DateTime
                            ' Try to parse regardless of type
                            If TypeOf approvedDateObj Is DateTime Then
                                parsedDate = CType(approvedDateObj, DateTime)
                                approvedDate.Value = parsedDate
                                approvedDate.Format = DateTimePickerFormat.Custom
                                approvedDate.CustomFormat = "dddd, dd MMMM yyyy"
                                approvedDate.ShowCheckBox = False
                                System.Diagnostics.Debug.WriteLine($"[v0] Set approvedDate from DateTime: {parsedDate}")
                            ElseIf approvedDateObj.GetType().Name = "MySqlDateTime" OrElse approvedDateObj.GetType().FullName.Contains("MySqlDateTime") Then
                                ' Handle MySqlDateTime type - use reflection to be safe
                                Try
                                    Dim typeObj = approvedDateObj.GetType()
                                    Dim isValidMethod = typeObj.GetProperty("IsValidDateTime")
                                    Dim getDateTimeMethod = typeObj.GetMethod("GetDateTime")
                                    
                                    If isValidMethod IsNot Nothing AndAlso getDateTimeMethod IsNot Nothing Then
                                        Dim isValid As Boolean = CBool(isValidMethod.GetValue(approvedDateObj))
                                        System.Diagnostics.Debug.WriteLine($"[v0] MySqlDateTime IsValid: {isValid}")
                                        
                                        If isValid Then
                                            parsedDate = CType(getDateTimeMethod.Invoke(approvedDateObj, Nothing), DateTime)
                                            ' Set format BEFORE setting value
                                            approvedDate.Format = DateTimePickerFormat.Custom
                                            approvedDate.CustomFormat = "dddd, dd MMMM yyyy"
                                            approvedDate.ShowCheckBox = False
                                            approvedDate.Value = parsedDate
                                            approvedDate.Refresh() ' Force refresh to update display
                                            System.Diagnostics.Debug.WriteLine($"[v0] Set approvedDate from MySqlDateTime: {parsedDate} -> Display: {approvedDate.Text}")
                                        End If
                                    End If
                                Catch ex As Exception
                                    System.Diagnostics.Debug.WriteLine($"[v0] MySqlDateTime conversion error: {ex.Message}")
                                    System.Diagnostics.Debug.WriteLine($"[v0] Stack: {ex.StackTrace}")
                                End Try
                            ElseIf DateTime.TryParse(approvedDateObj.ToString(), parsedDate) Then
                                approvedDate.Value = parsedDate
                                approvedDate.Format = DateTimePickerFormat.Custom
                                approvedDate.CustomFormat = "dddd, dd MMMM yyyy"
                                approvedDate.ShowCheckBox = False
                                System.Diagnostics.Debug.WriteLine($"[v0] Set approvedDate from parsed string: {parsedDate}")
                            Else
                                System.Diagnostics.Debug.WriteLine("[v0] Could not parse approved date")
                            End If
                        Else
                            System.Diagnostics.Debug.WriteLine("[v0] No approved date found")
                        End If
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine("[v0] Approved date parsing error: " & ex.Message & " - " & ex.StackTrace)
                    End Try
                End If
                If approvedBy IsNot Nothing Then
                    Dim approvedByName As String = SafeGetValue(requestData, "approved_by_name", "approvedBy")
                    Dim approvedIndex As Integer = approvedBy.Items.IndexOf(approvedByName)
                    If approvedIndex >= 0 Then
                        approvedBy.SelectedIndex = approvedIndex
                    Else
                        approvedBy.Text = approvedByName
                    End If
                End If

                ' Build requisition table with this single request
                Dim dt As New DataTable()
                dt.Columns.Add("request_id", GetType(Integer))
                dt.Columns.Add("itemName", GetType(String))
                dt.Columns.Add("unit", GetType(String))
                dt.Columns.Add("description", GetType(String))
                dt.Columns.Add("quantityRequested", GetType(Integer))
                dt.Columns.Add("remarks", GetType(String))
                dt.Columns.Add("status", GetType(String))

                Dim newRow As DataRow = dt.NewRow()
                newRow("request_id") = selectedRequestId.Value
                newRow("itemName") = SafeGetValue(requestData, "item_name", "itemName")
                newRow("unit") = SafeGetValue(requestData, "unit")
                newRow("description") = SafeGetValue(requestData, "description")
                newRow("quantityRequested") = SafeGetInt(requestData, "quantity", "quantityRequested", 1)
                newRow("remarks") = SafeGetValue(requestData, "remarks")
                newRow("status") = SafeGetValue(requestData, "status")
                dt.Rows.Add(newRow)

                requisitionTable = BuildRequisitionTable(dt)
            Else
                MessageBox.Show("Request not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LoadRequisitionData()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading request data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LoadRequisitionData()
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

    Private Function SafeGetDateValue(row As DataRow, ParamArray names() As String) As String
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not Convert.IsDBNull(row(name)) Then
                Try
                    Dim dateValue As DateTime
                    Dim dateObj As Object = row(name)
                    
                    ' Handle DateTime
                    If TypeOf dateObj Is DateTime Then
                        dateValue = CType(dateObj, DateTime)
                        If dateValue.TimeOfDay = TimeSpan.Zero Then
                            Return dateValue.ToString("dddd, dd MMMM yyyy")
                        Else
                            Return dateValue.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                        End If
                    ' Handle MySqlDateTime using reflection
                    ElseIf dateObj.GetType().Name = "MySqlDateTime" OrElse dateObj.GetType().FullName.Contains("MySqlDateTime") Then
                        Try
                            Dim typeObj = dateObj.GetType()
                            Dim isValidMethod = typeObj.GetProperty("IsValidDateTime")
                            Dim getDateTimeMethod = typeObj.GetMethod("GetDateTime")
                            
                            If isValidMethod IsNot Nothing AndAlso getDateTimeMethod IsNot Nothing Then
                                Dim isValid As Boolean = CBool(isValidMethod.GetValue(dateObj))
                                If isValid Then
                                    dateValue = CType(getDateTimeMethod.Invoke(dateObj, Nothing), DateTime)
                                    If dateValue.TimeOfDay = TimeSpan.Zero Then
                                        Return dateValue.ToString("dddd, dd MMMM yyyy")
                                    Else
                                        Return dateValue.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                                    End If
                                End If
                            End If
                        Catch mySqlEx As Exception
                            System.Diagnostics.Debug.WriteLine($"[v0] MySqlDateTime error for column '{name}': {mySqlEx.Message}")
                        End Try
                    ' Try parsing string
                    ElseIf DateTime.TryParse(dateObj.ToString(), dateValue) Then
                        If dateValue.TimeOfDay = TimeSpan.Zero Then
                            Return dateValue.ToString("dddd, dd MMMM yyyy")
                        Else
                            Return dateValue.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                        End If
                    Else
                        ' Return the string value as-is if it's not parseable
                        Dim strValue As String = dateObj.ToString().Trim()
                        If Not String.IsNullOrWhiteSpace(strValue) AndAlso strValue.Length < 50 Then
                            Return strValue
                        End If
                    End If
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine($"[v0] SafeGetDateValue error for column '{name}': {ex.Message}")
                End Try
            End If
        Next
        Return ""
    End Function

    Private Sub LoadRequisitionData()
        Try
            ' Load supply requests using modDB function
            Dim dt As DataTable = modDB.GetAllSuppliesRequests()
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                requisitionTable = New DataTable()
                Return
            End If

            ' Build requisition table
            requisitionTable = BuildRequisitionTable(dt)

            ' Populate form fields with first record if available
            If dt.Rows.Count > 0 Then
                Dim firstRow As DataRow = dt.Rows(0)
                ' Populate any form fields if needed
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading requisition data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            requisitionTable = New DataTable()
        End Try
    End Sub

    Private Sub admin_label_Reports_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub divisionName_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs)

    End Sub





    Private Function BuildRequisitionTable(source As DataTable) As DataTable
        Dim reportTable As New DataTable()
        reportTable.Columns.Add("requisitionName", GetType(String))
        reportTable.Columns.Add("requisitionUnit", GetType(String))
        reportTable.Columns.Add("requisitionParticulars", GetType(String))
        reportTable.Columns.Add("requisitionQuantity1", GetType(Integer))
        reportTable.Columns.Add("requisitionYes", GetType(String))
        reportTable.Columns.Add("requisitionNo", GetType(String))
        reportTable.Columns.Add("requisitionQuantity2", GetType(Integer))
        reportTable.Columns.Add("requisitionRemarks", GetType(String))

        If source Is Nothing Then
            Return reportTable
        End If

        Dim filteredRows = source.AsEnumerable().
            Where(Function(r)
                      Dim statusValue As String = If(Convert.IsDBNull(r("status")), "", r("status").ToString().ToLower())
                      Return statusValue = "approved"
                  End Function).
            ToList()

        For Each row As DataRow In filteredRows
            Try
                Dim quantityRequested As Integer = SafeGetInt(row, "quantityRequested", "quantity_requested", 1)
                Dim newRow As DataRow = reportTable.NewRow()
                newRow("requisitionName") = SafeGetString(row, "itemName", "item_name")
                newRow("requisitionUnit") = SafeGetString(row, "unit", "Unit")
                newRow("requisitionParticulars") = SafeGetString(row, "description")
                newRow("requisitionQuantity1") = quantityRequested
                newRow("requisitionYes") = "Yes"
                newRow("requisitionNo") = ""
                newRow("requisitionQuantity2") = quantityRequested
                newRow("requisitionRemarks") = SafeGetString(row, "remarks", "No remarks")
                reportTable.Rows.Add(newRow)
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] RequisitionIssueSlip BuildRow Error: " & ex.Message)
            End Try
        Next

        Return reportTable
    End Function

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel23_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel24_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel25_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub btn_Back_Click(sender As Object, e As EventArgs) Handles btn_Back.Click
        Me.Close()
    End Sub

    Private Sub btnCSV_Click(sender As Object, e As EventArgs) Handles btnCSV.Click
        Try
            ' If we have a selected request, export that specific request data as CSV
            If selectedRequestId.HasValue AndAlso Not String.IsNullOrEmpty(selectedRequestType) Then
                Dim requestData As DataRow = modDB.GetRequestById(selectedRequestId.Value, selectedRequestType)
                If requestData IsNot Nothing Then
                    ' Convert single request to a key-value DataTable for CSV export
                    Dim csvTable As New DataTable()
                    csvTable.Columns.Add("Field", GetType(String))
                    csvTable.Columns.Add("Value", GetType(String))

                    ' Add header
                    csvTable.Rows.Add("REQUISITION ISSUE SLIP", "")
                    csvTable.Rows.Add("", "")
                    
                    ' Add all fields with proper grouping
                    csvTable.Rows.Add("=== REQUEST INFORMATION ===", "")
                    csvTable.Rows.Add("Request ID", SafeGetValue(requestData, "request_id", "requestId"))
                    csvTable.Rows.Add("Date of Request", SafeGetDateValue(requestData, "request_date", "dateOfRequest"))
                    csvTable.Rows.Add("Status", SafeGetValue(requestData, "status"))
                    csvTable.Rows.Add("", "")
                    
                    csvTable.Rows.Add("=== REQUESTER DETAILS ===", "")
                    csvTable.Rows.Add("Requester Name", SafeGetValue(requestData, "requesterName", "requester_name"))
                    csvTable.Rows.Add("Position", SafeGetValue(requestData, "position"))
                    csvTable.Rows.Add("Department", SafeGetValue(requestData, "departmentName", "department"))
                    csvTable.Rows.Add("", "")
                    
                    csvTable.Rows.Add("=== ITEM DETAILS ===", "")
                    csvTable.Rows.Add("Item Name", SafeGetValue(requestData, "item_name", "itemName"))
                    csvTable.Rows.Add("Quantity Requested", SafeGetValue(requestData, "quantity", "quantityRequested"))
                    csvTable.Rows.Add("Unit of Measure", SafeGetValue(requestData, "unit"))
                    csvTable.Rows.Add("Description", SafeGetValue(requestData, "description"))
                    csvTable.Rows.Add("Purpose", SafeGetValue(requestData, "purpose"))
                    csvTable.Rows.Add("", "")
                    
                    csvTable.Rows.Add("=== APPROVAL INFORMATION ===", "")
                    csvTable.Rows.Add("Approved By", SafeGetValue(requestData, "approved_by_name", "approvedBy"))
                    csvTable.Rows.Add("Approved Date", SafeGetDateValue(requestData, "approval_date", "approvedDate"))
                    csvTable.Rows.Add("Remarks", SafeGetValue(requestData, "remarks"))

                    Dim fileName As String = "requisition_slip_" & selectedRequestId.Value.ToString() & "_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".csv"
                    ReportExportHelper.ExportDataTableToCsv(csvTable, fileName)
                Else
                    MessageBox.Show("Request data not found.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            ElseIf requisitionTable IsNot Nothing AndAlso requisitionTable.Rows.Count > 0 Then
                ' Export all requisitions
                Dim fileName As String = "requisition_issue_slip_all_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".csv"
                ReportExportHelper.ExportDataTableToCsv(requisitionTable, fileName, , True)
            Else
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting CSV: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        Try
            ' If we have a selected request, use the specialized PDF export
            If selectedRequestId.HasValue AndAlso Not String.IsNullOrEmpty(selectedRequestType) Then
                Dim requestData As DataRow = modDB.GetRequestById(selectedRequestId.Value, selectedRequestType)
                If requestData IsNot Nothing Then
                    Dim fileName As String = "requisition_slip_" & selectedRequestId.Value.ToString() & "_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".pdf"
                    ReportExportHelper.ExportRequisitionSlipToPdf(requestData, fileName)
                Else
                    MessageBox.Show("Request data not found.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            ElseIf requisitionTable IsNot Nothing AndAlso requisitionTable.Rows.Count > 0 Then
                ' Export all requisitions as table
                Dim fileName As String = "requisition_issue_slip_all_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".pdf"
                ReportExportHelper.ExportDataTableToPdf(requisitionTable, fileName, "Requisition and Issue Slip")
            Else
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
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
        ' If no match found and last parameter is not a column name, use it as fallback
        If names.Length > 0 AndAlso Not row.Table.Columns.Contains(names(names.Length - 1)) Then
            Return names(names.Length - 1)
        End If
        Return ""
    End Function

    Private Function SafeGetInt(row As DataRow, ParamArray names() As String) As Integer
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not Convert.IsDBNull(row(name)) Then
                Dim value As Integer
                If Integer.TryParse(row(name).ToString(), value) Then
                    Return value
                End If
            End If
        Next
        ' If no match found and last parameter is numeric, use it as fallback
        If names.Length > 0 Then
            Dim lastParam As String = names(names.Length - 1)
            If Not row.Table.Columns.Contains(lastParam) Then
                Dim fallbackValue As Integer
                If Integer.TryParse(lastParam, fallbackValue) Then
                    Return fallbackValue
                End If
            End If
        End If
        Return 0
    End Function

    Private Sub entityName_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub fundCluster_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblPropertyCard_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub departmentId_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub unit_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub departmentId_TextChanged_1(sender As Object, e As EventArgs) 

    End Sub

    Private Sub position_TextChanged(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub Panel16_Paint(sender As Object, e As PaintEventArgs) 

    End Sub

    Private Sub requestId_TextChanged(sender As Object, e As EventArgs) 

    End Sub
End Class