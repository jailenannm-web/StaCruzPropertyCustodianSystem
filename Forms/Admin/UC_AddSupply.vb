Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class UC_AddSupply
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        ' Load categories from database
        Try
            Dim categories As DataTable = DatabaseConnection.GetCategories("supply")
            If categories IsNot Nothing AndAlso categories.Rows.Count > 0 Then
                pm_as_cmbobxCateg.Items.Clear()
                For Each row As DataRow In categories.Rows
                    Dim categoryName As String = ""
                    If row.Table.Columns.Contains("category_name") AndAlso Not IsDBNull(row("category_name")) Then
                        categoryName = row("category_name").ToString()
                    ElseIf row.Table.Columns.Contains("categoryName") AndAlso Not IsDBNull(row("categoryName")) Then
                        categoryName = row("categoryName").ToString()
                    ElseIf row.Table.Columns.Count > 0 AndAlso Not IsDBNull(row(0)) Then
                        categoryName = row(0).ToString()
                    End If
                    If Not String.IsNullOrEmpty(categoryName) AndAlso Not pm_as_cmbobxCateg.Items.Contains(categoryName) Then
                        pm_as_cmbobxCateg.Items.Add(categoryName)
                    End If
                Next
            Else
                ' Fallback to hardcoded categories
                pm_as_cmbobxCateg.Items.AddRange(New String() {"Stationery", "Electronics", "Furniture", "Equipment", "Office Supplies", "Cleaning Supplies", "Medical Supplies", "Other"})
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Error loading categories: " & ex.Message)
            pm_as_cmbobxCateg.Items.AddRange(New String() {"Stationery", "Electronics", "Furniture", "Equipment", "Office Supplies", "Cleaning Supplies", "Medical Supplies", "Other"})
        End Try
        
        ' Initialize status combobox
        pm_as_cmbobxStatus.Items.Clear()
        pm_as_cmbobxStatus.Items.AddRange(New String() {"Available", "Low Stock", "Out of Stock"})
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles pm_as_btnSave.Click
        ' Validate inputs and add supply to database
        If String.IsNullOrWhiteSpace(um_as_txtSupplyID.Text) Or String.IsNullOrWhiteSpace(pm_as_txtName.Text) Then
            MessageBox.Show("Supply ID and Name are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If pm_as_cmbobxCateg.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If pm_as_cmbobxStatus.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Parse numeric values
            Dim stock As Integer = CInt(pm_as_numericStock.Value)
            Dim unitCost As Decimal = If(Decimal.TryParse(pm_as_txtUnitCost.Text, unitCost), unitCost, 0)
            Dim totalValue As Decimal = stock * unitCost

            ' Validate Date Received - use today if not provided (Date Received field may not exist in form)
            Dim dateReceived As Date = Date.Today
            
            ' Validate location
            If String.IsNullOrWhiteSpace(pm_as_txtLocation.Text) Then
                MessageBox.Show("Location is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Call database function with all required parameters including dateReceived
            Dim success As Boolean = DatabaseConnection.AddSupply(
                um_as_txtSupplyID.Text.Trim(),
                pm_as_txtName.Text.Trim(),
                pm_as_cmbobxCateg.SelectedItem.ToString(),
                stock,
                unitCost,
                totalValue,
                pm_as_cmbobxStatus.SelectedItem.ToString(),
                pm_as_txtLocation.Text.Trim(),
                "",  ' description - empty
                "",  ' uom (unit of measure) - empty
                0,   ' reorderLevel - empty
                "",  ' supplierID - empty
                dateReceived  ' dateReceived - use today's date
            )

            If success Then
                MessageBox.Show("Supply added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                
                ' Navigate back to Supply Management list
                Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
                If parentDashboard IsNot Nothing Then
                    parentDashboard.LoadUserControl(New UC_SupplyManagement())
                Else
                    ' Fallback: try to refresh parent control
                    Dim parentForm As Control = Me.Parent
                    While parentForm IsNot Nothing
                        If TypeOf parentForm Is UC_SupplyManagement Then
                            CType(parentForm, UC_SupplyManagement).LoadSuppliesData()
                            Exit While
                        End If
                        parentForm = parentForm.Parent
                    End While
                    Me.Parent.Controls.Remove(Me)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error adding supply: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] Add Supply Error: " & ex.Message)
        End Try
    End Sub

    ' Helper method to clear form
    Private Sub ClearForm()
        um_as_txtSupplyID.Clear()
        pm_as_txtName.Clear()
        pm_as_cmbobxCateg.SelectedIndex = -1
        pm_as_numericStock.Value = 0
        pm_as_txtUnitCost.Clear()
        pm_as_txtLocation.Clear()
        pm_as_cmbobxStatus.SelectedIndex = -1
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles pm_as_btnCancel.Click
        ' Close the UserControl when Cancel is clicked
        Me.Parent.Controls.Remove(Me)
    End Sub
End Class
