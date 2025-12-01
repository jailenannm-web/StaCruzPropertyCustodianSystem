Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class PropertyCard
    Inherits Form

    Private propertyData As DataRow
    Private ReadOnly propertyID As Integer

    ' Constructor receives property details
    Public Sub New(row As DataRow)
        InitializeComponent()
        propertyData = row

        If propertyData IsNot Nothing AndAlso propertyData.Table IsNot Nothing AndAlso propertyData.Table.Columns.Contains("property_id") Then
            Integer.TryParse(Convert.ToString(propertyData("property_id")), propertyID)
        End If
    End Sub

    Private Sub PropertyCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Property Card"
        Me.Size = New Size(500, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog

        EnsureFullPropertyData()

        ' Create panel for card
        Dim panelCard As New Panel()
        panelCard.Dock = DockStyle.Fill
        panelCard.Padding = New Padding(20)
        panelCard.BackColor = Color.White
        Me.Controls.Add(panelCard)

        ' Title
        Dim lblTitle As New Label()
        lblTitle.Text = "PROPERTY CARD"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.AutoSize = False
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        lblTitle.Dock = DockStyle.Top
        lblTitle.Height = 40
        panelCard.Controls.Add(lblTitle)

        ' Create details labels
        Dim yPos As Integer = 60
        Dim spacing As Integer = 30

        AddLabel(panelCard, "Property ID: " & GetFieldValue("property_id"), yPos) : yPos += spacing
        AddLabel(panelCard, "Property Name: " & GetFieldValue("item_name", "property_name"), yPos) : yPos += spacing
        AddLabel(panelCard, "Category: " & GetFieldValue("category"), yPos) : yPos += spacing
        AddLabel(panelCard, "Serial Number: " & GetFieldValue("serial_number"), yPos) : yPos += spacing
        AddLabel(panelCard, "Supplier: " & GetFieldValue("supplier_name"), yPos) : yPos += spacing
        AddLabel(panelCard, "Condition: " & GetFieldValue("condition_status", "condition"), yPos) : yPos += spacing
        AddLabel(panelCard, "Acquisition Cost: " & GetFieldValue("acquisition_cost"), yPos) : yPos += spacing
        AddLabel(panelCard, "Acquisition Date: " & GetFieldValue("acquisition_date"), yPos) : yPos += spacing
        AddLabel(panelCard, "Warranty: " & GetFieldValue("warranty_details"), yPos) : yPos += spacing
        AddLabel(panelCard, "Assigned Employee: " & GetFieldValue("assigned_employee"), yPos) : yPos += spacing
        AddLabel(panelCard, "Assigned Department: " & GetFieldValue("assigned_department"), yPos) : yPos += spacing
        AddLabel(panelCard, "Location: " & GetFieldValue("location"), yPos) : yPos += spacing
        AddLabel(panelCard, "Status: " & GetFieldValue("status"), yPos) : yPos += spacing
    End Sub

    Private Sub EnsureFullPropertyData()
        If propertyData Is Nothing Then
            MessageBox.Show("Property details are unavailable.", "Property Card", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim needsRefresh As Boolean =
            Not HasColumn("supplier_name") OrElse
            Not HasColumn("assigned_employee") OrElse
            Not HasColumn("assigned_department") OrElse
            Not HasColumn("warranty_details")

        If needsRefresh AndAlso propertyID > 0 Then
            Dim detailedRow As DataRow = DatabaseConnection.GetPropertyDetails(propertyID)
            If detailedRow IsNot Nothing Then
                propertyData = detailedRow
            End If
        End If
    End Sub

    Private Function HasColumn(columnName As String) As Boolean
        Return propertyData IsNot Nothing AndAlso propertyData.Table IsNot Nothing AndAlso propertyData.Table.Columns.Contains(columnName)
    End Function

    Private Function GetFieldValue(ParamArray names() As String) As String
        If propertyData Is Nothing Then Return ""
        For Each fieldName As String In names
            If HasColumn(fieldName) Then
                If Convert.IsDBNull(propertyData(fieldName)) Then
                    Return ""
                End If
                Return propertyData(fieldName).ToString()
            End If
        Next
        Return ""
    End Function

    Private Sub AddLabel(parent As Control, text As String, y As Integer)
        Dim lbl As New Label()
        lbl.Text = text
        lbl.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lbl.Location = New Point(20, y)
        lbl.AutoSize = True
        parent.Controls.Add(lbl)
    End Sub

End Class
