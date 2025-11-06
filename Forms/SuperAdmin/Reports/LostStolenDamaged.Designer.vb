Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LostStolenDamaged
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
        Me.propertyCard = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.pcEntityName = New System.Windows.Forms.TextBox()
        Me.entityName = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.pcFundCluster = New System.Windows.Forms.TextBox()
        Me.fundCluster = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pcPropertyPlant = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.loststolen_chkboxYes = New System.Windows.Forms.CheckBox()
        Me.loststolen_chkboxNo = New System.Windows.Forms.CheckBox()
        Me.pcPoliceStation = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pcDatepicker = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pcRLSDDPNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pcRLSDDPDate = New System.Windows.Forms.Label()
        Me.pcRLSDDPDatepicker = New System.Windows.Forms.DateTimePicker()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.pcPARNo = New System.Windows.Forms.Label()
        Me.pcPARDatepicker = New System.Windows.Forms.TextBox()
        Me.pcPARDate = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pcStolen = New System.Windows.Forms.CheckBox()
        Me.pcLost = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pcDestroyed = New System.Windows.Forms.CheckBox()
        Me.pcDamaged = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.propertyNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcAcquisitionCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pcCircumstances = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel16.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'propertyCard
        '
        Me.propertyCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyCard.AutoSize = True
        Me.propertyCard.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propertyCard.Location = New System.Drawing.Point(219, 29)
        Me.propertyCard.Name = "propertyCard"
        Me.propertyCard.Size = New System.Drawing.Size(804, 44)
        Me.propertyCard.TabIndex = 38
        Me.propertyCard.Text = "REPORT OF LOST, STOLEN, DAMAGED, OR DESTROYED PROPERTY" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel16
        '
        Me.Panel16.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel16.Controls.Add(Me.pcEntityName)
        Me.Panel16.Controls.Add(Me.entityName)
        Me.Panel16.Location = New System.Drawing.Point(201, 85)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(550, 31)
        Me.Panel16.TabIndex = 51
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
        Me.Panel15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel15.Controls.Add(Me.pcFundCluster)
        Me.Panel15.Controls.Add(Me.fundCluster)
        Me.Panel15.Location = New System.Drawing.Point(750, 85)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(289, 438)
        Me.Panel15.TabIndex = 50
        '
        'pcFundCluster
        '
        Me.pcFundCluster.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcFundCluster.Location = New System.Drawing.Point(104, 3)
        Me.pcFundCluster.Name = "pcFundCluster"
        Me.pcFundCluster.Size = New System.Drawing.Size(181, 22)
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
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.TextBox13)
        Me.Panel1.Controls.Add(Me.TextBox12)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.TextBox10)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.TextBox11)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.TextBox9)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.TextBox8)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(201, 115)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(838, 907)
        Me.Panel1.TabIndex = 52
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.pcDatepicker)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.pcPoliceStation)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.loststolen_chkboxNo)
        Me.Panel2.Controls.Add(Me.loststolen_chkboxYes)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.pcPropertyPlant)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(-1, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(550, 155)
        Me.Panel2.TabIndex = 51
        '
        'pcPropertyPlant
        '
        Me.pcPropertyPlant.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcPropertyPlant.Location = New System.Drawing.Point(182, 3)
        Me.pcPropertyPlant.Name = "pcPropertyPlant"
        Me.pcPropertyPlant.Size = New System.Drawing.Size(359, 22)
        Me.pcPropertyPlant.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 22)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Department/Office:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(183, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(359, 22)
        Me.TextBox1.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 22)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Accountable Office:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Location = New System.Drawing.Point(183, 51)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(359, 22)
        Me.TextBox2.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 22)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Designation:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(225, 22)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Police Notified (check if applicable):"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'loststolen_chkboxYes
        '
        Me.loststolen_chkboxYes.AutoSize = True
        Me.loststolen_chkboxYes.Location = New System.Drawing.Point(117, 99)
        Me.loststolen_chkboxYes.Name = "loststolen_chkboxYes"
        Me.loststolen_chkboxYes.Size = New System.Drawing.Size(53, 20)
        Me.loststolen_chkboxYes.TabIndex = 53
        Me.loststolen_chkboxYes.Text = "Yes"
        Me.loststolen_chkboxYes.UseVisualStyleBackColor = True
        '
        'loststolen_chkboxNo
        '
        Me.loststolen_chkboxNo.AutoSize = True
        Me.loststolen_chkboxNo.Location = New System.Drawing.Point(117, 125)
        Me.loststolen_chkboxNo.Name = "loststolen_chkboxNo"
        Me.loststolen_chkboxNo.Size = New System.Drawing.Size(47, 20)
        Me.loststolen_chkboxNo.TabIndex = 54
        Me.loststolen_chkboxNo.Text = "No"
        Me.loststolen_chkboxNo.UseVisualStyleBackColor = False
        '
        'pcPoliceStation
        '
        Me.pcPoliceStation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcPoliceStation.Location = New System.Drawing.Point(333, 97)
        Me.pcPoliceStation.Name = "pcPoliceStation"
        Me.pcPoliceStation.Size = New System.Drawing.Size(208, 22)
        Me.pcPoliceStation.TabIndex = 56
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(232, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 22)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Police Station:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(232, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 22)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Date:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcDatepicker
        '
        Me.pcDatepicker.Location = New System.Drawing.Point(333, 123)
        Me.pcDatepicker.Name = "pcDatepicker"
        Me.pcDatepicker.Size = New System.Drawing.Size(208, 22)
        Me.pcDatepicker.TabIndex = 58
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.pcPARDatepicker)
        Me.Panel3.Controls.Add(Me.pcPARDate)
        Me.Panel3.Controls.Add(Me.TextBox3)
        Me.Panel3.Controls.Add(Me.pcPARNo)
        Me.Panel3.Controls.Add(Me.pcRLSDDPDatepicker)
        Me.Panel3.Controls.Add(Me.pcRLSDDPDate)
        Me.Panel3.Controls.Add(Me.pcRLSDDPNo)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(548, -1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(289, 155)
        Me.Panel3.TabIndex = 52
        '
        'pcRLSDDPNo
        '
        Me.pcRLSDDPNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcRLSDDPNo.Location = New System.Drawing.Point(103, 5)
        Me.pcRLSDDPNo.Name = "pcRLSDDPNo"
        Me.pcRLSDDPNo.Size = New System.Drawing.Size(181, 22)
        Me.pcRLSDDPNo.TabIndex = 45
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(2, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 22)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "RLSDDP No.:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcRLSDDPDate
        '
        Me.pcRLSDDPDate.AutoSize = True
        Me.pcRLSDDPDate.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pcRLSDDPDate.Location = New System.Drawing.Point(2, 36)
        Me.pcRLSDDPDate.Name = "pcRLSDDPDate"
        Me.pcRLSDDPDate.Size = New System.Drawing.Size(91, 22)
        Me.pcRLSDDPDate.TabIndex = 46
        Me.pcRLSDDPDate.Text = "RLSDDP Date:"
        Me.pcRLSDDPDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcRLSDDPDatepicker
        '
        Me.pcRLSDDPDatepicker.Location = New System.Drawing.Point(103, 36)
        Me.pcRLSDDPDatepicker.Name = "pcRLSDDPDatepicker"
        Me.pcRLSDDPDatepicker.Size = New System.Drawing.Size(181, 22)
        Me.pcRLSDDPDatepicker.TabIndex = 59
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.Location = New System.Drawing.Point(103, 64)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(181, 22)
        Me.TextBox3.TabIndex = 61
        '
        'pcPARNo
        '
        Me.pcPARNo.AutoSize = True
        Me.pcPARNo.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pcPARNo.Location = New System.Drawing.Point(3, 66)
        Me.pcPARNo.Name = "pcPARNo"
        Me.pcPARNo.Size = New System.Drawing.Size(60, 22)
        Me.pcPARNo.TabIndex = 60
        Me.pcPARNo.Text = "PAR No.:"
        Me.pcPARNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcPARDatepicker
        '
        Me.pcPARDatepicker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcPARDatepicker.Location = New System.Drawing.Point(103, 92)
        Me.pcPARDatepicker.Name = "pcPARDatepicker"
        Me.pcPARDatepicker.Size = New System.Drawing.Size(181, 22)
        Me.pcPARDatepicker.TabIndex = 63
        '
        'pcPARDate
        '
        Me.pcPARDate.AutoSize = True
        Me.pcPARDate.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pcPARDate.Location = New System.Drawing.Point(3, 94)
        Me.pcPARDate.Name = "pcPARDate"
        Me.pcPARDate.Size = New System.Drawing.Size(69, 22)
        Me.pcPARDate.TabIndex = 62
        Me.pcPARDate.Text = "PAR Date:"
        Me.pcPARDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.pcDestroyed)
        Me.Panel4.Controls.Add(Me.pcDamaged)
        Me.Panel4.Controls.Add(Me.pcStolen)
        Me.Panel4.Controls.Add(Me.pcLost)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Location = New System.Drawing.Point(-1, 153)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(838, 83)
        Me.Panel4.TabIndex = 53
        '
        'pcStolen
        '
        Me.pcStolen.AutoSize = True
        Me.pcStolen.Location = New System.Drawing.Point(117, 45)
        Me.pcStolen.Name = "pcStolen"
        Me.pcStolen.Size = New System.Drawing.Size(67, 20)
        Me.pcStolen.TabIndex = 57
        Me.pcStolen.Text = "Stolen"
        Me.pcStolen.UseVisualStyleBackColor = False
        '
        'pcLost
        '
        Me.pcLost.AutoSize = True
        Me.pcLost.Location = New System.Drawing.Point(117, 25)
        Me.pcLost.Name = "pcLost"
        Me.pcLost.Size = New System.Drawing.Size(54, 20)
        Me.pcLost.TabIndex = 56
        Me.pcLost.Text = "Lost"
        Me.pcLost.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(225, 22)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "Police Notified (check if applicable):"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcDestroyed
        '
        Me.pcDestroyed.AutoSize = True
        Me.pcDestroyed.Location = New System.Drawing.Point(236, 45)
        Me.pcDestroyed.Name = "pcDestroyed"
        Me.pcDestroyed.Size = New System.Drawing.Size(92, 20)
        Me.pcDestroyed.TabIndex = 59
        Me.pcDestroyed.Text = "Destroyed"
        Me.pcDestroyed.UseVisualStyleBackColor = False
        '
        'pcDamaged
        '
        Me.pcDamaged.AutoSize = True
        Me.pcDamaged.Location = New System.Drawing.Point(236, 25)
        Me.pcDamaged.Name = "pcDamaged"
        Me.pcDamaged.Size = New System.Drawing.Size(90, 20)
        Me.pcDamaged.TabIndex = 58
        Me.pcDamaged.Text = "Damaged"
        Me.pcDamaged.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.propertyNo, Me.pcDescription, Me.pcAcquisitionCost})
        Me.DataGridView1.Location = New System.Drawing.Point(-1, 238)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(838, 142)
        Me.DataGridView1.TabIndex = 54
        '
        'propertyNo
        '
        Me.propertyNo.HeaderText = "Property No."
        Me.propertyNo.MinimumWidth = 6
        Me.propertyNo.Name = "propertyNo"
        Me.propertyNo.Width = 255
        '
        'pcDescription
        '
        Me.pcDescription.HeaderText = "Description"
        Me.pcDescription.MinimumWidth = 6
        Me.pcDescription.Name = "pcDescription"
        Me.pcDescription.Width = 275
        '
        'pcAcquisitionCost
        '
        Me.pcAcquisitionCost.HeaderText = "Acquisition Cost"
        Me.pcAcquisitionCost.MinimumWidth = 6
        Me.pcAcquisitionCost.Name = "pcAcquisitionCost"
        Me.pcAcquisitionCost.Width = 255
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.pcCircumstances)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Location = New System.Drawing.Point(-1, 384)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(838, 104)
        Me.Panel5.TabIndex = 55
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 22)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "Circumstances"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcCircumstances
        '
        Me.pcCircumstances.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcCircumstances.Location = New System.Drawing.Point(25, 36)
        Me.pcCircumstances.Multiline = True
        Me.pcCircumstances.Name = "pcCircumstances"
        Me.pcCircumstances.Size = New System.Drawing.Size(786, 58)
        Me.pcCircumstances.TabIndex = 57
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.TextBox5)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.DateTimePicker1)
        Me.Panel6.Controls.Add(Me.DateTimePicker2)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Controls.Add(Me.TextBox6)
        Me.Panel6.Controls.Add(Me.TextBox4)
        Me.Panel6.Controls.Add(Me.Label15)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Location = New System.Drawing.Point(-1, 487)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(494, 252)
        Me.Panel6.TabIndex = 59
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.Location = New System.Drawing.Point(73, 55)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(341, 22)
        Me.TextBox4.TabIndex = 60
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(363, 44)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "I hereby certify that the item/s and circumstances stated " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "above are true and co" &
    "rrect."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(71, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(343, 22)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "Signature over Printer Name of the Accountable Officer"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(145, 114)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(181, 22)
        Me.DateTimePicker1.TabIndex = 62
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(217, 139)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 22)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Date"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.Location = New System.Drawing.Point(182, 194)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(181, 22)
        Me.TextBox5.TabIndex = 67
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 223)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 22)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Date Issued:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(182, 220)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(181, 22)
        Me.DateTimePicker2.TabIndex = 65
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 195)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 22)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "ID No.:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox6.Location = New System.Drawing.Point(182, 170)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(181, 22)
        Me.TextBox6.TabIndex = 63
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 170)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(148, 22)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "Government Issued ID:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Label18)
        Me.Panel7.Controls.Add(Me.DateTimePicker3)
        Me.Panel7.Controls.Add(Me.Label17)
        Me.Panel7.Controls.Add(Me.TextBox7)
        Me.Panel7.Controls.Add(Me.Label16)
        Me.Panel7.Location = New System.Drawing.Point(492, 487)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(345, 252)
        Me.Panel7.TabIndex = 60
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 22)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "Noted by:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(59, 99)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(223, 44)
        Me.Label17.TabIndex = 63
        Me.Label17.Text = "Signature over Printer Name of the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Immediate Supervisor"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox7.Location = New System.Drawing.Point(33, 73)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(272, 22)
        Me.TextBox7.TabIndex = 62
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(151, 198)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 22)
        Me.Label18.TabIndex = 65
        Me.Label18.Text = "Date"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Location = New System.Drawing.Point(79, 173)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(181, 22)
        Me.DateTimePicker3.TabIndex = 64
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(21, 750)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(262, 22)
        Me.Label19.TabIndex = 61
        Me.Label19.Text = "SUBSCRIBE AND SWORN to before me this " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox8
        '
        Me.TextBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox8.Location = New System.Drawing.Point(282, 748)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(39, 22)
        Me.TextBox8.TabIndex = 64
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(323, 750)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 22)
        Me.Label20.TabIndex = 65
        Me.Label20.Text = "day of"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox9
        '
        Me.TextBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox9.Location = New System.Drawing.Point(375, 748)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(74, 22)
        Me.TextBox9.TabIndex = 66
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(452, 750)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(304, 22)
        Me.Label21.TabIndex = 67
        Me.Label21.Text = ", affiant exhibiting the above government issued"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(21, 772)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(121, 22)
        Me.Label22.TabIndex = 68
        Me.Label22.Text = "identification card"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox10
        '
        Me.TextBox10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox10.Location = New System.Drawing.Point(182, 823)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(181, 22)
        Me.TextBox10.TabIndex = 73
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(16, 846)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 22)
        Me.Label23.TabIndex = 72
        Me.Label23.Text = "Stock No.:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(16, 821)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(66, 22)
        Me.Label24.TabIndex = 71
        Me.Label24.Text = "Page No.:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox11
        '
        Me.TextBox11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox11.Location = New System.Drawing.Point(182, 799)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(181, 22)
        Me.TextBox11.TabIndex = 70
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(16, 799)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(101, 22)
        Me.Label25.TabIndex = 69
        Me.Label25.Text = "Document No.:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(16, 868)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 22)
        Me.Label26.TabIndex = 74
        Me.Label26.Text = "Series of:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox12
        '
        Me.TextBox12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox12.Location = New System.Drawing.Point(183, 848)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(181, 22)
        Me.TextBox12.TabIndex = 75
        '
        'TextBox13
        '
        Me.TextBox13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox13.Location = New System.Drawing.Point(183, 873)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(181, 22)
        Me.TextBox13.TabIndex = 76
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(552, 825)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(91, 22)
        Me.Label27.TabIndex = 77
        Me.Label27.Text = "Notary Public"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LostStolenDamaged
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1303, 1055)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.Panel15)
        Me.Controls.Add(Me.propertyCard)
        Me.Name = "LostStolenDamaged"
        Me.Text = "LostStolenDamaged"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents propertyCard As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents pcEntityName As TextBox
    Friend WithEvents entityName As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents pcFundCluster As TextBox
    Friend WithEvents fundCluster As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents pcPropertyPlant As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents loststolen_chkboxYes As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pcRLSDDPDate As Label
    Friend WithEvents pcRLSDDPNo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents pcDatepicker As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents pcPoliceStation As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents loststolen_chkboxNo As CheckBox
    Friend WithEvents pcPARDatepicker As TextBox
    Friend WithEvents pcPARDate As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents pcPARNo As Label
    Friend WithEvents pcRLSDDPDatepicker As DateTimePicker
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents pcDestroyed As CheckBox
    Friend WithEvents pcDamaged As CheckBox
    Friend WithEvents pcStolen As CheckBox
    Friend WithEvents pcLost As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents propertyNo As DataGridViewTextBoxColumn
    Friend WithEvents pcDescription As DataGridViewTextBoxColumn
    Friend WithEvents pcAcquisitionCost As DataGridViewTextBoxColumn
    Friend WithEvents pcCircumstances As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label22 As Label
End Class
