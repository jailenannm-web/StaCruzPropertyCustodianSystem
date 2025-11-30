Imports System
Imports System.Windows.Forms

Public Class AddSupplyRequest
    Inherits System.Windows.Forms.UserControl

    Private Sub employeeID_Click(sender As Object, e As System.EventArgs) Handles sqr_employeeID.Click

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New SupplyInventory())
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

            ' Submit supply request
            Dim success As Boolean = DatabaseConnection.StaffSubmitSupplyRequest(
                SessionContext.CurrentUserID.Value,
                TextBox8.Text.Trim(), ' item name
                quantity,
                TextBox3.Text.Trim(), ' purpose
                deptID,
                "", ' position - will be fetched from user record
                "" ' requester name - will be fetched from user record
            )

            If success Then
                MessageBox.Show("Supply request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Navigate back
                Dim parentDashboard = TryCast(Me.ParentForm, StaffDashboard)
                If parentDashboard IsNot Nothing Then
                    parentDashboard.LoadUserControl(New SupplyInventory())
                Else
                    Me.Parent.Controls.Remove(Me)
                End If
            Else
                MessageBox.Show("Failed to submit supply request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while submitting the request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
