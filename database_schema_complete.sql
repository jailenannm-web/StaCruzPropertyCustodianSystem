-- =====================================================
-- Sta. Cruz Property Custodian Management System
-- Complete Database Schema
-- =====================================================

DROP DATABASE IF EXISTS teamcruzim;

CREATE DATABASE teamcruzim CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE teamcruzim;

-- =====================================================
-- 1. DEPARTMENTS TABLE (15 attributes as required)
-- =====================================================
CREATE TABLE departments (
    department_id        INT AUTO_INCREMENT PRIMARY KEY,
    department_name      VARCHAR(100) NOT NULL UNIQUE,
    head_of_department   VARCHAR(100) NOT NULL,
    contact_number       VARCHAR(50),
    email                VARCHAR(100),
    location             VARCHAR(100) NOT NULL,
    no_of_employees      INT DEFAULT 0,
    department_code      VARCHAR(20) NOT NULL UNIQUE,
    office_hours         VARCHAR(50),
    established_date     DATE,
    parent_department_id INT,
    status               ENUM('active','inactive') DEFAULT 'active',
    budget_allocation    DECIMAL(12,2) DEFAULT 0,
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT fk_dept_parent FOREIGN KEY (parent_department_id)
        REFERENCES departments(department_id) ON DELETE SET NULL
);

-- =====================================================
-- 2. USERS TABLE (Admins / SuperAdmins)
-- =====================================================
CREATE TABLE users (
    user_id            INT AUTO_INCREMENT PRIMARY KEY,
    first_name         VARCHAR(50) NOT NULL,
    middle_name        VARCHAR(50),
    last_name          VARCHAR(50) NOT NULL,
    suffix             ENUM('JR.','SR.','III','II','IV'),
    position           VARCHAR(100) NOT NULL,
    department_id      INT,
    contact_number     VARCHAR(20),
    email              VARCHAR(100) UNIQUE,
    username           VARCHAR(50) NOT NULL UNIQUE,
    password_encrypted VARCHAR(255) NOT NULL,
    house_no_street    VARCHAR(100),
    barangay           VARCHAR(100),
    municipality       VARCHAR(100),
    province_city      VARCHAR(100),
    date_assigned      DATE NOT NULL,
    employee_id        VARCHAR(50) NOT NULL UNIQUE,
    user_type          ENUM('Admin','SuperAdmin') NOT NULL,
    status             ENUM('active','inactive') DEFAULT 'active',
    last_login         DATETIME,
    created_at         DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL
);

-- =====================================================
-- 3. STAFF ACCOUNTS TABLE
-- =====================================================
CREATE TABLE staff_accounts (
    staff_id           INT AUTO_INCREMENT PRIMARY KEY,
    first_name         VARCHAR(50) NOT NULL,
    middle_name        VARCHAR(50),
    last_name          VARCHAR(50) NOT NULL,
    suffix             ENUM('JR.','SR.','III','II','IV'),
    position           VARCHAR(100) DEFAULT 'Staff',
    department_id      INT,
    contact_number     VARCHAR(20),
    email              VARCHAR(100) UNIQUE,
    username           VARCHAR(50) NOT NULL UNIQUE,
    password_encrypted VARCHAR(255) NOT NULL,
    house_no_street    VARCHAR(100),
    barangay           VARCHAR(100),
    municipality       VARCHAR(100),
    province_city      VARCHAR(100),
    date_assigned      DATE NOT NULL,
    employee_id        VARCHAR(50) UNIQUE,
    status             ENUM('active','inactive') DEFAULT 'active',
    last_login         DATETIME,
    created_at         DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL
);

-- =====================================================
-- 4. PROPERTIES TABLE
-- =====================================================
CREATE TABLE properties (
    property_id        INT AUTO_INCREMENT PRIMARY KEY,
    property_name      VARCHAR(100) NOT NULL,
    category           ENUM('Furniture','Equipment','Office Supplies','IT Equipment',
                             'Laboratory Apparatus','Books and Publications',
                             'Building and Fixtures','Vehicles','Tools and Instruments','Others') NOT NULL,
    description        TEXT,
    serial_number      VARCHAR(100),
    acquisition_date   DATE NOT NULL,
    acquisition_cost   DECIMAL(10,2) NOT NULL,
    supplier_name      VARCHAR(100) NOT NULL,
    supplier_contact   VARCHAR(100),
    condition_status   ENUM('good','needs repair','damaged') DEFAULT 'good',
    location           VARCHAR(100) NOT NULL,
    custodian_id       INT,
    department_id      INT,
    warranty_details   VARCHAR(100),
    life_span          INT,
    depreciation_value DECIMAL(10,2),
    disposal_date      DATE,
    disposal_value     DECIMAL(10,2),
    status             ENUM('active','disposed','lost','damaged') DEFAULT 'active',
    created_at         DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at         DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (custodian_id) REFERENCES users(user_id) ON DELETE SET NULL,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL
);

