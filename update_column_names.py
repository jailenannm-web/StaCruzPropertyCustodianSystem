#!/usr/bin/env python3
"""
Script to update VB.NET code from snake_case to camelCase column names.
Run this script to automatically update column name references in VB.NET files.

Usage: python update_column_names.py

WARNING: This script will modify files in place. Make sure you have a backup!
"""

import re
import os
import glob

# Mapping of snake_case to camelCase column names
COLUMN_MAPPINGS = {
    # IDs
    'user_id': 'userId',
    'department_id': 'departmentId',
    'property_id': 'propertyId',
    'supply_id': 'supplyId',
    'request_id': 'requestId',
    'staff_id': 'staffId',
    'category_id': 'categoryId',
    'maintenance_id': 'maintenanceId',
    'custodian_id': 'custodianId',
    'borrow_id': 'borrowId',
    'config_id': 'configId',
    'log_id': 'logId',
    
    # Names
    'department_name': 'departmentName',
    'category_name': 'categoryName',
    'item_name': 'itemName',
    'first_name': 'firstName',
    'last_name': 'lastName',
    'middle_name': 'middleName',
    'full_name': 'fullName',
    'head_of_department': 'headOfDepartment',
    'requester_name': 'requesterName',
    'borrower_name': 'borrowerName',
    'property_item_name': 'propertyItemName',
    
    # Numbers and codes
    'property_number': 'propertyNumber',
    'serial_number': 'serialNumber',
    'employee_id': 'employeeId',
    'office_code': 'officeCode',
    'internal_codes': 'internalCodes',
    
    # Dates
    'acquisition_date': 'acquisitionDate',
    'acquisition_cost': 'acquisitionCost',
    'date_received': 'dateReceived',
    'date_of_request': 'dateOfRequest',
    'date_requested': 'dateRequested',
    'approved_date': 'approvedDate',
    'completion_date': 'completionDate',
    'target_date': 'targetDate',
    'maintenance_date': 'maintenanceDate',
    'assigned_date': 'assignedDate',
    'borrow_date': 'borrowDate',
    'expected_return_date': 'expectedReturnDate',
    'actual_return_date': 'actualReturnDate',
    'return_date': 'returnDate',
    'created_at': 'createdAt',
    'updated_at': 'updatedAt',
    'last_login': 'lastLogin',
    'date_assigned': 'dateAssigned',
    
    # Other fields
    'contact_number': 'contactNumber',
    'unit_of_measure': 'unitOfMeasure',
    'total_cost': 'totalCost',
    'source_of_funds': 'sourceOfFunds',
    'assigned_to': 'assignedTo',
    'approved_by': 'approvedBy',
    'requested_by': 'requestedBy',
    'updated_by': 'updatedBy',
    'borrowed_by': 'borrowedBy',
    'password_encrypted': 'passwordEncrypted',
    'stock_status': 'stockStatus',
    'condition_before': 'conditionBefore',
    'condition_after_maint': 'conditionAfterMaint',
    'condition_before_maint': 'conditionBeforeMaint',
    'condition_on_return': 'conditionOnReturn',
    'condition_upon_return': 'conditionUponReturn',
    'type_of_issue': 'typeOfIssue',
    'type_of_maintenance': 'typeOfMaintenance',
    'problem_description': 'problemDescription',
    'maintenance_details': 'maintenanceDetails',
    'assigned_technician': 'assignedTechnician',
    'quantity_requested': 'quantityRequested',
    'borrower_position': 'borrowerPosition',
    'cost_materials_labor': 'costMaterialsLabor',
    'action_taken': 'actionTaken',
    'parts_replaced': 'partsReplaced',
    'item_type': 'itemType',
    'item_id': 'itemId',
    'category_type': 'categoryType',
    'floor_number': 'floorNumber',
    'short_name': 'shortName',
    'total_properties': 'totalProperties',
    'total_supplies': 'totalSupplies',
    'unit_cost': 'unitCost',
    'table_name': 'tableName',
    'record_id': 'recordId',
    'ip_address': 'ipAddress',
    'user_agent': 'userAgent',
    'config_key': 'configKey',
    'config_value': 'configValue',
    'config_type': 'configType',
    
    # Aliases (used in JOIN queries)
    'assigned_employee': 'assignedEmployee',
    'assigned_department': 'assignedDepartment',
    'custodian_name': 'custodianName',
}

def update_file(filepath):
    """Update column names in a single file."""
    try:
        with open(filepath, 'r', encoding='utf-8') as f:
            content = f.read()
        
        original_content = content
        
        # Update in SQL queries (within quotes)
        for snake_case, camelCase in COLUMN_MAPPINGS.items():
            # Pattern for column names in SQL queries: "column_name" or 'column_name' or column_name
            patterns = [
                (f'"{snake_case}"', f'"{camelCase}"'),  # Double quotes
                (f"'{snake_case}'", f"'{camelCase}'"),  # Single quotes
                (f'\\b{snake_case}\\b', camelCase),     # Word boundary (for SQL queries)
            ]
            
            for pattern, replacement in patterns:
                content = re.sub(pattern, replacement, content)
        
        if content != original_content:
            with open(filepath, 'w', encoding='utf-8') as f:
                f.write(content)
            print(f"Updated: {filepath}")
            return True
        return False
    except Exception as e:
        print(f"Error updating {filepath}: {e}")
        return False

def main():
    """Main function to update all VB.NET files."""
    # Find all VB.NET files
    vb_files = []
    vb_files.extend(glob.glob('**/*.vb', recursive=True))
    vb_files.extend(glob.glob('**/*.vb', recursive=True))
    
    # Filter out bin and obj directories
    vb_files = [f for f in vb_files if 'bin' not in f and 'obj' not in f and 'packages' not in f]
    
    print(f"Found {len(vb_files)} VB.NET files to process...")
    
    updated_count = 0
    for filepath in vb_files:
        if update_file(filepath):
            updated_count += 1
    
    print(f"\nCompleted! Updated {updated_count} files.")

if __name__ == '__main__':
    main()

