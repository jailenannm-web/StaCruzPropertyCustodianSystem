# 📋 COMPLETE CNSC RUBRICS LOCATION GUIDE
## Where to Find Everything in Your Code - All 18 Criteria

**Team Cruz Property Custodian Management System**

---

## 🎯 SCORE SUMMARY: 100/100

---

## **CRITERION 1: ENTITY RELATIONSHIP DIAGRAM (ERD)** ⭐ 5/5

### **Requirement:** 5 or more main entities with clear relationships

### **Your Score: 5/5 (14 entities - EXCEEDS REQUIREMENT)**

### **WHERE TO FIND:**

#### **Primary Location:**
📁 **File:** `teamcruzim_database.sql`
📍 **Lines:** 38-370

#### **All 14 Entities:**

1. **departments** (Line 38-57)
   - Primary Key: `departmentId`
   - Attributes: 15 fields including departmentName, headOfDepartment, location
   - Indexes: `idx_dept_status`, `idx_dept_name`

2. **users** (Line 60-94)
   - Primary Key: `userId`
   - Foreign Key: `departmentId` → departments(departmentId)
   - Attributes: 18 fields including username, passwordEncrypted, role
   - Indexes: `idx_user_role`, `idx_user_status`, `idx_user_username`

3. **staff_accounts** (Line 97-131)
   - Primary Key: `staffId`
   - Foreign Keys: `userId` → users(userId), `departmentId` → departments
   - Attributes: 17 fields
   - Indexes: `idx_staff_status`, `idx_staff_username`

4. **categories** (Line 134-141)
   - Primary Key: `categoryId`
   - Attributes: 5 fields (categoryName, categoryType, description)
   - Used by: properties, supplies

5. **properties** (Line 145-172)
   - Primary Key: `propertyId`
   - Foreign Keys: `assignedTo` → users(userId), `departmentId` → departments
   - Attributes: 18 fields
   - Indexes: 5 indexes for performance

6. **supplies** (Line 175-194)
   - Primary Key: `supplyId`
   - Attributes: 13 fields
   - Indexes: `idx_supply_category`, `idx_supply_status`

7. **property_requests** (Line 197-219)
   - Primary Key: `requestId`
   - Foreign Keys: `departmentId` → departments, `approvedBy` → users
   - Attributes: 13 fields
   - Indexes: 3 indexes

8. **supplies_requests** (Line 222-244)
   - Primary Key: `requestId`
   - Foreign Keys: `departmentId` → departments, `approvedBy` → users
   - Attributes: 13 fields
   - Indexes: 3 indexes

9. **maintenance_requests** (Line 247-270)
   - Primary Key: `requestId`
   - Foreign Keys: `departmentId` → departments, `requestedBy` → users
   - Attributes: 14 fields
   - Indexes: 3 indexes

10. **maintenance** (Line 273-298)
    - Primary Key: `maintenanceId`
    - Foreign Keys: `requestId` → maintenance_requests, `departmentId` → departments
    - Attributes: 14 fields
    - Indexes: 3 indexes

11. **custodian** (Line 301-316)
    - Primary Key: `custodianId`
    - Foreign Keys: `userId` → users, `departmentId` → departments
    - Attributes: 8 fields
    - Indexes: 3 indexes

12. **borrowed_items** (Line 319-339)
    - Primary Key: `borrowId`
    - Foreign Key: `departmentId` → departments
    - Attributes: 13 fields
    - Indexes: 3 indexes

13. **system_config** (Line 342-352)
    - Primary Key: `configId`
    - Foreign Key: `updatedBy` → users
    - Attributes: 7 fields
    - Index: `idx_config_key`

14. **audit_logs** (Line 355-370)
    - Primary Key: `logId`
    - Foreign Key: `userId` → users
    - Attributes: 9 fields
    - Indexes: 4 indexes for searching

#### **Cardinality & Relationships:**

