Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_AddSupply
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pm_as_propertyman = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.pm_as_numericStock = New System.Windows.Forms.NumericUpDown()
        Me.pm_as_cmbobxStatus = New System.Windows.Forms.ComboBox()
        Me.pm_as_cmbobxCateg = New System.Windows.Forms.ComboBox()
        Me.pm_as_btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pm_as_btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pm_as_location = New System.Windows.Forms.Label()
        Me.pm_as_txtLocation = New System.Windows.Forms.TextBox()
        Me.pm_as_status = New System.Windows.Forms.Label()
        Me.pm_as_totalValue = New System.Windows.Forms.Label()
        Me.pm_as_txtTotalValue = New System.Windows.Forms.TextBox()
        Me.pm_as_unitCost = New System.Windows.Forms.Label()
        Me.pm_as_txtUnitCost = New System.Windows.Forms.TextBox()
        Me.pm_as_stock = New System.Windows.Forms.Label()
        Me.pm_as_category = New System.Windows.Forms.Label()
        Me.pm_as_name = New System.Windows.Forms.Label()
        Me.pm_as_txtName = New System.Windows.Forms.TextBox()
        Me.pm_as_supplyID = New System.Windows.Forms.Label()
        Me.um_as_txtSupplyID = New System.Windows.Forms.TextBox()
        Me.uc_um_adminprofile = New System.Windows.Forms.Label()
        Me.pm_as_propertyman.SuspendLayout()
        CType(Me.pm_as_numericStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pm_as_propertyman
        '
        Me.pm_as_propertyman.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_propertyman.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_as_propertyman.CornerRadius = 20
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_numericStock)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_cmbobxStatus)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_cmbobxCateg)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_btnSave)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_btnCancel)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_location)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_txtLocation)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_status)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_totalValue)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_txtTotalValue)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_unitCost)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_txtUnitCost)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_stock)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_category)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_name)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_txtName)
        Me.pm_as_propertyman.Controls.Add(Me.pm_as_supplyID)
        Me.pm_as_propertyman.Controls.Add(Me.um_as_txtSupplyID)
        Me.pm_as_propertyman.Controls.Add(Me.uc_um_adminprofile)
        Me.pm_as_propertyman.Location = New System.Drawing.Point(29, 15)
        Me.pm_as_propertyman.Name = "pm_as_propertyman"
        Me.pm_as_propertyman.Size = New System.Drawing.Size(1216, 737)
        Me.pm_as_propertyman.TabIndex = 1
        '
        'pm_as_numericStock
        '
        Me.pm_as_numericStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_as_numericStock.Font = New System.Drawing.Font("Poppins", 7.8!)
        Me.pm_as_numericStock.ForeColor = System.Drawing.Color.White
        Me.pm_as_numericStock.Location = New System.Drawing.Point(296, 339)
        Me.pm_as_numericStock.Name = "pm_as_numericStock"
        Me.pm_as_numericStock.Size = New System.Drawing.Size(258, 27)
        Me.pm_as_numericStock.TabIndex = 57
        '
        'pm_as_cmbobxStatus
        '
        Me.pm_as_cmbobxStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_cmbobxStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_as_cmbobxStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_as_cmbobxStatus.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_cmbobxStatus.ForeColor = System.Drawing.Color.White
        Me.pm_as_cmbobxStatus.FormattingEnabled = True
        Me.pm_as_cmbobxStatus.Location = New System.Drawing.Point(795, 285)
        Me.pm_as_cmbobxStatus.Name = "pm_as_cmbobxStatus"
        Me.pm_as_cmbobxStatus.Size = New System.Drawing.Size(258, 31)
        Me.pm_as_cmbobxStatus.TabIndex = 56
        Me.pm_as_cmbobxStatus.Text = "Choose"
        '
        'pm_as_cmbobxCateg
        '
        Me.pm_as_cmbobxCateg.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_as_cmbobxCateg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_as_cmbobxCateg.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_cmbobxCateg.ForeColor = System.Drawing.Color.White
        Me.pm_as_cmbobxCateg.FormattingEnabled = True
        Me.pm_as_cmbobxCateg.Location = New System.Drawing.Point(296, 285)
        Me.pm_as_cmbobxCateg.Name = "pm_as_cmbobxCateg"
        Me.pm_as_cmbobxCateg.Size = New System.Drawing.Size(258, 31)
        Me.pm_as_cmbobxCateg.TabIndex = 55
        Me.pm_as_cmbobxCateg.Text = "Choose"
        '
        'pm_as_btnSave
        '
        Me.pm_as_btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_btnSave.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_btnSave.Location = New System.Drawing.Point(977, 643)
        Me.pm_as_btnSave.Name = "pm_as_btnSave"
        Me.pm_as_btnSave.Size = New System.Drawing.Size(127, 39)
        Me.pm_as_btnSave.TabIndex = 54
        Me.pm_as_btnSave.Text = "Save"
        Me.pm_as_btnSave.UseVisualStyleBackColor = True
        '
        'pm_as_btnCancel
        '
        Me.pm_as_btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pm_as_btnCancel.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_btnCancel.Location = New System.Drawing.Point(144, 643)
        Me.pm_as_btnCancel.Name = "pm_as_btnCancel"
        Me.pm_as_btnCancel.Size = New System.Drawing.Size(127, 39)
        Me.pm_as_btnCancel.TabIndex = 53
        Me.pm_as_btnCancel.Text = "Cancel"
        Me.pm_as_btnCancel.UseVisualStyleBackColor = True
        '
        'pm_as_location
        '
        Me.pm_as_location.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_location.AutoSize = True
        Me.pm_as_location.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_location.ForeColor = System.Drawing.Color.White
        Me.pm_as_location.Location = New System.Drawing.Point(665, 339)
        Me.pm_as_location.Name = "pm_as_location"
        Me.pm_as_location.Size = New System.Drawing.Size(88, 30)
        Me.pm_as_location.TabIndex = 46
        Me.pm_as_location.Text = "Location"
        '
        'pm_as_txtLocation
        '
        Me.pm_as_txtLocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_txtLocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_as_txtLocation.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_txtLocation.ForeColor = System.Drawing.Color.LightGray
        Me.pm_as_txtLocation.Location = New System.Drawing.Point(795, 339)
        Me.pm_as_txtLocation.MaxLength = 10
        Me.pm_as_txtLocation.Name = "pm_as_txtLocation"
        Me.pm_as_txtLocation.Size = New System.Drawing.Size(258, 27)
        Me.pm_as_txtLocation.TabIndex = 45
        Me.pm_as_txtLocation.Text = "Enter Location"
        '
        'pm_as_status
        '
        Me.pm_as_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_status.AutoSize = True
        Me.pm_as_status.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_status.ForeColor = System.Drawing.Color.White
        Me.pm_as_status.Location = New System.Drawing.Point(665, 286)
        Me.pm_as_status.Name = "pm_as_status"
        Me.pm_as_status.Size = New System.Drawing.Size(69, 30)
        Me.pm_as_status.TabIndex = 44
        Me.pm_as_status.Text = "Status"
        '
        'pm_as_totalValue
        '
        Me.pm_as_totalValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_totalValue.AutoSize = True
        Me.pm_as_totalValue.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_totalValue.ForeColor = System.Drawing.Color.White
        Me.pm_as_totalValue.Location = New System.Drawing.Point(665, 232)
        Me.pm_as_totalValue.Name = "pm_as_totalValue"
        Me.pm_as_totalValue.Size = New System.Drawing.Size(112, 30)
        Me.pm_as_totalValue.TabIndex = 42
        Me.pm_as_totalValue.Text = "Total Value"
        '
        'pm_as_txtTotalValue
        '
        Me.pm_as_txtTotalValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_txtTotalValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_as_txtTotalValue.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_txtTotalValue.ForeColor = System.Drawing.Color.LightGray
        Me.pm_as_txtTotalValue.Location = New System.Drawing.Point(795, 232)
        Me.pm_as_txtTotalValue.MaxLength = 100
        Me.pm_as_txtTotalValue.Name = "pm_as_txtTotalValue"
        Me.pm_as_txtTotalValue.Size = New System.Drawing.Size(258, 27)
        Me.pm_as_txtTotalValue.TabIndex = 41
        Me.pm_as_txtTotalValue.Text = "Enter Total Value"
        '
        'pm_as_unitCost
        '
        Me.pm_as_unitCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_unitCost.AutoSize = True
        Me.pm_as_unitCost.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_unitCost.ForeColor = System.Drawing.Color.White
        Me.pm_as_unitCost.Location = New System.Drawing.Point(665, 176)
        Me.pm_as_unitCost.Name = "pm_as_unitCost"
        Me.pm_as_unitCost.Size = New System.Drawing.Size(92, 30)
        Me.pm_as_unitCost.TabIndex = 40
        Me.pm_as_unitCost.Text = "Unit Cost"
        '
        'pm_as_txtUnitCost
        '
        Me.pm_as_txtUnitCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_as_txtUnitCost.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_as_txtUnitCost.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_txtUnitCost.ForeColor = System.Drawing.Color.LightGray
        Me.pm_as_txtUnitCost.Location = New System.Drawing.Point(795, 176)
        Me.pm_as_txtUnitCost.MaxLength = 100
        Me.pm_as_txtUnitCost.Name = "pm_as_txtUnitCost"
        Me.pm_as_txtUnitCost.Size = New System.Drawing.Size(258, 27)
        Me.pm_as_txtUnitCost.TabIndex = 39
        Me.pm_as_txtUnitCost.Text = "Enter Unit Cost"
        '
        'pm_as_stock
        '
        Me.pm_as_stock.AutoSize = True
        Me.pm_as_stock.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_stock.ForeColor = System.Drawing.Color.White
        Me.pm_as_stock.Location = New System.Drawing.Point(170, 337)
        Me.pm_as_stock.Name = "pm_as_stock"
        Me.pm_as_stock.Size = New System.Drawing.Size(61, 30)
        Me.pm_as_stock.TabIndex = 32
        Me.pm_as_stock.Text = "Stock"
        '
        'pm_as_category
        '
        Me.pm_as_category.AutoSize = True
        Me.pm_as_category.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_category.ForeColor = System.Drawing.Color.White
        Me.pm_as_category.Location = New System.Drawing.Point(166, 289)
        Me.pm_as_category.Name = "pm_as_category"
        Me.pm_as_category.Size = New System.Drawing.Size(95, 30)
        Me.pm_as_category.TabIndex = 30
        Me.pm_as_category.Text = "Category"
        '
        'pm_as_name
        '
        Me.pm_as_name.AutoSize = True
        Me.pm_as_name.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_name.ForeColor = System.Drawing.Color.White
        Me.pm_as_name.Location = New System.Drawing.Point(166, 235)
        Me.pm_as_name.Name = "pm_as_name"
        Me.pm_as_name.Size = New System.Drawing.Size(65, 30)
        Me.pm_as_name.TabIndex = 28
        Me.pm_as_name.Text = "Name"
        '
        'pm_as_txtName
        '
        Me.pm_as_txtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.pm_as_txtName.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_txtName.ForeColor = System.Drawing.Color.LightGray
        Me.pm_as_txtName.Location = New System.Drawing.Point(296, 235)
        Me.pm_as_txtName.MaxLength = 100
        Me.pm_as_txtName.Name = "pm_as_txtName"
        Me.pm_as_txtName.Size = New System.Drawing.Size(258, 27)
        Me.pm_as_txtName.TabIndex = 27
        Me.pm_as_txtName.Text = "Enter Name"
        '
        'pm_as_supplyID
        '
        Me.pm_as_supplyID.AutoSize = True
        Me.pm_as_supplyID.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pm_as_supplyID.ForeColor = System.Drawing.Color.White
        Me.pm_as_supplyID.Location = New System.Drawing.Point(166, 179)
        Me.pm_as_supplyID.Name = "pm_as_supplyID"
        Me.pm_as_supplyID.Size = New System.Drawing.Size(94, 30)
        Me.pm_as_supplyID.TabIndex = 26
        Me.pm_as_supplyID.Text = "Supply ID"
        '
        'um_as_txtSupplyID
        '
        Me.um_as_txtSupplyID.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.um_as_txtSupplyID.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.um_as_txtSupplyID.ForeColor = System.Drawing.Color.LightGray
        Me.um_as_txtSupplyID.Location = New System.Drawing.Point(296, 179)
        Me.um_as_txtSupplyID.MaxLength = 100
        Me.um_as_txtSupplyID.Name = "um_as_txtSupplyID"
        Me.um_as_txtSupplyID.Size = New System.Drawing.Size(258, 27)
        Me.um_as_txtSupplyID.TabIndex = 25
        Me.um_as_txtSupplyID.Text = "Enter Supply ID"
        '
        'uc_um_adminprofile
        '
        Me.uc_um_adminprofile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uc_um_adminprofile.AutoSize = True
        Me.uc_um_adminprofile.Font = New System.Drawing.Font("Poppins", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_um_adminprofile.ForeColor = System.Drawing.Color.White
        Me.uc_um_adminprofile.Location = New System.Drawing.Point(446, 72)
        Me.uc_um_adminprofile.Name = "uc_um_adminprofile"
        Me.uc_um_adminprofile.Size = New System.Drawing.Size(348, 50)
        Me.uc_um_adminprofile.TabIndex = 23
        Me.uc_um_adminprofile.Text = "Add Supply"
        '
        'UC_AddSupply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pm_as_propertyman)
        Me.Name = "UC_AddSupply"
        Me.Size = New System.Drawing.Size(1274, 766)
        Me.pm_as_propertyman.ResumeLayout(False)
        Me.pm_as_propertyman.PerformLayout()
        CType(Me.pm_as_numericStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pm_as_propertyman As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel
    Friend WithEvents pm_as_btnSave As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents pm_as_btnCancel As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents pm_as_location As Label
    Friend WithEvents pm_as_txtLocation As TextBox
    Friend WithEvents pm_as_status As Label
    Friend WithEvents pm_as_totalValue As Label
    Friend WithEvents pm_as_txtTotalValue As TextBox
    Friend WithEvents pm_as_unitCost As Label
    Friend WithEvents pm_as_txtUnitCost As TextBox
    Friend WithEvents pm_as_stock As Label
    Friend WithEvents pm_as_category As Label
    Friend WithEvents pm_as_name As Label
    Friend WithEvents pm_as_txtName As TextBox
    Friend WithEvents pm_as_supplyID As Label
    Friend WithEvents um_as_txtSupplyID As TextBox
    Friend WithEvents uc_um_adminprofile As Label
    Friend WithEvents pm_as_cmbobxCateg As ComboBox
    Friend WithEvents pm_as_cmbobxStatus As ComboBox
    Friend WithEvents pm_as_numericStock As NumericUpDown
End Class
