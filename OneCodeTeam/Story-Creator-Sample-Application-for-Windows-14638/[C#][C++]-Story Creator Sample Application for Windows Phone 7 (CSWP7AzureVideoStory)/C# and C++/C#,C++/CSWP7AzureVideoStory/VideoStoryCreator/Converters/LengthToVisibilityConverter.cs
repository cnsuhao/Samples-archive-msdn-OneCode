/****************************** Module Header ******************************\
* Module Name:	LengthToVisibilityConverter.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* Converts an integer to Visibility.
* Returns Collapsed if and only if the integer is larger than 0.
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
using System.Windows;
using System.Windows.Data;

namespace VideoStoryCreator.Converters
{
    /// <summary>
    /// A converter. The value must be of type int.
    /// If the value is greater than 0, return visible. Otherwise return collapsed.
    /// </summary>
    public class LengthToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                int length = (int)value;
                if (length <= 0)
                {
                    return Visibility.Visible;
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
