╔═══════════════════════════════════════════════════════════════════╗
║       HARDCODED TEST ACCOUNTS - READY TO USE                      ║
╚═══════════════════════════════════════════════════════════════════╝

📁 FILE: hardcoded_test_accounts.sql

⚠️  IMPORTANT: These accounts use REAL BCrypt password hashes that are
   guaranteed to work with your VB.NET authentication system!

╔═══════════════════════════════════════════════════════════════════╗
║                    ACCOUNT CREDENTIALS                            ║
╚═══════════════════════════════════════════════════════════════════╝

┌───────────────────────────────────────────────────────────────────┐
│ 1. SUPERADMIN ACCOUNT                                             │
├───────────────────────────────────────────────────────────────────┤
│ Username:  superadmin                                             │
│ Password:  superadmin123                                          │
│ Email:     superadmin@stacruz.edu                                 │
│ Role:      SuperAdmin (Full System Access)                        │
│ Employee:  SA-2025-001                                            │
└───────────────────────────────────────────────────────────────────┘

┌───────────────────────────────────────────────────────────────────┐
│ 2. ADMIN ACCOUNT                                                  │
├───────────────────────────────────────────────────────────────────┤
│ Username:  admin                                                  │
│ Password:  admin123                                               │
│ Email:     admin@stacruz.edu                                      │
│ Role:      Admin (Administrative Access)                          │
│ Employee:  AD-2025-001                                            │
└───────────────────────────────────────────────────────────────────┘

┌───────────────────────────────────────────────────────────────────┐
│ 3. STAFF ACCOUNT                                                  │
├───────────────────────────────────────────────────────────────────┤
│ Username:  staff                                                  │
│ Password:  staff123                                               │
│ Email:     staff@stacruz.edu                                      │
│ Role:      Staff (Regular User Access)                            │
│ Employee:  ST-2025-001                                            │
└───────────────────────────────────────────────────────────────────┘

╔═══════════════════════════════════════════════════════════════════╗
║                      HOW TO IMPORT                                ║
╚═══════════════════════════════════════════════════════════════════╝

METHOD 1: MySQL Workbench (Recommended)
─────────────────────────────────────────
1. Open MySQL Workbench
2. Connect to your MySQL server
3. Click: File > Run SQL Script...
4. Select: hardcoded_test_accounts.sql
5. Click: Run

METHOD 2: MySQL Command Line
─────────────────────────────────────────
1. Open Command Prompt
2. Navigate to this folder
3. Run: mysql -u root -p teamcruzim
4. Enter your MySQL password
5. Run: source hardcoded_test_accounts.sql;

METHOD 3: phpMyAdmin
─────────────────────────────────────────
1. Open phpMyAdmin
2. Select "teamcruzim" database
3. Click "Import" tab
4. Choose hardcoded_test_accounts.sql
5. Click "Go"

╔═══════════════════════════════════════════════════════════════════╗
║                        WHAT HAPPENS                               ║
╚═══════════════════════════════════════════════════════════════════╝

The SQL script will:
✓ Create a "Test Department" (if needed)
✓ Delete any existing test accounts
✓ Create SuperAdmin account with BCrypt-hashed password
✓ Create Admin account with BCrypt-hashed password
✓ Create Staff account with BCrypt-hashed password
✓ Display verification information

╔═══════════════════════════════════════════════════════════════════╗
║                      AFTER IMPORTING                              ║
╚═══════════════════════════════════════════════════════════════════╝

1. ✓ Run your VB.NET application
2. ✓ Try logging in with:
   
   For SuperAdmin:
   - Username: superadmin
   - Password: superadmin123
   
   For Admin:
   - Username: admin
   - Password: admin123
   
   For Staff:
   - Username: staff
   - Password: staff123

3. ✓ Test each role's functionality

╔═══════════════════════════════════════════════════════════════════╗
║                      TECHNICAL DETAILS                            ║
╚═══════════════════════════════════════════════════════════════════╝

✓ Password Hashing: BCrypt (industry standard)
✓ Database Columns: All use camelCase (matching your schema)
✓ Status: All accounts set to "Active"
✓ Full Name: Auto-generated for display
✓ Department: All assigned to "Test Department"

╔═══════════════════════════════════════════════════════════════════╗
║                      TROUBLESHOOTING                              ║
╚═══════════════════════════════════════════════════════════════════╝

Problem: "Unknown database 'teamcruzim'"
Solution: Create the database first:
          CREATE DATABASE teamcruzim;

Problem: "Table doesn't exist"
Solution: Run database_schema_complete.sql first

Problem: Still can't login
Solution: 1. Check database connection in DatabaseConnection.vb
          2. Verify MySQL is running
          3. Check that columns match (camelCase)
          4. Rebuild your VB.NET project

╔═══════════════════════════════════════════════════════════════════╗
║                         FILES CREATED                             ║
╚═══════════════════════════════════════════════════════════════════╝

✓ hardcoded_test_accounts.sql       - SQL file to import
✓ HARDCODED_ACCOUNTS_README.txt     - This file
✓ DatabaseConnection.vb.backup      - Backup of fixed code

╔═══════════════════════════════════════════════════════════════════╗
║                           SECURITY                                ║
╚═══════════════════════════════════════════════════════════════════╝

⚠️  IMPORTANT: These are TEST ACCOUNTS ONLY!
   
   DO NOT USE IN PRODUCTION!
   
   For production:
   - Change all passwords immediately
   - Use stronger passwords
   - Enable two-factor authentication
   - Follow security best practices

═══════════════════════════════════════════════════════════════════

Generated: December 15, 2025
Project: Sta. Cruz Property Custodian Management System
Version: 1.0 - Hardcoded Test Accounts

═══════════════════════════════════════════════════════════════════
