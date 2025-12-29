Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PropertyCard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblPropertyCard = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.pcEntityName = New System.Windows.Forms.TextBox()
        Me.entityName = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.pcFundCluster = New System.Windows.Forms.TextBox()
        Me.fundCluster = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.pcDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcReference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcQuantity1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcQuantity3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcOfficer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcQuantity2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pcPropertyNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.pcDescription = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pcPropertyPlant = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.RoundedButton1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnCSV = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btn_Back = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPropertyCard
        '
        Me.lblPropertyCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPropertyCard.AutoSize = True
        Me.lblPropertyCard.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCard.Location = New System.Drawing.Point(499, 52)
        Me.lblPropertyCard.Name = "lblPropertyCard"
        Me.lblPropertyCard.Size = New System.Drawing.Size(200, 44)
        Me.lblPropertyCard.TabIndex = 37
        Me.lblPropertyCard.Text = "Property Card"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Panel16)
        Me.Panel1.Controls.Add(Me.Panel15)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(159, 111)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(897, 534)
        Me.Panel1.TabIndex = 52
        '
        'Panel16
        '
        Me.Panel16.Controls.Add(Me.pcEntityName)
        Me.Panel16.Controls.Add(Me.entityName)
        Me.Panel16.Location = New System.Drawing.Point(32, 12)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(550, 29)
        Me.Panel16.TabIndex = 55
        '
        'pcEntityName
        '
        Me.pcEntityName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcEntityName.Location = New System.Drawing.Point(97, 3)
        Me.pcEntityName.Name = "pcEntityName"
        Me.pcEntityName.Size = New System.Drawing.Size(446, 22)
        Me.pcEntityName.TabIndex = 43
        '
        'entityName
        '
        Me.entityName.AutoSize = True
        Me.entityName.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.entityName.Location = New System.Drawing.Point(3, 5)
        Me.entityName.Name = "entityName"
        Me.entityName.Size = New System.Drawing.Size(87, 22)
        Me.entityName.TabIndex = 38
        Me.entityName.Text = "Entity Name:"
        Me.entityName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel15
        '
        Me.Panel15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel15.Controls.Add(Me.pcFundCluster)
        Me.Panel15.Controls.Add(Me.fundCluster)
        Me.Panel15.Location = New System.Drawing.Point(581, 12)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(289, 29)
        Me.Panel15.TabIndex = 54
        '
        'pcFundCluster
        '
        Me.pcFundCluster.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcFundCluster.Location = New System.Drawing.Point(104, 3)
        Me.pcFundCluster.Name = "pcFundCluster"
        Me.pcFundCluster.Size = New System.Drawing.Size(178, 22)
        Me.pcFundCluster.TabIndex = 45
        '
        'fundCluster
        '
        Me.fundCluster.AutoSize = True
        Me.fundCluster.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fundCluster.Location = New System.Drawing.Point(2, 4)
        Me.fundCluster.Name = "fundCluster"
        Me.fundCluster.Size = New System.Drawing.Size(87, 22)
        Me.fundCluster.TabIndex = 39
        Me.fundCluster.Text = "Fund Cluster"
        Me.fundCluster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel10)
        Me.Panel2.Location = New System.Drawing.Point(32, 42)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(838, 483)
        Me.Panel2.TabIndex = 53
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Location = New System.Drawing.Point(548, 77)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(142, 45)
        Me.Panel4.TabIndex = 59
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(43, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 22)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Amount"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel9
        '
        Me.Panel9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.Label9)
        Me.Panel9.Location = New System.Drawing.Point(689, 77)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(148, 45)
        Me.Panel9.TabIndex = 58
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(39, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 22)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Remarks"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcDate, Me.pcReference, Me.pcQuantity1, Me.pcQuantity3, Me.pcOfficer, Me.pcQuantity2, Me.pcAmount, Me.pcRemarks})
        Me.DataGridView1.Location = New System.Drawing.Point(-1, 121)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(838, 354)
        Me.DataGridView1.TabIndex = 57
        '
        'pcDate
        '
        Me.pcDate.HeaderText = "Date"
        Me.pcDate.MinimumWidth = 6
        Me.pcDate.Name = "pcDate"
        Me.pcDate.Width = 70
        '
        'pcReference
        '
        Me.pcReference.HeaderText = "Reference"
        Me.pcReference.MinimumWidth = 6
        Me.pcReference.Name = "pcReference"
        Me.pcReference.Width = 85
        '
        'pcQuantity1
        '
        Me.pcQuantity1.HeaderText = "Qty."
        Me.pcQuantity1.MinimumWidth = 6
        Me.pcQuantity1.Name = "pcQuantity1"
        Me.pcQuantity1.Width = 75
        '
        'pcQuantity3
        '
        Me.pcQuantity3.HeaderText = "Qty."
        Me.pcQuantity3.MinimumWidth = 6
        Me.pcQuantity3.Name = "pcQuantity3"
        Me.pcQuantity3.Width = 50
        '
        'pcOfficer
        '
        Me.pcOfficer.HeaderText = "Office/Officer"
        Me.pcOfficer.MinimumWidth = 6
        Me.pcOfficer.Name = "pcOfficer"
        Me.pcOfficer.Width = 135
        '
        'pcQuantity2
        '
        Me.pcQuantity2.HeaderText = "Qty."
        Me.pcQuantity2.MinimumWidth = 6
        Me.pcQuantity2.Name = "pcQuantity2"
        Me.pcQuantity2.Width = 83
        '
        'pcAmount
        '
        Me.pcAmount.HeaderText = "Amount"
        Me.pcAmount.MinimumWidth = 6
        Me.pcAmount.Name = "pcAmount"
        Me.pcAmount.Width = 150
        '
        'pcRemarks
        '
        Me.pcRemarks.HeaderText = "Remarks"
        Me.pcRemarks.MinimumWidth = 6
        Me.pcRemarks.Name = "pcRemarks"
        Me.pcRemarks.Width = 135
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.Label8)
        Me.Panel8.Location = New System.Drawing.Point(464, 77)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(85, 45)
        Me.Panel8.TabIndex = 56
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 22)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Balance"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Location = New System.Drawing.Point(278, 77)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(188, 45)
        Me.Panel6.TabIndex = 55
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 22)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Issue/Transfer/Disposal"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Location = New System.Drawing.Point(204, 77)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(75, 45)
        Me.Panel7.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 22)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Receipt"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Location = New System.Drawing.Point(113, 77)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(92, 45)
        Me.Panel5.TabIndex = 53
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 44)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Reference/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PAR No.:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.pcPropertyNumber)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(548, -1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(289, 79)
        Me.Panel3.TabIndex = 51
        '
        'pcPropertyNumber
        '
        Me.pcPropertyNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcPropertyNumber.Location = New System.Drawing.Point(124, 30)
        Me.pcPropertyNumber.Name = "pcPropertyNumber"
        Me.pcPropertyNumber.Size = New System.Drawing.Size(157, 22)
        Me.pcPropertyNumber.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 22)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Property Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.pcDescription)
        Me.Panel10.Controls.Add(Me.Label3)
        Me.Panel10.Controls.Add(Me.pcPropertyPlant)
        Me.Panel10.Controls.Add(Me.Label1)
        Me.Panel10.Location = New System.Drawing.Point(-1, -1)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(550, 79)
        Me.Panel10.TabIndex = 50
        '
        'pcDescription
        '
        Me.pcDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcDescription.Location = New System.Drawing.Point(194, 30)
        Me.pcDescription.Multiline = True
        Me.pcDescription.Name = "pcDescription"
        Me.pcDescription.Size = New System.Drawing.Size(347, 41)
        Me.pcDescription.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 22)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Description:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcPropertyPlant
        '
        Me.pcPropertyPlant.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcPropertyPlant.Location = New System.Drawing.Point(194, 3)
        Me.pcPropertyPlant.Name = "pcPropertyPlant"
        Me.pcPropertyPlant.Size = New System.Drawing.Size(347, 22)
        Me.pcPropertyPlant.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 22)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Property, Plant, Equipment:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.Location = New System.Drawing.Point(159, 44)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(897, 61)
        Me.Panel11.TabIndex = 53
        '
        'RoundedButton1
        '
        Me.RoundedButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.CornerRadius = 15
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton1.Location = New System.Drawing.Point(903, 665)
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
        Me.btnCSV.Location = New System.Drawing.Point(742, 665)
        Me.btnCSV.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCSV.Name = "btnCSV"
        Me.btnCSV.Size = New System.Drawing.Size(153, 34)
        Me.btnCSV.TabIndex = 367
        Me.btnCSV.Text = "Generate CSV File"
        Me.btnCSV.UseVisualStyleBackColor = False
        '
        'btn_Back
        '
        Me.btn_Back.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Back.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btn_Back.ForeColor = System.Drawing.Color.White
        Me.btn_Back.Location = New System.Drawing.Point(622, 665)
        Me.btn_Back.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Back.Name = "btn_Back"
        Me.btn_Back.Size = New System.Drawing.Size(112, 34)
        Me.btn_Back.TabIndex = 366
        Me.btn_Back.Text = "Back"
        Me.btn_Back.UseVisualStyleBackColor = False
        '
        'PropertyCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1212, 799)
        Me.Controls.Add(Me.RoundedButton1)
        Me.Controls.Add(Me.btnCSV)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_Back)
        Me.Controls.Add(Me.lblPropertyCard)
        Me.Controls.Add(Me.Panel11)
        Me.Name = "PropertyCard"
        Me.Text = "PropertyCard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPropertyCard As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents pcEntityName As TextBox
    Friend WithEvents entityName As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents pcFundCluster As TextBox
    Friend WithEvents fundCluster As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents pcDate As DataGridViewTextBoxColumn
    Friend WithEvents pcReference As DataGridViewTextBoxColumn
    Friend WithEvents pcQuantity1 As DataGridViewTextBoxColumn
    Friend WithEvents pcQuantity3 As DataGridViewTextBoxColumn
    Friend WithEvents pcOfficer As DataGridViewTextBoxColumn
    Friend WithEvents pcQuantity2 As DataGridViewTextBoxColumn
    Friend WithEvents pcAmount As DataGridViewTextBoxColumn
    Friend WithEvents pcRemarks As DataGridViewTextBoxColumn
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pcPropertyNumber As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents pcDescription As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pcPropertyPlant As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents RoundedButton1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnCSV As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btn_Back As Button
End Class
