Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class SupplyInventory
    Inherits System.Windows.Forms.UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub SupplyInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSupplyData()
    End Sub

    Private Sub LoadSupplyData()
        Try
            ' Load all available supplies from database
            Dim dt As DataTable = DatabaseConnection.GetAllSupplies()
            
            ' Clear existing data
            propertyManagementGrid.Rows.Clear()
            
            ' Populate DataGridView
            For Each row As DataRow In dt.Rows
                Dim supplyID As String = ""
                Dim itemName As String = ""
                Dim category As String = ""
                Dim description As String = ""
                Dim unitOfMeasure As String = ""
                Dim quantity As String = "0"
                Dim location As String = ""
                Dim stockStatus As String = ""
                
                ' Handle different possible column names
                If dt.Columns.Contains("SupplyID") Then
                    supplyID = If(IsDBNull(row("SupplyID")), "", row("SupplyID").ToString())
                ElseIf dt.Columns.Contains("supply_id") Then
                    supplyID = If(IsDBNull(row("supply_id")), "", row("supply_id").ToString())
                End If
                
                If dt.Columns.Contains("SupplyName") Then
                    itemName = If(IsDBNull(row("SupplyName")), "", row("SupplyName").ToString())
                ElseIf dt.Columns.Contains("item_name") Then
                    itemName = If(IsDBNull(row("item_name")), "", row("item_name").ToString())
                End If
                
                If dt.Columns.Contains("Category") Then
                    category = If(IsDBNull(row("Category")), "", row("Category").ToString())
                ElseIf dt.Columns.Contains("category") Then
                    category = If(IsDBNull(row("category")), "", row("category").ToString())
                End If
                
                If dt.Columns.Contains("Description") Then
                    description = If(IsDBNull(row("Description")), "", row("Description").ToString())
                ElseIf dt.Columns.Contains("description") Then
                    description = If(IsDBNull(row("description")), "", row("description").ToString())
                End If
                
                If dt.Columns.Contains("UnitOfMeasure") Then
                    unitOfMeasure = If(IsDBNull(row("UnitOfMeasure")), "", row("UnitOfMeasure").ToString())
                ElseIf dt.Columns.Contains("unit_of_measure") Then
                    unitOfMeasure = If(IsDBNull(row("unit_of_measure")), "", row("unit_of_measure").ToString())
                End If
                
                If dt.Columns.Contains("QuantityInStock") Then
                    quantity = If(IsDBNull(row("QuantityInStock")), "0", row("QuantityInStock").ToString())
                ElseIf dt.Columns.Contains("quantity") Then
                    quantity = If(IsDBNull(row("quantity")), "0", row("quantity").ToString())
                End If
                
                If dt.Columns.Contains("Location") Then
                    location = If(IsDBNull(row("Location")), "", row("Location").ToString())
                ElseIf dt.Columns.Contains("location") Then
                    location = If(IsDBNull(row("location")), "", row("location").ToString())
                End If
                
                If dt.Columns.Contains("Status") Then
                    stockStatus = If(IsDBNull(row("Status")), "", row("Status").ToString())
                ElseIf dt.Columns.Contains("stock_status") Then
                    stockStatus = If(IsDBNull(row("stock_status")), "", row("stock_status").ToString())
                End If
                
                propertyManagementGrid.Rows.Add(supplyID, itemName, category, description, unitOfMeasure, quantity, location, stockStatus)
            Next
            
            ' Auto-size columns
            propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            MessageBox.Show("Error loading supply data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnrequestsupply_Click(sender As Object, e As System.EventArgs)
        Dim addRequest As New AddSupplyRequest()
        addRequest.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addRequest)
    End Sub

    Private Sub btnrequestsupply_Click_1(sender As Object, e As System.EventArgs) Handles btnrequestsupply.Click
        Dim addSupplyInventory As New AddSupplyRequest()

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addSupplyInventory)
    End Sub

End Class
