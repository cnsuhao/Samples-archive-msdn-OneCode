/****************************** Module Header ******************************\
 * Module Name:  CustomDataTemplateSelector.cs
 * Project:      CSWindowsStoreAppDisableItem
 * Copyright (c) Microsoft Corporation.
 * 
 * This code snippet creates a custom DataTemplateSelector for the GridView to 
 * choose DataTemplate.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CSWindowsStoreAppDisableItem
{
    public class CustomDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate defaultTemplate { get; set; }
        public DataTemplate unavailable { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            Book book = item as Book;
            if (book.Available == true)
            {
                return this.defaultTemplate;
            }
            else
            {
                return this.unavailable;
            }
        }
    }
}
