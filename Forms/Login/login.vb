Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Login


    Private Sub btn_Cancel_Click(sender As Object, e As System.EventArgs) Handles btn_Cancel.Click
        Dim userLevelForm As New UserLevel()
        userLevelForm.Show()
        Me.Close()
    End Sub

    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub txb_Password_TextChanged(sender As Object, e As EventArgs) Handles txb_Password.TextChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub txb_Username_TextChanged(sender As Object, e As EventArgs) Handles txb_Username.TextChanged

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make form full screen but not covering taskbar
        Me.Bounds = Screen.FromHandle(Me.Handle).WorkingArea

        ' Apply placeholders
        SetPlaceholder(txb_Username, "Username")
        SetPlaceholder(txb_Password, "Password", True)
    End Sub

    ' === Placeholder setup ===
    Private Sub SetPlaceholder(textBox As TextBox, placeholder As String, Optional isPassword As Boolean = False)
        If String.IsNullOrWhiteSpace(textBox.Text) Then
            textBox.ForeColor = Color.Gray
            textBox.Text = placeholder
            If isPassword Then textBox.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub RemovePlaceholder(textBox As TextBox, placeholder As String, Optional isPassword As Boolean = False)
        If textBox.Text = placeholder Then
            textBox.Text = ""
            textBox.ForeColor = Color.Black
            If isPassword Then textBox.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub PanelCard_Paint(sender As Object, e As Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txb_Username_GotFocus(sender As Object, e As EventArgs) Handles txb_Username.GotFocus
        RemovePlaceholder(txb_Username, "Username")
    End Sub

    Private Sub txb_Username_LostFocus(sender As Object, e As EventArgs) Handles txb_Username.LostFocus
        SetPlaceholder(txb_Username, "Username")
    End Sub

    Private Sub txb_Password_GotFocus(sender As Object, e As EventArgs) Handles txb_Password.GotFocus
        RemovePlaceholder(txb_Password, "Password", True)
    End Sub

    Private Sub txb_Password_LostFocus(sender As Object, e As EventArgs) Handles txb_Password.LostFocus
        SetPlaceholder(txb_Password, "Password", True)
    End Sub
End Class