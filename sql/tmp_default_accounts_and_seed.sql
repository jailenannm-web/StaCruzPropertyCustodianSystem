-- Default accounts and minimal seed data for teamcruzim
-- This script inserts default user accounts if they do not exist.
-- The application includes InitializeDefaultAccounts(), which will ensure passwords are hashed and synced.

USE teamcruzim;

-- Insert departments if not exists
INSERT INTO departments (departmentName, headOfDepartment, email, contactNumber, location, building, status, createdAt)
SELECT 'Administration','John Doe','admin@example.com','123-456-7890','Main Building','Building A','Active', NOW()
WHERE NOT EXISTS (SELECT 1 FROM departments WHERE LOWER(departmentName) = 'administration');

INSERT INTO departments (departmentName, headOfDepartment, email, contactNumber, location, building, status, createdAt)
SELECT 'IT Department','Jane Smith','it@example.com','123-456-7891','Main Building','Building A','Active', NOW()
WHERE NOT EXISTS (SELECT 1 FROM departments WHERE LOWER(departmentName) = 'it department');

-- Insert default users (accounts). Passwords will be set/updated by the application InitializeDefaultAccounts() which hashes passwords.
-- If you prefer to set password hashes here, generate PBKDF2 salted Base64 strings compatible with PasswordHelper.HashPassword and update the passwordEncrypted fields.

-- SuperAdmin
INSERT INTO users (firstName, lastName, email, username, role, status, createdAt)
SELECT 'Super','Admin','superadmin@example.com','superadmin','SuperAdmin','Active', NOW()
WHERE NOT EXISTS (SELECT 1 FROM users WHERE LOWER(username) = 'superadmin');

-- Admin
INSERT INTO users (firstName, lastName, email, username, role, status, createdAt)
SELECT 'System','Administrator','admin@example.com','admin','Admin','Active', NOW()
WHERE NOT EXISTS (SELECT 1 FROM users WHERE LOWER(username) = 'admin');

-- Custodian
INSERT INTO users (firstName, lastName, email, username, role, status, createdAt)
SELECT 'Property','Custodian','custodian@example.com','custodian','Custodian','Active', NOW()
WHERE NOT EXISTS (SELECT 1 FROM users WHERE LOWER(username) = 'custodian');

-- Staff (will also ensure staff_accounts synced by app)
INSERT INTO users (firstName, lastName, email, username, role, status, createdAt)
SELECT 'Test','Staff','staff@example.com','staff','Staff','Active', NOW()
WHERE NOT EXISTS (SELECT 1 FROM users WHERE LOWER(username) = 'staff');

-- Minimal note: Run the application once (open the login form) to trigger InitializeDefaultAccounts()
-- which will insert secure hashed passwords for these accounts and create/update corresponding staff_accounts entries.

SELECT userId, username, role, status FROM users WHERE username IN ('superadmin','admin','custodian','staff');

-- Example default credentials (after app initializes):
-- SuperAdmin: username = superadmin  password = SuperAdmin@123
-- Admin: username = admin  password = Admin@123
-- Custodian: username = custodian  password = Custodian@123
-- Staff: username = staff  password = Staff@123
