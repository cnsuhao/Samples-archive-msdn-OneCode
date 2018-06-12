'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBEFtoDataTable
' Copyright (c) Microsoft Corporation.
'
' This sample demonstrates how to fill a DataTable with the result of the Linq 
' to Entity query.
' Linq to Entity is a simple way for the developers, but sometimes we need to 
' use the DataTable. In this sample, we demonstrate two ways to fill a DataTable 
' with the result of the Linq to Entity query:
' 1. Use the connection string and query string that we get from the Linq to Entity;
' 2. Use the custom CopyToDataTable method.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Linq
Namespace VBEFtoDataTable
    Friend Class MainModule

        Shared Sub Main(ByVal args() As String)
            Using mySchool As New MySchoolEntities()

                Dim firstDepartment As Department = mySchool.Departments.First()

                Dim query As IQueryable(Of Course) = From c In mySchool.Courses
                                                     Where c.DepartmentID <> firstDepartment.DepartmentID
                                                     Select c

                Console.WriteLine("Use SQL string to fill Data Table:")
                ' Use the connection string and query string that we get from the Linq to Entity;
                Dim course As DataTable = FillDataTable.EFtoDataTable(query, mySchool)
                ShowDataTable(course)
                Console.WriteLine()

                Console.WriteLine("Use CopyToDataTable to fill Data Table:")
                ' Use the custom CopyToDataTable class.
                Dim copyCourse As DataTable = query.CopyToDataTable()
                ShowDataTable(copyCourse)
                Console.WriteLine()
            End Using

            Console.WriteLine("Press any key to exit.....")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Show the information of the DataTable.
        ''' </summary>
        ''' <param name="table"></param>
        Private Shared Sub ShowDataTable(ByVal table As DataTable)
            Dim columns As Integer = table.Columns.Count
            Dim rows As Integer = table.Rows.Count

            For col As Integer = 0 To columns - 1
                Console.Write("{0,-18}", table.Columns(col).Caption)
            Next col
            Console.WriteLine()

            For row As Integer = 0 To rows - 1
                For col As Integer = 0 To columns - 1
                    Console.Write("{0,-18}", table.Rows(row)(col))
                Next col
                Console.WriteLine()
            Next row

        End Sub

    End Class
End Namespace
