# Test Data Generation Guide
## Property Custodian Management System

---

## 📊 Overview

This test data generation package creates **100,000+ realistic records** for your Property Custodian Management System with proper relationships and workflow simulation.

### What Gets Generated

| Entity | Records | Description |
|--------|---------|-------------|
| **Departments** | 10,000+ | Academic and administrative departments |
| **Users** | 10,000+ | SuperAdmin, Admin, Custodian, Staff with Philippine names |
| **Properties** | 10,000+ | School equipment, furniture, vehicles, etc. |
| **Supplies** | 10,000+ | Consumable items with stock levels |
| **Property Requests** | 10,000+ | Request workflow with approvals |
| **Supply Requests** | 10,000+ | Supply requisitions |
| **Maintenance Requests** | 10,000+ | Equipment maintenance requests |
| **Maintenance Records** | 10,000+ | Completed maintenance work |
| **Borrowed Items** | 10,000+ | Borrowing transactions |
| **Custodian Assignments** | 10,000+ | Property/supply assignments |
| **Audit Logs** | 50,000+ | System activity tracking |
| **TOTAL** | **120,000+** | **Fully connected realistic data** |

---

## 🚀 Quick Start Guide

### Method 1: Using phpMyAdmin (Recommended for XAMPP)

1. **Start XAMPP** and ensure MySQL is running
2. **Open phpMyAdmin** (http://localhost/phpmyadmin)
3. **Select your database** (`teamcruzim`)
4. **Execute scripts in this order:**

```
Step 1: Click "SQL" tab
Step 2: Click "Import files" or paste SQL content
Step 3: Execute in sequence:

   ✓ tmp_rovodev_generate_departments.sql
   ✓ tmp_rovodev_generate_users.sql
   ✓ tmp_rovodev_generate_properties.sql
   ✓ tmp_rovodev_generate_supplies.sql
   ✓ tmp_rovodev_generate_requests_and_maintenance.sql
   ✓ tmp_rovodev_generate_borrowed_custodian_audit.sql
```

5. **Or use the master script:**
   - Import `MASTER_DATA_GENERATION_SCRIPT.sql`
   - Click "Go"
   - Wait 5-10 minutes

### Method 2: Using MySQL Command Line

```bash
# Navigate to project directory
cd /path/to/your/project

# Execute master script
mysql -u root -p teamcruzim < MASTER_DATA_GENERATION_SCRIPT.sql

# Or execute individually
mysql -u root -p teamcruzim < tmp_rovodev_generate_departments.sql
mysql -u root -p teamcruzim < tmp_rovodev_generate_users.sql
mysql -u root -p teamcruzim < tmp_rovodev_generate_properties.sql
mysql -u root -p teamcruzim < tmp_rovodev_generate_supplies.sql
mysql -u root -p teamcruzim < tmp_rovodev_generate_requests_and_maintenance.sql
mysql -u root -p teamcruzim < tmp_rovodev_generate_borrowed_custodian_audit.sql
```

---

## 📋 Data Characteristics

### ✅ Realistic Philippine School Data

- **Names**: Real Filipino first, middle, and last names
- **Locations**: Philippine provinces, municipalities, barangays
- **Departments**: Actual school departments (Engineering, IT, Business, etc.)
- **Equipment**: Real school property items with realistic costs
- **Suppliers**: Philippine retailers and suppliers
- **Positions**: Actual academic and administrative positions

### ✅ Proper Relationships

- Users are assigned to departments
- Properties are assigned to users
- Requests are linked to users and departments
- Maintenance requests reference properties
- Borrowed items link to approved requests
- Custodian assignments track ownership
- Audit logs record all activities

### ✅ Workflow Simulation

- **Property Requests**: 60% Approved, 25% Pending, 15% Rejected
- **Supply Requests**: 65% Approved, 20% Pending, 15% Rejected
- **Maintenance**: 50% Completed, 20% In Progress, 15% Approved, 15% Pending
- **Borrowed Items**: 40% Returned, 50% Borrowed, 8% Overdue, 2% Lost
- **Property Conditions**: 85% Good, 10% Needs Repair, 5% Damaged

---

## 🎯 Generated Data Examples

### Sample Users (10,000+)
```
Juan Martinez Reyes - Professor - Engineering Department
Maria Santos Cruz - Instructor - Business Department
Jose Garcia Lopez - Department Head - IT Department
Ana Ramos Torres - Admin Officer - Finance Department
...and 9,996 more unique users
```

### Sample Departments (100+)
```
College of Engineering
College of Business Administration
College of Computer Studies
IT Services Department
Library Services
Property Custodian Office
...and 94 more departments
```

### Sample Properties (10,000+)
```
PROP-2024-00001 - Desktop Computer - ₱45,000.00
PROP-2024-00002 - Office Desk - ₱12,500.00
PROP-2024-00003 - Air Conditioning Unit - ₱35,000.00
PROP-2024-00004 - Projector (LCD) - ₱28,000.00
...and 9,996 more properties
```

### Sample Supplies (10,000+)
```
Bond Paper (A4) - 500 reams - ₱125,000.00
Ballpen (Blue) - 1,000 boxes - ₱50,000.00
Whiteboard Marker - 250 sets - ₱37,500.00
...and 9,997 more supply items
```

---

## ⚙️ Configuration & Customization

### Adjust Record Counts

Open any generation script and modify the `total_*` variables:

```sql
-- In tmp_rovodev_generate_users.sql
DECLARE total_users INT DEFAULT 10000;  -- Change to desired count

-- In tmp_rovodev_generate_properties.sql
DECLARE total_props INT DEFAULT 10000;  -- Change to desired count
```

### Modify Data Distribution

Adjust the percentages in the scripts:

```sql
-- User role distribution (in generate_users.sql)
IF random_num = 1 THEN
    SET user_role = 'SuperAdmin';      -- 1%
ELSEIF random_num <= 6 THEN
    SET user_role = 'Admin';           -- 5%
ELSEIF random_num <= 21 THEN
    SET user_role = 'Custodian';       -- 15%
ELSE
    SET user_role = 'Staff';           -- 79%
END IF;
```

---

## 🔍 Verification Queries

After generation, verify your data:

```sql
-- Check total records
SELECT 
    'users' AS entity, COUNT(*) AS count FROM users
UNION ALL
SELECT 'properties', COUNT(*) FROM properties
UNION ALL
SELECT 'supplies', COUNT(*) FROM supplies
UNION ALL
SELECT 'requests', COUNT(*) FROM property_requests;

-- Check relationships
SELECT 
    u.fullName,
    d.departmentName,
    COUNT(p.propertyId) AS assigned_properties
FROM users u
LEFT JOIN departments d ON u.departmentId = d.departmentId
LEFT JOIN properties p ON u.userId = p.assignedTo
GROUP BY u.userId
LIMIT 20;

-- Check workflow status
SELECT 
    status,
    COUNT(*) AS count,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM property_requests), 2) AS percentage
FROM property_requests
GROUP BY status;
```

---

## 🎓 Use Cases

### 1. **System Testing**
- Test all CRUD operations with realistic data
- Validate search and filter functionality
- Test report generation with large datasets
- Verify pagination and performance

### 2. **User Training**
- Demonstrate complete workflows
- Show real-world scenarios
- Practice data entry and management
- Test user permissions and roles

### 3. **Performance Testing**
- Load testing with 100,000+ records
- Query optimization testing
- Report generation speed tests
- Database indexing validation

### 4. **Demonstrations**
- Present to stakeholders with realistic data
- Show system capabilities
- Demonstrate reporting features
- Validate compliance requirements

### 5. **Development**
- Test new features with existing data
- Validate data migration scripts
- Test backup and restore procedures
- Verify data integrity constraints

---

## ⚠️ Important Notes

### Before Generation

1. **Backup your database** (if you have existing data)
   ```sql
   mysqldump -u root -p teamcruzim > backup_before_generation.sql
   ```

2. **Ensure sufficient disk space** (~500MB required)

3. **Close other applications** to free up memory

4. **Increase timeout settings** in phpMyAdmin if needed:
   ```
   File: config.inc.php
   $cfg['ExecTimeLimit'] = 600; // 10 minutes
   ```

### During Generation

- **DO NOT** close phpMyAdmin/terminal
- **DO NOT** interrupt the process
- **DO NOT** run multiple scripts simultaneously
- Monitor progress messages in output

### After Generation

1. **Verify record counts** match expectations
2. **Test login** with generated user accounts
3. **Check relationships** between entities
4. **Review data quality** and realism
5. **Test system features** with new data

---

## 🐛 Troubleshooting

### Issue: Script Timeout

**Solution:**
```sql
-- Add at start of script
SET SESSION max_execution_time = 0;
SET SESSION wait_timeout = 28800;
```

### Issue: Out of Memory

**Solution:**
- Reduce batch size in scripts (change MOD value)
- Execute scripts one at a time
- Increase MySQL memory limits

### Issue: Duplicate Key Errors

**Solution:**
```sql
-- Clear all data first
DELETE FROM audit_logs;
DELETE FROM borrowed_items;
DELETE FROM custodian;
DELETE FROM maintenance;
DELETE FROM maintenance_requests;
DELETE FROM property_requests;
DELETE FROM supplies_requests;
DELETE FROM properties;
DELETE FROM supplies;
DELETE FROM users WHERE userId > 1;
DELETE FROM departments WHERE departmentId > 5;
```

### Issue: Foreign Key Constraint Errors

**Solution:**
- Ensure scripts are executed IN ORDER
- Check that parent records exist before child records
- Verify foreign key relationships in schema

---

## 📊 Expected Performance

| Script | Records | Execution Time |
|--------|---------|----------------|
| Departments | 100+ | ~5 seconds |
| Users | 10,000+ | ~30-60 seconds |
| Properties | 10,000+ | ~60-90 seconds |
| Supplies | 10,000+ | ~60-90 seconds |
| Requests | 30,000+ | ~120-180 seconds |
| Borrowed/Custodian | 18,000+ | ~60-90 seconds |
| Audit Logs | 50,000+ | ~90-120 seconds |
| **TOTAL** | **100,000+** | **5-10 minutes** |

*Times vary based on system specifications*

---

## 🔐 Security Considerations

### Generated Passwords

All users have the password hash: `$2a$11$YourHashedPasswordHere`

**To set actual passwords:**
```sql
-- Update all user passwords (use your password hashing method)
UPDATE users 
SET passwordEncrypted = 'your_actual_hashed_password'
WHERE userId > 1;
```

### Generated Credentials

For testing purposes, usernames follow the pattern:
- Format: `{first_initial}{lastname}{random_3_digits}`
- Example: `jcruz123`, `msantos456`, `rreyes789`

---

## 📈 Database Statistics After Generation

```
Departments:           100+
Users:                 10,000+
Properties:            10,000+
Supplies:              10,000+
Property Requests:     10,000+
Supply Requests:       10,000+
Maintenance Requests:  10,000+
Maintenance Records:   10,000+
Borrowed Items:        10,000+
Custodian Assignments: 10,000+
Audit Logs:            50,000+
─────────────────────────────────
TOTAL RECORDS:         120,000+

Total Property Value:  ₱500M - ₱1B
Total Supply Value:    ₱50M - ₱100M
Database Size:         ~500MB
```

---

## 🛠️ Cleanup Scripts

### To remove all generated data:

```sql
-- Clear generated data (keep schema)
USE teamcruzim;

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

-- Reset auto increments
ALTER TABLE audit_logs AUTO_INCREMENT = 1;
ALTER TABLE borrowed_items AUTO_INCREMENT = 1;
ALTER TABLE custodian AUTO_INCREMENT = 1;
ALTER TABLE maintenance AUTO_INCREMENT = 1;
ALTER TABLE maintenance_requests AUTO_INCREMENT = 1;
ALTER TABLE property_requests AUTO_INCREMENT = 1;
ALTER TABLE supplies_requests AUTO_INCREMENT = 1;
ALTER TABLE properties AUTO_INCREMENT = 1;
ALTER TABLE supplies AUTO_INCREMENT = 1;
ALTER TABLE users AUTO_INCREMENT = 2;
ALTER TABLE departments AUTO_INCREMENT = 6;

SELECT 'All generated data cleared!' AS Status;
```

---

## 📞 Support & Questions

If you encounter issues:

1. Check the troubleshooting section above
2. Review MySQL error logs
3. Verify your database schema matches the expected structure
4. Ensure all prerequisites are met (XAMPP running, database exists)

---

## ✅ Checklist

Before executing:
- [ ] XAMPP MySQL is running
- [ ] Database `teamcruzim` exists
- [ ] Backup completed (if needed)
- [ ] Sufficient disk space available
- [ ] No other heavy processes running

After executing:
- [ ] All scripts completed without errors
- [ ] Record counts verified
- [ ] Sample queries tested
- [ ] System functionality tested
- [ ] Performance is acceptable

---

## 🎉 Success!

Once generation is complete, your system will have:
- ✅ Realistic Philippine school data
- ✅ Proper entity relationships
- ✅ Complete workflow simulation
- ✅ Ready for testing and demonstration
- ✅ Production-like environment

**Enjoy testing your Property Custodian Management System!**

---

*Generated by: Test Data Generation Script v1.0*  
*Database: teamcruzim*  
*Date: January 2026*
