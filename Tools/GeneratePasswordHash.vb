Imports System

Module GeneratePasswordHash
    Sub Main()
        ' Temporary helper to produce password hashes using project's PasswordHelper.
        ' Usage: compile this file into a small exe referencing the project (or paste into immediate window of the project),
        ' then run and copy the printed hashes into the SQL script.

        ' Ensure System.Collections.Generic is available; use fully-qualified type if Option Infer/Option Strict settings vary
        Dim passwords As New System.Collections.Generic.Dictionary(Of String, String)()
        passwords.Add("SuperAdmin", "SuperAdmin@123")
        passwords.Add("Admin", "Admin@123")
        passwords.Add("Custodian", "Custodian@2025")
        passwords.Add("TestStaff", "Staff@1234")

        Console.WriteLine("Generating PBKDF2 hashes for default passwords (PasswordHelper.HashPassword must be available at runtime)...")
        For Each kvp In passwords
            Try
                Dim hash As String = PasswordHelper.HashPassword(kvp.Value)
                Console.WriteLine(kvp.Key & ": " & hash)
            Catch ex As Exception
                Console.WriteLine(kvp.Key & ": ERROR - " & ex.Message)
            End Try
        Next

        Console.WriteLine("\nCopy the generated Base64 hashes into sql/default_accounts.sql replacing the placeholders.")
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub
End Module
