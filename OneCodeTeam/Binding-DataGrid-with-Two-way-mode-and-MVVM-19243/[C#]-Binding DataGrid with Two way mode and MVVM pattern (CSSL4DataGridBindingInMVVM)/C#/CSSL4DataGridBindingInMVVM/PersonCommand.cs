/****************************** Module Header ******************************\
* Module Name: PersonCommand.cs
* Project:     CSSL4DataGridBindingInMVVM
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to bind data source with using two way mode with
* frequent changed data, the clients can be notified when properties has been 
* changed. The sample designed by MVVM pattern, the lightly pattern provides a 
* flexible way for improving code re-use, simply maintenance and testing.
* 
* The PersonCommand class is used to respond when Model instance value changed.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;

namespace CSSL4DataGridBindingInMVVM
{
    /// <summary>
    /// The class implements ICommand interface and displays a dialog box
    /// to show data.
    /// </summary>
    public class PersonCommand : ICommand
    {
        public PersonViewModel viewModel;
        public event EventHandler CanExecuteChanged;
        private IsolatedStorageSettings appSetting; 
        public PersonCommand(PersonViewModel view)
        {
            this.viewModel = view;
            appSetting = IsolatedStorageSettings.ApplicationSettings;
        }

        public bool CanExecute(object parameter)
        {
            bool validateFlag = false;
            if (appSetting.Contains("validateFlag"))
            {
                validateFlag = (bool)appSetting["validateFlag"];
            }
            if (validateFlag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }        

        public void Execute(object parameter)
        {
            viewModel.UpdatePerson(viewModel.person);        
        }
    }
}