-- =====================================================
-- 5. SUPPLIES TABLE (Fixed: supply_id as VARCHAR for string IDs)
-- =====================================================
CREATE TABLE supplies (
    supply_id          VARCHAR(50) PRIMARY KEY,  -- Changed to VARCHAR to support 'SUP001' format
    supply_name        VARCHAR(100) NOT NULL,
    category           VARCHAR(50) NOT NULL,
    description        TEXT,
    unit_of_measure    VARCHAR(50),  -- Changed from ENUM to VARCHAR for flexibility
    quantity_in_stock  INT NOT NULL DEFAULT 0,
    reorder_level      INT NOT NULL DEFAULT 0,
    supplier_name      VARCHAR(100) NOT NULL,
    supplier_contact   VARCHAR(100),
    unit_cost          DECIMAL(10,2) NOT NULL,
    total_value        DECIMAL(10,2) GENERATED ALWAYS AS (quantity_in_stock * unit_cost) STORED,
    acquisition_date   DATE NOT NULL,
    expiration_date    DATE,
    location           VARCHAR(100) NOT NULL,
    custodian_id       INT,
    department_id      INT,
    status             ENUM('active','inactive','low_stock','out_of_stock','used') DEFAULT 'active',
    created_at         DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at         DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (custodian_id) REFERENCES users(user_id) ON DELETE SET NULL,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL
);

-- =====================================================
-- 6. PROPERTY REQUESTS TABLE
-- =====================================================
CREATE TABLE property_requests (
    request_id           INT AUTO_INCREMENT PRIMARY KEY,
    user_id              INT NOT NULL,
    property_id          INT,
    supply_id            VARCHAR(50),  -- Changed to VARCHAR to match supplies.supply_id
    request_type         ENUM('property','supply') NOT NULL,
    request_date         DATE NOT NULL,
    purpose              TEXT NOT NULL,
    quantity             INT NOT NULL DEFAULT 1,
    status               ENUM('pending','approved','rejected','returned','released') DEFAULT 'pending',
    approved_by          INT,
    approval_date        DATE,
    release_date         DATE,
    expected_return_date DATE,
    actual_returned_date DATE,
    remarks              TEXT,
    penalty              DECIMAL(10,2) DEFAULT 0,
    condition_upon_return ENUM('good','damaged','lost','destroyed'),
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES staff_accounts(staff_id) ON DELETE CASCADE,
    FOREIGN KEY (property_id) REFERENCES properties(property_id) ON DELETE SET NULL,
    FOREIGN KEY (supply_id) REFERENCES supplies(supply_id) ON DELETE SET NULL,
    FOREIGN KEY (approved_by) REFERENCES users(user_id) ON DELETE SET NULL
);

-- =====================================================
-- 7. MAINTENANCE TABLE
-- =====================================================
CREATE TABLE maintenance (
    maintenance_id   INT AUTO_INCREMENT PRIMARY KEY,
    property_id      INT NOT NULL,
    custodian_id     INT,
    service_date     DATE NOT NULL,
    service_type     ENUM('repair','cleaning','inspection','calibration','upgrade') NOT NULL,
    description      TEXT,
    service_provider VARCHAR(100),
    provider_contact VARCHAR(100),
    cost             DECIMAL(10,2) DEFAULT 0,
    next_schedule    DATE,
    warranty_status  ENUM('active','expired') DEFAULT 'expired',
    technician_assigned VARCHAR(100),
    status           ENUM('ongoing','completed','pending','cancelled') DEFAULT 'pending',
    remarks          TEXT,
    created_at       DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at       DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (property_id) REFERENCES properties(property_id) ON DELETE CASCADE,
    FOREIGN KEY (custodian_id) REFERENCES users(user_id) ON DELETE SET NULL
);

-- =====================================================
-- 8. AUDIT LOGS TABLE
-- =====================================================
CREATE TABLE audit_logs (
    log_id     INT AUTO_INCREMENT PRIMARY KEY,
    user_id    INT,
    user_type  ENUM('Admin','SuperAdmin','Staff') NOT NULL,
    username   VARCHAR(50) NOT NULL,
    action     VARCHAR(100) NOT NULL,
    module     VARCHAR(50) NOT NULL,
    description TEXT,
    ip_address VARCHAR(45),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE SET NULL
);

-- =====================================================
-- 9. SYSTEM CONFIGURATION TABLE
-- =====================================================
CREATE TABLE system_config (
    config_id    INT AUTO_INCREMENT PRIMARY KEY,
    config_key   VARCHAR(100) NOT NULL UNIQUE,
    config_value TEXT,
    config_type  VARCHAR(50),
    description  TEXT,
    updated_by   INT,
    updated_at   DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (updated_by) REFERENCES users(user_id) ON DELETE SET NULL
);

