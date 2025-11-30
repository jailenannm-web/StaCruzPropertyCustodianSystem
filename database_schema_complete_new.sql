-- =====================================================
-- Sta. Cruz Property Custodian Management System
-- Complete Database Schema - Fixed for MySQL
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
    no_of_employees      INT DEFAULT 0,
    budget_allocation    DECIMAL(15,2) DEFAULT 0,
    office_hours         VARCHAR(50),
    established_date     DATE,
    parent_department_id INT,
    total_properties     INT DEFAULT 0,
    total_supplies       INT DEFAULT 0,
    status               ENUM('Active', 'Inactive') DEFAULT 'Active',
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_dept_status (status),
    INDEX idx_dept_name (department_name),
    FOREIGN KEY (parent_department_id) REFERENCES departments(department_id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 2. USERS TABLE
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
    date_assigned        DATE,
    role                 ENUM('SuperAdmin', 'Admin', 'Custodian', 'Staff') NOT NULL,
    status               ENUM('Active', 'Inactive') DEFAULT 'Active',
    last_login           DATETIME,
    created_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at           DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    INDEX idx_user_role (role),
    INDEX idx_user_status (status),
    INDEX idx_user_username (username),
    INDEX idx_user_department (department_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 3. PROPERTIES TABLE
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
    `condition`          ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT 'Good',
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
-- 4. SUPPLIES TABLE
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
-- 5. MAINTENANCE TABLE
-- =====================================================
CREATE TABLE maintenance (
    maintenance_id           INT AUTO_INCREMENT PRIMARY KEY,
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
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    INDEX idx_maint_status (status),
    INDEX idx_maint_date (maintenance_date),
    INDEX idx_maint_technician (assigned_technician),
    INDEX idx_maint_department (department_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 6. CUSTODIANS TABLE
-- =====================================================
CREATE TABLE custodians (
    custodian_id            INT AUTO_INCREMENT PRIMARY KEY,
    user_id                 INT NOT NULL,
    department_id           INT,
    assigned_property_count INT DEFAULT 0,
    assigned_supply_count   INT DEFAULT 0,
    specialization          VARCHAR(200),
    certification           VARCHAR(200),
    date_assigned           DATE,
    status                  ENUM('Active', 'Inactive') DEFAULT 'Active',
    created_at              DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at              DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    UNIQUE KEY unique_custodian_user (user_id),
    INDEX idx_custodian_status (status),
    INDEX idx_custodian_department (department_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 7. PROPERTY_REQUESTS TABLE
-- =====================================================
CREATE TABLE property_requests (
    request_id          INT AUTO_INCREMENT PRIMARY KEY,
    requester_name      VARCHAR(200) NOT NULL,
    department_id       INT,
    date_of_request     DATE NOT NULL,
    item_name           VARCHAR(200) NOT NULL,
    quantity_requested INT NOT NULL DEFAULT 1,
    purpose             TEXT,
    status              ENUM('Pending', 'Approved', 'Rejected') DEFAULT 'Pending',
    approved_by         INT,
    approved_date       DATE,
    remarks             TEXT,
    created_at          DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at          DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    FOREIGN KEY (approved_by) REFERENCES users(user_id) ON DELETE SET NULL,
    INDEX idx_prop_req_status (status),
    INDEX idx_prop_req_date (date_of_request),
    INDEX idx_prop_req_department (department_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 8. SUPPLIES_REQUESTS TABLE
-- =====================================================
CREATE TABLE supplies_requests (
    request_id          INT AUTO_INCREMENT PRIMARY KEY,
    requester_name      VARCHAR(200) NOT NULL,
    department_id       INT,
    date_of_request     DATE NOT NULL,
    item_name           VARCHAR(200) NOT NULL,
    quantity_requested INT NOT NULL DEFAULT 1,
    purpose             TEXT,
    status              ENUM('Pending', 'Approved', 'Rejected') DEFAULT 'Pending',
    approved_by         INT,
    approved_date       DATE,
    remarks             TEXT,
    created_at          DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at          DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    FOREIGN KEY (approved_by) REFERENCES users(user_id) ON DELETE SET NULL,
    INDEX idx_supply_req_status (status),
    INDEX idx_supply_req_date (date_of_request),
    INDEX idx_supply_req_department (department_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- 9. MAINTENANCE_REQUESTS TABLE
-- =====================================================
CREATE TABLE maintenance_requests (
    request_id          INT AUTO_INCREMENT PRIMARY KEY,
    date_requested      DATE NOT NULL,
    item_name           VARCHAR(200) NOT NULL,
    property_number     VARCHAR(100),
    serial_number       VARCHAR(100),
    department_id       INT,
    location            VARCHAR(200),
    condition_before    ENUM('Good', 'Needs Repair', 'Damaged') DEFAULT 'Good',
    type_of_issue       ENUM('Repair', 'Replace', 'Servicing') NOT NULL,
    problem_description TEXT,
    status              ENUM('Pending', 'Approved', 'Rejected', 'In Progress', 'Completed') DEFAULT 'Pending',
    assigned_technician VARCHAR(200),
    target_date         DATE,
    completion_date     DATE,
    requested_by        INT,
    approved_by         INT,
    approved_date       DATE,
    remarks             TEXT,
    created_at          DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at          DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id) ON DELETE SET NULL,
    FOREIGN KEY (requested_by) REFERENCES users(user_id) ON DELETE SET NULL,
    FOREIGN KEY (approved_by) REFERENCES users(user_id) ON DELETE SET NULL,
    INDEX idx_maint_req_status (status),
    INDEX idx_maint_req_date (date_requested),
    INDEX idx_maint_req_department (department_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- =====================================================
-- SAMPLE DATA INSERTIONS
-- =====================================================

-- Departments
INSERT INTO departments (department_name, head_of_department, email, contact_number, location, building, floor_number, short_name, office_code, description, no_of_employees, budget_allocation, office_hours, established_date, status) VALUES
('Information Technology', 'Dr. Maria Santos', 'it@stacruz.edu', '09123456789', 'Main Building', 'Building A', '2nd Floor', 'IT', 'IT-001', 'Handles all IT-related services and equipment', 15, 500000.00, '8:00 AM - 5:00 PM', '2020-01-15', 'Active'),
('Administration', 'Mr. Juan Dela Cruz', 'admin@stacruz.edu', '09123456790', 'Main Building', 'Building A', '1st Floor', 'ADMIN', 'ADM-001', 'Administrative services and management', 25, 750000.00, '8:00 AM - 5:00 PM', '2019-06-01', 'Active'),
('Human Resources', 'Ms. Anna Garcia', 'hr@stacruz.edu', '09123456791', 'Main Building', 'Building B', '1st Floor', 'HR', 'HR-001', 'Human resources and personnel management', 10, 300000.00, '8:00 AM - 5:00 PM', '2021-03-10', 'Active'),
('Finance', 'Mr. Carlos Rodriguez', 'finance@stacruz.edu', '09123456792', 'Main Building', 'Building A', '3rd Floor', 'FIN', 'FIN-001', 'Financial management and accounting', 12, 1000000.00, '8:00 AM - 5:00 PM', '2018-09-20', 'Active'),
('Maintenance', 'Eng. Roberto Martinez', 'maintenance@stacruz.edu', '09123456793', 'Annex Building', 'Building C', 'Ground Floor', 'MAINT', 'MAINT-001', 'Facilities and equipment maintenance', 8, 400000.00, '7:00 AM - 4:00 PM', '2022-01-05', 'Active');

-- Users
INSERT INTO users (first_name, middle_name, last_name, suffix, position, department_id, employee_id, contact_number, email, username, password_encrypted, province, municipal, barangay, date_assigned, role, status) VALUES
('Super', 'Admin', 'User', '', 'System Administrator', 2, 'EMP-001', '09111111111', 'superadmin@stacruz.edu', 'superadmin', 'encryptedpassword', 'Laguna', 'Sta. Cruz', 'Poblacion', '2020-01-01', 'SuperAdmin', 'Active'),
('John', 'Michael', 'Doe', 'Jr.', 'IT Manager', 1, 'EMP-002', '09222222222', 'john.doe@stacruz.edu', 'admin', 'encryptedpassword', 'Laguna', 'Sta. Cruz', 'Poblacion', '2021-03-15', 'Admin', 'Active'),
('Maria', 'Cruz', 'Santos', '', 'Property Custodian', 2, 'EMP-003', '09333333333', 'maria.santos@stacruz.edu', 'custodian', 'encryptedpassword', 'Laguna', 'Sta. Cruz', 'Poblacion', '2021-06-01', 'Custodian', 'Active'),
('Pedro', 'Alvarez', 'Reyes', '', 'Staff Member', 1, 'EMP-004', '09444444444', 'pedro.reyes@stacruz.edu', 'staff', 'encryptedpassword', 'Laguna', 'Sta. Cruz', 'Poblacion', '2022-01-10', 'Staff', 'Active'),
('Ana', 'Lopez', 'Garcia', '', 'HR Manager', 3, 'EMP-005', '09555555555', 'ana.garcia@stacruz.edu', 'ana.garcia', 'encryptedpassword', 'Laguna', 'Sta. Cruz', 'Poblacion', '2021-09-20', 'Admin', 'Active');

-- Properties
INSERT INTO properties (item_name, category, description, unit_of_measure, property_number, serial_number, acquisition_date, acquisition_cost, total_cost, source_of_funds, assigned_to, department_id, location, `condition`, status, internal_codes) VALUES
('Desktop Computer', 'IT Equipment', 'Dell OptiPlex 7090 Desktop', 'Unit', 'PROP-001', 'SN-DELL-2024-001', '2024-01-15', 45000.00, 45000.00, 'General Fund', 2, 1, 'IT Office', 'Good', 'Active', 'ICT-001'),
('Office Chair', 'Furniture', 'Ergonomic office chair', 'Unit', 'PROP-002', 'SN-CHAIR-2024-001', '2024-02-20', 3500.00, 3500.00, 'General Fund', 3, 2, 'Admin Office', 'Good', 'Active', 'FURN-001');

-- Supplies
INSERT INTO supplies (item_name, category, description, unit_of_measure, quantity, date_received, unit_cost, total_cost, supplier, source_of_funds, location, stock_status) VALUES
('Bond Paper A4', 'Stationery', 'Long bond paper A4 size 80gsm', 'Ream', 50, '2024-01-10', 250.00, 12500.00, 'Office Depot', 'General Fund', 'Supply Room', 'Available'),
('Printer Ink', 'Office Supplies', 'HP 305 Black Ink Cartridge', 'Cartridge', 20, '2024-02-15', 800.00, 16000.00, 'Tech Store', 'General Fund', 'IT Office', 'Available');

-- Maintenance
INSERT INTO maintenance (property_item_name, serial_number, location, department_id, condition_before_maint, type_of_maintenance, assigned_technician, maintenance_date, maintenance_details, cost_materials_labor, condition_after_maint, status, diagnosis, action_taken, parts_replaced) VALUES
('Desktop Computer', 'SN-DELL-2024-001', 'IT Office', 1, 'Needs Repair', 'Repair', 'Eng. Roberto Martinez', '2024-05-15', 'Fixed power supply and RAM', 2500.00, 'Good', 'Completed', 'Power supply failure and RAM module defect', 'Replaced PSU and RAM', 'PSU 450W, RAM 8GB DDR4');

-- Custodians
INSERT INTO custodians (user_id, department_id, assigned_property_count, assigned_supply_count, specialization, certification, date_assigned, status) VALUES
(3, 2, 2, 0, 'Property Management', 'Property Custodian Certification', '2024-01-01', 'Active'),
(2, 1, 3, 2, 'IT Equipment Management', 'IT Asset Management Certification', '2024-01-01', 'Active');

-- Property Requests
INSERT INTO property_requests (requester_name, department_id, date_of_request, item_name, quantity_requested, purpose, status) VALUES
('Pedro Alvarez Reyes', 1, '2024-06-01', 'Desktop Computer', 1, 'For office work', 'Pending'),
('Ana Lopez Garcia', 3, '2024-06-02', 'Office Chair', 2, 'New employees', 'Pending');

-- Supply Requests
INSERT INTO supplies_requests (requester_name, department_id, date_of_request, item_name, quantity_requested, purpose, status) VALUES
('Pedro Alvarez Reyes', 1, '2024-06-01', 'Bond Paper A4', 10, 'For printing documents', 'Pending'),
('Maria Cruz Santos', 2, '2024-06-02', 'Printer Ink', 2, 'Replacement cartridges', 'Pending');

-- Maintenance Requests
INSERT INTO maintenance_requests (date_requested, item_name, property_number, serial_number, department_id, location, condition_before, type_of_issue, problem_description, status, requested_by) VALUES
('2024-06-01', 'Office Chair', 'PROP-002', 'SN-CHAIR-2024-001', 2, 'Admin Office', 'Needs Repair', 'Repair', 'Wobbly base, broken caster wheel', 'Pending', 4),
('2024-06-02', 'Desktop Computer', 'PROP-001', 'SN-DELL-2024-001', 1, 'IT Office', 'Good', 'Servicing', 'Annual maintenance check', 'Pending', 4);

-- =====================================================
-- END OF FIXED SCHEMA
-- =====================================================
