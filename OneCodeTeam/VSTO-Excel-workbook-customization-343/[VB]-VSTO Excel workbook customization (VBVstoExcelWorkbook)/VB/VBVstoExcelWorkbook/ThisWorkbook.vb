
Public Class ThisWorkbook

    Private Sub ThisWorkbook_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        Me.ActionsPane.Controls.Add(New CourseQueryPane())
    End Sub

    Private Sub ThisWorkbook_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
