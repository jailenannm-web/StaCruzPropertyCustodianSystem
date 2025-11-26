Imports System
Imports System.Windows.Forms
Imports System.Drawing

Public Class EditPropertyManagement
    Inherits UserControl

    Private PropertyIDValue As Integer

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    '=========================================================
    ' LOAD PROPERTY DATA INTO EDIT FORM
    '=========================================================
    Public Sub LoadPropertyData(
        propertyID As Integer,
        propertyName As String,
        category As String,
        serialNumber As String,
        supplier As String,
        conditionStatus As String,
        cost As Decimal,
        datePurchased As Date,
        warrantyExpiration As Date,
        assignedEmployee As String,
        assignedDepartment As String,
        location As String,
        remarks As String,
        dateCreated As Date,
        dateUpdated As Date
    )

        Me.PropertyIDValue = propertyID

        txtpropertyID.Text = propertyID.ToString()
        txtPropertyName.Text = propertyName
        cboCategory.SelectedItem = category
        txtSerialNumber.Text = serialNumber
        txtSupplier.Text = supplier

        ' FIXED CONTROL NAME
        conditionStatusCmbo.SelectedItem = conditionStatus

        txtCost.Text = cost.ToString("0.00")

        dtpDatePurchased.Value = datePurchased
        dtpWarrantyExpiration.Value = warrantyExpiration

        txtAssignedEmployee.Text = assignedEmployee
        txtAssignedDepartment.Text = assignedDepartment
        txtLocation.Text = location
        txtRemarks.Text = remarks

        ' FIXED DATE FIELD NAME
        dtpDateCreated.Value = dateCreated
        dtpDateUpdated.Value = dateUpdated
    End Sub

    '=========================================================
    ' SAVE BUTTON — UPDATE PROPERTY RECORD
    '=========================================================
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ' 1. Basic validation
        If txtPropertyName.Text.Trim() = "" Then
            MessageBox.Show("Property name is required.", "Missing Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cboCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select a category.", "Missing Category",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Prepare values for update
        Dim updatedName As String = txtPropertyName.Text.Trim()
        Dim updatedCategory As String = cboCategory.SelectedItem.ToString()
        Dim updatedSerial As String = txtSerialNumber.Text.Trim()
        Dim updatedSupplier As String = txtSupplier.Text.Trim()
        Dim updatedCondition As String = conditionStatusCmbo.SelectedItem.ToString()
        Dim updatedCost As Decimal = Decimal.Parse(txtCost.Text)
        Dim updatedDatePurchased As Date = dtpDatePurchased.Value
        Dim updatedWarranty As Date = dtpWarrantyExpiration.Value
        Dim updatedAssignedEmp As String = txtAssignedEmployee.Text.Trim()
        Dim updatedAssignedDept As String = txtAssignedDepartment.Text.Trim()
        Dim updatedLocation As String = txtLocation.Text.Trim()
        Dim updatedRemarks As String = txtRemarks.Text.Trim()
        Dim updatedDateUpdated As Date = Date.Now

        Dim result As DialogResult = MessageBox.Show("Save changes to this property?",
                                                     "Confirm Update",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question)

        If result = DialogResult.Yes Then

            ' TODO: Add your DB update here

            MessageBox.Show("Property updated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
            If parentDashboard IsNot Nothing Then
                parentDashboard.LoadUserControl(New UC_PropertyManagement1())
            End If

        End If
    End Sub

    '=========================================================
    ' BACK BUTTON
    '=========================================================
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_PropertyManagement1())
        Else
            MessageBox.Show("Parent form not detected.", "Error",
                             MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class
