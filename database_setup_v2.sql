-- Create the TeamCruzIM database
CREATE DATABASE IF NOT EXISTS teamcruzim;
USE teamcruzim;

-- Create departments table
CREATE TABLE IF NOT EXISTS departments (
    department_id INT PRIMARY KEY AUTO_INCREMENT,
    department_name VARCHAR(100) NOT NULL,
    description TEXT,
    created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create users table (for Admin and SuperAdmin)
CREATE TABLE IF NOT EXISTS users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    user_type ENUM('Admin', 'SuperAdmin') NOT NULL,
    status VARCHAR(20) DEFAULT 'Active',
    created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create staff_accounts table
CREATE TABLE IF NOT EXISTS staff_accounts (
    staff_id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    contact_number VARCHAR(15),
    address TEXT,
    department_id INT,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    status VARCHAR(20) DEFAULT 'Active',
    created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES departments(department_id)
);

-- Insert sample departments
INSERT INTO departments (department_name, description) VALUES
('Human Resources', 'Human Resources Department'),
('Finance', 'Finance Department'),
('Operations', 'Operations Department'),
('Information Technology', 'IT Department');

-- Fixed comment formatting - separated comment lines properly
-- Insert sample staff account for testing
-- Username: teststaff, Password: password123
INSERT INTO staff_accounts (first_name, last_name, email, contact_number, address, department_id, username, password, status)
VALUES ('Test', 'Staff', 'teststaff@example.com', '09123456789', '123 Main Street', 1, 'teststaff', 'password123', 'Active');

-- Insert sample admin account for testing
-- Username: admin, Password: admin123
INSERT INTO users (first_name, last_name, email, username, password, user_type, status)
VALUES ('Admin', 'User', 'admin@example.com', 'admin', 'admin123', 'Admin', 'Active');

-- Insert sample super admin account for testing
-- Username: superadmin, Password: super123
INSERT INTO users (first_name, last_name, email, username, password, user_type, status)
VALUES ('Super', 'Admin', 'superadmin@example.com', 'superadmin', 'super123', 'SuperAdmin', 'Active');
