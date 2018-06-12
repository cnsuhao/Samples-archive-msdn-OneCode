'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBEFCodeFirstNonTableObjects
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to work with nontable database objects in Code 
' First.
' We can use Code First to map tables in the database, but database also supports 
' many other types of objects, including stored procedures and views.In the sample,
' we will demonstrate how to use the stored procedure and views in Code First.
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
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.SqlClient

Namespace VBEFCodeFirstNonTableObjects
    Friend Class MainModule
        Shared Sub Main(ByVal args() As String)
            Database.SetInitializer(New CreateDatabaseIfNotExists(Of MySchoolContext)())

            Console.WriteLine("Get the Courses from the EnglishCourse view:")
            FillView()
            Console.WriteLine()

            Dim firstCourse As Course = GetFirstCourse()

            ' First, get the CourseDepartment from the dbo.CourseExtInfoSP, and change 
            ' the Title of Course. Then get the CourseDepartment again, and show the 
            ' Title of it. Because the CourseDepartment isn't the Entity model object,
            ' the change of it isn't saved.
            Console.WriteLine("Execute the dbo.CourseExtInfoSP stored procedure:")
            ExecuteCourseExtInfoSP(firstCourse.CourseID, True)
            Console.WriteLine("After change the Course.Title:")
            ExecuteCourseExtInfoSP(firstCourse.CourseID, False)
            Console.WriteLine()

            ' First, get the Department from the dbo.dbo.DepartmentInfo, and change 
            ' the Budget of Department. Then get the Department again, and show the 
            ' Budget of it. Because the Department is the Entity model object, the 
            ' change of it is saved.
            Console.WriteLine("Execute the dbo.DepartmentInfo stored procedure:")
            ExecuteDepartmentSP(firstCourse.DepartmentID, True)
            Console.WriteLine("After change the Department.Budget:")
            ExecuteDepartmentSP(firstCourse.DepartmentID, False)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit...")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Get the English Course list from the EnglishCourse view.
        ''' </summary>
        Private Shared Sub FillView()
            Using school As New MySchoolContext("MySchool")
                ' Because the view doesn't have the same column name of the CourseName 
                ' property on Course class, we need to alias the Title column in the 
                ' Select statement.
                Dim courses As DbSqlQuery(Of Course) = school.Courses.SqlQuery(
                    "Select CourseID," & ControlChars.CrLf & _
                    "Title as CourseName," & ControlChars.CrLf & _
                    "Credits," & ControlChars.CrLf & _
                    "DepartmentID" & ControlChars.CrLf & _
                    "from dbo.EnglishCourse")

                For Each course As Course In courses
                    Console.WriteLine("Course:{0,-20} Department:{1,-20}", course.CourseName, course.Department.Name)
                Next course
            End Using
        End Sub

        Private Shared Function GetFirstCourse() As Course
            Using school As New MySchoolContext("MySchool")
                Dim firstCourse As Course = school.Courses.FirstOrDefault()
                Return firstCourse
            End Using
        End Function

        ''' <summary>
        ''' Get the CourseDepartment class object from the stored procedure dbo.CourseExtInfo.
        ''' </summary>
        ''' <param name="courseID">It is the CourseID of the Course we get from the dbo.CourseExtInfo.</param>
        ''' <param name="isChanged">If it is true, change and save the Course we get.</param>
        Private Shared Sub ExecuteCourseExtInfoSP(ByVal courseID As Int32, ByVal isChanged As Boolean)
            Using school As New MySchoolContext("MySchool")
                ' Entity Framework will take care of wrapping the parameters of SqlQuery into 
                ' DbParameter objects to help prevent against SQL injection attacks. It use a 
                ' @p prefix for parameters followed by an integer index. Entity Framework will
                ' will match these indexes up with the list of parameters you provide after the 
                ' query string.
                Dim courseSP As IEnumerable(Of CourseDepartment) =
                    school.Database.SqlQuery(Of CourseDepartment)("Exec dbo.CourseExtInfo @p0", courseID)
                Dim courseDepartment As CourseDepartment = courseSP.SingleOrDefault()

                If courseDepartment IsNot Nothing Then
                    Console.WriteLine("Course:{0,-20} Department:{1,-20}",
                                      courseDepartment.Title, courseDepartment.DepartmentName)

                    If isChanged Then
                        ' Change and save the value of the courseDepartment.Title
                        courseDepartment.Title = "CourseDepartment"
                        school.SaveChanges()
                    End If
                End If
            End Using
        End Sub

        ''' <summary>
        ''' Get the Department class object from the stored procedure dbo.DepartmentInfo.
        ''' </summary>
        ''' <param name="departmentID">It is the DepartmentID of the Department we get from the dbo.DepartmentInfo.</param>
        ''' <param name="isChanged">If it is true, change and save the Department we get.</param>
        Private Shared Sub ExecuteDepartmentSP(ByVal departmentID As Int32, ByVal isChanged As Boolean)
            Using school As New MySchoolContext("MySchool")
                ' Define two SqlParameter objects that are used in the SqlQuery method. The courseCount 
                ' is the output parameter.
                'INSTANT VB NOTE: The variable departmentId was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
                Dim departmentId_Renamed As New SqlParameter("@DepartmentID", departmentID)
                Dim courseCount As SqlParameter = New SqlParameter With
                                                  {
                                                   .ParameterName = "@CourseCount",
                                                   .Value = -1,
                                                   .Direction = ParameterDirection.Output
                                                  }

                ' We add the SqlParameter objects in the SqlQuery method, and use the parameter names 
                ' in the query string.
                Dim departmentSP As IEnumerable(Of Department) = school.Departments.SqlQuery(
                    "Exec dbo.DepartmentInfo @DepartmentID,@CourseCount out", departmentId_Renamed, courseCount)
                Dim department As Department = departmentSP.SingleOrDefault()

                If department IsNot Nothing Then
                    Console.WriteLine("Department:{0,-15}  Budget:{1,-10}  Quantity of Course:{2} ",
                                      department.Name, department.Budget, courseCount.Value)

                    If isChanged Then
                        ' Change and save the value of the department.Budget.
                        department.Budget += 1
                        school.SaveChanges()
                    End If
                End If
            End Using
        End Sub
    End Class
End Namespace
