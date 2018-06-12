'***************************** Module Header ******************************\
'* Module Name:    DBCreator.vb
'* Project:        VBASPNETCodeFirstCRUDInGridViewWithDetailsView
'* Copyright (c) Microsoft Corporation
'*
'* The whole file takes the ability of creating database with several tables
'* from the defined model classes.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'* All other rights reserved.
'\**************************************************************************


Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.Threading

Public Class DBCreator
    Inherits DbContext
    Public Property Students() As DbSet(Of Student)
        Get
            Return _students
        End Get
        Set(ByVal value As DbSet(Of Student))
            _students = value
        End Set
    End Property
    Private _students As DbSet(Of Student)
    Public Property Courses() As DbSet(Of Course)
        Get
            Return _courses
        End Get
        Set(ByVal value As DbSet(Of Course))
            _courses = value
        End Set
    End Property
    Private _courses As DbSet(Of Course)
    Public Property StudentCourses() As DbSet(Of Student_Course)
        Get
            Return _studentCourses
        End Get
        Set(ByVal value As DbSet(Of Student_Course))
            _studentCourses = value
        End Set
    End Property
    Private _studentCourses As DbSet(Of Student_Course)

    ''' <summary>
    ''' This method is used to remove the current db and re-create one
    ''' again with initialized data contents.
    ''' <param name="flag">Whether the whole db is re-created or not.</param>
    ''' </summary>
    Public Shared Sub DBAutoCreator(ByVal flag As Boolean)
        If flag Then
            Database.SetInitializer(Of DBCreator)(New DropCreateDatabaseAlways(Of DBCreator)())

            ' Auto create 5 students, 5 courses and their chosen lessons.
            Using entity As New DBCreator()
                Dim students As New List(Of Student)() From { _
                 New Student() With { _
                  .StudentName = "Jack" _
                 }, _
                 New Student() With { _
                  .StudentName = "Mary" _
                 }, _
                 New Student() With { _
                  .StudentName = "Tom" _
                 }, _
                 New Student() With { _
                  .StudentName = "Jerry" _
                 }, _
                 New Student() With { _
                  .StudentName = "Rose" _
                 } _
                }

                Dim courses As New List(Of Course)() From { _
                 New Course() With { _
                  .CourseName = "English" _
                 }, _
                 New Course() With { _
                  .CourseName = "Chinese" _
                 }, _
                 New Course() With { _
                  .CourseName = "Maths" _
                 }, _
                 New Course() With { _
                  .CourseName = "Music" _
                 }, _
                 New Course() With { _
                  .CourseName = "Programming" _
                 } _
                }

                For Each item As Student In students
                    entity.Students.Add(item)
                Next
                For Each item As Course In courses
                    entity.Courses.Add(item)
                Next

                'To save here first is that we can get the auto-generated primary key
                entity.SaveChanges()

                Dim scs As New List(Of Student_Course)()

                Dim rd As New Random(DateTime.Now.Millisecond)

                For Each item As Student In students

                    For Each c As Course In courses
                        Dim sc As New Student_Course() With { _
                         .Sid = item.StudentId, _
                         .Cid = c.CourseId, _
                         .Score = Math.Round(rd.NextDouble() * 41 + 60, 2) _
                        }
                        entity.StudentCourses.Add(sc)
                        Thread.Sleep(10)
                    Next
                Next

                entity.SaveChanges()

            End Using
        End If
    End Sub
End Class
