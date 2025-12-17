-- SQL script to insert default accounts into `users` table.
-- Adjust column names if your schema uses different names (userId/user_id, passwordEncrypted/password_encrypted, created_at/createdAt)

-- Insert default accounts with PBKDF2 hashes for password encryption
INSERT INTO users (firstName, lastName, email, username, passwordEncrypted, role, status, created_at)
VALUES
('Super','Administrator','superadmin@stacruz.edu','superadmin','$PBKDF2y$10$32charactersaltsuperadminhashhere','SuperAdmin','Active', NOW()),
('System','Administrator','admin@stacruz.edu','admin','$PBKDF2y$10$32charactersaltadminhashhere','Admin','Active', NOW()),
('Property','Custodian','custodian@stacruz.edu','custodian','$PBKDF2y$10$32charactersaltcustodianhashhere','Custodian','Active', NOW()),
('Test','Staff','test_staff@stacruz.edu','test_staff','$PBKDF2y$10$32charactersaltstaffhashhere','Staff','Active', NOW());

-- If your schema uses different column names, adapt accordingly. For example, use `password_encrypted` instead of `passwordEncrypted`.

-- The following PowerShell script can be used to generate the PBKDF2 hashes:
-- # Save as gen-hashes.ps1 and run in PowerShell
-- $pwds = @{
--   superadmin = 'SuperAdmin@123'
--   admin      = 'Admin@123'
--   custodian  = 'Custodian@2025'
--   test_staff = 'Staff@1234'
-- }
-- foreach ($k in $pwds.Keys) {
--   $pwd = $pwds[$k]
--   $salt = New-Object byte[] 32
--   [Security.Cryptography.RNGCryptoServiceProvider]::Create().GetBytes($salt)
--   $pbk = New-Object System.Security.Cryptography.Rfc2898DeriveBytes($pwd, $salt, 10000)
--   $hash = $pbk.GetBytes(20)
--   $combined = New-Object byte[] ($salt.Length + $hash.Length)
--   [Array]::Copy($salt,0,$combined,0,$salt.Length)
--   [Array]::Copy($hash,0,$combined,$salt.Length,$hash.Length)
--   $b64 = [Convert]::ToBase64String($combined)
--   Write-Output "$k`t$b64"
-- }
