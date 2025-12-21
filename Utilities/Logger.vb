Imports System
Imports System.IO

Public Module Logger
    Private ReadOnly LogPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.log")

    Public Sub LogInfo(message As String)
        Try
            File.AppendAllText(LogPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO  {message}{Environment.NewLine}")
        Catch
        End Try
    End Sub

    Public Sub LogError(message As String, Optional ex As Exception = Nothing)
        Try
            Dim full As String = message
            If ex IsNot Nothing Then
                full &= $" | {ex.GetType().FullName}: {ex.Message}{Environment.NewLine}{ex.StackTrace}"
            End If
            File.AppendAllText(LogPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR {full}{Environment.NewLine}")
        Catch
        End Try
    End Sub
End Module