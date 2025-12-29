<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Me.lblReports = New System.Windows.Forms.Label()
        Me.Essuance = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnBorrowReturn = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnRequisitionSlip = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.SuspendLayout()
        '
        'lblReports
        '
        Me.lblReports.AutoSize = True
        Me.lblReports.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReports.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblReports.Location = New System.Drawing.Point(534, 63)
        Me.lblReports.Name = "lblReports"
        Me.lblReports.Size = New System.Drawing.Size(128, 48)
        Me.lblReports.TabIndex = 2
        Me.lblReports.Text = "Reports"
        '
        'Essuance
        '
        Me.Essuance.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Essuance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Essuance.CornerRadius = 30
        Me.Essuance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Essuance.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Essuance.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Essuance.Location = New System.Drawing.Point(398, 404)
        Me.Essuance.Name = "Essuance"
        Me.Essuance.Size = New System.Drawing.Size(401, 65)
        Me.Essuance.TabIndex = 5
        Me.Essuance.Text = "Propety Acknowledgement Receipt"
        Me.Essuance.UseVisualStyleBackColor = False
        '
        'btnBorrowReturn
        '
        Me.btnBorrowReturn.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnBorrowReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBorrowReturn.CornerRadius = 30
        Me.btnBorrowReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrowReturn.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrowReturn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBorrowReturn.Location = New System.Drawing.Point(400, 300)
        Me.btnBorrowReturn.Name = "btnBorrowReturn"
        Me.btnBorrowReturn.Size = New System.Drawing.Size(401, 65)
        Me.btnBorrowReturn.TabIndex = 4
        Me.btnBorrowReturn.Text = "Borrow and Return Slip"
        Me.btnBorrowReturn.UseVisualStyleBackColor = False
        '
        'btnRequisitionSlip
        '
        Me.btnRequisitionSlip.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnRequisitionSlip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRequisitionSlip.CornerRadius = 30
        Me.btnRequisitionSlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRequisitionSlip.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRequisitionSlip.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRequisitionSlip.Location = New System.Drawing.Point(398, 184)
        Me.btnRequisitionSlip.Name = "btnRequisitionSlip"
        Me.btnRequisitionSlip.Size = New System.Drawing.Size(403, 65)
        Me.btnRequisitionSlip.TabIndex = 3
        Me.btnRequisitionSlip.Text = "Requisition Slip"
        Me.btnRequisitionSlip.UseVisualStyleBackColor = False
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1040, 640)
        Me.Controls.Add(Me.Essuance)
        Me.Controls.Add(Me.btnBorrowReturn)
        Me.Controls.Add(Me.btnRequisitionSlip)
        Me.Controls.Add(Me.lblReports)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmReports"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblReports As System.Windows.Forms.Label
    Friend WithEvents btnRequisitionSlip As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnBorrowReturn As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Essuance As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
End Class
