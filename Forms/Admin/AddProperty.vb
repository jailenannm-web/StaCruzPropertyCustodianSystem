Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class AddProperty
    Inherits UserControl

    Private departmentDirectory As DataTable
    Private custodianDirectory As DataTable

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        AddHandler Me.Load, AddressOf AddProperty_Load
    End Sub

    Private Sub AddProperty_Load(sender As Object, e As EventArgs)
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        categoryCmbo.Items.Clear()
        categoryCmbo.Items.AddRange(New Object() {
            "Furniture", "Equipment", "Office Supplies", "IT Equipment",
            "Laboratory Apparatus", "Books and Publications",
            "Building and Fixtures", "Vehicles", "Tools and Instruments", "Others"
        })
        If categoryCmbo.Items.Count > 0 Then categoryCmbo.SelectedIndex = 0

        conditionStatusCmbo.Items.Clear()
        conditionStatusCmbo.Items.AddRange(New Object() {"good", "needs repair", "damaged"})
        If conditionStatusCmbo.Items.Count > 0 Then conditionStatusCmbo.SelectedIndex = 0

        LoadDepartments()
        LoadCustodians()

        datePurchasedDate.Value = Date.Today
        warrantyExpirationDate.Value = Date.Today.AddYears(1)
    End Sub

    Private Sub LoadDepartments()
        Try
            departmentDirectory = DatabaseConnection.GetDepartmentLookup(True)
            assignedDeparmentCmbo.DataSource = departmentDirectory
            assignedDeparmentCmbo.DisplayMember = "department_name"
            assignedDeparmentCmbo.ValueMember = "department_id"
            assignedDeparmentCmbo.SelectedIndex = If(departmentDirectory.Rows.Count > 0, 0, -1)
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

            assignedEmployeeTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            assignedEmployeeTxt.AutoCompleteSource = AutoCompleteSource.CustomSource
            assignedEmployeeTxt.AutoCompleteCustomSource = suggestions
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
        If assignedDeparmentCmbo.SelectedValue IsNot Nothing Then
            departmentId = Convert.ToInt32(assignedDeparmentCmbo.SelectedValue)
        End If

        Dim custodianId As Integer? = ResolveCustodianId()

        Dim success = DatabaseConnection.AddProperty(
            propertyNameTxt.Text.Trim(),
            GetComboValue(categoryCmbo, "Others"),
            remarks_txt.Text.Trim(),
            serialNumberTxt.Text.Trim(),
            datePurchasedDate.Value,
            CDec(no_of_employees_numeric.Value),
            supplierTxt.Text.Trim(),
            "", ' supplier contact not captured separately
            GetComboValue(conditionStatusCmbo, "good"),
            propertyLocation.Text.Trim(),
            custodianId,
            departmentId,
            warrantyExpirationDate.Value.ToShortDateString(),
            Nothing
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
        If String.IsNullOrWhiteSpace(propertyNameTxt.Text) Then Return "Property name is required."
        If categoryCmbo.SelectedIndex = -1 Then Return "Please select a category."
        If String.IsNullOrWhiteSpace(supplierTxt.Text) Then Return "Supplier is required."
        If no_of_employees_numeric.Value <= 0 Then Return "Acquisition cost must be greater than zero."
        If String.IsNullOrWhiteSpace(propertyLocation.Text) Then Return "Location is required."
        Return ""
    End Function

    Private Function ResolveCustodianId() As Integer?
        Dim rawValue As String = assignedEmployeeTxt.Text.Trim()
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
End Class
