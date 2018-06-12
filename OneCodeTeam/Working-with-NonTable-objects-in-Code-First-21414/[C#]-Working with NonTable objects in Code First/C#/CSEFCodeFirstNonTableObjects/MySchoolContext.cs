/****************************** Module Header ******************************\
Module Name:  MySchoolContext.cs
Project:      CSEFCodeFirstNonTableObjects
Copyright (c) Microsoft Corporation.

This sample demonstrates how to work with nontable database objects in Code 
First.
The file defines the MySchoolContext class.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Data.Entity;

namespace CSEFCodeFirstNonTableObjects
{
    public class MySchoolContext:DbContext
    {
        public MySchoolContext()
        { }

        /// <summary>
        /// We can specify the database name the context creates or maps.
        /// </summary>
        /// <param name="databaseName">the database name the context creates or maps</param>
        public MySchoolContext(String databaseName)
            : base(databaseName)
        { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
