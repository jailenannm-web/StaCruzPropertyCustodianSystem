Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic

''' <summary>
''' System Configuration Management Form
''' Manages database connection settings and system configuration
''' Aligned with system_config table in database
''' </summary>
Public Class SASystemConfiguration

    ' ================================================================
    ' PRIVATE FIELDS
    ' ================================================================
    Private hasUnsavedChanges As Boolean = False
    Private originalValues As New Dictionary(Of String, String)

    ' ================================================================
    ' FORM LOAD
    ' ================================================================
    Private Sub SASystemConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadConfigurationSettings()
            SetupEventHandlers()
            ApplyModernStyling()
        Catch ex As Exception
            MessageBox.Show($"Error loading configuration: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================================
    ' LOAD CONFIGURATION FROM DATABASE
    ' ================================================================
    Private Sub LoadConfigurationSettings()
        Try
            Dim dt As DataTable = GetSystemConfigFromDatabase()

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ' Clear original values
                originalValues.Clear()

                ' Load database settings
                For Each row As DataRow In dt.Rows
                    Dim key As String = row("configKey").ToString()
                    Dim value As String = If(IsDBNull(row("configValue")), "", row("configValue").ToString())

                    Select Case key.ToLower()
                        Case "db_host"
                            txtDbHost.Text = value
                            originalValues("db_host") = value
                        Case "db_port"
                            txtDbPort.Text = value
                            originalValues("db_port") = value
                        Case "db_name"
                            txtDbName.Text = value
                            originalValues("db_name") = value
                        Case "db_user"
                            txtDbUser.Text = value
                            originalValues("db_user") = value
                        Case "db_password"
                            txtDbPassword.Text = value
                            originalValues("db_password") = value
                        Case "system_name"
                            txtSystemName.Text = value
                            originalValues("system_name") = value
                        Case "organization_name"
                            txtOrgName.Text = value
                            originalValues("organization_name") = value
                    End Select
                Next

                ' Set defaults if not found
                If String.IsNullOrEmpty(txtDbHost.Text) Then txtDbHost.Text = "localhost"
                If String.IsNullOrEmpty(txtDbPort.Text) Then txtDbPort.Text = "3306"
                If String.IsNullOrEmpty(txtDbName.Text) Then txtDbName.Text = "teamcruzim"
                If String.IsNullOrEmpty(txtDbUser.Text) Then txtDbUser.Text = "root"
                If String.IsNullOrEmpty(txtSystemName.Text) Then txtSystemName.Text = "Team Cruz Property Custodian Management System"
                If String.IsNullOrEmpty(txtOrgName.Text) Then txtOrgName.Text = "Team Cruz"

                hasUnsavedChanges = False
                lblConnectionStatus.Text = "Status: Configuration loaded successfully"
                lblConnectionStatus.ForeColor = Color.FromArgb(40, 167, 69)
            Else
                ' Load defaults if no config exists
                LoadDefaultSettings()
            End If

        Catch ex As Exception
            MessageBox.Show($"Error loading configuration: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LoadDefaultSettings()
        End Try
    End Sub

    ' ================================================================
    ' GET SYSTEM CONFIG FROM DATABASE
    ' ================================================================
    Private Function GetSystemConfigFromDatabase() As DataTable
        Dim dt As New DataTable()

        Try
            Using conn As MySqlConnection = modDB.GetConnection()
                conn.Open()

                Dim query As String = "SELECT configKey, configValue, configType, description FROM system_config ORDER BY configId"

                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[SASystemConfiguration] GetSystemConfigFromDatabase error: {ex.Message}")
            Throw
        End Try

        Return dt
    End Function

    ' ================================================================
    ' LOAD DEFAULT SETTINGS
    ' ================================================================
    Private Sub LoadDefaultSettings()
        txtDbHost.Text = "localhost"
        txtDbPort.Text = "3306"
        txtDbName.Text = "teamcruzim"
        txtDbUser.Text = "root"
        txtDbPassword.Text = ""
        txtSystemName.Text = "Team Cruz Property Custodian Management System"
        txtOrgName.Text = "Team Cruz"

        lblConnectionStatus.Text = "Status: Using default settings"
        lblConnectionStatus.ForeColor = Color.FromArgb(255, 193, 7)
    End Sub

    ' ================================================================
    ' SETUP EVENT HANDLERS
    ' ================================================================
    Private Sub SetupEventHandlers()
        ' Track changes
        AddHandler txtDbHost.TextChanged, AddressOf TextBox_TextChanged
        AddHandler txtDbPort.TextChanged, AddressOf TextBox_TextChanged
        AddHandler txtDbName.TextChanged, AddressOf TextBox_TextChanged
        AddHandler txtDbUser.TextChanged, AddressOf TextBox_TextChanged
        AddHandler txtDbPassword.TextChanged, AddressOf TextBox_TextChanged
        AddHandler txtSystemName.TextChanged, AddressOf TextBox_TextChanged
        AddHandler txtOrgName.TextChanged, AddressOf TextBox_TextChanged
    End Sub

    ' ================================================================
    ' TEXT CHANGED EVENT
    ' ================================================================
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs)
        hasUnsavedChanges = True
    End Sub

    ' ================================================================
    ' APPLY MODERN STYLING
    ' ================================================================
    Private Sub ApplyModernStyling()
        ' Style textboxes
        For Each ctrl As Control In grpDatabaseSettings.Controls
            If TypeOf ctrl Is TextBox Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.BorderStyle = BorderStyle.FixedSingle
                txt.BackColor = Color.White
            End If
        Next

        For Each ctrl As Control In grpSystemSettings.Controls
            If TypeOf ctrl Is TextBox Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                txt.BorderStyle = BorderStyle.FixedSingle
                txt.BackColor = Color.White
            End If
        Next

        ' Style group boxes
        grpDatabaseSettings.FlatStyle = FlatStyle.Flat
        grpSystemSettings.FlatStyle = FlatStyle.Flat
    End Sub

    ' ================================================================
    ' TEST CONNECTION BUTTON
    ' ================================================================
    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        TestDatabaseConnection()
    End Sub

    Private Sub TestDatabaseConnection()
        lblConnectionStatus.Text = "Status: Testing connection..."
        lblConnectionStatus.ForeColor = Color.FromArgb(255, 193, 7)
        Application.DoEvents()

        Try
            Dim host As String = txtDbHost.Text.Trim()
            Dim port As String = txtDbPort.Text.Trim()
            Dim dbName As String = txtDbName.Text.Trim()
            Dim user As String = txtDbUser.Text.Trim()
            Dim password As String = txtDbPassword.Text

            ' Validate inputs
            If String.IsNullOrEmpty(host) OrElse String.IsNullOrEmpty(port) OrElse 
               String.IsNullOrEmpty(dbName) OrElse String.IsNullOrEmpty(user) Then
                lblConnectionStatus.Text = "Status: Please fill in all required fields"
                lblConnectionStatus.ForeColor = Color.FromArgb(220, 53, 69)
                Return
            End If

            ' Build connection string
            Dim connString As String = $"server={host};port={port};database={dbName};uid={user};pwd={password};SslMode=none;"

            ' Test connection
            Using conn As New MySqlConnection(connString)
                conn.Open()

                ' Test query
                Using cmd As New MySqlCommand("SELECT 1", conn)
                    cmd.ExecuteScalar()
                End Using

                conn.Close()
            End Using

            lblConnectionStatus.Text = "Status: ✓ Connection successful!"
            lblConnectionStatus.ForeColor = Color.FromArgb(40, 167, 69)

            MessageBox.Show("Database connection test successful!" & vbCrLf & vbCrLf & 
                          $"Host: {host}" & vbCrLf & 
                          $"Port: {port}" & vbCrLf & 
                          $"Database: {dbName}", 
                          "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As MySqlException
            lblConnectionStatus.Text = $"Status: ✗ Connection failed - {ex.Message}"
            lblConnectionStatus.ForeColor = Color.FromArgb(220, 53, 69)

            MessageBox.Show($"Database connection failed!" & vbCrLf & vbCrLf & 
                          $"Error: {ex.Message}" & vbCrLf & vbCrLf & 
                          "Please check your connection settings.", 
                          "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            lblConnectionStatus.Text = $"Status: ✗ Error - {ex.Message}"
            lblConnectionStatus.ForeColor = Color.FromArgb(220, 53, 69)

            MessageBox.Show($"An error occurred:" & vbCrLf & vbCrLf & ex.Message, 
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================================
    ' SAVE SETTINGS BUTTON
    ' ================================================================
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveConfigurationSettings()
    End Sub

    Private Sub SaveConfigurationSettings()
        Try
            ' Validate inputs
            If String.IsNullOrWhiteSpace(txtDbHost.Text) OrElse 
               String.IsNullOrWhiteSpace(txtDbPort.Text) OrElse 
               String.IsNullOrWhiteSpace(txtDbName.Text) OrElse 
               String.IsNullOrWhiteSpace(txtDbUser.Text) Then
                MessageBox.Show("Please fill in all database connection fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrWhiteSpace(txtSystemName.Text) OrElse 
               String.IsNullOrWhiteSpace(txtOrgName.Text) Then
                MessageBox.Show("Please fill in all system settings fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Confirm save
            Dim result As DialogResult = MessageBox.Show(
                "Are you sure you want to save these configuration settings?" & vbCrLf & vbCrLf & 
                "Warning: Incorrect database settings may prevent the system from working properly.",
                "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result <> DialogResult.Yes Then
                Return
            End If

            ' Save to database
            Dim success As Boolean = SaveToDatabase()

            If success Then
                hasUnsavedChanges = False
                MessageBox.Show("Configuration settings saved successfully!" & vbCrLf & vbCrLf & 
                              "Note: You may need to restart the application for changes to take effect.",
                              "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Reload to confirm
                LoadConfigurationSettings()

                ' Log the action
                Try
                    AuditLogger.LogAction(SessionContext.CurrentUserId, "UPDATE", "system_config", 0, 
                                         "System configuration settings updated")
                Catch
                    ' Ignore logging errors
                End Try
            Else
                MessageBox.Show("Failed to save configuration settings. Please try again.",
                              "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show($"Error saving configuration: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================================
    ' SAVE TO DATABASE
    ' ================================================================
    Private Function SaveToDatabase() As Boolean
        Try
            Using conn As MySqlConnection = modDB.GetConnection()
                conn.Open()

                ' Prepare config items
                Dim configs As New Dictionary(Of String, String) From {
                    {"db_host", txtDbHost.Text.Trim()},
                    {"db_port", txtDbPort.Text.Trim()},
                    {"db_name", txtDbName.Text.Trim()},
                    {"db_user", txtDbUser.Text.Trim()},
                    {"db_password", txtDbPassword.Text},
                    {"system_name", txtSystemName.Text.Trim()},
                    {"organization_name", txtOrgName.Text.Trim()}
                }

                ' Update or insert each config
                For Each kvp In configs
                    Dim query As String = "INSERT INTO system_config (configKey, configValue, configType, description, updatedBy, updatedAt) " &
                                        "VALUES (@key, @value, @type, @desc, @userId, NOW()) " &
                                        "ON DUPLICATE KEY UPDATE configValue = @value, updatedBy = @userId, updatedAt = NOW()"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@key", kvp.Key)
                        cmd.Parameters.AddWithValue("@value", kvp.Value)

                        ' Set config type
                        Dim configType As String = If(kvp.Key.StartsWith("db_"), "connection", "system")
                        cmd.Parameters.AddWithValue("@type", configType)

                        ' Set description
                        Dim description As String = GetConfigDescription(kvp.Key)
                        cmd.Parameters.AddWithValue("@desc", description)

                        cmd.Parameters.AddWithValue("@userId", SessionContext.CurrentUserId)

                        cmd.ExecuteNonQuery()
                    End Using
                Next

                conn.Close()
            End Using

            Return True

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[SASystemConfiguration] SaveToDatabase error: {ex.Message}")
            Return False
        End Try
    End Function

    ' ================================================================
    ' GET CONFIG DESCRIPTION
    ' ================================================================
    Private Function GetConfigDescription(key As String) As String
        Select Case key.ToLower()
            Case "db_host"
                Return "Database host address"
            Case "db_port"
                Return "Database port number"
            Case "db_name"
                Return "Database name"
            Case "db_user"
                Return "Database username"
            Case "db_password"
                Return "Database password"
            Case "system_name"
                Return "System name"
            Case "organization_name"
                Return "Organization name"
            Case Else
                Return "Configuration setting"
        End Select
    End Function

    ' ================================================================
    ' CANCEL BUTTON
    ' ================================================================
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If hasUnsavedChanges Then
            Dim result As DialogResult = MessageBox.Show(
                "You have unsaved changes. Do you want to discard them?",
                "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                LoadConfigurationSettings()
            End If
        Else
            LoadConfigurationSettings()
        End If
    End Sub

    ' ================================================================
    ' REFRESH BUTTON
    ' ================================================================
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If hasUnsavedChanges Then
            Dim result As DialogResult = MessageBox.Show(
                "You have unsaved changes. Refreshing will discard them. Continue?",
                "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                LoadConfigurationSettings()
            End If
        Else
            LoadConfigurationSettings()
        End If
    End Sub

End Class
