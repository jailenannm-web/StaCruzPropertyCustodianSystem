# VB.NET Code Update Guide: snake_case to camelCase

## What Needs to Be Updated

Due to the database schema change from `snake_case` to `camelCase` column names, the following VB.NET code needs updating:

### 1. SQL Queries in DatabaseConnection.vb
- All SELECT statements with column names
- All INSERT statements with column lists
- All UPDATE statements with SET clauses
- All WHERE clauses referencing columns
- All JOIN clauses with ON conditions
- All ORDER BY clauses

### 2. Column References in Code
- `reader("column_name")` → `reader("columnName")`
- `row("column_name")` → `row("columnName")`
- `record("column_name")` → `record("columnName")`
- `.Columns.Contains("column_name")` → `.Columns.Contains("columnName")`
- DataTable column definitions: `dt.Columns.Add("column_name", ...)` → `dt.Columns.Add("columnName", ...)`

### 3. Common Patterns to Replace

**In SQL Queries:**
- `p.property_id` → `p.propertyId`
- `u.user_id` → `u.userId`
- `d.department_id` → `d.departmentId`
- `p.first_name` → `p.firstName`
- `p.last_name` → `p.lastName`
- `p.acquisition_date` → `p.acquisitionDate`
- `p.acquisition_cost` → `p.acquisitionCost`
- `p.property_number` → `p.propertyNumber`
- `p.serial_number` → `p.serialNumber`
- `p.assigned_to` → `p.assignedTo`
- `p.created_at` → `p.createdAt`
- `p.updated_at` → `p.updatedAt`

**In VB.NET Code:**
- `"user_id"` → `"userId"`
- `"first_name"` → `"firstName"`
- `"last_name"` → `"lastName"`
- `"department_id"` → `"departmentId"`
- `"property_id"` → `"propertyId"`
- `"supply_id"` → `"supplyId"`
- `"request_id"` → `"requestId"`
- `"contact_number"` → `"contactNumber"`
- `"password_encrypted"` → `"passwordEncrypted"`
- `"created_at"` → `"createdAt"`
- `"updated_at"` → `"updatedAt"`

## Files to Update

1. **DatabaseConnection.vb** - Primary file with most SQL queries
2. **All Form files** - Any code accessing DataRow columns
3. **Report files** - Column references in reports
4. **User Control files** - DataTable column references

## Testing Checklist

After updates, test:
- [ ] User login (all roles)
- [ ] Property management (CRUD operations)
- [ ] Supply management (CRUD operations)
- [ ] Department management
- [ ] User management
- [ ] Reports generation
- [ ] Data filtering and searching

