Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PropertyInventory
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
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.cboCondition = New System.Windows.Forms.ComboBox()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dgvProperties = New System.Windows.Forms.DataGridView()
        Me.colPropertyId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPropertyNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSerialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCondition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAssignedTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAcquisitionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAcquisitionCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSourceOfFunds = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnRequest = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        CType(Me.dgvProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.Controls.Add(Me.btnRequest)
        Me.pnlMain.Controls.Add(Me.lblTotal)
        Me.pnlMain.Controls.Add(Me.dgvProperties)
        Me.pnlMain.Controls.Add(Me.pnlFilters)
        Me.pnlMain.Controls.Add(Me.lblTitle)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlMain.Size = New System.Drawing.Size(1251, 889)
        Me.pnlMain.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(310, 53)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Property Inventory"
        '
        'pnlFilters
        '
        Me.pnlFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFilters.Controls.Add(Me.btnRefresh)
        Me.pnlFilters.Controls.Add(Me.lblStatus)
        Me.pnlFilters.Controls.Add(Me.cboStatus)
        Me.pnlFilters.Controls.Add(Me.lblCondition)
        Me.pnlFilters.Controls.Add(Me.cboCondition)
        Me.pnlFilters.Controls.Add(Me.lblCategory)
        Me.pnlFilters.Controls.Add(Me.cboCategory)
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Controls.Add(Me.txtSearch)
        Me.pnlFilters.Location = New System.Drawing.Point(30, 90)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlFilters.Size = New System.Drawing.Size(1191, 100)
        Me.pnlFilters.TabIndex = 1
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.txtSearch.Location = New System.Drawing.Point(20, 45)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(300, 30)
        Me.txtSearch.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(20, 20)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(128, 23)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search Properties"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(340, 45)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(200, 34)
        Me.cboCategory.TabIndex = 3
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCategory.Location = New System.Drawing.Point(340, 20)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(70, 23)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Category"
        '
        'cboCondition
        '
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboCondition.FormattingEnabled = True
        Me.cboCondition.Location = New System.Drawing.Point(560, 45)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(180, 34)
        Me.cboCondition.TabIndex = 5
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblCondition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCondition.Location = New System.Drawing.Point(560, 20)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(75, 23)
        Me.lblCondition.TabIndex = 4
        Me.lblCondition.Text = "Condition"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(760, 45)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(180, 34)
        Me.cboStatus.TabIndex = 7
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Poppins", 8.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(760, 20)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(51, 23)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Text = "Status"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(960, 40)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(120, 40)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'dgvProperties
        '
        Me.dgvProperties.AllowUserToAddRows = False
        Me.dgvProperties.AllowUserToDeleteRows = False
        Me.dgvProperties.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProperties.BackgroundColor = System.Drawing.Color.White
        Me.dgvProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProperties.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPropertyId, Me.colItemName, Me.colCategory, Me.colDescription, Me.colPropertyNumber, Me.colSerialNumber, Me.colLocation, Me.colCondition, Me.colStatus, Me.colAssignedTo, Me.colDepartment, Me.colAcquisitionDate, Me.colAcquisitionCost, Me.colSourceOfFunds})
        Me.dgvProperties.Location = New System.Drawing.Point(30, 210)
        Me.dgvProperties.MultiSelect = False
        Me.dgvProperties.Name = "dgvProperties"
        Me.dgvProperties.ReadOnly = True
        Me.dgvProperties.RowHeadersWidth = 51
        Me.dgvProperties.RowTemplate.Height = 30
        Me.dgvProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProperties.Size = New System.Drawing.Size(1191, 570)
        Me.dgvProperties.TabIndex = 2
        '
        'colPropertyId
        '
        Me.colPropertyId.HeaderText = "Property ID"
        Me.colPropertyId.MinimumWidth = 6
        Me.colPropertyId.Name = "colPropertyId"
        Me.colPropertyId.ReadOnly = True
        Me.colPropertyId.Visible = False
        Me.colPropertyId.Width = 100
        '
        'colItemName
        '
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.MinimumWidth = 6
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 200
        '
        'colCategory
        '
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.MinimumWidth = 6
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        Me.colCategory.Width = 150
        '
        'colDescription
        '
        Me.colDescription.HeaderText = "Description"
        Me.colDescription.MinimumWidth = 6
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        Me.colDescription.Width = 250
        '
        'colPropertyNumber
        '
        Me.colPropertyNumber.HeaderText = "Property #"
        Me.colPropertyNumber.MinimumWidth = 6
        Me.colPropertyNumber.Name = "colPropertyNumber"
        Me.colPropertyNumber.ReadOnly = True
        Me.colPropertyNumber.Width = 120
        '
        'colSerialNumber
        '
        Me.colSerialNumber.HeaderText = "Serial #"
        Me.colSerialNumber.MinimumWidth = 6
        Me.colSerialNumber.Name = "colSerialNumber"
        Me.colSerialNumber.ReadOnly = True
        Me.colSerialNumber.Width = 120
        '
        'colLocation
        '
        Me.colLocation.HeaderText = "Location"
        Me.colLocation.MinimumWidth = 6
        Me.colLocation.Name = "colLocation"
        Me.colLocation.ReadOnly = True
        Me.colLocation.Width = 150
        '
        'colCondition
        '
        Me.colCondition.HeaderText = "Condition"
        Me.colCondition.MinimumWidth = 6
        Me.colCondition.Name = "colCondition"
        Me.colCondition.ReadOnly = True
        Me.colCondition.Width = 120
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.MinimumWidth = 6
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        Me.colStatus.Width = 120
        '
        'colAssignedTo
        '
        Me.colAssignedTo.HeaderText = "Assigned To"
        Me.colAssignedTo.MinimumWidth = 6
        Me.colAssignedTo.Name = "colAssignedTo"
        Me.colAssignedTo.ReadOnly = True
        Me.colAssignedTo.Width = 150
        '
        'colDepartment
        '
        Me.colDepartment.HeaderText = "Department"
        Me.colDepartment.MinimumWidth = 6
        Me.colDepartment.Name = "colDepartment"
        Me.colDepartment.ReadOnly = True
        Me.colDepartment.Width = 150
        '
        'colAcquisitionDate
        '
        Me.colAcquisitionDate.HeaderText = "Acquisition Date"
        Me.colAcquisitionDate.MinimumWidth = 6
        Me.colAcquisitionDate.Name = "colAcquisitionDate"
        Me.colAcquisitionDate.ReadOnly = True
        Me.colAcquisitionDate.Visible = False
        Me.colAcquisitionDate.Width = 130
        '
        'colAcquisitionCost
        '
        Me.colAcquisitionCost.HeaderText = "Acquisition Cost"
        Me.colAcquisitionCost.MinimumWidth = 6
        Me.colAcquisitionCost.Name = "colAcquisitionCost"
        Me.colAcquisitionCost.ReadOnly = True
        Me.colAcquisitionCost.Visible = False
        Me.colAcquisitionCost.Width = 130
        '
        'colSourceOfFunds
        '
        Me.colSourceOfFunds.HeaderText = "Source Of Funds"
        Me.colSourceOfFunds.MinimumWidth = 6
        Me.colSourceOfFunds.Name = "colSourceOfFunds"
        Me.colSourceOfFunds.ReadOnly = True
        Me.colSourceOfFunds.Visible = False
        Me.colSourceOfFunds.Width = 150
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(30, 800)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(194, 30)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "Total Properties: 0"
        '
        'btnRequest
        '
        Me.btnRequest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRequest.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnRequest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRequest.FlatAppearance.BorderSize = 0
        Me.btnRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRequest.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRequest.ForeColor = System.Drawing.Color.White
        Me.btnRequest.Location = New System.Drawing.Point(1041, 795)
        Me.btnRequest.Name = "btnRequest"
        Me.btnRequest.Size = New System.Drawing.Size(180, 45)
        Me.btnRequest.TabIndex = 4
        Me.btnRequest.Text = "Request Property"
        Me.btnRequest.UseVisualStyleBackColor = False
        '
        'PropertyInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "PropertyInventory"
        Me.Size = New System.Drawing.Size(1251, 889)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        CType(Me.dgvProperties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents cboCondition As ComboBox
    Friend WithEvents lblCondition As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dgvProperties As DataGridView
    Friend WithEvents colPropertyId As DataGridViewTextBoxColumn
    Friend WithEvents colItemName As DataGridViewTextBoxColumn
    Friend WithEvents colCategory As DataGridViewTextBoxColumn
    Friend WithEvents colDescription As DataGridViewTextBoxColumn
    Friend WithEvents colPropertyNumber As DataGridViewTextBoxColumn
    Friend WithEvents colSerialNumber As DataGridViewTextBoxColumn
    Friend WithEvents colLocation As DataGridViewTextBoxColumn
    Friend WithEvents colCondition As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents colAssignedTo As DataGridViewTextBoxColumn
    Friend WithEvents colDepartment As DataGridViewTextBoxColumn
    Friend WithEvents colAcquisitionDate As DataGridViewTextBoxColumn
    Friend WithEvents colAcquisitionCost As DataGridViewTextBoxColumn
    Friend WithEvents colSourceOfFunds As DataGridViewTextBoxColumn
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnRequest As Button
End Class
