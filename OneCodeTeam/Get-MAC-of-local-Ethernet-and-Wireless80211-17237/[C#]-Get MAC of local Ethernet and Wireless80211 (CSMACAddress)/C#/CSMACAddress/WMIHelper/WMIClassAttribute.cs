/****************************** Module Header ******************************\
 * Module Name:  WMIPropertyAttribute.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 *
 * This attribute indicates that the class is related to a WMI object.
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

    [AttributeUsage(AttributeTargets.Class)]
    public class WMIClassAttribute : Attribute
    {

        /// <summary>
        /// The related WMI class name.
        /// </summary>
        public string ClassName { get; set; }

    }
}
