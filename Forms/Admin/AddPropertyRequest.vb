Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Public Class AddPropertyRequest
    Inherits UserControl
    
    Private _prefillItemName As String = ""
    Private _prefillItemDescription As String = ""
    Private _prefillRequesterName As String = ""
    Private _prefillPosition As String = ""
    Private _prefillDepartment As String = ""
    Private _prefillDate As String = ""

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub
    
    Public Sub New(itemName As String)
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        _prefillItemName = itemName
    End Sub
    
    Public Sub New(itemName As String, itemDescription As String, requesterName As String, position As String, department As String, requestDate As String)
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        _prefillItemName = itemName
        _prefillItemDescription = itemDescription
        _prefillRequesterName = requesterName
        _prefillPosition = position
        _prefillDepartment = department
        _prefillDate = requestDate
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
            If itemName Is Nothing OrElse String.IsNullOrWhiteSpace(itemName.Text) Then
                MessageBox.Show("Please enter the item name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If itemName IsNot Nothing Then itemName.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(purpose.Text) Then
                MessageBox.Show("Please enter the purpose of the request.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                purpose.Focus()
                Return
            End If

            If Not SessionContext.CurrentUserID.HasValue Then
                MessageBox.Show("User session not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get quantity (from Quantity Requested field)
            Dim quantity As Integer = 1
            If quantityRequested IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(quantityRequested.Text) Then
                Integer.TryParse(quantityRequested.Text.Trim(), quantity)
            End If
            If quantity <= 0 Then quantity = 1

            ' Get department ID if provided
            Dim deptID As Integer? = Nothing
            If department IsNot Nothing Then
                Try
                    If department.SelectedValue IsNot Nothing Then
                        Dim selectedValue As Object = department.SelectedValue
                        Dim parsedDeptID As Integer = 0
                        If Integer.TryParse(selectedValue.ToString(), parsedDeptID) Then
                            deptID = parsedDeptID
                        End If
                    ElseIf Not String.IsNullOrWhiteSpace(department.Text) Then
                        ' Try to find department by name
                        Dim deptTable As DataTable = DatabaseConnection.GetDepartmentLookup(True)
                        If deptTable IsNot Nothing Then
                            For Each row As DataRow In deptTable.Rows
                                Dim deptName As String = ""
                                If deptTable.Columns.Contains("department_name") Then
                                    deptName = row("department_name").ToString()
                                    If deptName.Equals(department.Text.Trim(), StringComparison.OrdinalIgnoreCase) Then
                                        deptID = Convert.ToInt32(row("department_id"))
                                        Exit For
                                    End If
                                ElseIf deptTable.Columns.Contains("departmentName") Then
                                    deptName = row("departmentName").ToString()
                                    If deptName.Equals(department.Text.Trim(), StringComparison.OrdinalIgnoreCase) Then
                                        deptID = Convert.ToInt32(row("departmentId"))
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    End If
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("Error parsing department ID: " & ex.Message)
                End Try
            End If

            ' Ensure purpose is not empty
            Dim purposeText As String = purpose.Text.Trim()
            If String.IsNullOrWhiteSpace(purposeText) Then
                MessageBox.Show("Please enter the purpose of the request.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                purpose.Focus()
                Return
            End If

            ' Ensure item name is not empty
            Dim itemNameText As String = itemName.Text.Trim()
            If String.IsNullOrWhiteSpace(itemNameText) Then
                MessageBox.Show("Please enter the item name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If itemName IsNot Nothing Then itemName.Focus()
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

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)

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

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles description.TextChanged

    End Sub

    Private Sub approved_by_Click(sender As Object, e As EventArgs) Handles approved_by.Click

    End Sub

    Private Sub TextBox3_TextChanged_1(sender As Object, e As EventArgs) Handles purpose.TextChanged

    End Sub

    Private Sub AddPropertyRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Bind Department dropdown to real departments (so SelectedValue is departmentId)
            Try
                If department IsNot Nothing Then
                    Dim deptTable As DataTable = DatabaseConnection.GetDepartmentLookup(True)
                    If deptTable IsNot Nothing AndAlso deptTable.Rows.Count > 0 Then
                        department.DataSource = deptTable
                        If deptTable.Columns.Contains("department_name") Then
                            department.DisplayMember = "department_name"
                            department.ValueMember = "department_id"
                        ElseIf deptTable.Columns.Contains("departmentName") Then
                            department.DisplayMember = "departmentName"
                            department.ValueMember = "departmentId"
                        ElseIf deptTable.Columns.Count >= 2 Then
                            department.DisplayMember = deptTable.Columns(1).ColumnName
                            department.ValueMember = deptTable.Columns(0).ColumnName
                        End If
                    End If
                End If
            Catch
            End Try

            ' Pre-fill item name and description if provided
            If Not String.IsNullOrEmpty(_prefillItemName) Then
                itemName.Text = _prefillItemName
            End If
            
            ' Pre-fill description if provided
            If Not String.IsNullOrEmpty(_prefillItemDescription) Then
                description.Text = _prefillItemDescription
            End If
            
            ' Pre-fill requester name if provided
            If Not String.IsNullOrEmpty(_prefillRequesterName) Then
                requesterName.Text = _prefillRequesterName
            End If
            
            ' Pre-fill position if provided
            If Not String.IsNullOrEmpty(_prefillPosition) Then
                position.Text = _prefillPosition
            End If
            
            ' Pre-fill department if provided
            If Not String.IsNullOrEmpty(_prefillDepartment) Then
                department.Text = _prefillDepartment
            End If
            
            ' Pre-fill date if provided
            If Not String.IsNullOrEmpty(_prefillDate) Then
                Try
                    Dim parsedDate As Date
                    If Date.TryParse(_prefillDate, parsedDate) Then
                        DateTimePicker1.Value = parsedDate
                    End If
                Catch
                End Try
            End If
            
            ' If pre-fill data not provided, try to get from profile
            If String.IsNullOrEmpty(_prefillRequesterName) AndAlso SessionContext.CurrentUserID.HasValue Then
                Try
                    Dim profile As Dictionary(Of String, Object) = DatabaseConnection.GetStaffProfile(SessionContext.CurrentUserID.Value)
                    If profile IsNot Nothing AndAlso profile.Count > 0 Then
                        ' Fill in requester name
                        If profile.ContainsKey("firstName") AndAlso profile.ContainsKey("lastName") Then
                            Dim firstName As String = profile("firstName").ToString()
                            Dim lastName As String = profile("lastName").ToString()
                            Dim middleName As String = If(profile.ContainsKey("middleName") AndAlso profile("middleName") IsNot Nothing, profile("middleName").ToString(), "")
                            Dim fullName As String = firstName & If(Not String.IsNullOrEmpty(middleName), " " & middleName, "") & " " & lastName
                            requesterName.Text = fullName
                        End If
                        
                        ' Fill position
                        If profile.ContainsKey("position") AndAlso profile("position") IsNot Nothing Then
                            position.Text = profile("position").ToString()
                        End If
                        
                        ' Fill department
                        If profile.ContainsKey("departmentId") AndAlso profile("departmentId") IsNot Nothing Then
                            Try
                                Dim deptID As Integer = Convert.ToInt32(profile("departmentId"))
                                If department IsNot Nothing AndAlso department.DataSource IsNot Nothing Then
                                    department.SelectedValue = deptID
                                ElseIf department IsNot Nothing Then
                                    department.Text = deptID.ToString()
                                End If
                            Catch
                            End Try
                        End If
                    End If
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine("AddPropertyRequest_Load Profile Error: " & ex.Message)
                End Try
            End If
            
            ' Set default date to today if not set
            If DateTimePicker1.Value = DateTimePicker1.MinDate Then
                DateTimePicker1.Value = Date.Now
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("AddPropertyRequest_Load Error: " & ex.Message)
        End Try
    End Sub
End Class