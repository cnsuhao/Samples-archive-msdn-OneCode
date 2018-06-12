
/****************************** Module Header ******************************\
Module Name:  SharedResourceExtension.cs
Project:      SharedResource_UsingMarkupExtension
Copyright (c) Microsoft Corporation.

This class inherits the MarkupExtension class. 
 * When a key is passed to this class instance , the method in the class will return 
 * the resource from the ResourceDictionary for the specified key.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Windows.Markup;

namespace SharedResource_UsingMarkupExtension
{
    /// <summary>
    /// Inherits the MarkupExtension class. 
    /// Provides resources from resourcedictionary for the specified Key.
    /// </summary>
    public class SharedResourceExtension : MarkupExtension
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SharedResourceExtension()
        {
        }

        /// <summary>
        /// Constructor which accepts one parameter.
        /// </summary>
        /// <param name="key">x:key of the resource which need to be loaded.</param>
        public SharedResourceExtension(object key)
        {
            Key = key;
        }

        #endregion

        /// <summary>
        /// Returns resource from resource dictionary for the specified Key.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return SharedResourceDictionaryManager.SharedResourceDictionary[Key];
        }

        #region Properties

        private object key;

        public object Key 
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        #endregion
    }
}
