Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Public Class AddPropertyRequest
    Inherits UserControl
    
    Private _prefillItemName As String = ""

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub
    
    Public Sub New(itemName As String)
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        _prefillItemName = itemName
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
            If departmentID IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(departmentID.Text) Then
                Dim parsedDeptID As Integer
                If Integer.TryParse(departmentID.Text.Trim(), parsedDeptID) Then
                    deptID = parsedDeptID
                End If
            End If

            ' Ensure purpose is not empty
            Dim purposeText As String = TextBox3.Text.Trim()
            If String.IsNullOrWhiteSpace(purposeText) Then
                MessageBox.Show("Please enter the purpose of the request.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox3.Focus()
                Return
            End If

            ' Ensure item name is not empty
            Dim itemNameText As String = TextBox8.Text.Trim()
            If String.IsNullOrWhiteSpace(itemNameText) Then
                MessageBox.Show("Please enter the item name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox8.Focus()
                Return
            End If

            ' Submit property request
            Dim success As Boolean = DatabaseConnection.SubmitPropertyRequest(
                SessionContext.CurrentUserID.Value,
                itemNameText,
                purposeText,
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
        ' Pre-fill item name if provided
        If Not String.IsNullOrEmpty(_prefillItemName) Then
            TextBox8.Text = _prefillItemName
        End If
        
        ' Pre-fill user info if available
        If SessionContext.CurrentUserID.HasValue Then
            Try
                Dim profile As Dictionary(Of String, Object) = DatabaseConnection.GetStaffProfile(SessionContext.CurrentUserID.Value)
                If profile IsNot Nothing AndAlso profile.Count > 0 Then
                    ' Fill in requester name if field exists (TextBox1 or similar)
                    If profile.ContainsKey("first_name") AndAlso profile.ContainsKey("last_name") Then
                        Dim fullName As String = profile("first_name").ToString() & " " & profile("last_name").ToString()
                        ' Try to find and fill requester name field - adjust control name as needed
                        Try
                            Dim requesterField As Control = Me.Controls.Find("TextBox1", True).FirstOrDefault()
                            If requesterField IsNot Nothing Then
                                requesterField.Text = fullName
                            End If
                        Catch
                        End Try
                    End If
                    
                    ' Fill position if field exists
                    If profile.ContainsKey("position") AndAlso profile("position") IsNot Nothing Then
                        Try
                            Dim positionField As Control = Me.Controls.Find("TextBox2", True).FirstOrDefault()
                            If positionField IsNot Nothing Then
                                positionField.Text = profile("position").ToString()
                            End If
                        Catch
                        End Try
                    End If
                    
                    ' Fill department if field exists
                    If profile.ContainsKey("department_id") AndAlso profile("department_id") IsNot Nothing Then
                        Try
                            Dim deptID As Integer = Convert.ToInt32(profile("department_id"))
                            Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
                            For Each row As DataRow In dt.Rows
                                If Convert.ToInt32(row("department_id")) = deptID Then
                                    Dim deptField As Control = Me.Controls.Find("departmentID", True).FirstOrDefault()
                                    If deptField IsNot Nothing Then
                                        deptField.Text = row("department_name").ToString()
                                    End If
                                    Exit For
                                End If
                            Next
                        Catch
                        End Try
                    End If
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("AddPropertyRequest_Load Error: " & ex.Message)
            End Try
        End If
    End Sub
End Class