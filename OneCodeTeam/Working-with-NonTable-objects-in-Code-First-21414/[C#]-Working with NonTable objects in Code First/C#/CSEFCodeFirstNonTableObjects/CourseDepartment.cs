/****************************** Module Header ******************************\
Module Name:  CourseDepartment.cs
Project:      CSEFCodeFirstNonTableObjects
Copyright (c) Microsoft Corporation.

This sample demonstrates how to work with nontable database objects in Code 
First.
The file defines the CourseDepartment Non-Entity Model class.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;

namespace CSEFCodeFirstNonTableObjects
{
    public class CourseDepartment
    {
        public Int32 CourseID { get; set; }
        public String Title { get; set; }
        public Int32 Credits { get; set; }
        public String DepartmentName { get; set; }
    }
}
