Imports System
Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Professional dialog for adding remarks to requests
''' </summary>
Public Class RemarksDialog
    Inherits Form

    Private lblTitle As Label
    Private lblInstruction As Label
    Private lblRemarks As Label
    Private txtRemarks As TextBox
    Private btnSubmit As Button
    Private btnCancel As Button
    Private pnlHeader As Panel
    Private pnlContent As Panel
    Private _dialogTitle As String = "Add Remarks"
    Private _buttonText As String = "Submit"

    Public Property Remarks As String
        Get
            Return txtRemarks.Text.Trim()
        End Get
        Set(value As String)
            txtRemarks.Text = value
        End Set
    End Property

    Public Sub New(Optional title As String = "Add Remarks", Optional buttonText As String = "Submit", Optional instruction As String = "Please enter your remarks (optional)")
        _dialogTitle = title
        _buttonText = buttonText
        InitializeComponent(instruction)
    End Sub

    Private Sub InitializeComponent(instruction As String)
        ' Form settings
        Me.Text = _dialogTitle
        Me.Size = New Size(600, 450)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.White

        ' Header Panel
        pnlHeader = New Panel()
        pnlHeader.BackColor = ColorTranslator.FromHtml("#2c3e50")
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 90
        Me.Controls.Add(pnlHeader)

        ' Title
        lblTitle = New Label()
        lblTitle.Text = _dialogTitle
        lblTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(25, 20)
        lblTitle.AutoSize = True
        pnlHeader.Controls.Add(lblTitle)

        ' Instruction
        lblInstruction = New Label()
        lblInstruction.Text = instruction
        lblInstruction.Font = New Font("Segoe UI", 10)
        lblInstruction.ForeColor = Color.FromArgb(220, 230, 240)
        lblInstruction.Location = New Point(25, 55)
        lblInstruction.Size = New Size(540, 25)
        pnlHeader.Controls.Add(lblInstruction)

        ' Remarks Label
        lblRemarks = New Label()
        lblRemarks.Text = "Remarks:"
        lblRemarks.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblRemarks.ForeColor = Color.FromArgb(50, 50, 50)
        lblRemarks.Location = New Point(25, 110)
        lblRemarks.AutoSize = True
        Me.Controls.Add(lblRemarks)

        ' Remarks TextBox - FIXED: White background with black text for visibility
        txtRemarks = New TextBox()
        txtRemarks.Font = New Font("Segoe UI", 11)
        txtRemarks.Location = New Point(25, 140)
        txtRemarks.Size = New Size(540, 200)
        txtRemarks.Multiline = True
        txtRemarks.BackColor = Color.White  ' WHITE background for visibility
        txtRemarks.ForeColor = Color.Black  ' BLACK text for visibility
        txtRemarks.BorderStyle = BorderStyle.FixedSingle
        txtRemarks.ScrollBars = ScrollBars.Vertical
        txtRemarks.Padding = New Padding(8)
        txtRemarks.TabIndex = 0
        Me.Controls.Add(txtRemarks)

        ' Submit Button
        btnSubmit = New Button()
        btnSubmit.Text = _buttonText
        btnSubmit.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnSubmit.Size = New Size(250, 45)
        btnSubmit.Location = New Point(315, 365)
        btnSubmit.BackColor = ColorTranslator.FromHtml("#27ae60")  ' Green
        btnSubmit.ForeColor = Color.White
        btnSubmit.FlatStyle = FlatStyle.Flat
        btnSubmit.FlatAppearance.BorderSize = 0
        btnSubmit.Cursor = Cursors.Hand
        btnSubmit.TabIndex = 1
        AddHandler btnSubmit.Click, AddressOf BtnSubmit_Click
        AddHandler btnSubmit.MouseEnter, Sub() btnSubmit.BackColor = ColorTranslator.FromHtml("#229954")
        AddHandler btnSubmit.MouseLeave, Sub() btnSubmit.BackColor = ColorTranslator.FromHtml("#27ae60")
        Me.Controls.Add(btnSubmit)

        ' Cancel Button
        btnCancel = New Button()
        btnCancel.Text = "Cancel"
        btnCancel.Font = New Font("Segoe UI", 11)
        btnCancel.Size = New Size(250, 45)
        btnCancel.Location = New Point(25, 365)
        btnCancel.BackColor = ColorTranslator.FromHtml("#95a5a6")  ' Gray
        btnCancel.ForeColor = Color.White
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.Cursor = Cursors.Hand
        btnCancel.TabIndex = 2
        AddHandler btnCancel.Click, AddressOf BtnCancel_Click
        AddHandler btnCancel.MouseEnter, Sub() btnCancel.BackColor = ColorTranslator.FromHtml("#7f8c8d")
        AddHandler btnCancel.MouseLeave, Sub() btnCancel.BackColor = ColorTranslator.FromHtml("#95a5a6")
        Me.Controls.Add(btnCancel)

        ' Accept button
        Me.AcceptButton = btnSubmit
        Me.CancelButton = btnCancel

        ' Focus on textbox
        AddHandler Me.Shown, Sub() txtRemarks.Focus()
    End Sub

    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
