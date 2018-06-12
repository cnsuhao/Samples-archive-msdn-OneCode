'***************************** Module Header ******************************\
'* Module Name:    DBObjectDataSource.vb
'* Project:        VBASPNETCodeFirstCRUDInGridViewWithDetailsView
'* Copyright (c) Microsoft Corporation
'*
'* The whole file offers several CRUDs for Students page, Courses page as well
'* as CourseChoice page.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'* All other rights reserved.
'\**************************************************************************


Imports System.Collections.Generic
Imports System.Linq
Imports System.Data

''' <summary>
''' This is a class that is used for CRUD
''' </summary>
Public NotInheritable Class DBObjectDataSource
    Private Sub New()
    End Sub

#Region "Students.aspx"
    ''' <summary>
    ''' Select all the students' records in model form.
    ''' </summary>
    Public Shared Function SelectAllStudents() As List(Of Student)
        Using ds As New DBCreator()
            Return ds.Students.ToList()
        End Using
    End Function

    ''' <summary>
    ''' Updating an existing student instance.
    ''' </summary>
    Public Shared Sub UpdateStudent(ByVal StudentId As Integer, ByVal StudentName As String)
        Using ds As New DBCreator()
            ds.Entry(Of Student)(New Student() With { _
             .StudentId = StudentId, _
             .StudentName = StudentName _
            }).State = EntityState.Modified
            ds.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Deleting an existing student instance.
    ''' </summary>
    Public Shared Sub DeleteStudent(ByVal StudentId As Integer)
        Using ds As New DBCreator()
            ds.Entry(Of Student)(New Student() With { _
             .StudentId = StudentId _
            }).State = EntityState.Deleted
            ds.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Adding an existing student instance.
    ''' </summary>
    Public Shared Sub AddNewStudent(ByVal StudentName As String)
        Using ds As New DBCreator()
            ds.Students.Add(New Student() With { _
             .StudentName = StudentName _
            })
            ds.SaveChanges()
        End Using
    End Sub

#End Region

#Region "Courses.aspx"

    ''' <summary>
    ''' Select all courses.
    ''' </summary>
    Public Shared Function SelectAllCourses() As List(Of Course)
        Using ds As New DBCreator()
            Return ds.Courses.ToList()
        End Using
    End Function

    ''' <summary>
    ''' Add a new course.
    ''' </summary>
    Public Shared Sub AddNewCourse(ByVal CourseName As String)
        Using ds As New DBCreator()
            ds.Entry(Of Course)(New Course() With { _
             .CourseName = CourseName _
            }).State = EntityState.Added
            ds.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Update an existing course.
    ''' </summary>
    Public Shared Sub UpdateCourse(ByVal CourseId As Integer, ByVal CourseName As String)
        Using ds As New DBCreator()
            ds.Entry(Of Course)(New Course() With { _
             .CourseName = CourseName, _
             .CourseId = CourseId _
            }).State = EntityState.Modified
            ds.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Select a specific course by id.
    ''' </summary>
    Public Shared Function SelectCourseById(ByVal CourseId As Integer) As List(Of Course)
        Using ds As New DBCreator()
            Return ds.Courses.Where(Function(c) c.CourseId = CourseId).ToList()
        End Using
    End Function

#End Region

#Region "CourseChoice.aspx"
    ''' <summary>
    ''' Selecting courses and scores according to the specific student.
    ''' </summary>
    Public Shared Function SelectAllCoursesByStudentId(ByVal StudentId As Integer) As List(Of TempStudentCourse)
        Using ds As New DBCreator()
            Dim result = ds.StudentCourses.Where(Function(sc) sc.Sid = StudentId).[Select](Function(s) New TempStudentCourse() With { _
             .Id = s.Id, _
             .CourseName = s.Course.CourseName, _
             .Score = s.Score, _
             .Cid = s.Cid, _
             .Sid = s.Sid _
            })


            Return result.ToList()
        End Using
    End Function

    ''' <summary>
    ''' Selecting courses and scores according to the specific student.
    ''' </summary>
    Public Shared Sub UpdateCourseScore(ByVal Id As Integer, ByVal Score As Double)
        Using ds As New DBCreator()
            Dim sc As Student_Course = ds.StudentCourses.First(Function(s) s.Id = Id)
            sc.Score = Score
            ds.Entry(Of Student_Course)(sc).State = EntityState.Modified
            ds.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Deleting specific courses'scores by their Ids.
    ''' </summary>
    Public Shared Sub DeleteCourseScore(ByVal Id As Integer)
        Using ds As New DBCreator()
            ds.Entry(Of Student_Course)(New Student_Course() With { _
             .Id = Id _
            }).State = EntityState.Deleted
            ds.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Adding a new student's chosen course and a score
    ''' </summary>
    Public Shared Sub AddNewCourseAndScore(ByVal sid As Integer, ByVal cid As Integer, ByVal score As Double)
        Using ds As New DBCreator()
            ds.Entry(Of Student_Course)(New Student_Course() With { _
             .Sid = sid, _
             .Cid = cid, _
             .Score = score _
            }).State = EntityState.Added
            ds.SaveChanges()
        End Using
    End Sub

    ''' <summary>
    ''' Get all the rest courses for the specific student
    ''' </summary>
    Public Shared Function SelectRestCourses(ByVal sid As Integer) As List(Of Course)
        Using ds As New DBCreator()
            Dim notchoosenCids = ds.Courses.[Select](Function(c) c.CourseId).Except(ds.StudentCourses.Where(Function(sc) sc.Sid = sid).[Select](Function(s) s.Cid))
            Dim result = From c In ds.Courses Join n In notchoosenCids On c.CourseId Equals n Select c
            Return result.ToList()
        End Using
    End Function
#End Region
End Class