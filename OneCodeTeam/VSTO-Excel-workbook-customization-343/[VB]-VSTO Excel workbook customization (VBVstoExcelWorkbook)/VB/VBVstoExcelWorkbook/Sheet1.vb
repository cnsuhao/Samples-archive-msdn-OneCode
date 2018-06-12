
Public Class Sheet1

    Friend Sub UpdateCourseList(ByVal studentName As String)
        ' Update the title.
        Me.Range("A1", "A1").Value2 = "Course List for " & studentName
        ' Update the DataTable.
        CourseListTableAdapter.Fill(SchoolDataSet.CourseList, studentName)
    End Sub


    Private Sub Sheet1_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup

    End Sub

    Private Sub Sheet1_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
