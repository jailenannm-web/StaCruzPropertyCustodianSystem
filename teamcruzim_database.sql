/*
  Name: Team Cruz Property Custodian Management System Database
  Database: teamcruzim
  Description: Complete database schema for Property Custodian Management System
  Based on MySQL Sample Database structure pattern
*/

/* Create the database */
CREATE DATABASE IF NOT EXISTS teamcruzim;

/* Switch to the teamcruzim database */
USE teamcruzim;

/* Disable foreign key checks to allow dropping tables in any order */
SET FOREIGN_KEY_CHECKS = 0;

/* Drop existing tables */
DROP TABLE IF EXISTS orderdetails;
DROP TABLE IF EXISTS audit_logs;
DROP TABLE IF EXISTS borrowed_items;
DROP TABLE IF EXISTS custodian;
DROP TABLE IF EXISTS maintenance;
DROP TABLE IF EXISTS maintenance_requests;
DROP TABLE IF EXISTS supplies_requests;
DROP TABLE IF EXISTS property_requests;
DROP TABLE IF EXISTS supplies;
DROP TABLE IF EXISTS properties;
DROP TABLE IF EXISTS staff_accounts;
DROP TABLE IF EXISTS categories;
DROP TABLE IF EXISTS system_config;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS departments;

/* Re-enable foreign key checks */
SET FOREIGN_KEY_CHECKS = 1;

/* Create the tables */

/* 1. DEPARTMENTS TABLE */
CREATE TABLE departments (
  departmentId INT AUTO_INCREMENT PRIMARY KEY,
  departmentName VARCHAR(100) NOT NULL UNIQUE,
  headOfDepartment VARCHAR(100) NOT NULL,
  email VARCHAR(100) DEFAULT NULL,
  contactNumber VARCHAR(50) DEFAULT NULL,
  location VARCHAR(200) NOT NULL,
  building VARCHAR(100) DEFAULT NULL,
  floorNumber VARCHAR(20) DEFAULT NULL,
  shortName VARCHAR(20) DEFAULT NULL,
  officeCode VARCHAR(20) DEFAULT NULL,
  description TEXT DEFAULT NULL,
  totalProperties INT DEFAULT 0,
  totalSupplies INT DEFAULT 0,
  status ENUM('Active', 'Inactive') DEFAULT 'Active',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  INDEX idx_dept_status (status),
  INDEX idx_dept_name (departmentName)
);

/* 2. USERS TABLE (Admin / SuperAdmin / Custodian) */
CREATE TABLE users (
  userId INT AUTO_INCREMENT PRIMARY KEY,
  firstName VARCHAR(50) NOT NULL,
  middleName VARCHAR(50) DEFAULT NULL,
  lastName VARCHAR(50) NOT NULL,
  suffix VARCHAR(10) DEFAULT NULL,
  fullName VARCHAR(255) GENERATED ALWAYS AS (
    CONCAT(
      firstName,
      IF(middleName IS NOT NULL AND middleName != '', CONCAT(' ', middleName), ''),
      ' ',
      lastName,
      IF(suffix IS NOT NULL AND suffix != '', CONCAT(' ', suffix), '')
    )
  ) STORED,
  position VARCHAR(100) DEFAULT NULL,
  departmentId INT DEFAULT NULL,
  employeeId VARCHAR(50) UNIQUE DEFAULT NULL,
  contactNumber VARCHAR(20) DEFAULT NULL,
  email VARCHAR(100) UNIQUE DEFAULT NULL,
  username VARCHAR(50) NOT NULL UNIQUE,
  passwordEncrypted VARCHAR(255) NOT NULL,
  province VARCHAR(100) DEFAULT NULL,
  municipal VARCHAR(100) DEFAULT NULL,
  barangay VARCHAR(100) DEFAULT NULL,
  role ENUM('SuperAdmin', 'Admin', 'Custodian', 'Staff') NOT NULL,
  status ENUM('Active', 'Inactive') DEFAULT 'Active',
  lastLogin DATETIME DEFAULT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId) ON DELETE SET NULL,
  INDEX idx_user_role (role),
  INDEX idx_user_status (status),
  INDEX idx_user_username (username)
);

