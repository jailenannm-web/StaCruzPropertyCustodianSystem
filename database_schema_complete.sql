-- =====================================================
-- Sta. Cruz Elementary School Property Custodian Management System
-- Complete Database Schema Based on Project Proposal
-- =====================================================

CREATE DATABASE IF NOT EXISTS teamcruzim;
USE teamcruzim;

-- =====================================================
-- 1. DEPARTMENT TABLE (Table 20 from Data Dictionary)
-- =====================================================
CREATE TABLE IF NOT EXISTS departments (
    department_id INT(10) PRIMARY KEY AUTO_INCREMENT,
    department_name VARCHAR(100) NOT NULL UNIQUE,
    head_of_department VARCHAR(100) NOT NULL,
    contact_number VARCHAR(50),
    email VARCHAR(100),
    location VARCHAR(100) NOT NULL,
    no_of_employees INT(10) DEFAULT 0,
    department_code VARCHAR(20) NOT NULL UNIQUE,
    office_hours VARCHAR(50),
    established_date DATE,
    parent_department_id INT(10),
    status ENUM('active', 'inactive') NOT NULL DEFAULT 'active',
    budget_allocation DECIMAL(12,2) DEFAULT 0.00,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (parent_department_id) REFERENCES departments(department_id) ON DELETE SET NULL
);

-- =====================================================
-- 2. CUSTODIAN/USERS TABLE (Table 19 from Data Dictionary)
-- =====================================================
CREATE TABLE IF NOT EXISTS users (
    user_id INT(10) PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(50) NOT NULL,
    middle_name VARCHAR(50),
    last_name VARCHAR(50) NOT NULL,
    suffix ENUM('JR.', 'SR.', 'III', 'II', 'IV') NULL,
    position VARCHAR(100) NOT NULL,
    department_id INT(10),
    contact_number VARCHAR(20),
    email VARCHAR(100) UNIQUE,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_encrypted VARCHAR(255) NOT NULL,
    house_no_street VARCHAR(100),
    barangay VARCHAR(100),
    municipality VARCHAR(100),
    province_city VARCHAR(100),
    date_assigned DATE NOT NULL,
    employee_id VARCHAR(50) NOT NULL UNIQUE,
    user_type ENUM('Admin', 'SuperAdmin') NOT NULL,
    status ENUM('active', 'inactive') NOT NULL DEFAULT 'active',
    last_login DATETIME,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL
);

-- =====================================================
-- 3. STAFF ACCOUNTS TABLE
-- =====================================================
CREATE TABLE IF NOT EXISTS staff_accounts (
    staff_id INT(10) PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(50) NOT NULL,
    middle_name VARCHAR(50),
    last_name VARCHAR(50) NOT NULL,
    suffix ENUM('JR.', 'SR.', 'III', 'II', 'IV') NULL,
    position VARCHAR(100) DEFAULT 'Staff',
    department_id INT(10),
    contact_number VARCHAR(20),
    email VARCHAR(100) UNIQUE,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_encrypted VARCHAR(255) NOT NULL,
    house_no_street VARCHAR(100),
    barangay VARCHAR(100),
    municipality VARCHAR(100),
    province_city VARCHAR(100),
    date_assigned DATE NOT NULL,
    employee_id VARCHAR(50) UNIQUE,
    status ENUM('active', 'inactive') NOT NULL DEFAULT 'active',
    last_login DATETIME,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL
);

-- =====================================================
-- 4. PROPERTY TABLE (Table 18 from Data Dictionary)
-- =====================================================
CREATE TABLE IF NOT EXISTS properties (
    property_id INT(10) PRIMARY KEY AUTO_INCREMENT,
    property_name VARCHAR(100) NOT NULL,
    category ENUM('Furniture', 'Equipment', 'Office Supplies', 'IT Equipment', 
                  'Laboratory Apparatus', 'Books and Publications', 
                  'Building and Fixtures', 'Vehicles', 'Tools and Instruments', 'Others') NOT NULL,
    description TEXT,
    serial_number VARCHAR(100),
    acquisition_date DATE NOT NULL,
    acquisition_cost DECIMAL(10,2) NOT NULL,
    supplier_name VARCHAR(100) NOT NULL,
    supplier_contact VARCHAR(100),
    condition_status ENUM('good', 'needs repair', 'damaged') NOT NULL DEFAULT 'good',
    location VARCHAR(100) NOT NULL,
    custodian_id INT(10),
    department_id INT(10),
    warranty_details VARCHAR(100),
    life_span INT(10),
    depreciation_value DECIMAL(10,2),
    disposal_date DATE,
    disposal_value DECIMAL(10,2),
    status ENUM('active', 'disposed', 'lost', 'damaged') NOT NULL DEFAULT 'active',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (custodian_id) REFERENCES users(user_id) ON DELETE SET NULL,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL
);

