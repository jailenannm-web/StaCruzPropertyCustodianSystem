Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RequisitionIssueSlip
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
        Me.admin_label_Reports = New System.Windows.Forms.Label()
        Me.entityName = New System.Windows.Forms.Label()
        Me.fundCluster = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.requisitionPurpose = New System.Windows.Forms.TextBox()
        Me.purpose = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.requisitionDataGrid1 = New System.Windows.Forms.DataGridView()
        Me.requisitionRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisitionQuantity2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisitionNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisitionYes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisitionQuantity1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisitionParticulars = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisitionUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisitionName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel28 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel33 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel39 = New System.Windows.Forms.Panel()
        Me.Panel38 = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.Panel29 = New System.Windows.Forms.Panel()
        Me.Panel30 = New System.Windows.Forms.Panel()
        Me.Panel31 = New System.Windows.Forms.Panel()
        Me.Panel32 = New System.Windows.Forms.Panel()
        Me.Panel35 = New System.Windows.Forms.Panel()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.Panel34 = New System.Windows.Forms.Panel()
        Me.Panel36 = New System.Windows.Forms.Panel()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Panel15.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.requisitionDataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel21.SuspendLayout()
        Me.Panel24.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel28.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel33.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel39.SuspendLayout()
        Me.Panel38.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel25.SuspendLayout()
        Me.Panel26.SuspendLayout()
        Me.Panel29.SuspendLayout()
        Me.Panel30.SuspendLayout()
        Me.Panel31.SuspendLayout()
        Me.Panel32.SuspendLayout()
        Me.Panel35.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.Panel34.SuspendLayout()
        Me.Panel36.SuspendLayout()
        Me.Panel27.SuspendLayout()
        Me.SuspendLayout()
        '
        'admin_label_Reports
        '
        Me.admin_label_Reports.AutoSize = True
        Me.admin_label_Reports.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_Reports.Location = New System.Drawing.Point(401, 34)
        Me.admin_label_Reports.Name = "admin_label_Reports"
        Me.admin_label_Reports.Size = New System.Drawing.Size(341, 44)
        Me.admin_label_Reports.TabIndex = 36
        Me.admin_label_Reports.Text = "Requisition and Issue Slip"
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
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(97, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(312, 22)
        Me.TextBox1.TabIndex = 43
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox6.Location = New System.Drawing.Point(104, 3)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(312, 22)
        Me.TextBox6.TabIndex = 45
        '
        'requisitionPurpose
        '
        Me.requisitionPurpose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requisitionPurpose.Location = New System.Drawing.Point(6, 30)
        Me.requisitionPurpose.Multiline = True
        Me.requisitionPurpose.Name = "requisitionPurpose"
        Me.requisitionPurpose.Size = New System.Drawing.Size(824, 94)
        Me.requisitionPurpose.TabIndex = 59
        '
        'purpose
        '
        Me.purpose.AutoSize = True
        Me.purpose.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.purpose.Location = New System.Drawing.Point(3, 5)
        Me.purpose.Name = "purpose"
        Me.purpose.Size = New System.Drawing.Size(63, 22)
        Me.purpose.TabIndex = 58
        Me.purpose.Text = "Purpose:"
        Me.purpose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel15
        '
        Me.Panel15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel15.Controls.Add(Me.TextBox6)
        Me.Panel15.Controls.Add(Me.fundCluster)
        Me.Panel15.Location = New System.Drawing.Point(577, 99)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(423, 29)
        Me.Panel15.TabIndex = 46
        '
        'Panel16
        '
        Me.Panel16.Controls.Add(Me.TextBox1)
        Me.Panel16.Controls.Add(Me.entityName)
        Me.Panel16.Location = New System.Drawing.Point(162, 99)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(416, 29)
        Me.Panel16.TabIndex = 47
        '
        'Panel17
        '
        Me.Panel17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel17.Controls.Add(Me.requisitionPurpose)
        Me.Panel17.Controls.Add(Me.purpose)
        Me.Panel17.Location = New System.Drawing.Point(162, 494)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(835, 139)
        Me.Panel17.TabIndex = 61
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.TextBox4)
        Me.Panel8.Controls.Add(Me.TextBox5)
        Me.Panel8.Controls.Add(Me.Label7)
        Me.Panel8.Controls.Add(Me.Label8)
        Me.Panel8.Location = New System.Drawing.Point(0, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(416, 56)
        Me.Panel8.TabIndex = 48
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 22)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Division:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 22)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Office:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.Location = New System.Drawing.Point(95, 5)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(312, 22)
        Me.TextBox5.TabIndex = 44
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.Location = New System.Drawing.Point(95, 28)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(312, 22)
        Me.TextBox4.TabIndex = 46
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.TextBox2)
        Me.Panel7.Controls.Add(Me.TextBox3)
        Me.Panel7.Controls.Add(Me.Label5)
        Me.Panel7.Controls.Add(Me.Label6)
        Me.Panel7.Location = New System.Drawing.Point(415, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(420, 56)
        Me.Panel7.TabIndex = 49
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(174, 22)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Responsibility Center Code"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 22)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "RIS No.:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.Location = New System.Drawing.Point(204, 5)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(207, 22)
        Me.TextBox3.TabIndex = 44
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Location = New System.Drawing.Point(99, 28)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(312, 22)
        Me.TextBox2.TabIndex = 46
        '
        'Panel9
        '
        Me.Panel9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.Label9)
        Me.Panel9.Location = New System.Drawing.Point(0, 59)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(416, 47)
        Me.Panel9.TabIndex = 50
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(157, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 22)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Requisition"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.BackColor = System.Drawing.Color.Transparent
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.Label11)
        Me.Panel11.Location = New System.Drawing.Point(415, 59)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(165, 47)
        Me.Panel11.TabIndex = 50
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(28, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 22)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Stock Available?"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel10
        '
        Me.Panel10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel10.BackColor = System.Drawing.Color.Transparent
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.Label15)
        Me.Panel10.Location = New System.Drawing.Point(579, 59)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(256, 47)
        Me.Panel10.TabIndex = 51
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(105, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 22)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Issue"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'requisitionDataGrid1
        '
        Me.requisitionDataGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requisitionDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.requisitionDataGrid1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.requisitionName, Me.requisitionUnit, Me.requisitionParticulars, Me.requisitionQuantity1, Me.requisitionYes, Me.requisitionNo, Me.requisitionQuantity2, Me.requisitionRemarks})
        Me.requisitionDataGrid1.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.requisitionDataGrid1.Location = New System.Drawing.Point(0, 105)
        Me.requisitionDataGrid1.Name = "requisitionDataGrid1"
        Me.requisitionDataGrid1.RowHeadersWidth = 51
        Me.requisitionDataGrid1.RowTemplate.Height = 24
        Me.requisitionDataGrid1.Size = New System.Drawing.Size(835, 263)
        Me.requisitionDataGrid1.TabIndex = 57
        '
        'requisitionRemarks
        '
        Me.requisitionRemarks.HeaderText = "Remarks"
        Me.requisitionRemarks.MinimumWidth = 6
        Me.requisitionRemarks.Name = "requisitionRemarks"
        Me.requisitionRemarks.Width = 200
        '
        'requisitionQuantity2
        '
        Me.requisitionQuantity2.HeaderText = "Quantity"
        Me.requisitionQuantity2.MinimumWidth = 6
        Me.requisitionQuantity2.Name = "requisitionQuantity2"
        Me.requisitionQuantity2.Width = 70
        '
        'requisitionNo
        '
        Me.requisitionNo.HeaderText = "No"
        Me.requisitionNo.MinimumWidth = 6
        Me.requisitionNo.Name = "requisitionNo"
        Me.requisitionNo.Width = 75
        '
        'requisitionYes
        '
        Me.requisitionYes.HeaderText = "Yes"
        Me.requisitionYes.MinimumWidth = 6
        Me.requisitionYes.Name = "requisitionYes"
        Me.requisitionYes.Width = 75
        '
        'requisitionQuantity1
        '
        Me.requisitionQuantity1.HeaderText = "Quantity"
        Me.requisitionQuantity1.MinimumWidth = 6
        Me.requisitionQuantity1.Name = "requisitionQuantity1"
        Me.requisitionQuantity1.Width = 70
        '
        'requisitionParticulars
        '
        Me.requisitionParticulars.HeaderText = "Particulars"
        Me.requisitionParticulars.MinimumWidth = 6
        Me.requisitionParticulars.Name = "requisitionParticulars"
        Me.requisitionParticulars.Width = 120
        '
        'requisitionUnit
        '
        Me.requisitionUnit.HeaderText = "Unit"
        Me.requisitionUnit.MinimumWidth = 6
        Me.requisitionUnit.Name = "requisitionUnit"
        Me.requisitionUnit.Width = 70
        '
        'requisitionName
        '
        Me.requisitionName.HeaderText = "Name"
        Me.requisitionName.MinimumWidth = 6
        Me.requisitionName.Name = "requisitionName"
        Me.requisitionName.Width = 120
        '
        'Panel21
        '
        Me.Panel21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel21.Controls.Add(Me.Label19)
        Me.Panel21.Location = New System.Drawing.Point(261, 505)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(146, 28)
        Me.Panel21.TabIndex = 66
        '
        'Label19
        '
        Me.Label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label19.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(18, 4)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(109, 22)
        Me.Label19.TabIndex = 48
        Me.Label19.Text = "Requested by:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel24
        '
        Me.Panel24.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel24.Controls.Add(Me.TextBox8)
        Me.Panel24.Location = New System.Drawing.Point(261, 532)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(146, 28)
        Me.Panel24.TabIndex = 71
        '
        'Panel18
        '
        Me.Panel18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel18.Location = New System.Drawing.Point(0, 505)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(263, 28)
        Me.Panel18.TabIndex = 67
        '
        'Panel23
        '
        Me.Panel23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel23.Controls.Add(Me.Label21)
        Me.Panel23.Location = New System.Drawing.Point(0, 532)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(263, 28)
        Me.Panel23.TabIndex = 72
        '
        'Label21
        '
        Me.Label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label21.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(77, 4)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(109, 22)
        Me.Label21.TabIndex = 48
        Me.Label21.Text = "Signature"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TextBox11)
        Me.Panel4.Location = New System.Drawing.Point(406, 532)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(146, 28)
        Me.Panel4.TabIndex = 88
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Location = New System.Drawing.Point(406, 505)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(146, 28)
        Me.Panel5.TabIndex = 87
        '
        'Label1
        '
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 22)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Approved by:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel28
        '
        Me.Panel28.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel28.Controls.Add(Me.Label16)
        Me.Panel28.Location = New System.Drawing.Point(0, 559)
        Me.Panel28.Name = "Panel28"
        Me.Panel28.Size = New System.Drawing.Size(263, 28)
        Me.Panel28.TabIndex = 77
        '
        'Label16
        '
        Me.Label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label16.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(77, 4)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 22)
        Me.Label16.TabIndex = 48
        Me.Label16.Text = "Printed Name"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TextBox12)
        Me.Panel3.Location = New System.Drawing.Point(406, 559)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(146, 28)
        Me.Panel3.TabIndex = 89
        '
        'Panel33
        '
        Me.Panel33.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel33.Controls.Add(Me.Label22)
        Me.Panel33.Location = New System.Drawing.Point(0, 586)
        Me.Panel33.Name = "Panel33"
        Me.Panel33.Size = New System.Drawing.Size(263, 28)
        Me.Panel33.TabIndex = 82
        '
        'Label22
        '
        Me.Label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label22.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(77, 4)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(109, 22)
        Me.Label22.TabIndex = 48
        Me.Label22.Text = "Designation"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TextBox13)
        Me.Panel2.Location = New System.Drawing.Point(406, 586)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(146, 28)
        Me.Panel2.TabIndex = 90
        '
        'Panel39
        '
        Me.Panel39.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel39.Controls.Add(Me.TextBox7)
        Me.Panel39.Location = New System.Drawing.Point(262, 559)
        Me.Panel39.Name = "Panel39"
        Me.Panel39.Size = New System.Drawing.Size(145, 28)
        Me.Panel39.TabIndex = 86
        '
        'Panel38
        '
        Me.Panel38.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel38.Controls.Add(Me.Label23)
        Me.Panel38.Location = New System.Drawing.Point(0, 613)
        Me.Panel38.Name = "Panel38"
        Me.Panel38.Size = New System.Drawing.Size(263, 28)
        Me.Panel38.TabIndex = 87
        '
        'Label23
        '
        Me.Label23.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label23.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(77, 4)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(109, 22)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "Date"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Location = New System.Drawing.Point(406, 613)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(146, 28)
        Me.Panel1.TabIndex = 91
        '
        'Panel20
        '
        Me.Panel20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel20.Controls.Add(Me.Panel12)
        Me.Panel20.Controls.Add(Me.Panel13)
        Me.Panel20.Controls.Add(Me.Label2)
        Me.Panel20.Location = New System.Drawing.Point(551, 505)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(146, 28)
        Me.Panel20.TabIndex = 92
        '
        'Label2
        '
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 22)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Issued by:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.Controls.Add(Me.TextBox14)
        Me.Panel6.Controls.Add(Me.Panel36)
        Me.Panel6.Controls.Add(Me.Panel34)
        Me.Panel6.Controls.Add(Me.Panel19)
        Me.Panel6.Controls.Add(Me.Panel35)
        Me.Panel6.Controls.Add(Me.Panel32)
        Me.Panel6.Controls.Add(Me.Panel31)
        Me.Panel6.Controls.Add(Me.Panel30)
        Me.Panel6.Controls.Add(Me.Panel29)
        Me.Panel6.Controls.Add(Me.Panel26)
        Me.Panel6.Controls.Add(Me.Panel14)
        Me.Panel6.Controls.Add(Me.Panel20)
        Me.Panel6.Controls.Add(Me.Panel1)
        Me.Panel6.Controls.Add(Me.Panel38)
        Me.Panel6.Controls.Add(Me.Panel39)
        Me.Panel6.Controls.Add(Me.Panel2)
        Me.Panel6.Controls.Add(Me.Panel33)
        Me.Panel6.Controls.Add(Me.Panel3)
        Me.Panel6.Controls.Add(Me.Panel28)
        Me.Panel6.Controls.Add(Me.Panel5)
        Me.Panel6.Controls.Add(Me.Panel4)
        Me.Panel6.Controls.Add(Me.Panel23)
        Me.Panel6.Controls.Add(Me.Panel18)
        Me.Panel6.Controls.Add(Me.Panel24)
        Me.Panel6.Controls.Add(Me.Panel21)
        Me.Panel6.Controls.Add(Me.requisitionDataGrid1)
        Me.Panel6.Controls.Add(Me.Panel10)
        Me.Panel6.Controls.Add(Me.Panel11)
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Location = New System.Drawing.Point(162, 127)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(838, 648)
        Me.Panel6.TabIndex = 44
        '
        'Panel12
        '
        Me.Panel12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Location = New System.Drawing.Point(147, 29)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(136, 28)
        Me.Panel12.TabIndex = 95
        '
        'Panel13
        '
        Me.Panel13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.Label3)
        Me.Panel13.Location = New System.Drawing.Point(147, 2)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(136, 28)
        Me.Panel13.TabIndex = 94
        '
        'Label3
        '
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 22)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Issued by:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel14
        '
        Me.Panel14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel14.Controls.Add(Me.Panel22)
        Me.Panel14.Controls.Add(Me.Panel25)
        Me.Panel14.Controls.Add(Me.Label10)
        Me.Panel14.Location = New System.Drawing.Point(696, 505)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(139, 28)
        Me.Panel14.TabIndex = 96
        '
        'Panel22
        '
        Me.Panel22.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel22.Location = New System.Drawing.Point(147, 29)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(129, 28)
        Me.Panel22.TabIndex = 95
        '
        'Panel25
        '
        Me.Panel25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel25.Controls.Add(Me.Label4)
        Me.Panel25.Location = New System.Drawing.Point(147, 2)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(129, 28)
        Me.Panel25.TabIndex = 94
        '
        'Label4
        '
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 22)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Issued by:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label10.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 22)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Received by:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel26
        '
        Me.Panel26.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel26.Controls.Add(Me.Panel27)
        Me.Panel26.Location = New System.Drawing.Point(551, 559)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(146, 28)
        Me.Panel26.TabIndex = 94
        '
        'Panel29
        '
        Me.Panel29.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel29.Controls.Add(Me.DateTimePicker3)
        Me.Panel29.Location = New System.Drawing.Point(551, 613)
        Me.Panel29.Name = "Panel29"
        Me.Panel29.Size = New System.Drawing.Size(146, 28)
        Me.Panel29.TabIndex = 98
        '
        'Panel30
        '
        Me.Panel30.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel30.Controls.Add(Me.TextBox19)
        Me.Panel30.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Panel30.Location = New System.Drawing.Point(696, 532)
        Me.Panel30.Name = "Panel30"
        Me.Panel30.Size = New System.Drawing.Size(139, 28)
        Me.Panel30.TabIndex = 97
        '
        'Panel31
        '
        Me.Panel31.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel31.Controls.Add(Me.TextBox20)
        Me.Panel31.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Panel31.Location = New System.Drawing.Point(696, 559)
        Me.Panel31.Name = "Panel31"
        Me.Panel31.Size = New System.Drawing.Size(139, 28)
        Me.Panel31.TabIndex = 98
        '
        'Panel32
        '
        Me.Panel32.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel32.Controls.Add(Me.TextBox21)
        Me.Panel32.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Panel32.Location = New System.Drawing.Point(696, 586)
        Me.Panel32.Name = "Panel32"
        Me.Panel32.Size = New System.Drawing.Size(139, 28)
        Me.Panel32.TabIndex = 99
        '
        'Panel35
        '
        Me.Panel35.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel35.Controls.Add(Me.DateTimePicker4)
        Me.Panel35.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Panel35.Location = New System.Drawing.Point(696, 613)
        Me.Panel35.Name = "Panel35"
        Me.Panel35.Size = New System.Drawing.Size(139, 28)
        Me.Panel35.TabIndex = 100
        '
        'TextBox8
        '
        Me.TextBox8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox8.Location = New System.Drawing.Point(3, 2)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(139, 22)
        Me.TextBox8.TabIndex = 101
        '
        'TextBox11
        '
        Me.TextBox11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox11.Location = New System.Drawing.Point(3, 2)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(139, 22)
        Me.TextBox11.TabIndex = 102
        '
        'TextBox12
        '
        Me.TextBox12.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox12.Location = New System.Drawing.Point(3, 2)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(139, 22)
        Me.TextBox12.TabIndex = 102
        '
        'TextBox13
        '
        Me.TextBox13.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox13.Location = New System.Drawing.Point(3, 2)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(139, 22)
        Me.TextBox13.TabIndex = 102
        '
        'TextBox15
        '
        Me.TextBox15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox15.Location = New System.Drawing.Point(3, 2)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(139, 22)
        Me.TextBox15.TabIndex = 102
        '
        'Panel19
        '
        Me.Panel19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel19.Controls.Add(Me.TextBox15)
        Me.Panel19.Location = New System.Drawing.Point(551, 532)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(146, 28)
        Me.Panel19.TabIndex = 103
        '
        'TextBox19
        '
        Me.TextBox19.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox19.Location = New System.Drawing.Point(2, 2)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(132, 22)
        Me.TextBox19.TabIndex = 103
        '
        'TextBox20
        '
        Me.TextBox20.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox20.Location = New System.Drawing.Point(2, 2)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(132, 22)
        Me.TextBox20.TabIndex = 104
        '
        'TextBox21
        '
        Me.TextBox21.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox21.Location = New System.Drawing.Point(2, 2)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(132, 22)
        Me.TextBox21.TabIndex = 104
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker2.Location = New System.Drawing.Point(3, 2)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(139, 22)
        Me.DateTimePicker2.TabIndex = 1
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker3.Location = New System.Drawing.Point(3, 2)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(139, 22)
        Me.DateTimePicker3.TabIndex = 1
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker4.Location = New System.Drawing.Point(3, 2)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(131, 22)
        Me.DateTimePicker4.TabIndex = 1
        '
        'Panel34
        '
        Me.Panel34.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel34.Controls.Add(Me.TextBox9)
        Me.Panel34.Location = New System.Drawing.Point(262, 586)
        Me.Panel34.Name = "Panel34"
        Me.Panel34.Size = New System.Drawing.Size(145, 28)
        Me.Panel34.TabIndex = 87
        '
        'Panel36
        '
        Me.Panel36.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel36.Controls.Add(Me.DateTimePicker1)
        Me.Panel36.Location = New System.Drawing.Point(262, 613)
        Me.Panel36.Name = "Panel36"
        Me.Panel36.Size = New System.Drawing.Size(145, 28)
        Me.Panel36.TabIndex = 102
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox7.Location = New System.Drawing.Point(2, 2)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(139, 22)
        Me.TextBox7.TabIndex = 102
        '
        'TextBox9
        '
        Me.TextBox9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox9.Location = New System.Drawing.Point(2, 2)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(139, 22)
        Me.TextBox9.TabIndex = 103
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.Location = New System.Drawing.Point(2, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(139, 22)
        Me.DateTimePicker1.TabIndex = 2
        '
        'Panel27
        '
        Me.Panel27.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel27.Controls.Add(Me.TextBox10)
        Me.Panel27.Location = New System.Drawing.Point(-1, -1)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(146, 28)
        Me.Panel27.TabIndex = 95
        '
        'TextBox10
        '
        Me.TextBox10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox10.Location = New System.Drawing.Point(3, 2)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(139, 22)
        Me.TextBox10.TabIndex = 103
        '
        'TextBox14
        '
        Me.TextBox14.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox14.Location = New System.Drawing.Point(555, 589)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(139, 22)
        Me.TextBox14.TabIndex = 104
        '
        'RequisitionIssueSlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 880)
        Me.Controls.Add(Me.Panel17)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.Panel15)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.admin_label_Reports)
        Me.Name = "RequisitionIssueSlip"
        Me.Text = "RequisitionIssueSlip"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.requisitionDataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel21.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        Me.Panel24.PerformLayout()
        Me.Panel23.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel28.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel33.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel39.ResumeLayout(False)
        Me.Panel39.PerformLayout()
        Me.Panel38.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel20.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel25.ResumeLayout(False)
        Me.Panel26.ResumeLayout(False)
        Me.Panel29.ResumeLayout(False)
        Me.Panel30.ResumeLayout(False)
        Me.Panel30.PerformLayout()
        Me.Panel31.ResumeLayout(False)
        Me.Panel31.PerformLayout()
        Me.Panel32.ResumeLayout(False)
        Me.Panel32.PerformLayout()
        Me.Panel35.ResumeLayout(False)
        Me.Panel19.ResumeLayout(False)
        Me.Panel19.PerformLayout()
        Me.Panel34.ResumeLayout(False)
        Me.Panel34.PerformLayout()
        Me.Panel36.ResumeLayout(False)
        Me.Panel27.ResumeLayout(False)
        Me.Panel27.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents admin_label_Reports As Label
    Friend WithEvents entityName As Label
    Friend WithEvents fundCluster As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents requisitionPurpose As TextBox
    Friend WithEvents purpose As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents requisitionDataGrid1 As DataGridView
    Friend WithEvents requisitionName As DataGridViewTextBoxColumn
    Friend WithEvents requisitionUnit As DataGridViewTextBoxColumn
    Friend WithEvents requisitionParticulars As DataGridViewTextBoxColumn
    Friend WithEvents requisitionQuantity1 As DataGridViewTextBoxColumn
    Friend WithEvents requisitionYes As DataGridViewTextBoxColumn
    Friend WithEvents requisitionNo As DataGridViewTextBoxColumn
    Friend WithEvents requisitionQuantity2 As DataGridViewTextBoxColumn
    Friend WithEvents requisitionRemarks As DataGridViewTextBoxColumn
    Friend WithEvents Panel21 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel24 As Panel
    Friend WithEvents Panel18 As Panel
    Friend WithEvents Panel23 As Panel
    Friend WithEvents Label21 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel28 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel33 As Panel
    Friend WithEvents Label22 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel39 As Panel
    Friend WithEvents Panel38 As Panel
    Friend WithEvents Label23 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel20 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel22 As Panel
    Friend WithEvents Panel25 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel26 As Panel
    Friend WithEvents Panel29 As Panel
    Friend WithEvents Panel35 As Panel
    Friend WithEvents Panel32 As Panel
    Friend WithEvents Panel31 As Panel
    Friend WithEvents Panel30 As Panel
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Panel19 As Panel
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents DateTimePicker4 As DateTimePicker
    Friend WithEvents TextBox21 As TextBox
    Friend WithEvents TextBox20 As TextBox
    Friend WithEvents TextBox19 As TextBox
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Panel36 As Panel
    Friend WithEvents Panel34 As Panel
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Panel27 As Panel
    Friend WithEvents TextBox10 As TextBox
End Class
