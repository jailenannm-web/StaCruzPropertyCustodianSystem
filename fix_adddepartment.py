#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""Fix AddDepartment errors"""

import re

# Fix Forms/Admin/AddDepartment.vb
print("Fixing Forms/Admin/AddDepartment.vb...")
with open('Forms/Admin/AddDepartment.vb', 'r', encoding='utf-8') as f:
    content = f.read()

# Fix 1: Add missing parameters to function call
old_call = """                officeHours
            )"""
new_call = """                officeHours,
                establishedDate,
                parentDeptID,
                statusValue
            )"""
if old_call in content:
    content = content.replace(old_call, new_call)
    print("  ✓ Fixed function call parameters")

# Fix 2: Replace vbCrLf with Environment.NewLine
if 'vbCrLf' in content:
    content = content.replace('vbCrLf', 'Environment.NewLine')
    print("  ✓ Fixed vbCrLf issue")

with open('Forms/Admin/AddDepartment.vb', 'w', encoding='utf-8') as f:
    f.write(content)

# Fix DatabaseConnection.vb
print("\nFixing DatabaseConnection.vb...")
with open('DatabaseConnection.vb', 'r', encoding='utf-8') as f:
    content = f.read()

# Fix 1: Update function signature
old_sig = """    Public Shared Function AddDepartment(departmentName As String, headOfDepartment As String, location As String,
                                        departmentCode As String, Optional contactNumber As String = "",
                                        Optional email As String = "", Optional noOfEmployees As Integer = 0,
                                        Optional budgetAllocation As Decimal = 0) As Boolean"""
new_sig = """    Public Shared Function AddDepartment(departmentName As String, headOfDepartment As String, location As String,
                                        departmentCode As String, Optional contactNumber As String = "",
                                        Optional email As String = "", Optional noOfEmployees As Integer = 0,
                                        Optional budgetAllocation As Decimal = 0, Optional officeHours As String = "",
                                        Optional establishedDate As Date? = Nothing, Optional parentDepartmentID As Integer? = Nothing,
                                        Optional status As String = "active") As Boolean"""
if old_sig in content:
    content = content.replace(old_sig, new_sig)
    print("  ✓ Fixed function signature")

# Fix 2: Update INSERT query
old_query = """            Dim query As String = "INSERT INTO departments (department_name, head_of_department, location, department_code, " &
                                 "contact_number, email, no_of_employees, budget_allocation, status) " &
                                 "VALUES (@departmentName, @headOfDepartment, @location, @departmentCode, " &
                                 "@contactNumber, @email, @noOfEmployees, @budgetAllocation, 'active')"""
new_query = """            Dim query As String = "INSERT INTO departments (department_name, head_of_department, location, department_code, " &
                                 "contact_number, email, no_of_employees, budget_allocation, status, " &
                                 "office_hours, established_date, parent_department_id) " &
                                 "VALUES (@departmentName, @headOfDepartment, @location, @departmentCode, " &
                                 "@contactNumber, @email, @noOfEmployees, @budgetAllocation, @status, " &
                                 "@officeHours, @establishedDate, @parentDepartmentID)"""
if old_query in content:
    content = content.replace(old_query, new_query)
    print("  ✓ Fixed INSERT query")

# Fix 3: Add new parameters
old_params = """                cmd.Parameters.AddWithValue("@budgetAllocation", budgetAllocation)

                Dim result As Integer = cmd.ExecuteNonQuery()"""
new_params = """                cmd.Parameters.AddWithValue("@budgetAllocation", budgetAllocation)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@officeHours", If(String.IsNullOrEmpty(officeHours), DBNull.Value, officeHours))
                cmd.Parameters.AddWithValue("@establishedDate", If(establishedDate.HasValue, establishedDate.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@parentDepartmentID", If(parentDepartmentID.HasValue, parentDepartmentID.Value, DBNull.Value))

                Dim result As Integer = cmd.ExecuteNonQuery()"""
if old_params in content:
    content = content.replace(old_params, new_params)
    print("  ✓ Fixed parameter bindings")

with open('DatabaseConnection.vb', 'w', encoding='utf-8') as f:
    f.write(content)

print("\nAll fixes applied successfully!")

