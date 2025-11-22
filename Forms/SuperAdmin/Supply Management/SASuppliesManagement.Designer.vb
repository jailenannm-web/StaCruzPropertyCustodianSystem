Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SASuppliesManagement
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
        Me.lblSuppliesManagement = New System.Windows.Forms.Label()
        Me.btnAddSupply = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnEdit = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PropertID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PropertyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AcquisitionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AcquisitionCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConditionStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustodianID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarrantyDetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LifeSpan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepreciationValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisposalDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlStatus = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.combostatus = New System.Windows.Forms.ComboBox()
        Me.pnlCategories = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.comboCategoris = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStatus.SuspendLayout()
        Me.pnlCategories.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSuppliesManagement
        '
        Me.lblSuppliesManagement.AutoSize = True
        Me.lblSuppliesManagement.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuppliesManagement.Location = New System.Drawing.Point(131, 73)
        Me.lblSuppliesManagement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSuppliesManagement.Name = "lblSuppliesManagement"
        Me.lblSuppliesManagement.Size = New System.Drawing.Size(404, 58)
        Me.lblSuppliesManagement.TabIndex = 23
        Me.lblSuppliesManagement.Text = "Supplies Management"
        '
        'btnAddSupply
        '
        Me.btnAddSupply.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAddSupply.CornerRadius = 15
        Me.btnAddSupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSupply.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSupply.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddSupply.Location = New System.Drawing.Point(1396, 1054)
        Me.btnAddSupply.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddSupply.Name = "btnAddSupply"
        Me.btnAddSupply.Size = New System.Drawing.Size(125, 38)
        Me.btnAddSupply.TabIndex = 25
        Me.btnAddSupply.Text = "Add Supply"
        Me.btnAddSupply.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnEdit.CornerRadius = 15
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.Location = New System.Drawing.Point(1230, 1054)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(125, 38)
        Me.btnEdit.TabIndex = 24
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PropertID, Me.PropertyName, Me.Category, Me.Description, Me.SerialNumber, Me.AcquisitionDate, Me.AcquisitionCost, Me.Supplier, Me.ConditionStatus, Me.LocationColumn, Me.CustodianID, Me.WarrantyDetail, Me.LifeSpan, Me.DepreciationValue, Me.DisposalDate})
        Me.DataGridView1.Location = New System.Drawing.Point(138, 231)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1391, 815)
        Me.DataGridView1.TabIndex = 153
        '
        'PropertID
        '
        Me.PropertID.HeaderText = "Propert I.D"
        Me.PropertID.MinimumWidth = 6
        Me.PropertID.Name = "PropertID"
        Me.PropertID.Width = 125
        '
        'PropertyName
        '
        Me.PropertyName.HeaderText = "Property Name"
        Me.PropertyName.MinimumWidth = 6
        Me.PropertyName.Name = "PropertyName"
        Me.PropertyName.Width = 125
        '
        'Category
        '
        Me.Category.HeaderText = "Category"
        Me.Category.MinimumWidth = 6
        Me.Category.Name = "Category"
        Me.Category.Width = 125
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        Me.Description.Width = 125
        '
        'SerialNumber
        '
        Me.SerialNumber.HeaderText = "Serial Number"
        Me.SerialNumber.MinimumWidth = 6
        Me.SerialNumber.Name = "SerialNumber"
        Me.SerialNumber.Width = 125
        '
        'AcquisitionDate
        '
        Me.AcquisitionDate.HeaderText = "Acquisition Date"
        Me.AcquisitionDate.MinimumWidth = 6
        Me.AcquisitionDate.Name = "AcquisitionDate"
        Me.AcquisitionDate.Width = 125
        '
        'AcquisitionCost
        '
        Me.AcquisitionCost.HeaderText = "AcquisitionCost"
        Me.AcquisitionCost.MinimumWidth = 6
        Me.AcquisitionCost.Name = "AcquisitionCost"
        Me.AcquisitionCost.Width = 125
        '
        'Supplier
        '
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.MinimumWidth = 6
        Me.Supplier.Name = "Supplier"
        Me.Supplier.Width = 125
        '
        'ConditionStatus
        '
        Me.ConditionStatus.HeaderText = "Condition Status"
        Me.ConditionStatus.MinimumWidth = 6
        Me.ConditionStatus.Name = "ConditionStatus"
        Me.ConditionStatus.Width = 125
        '
        'LocationColumn
        '
        Me.LocationColumn.HeaderText = "Location"
        Me.LocationColumn.MinimumWidth = 6
        Me.LocationColumn.Name = "LocationColumn"
        Me.LocationColumn.Width = 125
        '
        'CustodianID
        '
        Me.CustodianID.HeaderText = "Custodian I.D"
        Me.CustodianID.MinimumWidth = 6
        Me.CustodianID.Name = "CustodianID"
        Me.CustodianID.Width = 125
        '
        'WarrantyDetail
        '
        Me.WarrantyDetail.HeaderText = "Warranty Detail"
        Me.WarrantyDetail.MinimumWidth = 6
        Me.WarrantyDetail.Name = "WarrantyDetail"
        Me.WarrantyDetail.Width = 125
        '
        'LifeSpan
        '
        Me.LifeSpan.HeaderText = "LifeSpan"
        Me.LifeSpan.MinimumWidth = 6
        Me.LifeSpan.Name = "LifeSpan"
        Me.LifeSpan.Width = 125
        '
        'DepreciationValue
        '
        Me.DepreciationValue.HeaderText = "Depreciation Value"
        Me.DepreciationValue.MinimumWidth = 6
        Me.DepreciationValue.Name = "DepreciationValue"
        Me.DepreciationValue.Width = 125
        '
        'DisposalDate
        '
        Me.DisposalDate.HeaderText = "Disposa lDate"
        Me.DisposalDate.MinimumWidth = 6
        Me.DisposalDate.Name = "DisposalDate"
        Me.DisposalDate.Width = 125
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(156, 165)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(58, 41)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 164
        Me.PictureBox2.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(216, 165)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(729, 41)
        Me.TextBox1.TabIndex = 163
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.Label2.Location = New System.Drawing.Point(1266, 175)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 30)
        Me.Label2.TabIndex = 162
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.Label1.Location = New System.Drawing.Point(953, 173)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 30)
        Me.Label1.TabIndex = 161
        Me.Label1.Text = "Categories"
        '
        'pnlStatus
        '
        Me.pnlStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlStatus.Controls.Add(Me.combostatus)
        Me.pnlStatus.CornerRadius = 5
        Me.pnlStatus.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.pnlStatus.Location = New System.Drawing.Point(1334, 168)
        Me.pnlStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(177, 37)
        Me.pnlStatus.TabIndex = 160
        '
        'combostatus
        '
        Me.combostatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.combostatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.combostatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.combostatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.combostatus.FormattingEnabled = True
        Me.combostatus.Location = New System.Drawing.Point(16, 7)
        Me.combostatus.Margin = New System.Windows.Forms.Padding(4)
        Me.combostatus.Name = "combostatus"
        Me.combostatus.Size = New System.Drawing.Size(144, 23)
        Me.combostatus.TabIndex = 1
        '
        'pnlCategories
        '
        Me.pnlCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlCategories.Controls.Add(Me.comboCategoris)
        Me.pnlCategories.CornerRadius = 5
        Me.pnlCategories.Font = New System.Drawing.Font("Poppins", 9.8!)
        Me.pnlCategories.Location = New System.Drawing.Point(1066, 170)
        Me.pnlCategories.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCategories.Name = "pnlCategories"
        Me.pnlCategories.Size = New System.Drawing.Size(177, 37)
        Me.pnlCategories.TabIndex = 159
        '
        'comboCategoris
        '
        Me.comboCategoris.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboCategoris.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.comboCategoris.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.comboCategoris.FormattingEnabled = True
        Me.comboCategoris.Location = New System.Drawing.Point(19, 7)
        Me.comboCategoris.Margin = New System.Windows.Forms.Padding(4)
        Me.comboCategoris.Name = "comboCategoris"
        Me.comboCategoris.Size = New System.Drawing.Size(144, 23)
        Me.comboCategoris.TabIndex = 0
        '
        'SASuppliesManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1773, 1080)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnlCategories)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnAddSupply)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.lblSuppliesManagement)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SASuppliesManagement"
        Me.Text = "SASuppliesManagement"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlCategories.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddSupply As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnEdit As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents lblSuppliesManagement As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PropertID As DataGridViewTextBoxColumn
    Friend WithEvents PropertyName As DataGridViewTextBoxColumn
    Friend WithEvents Category As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents SerialNumber As DataGridViewTextBoxColumn
    Friend WithEvents AcquisitionDate As DataGridViewTextBoxColumn
    Friend WithEvents AcquisitionCost As DataGridViewTextBoxColumn
    Friend WithEvents Supplier As DataGridViewTextBoxColumn
    Friend WithEvents ConditionStatus As DataGridViewTextBoxColumn
    Friend WithEvents LocationColumn As DataGridViewTextBoxColumn
    Friend WithEvents CustodianID As DataGridViewTextBoxColumn
    Friend WithEvents WarrantyDetail As DataGridViewTextBoxColumn
    Friend WithEvents LifeSpan As DataGridViewTextBoxColumn
    Friend WithEvents DepreciationValue As DataGridViewTextBoxColumn
    Friend WithEvents DisposalDate As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlStatus As Resources.Controls.RoundedPanel
    Friend WithEvents combostatus As ComboBox
    Friend WithEvents pnlCategories As Resources.Controls.RoundedPanel
    Friend WithEvents comboCategoris As ComboBox
End Class
