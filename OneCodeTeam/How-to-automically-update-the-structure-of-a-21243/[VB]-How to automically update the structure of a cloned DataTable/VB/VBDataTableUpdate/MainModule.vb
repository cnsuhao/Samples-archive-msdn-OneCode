' **************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBDataTableUpdate
' Copyright (c) Microsoft Corporation.
' 
' We can use the DataTable.Clone method to clone the structure of the DataTabe. 
' After clone, the changes of structure in source table won’t be updated in the 
' destination table.  
' In this sample, we will demonstrate how to update the structure and constraints 
' of the destination table after DataTable.Clone:
' 1. Update the changes of the columns in source table.
' 2. Update the changes of the UniqueConstraint in source table.
' 3. Update the changes of the ForeignKeyConstraint in source table.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Namespace VBDataTableUpdate
    Friend Class MainModule
        Shared Sub Main(ByVal args() As String)
            Dim courses As DataTable = NewCourseDataTable()
            Console.WriteLine("This is the source table:")
            WriteDataTable(courses)

            Dim clonedResult As New ClonedDataTable(courses)
            Dim clonedCourses As DataTable = clonedResult.DestinationTable
            Console.WriteLine("This is the destination table:")
            WriteDataTable(clonedCourses)

            '			#Region "Update the columns"
            ' Add the events of updating column collection into the source table.
            clonedResult.UpdateAddedColumn()
            clonedResult.UpdateDeletedColumn()
            ' Add a DataColumn in source table.
            Dim columnCreidts As New DataColumn("Credits", GetType(Int32))
            courses.Columns.Add(columnCreidts)
            Console.WriteLine("After add a column in source table, it's the result in the destination:")
            WriteDataTable(clonedCourses)
            '			#End Region

            '			#Region "Update the UniqueConstraint"
            ' Add the event of updating UniqueConstraint into the source table.
            clonedResult.UpdateUniqueConstraint()

            ' Add the unique constraint in source table.
            Dim uniqueConstraint As New UniqueConstraint(courses.Columns("CourseId"))
            courses.Constraints.Add(uniqueConstraint)

            Console.WriteLine("If we add the unique constraint in source table and then insert the duplicate " &
                              ControlChars.CrLf & "rows into the destination table, we will get the following error:")
            InsertDuplicateData(clonedCourses)
            Console.WriteLine()
            '			#End Region

            '			#Region "Update the ForeignKeyConstraint"
            ' Add the event of updating ForeignKeyConstraint into the source table.
            clonedResult.UpdateForeignKeyConstraint()

            ' Add the ForeignKeyConstraint into the source table.
            Dim deparments As DataTable = NewDeparmentDataTable()
            Dim dataset As New DataSet()

            dataset.Tables.Add(courses)
            dataset.Tables.Add(clonedCourses)
            dataset.Tables.Add(deparments)

            Dim foreignKey As New ForeignKeyConstraint(deparments.Columns("DepartmentId"),
                                                       courses.Columns("DepartmentId"))
            courses.Constraints.Add(foreignKey)

            Console.WriteLine("If we add the foreign key constraint in source table and then insert a row " &
              ControlChars.CrLf & "without the parent  into the destination table, we will get the following error:")
            InsertNoParentRow(clonedCourses)
            Console.WriteLine()
            '			#End Region

            Console.WriteLine("Please press any key to exit...")
            Console.ReadKey()
        End Sub

        Private Shared Function NewCourseDataTable() As DataTable
            Dim newTable As New DataTable()

            Dim columns() As DataColumn =
                {
                    New DataColumn("CourseId", GetType(String)),
                    New DataColumn("CourseName", GetType(String)),
                    New DataColumn("DepartmentId", GetType(Int32))
                }

            newTable.Columns.AddRange(columns)

            newTable.Rows.Add("C1045", "Calculus", 7)
            newTable.Rows.Add("C1061", "Physics", 1)
            newTable.Rows.Add("C2021", "Composition", 2)
            newTable.Rows.Add("C2042", "Literature", 2)

            Return newTable
        End Function

        Private Shared Function NewDeparmentDataTable() As DataTable
            Dim newTable As New DataTable()

            Dim columns() As DataColumn =
                {
                    New DataColumn("DepartmentId", GetType(Int32)),
                    New DataColumn("Name", GetType(String))
                }

            newTable.Columns.AddRange(columns)

            newTable.Rows.Add(1, "Engineering")
            newTable.Rows.Add(2, "English")
            newTable.Rows.Add(4, "Economics")
            newTable.Rows.Add(7, "Mathematics")

            Return newTable
        End Function

        Private Shared Sub WriteDataTable(ByVal table As DataTable)
            If table Is Nothing Then
                Return
            End If

            For Each column As DataColumn In table.Columns
                Console.Write("{0,-15}", column.ColumnName)
            Next column
            Console.WriteLine()

            For Each row As DataRow In table.Rows
                For i As Integer = 0 To table.Columns.Count - 1
                    Console.Write("{0,-15}", row(i).ToString())
                Next i
                Console.WriteLine()
            Next row

            Console.WriteLine()
        End Sub

        Private Shared Sub InsertDuplicateData(ByVal table As DataTable)
            Try
                table.Rows.Add("C1045", "Calculus", 7)
                table.Rows.Add("C1045", "Calculus", 7)
            Catch e As Exception
                Console.WriteLine("""" & e.Message & """")
            End Try
        End Sub

        Private Shared Sub InsertNoParentRow(ByVal table As DataTable)
            Try
                table.Rows.Add("C1061", "Physics", 11)
            Catch e As Exception
                Console.WriteLine("""" & e.Message & """")
            End Try
        End Sub

    End Class
End Namespace
