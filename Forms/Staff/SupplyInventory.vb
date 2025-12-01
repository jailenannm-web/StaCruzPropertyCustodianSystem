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
            
            If dt Is Nothing Then
                MessageBox.Show("Unable to connect to the database. Please ensure MySQL is running and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Clear existing data
            propertyManagementGrid.Rows.Clear()
            
            ' Populate DataGridView
            If dt.Rows.Count > 0 Then
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
                    If dt.Columns.Contains("supply_id") AndAlso Not IsDBNull(row("supply_id")) Then
                        supplyID = row("supply_id").ToString()
                    ElseIf dt.Columns.Contains("SupplyID") AndAlso Not IsDBNull(row("SupplyID")) Then
                        supplyID = row("SupplyID").ToString()
                    End If
                    
                    If dt.Columns.Contains("item_name") AndAlso Not IsDBNull(row("item_name")) Then
                        itemName = row("item_name").ToString()
                    ElseIf dt.Columns.Contains("SupplyName") AndAlso Not IsDBNull(row("SupplyName")) Then
                        itemName = row("SupplyName").ToString()
                    End If
                    
                    If dt.Columns.Contains("category") AndAlso Not IsDBNull(row("category")) Then
                        category = row("category").ToString()
                    ElseIf dt.Columns.Contains("Category") AndAlso Not IsDBNull(row("Category")) Then
                        category = row("Category").ToString()
                    End If
                    
                    If dt.Columns.Contains("description") AndAlso Not IsDBNull(row("description")) Then
                        description = row("description").ToString()
                    ElseIf dt.Columns.Contains("Description") AndAlso Not IsDBNull(row("Description")) Then
                        description = row("Description").ToString()
                    End If
                    
                    If dt.Columns.Contains("unit_of_measure") AndAlso Not IsDBNull(row("unit_of_measure")) Then
                        unitOfMeasure = row("unit_of_measure").ToString()
                    ElseIf dt.Columns.Contains("UnitOfMeasure") AndAlso Not IsDBNull(row("UnitOfMeasure")) Then
                        unitOfMeasure = row("UnitOfMeasure").ToString()
                    End If
                    
                    ' Fix quantity display - check multiple possible column names
                    If dt.Columns.Contains("quantity") AndAlso Not IsDBNull(row("quantity")) Then
                        quantity = row("quantity").ToString()
                    ElseIf dt.Columns.Contains("QuantityInStock") AndAlso Not IsDBNull(row("QuantityInStock")) Then
                        quantity = row("QuantityInStock").ToString()
                    ElseIf dt.Columns.Contains("quantity_available") AndAlso Not IsDBNull(row("quantity_available")) Then
                        quantity = row("quantity_available").ToString()
                    End If
                    
                    If dt.Columns.Contains("location") AndAlso Not IsDBNull(row("location")) Then
                        location = row("location").ToString()
                    ElseIf dt.Columns.Contains("Location") AndAlso Not IsDBNull(row("Location")) Then
                        location = row("Location").ToString()
                    End If
                    
                    If dt.Columns.Contains("stock_status") AndAlso Not IsDBNull(row("stock_status")) Then
                        stockStatus = row("stock_status").ToString()
                    ElseIf dt.Columns.Contains("Status") AndAlso Not IsDBNull(row("Status")) Then
                        stockStatus = row("Status").ToString()
                    End If
                    
                    propertyManagementGrid.Rows.Add(supplyID, itemName, category, description, unitOfMeasure, quantity, location, stockStatus)
                Next
            End If
            
            ' Auto-size columns
            propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            Dim errorMsg As String = "Unable to connect to the database. Please ensure MySQL is running and try again."
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            System.Diagnostics.Debug.WriteLine("SupplyInventory LoadSupplyData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
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
        ' Load AddSupplyRequest into parent dashboard
        Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddSupplyRequest())
        Else
            ' Fallback: add directly to parent
            Dim addSupplyRequest As New AddSupplyRequest()
            addSupplyRequest.Dock = DockStyle.Fill
            Me.Parent.Controls.Clear()
            Me.Parent.Controls.Add(addSupplyRequest)
        End If
    End Sub
    
    Private Sub propertyManagementGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellClick
        ' Auto-fill supply request form when clicking a row
        If e.RowIndex >= 0 AndAlso e.RowIndex < propertyManagementGrid.Rows.Count Then
            Try
                Dim selectedRow As DataGridViewRow = propertyManagementGrid.Rows(e.RowIndex)
                Dim itemName As String = ""
                
                ' Try to get item name from different possible column names
                ' Column order: supplyID (0), itemName (1), category (2), description (3), unitOfMeasure (4), quantity (5), location (6), stockStatus (7)
                If selectedRow.Cells.Count > 1 Then
                    ' Try to get from column by name first
                    If propertyManagementGrid.Columns.Contains("Item Name") Then
                        Dim cell As DataGridViewCell = selectedRow.Cells("Item Name")
                        If cell IsNot Nothing AndAlso cell.Value IsNot Nothing Then
                            itemName = cell.Value.ToString()
                        End If
                    ElseIf propertyManagementGrid.Columns.Contains("item_name") Then
                        Dim cell As DataGridViewCell = selectedRow.Cells("item_name")
                        If cell IsNot Nothing AndAlso cell.Value IsNot Nothing Then
                            itemName = cell.Value.ToString()
                        End If
                    ElseIf selectedRow.Cells.Count > 1 Then
                        ' Try second column (index 1) which is usually item name
                        If selectedRow.Cells(1).Value IsNot Nothing Then
                            itemName = selectedRow.Cells(1).Value.ToString()
                        End If
                    End If
                End If
                
                ' Navigate to request form with pre-filled item name
                If Not String.IsNullOrEmpty(itemName) Then
                    Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
                    If parentDashboard IsNot Nothing Then
                        Dim requestForm As New AddSupplyRequest(itemName)
                        parentDashboard.LoadUserControl(requestForm)
                    End If
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("SupplyInventory CellClick Error: " & ex.Message)
            End Try
        End If
    End Sub

End Class
