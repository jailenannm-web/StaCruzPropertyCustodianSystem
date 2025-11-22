Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class UC_AddSupply
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        ' Initialize combobox options
        pm_as_cmbobxCateg.Items.AddRange(New String() {"Stationery", "Electronics", "Furniture", "Equipment", "Other"})
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

            ' Call database function with all 12 required parameters
            ' Passing empty strings for optional fields not present in this form
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
                ""   ' supplierID - empty
            )

            If success Then
                ' Clear form fields after successful add
                ClearForm()
                
                ' Refresh the Property Management data grid
                Dim parentForm As Control = Me.Parent
                While parentForm IsNot Nothing
                    If TypeOf parentForm Is UC_SupplyManagement Then
                        CType(parentForm, UC_SupplyManagement).LoadSuppliesData()
                        Exit While
                    End If
                    parentForm = parentForm.Parent
                End While
                
                ' Also try to refresh if parent is a form with Property Management control
                If Me.Parent IsNot Nothing Then
                    For Each ctrl As Control In Me.Parent.Controls
                        If TypeOf ctrl Is UC_SupplyManagement Then
                            CType(ctrl, UC_SupplyManagement).LoadSuppliesData()
                        End If
                    Next
                End If
                
                ' Notify parent form to refresh data
                Me.Parent.Controls.Remove(Me)
                MessageBox.Show("Supply added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
