'**************************** Module Header ******************************\
' Module Name:  ObjectUndoChanges.vb
' Project:      VBEFUndoChanges
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to undo the changes in Entity Framework.
' This file demonstrates how to undo the changes in different levels using ObjectContext
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
Imports ObjMySchool

Namespace VBEFUndoChanges
    Public Module ObjectUndoChanges
        ''' <summary>
        ''' This method demonstrates how to undo the changes in Context level using ObjectContext.
        ''' </summary>
        Public Sub UndoChangesInContext()
            Using school As New ObjectMySchool()
                Dim course As ObjectCourse = school.ObjectCourses.FirstOrDefault()
                If course IsNot Nothing Then
                    Console.WriteLine("Before changes:")
                    course.ShowObjectCourse()

                    Console.WriteLine("After changes:")
                    ' Change the course and the related department
                    course.Title &= "-Modified"
                    course.Department.Name &= "-Modified"
                    course.ShowObjectCourse()

                    Console.WriteLine("After Undo ObjectContext")
                    ' Undo the whole Context
                    school.UndoObjectContext()
                    course.ShowObjectCourse()

                End If
            End Using
        End Sub

        ''' <summary>
        ''' This method demonstrates how to undo the changes in Entities level using ObjectContext.
        ''' </summary>
        Public Sub UndoChangesInEntities()
            Using school As New ObjectMySchool()
                Dim department As ObjectDepartment = school.ObjectDepartments.FirstOrDefault()
                Dim courses As IQueryable(Of ObjectCourse) = From c In school.ObjectCourses
                                                             Where c.DepartmentID = department.DepartmentID
                                                             Select c

                Console.WriteLine("Before changes:")
                For Each course As ObjectCourse In courses
                    course.ShowObjectCourse()
                Next course

                ' Change the department and the related course.
                Console.WriteLine("After changes:")
                department.Name &= "-Modified"
                For Each course As ObjectCourse In courses
                    course.Title &= "-Modified"
                    course.ShowObjectCourse()
                Next course

                Console.WriteLine("After Undo Course Entities:")
                ' Undo the ObjectCourse type Entities. We will see the changes of the department 
                ' are not undone.
                school.UndoObjectEntities(Of ObjectCourse)(school.ObjectCourses)
                For Each course As ObjectCourse In courses
                    course.ShowObjectCourse()
                Next course
            End Using
        End Sub

        ''' <summary>
        ''' This method demonstrates how to undo the changes in Entity level using ObjectContext.
        ''' </summary>
        Public Sub UndoChangesInEnity()
            Using school As New ObjectMySchool()
                Dim department As ObjectDepartment = school.ObjectDepartments.FirstOrDefault()
                Dim courses As IQueryable(Of ObjectCourse) = From c In school.ObjectCourses
                                                             Where c.DepartmentID = department.DepartmentID
                                                             Select c

                Console.WriteLine("Before changes:")
                For Each course As ObjectCourse In courses
                    course.ShowObjectCourse()
                Next course

                ' Change the course.
                Console.WriteLine("After changes:")
                For Each course As ObjectCourse In courses
                    course.Title &= "-Modified"
                    course.ShowObjectCourse()
                Next course

                Console.WriteLine("After Undo the First Course Entity:")
                ' Undo one course. You can see only the changes of the first course are undone.
                school.UndoObjectEntity(courses.FirstOrDefault())
                For Each course As ObjectCourse In courses
                    course.ShowObjectCourse()
                Next course
            End Using
        End Sub

        ''' <summary>
        ''' This method demonstrates how to undo the changes in Property level using ObjectContext.
        ''' </summary>
        Public Sub UndoChangesInProperty()
            Using school As New ObjectMySchool()
                Dim course As ObjectCourse = school.ObjectCourses.FirstOrDefault()
                Dim department As ObjectDepartment = school.ObjectDepartments.FirstOrDefault()
                If course IsNot Nothing Then
                    Console.WriteLine("Before changes:")
                    course.ShowObjectCourse()

                    Console.WriteLine("After changes:")
                    ' Change the course Properties.
                    course.Title &= "-Modified"
                    course.Department = department
                    course.ShowObjectCourse()

                    Console.WriteLine("After Undo Course Entity's Title Property:")
                    ' Undo the change in the Entity Property level. UndoObjectEntityProperty 
                    ' method will undo the Title property of the course, but the change of the 
                    ' Department Property will not be undone.
                    school.UndoObjectEntityProperty(course, "Title")
                    course.ShowObjectCourse()
                End If
            End Using
        End Sub

        ''' <summary>
        ''' This method shows the information of the course and the related department.
        ''' </summary>
        ''' <param name="course">show the information in the course</param>
        <System.Runtime.CompilerServices.Extension()> _
        Private Sub ShowObjectCourse(ByVal course As ObjectCourse)
            If course IsNot Nothing Then
                Console.WriteLine("CourseID:{0,-5} CourseName:{1,-15} DepartmentName:{2}", course.CourseID, course.Title, course.Department.Name)
            End If
        End Sub
    End Module
End Namespace
