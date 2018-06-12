'****************************** Module Header ******************************\
' Module Name:  Program.cs
' Project:      VBLinqToObject
' Copyright (c) Microsoft Corporation.
' 
' This example illustrates how to write Linq to Object queries using Visual 
' VB.NET. First, it builds a class named Person. Person inculdes the ID, 
' Name and Age properties. Then the example creates a list of Person which 
' will be used as the datasource. In the example, you will see the basic 
' Linq operations like select, update, orderby, max, average, etc.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' ***************************************************************************/


Module MainModule

    Sub Main()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Build the Person list that serves as the data source.
        '
        Dim persons As New List(Of Person)

        persons.Add(New Person(1, "Alexander David", 20))
        persons.Add(New Person(2, "Aziz Hassouneh", 18))
        persons.Add(New Person(3, "Guido Pica", 20))
        persons.Add(New Person(4, "Chris Preston", 19))
        persons.Add(New Person(5, "Jorgen Rahgek", 20))
        persons.Add(New Person(6, "Todd Rowe", 18))
        persons.Add(New Person(7, "SPeter addow", 22))
        persons.Add(New Person(8, "Markus Breyer", 19))
        persons.Add(New Person(9, "Scott Brown", 20))


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Query a person in the data source.
        '
        Dim Todd = (From p In persons _
                    Where p.Name = "Todd Rowe" _
                    Select p).First()

        Console.WriteLine("Todd Rowe's age is {0}", Todd.Age)


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Perform the Update operation on the person's age.
        '
        Todd.Age = 21

        Console.WriteLine("Todd Rowe's age is updated to {0}", (From p In persons _
                                                                Where p.Name = "Todd Rowe" _
                                                                Select p).First().Age)


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Sort the data in the data source.
        ' Order the persons by age
        Dim query1 = From p In persons _
                     Order By p.Age _
                     Select p

        Console.WriteLine("ID" & vbTab & "Name" & vbTab & vbTab & "Age")

        For Each p In query1.ToList()
            Console.WriteLine("{0}" & vbTab & "{1}" & vbTab & vbTab & "{2}", _
                              p.PersonID, p.Name, p.Age)
        Next


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Print the average, max, min age of the persons.
        '
        Dim avgAge As Double = (From p In persons _
                                Select p.Age).Average()
        Console.WriteLine("The average age of the persons is {0:f2}", avgAge)

        Dim maxAge As Double = (From p In persons _
                                Select p.Age).Max()
        Console.WriteLine("The maximum age of the persons is {0}", maxAge)

        Dim minAge As Double = (From p In persons _
                                Select p.Age).Min()
        Console.WriteLine("The minimum age of the persons is {0}", minAge)


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Count the persons who age is larger than 20.
        '
        Dim query2 = From p In persons _
                     Where p.Age > 20 _
                     Select p

        Dim count As Integer = query2.Count()

        Console.WriteLine("{0} persons are older than 20:", count)

        For i = 0 To count - 1
            Console.WriteLine(query2.ElementAt(i).Name)
        Next

    End Sub

End Module
