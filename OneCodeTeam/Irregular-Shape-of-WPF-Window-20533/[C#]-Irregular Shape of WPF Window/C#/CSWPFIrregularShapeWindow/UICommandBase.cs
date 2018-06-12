/********************************** Module Header **********************************\
*Module Name:  UICommandBase.cs
*Project:      CSWPFIrregularShapeWindow
*Copyright (c) Microsoft Corporation.
*
*The UICommandBase.cs file defines a RoutedUICommand inherit RoutedCommand by implementing the 
*shortcuts bound to command instance variables
*
*This source is subject to the Microsoft Public License.
*See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
*All other rights reserved.
*
*THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
*EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
*MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***********************************************************************************/

using System.Windows;
using System.Windows.Input;

namespace CSWPFIrregularShapeWindow
{
    public abstract class UICommandBase : Window
    {
        

        //<summary>
        //Command to Minimize the windows
        //As you can see the command also hooks to the F3 key of the keyboard
        //</summary>
        public static RoutedUICommand MinimizeCmd = new RoutedUICommand("MinimizeCmd",
                "MinimizeCmd", typeof(UICommandBase), new InputGestureCollection(
                    new InputGesture[] { new KeyGesture(Key.F3, ModifierKeys.None, "Minimize Cmd") }
                    ));

        /// <summary>
        /// Command to Maximize the windows
        ///As you can see the command also hooks to the F4 key of the keyboard
        /// </summary>
        public static RoutedUICommand MaximizeCmd = new RoutedUICommand("MaximizeCmd",
                "MaximizeCmd", typeof(UICommandBase), new InputGestureCollection(
                    new InputGesture[] { new KeyGesture(Key.F4, ModifierKeys.None, "Maximize Cmd") }
                    ));

        /// <summary>
        /// Command to Restore the windows
        /// As you can see the command also hooks to the F5 key of the keyboard
        /// </summary>
        public static RoutedUICommand RestoreCmd = new RoutedUICommand("RestoreCmd",
                "RestoreCmd", typeof(UICommandBase), new InputGestureCollection(
                    new InputGesture[] { new KeyGesture(Key.F5, ModifierKeys.None, "Restore Cmd") }
                    ));

        /// <summary>
        /// Command to Close the windows
        /// As you can see the command also hooks to the F6 key of the keyboard
        /// </summary>
        public static RoutedUICommand CloseCmd = new RoutedUICommand("CloseCmd",
                "CloseCmd", typeof(UICommandBase), new InputGestureCollection(
                    new InputGesture[] { new KeyGesture(Key.F6, ModifierKeys.None, "Close Cmd") }
                    ));


        public UICommandBase()
        {
                      
        }

    }
}
