/****************************** Module Header ******************************\
* Module Name:    DataBaseModel.cs
* Project:        CSASPNETCodeFirstCRUDInGridViewWithDetailsView
* Copyright (c) Microsoft Corporation
*
* The whole file defines several model classes for code-first to generate
* the related databases.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCodeFirstCRUDInGridView
{
    /// <summary>
    /// This is a student table
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Point out this is a Primary Key and it's auto-generated.
        /// </summary>
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        /// <summary>
        /// Point out this field is not null and it has the number 
        /// of character to int.MaxValue
        /// </summary>
        [Required]
        [MaxLength(int.MaxValue)]
        public string StudentName { get; set; }

        public virtual ICollection<Student_Course> Courses { get; set; }
    }

    /// <summary>
    /// Course Table
    /// </summary>
    public class Course
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string CourseName { get; set; }

        public virtual ICollection<Student_Course> Students { get; set; }

    }

    /// <summary>
    /// This table links the "Student" and "Course" tables together for searching.
    /// </summary>
    public class Student_Course
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Sid { get; set; }
        public int Cid { get; set; }
        [Required]
        public double Score { get; set; }

        /// <summary>
        /// This points out that Sid is the foreign Key to Student's StudentId,
        /// and it's Cascading Deleting by default.
        /// </summary>
        [ForeignKey("Sid")]

        /// <summary>
        /// This points out that Cid is the foreign Key to Course's CourseId,
        /// and it's Cascading Deleting by default.
        /// </summary>
        public virtual Student Student { get; set; }
        [ForeignKey("Cid")]
        public virtual Course Course { get; set; }
    }

    /// <summary>
    /// This is a nested class that will show the relationship
    /// between Students and Courses
    /// </summary>
    public class TempStudentCourse
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Sid { get; set; }
        public int Cid { get; set; }
        public double Score { get; set; }
    }
}