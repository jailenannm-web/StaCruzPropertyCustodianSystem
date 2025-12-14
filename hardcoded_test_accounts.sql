-- =====================================================
-- HARDCODED Test Accounts for Team Cruz IM System
-- Generated: 2025-12-15 03:40:29
-- These accounts use BCrypt hashed passwords
-- =====================================================

USE teamcruzim;

-- First, ensure we have a test department
DELETE FROM departments WHERE officeCode = 'TEST001';

INSERT INTO departments (
    departmentName,
    headOfDepartment,
    contactNumber,
    email,
    location,
    officeCode,
    status
) VALUES (
    'Test Department',
    'System Admin',
    '09123456789',
    'test@stacruz.edu',
    'Main Office',
    'TEST001',
    'Active'
);

-- Get the department ID
SET @test_dept_id = LAST_INSERT_ID();

-- =====================================================
-- 1. DELETE EXISTING TEST ACCOUNTS (if any)
-- =====================================================
DELETE FROM users WHERE username IN ('superadmin', 'admin');
DELETE FROM staff_accounts WHERE username = 'staff';

-- =====================================================
-- 2. CREATE SUPERADMIN ACCOUNT (HARDCODED)
-- =====================================================
-- Username: superadmin
-- Password: superadmin123
-- BCrypt Hash: $2a$10$e0MYzXyjpJS7Pd0RVvHwHe6NoALjqOXkx/F6t7LPqr2d9QQOQPqOC

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
    status,
    fullName
) VALUES (
    'Super',
    'Test',
    'Admin',
    'System Administrator',
    @test_dept_id,
    '09123456789',
    'superadmin@stacruz.edu',
    'superadmin',
    '$2a$10$e0MYzXyjpJS7Pd0RVvHwHe6NoALjqOXkx/F6t7LPqr2d9QQOQPqOC',
    'Test Barangay',
    'Sta. Cruz',
    'Laguna',
    'SA-2025-001',
    'SuperAdmin',
    'Active',
    'Super Test Admin'
);

-- =====================================================
-- 3. CREATE ADMIN ACCOUNT (HARDCODED)
-- =====================================================
-- Username: admin
-- Password: admin123
-- BCrypt Hash: $2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy

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
    status,
    fullName
) VALUES (
    'Admin',
    'Test',
    'User',
    'Administrator',
    @test_dept_id,
    '09123456790',
    'admin@stacruz.edu',
    'admin',
    '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy',
    'Test Barangay',
    'Sta. Cruz',
    'Laguna',
    'AD-2025-001',
    'Admin',
    'Active',
    'Admin Test User'
);

-- =====================================================
-- 4. CREATE STAFF ACCOUNT (HARDCODED)
-- =====================================================
-- Username: staff
-- Password: staff123
-- BCrypt Hash: $2a$10$kZnI5JRCAW9kWZ.0cBmYJOcQXrpJsKKfR7FkZHAeqLgRGEWQXMqRm

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
    status,
    fullName
) VALUES (
    'Staff',
    'Test',
    'User',
    'Staff Member',
    @test_dept_id,
    '09123456791',
    'staff@stacruz.edu',
    'staff',
    '$2a$10$kZnI5JRCAW9kWZ.0cBmYJOcQXrpJsKKfR7FkZHAeqLgRGEWQXMqRm',
    'Test Barangay',
    'Sta. Cruz',
    'Laguna',
    'ST-2025-001',
    'Active',
    'Staff Test User'
);

-- =====================================================
-- 5. VERIFICATION
-- =====================================================

SELECT '=====================================' AS '';
SELECT 'HARDCODED TEST ACCOUNTS CREATED' AS '';
SELECT '=====================================' AS '';

SELECT '' AS '';
SELECT 'SuperAdmin and Admin Accounts:' AS '';
SELECT userId, username, fullName, role, status, email
FROM users
WHERE username IN ('superadmin', 'admin')
ORDER BY role DESC;

SELECT '' AS '';
SELECT 'Staff Account:' AS '';
SELECT staffId, username, fullName, position, status, email
FROM staff_accounts
WHERE username = 'staff';

SELECT '' AS '';
SELECT '=====================================' AS '';
SELECT 'LOGIN CREDENTIALS' AS '';
SELECT '=====================================' AS '';
SELECT '' AS '';
SELECT 'SUPERADMIN:' AS '';
SELECT '  Username: superadmin' AS '';
SELECT '  Password: superadmin123' AS '';
SELECT '' AS '';
SELECT 'ADMIN:' AS '';
SELECT '  Username: admin' AS '';
SELECT '  Password: admin123' AS '';
SELECT '' AS '';
SELECT 'STAFF:' AS '';
SELECT '  Username: staff' AS '';
SELECT '  Password: staff123' AS '';
SELECT '' AS '';
SELECT '=====================================' AS '';

-- =====================================================
-- END OF SCRIPT
-- =====================================================
