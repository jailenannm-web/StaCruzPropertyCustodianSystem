Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient

''' <summary>
''' Modern Staff Dashboard with 3D charts and statistics
''' Shows: Requests, Borrowed Items, Maintenance, and Activity
''' </summary>
Public Class StaffDashboardContent
    Inherits UserControl

    ' Statistics Cards
    Private pnlTotalRequests As Panel
    Private lblTotalRequestsValue As Label
    Private lblTotalRequestsTitle As Label
    
    Private pnlBorrowedItems As Panel
    Private lblBorrowedItemsValue As Label
    Private lblBorrowedItemsTitle As Label
    
    Private pnlMaintenanceRequests As Panel
    Private lblMaintenanceValue As Label
    Private lblMaintenanceTitle As Label
    
    Private pnlPendingApprovals As Panel
    Private lblPendingValue As Label
    Private lblPendingTitle As Label
    
    ' Charts
    Private chartRequestsStatus As Chart
    Private chartBorrowedItems As Chart
    Private chartMaintenanceStatus As Chart
    
    ' Header
    Private lblDashboardTitle As Label
    Private lblWelcome As Label
    
    Public Sub New()
        InitializeComponent()
        LoadDashboardData()
    End Sub
    
    Private Sub InitializeComponent()
        Me.BackColor = Color.FromArgb(245, 247, 250)
        Me.AutoScroll = True
        
        ' Header Section
        CreateHeader()
        
        ' Statistics Cards Row
        CreateStatisticsCards()
        
        ' Charts Row
        CreateCharts()
        
        ' Recent Activity Section
        CreateRecentActivity()
    End Sub
    
    Private Sub CreateHeader()
        ' Welcome Label
        lblWelcome = New Label()
        lblWelcome.Text = $"Welcome back, {SessionContext.CurrentFullName}!"
        lblWelcome.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblWelcome.ForeColor = Color.FromArgb(52, 73, 94)
        lblWelcome.Location = New Point(30, 20)
        lblWelcome.AutoSize = True
        Me.Controls.Add(lblWelcome)
        
        ' Dashboard Title
        lblDashboardTitle = New Label()
        lblDashboardTitle.Text = "Dashboard Overview"
        lblDashboardTitle.Font = New Font("Segoe UI", 11)
        lblDashboardTitle.ForeColor = Color.Gray
        lblDashboardTitle.Location = New Point(30, 50)
        lblDashboardTitle.AutoSize = True
        Me.Controls.Add(lblDashboardTitle)
    End Sub
    
    Private Sub CreateStatisticsCards()
        Dim startX As Integer = 30
        Dim startY As Integer = 100
        Dim cardWidth As Integer = 280
        Dim cardHeight As Integer = 130
        Dim spacing As Integer = 25
        
        ' Card 1: Total Requests
        pnlTotalRequests = CreateStatsCard(New Point(startX, startY), cardWidth, cardHeight, 
                                           "📋", "Total Requests", "0", Color.FromArgb(52, 152, 219))
        Me.Controls.Add(pnlTotalRequests)
        lblTotalRequestsValue = CType(pnlTotalRequests.Controls("lblValue"), Label)
        lblTotalRequestsTitle = CType(pnlTotalRequests.Controls("lblTitle"), Label)
        
        ' Card 2: Borrowed Items
        pnlBorrowedItems = CreateStatsCard(New Point(startX + (cardWidth + spacing), startY), cardWidth, cardHeight,
                                          "📦", "Borrowed Items", "0", Color.FromArgb(46, 204, 113))
        Me.Controls.Add(pnlBorrowedItems)
        lblBorrowedItemsValue = CType(pnlBorrowedItems.Controls("lblValue"), Label)
        lblBorrowedItemsTitle = CType(pnlBorrowedItems.Controls("lblTitle"), Label)
        
        ' Card 3: Maintenance Requests
        pnlMaintenanceRequests = CreateStatsCard(New Point(startX + (cardWidth + spacing) * 2, startY), cardWidth, cardHeight,
                                                "🔧", "Maintenance", "0", Color.FromArgb(230, 126, 34))
        Me.Controls.Add(pnlMaintenanceRequests)
        lblMaintenanceValue = CType(pnlMaintenanceRequests.Controls("lblValue"), Label)
        lblMaintenanceTitle = CType(pnlMaintenanceRequests.Controls("lblTitle"), Label)
        
        ' Card 4: Pending Approvals
        pnlPendingApprovals = CreateStatsCard(New Point(startX + (cardWidth + spacing) * 3, startY), cardWidth, cardHeight,
                                             "⏳", "Pending", "0", Color.FromArgb(155, 89, 182))
        Me.Controls.Add(pnlPendingApprovals)
        lblPendingValue = CType(pnlPendingApprovals.Controls("lblValue"), Label)
        lblPendingTitle = CType(pnlPendingApprovals.Controls("lblTitle"), Label)
    End Sub
    
    Private Function CreateStatsCard(location As Point, width As Integer, height As Integer, 
                                     icon As String, title As String, value As String, color As Color) As Panel
        Dim card As New Panel()
        card.Location = location
        card.Size = New Size(width, height)
        card.BackColor = Color.White
        card.BorderStyle = BorderStyle.None
        
        ' Add shadow effect
        AddPanelShadow(card)
        
        ' Icon
        Dim lblIcon As New Label()
        lblIcon.Text = icon
        lblIcon.Font = New Font("Segoe UI Emoji", 32)
        lblIcon.Location = New Point(15, 20)
        lblIcon.AutoSize = True
        lblIcon.ForeColor = color
        card.Controls.Add(lblIcon)
        
        ' Value
        Dim lblValue As New Label()
        lblValue.Name = "lblValue"
        lblValue.Text = value
        lblValue.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        lblValue.ForeColor = Color.FromArgb(52, 73, 94)
        lblValue.Location = New Point(90, 25)
        lblValue.AutoSize = True
        card.Controls.Add(lblValue)
        
        ' Title
        Dim lblTitle As New Label()
        lblTitle.Name = "lblTitle"
        lblTitle.Text = title
        lblTitle.Font = New Font("Segoe UI", 11)
        lblTitle.ForeColor = Color.Gray
        lblTitle.Location = New Point(90, 65)
        lblTitle.AutoSize = True
        card.Controls.Add(lblTitle)
        
        ' Hover effect
        AddHandler card.MouseEnter, Sub() card.BackColor = Color.FromArgb(248, 249, 250)
        AddHandler card.MouseLeave, Sub() card.BackColor = Color.White
        
        Return card
    End Function
    
    Private Sub AddPanelShadow(panel As Panel)
        ' Add rounded corners and shadow using Paint event
        AddHandler panel.Paint, Sub(sender As Object, e As PaintEventArgs)
            Dim rect As New Rectangle(0, 0, panel.Width - 1, panel.Height - 1)
            Using path As GraphicsPath = GetRoundedRect(rect, 10)
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                Using brush As New SolidBrush(panel.BackColor)
                    e.Graphics.FillPath(brush, path)
                End Using
                Using pen As New Pen(Color.FromArgb(230, 230, 230), 1)
                    e.Graphics.DrawPath(pen, path)
                End Using
            End Using
        End Sub
    End Sub
    
    Private Function GetRoundedRect(bounds As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.AddArc(bounds.Left, bounds.Top, radius, radius, 180, 90)
        path.AddArc(bounds.Right - radius, bounds.Top, radius, radius, 270, 90)
        path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(bounds.Left, bounds.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function
    
    Private Sub CreateCharts()
        Dim startY As Integer = 270
        Dim chartHeight As Integer = 350
        
        ' Chart 1: Requests Status (Pie Chart 3D)
        chartRequestsStatus = CreateChart("Requests by Status", New Point(30, startY), New Size(400, chartHeight))
        ConfigureRequestsStatusChart()
        Me.Controls.Add(chartRequestsStatus)
        
        ' Chart 2: Borrowed Items Over Time (Column Chart 3D)
        chartBorrowedItems = CreateChart("Borrowed Items Timeline", New Point(450, startY), New Size(400, chartHeight))
        ConfigureBorrowedItemsChart()
        Me.Controls.Add(chartBorrowedItems)
        
        ' Chart 3: Maintenance Status (Doughnut Chart 3D)
        chartMaintenanceStatus = CreateChart("Maintenance Status", New Point(870, startY), New Size(400, chartHeight))
        ConfigureMaintenanceChart()
        Me.Controls.Add(chartMaintenanceStatus)
    End Sub
    
    Private Function CreateChart(title As String, location As Point, size As Size) As Chart
        Dim chart As New Chart()
        chart.Location = location
        chart.Size = size
        chart.BackColor = Color.White
        
        ' Add chart area with 3D effect
        Dim chartArea As New ChartArea()
        chartArea.BackColor = Color.White
        chartArea.Area3DStyle.Enable3D = True
        chartArea.Area3DStyle.Rotation = 10
        chartArea.Area3DStyle.Inclination = 15
        chartArea.Area3DStyle.Perspective = 10
        chartArea.Area3DStyle.LightStyle = LightStyle.Realistic
        chartArea.Area3DStyle.WallWidth = 0
        chart.ChartAreas.Add(chartArea)
        
        ' Add title
        Dim chartTitle As New Title(title)
        chartTitle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        chartTitle.ForeColor = Color.FromArgb(52, 73, 94)
        chart.Titles.Add(chartTitle)
        
        ' Add legend
        Dim legend As New Legend()
        legend.Docking = Docking.Bottom
        legend.Font = New Font("Segoe UI", 9)
        chart.Legends.Add(legend)
        
        ' Shadow and border
        AddHandler chart.Paint, Sub(sender As Object, e As PaintEventArgs)
            Dim rect As New Rectangle(0, 0, chart.Width - 1, chart.Height - 1)
            Using pen As New Pen(Color.FromArgb(230, 230, 230), 1)
                e.Graphics.DrawRectangle(pen, rect)
            End Using
        End Sub
        
        Return chart
    End Function
    
    Private Sub ConfigureRequestsStatusChart()
        Dim series As New Series("Requests")
        series.ChartType = SeriesChartType.Pie
        series.IsValueShownAsLabel = True
        series.LabelForeColor = Color.White
        series.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        
        ' Enable 3D for the series
        series("PieDrawingStyle") = "Concave"
        series("PieLabelStyle") = "Outside"
        
        ' Add sample data points with colors
        series.Points.AddXY("Pending", 0)
        series.Points(0).Color = Color.FromArgb(52, 152, 219)
        
        series.Points.AddXY("Approved", 0)
        series.Points(1).Color = Color.FromArgb(46, 204, 113)
        
        series.Points.AddXY("Rejected", 0)
        series.Points(2).Color = Color.FromArgb(231, 76, 60)
        
        chartRequestsStatus.Series.Add(series)
    End Sub
    
    Private Sub ConfigureBorrowedItemsChart()
        Dim series As New Series("Borrowed Items")
        series.ChartType = SeriesChartType.Column
        series.Color = Color.FromArgb(46, 204, 113)
        series.IsValueShownAsLabel = True
        series.Font = New Font("Segoe UI", 8)
        
        ' Sample data - last 6 months
        Dim months() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun"}
        For i As Integer = 0 To 5
            series.Points.AddXY(months(i), 0)
        Next
        
        chartBorrowedItems.Series.Add(series)
    End Sub
    
    Private Sub ConfigureMaintenanceChart()
        Dim series As New Series("Maintenance")
        series.ChartType = SeriesChartType.Doughnut
        series.IsValueShownAsLabel = True
        series.LabelForeColor = Color.White
        series.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        
        ' Enable 3D
        series("PieDrawingStyle") = "SoftEdge"
        series("DoughnutRadius") = "40"
        
        ' Add data points
        series.Points.AddXY("Pending", 0)
        series.Points(0).Color = Color.FromArgb(230, 126, 34)
        
        series.Points.AddXY("Ongoing", 0)
        series.Points(1).Color = Color.FromArgb(52, 152, 219)
        
        series.Points.AddXY("Completed", 0)
        series.Points(2).Color = Color.FromArgb(46, 204, 113)
        
        chartMaintenanceStatus.Series.Add(series)
    End Sub
    
    Private dgvActivity As DataGridView ' Make it a class field so we can access it later
    
    Private Sub CreateRecentActivity()
        Dim startY As Integer = 650
        
        ' Recent Activity Panel
        Dim pnlActivity As New Panel()
        pnlActivity.Location = New Point(30, startY)
        pnlActivity.Size = New Size(1240, 250)
        pnlActivity.BackColor = Color.White
        AddPanelShadow(pnlActivity)
        Me.Controls.Add(pnlActivity)
        
        ' Activity Title
        Dim lblActivityTitle As New Label()
        lblActivityTitle.Text = "📊 Recent Activity"
        lblActivityTitle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblActivityTitle.ForeColor = Color.FromArgb(52, 73, 94)
        lblActivityTitle.Location = New Point(20, 15)
        lblActivityTitle.AutoSize = True
        pnlActivity.Controls.Add(lblActivityTitle)
        
        ' Activity DataGridView
        dgvActivity = New DataGridView()
        dgvActivity.Location = New Point(20, 50)
        dgvActivity.Size = New Size(1200, 180)
        dgvActivity.BackgroundColor = Color.White
        dgvActivity.BorderStyle = BorderStyle.None
        dgvActivity.AllowUserToAddRows = False
        dgvActivity.ReadOnly = True
        dgvActivity.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvActivity.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
        dgvActivity.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvActivity.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvActivity.ColumnHeadersHeight = 35
        dgvActivity.RowTemplate.Height = 30
        dgvActivity.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250)
        dgvActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        
        ' Add columns
        dgvActivity.Columns.Add("Date", "Date")
        dgvActivity.Columns(0).Width = 150
        dgvActivity.Columns.Add("Type", "Type")
        dgvActivity.Columns(1).Width = 150
        dgvActivity.Columns.Add("Item", "Item")
        dgvActivity.Columns(2).Width = 300
        dgvActivity.Columns.Add("Status", "Status")
        dgvActivity.Columns(3).Width = 150
        dgvActivity.Columns.Add("Action", "Action")
        dgvActivity.Columns(4).Width = 200
        
        pnlActivity.Controls.Add(dgvActivity)
    End Sub
    
    Private Sub LoadDashboardData()
        Try
            Dim staffId As Integer = SessionContext.CurrentUserID.GetValueOrDefault(0)
            If staffId = 0 Then Return
            
            ' Load statistics
            LoadStatistics(staffId)
            
            ' Load chart data
            LoadChartData(staffId)
            
            ' Load recent activity
            LoadRecentActivity(staffId)
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadDashboardData Error: " & ex.Message)
        End Try
    End Sub
    
    ''' <summary>
    ''' Load recent activity into the DataGridView
    ''' </summary>
    Private Sub LoadRecentActivity(staffId As Integer)
        Try
            If dgvActivity Is Nothing Then Return
            
            ' Get user's full name
            Dim fullName As String = SessionContext.CurrentFullName
            If String.IsNullOrEmpty(fullName) Then
                Dim userQuery As String = "SELECT CONCAT(firstName, ' ', lastName) AS fullName FROM users WHERE userId = @staffId"
                Dim dtUser = ExecuteQuery(userQuery, New Dictionary(Of String, Object) From {{"@staffId", staffId}})
                If dtUser IsNot Nothing AndAlso dtUser.Rows.Count > 0 Then
                    fullName = dtUser.Rows(0)("fullName").ToString()
                End If
            End If
            
            dgvActivity.Rows.Clear()
            System.Diagnostics.Debug.WriteLine($"[v0] Loading recent activity for staffId: {staffId}, fullName: {fullName}")
            
            ' Get recent property requests by requesterName
            Dim propQuery As String = "SELECT dateOfRequest as date, 'Property Request' as type, itemName as item, " &
                                     "status, CONCAT('Requested ', quantityRequested, ' ', unit) as action " &
                                     "FROM property_requests WHERE LOWER(TRIM(requesterName)) LIKE LOWER(TRIM(@fullName)) " &
                                     "ORDER BY dateOfRequest DESC LIMIT 5"
            
            Dim dtProp = ExecuteQuery(propQuery, New Dictionary(Of String, Object) From {{"@fullName", "%" & fullName & "%"}})
            If dtProp IsNot Nothing AndAlso dtProp.Rows.Count > 0 Then
                For Each row As DataRow In dtProp.Rows
                    Dim dateValue As String = Convert.ToDateTime(row("date")).ToString("MM/dd/yyyy")
                    dgvActivity.Rows.Add(dateValue, row("type"), row("item"), row("status"), row("action"))
                Next
                System.Diagnostics.Debug.WriteLine($"[v0] Added {dtProp.Rows.Count} property requests to activity")
            End If
            
            ' Get recent supply requests by requesterName
            Dim supQuery As String = "SELECT dateOfRequest as date, 'Supply Request' as type, itemName as item, " &
                                    "status, CONCAT('Requested ', quantityRequested, ' ', unit) as action " &
                                    "FROM supplies_requests WHERE LOWER(TRIM(requesterName)) LIKE LOWER(TRIM(@fullName)) " &
                                    "ORDER BY dateOfRequest DESC LIMIT 5"
            
            Dim dtSup = ExecuteQuery(supQuery, New Dictionary(Of String, Object) From {{"@fullName", "%" & fullName & "%"}})
            If dtSup IsNot Nothing AndAlso dtSup.Rows.Count > 0 Then
                For Each row As DataRow In dtSup.Rows
                    Dim dateValue As String = Convert.ToDateTime(row("date")).ToString("MM/dd/yyyy")
                    dgvActivity.Rows.Add(dateValue, row("type"), row("item"), row("status"), row("action"))
                Next
                System.Diagnostics.Debug.WriteLine($"[v0] Added {dtSup.Rows.Count} supply requests to activity")
            End If
            
            ' Get recent borrowed items by userId
            Dim borrowQuery As String = "SELECT bi.borrowDate as date, 'Borrowed Item' as type, " &
                                       "CASE WHEN bi.itemType = 'property' THEN p.itemName ELSE s.itemName END as item, " &
                                       "bi.status, CONCAT('Borrowed on ', DATE_FORMAT(bi.borrowDate, '%m/%d/%Y')) as action " &
                                       "FROM borrowed_items bi " &
                                       "INNER JOIN users u ON TRIM(bi.borrowerName) = TRIM(CONCAT(u.firstName, ' ', u.lastName)) " &
                                       "LEFT JOIN properties p ON bi.itemId = p.propertyId AND bi.itemType = 'property' " &
                                       "LEFT JOIN supplies s ON bi.itemId = s.supplyId AND bi.itemType = 'supply' " &
                                       "WHERE u.userId = @staffId " &
                                       "ORDER BY bi.borrowDate DESC LIMIT 5"
            
            Dim dtBorrow = ExecuteQuery(borrowQuery, New Dictionary(Of String, Object) From {{"@staffId", staffId}})
            If dtBorrow IsNot Nothing AndAlso dtBorrow.Rows.Count > 0 Then
                For Each row As DataRow In dtBorrow.Rows
                    Dim dateValue As String = Convert.ToDateTime(row("date")).ToString("MM/dd/yyyy")
                    dgvActivity.Rows.Add(dateValue, row("type"), row("item"), row("status"), row("action"))
                Next
                System.Diagnostics.Debug.WriteLine($"[v0] Added {dtBorrow.Rows.Count} borrowed items to activity")
            End If
            
            ' Sort by date descending
            dgvActivity.Sort(dgvActivity.Columns(0), System.ComponentModel.ListSortDirection.Descending)
            
            ' Limit to 10 most recent
            While dgvActivity.Rows.Count > 10
                dgvActivity.Rows.RemoveAt(dgvActivity.Rows.Count - 1)
            End While
            
            System.Diagnostics.Debug.WriteLine($"[v0] Total activity rows: {dgvActivity.Rows.Count}")
            
            ' Color code status column
            For Each row As DataGridViewRow In dgvActivity.Rows
                If row.Cells(3).Value IsNot Nothing Then
                    Select Case row.Cells(3).Value.ToString()
                        Case "Pending"
                            row.Cells(3).Style.ForeColor = Color.FromArgb(230, 126, 34)
                        Case "Approved"
                            row.Cells(3).Style.ForeColor = Color.FromArgb(46, 204, 113)
                        Case "Rejected"
                            row.Cells(3).Style.ForeColor = Color.FromArgb(231, 76, 60)
                        Case "Borrowed"
                            row.Cells(3).Style.ForeColor = Color.FromArgb(52, 152, 219)
                        Case "Returned"
                            row.Cells(3).Style.ForeColor = Color.FromArgb(149, 165, 166)
                    End Select
                End If
            Next
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadRecentActivity Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub
    
    ''' <summary>
    ''' Helper method to execute SQL query and return DataTable
    ''' </summary>
    Private Function ExecuteQuery(query As String, params As Dictionary(Of String, Object)) As DataTable
        Dim dt As New DataTable()
        Dim conn As MySqlConnection = Nothing
        Try
            conn = modDB.GetConnection()
            If conn Is Nothing Then Return Nothing
            
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                ' Add parameters
                If params IsNot Nothing Then
                    For Each kvp In params
                        cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
                    Next
                End If
                
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
            
            Return dt
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] ExecuteQuery Error: " & ex.Message)
            Return Nothing
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
                conn.Dispose()
            End If
        End Try
    End Function
    
    Private Sub LoadStatistics(staffId As Integer)
        Try
            ' Get user's full name from session to match with requesterName
            Dim fullName As String = SessionContext.CurrentFullName
            If String.IsNullOrEmpty(fullName) Then
                ' Fallback: Get from database
                Dim userQuery As String = "SELECT CONCAT(firstName, ' ', lastName) AS fullName FROM users WHERE userId = @staffId"
                Dim dtUser = ExecuteQuery(userQuery, New Dictionary(Of String, Object) From {{"@staffId", staffId}})
                If dtUser IsNot Nothing AndAlso dtUser.Rows.Count > 0 Then
                    fullName = dtUser.Rows(0)("fullName").ToString()
                End If
            End If
            
            System.Diagnostics.Debug.WriteLine($"[v0] LoadStatistics for staffId={staffId}, fullName={fullName}")
            
            ' Total Requests (Property + Supply) - Match by requesterName since userId column doesn't exist
            Dim totalRequests As Integer = 0
            Dim query1 As String = "SELECT COUNT(*) FROM property_requests WHERE LOWER(TRIM(requesterName)) LIKE LOWER(TRIM(@fullName))"
            Dim query2 As String = "SELECT COUNT(*) FROM supplies_requests WHERE LOWER(TRIM(requesterName)) LIKE LOWER(TRIM(@fullName))"
            
            Dim dt1 = ExecuteQuery(query1, New Dictionary(Of String, Object) From {{"@fullName", "%" & fullName & "%"}})
            Dim dt2 = ExecuteQuery(query2, New Dictionary(Of String, Object) From {{"@fullName", "%" & fullName & "%"}})
            
            If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then
                totalRequests += Convert.ToInt32(dt1.Rows(0)(0))
                System.Diagnostics.Debug.WriteLine($"[v0] Property requests: {dt1.Rows(0)(0)}")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Property requests: 0")
            End If
            If dt2 IsNot Nothing AndAlso dt2.Rows.Count > 0 Then
                totalRequests += Convert.ToInt32(dt2.Rows(0)(0))
                System.Diagnostics.Debug.WriteLine($"[v0] Supply requests: {dt2.Rows(0)(0)}")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Supply requests: 0")
            End If
            lblTotalRequestsValue.Text = totalRequests.ToString()
            System.Diagnostics.Debug.WriteLine($"[v0] Total requests: {totalRequests}")
            
            ' Borrowed Items - Match by userId via properties/supplies assignment
            Dim borrowedQuery As String = "SELECT COUNT(*) FROM borrowed_items bi " &
                                         "INNER JOIN users u ON TRIM(bi.borrowerName) = TRIM(CONCAT(u.firstName, ' ', u.lastName)) " &
                                         "WHERE u.userId = @staffId AND bi.status = 'Borrowed'"
            Dim dtBorrowed = ExecuteQuery(borrowedQuery, New Dictionary(Of String, Object) From {{"@staffId", staffId}})
            If dtBorrowed IsNot Nothing AndAlso dtBorrowed.Rows.Count > 0 Then
                lblBorrowedItemsValue.Text = dtBorrowed.Rows(0)(0).ToString()
                System.Diagnostics.Debug.WriteLine($"[v0] Borrowed items: {dtBorrowed.Rows(0)(0)}")
            Else
                lblBorrowedItemsValue.Text = "0"
                System.Diagnostics.Debug.WriteLine("[v0] Borrowed items: 0")
            End If
            
            ' Maintenance Requests - Match by requestedBy (user ID)
            Dim maintQuery As String = "SELECT COUNT(*) FROM maintenance_requests WHERE requestedBy = @staffId"
            Dim dtMaint = ExecuteQuery(maintQuery, New Dictionary(Of String, Object) From {{"@staffId", staffId}})
            If dtMaint IsNot Nothing AndAlso dtMaint.Rows.Count > 0 Then
                lblMaintenanceValue.Text = dtMaint.Rows(0)(0).ToString()
                System.Diagnostics.Debug.WriteLine($"[v0] Maintenance requests: {dtMaint.Rows(0)(0)}")
            Else
                lblMaintenanceValue.Text = "0"
                System.Diagnostics.Debug.WriteLine("[v0] Maintenance requests: 0")
            End If
            
            ' Pending Approvals (Property + Supply with Pending status) - Match by requesterName
            Dim pendingCount As Integer = 0
            Dim pendingQuery1 As String = "SELECT COUNT(*) FROM property_requests WHERE LOWER(TRIM(requesterName)) LIKE LOWER(TRIM(@fullName)) AND status = 'Pending'"
            Dim pendingQuery2 As String = "SELECT COUNT(*) FROM supplies_requests WHERE LOWER(TRIM(requesterName)) LIKE LOWER(TRIM(@fullName)) AND status = 'Pending'"
            
            Dim dtPending1 = ExecuteQuery(pendingQuery1, New Dictionary(Of String, Object) From {{"@fullName", "%" & fullName & "%"}})
            Dim dtPending2 = ExecuteQuery(pendingQuery2, New Dictionary(Of String, Object) From {{"@fullName", "%" & fullName & "%"}})
            
            If dtPending1 IsNot Nothing AndAlso dtPending1.Rows.Count > 0 Then
                pendingCount += Convert.ToInt32(dtPending1.Rows(0)(0))
                System.Diagnostics.Debug.WriteLine($"[v0] Pending property requests: {dtPending1.Rows(0)(0)}")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Pending property requests: 0")
            End If
            If dtPending2 IsNot Nothing AndAlso dtPending2.Rows.Count > 0 Then
                pendingCount += Convert.ToInt32(dtPending2.Rows(0)(0))
                System.Diagnostics.Debug.WriteLine($"[v0] Pending supply requests: {dtPending2.Rows(0)(0)}")
            Else
                System.Diagnostics.Debug.WriteLine("[v0] Pending supply requests: 0")
            End If
            lblPendingValue.Text = pendingCount.ToString()
            System.Diagnostics.Debug.WriteLine($"[v0] Total pending: {pendingCount}")
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadStatistics Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
            ' Set all to 0 on error
            lblTotalRequestsValue.Text = "0"
            lblBorrowedItemsValue.Text = "0"
            lblMaintenanceValue.Text = "0"
            lblPendingValue.Text = "0"
        End Try
    End Sub
    
    Private Sub LoadChartData(staffId As Integer)
        Try
            ' Get user's full name to match with requesterName
            Dim fullName As String = SessionContext.CurrentFullName
            If String.IsNullOrEmpty(fullName) Then
                Dim userQuery As String = "SELECT CONCAT(firstName, ' ', lastName) AS fullName FROM users WHERE userId = @staffId"
                Dim dtUser = ExecuteQuery(userQuery, New Dictionary(Of String, Object) From {{"@staffId", staffId}})
                If dtUser IsNot Nothing AndAlso dtUser.Rows.Count > 0 Then
                    fullName = dtUser.Rows(0)("fullName").ToString()
                End If
            End If
            
            System.Diagnostics.Debug.WriteLine($"[v0] LoadChartData started for staffId: {staffId}, fullName: {fullName}")
            
            ' ========== Chart 1: Requests Status ==========
            chartRequestsStatus.Series(0).Points.Clear()
            
            Dim totalRequestCount As Integer = 0
            Dim statusCounts As New Dictionary(Of String, Integer)
            statusCounts.Add("Pending", 0)
            statusCounts.Add("Approved", 0)
            statusCounts.Add("Rejected", 0)
            
            ' Get property requests by requesterName (userId column doesn't exist)
            Dim propQuery As String = "SELECT status, COUNT(*) as count FROM property_requests WHERE LOWER(TRIM(requesterName)) LIKE LOWER(TRIM(@fullName)) GROUP BY status"
            Dim dtProp = ExecuteQuery(propQuery, New Dictionary(Of String, Object) From {{"@fullName", "%" & fullName & "%"}})
            If dtProp IsNot Nothing AndAlso dtProp.Rows.Count > 0 Then
                System.Diagnostics.Debug.WriteLine($"[v0] Property requests found: {dtProp.Rows.Count} status groups")
                For Each row As DataRow In dtProp.Rows
                    Dim status As String = row("status").ToString()
                    Dim count As Integer = Convert.ToInt32(row("count"))
                    System.Diagnostics.Debug.WriteLine($"[v0] Property: {status} = {count}")
                    If statusCounts.ContainsKey(status) Then
                        statusCounts(status) += count
                    Else
                        statusCounts.Add(status, count)
                    End If
                Next
            Else
                System.Diagnostics.Debug.WriteLine("[v0] No property requests found for this user")
            End If
            
            ' Get supply requests by requesterName
            Dim supQuery As String = "SELECT status, COUNT(*) as count FROM supplies_requests WHERE LOWER(TRIM(requesterName)) LIKE LOWER(TRIM(@fullName)) GROUP BY status"
            Dim dtSup = ExecuteQuery(supQuery, New Dictionary(Of String, Object) From {{"@fullName", "%" & fullName & "%"}})
            If dtSup IsNot Nothing AndAlso dtSup.Rows.Count > 0 Then
                System.Diagnostics.Debug.WriteLine($"[v0] Supply requests found: {dtSup.Rows.Count} status groups")
                For Each row As DataRow In dtSup.Rows
                    Dim status As String = row("status").ToString()
                    Dim count As Integer = Convert.ToInt32(row("count"))
                    System.Diagnostics.Debug.WriteLine($"[v0] Supply: {status} = {count}")
                    If statusCounts.ContainsKey(status) Then
                        statusCounts(status) += count
                    Else
                        statusCounts.Add(status, count)
                    End If
                Next
            Else
                System.Diagnostics.Debug.WriteLine("[v0] No supply requests found for this user")
            End If
            
            ' Count total requests
            For Each kvp In statusCounts
                totalRequestCount += kvp.Value
            Next
            
            System.Diagnostics.Debug.WriteLine($"[v0] Total requests found: {totalRequestCount}")
            
            ' Update Requests chart with colors
            Dim pointIndex As Integer = 0
            If totalRequestCount = 0 Then
                ' No data - show message on chart
                System.Diagnostics.Debug.WriteLine("[v0] No requests found - chart will be empty")
                chartRequestsStatus.Titles.Clear()
                chartRequestsStatus.Titles.Add("Requests by Status")
                Dim noDataTitle As New Title("No requests yet")
                noDataTitle.Font = New Font("Segoe UI", 10, FontStyle.Italic)
                noDataTitle.ForeColor = Color.Gray
                chartRequestsStatus.Titles.Add(noDataTitle)
            Else
                For Each kvp In statusCounts
                    If kvp.Value > 0 Then ' Only show statuses with data
                        Dim pt = chartRequestsStatus.Series(0).Points.AddXY(kvp.Key, kvp.Value)
                        ' Set colors
                        Select Case kvp.Key
                            Case "Pending"
                                chartRequestsStatus.Series(0).Points(pointIndex).Color = Color.FromArgb(52, 152, 219)
                            Case "Approved"
                                chartRequestsStatus.Series(0).Points(pointIndex).Color = Color.FromArgb(46, 204, 113)
                            Case "Rejected"
                                chartRequestsStatus.Series(0).Points(pointIndex).Color = Color.FromArgb(231, 76, 60)
                        End Select
                        pointIndex += 1
                    End If
                Next
                System.Diagnostics.Debug.WriteLine($"[v0] Requests chart points added: {chartRequestsStatus.Series(0).Points.Count}")
            End If
            
            ' ========== Chart 2: Borrowed Items Timeline ==========
            chartBorrowedItems.Series(0).Points.Clear()
            
            ' Get borrowed items by month for last 6 months by userId
            Dim borrowedQuery As String = "SELECT MONTH(bi.borrowDate) as month, MONTHNAME(bi.borrowDate) as monthName, COUNT(*) as count " &
                                         "FROM borrowed_items bi " &
                                         "INNER JOIN users u ON TRIM(bi.borrowerName) = TRIM(CONCAT(u.firstName, ' ', u.lastName)) " &
                                         "WHERE u.userId = @staffId AND bi.borrowDate >= DATE_SUB(CURDATE(), INTERVAL 6 MONTH) " &
                                         "GROUP BY MONTH(bi.borrowDate), MONTHNAME(bi.borrowDate) " &
                                         "ORDER BY MONTH(bi.borrowDate)"
            
            Dim dtBorrowed = ExecuteQuery(borrowedQuery, New Dictionary(Of String, Object) From {{"@staffId", staffId}})
            If dtBorrowed IsNot Nothing AndAlso dtBorrowed.Rows.Count > 0 Then
                System.Diagnostics.Debug.WriteLine($"[v0] Borrowed items timeline: {dtBorrowed.Rows.Count} months")
                For Each row As DataRow In dtBorrowed.Rows
                    Dim monthName As String = row("monthName").ToString().Substring(0, 3) ' First 3 letters
                    Dim count As Integer = Convert.ToInt32(row("count"))
                    chartBorrowedItems.Series(0).Points.AddXY(monthName, count)
                    System.Diagnostics.Debug.WriteLine($"[v0] Borrowed: {monthName} = {count}")
                Next
            Else
                ' Add dummy data if no results
                System.Diagnostics.Debug.WriteLine("[v0] No borrowed items data, adding dummy months")
                Dim currentMonth As Integer = DateTime.Now.Month
                For i As Integer = 5 To 0 Step -1
                    Dim month As DateTime = DateTime.Now.AddMonths(-i)
                    chartBorrowedItems.Series(0).Points.AddXY(month.ToString("MMM"), 0)
                Next
            End If
            System.Diagnostics.Debug.WriteLine($"[v0] Borrowed items chart points: {chartBorrowedItems.Series(0).Points.Count}")
            
            ' ========== Chart 3: Maintenance Status ==========
            chartMaintenanceStatus.Series(0).Points.Clear()
            
            Dim maintCounts As New Dictionary(Of String, Integer)
            maintCounts.Add("Pending", 0)
            maintCounts.Add("Approved", 0)
            maintCounts.Add("In Progress", 0)
            maintCounts.Add("Completed", 0)
            
            Dim maintQuery As String = "SELECT status, COUNT(*) as count FROM maintenance_requests WHERE requestedBy = @staffId GROUP BY status"
            Dim dtMaint = ExecuteQuery(maintQuery, New Dictionary(Of String, Object) From {{"@staffId", staffId}})
            If dtMaint IsNot Nothing AndAlso dtMaint.Rows.Count > 0 Then
                System.Diagnostics.Debug.WriteLine($"[v0] Maintenance requests found: {dtMaint.Rows.Count} status groups")
                For Each row As DataRow In dtMaint.Rows
                    Dim status As String = row("status").ToString()
                    Dim count As Integer = Convert.ToInt32(row("count"))
                    System.Diagnostics.Debug.WriteLine($"[v0] Maintenance: {status} = {count}")
                    If maintCounts.ContainsKey(status) Then
                        maintCounts(status) = count
                    Else
                        maintCounts.Add(status, count)
                    End If
                Next
            End If
            
            ' Update Maintenance chart with colors
            pointIndex = 0
            For Each kvp In maintCounts
                If kvp.Value > 0 Then ' Only show statuses with data
                    chartMaintenanceStatus.Series(0).Points.AddXY(kvp.Key, kvp.Value)
                    ' Set colors
                    Select Case kvp.Key
                        Case "Pending"
                            chartMaintenanceStatus.Series(0).Points(pointIndex).Color = Color.FromArgb(230, 126, 34)
                        Case "Approved", "In Progress"
                            chartMaintenanceStatus.Series(0).Points(pointIndex).Color = Color.FromArgb(52, 152, 219)
                        Case "Completed"
                            chartMaintenanceStatus.Series(0).Points(pointIndex).Color = Color.FromArgb(46, 204, 113)
                    End Select
                    pointIndex += 1
                End If
            Next
            System.Diagnostics.Debug.WriteLine($"[v0] Maintenance chart points: {chartMaintenanceStatus.Series(0).Points.Count}")
            
            System.Diagnostics.Debug.WriteLine("[v0] LoadChartData completed successfully")
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] LoadChartData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show("Error loading chart data. Check Output window for details.", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class
