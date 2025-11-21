#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""Fix GetAllDepartments query to include all 15 attributes"""

import re

# Read the file
with open('DatabaseConnection.vb', 'r', encoding='utf-8') as f:
    content = f.read()

# Find and replace the query
old_query = '''            Dim query As String = "SELECT d.department_id, d.department_name, d.head_of_department, " &
                                 "d.contact_number, d.email, d.location, d.department_code, " &
                                 "d.no_of_employees, d.budget_allocation, d.status, " &
                                 "COUNT(DISTINCT sa.staff_id) AS actual_employee_count, " &
                                 "COUNT(DISTINCT p.property_id) AS property_count " &
                                 "FROM departments d " &
                                 "LEFT JOIN staff_accounts sa ON d.department_id = sa.department_id AND sa.status = 'active' " &
                                 "LEFT JOIN properties p ON d.department_id = p.department_id AND p.status = 'active' " &
                                 "GROUP BY d.department_id, d.department_name, d.head_of_department, " &
                                 "d.contact_number, d.email, d.location, d.department_code, " &
                                 "d.no_of_employees, d.budget_allocation, d.status " &
                                 "ORDER BY d.department_name"'''

new_query = '''            ' Select all 15 attributes as specified in requirements
            Dim query As String = "SELECT d.department_id, d.department_name, d.head_of_department, " &
                                 "d.contact_number, d.email, d.location, d.no_of_employees, d.department_code, " &
                                 "d.office_hours, d.established_date, d.parent_department_id, d.status, " &
                                 "d.budget_allocation, d.created_at, d.updated_at " &
                                 "FROM departments d " &
                                 "ORDER BY d.department_name"'''

# Replace
if old_query in content:
    content = content.replace(old_query, new_query)
    with open('DatabaseConnection.vb', 'w', encoding='utf-8') as f:
        f.write(content)
    print("SUCCESS: Query fixed!")
else:
    print("ERROR: Could not find the exact query to replace.")
    print("Please manually replace the GetAllDepartments query in DatabaseConnection.vb")

