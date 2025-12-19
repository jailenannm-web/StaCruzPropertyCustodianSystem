Imports System
Imports System.Windows.Forms

Module Module1
    <STAThread()>
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New StaffLogin())
    End Sub
End Module
