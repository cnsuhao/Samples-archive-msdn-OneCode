/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSEFCodeFirstNonTableObjects
Copyright (c) Microsoft Corporation.

This sample demonstrates how to work with nontable database objects in Code 
First.
We can use Code First to map tables in the database, but database also supports 
many other types of objects, including stored procedures and views.In the sample,
we will demonstrate how to use the stored procedure and views in Code First.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.SqlClient;

namespace CSEFCodeFirstNonTableObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MySchoolContext>());

            Console.WriteLine("Get the Courses from the EnglishCourse view:");
            FillView();
            Console.WriteLine();

            Course firstCourse = GetFirstCourse();

            // First, get the CourseDepartment from the dbo.CourseExtInfoSP, and change 
            // the Title of Course. Then get the CourseDepartment again, and show the 
            // Title of it. Because the CourseDepartment isn't the Entity model object,
            // the change of it isn't saved.
            Console.WriteLine("Execute the dbo.CourseExtInfoSP stored procedure:");
            ExecuteCourseExtInfoSP(firstCourse.CourseID, true);
            Console.WriteLine("After change the Course.Title:");
            ExecuteCourseExtInfoSP(firstCourse.CourseID, false);
            Console.WriteLine();

            // First, get the Department from the dbo.dbo.DepartmentInfo, and change 
            // the Budget of Department. Then get the Department again, and show the 
            // Budget of it. Because the Department is the Entity model object, the 
            // change of it is saved.
            Console.WriteLine("Execute the dbo.DepartmentInfo stored procedure:");
            ExecuteDepartmentSP(firstCourse.DepartmentID, true);
            Console.WriteLine("After change the Department.Budget:");
            ExecuteDepartmentSP(firstCourse.DepartmentID, false);
            Console.WriteLine();
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Get the English Course list from the EnglishCourse view.
        /// </summary>
        static void FillView()
        {
            using (MySchoolContext school = new MySchoolContext("MySchool"))
            {
                // Because the view doesn't have the same column name of the CourseName 
                // property on Course class, we need to alias the Title column in the 
                // Select statement.
                DbSqlQuery<Course> courses = school.Courses.SqlQuery(
                     @"Select CourseID,
                      Title as CourseName,
                      Credits,
                      DepartmentID
                      from dbo.EnglishCourse");

                foreach (Course course in courses)
                {
                    Console.WriteLine("Course:{0,-20} Department:{1,-20}", course.CourseName, course.Department.Name);
                }
            }
        }

        static Course GetFirstCourse()
        {
            using (MySchoolContext school = new MySchoolContext("MySchool"))
            {
                Course firstCourse = school.Courses.FirstOrDefault();
                return firstCourse;
            }
        }

        /// <summary>
        /// Get the CourseDepartment class object from the stored procedure dbo.CourseExtInfo.
        /// </summary>
        /// <param name="courseID">It is the CourseID of the Course we get from the dbo.CourseExtInfo.</param>
        /// <param name="isChanged">If it is true, change and save the Course we get.</param>
        static void ExecuteCourseExtInfoSP(Int32 courseID, bool isChanged)
        {
            using (MySchoolContext school = new MySchoolContext("MySchool"))
            {
                // Entity Framework will take care of wrapping the parameters of SqlQuery into 
                // DbParameter objects to help prevent against SQL injection attacks. It use a 
                // @p prefix for parameters followed by an integer index. Entity Framework will
                // will match these indexes up with the list of parameters you provide after the 
                // query string.
                IEnumerable<CourseDepartment> courseSP = school.Database.SqlQuery<CourseDepartment>(
     @"Exec dbo.CourseExtInfo @p0", courseID);
                CourseDepartment courseDepartment = courseSP.SingleOrDefault();

                if (courseDepartment != null)
                {
                    Console.WriteLine("Course:{0,-20} Department:{1,-20}", 
                        courseDepartment.Title, courseDepartment.DepartmentName);

                    if (isChanged)
                    {
                        // Change and save the value of the courseDepartment.Title
                        courseDepartment.Title = "CourseDepartment";
                        school.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Get the Department class object from the stored procedure dbo.DepartmentInfo.
        /// </summary>
        /// <param name="departmentID">It is the DepartmentID of the Department we get from the dbo.DepartmentInfo.</param>
        /// <param name="isChanged">If it is true, change and save the Department we get.</param>
        static void ExecuteDepartmentSP(Int32 departmentID, bool isChanged)
        {
            using (MySchoolContext school = new MySchoolContext("MySchool"))
            {
                // Define two SqlParameter objects that are used in the SqlQuery method. The courseCount 
                // is the output parameter.
                SqlParameter departmentId = new SqlParameter("@DepartmentID", departmentID);
                SqlParameter courseCount = new SqlParameter
                {
                    ParameterName = "@CourseCount",
                    Value = -1,
                    Direction = ParameterDirection.Output
                };

                // We add the SqlParameter objects in the SqlQuery method, and use the parameter names 
                // in the query string.
                IEnumerable<Department> departmentSP = school.Departments.SqlQuery(@"Exec dbo.DepartmentInfo @DepartmentID,@CourseCount out",
                    departmentId, courseCount);
                Department department = departmentSP.SingleOrDefault();

                if (department != null)
                {
                    Console.WriteLine("Department:{0,-15}  Budget:{1,-10}  Quantity of Course:{2} ", 
                        department.Name, department.Budget, courseCount.Value);

                    if (isChanged)
                    {
                        // Change and save the value of the department.Budget.
                        department.Budget++;
                        school.SaveChanges();
                    }
                }
            }
        }
    }
}
