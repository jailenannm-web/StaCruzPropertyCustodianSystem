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
            
            ' Clear existing data
            propertyManagementGrid.Rows.Clear()
            
            ' Populate DataGridView
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
                    If dt.Columns.Contains("property_number") Then
                        propertyNo = If(IsDBNull(row("property_number")), "", row("property_number").ToString())
                    End If
                    If dt.Columns.Contains("item_name") Then
                        itemName = If(IsDBNull(row("item_name")), "", row("item_name").ToString())
                    End If
                    If dt.Columns.Contains("category") Then
                        category = If(IsDBNull(row("category")), "", row("category").ToString())
                    End If
                    ' Description might not be in the query result
                    If dt.Columns.Contains("description") Then
                        description = If(IsDBNull(row("description")), "", row("description").ToString())
                    End If
                    If dt.Columns.Contains("location") Then
                        location = If(IsDBNull(row("location")), "", row("location").ToString())
                    End If
                    If dt.Columns.Contains("assigned_department") Then
                        department = If(IsDBNull(row("assigned_department")), "", row("assigned_department").ToString())
                    End If
                    If dt.Columns.Contains("condition") Then
                        condition = If(IsDBNull(row("condition")), "", row("condition").ToString())
                    End If
                    If dt.Columns.Contains("status") Then
                        status = If(IsDBNull(row("status")), "", row("status").ToString())
                    End If
                Catch colEx As Exception
                    ' Handle column access errors gracefully
                    System.Diagnostics.Debug.WriteLine("Column access error: " & colEx.Message)
                End Try
                
                Dim quantity As Integer = 1 ' Properties are typically 1 per item
                
                propertyManagementGrid.Rows.Add(propertyNo, itemName, category, description, location, department, condition, status, quantity)
            Next
            
            ' Auto-size columns
            propertyManagementGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            MessageBox.Show("Error loading property data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Dim addPropertyInventory As New AddPropertyRequest()

        ' Clear previous controls
        Me.Controls.Clear()

        ' Add new user control
        Me.Controls.Add(addPropertyInventory)
    End Sub
End Class
