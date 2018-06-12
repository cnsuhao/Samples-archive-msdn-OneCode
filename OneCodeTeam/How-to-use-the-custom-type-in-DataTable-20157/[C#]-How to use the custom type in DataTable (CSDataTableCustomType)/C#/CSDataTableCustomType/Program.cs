/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSDataTableCustomType
Copyright (c) Microsoft Corporation.

This sample demonstrates how to use the custom type in DataTable:
1. Set the custom type as the datatable primary column type;
2. Sort the datatable by the custom type;
3. Write the datatable into the Xml file;
4. Read the Xml file into the datatable.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Data;
using System.Xml.Serialization;

namespace CSDataTableCustomType
{
    class Program
    {
        static void Main(string[] args)
        {
            String xmlSchema = "Courses.xsd";
            String xmlFile = "Courses.xml";
            
            // We first create a DataTable that contains the custom type, and set the custom 
            // type column as the primary key.
            // Secondly, we will sort the DataTable by the custom type column.
            // Last, we will write the DataTable into the xml file and read the data from the 
            // xml file.
            DataTable table = FillDataTable();

            SortByCourse(table);

            WriteTableToXml(table,xmlSchema,xmlFile);

            ReadXmlToTable(xmlSchema,xmlFile);
            
            Console.WriteLine("Press any key to exit.....");
            Console.ReadKey();
        }


        static DataTable FillDataTable()
        {
            DataTable table = new DataTable();
            table.TableName = "Courses";

            // Add the custom type column into the DataTable.
            DataColumn[] columns = 
            { 
                new DataColumn("Course",typeof(Course)),
                new DataColumn("Classroom",typeof(String)),
                new DataColumn("Year",typeof(Int32))
            };
            table.Columns.AddRange(columns);

            // Set the custom type column as the primary key.
            table.PrimaryKey = new DataColumn[1] { table.Columns[0] };

            Course courseMa = new Course { CourseId = "C1050", Title = "Mathematics", Credits = 4 };
            Course courseHis = new Course { CourseId = "C1075", Title = "History", Credits = 5 };
            Course coursePhy = new Course { CourseId = "C1099", Title = "Physics", Credits = 11 };
            
            table.Rows.Add(courseMa, "Room101", 2012);
            table.Rows.Add(courseHis, "Room203", 2012);
            table.Rows.Add(coursePhy, "Room102", 2012);

            return table;
        }

        static void SortByCourse(DataTable table)
        {
            // Use the Select method to sort the DataTable.
            DataRow[] resultRows = table.Select("", "Course DESC");

            Console.WriteLine("It's the result of sorting");
            foreach (DataRow row in resultRows)
            {
                Console.WriteLine(row[0]);
            }

            Console.WriteLine();
        }

        static void WriteTableToXml(DataTable table, String xmlSchema, String xmlFile)
        {
            // We use the custom type in the DataTable, so we need to write the xml schema into a file.
            table.WriteXmlSchema(xmlSchema);
            table.WriteXml(xmlFile);

            Console.WriteLine("Write the DataTable into Xml file.");
            Console.WriteLine();
        }

        static void ReadXmlToTable(String xmlSchema,String xmlFile)
        {
            DataTable newTable = new DataTable();

            // We use the custom type in the DataTable, so the application can't identify the 
            // custom type without xml schema.
            newTable.ReadXmlSchema(xmlSchema);
            newTable.ReadXml(xmlFile);
            
            Console.WriteLine("After load from the Xml file.");
            foreach (DataRow row in newTable.Rows)
            {
                Console.WriteLine(row[0]);
            }

            Console.WriteLine();
        }
    }
}
