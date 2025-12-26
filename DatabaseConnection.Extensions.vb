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
        Try
            conn = GetConnection()
            If conn Is Nothing Then Return False
            If Not SafeOpenConnection(conn) Then Return False
            
            ' Auto-generate propertyNumber if empty
            If String.IsNullOrWhiteSpace(propertyNumber) Then
                propertyNumber = GeneratePropertyNumber()
            End If
            
            ' Auto-generate internalCodes if empty
            If String.IsNullOrWhiteSpace(internalCodes) Then
                internalCodes = GenerateInternalCode()
            End If
            
            ' Insert property into database
            Dim query As String = "INSERT INTO properties (itemName, category, description, unitOfMeasure, " &
                                 "propertyNumber, serialNumber, acquisitionDate, acquisitionCost, totalCost, " &
                                 "sourceOfFunds, assignedTo, departmentId, location, `condition`, status, internalCodes, " &
                                 "createdAt, updatedAt) VALUES (@itemName, @category, @description, @unitOfMeasure, " &
                                 "@propertyNumber, @serialNumber, @acquisitionDate, @acquisitionCost, @totalCost, " &
                                 "@sourceOfFunds, @assignedTo, @departmentId, @location, @condition, @status, @internalCodes, " &
                                 "NOW(), NOW())"
            
            Using cmd As New MySqlCommand(query, conn)
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
                Return rowsAffected > 0
            End Using
            
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] AddProperty Exception: " & ex.Message)
            MessageBox.Show("Error adding property: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
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
    
End Class
