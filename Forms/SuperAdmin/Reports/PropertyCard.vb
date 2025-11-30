Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class PropertyCard
    Inherits Form

    Private propertyData As DataRow

    ' Constructor receives property details
    Public Sub New(row As DataRow)
        InitializeComponent()
        propertyData = row
    End Sub

    Private Sub PropertyCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Property Card"
        Me.Size = New Size(500, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog

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

        AddLabel(panelCard, "Property ID: " & propertyData("property_id").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Property Name: " & propertyData("property_name").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Category: " & propertyData("category").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Serial Number: " & propertyData("serial_number").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Supplier: " & propertyData("supplier_name").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Condition: " & propertyData("condition_status").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Acquisition Cost: " & propertyData("acquisition_cost").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Acquisition Date: " & propertyData("acquisition_date").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Warranty: " & propertyData("warranty_details").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Assigned Employee: " & propertyData("assigned_employee").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Assigned Department: " & propertyData("assigned_department").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Location: " & propertyData("location").ToString(), yPos) : yPos += spacing
        AddLabel(panelCard, "Status: " & propertyData("status").ToString(), yPos) : yPos += spacing
    End Sub

    Private Sub AddLabel(parent As Control, text As String, y As Integer)
        Dim lbl As New Label()
        lbl.Text = text
        lbl.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lbl.Location = New Point(20, y)
        lbl.AutoSize = True
        parent.Controls.Add(lbl)
    End Sub

End Class
