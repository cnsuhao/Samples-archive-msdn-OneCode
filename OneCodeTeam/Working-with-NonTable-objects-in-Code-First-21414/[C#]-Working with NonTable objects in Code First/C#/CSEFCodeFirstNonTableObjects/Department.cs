/****************************** Module Header ******************************\
Module Name:  Department.cs
Project:      CSEFCodeFirstNonTableObjects
Copyright (c) Microsoft Corporation.

This sample demonstrates how to work with nontable database objects in Code 
First.
The file defines the Department Entity Model class.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSEFCodeFirstNonTableObjects
{
    [Table("Department")]
    public class Department
    {
        public Int32 DepartmentID { get; set; }
        public String Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public Int32 Administrator { get; set; }

        public virtual List<Course> Courses { get; set; }
    }
}
