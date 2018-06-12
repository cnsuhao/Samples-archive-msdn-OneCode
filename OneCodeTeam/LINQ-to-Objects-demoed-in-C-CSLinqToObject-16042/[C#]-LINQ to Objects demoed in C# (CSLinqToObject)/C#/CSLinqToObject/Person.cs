/****************************** Module Header ******************************\
* Module Name:  Person.cs
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Person
{
    public Person(int id, string name, int age)
    {
        this.id = id;
        this.name = name;
        this.age = age;
    }

    private int id;

    /// <summary>
    /// Person ID
    /// </summary>
    public int PersonID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    private string name;

    /// <summary>
    /// Person name
    /// </summary>
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private int age;

    /// <summary>
    /// Age that ranges from 1 to 100
    /// </summary>
    public int Age
    {
        get { return this.age; }
        set
        {
            if (value > 0 && value <= 100)
                this.age = value;
            else
                throw new Exception("Age is out of scope [1,100]");
        }
    }
}