**1:M (One-to-Many) Relationships:**
- One department → Many users (Line 90)
- One department → Many properties (Line 166)
- One user → Many properties assigned (Line 165)
- One user → Many requests approved (Line 215)
- One department → Many requests (Line 214)
- One maintenance_request → Many maintenance records (Line 293)

**HOW TO DEMONSTRATE:**
1. Open `teamcruzim_database.sql`
2. Show CREATE TABLE statements for all 14 entities
3. Point to FOREIGN KEY constraints showing relationships
4. Explain: "14 entities with proper foreign keys ensure referential integrity"

---

## **CRITERION 2: NORMALIZATION** ⭐ 5/5

### **Requirement:** 5 or more entities in 3NF

### **Your Score: 5/5 (All 14 entities in 3NF - EXCEEDS REQUIREMENT)**

### **WHERE TO FIND:**

#### **Evidence in Database Schema:**
📁 **File:** `teamcruzim_database.sql`
📍 **Lines:** 38-370 (entire schema)

#### **3NF Compliance Examples:**

**Example 1: Properties Table (Line 145)**
```sql
CREATE TABLE properties (
  propertyId INT PRIMARY KEY,          -- Single primary key ✓
  itemName VARCHAR(200),
  category VARCHAR(100),                -- References categories table
  departmentId INT,                     -- FK to departments (no redundancy) ✓
  assignedTo INT,                       -- FK to users (no redundancy) ✓
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId),
  FOREIGN KEY (assignedTo) REFERENCES users(userId)
);
```
**3NF Proof:**
- ✓ 1NF: No repeating groups, atomic values
- ✓ 2NF: No partial dependencies (all attributes depend on full PK)
- ✓ 3NF: No transitive dependencies (department name stored in departments table, not here)

**Example 2: Users Table (Line 60)**
```sql
CREATE TABLE users (
  userId INT PRIMARY KEY,
  departmentId INT,                     -- FK instead of storing dept name ✓
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId)
);
```
**3NF Proof:**
- Department info stored once in departments table
- No redundancy of department names
- Update a department name once, reflects everywhere

**Example 3: Separated Categories (Line 134)**
```sql
CREATE TABLE categories (
  categoryId INT PRIMARY KEY,
  categoryName VARCHAR(100) UNIQUE,
  categoryType ENUM('property', 'supply')
);
```
**Why this shows 3NF:**
- Category names stored centrally
- Properties and supplies reference this table
- No category name duplication

**Example 4: Property Requests (Line 197)**
```sql
CREATE TABLE property_requests (
  requestId INT PRIMARY KEY,
  departmentId INT,                     -- FK, not department name ✓
  approvedBy INT,                       -- FK to users, not username ✓
  FOREIGN KEY (departmentId) REFERENCES departments(departmentId),
  FOREIGN KEY (approvedBy) REFERENCES users(userId)
);
```

#### **All 14 Entities in 3NF:**

| Entity | Primary Key | Foreign Keys | 3NF Compliance |
|--------|-------------|--------------|----------------|
| departments | departmentId | None | ✓ Base table, no redundancy |
| users | userId | departmentId | ✓ Department info via FK |
| staff_accounts | staffId | userId, departmentId | ✓ References users & departments |
| categories | categoryId | None | ✓ Central lookup table |
| properties | propertyId | assignedTo, departmentId | ✓ All references via FK |
| supplies | supplyId | None | ✓ No transitive dependencies |
| property_requests | requestId | departmentId, approvedBy | ✓ All references via FK |
| supplies_requests | requestId | departmentId, approvedBy | ✓ All references via FK |
| maintenance_requests | requestId | departmentId, requestedBy | ✓ All references via FK |
| maintenance | maintenanceId | requestId, departmentId | ✓ All references via FK |
| custodian | custodianId | userId, departmentId | ✓ All references via FK |
| borrowed_items | borrowId | departmentId | ✓ Item references via ID |
| system_config | configId | updatedBy | ✓ Config values normalized |
| audit_logs | logId | userId | ✓ References users via FK |

