Imports System
Imports System.Security.Cryptography
Imports System.Text

Public Class PasswordHelper
    ''' <summary>
    ''' Hash a password using SHA256 with salt
    ''' </summary>
    Public Shared Function HashPassword(password As String) As String
        Try
            ' Generate a random salt
            Dim salt As Byte() = New Byte(31) {}
            Using rng As New RNGCryptoServiceProvider()
                rng.GetBytes(salt)
            End Using

            ' Hash the password with salt using PBKDF2
            Using pbkdf2 As New Rfc2898DeriveBytes(password, salt, 10000)
                Dim hash As Byte() = pbkdf2.GetBytes(20)

                ' Combine salt and hash
                Dim hashWithSalt As Byte() = New Byte(salt.Length + hash.Length - 1) {}
                Array.Copy(salt, 0, hashWithSalt, 0, salt.Length)
                Array.Copy(hash, 0, hashWithSalt, salt.Length, hash.Length)

                ' Convert to Base64 for database storage
                Return Convert.ToBase64String(hashWithSalt)
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Error hashing password: " & ex.Message)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Verify if a password matches the stored hash
    ''' </summary>
    Public Shared Function VerifyPassword(password As String, storedHash As String) As Boolean
        Try
            ' Decode the stored hash from Base64
            Dim hashWithSalt As Byte() = Convert.FromBase64String(storedHash)

            ' Extract salt from the hash
            Dim salt As Byte() = New Byte(31) {}
            Array.Copy(hashWithSalt, 0, salt, 0, salt.Length)

            ' Hash the input password with the extracted salt
            Using pbkdf2 As New Rfc2898DeriveBytes(password, salt, 10000)
                Dim hash As Byte() = pbkdf2.GetBytes(20)

                ' Compare the hashes
                For i As Integer = 0 To hash.Length - 1
                    If hashWithSalt(i + salt.Length) <> hash(i) Then
                        Return False
                    End If
                Next

                Return True
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[v0] Error verifying password: " & ex.Message)
            Return False
        End Try
    End Function
End Class
