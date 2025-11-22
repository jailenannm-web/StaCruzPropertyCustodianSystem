Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SAAddSuppliesManagement
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
        Me.LocationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustodianID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarrantyDetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LifeSpan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisposalDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConditionStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepreciationValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdd = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Label1 = New System.Windows.Forms.Label()
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
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'DisposalDate
        '
        Me.DisposalDate.HeaderText = "Disposa lDate"
        Me.DisposalDate.MinimumWidth = 6
        Me.DisposalDate.Name = "DisposalDate"
        Me.DisposalDate.Width = 125
        '
        'ConditionStatus
        '
        Me.ConditionStatus.HeaderText = "Condition Status"
        Me.ConditionStatus.MinimumWidth = 6
        Me.ConditionStatus.Name = "ConditionStatus"
        Me.ConditionStatus.Width = 125
        '
        'DepreciationValue
        '
        Me.DepreciationValue.HeaderText = "Depreciation Value"
        Me.DepreciationValue.MinimumWidth = 6
        Me.DepreciationValue.Name = "DepreciationValue"
        Me.DepreciationValue.Width = 125
        '
        'Supplier
        '
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.MinimumWidth = 6
        Me.Supplier.Name = "Supplier"
        Me.Supplier.Width = 125
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnAdd.CornerRadius = 15
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Poppins", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.Location = New System.Drawing.Point(1344, 122)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(136, 38)
        Me.btnAdd.TabIndex = 147
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(416, 129)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 32)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "Search"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(525, 119)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(656, 42)
        Me.TextBox1.TabIndex = 151
        '
        'lblUserManagement
        '
        Me.lblUserManagement.AutoSize = True
        Me.lblUserManagement.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblUserManagement.Location = New System.Drawing.Point(416, 34)
        Me.lblUserManagement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserManagement.Name = "lblUserManagement"
        Me.lblUserManagement.Size = New System.Drawing.Size(404, 60)
        Me.lblUserManagement.TabIndex = 150
        Me.lblUserManagement.Text = "Supply Mamagement"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnUpdate.CornerRadius = 15
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Poppins", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdate.Location = New System.Drawing.Point(1693, 119)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(135, 42)
        Me.btnUpdate.TabIndex = 149
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnDelete.CornerRadius = 15
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Poppins", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Location = New System.Drawing.Point(1527, 120)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(135, 39)
        Me.btnDelete.TabIndex = 148
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PropertID, Me.PropertyName, Me.Category, Me.Description, Me.SerialNumber, Me.AcquisitionDate, Me.AcquisitionCost, Me.Supplier, Me.ConditionStatus, Me.LocationColumn, Me.CustodianID, Me.WarrantyDetail, Me.LifeSpan, Me.DepreciationValue, Me.DisposalDate})
        Me.DataGridView1.Location = New System.Drawing.Point(419, 187)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1409, 705)
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
        Me.AcquisitionCost.HeaderText = "AcquisitionCost"
        Me.AcquisitionCost.MinimumWidth = 6
        Me.AcquisitionCost.Name = "AcquisitionCost"
        Me.AcquisitionCost.Width = 125
        '
        'SAAddSuppliesManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1911, 970)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblUserManagement)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SAAddSuppliesManagement"
        Me.Text = "SAAddSuppliesManagement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LocationColumn As DataGridViewTextBoxColumn
    Friend WithEvents CustodianID As DataGridViewTextBoxColumn
    Friend WithEvents WarrantyDetail As DataGridViewTextBoxColumn
    Friend WithEvents LifeSpan As DataGridViewTextBoxColumn
    Friend WithEvents DisposalDate As DataGridViewTextBoxColumn
    Friend WithEvents ConditionStatus As DataGridViewTextBoxColumn
    Friend WithEvents DepreciationValue As DataGridViewTextBoxColumn
    Friend WithEvents Supplier As DataGridViewTextBoxColumn
    Friend WithEvents btnAdd As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Label1 As Label
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
End Class
