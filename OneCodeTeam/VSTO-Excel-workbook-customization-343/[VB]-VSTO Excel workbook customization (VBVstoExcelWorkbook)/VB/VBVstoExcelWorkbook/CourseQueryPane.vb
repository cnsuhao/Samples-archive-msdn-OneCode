Public Class CourseQueryPane

    Private Sub CourseQueryPane_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StudentListTableAdapter.Fill(SchoolDataSet.StudentList)

    End Sub

    Private Sub cmdQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuery.Click
        Globals.Sheet1.UpdateCourseList(Me.cboName.Text.ToString().Trim())
    End Sub
End Class
