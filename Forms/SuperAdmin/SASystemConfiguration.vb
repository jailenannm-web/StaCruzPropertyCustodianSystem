Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class SASystemConfiguration

    Private Enum ConfigModule
        DatabaseSettings
        CategoryStatus
        UserRoles
        SystemLogs
    End Enum

    Private Structure DbSettings
        Public Host As String
        Public Port As Integer
        Public Username As String
        Public Password As String
        Public DatabaseName As String
    End Structure

    Private ReadOnly moduleControls As New Dictionary(Of ConfigModule, List(Of Control))()
    Private currentModule As ConfigModule = ConfigModule.DatabaseSettings
    Private currentDbSettings As DbSettings = GetDefaultDbSettings()
    Private ReadOnly fallbackSettingsPath As String = Path.Combine(Application.StartupPath, "system_config.local")
    Private isDatabaseOnline As Boolean = False

    ' Dynamic UI references
    Private lblStatusIndicator As Label
    Private btnDeleteCategory As Button
    Private btnRefreshCategories As Button
    Private grpStatusPanel As GroupBox
    Private txtStatusName As TextBox
    Private cmbStatusType As ComboBox
    Private chkStatusActive As CheckBox
    Private btnSaveStatus As Button
    Private btnDeleteStatus As Button
    Private dgvStatuses As DataGridView
    Private grpRoleAssignment As GroupBox
    Private cmbRoleSelector As ComboBox
    Private cmbRoleUsers As ComboBox
    Private btnAssignRole As Button
    Private btnDeactivateRole As Button
    Private btnFilterLogs As Button
    Private btnRefreshLogs As Button

    Private categoryTable As DataTable
    Private statusTable As DataTable
    Private roleTable As DataTable
    Private logTable As DataTable

    Private editingCategoryId As Integer? = Nothing
    Private editingStatusId As Integer? = Nothing
    Private editingRoleId As Integer? = Nothing

    ' Side panel navigation controls
    Private pnlSideMenu As Panel
    Private btnNavDatabase As Button
    Private btnNavCategories As Button
    Private btnNavStatus As Button
    Private btnNavUserRoles As Button
    Private btnNavLogs As Button
    
    ' Content panels for each section
    Private pnlDatabaseSettings As Panel
    Private pnlCategoryManagement As Panel
    Private pnlStatusManagement As Panel
    Private pnlUserRoles As Panel
    Private pnlSystemLogs As Panel

    Private Sub SASystemConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SuspendLayout()
            SetupSideNavigationPanel()
            SetupContentPanels()
            SetupStatusIndicator()
            InitializeDynamicControls()
            ResumeLayout()

            LoadFallbackSettings()
            LoadAllModulesData()
            ShowPanel(pnlDatabaseSettings) ' Show database settings by default
            ShowModuleStatus("System Configuration ready.", False)
        Catch ex As Exception
            ResumeLayout()
            ShowModuleStatus("Initialization failed: " & ex.Message, True)
            LogRecoveryEvent("Initialization", ex)
        End Try
    End Sub
    
    Private Sub SetupSideNavigationPanel()
        ' Create side menu panel
        pnlSideMenu = New Panel() With {
            .BackColor = Color.FromArgb(30, 30, 30),
            .Dock = DockStyle.Left,
            .Width = 250,
            .Padding = New Padding(10)
        }
        Controls.Add(pnlSideMenu)
        pnlSideMenu.BringToFront()
        
        ' Title label
        Dim lblMenuTitle As New Label() With {
            .Text = "Configuration Menu",
            .Font = New Font("Poppins", 12, FontStyle.Bold),
            .ForeColor = Color.White,
            .AutoSize = False,
            .Height = 40,
            .Width = 230,
            .Location = New Point(10, 20),
            .TextAlign = ContentAlignment.MiddleLeft
        }
        pnlSideMenu.Controls.Add(lblMenuTitle)
        
        ' Create navigation buttons
        Dim yPosition As Integer = 80
        
        btnNavDatabase = CreateNavButton("Database Settings", yPosition)
        AddHandler btnNavDatabase.Click, Sub() ShowPanel(pnlDatabaseSettings)
        pnlSideMenu.Controls.Add(btnNavDatabase)
        yPosition += 60
        
        btnNavCategories = CreateNavButton("Category Management", yPosition)
        AddHandler btnNavCategories.Click, Sub() ShowPanel(pnlCategoryManagement)
        pnlSideMenu.Controls.Add(btnNavCategories)
        yPosition += 60
        
        btnNavStatus = CreateNavButton("Status Management", yPosition)
        AddHandler btnNavStatus.Click, Sub() ShowPanel(pnlStatusManagement)
        pnlSideMenu.Controls.Add(btnNavStatus)
        yPosition += 60
        
        btnNavUserRoles = CreateNavButton("User Roles", yPosition)
        AddHandler btnNavUserRoles.Click, Sub() ShowPanel(pnlUserRoles)
        pnlSideMenu.Controls.Add(btnNavUserRoles)
        yPosition += 60
        
        btnNavLogs = CreateNavButton("System Logs", yPosition)
        AddHandler btnNavLogs.Click, Sub() ShowPanel(pnlSystemLogs)
        pnlSideMenu.Controls.Add(btnNavLogs)
    End Sub
    
    Private Function CreateNavButton(text As String, yPos As Integer) As Button
        Dim btn As New Button() With {
            .Text = text,
            .Font = New Font("Poppins", 10, FontStyle.Regular),
            .ForeColor = Color.White,
            .BackColor = Color.FromArgb(50, 50, 50),
            .FlatStyle = FlatStyle.Flat,
            .Width = 230,
            .Height = 50,
            .Location = New Point(10, yPos),
            .TextAlign = ContentAlignment.MiddleLeft,
            .Padding = New Padding(15, 0, 0, 0),
            .Cursor = Cursors.Hand
        }
        btn.FlatAppearance.BorderSize = 0
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(27, 60, 83)
        btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 45, 65)
        Return btn
    End Function
    
    Private Sub SetupContentPanels()
        Dim contentX As Integer = 260 ' Start after side menu
        Dim contentY As Integer = 100
        Dim contentWidth As Integer = Me.ClientSize.Width - 270
        Dim contentHeight As Integer = Me.ClientSize.Height - 110
        
        ' Database Settings Panel
        pnlDatabaseSettings = New Panel() With {
            .Location = New Point(contentX, contentY),
            .Size = New Size(contentWidth, contentHeight),
            .BackColor = Color.White,
            .Visible = False,
            .AutoScroll = True
        }
        Controls.Add(pnlDatabaseSettings)
        
        ' Category Management Panel
        pnlCategoryManagement = New Panel() With {
            .Location = New Point(contentX, contentY),
            .Size = New Size(contentWidth, contentHeight),
            .BackColor = Color.White,
            .Visible = False,
            .AutoScroll = True
        }
        Controls.Add(pnlCategoryManagement)
        
        ' Status Management Panel
        pnlStatusManagement = New Panel() With {
            .Location = New Point(contentX, contentY),
            .Size = New Size(contentWidth, contentHeight),
            .BackColor = Color.White,
            .Visible = False,
            .AutoScroll = True
        }
        Controls.Add(pnlStatusManagement)
        
        ' User Roles Panel
        pnlUserRoles = New Panel() With {
            .Location = New Point(contentX, contentY),
            .Size = New Size(contentWidth, contentHeight),
            .BackColor = Color.White,
            .Visible = False,
            .AutoScroll = True
        }
        Controls.Add(pnlUserRoles)
        
        ' System Logs Panel
        pnlSystemLogs = New Panel() With {
            .Location = New Point(contentX, contentY),
            .Size = New Size(contentWidth, contentHeight),
            .BackColor = Color.White,
            .Visible = False,
            .AutoScroll = True
        }
        Controls.Add(pnlSystemLogs)
        
        ' Move existing controls to appropriate panels
        MoveControlsToPanels()
    End Sub
    
    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all content panels
        pnlDatabaseSettings.Visible = False
        pnlCategoryManagement.Visible = False
        pnlStatusManagement.Visible = False
        pnlUserRoles.Visible = False
        pnlSystemLogs.Visible = False
        
        ' Reset button colors
        ResetNavButtonColors()
        
        ' Show selected panel and highlight button
        panelToShow.Visible = True
        panelToShow.BringToFront()
        
        ' Highlight active button
        If panelToShow Is pnlDatabaseSettings Then
            HighlightButton(btnNavDatabase)
        ElseIf panelToShow Is pnlCategoryManagement Then
            HighlightButton(btnNavCategories)
        ElseIf panelToShow Is pnlStatusManagement Then
            HighlightButton(btnNavStatus)
        ElseIf panelToShow Is pnlUserRoles Then
            HighlightButton(btnNavUserRoles)
        ElseIf panelToShow Is pnlSystemLogs Then
            HighlightButton(btnNavLogs)
        End If
    End Sub
    
    Private Sub ResetNavButtonColors()
        For Each btn In {btnNavDatabase, btnNavCategories, btnNavStatus, btnNavUserRoles, btnNavLogs}
            If btn IsNot Nothing Then
                btn.BackColor = Color.FromArgb(50, 50, 50)
                btn.Font = New Font("Poppins", 10, FontStyle.Regular)
            End If
        Next
    End Sub
    
    Private Sub HighlightButton(btn As Button)
        If btn IsNot Nothing Then
            btn.BackColor = Color.FromArgb(27, 60, 83)
            btn.Font = New Font("Poppins", 10, FontStyle.Bold)
        End If
    End Sub
    
    Private Sub MoveControlsToPanels()
        Try
            ' Move database connection controls to pnlDatabaseSettings
            If txtHost IsNot Nothing Then txtHost.Parent = pnlDatabaseSettings : txtHost.Location = New Point(200, 50)
            If txtPort IsNot Nothing Then txtPort.Parent = pnlDatabaseSettings : txtPort.Location = New Point(200, 100)
            If txtDBName IsNot Nothing Then txtDBName.Parent = pnlDatabaseSettings : txtDBName.Location = New Point(200, 150)
            If txtUser IsNot Nothing Then txtUser.Parent = pnlDatabaseSettings : txtUser.Location = New Point(200, 200)
            If txtPassword IsNot Nothing Then txtPassword.Parent = pnlDatabaseSettings : txtPassword.Location = New Point(200, 250)
            If btnTestConn IsNot Nothing Then btnTestConn.Parent = pnlDatabaseSettings : btnTestConn.Location = New Point(200, 310)
            If btnSaveConn IsNot Nothing Then btnSaveConn.Parent = pnlDatabaseSettings : btnSaveConn.Location = New Point(350, 310)
            
            ' Move corresponding labels
            If DBHost IsNot Nothing Then DBHost.Parent = pnlDatabaseSettings : DBHost.Location = New Point(50, 55)
            If port IsNot Nothing Then port.Parent = pnlDatabaseSettings : port.Location = New Point(50, 105)
            If Label5 IsNot Nothing Then Label5.Parent = pnlDatabaseSettings : Label5.Location = New Point(50, 155)
            If Label6 IsNot Nothing Then Label6.Parent = pnlDatabaseSettings : Label6.Location = New Point(50, 205)
            If Label7 IsNot Nothing Then Label7.Parent = pnlDatabaseSettings : Label7.Location = New Point(50, 255)
            
            ' Add title to database panel
            Dim lblDbTitle As New Label() With {
                .Text = "Database Connection Settings",
                .Font = New Font("Poppins", 14, FontStyle.Bold),
                .Location = New Point(20, 10),
                .AutoSize = True
            }
            pnlDatabaseSettings.Controls.Add(lblDbTitle)
            
            ' Move category/status controls to their respective panels
            If comboCategoris IsNot Nothing Then comboCategoris.Parent = pnlCategoryManagement : comboCategoris.Location = New Point(50, 50)
            If combostatus IsNot Nothing Then combostatus.Parent = pnlStatusManagement : combostatus.Location = New Point(50, 50)
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[SASystemConfig] Error moving controls: " & ex.Message)
        End Try
    End Sub

