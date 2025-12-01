Imports System
Imports System.Windows.Forms

Public Class AddPropertyRequest
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New PropertyInventory())
        Else
            Me.Parent.Controls.Remove(Me)
        End If
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Validate required fields
            If String.IsNullOrWhiteSpace(TextBox8.Text) Then
                MessageBox.Show("Please enter the item name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox8.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(TextBox3.Text) Then
                MessageBox.Show("Please enter the purpose of the request.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox3.Focus()
                Return
            End If

            If Not SessionContext.CurrentUserID.HasValue Then
                MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get quantity
            Dim quantity As Integer = 1
            If Not String.IsNullOrWhiteSpace(TextBox5.Text) Then
                Integer.TryParse(TextBox5.Text, quantity)
            End If

            ' Get department ID if provided
            Dim deptID As Integer? = Nothing
            If Not String.IsNullOrWhiteSpace(departmentID.Text) Then
                Integer.TryParse(departmentID.Text, deptID)
            End If

            ' Submit property request
            Dim success As Boolean = DatabaseConnection.SubmitPropertyRequest(
                SessionContext.CurrentUserID.Value,
                TextBox8.Text.Trim(), ' item name
                TextBox3.Text.Trim(), ' purpose
                quantity,
                deptID,
                "", ' position - will be fetched
                "" ' requester name - will be fetched
            )

            If success Then
                MessageBox.Show("Property request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Navigate back
                Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
                If parentDashboard IsNot Nothing Then
                    parentDashboard.LoadUserControl(New PropertyInventory())
                Else
                    Me.Parent.Controls.Remove(Me)
                End If
            Else
                MessageBox.Show("Failed to submit property request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while submitting the request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub approvedDate_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub purpose_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub request_date_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub status_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub approved_by_Click(sender As Object, e As EventArgs) Handles approved_by.Click

    End Sub

    Private Sub TextBox3_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub AddPropertyRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class