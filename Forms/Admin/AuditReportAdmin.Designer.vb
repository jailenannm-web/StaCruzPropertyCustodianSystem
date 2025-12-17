Imports System.Windows.Forms
Imports System.Drawing

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AuditReportAdmin
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblUserRole = New System.Windows.Forms.Label()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.lblLogID = New System.Windows.Forms.Label()
        Me.lblAction = New System.Windows.Forms.Label()
        Me.lblTableName = New System.Windows.Forms.Label()
        Me.lblRecordID = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblIPAddress = New System.Windows.Forms.Label()
        Me.lblUserAgent = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtUserRole = New System.Windows.Forms.TextBox()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.txtLogID = New System.Windows.Forms.TextBox()
        Me.txtAction = New System.Windows.Forms.TextBox()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.txtRecordID = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtIPAddress = New System.Windows.Forms.TextBox()
        Me.txtUserAgent = New System.Windows.Forms.TextBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnGenerateCSV = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnGeneratePDF = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(400, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(200, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "AUDIT REPORT"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.Location = New System.Drawing.Point(50, 80)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(50, 18)
        Me.lblFrom.TabIndex = 1
        Me.lblFrom.Text = "From :"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.Location = New System.Drawing.Point(350, 80)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(35, 18)
        Me.lblTo.TabIndex = 2
        Me.lblTo.Text = "To :"
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(110, 78)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(220, 24)
        Me.dtpFrom.TabIndex = 3
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(390, 78)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(220, 24)
        Me.dtpTo.TabIndex = 4
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(50, 130)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(50, 18)
        Me.lblUserName.TabIndex = 5
        Me.lblUserName.Text = "User :"
        '
        'lblUserRole
        '
        Me.lblUserRole.AutoSize = True
        Me.lblUserRole.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserRole.Location = New System.Drawing.Point(50, 170)
        Me.lblUserRole.Name = "lblUserRole"
        Me.lblUserRole.Size = New System.Drawing.Size(45, 18)
        Me.lblUserRole.TabIndex = 6
        Me.lblUserRole.Text = "Role :"
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserID.Location = New System.Drawing.Point(50, 210)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(65, 18)
        Me.lblUserID.TabIndex = 7
        Me.lblUserID.Text = "User ID :"
        '
        'lblLogID
        '
        Me.lblLogID.AutoSize = True
        Me.lblLogID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogID.Location = New System.Drawing.Point(50, 250)
        Me.lblLogID.Name = "lblLogID"
        Me.lblLogID.Size = New System.Drawing.Size(60, 18)
        Me.lblLogID.TabIndex = 8
        Me.lblLogID.Text = "Log ID :"
        '
        'lblAction
        '
        Me.lblAction.AutoSize = True
        Me.lblAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAction.Location = New System.Drawing.Point(50, 290)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.Size = New System.Drawing.Size(55, 18)
        Me.lblAction.TabIndex = 9
        Me.lblAction.Text = "Action :"
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableName.Location = New System.Drawing.Point(50, 330)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(95, 18)
        Me.lblTableName.TabIndex = 10
        Me.lblTableName.Text = "Table Name :"
        '
        'lblRecordID
        '
        Me.lblRecordID.AutoSize = True
        Me.lblRecordID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordID.Location = New System.Drawing.Point(50, 370)
        Me.lblRecordID.Name = "lblRecordID"
        Me.lblRecordID.Size = New System.Drawing.Size(80, 18)
        Me.lblRecordID.TabIndex = 11
        Me.lblRecordID.Text = "Record ID :"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(50, 410)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(90, 18)
        Me.lblDescription.TabIndex = 12
        Me.lblDescription.Text = "Description :"
        '
        'lblIPAddress
        '
        Me.lblIPAddress.AutoSize = True
        Me.lblIPAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIPAddress.Location = New System.Drawing.Point(50, 490)
        Me.lblIPAddress.Name = "lblIPAddress"
        Me.lblIPAddress.Size = New System.Drawing.Size(85, 18)
        Me.lblIPAddress.TabIndex = 13
        Me.lblIPAddress.Text = "IP Address :"
        '
        'lblUserAgent
        '
        Me.lblUserAgent.AutoSize = True
        Me.lblUserAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserAgent.Location = New System.Drawing.Point(50, 530)
        Me.lblUserAgent.Name = "lblUserAgent"
        Me.lblUserAgent.Size = New System.Drawing.Size(90, 18)
        Me.lblUserAgent.TabIndex = 14
        Me.lblUserAgent.Text = "User Agent :"
        '
        'txtUserName
        '
        Me.txtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(150, 128)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(300, 24)
        Me.txtUserName.TabIndex = 15
        '
        'txtUserRole
        '
        Me.txtUserRole.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserRole.Location = New System.Drawing.Point(150, 168)
        Me.txtUserRole.Name = "txtUserRole"
        Me.txtUserRole.Size = New System.Drawing.Size(300, 24)
        Me.txtUserRole.TabIndex = 16
        '
        'txtUserID
        '
        Me.txtUserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.Location = New System.Drawing.Point(150, 208)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(300, 24)
        Me.txtUserID.TabIndex = 17
        '
        'txtLogID
        '
        Me.txtLogID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogID.Location = New System.Drawing.Point(150, 248)
        Me.txtLogID.Name = "txtLogID"
        Me.txtLogID.Size = New System.Drawing.Size(300, 24)
        Me.txtLogID.TabIndex = 18
        '
        'txtAction
        '
        Me.txtAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAction.Location = New System.Drawing.Point(150, 288)
        Me.txtAction.Name = "txtAction"
        Me.txtAction.Size = New System.Drawing.Size(300, 24)
        Me.txtAction.TabIndex = 19
        '
        'txtTableName
        '
        Me.txtTableName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTableName.Location = New System.Drawing.Point(150, 328)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(300, 24)
        Me.txtTableName.TabIndex = 20
        '
        'txtRecordID
        '
        Me.txtRecordID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecordID.Location = New System.Drawing.Point(150, 368)
        Me.txtRecordID.Name = "txtRecordID"
        Me.txtRecordID.Size = New System.Drawing.Size(300, 24)
        Me.txtRecordID.TabIndex = 21
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(150, 408)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(600, 70)
        Me.txtDescription.TabIndex = 22
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIPAddress.Location = New System.Drawing.Point(150, 488)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(300, 24)
        Me.txtIPAddress.TabIndex = 23
        '
        'txtUserAgent
        '
        Me.txtUserAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserAgent.Location = New System.Drawing.Point(150, 528)
        Me.txtUserAgent.Name = "txtUserAgent"
        Me.txtUserAgent.Size = New System.Drawing.Size(600, 24)
        Me.txtUserAgent.TabIndex = 24
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBack.Location = New System.Drawing.Point(50, 600)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(120, 35)
        Me.btnBack.TabIndex = 25
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnGenerateCSV
        '
        Me.btnGenerateCSV.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnGenerateCSV.CornerRadius = 15
        Me.btnGenerateCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateCSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateCSV.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateCSV.Location = New System.Drawing.Point(530, 600)
        Me.btnGenerateCSV.Name = "btnGenerateCSV"
        Me.btnGenerateCSV.Size = New System.Drawing.Size(160, 35)
        Me.btnGenerateCSV.TabIndex = 26
        Me.btnGenerateCSV.Text = "Generate CSV File"
        Me.btnGenerateCSV.UseVisualStyleBackColor = False
        '
        'btnGeneratePDF
        '
        Me.btnGeneratePDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnGeneratePDF.CornerRadius = 15
        Me.btnGeneratePDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGeneratePDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGeneratePDF.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGeneratePDF.Location = New System.Drawing.Point(700, 600)
        Me.btnGeneratePDF.Name = "btnGeneratePDF"
        Me.btnGeneratePDF.Size = New System.Drawing.Size(160, 35)
        Me.btnGeneratePDF.TabIndex = 27
        Me.btnGeneratePDF.Text = "Generate PDF File"
        Me.btnGeneratePDF.UseVisualStyleBackColor = False
        '
        'auditreport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 680)
        Me.Controls.Add(Me.btnGeneratePDF)
        Me.Controls.Add(Me.btnGenerateCSV)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.txtUserAgent)
        Me.Controls.Add(Me.txtIPAddress)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtRecordID)
        Me.Controls.Add(Me.txtTableName)
        Me.Controls.Add(Me.txtAction)
        Me.Controls.Add(Me.txtLogID)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.txtUserRole)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.lblUserAgent)
        Me.Controls.Add(Me.lblIPAddress)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblRecordID)
        Me.Controls.Add(Me.lblTableName)
        Me.Controls.Add(Me.lblAction)
        Me.Controls.Add(Me.lblLogID)
        Me.Controls.Add(Me.lblUserID)
        Me.Controls.Add(Me.lblUserRole)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AuditReportAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Audit Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblFrom As Label
    Friend WithEvents lblTo As Label
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents lblUserName As Label
    Friend WithEvents lblUserRole As Label
    Friend WithEvents lblUserID As Label
    Friend WithEvents lblLogID As Label
    Friend WithEvents lblAction As Label
    Friend WithEvents lblTableName As Label
    Friend WithEvents lblRecordID As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblIPAddress As Label
    Friend WithEvents lblUserAgent As Label
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents txtUserRole As TextBox
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents txtLogID As TextBox
    Friend WithEvents txtAction As TextBox
    Friend WithEvents txtTableName As TextBox
    Friend WithEvents txtRecordID As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtIPAddress As TextBox
    Friend WithEvents txtUserAgent As TextBox
    Friend WithEvents btnBack As Button
    Friend WithEvents btnGenerateCSV As Resources.Controls.RoundedButton
    Friend WithEvents btnGeneratePDF As Resources.Controls.RoundedButton
End Class