-- =====================================================
-- 5. SUPPLIES TABLE (Table 15 from Data Dictionary)
-- =====================================================
CREATE TABLE IF NOT EXISTS supplies (
    supply_id INT(10) PRIMARY KEY AUTO_INCREMENT,
    supply_name VARCHAR(100) NOT NULL,
    category VARCHAR(50) NOT NULL,
    description TEXT,
    unit_of_measure ENUM('pieces', 'box', 'liters', 'ream', 'grams', 'sacks') NULL,
    quantity_in_stock INT(10) NOT NULL DEFAULT 0,
    reorder_level INT(10) NOT NULL DEFAULT 0,
    supplier_name VARCHAR(100) NOT NULL,
    supplier_contact VARCHAR(100),
    unit_cost DECIMAL(10,2) NOT NULL,
    total_value DECIMAL(10,2) GENERATED ALWAYS AS (quantity_in_stock * unit_cost) STORED,
    acquisition_date DATE NOT NULL,
    expiration_date DATE,
    location VARCHAR(100) NOT NULL,
    custodian_id INT(10),
    department_id INT(10),
    status ENUM('active', 'used', 'leave') NOT NULL DEFAULT 'active',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (custodian_id) REFERENCES users(user_id) ON DELETE SET NULL,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL
);

-- =====================================================
-- 6. PROPERTY REQUEST TABLE (Table 16 from Data Dictionary)
-- =====================================================
CREATE TABLE IF NOT EXISTS property_requests (
    request_id INT(10) PRIMARY KEY AUTO_INCREMENT,
    user_id INT(10) NOT NULL,
    property_id INT(10),
    supply_id INT(10),
    request_type ENUM('property', 'supply') NOT NULL,
    request_date DATE NOT NULL,
    purpose TEXT NOT NULL,
    quantity INT(10) NOT NULL DEFAULT 1,
    status ENUM('pending', 'approved', 'rejected', 'returned', 'released') NOT NULL DEFAULT 'pending',
    approved_by INT(10),
    approval_date DATE,
    release_date DATE,
    expected_return_date DATE,
    actual_returned_date DATE,
    remarks TEXT,
    penalty DECIMAL(10,2) DEFAULT 0.00,
    condition_upon_return ENUM('good', 'damaged', 'lost', 'destroyed'),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES staff_accounts(staff_id) ON DELETE CASCADE,
    FOREIGN KEY (property_id) REFERENCES properties(property_id) ON DELETE SET NULL,
    FOREIGN KEY (supply_id) REFERENCES supplies(supply_id) ON DELETE SET NULL,
    FOREIGN KEY (approved_by) REFERENCES users(user_id) ON DELETE SET NULL
);

-- =====================================================
-- 7. MAINTENANCE TABLE (Table 17 from Data Dictionary)
-- =====================================================
CREATE TABLE IF NOT EXISTS maintenance (
    maintenance_id INT(10) PRIMARY KEY AUTO_INCREMENT,
    property_id INT(10) NOT NULL,
    custodian_id INT(10),
    service_date DATE NOT NULL,
    service_type ENUM('repair', 'cleaning', 'inspection', 'calibration', 'upgrade') NOT NULL,
    description TEXT,
    service_provider VARCHAR(100),
    provider_contact VARCHAR(100),
    cost DECIMAL(10,2) DEFAULT 0.00,
    next_schedule DATE,
    warranty_status ENUM('active', 'expired') DEFAULT 'expired',
    technician_assigned VARCHAR(100),
    status ENUM('ongoing', 'completed', 'pending', 'cancelled') NOT NULL DEFAULT 'pending',
    remarks TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (property_id) REFERENCES properties(property_id) ON DELETE CASCADE,
    FOREIGN KEY (custodian_id) REFERENCES users(user_id) ON DELETE SET NULL
);