#Region "Initialization Helpers"

    Private Sub SetupStatusIndicator()
        lblStatusIndicator = New Label() With {
            .AutoSize = False,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Font = New Font("Segoe UI", 9.0!, FontStyle.Bold),
            .ForeColor = Color.White,
            .BackColor = Color.FromArgb(64, 64, 64),
            .Dock = DockStyle.Bottom,
            .Height = 30,
            .Text = "Loading configuration..."
        }
        Controls.Add(lblStatusIndicator)
        lblStatusIndicator.BringToFront()
    End Sub

    Private Sub InitializeDynamicControls()
        ' Initialize Status Management Controls
        dgvStatuses = New DataGridView() With {
            .Location = New Point(420, 650),
            .Size = New Size(850, 300),
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }
        Controls.Add(dgvStatuses)
        AddHandler dgvStatuses.SelectionChanged, AddressOf dgvStatuses_SelectionChanged

        ' Initialize Role Management Controls
        cmbRoleSelector = New ComboBox() With {
            .Location = New Point(420, 250),
            .Size = New Size(300, 25),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        Controls.Add(cmbRoleSelector)

        cmbRoleUsers = New ComboBox() With {
            .Location = New Point(750, 250),
            .Size = New Size(300, 25),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        Controls.Add(cmbRoleUsers)

        ' Initialize Status Panel Controls
        grpStatusPanel = New GroupBox() With {
            .Text = "Status Management",
            .Location = New Point(420, 400),
            .Size = New Size(850, 220),
            .Font = New Font("Poppins", 9.0!, FontStyle.Bold)
        }

        txtStatusName = New TextBox() With {
            .Location = New Point(120, 30),
            .Size = New Size(250, 25)
        }
        grpStatusPanel.Controls.Add(txtStatusName)

        Dim lblStatusName As New Label() With {
            .Text = "Status Name:",
            .Location = New Point(20, 33),
            .AutoSize = True,
            .Font = New Font("Poppins", 8.0!)
        }
        grpStatusPanel.Controls.Add(lblStatusName)

        cmbStatusType = New ComboBox() With {
            .Location = New Point(120, 70),
            .Size = New Size(250, 25),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cmbStatusType.Items.AddRange(New String() {"property", "supply", "maintenance", "request"})
        If cmbStatusType.Items.Count > 0 Then cmbStatusType.SelectedIndex = 0
        grpStatusPanel.Controls.Add(cmbStatusType)

        Dim lblStatusType As New Label() With {
            .Text = "Status Type:",
            .Location = New Point(20, 73),
            .AutoSize = True,
            .Font = New Font("Poppins", 8.0!)
        }
        grpStatusPanel.Controls.Add(lblStatusType)

        chkStatusActive = New CheckBox() With {
            .Text = "Active",
            .Location = New Point(120, 110),
            .Checked = True,
            .Font = New Font("Poppins", 8.0!)
        }
        grpStatusPanel.Controls.Add(chkStatusActive)

        btnSaveStatus = New Button() With {
            .Text = "Save Status",
            .Location = New Point(120, 150),
            .Size = New Size(120, 40),
            .BackColor = Color.FromArgb(27, 60, 83),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Poppins", 8.0!, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        AddHandler btnSaveStatus.Click, AddressOf btnSaveStatus_Click
        grpStatusPanel.Controls.Add(btnSaveStatus)

        btnDeleteStatus = New Button() With {
            .Text = "Delete Status",
            .Location = New Point(250, 150),
            .Size = New Size(120, 40),
            .BackColor = Color.Firebrick,
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Poppins", 8.0!, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        AddHandler btnDeleteStatus.Click, AddressOf btnDeleteStatus_Click
        grpStatusPanel.Controls.Add(btnDeleteStatus)

        Controls.Add(grpStatusPanel)

        ' Initialize Role Assignment Controls
        grpRoleAssignment = New GroupBox() With {
            .Text = "Role Assignment",
            .Location = New Point(1300, 400),
            .Size = New Size(600, 220),
            .Font = New Font("Poppins", 9.0!, FontStyle.Bold)
        }

        Dim lblRole As New Label() With {
            .Text = "Select Role:",
            .Location = New Point(20, 40),
            .AutoSize = True,
            .Font = New Font("Poppins", 8.0!)
        }
        grpRoleAssignment.Controls.Add(lblRole)

        Dim cmbRoleSelectorInGroup As New ComboBox() With {
            .Location = New Point(120, 37),
            .Size = New Size(300, 25),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cmbRoleSelector = cmbRoleSelectorInGroup
        grpRoleAssignment.Controls.Add(cmbRoleSelectorInGroup)

        Dim lblUser As New Label() With {
            .Text = "Select User:",
            .Location = New Point(20, 80),
            .AutoSize = True,
            .Font = New Font("Poppins", 8.0!)
        }
        grpRoleAssignment.Controls.Add(lblUser)

        Dim cmbRoleUsersInGroup As New ComboBox() With {
            .Location = New Point(120, 77),
            .Size = New Size(300, 25),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cmbRoleUsers = cmbRoleUsersInGroup
        grpRoleAssignment.Controls.Add(cmbRoleUsersInGroup)

        btnAssignRole = New Button() With {
            .Text = "Assign Role",
            .Location = New Point(120, 120),
            .Size = New Size(120, 40),
            .BackColor = Color.FromArgb(27, 60, 83),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Poppins", 8.0!, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        AddHandler btnAssignRole.Click, AddressOf btnAssignRole_Click
        grpRoleAssignment.Controls.Add(btnAssignRole)

        btnDeactivateRole = New Button() With {
            .Text = "Toggle Role Status",
            .Location = New Point(250, 120),
            .Size = New Size(150, 40),
            .BackColor = Color.DarkOrange,
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Poppins", 8.0!, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        AddHandler btnDeactivateRole.Click, AddressOf btnDeactivateRole_Click
        grpRoleAssignment.Controls.Add(btnDeactivateRole)

        Controls.Add(grpRoleAssignment)
    End Sub


#End Region

#Region "Navigation"

    Private Sub btnCategory_Click(sender As Object, e As EventArgs)
        LoadCategories()
        LoadStatuses()
    End Sub

    Private Sub btnRoles_Click(sender As Object, e As EventArgs)
        LoadRoleLookups()
        LoadUsersForAssignment()
    End Sub


#End Region

#Region "DB Settings"

    Private Sub LoadAllModulesData()
        LoadDbSettings()
        EnsureDatabaseInfrastructure()
        LoadCategories()
        LoadStatuses()
        LoadRoleLookups()
        LoadUsersForAssignment()
    End Sub

    Private Sub LoadDbSettings()
        Dim fallback = LoadFallbackDbSettings()
        currentDbSettings = fallback
        PopulateDbSettingsForm(currentDbSettings)

        Try
            Using conn = GetModuleConnection()
                If Not TryOpenModuleConnection(conn, False) Then
                    ShowModuleStatus("Loaded fallback database settings. Database offline.", True)
                    Return
                End If

                EnsureSystemConfigKeys(conn)

                Dim query = "SELECT config_key, config_value FROM system_config WHERE config_key IN ('db_host','db_port','db_username','db_password','db_name')"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader = cmd.ExecuteReader()
                        Dim settings As DbSettings = currentDbSettings
                        While reader.Read()
                            Dim key = reader.GetString("config_key")
                            Dim value = reader.GetString("config_value")
                            Select Case key
                                Case "db_host"
                                    settings.Host = value
                                Case "db_port"
                                    Dim p As Integer
                                    If Integer.TryParse(value, p) Then settings.Port = p
                                Case "db_username"
                                    settings.Username = value
                                Case "db_password"
                                    settings.Password = value
                                Case "db_name"
                                    settings.DatabaseName = value
                            End Select
                        End While
                        currentDbSettings = settings
                    End Using
                End Using

                PopulateDbSettingsForm(currentDbSettings)
                SaveFallbackDbSettings(currentDbSettings)
                ShowModuleStatus("Database settings loaded from system_config.", False)
            End Using
        Catch ex As Exception
            ShowModuleStatus("Unable to load DB settings from database. Using fallback values.", True)
            LogRecoveryEvent("LoadDbSettings", ex)
        End Try
    End Sub

    Private Sub PopulateDbSettingsForm(settings As DbSettings)
        txtHost.Text = settings.Host
        txtPort.Text = settings.Port.ToString()
        txtUser.Text = settings.Username
        txtPassword.Text = settings.Password
        txtDBName.Text = settings.DatabaseName
    End Sub

    Private Function GetDbSettingsFromForm() As DbSettings
        Dim settings = currentDbSettings
        settings.Host = txtHost.Text.Trim()
        Dim portValue As Integer
        If Integer.TryParse(txtPort.Text.Trim(), portValue) Then
            settings.Port = portValue
        End If
        settings.Username = txtUser.Text.Trim()
        settings.Password = txtPassword.Text
        settings.DatabaseName = txtDBName.Text.Trim()
        Return settings
    End Function

    Private Sub btnTestConn_Click(sender As Object, e As EventArgs) Handles btnTestConn.Click
        Dim settings = GetDbSettingsFromForm()
        Try
            Using conn As New MySqlConnection(BuildConnectionString(settings))
                conn.Open()
                MessageBox.Show("Connection successful.", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Connection test failed: " & ex.Message, "Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSaveConn_Click(sender As Object, e As EventArgs) Handles btnSaveConn.Click
        Dim settings = GetDbSettingsFromForm()
        If Not ValidateDbSettings(settings) Then Return

        SaveFallbackDbSettings(settings)
        UpdateAppConfigConnectionString(settings)

        Try
            Using conn As New MySqlConnection(BuildConnectionString(settings))
                conn.Open()
                PersistSettingsToDatabase(settings, conn)
                isDatabaseOnline = True
                MessageBox.Show("Database settings saved and connection verified.", "System Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            isDatabaseOnline = False
            MessageBox.Show("Settings saved locally but database is still unreachable: " & ex.Message, "System Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LogRecoveryEvent("SaveConnection", ex)
        End Try

        currentDbSettings = settings
    End Sub

    Private Function ValidateDbSettings(settings As DbSettings) As Boolean
        If String.IsNullOrWhiteSpace(settings.Host) OrElse
           settings.Port <= 0 OrElse settings.Port > 65535 OrElse
           String.IsNullOrWhiteSpace(settings.Username) OrElse
           String.IsNullOrWhiteSpace(settings.DatabaseName) Then
            MessageBox.Show("Please provide valid host, port, username, and database name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub PersistSettingsToDatabase(settings As DbSettings, conn As MySqlConnection)
        Dim upsert = "INSERT INTO system_config (config_key, config_value, config_type, description) " &
                     "VALUES (@key, @value, 'connection', @desc) " &
                     "ON DUPLICATE KEY UPDATE config_value = VALUES(config_value), updated_at = CURRENT_TIMESTAMP"
        Dim entries = New Dictionary(Of String, Tuple(Of String, String)) From {
            {"db_host", Tuple.Create(settings.Host, "Database host name or IP")},
            {"db_port", Tuple.Create(settings.Port.ToString(), "Database port")},
            {"db_username", Tuple.Create(settings.Username, "Database username")},
            {"db_password", Tuple.Create(settings.Password, "Database password")},
            {"db_name", Tuple.Create(settings.DatabaseName, "Database name")}
        }

        For Each entry As KeyValuePair(Of String, Tuple(Of String, String)) In entries
            Using cmd As New MySqlCommand(upsert, conn)
                cmd.Parameters.AddWithValue("@key", entry.Key)
                cmd.Parameters.AddWithValue("@value", entry.Value.Item1)
                cmd.Parameters.AddWithValue("@desc", entry.Value.Item2)
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub SaveFallbackDbSettings(settings As DbSettings)
        Try
            Dim builder = New StringBuilder()
            builder.AppendLine("host=" & settings.Host)
            builder.AppendLine("port=" & settings.Port.ToString())
            builder.AppendLine("username=" & settings.Username)
            builder.AppendLine("password=" & settings.Password)
            builder.AppendLine("database=" & settings.DatabaseName)
            File.WriteAllText(fallbackSettingsPath, builder.ToString())
        Catch ex As Exception
            LogRecoveryEvent("SaveFallback", ex)
        End Try
    End Sub

    Private Function LoadFallbackDbSettings() As DbSettings
        Dim settings = GetDefaultDbSettings()
        If Not File.Exists(fallbackSettingsPath) Then Return settings

        Try
            For Each line In File.ReadAllLines(fallbackSettingsPath)
                If String.IsNullOrWhiteSpace(line) OrElse Not line.Contains("=") Then Continue For
                Dim parts = line.Split({"="c}, 2, StringSplitOptions.None)
                Dim key = parts(0).Trim().ToLowerInvariant()
                Dim value = parts(1).Trim()
                Select Case key
                    Case "host"
                        settings.Host = value
                    Case "port"
                        Dim p As Integer
                        If Integer.TryParse(value, p) Then settings.Port = p
                    Case "username"
                        settings.Username = value
                    Case "password"
                        settings.Password = value
                    Case "database"
                        settings.DatabaseName = value
                End Select
            Next
        Catch ex As Exception
            LogRecoveryEvent("LoadFallback", ex)
        End Try

        Return settings
    End Function

    Private Shared Function GetDefaultDbSettings() As DbSettings
        Return New DbSettings With {
            .Host = "localhost",
            .Port = 3306,
            .Username = "root",
            .Password = "",
            .DatabaseName = "teamcruzim"
        }
    End Function

    Private Function BuildConnectionString(settings As DbSettings) As String
        Dim builder As New MySqlConnectionStringBuilder() With {
            .Server = settings.Host,
            .Port = CUInt(Math.Max(1, settings.Port)),
            .UserID = settings.Username,
            .Password = settings.Password,
            .Database = settings.DatabaseName,
            .SslMode = MySqlSslMode.None,
            .AllowZeroDateTime = True,
            .ConvertZeroDateTime = True,
            .AllowUserVariables = True,
            .ConnectionTimeout = 10,
            .DefaultCommandTimeout = 30,
            .PersistSecurityInfo = True
        }
        builder("AllowPublicKeyRetrieval") = "True"
        builder("AllowLoadLocalInfile") = "False"
        builder("Replication") = "False"
        Return builder.ConnectionString
    End Function

    Private Function GetModuleConnection() As MySqlConnection
        Return New MySqlConnection(BuildConnectionString(currentDbSettings))
    End Function

    Private Function TryOpenModuleConnection(conn As MySqlConnection, Optional showError As Boolean = True) As Boolean
        Try
            If conn.State <> ConnectionState.Open Then conn.Open()
            isDatabaseOnline = True
            Return True
        Catch ex As Exception
            isDatabaseOnline = False
            If showError Then
                ShowModuleStatus("Database offline: " & ex.Message, True)
            End If
            Return False
        End Try
    End Function

    Private Sub UpdateAppConfigConnectionString(settings As DbSettings)
        Try
            Dim config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim section = CType(config.ConnectionStrings, ConnectionStringsSection)
            If section IsNot Nothing AndAlso section.ConnectionStrings("MySQLConnection") IsNot Nothing Then
                section.ConnectionStrings("MySQLConnection").ConnectionString = BuildConnectionString(settings)
                config.Save(ConfigurationSaveMode.Modified)
                ConfigurationManager.RefreshSection("connectionStrings")
            End If
        Catch ex As Exception
            LogRecoveryEvent("UpdateAppConfig", ex)
        End Try
    End Sub

#End Region

#Region "Category Management"

    Private Sub LoadCategories()
        Try
            Using conn = GetModuleConnection()
                If Not TryOpenModuleConnection(conn) Then
                    Return
                End If
                Dim query = "SELECT category_id, category_name, category_type, description, status FROM categories ORDER BY category_name"
                Using adapter As New MySqlDataAdapter(query, conn)
                    categoryTable = New DataTable()
                    adapter.Fill(categoryTable)
                End Using
            End Using
            ApplyCategoryFilters()
        Catch ex As Exception
            ShowModuleStatus("Unable to load categories: " & ex.Message, True)
            LogRecoveryEvent("LoadCategories", ex)
        End Try
    End Sub




    Private Sub btnDeleteCategory_Click(sender As Object, e As EventArgs)
        If Not editingCategoryId.HasValue Then
            MessageBox.Show("Select a category to delete.", "Category", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show("Delete selected category?", "Category", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn = GetModuleConnection()
                If Not TryOpenModuleConnection(conn) Then Return
                Using cmd As New MySqlCommand("DELETE FROM categories WHERE category_id=@id", conn)
                    cmd.Parameters.AddWithValue("@id", editingCategoryId.Value)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            ShowModuleStatus("Category deleted.", False)
            LoadCategories()
        Catch ex As Exception
            ShowModuleStatus("Unable to delete category: " & ex.Message, True)
            LogRecoveryEvent("DeleteCategory", ex)
        End Try
    End Sub

    Private Sub btnRefreshCategories_Click(sender As Object, e As EventArgs)
        LoadCategories()
        LoadStatuses()
    End Sub

    Private Function ValidateCategoryInputs(name As String, typeValue As String) As Boolean
        If String.IsNullOrWhiteSpace(name) Then
            MessageBox.Show("Category name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrWhiteSpace(typeValue) Then
            MessageBox.Show("Category type is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub comboCategoris_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboCategoris.SelectedIndexChanged
        ApplyCategoryFilters()
    End Sub

    Private Sub combostatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combostatus.SelectedIndexChanged
        ApplyCategoryFilters()
    End Sub

    Private Sub ApplyCategoryFilters()
        If categoryTable Is Nothing Then Return
        Dim filters As New List(Of String)
        If comboCategoris.SelectedIndex > 0 Then
            filters.Add(String.Format("category_type = '{0}'", comboCategoris.SelectedItem.ToString().Replace("'", "''")))
        End If
        If combostatus.SelectedIndex > 0 Then
            filters.Add(String.Format("status = '{0}'", combostatus.SelectedItem.ToString().Replace("'", "''")))
        End If
        categoryTable.DefaultView.RowFilter = String.Join(" AND ", filters)
    End Sub

#End Region

#Region "Status Management"

    Private Sub LoadStatuses()
        Try
            If dgvStatuses Is Nothing Then
                LogRecoveryEvent("LoadStatuses", New Exception("dgvStatuses not initialized"))
                Return
            End If

            Using conn = GetModuleConnection()
                If Not TryOpenModuleConnection(conn) Then
                    dgvStatuses.DataSource = Nothing
                    ShowModuleStatus("Database connection unavailable", True)
                    Return
                End If
                
                ' Check if category_statuses table exists
                Dim tableExists As Boolean = False
                Using cmdCheck As New MySqlCommand("SHOW TABLES LIKE 'category_statuses'", conn)
                    Using reader = cmdCheck.ExecuteReader()
                        tableExists = reader.HasRows
                    End Using
                End Using
                
                If Not tableExists Then
                    ShowModuleStatus("Status table not found. Please run database setup script.", True)
                    dgvStatuses.DataSource = Nothing
                    Return
                End If
                
                Dim query = "SELECT status_id, status_name, status_type, IF(is_active=1,'Yes','No') AS is_active FROM category_statuses ORDER BY status_type, status_name"
                Using adapter As New MySqlDataAdapter(query, conn)
                    statusTable = New DataTable()
                    adapter.Fill(statusTable)
                End Using
            End Using
            dgvStatuses.DataSource = statusTable
            ShowModuleStatus("Statuses loaded successfully", False)
        Catch ex As Exception
            ShowModuleStatus("Unable to load statuses: " & ex.Message, True)
            LogRecoveryEvent("LoadStatuses", ex)
            dgvStatuses.DataSource = Nothing
        End Try
    End Sub

    Private Sub btnSaveStatus_Click(sender As Object, e As EventArgs)
        Dim name = txtStatusName.Text.Trim()
        Dim typeValue = If(cmbStatusType.SelectedItem?.ToString(), String.Empty)
        Dim isActive = If(chkStatusActive.Checked, 1, 0)

        If String.IsNullOrWhiteSpace(name) OrElse String.IsNullOrWhiteSpace(typeValue) Then
            MessageBox.Show("Status name and type are required.", "Status Management", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim sql As String
        Dim message As String
        If editingStatusId.HasValue Then
            sql = "UPDATE category_statuses SET status_name=@name, status_type=@type, is_active=@active WHERE status_id=@id"
            message = "Status updated."
        Else
            sql = "INSERT INTO category_statuses (status_name, status_type, is_active) VALUES (@name, @type, @active)"
            message = "Status saved."
        End If

        Try
            Using conn = GetModuleConnection()
                If Not TryOpenModuleConnection(conn) Then
                    MessageBox.Show("Database connection unavailable.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                
                ' Check if table exists
                Dim tableExists As Boolean = False
                Using cmdCheck As New MySqlCommand("SHOW TABLES LIKE 'category_statuses'", conn)
                    Using reader = cmdCheck.ExecuteReader()
                        tableExists = reader.HasRows
                    End Using
                End Using
                
                If Not tableExists Then
                    MessageBox.Show("Status table not found. Run tmp_rovodev_missing_tables.sql first.", "Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@name", name)
                    cmd.Parameters.AddWithValue("@type", typeValue)
                    cmd.Parameters.AddWithValue("@active", isActive)
                    If editingStatusId.HasValue Then cmd.Parameters.AddWithValue("@id", editingStatusId.Value)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            ShowModuleStatus(message, False)
            ClearStatusFields()
            LoadStatuses()
        Catch ex As Exception
            ShowModuleStatus("Unable to save status: " & ex.Message, True)
            LogRecoveryEvent("SaveStatus", ex)
        End Try
    End Sub

    Private Sub btnDeleteStatus_Click(sender As Object, e As EventArgs)
        If Not editingStatusId.HasValue Then
            MessageBox.Show("Select a status to delete.", "Status Management", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show("Delete selected status?", "Status Management", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn = GetModuleConnection()
                If Not TryOpenModuleConnection(conn) Then
                    MessageBox.Show("Database connection unavailable.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                
                ' Check if table exists
                Dim tableExists As Boolean = False
                Using cmdCheck As New MySqlCommand("SHOW TABLES LIKE 'category_statuses'", conn)
                    Using reader = cmdCheck.ExecuteReader()
                        tableExists = reader.HasRows
                    End Using
                End Using
                
                If Not tableExists Then
                    MessageBox.Show("Status table not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                
                Using cmd As New MySqlCommand("DELETE FROM category_statuses WHERE status_id=@id", conn)
                    cmd.Parameters.AddWithValue("@id", editingStatusId.Value)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            ShowModuleStatus("Status removed.", False)
            ClearStatusFields()
            LoadStatuses()
        Catch ex As Exception
            ShowModuleStatus("Unable to delete status: " & ex.Message, True)
            LogRecoveryEvent("DeleteStatus", ex)
        End Try
    End Sub

    Private Sub dgvStatuses_SelectionChanged(sender As Object, e As EventArgs)
        If dgvStatuses.SelectedRows.Count = 0 Then
            editingStatusId = Nothing
            Return
        End If

        Dim row = dgvStatuses.SelectedRows(0)
        editingStatusId = CInt(row.Cells(0).Value)
        Dim statusNameValue As Object = row.Cells(1).Value
        Dim statusTypeValue As Object = row.Cells(2).Value
        Dim statusActiveValue As Object = row.Cells(3).Value
        txtStatusName.Text = If(statusNameValue IsNot Nothing, statusNameValue.ToString(), "")
        cmbStatusType.SelectedItem = If(statusTypeValue IsNot Nothing, statusTypeValue.ToString(), "")
        Dim activeValue As String = If(statusActiveValue IsNot Nothing, statusActiveValue.ToString(), "")
        chkStatusActive.Checked = String.Equals(activeValue, "Yes", StringComparison.OrdinalIgnoreCase)
    End Sub

    Private Sub ClearStatusFields()
        txtStatusName.Clear()
        If cmbStatusType.Items.Count > 0 Then cmbStatusType.SelectedIndex = 0
        chkStatusActive.Checked = True
        editingStatusId = Nothing
    End Sub

#End Region

#Region "User Roles"

    Private Sub btnDeactivateRole_Click(sender As Object, e As EventArgs)
        If Not editingRoleId.HasValue Then
            MessageBox.Show("Select a role first.", "Roles", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Using conn = GetModuleConnection()
                If Not TryOpenModuleConnection(conn) Then Return
                Using cmd As New MySqlCommand("UPDATE user_roles SET is_active = CASE WHEN is_active=1 THEN 0 ELSE 1 END WHERE role_id=@id", conn)
                    cmd.Parameters.AddWithValue("@id", editingRoleId.Value)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            ShowModuleStatus("Role status toggled.", False)
            LoadRoleLookups()
        Catch ex As Exception
            ShowModuleStatus("Unable to toggle role: " & ex.Message, True)
            LogRecoveryEvent("ToggleRole", ex)
        End Try
    End Sub

    Private Sub LoadRoleLookups()
        Try
            If cmbRoleSelector Is Nothing Then
                LogRecoveryEvent("LoadRoleLookups", New Exception("cmbRoleSelector not initialized"))
                Return
            End If

            Using conn = GetModuleConnection()
                If Not TryOpenModuleConnection(conn) Then
                    cmbRoleSelector.DataSource = Nothing
                    Return
                End If
                
                ' Check if user_roles table exists
                Dim tableExists As Boolean = False
                Using cmdCheck As New MySqlCommand("SHOW TABLES LIKE 'user_roles'", conn)
                    Using reader = cmdCheck.ExecuteReader()
                        tableExists = reader.HasRows
                    End Using
                End Using
                
                If Not tableExists Then
                    ' Use default roles from users table if user_roles doesn't exist
                    Dim items As New List(Of ComboBoxItem)
                    items.Add(New ComboBoxItem(1, "SuperAdmin"))
                    items.Add(New ComboBoxItem(2, "Admin"))
                    items.Add(New ComboBoxItem(3, "Custodian"))
                    items.Add(New ComboBoxItem(4, "Staff"))
                    cmbRoleSelector.DataSource = Nothing
                    cmbRoleSelector.DataSource = items
                    cmbRoleSelector.DisplayMember = "DisplayText"
                    cmbRoleSelector.ValueMember = "Key"
                    cmbRoleSelector.SelectedIndex = 0
                    Return
                End If
                
                Using cmd As New MySqlCommand("SELECT role_id, role_name FROM user_roles WHERE is_active=1 ORDER BY role_name", conn)
                    Using reader = cmd.ExecuteReader()
                        Dim items As New List(Of ComboBoxItem)
                        While reader.Read()
                            items.Add(New ComboBoxItem(reader.GetInt32("role_id"), reader.GetString("role_name")))
                        End While
                        cmbRoleSelector.DataSource = Nothing
                        cmbRoleSelector.DataSource = items
                        cmbRoleSelector.DisplayMember = "DisplayText"
                        cmbRoleSelector.ValueMember = "Key"
                        cmbRoleSelector.SelectedIndex = If(items.Count > 0, 0, -1)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            LogRecoveryEvent("LoadRoleLookups", ex)
            ' Fallback to default roles
            If cmbRoleSelector IsNot Nothing Then
                Dim items As New List(Of ComboBoxItem)
                items.Add(New ComboBoxItem(1, "SuperAdmin"))
                items.Add(New ComboBoxItem(2, "Admin"))
                items.Add(New ComboBoxItem(3, "Custodian"))
                items.Add(New ComboBoxItem(4, "Staff"))
                cmbRoleSelector.DataSource = items
                cmbRoleSelector.DisplayMember = "DisplayText"
                cmbRoleSelector.ValueMember = "Key"
                If items.Count > 0 Then cmbRoleSelector.SelectedIndex = 0
            End If
        End Try
    End Sub

    Private Sub LoadUsersForAssignment()
        Try
            If cmbRoleUsers Is Nothing Then
                LogRecoveryEvent("LoadUsersForAssignment", New Exception("cmbRoleUsers not initialized"))
                Return
            End If

            Using conn = GetModuleConnection()
                If Not TryOpenModuleConnection(conn) Then
                    cmbRoleUsers.DataSource = Nothing
                    Return
                End If
                Dim sql = "SELECT userId AS user_id, CONCAT(IFNULL(firstName,''),' ',IFNULL(lastName,'')) AS full_name FROM users ORDER BY full_name"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader = cmd.ExecuteReader()
                        Dim items As New List(Of ComboBoxItem)
                        While reader.Read()
                            items.Add(New ComboBoxItem(reader.GetInt32("user_id"), reader.GetString("full_name")))
                        End While
                        cmbRoleUsers.DataSource = Nothing
                        cmbRoleUsers.DataSource = items
                        cmbRoleUsers.DisplayMember = "DisplayText"
                        cmbRoleUsers.ValueMember = "Key"
                        cmbRoleUsers.SelectedIndex = If(items.Count > 0, 0, -1)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ShowModuleStatus("Unable to load users: " & ex.Message, True)
            LogRecoveryEvent("LoadUsers", ex)
        End Try
    End Sub

    Private Sub btnAssignRole_Click(sender As Object, e As EventArgs)
        If cmbRoleSelector.SelectedItem Is Nothing OrElse cmbRoleUsers.SelectedItem Is Nothing Then
            MessageBox.Show("Select both a role and a user.", "Roles", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim roleItem = CType(cmbRoleSelector.SelectedItem, ComboBoxItem)
        Dim userItem = CType(cmbRoleUsers.SelectedItem, ComboBoxItem)

        Try
            Using conn = GetModuleConnection()
                If Not TryOpenModuleConnection(conn) Then
                    MessageBox.Show("Database connection unavailable.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                
                ' Check if table exists
                Dim tableExists As Boolean = False
                Using cmdCheck As New MySqlCommand("SHOW TABLES LIKE 'user_role_assignments'", conn)
                    Using reader = cmdCheck.ExecuteReader()
                        tableExists = reader.HasRows
                    End Using
                End Using
                
                If Not tableExists Then
                    MessageBox.Show("Role assignment table not found. Run tmp_rovodev_missing_tables.sql first.", "Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                
                Dim sql = "INSERT INTO user_role_assignments (user_id, role_id) VALUES (@user, @role) " &
                          "ON DUPLICATE KEY UPDATE assigned_at = CURRENT_TIMESTAMP"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@user", userItem.Key)
                    cmd.Parameters.AddWithValue("@role", roleItem.Key)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            ShowModuleStatus("Role '" & roleItem.DisplayText & "' assigned to " & userItem.DisplayText & ".", False)
        Catch ex As Exception
            ShowModuleStatus("Unable to assign role: " & ex.Message, True)
            LogRecoveryEvent("AssignRole", ex)
        End Try
    End Sub

    Private Class ComboBoxItem
        Public ReadOnly Property Key As Integer
        Public ReadOnly Property DisplayText As String
        Public Sub New(id As Integer, text As String)
            Key = id
            DisplayText = text
        End Sub
        Public Overrides Function ToString() As String
            Return DisplayText
        End Function
    End Class

#End Region

#Region "Logs"

    Private Sub btnExportLogs_Click(sender As Object, e As EventArgs)
        If logTable Is Nothing OrElse logTable.Rows.Count = 0 Then
            MessageBox.Show("No logs to export.", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "CSV Files|*.csv"
            dialog.FileName = "system_logs_" & System.DateTime.Now.ToString("yyyyMMdd_HHmm") & ".csv"
            If dialog.ShowDialog() = DialogResult.OK Then
                ExportDataTableToCsv(logTable, dialog.FileName)
                MessageBox.Show("Logs exported successfully.", "Logs", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub ExportDataTableToCsv(table As DataTable, filePath As String)
        Try
            Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
                Dim headers = table.Columns.Cast(Of DataColumn)().Select(Function(c) QuoteCsvValue(c.ColumnName))
                writer.WriteLine(String.Join(",", headers))
                For Each row As DataRow In table.Rows
                    Dim values = row.ItemArray.Select(Function(value) QuoteCsvValue(Convert.ToString(value)))
                    writer.WriteLine(String.Join(",", values))
                Next
            End Using
        Catch ex As Exception
            LogRecoveryEvent("ExportLogs", ex)
        End Try
    End Sub

    Private Function QuoteCsvValue(value As String) As String
        If value Is Nothing Then value = String.Empty
        value = value.Replace("""", """""")
        Return """" & value & """"
    End Function

#End Region

#Region "Infrastructure & Utilities"

    Private Sub EnsureDatabaseInfrastructure()
        If Not isDatabaseOnline Then Return

        Try
            Using conn = GetModuleConnection()
                If Not TryOpenModuleConnection(conn) Then Return

                Dim ddlConfig = "CREATE TABLE IF NOT EXISTS system_config (" &
                                "config_id INT AUTO_INCREMENT PRIMARY KEY, " &
                                "config_key VARCHAR(100) NOT NULL UNIQUE, " &
                                "config_value TEXT, config_type VARCHAR(50), description TEXT, " &
                                "updated_by INT, updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)"
                ExecuteNonQuery(conn, ddlConfig)

                Dim ddlStatus = "CREATE TABLE IF NOT EXISTS category_statuses (" &
                                "status_id INT AUTO_INCREMENT PRIMARY KEY, status_name VARCHAR(100) NOT NULL UNIQUE, " &
                                "status_type VARCHAR(30) NOT NULL DEFAULT 'property', is_active TINYINT(1) DEFAULT 1, " &
                                "updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)"
                ExecuteNonQuery(conn, ddlStatus)

                Dim ddlRole = "CREATE TABLE IF NOT EXISTS user_roles (" &
                              "role_id INT AUTO_INCREMENT PRIMARY KEY, role_name VARCHAR(100) NOT NULL UNIQUE, " &
                              "can_inventory TINYINT(1) DEFAULT 0, can_maintenance TINYINT(1) DEFAULT 0, " &
                              "can_borrow TINYINT(1) DEFAULT 0, can_reports TINYINT(1) DEFAULT 0, is_active TINYINT(1) DEFAULT 1, " &
                              "created_at DATETIME DEFAULT CURRENT_TIMESTAMP)"
                ExecuteNonQuery(conn, ddlRole)

                Dim ddlAssignments = "CREATE TABLE IF NOT EXISTS user_role_assignments (" &
                                     "assignment_id INT AUTO_INCREMENT PRIMARY KEY, user_id INT NOT NULL, role_id INT NOT NULL, " &
                                     "assigned_at DATETIME DEFAULT CURRENT_TIMESTAMP, UNIQUE KEY uq_user_role (user_id, role_id))"
                ExecuteNonQuery(conn, ddlAssignments)
            End Using
        Catch ex As Exception
            LogRecoveryEvent("EnsureInfrastructure", ex)
        End Try
    End Sub

    Private Sub ExecuteNonQuery(conn As MySqlConnection, sql As String)
        Using cmd As New MySqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub EnsureSystemConfigKeys(conn As MySqlConnection)
        Dim sql = "INSERT INTO system_config (config_key, config_value, config_type, description) " &
                  "SELECT @key, @value, 'connection', @desc FROM DUAL WHERE NOT EXISTS (SELECT 1 FROM system_config WHERE config_key=@key)"
        Dim defaults = New Dictionary(Of String, Tuple(Of String, String)) From {
            {"db_host", Tuple.Create(currentDbSettings.Host, "Database host name or IP")},
            {"db_port", Tuple.Create(currentDbSettings.Port.ToString(), "Database port number")},
            {"db_username", Tuple.Create(currentDbSettings.Username, "Database username")},
            {"db_password", Tuple.Create(currentDbSettings.Password, "Database password")},
            {"db_name", Tuple.Create(currentDbSettings.DatabaseName, "Database name")}
        }

        For Each entry In defaults
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@key", entry.Key)
                cmd.Parameters.AddWithValue("@value", entry.Value.Item1)
                cmd.Parameters.AddWithValue("@desc", entry.Value.Item2)
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub ShowModuleStatus(message As String, isError As Boolean)
        If lblStatusIndicator Is Nothing Then Return
        lblStatusIndicator.Text = message
        lblStatusIndicator.BackColor = If(isError, Color.Firebrick, Color.FromArgb(64, 128, 64))
    End Sub

    Private Sub LogRecoveryEvent(context As String, ex As Exception)
        Try
            Dim logPath = Path.Combine(Application.StartupPath, "system_config_errors.log")
            Dim entry = $"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss} [{context}] {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}"
            File.AppendAllText(logPath, entry)
        Catch
            ' ignore logging errors
        End Try
    End Sub

    Private Function DataRowBool(row As DataRow, columnName As String) As Boolean
        Return row.Table.Columns.Contains(columnName) AndAlso Not row.IsNull(columnName) AndAlso Convert.ToBoolean(row(columnName))
    End Function

    Private Sub LoadFallbackSettings()
        currentDbSettings = LoadFallbackDbSettings()
        PopulateDbSettingsForm(currentDbSettings)
    End Sub

#End Region

    Public Sub OpenConfig()
        Show()
        BringToFront()
    End Sub

    Private Sub chkInventory_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtRoleName_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dtTo_ValueChanged(sender As Object, e As EventArgs)

    End Sub
End Class