/* 3. STAFF_ACCOUNTS TABLE (For Staff role) */
CREATE TABLE staff_accounts (
  staffId INT AUTO_INCREMENT PRIMARY KEY,
  userId INT UNIQUE DEFAULT NULL,
  firstName VARCHAR(50) NOT NULL,
  middleName VARCHAR(50) DEFAULT NULL,
  lastName VARCHAR(50) NOT NULL,
  suffix VARCHAR(10) DEFAULT NULL,
  fullName VARCHAR(255) GENERATED ALWAYS AS (
    CONCAT(
      firstName,
      IF(middleName IS NOT NULL AND middleName != '', CONCAT(' ', middleName), ''),
      ' ',
      lastName,
      IF(suffix IS NOT NULL AND suffix != '', CONCAT(' ', suffix), '')
    )
  ) STORED,
  position VARCHAR(100) DEFAULT 'Staff',
  departmentId INT DEFAULT NULL,
  employeeId VARCHAR(50) UNIQUE DEFAULT NULL,
  contactNumber VARCHAR(20) DEFAULT NULL,
  email VARCHAR(100) UNIQUE DEFAULT NULL,
  username VARCHAR(50) NOT NULL UNIQUE,
  passwordEncrypted VARCHAR(255) NOT NULL,
  province VARCHAR(100) DEFAULT NULL,
  municipal VARCHAR(100) DEFAULT NULL,
  barangay VARCHAR(100) DEFAULT NULL,
  status ENUM('Active', 'Inactive') DEFAULT 'Active',
  lastLogin DATETIME DEFAULT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId) ON DELETE SET NULL,
  FOREIGN KEY (userId) REFERENCES users(userId) ON DELETE SET NULL,
  INDEX idx_staff_status (status),
  INDEX idx_staff_username (username)
);

/* 4. CATEGORIES TABLE */
CREATE TABLE categories (
  categoryId INT AUTO_INCREMENT PRIMARY KEY,
  categoryName VARCHAR(100) NOT NULL UNIQUE,
  categoryType ENUM('property', 'supply') NOT NULL,
  description TEXT DEFAULT NULL,
  status ENUM('Active', 'Inactive') DEFAULT 'Active',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

/* 5. PROPERTIES TABLE */
CREATE TABLE properties (
  propertyId INT AUTO_INCREMENT PRIMARY KEY,
  itemName VARCHAR(200) NOT NULL,
  category VARCHAR(100) NOT NULL,
  description TEXT DEFAULT NULL,
  unitOfMeasure VARCHAR(50) DEFAULT NULL,
  propertyNumber VARCHAR(100) UNIQUE DEFAULT NULL,
  serialNumber VARCHAR(100) DEFAULT NULL,
  acquisitionDate DATE NOT NULL,
  acquisitionCost DECIMAL(15,2) NOT NULL,
  totalCost DECIMAL(15,2) DEFAULT NULL,
  sourceOfFunds VARCHAR(200) DEFAULT NULL,
  assignedTo INT DEFAULT NULL,
  departmentId INT DEFAULT NULL,
  location VARCHAR(200) NOT NULL,
  condition ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT 'Good',
  status ENUM('Active', 'Borrowed', 'For Disposal', 'Lost', 'Cost') DEFAULT 'Active',
  internalCodes VARCHAR(100) DEFAULT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (assignedTo) REFERENCES users(userId) ON DELETE SET NULL,
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId) ON DELETE SET NULL,
  INDEX idx_prop_category (category),
  INDEX idx_prop_status (status),
  INDEX idx_prop_department (departmentId),
  INDEX idx_prop_assigned (assignedTo),
  INDEX idx_prop_number (propertyNumber)
);

/* 6. SUPPLIES TABLE */
CREATE TABLE supplies (
  supplyId INT AUTO_INCREMENT PRIMARY KEY,
  itemName VARCHAR(200) NOT NULL,
  category VARCHAR(100) NOT NULL,
  description TEXT DEFAULT NULL,
  unitOfMeasure VARCHAR(50) NOT NULL,
  quantity INT NOT NULL DEFAULT 0,
  dateReceived DATE NOT NULL,
  unitCost DECIMAL(15,2) NOT NULL,
  totalCost DECIMAL(15,2) DEFAULT NULL,
  supplier VARCHAR(200) DEFAULT NULL,
  sourceOfFunds VARCHAR(200) DEFAULT NULL,
  location VARCHAR(200) NOT NULL,
  stockStatus ENUM('Available', 'Low Stock', 'Out of Stock') DEFAULT 'Available',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  INDEX idx_supply_category (category),
  INDEX idx_supply_status (stockStatus),
  INDEX idx_supply_location (location)
);

/* 7. PROPERTY REQUESTS TABLE */
CREATE TABLE property_requests (
  requestId INT AUTO_INCREMENT PRIMARY KEY,
  requesterName VARCHAR(200) NOT NULL,
  position VARCHAR(100) DEFAULT NULL,
  departmentId INT DEFAULT NULL,
  dateOfRequest DATE NOT NULL,
  itemName VARCHAR(200) NOT NULL,
  description TEXT DEFAULT NULL,
  quantityRequested INT NOT NULL DEFAULT 1,
  unit VARCHAR(50) DEFAULT NULL,
  purpose TEXT NOT NULL,
  status ENUM('Pending', 'Approved', 'Rejected') DEFAULT 'Pending',
  approvedBy INT DEFAULT NULL,
  approvedDate DATETIME DEFAULT NULL,
  remarks TEXT DEFAULT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId) ON DELETE SET NULL,
  FOREIGN KEY (approvedBy) REFERENCES users(userId) ON DELETE SET NULL,
  INDEX idx_prop_req_status (status),
  INDEX idx_prop_req_date (dateOfRequest),
  INDEX idx_prop_req_department (departmentId)
);

