Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class StaffDashboard
    Private isSidebarExpanded As Boolean = True
    Private sidebarExpandedWidth As Integer = 250
    Private sidebarCollapsedWidth As Integer = 60


    Private Sub SetActiveButton(ByVal activeBtn As Button)

    End Sub

    Private Sub ToggleSidebar()
        ' Only start the timer if it's not already animating
        If Not tmrSidebar.Enabled Then
            tmrSidebar.Start()
        End If
    End Sub





    Private Sub StaffDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Verify session is still valid
        If Not SessionContext.CurrentUserID.HasValue OrElse SessionContext.CurrentUserID.Value <= 0 Then
            ' Try to restore session from settings if available
            If Not String.IsNullOrEmpty(My.Settings.LoggedInuser) Then
                ' Session was lost, redirect to login
                MessageBox.Show("Your session has expired. Please log in again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Dim loginForm As New StaffLogin()
                loginForm.Show()
                Me.Close()
                Return
            Else
                ' No saved session, redirect to login
                MessageBox.Show("Please log in to continue.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim loginForm As New StaffLogin()
                loginForm.Show()
                Me.Close()
                Return
            End If
        End If

        ' Set Dashboard as the active button on startup
        SetActiveButton(btnDashboard)

        ' CLEAR the panel first
        pnlFormLoader.Controls.Clear()
        
        ' Show the form loader panel with dashboard content
        pnlFormLoader.Visible = True
        pnlFormLoader.BringToFront()

        ' Load modern dashboard on startup
        Try
            Dim dashboardContent As New StaffDashboardContent()
            dashboardContent.Dock = DockStyle.Fill
            pnlFormLoader.Controls.Add(dashboardContent)
            System.Diagnostics.Debug.WriteLine("[v0] Modern dashboard loaded on startup")
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Dashboard load error: " & ex.Message)
            MessageBox.Show("Error loading dashboard: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' (Your other load code... like sidebar setup)
    End Sub

    Private Sub pnlSidebar_Click(sender As Object, e As EventArgs) Handles pnlSidebar.Click
        ToggleSidebar()
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        Try
            ' Expand sidebar if collapsed
            If Not isSidebarExpanded Then
                ToggleSidebar()
            End If

            SetActiveButton(btnDashboard)

            ' Clear all controls from panel
            pnlFormLoader.Controls.Clear()

            ' Load new modern dashboard
            Dim dashboardContent As New StaffDashboardContent()
            dashboardContent.Dock = DockStyle.Fill
            pnlFormLoader.Controls.Add(dashboardContent)
            
            ' SHOW the form loader panel
            pnlFormLoader.Visible = True
            pnlFormLoader.BringToFront()
            
            System.Diagnostics.Debug.WriteLine("[v0] Modern dashboard loaded with 3D charts")
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("btnDashboard_Click Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
            MessageBox.Show("Error loading dashboard: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDashboardData()
        Try
            If Not SessionContext.CurrentUserID.HasValue OrElse SessionContext.CurrentUserID.Value <= 0 Then
                Return
            End If

            ' Load recent requests for the DataGridView
            Dim dt As DataTable = modDB.GetStaffRequests(SessionContext.CurrentUserID.Value)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ' Clear existing data
                DataGridView1.Rows.Clear()

                ' Populate DataGridView with recent requests (limit to 10 most recent)
                Dim rowCount As Integer = Math.Min(10, dt.Rows.Count)
                For i As Integer = 0 To rowCount - 1
                    Dim row As DataRow = dt.Rows(i)
                    Try
                        Dim requestID As String = ""
                        Dim requestDate As String = ""
                        Dim itemName As String = ""
                        Dim requestType As String = ""
                        Dim quantity As String = "1"
                        Dim requestStatus As String = ""
                        Dim approvedBy As String = ""
                        Dim releaseDate As String = ""
                        Dim returnDate As String = ""

                        If dt.Columns.Contains("request_id") AndAlso Not IsDBNull(row("request_id")) Then
                            requestID = row("request_id").ToString()
                        End If
                        If dt.Columns.Contains("request_date") AndAlso Not IsDBNull(row("request_date")) Then
                            requestDate = Convert.ToDateTime(row("request_date")).ToString("yyyy-MM-dd")
                        End If
                        If dt.Columns.Contains("item_name") AndAlso Not IsDBNull(row("item_name")) Then
                            itemName = row("item_name").ToString()
                        End If
                        If dt.Columns.Contains("request_type") AndAlso Not IsDBNull(row("request_type")) Then
                            requestType = row("request_type").ToString()
                        End If
                        If dt.Columns.Contains("quantity") AndAlso Not IsDBNull(row("quantity")) Then
                            quantity = row("quantity").ToString()
                        End If
                        If dt.Columns.Contains("status") AndAlso Not IsDBNull(row("status")) Then
                            requestStatus = row("status").ToString()
                        End If
                        If dt.Columns.Contains("approval_date") AndAlso Not IsDBNull(row("approval_date")) Then
                            approvedBy = Convert.ToDateTime(row("approval_date")).ToString("yyyy-MM-dd")
                        End If
                        If dt.Columns.Contains("release_date") AndAlso Not IsDBNull(row("release_date")) Then
                            releaseDate = Convert.ToDateTime(row("release_date")).ToString("yyyy-MM-dd")
                        End If
                        If dt.Columns.Contains("expected_return_date") AndAlso Not IsDBNull(row("expected_return_date")) Then
                            returnDate = Convert.ToDateTime(row("expected_return_date")).ToString("yyyy-MM-dd")
                        End If

                        DataGridView1.Rows.Add(requestID, SessionContext.CurrentUserID.Value.ToString(), "", requestDate, itemName, quantity, requestStatus, approvedBy, releaseDate, returnDate)
                    Catch rowEx As Exception
                        System.Diagnostics.Debug.WriteLine("Error processing row in LoadDashboardData: " & rowEx.Message)
                    End Try
                Next
            End If

            ' Update summary cards
            UpdateDashboardSummary()
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("LoadDashboardData Error: " & ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub UpdateDashboardSummary()
        Try
            If Not SessionContext.CurrentUserID.HasValue OrElse SessionContext.CurrentUserID.Value <= 0 Then
                Return
            End If

            ' Get pending requests count
            Dim pendingRequests As Integer = 0
            Try
                Dim dtPending As DataTable = modDB.GetStaffRequests(SessionContext.CurrentUserID.Value, "Pending", "", Nothing, Nothing)
                If dtPending IsNot Nothing Then
                    pendingRequests = dtPending.Rows.Count
                End If
            Catch
            End Try

            ' Get borrowed items count
            Dim borrowedItems As Integer = 0
            Try
                Dim dtBorrowed As DataTable = modDB.GetStaffBorrowedItems(SessionContext.CurrentUserID.Value, False)
                If dtBorrowed IsNot Nothing Then
                    borrowedItems = dtBorrowed.Rows.Count
                End If
            Catch
            End Try

            ' Update labels if they exist
            If Label5 IsNot Nothing Then
                Label5.Text = pendingRequests.ToString()
            End If
            If Label3 IsNot Nothing Then
                Label3.Text = borrowedItems.ToString()
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("UpdateDashboardSummary Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        ' --- This code expands the sidebar ---
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If

        ' --- This code changes the active button color ---
        SetActiveButton(btnProfile)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New frmProfile())
    End Sub



    Private Sub btnViewInventory_Click(sender As Object, e As EventArgs) Handles btnSupplyInventory.Click
        LoadUserControl(New SupplyInventory)
    End Sub

    Private Sub btnBorrowedItem_Click(sender As Object, e As EventArgs) Handles btnBorrowedItem.Click
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If

        ' --- This code changes the active button color ---
        SetActiveButton(btnBorrowedItem)

        ' Load borrowed items user control
        Dim borrowedItemControl As New frmBorrowedItem()
        pnlFormLoader.Controls.Clear()
        borrowedItemControl.Dock = DockStyle.Fill
        pnlFormLoader.Controls.Add(borrowedItemControl)
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs)
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If

        ' --- This code changes the active button color ---


        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New frmReports())

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim logout As New Form1()
        logout.Show()   ' Show the register form
        Me.Hide()            ' Hide current login form instead of closing it
    End Sub

    ' This code is in your StaffDashboard.vb
    ' This sub will load any form you give it into your panel
    Private Sub loadFormIntoPanel(ByVal formToLoad As Form)
        ' Clear any other form out of the panel
        If pnlFormLoader.Controls.Count > 0 Then
            pnlFormLoader.Controls.Clear()
        End If

        ' --- Setup the new form ---
        formToLoad.TopLevel = False  ' This is key for nesting
        formToLoad.Dock = DockStyle.Fill ' Make it fill the panel

        ' --- Add the new form to the panel ---
        pnlFormLoader.Controls.Add(formToLoad)
        pnlFormLoader.Tag = formToLoad
        formToLoad.Show() ' Show the form

        ' --- Show the panel ---
        pnlFormLoader.Visible = True
        pnlFormLoader.BringToFront() ' Make sure it's on top of pnlMain
    End Sub

    ' ----------------------
    ' Load UserControl into Main Panel
    ' ----------------------
    Public Sub LoadUserControl(uc As UserControl)
        Try
            ' Clear previous controls
            pnlFormLoader.Controls.Clear()


            ' Add new UserControl
            pnlFormLoader.Controls.Add(uc)
            uc.Dock = DockStyle.Fill
            uc.BringToFront()
            uc.Focus()

            ' Debug info (optional)
            Debug.WriteLine("Loaded UC: " & uc.Name)
            Debug.WriteLine("Panel Size: " & pnlFormLoader.ClientSize.ToString())
            Debug.WriteLine("UC Size: " & uc.Size.ToString())

        Catch ex As Exception
            MessageBox.Show("Error loading UserControl: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvHistory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub btnMyRequest_Click(sender As Object, e As EventArgs) Handles btnMyRequest.Click
        If Not isSidebarExpanded Then
            ToggleSidebar()
        End If

        ' --- This code changes the active button color ---
        SetActiveButton(btnMyRequest)

        ' --- THIS IS THE NEW CODE ---
        ' Load your new profile form
        loadFormIntoPanel(New frmRequest())
    End Sub

    Private Sub btnMaintenanceReq_Click(sender As Object, e As EventArgs) Handles btnMaintenanceReq.Click
        LoadUserControl(New MaintenanceRequest())
    End Sub

    Private Sub btnPropertyInventory_Click(sender As Object, e As EventArgs) Handles btnPropertyInventory.Click
        LoadUserControl(New PropertyInventory)
    End Sub

    Private Sub pnlFormLoader_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class