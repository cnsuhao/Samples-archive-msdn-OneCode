/****************************** Module Header ******************************\
 * Module Name:    DelegateCommand.cs
 * Project:        CSWindowsStoreAppCommandBindingInDataTemplate
 * Copyright (c) Microsoft Corporation.
 * 
 * This class implements IDlegateCommand interface
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;

namespace CSWindowsStoreAppCommandBindingInDataTemplate.Command
{
    public class DelegateCommand:IDelegateCommand
    {
        Action<object> execute;
        Func<object, bool> canExecute;

        #region Constructors
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action<object> execute)
        {
            this.execute = execute;
            this.canExecute = this.AlwaysCanExecute;
        }
        #endregion
       
        #region IDelegateCommand
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            execute(parameter);
        }
        #endregion

        bool AlwaysCanExecute(object param)
        {
            return true;
        }
    }
}
