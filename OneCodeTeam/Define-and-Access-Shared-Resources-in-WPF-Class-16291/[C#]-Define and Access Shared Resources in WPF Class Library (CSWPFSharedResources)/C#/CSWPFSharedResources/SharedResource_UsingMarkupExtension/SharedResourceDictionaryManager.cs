
/****************************** Module Header ******************************\
Module Name:  SharedResourceDictionaryManager.cs
Project:      SharedResource_UsingMarkupExtension
Copyright (c) Microsoft Corporation.

This class provides the access to the resourcedictionary of the specified Uri. 
 * This is a static class and can be accessed anywhere from the application.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using System.Windows;

namespace SharedResource_UsingMarkupExtension
{
    /// <summary>
    /// Static class to access resourcedictionary for specified Uri.
    /// </summary>
    internal static class SharedResourceDictionaryManager
    {
        /// <summary>
        /// Returns the resourcedictionary from the xaml whose uri is provided.
        /// </summary>
        internal static ResourceDictionary SharedResourceDictionary
        {
            get
            {
                if (_SharedResourceDictionary == null)
                {
                    Uri resourceUri = new Uri(_UriString, UriKind.Relative);

                    _SharedResourceDictionary =
                        (ResourceDictionary)Application.LoadComponent(resourceUri);
                }

                return _SharedResourceDictionary;
            }
        }


        static ResourceDictionary _SharedResourceDictionary;
        static string _UriString = "/SharedResource_UsingMarkupExtension;component/MyResources.xaml";
    }
}
