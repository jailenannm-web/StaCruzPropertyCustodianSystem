<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPropertyRequest
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.RoundedPanel1 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.instructions = New System.Windows.Forms.Label()
        Me.admin_label_DepartmentManagement = New System.Windows.Forms.Label()
        Me.RoundedPanel2 = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.approvedDate = New System.Windows.Forms.DateTimePicker()
        Me.remarks = New System.Windows.Forms.TextBox()
        Me.release_date = New System.Windows.Forms.Label()
        Me.approved_by = New System.Windows.Forms.Label()
        Me.approved_date = New System.Windows.Forms.Label()
        Me.returned_date = New System.Windows.Forms.Label()
        Me.remarks_property = New System.Windows.Forms.Label()
        Me.penalty = New System.Windows.Forms.Label()
        Me.penaltyProperty = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.propertyID = New System.Windows.Forms.TextBox()
        Me.departmentID = New System.Windows.Forms.TextBox()
        Me.requestID = New System.Windows.Forms.TextBox()
        Me.purpose = New System.Windows.Forms.Label()
        Me.quantityRequest = New System.Windows.Forms.Label()
        Me.property_id = New System.Windows.Forms.Label()
        Me.department_id = New System.Windows.Forms.Label()
        Me.employeeID = New System.Windows.Forms.Label()
        Me.request_id = New System.Windows.Forms.Label()
        Me.purposeTxt = New System.Windows.Forms.TextBox()
        Me.request_date = New System.Windows.Forms.Label()
        Me.status = New System.Windows.Forms.Label()
        Me.updated_at = New System.Windows.Forms.Label()
        Me.employee_ID = New System.Windows.Forms.TextBox()
        Me.quantity = New System.Windows.Forms.NumericUpDown()
        Me.reuqestDate = New System.Windows.Forms.DateTimePicker()
        Me.propertyStatus = New System.Windows.Forms.ComboBox()
        Me.approvedBy = New System.Windows.Forms.TextBox()
        Me.releaseDate = New System.Windows.Forms.DateTimePicker()
        Me.returnDate = New System.Windows.Forms.DateTimePicker()
        Me.updatedAt = New System.Windows.Forms.DateTimePicker()
        Me.btnCancel = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.btnSave = New StaCruzPropertyCustodianSystem.Resources.Controls.RoundedButton()
        Me.RoundedPanel1.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.quantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel1.Controls.Add(Me.instructions)
        Me.RoundedPanel1.CornerRadius = 5
        Me.RoundedPanel1.Location = New System.Drawing.Point(43, 117)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1264, 72)
        Me.RoundedPanel1.TabIndex = 45
        '
        'instructions
        '
        Me.instructions.AutoSize = True
        Me.instructions.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructions.Location = New System.Drawing.Point(18, 24)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(224, 26)
        Me.instructions.TabIndex = 40
        Me.instructions.Text = "Fill the required information."
        '
        'admin_label_DepartmentManagement
        '
        Me.admin_label_DepartmentManagement.AutoSize = True
        Me.admin_label_DepartmentManagement.Font = New System.Drawing.Font("Poppins Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.admin_label_DepartmentManagement.Location = New System.Drawing.Point(33, 56)
        Me.admin_label_DepartmentManagement.Name = "admin_label_DepartmentManagement"
        Me.admin_label_DepartmentManagement.Size = New System.Drawing.Size(397, 58)
        Me.admin_label_DepartmentManagement.TabIndex = 44
        Me.admin_label_DepartmentManagement.Text = "Add Property Request"
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundedPanel2.Controls.Add(Me.Panel2)
        Me.RoundedPanel2.Controls.Add(Me.Panel1)
        Me.RoundedPanel2.CornerRadius = 5
        Me.RoundedPanel2.Location = New System.Drawing.Point(43, 207)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1264, 562)
        Me.RoundedPanel2.TabIndex = 46
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.updatedAt)
        Me.Panel2.Controls.Add(Me.returnDate)
        Me.Panel2.Controls.Add(Me.releaseDate)
        Me.Panel2.Controls.Add(Me.approvedBy)
        Me.Panel2.Controls.Add(Me.updated_at)
        Me.Panel2.Controls.Add(Me.approvedDate)
        Me.Panel2.Controls.Add(Me.remarks)
        Me.Panel2.Controls.Add(Me.release_date)
        Me.Panel2.Controls.Add(Me.approved_by)
        Me.Panel2.Controls.Add(Me.approved_date)
        Me.Panel2.Controls.Add(Me.returned_date)
        Me.Panel2.Controls.Add(Me.remarks_property)
        Me.Panel2.Controls.Add(Me.penalty)
        Me.Panel2.Controls.Add(Me.penaltyProperty)
        Me.Panel2.Location = New System.Drawing.Point(655, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(537, 519)
        Me.Panel2.TabIndex = 65
        '
        'approvedDate
        '
        Me.approvedDate.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.approvedDate.Location = New System.Drawing.Point(242, 102)
        Me.approvedDate.Name = "approvedDate"
        Me.approvedDate.Size = New System.Drawing.Size(238, 30)
        Me.approvedDate.TabIndex = 67
        '
        'remarks
        '
        Me.remarks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.remarks.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remarks.Location = New System.Drawing.Point(242, 252)
        Me.remarks.Name = "remarks"
        Me.remarks.Size = New System.Drawing.Size(238, 30)
        Me.remarks.TabIndex = 64
        '
        'release_date
        '
        Me.release_date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.release_date.AutoSize = True
        Me.release_date.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.release_date.Location = New System.Drawing.Point(44, 155)
        Me.release_date.Name = "release_date"
        Me.release_date.Size = New System.Drawing.Size(109, 26)
        Me.release_date.TabIndex = 48
        Me.release_date.Text = "Release Date"
        '
        'approved_by
        '
        Me.approved_by.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.approved_by.AutoSize = True
        Me.approved_by.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.approved_by.Location = New System.Drawing.Point(44, 47)
        Me.approved_by.Name = "approved_by"
        Me.approved_by.Size = New System.Drawing.Size(107, 26)
        Me.approved_by.TabIndex = 46
        Me.approved_by.Text = "Approved by"
        '
        'approved_date
        '
        Me.approved_date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.approved_date.AutoSize = True
        Me.approved_date.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.approved_date.Location = New System.Drawing.Point(44, 98)
        Me.approved_date.Name = "approved_date"
        Me.approved_date.Size = New System.Drawing.Size(124, 26)
        Me.approved_date.TabIndex = 47
        Me.approved_date.Text = "Approved Date"
        '
        'returned_date
        '
        Me.returned_date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.returned_date.AutoSize = True
        Me.returned_date.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.returned_date.Location = New System.Drawing.Point(44, 204)
        Me.returned_date.Name = "returned_date"
        Me.returned_date.Size = New System.Drawing.Size(100, 26)
        Me.returned_date.TabIndex = 49
        Me.returned_date.Text = "Return Date"
        '
        'remarks_property
        '
        Me.remarks_property.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.remarks_property.AutoSize = True
        Me.remarks_property.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remarks_property.Location = New System.Drawing.Point(44, 254)
        Me.remarks_property.Name = "remarks_property"
        Me.remarks_property.Size = New System.Drawing.Size(77, 26)
        Me.remarks_property.TabIndex = 50
        Me.remarks_property.Text = "Remarks"
        '
        'penalty
        '
        Me.penalty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.penalty.AutoSize = True
        Me.penalty.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.penalty.Location = New System.Drawing.Point(44, 311)
        Me.penalty.Name = "penalty"
        Me.penalty.Size = New System.Drawing.Size(67, 26)
        Me.penalty.TabIndex = 51
        Me.penalty.Text = "Penalty"
        '
        'penaltyProperty
        '
        Me.penaltyProperty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.penaltyProperty.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.penaltyProperty.Location = New System.Drawing.Point(242, 307)
        Me.penaltyProperty.Name = "penaltyProperty"
        Me.penaltyProperty.Size = New System.Drawing.Size(238, 30)
        Me.penaltyProperty.TabIndex = 58
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.propertyStatus)
        Me.Panel1.Controls.Add(Me.reuqestDate)
        Me.Panel1.Controls.Add(Me.quantity)
        Me.Panel1.Controls.Add(Me.employee_ID)
        Me.Panel1.Controls.Add(Me.status)
        Me.Panel1.Controls.Add(Me.purposeTxt)
        Me.Panel1.Controls.Add(Me.request_date)
        Me.Panel1.Controls.Add(Me.propertyID)
        Me.Panel1.Controls.Add(Me.departmentID)
        Me.Panel1.Controls.Add(Me.requestID)
        Me.Panel1.Controls.Add(Me.purpose)
        Me.Panel1.Controls.Add(Me.quantityRequest)
        Me.Panel1.Controls.Add(Me.property_id)
        Me.Panel1.Controls.Add(Me.department_id)
        Me.Panel1.Controls.Add(Me.employeeID)
        Me.Panel1.Controls.Add(Me.request_id)
        Me.Panel1.Location = New System.Drawing.Point(67, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(553, 519)
        Me.Panel1.TabIndex = 64
        '
        'propertyID
        '
        Me.propertyID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propertyID.Location = New System.Drawing.Point(256, 198)
        Me.propertyID.Name = "propertyID"
        Me.propertyID.Size = New System.Drawing.Size(254, 30)
        Me.propertyID.TabIndex = 67
        '
        'departmentID
        '
        Me.departmentID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.departmentID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.departmentID.Location = New System.Drawing.Point(256, 147)
        Me.departmentID.Name = "departmentID"
        Me.departmentID.Size = New System.Drawing.Size(254, 30)
        Me.departmentID.TabIndex = 66
        '
        'requestID
        '
        Me.requestID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requestID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestID.Location = New System.Drawing.Point(256, 44)
        Me.requestID.Name = "requestID"
        Me.requestID.Size = New System.Drawing.Size(254, 30)
        Me.requestID.TabIndex = 64
        '
        'purpose
        '
        Me.purpose.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.purpose.AutoSize = True
        Me.purpose.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.purpose.Location = New System.Drawing.Point(42, 313)
        Me.purpose.Name = "purpose"
        Me.purpose.Size = New System.Drawing.Size(74, 26)
        Me.purpose.TabIndex = 63
        Me.purpose.Text = "Purpose"
        '
        'quantityRequest
        '
        Me.quantityRequest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.quantityRequest.AutoSize = True
        Me.quantityRequest.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantityRequest.Location = New System.Drawing.Point(42, 256)
        Me.quantityRequest.Name = "quantityRequest"
        Me.quantityRequest.Size = New System.Drawing.Size(76, 26)
        Me.quantityRequest.TabIndex = 62
        Me.quantityRequest.Text = "Quantity"
        '
        'property_id
        '
        Me.property_id.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.property_id.AutoSize = True
        Me.property_id.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.property_id.Location = New System.Drawing.Point(42, 201)
        Me.property_id.Name = "property_id"
        Me.property_id.Size = New System.Drawing.Size(94, 26)
        Me.property_id.TabIndex = 61
        Me.property_id.Text = "Property ID"
        '
        'department_id
        '
        Me.department_id.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.department_id.AutoSize = True
        Me.department_id.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.department_id.Location = New System.Drawing.Point(42, 151)
        Me.department_id.Name = "department_id"
        Me.department_id.Size = New System.Drawing.Size(121, 26)
        Me.department_id.TabIndex = 60
        Me.department_id.Text = "Department ID"
        '
        'employeeID
        '
        Me.employeeID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.employeeID.AutoSize = True
        Me.employeeID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.employeeID.Location = New System.Drawing.Point(42, 98)
        Me.employeeID.Name = "employeeID"
        Me.employeeID.Size = New System.Drawing.Size(104, 26)
        Me.employeeID.TabIndex = 59
        Me.employeeID.Text = "Employee ID"
        '
        'request_id
        '
        Me.request_id.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.request_id.AutoSize = True
        Me.request_id.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.request_id.Location = New System.Drawing.Point(42, 47)
        Me.request_id.Name = "request_id"
        Me.request_id.Size = New System.Drawing.Size(91, 26)
        Me.request_id.TabIndex = 58
        Me.request_id.Text = "Request ID"
        '
        'purposeTxt
        '
        Me.purposeTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.purposeTxt.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.purposeTxt.Location = New System.Drawing.Point(256, 307)
        Me.purposeTxt.Multiline = True
        Me.purposeTxt.Name = "purposeTxt"
        Me.purposeTxt.Size = New System.Drawing.Size(254, 69)
        Me.purposeTxt.TabIndex = 73
        '
        'request_date
        '
        Me.request_date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.request_date.AutoSize = True
        Me.request_date.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.request_date.Location = New System.Drawing.Point(42, 397)
        Me.request_date.Name = "request_date"
        Me.request_date.Size = New System.Drawing.Size(111, 26)
        Me.request_date.TabIndex = 72
        Me.request_date.Text = "Request Date"
        '
        'status
        '
        Me.status.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.status.AutoSize = True
        Me.status.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status.Location = New System.Drawing.Point(42, 459)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(59, 26)
        Me.status.TabIndex = 74
        Me.status.Text = "Status"
        '
        'updated_at
        '
        Me.updated_at.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.updated_at.AutoSize = True
        Me.updated_at.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updated_at.Location = New System.Drawing.Point(44, 364)
        Me.updated_at.Name = "updated_at"
        Me.updated_at.Size = New System.Drawing.Size(95, 26)
        Me.updated_at.TabIndex = 69
        Me.updated_at.Text = "Updated At"
        '
        'employee_ID
        '
        Me.employee_ID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.employee_ID.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.employee_ID.Location = New System.Drawing.Point(256, 95)
        Me.employee_ID.Name = "employee_ID"
        Me.employee_ID.Size = New System.Drawing.Size(254, 30)
        Me.employee_ID.TabIndex = 76
        '
        'quantity
        '
        Me.quantity.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.quantity.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantity.Location = New System.Drawing.Point(256, 252)
        Me.quantity.Name = "quantity"
        Me.quantity.Size = New System.Drawing.Size(254, 30)
        Me.quantity.TabIndex = 77
        '
        'reuqestDate
        '
        Me.reuqestDate.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.reuqestDate.Location = New System.Drawing.Point(256, 397)
        Me.reuqestDate.Name = "reuqestDate"
        Me.reuqestDate.Size = New System.Drawing.Size(254, 30)
        Me.reuqestDate.TabIndex = 71
        '
        'propertyStatus
        '
        Me.propertyStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyStatus.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propertyStatus.FormattingEnabled = True
        Me.propertyStatus.Location = New System.Drawing.Point(256, 456)
        Me.propertyStatus.Name = "propertyStatus"
        Me.propertyStatus.Size = New System.Drawing.Size(254, 34)
        Me.propertyStatus.TabIndex = 78
        '
        'approvedBy
        '
        Me.approvedBy.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.approvedBy.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.approvedBy.Location = New System.Drawing.Point(242, 44)
        Me.approvedBy.Name = "approvedBy"
        Me.approvedBy.Size = New System.Drawing.Size(238, 30)
        Me.approvedBy.TabIndex = 71
        '
        'releaseDate
        '
        Me.releaseDate.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.releaseDate.Location = New System.Drawing.Point(242, 151)
        Me.releaseDate.Name = "releaseDate"
        Me.releaseDate.Size = New System.Drawing.Size(238, 30)
        Me.releaseDate.TabIndex = 72
        '
        'returnDate
        '
        Me.returnDate.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.returnDate.Location = New System.Drawing.Point(242, 200)
        Me.returnDate.Name = "returnDate"
        Me.returnDate.Size = New System.Drawing.Size(238, 30)
        Me.returnDate.TabIndex = 73
        '
        'updatedAt
        '
        Me.updatedAt.Font = New System.Drawing.Font("Poppins", 9.0!)
        Me.updatedAt.Location = New System.Drawing.Point(242, 360)
        Me.updatedAt.Name = "updatedAt"
        Me.updatedAt.Size = New System.Drawing.Size(238, 30)
        Me.updatedAt.TabIndex = 74
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnCancel.CornerRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(937, 797)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(145, 34)
        Me.btnCancel.TabIndex = 155
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnSave.CornerRadius = 15
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Poppins SemiBold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(1090, 797)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 34)
        Me.btnSave.TabIndex = 154
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'AddPropertyRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.admin_label_DepartmentManagement)
        Me.Name = "AddPropertyRequest"
        Me.Size = New System.Drawing.Size(1337, 865)
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.quantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RoundedPanel1 As Resources.Controls.RoundedPanel
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents admin_label_DepartmentManagement As System.Windows.Forms.Label
    Friend WithEvents RoundedPanel2 As Resources.Controls.RoundedPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents approvedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents remarks As System.Windows.Forms.TextBox
    Friend WithEvents release_date As System.Windows.Forms.Label
    Friend WithEvents approved_by As System.Windows.Forms.Label
    Friend WithEvents approved_date As System.Windows.Forms.Label
    Friend WithEvents returned_date As System.Windows.Forms.Label
    Friend WithEvents remarks_property As System.Windows.Forms.Label
    Friend WithEvents penalty As System.Windows.Forms.Label
    Friend WithEvents penaltyProperty As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents propertyID As System.Windows.Forms.TextBox
    Friend WithEvents departmentID As System.Windows.Forms.TextBox
    Friend WithEvents requestID As System.Windows.Forms.TextBox
    Friend WithEvents purpose As System.Windows.Forms.Label
    Friend WithEvents quantityRequest As System.Windows.Forms.Label
    Friend WithEvents property_id As System.Windows.Forms.Label
    Friend WithEvents department_id As System.Windows.Forms.Label
    Friend WithEvents employeeID As System.Windows.Forms.Label
    Friend WithEvents request_id As System.Windows.Forms.Label
    Friend WithEvents purposeTxt As System.Windows.Forms.TextBox
    Friend WithEvents request_date As System.Windows.Forms.Label
    Friend WithEvents status As System.Windows.Forms.Label
    Friend WithEvents updated_at As System.Windows.Forms.Label
    Friend WithEvents employee_ID As System.Windows.Forms.TextBox
    Friend WithEvents quantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents reuqestDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents approvedBy As System.Windows.Forms.TextBox
    Friend WithEvents propertyStatus As System.Windows.Forms.ComboBox
    Friend WithEvents returnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents releaseDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents updatedAt As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancel As Resources.Controls.RoundedButton
    Friend WithEvents btnSave As Resources.Controls.RoundedButton
End Class
