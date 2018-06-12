/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSDataTableUpdate
Copyright (c) Microsoft Corporation.

We can use the DataTable.Clone method to clone the structure of the DataTabe. 
After clone, the changes of structure in source table won’t be updated in the 
destination table.  
In this sample, we will demonstrate how to update the structure and constraints 
of the destination table after DataTable.Clone:
1. Update the changes of the columns in source table.
2. Update the changes of the UniqueConstraint in source table.
3. Update the changes of the ForeignKeyConstraint in source table.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Data;

namespace CSDataTableUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable courses = NewCourseDataTable();
            Console.WriteLine("This is the source table:");
            WriteDataTable(courses);

            ClonedDataTable clonedResult = new ClonedDataTable(courses);
            DataTable clonedCourses = clonedResult.DestinationTable;
            Console.WriteLine("This is the destination table:");
            WriteDataTable(clonedCourses);

            #region Update the columns
            // Add the events of updating column collection into the source table.
            clonedResult.UpdateAddedColumn();
            clonedResult.UpdateDeletedColumn();
            // Add a DataColumn in source table.
            DataColumn columnCreidts = new DataColumn("Credits", typeof(Int32));
            courses.Columns.Add(columnCreidts);
            Console.WriteLine("After add a column in source table, it's the result in the destination:");
            WriteDataTable(clonedCourses);
            #endregion

            #region Update the UniqueConstraint
            // Add the event of updating UniqueConstraint into the source table.
            clonedResult.UpdateUniqueConstraint();

            // Add the unique constraint in source table.
            UniqueConstraint uniqueConstraint = new UniqueConstraint(courses.Columns["CourseId"]);
            courses.Constraints.Add(uniqueConstraint);

            Console.WriteLine(@"If we add the unique constraint in source table and then insert the duplicate 
rows into the destination table, we will get the following error:");
            InsertDuplicateData(clonedCourses);
            Console.WriteLine();
            #endregion

            #region Update the ForeignKeyConstraint
            // Add the event of updating ForeignKeyConstraint into the source table.
            clonedResult.UpdateForeignKeyConstraint();

            // Add the ForeignKeyConstraint into the source table.
            DataTable deparments = NewDeparmentDataTable();
            DataSet dataset = new DataSet();

            dataset.Tables.Add(courses);
            dataset.Tables.Add(clonedCourses);
            dataset.Tables.Add(deparments);

            ForeignKeyConstraint foreignKey =
                new ForeignKeyConstraint(deparments.Columns["DepartmentId"], courses.Columns["DepartmentId"]);
            courses.Constraints.Add(foreignKey);

            Console.WriteLine(@"If we add the foreign key constraint in source table and then insert a row 
without the parent  into the destination table, we will get the following error:");
            InsertNoParentRow(clonedCourses);
            Console.WriteLine();
            #endregion

            Console.WriteLine("Please press any key to exit...");
            Console.ReadKey();
        }

        static private DataTable NewCourseDataTable()
        {
            DataTable newTable = new DataTable();

            DataColumn[] columns ={ 
                                      new DataColumn("CourseId", typeof(String)),
                                      new DataColumn("CourseName",typeof(String)),                                      
                                      new DataColumn("DepartmentId", typeof(Int32))
                                  };

            newTable.Columns.AddRange(columns);

            newTable.Rows.Add("C1045", "Calculus", 7);
            newTable.Rows.Add("C1061", "Physics", 1);
            newTable.Rows.Add("C2021", "Composition", 2);
            newTable.Rows.Add("C2042", "Literature", 2);

            return newTable;
        }

        static private DataTable NewDeparmentDataTable()
        {
            DataTable newTable = new DataTable();

            DataColumn[] columns ={ 
                                      new DataColumn("DepartmentId", typeof(Int32)),
                                      new DataColumn("Name",typeof(String)),
                                  };

            newTable.Columns.AddRange(columns);

            newTable.Rows.Add(1, "Engineering");
            newTable.Rows.Add(2, "English");
            newTable.Rows.Add(4, "Economics");
            newTable.Rows.Add(7, "Mathematics");

            return newTable;
        }

        static private void WriteDataTable(DataTable table)
        {
            if (table == null)
            {
                return;
            }

            foreach (DataColumn column in table.Columns)
            {
                Console.Write("{0,-15}", column.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    Console.Write("{0,-15}", row[i].ToString());
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static private void InsertDuplicateData(DataTable table)
        {
            try
            {
                table.Rows.Add("C1045", "Calculus", 7);
                table.Rows.Add("C1045", "Calculus", 7);
            }
            catch (Exception e)
            {
                Console.WriteLine("\"" + e.Message + "\"");
            }
        }

        private static void InsertNoParentRow(DataTable table)
        {
            try
            {
                table.Rows.Add("C1061", "Physics", 11);
            }
            catch (Exception e)
            {
                Console.WriteLine("\"" + e.Message + "\"");
            }
        }

    }
}
