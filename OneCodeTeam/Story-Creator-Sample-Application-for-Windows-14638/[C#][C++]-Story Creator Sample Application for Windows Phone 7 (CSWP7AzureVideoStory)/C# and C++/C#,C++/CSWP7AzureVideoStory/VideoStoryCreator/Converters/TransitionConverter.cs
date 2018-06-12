/****************************** Module Header ******************************\
* Module Name:	TransitionConverter.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* Converts a transition to string and vice versa.
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
using VideoStoryCreator.Transitions;

namespace VideoStoryCreator.Converters
{
    public class TransitionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                // Default to fade transition.
                return "Fade Transition";
            }
            return ((ITransition)value).Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return TransitionFactory.CreateTransition("Fade Transition");
            }
            return TransitionFactory.CreateTransition((string)value);
        }
    }
}
