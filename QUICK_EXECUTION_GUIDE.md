# ⚡ Quick Execution Guide
## Generate 100,000+ Test Records in 3 Steps

---

## 🎯 For XAMPP/phpMyAdmin Users (EASIEST)

### Step 1: Open phpMyAdmin
```
1. Start XAMPP Control Panel
2. Start MySQL
3. Open browser: http://localhost/phpmyadmin
4. Select database: teamcruzim
```

### Step 2: Execute Master Script
```
1. Click "SQL" tab
2. Click "Import" or paste the content
3. Select file: MASTER_DATA_GENERATION_SCRIPT.sql
4. Click "Go"
5. Wait 5-10 minutes ⏱️
```

### Step 3: Verify
```sql
-- Run this to check results:
SELECT 'users' AS table_name, COUNT(*) AS count FROM users
UNION ALL SELECT 'properties', COUNT(*) FROM properties
UNION ALL SELECT 'supplies', COUNT(*) FROM supplies
UNION ALL SELECT 'audit_logs', COUNT(*) FROM audit_logs;
```

**Expected Result:** 100,000+ total records ✅

---

## 💻 For Command Line Users

```bash
# Navigate to project folder
cd /path/to/your/project

# Run master script
mysql -u root -p teamcruzim < MASTER_DATA_GENERATION_SCRIPT.sql

# Or run individually (if master script fails)
mysql -u root -p teamcruzim < tmp_rovodev_generate_departments.sql
mysql -u root -p teamcruzim < tmp_rovodev_generate_users.sql
mysql -u root -p teamcruzim < tmp_rovodev_generate_properties.sql
mysql -u root -p teamcruzim < tmp_rovodev_generate_supplies.sql
mysql -u root -p teamcruzim < tmp_rovodev_generate_requests_and_maintenance.sql
mysql -u root -p teamcruzim < tmp_rovodev_generate_borrowed_custodian_audit.sql
```

---

## 📊 What You'll Get

| Entity | Records |
|--------|---------|
| Departments | 10,000+ |
| Users | 10,000+ |
| Properties | 10,000+ |
| Supplies | 10,000+ |
| Property Requests | 10,000+ |
| Supply Requests | 10,000+ |
| Maintenance Requests | 10,000+ |
| Maintenance Records | 10,000+ |
| Borrowed Items | 10,000+ |
| Custodian Assignments | 10,000+ |
| Audit Logs | 50,000+ |
| **TOTAL** | **120,000+** |

---

## ✨ Features

✅ **Realistic Data**
- Real Filipino names (10,000+ unique combinations)
- Actual school departments and positions
- Real Philippine locations and addresses
- Realistic equipment and supply items
- Proper pricing and cost values

✅ **Proper Relationships**
- Users → Departments
- Properties → Users (assigned to)
- Requests → Approvals → Actions
- Maintenance → Properties
- Borrowed Items → Requests
- Audit Logs → All activities

✅ **System Workflow**
- Request creation and approval flow
- Property assignment workflow
- Maintenance request to completion
- Borrowing and return process
- Status transitions (Pending→Approved→Completed)

✅ **No Duplicates**
- Unique names (no duplicate persons)
- Unique departments (100+ different)
- Unique property numbers
- Unique employee IDs
- Unique email addresses

---

## ⚠️ Before You Start

```sql
-- OPTIONAL: Backup your database first
mysqldump -u root -p teamcruzim > backup.sql
```

**Requirements:**
- ✅ XAMPP MySQL running
- ✅ Database `teamcruzim` exists
- ✅ At least 500MB free disk space
- ✅ 5-10 minutes of time

---

## 🚨 If Something Goes Wrong

### Error: "Script timeout"
```sql
-- Add this at the start of the script:
SET SESSION max_execution_time = 0;
```

### Error: "Out of memory"
**Solution:** Run scripts individually instead of master script

### Error: "Duplicate entry"
**Solution:** Clear existing data first:
```sql
SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE audit_logs;
TRUNCATE TABLE borrowed_items;
TRUNCATE TABLE custodian;
TRUNCATE TABLE maintenance;
TRUNCATE TABLE maintenance_requests;
TRUNCATE TABLE property_requests;
TRUNCATE TABLE supplies_requests;
TRUNCATE TABLE properties;
TRUNCATE TABLE supplies;
DELETE FROM users WHERE userId > 1;
DELETE FROM departments WHERE departmentId > 5;
SET FOREIGN_KEY_CHECKS = 1;
```

---

## 🎉 After Generation

### Test Your System

```sql
-- Login Test Users
SELECT username, role, email 
FROM users 
WHERE role = 'Admin' 
LIMIT 5;

-- View Sample Properties
SELECT itemName, category, propertyNumber, 
       CONCAT('₱', FORMAT(acquisitionCost, 2)) AS cost
FROM properties 
LIMIT 10;

-- Check Request Workflow
SELECT status, COUNT(*) as count 
FROM property_requests 
GROUP BY status;

-- View Borrowed Items
SELECT borrowerName, itemType, status, borrowDate
FROM borrowed_items
LIMIT 10;
```

### Sample Generated Data

**Users:**
```
jcruz123       - Juan Martinez Cruz - Staff
msantos456     - Maria Elena Santos - Professor
rreyes789      - Roberto Garcia Reyes - Admin
```

**Departments:**
```
College of Engineering
College of Business Administration
IT Services Department
Library Services
Property Custodian Office
...and 95 more
```

**Properties:**
```
PROP-2024-00001 - Desktop Computer - ₱45,000
PROP-2024-00002 - Office Chair - ₱8,500
PROP-2024-00003 - Air Conditioner - ₱35,000
...and 9,997 more
```

---

## 📈 Performance Metrics

**Execution Time:**
- Departments: ~5 seconds
- Users: ~30-60 seconds
- Properties: ~60-90 seconds
- Supplies: ~60-90 seconds
- Requests: ~2-3 minutes
- Other records: ~2-3 minutes
- **Total: 5-10 minutes**

**Database Size After:**
- ~500MB total
- 100,000+ records
- Fully indexed and optimized

---

## ✅ Success Checklist

After execution, verify:
- [ ] No error messages in output
- [ ] Record counts match expectations (run count query)
- [ ] Can login to system
- [ ] Can view properties and supplies
- [ ] Can see requests and approvals
- [ ] Reports generate correctly
- [ ] System performance is good

---

## 🔄 To Start Fresh

```sql
-- Run cleanup script to remove all generated data
SOURCE cleanup_generated_data.sql;

-- Or manually:
SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE audit_logs;
TRUNCATE TABLE borrowed_items;
TRUNCATE TABLE custodian;
TRUNCATE TABLE maintenance;
TRUNCATE TABLE maintenance_requests;
TRUNCATE TABLE property_requests;
TRUNCATE TABLE supplies_requests;
TRUNCATE TABLE properties;
TRUNCATE TABLE supplies;
DELETE FROM users WHERE userId > 1;
DELETE FROM departments WHERE departmentId > 5;
SET FOREIGN_KEY_CHECKS = 1;
```

---

## 📚 Need More Help?

See detailed documentation in:
- `TEST_DATA_GENERATION_README.md` - Full documentation
- `MASTER_DATA_GENERATION_SCRIPT.sql` - Main execution script

---

## 🎊 You're All Set!

Your Property Custodian Management System now has:
- ✨ 100,000+ realistic records
- 🔗 Properly connected data
- 📊 Complete workflow simulation
- 🇵🇭 Philippine school context
- 🚀 Ready for testing!

**Happy Testing! 🎉**

---

*Quick Guide | Property Custodian Management System | January 2026*
