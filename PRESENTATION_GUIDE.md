# 🎓 CNSC IT106 Final Project Presentation Guide
## Team Cruz Property Custodian Management System

---

## 📋 PRE-PRESENTATION CHECKLIST

### ✅ Before Demo Day:
- [ ] Print complete project proposal
- [ ] Print rubrics with self-assessment
- [ ] Backup database to USB/cloud
- [ ] Test on presentation computers
- [ ] Prepare 3 computers (SuperAdmin, Admin, Staff)
- [ ] Import database to server computer
- [ ] Test network connectivity between computers
- [ ] Verify all forms open without errors

---

## 🎯 PRESENTATION FLOW (Follow This Order)

### **PART 1: DESIGN CRITERIA (15 minutes)**

---

## 1️⃣ **ENTITY RELATIONSHIP DIAGRAM (ERD)** - TARGET: 5/5

### **What to Show:**
"We have **14 main entities** with proper relationships and foreign keys."

### **How to Demonstrate:**

1. **Open File:** `teamcruzim_database.sql`
2. **Show Lines:** 38-370
3. **Point Out These Tables:**
   ```
   ✅ departments (line 38)
   ✅ users (line 60)
   ✅ staff_accounts (line 97)
   ✅ categories (line 134)
   ✅ properties (line 145)
   ✅ supplies (line 175)
   ✅ property_requests (line 197)
   ✅ supplies_requests (line 222)
   ✅ maintenance_requests (line 247)
   ✅ maintenance (line 273)
   ✅ custodian (line 301)
   ✅ borrowed_items (line 319)
   ✅ system_config (line 342)
   ✅ audit_logs (line 355)
   ```

4. **Highlight Foreign Keys:**
   - Line 90: `FOREIGN KEY (departmentId) REFERENCES departments`
   - Line 165: `FOREIGN KEY (assignedTo) REFERENCES users`
   - Line 214: `FOREIGN KEY (approvedBy) REFERENCES users`
   - Line 293: `FOREIGN KEY (requestId) REFERENCES maintenance_requests`

5. **Show Cardinality:**
   - "One department has many users (1:M)"
   - "One user can have many properties assigned (1:M)"
   - "Properties can have many maintenance records (1:M)"

### **What to Say:**
> "Our system has 14 interconnected entities following proper database design principles. Each foreign key establishes clear relationships—for example, properties reference both users (for assignment) and departments (for location), ensuring data integrity through proper cardinality constraints."

---

## 2️⃣ **NORMALIZATION** - TARGET: 5/5

### **What to Show:**
"All 14 entities are in **3rd Normal Form (3NF)**."

### **How to Demonstrate:**

1. **Open:** `teamcruzim_database.sql`
2. **Explain 3NF Compliance:**

   **Example 1 - Users Table (Line 60):**
   ```sql
   - userId (Primary Key) ✓
   - No repeating groups ✓
   - All attributes depend on userId only ✓
   - No transitive dependencies ✓
   ```

   **Example 2 - Properties Table (Line 145):**
   ```sql
   - propertyId (Primary Key) ✓
   - Separated category into categories table ✓
   - Department info in departments table (not duplicated) ✓
   - No partial dependencies ✓
   ```

3. **Show Separation:**
   - Point to `categories` table (line 134): "Categories separated to avoid redundancy"
   - Point to `departments` table (line 38): "Department info stored once, referenced by FK"

### **What to Say:**
> "Every table follows 3rd Normal Form. For instance, instead of storing department names repeatedly in the properties table, we have a separate departments table with a foreign key reference. This eliminates redundancy and update anomalies—a single department name change updates everywhere automatically."

---

## 3️⃣ **DATA TYPES** - TARGET: 5/5

### **What to Show:**
"Consistent and appropriate data types throughout."

### **How to Demonstrate:**

1. **Open:** `teamcruzim_database.sql`
2. **Show Consistency:**

   **Properties Table (Line 145):**
   ```sql
   propertyId INT                    ✓ Numeric ID
   itemName VARCHAR(200)             ✓ Text
   acquisitionCost DECIMAL(15,2)     ✓ Currency
   acquisitionDate DATE              ✓ Date only
   createdAt DATETIME                ✓ Date + time
   status ENUM('Active','Borrowed')  ✓ Fixed choices
   ```

   **Users Table (Line 60):**
   ```sql
   userId INT                        ✓ Same ID pattern
   passwordEncrypted VARCHAR(255)    ✓ Secure hash storage
   ```

3. **Count Inconsistencies:** "Zero inconsistencies—all IDs are INT, all costs are DECIMAL(15,2), all dates use DATE/DATETIME consistently."

### **What to Say:**
> "We've used appropriate data types consistently across all tables. Currency values use DECIMAL(15,2) for precision, status fields use ENUM for data validation, and all primary keys are INT AUTO_INCREMENT. This consistency prevents data type errors and ensures database integrity."

---

