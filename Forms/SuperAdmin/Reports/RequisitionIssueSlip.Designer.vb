Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RequisitionIssueSlip
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.entityName = New System.Windows.Forms.Label()
        Me.fundCluster = New System.Windows.Forms.Label()
        Me.requestId = New System.Windows.Forms.TextBox()
        Me.requesterName = New System.Windows.Forms.TextBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.departmentId = New System.Windows.Forms.TextBox()
        Me.position = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RoundedButton1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnCSV = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btn_Back = New System.Windows.Forms.Button()
        Me.Panel37 = New System.Windows.Forms.Panel()
        Me.lblPropertyCard = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.purpose = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.unit = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.quantityRequested = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.description = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.itemName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dateOfRequest = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.status = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.remarks = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel16.SuspendLayout()
        Me.Panel37.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'entityName
        '
        Me.entityName.AutoSize = True
        Me.entityName.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.entityName.Location = New System.Drawing.Point(151, 26)
        Me.entityName.Name = "entityName"
        Me.entityName.Size = New System.Drawing.Size(78, 22)
        Me.entityName.TabIndex = 38
        Me.entityName.Text = "Request ID:"
        Me.entityName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fundCluster
        '
        Me.fundCluster.AutoSize = True
        Me.fundCluster.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fundCluster.Location = New System.Drawing.Point(561, 25)
        Me.fundCluster.Name = "fundCluster"
        Me.fundCluster.Size = New System.Drawing.Size(115, 22)
        Me.fundCluster.TabIndex = 39
        Me.fundCluster.Text = "Requester Name:"
        Me.fundCluster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'requestId
        '
        Me.requestId.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requestId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.requestId.Location = New System.Drawing.Point(702, 23)
        Me.requestId.Name = "requestId"
        Me.requestId.Size = New System.Drawing.Size(253, 22)
        Me.requestId.TabIndex = 43
        '
        'requesterName
        '
        Me.requesterName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requesterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.requesterName.Location = New System.Drawing.Point(246, 25)
        Me.requesterName.Name = "requesterName"
        Me.requesterName.Size = New System.Drawing.Size(253, 22)
        Me.requesterName.TabIndex = 45
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.White
        Me.Panel16.Controls.Add(Me.Label1)
        Me.Panel16.Controls.Add(Me.departmentId)
        Me.Panel16.Controls.Add(Me.position)
        Me.Panel16.Controls.Add(Me.requesterName)
        Me.Panel16.Controls.Add(Me.fundCluster)
        Me.Panel16.Controls.Add(Me.Label2)
        Me.Panel16.Controls.Add(Me.requestId)
        Me.Panel16.Controls.Add(Me.entityName)
        Me.Panel16.Location = New System.Drawing.Point(164, 223)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(1209, 92)
        Me.Panel16.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(167, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 22)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Position:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'departmentId
        '
        Me.departmentId.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.departmentId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.departmentId.Location = New System.Drawing.Point(246, 53)
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Size = New System.Drawing.Size(253, 22)
        Me.departmentId.TabIndex = 46
        '
        'position
        '
        Me.position.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.position.Location = New System.Drawing.Point(702, 52)
        Me.position.Name = "position"
        Me.position.Size = New System.Drawing.Size(253, 22)
        Me.position.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(573, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 22)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Department ID:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RoundedButton1
        '
        Me.RoundedButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.CornerRadius = 15
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton1.Location = New System.Drawing.Point(1205, 874)
        Me.RoundedButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(153, 34)
        Me.RoundedButton1.TabIndex = 368
        Me.RoundedButton1.Text = "Generate PDF File"
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'btnCSV
        '
        Me.btnCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCSV.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnCSV.CornerRadius = 15
        Me.btnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCSV.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnCSV.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCSV.Location = New System.Drawing.Point(1044, 874)
        Me.btnCSV.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCSV.Name = "btnCSV"
        Me.btnCSV.Size = New System.Drawing.Size(153, 34)
        Me.btnCSV.TabIndex = 367
        Me.btnCSV.Text = "Generate CSV File"
        Me.btnCSV.UseVisualStyleBackColor = False
        '
        'btn_Back
        '
        Me.btn_Back.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Back.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Back.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btn_Back.ForeColor = System.Drawing.Color.White
        Me.btn_Back.Location = New System.Drawing.Point(901, 874)
        Me.btn_Back.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Back.Name = "btn_Back"
        Me.btn_Back.Size = New System.Drawing.Size(112, 34)
        Me.btn_Back.TabIndex = 366
        Me.btn_Back.Text = "Back"
        Me.btn_Back.UseVisualStyleBackColor = False
        '
        'Panel37
        '
        Me.Panel37.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel37.BackColor = System.Drawing.Color.White
        Me.Panel37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel37.Controls.Add(Me.lblPropertyCard)
        Me.Panel37.Location = New System.Drawing.Point(164, 160)
        Me.Panel37.Name = "Panel37"
        Me.Panel37.Size = New System.Drawing.Size(1209, 64)
        Me.Panel37.TabIndex = 369
        '
        'lblPropertyCard
        '
        Me.lblPropertyCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPropertyCard.AutoSize = True
        Me.lblPropertyCard.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCard.Location = New System.Drawing.Point(416, 15)
        Me.lblPropertyCard.Name = "lblPropertyCard"
        Me.lblPropertyCard.Size = New System.Drawing.Size(366, 44)
        Me.lblPropertyCard.TabIndex = 38
        Me.lblPropertyCard.Text = "REQUISITION AND ISSUE SLIP"
        Me.lblPropertyCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.purpose)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.unit)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.quantityRequested)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.description)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.itemName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.dateOfRequest)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(164, 312)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1209, 322)
        Me.Panel1.TabIndex = 370
        '
        'purpose
        '
        Me.purpose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.purpose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.purpose.Location = New System.Drawing.Point(445, 167)
        Me.purpose.Name = "purpose"
        Me.purpose.Size = New System.Drawing.Size(307, 22)
        Me.purpose.TabIndex = 58
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(316, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 22)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Purpose:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'unit
        '
        Me.unit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.unit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.unit.Location = New System.Drawing.Point(445, 124)
        Me.unit.Name = "unit"
        Me.unit.Size = New System.Drawing.Size(307, 22)
        Me.unit.TabIndex = 56
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(315, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 22)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Unit: "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'quantityRequested
        '
        Me.quantityRequested.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.quantityRequested.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.quantityRequested.Location = New System.Drawing.Point(445, 253)
        Me.quantityRequested.Name = "quantityRequested"
        Me.quantityRequested.Size = New System.Drawing.Size(307, 22)
        Me.quantityRequested.TabIndex = 54
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(305, 255)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 22)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Quantity Requested:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'description
        '
        Me.description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.description.Location = New System.Drawing.Point(445, 82)
        Me.description.Name = "description"
        Me.description.Size = New System.Drawing.Size(307, 22)
        Me.description.TabIndex = 52
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(316, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 22)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "Description:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'itemName
        '
        Me.itemName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.itemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.itemName.Location = New System.Drawing.Point(445, 39)
        Me.itemName.Name = "itemName"
        Me.itemName.Size = New System.Drawing.Size(307, 22)
        Me.itemName.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(317, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 22)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Item Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dateOfRequest
        '
        Me.dateOfRequest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dateOfRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dateOfRequest.Location = New System.Drawing.Point(445, 211)
        Me.dateOfRequest.Name = "dateOfRequest"
        Me.dateOfRequest.Size = New System.Drawing.Size(307, 22)
        Me.dateOfRequest.TabIndex = 48
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(317, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 22)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Date of Request:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'status
        '
        Me.status.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.status.Location = New System.Drawing.Point(150, 23)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(214, 22)
        Me.status.TabIndex = 60
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(34, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 22)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Status:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'remarks
        '
        Me.remarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.remarks.Location = New System.Drawing.Point(150, 103)
        Me.remarks.Name = "remarks"
        Me.remarks.Size = New System.Drawing.Size(214, 22)
        Me.remarks.TabIndex = 66
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(34, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 22)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Remarks:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(150, 66)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(214, 22)
        Me.TextBox2.TabIndex = 64
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(34, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 22)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Approved Date:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Location = New System.Drawing.Point(150, 144)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(214, 22)
        Me.TextBox3.TabIndex = 62
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(34, 143)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 22)
        Me.Label15.TabIndex = 61
        Me.Label15.Text = "Approved By:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TextBox2)
        Me.Panel3.Controls.Add(Me.remarks)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.status)
        Me.Panel3.Controls.Add(Me.TextBox3)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Location = New System.Drawing.Point(164, 630)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1209, 205)
        Me.Panel3.TabIndex = 372
        '
        'RequisitionIssueSlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1569, 942)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel37)
        Me.Controls.Add(Me.RoundedButton1)
        Me.Controls.Add(Me.btnCSV)
        Me.Controls.Add(Me.btn_Back)
        Me.Controls.Add(Me.Panel16)
        Me.Name = "RequisitionIssueSlip"
        Me.Text = "RequisitionIssueSlip"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel37.ResumeLayout(False)
        Me.Panel37.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents entityName As Label
    Friend WithEvents fundCluster As Label
    Friend WithEvents requestId As TextBox
    Friend WithEvents requesterName As TextBox
    Friend WithEvents Panel16 As Panel
    Friend WithEvents RoundedButton1 As Resources.Controls.RoundedButton
    Friend WithEvents btnCSV As Resources.Controls.RoundedButton
    Friend WithEvents btn_Back As Button
    Friend WithEvents Panel37 As Panel
    Friend WithEvents lblPropertyCard As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents departmentId As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents position As TextBox
    Friend WithEvents unit As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents quantityRequested As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents description As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents itemName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dateOfRequest As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents remarks As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents status As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents purpose As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel3 As Panel
End Class
