/****************************** Module Header ******************************\
* Module Name:    DBCreator.cs
* Project:        CSASPNETCodeFirstCRUDInGridViewWithDetailsView
* Copyright (c) Microsoft Corporation
*
* The whole file takes the ability of creating database with several tables
* from the defined model classes.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;

namespace ASPNETCodeFirstCRUDInGridView
{
    public class DBCreator : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student_Course> StudentCourses { get; set; }

        /// <summary>
        /// This method is used to remove the current db and re-create one
        /// again with initialized data contents.
        /// <param name="flag">Whether the whole db is re-created or not.</param>
        /// </summary>
        public static void DBAutoCreator(bool flag)
        {
            if(flag)
            {
            Database.SetInitializer<DBCreator>(new DropCreateDatabaseAlways<DBCreator>());

            // Auto create 5 students, 5 courses and their chosen lessons.
            using (DBCreator entity = new DBCreator())
            {
                List<Student> students = new List<Student>()
                {
                    new Student{StudentName="Jack"},
                    new Student{StudentName="Mary"},
                    new Student{StudentName="Tom"},
                    new Student{StudentName="Jerry"},
                    new Student{StudentName="Rose"}
                };

                List<Course> courses = new List<Course>() 
                {
                    new Course{CourseName="English"},
                    new Course{CourseName="Chinese"},
                    new Course{CourseName="Maths"},
                    new Course{CourseName="Music"},
                    new Course{CourseName="Programming"},
                };

                foreach (Student item in students)
                {
                    entity.Students.Add(item);
                }
                foreach (Course item in courses)
                {
                    entity.Courses.Add(item);
                }

                //To save here first is that we can get the auto-generated primary key
                entity.SaveChanges();

                List<Student_Course> scs = new List<Student_Course>();

                Random rd = new Random(DateTime.Now.Millisecond);

                foreach (Student item in students)
                {

                    foreach (Course c in courses)
                    {
                        Student_Course sc = new Student_Course 
                        { 
                            Sid = item.StudentId,
                            Cid = c.CourseId, 
                            Score = Math.Round(rd.NextDouble() * 41 + 60, 2)
                        };
                        entity.StudentCourses.Add(sc);
                        Thread.Sleep(10);
                    }
                }

                entity.SaveChanges();
            }

            }
        }
    }
}