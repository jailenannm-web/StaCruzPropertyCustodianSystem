Public Class PropertyIssuance
    Private Sub fundCluster_Click(sender As Object, e As System.EventArgs) Handles fundCluster.Click

    End Sub

    Private Sub pcEntityName_TextChanged(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub lblName_Click(sender As Object, e As System.EventArgs) Handles lblName.Click

    End Sub

    Private Sub PropertyIssuance_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtname_TextChanged(sender As Object, e As System.EventArgs) Handles entityNameTxt.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles propertyAcknowledgement.CellContentClick

    End Sub

    Private Sub Label6_Click(sender As Object, e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As System.EventArgs) Handles RoundedButton2.Click
        Dim StaffDashboard As New StaffDashboard()
        StaffDashboard.Show()
        Me.Close()
    End Sub
End Class