Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBorrowedItem
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
        Me.lblBorrowed = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.borrowedId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requestID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.borrowerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.borrowerPosition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.borrowDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.expectedReturnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actualReturnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conditionOnReturn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.borrowedItemsearchbar = New System.Windows.Forms.TextBox()
        Me.pm_cbobx_status = New System.Windows.Forms.ComboBox()
        Me.pm_cbobx_categ = New System.Windows.Forms.ComboBox()
        Me.btnBorrowReturn = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.Essuance = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBorrowed
        '
        Me.lblBorrowed.AutoSize = True
        Me.lblBorrowed.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrowed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.lblBorrowed.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblBorrowed.Location = New System.Drawing.Point(75, 86)
        Me.lblBorrowed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBorrowed.Name = "lblBorrowed"
        Me.lblBorrowed.Size = New System.Drawing.Size(331, 58)
        Me.lblBorrowed.TabIndex = 1
        Me.lblBorrowed.Text = "My Borrowed Item"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.borrowedId, Me.requestID, Me.itemType, Me.itemId, Me.borrowerName, Me.borrowerPosition, Me.departmentId, Me.borrowDate, Me.expectedReturnDate, Me.actualReturnDate, Me.conditionOnReturn, Me.status, Me.remarks})
        Me.DataGridView1.Location = New System.Drawing.Point(4, 4)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(1267, 876)
        Me.DataGridView1.TabIndex = 2
        '
        'borrowedId
        '
        Me.borrowedId.HeaderText = "Borrowed ID"
        Me.borrowedId.MinimumWidth = 6
        Me.borrowedId.Name = "borrowedId"
        Me.borrowedId.Width = 125
        '
        'requestID
        '
        Me.requestID.HeaderText = "Request ID"
        Me.requestID.MinimumWidth = 6
        Me.requestID.Name = "requestID"
        Me.requestID.Width = 125
        '
        'itemType
        '
        Me.itemType.HeaderText = "Item Type"
        Me.itemType.MinimumWidth = 6
        Me.itemType.Name = "itemType"
        Me.itemType.Width = 125
        '
        'itemId
        '
        Me.itemId.HeaderText = "Item ID"
        Me.itemId.MinimumWidth = 6
        Me.itemId.Name = "itemId"
        Me.itemId.Width = 125
        '
        'borrowerName
        '
        Me.borrowerName.HeaderText = "Borrower Name"
        Me.borrowerName.MinimumWidth = 6
        Me.borrowerName.Name = "borrowerName"
        Me.borrowerName.Width = 125
        '
        'borrowerPosition
        '
        Me.borrowerPosition.HeaderText = "Borrower Position"
        Me.borrowerPosition.MinimumWidth = 6
        Me.borrowerPosition.Name = "borrowerPosition"
        Me.borrowerPosition.Width = 125
        '
        'departmentId
        '
        Me.departmentId.HeaderText = "Department ID"
        Me.departmentId.MinimumWidth = 6
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Width = 125
        '
        'borrowDate
        '
        Me.borrowDate.HeaderText = "Borrow Date"
        Me.borrowDate.MinimumWidth = 6
        Me.borrowDate.Name = "borrowDate"
        Me.borrowDate.Width = 125
        '
        'expectedReturnDate
        '
        Me.expectedReturnDate.HeaderText = "Expected Return Date"
        Me.expectedReturnDate.MinimumWidth = 6
        Me.expectedReturnDate.Name = "expectedReturnDate"
        Me.expectedReturnDate.Width = 125
        '
        'actualReturnDate
        '
        Me.actualReturnDate.HeaderText = "Actual Return Date"
        Me.actualReturnDate.MinimumWidth = 6
        Me.actualReturnDate.Name = "actualReturnDate"
        Me.actualReturnDate.Width = 125
        '
        'conditionOnReturn
        '
        Me.conditionOnReturn.HeaderText = "Condition On Return"
        Me.conditionOnReturn.MinimumWidth = 6
        Me.conditionOnReturn.Name = "conditionOnReturn"
        Me.conditionOnReturn.Width = 125
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.MinimumWidth = 6
        Me.status.Name = "status"
        Me.status.Width = 125
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.MinimumWidth = 6
        Me.remarks.Name = "remarks"
        Me.remarks.Width = 125
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.5!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(85, 147)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1275, 884)
        Me.TableLayoutPanel1.TabIndex = 162
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.StaCruzPropertyCustodianSystem.My.Resources.Resources.icon_search1
        Me.PictureBox2.Location = New System.Drawing.Point(420, 94)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(58, 42)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 186
        Me.PictureBox2.TabStop = False
        '
        'borrowedItemsearchbar
        '
        Me.borrowedItemsearchbar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.borrowedItemsearchbar.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.borrowedItemsearchbar.Location = New System.Drawing.Point(485, 94)
        Me.borrowedItemsearchbar.Margin = New System.Windows.Forms.Padding(4)
        Me.borrowedItemsearchbar.Name = "borrowedItemsearchbar"
        Me.borrowedItemsearchbar.Size = New System.Drawing.Size(367, 42)
        Me.borrowedItemsearchbar.TabIndex = 185
        '
        'pm_cbobx_status
        '
        Me.pm_cbobx_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_status.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_cbobx_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_status.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_status.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_status.Location = New System.Drawing.Point(1067, 105)
        Me.pm_cbobx_status.Name = "pm_cbobx_status"
        Me.pm_cbobx_status.Size = New System.Drawing.Size(145, 31)
        Me.pm_cbobx_status.TabIndex = 183
        Me.pm_cbobx_status.Text = "Status"
        '
        'pm_cbobx_categ
        '
        Me.pm_cbobx_categ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pm_cbobx_categ.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.pm_cbobx_categ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pm_cbobx_categ.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.pm_cbobx_categ.ForeColor = System.Drawing.Color.White
        Me.pm_cbobx_categ.Location = New System.Drawing.Point(892, 105)
        Me.pm_cbobx_categ.Name = "pm_cbobx_categ"
        Me.pm_cbobx_categ.Size = New System.Drawing.Size(159, 31)
        Me.pm_cbobx_categ.TabIndex = 184
        Me.pm_cbobx_categ.Text = "Categories"
        '
        'btnBorrowReturn
        '
        Me.btnBorrowReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBorrowReturn.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnBorrowReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBorrowReturn.CornerRadius = 30
        Me.btnBorrowReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrowReturn.Font = New System.Drawing.Font("Poppins", 10.0!)
        Me.btnBorrowReturn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBorrowReturn.Location = New System.Drawing.Point(1140, 1061)
        Me.btnBorrowReturn.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBorrowReturn.Name = "btnBorrowReturn"
        Me.btnBorrowReturn.Size = New System.Drawing.Size(220, 35)
        Me.btnBorrowReturn.TabIndex = 187
        Me.btnBorrowReturn.Text = "Borrow and Return Slip"
        Me.btnBorrowReturn.UseVisualStyleBackColor = False
        '
        'Essuance
        '
        Me.Essuance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Essuance.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.Essuance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Essuance.CornerRadius = 30
        Me.Essuance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Essuance.Font = New System.Drawing.Font("Poppins", 10.0!)
        Me.Essuance.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Essuance.Location = New System.Drawing.Point(780, 1061)
        Me.Essuance.Margin = New System.Windows.Forms.Padding(4)
        Me.Essuance.Name = "Essuance"
        Me.Essuance.Size = New System.Drawing.Size(352, 35)
        Me.Essuance.TabIndex = 188
        Me.Essuance.Text = "Propety Acknowledgement Receipt"
        Me.Essuance.UseVisualStyleBackColor = False
        '
        'frmBorrowedItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1467, 1175)
        Me.Controls.Add(Me.Essuance)
        Me.Controls.Add(Me.btnBorrowReturn)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.borrowedItemsearchbar)
        Me.Controls.Add(Me.pm_cbobx_status)
        Me.Controls.Add(Me.pm_cbobx_categ)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblBorrowed)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBorrowedItem"
        Me.Text = "frmBorrowedItem"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblBorrowed As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents borrowedItemsearchbar As TextBox
    Friend WithEvents pm_cbobx_status As ComboBox
    Friend WithEvents pm_cbobx_categ As ComboBox
    Friend WithEvents borrowedId As DataGridViewTextBoxColumn
    Friend WithEvents requestID As DataGridViewTextBoxColumn
    Friend WithEvents itemType As DataGridViewTextBoxColumn
    Friend WithEvents itemId As DataGridViewTextBoxColumn
    Friend WithEvents borrowerName As DataGridViewTextBoxColumn
    Friend WithEvents borrowerPosition As DataGridViewTextBoxColumn
    Friend WithEvents departmentId As DataGridViewTextBoxColumn
    Friend WithEvents borrowDate As DataGridViewTextBoxColumn
    Friend WithEvents expectedReturnDate As DataGridViewTextBoxColumn
    Friend WithEvents actualReturnDate As DataGridViewTextBoxColumn
    Friend WithEvents conditionOnReturn As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents remarks As DataGridViewTextBoxColumn
    Friend WithEvents btnBorrowReturn As Resources.Controls.RoundedButton
    Friend WithEvents Essuance As Resources.Controls.RoundedButton
End Class
