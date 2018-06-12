/****************************** Module Header ******************************\
 * Module Name:  WMIPropertyAttribute.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 *
 * This attribute indicates that the property is related to a WMI object 
 * property.
 * 
 * 
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;

namespace CSMACAddress.WMIHelper
{
    [AttributeUsage(AttributeTargets.Property)]
    public class WMIPropertyAttribute : Attribute
    {

        /// <summary>
        /// The related WMI object property name.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// The type of the related WMI object property value.
        /// </summary>
        public WMIPropertyType PropertyType { get; set; }

        /// <summary>
        /// Specify the .NET type if the WMI object property is referring to another 
        /// WMI object.
        /// </summary>
        public Type AssociatedWMIClass { get; set; }
    }

}
