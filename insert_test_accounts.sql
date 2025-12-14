-- =====================================================
-- Test Accounts for Team Cruz IM System
-- Generated: 2025-12-15 02:31:57
-- =====================================================

USE teamcruzim;

-- Ensure we have at least one department
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

-- Get department ID
SET @dept_id = (SELECT departmentId FROM departments WHERE officeCode = 'IT001' LIMIT 1);

-- =====================================================
-- 1. CREATE SUPERADMIN ACCOUNT
-- =====================================================
-- Username: superadmin
-- Password: SuperAdmin@123

INSERT INTO users (
    firstName,
    middleName,
    lastName,
    position,
    departmentId,
    contactNumber,
    email,
    username,
    passwordEncrypted,
    barangay,
    municipal,
    province,
    employeeId,
    role,
    status
) VALUES (
    'Super',
    'Test',
    'Admin',
    'System Administrator',
    @dept_id,
    '09123456789',
    'superadmin@stacruz.edu',
    'superadmin',
    'LhI+W+R30BpzedgPhf2InACoUxiTmbWgXgRCNNwXSvYlhSUImCMDyswz9BhH+zAjvE/hRg==',
    'Test Barangay',
    'Sta. Cruz',
    'Laguna',
    'SA-001',
    'SuperAdmin',
    'Active'
)
ON DUPLICATE KEY UPDATE
    passwordEncrypted = VALUES(passwordEncrypted),
    status = 'Active';

-- =====================================================
-- 2. CREATE ADMIN ACCOUNT
-- =====================================================
-- Username: admin
-- Password: Admin@123

INSERT INTO users (
    firstName,
    middleName,
    lastName,
    position,
    departmentId,
    contactNumber,
    email,
    username,
    passwordEncrypted,
    barangay,
    municipal,
    province,
    employeeId,
    role,
    status
) VALUES (
    'Admin',
    'Test',
    'User',
    'Administrator',
    @dept_id,
    '09123456790',
    'admin@stacruz.edu',
    'admin',
    '9zW+jPeOrjixpWx/nw2KkvOkuhCZmpwPt9zMcPW0wx/Ci8hKEvgitnGlBlSErzftHN4k6g==',
    'Test Barangay',
    'Sta. Cruz',
    'Laguna',
    'AD-001',
    'Admin',
    'Active'
)
ON DUPLICATE KEY UPDATE
    passwordEncrypted = VALUES(passwordEncrypted),
    status = 'Active';

-- =====================================================
-- 3. CREATE STAFF ACCOUNT
-- =====================================================
-- Username: staff
-- Password: Staff@123

INSERT INTO staff_accounts (
    firstName,
    middleName,
    lastName,
    position,
    departmentId,
    contactNumber,
    email,
    username,
    passwordEncrypted,
    barangay,
    municipal,
    province,
    employeeId,
    status
) VALUES (
    'Staff',
    'Test',
    'User',
    'Staff Member',
    @dept_id,
    '09123456791',
    'staff@stacruz.edu',
    'staff',
    'tmmnPevrud+hYqfAZ1xc7mKSEAqYdS25iEl1rtlmCJYnW7fy+8zw1rbzyuISzUDagNgamA==',
    'Test Barangay',
    'Sta. Cruz',
    'Laguna',
    'ST-001',
    'Active'
)
ON DUPLICATE KEY UPDATE
    passwordEncrypted = VALUES(passwordEncrypted),
    status = 'Active';

-- =====================================================
-- VERIFICATION
-- =====================================================

SELECT 'SuperAdmin and Admin accounts created:' AS Info;
SELECT userId, username, fullName, role, status
FROM users
WHERE username IN ('superadmin', 'admin');

SELECT 'Staff account created:' AS Info;
SELECT staffId, username, fullName, position, status
FROM staff_accounts
WHERE username = 'staff';

-- =====================================================
-- END OF SCRIPT
-- =====================================================