**HOW TO DEMONSTRATE:**
1. Open `teamcruzim_database.sql`
2. Pick properties table (Line 145)
3. Explain: "Department name not stored here—referenced via departmentId FK"
4. Show categories table (Line 134): "Category names centralized, no duplication"
5. State: "All 14 entities follow 3NF—no redundancy, all dependencies resolved via foreign keys"

---

## **CRITERION 3: DATA TYPES** ⭐ 5/5

### **Requirement:** Consistent data types (1-2 inconsistencies = 5 points)

### **Your Score: 5/5 (ZERO inconsistencies)**

### **WHERE TO FIND:**

📁 **File:** `teamcruzim_database.sql`
📍 **Lines:** 38-370

#### **Data Type Consistency:**

**All IDs use INT AUTO_INCREMENT:**
- `departmentId INT AUTO_INCREMENT` (Line 39)
- `userId INT AUTO_INCREMENT` (Line 61)
- `staffId INT AUTO_INCREMENT` (Line 98)
- `propertyId INT AUTO_INCREMENT` (Line 146)
- `supplyId INT AUTO_INCREMENT` (Line 176)
- All 14 primary keys: Consistent ✓

**All Currency uses DECIMAL(15,2):**
- `acquisitionCost DECIMAL(15,2)` (Line 154 - properties)
- `totalCost DECIMAL(15,2)` (Line 155 - properties)
- `unitCost DECIMAL(15,2)` (Line 183 - supplies)
- `totalCost DECIMAL(15,2)` (Line 184 - supplies)
- `costMaterialsLabor DECIMAL(15,2)` (Line 285 - maintenance)
- All money fields: Consistent ✓

**All Names use VARCHAR with appropriate lengths:**
- `departmentName VARCHAR(100)` (Line 40)
- `firstName VARCHAR(50)` (Line 62)
- `lastName VARCHAR(50)` (Line 64)
- `itemName VARCHAR(200)` (Line 147 - properties)
- `itemName VARCHAR(200)` (Line 177 - supplies)
- All name fields: Consistent ✓

**All Dates use DATE or DATETIME appropriately:**
- `acquisitionDate DATE` (Line 153 - properties)
- `dateReceived DATE` (Line 182 - supplies)
- `dateOfRequest DATE` (Line 202 - property_requests)
- `createdAt DATETIME` (Line 53 - departments)
- `updatedAt DATETIME` (Line 54 - departments)
- Date-only vs. timestamp: Consistent ✓

**All Status fields use ENUM:**
- `status ENUM('Active', 'Inactive')` (Line 52 - departments)
- `status ENUM('Active', 'Borrowed', 'For Disposal', 'Lost')` (Line 161 - properties)
- `stockStatus ENUM('Available', 'Low Stock', 'Out of Stock')` (Line 188 - supplies)
- `status ENUM('Pending', 'Approved', 'Rejected')` (Line 208 - property_requests)
- All status fields: Consistent ✓

**All Descriptions use TEXT:**
- `description TEXT` (Line 49 - departments)
- `description TEXT` (Line 149 - properties)
- `description TEXT` (Line 179 - supplies)
- All description fields: Consistent ✓

**All Foreign Keys use INT:**
- `departmentId INT` (Line 76 - users)
- `assignedTo INT` (Line 157 - properties)
- `approvedBy INT` (Line 209 - property_requests)
- All FK fields: Consistent ✓

#### **Zero Inconsistencies Found:**

**HOW TO DEMONSTRATE:**
1. Open `teamcruzim_database.sql`
2. Show: All IDs are INT (Lines 39, 61, 98, 146, 176...)
3. Show: All costs are DECIMAL(15,2) (Lines 154, 155, 183, 184, 285)
4. Show: All status fields use ENUM (Lines 52, 161, 188, 208)
5. State: "Perfect consistency—no data type conflicts across 14 entities"

---

