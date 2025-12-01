-- Create test staff account
-- Username: test_staff
-- Password: Staff@1234
-- Role: Staff

USE teamcruzim;

-- Get the first department ID for assignment
SET @dept_id = (SELECT department_id FROM departments LIMIT 1);

-- Insert test staff account
INSERT INTO staff_accounts (
    first_name,
    last_name,
    email,
    username,
    password_encrypted,
    position,
    department_id,
    status,
    created_at
) VALUES (
    'Test',
    'Staff',
    'test_staff@stacruz.edu',
    'test_staff',
    '$2a$11$YourHashedPasswordHere', -- This should be hashed with PasswordHelper.HashPassword('Staff@1234')
    'Staff',
    @dept_id,
    'Active',
    NOW()
)
ON DUPLICATE KEY UPDATE
    status = 'Active',
    updated_at = NOW();

-- Note: The password hash above is a placeholder. 
-- In production, use PasswordHelper.HashPassword('Staff@1234') from the application
-- or use a MySQL function to hash the password if available.

