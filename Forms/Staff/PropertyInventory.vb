Imports System
Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class PropertyInventory
    Inherits System.Windows.Forms.UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub PropertyInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPropertyData()
    End Sub

    Private Sub LoadPropertyData()
        Try
            ' Load all available properties from database
            Dim dt As DataTable = DatabaseConnection.GetAllProperties()
            
            If dt Is Nothing Then
                MessageBox.Show("Unable to connect to the database. Please ensure MySQL is running and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Clear existing data
            propertyManagementGrid.Rows.Clear()
            
            ' Populate DataGridView
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim propertyNo As String = ""
                    Dim itemName As String = ""
                    Dim category As String = ""
                    Dim description As String = ""
                    Dim location As String = ""
                    Dim department As String = ""
                    Dim condition As String = ""
                    Dim status As String = ""
                    
                    ' Handle different possible column names
                    Try
                        If dt.Columns.Contains("property_number") AndAlso Not IsDBNull(row("property_number")) Then
                            propertyNo = row("property_number").ToString()
                        ElseIf dt.Columns.Contains("property_id") AndAlso Not IsDBNull(row("property_id")) Then
                            propertyNo = row("property_id").ToString()
                        End If
                        If dt.Columns.Contains("item_name") AndAlso Not IsDBNull(row("item_name")) Then
                            itemName = row("item_name").ToString()
                        End If
                        If dt.Columns.Contains("category") AndAlso Not IsDBNull(row("category")) Then
                            category = row("category").ToString()
                        End If
                        If dt.Columns.Contains("description") AndAlso Not IsDBNull(row("description")) Then
                            description = row("description").ToString()
                        End If
                        If dt.Columns.Contains("location") AndAlso Not IsDBNull(row("location")) Then
                            location = row("location").ToString()
                        End If
                        If dt.Columns.Contains("assigned_department") AndAlso Not IsDBNull(row("assigned_department")) Then
                            department = row("assigned_department").ToString()
                        End If
                        If dt.Columns.Contains("condition") AndAlso Not IsDBNull(row("condition")) Then
                            condition = row("condition").ToString()
                        End If
                        If dt.Columns.Contains("status") AndAlso Not IsDBNull(row("status")) Then
                            status = row("status").ToString()
                        End If
                    Catch colEx As Exception
                        ' Handle column access errors gracefully
                        System.Diagnostics.Debug.WriteLine("Column access error: " & colEx.Message)
                    End Try
                    
                    Dim quantity As Integer = 1 ' Properties are typically 1 per item
                    
                    propertyManagementGrid.Rows.Add(propertyNo, itemName, category, description, location, department, condition, status, quantity)
                Next
            End If
            
            ' Auto-size columns
            propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            Dim errorMsg As String = "Unable to connect to the database. Please ensure MySQL is running and try again."
            MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            System.Diagnostics.Debug.WriteLine("PropertyInventory LoadPropertyData Error: " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnrequestproperty_Click(sender As Object, e As System.EventArgs)
        Dim addRequest As New AddPropertyRequest()
        addRequest.Dock = DockStyle.Fill

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addRequest)
    End Sub

    Private Sub btnrequestproperty_Click_1(sender As Object, e As System.EventArgs) Handles btnrequestproperty.Click
        ' Load AddPropertyRequest into parent dashboard
        Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New AddPropertyRequest())
        Else
            ' Fallback: add directly to parent
            Dim addPropertyRequest As New AddPropertyRequest()
            addPropertyRequest.Dock = DockStyle.Fill
            Me.Parent.Controls.Clear()
            Me.Parent.Controls.Add(addPropertyRequest)
        End If
    End Sub
    
    Private Sub propertyManagementGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles propertyManagementGrid.CellClick
        ' Auto-fill property request form when clicking a row
        If e.RowIndex >= 0 AndAlso e.RowIndex < propertyManagementGrid.Rows.Count Then
            Try
                Dim selectedRow As DataGridViewRow = propertyManagementGrid.Rows(e.RowIndex)
                Dim itemName As String = ""
                
                ' Try to get item name from different possible column names
                ' Column order: propertyNo (0), itemName (1), category (2), description (3), location (4), department (5), condition (6), status (7), quantity (8)
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
                        Dim requestForm As New AddPropertyRequest(itemName)
                        parentDashboard.LoadUserControl(requestForm)
                    End If
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("PropertyInventory CellClick Error: " & ex.Message)
            End Try
        End If
    End Sub
End Class
