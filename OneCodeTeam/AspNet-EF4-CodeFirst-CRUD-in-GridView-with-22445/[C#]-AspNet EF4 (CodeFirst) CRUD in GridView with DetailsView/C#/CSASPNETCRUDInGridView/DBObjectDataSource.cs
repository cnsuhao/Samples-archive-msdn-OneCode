/****************************** Module Header ******************************\
* Module Name:    DBObjectDataSource.cs
* Project:        CSASPNETCodeFirstCRUDInGridViewWithDetailsView
* Copyright (c) Microsoft Corporation
*
* The whole file offers several CRUDs for Students page, Courses page as well
* as CourseChoice page.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace ASPNETCodeFirstCRUDInGridView
{
    /// <summary>
    /// This is a class that is used for CRUD
    /// </summary>
    public static class DBObjectDataSource
    {

        #region Students.aspx
        /// <summary>
        /// Select all the students' records in model form.
        /// </summary>
        public static List<Student> SelectAllStudents()
        {
            using (DBCreator ds = new DBCreator())
            {
                return ds.Students.ToList();
            }
        }

        /// <summary>
        /// Updating an existing student instance.
        /// </summary>
        public static void UpdateStudent(int StudentId, string StudentName)
        {
            using (DBCreator ds = new DBCreator())
            {
                ds.Entry<Student>(new Student { StudentId = StudentId, StudentName = StudentName }).State = EntityState.Modified;
                ds.SaveChanges();
            }
        }

        /// <summary>
        /// Deleting an existing student instance.
        /// </summary>
        public static void DeleteStudent(int StudentId)
        {
            using (DBCreator ds = new DBCreator())
            {
                ds.Entry<Student>(new Student { StudentId = StudentId }).State = EntityState.Deleted;
                ds.SaveChanges();
            }
        }

        /// <summary>
        /// Adding an existing student instance.
        /// </summary>
        public static void AddNewStudent(string StudentName)
        {
            using (DBCreator ds = new DBCreator())
            {
                ds.Students.Add(new Student { StudentName = StudentName });
                ds.SaveChanges();
            }
        }

        #endregion

        #region Courses.aspx

        /// <summary>
        /// Select all courses.
        /// </summary>
        public static List<Course> SelectAllCourses()
        {
            using (DBCreator ds = new DBCreator())
            {
                return ds.Courses.ToList();
            }
        }

        /// <summary>
        /// Add a new course.
        /// </summary>
        public static void AddNewCourse(string CourseName)
        {
            using (DBCreator ds = new DBCreator())
            {
                ds.Entry<Course>(new Course { CourseName = CourseName }).State = EntityState.Added;
                ds.SaveChanges();
            }
        }

        /// <summary>
        /// Update an existing course.
        /// </summary>
        public static void UpdateCourse(int CourseId, string CourseName)
        {
             using (DBCreator ds = new DBCreator())
            {
                ds.Entry<Course>(new Course { CourseName = CourseName, CourseId = CourseId }).State = EntityState.Modified;
                ds.SaveChanges();
            }
        }

        /// <summary>
        /// Select a specific course by id.
        /// </summary>
        public static List<Course> SelectCourseById(int CourseId)
        {
            using (DBCreator ds = new DBCreator())
            {
                return ds.Courses.Where(c => c.CourseId == CourseId).ToList();
            }
        }

        #endregion

        #region CourseChoice.aspx
        /// <summary>
        /// Selecting courses and scores according to the specific student.
        /// </summary>
        public static List<TempStudentCourse> SelectAllCoursesByStudentId(int StudentId)
        {
            using (DBCreator ds = new DBCreator())
            {
                var result = ds.StudentCourses.Where(sc => sc.Sid == StudentId).Select(s => new TempStudentCourse { Id = s.Id, CourseName = s.Course.CourseName, Score = s.Score,Cid=s.Cid,Sid=s.Sid });

                return result.ToList();

            }
        }

        /// <summary>
        /// Selecting courses and scores according to the specific student.
        /// </summary>
        public static void UpdateCourseScore(int Id,double Score)
        {
            using (DBCreator ds = new DBCreator())
            {
                Student_Course sc = ds.StudentCourses.First(s => s.Id == Id);
                sc.Score = Score;
                ds.Entry<Student_Course>(sc).State = EntityState.Modified;
                ds.SaveChanges();
            }
        }

        /// <summary>
        /// Deleting specific courses'scores by their Ids.
        /// </summary>
        public static void DeleteCourseScore(int Id)
        {
            using (DBCreator ds = new DBCreator())
            {
                ds.Entry<Student_Course>(new Student_Course { Id = Id }).State = EntityState.Deleted;
                ds.SaveChanges();
            }
        }

        /// <summary>
        /// Adding a new student's chosen course and a score
        /// </summary>
        public static void AddNewCourseAndScore(int sid, int cid, double score)
        {
            using (DBCreator ds = new DBCreator())
            {
                ds.Entry<Student_Course>(new Student_Course { Sid = sid, Cid = cid, Score = score }).State = EntityState.Added;
                ds.SaveChanges();
            }
        }

        /// <summary>
        /// Get all the rest courses for the specific student
        /// </summary>
        public static List<Course> SelectRestCourses(int sid)
        {
            using (DBCreator ds = new DBCreator())
            {
                var notchoosenCids = ds.Courses.Select(c => c.CourseId).Except(ds.StudentCourses.Where(sc => sc.Sid == sid).Select(s => s.Cid));
                var result = from c in ds.Courses
                             join n in notchoosenCids on c.CourseId equals n
                             select c;
                return result.ToList();
            }
        }
        #endregion
    }
}