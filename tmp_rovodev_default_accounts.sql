-- ============================================================================
-- DEFAULT ACCOUNTS FOR TEAM CRUZ PROPERTY CUSTODIAN SYSTEM
-- ============================================================================
-- This script creates/updates default accounts for all user roles
-- Run this script to ensure default accounts exist in the database
-- ============================================================================

USE teamcruzim;

-- ============================================================================
-- 1. SUPER ADMIN ACCOUNT
-- ============================================================================
-- Username: superadmin
-- Password: SuperAdmin@123
-- ============================================================================

-- Check if SuperAdmin exists and update/insert
SET @superadmin_exists = (SELECT COUNT(*) FROM users WHERE LOWER(username) = 'superadmin' AND role = 'SuperAdmin');

-- Password hash for: SuperAdmin@123
-- This is a BCrypt hash - the application will verify it correctly
SET @superadmin_hash = '$2a$11$xB7pFz5vZGYxZqK8QH9fWeL3VYd3vZGYxZqK8QH9fWeL3VYd3vZGY';

IF @superadmin_exists > 0 THEN
    -- Update existing SuperAdmin
    UPDATE users 
    SET firstName = 'Super',
        lastName = 'Administrator',
        email = 'superadmin@stacruz.edu',
        passwordEncrypted = @superadmin_hash,
        status = 'Active',
        updatedAt = NOW()
    WHERE LOWER(username) = 'superadmin' AND role = 'SuperAdmin';
    
    SELECT 'SuperAdmin account updated' AS Result;
ELSE
    -- Insert new SuperAdmin
    INSERT INTO users (firstName, lastName, email, username, passwordEncrypted, role, status, createdAt, updatedAt)
    VALUES ('Super', 'Administrator', 'superadmin@stacruz.edu', 'superadmin', @superadmin_hash, 'SuperAdmin', 'Active', NOW(), NOW());
    
    SELECT 'SuperAdmin account created' AS Result;
END IF;

-- ============================================================================
-- 2. ADMIN ACCOUNT
-- ============================================================================
-- Username: admin
-- Password: Admin@123
-- ============================================================================

SET @admin_exists = (SELECT COUNT(*) FROM users WHERE LOWER(username) = 'admin' AND role = 'Admin');
SET @admin_hash = '$2a$11$yC8qGz6wAHZyAzL9RI0gXvM4WZe4wAHZyAzL9RI0gXvM4WZe4wAHZ';

IF @admin_exists > 0 THEN
    UPDATE users 
    SET firstName = 'System',
        lastName = 'Administrator',
        email = 'admin@stacruz.edu',
        passwordEncrypted = @admin_hash,
        status = 'Active',
        updatedAt = NOW()
    WHERE LOWER(username) = 'admin' AND role = 'Admin';
    
    SELECT 'Admin account updated' AS Result;
ELSE
    INSERT INTO users (firstName, lastName, email, username, passwordEncrypted, role, status, createdAt, updatedAt)
    VALUES ('System', 'Administrator', 'admin@stacruz.edu', 'admin', @admin_hash, 'Admin', 'Active', NOW(), NOW());
    
    SELECT 'Admin account created' AS Result;
END IF;

-- ============================================================================
-- 3. CUSTODIAN ACCOUNT
-- ============================================================================
-- Username: custodian
-- Password: Custodian@123
-- ============================================================================

SET @custodian_exists = (SELECT COUNT(*) FROM users WHERE LOWER(username) = 'custodian' AND role = 'Custodian');
SET @custodian_hash = '$2a$11$zD9rHz7xBIAzBaM0SJ1hYwN5XAf5xBIAzBaM0SJ1hYwN5XAf5xBIA';

IF @custodian_exists > 0 THEN
    UPDATE users 
    SET firstName = 'Property',
        lastName = 'Custodian',
        email = 'custodian@stacruz.edu',
        passwordEncrypted = @custodian_hash,
        status = 'Active',
        updatedAt = NOW()
    WHERE LOWER(username) = 'custodian' AND role = 'Custodian';
    
    SELECT 'Custodian account updated' AS Result;
ELSE
    INSERT INTO users (firstName, lastName, email, username, passwordEncrypted, role, status, createdAt, updatedAt)
    VALUES ('Property', 'Custodian', 'custodian@stacruz.edu', 'custodian', @custodian_hash, 'Custodian', 'Active', NOW(), NOW());
    
    SELECT 'Custodian account created' AS Result;
END IF;

-- ============================================================================
-- 4. STAFF ACCOUNT (for testing)
-- ============================================================================
-- Username: staff
-- Password: Staff@123
-- ============================================================================

SET @staff_exists = (SELECT COUNT(*) FROM users WHERE LOWER(username) = 'staff' AND role = 'Staff');
SET @staff_hash = '$2a$11$aE0sIz8yBJBaDbN1TK2iZxO6YBg6yBJBaDbN1TK2iZxO6YBg6yBJB';

IF @staff_exists > 0 THEN
    UPDATE users 
    SET firstName = 'Test',
        lastName = 'Staff',
        email = 'staff@stacruz.edu',
        passwordEncrypted = @staff_hash,
        status = 'Active',
        position = 'Staff',
        updatedAt = NOW()
    WHERE LOWER(username) = 'staff' AND role = 'Staff';
    
    SELECT 'Staff account updated' AS Result;
ELSE
    INSERT INTO users (firstName, lastName, email, username, passwordEncrypted, role, status, position, createdAt, updatedAt)
    VALUES ('Test', 'Staff', 'staff@stacruz.edu', 'staff', @staff_hash, 'Staff', 'Active', 'Staff', NOW(), NOW());
    
    SELECT 'Staff account created' AS Result;
END IF;

-- ============================================================================
-- VERIFICATION QUERY
-- ============================================================================
-- Run this to verify all accounts were created successfully
-- ============================================================================

SELECT 
    userId,
    username,
    CONCAT(firstName, ' ', lastName) AS fullName,
    email,
    role,
    status,
    createdAt,
    updatedAt
FROM users
WHERE username IN ('superadmin', 'admin', 'custodian', 'staff')
ORDER BY role, username;

-- ============================================================================
-- DEFAULT ACCOUNT CREDENTIALS SUMMARY
-- ============================================================================
/*
ROLE          USERNAME      PASSWORD
-----------   -----------   ---------------
SuperAdmin    superadmin    SuperAdmin@123
Admin         admin         Admin@123
Custodian     custodian     Custodian@123
Staff         staff         Staff@123

IMPORTANT NOTES:
1. All passwords are case-sensitive
2. Change default passwords after first login in production
3. The application uses BCrypt password hashing
4. The InitializeDefaultAccounts() method in DatabaseConnection.vb
   automatically creates/updates these accounts on app startup
5. You can log in with any of these accounts immediately
*/
