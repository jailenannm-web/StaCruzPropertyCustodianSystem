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
            ' Validate required fields - handle both ComboBox and TextBox
            Dim itemNameValid As Boolean = False
            ' Declare once and reuse to avoid shadowing
            Dim itemNameCombo As ComboBox = Nothing
            If itemName IsNot Nothing Then
                ' Use Control as intermediary to allow TryCast even if itemName is declared as TextBox in designer
                Dim ctl As Control = DirectCast(itemName, Control)
                itemNameCombo = TryCast(ctl, ComboBox)
                If itemNameCombo IsNot Nothing Then
                    ' It's a ComboBox
                    itemNameValid = (itemNameCombo.SelectedValue IsNot Nothing) OrElse Not String.IsNullOrWhiteSpace(itemNameCombo.Text)
                Else
                    ' It's a TextBox
                    itemNameValid = Not String.IsNullOrWhiteSpace(itemName.Text)
                End If
            End If
            
            If Not itemNameValid Then
                MessageBox.Show("Please select or enter the item name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            ' Ensure item name is not empty - handle both ComboBox and TextBox
            Dim itemNameText As String = ""
            ' Reuse previously declared itemNameCombo (don't redeclare)
            If itemNameCombo Is Nothing AndAlso itemName IsNot Nothing Then
                Dim ctl2 As Control = DirectCast(itemName, Control)
                itemNameCombo = TryCast(ctl2, ComboBox)
            End If

            If itemNameCombo IsNot Nothing Then
                ' It's a ComboBox
                If itemNameCombo.SelectedValue IsNot Nothing Then
                    itemNameText = itemNameCombo.SelectedValue.ToString()
                ElseIf Not String.IsNullOrWhiteSpace(itemNameCombo.Text) Then
                    itemNameText = itemNameCombo.Text.Trim()
                End If
            Else
                ' It's a TextBox
                itemNameText = itemName.Text.Trim()
            End If
            
            If String.IsNullOrWhiteSpace(itemNameText) Then
                MessageBox.Show("Please select or enter the item name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If itemName IsNot Nothing Then itemName.Focus()
                Return
            End If

            ' Get position and requester name from current session if available
            Dim positionText As String = ""
            Dim requesterNameText As String = ""
            Dim descriptionText As String = ""
            Dim unitText As String = ""
            
            If position IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(position.Text) Then
                positionText = position.Text.Trim()
            End If
            If requesterName IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(requesterName.Text) Then
                requesterNameText = requesterName.Text.Trim()
            End If
            If description IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(description.Text) Then
                descriptionText = description.Text.Trim()
            End If
            
            ' Get unit from form if available
            Try
                Dim unitControl As Control = Me.Controls.Find("unit", True).FirstOrDefault()
                If unitControl Is Nothing Then
                    ' Try in Panel1
                    For Each ctrl As Control In Me.Controls
                        For Each subCtrl As Control In ctrl.Controls
                            If subCtrl.Name.ToLower().Contains("unit") Then
                                unitControl = subCtrl
                                Exit For
                            End If
                        Next
                        If unitControl IsNot Nothing Then Exit For
                    Next
                End If
                If unitControl IsNot Nothing Then
                    If TypeOf unitControl Is ComboBox Then
                        Dim unitCombo As ComboBox = CType(unitControl, ComboBox)
                        If unitCombo.SelectedValue IsNot Nothing Then
                            unitText = unitCombo.SelectedValue.ToString()
                        ElseIf Not String.IsNullOrWhiteSpace(unitCombo.Text) Then
                            unitText = unitCombo.Text.Trim()
                        End If
                    ElseIf TypeOf unitControl Is TextBox Then
                        unitText = CType(unitControl, TextBox).Text.Trim()
                    End If
                End If
            Catch
            End Try

            ' Submit property request
            Dim success As Boolean = DatabaseConnection.SubmitPropertyRequest(
                SessionContext.CurrentUserID.Value,
                itemNameText,
                purposeText,
                quantity,
                deptID,
                positionText, ' position
                requesterNameText, ' requester name
                descriptionText, ' description
                unitText ' unit
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

            ' Bind Item Name dropdown to available properties
            Try
                If itemName IsNot Nothing Then
                    ' Convert TextBox to ComboBox if needed - check if it's already a ComboBox
                    Dim itemNameCombo As ComboBox = Nothing
                    Dim ctl As Control = DirectCast(itemName, Control)
                    itemNameCombo = TryCast(ctl, ComboBox)
                    If itemNameCombo Is Nothing Then
                        ' It's a TextBox, we'll keep using it as TextBox but populate with data
                        ' For now, just set the text if provided
                        If Not String.IsNullOrEmpty(_prefillItemName) Then
                            itemName.Text = _prefillItemName
                        End If
                    Else
                        ' It's a ComboBox, populate it
                        Dim propTable As DataTable = DatabaseConnection.GetAvailablePropertiesForDropdown()
                        If propTable IsNot Nothing AndAlso propTable.Rows.Count > 0 Then
                            ' Create a display format with itemName and propertyNumber
                            propTable.Columns.Add("DisplayName", GetType(String), "itemName + IIF(propertyNumber IS NULL OR propertyNumber = '', '', ' (' + propertyNumber + ')')")
                            itemNameCombo.DataSource = propTable
                            itemNameCombo.DisplayMember = "DisplayName"
                            itemNameCombo.ValueMember = "itemName"
                            
                            ' Select pre-filled item if provided
                            If Not String.IsNullOrEmpty(_prefillItemName) Then
                                Try
                                    Dim foundRow() As DataRow = propTable.Select("itemName = '" & _prefillItemName.Replace("'", "''") & "'")
                                    If foundRow.Length > 0 Then
                                        itemNameCombo.SelectedValue = _prefillItemName
                                    Else
                                        itemNameCombo.Text = _prefillItemName
                                    End If
                                Catch
                                    itemNameCombo.Text = _prefillItemName
                                End Try
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("AddPropertyRequest_Load ItemName Dropdown Error: " & ex.Message)
                ' Fallback: use as TextBox
                If Not String.IsNullOrEmpty(_prefillItemName) Then
                    itemName.Text = _prefillItemName
                End If
            End Try
            
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