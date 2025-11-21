Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SADepartmentManagement
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
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblUserManagement = New System.Windows.Forms.Label()
        Me.btnUpdate = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnDelete = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(1071, 156)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(153, 34)
        Me.btnAdd.TabIndex = 147
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(224, 151)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(775, 41)
        Me.TextBox1.TabIndex = 151
        '
        'lblUserManagement
        '
        Me.lblUserManagement.AutoSize = True
        Me.lblUserManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserManagement.Location = New System.Drawing.Point(143, 70)
        Me.lblUserManagement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserManagement.Name = "lblUserManagement"
        Me.lblUserManagement.Size = New System.Drawing.Size(422, 39)
        Me.lblUserManagement.TabIndex = 150
        Me.lblUserManagement.Text = "Department Management"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnUpdate.CornerRadius = 15
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdate.Location = New System.Drawing.Point(1430, 155)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(152, 35)
        Me.btnUpdate.TabIndex = 149
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnDelete.CornerRadius = 15
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(1254, 155)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(152, 35)
        Me.btnDelete.TabIndex = 148
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PropertID, Me.PropertyName, Me.Category, Me.Description, Me.SerialNumber, Me.AcquisitionDate, Me.AcquisitionCost, Me.Supplier, Me.ConditionStatus, Me.LocationColumn, Me.CustodianID, Me.WarrantyDetail, Me.LifeSpan, Me.DepreciationValue, Me.DisposalDate})
        Me.DataGridView1.Location = New System.Drawing.Point(146, 222)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1436, 817)
        Me.DataGridView1.TabIndex = 146
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
        Me.AcquisitionCost.HeaderText = "Acquisition Cost"
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
        Me.LifeSpan.HeaderText = "Life Span"
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
        Me.DisposalDate.HeaderText = "Disposa Date"
        Me.DisposalDate.MinimumWidth = 6
        Me.DisposalDate.Name = "DisposalDate"
        Me.DisposalDate.Width = 125
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.Location = New System.Drawing.Point(140, 222)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1442, 639)
        Me.Panel1.TabIndex = 153
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(146, 151)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(58, 41)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 154
        Me.PictureBox2.TabStop = False
        '
        'SADepartmentManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1773, 1080)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblUserManagement)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SADepartmentManagement"
        Me.Text = "SADepartmentManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblUserManagement As Label
    Friend WithEvents btnUpdate As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnDelete As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox2 As PictureBox
End Class
