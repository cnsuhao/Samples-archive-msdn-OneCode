/****************************** Module Header ******************************\
 * Module Name:  Customer.cs
 * Project:      CSWindowsStoreAppAdaptToResolutionGridView
 * Copyright (c) Microsoft Corporation.
 * 
 * This is the demo data
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

using System.ComponentModel;
namespace CSWindowsStoreAppAdaptToResolutionGridView
{
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public Sport FavouriteSport { get; set; }
    }

    public enum Sport
    {
        Football,
        Basketball,
        Baseball,
        Swimming
    }
}
