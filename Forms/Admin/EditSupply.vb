Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Public Class EditSupply
    Inherits UserControl

    Private currentSupplyID As Integer

    ' Helper to find a control by name and cast to expected type
    Private Function FindControlOfType(Of T As Control)(name As String) As T
        Dim matches = Me.Controls.Find(name, True)
        If matches Is Nothing OrElse matches.Length = 0 Then
            Return Nothing
        End If
        Return TryCast(matches(0), T)
    End Function

    Public Sub LoadSupplyData(supplyIDParam As Integer, supplyRow As DataRow)
        currentSupplyID = supplyIDParam

        Try
            ' Map database columns to form fields using correct camelCase column names
            If supplyRow.Table.Columns.Contains("itemName") AndAlso Not IsDBNull(supplyRow("itemName")) Then
                Dim txt = FindControlOfType(Of TextBox)("supplyName")
                If txt IsNot Nothing Then txt.Text = supplyRow("itemName").ToString()
            ElseIf supplyRow.Table.Columns.Contains("item_name") AndAlso Not IsDBNull(supplyRow("item_name")) Then
                Dim txt = FindControlOfType(Of TextBox)("supplyName")
                If txt IsNot Nothing Then txt.Text = supplyRow("item_name").ToString()
            End If

            If supplyRow.Table.Columns.Contains("category") AndAlso Not IsDBNull(supplyRow("category")) Then
                Dim categoryBox As ComboBox = FindControlOfType(Of ComboBox)("category")
                If categoryBox Is Nothing Then categoryBox = FindControlOfType(Of ComboBox)("categoryCmbo")
                If categoryBox IsNot Nothing Then
                    ' Populate dropdown first if empty
                    If categoryBox.Items.Count = 0 Then
                        Dim categories As DataTable = DatabaseConnection.GetCategories("supply")
                        If categories IsNot Nothing AndAlso categories.Rows.Count > 0 Then
                            For Each row As DataRow In categories.Rows
                                Dim categoryName As String = ""
                                If row.Table.Columns.Contains("category_name") AndAlso Not IsDBNull(row("category_name")) Then
                                    categoryName = row("category_name").ToString()
                                ElseIf row.Table.Columns.Contains("categoryName") AndAlso Not IsDBNull(row("categoryName")) Then
                                    categoryName = row("categoryName").ToString()
                                ElseIf row.Table.Columns.Count > 0 AndAlso Not IsDBNull(row(0)) Then
                                    categoryName = row(0).ToString()
                                End If
                                If Not String.IsNullOrEmpty(categoryName) AndAlso Not categoryBox.Items.Contains(categoryName) Then
                                    categoryBox.Items.Add(categoryName)
                                End If
                            Next
                        End If
                    End If
                    ' Try to select the category in the combo box
                    Dim categoryValue As String = supplyRow("category").ToString()
                    Dim categoryIndex As Integer = categoryBox.FindStringExact(categoryValue)
                    If categoryIndex >= 0 Then
                        categoryBox.SelectedIndex = categoryIndex
                    Else
                        categoryBox.Text = categoryValue
                    End If
                End If
            End If

            If supplyRow.Table.Columns.Contains("quantity") AndAlso Not IsDBNull(supplyRow("quantity")) Then
                Dim qtyValue As Integer = 0
                If Integer.TryParse(supplyRow("quantity").ToString(), qtyValue) Then
                    Dim nud As NumericUpDown = FindControlOfType(Of NumericUpDown)("stockSupply")
                    If nud IsNot Nothing Then
                        ' Ensure value is within bounds
                        Dim safeVal As Decimal = Math.Min(Math.Max(qtyValue, nud.Minimum), nud.Maximum)
                        nud.Value = safeVal
                    End If
                End If
            End If

            If supplyRow.Table.Columns.Contains("unitOfMeasure") AndAlso Not IsDBNull(supplyRow("unitOfMeasure")) Then
                Dim uomBox As ComboBox = FindControlOfType(Of ComboBox)("unitOfMeasur")
                If uomBox Is Nothing Then uomBox = FindControlOfType(Of ComboBox)("ComboBox1")
                If uomBox IsNot Nothing Then
                    ' Populate dropdown first if empty
                    If uomBox.Items.Count = 0 Then
                        uomBox.Items.AddRange(New String() {"Piece", "Box", "Ream", "Liter", "Kilogram", "Meter", "Set", "Unit", "Pack", "Bottle", "Can", "Roll"})
                    End If
                    Dim uomValue As String = supplyRow("unitOfMeasure").ToString()
                    Dim uomIndex As Integer = uomBox.FindStringExact(uomValue)
                    If uomIndex >= 0 Then
                        uomBox.SelectedIndex = uomIndex
                    Else
                        uomBox.Text = uomValue
                    End If
                End If
            ElseIf supplyRow.Table.Columns.Contains("unit_of_measure") AndAlso Not IsDBNull(supplyRow("unit_of_measure")) Then
                Dim uomBox As ComboBox = FindControlOfType(Of ComboBox)("unitOfMeasur")
                If uomBox Is Nothing Then uomBox = FindControlOfType(Of ComboBox)("ComboBox1")
                If uomBox IsNot Nothing Then
                    If uomBox.Items.Count = 0 Then
                        uomBox.Items.AddRange(New String() {"Piece", "Box", "Ream", "Liter", "Kilogram", "Meter", "Set", "Unit", "Pack", "Bottle", "Can", "Roll"})
                    End If
                    Dim uomValue As String = supplyRow("unit_of_measure").ToString()
                    Dim uomIndex As Integer = uomBox.FindStringExact(uomValue)
                    If uomIndex >= 0 Then
                        uomBox.SelectedIndex = uomIndex
                    Else
                        uomBox.Text = uomValue
                    End If
                End If
            End If

            If supplyRow.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(supplyRow("supplier")) Then
                Dim supplierBox As ComboBox = FindControlOfType(Of ComboBox)("supplier")
                If supplierBox IsNot Nothing Then
                    ' Populate dropdown first if empty
                    If supplierBox.Items.Count = 0 Then
                        Dim suppliers As DataTable = DatabaseConnection.GetSuppliers()
                        If suppliers IsNot Nothing AndAlso suppliers.Rows.Count > 0 Then
                            For Each row As DataRow In suppliers.Rows
                                Dim supplierName As String = ""
                                If row.Table.Columns.Contains("supplier_name") AndAlso Not IsDBNull(row("supplier_name")) Then
                                    supplierName = row("supplier_name").ToString()
                                ElseIf row.Table.Columns.Count > 0 AndAlso Not IsDBNull(row(0)) Then
                                    supplierName = row(0).ToString()
                                End If
                                If Not String.IsNullOrEmpty(supplierName) AndAlso Not supplierBox.Items.Contains(supplierName) Then
                                    supplierBox.Items.Add(supplierName)
                                End If
                            Next
                        End If
                    End If
                    Dim supplierValue As String = supplyRow("supplier").ToString()
                    Dim supplierIndex As Integer = supplierBox.FindStringExact(supplierValue)
                    If supplierIndex >= 0 Then
                        supplierBox.SelectedIndex = supplierIndex
                    Else
                        supplierBox.Text = supplierValue
                    End If
                Else
                    ' Fallback to textbox if ComboBox not found
                    Dim supplier As TextBox = FindControlOfType(Of TextBox)("supplierTxt")
                    If supplier IsNot Nothing Then supplier.Text = supplyRow("supplier").ToString()
                End If
            End If

            If supplyRow.Table.Columns.Contains("description") AndAlso Not IsDBNull(supplyRow("description")) Then
                Dim descBox As ComboBox = FindControlOfType(Of ComboBox)("description")
                If descBox IsNot Nothing Then
                    ' Populate dropdown first if empty
                    If descBox.Items.Count = 0 Then
                        Try
                            Dim conn = DatabaseConnection.GetConnection()
                            If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                                Dim query As String = "SELECT DISTINCT description FROM supplies WHERE description IS NOT NULL AND description != '' ORDER BY description LIMIT 50"
                                Using cmd As New MySql.Data.MySqlClient.MySqlCommand(query, conn)
                                    Using reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                                        While reader.Read()
                                            Dim desc As String = reader("description").ToString()
                                            If Not String.IsNullOrEmpty(desc) AndAlso Not descBox.Items.Contains(desc) Then
                                                descBox.Items.Add(desc)
                                            End If
                                        End While
                                    End Using
                                End Using
                                conn.Close()
                            End If
                        Catch
                            descBox.Items.AddRange(New String() {"Office Supplies", "Cleaning Materials", "Medical Supplies", "IT Equipment", "Furniture", "Tools"})
                        End Try
                    End If
                    Dim descValue As String = supplyRow("description").ToString()
                    Dim descIndex As Integer = descBox.FindStringExact(descValue)
                    If descIndex >= 0 Then
                        descBox.SelectedIndex = descIndex
                    Else
                        descBox.Text = descValue
                    End If
                Else
                    ' Fallback to textbox if ComboBox not found
                    Dim remarks As TextBox = FindControlOfType(Of TextBox)("remarksTxt")
                    If remarks IsNot Nothing Then remarks.Text = supplyRow("description").ToString()
                End If
            End If

            ' Get unitCost (try both camelCase and snake_case)
            Dim unitCostValue As Decimal = 0
            If supplyRow.Table.Columns.Contains("unitCost") AndAlso Not IsDBNull(supplyRow("unitCost")) Then
                Decimal.TryParse(supplyRow("unitCost").ToString(), unitCostValue)
            ElseIf supplyRow.Table.Columns.Contains("unit_cost") AndAlso Not IsDBNull(supplyRow("unit_cost")) Then
                Decimal.TryParse(supplyRow("unit_cost").ToString(), unitCostValue)
            End If
            If Me.Controls.Find("TextBox1", True).Length > 0 Then
                Dim unitCostTxt As TextBox = TryCast(Me.Controls.Find("TextBox1", True)(0), TextBox)
                If unitCostTxt IsNot Nothing Then
                    unitCostTxt.Text = unitCostValue.ToString("0.00")
                End If
            End If

            ' Get totalCost - calculate from quantity * unitCost if not provided
            Dim totalCostValue As Decimal = 0
            If supplyRow.Table.Columns.Contains("totalCost") AndAlso Not IsDBNull(supplyRow("totalCost")) Then
                Decimal.TryParse(supplyRow("totalCost").ToString(), totalCostValue)
            ElseIf supplyRow.Table.Columns.Contains("total_cost") AndAlso Not IsDBNull(supplyRow("total_cost")) Then
                Decimal.TryParse(supplyRow("total_cost").ToString(), totalCostValue)
            Else
                ' Calculate from quantity and unitCost
                Dim qty As Integer = 0
                Dim unitCost As Decimal = 0
                If supplyRow.Table.Columns.Contains("quantity") AndAlso Not IsDBNull(supplyRow("quantity")) Then
                    Integer.TryParse(supplyRow("quantity").ToString(), qty)
                End If
                If supplyRow.Table.Columns.Contains("unitCost") AndAlso Not IsDBNull(supplyRow("unitCost")) Then
                    Decimal.TryParse(supplyRow("unitCost").ToString(), unitCost)
                End If
                totalCostValue = qty * unitCost
            End If
            If Me.Controls.Find("totalCost", True).Length > 0 Then
                Dim totalCostTxt As Control = Me.Controls.Find("totalCost", True)(0)
                If TypeOf totalCostTxt Is TextBox Then
                    CType(totalCostTxt, TextBox).Text = totalCostValue.ToString("0.00")
                ElseIf TypeOf totalCostTxt Is NumericUpDown Then
                    Dim nudTotal As NumericUpDown = CType(totalCostTxt, NumericUpDown)
                    Dim safeVal As Decimal = Math.Min(Math.Max(totalCostValue, nudTotal.Minimum), nudTotal.Maximum)
                    nudTotal.Value = safeVal
                End If
            End If

            ' Get sourceOfFunds
            If supplyRow.Table.Columns.Contains("sourceOfFunds") AndAlso Not IsDBNull(supplyRow("sourceOfFunds")) Then
                Dim sourceTxt As TextBox = FindControlOfType(Of TextBox)("sourceOfFunds")
                If sourceTxt IsNot Nothing Then
                    sourceTxt.Text = supplyRow("sourceOfFunds").ToString()
                End If
            ElseIf supplyRow.Table.Columns.Contains("source_of_funds") AndAlso Not IsDBNull(supplyRow("source_of_funds")) Then
                Dim sourceTxt As TextBox = FindControlOfType(Of TextBox)("sourceOfFunds")
                If sourceTxt IsNot Nothing Then
                    sourceTxt.Text = supplyRow("source_of_funds").ToString()
                End If
            End If

            ' Get location
            If supplyRow.Table.Columns.Contains("location") AndAlso Not IsDBNull(supplyRow("location")) Then
                Dim locationBox As ComboBox = FindControlOfType(Of ComboBox)("location")
                If locationBox IsNot Nothing Then
                    ' Populate dropdown first if empty
                    If locationBox.Items.Count = 0 Then
                        Dim locations As DataTable = DatabaseConnection.GetLocations()
                        If locations IsNot Nothing AndAlso locations.Rows.Count > 0 Then
                            For Each row As DataRow In locations.Rows
                                Dim locationName As String = ""
                                If row.Table.Columns.Contains("location_name") AndAlso Not IsDBNull(row("location_name")) Then
                                    locationName = row("location_name").ToString()
                                ElseIf row.Table.Columns.Count > 0 AndAlso Not IsDBNull(row(0)) Then
                                    locationName = row(0).ToString()
                                End If
                                If Not String.IsNullOrEmpty(locationName) AndAlso Not locationBox.Items.Contains(locationName) Then
                                    locationBox.Items.Add(locationName)
                                End If
                            Next
                        End If
                    End If
                    Dim locationValue As String = supplyRow("location").ToString()
                    Dim locationIndex As Integer = locationBox.FindStringExact(locationValue)
                    If locationIndex >= 0 Then
                        locationBox.SelectedIndex = locationIndex
                    Else
                        locationBox.Text = locationValue
                    End If
                Else
                    ' Fallback to textbox if ComboBox not found
                    Dim locationTxt As TextBox = FindControlOfType(Of TextBox)("TextBox2")
                    If locationTxt IsNot Nothing Then
                        locationTxt.Text = supplyRow("location").ToString()
                    End If
                End If
            End If

            ' Get dateReceived
            If supplyRow.Table.Columns.Contains("dateReceived") AndAlso Not IsDBNull(supplyRow("dateReceived")) Then
                Dim dateValue As Date
                If Date.TryParse(supplyRow("dateReceived").ToString(), dateValue) Then
                    Dim datePicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("dateReceived")
                    If datePicker Is Nothing Then datePicker = FindControlOfType(Of DateTimePicker)("DateTimePicker1")
                    If datePicker IsNot Nothing Then
                        datePicker.Value = dateValue
                    End If
                End If
            ElseIf supplyRow.Table.Columns.Contains("date_received") AndAlso Not IsDBNull(supplyRow("date_received")) Then
                Dim dateValue As Date
                If Date.TryParse(supplyRow("date_received").ToString(), dateValue) Then
                    Dim datePicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("dateReceived")
                    If datePicker Is Nothing Then datePicker = FindControlOfType(Of DateTimePicker)("DateTimePicker1")
                    If datePicker IsNot Nothing Then
                        datePicker.Value = dateValue
                    End If
                End If
            End If

            ' Get stockStatus
            If supplyRow.Table.Columns.Contains("stockStatus") AndAlso Not IsDBNull(supplyRow("stockStatus")) Then
                Dim statusBox As ComboBox = FindControlOfType(Of ComboBox)("stockStatus")
                If statusBox Is Nothing Then statusBox = FindControlOfType(Of ComboBox)("status")
                If statusBox IsNot Nothing Then
                    ' Populate dropdown first if empty
                    If statusBox.Items.Count = 0 Then
                        statusBox.Items.AddRange(New String() {"Available", "Low Stock", "Out of Stock"})
                    End If
                    Dim statusValue As String = supplyRow("stockStatus").ToString()
                    Dim statusIndex As Integer = statusBox.FindStringExact(statusValue)
                    If statusIndex >= 0 Then
                        statusBox.SelectedIndex = statusIndex
                    Else
                        statusBox.Text = statusValue
                    End If
                End If
            End If

            ' Get supplyId
            If supplyRow.Table.Columns.Contains("supplyId") AndAlso Not IsDBNull(supplyRow("supplyId")) Then
                If Me.Controls.Find("supplyID", True).Length > 0 Then
                    Dim supplyIDTxt As Control = Me.Controls.Find("supplyID", True)(0)
                    If TypeOf supplyIDTxt Is TextBox Then
                        CType(supplyIDTxt, TextBox).Text = supplyRow("supplyId").ToString()
                    ElseIf TypeOf supplyIDTxt Is Label Then
                        CType(supplyIDTxt, Label).Text = supplyRow("supplyId").ToString()
                    End If
                End If
            ElseIf supplyRow.Table.Columns.Contains("supply_id") AndAlso Not IsDBNull(supplyRow("supply_id")) Then
                If Me.Controls.Find("supplyID", True).Length > 0 Then
                    Dim supplyIDTxt As Control = Me.Controls.Find("supplyID", True)(0)
                    If TypeOf supplyIDTxt Is TextBox Then
                        CType(supplyIDTxt, TextBox).Text = supplyRow("supply_id").ToString()
                    ElseIf TypeOf supplyIDTxt Is Label Then
                        CType(supplyIDTxt, Label).Text = supplyRow("supply_id").ToString()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading supply data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] EditSupply.LoadSupplyData Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub EditSupply_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate dropdowns from database
        PopulateDropdowns()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Get all form values
            Dim supplyNameTxt As TextBox = FindControlOfType(Of TextBox)("supplyName")
            Dim categoryBox As ComboBox = FindControlOfType(Of ComboBox)("category")
            Dim quantityNud As NumericUpDown = FindControlOfType(Of NumericUpDown)("quantity")
            Dim unitCostNud As NumericUpDown = FindControlOfType(Of NumericUpDown)("unitCost")
            Dim totalCostNud As NumericUpDown = FindControlOfType(Of NumericUpDown)("totalCost")
            Dim statusBox As ComboBox = FindControlOfType(Of ComboBox)("stockStatus")
            If statusBox Is Nothing Then statusBox = FindControlOfType(Of ComboBox)("status")
            Dim locationBox As ComboBox = FindControlOfType(Of ComboBox)("location")
            Dim descriptionBox As ComboBox = FindControlOfType(Of ComboBox)("description")
            Dim supplierBox As ComboBox = FindControlOfType(Of ComboBox)("supplier")
            Dim uomBox As ComboBox = FindControlOfType(Of ComboBox)("unitOfMeasur")
            If uomBox Is Nothing Then uomBox = FindControlOfType(Of ComboBox)("ComboBox1")
            Dim sourceOfFundsTxt As TextBox = FindControlOfType(Of TextBox)("sourceOfFunds")
            Dim dateReceivedPicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("dateReceived")
            If dateReceivedPicker Is Nothing Then dateReceivedPicker = FindControlOfType(Of DateTimePicker)("DateTimePicker1")

            ' Validate required fields
            If supplyNameTxt Is Nothing OrElse String.IsNullOrWhiteSpace(supplyNameTxt.Text) Then
                MessageBox.Show("Item Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If categoryBox Is Nothing OrElse (categoryBox.SelectedIndex < 0 AndAlso String.IsNullOrWhiteSpace(categoryBox.Text)) Then
                MessageBox.Show("Please select or enter a Category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If quantityNud Is Nothing OrElse quantityNud.Value < 0 Then
                MessageBox.Show("Quantity must be 0 or greater.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If unitCostNud Is Nothing OrElse unitCostNud.Value < 0 Then
                MessageBox.Show("Unit Cost must be 0 or greater.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get values with fallbacks
            Dim supplyName As String = supplyNameTxt.Text.Trim()
            Dim category As String = If(categoryBox.SelectedIndex >= 0, categoryBox.SelectedItem.ToString(), categoryBox.Text.Trim())
            Dim stock As Integer = CInt(quantityNud.Value)
            Dim unitCost As Decimal = CDec(unitCostNud.Value)
            Dim totalValue As Decimal = If(totalCostNud IsNot Nothing, CDec(totalCostNud.Value), stock * unitCost)
            Dim status As String = If(statusBox IsNot Nothing AndAlso statusBox.SelectedIndex >= 0, statusBox.SelectedItem.ToString(), If(statusBox IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(statusBox.Text), statusBox.Text, "Available"))
            Dim location As String = If(locationBox IsNot Nothing AndAlso locationBox.SelectedIndex >= 0, locationBox.SelectedItem.ToString(), If(locationBox IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(locationBox.Text), locationBox.Text, ""))
            Dim description As String = If(descriptionBox IsNot Nothing AndAlso descriptionBox.SelectedIndex >= 0, descriptionBox.SelectedItem.ToString(), If(descriptionBox IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(descriptionBox.Text), descriptionBox.Text, ""))
            Dim supplierName As String = If(supplierBox IsNot Nothing AndAlso supplierBox.SelectedIndex >= 0, supplierBox.SelectedItem.ToString(), If(supplierBox IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(supplierBox.Text), supplierBox.Text, ""))
            Dim unitOfMeasureValue As String = If(uomBox IsNot Nothing AndAlso uomBox.SelectedIndex >= 0, uomBox.SelectedItem.ToString(), If(uomBox IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(uomBox.Text), uomBox.Text, ""))
            Dim sourceOfFundsValue As String = If(sourceOfFundsTxt IsNot Nothing, sourceOfFundsTxt.Text.Trim(), "")
            Dim dateReceivedValue As Date? = If(dateReceivedPicker IsNot Nothing, dateReceivedPicker.Value, Nothing)

            ' Call UpdateSupply with all parameters
            Dim success As Boolean = DatabaseConnection.UpdateSupply(
                currentSupplyID.ToString(),
                supplyName,
                category,
                stock,
                unitCost,
                status,
                location,
                description,
                0, ' reorderLevel
                supplierName,
                "", ' supplierContact
                unitOfMeasureValue,
                sourceOfFundsValue,
                dateReceivedValue
            )

            If success Then
                ' Navigate back to Supply Management list
                Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
                If parentDashboard IsNot Nothing Then
                    parentDashboard.LoadUserControl(New UC_SupplyManagement())
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] EditSupply.btnSave_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Navigate back to Supply Management
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_SupplyManagement())
        End If
    End Sub

    Private Sub PopulateDropdowns()
        Try
            ' Populate Category dropdown
            Dim categoryBox As ComboBox = FindControlOfType(Of ComboBox)("category")
            If categoryBox IsNot Nothing Then
                categoryBox.Items.Clear()
                Dim categories As DataTable = DatabaseConnection.GetCategories("supply")
                If categories IsNot Nothing AndAlso categories.Rows.Count > 0 Then
                    For Each row As DataRow In categories.Rows
                        Dim categoryName As String = ""
                        If row.Table.Columns.Contains("category_name") AndAlso Not IsDBNull(row("category_name")) Then
                            categoryName = row("category_name").ToString()
                        ElseIf row.Table.Columns.Contains("categoryName") AndAlso Not IsDBNull(row("categoryName")) Then
                            categoryName = row("categoryName").ToString()
                        ElseIf row.Table.Columns.Count > 0 AndAlso Not IsDBNull(row(0)) Then
                            categoryName = row(0).ToString()
                        End If
                        If Not String.IsNullOrEmpty(categoryName) AndAlso Not categoryBox.Items.Contains(categoryName) Then
                            categoryBox.Items.Add(categoryName)
                        End If
                    Next
                End If
            End If

            ' Populate Unit of Measure dropdown
            Dim uomBox As ComboBox = FindControlOfType(Of ComboBox)("unitOfMeasur")
            If uomBox Is Nothing Then uomBox = FindControlOfType(Of ComboBox)("ComboBox1")
            If uomBox IsNot Nothing Then
                uomBox.Items.Clear()
                uomBox.Items.AddRange(New String() {"Piece", "Box", "Ream", "Liter", "Kilogram", "Meter", "Set", "Unit", "Pack", "Bottle", "Can", "Roll"})
            End If

            ' Populate Supplier dropdown
            Dim supplierBox As ComboBox = FindControlOfType(Of ComboBox)("supplier")
            If supplierBox IsNot Nothing Then
                supplierBox.Items.Clear()
                Dim suppliers As DataTable = DatabaseConnection.GetSuppliers()
                If suppliers IsNot Nothing AndAlso suppliers.Rows.Count > 0 Then
                    For Each row As DataRow In suppliers.Rows
                        Dim supplierName As String = ""
                        If row.Table.Columns.Contains("supplier_name") AndAlso Not IsDBNull(row("supplier_name")) Then
                            supplierName = row("supplier_name").ToString()
                        ElseIf row.Table.Columns.Count > 0 AndAlso Not IsDBNull(row(0)) Then
                            supplierName = row(0).ToString()
                        End If
                        If Not String.IsNullOrEmpty(supplierName) AndAlso Not supplierBox.Items.Contains(supplierName) Then
                            supplierBox.Items.Add(supplierName)
                        End If
                    Next
                End If
            End If

            ' Populate Location dropdown
            Dim locationBox As ComboBox = FindControlOfType(Of ComboBox)("location")
            If locationBox IsNot Nothing Then
                locationBox.Items.Clear()
                Dim locations As DataTable = DatabaseConnection.GetLocations()
                If locations IsNot Nothing AndAlso locations.Rows.Count > 0 Then
                    For Each row As DataRow In locations.Rows
                        Dim locationName As String = ""
                        If row.Table.Columns.Contains("location_name") AndAlso Not IsDBNull(row("location_name")) Then
                            locationName = row("location_name").ToString()
                        ElseIf row.Table.Columns.Count > 0 AndAlso Not IsDBNull(row(0)) Then
                            locationName = row(0).ToString()
                        End If
                        If Not String.IsNullOrEmpty(locationName) AndAlso Not locationBox.Items.Contains(locationName) Then
                            locationBox.Items.Add(locationName)
                        End If
                    Next
                End If
            End If

            ' Populate Description dropdown (use common descriptions or get from database)
            Dim descBox As ComboBox = FindControlOfType(Of ComboBox)("description")
            If descBox IsNot Nothing Then
                descBox.Items.Clear()
                ' Get unique descriptions from supplies table
                Try
                    Dim conn = DatabaseConnection.GetConnection()
                    If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                        Dim query As String = "SELECT DISTINCT description FROM supplies WHERE description IS NOT NULL AND description != '' ORDER BY description LIMIT 50"
                        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(query, conn)
                            Using reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                                While reader.Read()
                                    Dim desc As String = reader("description").ToString()
                                    If Not String.IsNullOrEmpty(desc) AndAlso Not descBox.Items.Contains(desc) Then
                                        descBox.Items.Add(desc)
                                    End If
                                End While
                            End Using
                        End Using
                        conn.Close()
                    End If
                Catch
                    ' Fallback to common descriptions
                    descBox.Items.AddRange(New String() {"Office Supplies", "Cleaning Materials", "Medical Supplies", "IT Equipment", "Furniture", "Tools"})
                End Try
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] PopulateDropdowns Error: " & ex.Message)
        End Try
    End Sub

End Class
