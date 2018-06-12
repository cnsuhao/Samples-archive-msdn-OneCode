/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSEFtoDataTable
Copyright (c) Microsoft Corporation.

This sample demonstrates how to fill a DataTable with the result of the Linq 
to Entity query.
Linq to Entity is a simple way for the developers, but sometimes we need to 
use the DataTable. In this sample, we demonstrate two ways to fill a DataTable 
with the result of the Linq to Entity query:
1. Use the connection string and query string that we get from the Linq to Entity;
2. Use the custom CopyToDataTable method.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Linq;
using System.Data;

namespace CSEFtoDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MySchoolEntities mySchool = new MySchoolEntities())
            {

                Department firstDepartment = mySchool.Departments.First();

                IQueryable<Course> query = from c in mySchool.Courses
                                           where c.DepartmentID != firstDepartment.DepartmentID
                                           select c;

                Console.WriteLine("Use SQL string to fill Data Table:");

                // Use the connection string and query string that we get from the Linq to Entity;
                DataTable course = FillDataTable.EFtoDataTable(query, mySchool);
                ShowDataTable(course);
                Console.WriteLine();

                Console.WriteLine("Use CopyToDataTable to fill Data Table:");

                // Use the custom CopyToDataTable class.
                DataTable copyCourse = query.CopyToDataTable();
                ShowDataTable(copyCourse);
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit.....");
            Console.ReadKey();
        }

        /// <summary>
        /// Show the information of the DataTable.
        /// </summary>
        /// <param name="table"></param>
        static void ShowDataTable(DataTable table)
        {
            int columns=table.Columns.Count;
            int rows=table.Rows.Count;

            for (int col = 0; col < columns; col++)
            {
                Console.Write("{0,-18}",table.Columns[col].Caption);
            }
            Console.WriteLine();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Console.Write("{0,-18}", table.Rows[row][col]);
                }
                Console.WriteLine();
            }

        }
    }
}
