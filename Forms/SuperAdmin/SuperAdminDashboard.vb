Imports System
Imports System.Windows.Forms

' Compatibility shim: Some modules reference "SuperAdminDashboard".
' SADashboard.vb declares a partial class named SADashboard. To avoid changing many files,
' provide this lightweight class that inherits from SADashboard so TryCast checks succeed.

Public Class SuperAdminDashboard
    Inherits SADashboard

    ' No additional members required - this class exists only for type compatibility.
End Class