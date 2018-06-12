/****************************** Module Header ******************************\
* Module Name:	NullToBoolConverter.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* Converts an object to a boolean.
* If the object is null, returns false.
* Otherwise returns true.
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
using System.Windows.Data;

namespace VideoStoryCreator.Converters
{
    /// <summary>
    /// A converter. If the value is null, return false. Otherwise return true.
    /// </summary>
    public class NullToBoolConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (value != null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
