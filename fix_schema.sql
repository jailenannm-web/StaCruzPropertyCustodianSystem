-- ============================================================================
-- FIX SCHEMA: Rename columns from camelCase to snake_case
-- ============================================================================
-- This script alters all tables to use snake_case column names as expected by the VB code
-- Run this after creating the database with teamcruzim_database.sql
-- ============================================================================

USE teamcruzim;

-- ============================================================================
-- USERS TABLE
-- ============================================================================
ALTER TABLE users CHANGE userId user_id INT AUTO_INCREMENT PRIMARY KEY;
ALTER TABLE users CHANGE firstName first_name VARCHAR(50) NOT NULL;
ALTER TABLE users CHANGE middleName middle_name VARCHAR(50) DEFAULT NULL;
ALTER TABLE users CHANGE lastName last_name VARCHAR(50) NOT NULL;
ALTER TABLE users CHANGE suffix suffix VARCHAR(10) DEFAULT NULL;
ALTER TABLE users CHANGE fullName full_name VARCHAR(255) GENERATED ALWAYS AS (
    CONCAT(
      first_name,
      IF(middle_name IS NOT NULL AND middle_name != '', CONCAT(' ', middle_name), ''),
      ' ',
      last_name,
      IF(suffix IS NOT NULL AND suffix != '', CONCAT(' ', suffix), '')
    )
  ) STORED;
ALTER TABLE users CHANGE position position VARCHAR(100) DEFAULT NULL;
ALTER TABLE users CHANGE departmentId department_id INT DEFAULT NULL;
ALTER TABLE users CHANGE employeeId employee_id VARCHAR(50) UNIQUE DEFAULT NULL;
ALTER TABLE users CHANGE contactNumber contact_number VARCHAR(20) DEFAULT NULL;
ALTER TABLE users CHANGE email email VARCHAR(100) UNIQUE DEFAULT NULL;
ALTER TABLE users CHANGE username username VARCHAR(50) NOT NULL UNIQUE;
ALTER TABLE users CHANGE passwordEncrypted password_encrypted VARCHAR(255) NOT NULL;
ALTER TABLE users CHANGE province province VARCHAR(100) DEFAULT NULL;
ALTER TABLE users CHANGE municipal municipal VARCHAR(100) DEFAULT NULL;
ALTER TABLE users CHANGE barangay barangay VARCHAR(100) DEFAULT NULL;
ALTER TABLE users CHANGE role role ENUM('SuperAdmin', 'Admin', 'Custodian', 'Staff') NOT NULL;
ALTER TABLE users CHANGE status status ENUM('Active', 'Inactive') DEFAULT 'Active';
ALTER TABLE users CHANGE lastLogin last_login DATETIME DEFAULT NULL;
ALTER TABLE users CHANGE createdAt created_at DATETIME DEFAULT CURRENT_TIMESTAMP;
ALTER TABLE users CHANGE updatedAt updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP;

-- ============================================================================
-- DEPARTMENTS TABLE
-- ============================================================================
ALTER TABLE departments CHANGE departmentId department_id INT AUTO_INCREMENT PRIMARY KEY;
ALTER TABLE departments CHANGE departmentName department_name VARCHAR(100) NOT NULL UNIQUE;
ALTER TABLE departments CHANGE headOfDepartment head_of_department VARCHAR(100) NOT NULL;
ALTER TABLE departments CHANGE email email VARCHAR(100) DEFAULT NULL;
ALTER TABLE departments CHANGE contactNumber contact_number VARCHAR(50) DEFAULT NULL;
ALTER TABLE departments CHANGE location location VARCHAR(200) NOT NULL;
ALTER TABLE departments CHANGE building building VARCHAR(100) DEFAULT NULL;
ALTER TABLE departments CHANGE floorNumber floor_number VARCHAR(20) DEFAULT NULL;
ALTER TABLE departments CHANGE shortName short_name VARCHAR(20) DEFAULT NULL;
ALTER TABLE departments CHANGE officeCode office_code VARCHAR(20) DEFAULT NULL;
ALTER TABLE departments CHANGE description description TEXT DEFAULT NULL;
ALTER TABLE departments CHANGE totalProperties total_properties INT DEFAULT 0;
ALTER TABLE departments CHANGE totalSupplies total_supplies INT DEFAULT 0;
ALTER TABLE departments CHANGE status status ENUM('Active', 'Inactive') DEFAULT 'Active';
ALTER TABLE departments CHANGE createdAt created_at DATETIME DEFAULT CURRENT_TIMESTAMP;
ALTER TABLE departments CHANGE updatedAt updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP;

-- ============================================================================
-- STAFF_ACCOUNTS TABLE
-- ============================================================================
ALTER TABLE staff_accounts CHANGE staffId staff_id INT AUTO_INCREMENT PRIMARY KEY;
ALTER TABLE staff_accounts CHANGE userId user_id INT UNIQUE DEFAULT NULL;
ALTER TABLE staff_accounts CHANGE firstName first_name VARCHAR(50) NOT NULL;
ALTER TABLE staff_accounts CHANGE middleName middle_name VARCHAR(50) DEFAULT NULL;
ALTER TABLE staff_accounts CHANGE lastName last_name VARCHAR(50) NOT NULL;
ALTER TABLE staff_accounts CHANGE suffix suffix VARCHAR(10) DEFAULT NULL;
ALTER TABLE staff_accounts CHANGE fullName full_name VARCHAR(255) GENERATED ALWAYS AS (
    CONCAT(
      first_name,
      IF(middle_name IS NOT NULL AND middle_name != '', CONCAT(' ', middle_name), ''),
      ' ',
      last_name,
      IF(suffix IS NOT NULL AND suffix != '', CONCAT(' ', suffix), '')
    )
  ) STORED;
ALTER TABLE staff_accounts CHANGE position position VARCHAR(100) DEFAULT 'Staff';
ALTER TABLE staff_accounts CHANGE departmentId department_id INT DEFAULT NULL;
ALTER TABLE staff_accounts CHANGE employeeId employee_id VARCHAR(50) UNIQUE DEFAULT NULL;
ALTER TABLE staff_accounts CHANGE contactNumber contact_number VARCHAR(20) DEFAULT NULL;
ALTER TABLE staff_accounts CHANGE email email VARCHAR(100) UNIQUE DEFAULT NULL;
ALTER TABLE staff_accounts CHANGE username username VARCHAR(50) NOT NULL UNIQUE;
ALTER TABLE staff_accounts CHANGE passwordEncrypted password_encrypted VARCHAR(255) NOT NULL;
ALTER TABLE staff_accounts CHANGE province province VARCHAR(100) DEFAULT NULL;
ALTER TABLE staff_accounts CHANGE municipal municipal VARCHAR(100) DEFAULT NULL;
ALTER TABLE staff_accounts CHANGE barangay barangay VARCHAR(100) DEFAULT NULL;
ALTER TABLE staff_accounts CHANGE status status ENUM('Active', 'Inactive') DEFAULT 'Active';
ALTER TABLE staff_accounts CHANGE lastLogin last_login DATETIME DEFAULT NULL;
