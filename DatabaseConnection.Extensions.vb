Imports System
Imports System.Data
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

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
    
End Class
