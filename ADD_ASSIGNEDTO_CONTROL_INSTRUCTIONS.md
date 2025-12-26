# Adding Assigned To Control to Supply Forms

## Problem
The `cboAssignedTo` control doesn't exist in AddSupply.vb and EditSupply.vb designer files.

## Solution Options

### Option 1: Add Control in Visual Studio Designer (Recommended)

#### For AddSupply.vb:
1. Open **AddSupply.Designer.vb** in Visual Studio
2. Switch to **Design View** (View → Designer or Shift+F7)
3. Add a **Label** control:
   - Name: `lblAssignedTo`
   - Text: `Assigned To:`
   - Location: Place it near the Department field
   - Font: Segoe UI, 10pt

4. Add a **ComboBox** control:
   - Name: `cboAssignedTo`
   - DropDownStyle: `DropDownList`
   - Location: Right of the label
   - Size: Same width as other combo boxes

5. **Save** the designer file

#### For EditSupply.vb:
Follow the same steps as above.

---

### Option 2: Dynamically Create Control in Code (Quick Fix)

If you can't access the designer, add this code to create the control dynamically:

#### Update AddSupply.vb

Add this code at the end of `InitializeForm()` method:

```vb
Private Sub InitializeForm()
    ' ... existing code ...
    
    ' Load users for assignment
    LoadUsers()

    ' Set default date to today
    dtpDateReceived.Value = Date.Today
    
    ' Dynamically create Assigned To control if it doesn't exist
    CreateAssignedToControlIfNeeded()
End Sub

Private Sub CreateAssignedToControlIfNeeded()
    Try
        ' Check if control already exists
        Dim existingControls() As Control = Me.Controls.Find("cboAssignedTo", True)
        If existingControls.Length > 0 Then
            Return ' Control already exists
        End If
        
        ' Find a reference control to position near (e.g., cboDepartment or cboStockStatus)
        Dim referenceControl As Control = Nothing
        Dim referenceLabel As Control = Nothing
        
        ' Try to find department combo box
        Dim deptControls() As Control = Me.Controls.Find("cboDepartment", True)
        If deptControls.Length > 0 Then
            referenceControl = deptControls(0)
        Else
            ' Try to find stock status combo box
            Dim stockControls() As Control = Me.Controls.Find("cboStockStatus", True)
            If stockControls.Length > 0 Then
                referenceControl = stockControls(0)
            End If
        End If
        
        If referenceControl Is Nothing Then
            System.Diagnostics.Debug.WriteLine("Could not find reference control for positioning")
            Return
        End If
        
        ' Create Label
        Dim lblAssignedTo As New Label()
        lblAssignedTo.Name = "lblAssignedTo"
        lblAssignedTo.Text = "Assigned To:"
        lblAssignedTo.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblAssignedTo.AutoSize = True
        lblAssignedTo.Location = New Point(referenceControl.Left - 150, referenceControl.Bottom + 10)
        
        ' Create ComboBox
        Dim cboAssignedTo As New ComboBox()
        cboAssignedTo.Name = "cboAssignedTo"
        cboAssignedTo.DropDownStyle = ComboBoxStyle.DropDownList
        cboAssignedTo.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        cboAssignedTo.Size = New Size(referenceControl.Width, 25)
        cboAssignedTo.Location = New Point(referenceControl.Left, referenceControl.Bottom + 10)
        
        ' Add controls to form
        If referenceControl.Parent IsNot Nothing Then
            referenceControl.Parent.Controls.Add(lblAssignedTo)
            referenceControl.Parent.Controls.Add(cboAssignedTo)
        Else
            Me.Controls.Add(lblAssignedTo)
            Me.Controls.Add(cboAssignedTo)
        End If
        
        System.Diagnostics.Debug.WriteLine("Assigned To control created dynamically")
        
        ' Reload users to populate the new control
        LoadUsers()
        
    Catch ex As Exception
        System.Diagnostics.Debug.WriteLine("Error creating Assigned To control: " & ex.Message)
    End Try
End Sub
```

#### Update EditSupply.vb

Add the same `CreateAssignedToControlIfNeeded()` method and call it in `InitializeForm()`:

```vb
Private Sub InitializeForm()
    ' ... existing code ...
    
    ' Load users for assignment
    LoadUsers()
    
    ' Dynamically create Assigned To control if it doesn't exist
    CreateAssignedToControlIfNeeded()
End Sub

Private Sub CreateAssignedToControlIfNeeded()
    ' Same code as AddSupply.vb above
End Sub
```

---

### Option 3: Add Control Manually to Designer Code

If you can open the `.Designer.vb` files in a text editor:

#### AddSupply.Designer.vb

1. Find the line that declares controls (usually near the top):
```vb
Friend WithEvents txtItemName As TextBox
Friend WithEvents cboCategory As ComboBox
' ... other controls ...
```

2. Add these lines:
```vb
Friend WithEvents lblAssignedTo As Label
Friend WithEvents cboAssignedTo As ComboBox
```

3. Find the `InitializeComponent()` method and add:
```vb
Private Sub InitializeComponent()
    ' ... existing code ...
    
    Me.lblAssignedTo = New System.Windows.Forms.Label()
    Me.cboAssignedTo = New System.Windows.Forms.ComboBox()
    
    ' ... existing code ...
    
    ' Configure lblAssignedTo
    Me.lblAssignedTo.AutoSize = True
    Me.lblAssignedTo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular)
    Me.lblAssignedTo.Location = New System.Drawing.Point(50, 400) ' Adjust position
    Me.lblAssignedTo.Name = "lblAssignedTo"
    Me.lblAssignedTo.Size = New System.Drawing.Size(90, 19)
    Me.lblAssignedTo.TabIndex = 20 ' Adjust tab index
    Me.lblAssignedTo.Text = "Assigned To:"
    
    ' Configure cboAssignedTo
    Me.cboAssignedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboAssignedTo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular)
    Me.cboAssignedTo.FormattingEnabled = True
    Me.cboAssignedTo.Location = New System.Drawing.Point(200, 398) ' Adjust position
    Me.cboAssignedTo.Name = "cboAssignedTo"
    Me.cboAssignedTo.Size = New System.Drawing.Size(300, 25)
    Me.cboAssignedTo.TabIndex = 21 ' Adjust tab index
    
    ' Add controls to form
    Me.Controls.Add(Me.lblAssignedTo)
    Me.Controls.Add(Me.cboAssignedTo)
End Sub
```

4. Do the same for **EditSupply.Designer.vb**

---

## Recommended Approach

**I recommend Option 2 (Dynamic Creation)** because:
- ✅ No need to edit designer files manually
- ✅ Works immediately
- ✅ Safe and doesn't break existing layout
- ✅ Easy to implement

Just add the `CreateAssignedToControlIfNeeded()` method to both AddSupply.vb and EditSupply.vb!

---

## Testing After Adding Control

1. Build the project
2. Run the application
3. Go to Supply Management → Add Supply
4. You should see "Assigned To:" dropdown
5. Select a user and save
6. Check the database - assignedTo field should be populated

---

## Alternative: Using Existing Department Field

If you prefer not to add a new control, you could temporarily use an existing unused field or add it to a tab control if one exists in the form.
