'***************************** Module Header ******************************\
' Module Name:	MainModule.vb
' Project:		VBDataTable2ListLINQOperation
' Copyright (c) Microsoft Corporation.
' 
' The project illustrates how to get a distinct, ordered list of names from a 
' DataTable using LINQ.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Module MainModule

    Sub Main()

        ' Get the data table
        Dim sourceData As DataTable = GetDataSource()

        ' Convert to to a new employee list
        Dim employeeList As List(Of Employee) = sourceData.AsEnumerable().Select(Function(rw) New Employee() With { _
                                                                                     .Id = Int32.Parse(rw("Id").ToString()), _
                                                                                     .Name = rw("Name").ToString(), _
                                                                                     .Location = rw("Location").ToString() _
                                                        }).ToList()

        ' Read out the list items
        Console.WriteLine(vbLf & "Employee list:")
        ReadEmployees(employeeList)

        ' Take the distinct employee list
        Dim distinctEmployeeList As List(Of Employee) = employeeList.Distinct(New EmployeeComparer()).ToList()

        ' Read out the distinct list items
        Console.WriteLine(vbLf & "Distinct Employee list:")
        ReadEmployees(distinctEmployeeList)


        ' Take the ordered employee list by Location
        Dim orderedEmployeeList As List(Of Employee) = distinctEmployeeList.OrderBy(Function(x) x.Location).ToList()

        ' Read out the ordered by Location list items
        Console.WriteLine(vbLf & "Ordered by Location Employee list:")
        ReadEmployees(orderedEmployeeList)

    End Sub

    ' Read through the list
    Private Sub ReadEmployees(employeeList As List(Of Employee))
        For Each emp As Employee In employeeList
            Console.WriteLine((emp.Id.ToString() + vbTab + emp.Name & vbTab) + emp.Location)
        Next
    End Sub

    ' Prepare the data table
    Private Function GetDataSource() As DataTable
        ' Prepare schema
        Dim dt As New DataTable("TestDB")
        dt.Columns.Add("Id", GetType(System.Int32))
        dt.Columns.Add("Name", GetType(System.String))
        dt.Columns.Add("Location", GetType(System.String))

        ' way 1: Create a row for the table
        Dim row As DataRow = dt.NewRow()
        row("Id") = 1236
        row("Name") = "James"
        row("Location") = "NewYork"
        dt.Rows.Add(row)

        ' way 2: Create a row for the table
        dt.Rows.Add(New Object() {4321, "Brian", "Boston"})
        dt.Rows.Add(New Object() {3213, "Jeff", "Chicago"})
        dt.Rows.Add(New Object() {5435, "Adam", "NewYork"})
        dt.Rows.Add(New Object() {3453, "Brian", "Dallas"})
        dt.Rows.Add(New Object() {5344, "Kayle", "Dallas"})
        dt.Rows.Add(New Object() {3213, "Jeff", "Chicago"})

        ' return the populated data table
        Return dt
    End Function

End Module
