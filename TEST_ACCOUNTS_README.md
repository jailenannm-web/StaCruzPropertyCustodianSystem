# Test Accounts for Team Cruz IM System

## 📋 Overview
This document contains the credentials for test accounts created for the Sta. Cruz Property Custodian Management System.

## 🔐 Test Account Credentials

### 1. SuperAdmin Account
- **Username:** `superadmin`
- **Password:** `SuperAdmin@123`
- **Email:** superadmin@stacruz.edu
- **Employee ID:** SA-001
- **Role:** SuperAdmin (Full system access)

### 2. Admin Account
- **Username:** `admin`
- **Password:** `Admin@123`
- **Email:** admin@stacruz.edu
- **Employee ID:** AD-001
- **Role:** Admin (Administrative access)

### 3. Staff Account
- **Username:** `staff`
- **Password:** `Staff@123`
- **Email:** staff@stacruz.edu
- **Employee ID:** ST-001
- **Role:** Staff (Regular user access)

## 📁 Generated Files

1. **insert_test_accounts.sql** - SQL script to create the test accounts
2. **Generate-TestAccounts.ps1** - PowerShell script to regenerate accounts (if needed)

## 🚀 How to Import the Accounts

### Method 1: Using MySQL Workbench (Recommended)
1. Open MySQL Workbench
2. Connect to your MySQL server
3. Go to **File > Run SQL Script...**
4. Select `insert_test_accounts.sql`
5. Click **Run**

### Method 2: Using MySQL Command Line
```bash
mysql -u root -p teamcruzim < insert_test_accounts.sql
```
Enter your MySQL root password when prompted.

### Method 3: Using phpMyAdmin
1. Open phpMyAdmin
2. Select the `teamcruzim` database
3. Click on the **Import** tab
4. Choose `insert_test_accounts.sql`
5. Click **Go**

## ✅ Verification

After importing, you can verify the accounts were created by running these queries:

```sql
-- Check SuperAdmin and Admin accounts
SELECT user_id, username, CONCAT(first_name, ' ', last_name) AS full_name, user_type, status
FROM users
WHERE username IN ('superadmin', 'admin');

-- Check Staff account
SELECT staff_id, username, CONCAT(first_name, ' ', last_name) AS full_name, position, status
FROM staff_accounts
WHERE username = 'staff';
```

## 🔄 Regenerating Accounts

If you need to regenerate the accounts with new password hashes:

```powershell
powershell -ExecutionPolicy Bypass -File .\Generate-TestAccounts.ps1
```

This will create a new `insert_test_accounts.sql` file with fresh password hashes.

## 🔒 Security Notes

- These are **TEST ACCOUNTS ONLY** - Do not use in production
- Change passwords immediately after initial testing
- The password hashing uses PBKDF2 with 10,000 iterations (same as your PasswordHelper.vb)
- Passwords are salted and hashed using the same algorithm as your application

## 📝 What Gets Created

The SQL script will:
1. Create an IT Department (if it doesn't exist) with code 'IT001'
2. Create a SuperAdmin user account
3. Create an Admin user account
4. Create a Staff user account
5. Assign all accounts to the IT Department
6. Set all accounts to 'active' status

## 🎯 Testing Workflow

1. **Import the SQL file** into your `teamcruzim` database
2. **Run your application** (StaCruzPropertyCustodianSystem)
3. **Test each account:**
   - Login as `superadmin` to test full administrative features
   - Login as `admin` to test admin-level features
   - Login as `staff` to test staff-level features
4. **Verify role-based access control** is working properly

## 🐛 Troubleshooting

### Issue: "Duplicate entry" error
**Solution:** The script uses `ON DUPLICATE KEY UPDATE`, so it should update existing accounts. If you still get errors, manually delete the accounts first:

```sql
DELETE FROM users WHERE username IN ('superadmin', 'admin');
DELETE FROM staff_accounts WHERE username = 'staff';
```

### Issue: "Unknown database 'teamcruzim'"
**Solution:** Create the database first:
```sql
CREATE DATABASE teamcruzim CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
```

### Issue: "Department not found"
**Solution:** The script creates the IT Department automatically. If there are still issues, check if the departments table exists.

## 📞 Support

If you encounter any issues:
1. Check the database connection in `DatabaseConnection.vb`
2. Verify MySQL is running
3. Ensure the `teamcruzim` database exists
4. Check that all required tables are created using `database_schema_complete.sql`

---

**Generated:** 2025-12-15  
**Version:** 1.0  
**Project:** Sta. Cruz Property Custodian Management System
