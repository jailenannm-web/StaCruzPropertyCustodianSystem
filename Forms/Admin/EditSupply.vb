Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports Microsoft.VisualBasic

Public Class EditSupply
    Inherits UserControl

    Private currentSupplyID As Integer

    Public Sub LoadSupplyData(supplyIDParam As Integer, supplyRow As DataRow)
        currentSupplyID = supplyIDParam

        Try
            ' Map database columns to form fields using correct column names
            If supplyRow.Table.Columns.Contains("item_name") AndAlso Not IsDBNull(supplyRow("item_name")) Then
                supplyName.Text = supplyRow("item_name").ToString()
            End If

            If supplyRow.Table.Columns.Contains("category") AndAlso Not IsDBNull(supplyRow("category")) Then
                categoryCmbo.Text = supplyRow("category").ToString()
                ' Try to select the category in the combo box
                Dim categoryIndex As Integer = categoryCmbo.FindStringExact(supplyRow("category").ToString())
                If categoryIndex >= 0 Then
                    categoryCmbo.SelectedIndex = categoryIndex
                End If
            End If

            If supplyRow.Table.Columns.Contains("quantity") AndAlso Not IsDBNull(supplyRow("quantity")) Then
                Dim qtyValue As Integer = 0
                If Integer.TryParse(supplyRow("quantity").ToString(), qtyValue) Then
                    stockSupply.Value = qtyValue
                End If
            End If

            If supplyRow.Table.Columns.Contains("unit_of_measure") AndAlso Not IsDBNull(supplyRow("unit_of_measure")) Then
                ComboBox1.Text = supplyRow("unit_of_measure").ToString()
            End If

            If supplyRow.Table.Columns.Contains("supplier") AndAlso Not IsDBNull(supplyRow("supplier")) Then
                supplierTxt.Text = supplyRow("supplier").ToString()
            End If

            If supplyRow.Table.Columns.Contains("description") AndAlso Not IsDBNull(supplyRow("description")) Then
                remarksTxt.Text = supplyRow("description").ToString()
            End If

            If supplyRow.Table.Columns.Contains("unit_cost") AndAlso Not IsDBNull(supplyRow("unit_cost")) Then
                TextBox1.Text = supplyRow("unit_cost").ToString()
            End If

            If supplyRow.Table.Columns.Contains("location") AndAlso Not IsDBNull(supplyRow("location")) Then
                TextBox2.Text = supplyRow("location").ToString()
            End If

            If supplyRow.Table.Columns.Contains("date_received") AndAlso Not IsDBNull(supplyRow("date_received")) Then
                Dim dateValue As Date
                If Date.TryParse(supplyRow("date_received").ToString(), dateValue) Then
                    DateTimePicker1.Value = dateValue
                End If
            End If

            If supplyRow.Table.Columns.Contains("supply_id") AndAlso Not IsDBNull(supplyRow("supply_id")) Then
                Me.supplyID.Text = supplyRow("supply_id").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading supply data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Diagnostics.Debug.WriteLine("[v0] EditSupply.LoadSupplyData Exception: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub EditSupply_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Optional initialization
    End Sub

End Class
