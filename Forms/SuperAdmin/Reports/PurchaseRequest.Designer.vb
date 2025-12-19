<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseRequest
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
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.prEntityName = New System.Windows.Forms.TextBox()
        Me.entityName = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.pcFundCluster = New System.Windows.Forms.TextBox()
        Me.fundCluster = New System.Windows.Forms.Label()
        Me.lblPropertyCard = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.prResponsibilityCenterCode = New System.Windows.Forms.Label()
        Me.pcDescription = New System.Windows.Forms.TextBox()
        Me.PRNo = New System.Windows.Forms.Label()
        Me.pcPropertyPlant = New System.Windows.Forms.TextBox()
        Me.prOfficeSection = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.prDate = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.prStockNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prTotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel16.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel16
        '
        Me.Panel16.Controls.Add(Me.prEntityName)
        Me.Panel16.Controls.Add(Me.entityName)
        Me.Panel16.Location = New System.Drawing.Point(259, 151)
        Me.Panel16.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(549, 30)
        Me.Panel16.TabIndex = 53
        '
        'prEntityName
        '
        Me.prEntityName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prEntityName.Location = New System.Drawing.Point(97, 2)
        Me.prEntityName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.prEntityName.Name = "prEntityName"
        Me.prEntityName.Size = New System.Drawing.Size(447, 22)
        Me.prEntityName.TabIndex = 43
        '
        'entityName
        '
        Me.entityName.AutoSize = True
        Me.entityName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.entityName.Location = New System.Drawing.Point(3, 5)
        Me.entityName.Name = "entityName"
        Me.entityName.Size = New System.Drawing.Size(88, 15)
        Me.entityName.TabIndex = 38
        Me.entityName.Text = "Entity Name:"
        Me.entityName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel15
        '
        Me.Panel15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel15.Controls.Add(Me.pcFundCluster)
        Me.Panel15.Controls.Add(Me.fundCluster)
        Me.Panel15.Location = New System.Drawing.Point(808, 151)
        Me.Panel15.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(289, 30)
        Me.Panel15.TabIndex = 52
        '
        'pcFundCluster
        '
        Me.pcFundCluster.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcFundCluster.Location = New System.Drawing.Point(104, 2)
        Me.pcFundCluster.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pcFundCluster.Name = "pcFundCluster"
        Me.pcFundCluster.Size = New System.Drawing.Size(177, 22)
        Me.pcFundCluster.TabIndex = 45
        '
        'fundCluster
        '
        Me.fundCluster.AutoSize = True
        Me.fundCluster.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fundCluster.Location = New System.Drawing.Point(3, 4)
        Me.fundCluster.Name = "fundCluster"
        Me.fundCluster.Size = New System.Drawing.Size(88, 15)
        Me.fundCluster.TabIndex = 39
        Me.fundCluster.Text = "Fund Cluster"
        Me.fundCluster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPropertyCard
        '
        Me.lblPropertyCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPropertyCard.AutoSize = True
        Me.lblPropertyCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCard.Location = New System.Drawing.Point(531, 92)
        Me.lblPropertyCard.Name = "lblPropertyCard"
        Me.lblPropertyCard.Size = New System.Drawing.Size(237, 29)
        Me.lblPropertyCard.TabIndex = 50
        Me.lblPropertyCard.Text = "Purchase Request"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.prResponsibilityCenterCode)
        Me.Panel2.Controls.Add(Me.pcDescription)
        Me.Panel2.Controls.Add(Me.PRNo)
        Me.Panel2.Controls.Add(Me.pcPropertyPlant)
        Me.Panel2.Controls.Add(Me.prOfficeSection)
        Me.Panel2.Location = New System.Drawing.Point(-1, -1)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(550, 80)
        Me.Panel2.TabIndex = 50
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(313, 50)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(225, 16)
        Me.TextBox1.TabIndex = 47
        '
        'prResponsibilityCenterCode
        '
        Me.prResponsibilityCenterCode.AutoSize = True
        Me.prResponsibilityCenterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prResponsibilityCenterCode.Location = New System.Drawing.Point(147, 52)
        Me.prResponsibilityCenterCode.Name = "prResponsibilityCenterCode"
        Me.prResponsibilityCenterCode.Size = New System.Drawing.Size(138, 15)
        Me.prResponsibilityCenterCode.TabIndex = 46
        Me.prResponsibilityCenterCode.Text = "Responisbility Code:"
        Me.prResponsibilityCenterCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcDescription
        '
        Me.pcDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcDescription.Location = New System.Drawing.Point(219, 22)
        Me.pcDescription.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pcDescription.Multiline = True
        Me.pcDescription.Name = "pcDescription"
        Me.pcDescription.Size = New System.Drawing.Size(325, 16)
        Me.pcDescription.TabIndex = 45
        '
        'PRNo
        '
        Me.PRNo.AutoSize = True
        Me.PRNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PRNo.Location = New System.Drawing.Point(147, 22)
        Me.PRNo.Name = "PRNo"
        Me.PRNo.Size = New System.Drawing.Size(56, 15)
        Me.PRNo.TabIndex = 44
        Me.PRNo.Text = "PR No.:"
        Me.PRNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcPropertyPlant
        '
        Me.pcPropertyPlant.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcPropertyPlant.Location = New System.Drawing.Point(0, 48)
        Me.pcPropertyPlant.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pcPropertyPlant.Name = "pcPropertyPlant"
        Me.pcPropertyPlant.Size = New System.Drawing.Size(119, 22)
        Me.pcPropertyPlant.TabIndex = 43
        '
        'prOfficeSection
        '
        Me.prOfficeSection.AutoSize = True
        Me.prOfficeSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prOfficeSection.Location = New System.Drawing.Point(0, 22)
        Me.prOfficeSection.Name = "prOfficeSection"
        Me.prOfficeSection.Size = New System.Drawing.Size(100, 15)
        Me.prOfficeSection.TabIndex = 38
        Me.prOfficeSection.Text = "Office/Section:"
        Me.prOfficeSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.DateTimePicker2)
        Me.Panel3.Controls.Add(Me.DateTimePicker1)
        Me.Panel3.Controls.Add(Me.prDate)
        Me.Panel3.Location = New System.Drawing.Point(548, -1)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(289, 80)
        Me.Panel3.TabIndex = 51
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(213, 26)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(9, 22)
        Me.DateTimePicker2.TabIndex = 41
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(68, 22)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(211, 22)
        Me.DateTimePicker1.TabIndex = 40
        '
        'prDate
        '
        Me.prDate.AutoSize = True
        Me.prDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prDate.Location = New System.Drawing.Point(5, 26)
        Me.prDate.Name = "prDate"
        Me.prDate.Size = New System.Drawing.Size(45, 15)
        Me.prDate.TabIndex = 39
        Me.prDate.Text = "Date: "
        Me.prDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.prStockNo, Me.prUnit, Me.prDescription, Me.prQuantity, Me.prUnitCost, Me.prTotalCost})
        Me.DataGridView1.Location = New System.Drawing.Point(-1, 84)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(837, 391)
        Me.DataGridView1.TabIndex = 57
        '
        'prStockNo
        '
        Me.prStockNo.HeaderText = "Stock/Property No."
        Me.prStockNo.MinimumWidth = 6
        Me.prStockNo.Name = "prStockNo"
        Me.prStockNo.Width = 80
        '
        'prUnit
        '
        Me.prUnit.HeaderText = "Unit"
        Me.prUnit.MinimumWidth = 6
        Me.prUnit.Name = "prUnit"
        Me.prUnit.Width = 75
        '
        'prDescription
        '
        Me.prDescription.HeaderText = "Item Description"
        Me.prDescription.MinimumWidth = 6
        Me.prDescription.Name = "prDescription"
        Me.prDescription.Width = 150
        '
        'prQuantity
        '
        Me.prQuantity.HeaderText = "Quantity"
        Me.prQuantity.MinimumWidth = 6
        Me.prQuantity.Name = "prQuantity"
        Me.prQuantity.Width = 90
        '
        'prUnitCost
        '
        Me.prUnitCost.HeaderText = "Unit Cost"
        Me.prUnitCost.MinimumWidth = 6
        Me.prUnitCost.Name = "prUnitCost"
        Me.prUnitCost.Width = 90
        '
        'prTotalCost
        '
        Me.prTotalCost.HeaderText = "Total Cost"
        Me.prTotalCost.MinimumWidth = 6
        Me.prTotalCost.Name = "prTotalCost"
        Me.prTotalCost.Width = 90
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(259, 182)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(838, 483)
        Me.Panel1.TabIndex = 51
        '
        'PurchaseRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1355, 772)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.Panel15)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblPropertyCard)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "PurchaseRequest"
        Me.Text = "PurchaseRequest"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents prEntityName As System.Windows.Forms.TextBox
    Friend WithEvents entityName As System.Windows.Forms.Label
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents pcFundCluster As System.Windows.Forms.TextBox
    Friend WithEvents fundCluster As System.Windows.Forms.Label
    Friend WithEvents lblPropertyCard As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents prResponsibilityCenterCode As System.Windows.Forms.Label
    Friend WithEvents pcDescription As System.Windows.Forms.TextBox
    Friend WithEvents PRNo As System.Windows.Forms.Label
    Friend WithEvents pcPropertyPlant As System.Windows.Forms.TextBox
    Friend WithEvents prOfficeSection As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents prDate As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents prStockNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prTotalCost As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
