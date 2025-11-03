Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DashBoard
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_Logout = New System.Windows.Forms.Button()
        Me.btn_SystemConfiguration = New System.Windows.Forms.Button()
        Me.btn_Reports = New System.Windows.Forms.Button()
        Me.btn_MaintenanceManagement = New System.Windows.Forms.Button()
        Me.btn_PropertyRequestManagement = New System.Windows.Forms.Button()
        Me.btn_DepartmentManagement = New System.Windows.Forms.Button()
        Me.btn_SuppliesManagement = New System.Windows.Forms.Button()
        Me.btn_PropertyManagement = New System.Windows.Forms.Button()
        Me.btn_UserManagement = New System.Windows.Forms.Button()
        Me.btn_DashBoard = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Add = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
        Me.btn_AddUser = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
        Me.txb_Username = New System.Windows.Forms.TextBox()
        Me.RoundedButton1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
        Me.btn_AddSupply = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
        Me.btn_GenerateReport = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
        Me.comboCategory = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btn_Logout)
        Me.Panel1.Controls.Add(Me.btn_SystemConfiguration)
        Me.Panel1.Controls.Add(Me.btn_Reports)
        Me.Panel1.Controls.Add(Me.btn_MaintenanceManagement)
        Me.Panel1.Controls.Add(Me.btn_PropertyRequestManagement)
        Me.Panel1.Controls.Add(Me.btn_DepartmentManagement)
        Me.Panel1.Controls.Add(Me.btn_SuppliesManagement)
        Me.Panel1.Controls.Add(Me.btn_PropertyManagement)
        Me.Panel1.Controls.Add(Me.btn_UserManagement)
        Me.Panel1.Controls.Add(Me.btn_DashBoard)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(323, 767)
        Me.Panel1.TabIndex = 0
        '
        'btn_Logout
        '
        Me.btn_Logout.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Logout.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Logout.ForeColor = System.Drawing.Color.White
        Me.btn_Logout.Location = New System.Drawing.Point(0, 614)
        Me.btn_Logout.Name = "btn_Logout"
        Me.btn_Logout.Size = New System.Drawing.Size(323, 42)
        Me.btn_Logout.TabIndex = 10
        Me.btn_Logout.Text = "Logout"
        Me.btn_Logout.UseVisualStyleBackColor = False
        '
        'btn_SystemConfiguration
        '
        Me.btn_SystemConfiguration.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_SystemConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_SystemConfiguration.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SystemConfiguration.ForeColor = System.Drawing.Color.White
        Me.btn_SystemConfiguration.Location = New System.Drawing.Point(0, 566)
        Me.btn_SystemConfiguration.Name = "btn_SystemConfiguration"
        Me.btn_SystemConfiguration.Size = New System.Drawing.Size(323, 42)
        Me.btn_SystemConfiguration.TabIndex = 9
        Me.btn_SystemConfiguration.Text = "System Configuration"
        Me.btn_SystemConfiguration.UseVisualStyleBackColor = False
        '
        'btn_Reports
        '
        Me.btn_Reports.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Reports.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Reports.ForeColor = System.Drawing.Color.White
        Me.btn_Reports.Location = New System.Drawing.Point(0, 518)
        Me.btn_Reports.Name = "btn_Reports"
        Me.btn_Reports.Size = New System.Drawing.Size(323, 42)
        Me.btn_Reports.TabIndex = 8
        Me.btn_Reports.Text = "Reports"
        Me.btn_Reports.UseVisualStyleBackColor = False
        '
        'btn_MaintenanceManagement
        '
        Me.btn_MaintenanceManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_MaintenanceManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_MaintenanceManagement.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_MaintenanceManagement.ForeColor = System.Drawing.Color.White
        Me.btn_MaintenanceManagement.Location = New System.Drawing.Point(0, 470)
        Me.btn_MaintenanceManagement.Name = "btn_MaintenanceManagement"
        Me.btn_MaintenanceManagement.Size = New System.Drawing.Size(323, 42)
        Me.btn_MaintenanceManagement.TabIndex = 7
        Me.btn_MaintenanceManagement.Text = "Maintenance Management"
        Me.btn_MaintenanceManagement.UseVisualStyleBackColor = False
        '
        'btn_PropertyRequestManagement
        '
        Me.btn_PropertyRequestManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_PropertyRequestManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_PropertyRequestManagement.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_PropertyRequestManagement.ForeColor = System.Drawing.Color.White
        Me.btn_PropertyRequestManagement.Location = New System.Drawing.Point(0, 422)
        Me.btn_PropertyRequestManagement.Name = "btn_PropertyRequestManagement"
        Me.btn_PropertyRequestManagement.Size = New System.Drawing.Size(323, 42)
        Me.btn_PropertyRequestManagement.TabIndex = 6
        Me.btn_PropertyRequestManagement.Text = "Property Request Management"
        Me.btn_PropertyRequestManagement.UseVisualStyleBackColor = False
        '
        'btn_DepartmentManagement
        '
        Me.btn_DepartmentManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_DepartmentManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DepartmentManagement.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DepartmentManagement.ForeColor = System.Drawing.Color.White
        Me.btn_DepartmentManagement.Location = New System.Drawing.Point(0, 374)
        Me.btn_DepartmentManagement.Name = "btn_DepartmentManagement"
        Me.btn_DepartmentManagement.Size = New System.Drawing.Size(323, 42)
        Me.btn_DepartmentManagement.TabIndex = 5
        Me.btn_DepartmentManagement.Text = "Department Management"
        Me.btn_DepartmentManagement.UseVisualStyleBackColor = False
        '
        'btn_SuppliesManagement
        '
        Me.btn_SuppliesManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_SuppliesManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_SuppliesManagement.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SuppliesManagement.ForeColor = System.Drawing.Color.White
        Me.btn_SuppliesManagement.Location = New System.Drawing.Point(0, 326)
        Me.btn_SuppliesManagement.Name = "btn_SuppliesManagement"
        Me.btn_SuppliesManagement.Size = New System.Drawing.Size(323, 42)
        Me.btn_SuppliesManagement.TabIndex = 4
        Me.btn_SuppliesManagement.Text = "Supplies Management"
        Me.btn_SuppliesManagement.UseVisualStyleBackColor = False
        '
        'btn_PropertyManagement
        '
        Me.btn_PropertyManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_PropertyManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_PropertyManagement.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_PropertyManagement.ForeColor = System.Drawing.Color.White
        Me.btn_PropertyManagement.Location = New System.Drawing.Point(0, 278)
        Me.btn_PropertyManagement.Name = "btn_PropertyManagement"
        Me.btn_PropertyManagement.Size = New System.Drawing.Size(323, 42)
        Me.btn_PropertyManagement.TabIndex = 3
        Me.btn_PropertyManagement.Text = "Property Management"
        Me.btn_PropertyManagement.UseVisualStyleBackColor = False
        '
        'btn_UserManagement
        '
        Me.btn_UserManagement.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_UserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_UserManagement.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_UserManagement.ForeColor = System.Drawing.Color.White
        Me.btn_UserManagement.Location = New System.Drawing.Point(0, 230)
        Me.btn_UserManagement.Name = "btn_UserManagement"
        Me.btn_UserManagement.Size = New System.Drawing.Size(323, 42)
        Me.btn_UserManagement.TabIndex = 2
        Me.btn_UserManagement.Text = "User Management"
        Me.btn_UserManagement.UseVisualStyleBackColor = False
        '
        'btn_DashBoard
        '
        Me.btn_DashBoard.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_DashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DashBoard.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DashBoard.ForeColor = System.Drawing.Color.White
        Me.btn_DashBoard.Location = New System.Drawing.Point(0, 182)
        Me.btn_DashBoard.Name = "btn_DashBoard"
        Me.btn_DashBoard.Size = New System.Drawing.Size(323, 42)
        Me.btn_DashBoard.TabIndex = 1
        Me.btn_DashBoard.Text = "DashBoard"
        Me.btn_DashBoard.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(74, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Super Admin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(348, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(312, 84)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "DashBoard"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins Medium", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(329, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 48)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Search"
        '
        'btn_Add
        '
        Me.btn_Add.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_Add.CornerRadius = 15
        Me.btn_Add.FlatAppearance.BorderSize = 0
        Me.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Add.ForeColor = System.Drawing.Color.White
        Me.btn_Add.Location = New System.Drawing.Point(980, 145)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(143, 37)
        Me.btn_Add.TabIndex = 15
        Me.btn_Add.Text = "Add Property"
        Me.btn_Add.UseVisualStyleBackColor = False
        '
        'btn_AddUser
        '
        Me.btn_AddUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_AddUser.CornerRadius = 15
        Me.btn_AddUser.FlatAppearance.BorderSize = 0
        Me.btn_AddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_AddUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AddUser.ForeColor = System.Drawing.Color.White
        Me.btn_AddUser.Location = New System.Drawing.Point(1141, 145)
        Me.btn_AddUser.Name = "btn_AddUser"
        Me.btn_AddUser.Size = New System.Drawing.Size(138, 37)
        Me.btn_AddUser.TabIndex = 16
        Me.btn_AddUser.Text = "Add User"
        Me.btn_AddUser.UseVisualStyleBackColor = False
        '
        'txb_Username
        '
        Me.txb_Username.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.txb_Username.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txb_Username.Font = New System.Drawing.Font("Poppins", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_Username.ForeColor = System.Drawing.Color.White
        Me.txb_Username.Location = New System.Drawing.Point(450, 145)
        Me.txb_Username.Multiline = True
        Me.txb_Username.Name = "txb_Username"
        Me.txb_Username.Size = New System.Drawing.Size(332, 34)
        Me.txb_Username.TabIndex = 17
        '
        'RoundedButton1
        '
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.CornerRadius = 15
        Me.RoundedButton1.FlatAppearance.BorderSize = 0
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton1.ForeColor = System.Drawing.Color.White
        Me.RoundedButton1.Location = New System.Drawing.Point(811, 144)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(136, 37)
        Me.RoundedButton1.TabIndex = 18
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'btn_AddSupply
        '
        Me.btn_AddSupply.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_AddSupply.CornerRadius = 15
        Me.btn_AddSupply.FlatAppearance.BorderSize = 0
        Me.btn_AddSupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_AddSupply.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AddSupply.ForeColor = System.Drawing.Color.White
        Me.btn_AddSupply.Location = New System.Drawing.Point(1299, 145)
        Me.btn_AddSupply.Name = "btn_AddSupply"
        Me.btn_AddSupply.Size = New System.Drawing.Size(138, 37)
        Me.btn_AddSupply.TabIndex = 19
        Me.btn_AddSupply.Text = "Add Supply"
        Me.btn_AddSupply.UseVisualStyleBackColor = False
        '
        'btn_GenerateReport
        '
        Me.btn_GenerateReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btn_GenerateReport.CornerRadius = 15
        Me.btn_GenerateReport.FlatAppearance.BorderSize = 0
        Me.btn_GenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_GenerateReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GenerateReport.ForeColor = System.Drawing.Color.White
        Me.btn_GenerateReport.Location = New System.Drawing.Point(1452, 145)
        Me.btn_GenerateReport.Name = "btn_GenerateReport"
        Me.btn_GenerateReport.Size = New System.Drawing.Size(160, 37)
        Me.btn_GenerateReport.TabIndex = 20
        Me.btn_GenerateReport.Text = "Generate Report"
        Me.btn_GenerateReport.UseVisualStyleBackColor = False
        '
        'comboCategory
        '
        Me.comboCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.comboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comboCategory.FormattingEnabled = True
        Me.comboCategory.Location = New System.Drawing.Point(811, 155)
        Me.comboCategory.Name = "comboCategory"
        Me.comboCategory.Size = New System.Drawing.Size(131, 21)
        Me.comboCategory.TabIndex = 21
        '
        'DashBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1614, 891)
        Me.ControlBox = False
        Me.Controls.Add(Me.comboCategory)
        Me.Controls.Add(Me.btn_GenerateReport)
        Me.Controls.Add(Me.btn_AddSupply)
        Me.Controls.Add(Me.RoundedButton1)
        Me.Controls.Add(Me.txb_Username)
        Me.Controls.Add(Me.btn_AddUser)
        Me.Controls.Add(Me.btn_Add)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "DashBoard"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "D"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_DashBoard As System.Windows.Forms.Button
    Friend WithEvents btn_Logout As System.Windows.Forms.Button
    Friend WithEvents btn_SystemConfiguration As System.Windows.Forms.Button
    Friend WithEvents btn_Reports As System.Windows.Forms.Button
    Friend WithEvents btn_MaintenanceManagement As System.Windows.Forms.Button
    Friend WithEvents btn_PropertyRequestManagement As System.Windows.Forms.Button
    Friend WithEvents btn_DepartmentManagement As System.Windows.Forms.Button
    Friend WithEvents btn_SuppliesManagement As System.Windows.Forms.Button
    Friend WithEvents btn_PropertyManagement As System.Windows.Forms.Button
    Friend WithEvents btn_UserManagement As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Add As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btn_AddUser As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton

    Friend WithEvents txb_Username As System.Windows.Forms.TextBox
    Friend WithEvents RoundedButton1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btn_AddSupply As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btn_GenerateReport As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents comboCategory As System.Windows.Forms.ComboBox
End Class