/* 8. SUPPLIES REQUESTS TABLE */
CREATE TABLE supplies_requests (
  requestId INT AUTO_INCREMENT PRIMARY KEY,
  requesterName VARCHAR(200) NOT NULL,
  position VARCHAR(100) DEFAULT NULL,
  departmentId INT DEFAULT NULL,
  dateOfRequest DATE NOT NULL,
  itemName VARCHAR(200) NOT NULL,
  description TEXT DEFAULT NULL,
  quantityRequested INT NOT NULL DEFAULT 1,
  unit VARCHAR(50) DEFAULT NULL,
  purpose TEXT NOT NULL,
  status ENUM('Pending', 'Approved', 'Rejected') DEFAULT 'Pending',
  approvedBy INT DEFAULT NULL,
  approvedDate DATETIME DEFAULT NULL,
  remarks TEXT DEFAULT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId) ON DELETE SET NULL,
  FOREIGN KEY (approvedBy) REFERENCES users(userId) ON DELETE SET NULL,
  INDEX idx_supply_req_status (status),
  INDEX idx_supply_req_date (dateOfRequest),
  INDEX idx_supply_req_department (departmentId)
);

/* 9. MAINTENANCE REQUESTS TABLE */
CREATE TABLE maintenance_requests (
  requestId INT AUTO_INCREMENT PRIMARY KEY,
  dateRequested DATE NOT NULL,
  itemName VARCHAR(200) NOT NULL,
  propertyNumber VARCHAR(100) DEFAULT NULL,
  serialNumber VARCHAR(100) DEFAULT NULL,
  departmentId INT DEFAULT NULL,
  location VARCHAR(200) DEFAULT NULL,
  conditionBefore ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT 'Good',
  typeOfIssue ENUM('Repair', 'Replace', 'Servicing') NOT NULL,
  problemDescription TEXT NOT NULL,
  status ENUM('Pending', 'Approved', 'In Progress', 'Completed', 'Rejected') DEFAULT 'Pending',
  assignedTechnician VARCHAR(200) DEFAULT NULL,
  targetDate DATE DEFAULT NULL,
  completionDate DATE DEFAULT NULL,
  requestedBy INT DEFAULT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId) ON DELETE SET NULL,
  FOREIGN KEY (requestedBy) REFERENCES users(userId) ON DELETE SET NULL,
  INDEX idx_maint_req_status (status),
  INDEX idx_maint_req_date (dateRequested),
  INDEX idx_maint_req_department (departmentId)
);

/* 10. MAINTENANCE TABLE (Maintenance Work Records) */
CREATE TABLE maintenance (
  maintenanceId INT AUTO_INCREMENT PRIMARY KEY,
  requestId INT DEFAULT NULL,
  propertyItemName VARCHAR(200) NOT NULL,
  serialNumber VARCHAR(100) DEFAULT NULL,
  location VARCHAR(200) DEFAULT NULL,
  departmentId INT DEFAULT NULL,
  conditionBeforeMaint ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT 'Good',
  typeOfMaintenance ENUM('Repair', 'Replace', 'Servicing') NOT NULL,
  assignedTechnician VARCHAR(200) DEFAULT NULL,
  maintenanceDate DATE NOT NULL,
  maintenanceDetails TEXT DEFAULT NULL,
  costMaterialsLabor DECIMAL(15,2) DEFAULT 0,
  conditionAfterMaint ENUM('Good', 'Needs Further Repair') DEFAULT 'Good',
  status ENUM('Completed', 'Ongoing', 'For Review') DEFAULT 'Ongoing',
  diagnosis TEXT DEFAULT NULL,
  actionTaken TEXT DEFAULT NULL,
  partsReplaced TEXT DEFAULT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (requestId) REFERENCES maintenance_requests(requestId) ON DELETE SET NULL,
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId) ON DELETE SET NULL,
  INDEX idx_maint_status (status),
  INDEX idx_maint_date (maintenanceDate),
  INDEX idx_maint_technician (assignedTechnician)
);

/* 11. CUSTODIAN TABLE (Custodian Assignments) */
CREATE TABLE custodian (
  custodianId INT AUTO_INCREMENT PRIMARY KEY,
  userId INT NOT NULL,
  departmentId INT DEFAULT NULL,
  itemId INT DEFAULT NULL,
  itemType ENUM('property', 'supply') DEFAULT NULL,
  assignedDate DATE NOT NULL,
  status ENUM('Active', 'Inactive') DEFAULT 'Active',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (userId) REFERENCES users(userId) ON DELETE CASCADE,
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId) ON DELETE SET NULL,
  INDEX idx_custodian_user (userId),
  INDEX idx_custodian_department (departmentId),
  INDEX idx_custodian_status (status)
);

