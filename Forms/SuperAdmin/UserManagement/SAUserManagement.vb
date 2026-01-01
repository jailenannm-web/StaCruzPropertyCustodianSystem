Imports System.Linq
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic
Imports System.Data

Public Class SAUserManagement
    Private originalUserData As DataTable = Nothing
    Private isSearching As Boolean = False
    
    Private Sub SAUserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureDataGrid()
        LoadAllUsers()
        
        ' Wire up search textbox
        AddHandler TextBox1.TextChanged, AddressOf Search_TextChanged
    End Sub

    Private Sub ConfigureDataGrid()
        Try
            DataGridView1.AutoGenerateColumns = False
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.MultiSelect = False
            DataGridView1.ReadOnly = True
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[SAUserManagement] ConfigureDataGrid Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadAllUsers()
        Try
            DataGridView1.Rows.Clear()
            
            ' Get all users from database
            Dim dt As DataTable = modDB.GetAllUsers("", "", "")
            
            If dt IsNot Nothing Then
                originalUserData = dt.Copy()
                
                For Each row As DataRow In dt.Rows
                    ' Add row to DataGridView matching column order: FirstName, MiddleName, LastName, Suffix, Position, 
                    ' DepartmentID, EmployeeID, ContactNumber, Email, UserName, Province, Municipality, Barangay, HouseNoStreet, Password
                    DataGridView1.Rows.Add(
                        SafeValue(row, "firstName"),
                        SafeValue(row, "middleName"),
                        SafeValue(row, "lastName"),
                        SafeValue(row, "suffix"),
                        SafeValue(row, "position"),
                        SafeValue(row, "departmentId"),
                        SafeValue(row, "employeeId"),
                        SafeValue(row, "contactNumber"),
                        SafeValue(row, "email"),
                        SafeValue(row, "username"),
                        SafeValue(row, "province_city"),
                        SafeValue(row, "municipality"),
                        SafeValue(row, "barangay"),
                        "",
                        "******"
                    )
                Next
                
                ' Update total count label if it exists
                Try
                    Dim totalLabel As Label = TryCast(Me.Controls.Find("lblTotalUsers", True).FirstOrDefault(), Label)
                    If totalLabel IsNot Nothing Then
                        totalLabel.Text = dt.Rows.Count.ToString()
                    End If
                Catch
                    ' Label not found, continue
                End Try
                
                System.Diagnostics.Debug.WriteLine("[SAUserManagement] Loaded " & dt.Rows.Count & " users")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[SAUserManagement] LoadAllUsers Error: " & ex.Message)
            MessageBox.Show("Error loading users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Shared Function SafeValue(row As DataRow, columnName As String) As String
        If Not row.Table.Columns.Contains(columnName) Then Return ""
        Dim value = row(columnName)
        Return If(value Is DBNull.Value OrElse value Is Nothing, "", value.ToString())
    End Function

    Private Sub Search_TextChanged(sender As Object, e As EventArgs)
        ApplySearch(TextBox1.Text)
    End Sub

    Private Sub ApplySearch(searchText As String)
        If originalUserData Is Nothing Then Return
        If isSearching Then Return
        isSearching = True
        
        Try
            Dim searchLower As String = If(String.IsNullOrWhiteSpace(searchText), String.Empty, searchText.Trim().ToLower())
            
            If String.IsNullOrEmpty(searchLower) Then
                LoadAllUsers()
                isSearching = False
                Return
            End If
            
            ' Filter original data
            Dim filtered = originalUserData.AsEnumerable().Where(Function(row)
                Dim firstName As String = SafeValue(row, "firstName").ToLower()
                Dim middleName As String = SafeValue(row, "middleName").ToLower()
                Dim lastName As String = SafeValue(row, "lastName").ToLower()
                Dim username As String = SafeValue(row, "username").ToLower()
                Dim email As String = SafeValue(row, "email").ToLower()
                Dim employeeId As String = SafeValue(row, "employeeId").ToLower()
                
                Return firstName.Contains(searchLower) OrElse middleName.Contains(searchLower) OrElse 
                       lastName.Contains(searchLower) OrElse username.Contains(searchLower) OrElse 
                       email.Contains(searchLower) OrElse employeeId.Contains(searchLower)
            End Function)
            
            ' Clear and repopulate grid
            DataGridView1.Rows.Clear()
            For Each row As DataRow In filtered
                DataGridView1.Rows.Add(
                    SafeValue(row, "firstName"),
                    SafeValue(row, "middleName"),
                    SafeValue(row, "lastName"),
                    SafeValue(row, "suffix"),
                    SafeValue(row, "position"),
                    SafeValue(row, "departmentId"),
                    SafeValue(row, "employeeId"),
                    SafeValue(row, "contactNumber"),
                    SafeValue(row, "email"),
                    SafeValue(row, "username"),
                    SafeValue(row, "province_city"),
                    SafeValue(row, "municipality"),
                    SafeValue(row, "barangay"),
                    "",
                    "******"
                )
            Next
            
            ' Update total count
            Try
                Dim totalLabel As Label = TryCast(Me.Controls.Find("lblTotalUsers", True).FirstOrDefault(), Label)
                If totalLabel IsNot Nothing Then
                    totalLabel.Text = filtered.Count().ToString()
                End If
            Catch
            End Try
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[SAUserManagement] ApplySearch Error: " & ex.Message)
        Finally
            isSearching = False
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ' Search icon click - focus on search textbox
        TextBox1.Focus()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Open AddUserManagement form for Super Admin
        Dim saDashboard = TryCast(Me.ParentForm, SADashboard)
        If saDashboard IsNot Nothing Then
            Try
                saDashboard.LoadUserControl(New AddUserManagement())
                Return
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[SAUserManagement] btnAdd SADashboard Error: " & ex.Message)
            End Try
        End If
        
        ' Fallback - open AddUserManagement (UserControl, not Form)
        MessageBox.Show("Unable to open Add User form. Please ensure you are using the Super Admin dashboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        Dim selectedRow = DataGridView1.SelectedRows(0)
        Dim username As String = If(selectedRow.Cells("UserName").Value IsNot Nothing, selectedRow.Cells("UserName").Value.ToString(), "")
        Dim fullName As String = selectedRow.Cells("FirstName").Value.ToString() & " " & selectedRow.Cells("LastName").Value.ToString()
        
        Dim result = MessageBox.Show($"Are you sure you want to delete user '{fullName}' (Username: {username})?", 
                                     "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            ' Implement delete logic here when ready
            MessageBox.Show("Delete functionality to be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        ' Implement edit/update logic here when ready
        MessageBox.Show("Update functionality to be implemented", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class