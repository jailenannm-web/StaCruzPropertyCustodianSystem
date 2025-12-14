-- =====================================================
-- CREATE TEST ACCOUNTS - SIMPLE VERSION
-- Just copy and paste this entire script into MySQL
-- =====================================================

-- Make sure we're using the correct database
USE teamcruzim;

-- Step 1: Create IT Department if it doesn't exist
INSERT IGNORE INTO departments (
    departmentName,
    headOfDepartment,
    contactNumber,
    email,
    location,
    officeCode,
    status
) VALUES (
    'IT Department',
    'Test Head',
    '09123456789',
    'it@stacruz.edu',
    'Main Building',
    'IT001',
    'Active'
);

-- Get the department ID
SET @dept_id = (SELECT departmentId FROM departments WHERE officeCode = 'IT001' LIMIT 1);

-- Step 2: Delete old test accounts if they exist (to start fresh)
DELETE FROM users WHERE username IN ('superadmin', 'admin');
DELETE FROM staff_accounts WHERE username = 'staff';

-- Step 3: Create SuperAdmin account
-- Username: superadmin
-- Password: SuperAdmin@123
INSERT INTO users (
    firstName,
    lastName,
    position,
    departmentId,
    contactNumber,
    email,
    username,
    passwordEncrypted,
    province,
    municipal,
    barangay,
    employeeId,
    role,
    status
) VALUES (
    'Super',
    'Admin',
    'System Administrator',
    @dept_id,
    '09123456789',
    'superadmin@stacruz.edu',
    'superadmin',
    'LhI+W+R30BpzedgPhf2InACoUxiTmbWgXgRCNNwXSvYlhSUImCMDyswz9BhH+zAjvE/hRg==',
    'Laguna',
    'Sta. Cruz',
    'Test Barangay',
    'SA-001',
    'SuperAdmin',
    'Active'
);

-- Step 4: Create Admin account
-- Username: admin
-- Password: Admin@123
INSERT INTO users (
    firstName,
    lastName,
    position,
    departmentId,
    contactNumber,
    email,
    username,
    passwordEncrypted,
    province,
    municipal,
    barangay,
    employeeId,
    role,
    status
) VALUES (
    'Admin',
    'User',
    'Administrator',
    @dept_id,
    '09123456790',
    'admin@stacruz.edu',
    'admin',
    '9zW+jPeOrjixpWx/nw2KkvOkuhCZmpwPt9zMcPW0wx/Ci8hKEvgitnGlBlSErzftHN4k6g==',
    'Laguna',
    'Sta. Cruz',
    'Test Barangay',
    'AD-001',
    'Admin',
    'Active'
);

-- Step 5: Create Staff account
-- Username: staff
-- Password: Staff@123
INSERT INTO staff_accounts (
    firstName,
    lastName,
    position,
    departmentId,
    contactNumber,
    email,
    username,
    passwordEncrypted,
    province,
    municipal,
    barangay,
    employeeId,
    status
) VALUES (
    'Staff',
    'User',
    'Staff Member',
    @dept_id,
    '09123456791',
    'staff@stacruz.edu',
    'staff',
    'tmmnPevrud+hYqfAZ1xc7mKSEAqYdS25iEl1rtlmCJYnW7fy+8zw1rbzyuISzUDagNgamA==',
    'Laguna',
    'Sta. Cruz',
    'Test Barangay',
    'ST-001',
    'Active'
);

-- Verify the accounts were created
SELECT '========================================' AS '';
SELECT 'ACCOUNTS CREATED SUCCESSFULLY!' AS '';
SELECT '========================================' AS '';

SELECT 'SuperAdmin Account:' AS '';
SELECT userId, username, role, status FROM users WHERE username = 'superadmin';

SELECT 'Admin Account:' AS '';
SELECT userId, username, role, status FROM users WHERE username = 'admin';

SELECT 'Staff Account:' AS '';
SELECT staffId, username, status FROM staff_accounts WHERE username = 'staff';

SELECT '========================================' AS '';
SELECT 'You can now login with:' AS '';
SELECT 'superadmin / SuperAdmin@123' AS 'Credential 1';
SELECT 'admin / Admin@123' AS 'Credential 2';
SELECT 'staff / Staff@123' AS 'Credential 3';
SELECT '========================================' AS '';
