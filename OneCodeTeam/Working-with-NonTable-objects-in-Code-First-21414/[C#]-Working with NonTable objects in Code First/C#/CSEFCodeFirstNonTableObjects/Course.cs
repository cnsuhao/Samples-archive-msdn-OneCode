/****************************** Module Header ******************************\
Module Name:  Course.cs
Project:      CSEFCodeFirstNonTableObjects
Copyright (c) Microsoft Corporation.

This sample demonstrates how to work with nontable database objects in Code 
First.
The file defines the Course Entity Model class.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;

namespace CSEFCodeFirstNonTableObjects
{
    [Table("Course")]
    public class Course
    {
        public Int32 CourseID { get; set; }
        [Column("Title")]
        public String CourseName { get; set; }
        public Int32 Credits { get; set; }
        public Int32 DepartmentID { get; set; }

        public virtual Department Department { get; set; }
    }
}
