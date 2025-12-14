# =====================================================
# Team Cruz IM - Test Account Generator
# PowerShell Script to Generate Password Hashes
# =====================================================

Write-Host "=====================================================" -ForegroundColor Cyan
Write-Host "Team Cruz IM - Test Account Generator" -ForegroundColor Cyan
Write-Host "=====================================================" -ForegroundColor Cyan
Write-Host ""

# Function to hash password using PBKDF2 (same as VB.NET PasswordHelper)
function Get-PasswordHash {
    param([string]$Password)
    
    # Generate a random salt (32 bytes)
    $salt = New-Object byte[] 32
    $rng = New-Object System.Security.Cryptography.RNGCryptoServiceProvider
    $rng.GetBytes($salt)
    
    # Hash the password with salt using PBKDF2 (10000 iterations)
    $pbkdf2 = New-Object System.Security.Cryptography.Rfc2898DeriveBytes($Password, $salt, 10000)
    $hash = $pbkdf2.GetBytes(20)
    
    # Combine salt and hash
    $hashBytes = New-Object byte[] ($salt.Length + $hash.Length)
    [Array]::Copy($salt, 0, $hashBytes, 0, $salt.Length)
    [Array]::Copy($hash, 0, $hashBytes, $salt.Length, $hash.Length)
    
    # Convert to Base64 for database storage
    return [Convert]::ToBase64String($hashBytes)
}

Write-Host "Generating password hashes..." -ForegroundColor Yellow
Write-Host ""

# Generate password hashes
$superAdminHash = Get-PasswordHash "SuperAdmin@123"
$adminHash = Get-PasswordHash "Admin@123"
$staffHash = Get-PasswordHash "Staff@123"

Write-Host "Password hashes generated successfully!" -ForegroundColor Green
Write-Host ""
Write-Host "SuperAdmin Hash:" -ForegroundColor Yellow
Write-Host $superAdminHash -ForegroundColor White
Write-Host ""
Write-Host "Admin Hash:" -ForegroundColor Yellow
Write-Host $adminHash -ForegroundColor White
Write-Host ""
Write-Host "Staff Hash:" -ForegroundColor Yellow
Write-Host $staffHash -ForegroundColor White
Write-Host ""

# Generate SQL script
$timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"

$sqlScript = @"
-- =====================================================
-- Test Accounts for Team Cruz IM System
-- Generated: $timestamp
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
    '$superAdminHash',
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
    '$adminHash',
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
    '$staffHash',
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
"@

# Save to file
$sqlScript | Out-File -FilePath "insert_test_accounts.sql" -Encoding UTF8

Write-Host "=====================================================" -ForegroundColor Cyan
Write-Host "SQL script generated: insert_test_accounts.sql" -ForegroundColor Green
Write-Host "=====================================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Test Account Credentials:" -ForegroundColor Cyan
Write-Host "=====================================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "1. SUPER ADMIN" -ForegroundColor Yellow
Write-Host "   Username: superadmin" -ForegroundColor White
Write-Host "   Password: SuperAdmin@123" -ForegroundColor White
Write-Host "   Email: superadmin@stacruz.edu" -ForegroundColor White
Write-Host ""
Write-Host "2. ADMIN" -ForegroundColor Yellow
Write-Host "   Username: admin" -ForegroundColor White
Write-Host "   Password: Admin@123" -ForegroundColor White
Write-Host "   Email: admin@stacruz.edu" -ForegroundColor White
Write-Host ""
Write-Host "3. STAFF" -ForegroundColor Yellow
Write-Host "   Username: staff" -ForegroundColor White
Write-Host "   Password: Staff@123" -ForegroundColor White
Write-Host "   Email: staff@stacruz.edu" -ForegroundColor White
Write-Host ""
Write-Host "=====================================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Next Steps:" -ForegroundColor Green
Write-Host "1. Run 'insert_test_accounts.sql' in your MySQL database" -ForegroundColor White
Write-Host "2. Use the credentials above to login to the system" -ForegroundColor White
Write-Host ""
Write-Host "To import the SQL file, use one of these methods:" -ForegroundColor Yellow
Write-Host "- MySQL Workbench: File > Run SQL Script..." -ForegroundColor White
Write-Host "- Command line: mysql -u root -p teamcruzim < insert_test_accounts.sql" -ForegroundColor White
Write-Host ""
