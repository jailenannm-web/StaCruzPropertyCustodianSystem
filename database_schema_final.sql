-- =====================================================
-- Sta. Cruz Property Custodian Management System
-- Complete Final Database Schema
-- Compatible with VB.NET MySQL Connector
-- Includes SUPERADMIN role and all required attributes
-- =====================================================

DROP DATABASE IF EXISTS teamcruzim;

CREATE DATABASE teamcruzim CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE teamcruzim;

-- =====================================================
-- 1. DEPARTMENTS TABLE
-- =====================================================
CREATE TABLE departments (
    department_id        INT AUTO_INCREMENT PRIMARY KEY,
    department_name      VARCHAR(100) NOT NULL UNIQUE,
    head_of_department   VARCHAR(100) NOT NULL,
    email                VARCHAR(100),
    contact_number       VARCHAR(50),
    location             VARCHAR(200) NOT NULL,
    building             VARCHAR(100),
    floor_number         VARCHAR(20),
    short_name           VARCHAR(20),
    office_code          VARCHAR(20),
    description          TEXT,
    total_properties     INT DEFAULT 0,
    total_supplies       INT DEFAULT 0,
    status               ENUM('Active', 'Inactive') DEFAULT 'Active',
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_dept_status (status),
    INDEX idx_dept_name (department_name)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 2. USERS TABLE (Admin / SuperAdmin / Custodian)
-- =====================================================
CREATE TABLE users (
    user_id              INT AUTO_INCREMENT PRIMARY KEY,
    first_name           VARCHAR(50) NOT NULL,
    middle_name          VARCHAR(50),
    last_name            VARCHAR(50) NOT NULL,
    suffix               VARCHAR(10),
    full_name            VARCHAR(255) GENERATED ALWAYS AS (
        CONCAT(
            first_name,
            IF(middle_name IS NOT NULL AND middle_name != '', CONCAT(' ', middle_name), ''),
            ' ',
            last_name,
            IF(suffix IS NOT NULL AND suffix != '', CONCAT(' ', suffix), '')
        )
    ) STORED,
    position             VARCHAR(100),
    department_id        INT,
    employee_id          VARCHAR(50) UNIQUE,
    contact_number       VARCHAR(20),
    email                VARCHAR(100) UNIQUE,
    username             VARCHAR(50) NOT NULL UNIQUE,
    password_encrypted   VARCHAR(255) NOT NULL,
    province             VARCHAR(100),
    municipal            VARCHAR(100),
    barangay             VARCHAR(100),
    role                 ENUM('SuperAdmin', 'Admin', 'Custodian', 'Staff') NOT NULL,
    status               ENUM('Active', 'Inactive') DEFAULT 'Active',
    last_login           DATETIME,
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    INDEX idx_user_role (role),
    INDEX idx_user_status (status),
    INDEX idx_user_username (username)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 3. STAFF_ACCOUNTS TABLE (For Staff role)
-- =====================================================
CREATE TABLE staff_accounts (
    staff_id             INT AUTO_INCREMENT PRIMARY KEY,
    user_id              INT UNIQUE,
    first_name           VARCHAR(50) NOT NULL,
    middle_name          VARCHAR(50),
    last_name            VARCHAR(50) NOT NULL,
    suffix               VARCHAR(10),
    full_name            VARCHAR(255) GENERATED ALWAYS AS (
        CONCAT(
            first_name,
            IF(middle_name IS NOT NULL AND middle_name != '', CONCAT(' ', middle_name), ''),
            ' ',
            last_name,
            IF(suffix IS NOT NULL AND suffix != '', CONCAT(' ', suffix), '')
        )
    ) STORED,
    position             VARCHAR(100) DEFAULT 'Staff',
    department_id        INT,
    employee_id          VARCHAR(50) UNIQUE,
    contact_number       VARCHAR(20),
    email                VARCHAR(100) UNIQUE,
    username             VARCHAR(50) NOT NULL UNIQUE,
    password_encrypted   VARCHAR(255) NOT NULL,
    province             VARCHAR(100),
    municipal            VARCHAR(100),
    barangay             VARCHAR(100),
    status               ENUM('Active', 'Inactive') DEFAULT 'Active',
    last_login           DATETIME,
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE SET NULL,
    INDEX idx_staff_status (status),
    INDEX idx_staff_username (username)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 4. PROPERTIES TABLE
-- =====================================================
CREATE TABLE properties (
    property_id          INT AUTO_INCREMENT PRIMARY KEY,
    item_name            VARCHAR(200) NOT NULL,
    category             VARCHAR(100) NOT NULL,
    description          TEXT,
    unit_of_measure      VARCHAR(50),
    property_number      VARCHAR(100) UNIQUE,
    serial_number        VARCHAR(100),
    acquisition_date     DATE NOT NULL,
    acquisition_cost     DECIMAL(15,2) NOT NULL,
    total_cost           DECIMAL(15,2),
    source_of_funds      VARCHAR(200),
    assigned_to          INT,
    department_id        INT,
    location             VARCHAR(200) NOT NULL,
    condition            ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT 'Good',
    status               ENUM('Active', 'Borrowed', 'For Disposal', 'Lost', 'Cost') DEFAULT 'Active',
    internal_codes       VARCHAR(100),
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (assigned_to) REFERENCES users(user_id) ON DELETE SET NULL,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    INDEX idx_prop_category (category),
    INDEX idx_prop_status (status),
    INDEX idx_prop_department (department_id),
    INDEX idx_prop_assigned (assigned_to),
    INDEX idx_prop_number (property_number)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 5. SUPPLIES TABLE
-- =====================================================
CREATE TABLE supplies (
    supply_id            INT AUTO_INCREMENT PRIMARY KEY,
    item_name            VARCHAR(200) NOT NULL,
    category             VARCHAR(100) NOT NULL,
    description          TEXT,
    unit_of_measure      VARCHAR(50) NOT NULL,
    quantity             INT NOT NULL DEFAULT 0,
    date_received        DATE NOT NULL,
    unit_cost            DECIMAL(15,2) NOT NULL,
    total_cost           DECIMAL(15,2),
    supplier             VARCHAR(200),
    source_of_funds      VARCHAR(200),
    location             VARCHAR(200) NOT NULL,
    stock_status         ENUM('Available', 'Low Stock', 'Out of Stock') DEFAULT 'Available',
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_supply_category (category),
    INDEX idx_supply_status (stock_status),
    INDEX idx_supply_location (location)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 6. PROPERTY REQUESTS TABLE
-- =====================================================
CREATE TABLE property_requests (
    request_id           INT AUTO_INCREMENT PRIMARY KEY,
    requester_name       VARCHAR(200) NOT NULL,
    position             VARCHAR(100),
    department_id        INT,
    date_of_request      DATE NOT NULL,
    item_name            VARCHAR(200) NOT NULL,
    description          TEXT,
    quantity_requested   INT NOT NULL DEFAULT 1,
    unit                 VARCHAR(50),
    purpose              TEXT NOT NULL,
    status               ENUM('Pending', 'Approved', 'Rejected') DEFAULT 'Pending',
    approved_by          INT,
    approved_date        DATETIME,
    remarks              TEXT,
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    FOREIGN KEY (approved_by) REFERENCES users(user_id) ON DELETE SET NULL,
    INDEX idx_prop_req_status (status),
    INDEX idx_prop_req_date (date_of_request),
    INDEX idx_prop_req_department (department_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 7. SUPPLIES REQUESTS TABLE
-- =====================================================
CREATE TABLE supplies_requests (
    request_id           INT AUTO_INCREMENT PRIMARY KEY,
    requester_name       VARCHAR(200) NOT NULL,
    position             VARCHAR(100),
    department_id        INT,
    date_of_request      DATE NOT NULL,
    item_name            VARCHAR(200) NOT NULL,
    description          TEXT,
    quantity_requested   INT NOT NULL DEFAULT 1,
    unit                 VARCHAR(50),
    purpose              TEXT NOT NULL,
    status               ENUM('Pending', 'Approved', 'Rejected') DEFAULT 'Pending',
    approved_by          INT,
    approved_date        DATETIME,
    remarks              TEXT,
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    FOREIGN KEY (approved_by) REFERENCES users(user_id) ON DELETE SET NULL,
    INDEX idx_supply_req_status (status),
    INDEX idx_supply_req_date (date_of_request),
    INDEX idx_supply_req_department (department_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 8. MAINTENANCE REQUESTS TABLE
-- =====================================================
CREATE TABLE maintenance_requests (
    request_id           INT AUTO_INCREMENT PRIMARY KEY,
    date_requested       DATE NOT NULL,
    item_name            VARCHAR(200) NOT NULL,
    property_number      VARCHAR(100),
    serial_number        VARCHAR(100),
    department_id        INT,
    location             VARCHAR(200),
    condition_before     ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT 'Good',
    type_of_issue        ENUM('Repair', 'Replace', 'Servicing') NOT NULL,
    problem_description  TEXT NOT NULL,
    status               ENUM('Pending', 'Approved', 'In Progress', 'Completed', 'Rejected') DEFAULT 'Pending',
    assigned_technician  VARCHAR(200),
    target_date          DATE,
    completion_date      DATE,
    requested_by         INT,
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    FOREIGN KEY (requested_by) REFERENCES users(user_id) ON DELETE SET NULL,
    INDEX idx_maint_req_status (status),
    INDEX idx_maint_req_date (date_requested),
    INDEX idx_maint_req_department (department_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 9. MAINTENANCE TABLE (Maintenance Work Records)
-- =====================================================
CREATE TABLE maintenance (
    maintenance_id           INT AUTO_INCREMENT PRIMARY KEY,
    request_id               INT,
    property_item_name       VARCHAR(200) NOT NULL,
    serial_number            VARCHAR(100),
    location                 VARCHAR(200),
    department_id            INT,
    condition_before_maint   ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT 'Good',
    type_of_maintenance      ENUM('Repair', 'Replace', 'Servicing') NOT NULL,
    assigned_technician      VARCHAR(200),
    maintenance_date         DATE NOT NULL,
    maintenance_details      TEXT,
    cost_materials_labor     DECIMAL(15,2) DEFAULT 0,
    condition_after_maint    ENUM('Good', 'Needs Further Repair') DEFAULT 'Good',
    status                   ENUM('Completed', 'Ongoing', 'For Review') DEFAULT 'Ongoing',
    diagnosis                TEXT,
    action_taken             TEXT,
    parts_replaced           TEXT,
    created_at               DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at               DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (request_id) REFERENCES maintenance_requests(request_id) ON DELETE SET NULL,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    INDEX idx_maint_status (status),
    INDEX idx_maint_date (maintenance_date),
    INDEX idx_maint_technician (assigned_technician)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 10. CUSTODIAN TABLE (Custodian Assignments)
-- =====================================================
CREATE TABLE custodian (
    custodian_id            INT AUTO_INCREMENT PRIMARY KEY,
    user_id                 INT NOT NULL,
    department_id           INT,
    item_id                 INT,
    item_name               VARCHAR(200),
    serial_number           VARCHAR(100),
    property_number         VARCHAR(100),
    date_assigned           DATE NOT NULL,
    location                VARCHAR(200),
    condition_before        ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT 'Good',
    purpose_of_assignment   TEXT,
    type_of_issuance        ENUM('ICS', 'PAR', 'Borrowed') DEFAULT 'Borrowed',
    remarks                 TEXT,
    status                  ENUM('Active', 'Returned', 'Reassigned') DEFAULT 'Active',
    created_at              DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at              DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    INDEX idx_custodian_user (user_id),
    INDEX idx_custodian_status (status),
    INDEX idx_custodian_date (date_assigned)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 11. BORROWED ITEMS TABLE
-- =====================================================
CREATE TABLE borrowed_items (
    borrow_id               INT AUTO_INCREMENT PRIMARY KEY,
    property_number         VARCHAR(100),
    item_name               VARCHAR(200) NOT NULL,
    description             TEXT,
    quantity                INT NOT NULL DEFAULT 1,
    borrow_date             DATE NOT NULL,
    due_date                DATE,
    condition_before        ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT 'Good',
    status                  ENUM('Borrowed', 'Returned', 'Overdue') DEFAULT 'Borrowed',
    return_date             DATE,
    condition_upon_return   ENUM('Good', 'Damaged', 'Lost') DEFAULT 'Good',
    borrowed_by             INT,
    approved_by             INT,
    remarks                 TEXT,
    created_at              DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at              DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (borrowed_by) REFERENCES users(user_id) ON DELETE SET NULL,
    FOREIGN KEY (approved_by) REFERENCES users(user_id) ON DELETE SET NULL,
    INDEX idx_borrow_status (status),
    INDEX idx_borrow_date (borrow_date),
    INDEX idx_borrow_user (borrowed_by)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 12. AUDIT LOGS TABLE
-- =====================================================
CREATE TABLE audit_logs (
    log_id              INT AUTO_INCREMENT PRIMARY KEY,
    user_id             INT,
    user_type           ENUM('SuperAdmin', 'Admin', 'Custodian', 'Staff') NOT NULL,
    username            VARCHAR(50) NOT NULL,
    action              VARCHAR(100) NOT NULL,
    module              VARCHAR(50) NOT NULL,
    description         TEXT,
    ip_address          VARCHAR(45),
    created_at          DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE SET NULL,
    INDEX idx_audit_user (user_id),
    INDEX idx_audit_date (created_at),
    INDEX idx_audit_action (action)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 13. SYSTEM CONFIGURATION TABLE
-- =====================================================
CREATE TABLE system_config (
    config_id           INT AUTO_INCREMENT PRIMARY KEY,
    config_key          VARCHAR(100) NOT NULL UNIQUE,
    config_value        TEXT,
    config_type         VARCHAR(50),
    description         TEXT,
    updated_by          INT,
    updated_at          DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (updated_by) REFERENCES users(user_id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 14. CATEGORIES TABLE
-- =====================================================
CREATE TABLE categories (
    category_id         INT AUTO_INCREMENT PRIMARY KEY,
    category_name       VARCHAR(100) NOT NULL UNIQUE,
    category_type       ENUM('property', 'supply') NOT NULL,
    description         TEXT,
    status              ENUM('Active', 'Inactive') DEFAULT 'Active',
    created_at          DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- TRIGGERS: Update Department Totals
-- =====================================================
DELIMITER $$

CREATE TRIGGER trg_update_dept_property_count 
AFTER INSERT ON properties
FOR EACH ROW
BEGIN
    IF NEW.department_id IS NOT NULL THEN
        UPDATE departments 
        SET total_properties = (
            SELECT COUNT(*) 
            FROM properties 
            WHERE department_id = NEW.department_id AND status = 'Active'
        )
        WHERE department_id = NEW.department_id;
    END IF;
END$$

CREATE TRIGGER trg_update_dept_supply_count 
AFTER INSERT ON supplies
FOR EACH ROW
BEGIN
    UPDATE departments 
    SET total_supplies = (
        SELECT SUM(quantity) 
        FROM supplies 
        WHERE stock_status = 'Available'
    );
END$$

DELIMITER ;

-- =====================================================
-- INITIAL DATA: Default SuperAdmin Account
-- =====================================================
INSERT INTO users (
    first_name, last_name, username, password_encrypted, 
    role, status, email, employee_id
) VALUES (
    'Super', 'Admin', 'superadmin', 
    '$2a$11$YourHashedPasswordHere',
    'SuperAdmin', 'Active', 'superadmin@stacruz.edu', 'SA001'
);

-- Insert default Admin account
INSERT INTO users (
    first_name, last_name, username, password_encrypted, 
    role, status, email, employee_id
) VALUES (
    'Admin', 'User', 'admin', 
    '$2a$11$YourHashedPasswordHere',
    'Admin', 'Active', 'admin@stacruz.edu', 'AD001'
);

-- Insert sample departments
INSERT INTO departments (
    department_name, head_of_department, email, contact_number, 
    location, building, floor_number, short_name, office_code, 
    description, status
) VALUES
('Information Technology', 'John Smith', 'it@stacruz.edu', '09123456789', 
 'Building A, Room 201', 'Building A', '2', 'IT', 'IT-001', 
 'Information Technology Department', 'Active'),
('Human Resources', 'Maria Garcia', 'hr@stacruz.edu', '09123456790', 
 'Building B, Room 101', 'Building B', '1', 'HR', 'HR-001', 
 'Human Resources Department', 'Active'),
('Finance', 'Robert Johnson', 'finance@stacruz.edu', '09123456791', 
 'Building A, Room 301', 'Building A', '3', 'FIN', 'FIN-001', 
 'Finance Department', 'Active'),
('Administration', 'Sarah Williams', 'admin@stacruz.edu', '09123456792', 
 'Building C, Room 101', 'Building C', '1', 'ADMIN', 'ADMIN-001', 
 'Administration Department', 'Active');

-- Insert default categories
INSERT INTO categories (category_name, category_type, description) VALUES
('Furniture', 'property', 'School furniture items'),
('Equipment', 'property', 'School equipment'),
('Office Supplies', 'supply', 'Consumable office materials'),
('IT Equipment', 'property', 'Computers and IT devices'),
('Stationery', 'supply', 'Writing & paper supplies'),
('Electronics', 'property', 'Electronic devices'),
('Laboratory Apparatus', 'property', 'Lab equipment'),
('Books and Publications', 'property', 'Books and reading materials'),
('Building and Fixtures', 'property', 'Building fixtures'),
('Vehicles', 'property', 'School vehicles'),
('Tools and Instruments', 'property', 'Tools and instruments'),
('Others', 'property', 'Other items');

-- Insert system configuration
INSERT INTO system_config (config_key, config_value, config_type, description) VALUES
('school_name', 'Sta. Cruz Elementary School', 'text', 'Name of the school'),
('school_address', 'Sta. Cruz, Philippines', 'text', 'School address'),
('penalty_rate_per_day', '50.00', 'decimal', 'Penalty for late returns'),
('max_borrowing_days', '30', 'integer', 'Maximum borrowing days'),
('system_version', '1.0.0', 'text', 'System version'),
('low_stock_threshold', '10', 'integer', 'Threshold for low stock alert');

-- =====================================================
-- END OF SCHEMA
-- =====================================================

