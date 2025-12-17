Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports Microsoft.VisualBasic

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
                Dim categoryBox As ComboBox = FindControlOfType(Of ComboBox)("categoryCmbo")
                If categoryBox IsNot Nothing Then
                    categoryBox.Text = supplyRow("category").ToString()
                    ' Try to select the category in the combo box
                    Dim categoryIndex As Integer = categoryBox.FindStringExact(supplyRow("category").ToString())
                    If categoryIndex >= 0 Then
                        categoryBox.SelectedIndex = categoryIndex
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
                Dim uomBox As ComboBox = FindControlOfType(Of ComboBox)("ComboBox1")
                If uomBox IsNot Nothing Then uomBox.Text = supplyRow("unitOfMeasure").ToString()
            ElseIf supplyRow.Table.Columns.Contains("unit_of_measure") AndAlso Not IsDBNull(supplyRow("unit_of_measure")) Then
                Dim uomBox As ComboBox = FindControlOfType(Of ComboBox)("ComboBox1")
                If uomBox IsNot Nothing Then uomBox.Text = supplyRow("unit_of_measure").ToString()
            End If

            If supplyRow.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(supplyRow("supplier")) Then
                Dim supplier As TextBox = FindControlOfType(Of TextBox)("supplierTxt")
                If supplier IsNot Nothing Then supplier.Text = supplyRow("supplier").ToString()
            End If

            If supplyRow.Table.Columns.Contains("description") AndAlso Not IsDBNull(supplyRow("description")) Then
                Dim remarks As TextBox = FindControlOfType(Of TextBox)("remarksTxt")
                If remarks IsNot Nothing Then remarks.Text = supplyRow("description").ToString()
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

            ' Get totalCost
            Dim totalCostValue As Decimal = 0
            If supplyRow.Table.Columns.Contains("totalCost") AndAlso Not IsDBNull(supplyRow("totalCost")) Then
                Decimal.TryParse(supplyRow("totalCost").ToString(), totalCostValue)
            ElseIf supplyRow.Table.Columns.Contains("total_cost") AndAlso Not IsDBNull(supplyRow("total_cost")) Then
                Decimal.TryParse(supplyRow("total_cost").ToString(), totalCostValue)
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
                Dim locationTxt As TextBox = FindControlOfType(Of TextBox)("TextBox2")
                If locationTxt IsNot Nothing Then
                    locationTxt.Text = supplyRow("location").ToString()
                End If
            End If

            ' Get dateReceived
            If supplyRow.Table.Columns.Contains("dateReceived") AndAlso Not IsDBNull(supplyRow("dateReceived")) Then
                Dim dateValue As Date
                If Date.TryParse(supplyRow("dateReceived").ToString(), dateValue) Then
                    Dim datePicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("DateTimePicker1")
                    If datePicker IsNot Nothing Then
                        datePicker.Value = dateValue
                    End If
                End If
            ElseIf supplyRow.Table.Columns.Contains("date_received") AndAlso Not IsDBNull(supplyRow("date_received")) Then
                Dim dateValue As Date
                If Date.TryParse(supplyRow("date_received").ToString(), dateValue) Then
                    Dim datePicker As DateTimePicker = FindControlOfType(Of DateTimePicker)("DateTimePicker1")
                    If datePicker IsNot Nothing Then
                        datePicker.Value = dateValue
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
        ' Optional initialization
    End Sub

End Class