-- =====================================================
-- 10. CATEGORIES TABLE
-- =====================================================
CREATE TABLE categories (
    category_id   INT AUTO_INCREMENT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL UNIQUE,
    category_type ENUM('property','supply') NOT NULL,
    description   TEXT,
    status        ENUM('active','inactive') DEFAULT 'active',
    created_at    DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- =====================================================
-- INDEXES FOR PERFORMANCE
-- =====================================================
CREATE INDEX idx_property_category ON properties(category);
CREATE INDEX idx_property_status   ON properties(status);
CREATE INDEX idx_property_custodian ON properties(custodian_id);
CREATE INDEX idx_property_department ON properties(department_id);
CREATE INDEX idx_supply_category   ON supplies(category);
CREATE INDEX idx_supply_status     ON supplies(status);
CREATE INDEX idx_request_status    ON property_requests(status);
CREATE INDEX idx_request_user      ON property_requests(user_id);
CREATE INDEX idx_maintenance_property ON maintenance(property_id);
CREATE INDEX idx_audit_user        ON audit_logs(user_id);
CREATE INDEX idx_audit_date        ON audit_logs(created_at);
CREATE INDEX idx_department_status ON departments(status);
CREATE INDEX idx_department_code   ON departments(department_code);

-- =====================================================
-- SEED DATA
-- =====================================================

-- Departments
INSERT INTO departments (department_name, head_of_department, contact_number, email, location, 
                        no_of_employees, department_code, office_hours, established_date, 
                        parent_department_id, status, budget_allocation, created_at, updated_at)
VALUES
('Information Technology', 'John Smith', '09123456789', 'it@stacruz.edu', 'Building A, 2nd Floor', 
 15, 'IT', '8:00 AM - 5:00 PM', '2020-01-15', NULL, 'active', 500000.00, NOW(), NOW()),

('Human Resources', 'Maria Garcia', '09123456790', 'hr@stacruz.edu', 'Building B, 1st Floor', 
 8, 'HR', '8:00 AM - 5:00 PM', '2019-03-20', NULL, 'active', 300000.00, NOW(), NOW()),

('Finance', 'Robert Johnson', '09123456791', 'finance@stacruz.edu', 'Building A, 3rd Floor', 
 12, 'FIN', '8:00 AM - 5:00 PM', '2018-06-10', NULL, 'active', 800000.00, NOW(), NOW()),

('Administration', 'Sarah Williams', '09123456792', 'admin@stacruz.edu', 'Building C, 1st Floor', 
 20, 'ADMIN', '7:00 AM - 6:00 PM', '2017-01-05', NULL, 'active', 1000000.00, NOW(), NOW()),

('Maintenance', 'Michael Brown', '09123456793', 'maintenance@stacruz.edu', 'Building D, Ground Floor', 
 10, 'MAINT', '7:00 AM - 4:00 PM', '2019-08-15', NULL, 'active', 400000.00, NOW(), NOW()),

('Library', 'Emily Davis', '09123456794', 'library@stacruz.edu', 'Building E, 2nd Floor', 
 6, 'LIB', '7:00 AM - 7:00 PM', '2018-02-28', NULL, 'active', 250000.00, NOW(), NOW()),

('Security', 'David Martinez', '09123456795', 'security@stacruz.edu', 'Building A, Ground Floor', 
 18, 'SEC', '24/7', '2017-05-12', NULL, 'active', 600000.00, NOW(), NOW());

-- Categories
INSERT INTO categories (category_name, category_type, description)
VALUES 
('Furniture','property','School furniture items'),
('Equipment','property','School equipment'),
('Office Supplies','supply','Consumable office materials'),
('IT Equipment','property','Computers and IT devices'),
('Stationery','supply','Writing & paper supplies'),
('Electronics','property','Electronic devices'),
('Laboratory Apparatus','property','Lab equipment'),
('Books and Publications','property','Books and reading materials'),
('Building and Fixtures','property','Building fixtures'),
('Vehicles','property','School vehicles'),
('Tools and Instruments','property','Tools and instruments'),
('Others','property','Other items');

-- System Configuration
INSERT INTO system_config (config_key, config_value, config_type, description)
VALUES 
('school_name','Sta. Cruz Elementary School','text','Name of the school'),
('school_address','Sta. Cruz, Philippines','text','School address'),
('penalty_rate_per_day','50.00','decimal','Penalty for late returns'),
('max_borrowing_days','30','integer','Maximum borrowing days'),
('system_version','1.0.0','text','System version');

-- =====================================================
-- END OF SCHEMA
-- =====================================================
