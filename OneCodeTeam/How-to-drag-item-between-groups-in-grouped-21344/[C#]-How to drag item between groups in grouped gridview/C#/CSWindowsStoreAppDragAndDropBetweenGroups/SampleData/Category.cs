/****************************** Module Header ******************************\
 * Module Name:  Category.cs
 * Project:      CSWindowsStoreAppDragAndDropBetweenGroups
 * Copyright (c) Microsoft Corporation.
 * 
 * This class holds a collection of Books.  
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Collections.ObjectModel;

namespace CSWindowsStoreAppDragAndDropBetweenGroups.Model
{
    public class Category
    {
        public Category()
        {
            BookList = new ObservableCollection<Book>();
        }

        public string Name { get; set; }
        public ObservableCollection<Book> BookList { get; set; }
    }
}
