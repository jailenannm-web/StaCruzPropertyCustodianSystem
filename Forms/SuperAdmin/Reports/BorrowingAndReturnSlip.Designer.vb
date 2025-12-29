Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BorrowingAndReturnSlip
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
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblPropertyCard = New System.Windows.Forms.Label()
        Me.borrowedId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.itemType = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.itemID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.requestId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.actualReturnDate = New System.Windows.Forms.DateTimePicker()
        Me.expectedReturnDate = New System.Windows.Forms.DateTimePicker()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.borrowerDate = New System.Windows.Forms.DateTimePicker()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.remarks = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.conditionOnReturn = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.departmentId = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.borrowedName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.borrowerPosition = New System.Windows.Forms.ComboBox()
        Me.status = New System.Windows.Forms.ComboBox()
        Me.RoundedButton1 = New Resources.Controls.RoundedButton()
        Me.btnCSV = New Resources.Controls.RoundedButton()
        Me.RoundedButton2 = New Resources.Controls.RoundedButton()
        Me.RoundedButton3 = New Resources.Controls.RoundedButton()
        Me.RoundedButton4 = New Resources.Controls.RoundedButton()
        Me.Panel11.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.lblPropertyCard)
        Me.Panel11.Location = New System.Drawing.Point(338, 84)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(670, 47)
        Me.Panel11.TabIndex = 366
        '
        'lblPropertyCard
        '
        Me.lblPropertyCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPropertyCard.AutoSize = True
        Me.lblPropertyCard.Font = New System.Drawing.Font("Poppins", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyCard.Location = New System.Drawing.Point(200, 6)
        Me.lblPropertyCard.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPropertyCard.Name = "lblPropertyCard"
        Me.lblPropertyCard.Size = New System.Drawing.Size(318, 36)
        Me.lblPropertyCard.TabIndex = 38
        Me.lblPropertyCard.Text = "BORROWING AND RETURN SLIP"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.borrowedId)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(338, 136)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(892, 50)
        Me.Panel2.TabIndex = 367
        '
        'borrowedId
        '
        Me.borrowedId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.borrowedId.Location = New System.Drawing.Point(331, 10)
        Me.borrowedId.Name = "borrowedId"
        Me.borrowedId.Size = New System.Drawing.Size(357, 22)
        Me.borrowedId.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(222, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 17)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Borrowed ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.borrowedId)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.itemType)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.itemID)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.requestId)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(338, 179)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(892, 64)
        Me.Panel1.TabIndex = 368
        '
        'itemType
        '
        Me.itemType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.itemType.Location = New System.Drawing.Point(397, 12)
        Me.itemType.Name = "itemType"
        Me.itemType.Size = New System.Drawing.Size(218, 22)
        Me.itemType.TabIndex = 333
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(316, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 17)
        Me.Label3.TabIndex = 332
        Me.Label3.Text = "Item Type:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'itemID
        '
        Me.itemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.itemID.Location = New System.Drawing.Point(694, 13)
        Me.itemID.Name = "itemID"
        Me.itemID.Size = New System.Drawing.Size(183, 22)
        Me.itemID.TabIndex = 331
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(632, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 17)
        Me.Label6.TabIndex = 330
        Me.Label6.Text = "Item ID:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'requestId
        '
        Me.requestId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.requestId.Location = New System.Drawing.Point(87, 12)
        Me.requestId.Name = "requestId"
        Me.requestId.Size = New System.Drawing.Size(203, 22)
        Me.requestId.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Request ID:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RoundedButton4
        '
        Me.RoundedButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton4.CornerRadius = 15
        Me.RoundedButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton4.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton4.Location = New System.Drawing.Point(757, 838)
        Me.RoundedButton4.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedButton4.Name = "RoundedButton4"
        Me.RoundedButton4.Size = New System.Drawing.Size(153, 34)
        Me.RoundedButton4.TabIndex = 377
        Me.RoundedButton4.Text = "Back"
        Me.RoundedButton4.UseVisualStyleBackColor = False
        '
        'RoundedButton2
        '
        Me.RoundedButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton2.CornerRadius = 15
        Me.RoundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton2.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton2.Location = New System.Drawing.Point(1077, 838)
        Me.RoundedButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedButton2.Name = "RoundedButton2"
        Me.RoundedButton2.Size = New System.Drawing.Size(153, 34)
        Me.RoundedButton2.TabIndex = 376
        Me.RoundedButton2.Text = "Generate PDF File"
        Me.RoundedButton2.UseVisualStyleBackColor = False
        '
        'RoundedButton3
        '
        Me.RoundedButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton3.CornerRadius = 15
        Me.RoundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton3.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton3.Location = New System.Drawing.Point(918, 838)
        Me.RoundedButton3.Margin = New System.Windows.Forms.Padding(4)
        Me.RoundedButton3.Name = "RoundedButton3"
        Me.RoundedButton3.Size = New System.Drawing.Size(153, 34)
        Me.RoundedButton3.TabIndex = 375
        Me.RoundedButton3.Text = "Generate CSV File"
        Me.RoundedButton3.UseVisualStyleBackColor = False
        '
        'RoundedButton1
        '
        Me.RoundedButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundedButton1.CornerRadius = 15
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RoundedButton1.Location = New System.Drawing.Point(926, 997)
        Me.RoundedButton1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(11, 7)
        Me.RoundedButton1.TabIndex = 365
        Me.RoundedButton1.Text = "Generate PDF File"
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'btnCSV
        '
        Me.btnCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCSV.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnCSV.CornerRadius = 15
        Me.btnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCSV.Font = New System.Drawing.Font("Poppins SemiBold", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnCSV.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCSV.Location = New System.Drawing.Point(765, 997)
        Me.btnCSV.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnCSV.Name = "btnCSV"
        Me.btnCSV.Size = New System.Drawing.Size(11, 7)
        Me.btnCSV.TabIndex = 364
        Me.btnCSV.Text = "Generate CSV File"
        Me.btnCSV.UseVisualStyleBackColor = False
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.White
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.actualReturnDate)
        Me.Panel10.Controls.Add(Me.expectedReturnDate)
        Me.Panel10.Controls.Add(Me.Label29)
        Me.Panel10.Controls.Add(Me.borrowerDate)
        Me.Panel10.Controls.Add(Me.Label31)
        Me.Panel10.Controls.Add(Me.Label30)
        Me.Panel10.Controls.Add(Me.departmentId)
        Me.Panel10.Controls.Add(Me.Label26)
        Me.Panel10.Controls.Add(Me.borrowerPosition)
        Me.Panel10.Controls.Add(Me.Label5)
        Me.Panel10.Controls.Add(Me.borrowedName)
        Me.Panel10.Controls.Add(Me.Label4)
        Me.Panel10.Controls.Add(Me.status)
        Me.Panel10.Controls.Add(Me.Label33)
        Me.Panel10.Controls.Add(Me.conditionOnReturn)
        Me.Panel10.Controls.Add(Me.Label32)
        Me.Panel10.Controls.Add(Me.remarks)
        Me.Panel10.Controls.Add(Me.Label34)
        Me.Panel10.Location = New System.Drawing.Point(338, 242)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(892, 527)
        Me.Panel10.TabIndex = 368
        '
        'actualReturnDate
        '
        Me.actualReturnDate.Font = New System.Drawing.Font("Poppins", 7.2!)
        Me.actualReturnDate.Location = New System.Drawing.Point(621, 50)
        Me.actualReturnDate.Name = "actualReturnDate"
        Me.actualReturnDate.Size = New System.Drawing.Size(256, 25)
        Me.actualReturnDate.TabIndex = 339
        '
        'expectedReturnDate
        '
        Me.expectedReturnDate.Font = New System.Drawing.Font("Poppins", 7.2!)
        Me.expectedReturnDate.Location = New System.Drawing.Point(621, 15)
        Me.expectedReturnDate.Name = "expectedReturnDate"
        Me.expectedReturnDate.Size = New System.Drawing.Size(256, 25)
        Me.expectedReturnDate.TabIndex = 338
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(13, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(101, 22)
        Me.Label29.TabIndex = 60
        Me.Label29.Text = "Borrower Date:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'borrowerDate
        '
        Me.borrowerDate.Font = New System.Drawing.Font("Poppins", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.borrowerDate.Location = New System.Drawing.Point(115, 16)
        Me.borrowerDate.Name = "borrowerDate"
        Me.borrowerDate.Size = New System.Drawing.Size(326, 25)
        Me.borrowerDate.TabIndex = 337
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(472, 53)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(129, 22)
        Me.Label31.TabIndex = 64
        Me.Label31.Text = "Actual Return Date:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(472, 19)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(143, 22)
        Me.Label30.TabIndex = 62
        Me.Label30.Text = "Expected Return Date:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'remarks
        '
        Me.remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.remarks.Location = New System.Drawing.Point(331, 421)
        Me.remarks.Name = "remarks"
        Me.remarks.Size = New System.Drawing.Size(341, 22)
        Me.remarks.TabIndex = 336
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(213, 421)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(55, 17)
        Me.Label34.TabIndex = 335
        Me.Label34.Text = "Remarks:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'status
        '
        Me.status.Location = New System.Drawing.Point(331, 377)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(341, 22)
        Me.status.TabIndex = 334
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(213, 378)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(44, 17)
        Me.Label33.TabIndex = 68
        Me.Label33.Text = "Status:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'conditionOnReturn
        '
        Me.conditionOnReturn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.conditionOnReturn.Location = New System.Drawing.Point(331, 330)
        Me.conditionOnReturn.Name = "conditionOnReturn"
        Me.conditionOnReturn.Size = New System.Drawing.Size(341, 22)
        Me.conditionOnReturn.TabIndex = 67
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(188, 331)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(113, 17)
        Me.Label32.TabIndex = 66
        Me.Label32.Text = "Condition on Return:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'departmentId
        '
        Me.departmentId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.departmentId.Location = New System.Drawing.Point(315, 138)
        Me.departmentId.Name = "departmentId"
        Me.departmentId.Size = New System.Drawing.Size(357, 22)
        Me.departmentId.TabIndex = 59
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(197, 138)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(85, 17)
        Me.Label26.TabIndex = 58
        Me.Label26.Text = "Department ID:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'borrowerPosition
        '
        Me.borrowerPosition.Location = New System.Drawing.Point(315, 92)
        Me.borrowerPosition.Name = "borrowerPosition"
        Me.borrowerPosition.Size = New System.Drawing.Size(357, 22)
        Me.borrowerPosition.TabIndex = 57
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(197, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 17)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Borrower Position:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'borrowedName
        '
        Me.borrowedName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.borrowedName.Location = New System.Drawing.Point(315, 42)
        Me.borrowedName.Name = "borrowedName"
        Me.borrowedName.Size = New System.Drawing.Size(357, 22)
        Me.borrowedName.TabIndex = 55
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins SemiBold", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(197, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 17)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Borrowed Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BorrowingAndReturnSlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1569, 919)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.RoundedButton4)
        Me.Controls.Add(Me.RoundedButton2)
        Me.Controls.Add(Me.RoundedButton3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.RoundedButton1)
        Me.Controls.Add(Me.btnCSV)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "BorrowingAndReturnSlip"
        Me.Text = "BorrowingAndReturnSlip"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RoundedButton1 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents btnCSV As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents Panel11 As Panel
    Friend WithEvents lblPropertyCard As Label
    Friend WithEvents borrowedId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents itemID As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents requestId As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents RoundedButton2 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents RoundedButton3 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents RoundedButton4 As StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton
    Friend WithEvents itemType As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents borrowedName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents departmentId As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents conditionOnReturn As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents remarks As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents borrowerDate As DateTimePicker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents borrowerPosition As ComboBox
    Friend WithEvents expectedReturnDate As DateTimePicker
    Friend WithEvents actualReturnDate As DateTimePicker
    Friend WithEvents Panel3 As Panel
    Friend WithEvents status As ComboBox
End Class
