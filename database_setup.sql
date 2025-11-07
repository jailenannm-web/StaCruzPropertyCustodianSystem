<div style="color: #e1e4e8;background-color: #0f0f10;font-family: var(--font-geist-mono), ui-sans-serif, system-ui, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol', 'Noto Color Emoji', Consolas, 'Courier New', monospace;font-weight: normal;font-size: 13px;line-height: 18px;white-space: pre;">
    <div>
        <span style="color: #a1a1aa;">-- Create the TeamCruzIM database</span></div>
    <div>
        <span style="color: #f472b6;">CREATE</span><span style="color: #e1e4e8;"> DATABASE </span><span style="color: #f472b6;">IF</span><span style="color: #e1e4e8;"> NOT EXISTS teamcruzim;</span></div>
    <div>
        <span style="color: #e1e4e8;">USE teamcruzim;</span></div>
    <br />
    <div>
        <span style="color: #a1a1aa;">-- Create departments table</span></div>
    <div>
        <span style="color: #f472b6;">CREATE</span><span style="color: #e1e4e8;"> </span><span style="color: #f472b6;">TABLE</span><span style="color: #e1e4e8;"> </span><span style="color: #f472b6;">IF</span><span style="color: #e1e4e8;"> NOT EXISTS departments (</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; department_id INT PRIMARY KEY AUTO_INCREMENT,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; department_name </span><span style="color: #f472b6;">VARCHAR</span><span style="color: #e1e4e8;">(</span><span style="color: #79b8ff;">100</span><span style="color: #e1e4e8;">) NOT </span><span style="color: #f472b6;">NULL</span><span style="color: #e1e4e8;">,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; </span><span style="color: #f472b6;">description</span><span style="color: #e1e4e8;"> </span><span style="color: #f472b6;">TEXT</span><span style="color: #e1e4e8;">,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; created_date </span><span style="color: #f472b6;">TIMESTAMP</span><span style="color: #e1e4e8;"> DEFAULT CURRENT_TIMESTAMP</span></div>
    <div>
        <span style="color: #e1e4e8;">);</span></div>
    <br />
    <div>
        <span style="color: #a1a1aa;">-- Create staff_accounts table</span></div>
    <div>
        <span style="color: #f472b6;">CREATE</span><span style="color: #e1e4e8;"> </span><span style="color: #f472b6;">TABLE</span><span style="color: #e1e4e8;"> </span><span style="color: #f472b6;">IF</span><span style="color: #e1e4e8;"> NOT EXISTS staff_accounts (</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; staff_id INT PRIMARY KEY AUTO_INCREMENT,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; first_name </span><span style="color: #f472b6;">VARCHAR</span><span style="color: #e1e4e8;">(</span><span style="color: #79b8ff;">50</span><span style="color: #e1e4e8;">) NOT </span><span style="color: #f472b6;">NULL</span><span style="color: #e1e4e8;">,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; last_name </span><span style="color: #f472b6;">VARCHAR</span><span style="color: #e1e4e8;">(</span><span style="color: #79b8ff;">50</span><span style="color: #e1e4e8;">) NOT </span><span style="color: #f472b6;">NULL</span><span style="color: #e1e4e8;">,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; email </span><span style="color: #f472b6;">VARCHAR</span><span style="color: #e1e4e8;">(</span><span style="color: #79b8ff;">100</span><span style="color: #e1e4e8;">) NOT </span><span style="color: #f472b6;">NULL</span><span style="color: #e1e4e8;"> UNIQUE,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; contact_number </span><span style="color: #f472b6;">VARCHAR</span><span style="color: #e1e4e8;">(</span><span style="color: #79b8ff;">15</span><span style="color: #e1e4e8;">),</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; </span><span style="color: #f472b6;">address</span><span style="color: #e1e4e8;"> </span><span style="color: #f472b6;">TEXT</span><span style="color: #e1e4e8;">,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; department_id INT,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; username </span><span style="color: #f472b6;">VARCHAR</span><span style="color: #e1e4e8;">(</span><span style="color: #79b8ff;">50</span><span style="color: #e1e4e8;">) NOT </span><span style="color: #f472b6;">NULL</span><span style="color: #e1e4e8;"> UNIQUE,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; </span><span style="color: #f472b6;">password</span><span style="color: #e1e4e8;"> </span><span style="color: #f472b6;">VARCHAR</span><span style="color: #e1e4e8;">(</span><span style="color: #79b8ff;">255</span><span style="color: #e1e4e8;">) NOT </span><span style="color: #f472b6;">NULL</span><span style="color: #e1e4e8;">,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; </span><span style="color: #f472b6;">status</span><span style="color: #e1e4e8;"> </span><span style="color: #f472b6;">VARCHAR</span><span style="color: #e1e4e8;">(</span><span style="color: #79b8ff;">20</span><span style="color: #e1e4e8;">) DEFAULT </span><span style="color: #4ade80;">&#39;Active&#39;</span><span style="color: #e1e4e8;">,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; created_date </span><span style="color: #f472b6;">TIMESTAMP</span><span style="color: #e1e4e8;"> DEFAULT CURRENT_TIMESTAMP,</span></div>
    <div>
        <span style="color: #e1e4e8;">&nbsp; &nbsp; FOREIGN KEY (department_id) REFERENCES departments(department_id)</span></div>
    <div>
        <span style="color: #e1e4e8;">);</span></div>
    <br />
    <div>
        <span style="color: #a1a1aa;">-- Insert sample departments</span></div>
    <div>
        <span style="color: #e1e4e8;">INSERT INTO departments (department_name, </span><span style="color: #f472b6;">description</span><span style="color: #e1e4e8;">) </span><span style="color: #f472b6;">VALUES</span></div>
    <div>
        <span style="color: #e1e4e8;">(</span><span style="color: #4ade80;">&#39;Human Resources&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;Human Resources Department&#39;</span><span style="color: #e1e4e8;">),</span></div>
    <div>
        <span style="color: #e1e4e8;">(</span><span style="color: #4ade80;">&#39;Finance&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;Finance Department&#39;</span><span style="color: #e1e4e8;">),</span></div>
    <div>
        <span style="color: #e1e4e8;">(</span><span style="color: #4ade80;">&#39;Operations&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;Operations Department&#39;</span><span style="color: #e1e4e8;">),</span></div>
    <div>
        <span style="color: #e1e4e8;">(</span><span style="color: #4ade80;">&#39;Information Technology&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;IT Department&#39;</span><span style="color: #e1e4e8;">);</span></div>
    <br />
    <div>
        <span style="color: #a1a1aa;">-- Insert sample staff account for testing</span></div>
    <div>
        <span style="color: #a1a1aa;">-- Username: teststaff, Password: password123</span></div>
    <div>
        <span style="color: #e1e4e8;">INSERT INTO staff_accounts </span>
    </div>
    <div>
        <span style="color: #e1e4e8;">(first_name, last_name, email, contact_number, </span><span style="color: #f472b6;">address</span><span style="color: #e1e4e8;">, department_id, username, </span><span style="color: #f472b6;">password</span><span style="color: #e1e4e8;">, </span><span style="color: #f472b6;">status</span><span style="color: #e1e4e8;">)</span></div>
    <div>
        <span style="color: #f472b6;">VALUES</span><span style="color: #e1e4e8;"> </span>
    </div>
    <div>
        <span style="color: #e1e4e8;">(</span><span style="color: #4ade80;">&#39;Test&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;Staff&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;test@example.com&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;09123456789&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;123 Main Street&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #79b8ff;">1</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;teststaff&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;password123&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;Active&#39;</span><span style="color: #e1e4e8;">);</span></div>
    <br />
    <div>
        <span style="color: #a1a1aa;">-- Create a simple admin user (optional)</span></div>
    <div>
        <span style="color: #a1a1aa;">-- Username: admin, Password: admin123</span></div>
    <div>
        <span style="color: #e1e4e8;">INSERT INTO staff_accounts </span>
    </div>
    <div>
        <span style="color: #e1e4e8;">(first_name, last_name, email, contact_number, </span><span style="color: #f472b6;">address</span><span style="color: #e1e4e8;">, department_id, username, </span><span style="color: #f472b6;">password</span><span style="color: #e1e4e8;">, </span><span style="color: #f472b6;">status</span><span style="color: #e1e4e8;">)</span></div>
    <div>
        <span style="color: #f472b6;">VALUES</span><span style="color: #e1e4e8;"> </span>
    </div>
    <div>
        <span style="color: #e1e4e8;">(</span><span style="color: #4ade80;">&#39;Admin&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;User&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;admin@example.com&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;09987654321&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;456 Admin Street&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #79b8ff;">1</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;admin&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;admin123&#39;</span><span style="color: #e1e4e8;">, </span><span style="color: #4ade80;">&#39;Active&#39;</span><span style="color: #e1e4e8;">);</span></div>
    <br />
</div>
