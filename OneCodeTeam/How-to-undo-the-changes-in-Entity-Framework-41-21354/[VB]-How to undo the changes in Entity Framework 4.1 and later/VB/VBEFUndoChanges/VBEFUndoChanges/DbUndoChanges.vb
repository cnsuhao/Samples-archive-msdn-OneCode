'**************************** Module Header ******************************\
' Module Name:  DbUndoChanges.vb
' Project:      VBEFUndoChanges
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to undo the changes in Entity Framework.
' This file demonstrates how to undo the changes in different levels using DbContext
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Linq
Imports DBMySchool

Namespace VBEFUndoChanges
    Public Module DbUndoChanges
        ''' <summary>
        ''' This method demonstrates how to undo the changes in Context level using DbContext.
        ''' </summary>
        Public Sub UndoChangesInContext()
            Using school As New DBMySchool.DbMySchool()
                Dim course As DbCourse = school.DbCourses.FirstOrDefault()
                If course IsNot Nothing Then
                    Console.WriteLine("Before changes:")
                    course.ShowDbCourse()

                    Console.WriteLine("After changes:")
                    ' Change the course and the related department.
                    course.Title &= "-Modified"
                    course.Department.Name &= "-Modified"
                    course.ShowDbCourse()

                    Console.WriteLine("After Undo DbContext:")
                    ' Undo the whole Context.
                    school.UndoDbContext()
                    course.ShowDbCourse()
                End If
            End Using
        End Sub

        ''' <summary>
        ''' This method demonstrates how to undo the changes in Entities level using DbContext.
        ''' </summary>
        Public Sub UndoChangesInEntities()
            Using school As New DBMySchool.DbMySchool()
                Dim department As DbDepartment = school.DbDepartments.FirstOrDefault()
                Dim courses As IQueryable(Of DbCourse) = From c In school.DbCourses
                                                         Where c.DepartmentID = department.DepartmentID
                                                         Select c

                Console.WriteLine("Before changes:")
                For Each course As DbCourse In courses
                    course.ShowDbCourse()
                Next course

                ' Change the department and the related courses.
                Console.WriteLine("After changes:")
                department.Name &= "-Modified"
                For Each course As DbCourse In courses
                    course.Title &= "-Modified"
                    course.ShowDbCourse()
                Next course

                Console.WriteLine("After Undo Course Entities:")
                ' Undo the DbCourse type Entities. We will see the changes of the department 
                ' are not undone.
                school.UndoDbEntities(Of DbCourse)()
                For Each course As DbCourse In courses
                    course.ShowDbCourse()
                Next course
            End Using
        End Sub

        ''' <summary>
        ''' This method demonstrates how to undo the changes in Entity level using DbContext.
        ''' </summary>
        Public Sub UndoChangesInEntity()
            Using school As New DBMySchool.DbMySchool()
                Dim department As DbDepartment = school.DbDepartments.FirstOrDefault()
                Dim courses As IQueryable(Of DbCourse) = From c In school.DbCourses
                                                         Where c.DepartmentID = department.DepartmentID
                                                         Select c

                Console.WriteLine("Before changes:")
                For Each course As DbCourse In courses
                    course.ShowDbCourse()
                Next course

                ' Change the courses.
                Console.WriteLine("After changes:")
                For Each course As DbCourse In courses
                    course.Title &= "-Modified"
                    course.ShowDbCourse()
                Next course

                Console.WriteLine("After Undo the First Course Entity:")
                ' Undo one course. You can see only the changes of the first course are undone.
                school.UndoDbEntity(courses.FirstOrDefault())
                For Each course As DbCourse In courses
                    course.ShowDbCourse()
                Next course
            End Using
        End Sub


        ''' <summary>
        ''' This method demonstrates how to undo the changes in Property level using DbContext.
        ''' </summary>
        Public Sub UndoChangesInProperty()
            Using school As New DBMySchool.DbMySchool()
                Dim course As DbCourse = school.DbCourses.FirstOrDefault()
                Dim department As DbDepartment = school.DbDepartments.FirstOrDefault()
                If course IsNot Nothing Then
                    Console.WriteLine("Before changes:")
                    course.ShowDbCourse()

                    Console.WriteLine("After changes:")
                    ' Change the course Properties.
                    course.Title &= "-Modified"
                    course.Department = department
                    course.ShowDbCourse()

                    Console.WriteLine("After Undo Course Entity's Title Property:")
                    ' Undo the change in the Entity Property level. UndoDbEntityProperty 
                    ' method will undo the Title property of the course, but the change of the 
                    ' Department Property will not be undone.
                    school.UndoDbEntityProperty(course, "Title")
                    course.ShowDbCourse()
                End If
            End Using
        End Sub

        ''' <summary>
        ''' This method shows the information of the course and the related department.
        ''' </summary>
        ''' <param name="course">show the information in the course</param>
        <System.Runtime.CompilerServices.Extension()> _
        Private Sub ShowDbCourse(ByVal course As DbCourse)
            If course IsNot Nothing Then
                Console.WriteLine("CourseID:{0,-5} CourseName:{1,-15} DepartmentName:{2}", course.CourseID, course.Title, course.Department.Name)
            End If
        End Sub

    End Module
End Namespace
