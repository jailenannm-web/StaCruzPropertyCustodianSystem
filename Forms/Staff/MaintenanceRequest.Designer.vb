<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaintenanceRequest


    'UserControl overrides dispose to clean up the component list.
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
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.RoundedButton1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.maintenancerequestssearchbar = New System.Windows.Forms.TextBox()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pm_cbobx_categ = New System.Windows.Forms.ComboBox()
        Me.btnGenerateMaintenance = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(15, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(301, 42)
        Me.Label3.TabIndex = 174
        Me.Label3.Text = "Maintenance Requests"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PropertID, Me.PropertyName, Me.Category, Me.Description, Me.SerialNumber, Me.AcquisitionDate, Me.AcquisitionCost, Me.Supplier, Me.ConditionStatus})
        Me.DataGridView1.Location = New System.Drawing.Point(22, 171)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(889, 460)
        Me.DataGridView1.TabIndex = 173
        '
        'PropertID
        '
        Me.PropertID.HeaderText = "Property/Item Name"
        Me.PropertID.MinimumWidth = 6
        Me.PropertID.Name = "PropertID"
        Me.PropertID.Width = 180
        '
        'PropertyName
        '
        Me.PropertyName.HeaderText = "Serial No."
        Me.PropertyName.MinimumWidth = 6
        Me.PropertyName.Name = "PropertyName"
        Me.PropertyName.Width = 125
        '
        'Category
        '
        Me.Category.HeaderText = "Location"
        Me.Category.MinimumWidth = 6
        Me.Category.Name = "Category"
        Me.Category.Width = 125
        '
        'Description
        '
        Me.Description.HeaderText = "Department"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        Me.Description.Width = 150
        '
        'SerialNumber
        '
        Me.SerialNumber.HeaderText = "Condition Before Maintenance"
        Me.SerialNumber.MinimumWidth = 6
        Me.SerialNumber.Name = "SerialNumber"
        Me.SerialNumber.Width = 175
        '
        'AcquisitionDate
        '
        Me.AcquisitionDate.HeaderText = "Type of Issue"
        Me.AcquisitionDate.MinimumWidth = 6
        Me.AcquisitionDate.Name = "AcquisitionDate"
        Me.AcquisitionDate.Width = 175
        '
        'AcquisitionCost
        '
        Me.AcquisitionCost.HeaderText = "Problem Description"
        Me.AcquisitionCost.MinimumWidth = 6
        Me.AcquisitionCost.Name = "AcquisitionCost"
        Me.AcquisitionCost.Width = 200
        '
        'Supplier
        '
        Me.Supplier.HeaderText = "Maintenance Date"
        Me.Supplier.MinimumWidth = 6
        Me.Supplier.Name = "Supplier"
        Me.Supplier.Width = 150
        '
        'ConditionStatus
        '
        Me.ConditionStatus.HeaderText = "Status"
        Me.ConditionStatus.MinimumWidth = 6
        Me.ConditionStatus.Name = "ConditionStatus"
        Me.ConditionStatus.Width = 125
        '
        'RoundedButton1
        '
        Me.RoundedButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton1.Location = New System.Drawing.Point(707, 642)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(207, 32)
        Me.RoundedButton1.TabIndex = 177
        Me.RoundedButton1.Text = "Add Maintenance Request"
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'maintenancerequestssearchbar
        '
        Me.maintenancerequestssearchbar.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.maintenancerequestssearchbar.Location = New System.Drawing.Point(15, 41)
        Me.maintenancerequestssearchbar.Name = "maintenancerequestssearchbar"
        Me.maintenancerequestssearchbar.Size = New System.Drawing.Size(226, 25)
        Me.maintenancerequestssearchbar.TabIndex = 181
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.Black
        Me.pm_cbobx_status.Location = New System.Drawing.Point(448, 41)
        Me.pm_cbobx_status.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(136, 30)
        Me.pm_cbobx_status.TabIndex = 179
        '
        'pm_cbobx_categ
        '
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.Black
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(260, 41)
        Me.pm_cbobx_categ.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(151, 30)
        Me.pm_cbobx_categ.TabIndex = 180
        '
        'btnGenerateMaintenance
        '
        Me.btnGenerateMaintenance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateMaintenance.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnGenerateMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateMaintenance.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold)
        Me.btnGenerateMaintenance.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateMaintenance.Location = New System.Drawing.Point(470, 642)
        Me.btnGenerateMaintenance.Name = "btnGenerateMaintenance"
        Me.btnGenerateMaintenance.Size = New System.Drawing.Size(222, 32)
        Me.btnGenerateMaintenance.TabIndex = 183
        Me.btnGenerateMaintenance.Text = "Generate Maintenance Report"
        Me.btnGenerateMaintenance.UseVisualStyleBackColor = False
        '
        'pnlFilters
        '
        Me.pnlFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilters.Controls.Add(Me.lblStatus)
        Me.pnlFilters.Controls.Add(Me.lblCategory)
        Me.pnlFilters.Controls.Add(Me.maintenancerequestssearchbar)
        Me.pnlFilters.Controls.Add(Me.pm_cbobx_status)
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Controls.Add(Me.pm_cbobx_categ)
        Me.pnlFilters.Location = New System.Drawing.Point(23, 74)
        Me.pnlFilters.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(11, 12, 11, 12)
        Me.pnlFilters.Size = New System.Drawing.Size(895, 82)
        Me.pnlFilters.TabIndex = 184
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(442, 17)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(43, 19)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Text = "Status"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCategory.Location = New System.Drawing.Point(255, 16)
        Me.lblCategory.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(59, 19)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Category"
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(15, 16)
        Me.lblSearch.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(122, 19)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search Maintenance"
        '
        'MaintenanceRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnGenerateMaintenance)
        Me.Controls.Add(Me.RoundedButton1)
        Me.Controls.Add(Me.Label3)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "MaintenanceRequest"
        Me.Size = New System.Drawing.Size(938, 722)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PropertID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PropertyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcquisitionDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AcquisitionCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Supplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConditionStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Protected Friend WithEvents RoundedButton1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents maintenancerequestssearchbar As System.Windows.Forms.TextBox
    Friend WithEvents pm_cbobx_status As System.Windows.Forms.ComboBox
    Friend WithEvents pm_cbobx_categ As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerateMaintenance As Resources.Controls.RoundedButton
    Friend WithEvents pnlFilters As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
End Class
