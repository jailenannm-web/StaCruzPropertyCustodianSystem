Imports System
Imports System.Collections.Generic
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
        
        ' Load suppliers
        LoadSuppliers()
        
        ' Load unit of measures
        LoadUnitOfMeasures()

        ' Set default date to today
        dtpDateReceived.Value = Date.Today
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
    
    Private Sub LoadUsers()
        Try
            ' Load users for Assigned To dropdown
            Using conn As MySqlConnection = DatabaseConnection.GetConnection()
                If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                    Using cmd As New MySqlCommand("SELECT userId, CONCAT(IFNULL(firstName,''), ' ', IFNULL(lastName,'')) AS fullName FROM users WHERE status = 'Active' ORDER BY firstName, lastName", conn)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            cboAssignedTo.Items.Clear()
                            cboAssignedTo.Items.Add("-- Not Assigned --")

                            While reader.Read()
                                Dim userItem As New UserItem() With {
                                    .UserId = CInt(reader("userId")),
                                    .FullName = reader("fullName").ToString()
                                }
                                cboAssignedTo.Items.Add(userItem)
                            End While

                            cboAssignedTo.SelectedIndex = 0
                        End Using
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSuppliers()
        Try
            Dim suppliers As List(Of String) = DatabaseConnection.GetAllSuppliers()
            cboSupplier.Items.Clear()
            cboSupplier.Items.Add("-- Select or Type Supplier --")

            For Each supplier As String In suppliers
                cboSupplier.Items.Add(supplier)
            Next

            cboSupplier.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUnitOfMeasures()
        Try
            Dim units As List(Of String) = DatabaseConnection.GetAllUnitOfMeasures()
            cboUnitOfMeasure.Items.Clear()
            cboUnitOfMeasure.Items.Add("-- Select or Type Unit --")

            For Each unit As String In units
                cboUnitOfMeasure.Items.Add(unit)
            Next

            cboUnitOfMeasure.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error loading unit of measures: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Note: Supplies don't have direct assignedTo field in database.
    ''' When supplies are assigned to staff, they are tracked through:
    ''' 1. The custodian table (for inventory tracking)
    ''' 2. Quantity deduction from supplies table
    ''' This happens during the assignment/request approval process, not during add/edit.
    ''' </summary>

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

    ' Helper class to store user information
    Private Class UserItem
        Public Property UserId As Integer
        Public Property FullName As String

        Public Overrides Function ToString() As String
            Return FullName
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

        If cboUnitOfMeasure.SelectedIndex <= 0 AndAlso String.IsNullOrWhiteSpace(cboUnitOfMeasure.Text) Then
            MessageBox.Show("Please enter the unit of measure.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboUnitOfMeasure.Focus()
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

            ' Get assignedTo user ID (if selected)
            Dim assignedToId As Integer? = Nothing
            If cboAssignedTo.SelectedIndex > 0 AndAlso TypeOf cboAssignedTo.SelectedItem Is UserItem Then
                assignedToId = CType(cboAssignedTo.SelectedItem, UserItem).UserId
            End If

            Dim success = DatabaseConnection.AddSupply(
                txtItemName.Text.Trim(),
                GetComboValue(cboCategory, "Others"),
                txtDescription.Text.Trim(),
                GetComboValue(cboUnitOfMeasure, ""),
                CInt(numQuantity.Value),
                dtpDateReceived.Value,
                numUnitCost.Value,
                totalCost,
                GetComboValue(cboSupplier, ""),
                GetComboValue(cboSourceOfFunds, ""),
                txtLocation.Text.Trim(),
                GetComboValue(cboStockStatus, "Available"),
                assignedToId
            )

            If success Then
                ' If supply is assigned to a user, create borrowed_items record
                If assignedToId.HasValue AndAlso assignedToId.Value > 0 Then
                    Try
                        Dim conn As MySqlConnection = DatabaseConnection.GetConnection()
                        If conn IsNot Nothing AndAlso DatabaseConnection.SafeOpenConnection(conn) Then
                            ' Get the newly created supply ID
                            Dim newSupplyId As Integer = 0
                            Using cmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn)
                                Dim result = cmd.ExecuteScalar()
                                If result IsNot Nothing Then
                                    newSupplyId = Convert.ToInt32(result)
                                End If
                            End Using

                            If newSupplyId > 0 Then
                                ' Create borrowed_items record
                                Dim borrowQuery As String = "INSERT INTO borrowed_items (itemType, itemId, itemName, borrowerName, borrowerPosition, " &
                                                            "departmentId, borrowDate, returnReason, status, remarks, createdAt, updatedAt) " &
                                                            "SELECT 'supply', s.supplyId, s.itemName, CONCAT(u.firstName, ' ', u.lastName), u.position, " &
                                                            "u.departmentId, NOW(), NULL, 'Borrowed', @remarks, NOW(), NOW() " &
                                                            "FROM supplies s, users u WHERE s.supplyId = @supplyId AND u.userId = @userId"

                                Using borrowCmd As New MySqlCommand(borrowQuery, conn)
                                    borrowCmd.Parameters.AddWithValue("@supplyId", newSupplyId)
                                    borrowCmd.Parameters.AddWithValue("@userId", assignedToId.Value)
                                    borrowCmd.Parameters.AddWithValue("@remarks", "Supply assigned: " & txtItemName.Text.Trim())
                                    borrowCmd.ExecuteNonQuery()
                                End Using

                                System.Diagnostics.Debug.WriteLine($"[v0] AddSupply - Created borrowed_items record for supplyId: {newSupplyId}, userId: {assignedToId.Value}")
                            End If

                            If conn.State = ConnectionState.Open Then conn.Close()
                        End If
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine("[v0] AddSupply - Error creating borrowed_items: " & ex.Message)
                        ' Don't fail the add operation if borrowed_items creation fails
                    End Try
                End If

                MessageBox.Show("Supply added successfully!" & If(assignedToId.HasValue, Environment.NewLine & "The supply will appear in the assigned user's 'My Borrowed Items'.", ""), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
