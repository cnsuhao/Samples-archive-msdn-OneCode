'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBDataTableCustomType
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to use the custom type in DataTable:
' 1. Set the custom type as the datatable primary column type;
' 2. Sort the datatable by the custom type;
' 3. Write the datatable into the Xml file;
' 4. Read the Xml file into the datatable.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Xml.Serialization

Namespace VBDataTableCustomType
    Friend Class MainModule
        Shared Sub Main(ByVal args() As String)
            Dim xmlSchema As String = "Courses.xsd"
            Dim xmlFile As String = "Courses.xml"

            ' We first create a DataTable that contains the custom type, and set the custom 
            ' type column as the primary key.
            ' Secondly, we will sort the DataTable by the custom type column.
            ' Last, we will write the DataTable into the xml file and read the data from the 
            ' xml file.
            Dim table As DataTable = FillDataTable()

            SortByCourse(table)

            WriteTableToXml(table, xmlSchema, xmlFile)

            ReadXmlToTable(xmlSchema, xmlFile)

            Console.WriteLine("Press any key to exit.....")
            Console.ReadKey()
        End Sub


        Private Shared Function FillDataTable() As DataTable
            Dim table As New DataTable()
            table.TableName = "Courses"

            ' Add the custom type column into the DataTable.
            Dim columns() As DataColumn =
                {
                    New DataColumn("Course", GetType(Course)),
                    New DataColumn("Classroom", GetType(String)),
                    New DataColumn("Year", GetType(Int32))
                }
            table.Columns.AddRange(columns)

            ' Set the custom type column as the primary key.
            table.PrimaryKey = New DataColumn(0) {table.Columns(0)}

            Dim courseMa As Course = New Course With
                                     {.CourseId = "C1050", .Title = "Mathematics", .Credits = 4}
            Dim courseHis As Course = New Course With
                                      {.CourseId = "C1075", .Title = "History", .Credits = 5}
            Dim coursePhy As Course = New Course With
                                      {.CourseId = "C1099", .Title = "Physics", .Credits = 11}

            table.Rows.Add(courseMa, "Room101", 2012)
            table.Rows.Add(courseHis, "Room203", 2012)
            table.Rows.Add(coursePhy, "Room102", 2012)

            Return table
        End Function

        Private Shared Sub SortByCourse(ByVal table As DataTable)
            ' Use the Select method to sort the DataTable.
            Dim resultRows() As DataRow = table.Select("", "Course DESC")

            Console.WriteLine("It's the result of sorting")
            For Each row As DataRow In resultRows
                Console.WriteLine(row(0))
            Next row

            Console.WriteLine()
        End Sub

        Private Shared Sub WriteTableToXml(ByVal table As DataTable,
                                           ByVal xmlSchema As String, ByVal xmlFile As String)
            ' We use the custom type in the DataTable, so we need to write the xml schema into a file.
            table.WriteXmlSchema(xmlSchema)
            table.WriteXml(xmlFile)

            Console.WriteLine("Write the DataTable into Xml file.")
            Console.WriteLine()
        End Sub

        Private Shared Sub ReadXmlToTable(ByVal xmlSchema As String, ByVal xmlFile As String)
            Dim newTable As New DataTable()

            ' We use the custom type in the DataTable, so the application can't identify the 
            ' custom type without xml schema.
            newTable.ReadXmlSchema(xmlSchema)
            newTable.ReadXml(xmlFile)

            Console.WriteLine("After load from the Xml file.")
            For Each row As DataRow In newTable.Rows
                Console.WriteLine(row(0))
            Next row

            Console.WriteLine()
        End Sub
    End Class
End Namespace
