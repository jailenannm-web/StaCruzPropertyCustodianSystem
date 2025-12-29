Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic

''' <summary>
''' Extension methods for DatabaseConnection to support location dropdowns and utilities
''' </summary>
Partial Public Class DatabaseConnection
    
    ''' <summary>
    ''' Get list of provinces for location dropdown - Bicol Region, Philippines
    ''' </summary>
    Public Shared Function GetProvinces() As DataTable
        Dim dt As New DataTable()
        Try
            ' Create simple province table
            dt.Columns.Add("province_name", GetType(String))
            
            ' Add Bicol Region provinces
            dt.Rows.Add("Albay")
            dt.Rows.Add("Camarines Norte")
            dt.Rows.Add("Camarines Sur")
            dt.Rows.Add("Catanduanes")
            dt.Rows.Add("Masbate")
            dt.Rows.Add("Sorsogon")
            
            ' Sort alphabetically
            Dim dv As DataView = dt.DefaultView
            dv.Sort = "province_name ASC"
            dt = dv.ToTable()
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetProvinces Exception: " & ex.Message)
        End Try
        Return dt
    End Function
    
    ''' <summary>
    ''' Get municipalities for selected province in Bicol Region
    ''' </summary>
    Public Shared Function GetMunicipalities(province As String) As DataTable
        Dim dt As New DataTable()
        Try
            ' Create municipality table
            dt.Columns.Add("municipality_name", GetType(String))
            
            ' Check if province is empty or null
            If String.IsNullOrWhiteSpace(province) Then
                dt.Rows.Add("Please select a province first")
                Return dt
            End If
            
            ' Add municipalities based on Bicol province
            Select Case province.Trim().ToLower()
                Case "albay"
                    dt.Rows.Add("Legazpi City")
                    dt.Rows.Add("Ligao City")
                    dt.Rows.Add("Tabaco City")
                    dt.Rows.Add("Bacacay")
                    dt.Rows.Add("Camalig")
                    dt.Rows.Add("Daraga")
                    dt.Rows.Add("Guinobatan")
                    dt.Rows.Add("Jovellar")
                    dt.Rows.Add("Libon")
                    dt.Rows.Add("Malilipot")
                    dt.Rows.Add("Malinao")
                    dt.Rows.Add("Manito")
                    dt.Rows.Add("Oas")
                    dt.Rows.Add("Pio Duran")
                    dt.Rows.Add("Polangui")
                    dt.Rows.Add("Rapu-Rapu")
                    dt.Rows.Add("Santo Domingo")
                    dt.Rows.Add("Tiwi")
                    
                Case "camarines norte"
                    dt.Rows.Add("Daet")
                    dt.Rows.Add("Basud")
                    dt.Rows.Add("Capalonga")
                    dt.Rows.Add("Jose Panganiban")
                    dt.Rows.Add("Labo")
                    dt.Rows.Add("Mercedes")
                    dt.Rows.Add("Paracale")
                    dt.Rows.Add("San Lorenzo Ruiz")
                    dt.Rows.Add("San Vicente")
                    dt.Rows.Add("Santa Elena")
                    dt.Rows.Add("Talisay")
                    dt.Rows.Add("Vinzons")
                    
                Case "camarines sur"
                    dt.Rows.Add("Naga City")
                    dt.Rows.Add("Iriga City")
                    dt.Rows.Add("Baao")
                    dt.Rows.Add("Balatan")
                    dt.Rows.Add("Bato")
                    dt.Rows.Add("Bombon")
                    dt.Rows.Add("Buhi")
                    dt.Rows.Add("Bula")
                    dt.Rows.Add("Cabusao")
                    dt.Rows.Add("Calabanga")
                    dt.Rows.Add("Camaligan")
                    dt.Rows.Add("Canaman")
                    dt.Rows.Add("Caramoan")
                    dt.Rows.Add("Del Gallego")
                    dt.Rows.Add("Gainza")
                    dt.Rows.Add("Garchitorena")
                    dt.Rows.Add("Goa")
                    dt.Rows.Add("Lagonoy")
                    dt.Rows.Add("Libmanan")
                    dt.Rows.Add("Lupi")
                    dt.Rows.Add("Magarao")
                    dt.Rows.Add("Milaor")
                    dt.Rows.Add("Minalabac")
                    dt.Rows.Add("Nabua")
                    dt.Rows.Add("Ocampo")
                    dt.Rows.Add("Pamplona")
                    dt.Rows.Add("Pasacao")
                    dt.Rows.Add("Pili")
                    dt.Rows.Add("Presentacion")
                    dt.Rows.Add("Ragay")
                    dt.Rows.Add("Sagnay")
                    dt.Rows.Add("San Fernando")
                    dt.Rows.Add("San Jose")
                    dt.Rows.Add("Sipocot")
                    dt.Rows.Add("Siruma")
                    dt.Rows.Add("Tigaon")
                    dt.Rows.Add("Tinambac")
                    
                Case "catanduanes"
                    dt.Rows.Add("Virac")
                    dt.Rows.Add("Bagamanoc")
                    dt.Rows.Add("Baras")
                    dt.Rows.Add("Bato")
                    dt.Rows.Add("Caramoran")
                    dt.Rows.Add("Gigmoto")
                    dt.Rows.Add("Pandan")
                    dt.Rows.Add("Panganiban")
                    dt.Rows.Add("San Andres")
                    dt.Rows.Add("San Miguel")
                    dt.Rows.Add("Viga")
                    
                Case "masbate"
                    dt.Rows.Add("Masbate City")
                    dt.Rows.Add("Aroroy")
                    dt.Rows.Add("Baleno")
                    dt.Rows.Add("Balud")
                    dt.Rows.Add("Batuan")
                    dt.Rows.Add("Cataingan")
                    dt.Rows.Add("Cawayan")
                    dt.Rows.Add("Claveria")
                    dt.Rows.Add("Dimasalang")
                    dt.Rows.Add("Esperanza")
                    dt.Rows.Add("Mandaon")
                    dt.Rows.Add("Milagros")
                    dt.Rows.Add("Mobo")
                    dt.Rows.Add("Monreal")
                    dt.Rows.Add("Palanas")
                    dt.Rows.Add("Pio V. Corpuz")
                    dt.Rows.Add("Placer")
                    dt.Rows.Add("San Fernando")
                    dt.Rows.Add("San Jacinto")
                    dt.Rows.Add("San Pascual")
                    dt.Rows.Add("Uson")
                    
                Case "sorsogon"
                    dt.Rows.Add("Sorsogon City")
                    dt.Rows.Add("Barcelona")
                    dt.Rows.Add("Bulan")
                    dt.Rows.Add("Bulusan")
                    dt.Rows.Add("Casiguran")
                    dt.Rows.Add("Castilla")
                    dt.Rows.Add("Donsol")
                    dt.Rows.Add("Gubat")
                    dt.Rows.Add("Irosin")
                    dt.Rows.Add("Juban")
                    dt.Rows.Add("Magallanes")
                    dt.Rows.Add("Matnog")
                    dt.Rows.Add("Pilar")
                    dt.Rows.Add("Prieto Diaz")
                    dt.Rows.Add("Santa Magdalena")
                    
                Case Else
                    ' If province doesn't match, return empty message
                    dt.Rows.Add("No municipalities found for " & province)
            End Select
            
            ' Sort alphabetically if we have data
            If dt.Rows.Count > 1 AndAlso dt.Rows(0)("municipality_name").ToString() <> "Please select a province first" Then
                Dim dv As DataView = dt.DefaultView
                dv.Sort = "municipality_name ASC"
                dt = dv.ToTable()
            End If
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetMunicipalities Exception: " & ex.Message)
            ' Return empty table with error message
            dt.Clear()
            dt.Rows.Add("Error loading municipalities")
        End Try
        Return dt
    End Function
    
    ''' <summary>
    ''' Get barangays for selected municipality
    ''' </summary>
    Public Shared Function GetBarangays(municipality As String) As DataTable
        Dim dt As New DataTable()
        Try
            ' Create barangay table
            dt.Columns.Add("barangay_name", GetType(String))
            
            ' Add sample barangays (generic list - customize per municipality as needed)
            For i As Integer = 1 To 20
                dt.Rows.Add($"Barangay {i}")
            Next
            
            ' Add some common barangay names in Bicol
            dt.Rows.Add("Poblacion")
            dt.Rows.Add("San Isidro")
            dt.Rows.Add("San Juan")
            dt.Rows.Add("San Roque")
            dt.Rows.Add("Santa Cruz")
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GetBarangays Exception: " & ex.Message)
        End Try
        Return dt
    End Function
    
    ''' <summary>
    ''' Generate a unique property number in format: PROP-YYYY-####
    ''' </summary>
    Private Shared Function GeneratePropertyNumber() As String
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return ""
            If Not SafeOpenConnection(conn) Then Return ""
            
            Return GeneratePropertyNumber(conn, Nothing)
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GeneratePropertyNumber Exception: " & ex.Message)
            ' Fallback to timestamp-based number
            Return "PROP-" & DateTime.Now.ToString("yyyy-MMddHHmmss")
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function
    
    ''' <summary>
    ''' Generate a unique property number in format: PROP-YYYY-#### (with transaction support)
    ''' </summary>
    Friend Shared Function GeneratePropertyNumber(conn As MySqlConnection, transaction As MySqlTransaction) As String
        Try
            Dim year As String = DateTime.Now.Year.ToString()
            Dim prefix As String = "PROP-" & year & "-"
            
            ' Get the highest number for this year
            Dim query As String = "SELECT propertyNumber FROM properties WHERE propertyNumber LIKE @prefix ORDER BY propertyNumber DESC LIMIT 1"
            Using cmd As New MySqlCommand(query, conn, transaction)
                cmd.Parameters.AddWithValue("@prefix", prefix & "%")
                Dim result = cmd.ExecuteScalar()
                
                If result IsNot Nothing AndAlso Not result.Equals(DBNull.Value) Then
                    Dim lastNumber As String = result.ToString()
                    ' Extract the number part (last 4 digits)
                    Dim parts() As String = lastNumber.Split("-"c)
                    If parts.Length = 3 Then
                        Dim lastSeq As Integer = 0
                        If Integer.TryParse(parts(2), lastSeq) Then
                            Return prefix & (lastSeq + 1).ToString("D4")
                        End If
                    End If
                End If
                
                ' If no existing number found, start with 0001
                Return prefix & "0001"
            End Using
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GeneratePropertyNumber Exception: " & ex.Message)
            ' Fallback to timestamp-based number
            Return "PROP-" & DateTime.Now.ToString("yyyy-MMddHHmmss")
        End Try
    End Function
    
    ''' <summary>
    ''' Generate a unique internal code in format: IC-YYYY-####
    ''' </summary>
    Private Shared Function GenerateInternalCode() As String
        Dim conn As MySqlConnection = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return ""
            If Not SafeOpenConnection(conn) Then Return ""
            
            Return GenerateInternalCode(conn, Nothing)
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GenerateInternalCode Exception: " & ex.Message)
            ' Fallback to timestamp-based code
            Return "IC-" & DateTime.Now.ToString("yyyy-MMddHHmmss")
        Finally
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function
    
    ''' <summary>
    ''' Generate a unique internal code in format: IC-YYYY-#### (with transaction support)
    ''' </summary>
    Friend Shared Function GenerateInternalCode(conn As MySqlConnection, transaction As MySqlTransaction) As String
        Try
            Dim year As String = DateTime.Now.Year.ToString()
            Dim prefix As String = "IC-" & year & "-"
            
            ' Get the highest number for this year
            Dim query As String = "SELECT internalCodes FROM properties WHERE internalCodes LIKE @prefix ORDER BY internalCodes DESC LIMIT 1"
            Using cmd As New MySqlCommand(query, conn, transaction)
                cmd.Parameters.AddWithValue("@prefix", prefix & "%")
                Dim result = cmd.ExecuteScalar()
                
                If result IsNot Nothing AndAlso Not result.Equals(DBNull.Value) Then
                    Dim lastCode As String = result.ToString()
                    ' Extract the number part (last 4 digits)
                    Dim parts() As String = lastCode.Split("-"c)
                    If parts.Length = 3 Then
                        Dim lastSeq As Integer = 0
                        If Integer.TryParse(parts(2), lastSeq) Then
                            Return prefix & (lastSeq + 1).ToString("D4")
                        End If
                    End If
                End If
                
                ' If no existing code found, start with 0001
                Return prefix & "0001"
            End Using
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] GenerateInternalCode Exception: " & ex.Message)
            ' Fallback to timestamp-based code
            Return "IC-" & DateTime.Now.ToString("yyyy-MMddHHmmss")
        End Try
    End Function
    
    ''' <summary>
    ''' Add a new property to the database with auto-generated propertyNumber and internalCodes
    ''' Automatically creates borrowed_items record if property is assigned to a user
    ''' </summary>
    Public Shared Function AddProperty(itemName As String,
                                       category As String,
                                       description As String,
                                       unitOfMeasure As String,
                                       propertyNumber As String,
                                       serialNumber As String,
                                       acquisitionDate As Date,
                                       acquisitionCost As Decimal,
                                       totalCost As Decimal?,
                                       sourceOfFunds As String,
                                       assignedTo As Integer?,
                                       departmentId As Integer?,
                                       location As String,
                                       condition As String,
                                       status As String,
                                       internalCodes As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Dim transaction As MySqlTransaction = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False
            
            ' Start transaction to ensure both property and borrowed_items are created together
            transaction = conn.BeginTransaction()
            
            ' Auto-generate propertyNumber if empty
            If String.IsNullOrWhiteSpace(propertyNumber) Then
                propertyNumber = GeneratePropertyNumber(conn, transaction)
            End If
            
            ' Auto-generate internalCodes if empty
            If String.IsNullOrWhiteSpace(internalCodes) Then
                internalCodes = GenerateInternalCode(conn, transaction)
            End If
            
            ' Insert property into database
            Dim query As String = "INSERT INTO properties (itemName, category, description, unitOfMeasure, " &
                                 "propertyNumber, serialNumber, acquisitionDate, acquisitionCost, totalCost, " &
                                 "sourceOfFunds, assignedTo, departmentId, location, `condition`, status, internalCodes, " &
                                 "createdAt, updatedAt) VALUES (@itemName, @category, @description, @unitOfMeasure, " &
                                 "@propertyNumber, @serialNumber, @acquisitionDate, @acquisitionCost, @totalCost, " &
                                 "@sourceOfFunds, @assignedTo, @departmentId, @location, @condition, @status, @internalCodes, " &
                                 "NOW(), NOW())"
            
            Dim newPropertyId As Integer = 0
            Using cmd As New MySqlCommand(query, conn, transaction)
                cmd.Parameters.AddWithValue("@itemName", itemName)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@unitOfMeasure", If(String.IsNullOrWhiteSpace(unitOfMeasure), DBNull.Value, unitOfMeasure))
                cmd.Parameters.AddWithValue("@propertyNumber", propertyNumber)
                cmd.Parameters.AddWithValue("@serialNumber", If(String.IsNullOrWhiteSpace(serialNumber), DBNull.Value, serialNumber))
                cmd.Parameters.AddWithValue("@acquisitionDate", acquisitionDate)
                cmd.Parameters.AddWithValue("@acquisitionCost", acquisitionCost)
                cmd.Parameters.AddWithValue("@totalCost", If(totalCost.HasValue, totalCost.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@sourceOfFunds", If(String.IsNullOrWhiteSpace(sourceOfFunds), DBNull.Value, sourceOfFunds))
                cmd.Parameters.AddWithValue("@assignedTo", If(assignedTo.HasValue, assignedTo.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, departmentId.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@location", location)
                cmd.Parameters.AddWithValue("@condition", condition)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Parameters.AddWithValue("@internalCodes", internalCodes)
                
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected <= 0 Then
                    transaction.Rollback()
                    Return False
                End If
                
                ' Get the newly inserted property ID
                Using idCmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn, transaction)
                    newPropertyId = Convert.ToInt32(idCmd.ExecuteScalar())
                End Using
            End Using
            
            ' If property is assigned to a user, automatically create borrowed_items record
            If assignedTo.HasValue AndAlso assignedTo.Value > 0 Then
                CreateBorrowedItemRecord(conn, transaction, newPropertyId, assignedTo.Value, departmentId, itemName, propertyNumber, serialNumber)
            End If
            
            ' Commit transaction
            transaction.Commit()
            System.Diagnostics.Debug.WriteLine($"[v0] AddProperty Success - ID: {newPropertyId}, AssignedTo: {If(assignedTo.HasValue, assignedTo.Value.ToString(), "None")}")
            Return True
            
        Catch ex As Exception
            If transaction IsNot Nothing Then
                Try
                    transaction.Rollback()
                Catch
                End Try
            End If
            System.Diagnostics.Debug.WriteLine("[v0] AddProperty Exception: " & ex.Message)
            MessageBox.Show("Error adding property: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If transaction IsNot Nothing Then
                Try
                    transaction.Dispose()
                Catch
                End Try
            End If
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function
    
    ''' <summary>
    ''' Create a borrowed_items record when a property is assigned to a user
    ''' </summary>
    Private Shared Sub CreateBorrowedItemRecord(conn As MySqlConnection, transaction As MySqlTransaction,
                                                propertyId As Integer, userId As Integer,
                                                departmentId As Integer?, itemName As String,
                                                propertyNumber As String, serialNumber As String)
        Try
            ' Get user information
            Dim borrowerName As String = ""
            Dim borrowerPosition As String = ""
            Dim userDeptId As Integer? = departmentId
            
            Using userCmd As New MySqlCommand("SELECT CONCAT(IFNULL(firstName,''), ' ', IFNULL(lastName,'')) AS fullName, position, departmentId FROM users WHERE userId = @userId", conn, transaction)
                userCmd.Parameters.AddWithValue("@userId", userId)
                Using reader As MySqlDataReader = userCmd.ExecuteReader()
                    If reader.Read() Then
                        borrowerName = If(reader.IsDBNull(0), "Unknown User", reader.GetString(0))
                        borrowerPosition = If(reader.IsDBNull(1), Nothing, reader.GetString(1))
                        If Not reader.IsDBNull(2) Then userDeptId = reader.GetInt32(2)
                    End If
                End Using
            End Using
            
            ' Create borrowed_items record
            Dim borrowQuery As String = "INSERT INTO borrowed_items (itemType, itemId, itemName, borrowerName, borrowerPosition, " &
                                       "departmentId, borrowDate, returnReason, status, remarks, createdAt, updatedAt) " &
                                       "VALUES ('property', @itemId, @itemName, @borrowerName, @borrowerPosition, @departmentId, " &
                                       "NOW(), NULL, 'Borrowed', @remarks, NOW(), NOW())"
            
            Using borrowCmd As New MySqlCommand(borrowQuery, conn, transaction)
                borrowCmd.Parameters.AddWithValue("@itemId", propertyId)
                borrowCmd.Parameters.AddWithValue("@itemName", itemName)
                borrowCmd.Parameters.AddWithValue("@borrowerName", borrowerName)
                borrowCmd.Parameters.AddWithValue("@borrowerPosition", If(String.IsNullOrEmpty(borrowerPosition), DBNull.Value, borrowerPosition))
                borrowCmd.Parameters.AddWithValue("@departmentId", If(userDeptId.HasValue, userDeptId.Value, DBNull.Value))
                
                Dim remarks As String = $"Property assigned: {itemName}"
                If Not String.IsNullOrEmpty(propertyNumber) Then remarks &= $" (Property #: {propertyNumber})"
                If Not String.IsNullOrEmpty(serialNumber) Then remarks &= $" (Serial #: {serialNumber})"
                borrowCmd.Parameters.AddWithValue("@remarks", remarks)
                
                borrowCmd.ExecuteNonQuery()
                System.Diagnostics.Debug.WriteLine($"[v0] Created borrowed_items record for propertyId: {propertyId}, userId: {userId}")
            End Using
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] CreateBorrowedItemRecord Exception: " & ex.Message)
            Throw ' Re-throw to rollback transaction
        End Try
    End Sub
    
    ''' <summary>
    ''' Update an existing property in the database
    ''' Automatically manages borrowed_items records when assignment changes
    ''' </summary>
    Public Shared Function UpdateProperty(propertyId As Integer,
                                          itemName As String,
                                          category As String,
                                          description As String,
                                          unitOfMeasure As String,
                                          serialNumber As String,
                                          condition As String,
                                          location As String,
                                          custodianId As Integer?,
                                          departmentId As Integer?,
                                          acquisitionDate As Date,
                                          acquisitionCost As Decimal,
                                          sourceOfFunds As String,
                                          status As String) As Boolean
        Dim conn As MySqlConnection = Nothing
        Dim transaction As MySqlTransaction = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False
            
            ' Start transaction
            transaction = conn.BeginTransaction()
            
            ' Get current assignedTo value before update
            Dim oldAssignedTo As Integer? = Nothing
            Dim propertyNumber As String = ""
            Using checkCmd As New MySqlCommand("SELECT assignedTo, propertyNumber FROM properties WHERE propertyId = @propertyId", conn, transaction)
                checkCmd.Parameters.AddWithValue("@propertyId", propertyId)
                Using reader As MySqlDataReader = checkCmd.ExecuteReader()
                    If reader.Read() Then
                        If Not reader.IsDBNull(0) Then oldAssignedTo = reader.GetInt32(0)
                        If Not reader.IsDBNull(1) Then propertyNumber = reader.GetString(1)
                    End If
                End Using
            End Using
            
            ' Update property
            Dim query As String = "UPDATE properties SET itemName = @itemName, category = @category, " &
                                 "description = @description, unitOfMeasure = @unitOfMeasure, serialNumber = @serialNumber, " &
                                 "`condition` = @condition, location = @location, assignedTo = @assignedTo, " &
                                 "departmentId = @departmentId, acquisitionDate = @acquisitionDate, " &
                                 "acquisitionCost = @acquisitionCost, sourceOfFunds = @sourceOfFunds, " &
                                 "status = @status, updatedAt = NOW() WHERE propertyId = @propertyId"
            
            Using cmd As New MySqlCommand(query, conn, transaction)
                cmd.Parameters.AddWithValue("@propertyId", propertyId)
                cmd.Parameters.AddWithValue("@itemName", itemName)
                cmd.Parameters.AddWithValue("@category", category)
                cmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(description), DBNull.Value, description))
                cmd.Parameters.AddWithValue("@unitOfMeasure", If(String.IsNullOrWhiteSpace(unitOfMeasure), DBNull.Value, unitOfMeasure))
                cmd.Parameters.AddWithValue("@serialNumber", If(String.IsNullOrWhiteSpace(serialNumber), DBNull.Value, serialNumber))
                cmd.Parameters.AddWithValue("@condition", condition)
                cmd.Parameters.AddWithValue("@location", location)
                cmd.Parameters.AddWithValue("@assignedTo", If(custodianId.HasValue, custodianId.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, departmentId.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@acquisitionDate", acquisitionDate)
                cmd.Parameters.AddWithValue("@acquisitionCost", acquisitionCost)
                cmd.Parameters.AddWithValue("@sourceOfFunds", If(String.IsNullOrWhiteSpace(sourceOfFunds), DBNull.Value, sourceOfFunds))
                cmd.Parameters.AddWithValue("@status", status)
                
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected <= 0 Then
                    transaction.Rollback()
                    Return False
                End If
            End Using
            
            ' Handle borrowed_items based on assignment changes
            ' Case 1: Property was not assigned, now it is assigned
            If (Not oldAssignedTo.HasValue OrElse oldAssignedTo.Value = 0) AndAlso custodianId.HasValue AndAlso custodianId.Value > 0 Then
                CreateBorrowedItemRecord(conn, transaction, propertyId, custodianId.Value, departmentId, itemName, propertyNumber, serialNumber)
            
            ' Case 2: Property was assigned to someone, now assigned to different user
            ElseIf oldAssignedTo.HasValue AndAlso oldAssignedTo.Value > 0 AndAlso custodianId.HasValue AndAlso custodianId.Value > 0 AndAlso oldAssignedTo.Value <> custodianId.Value Then
                ' Mark old borrowed_items as returned
                Using returnCmd As New MySqlCommand("UPDATE borrowed_items SET status = 'Returned', actualReturnDate = NOW(), " &
                                                   "updatedAt = NOW() WHERE itemType = 'property' AND itemId = @propertyId AND status = 'Borrowed'", conn, transaction)
                    returnCmd.Parameters.AddWithValue("@propertyId", propertyId)
                    returnCmd.ExecuteNonQuery()
                End Using
                
                ' Create new borrowed_items record for new user
                CreateBorrowedItemRecord(conn, transaction, propertyId, custodianId.Value, departmentId, itemName, propertyNumber, serialNumber)
            
            ' Case 3: Property was assigned, now unassigned (mark as returned)
            ElseIf oldAssignedTo.HasValue AndAlso oldAssignedTo.Value > 0 AndAlso (Not custodianId.HasValue OrElse custodianId.Value = 0) Then
                Using returnCmd As New MySqlCommand("UPDATE borrowed_items SET status = 'Returned', actualReturnDate = NOW(), " &
                                                   "updatedAt = NOW() WHERE itemType = 'property' AND itemId = @propertyId AND status = 'Borrowed'", conn, transaction)
                    returnCmd.Parameters.AddWithValue("@propertyId", propertyId)
                    returnCmd.ExecuteNonQuery()
                End Using
            End If
            
            ' Commit transaction
            transaction.Commit()
            System.Diagnostics.Debug.WriteLine($"[v0] UpdateProperty Success - ID: {propertyId}, OldAssignedTo: {If(oldAssignedTo.HasValue, oldAssignedTo.Value.ToString(), "None")}, NewAssignedTo: {If(custodianId.HasValue, custodianId.Value.ToString(), "None")}")
            Return True
            
        Catch ex As Exception
            If transaction IsNot Nothing Then
                Try
                    transaction.Rollback()
                Catch
                End Try
            End If
            System.Diagnostics.Debug.WriteLine("[v0] UpdateProperty Exception: " & ex.Message)
            MessageBox.Show("Error updating property: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If transaction IsNot Nothing Then
                Try
                    transaction.Dispose()
                Catch
                End Try
            End If
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function
    
    ''' <summary>
    ''' Approve a property request and update the matching property with requester information
    ''' </summary>
    Private Shared Function ApprovePropertyRequest_Extensions(requestId As Integer,
                                                   adminId As Integer,
                                                   adminUsername As String,
                                                   adminRole As String,
                                                   Optional propertyId As Integer? = Nothing,
                                                   Optional assignedUserId As Integer? = Nothing,
                                                   Optional remarks As String = "") As Boolean
        Dim conn As MySqlConnection = Nothing
        Dim transaction As MySqlTransaction = Nothing
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False
            
            transaction = conn.BeginTransaction()
            
            ' Get request details including requester info
            Dim requestQuery As String = "SELECT pr.requesterName, pr.itemName, pr.departmentId, " &
                                         "d.location, pr.position, u.userId, u.fullName " &
                                         "FROM property_requests pr " &
                                         "LEFT JOIN departments d ON pr.departmentId = d.departmentId " &
                                         "LEFT JOIN users u ON LOWER(CONCAT(u.firstName, ' ', u.lastName)) = LOWER(pr.requesterName) " &
                                         "WHERE pr.requestId = @requestId"
            
            Dim requesterName As String = ""
            Dim itemName As String = ""
            Dim departmentId As Integer? = Nothing
            Dim deptLocation As String = ""
            Dim requesterUserId As Integer? = Nothing
            Dim requesterFullName As String = ""
            
            Using cmd As New MySqlCommand(requestQuery, conn, transaction)
                cmd.Parameters.AddWithValue("@requestId", requestId)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        requesterName = If(Not reader.IsDBNull(0), reader.GetString(0), "")
                        itemName = If(Not reader.IsDBNull(1), reader.GetString(1), "")
                        If Not reader.IsDBNull(2) Then departmentId = reader.GetInt32(2)
                        deptLocation = If(Not reader.IsDBNull(3), reader.GetString(3), "")
                        If Not reader.IsDBNull(5) Then requesterUserId = reader.GetInt32(5)
                        requesterFullName = If(Not reader.IsDBNull(6), reader.GetString(6), "")
                    Else
                        transaction.Rollback()
                        System.Diagnostics.Debug.WriteLine("[v0] ApprovePropertyRequest - Request not found: " & requestId)
                        Return False
                    End If
                End Using
            End Using
            
            ' Update property_requests status to Approved
            Dim updateRequestQuery As String = "UPDATE property_requests SET status = 'Approved', " &
                                               "approvedBy = @adminId, approvedDate = NOW(), " &
                                               "remarks = @remarks, updatedAt = NOW() " &
                                               "WHERE requestId = @requestId"
            
            Using cmd As New MySqlCommand(updateRequestQuery, conn, transaction)
                cmd.Parameters.AddWithValue("@requestId", requestId)
                cmd.Parameters.AddWithValue("@adminId", adminId)
                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrWhiteSpace(remarks), DBNull.Value, remarks))
                cmd.ExecuteNonQuery()
            End Using
            
            ' Find matching property by itemName (case-insensitive)
            Dim findPropertyQuery As String = "SELECT propertyId FROM properties " &
                                             "WHERE LOWER(itemName) = LOWER(@itemName) " &
                                             "AND (assignedTo IS NULL OR assignedTo = 0) " &
                                             "LIMIT 1"
            
            Dim matchedPropertyId As Integer? = Nothing
            Using cmd As New MySqlCommand(findPropertyQuery, conn, transaction)
                cmd.Parameters.AddWithValue("@itemName", itemName)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    matchedPropertyId = Convert.ToInt32(result)
                End If
            End Using
            
            ' If property found, update it with requester information
            If matchedPropertyId.HasValue Then
                ' Use requesterUserId if found, otherwise use assignedUserId parameter
                Dim userIdToAssign As Integer? = If(requesterUserId.HasValue, requesterUserId, assignedUserId)
                
                Dim updatePropertyQuery As String = "UPDATE properties SET " &
                                                   "assignedTo = @assignedTo, " &
                                                   "departmentId = @departmentId, " &
                                                   "location = @location, " &
                                                   "status = 'Active', " &
                                                   "updatedAt = NOW() " &
                                                   "WHERE propertyId = @propertyId"
                
                Using cmd As New MySqlCommand(updatePropertyQuery, conn, transaction)
                    cmd.Parameters.AddWithValue("@propertyId", matchedPropertyId.Value)
                    cmd.Parameters.AddWithValue("@assignedTo", If(userIdToAssign.HasValue, userIdToAssign.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, departmentId.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@location", If(String.IsNullOrWhiteSpace(deptLocation), DBNull.Value, deptLocation))
                    
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    System.Diagnostics.Debug.WriteLine($"[v0] ApprovePropertyRequest - Updated property {matchedPropertyId.Value}, rows affected: {rowsAffected}")
                End Using
                
                ' Create borrowed_items record if user is assigned
                If userIdToAssign.HasValue AndAlso userIdToAssign.Value > 0 Then
                    Dim borrowQuery As String = "INSERT INTO borrowed_items (itemType, itemId, itemName, borrowerName, " &
                                               "borrowerPosition, departmentId, borrowDate, returnReason, status, remarks, createdAt, updatedAt) " &
                                               "VALUES ('property', @itemId, @itemName, @borrowerName, @borrowerPosition, " &
                                               "@departmentId, NOW(), NULL, 'Borrowed', @remarks, NOW(), NOW())"
                    
                    Using cmd As New MySqlCommand(borrowQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@itemId", matchedPropertyId.Value)
                        cmd.Parameters.AddWithValue("@itemName", itemName)
                        cmd.Parameters.AddWithValue("@borrowerName", If(String.IsNullOrWhiteSpace(requesterFullName), requesterName, requesterFullName))
                        cmd.Parameters.AddWithValue("@borrowerPosition", DBNull.Value)
                        cmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, departmentId.Value, DBNull.Value))
                        cmd.Parameters.AddWithValue("@remarks", "Approved property request #" & requestId)
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            Else
                System.Diagnostics.Debug.WriteLine($"[v0] ApprovePropertyRequest - No matching unassigned property found for: {itemName}")
            End If
            
            transaction.Commit()
            System.Diagnostics.Debug.WriteLine($"[v0] ApprovePropertyRequest Success - RequestId: {requestId}, PropertyId: {If(matchedPropertyId.HasValue, matchedPropertyId.Value.ToString(), "None")}")
            Return True
            
        Catch ex As Exception
            If transaction IsNot Nothing Then
                Try
                    transaction.Rollback()
                Catch
                End Try
            End If
            System.Diagnostics.Debug.WriteLine("[v0] ApprovePropertyRequest Exception: " & ex.Message & vbCrLf & ex.StackTrace)
            MessageBox.Show("Error approving property request: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If transaction IsNot Nothing Then
                Try
                    transaction.Dispose()
                Catch
                End Try
            End If
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

    ''' <summary>
    ''' Assign a supply to a user and update quantity
    ''' </summary>
    Public Shared Function AssignSupplyToUser(supplyId As Integer, userId As Integer, quantity As Integer,
                                             Optional departmentId As Integer? = Nothing,
                                             Optional purpose As String = "") As Boolean
        Dim conn As MySqlConnection = Nothing
        Dim transaction As MySqlTransaction = Nothing
        Try
            conn = DatabaseConnection.GetConnection()
            If conn Is Nothing Then Return False
            If Not DatabaseConnection.SafeOpenConnection(conn) Then Return False

            transaction = conn.BeginTransaction()

            ' Check available quantity
            Dim availableQty As Integer = 0
            Using checkCmd As New MySqlCommand("SELECT quantity FROM supplies WHERE supplyId = @supplyId", conn, transaction)
                checkCmd.Parameters.AddWithValue("@supplyId", supplyId)
                Dim result = checkCmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    Integer.TryParse(result.ToString(), availableQty)
                End If
            End Using

            If availableQty < quantity Then
                System.Diagnostics.Debug.WriteLine($"[v0] AssignSupplyToUser - Insufficient quantity. Available: {availableQty}, Requested: {quantity}")
                Return False
            End If

            ' Update supply: deduct quantity and set assignedTo
            Using updateCmd As New MySqlCommand("UPDATE supplies SET quantity = quantity - @qty, assignedTo = @userId, updatedAt = NOW() WHERE supplyId = @supplyId", conn, transaction)
                updateCmd.Parameters.AddWithValue("@qty", quantity)
                updateCmd.Parameters.AddWithValue("@userId", userId)
                updateCmd.Parameters.AddWithValue("@supplyId", supplyId)
                updateCmd.ExecuteNonQuery()
            End Using

            ' Create borrowed_items record for tracking
            Dim borrowQuery As String = "INSERT INTO borrowed_items (itemType, itemId, itemName, borrowerName, borrowerPosition, " &
                                        "departmentId, borrowDate, returnReason, status, remarks, createdAt, updatedAt) " &
                                        "SELECT 'supply', s.supplyId, s.itemName, CONCAT(u.firstName, ' ', u.lastName), u.position, " &
                                        "@departmentId, NOW(), NULL, 'Borrowed', @remarks, NOW(), NOW() " &
                                        "FROM supplies s, users u WHERE s.supplyId = @supplyId AND u.userId = @userId"

            Using borrowCmd As New MySqlCommand(borrowQuery, conn, transaction)
                borrowCmd.Parameters.AddWithValue("@supplyId", supplyId)
                borrowCmd.Parameters.AddWithValue("@userId", userId)
                borrowCmd.Parameters.AddWithValue("@departmentId", If(departmentId.HasValue, departmentId.Value, DBNull.Value))
                borrowCmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(purpose), "Supply assigned", purpose))
                borrowCmd.ExecuteNonQuery()
            End Using

            transaction.Commit()
            System.Diagnostics.Debug.WriteLine($"[v0] AssignSupplyToUser Success - SupplyId: {supplyId}, UserId: {userId}, Quantity: {quantity}")
            Return True

        Catch ex As Exception
            If transaction IsNot Nothing Then
                Try
                    transaction.Rollback()
                Catch
                End Try
            End If
            System.Diagnostics.Debug.WriteLine("[v0] AssignSupplyToUser Exception: " & ex.Message & vbCrLf & ex.StackTrace)
            Return False
        Finally
            If transaction IsNot Nothing Then
                Try
                    transaction.Dispose()
                Catch
                End Try
            End If
            If conn IsNot Nothing Then
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Dispose()
                Catch
                End Try
            End If
        End Try
    End Function

End Class
