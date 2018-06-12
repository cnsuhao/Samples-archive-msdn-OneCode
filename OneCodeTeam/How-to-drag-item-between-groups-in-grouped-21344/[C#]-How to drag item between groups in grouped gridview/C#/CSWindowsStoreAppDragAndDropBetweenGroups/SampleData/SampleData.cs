/****************************** Module Header ******************************\
 * Module Name:  SampleData.cs
 * Project:      CSWindowsStoreAppDragAndDropBetweenGroups
 * Copyright (c) Microsoft Corporation.
 * 
 * It generates the sample data for data binding.
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using CSWindowsStoreAppDragAndDropBetweenGroups.Model;
using System.Collections.ObjectModel;
namespace CSWindowsStoreAppDragAndDropBetweenGroups
{
    public class SampleData
    {        
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Book> Books { get; set; }   

        public SampleData()
        {
            Categories = new ObservableCollection<Category>();
            Books = new ObservableCollection<Book>();

            Category novel = new Category();
            novel.Name = "Novel";
            Category fairyTale = new Category();
            fairyTale.Name = "Fairy Tale";
            Category management = new Category();
            management.Name = "Management";
            Category computerScience = new Category();
            computerScience.Name = "Computer Science";

            #region Novel
            Book badBoy = new Book();
            badBoy.Name = "Bad Boy";
            badBoy.Author = "John";
            badBoy.Price = 30;
            badBoy.Cate = novel;
            novel.BookList.Add(badBoy);
            Books.Add(badBoy);

            Book fighting = new Book();
            fighting.Name = "Fighting";
            fighting.Author = "Rose";
            fighting.Price = 50;
            fighting.Cate = novel;
            novel.BookList.Add(fighting);
            Books.Add(fighting);

            Book heaven = new Book();
            heaven.Name = "Heaven";
            heaven.Author = "Allen";
            heaven.Price = 100;
            heaven.Cate = novel;
            novel.BookList.Add(heaven);
            Books.Add(heaven);
            #endregion

            #region Fairy Tale
            Book hood = new Book();
            hood.Name = "Hood";
            hood.Author = "Bruce";
            hood.Price = 10;
            hood.Cate = fairyTale;
            fairyTale.BookList.Add(hood);
            Books.Add(hood);

            Book theThree = new Book();
            theThree.Name = "The Three";
            theThree.Author = "Jobs";
            theThree.Price = 60;
            theThree.Cate = fairyTale;
            fairyTale.BookList.Add(theThree);
            Books.Add(theThree);

            Book ninja = new Book();
            ninja.Name = "Ninja";
            ninja.Cate = fairyTale;
            ninja.Author = "Brown";
            ninja.Price = 10;
            fairyTale.BookList.Add(ninja);
            Books.Add(ninja);

            Book White = new Book();
            White.Name = "White";
            White.Author = "Jesson";
            White.Price = 100;
            White.Cate = fairyTale;
            fairyTale.BookList.Add(White);
            Books.Add(White);
            #endregion

            #region Management
            Book fifteenMinutes = new Book();
            fifteenMinutes.Name = "Fifteen Minutes Management";
            fifteenMinutes.Author = "Carter";
            fifteenMinutes.Price = 35;
            fifteenMinutes.Cate = management;
            management.BookList.Add(fifteenMinutes);
            Books.Add(fifteenMinutes);

            Book staffMotivation = new Book();
            staffMotivation.Name = "Staff Motivation";
            staffMotivation.Author = "Sherry";
            staffMotivation.Price = 99;
            staffMotivation.Cate = management;
            management.BookList.Add(staffMotivation);
            Books.Add(staffMotivation);
            #endregion

            #region Computer Science
            Book csharp = new Book();
            csharp.Name = "Learning C# In One Week";
            csharp.Author = "Bob";
            csharp.Price = 200;
            csharp.Cate = computerScience;
            computerScience.BookList.Add(csharp);
            #endregion

            Categories.Add(novel);
            Categories.Add(fairyTale);
            Categories.Add(management);
            Categories.Add(computerScience);   
        }

        /// <summary>
        /// Return the Category Datasouce
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Category> GetCategoryDataSource()
        {
            return Categories;
        }

        /// <summary>
        /// Return the Book Datasource
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Book> GetBookDataSource()
        {
            return Books;
        }
    }
}
