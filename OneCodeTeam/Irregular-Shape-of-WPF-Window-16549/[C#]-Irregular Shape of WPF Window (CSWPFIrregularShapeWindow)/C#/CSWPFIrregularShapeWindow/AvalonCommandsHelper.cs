/********************************** Module Header **********************************\
*Module Name:  AvalonCommandsHelper.cs
*Project:      CSWPFIrregularShapeWindow
*Copyright (c) Microsoft Corporation.
*
*The AvalonCommandsHelper.cs file defines a CanExecuteCommandSource method which is 
*responsible for Can Execute of a specific command or not
*
*This source is subject to the Microsoft Public License.
*See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
*All other rights reserved.
*
*THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
*EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
*MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***********************************************************************************/

using System.Windows.Input;
using System.Windows;

namespace CSWPFIrregularShapeWindow
{
    /// <summary>
    /// Helper class for WPF commands
    /// </summary>
    public static class AvalonCommandsHelper
    {
        /// <summary>
        /// Gets the Can Execute of a specific command
        /// </summary>
        /// <param name="commandSource">The command to verify</param>
        /// <returns></returns>
        public static bool CanExecuteCommandSource(ICommandSource commandSource)
        {
            ICommand baseCommand = commandSource.Command;
            if (baseCommand == null)
                return false;

            
            object commandParameter = commandSource.CommandParameter;
            IInputElement commandTarget = commandSource.CommandTarget;
            RoutedCommand command = baseCommand as RoutedCommand;
            if (command == null)
                return baseCommand.CanExecute(commandParameter);
            if (commandTarget == null)
                commandTarget = commandSource as IInputElement;
            return command.CanExecute(commandParameter, commandTarget);
        }


    }
}
