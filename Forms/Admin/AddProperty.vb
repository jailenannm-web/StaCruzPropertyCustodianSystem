Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class AddProperty
    Inherits UserControl

    Private departmentDirectory As DataTable
    Private custodianDirectory As DataTable
    Private canModifyProperties As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        AddHandler Me.Load, AddressOf AddProperty_Load
    End Sub

    Private Sub AddProperty_Load(sender As Object, e As EventArgs)

        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        category.Items.Clear()
        category.Items.AddRange(New Object() {
            "Furniture", "Equipment", "Office Supplies", "IT Equipment",
            "Laboratory Apparatus", "Books and Publications",
            "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
        })
        If category.Items.Count > 0 Then category.SelectedIndex = 0

        condition.Items.Clear()
        condition.Items.AddRange(New Object() {"good", "needs repair", "damaged"})
        If condition.Items.Count > 0 Then condition.SelectedIndex = 0

        LoadDepartments()
        LoadCustodians()

        acquisitionDate.Value = Date.Today
        warrantyExpirationDate.Value = Date.Today.AddYears(1)
    End Sub

    Private Sub LoadDepartments()
        Try
            departmentDirectory = DatabaseConnection.GetDepartmentLookup(True)
            department.DataSource = departmentDirectory
            department.DisplayMember = "department_name"
            department.ValueMember = "department_id"
            department.SelectedIndex = If(departmentDirectory.Rows.Count > 0, 0, -1)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddProperty.LoadDepartments Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadCustodians()
        Try
            custodianDirectory = DatabaseConnection.GetActiveUsersForAssignment(New String() {"Admin", "Custodian", "Staff"})
            If custodianDirectory Is Nothing Then Return

            Dim suggestions As New AutoCompleteStringCollection()
            For Each row As DataRow In custodianDirectory.Rows
                suggestions.Add($"{row("user_id")} - {row("full_name")}")
            Next

            assignedTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            assignedTo.AutoCompleteSource = AutoCompleteSource.CustomSource
            assignedTo.AutoCompleteCustomSource = suggestions
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddProperty.LoadCustodians Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim validationError = ValidateFields()
        If Not String.IsNullOrEmpty(validationError) Then
            MessageBox.Show(validationError, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim departmentId As Integer? = Nothing
        If department.SelectedValue IsNot Nothing Then
            departmentId = Convert.ToInt32(department.SelectedValue)
        End If

        Dim custodianId As Integer? = ResolveCustodianId()

        ' Parse acquisition cost
        Dim acquisitionCostValue As Decimal = 0
        If Not String.IsNullOrWhiteSpace(acquisitionCost.Text) Then
            If Not Decimal.TryParse(acquisitionCost.Text.Trim(), acquisitionCostValue) Then
                MessageBox.Show("Please enter a valid acquisition cost.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                acquisitionCost.Focus()
                Return
            End If
        End If

        ' Get description from description field
        Dim descriptionValue As String = ""
        If description IsNot Nothing Then
            descriptionValue = description.Text.Trim()
        End If

        ' Get property number if available
        Dim propertyNumberValue As String = ""
        If propertyNumber IsNot Nothing Then
            propertyNumberValue = propertyNumber.Text.Trim()
        End If

        Dim success = DatabaseConnection.AddProperty(
            itemName.Text.Trim(),                            ' propertyName
            GetComboValue(category, "Others"),                       ' category
            descriptionValue,                                        ' description
            serialNumberTxt.Text.Trim(),                             ' serialNumber
            acquisitionDate.Value,                                  ' acquisitionDate
            acquisitionCostValue,                                   ' acquisitionCost
            supplierTxt.Text.Trim(),                                 ' supplierName
            "",                                                      ' supplierContact
            GetComboValue(condition, "good"),                       ' conditionStatus
            propertyLocation.Text.Trim(),                           ' location
            custodianId,                                             ' custodianID
            departmentId,                                            ' departmentID
            warrantyExpirationDate.Value.ToShortDateString(),       ' warrantyDetails
            Nothing,                                                 ' lifeSpan
            propertyNumberValue                                      ' propertyNumber
        )

        If success Then
            MessageBox.Show("Property added successfully!", "Property Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBackToList()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBackToList()
    End Sub

    Private Sub NavigateBackToList()
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_PropertyManagement1())
        End If
    End Sub

    Private Function ValidateFields() As String
        If String.IsNullOrWhiteSpace(itemName.Text) Then Return "Property name is required."
        If category.SelectedIndex = -1 Then Return "Please select a category."
        If String.IsNullOrWhiteSpace(supplierTxt.Text) Then Return "Supplier is required."
        ' Validate acquisition cost from the correct field
        If String.IsNullOrWhiteSpace(acquisitionCost.Text) Then Return "Acquisition cost is required."
        Dim costValue As Decimal = 0
        If Not Decimal.TryParse(acquisitionCost.Text.Trim(), costValue) OrElse costValue <= 0 Then
            Return "Acquisition cost must be a valid number greater than zero."
        End If
        If String.IsNullOrWhiteSpace(propertyLocation.Text) Then Return "Location is required."
        Return ""
    End Function

    Private Function ResolveCustodianId() As Integer?
        Dim rawValue As String = assignedTo.Text.Trim()
        If String.IsNullOrWhiteSpace(rawValue) Then Return Nothing
        Dim candidate As String = rawValue
        If rawValue.Contains("-") Then candidate = rawValue.Split("-"c)(0).Trim()
        Dim parsed As Integer
        If Integer.TryParse(candidate, parsed) Then Return parsed
        Return Nothing
    End Function

    Private Shared Function GetComboValue(combo As ComboBox, Optional fallback As String = "") As String
        If combo Is Nothing Then Return fallback
        If combo.SelectedItem Is Nothing Then
            Dim textValue = combo.Text
            If Not String.IsNullOrWhiteSpace(textValue) Then
                Return textValue.Trim()
            End If
            Return fallback
        End If
        Return combo.SelectedItem.ToString()
    End Function



    Private Sub conditionStatusCmbo_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub datePurchasedDate_ValueChanged(sender As Object, e As EventArgs) Handles acquisitionDate.ValueChanged

    End Sub

    Private Sub AddProperty_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
