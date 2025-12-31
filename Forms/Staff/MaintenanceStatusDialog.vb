Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic

''' <summary>
''' Dialog to view detailed maintenance status and progress for borrowed items
''' Shows maintenance details, parts replaced, diagnosis, actions taken, and costs
''' </summary>
Public Class MaintenanceStatusDialog
    Inherits Form

    Private lblTitle As Label
    Private lblItemName As Label
    Private lblSerialNumber As Label
    Private lblStatus As Label
    Private lblStatusValue As Label
    Private lblTechnician As Label
    Private lblTechnicianValue As Label
    Private lblMaintenanceDate As Label
    Private lblMaintenanceDateValue As Label
    Private lblConditionBefore As Label
    Private lblConditionBeforeValue As Label
    Private lblConditionAfter As Label
    Private lblConditionAfterValue As Label
    Private lblType As Label
    Private lblTypeValue As Label
    Private lblCost As Label
    Private lblCostValue As Label
    
    Private grpDiagnosis As GroupBox
    Private txtDiagnosis As TextBox
    
    Private grpActionTaken As GroupBox
    Private txtActionTaken As TextBox
    
    Private grpPartsReplaced As GroupBox
    Private txtPartsReplaced As TextBox
    
    Private grpDetails As GroupBox
    Private txtDetails As TextBox
    
    Private btnClose As Button
    
    Private maintenanceData As DataRow
    
    Public Sub New(maintenanceRecord As DataRow)
        InitializeComponent()
        maintenanceData = maintenanceRecord
        LoadMaintenanceData()
    End Sub
    
    Private Sub InitializeComponent()
        ' Form settings
        Me.Text = "Maintenance Status & Details"
        Me.Size = New Size(900, 750)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(245, 247, 250)
        Me.Font = New Font("Segoe UI", 9)
        
        ' Title Label
        lblTitle = New Label()
        lblTitle.Text = "🔧 Maintenance Status & Details"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(52, 73, 94)
        lblTitle.Location = New Point(20, 20)
        lblTitle.AutoSize = True
        Me.Controls.Add(lblTitle)
        
        ' Item Name
        lblItemName = New Label()
        lblItemName.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblItemName.ForeColor = Color.FromArgb(41, 128, 185)
        lblItemName.Location = New Point(20, 60)
        lblItemName.Size = New Size(850, 30)
        Me.Controls.Add(lblItemName)
        
        ' Serial Number
        lblSerialNumber = New Label()
        lblSerialNumber.Font = New Font("Segoe UI", 10)
        lblSerialNumber.ForeColor = Color.Gray
        lblSerialNumber.Location = New Point(20, 90)
        lblSerialNumber.Size = New Size(850, 25)
        Me.Controls.Add(lblSerialNumber)
        
        ' Status Panel
        Dim pnlStatus As New Panel()
        pnlStatus.BackColor = Color.White
        pnlStatus.Location = New Point(20, 125)
        pnlStatus.Size = New Size(850, 140)
        pnlStatus.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(pnlStatus)
        
        ' Status Label and Value
        lblStatus = New Label()
        lblStatus.Text = "Status:"
        lblStatus.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblStatus.Location = New Point(15, 15)
        lblStatus.AutoSize = True
        pnlStatus.Controls.Add(lblStatus)
        
        lblStatusValue = New Label()
        lblStatusValue.Font = New Font("Segoe UI", 10)
        lblStatusValue.Location = New Point(150, 15)
        lblStatusValue.Size = New Size(680, 25)
        pnlStatus.Controls.Add(lblStatusValue)
        
        ' Technician
        lblTechnician = New Label()
        lblTechnician.Text = "Assigned To:"
        lblTechnician.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblTechnician.Location = New Point(15, 45)
        lblTechnician.AutoSize = True
        pnlStatus.Controls.Add(lblTechnician)
        
        lblTechnicianValue = New Label()
        lblTechnicianValue.Font = New Font("Segoe UI", 10)
        lblTechnicianValue.Location = New Point(150, 45)
        lblTechnicianValue.Size = New Size(300, 25)
        pnlStatus.Controls.Add(lblTechnicianValue)
        
        ' Maintenance Date
        lblMaintenanceDate = New Label()
        lblMaintenanceDate.Text = "Date:"
        lblMaintenanceDate.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblMaintenanceDate.Location = New Point(460, 45)
        lblMaintenanceDate.AutoSize = True
        pnlStatus.Controls.Add(lblMaintenanceDate)
        
        lblMaintenanceDateValue = New Label()
        lblMaintenanceDateValue.Font = New Font("Segoe UI", 10)
        lblMaintenanceDateValue.Location = New Point(520, 45)
        lblMaintenanceDateValue.Size = New Size(310, 25)
        pnlStatus.Controls.Add(lblMaintenanceDateValue)
        
        ' Type
        lblType = New Label()
        lblType.Text = "Type:"
        lblType.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblType.Location = New Point(15, 75)
        lblType.AutoSize = True
        pnlStatus.Controls.Add(lblType)
        
        lblTypeValue = New Label()
        lblTypeValue.Font = New Font("Segoe UI", 10)
        lblTypeValue.Location = New Point(150, 75)
        lblTypeValue.Size = New Size(300, 25)
        pnlStatus.Controls.Add(lblTypeValue)
        
        ' Cost
        lblCost = New Label()
        lblCost.Text = "Cost:"
        lblCost.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblCost.Location = New Point(460, 75)
        lblCost.AutoSize = True
        pnlStatus.Controls.Add(lblCost)
        
        lblCostValue = New Label()
        lblCostValue.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblCostValue.ForeColor = Color.FromArgb(231, 76, 60)
        lblCostValue.Location = New Point(520, 75)
        lblCostValue.Size = New Size(310, 25)
        pnlStatus.Controls.Add(lblCostValue)
        
        ' Condition Before
        lblConditionBefore = New Label()
        lblConditionBefore.Text = "Condition Before:"
        lblConditionBefore.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblConditionBefore.Location = New Point(15, 105)
        lblConditionBefore.AutoSize = True
        pnlStatus.Controls.Add(lblConditionBefore)
        
        lblConditionBeforeValue = New Label()
        lblConditionBeforeValue.Font = New Font("Segoe UI", 10)
        lblConditionBeforeValue.Location = New Point(150, 105)
        lblConditionBeforeValue.Size = New Size(300, 25)
        pnlStatus.Controls.Add(lblConditionBeforeValue)
        
        ' Condition After
        lblConditionAfter = New Label()
        lblConditionAfter.Text = "Condition After:"
        lblConditionAfter.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblConditionAfter.Location = New Point(460, 105)
        lblConditionAfter.AutoSize = True
        pnlStatus.Controls.Add(lblConditionAfter)
        
        lblConditionAfterValue = New Label()
        lblConditionAfterValue.Font = New Font("Segoe UI", 10)
        lblConditionAfterValue.Location = New Point(580, 105)
        lblConditionAfterValue.Size = New Size(250, 25)
        pnlStatus.Controls.Add(lblConditionAfterValue)
        
        ' Diagnosis GroupBox
        grpDiagnosis = New GroupBox()
        grpDiagnosis.Text = "Diagnosis"
        grpDiagnosis.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        grpDiagnosis.Location = New Point(20, 280)
        grpDiagnosis.Size = New Size(850, 80)
        Me.Controls.Add(grpDiagnosis)
        
        txtDiagnosis = New TextBox()
        txtDiagnosis.Multiline = True
        txtDiagnosis.ScrollBars = ScrollBars.Vertical
        txtDiagnosis.ReadOnly = True
        txtDiagnosis.Location = New Point(10, 25)
        txtDiagnosis.Size = New Size(830, 45)
        txtDiagnosis.Font = New Font("Segoe UI", 9)
        grpDiagnosis.Controls.Add(txtDiagnosis)
        
        ' Action Taken GroupBox
        grpActionTaken = New GroupBox()
        grpActionTaken.Text = "Action Taken"
        grpActionTaken.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        grpActionTaken.Location = New Point(20, 370)
        grpActionTaken.Size = New Size(850, 80)
        Me.Controls.Add(grpActionTaken)
        
        txtActionTaken = New TextBox()
        txtActionTaken.Multiline = True
        txtActionTaken.ScrollBars = ScrollBars.Vertical
        txtActionTaken.ReadOnly = True
        txtActionTaken.Location = New Point(10, 25)
        txtActionTaken.Size = New Size(830, 45)
        txtActionTaken.Font = New Font("Segoe UI", 9)
        grpActionTaken.Controls.Add(txtActionTaken)
        
        ' Parts Replaced GroupBox
        grpPartsReplaced = New GroupBox()
        grpPartsReplaced.Text = "Parts Replaced"
        grpPartsReplaced.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        grpPartsReplaced.Location = New Point(20, 460)
        grpPartsReplaced.Size = New Size(850, 80)
        Me.Controls.Add(grpPartsReplaced)
        
        txtPartsReplaced = New TextBox()
        txtPartsReplaced.Multiline = True
        txtPartsReplaced.ScrollBars = ScrollBars.Vertical
        txtPartsReplaced.ReadOnly = True
        txtPartsReplaced.Location = New Point(10, 25)
        txtPartsReplaced.Size = New Size(830, 45)
        txtPartsReplaced.Font = New Font("Segoe UI", 9)
        grpPartsReplaced.Controls.Add(txtPartsReplaced)
        
        ' Details GroupBox
        grpDetails = New GroupBox()
        grpDetails.Text = "Additional Details"
        grpDetails.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        grpDetails.Location = New Point(20, 550)
        grpDetails.Size = New Size(850, 90)
        Me.Controls.Add(grpDetails)
        
        txtDetails = New TextBox()
        txtDetails.Multiline = True
        txtDetails.ScrollBars = ScrollBars.Vertical
        txtDetails.ReadOnly = True
        txtDetails.Location = New Point(10, 25)
        txtDetails.Size = New Size(830, 55)
        txtDetails.Font = New Font("Segoe UI", 9)
        grpDetails.Controls.Add(txtDetails)
        
        ' Close Button
        btnClose = New Button()
        btnClose.Text = "Close"
        btnClose.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnClose.Size = New Size(150, 45)
        btnClose.Location = New Point(720, 655)
        btnClose.BackColor = Color.FromArgb(52, 73, 94)
        btnClose.ForeColor = Color.White
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.Cursor = Cursors.Hand
        btnClose.DialogResult = DialogResult.OK
        AddHandler btnClose.Click, AddressOf BtnClose_Click
        AddHandler btnClose.MouseEnter, Sub() btnClose.BackColor = Color.FromArgb(44, 62, 80)
        AddHandler btnClose.MouseLeave, Sub() btnClose.BackColor = Color.FromArgb(52, 73, 94)
        Me.Controls.Add(btnClose)
    End Sub
    
    Private Sub LoadMaintenanceData()
        Try
            ' Item Name
            lblItemName.Text = "Item: " & If(IsDBNull(maintenanceData("propertyItemName")), "N/A", maintenanceData("propertyItemName").ToString())
            
            ' Serial Number
            lblSerialNumber.Text = "Serial Number: " & If(IsDBNull(maintenanceData("serialNumber")), "N/A", maintenanceData("serialNumber").ToString())
            
            ' Status
            Dim status As String = If(IsDBNull(maintenanceData("status")), "Unknown", maintenanceData("status").ToString())
            lblStatusValue.Text = status
            Select Case status
                Case "Ongoing"
                    lblStatusValue.ForeColor = Color.FromArgb(230, 126, 34) ' Orange
                    lblStatusValue.Text = "🔄 " & status
                Case "Completed"
                    lblStatusValue.ForeColor = Color.FromArgb(46, 204, 113) ' Green
                    lblStatusValue.Text = "✅ " & status
                Case "For Review"
                    lblStatusValue.ForeColor = Color.FromArgb(52, 152, 219) ' Blue
                    lblStatusValue.Text = "📋 " & status
                Case Else
                    lblStatusValue.ForeColor = Color.Gray
            End Select
            
            ' Technician
            lblTechnicianValue.Text = If(IsDBNull(maintenanceData("assignedTechnician")), "Not assigned", maintenanceData("assignedTechnician").ToString())
            
            ' Maintenance Date
            If Not IsDBNull(maintenanceData("maintenanceDate")) Then
                lblMaintenanceDateValue.Text = CDate(maintenanceData("maintenanceDate")).ToString("MMMM dd, yyyy")
            Else
                lblMaintenanceDateValue.Text = "Not scheduled"
            End If
            
            ' Type
            lblTypeValue.Text = If(IsDBNull(maintenanceData("typeOfMaintenance")), "N/A", maintenanceData("typeOfMaintenance").ToString())
            
            ' Cost
            If Not IsDBNull(maintenanceData("costMaterialsLabor")) Then
                Dim cost As Decimal = CDec(maintenanceData("costMaterialsLabor"))
                lblCostValue.Text = "₱" & cost.ToString("N2")
            Else
                lblCostValue.Text = "₱0.00"
            End If
            
            ' Condition Before
            lblConditionBeforeValue.Text = If(IsDBNull(maintenanceData("conditionBeforeMaint")), "N/A", maintenanceData("conditionBeforeMaint").ToString())
            
            ' Condition After
            If Not IsDBNull(maintenanceData("conditionAfterMaint")) Then
                lblConditionAfterValue.Text = maintenanceData("conditionAfterMaint").ToString()
            Else
                lblConditionAfterValue.Text = "Pending completion"
            End If
            
            ' Diagnosis
            If Not IsDBNull(maintenanceData("diagnosis")) AndAlso Not String.IsNullOrWhiteSpace(maintenanceData("diagnosis").ToString()) Then
                txtDiagnosis.Text = maintenanceData("diagnosis").ToString()
            Else
                txtDiagnosis.Text = "No diagnosis recorded yet."
                txtDiagnosis.ForeColor = Color.Gray
            End If
            
            ' Action Taken
            If Not IsDBNull(maintenanceData("actionTaken")) AndAlso Not String.IsNullOrWhiteSpace(maintenanceData("actionTaken").ToString()) Then
                txtActionTaken.Text = maintenanceData("actionTaken").ToString()
            Else
                txtActionTaken.Text = "No actions recorded yet."
                txtActionTaken.ForeColor = Color.Gray
            End If
            
            ' Parts Replaced
            If Not IsDBNull(maintenanceData("partsReplaced")) AndAlso Not String.IsNullOrWhiteSpace(maintenanceData("partsReplaced").ToString()) Then
                txtPartsReplaced.Text = maintenanceData("partsReplaced").ToString()
            Else
                txtPartsReplaced.Text = "No parts replaced."
                txtPartsReplaced.ForeColor = Color.Gray
            End If
            
            ' Additional Details
            If Not IsDBNull(maintenanceData("maintenanceDetails")) AndAlso Not String.IsNullOrWhiteSpace(maintenanceData("maintenanceDetails").ToString()) Then
                txtDetails.Text = maintenanceData("maintenanceDetails").ToString()
            Else
                txtDetails.Text = "No additional details provided."
                txtDetails.ForeColor = Color.Gray
            End If
            
        Catch ex As Exception
            MessageBox.Show("Error loading maintenance data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub BtnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class
