/****************************** Module Header ******************************\
* Module Name:  Program.cs
* Project:      CSLinqToObject
* Copyright (c) Microsoft Corporation.
* 
* This example illustrates how to write Linq to Object queries using Visual 
* C#. First, it builds a class named Person. Person inculdes the ID, Name and 
* Age properties. Then the example creates a list of Person which will be  
* used as the datasource. In the example, you will see the basic Linq 
* operations like select, update, orderby, max, average, etc.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion


class Program
{
    static void Main(string[] args)
    {
        /////////////////////////////////////////////////////////////////////
        // Build the Person list that serves as the data source.
        // 
        List<Person> persons = new List<Person>();

        persons.Add(new Person(1, "Alexander David", 20));
        persons.Add(new Person(2, "Aziz Hassouneh", 18));
        persons.Add(new Person(3, "Guido Pica", 20));
        persons.Add(new Person(4, "Chris Preston", 19));
        persons.Add(new Person(5, "Jorgen Rahgek", 20));
        persons.Add(new Person(6, "Todd Rowe", 18));
        persons.Add(new Person(7, "SPeter addow", 22));
        persons.Add(new Person(8, "Markus Breyer", 19));
        persons.Add(new Person(9, "Scott Brown", 20));


        /////////////////////////////////////////////////////////////////////
        // Query a person in the data source.
        // 
        var Todd = (from p in persons
                    where p.Name == "Todd Rowe"
                     select p).First();
        // [-or-]
        // Use extension method + lambda expression directly 
        //var Todd = persons.Where(p => p.Name == "Todd Rowe").First();

        Console.WriteLine("Todd Rowe's age is {0}", Todd.Age);


        /////////////////////////////////////////////////////////////////////
        // Perform the Update operation on the person's age.
        // 
        Todd.Age = 21;
        Console.WriteLine("Todd Rowe's age is updated to {0}", (from p in persons
                                                                where p.Name == "Todd Rowe"
                                                            select p).First().Age);


        /////////////////////////////////////////////////////////////////////
        // Sort the data in the data source.       
        // Order the persons by age
        var query1 = from p in persons
                     orderby p.Age
                     select p;

        Console.WriteLine("ID\tName\t\tAge");

        foreach (Person p in query1.ToList<Person>())
        {
            Console.WriteLine("{0}\t{1}\t\t{2}", p.PersonID, p.Name, p.Age);
        }


        /////////////////////////////////////////////////////////////////////
        // Print the average, max, min age of the persons.
        // 
        double avgAge = (from p in persons
                         select p.Age).Average();
        Console.WriteLine("The average age of the persons is {0:f2}", avgAge);

        double maxAge = (from p in persons
                         select p.Age).Max();
        Console.WriteLine("The maximum age of the persons is {0}", maxAge);

        double minAge = (from p in persons
                         select p.Age).Min();
        Console.WriteLine("The minimum age of the persons is {0}", minAge);


        /////////////////////////////////////////////////////////////////////
        // Count the persons who age is larger than 20
        // 
        var query2 = from p in persons
                     where p.Age > 20
                     select p;

        int count = query2.Count();
        Console.WriteLine("{0} persons are older than 20:", count);
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(query2.ElementAt(i).Name);
        }
    }
}