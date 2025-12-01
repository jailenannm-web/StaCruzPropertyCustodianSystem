-- =====================================================
-- SQL Queries for Property Request and Supply Request Datagrids
-- Returns only the specified columns with proper aliases
-- =====================================================

USE teamcruzim;

-- =====================================================
-- PROPERTY REQUEST DATAGRID QUERY
-- Columns: Name of requester, Department, Date of request, 
--          Item name, Quantity requested, Purpose, Status
-- =====================================================

SELECT 
    TRIM(CONCAT(IFNULL(u.first_name,''), ' ', IFNULL(u.middle_name,''), ' ', IFNULL(u.last_name,''), 
           IF(u.suffix IS NOT NULL AND u.suffix != '', CONCAT(' ', u.suffix), ''))) AS 'Name of requester',
    IFNULL(d.department_name, 'N/A') AS 'Department',
    pr.date_of_request AS 'Date of request',
    pr.item_name AS 'Item name',
    pr.quantity_requested AS 'Quantity requested',
    pr.purpose AS 'Purpose',
    pr.status AS 'Status'
FROM property_requests pr
LEFT JOIN users u ON pr.user_id = u.user_id
LEFT JOIN departments d ON pr.department_id = d.department_id
ORDER BY pr.date_of_request DESC, pr.request_id DESC;

-- =====================================================
-- SUPPLY REQUEST DATAGRID QUERY
-- Columns: Name of requester, Department, Date of request, 
--          Item name, Quantity requested, Purpose, Status
-- =====================================================

SELECT 
    TRIM(CONCAT(IFNULL(u.first_name,''), ' ', IFNULL(u.middle_name,''), ' ', IFNULL(u.last_name,''), 
           IF(u.suffix IS NOT NULL AND u.suffix != '', CONCAT(' ', u.suffix), ''))) AS 'Name of requester',
    IFNULL(d.department_name, 'N/A') AS 'Department',
    sr.date_of_request AS 'Date of request',
    sr.item_name AS 'Item name',
    sr.quantity_requested AS 'Quantity requested',
    sr.purpose AS 'Purpose',
    sr.status AS 'Status'
FROM supply_requests sr
LEFT JOIN users u ON sr.user_id = u.user_id
LEFT JOIN departments d ON sr.department_id = d.department_id
ORDER BY sr.date_of_request DESC, sr.request_id DESC;
