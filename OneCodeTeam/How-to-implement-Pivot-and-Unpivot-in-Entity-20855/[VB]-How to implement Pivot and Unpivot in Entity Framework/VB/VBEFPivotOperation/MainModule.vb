'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBEFPivotOperation
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to implement the Pivot and Unpivot operation in 
' Entity Framework.
' In this sample, we use two classes to store the data from the database by EF,
' and then display the data in Pivot/Unpivot format.
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
Imports System.Reflection

Namespace VBEFPivotOperation
    Friend Class MainModule
        Shared Sub Main(ByVal args() As String)
            PivotInEF()
            Console.WriteLine()

            UnpivotInEF()
            Console.WriteLine()

            Console.WriteLine("Press any key to exit.....")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' Execute the Pivot operation in EF.
        ''' </summary>
        Private Shared Sub PivotInEF()
            Dim studentGrade As List(Of PivotRow(Of Person, String, Decimal)) = Nothing
            Dim courses As List(Of String) = Nothing

            Using school As New MySchoolEntities()
                ' Get the data from the database.
                studentGrade = (
                    From sg In school.StudentGrades
                    Group sg By sg.StudentID Into sgGroup = Group
                    Select New PivotRow(Of Person, String, Decimal) With
                           {
                            .ObjectId = sgGroup.Select(Function(g) g.Person).FirstOrDefault(),
                            .Attributes = sgGroup.Select(Function(g) g.Course.Title),
                            .Values = sgGroup.Select(Function(g) g.Grade)
                           }).ToList()

                ' Get the list of attributes.
                courses = school.Courses.Select(Function(c) c.Title).ToList()
            End Using

            ' Get the Pivot table.
            Using pivotTable As DataTable = PivotRow(Of Person, String, Decimal).GetPivotTable(courses, studentGrade)
                Console.WriteLine("It's the result of Pivot in EF:")
                For Each col As DataColumn In pivotTable.Columns
                    Console.Write("{0,-15}", col.ColumnName)
                Next col
                Console.WriteLine()

                For Each row As DataRow In pivotTable.Rows
                    Dim p As Person = CType(row(0), Person)
                    Console.Write("{0,-15}", p.FirstName & " " & p.LastName)

                    For i As Integer = 1 To pivotTable.Columns.Count - 1
                        Console.Write("{0,-15}", If(row(i).GetType().Equals(GetType(DBNull)), "NULL", row(i)))
                    Next i
                    Console.WriteLine()
                Next row
            End Using
        End Sub

        ''' <summary>
        ''' Execute the Upivot operation in EF.
        ''' </summary>
        Private Shared Sub UnpivotInEF()
            ' set the function list of attributes.
            Dim attrFuncList As New Dictionary(Of String, Func(Of Person, Date?))()
            attrFuncList("HireDate") = Function(p) p.HireDate
            attrFuncList("EnrollmentDate") = Function(p) p.EnrollmentDate

            ' Store the Unpivot result.
            Dim result As IEnumerable(Of UnpivotRow(Of String, String, Date)) = Nothing

            Using school As New MySchoolEntities()
                ' Get the data from databasy by EF.
                Dim persons = (
                    From person In school.People
                    Select person).ToList()

                ' Get the query result of every attribute.
                For Each key As String In attrFuncList.Keys
                    Dim k As String = key
                    ' Get the value of a certain attribute.
                    Dim query As IEnumerable(Of UnpivotRow(Of String, String, Date)) = (
                        From person In persons
                        Where attrFuncList(k)(person) IsNot Nothing
                        Select New UnpivotRow(Of String, String, Date) With
                               {
                                .ObjectId = person.FirstName & " " & person.LastName,
                                .Attribute = k,
                                .Value = CDate(attrFuncList(k)(person))
                            })

                    ' Concat the results.
                    result = If(result Is Nothing, query, result.Concat(query))
                Next key
            End Using

            Console.WriteLine("It's the result of Unpivot In EF:")
            Console.WriteLine("{0,-15}{1,-15}{2,-15}", "ObjectId", "AttributeName", "Value")
            For Each row In result.ToList()
                Console.WriteLine("{0,-15}{1,-15}{2,-15}", row.ObjectId, row.Attribute, row.Value.ToShortDateString())
            Next row
        End Sub
    End Class
End Namespace
