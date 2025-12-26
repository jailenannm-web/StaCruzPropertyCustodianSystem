Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class AddSupply
    Public Sub New()
        InitializeComponent()
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        ' Initialize Category dropdown
        If cboCategory.Items.Count = 0 Then
            cboCategory.Items.AddRange(New Object() {
                "Office Supplies", "Cleaning Supplies", "Medical Supplies",
                "IT Supplies", "Laboratory Supplies", "Others"
            })
        End If

        ' Initialize Stock Status dropdown
        If cboStockStatus.Items.Count = 0 Then
            cboStockStatus.Items.AddRange(New Object() {"Available", "Low Stock", "Out of Stock"})
        End If

        ' Initialize Source of Funds dropdown
        If cboSourceOfFunds.Items.Count = 0 Then
            cboSourceOfFunds.Items.AddRange(New Object() {
                "General Fund", "Special Education Fund", "Trust Fund", "Donation", "Others"
            })
        End If

        ' Load departments
        LoadDepartments()
        
        ' Load users for assignment
        LoadUsers()

        ' Set default date to today
        dtpDateReceived.Value = Date.Today
        
        ' Dynamically create Assigned To control if it doesn't exist
        CreateAssignedToControlIfNeeded()
    End Sub
    
    Private Sub CreateAssignedToControlIfNeeded()
        Try
            ' Check if control already exists
            Dim existingControls() As Control = Me.Controls.Find("cboAssignedTo", True)
            If existingControls.Length > 0 Then
                Return ' Control already exists
            End If
            
            ' Find a reference control to position near (e.g., cboStockStatus)
            Dim referenceControl As Control = Nothing
            
            ' Try to find stock status combo box
            Dim stockControls() As Control = Me.Controls.Find("cboStockStatus", True)
            If stockControls.Length > 0 Then
                referenceControl = stockControls(0)
            Else
                ' Try to find category combo box
                Dim catControls() As Control = Me.Controls.Find("cboCategory", True)
                If catControls.Length > 0 Then
                    referenceControl = catControls(0)
                End If
            End If
            
            If referenceControl Is Nothing Then
                System.Diagnostics.Debug.WriteLine("Could not find reference control for positioning")
                Return
            End If
            
            ' Create Label
            Dim lblAssignedTo As New Label()
            lblAssignedTo.Name = "lblAssignedTo"
            lblAssignedTo.Text = "Assigned To:"
            lblAssignedTo.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            lblAssignedTo.AutoSize = True
            lblAssignedTo.Location = New Point(referenceControl.Left - 150, referenceControl.Bottom + 10)
            
            ' Create ComboBox
            Dim cboAssignedTo As New ComboBox()
            cboAssignedTo.Name = "cboAssignedTo"
            cboAssignedTo.DropDownStyle = ComboBoxStyle.DropDownList
            cboAssignedTo.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            cboAssignedTo.Size = New Size(referenceControl.Width, 25)
            cboAssignedTo.Location = New Point(referenceControl.Left, referenceControl.Bottom + 10)
            
            ' Add controls to form
            If referenceControl.Parent IsNot Nothing Then
                referenceControl.Parent.Controls.Add(lblAssignedTo)
                referenceControl.Parent.Controls.Add(cboAssignedTo)
            Else
                Me.Controls.Add(lblAssignedTo)
                Me.Controls.Add(cboAssignedTo)
            End If
            
            System.Diagnostics.Debug.WriteLine("[v0] Assigned To control created dynamically in AddSupply")
            
            ' Reload users to populate the new control
            LoadUsers()
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Error creating Assigned To control: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadDepartments()
        Try
            Dim dt As DataTable = DatabaseConnection.GetAllDepartments()
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                cboDepartment.Items.Clear()
                cboDepartment.Items.Add("-- Select Department --")
                
                For Each row As DataRow In dt.Rows
                    Dim deptItem As New DepartmentItem() With {
                        .DepartmentId = CInt(row("departmentId")),
                        .DepartmentName = row("departmentName").ToString(),
                        .Location = If(row.IsNull("location"), "", row("location").ToString())
                    }
                    cboDepartment.Items.Add(deptItem)
                Next
                
                cboDepartment.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private usersDirectory As DataTable
    
    Private Sub LoadUsers()
        Try
            ' Load users for Assigned To dropdown
            Using conn As MySqlConnection = DatabaseConnection.GetConnection()
                If conn IsNot Nothing Then
                    conn.Open()
                    Using cmd As New MySqlCommand("SELECT userId, CONCAT(IFNULL(firstName,''), ' ', IFNULL(lastName,'')) AS fullName, employeeId FROM users WHERE status = 'Active' ORDER BY firstName, lastName", conn)
                        Using adapter As New MySqlDataAdapter(cmd)
                            usersDirectory = New DataTable()
                            adapter.Fill(usersDirectory)

                            If usersDirectory.Rows.Count > 0 Then
                                ' Add a blank row for "Not Assigned"
                                Dim blankRow As DataRow = usersDirectory.NewRow()
                                blankRow("userId") = DBNull.Value
                                blankRow("fullName") = "-- Not Assigned --"
                                blankRow("employeeId") = DBNull.Value
                                usersDirectory.Rows.InsertAt(blankRow, 0)

                                ' Check if cboAssignedTo control exists
                                Dim assignedToControls() As Control = Me.Controls.Find("cboAssignedTo", True)
                                If assignedToControls.Length > 0 AndAlso TypeOf assignedToControls(0) Is ComboBox Then
                                    Dim cboAssignedTo As ComboBox = CType(assignedToControls(0), ComboBox)
                                    cboAssignedTo.DataSource = usersDirectory
                                    cboAssignedTo.DisplayMember = "fullName"
                                    cboAssignedTo.ValueMember = "userId"
                                    cboAssignedTo.SelectedIndex = 0
                                End If
                            End If
                        End Using
                    End Using
                End If
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("LoadUsers Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged
        If cboDepartment.SelectedIndex > 0 AndAlso TypeOf cboDepartment.SelectedItem Is DepartmentItem Then
            Dim selectedDept As DepartmentItem = CType(cboDepartment.SelectedItem, DepartmentItem)
            txtLocation.Text = selectedDept.Location
        Else
            txtLocation.Text = ""
        End If
    End Sub

    ' Helper class to store department information
    Private Class DepartmentItem
        Public Property DepartmentId As Integer
        Public Property DepartmentName As String
        Public Property Location As String

        Public Overrides Function ToString() As String
            Return DepartmentName
        End Function
    End Class

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate required fields
        If String.IsNullOrWhiteSpace(txtItemName.Text) Then
            MessageBox.Show("Please enter the item name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtItemName.Focus()
            Return
        End If

        If cboCategory.SelectedIndex < 0 Then
            MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtUnitOfMeasure.Text) Then
            MessageBox.Show("Please enter the unit of measure.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitOfMeasure.Focus()
            Return
        End If

        If numQuantity.Value <= 0 Then
            MessageBox.Show("Please enter a quantity greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numQuantity.Focus()
            Return
        End If

        If numUnitCost.Value <= 0 Then
            MessageBox.Show("Please enter a unit cost greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numUnitCost.Focus()
            Return
        End If

        Try
            ' Calculate total cost
            Dim totalCost As Decimal = numQuantity.Value * numUnitCost.Value

            ' Get assigned user ID
            Dim assignedTo As Integer? = Nothing
            Dim assignedToControls() As Control = Me.Controls.Find("cboAssignedTo", True)
            If assignedToControls.Length > 0 AndAlso TypeOf assignedToControls(0) Is ComboBox Then
                Dim cboAssignedTo As ComboBox = CType(assignedToControls(0), ComboBox)
                If cboAssignedTo.SelectedValue IsNot Nothing AndAlso Not cboAssignedTo.SelectedValue.Equals(DBNull.Value) Then
                    assignedTo = CInt(cboAssignedTo.SelectedValue)
                End If
            End If

            Dim success = DatabaseConnection.AddSupply(
                txtItemName.Text.Trim(),
                GetComboValue(cboCategory, "Others"),
                txtDescription.Text.Trim(),
                txtUnitOfMeasure.Text.Trim(),
                CInt(numQuantity.Value),
                dtpDateReceived.Value,
                numUnitCost.Value,
                totalCost,
                txtSupplier.Text.Trim(),
                GetComboValue(cboSourceOfFunds, ""),
                assignedTo,
                txtLocation.Text.Trim(),
                GetComboValue(cboStockStatus, "Available")
            )

            If success Then
                MessageBox.Show("Supply added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NavigateBackToList()
            End If
        Catch ex As Exception
            MessageBox.Show("Error adding supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBackToList()
    End Sub

    Private Function GetComboValue(combo As ComboBox, Optional fallback As String = "") As String
        If combo Is Nothing Then Return fallback
        If combo.SelectedIndex >= 0 AndAlso combo.SelectedItem IsNot Nothing Then
            Return combo.SelectedItem.ToString()
        End If
        If Not String.IsNullOrWhiteSpace(combo.Text) Then
            Return combo.Text.Trim()
        End If
        Return fallback
    End Function

    Private Sub NavigateBackToList()
        Dim parentForm = Me.FindForm()
        If TypeOf parentForm Is SADashboard Then
            Dim dashboard = CType(parentForm, SADashboard)
            dashboard.LoadUserControl(New UC_SupplyManagement())
        ElseIf TypeOf parentForm Is AdminDashboard Then
            Dim dashboard = CType(parentForm, AdminDashboard)
            dashboard.LoadUserControl(New UC_SupplyManagement())
        End If
    End Sub

    Private Sub numQuantity_ValueChanged(sender As Object, e As EventArgs) Handles numQuantity.ValueChanged
        UpdateTotalCost()
    End Sub

    Private Sub numUnitCost_ValueChanged(sender As Object, e As EventArgs) Handles numUnitCost.ValueChanged
        UpdateTotalCost()
    End Sub

    Private Sub UpdateTotalCost()
        Try
            txtTotalCost.Text = (numQuantity.Value * numUnitCost.Value).ToString("N2")
        Catch
            txtTotalCost.Text = "0.00"
        End Try
    End Sub
End Class
