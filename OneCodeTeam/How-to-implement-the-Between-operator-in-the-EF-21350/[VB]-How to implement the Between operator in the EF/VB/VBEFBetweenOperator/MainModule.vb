'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBEFBetweenOperator
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to implement the Between operation in Entity 
' Framework.
' In this sample, we use two ways to implement the Between operation in Enitity
' Framework:
' 1. Use the Entity SQL;
' 2. Use the extension method and expression tree.
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
Imports System.Data.Objects

Namespace VBEFBetweenOperator
    Friend Class MainModule
        Shared Sub Main(ByVal args() As String)
            ' Use the Entity SQL to implement the Between operation
            Dim courses As IEnumerable(Of Course) = GetCoursesByEntitySQL()
            ShowCourses("Get the Courses by Entity SQL", courses)
            Console.WriteLine()

            ' Use the extension method to implement the Between operation
            courses = GetCoursesByExtension()
            ShowCourses("Get the Courses by extension method", courses)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit.....")
            Console.ReadKey()
        End Sub


        Private Shared Sub ShowCourses(ByVal showString As String, ByVal courses As IEnumerable(Of Course))
            Console.WriteLine(showString)
            For Each course As Course In courses
                Console.WriteLine("CourseID:{0,-10} CourseTitle:{1,-15} Department:{2,-10}",
                                  course.CourseID, course.Title, course.DepartmentID)
            Next course
        End Sub

        ''' <summary>
        ''' Use the Entity SQL to implement the Between operation
        ''' </summary>
        ''' <returns>course list</returns>
        Private Shared Function GetCoursesByEntitySQL() As List(Of Course)
            Using school As New School()
                Return school.Courses.Where(
                    "it.DepartmentID between @lowerbound And @highbound",
                    New ObjectParameter("lowerbound", 1),
                    New ObjectParameter("highbound", 5)).ToList()
            End Using
        End Function

        ''' <summary>
        ''' Use the extension method to implement the Between operation
        ''' </summary>
        ''' <returns>course list</returns>
        Private Shared Function GetCoursesByExtension() As List(Of Course)
            Using school As New School()
                Return school.Courses.Between(Function(c) c.CourseID, "C1050", "C3141").ToList()
            End Using
        End Function
    End Class
End Namespace
