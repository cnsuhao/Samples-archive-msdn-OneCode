/****************************** Module Header ******************************\
 * Module Name:    IDelegateCommand.cs
 * Project:        CSWindowsStoreAppCommandBindingInDataTemplate
 * Copyright (c) Microsoft Corporation.
 * 
 * This class implements ICommand interface and adds a method to fire CanExecuteChanged event.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Windows.Input;

namespace CSWindowsStoreAppCommandBindingInDataTemplate.Command
{
    public interface IDelegateCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
