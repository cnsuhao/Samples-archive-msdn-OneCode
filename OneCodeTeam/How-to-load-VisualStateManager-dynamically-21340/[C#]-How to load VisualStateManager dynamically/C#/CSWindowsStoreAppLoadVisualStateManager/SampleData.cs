/****************************** Module Header ******************************\
 * Module Name:  SampleData.cs
 * Project:      CSWindowsStoreAppLoadVisualStateManager
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample code is used to prepare data for display in UI
 *  
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Collections.Generic;

namespace CSWindowsStoreAppLoadVisualStateManager
{
    class SampleData
    {
        public List<Book> Books { get; set; }
        public SampleData()
        {
            Books = new List<Book>();
            Books.Add(
                new Book()
                {
                    Category = "Novel",
                    Name = "John's relique",
                    Price = 50.0M
                });
            Books.Add(
                new Book()
                {
                    Category = "Novel",
                    Name = "A magical pig",
                    Price = 30.50M
                });
            Books.Add(
                new Book()
                {
                    Category = "Novel",
                    Name = "Wolves",
                    Price = 40.50M
                });
            Books.Add(
                new Book()
                {
                    Category = "Novel",
                    Name = "Naughty Tom",
                    Price = 33.50M
                });
            Books.Add(
                new Book()
                {
                    Category = "Novel",
                    Name = "Beyond",
                    Price = 60.00M
                });
            Books.Add(
                new Book()
                {
                    Category = "Novel",
                    Name = "Black 3 Minutes",
                    Price = 230.0M
                });
            Books.Add(
                new Book()
                {
                    Category = "Novel",
                    Name = "Rich and Powerful",
                    Price = 310.50M
                });
            Books.Add(
                new Book()
                {
                    Category = "Novel",
                    Name = "Lie",
                    Price = 130.50M
                });
            Books.Add(
               new Book()
               {
                   Category = "Novel",
                   Name = "See you next century",
                   Price = 10.50M
               });
        }
    }

    class Book
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
