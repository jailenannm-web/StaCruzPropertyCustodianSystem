Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Linq
Imports Microsoft.VisualBasic

Public Class AssignRequestManagement
    Inherits UserControl

    Private canModifyRequests As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Dock = DockStyle.Fill
    End Sub

    Private currentRequestID As Integer = -1
    Private requestData As DataRow = Nothing

    ' Public property to receive RequestID
    Public Property RequestID As Integer
        Get
            Return currentRequestID
        End Get
        Set(value As Integer)
            currentRequestID = value
            If Me.IsHandleCreated Then
                LoadRequestData()
            End If
        End Set
    End Property

    Private Sub AssignRequestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureModifyPermission()
        ' Load available properties/supplies even if no request
        LoadAvailableProperties()
        LoadAvailableSupplies()
        ' Load request data if RequestID is set
        If currentRequestID > 0 Then
            LoadRequestData()
        End If
    End Sub

    Private Sub LoadRequestData()
        ' Get request ID from parent form or session if available
        ' For now, we'll load from the selected request in PropertyRequestManagement
        ' This should be set when navigating to this form
        If currentRequestID > 0 Then
            Try
                Dim dt As DataTable = DatabaseConnection.GetAllPropertyRequests()
                Dim requestRows() As DataRow = dt.Select("request_id = " & currentRequestID)
                If requestRows.Length > 0 Then
                    requestData = requestRows(0)
                    PopulateFormFields()
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("[v0] LoadRequestData Exception: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub PopulateFormFields()
        If requestData Is Nothing Then Return

        Try
            ' Populate form fields with request data
            If requestData.Table.Columns.Contains("item_name") AndAlso Not IsDBNull(requestData("item_name")) Then
                btn_PropertyName.Text = requestData("item_name").ToString()
            End If

            ' Load available properties that match the request
            LoadAvailableProperties()
        Catch ex As Exception
            MessageBox.Show("Error populating form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAvailableProperties()
        ' Load properties that are available (can assign even without request)
        Try
            Dim propertiesTable As DataTable = DatabaseConnection.GetAllProperties()
            ' Filter for available properties (status = 'Active' or 'Available')
            Dim availableProperties = propertiesTable.AsEnumerable().Where(Function(p)
                                                                                Dim status As String = If(IsDBNull(p("status")), "", p("status").ToString().ToLower())
                                                                                Return status = "active" OrElse status = "available"
                                                                            End Function).CopyToDataTable()

            ' Populate ComboBox with available properties
            If ComboBox1 IsNot Nothing Then
                ComboBox1.DataSource = availableProperties
                ComboBox1.DisplayMember = "item_name"
                ComboBox1.ValueMember = "property_id"
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadAvailableProperties Exception: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadAvailableSupplies()
        ' Load supplies that are available (can assign even without request)
        Try
            Dim suppliesTable As DataTable = DatabaseConnection.GetAllSupplies()
            ' Filter for available supplies
            Dim availableSupplies = suppliesTable.AsEnumerable().Where(Function(s)
                                                                                Dim status As String = If(IsDBNull(s("Status")), "", s("Status").ToString().ToLower())
                                                                                Dim qty As Integer = 0
                                                                                If s.Table.Columns.Contains("QuantityInStock") AndAlso Not IsDBNull(s("QuantityInStock")) Then
                                                                                    Integer.TryParse(s("QuantityInStock").ToString(), qty)
                                                                                End If
                                                                                Return (status = "available" OrElse status = "") AndAlso qty > 0
                                                                            End Function).CopyToDataTable()

            ' Populate ComboBox with available supplies
            If ComboBox2 IsNot Nothing Then
                ComboBox2.DataSource = availableSupplies
                ComboBox2.DisplayMember = "SupplyName"
                ComboBox2.ValueMember = "SupplyID"
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadAvailableSupplies Exception: " & ex.Message)
        End Try
    End Sub

    Public Sub SetRequestID(requestID As Integer)
        currentRequestID = requestID
        If Me.IsHandleCreated Then
            LoadRequestData()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        NavigateBack()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        If Not EnsureModifyPermission() Then
            Return
        End If
        MessageBox.Show("Property Request added successfully!")
        ' Add your save logic here
    End Sub

    Private Sub RoundedPanel3_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel3.Paint
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
    End Sub

    Private Sub NavigateBack()
        Dim parentDashboard = TryCast(Me.ParentForm, AdminDashboard)
        If parentDashboard IsNot Nothing Then
            parentDashboard.LoadUserControl(New UC_PropertyRequestManagement())
        Else
            Me.Parent?.Controls.Remove(Me)
        End If
    End Sub

    Private Function EnsureModifyPermission() As Boolean
        ' No restrictions for Super Admin, Admin, and Custodian
        Dim hasFullAccess As Boolean = SessionContext.IsSuperAdmin() OrElse SessionContext.IsAdmin() OrElse SessionContext.IsCustodianAdmin() OrElse SessionContext.IsCustodian()
        If hasFullAccess Then
            Return True
        End If
        ' For other roles, check permission
        canModifyRequests = SessionContext.HasPermission(SessionContext.ModulePermission.ModifyRequests)
        If Not canModifyRequests Then
            MessageBox.Show("You have view-only access to Property Request Management.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            NavigateBack()
            Return False
        End If
        Return True
    End Function
End Class

