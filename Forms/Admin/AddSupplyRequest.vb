Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Public Class AddSupplyRequest
    Inherits System.Windows.Forms.UserControl
    
    Private _prefillItemName As String = ""
    Private _prefillItemDescription As String = ""
    Private _prefillCategory As String = ""
    Private _prefillAvailableQuantity As String = ""
    Private _prefillLocation As String = ""
    Private _prefillUnitOfMeasure As String = ""
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
    
    ' New constructor with all fields for Supply Inventory row click
    Public Sub New(itemName As String, itemDescription As String, category As String, availableQuantity As String, location As String, unitOfMeasure As String, requesterName As String, position As String, department As String, requestDate As String)
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        _prefillItemName = itemName
        _prefillItemDescription = itemDescription
        _prefillCategory = category
        _prefillAvailableQuantity = availableQuantity
        _prefillLocation = location
        _prefillUnitOfMeasure = unitOfMeasure
        _prefillRequesterName = requesterName
        _prefillPosition = position
        _prefillDepartment = department
        _prefillDate = requestDate
    End Sub

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

    Private Sub AddSupplyRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Bind Department dropdown (ComboBox) to real departments
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

            ' Bind Item Name dropdown to available supplies
            Try
                If itemName IsNot Nothing Then
                    ' Use Control intermediary to avoid direct cast issues
                    Dim itemNameCombo As ComboBox = Nothing
                    Dim ctl As Control = DirectCast(itemName, Control)
                    itemNameCombo = TryCast(ctl, ComboBox)
                    If itemNameCombo Is Nothing Then
                        ' It's a TextBox, just set the text if provided
                        If Not String.IsNullOrEmpty(_prefillItemName) Then
                            itemName.Text = _prefillItemName
                        End If
                    Else
                        ' It's a ComboBox, populate it
                        Dim supplyTable As DataTable = DatabaseConnection.GetAvailableSuppliesForDropdown()
                        If supplyTable IsNot Nothing AndAlso supplyTable.Rows.Count > 0 Then
                            itemNameCombo.DataSource = supplyTable
                            itemNameCombo.DisplayMember = "itemName"
                            itemNameCombo.ValueMember = "itemName"
                            
                            ' Select pre-filled item if provided
                            If Not String.IsNullOrEmpty(_prefillItemName) Then
                                Try
                                    Dim foundRow() As DataRow = supplyTable.Select("itemName = '" & _prefillItemName.Replace("'", "''") & "'")
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
                System.Diagnostics.Debug.WriteLine("AddSupplyRequest_Load ItemName Dropdown Error: " & ex.Message)
                ' Fallback: use as TextBox
                If Not String.IsNullOrEmpty(_prefillItemName) Then
                    itemName.Text = _prefillItemName
                End If
            End Try

            ' Pre-fill description, category, available quantity, location, and unit if provided
            If Not String.IsNullOrEmpty(_prefillItemDescription) Then
                description.Text = _prefillItemDescription
            End If
            
            ' Pre-fill category if provided
            If Not String.IsNullOrEmpty(_prefillCategory) Then
                Try
                    ' Try to find a category control and set it
                    Dim categoryControl As Control = Me.Controls.Find("category", True).FirstOrDefault()
                    If categoryControl IsNot Nothing AndAlso TypeOf categoryControl Is TextBox Then
                        CType(categoryControl, TextBox).Text = _prefillCategory
                    ElseIf categoryControl IsNot Nothing AndAlso TypeOf categoryControl Is ComboBox Then
                        CType(categoryControl, ComboBox).Text = _prefillCategory
                    End If
                Catch
                End Try
            End If
            
            ' Pre-fill available quantity if provided
            If Not String.IsNullOrEmpty(_prefillAvailableQuantity) Then
                Try
                    Dim availableQtyControl As Control = Me.Controls.Find("availableQuantity", True).FirstOrDefault()
                    If availableQtyControl IsNot Nothing AndAlso TypeOf availableQtyControl Is TextBox Then
                        CType(availableQtyControl, TextBox).Text = _prefillAvailableQuantity
                    ElseIf availableQtyControl IsNot Nothing AndAlso TypeOf availableQtyControl Is Label Then
                        CType(availableQtyControl, Label).Text = "Available: " & _prefillAvailableQuantity
                    End If
                Catch
                End Try
            End If
            
            ' Pre-fill location if provided
            If Not String.IsNullOrEmpty(_prefillLocation) Then
                Try
                    Dim locationControl As Control = Me.Controls.Find("location", True).FirstOrDefault()
                    If locationControl IsNot Nothing AndAlso TypeOf locationControl Is TextBox Then
                        CType(locationControl, TextBox).Text = _prefillLocation
                    End If
                Catch
                End Try
            End If
            
            ' Pre-fill unit if provided
            If Not String.IsNullOrEmpty(_prefillUnitOfMeasure) Then
                Try
                    Dim unitControl As Control = Me.Controls.Find("unit", True).FirstOrDefault()
                    If unitControl IsNot Nothing AndAlso TypeOf unitControl Is TextBox Then
                        CType(unitControl, TextBox).Text = _prefillUnitOfMeasure
                    ElseIf unitControl IsNot Nothing AndAlso TypeOf unitControl Is ComboBox Then
                        CType(unitControl, ComboBox).Text = _prefillUnitOfMeasure
                    End If
                Catch
                End Try
            End If

            ' Pre-fill requester name if provided
            If Not String.IsNullOrEmpty(_prefillRequesterName) Then
                Try
                    Dim requesterField As Control = Me.Controls.Find("TextBox1", True).FirstOrDefault()
                    If requesterField IsNot Nothing Then
                        requesterField.Text = _prefillRequesterName
                    End If
                Catch
                End Try
            End If

            ' Pre-fill position if provided
            If Not String.IsNullOrEmpty(_prefillPosition) Then
                Try
                    Dim positionField As Control = Me.Controls.Find("TextBox2", True).FirstOrDefault()
                    If positionField IsNot Nothing Then
                        positionField.Text = _prefillPosition
                    End If
                Catch
                End Try
            End If

            ' Pre-fill department if provided - try to match by name first
            If Not String.IsNullOrEmpty(_prefillDepartment) Then
                Try
                    ' Try to select by name
                    If department IsNot Nothing AndAlso department.DataSource IsNot Nothing Then
                        Dim deptTable As DataTable = CType(department.DataSource, DataTable)
                        For Each row As DataRow In deptTable.Rows
                            Dim deptName As String = ""
                            If deptTable.Columns.Contains("department_name") Then
                                deptName = row("department_name").ToString()
                            ElseIf deptTable.Columns.Contains("departmentName") Then
                                deptName = row("departmentName").ToString()
                            End If
                            If deptName.Equals(_prefillDepartment.Trim(), StringComparison.OrdinalIgnoreCase) Then
                                department.SelectedValue = row(department.ValueMember)
                                Exit For
                            End If
                        Next
                    ElseIf department IsNot Nothing Then
                        department.Text = _prefillDepartment
                    End If
                Catch ex As Exception
                    If department IsNot Nothing Then
                        department.Text = _prefillDepartment
                    End If
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
                            Try
                                Dim requesterField As Control = Me.Controls.Find("TextBox1", True).FirstOrDefault()
                                If requesterField IsNot Nothing Then
                                    requesterField.Text = fullName
                                End If
                            Catch
                            End Try
                        End If

                        ' Fill position
                        If profile.ContainsKey("position") AndAlso profile("position") IsNot Nothing Then
                            Try
                                Dim positionField As Control = Me.Controls.Find("TextBox2", True).FirstOrDefault()
                                If positionField IsNot Nothing Then
                                    positionField.Text = profile("position").ToString()
                                End If
                            Catch
                            End Try
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
                    System.Diagnostics.Debug.WriteLine("AddSupplyRequest_Load Profile Error: " & ex.Message)
                End Try
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("AddSupplyRequest_Load Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Validate required fields
            If String.IsNullOrWhiteSpace(description.Text) Then
                MessageBox.Show("Please enter the item name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                description.Focus()
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
            Dim itemNameCombo As ComboBox = Nothing
            If itemName IsNot Nothing Then
                Dim ctl As Control = DirectCast(itemName, Control)
                itemNameCombo = TryCast(ctl, ComboBox)
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
                If itemName IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(itemName.Text) Then
                    itemNameText = itemName.Text.Trim()
                ElseIf description IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(description.Text) Then
                    itemNameText = description.Text.Trim()
                End If
            End If
            
            If String.IsNullOrWhiteSpace(itemNameText) Then
                MessageBox.Show("Please select or enter the item name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If itemName IsNot Nothing Then itemName.Focus()
                Return
            End If

            ' Get position and requester name from form if available
            Dim positionText As String = ""
            Dim requesterNameText As String = ""
            Dim descriptionText As String = ""
            Dim unitText As String = ""
            
            Try
                Dim positionField As Control = Me.Controls.Find("TextBox2", True).FirstOrDefault()
                If positionField IsNot Nothing AndAlso TypeOf positionField Is TextBox Then
                    positionText = CType(positionField, TextBox).Text.Trim()
                End If
            Catch
            End Try
            
            Try
                Dim requesterField As Control = Me.Controls.Find("TextBox1", True).FirstOrDefault()
                If requesterField IsNot Nothing AndAlso TypeOf requesterField Is TextBox Then
                    requesterNameText = CType(requesterField, TextBox).Text.Trim()
                End If
            Catch
            End Try
            
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

            ' Submit supply request
            Dim success As Boolean = DatabaseConnection.StaffSubmitSupplyRequest(
                SessionContext.CurrentUserID.Value,
                itemNameText,
                quantity,
                purposeText,
                deptID,
                positionText, ' position
                requesterNameText, ' requester name
                descriptionText, ' description
                unitText ' unit
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
