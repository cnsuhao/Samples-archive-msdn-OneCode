/****************************** Module Header ******************************\
 * Module Name:  Book.cs
 * Project:      CSWindowsStoreAppDragAndDropBetweenGroups
 * Copyright (c) Microsoft Corporation.
 * 
 * A simple entity class for demo purpose.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

namespace CSWindowsStoreAppDragAndDropBetweenGroups.Model
{
    public class Book 
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public Category Cate { get; set; }
    }
}