-- =====================================================
-- 8. AUDIT LOGS TABLE
-- =====================================================
CREATE TABLE IF NOT EXISTS audit_logs (
    log_id INT(10) PRIMARY KEY AUTO_INCREMENT,
    user_id INT(10),
    user_type ENUM('Admin', 'SuperAdmin', 'Staff') NOT NULL,
    username VARCHAR(50) NOT NULL,
    action VARCHAR(100) NOT NULL,
    module VARCHAR(50) NOT NULL,
    description TEXT,
    ip_address VARCHAR(45),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE SET NULL
);

-- =====================================================
-- 9. SYSTEM CONFIGURATION TABLE
-- =====================================================
CREATE TABLE IF NOT EXISTS system_config (
    config_id INT(10) PRIMARY KEY AUTO_INCREMENT,
    config_key VARCHAR(100) NOT NULL UNIQUE,
    config_value TEXT,
    config_type VARCHAR(50),
    description TEXT,
    updated_by INT(10),
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (updated_by) REFERENCES users(user_id) ON DELETE SET NULL
);

-- =====================================================
-- 10. CATEGORIES TABLE (For System Configuration)
-- =====================================================
CREATE TABLE IF NOT EXISTS categories (
    category_id INT(10) PRIMARY KEY AUTO_INCREMENT,
    category_name VARCHAR(100) NOT NULL UNIQUE,
    category_type ENUM('property', 'supply') NOT NULL,
    description TEXT,
    status ENUM('active', 'inactive') NOT NULL DEFAULT 'active',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- =====================================================
-- SAMPLE DATA INSERTION
-- =====================================================

-- Insert sample departments
INSERT INTO departments (department_name, head_of_department, location, department_code, status) VALUES
('Administration', 'Dr. Maria Santos', 'Main Building, 2nd Floor', 'ADMIN', 'active'),
('Academic Affairs', 'Dr. Juan Dela Cruz', 'Main Building, 3rd Floor', 'ACAD', 'active'),
('Finance and Accounting', 'Ms. Anna Garcia', 'Main Building, 1st Floor', 'FIN', 'active'),
('Information Technology', 'Mr. Carlos Rodriguez', 'IT Building', 'IT', 'active'),
('Maintenance', 'Mr. Pedro Martinez', 'Maintenance Office', 'MAINT', 'active');

-- Insert sample categories
INSERT INTO categories (category_name, category_type, description) VALUES
('Furniture', 'property', 'School furniture items'),
('Equipment', 'property', 'School equipment'),
('Office Supplies', 'supply', 'Consumable office materials'),
('IT Equipment', 'property', 'Computers and IT devices'),
('Stationery', 'supply', 'Writing and paper supplies'),
('Electronics', 'property', 'Electronic devices');

-- Insert default system configuration
INSERT INTO system_config (config_key, config_value, config_type, description) VALUES
('school_name', 'Sta. Cruz Elementary School', 'text', 'Name of the school'),
('school_address', 'Sta. Cruz, Philippines', 'text', 'School address'),
('penalty_rate_per_day', '50.00', 'decimal', 'Penalty rate for late returns per day'),
('max_borrowing_days', '30', 'integer', 'Maximum days for borrowing'),
('system_version', '1.0.0', 'text', 'System version');

-- =====================================================
-- INDEXES FOR PERFORMANCE
-- =====================================================
CREATE INDEX idx_property_category ON properties(category);
CREATE INDEX idx_property_status ON properties(status);
CREATE INDEX idx_property_custodian ON properties(custodian_id);
CREATE INDEX idx_supply_category ON supplies(category);
CREATE INDEX idx_supply_status ON supplies(status);
CREATE INDEX idx_request_status ON property_requests(status);
CREATE INDEX idx_request_user ON property_requests(user_id);
CREATE INDEX idx_maintenance_property ON maintenance(property_id);
CREATE INDEX idx_audit_user ON audit_logs(user_id);
CREATE INDEX idx_audit_date ON audit_logs(created_at);

-- =====================================================
-- END OF SCHEMA
-- =====================================================

