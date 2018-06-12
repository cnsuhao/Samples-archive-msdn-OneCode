/****************************** Module Header ******************************\
* Module Name:  Person.cs
* Project:	    CSWindowsStoreAppReflection
* Copyright (c) Microsoft Corporation.
* 
* Define the classes to be demonstrated.
* 
* Person is the base class.
* Student inherits from Person, and implements IStudy.
* Employee inherits from Person, and implements IWork.
* Engineer and Saler inherit from Employee.
* 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


namespace CSWindowsStoreAppReflection.Types
{
    public class Person
    {
        public double Name { get; set; }

        public int Age { get; set; }

        public bool IsMale { get; set; }
    }

    public class Student:Person,IStudy
    {
        public int Grade { get; set; }

        public string School { get; set; }

        public void Study()
        {          
        }
    }

    public class Employee:Person,IWork
    {
        public string Company { get; set; }

        public virtual void Work()
        {          
        }
    }

    public class Engineer:Employee
    {
        public string Technology { get; set; }
    }

    public class Saler:Employee
    {
        public string Product { get; set; }
    }
}
