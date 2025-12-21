Imports System
Imports System.Windows.Forms

Module Module1
    <STAThread()>
    Public Sub Main()
        ' Global exception handlers to capture unhandled errors
        AddHandler Application.ThreadException, Sub(sender As Object, e As Threading.ThreadExceptionEventArgs)
                                                    Try
                                                        Logger.LogError("Unhandled UI thread exception", e.Exception)
                                                    Catch
                                                    End Try
                                                End Sub
        AddHandler AppDomain.CurrentDomain.UnhandledException, Sub(sender As Object, e As UnhandledExceptionEventArgs)
                                                                   Try
                                                                       Dim ex = TryCast(e.ExceptionObject, Exception)
                                                                       If ex IsNot Nothing Then
                                                                           Logger.LogError("Unhandled domain exception", ex)
                                                                       Else
                                                                           Logger.LogError("Unhandled domain exception (non-Exception)")
                                                                       End If
                                                                   Catch
                                                                   End Try
                                                               End Sub

        Logger.LogInfo("Application starting")

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New StaffLogin())
    End Sub
End Module
