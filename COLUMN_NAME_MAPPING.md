# Column Name Mapping: snake_case to camelCase

This document lists all column name changes needed when updating from snake_case to camelCase naming convention to match MySQL sample database style.

## Main Table Column Mappings

### departments table
- `department_id` → `departmentId`
- `department_name` → `departmentName`
- `head_of_department` → `headOfDepartment`
- `contact_number` → `contactNumber`
- `floor_number` → `floorNumber`
- `short_name` → `shortName`
- `office_code` → `officeCode`
- `total_properties` → `totalProperties`
- `total_supplies` → `totalSupplies`
- `created_at` → `createdAt`
- `updated_at` → `updatedAt`

### users table
- `user_id` → `userId`
- `first_name` → `firstName`
- `middle_name` → `middleName`
- `last_name` → `lastName`
- `full_name` → `fullName` (generated column)
- `department_id` → `departmentId`
- `employee_id` → `employeeId`
- `contact_number` → `contactNumber`
- `password_encrypted` → `passwordEncrypted`
- `last_login` → `lastLogin`
- `created_at` → `createdAt`
- `updated_at` → `updatedAt`

### properties table
- `property_id` → `propertyId`
- `item_name` → `itemName`
- `unit_of_measure` → `unitOfMeasure`
- `property_number` → `propertyNumber`
- `serial_number` → `serialNumber`
- `acquisition_date` → `acquisitionDate`
- `acquisition_cost` → `acquisitionCost`
- `total_cost` → `totalCost`
- `source_of_funds` → `sourceOfFunds`
- `assigned_to` → `assignedTo`
- `department_id` → `departmentId`
- `internal_codes` → `internalCodes`
- `created_at` → `createdAt`
- `updated_at` → `updatedAt`

### supplies table
- `supply_id` → `supplyId`
- `item_name` → `itemName`
- `unit_of_measure` → `unitOfMeasure`
- `date_received` → `dateReceived`
- `unit_cost` → `unitCost`
- `total_cost` → `totalCost`
- `source_of_funds` → `sourceOfFunds`
- `stock_status` → `stockStatus`
- `created_at` → `createdAt`
- `updated_at` → `updatedAt`

### property_requests table
- `request_id` → `requestId`
- `requester_name` → `requesterName`
- `department_id` → `departmentId`
- `date_of_request` → `dateOfRequest`
- `item_name` → `itemName`
- `quantity_requested` → `quantityRequested`
- `approved_by` → `approvedBy`
- `approved_date` → `approvedDate`
- `created_at` → `createdAt`
- `updated_at` → `updatedAt`

### supplies_requests table
- `request_id` → `requestId`
- `requester_name` → `requesterName`
- `department_id` → `departmentId`
- `date_of_request` → `dateOfRequest`
- `item_name` → `itemName`
- `quantity_requested` → `quantityRequested`
- `approved_by` → `approvedBy`
- `approved_date` → `approvedDate`
- `created_at` → `createdAt`
- `updated_at` → `updatedAt`

### maintenance_requests table
- `request_id` → `requestId`
- `date_requested` → `dateRequested`
- `item_name` → `itemName`
- `property_number` → `propertyNumber`
- `serial_number` → `serialNumber`
- `department_id` → `departmentId`
- `condition_before` → `conditionBefore`
- `type_of_issue` → `typeOfIssue`
- `problem_description` → `problemDescription`
- `assigned_technician` → `assignedTechnician`
- `target_date` → `targetDate`
- `completion_date` → `completionDate`
- `requested_by` → `requestedBy`
- `created_at` → `createdAt`
- `updated_at` → `updatedAt`

### maintenance table
- `maintenance_id` → `maintenanceId`
- `request_id` → `requestId`
- `property_item_name` → `propertyItemName`
- `serial_number` → `serialNumber`
- `department_id` → `departmentId`
- `condition_before_maint` → `conditionBeforeMaint`
- `type_of_maintenance` → `typeOfMaintenance`
- `assigned_technician` → `assignedTechnician`
- `maintenance_date` → `maintenanceDate`
- `maintenance_details` → `maintenanceDetails`
- `cost_materials_labor` → `costMaterialsLabor`
- `condition_after_maint` → `conditionAfterMaint`
- `action_taken` → `actionTaken`
- `parts_replaced` → `partsReplaced`
- `created_at` → `createdAt`
- `updated_at` → `updatedAt`

### custodian table
- `custodian_id` → `custodianId`
- `user_id` → `userId`
- `department_id` → `departmentId`
- `item_id` → `itemId`
- `item_type` → `itemType`
- `assigned_date` → `assignedDate`
- `created_at` → `createdAt`
- `updated_at` → `updatedAt`

### borrowed_items table
- `borrow_id` → `borrowId`
- `request_id` → `requestId`
- `item_type` → `itemType`
- `item_id` → `itemId`
- `borrower_name` → `borrowerName`
- `borrower_position` → `borrowerPosition`
- `department_id` → `departmentId`
- `borrow_date` → `borrowDate`
- `expected_return_date` → `expectedReturnDate`
- `actual_return_date` → `actualReturnDate`
- `condition_on_return` → `conditionOnReturn`
- `created_at` → `createdAt`
- `updated_at` → `updatedAt`

### system_config table
- `config_id` → `configId`
- `config_key` → `configKey`
- `config_value` → `configValue`
- `config_type` → `configType`
- `updated_by` → `updatedBy`
- `updated_at` → `updatedAt`

### audit_logs table
- `log_id` → `logId`
- `user_id` → `userId`
- `table_name` → `tableName`
- `record_id` → `recordId`
- `ip_address` → `ipAddress`
- `user_agent` → `userAgent`
- `created_at` → `createdAt`

### categories table
- `category_id` → `categoryId`
- `category_name` → `categoryName`
- `category_type` → `categoryType`
- `created_at` → `createdAt`

### staff_accounts table
- `staff_id` → `staffId`
- `user_id` → `userId`
- `first_name` → `firstName`
- `middle_name` → `middleName`
- `last_name` → `lastName`
- `full_name` → `fullName`
- `department_id` → `departmentId`
- `employee_id` → `employeeId`
- `contact_number` → `contactNumber`
- `password_encrypted` → `passwordEncrypted`
- `last_login` → `lastLogin`
- `created_at` → `createdAt`
- `updated_at` → `updatedAt`

## Alias Names in Queries

These are column aliases used in JOIN queries - they may also need updating:
- `assigned_employee` → `assignedEmployee`
- `assigned_department` → `assignedDepartment`
- `custodian_name` → `custodianName`
- `requester_name` → `requesterName`

## Files That Need Updating

1. **DatabaseConnection.vb** - All SQL queries and column references
2. **All Form files** - Any code that accesses DataRow columns using row("column_name")
3. **DataTable column definitions** - Where columns are explicitly defined

