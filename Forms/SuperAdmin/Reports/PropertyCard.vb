Imports System.Windows.Forms
Imports System.Linq
Imports System
Imports System.Drawing
Imports Microsoft.VisualBasic

Partial Public Class PropertyCard
    Public Sub New()
        InitializeComponent()
    End Sub

    ' ===============================
    ' Added method so other forms can 
    ' pass requestId to this UserControl
    ' ===============================
    Public Sub LoadRequestData(requestId As String)
        If String.IsNullOrEmpty(requestId) Then
            MessageBox.Show("No Request ID provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' TODO: Replace this with real loading logic.
        MessageBox.Show("PropertyCard received Request ID: " & requestId,
                        "Loaded",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub PropertyCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