/* 12. BORROWED ITEMS TABLE */
CREATE TABLE borrowed_items (
  borrowId INT AUTO_INCREMENT PRIMARY KEY,
  requestId INT DEFAULT NULL,
  itemType ENUM('property', 'supply') NOT NULL,
  itemId INT NOT NULL,
  borrowerName VARCHAR(200) NOT NULL,
  borrowerPosition VARCHAR(100) DEFAULT NULL,
  departmentId INT DEFAULT NULL,
  borrowDate DATE NOT NULL,
  expectedReturnDate DATE DEFAULT NULL,
  actualReturnDate DATE DEFAULT NULL,
  conditionOnReturn ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT NULL,
  status ENUM('Borrowed', 'Returned', 'Overdue', 'Lost') DEFAULT 'Borrowed',
  remarks TEXT DEFAULT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId) ON DELETE SET NULL,
  INDEX idx_borrow_status (status),
  INDEX idx_borrow_date (borrowDate),
  INDEX idx_borrow_department (departmentId)
);

/* 13. SYSTEM_CONFIG TABLE */
CREATE TABLE system_config (
  configId INT AUTO_INCREMENT PRIMARY KEY,
  configKey VARCHAR(100) NOT NULL UNIQUE,
  configValue TEXT DEFAULT NULL,
  configType VARCHAR(50) DEFAULT NULL,
  description TEXT DEFAULT NULL,
  updatedBy INT DEFAULT NULL,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (updatedBy) REFERENCES users(userId) ON DELETE SET NULL,
  INDEX idx_config_key (configKey)
);

/* 14. AUDIT_LOGS TABLE */
CREATE TABLE audit_logs (
  logId INT AUTO_INCREMENT PRIMARY KEY,
  userId INT DEFAULT NULL,
  action VARCHAR(100) NOT NULL,
  tableName VARCHAR(100) DEFAULT NULL,
  recordId INT DEFAULT NULL,
  description TEXT DEFAULT NULL,
  ipAddress VARCHAR(50) DEFAULT NULL,
  userAgent VARCHAR(255) DEFAULT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (userId) REFERENCES users(userId) ON DELETE SET NULL,
  INDEX idx_audit_user (userId),
  INDEX idx_audit_action (action),
  INDEX idx_audit_table (tableName),
  INDEX idx_audit_date (createdAt)
);

/* Inserting default data */

/* Insert default categories */
INSERT INTO categories (categoryName, categoryType, description, status) VALUES
('Office Equipment', 'property', 'Office furniture and equipment', 'Active'),
('IT Equipment', 'property', 'Computers, printers, and IT devices', 'Active'),
('Furniture', 'property', 'Desks, chairs, and other furniture', 'Active'),
('Vehicles', 'property', 'Motor vehicles and transportation', 'Active'),
('Office Supplies', 'supply', 'Paper, pens, and consumable office items', 'Active'),
('Cleaning Supplies', 'supply', 'Cleaning materials and chemicals', 'Active'),
('Medical Supplies', 'supply', 'Medical equipment and supplies', 'Active');

/* Insert default departments */
INSERT INTO departments (departmentName, headOfDepartment, email, contactNumber, location, building, status) VALUES
('Administration', 'John Doe', 'admin@example.com', '123-456-7890', 'Main Building', 'Building A', 'Active'),
('IT Department', 'Jane Smith', 'it@example.com', '123-456-7891', 'Main Building', 'Building A', 'Active'),
('Finance', 'Bob Johnson', 'finance@example.com', '123-456-7892', 'Main Building', 'Building B', 'Active'),
('Human Resources', 'Alice Williams', 'hr@example.com', '123-456-7893', 'Main Building', 'Building B', 'Active'),
('Maintenance', 'Charlie Brown', 'maintenance@example.com', '123-456-7894', 'Annex Building', 'Building C', 'Active');

/* Insert default SuperAdmin user */
INSERT INTO users (firstName, lastName, username, passwordEncrypted, role, status, email) VALUES
('Super', 'Admin', 'superadmin', '$2a$11$YourHashedPasswordHere', 'SuperAdmin', 'Active', 'superadmin@example.com');

/* Insert sample system config */
INSERT INTO system_config (configKey, configValue, configType, description) VALUES
('system_name', 'Team Cruz Property Custodian Management System', 'system', 'System name'),
('organization_name', 'Team Cruz', 'system', 'Organization name'),
('db_host', 'localhost', 'connection', 'Database host'),
('db_port', '3306', 'connection', 'Database port');
