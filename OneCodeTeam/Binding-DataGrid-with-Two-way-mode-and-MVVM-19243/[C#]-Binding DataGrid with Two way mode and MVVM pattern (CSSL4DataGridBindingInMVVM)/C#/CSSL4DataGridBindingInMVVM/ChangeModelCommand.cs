/****************************** Module Header ******************************\
* Module Name: ChangeModelCommand.cs
* Project:     CSSL4DataGridBindingInMVVM
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to bind data source with using two way mode with
* frequent changed data, the clients can be notified when properties has been 
* changed. The sample designed by MVVM pattern, the lightly pattern provides a 
* flexible way for improving code re-use, simply maintenance and testing.
* 
* The class is used to respond ChangeModelByCode button onclick event.
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

namespace CSSL4DataGridBindingInMVVM
{
    public class ChangeModelCommand: ICommand
    {
        /// <summary>
        /// This class is used to change model instance via code, and view layer will update 
        /// when background data source has been changed.
        /// </summary>
        private PersonViewModel viewModel;
        public event EventHandler CanExecuteChanged;
        public ChangeModelCommand(PersonViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter.ToString() != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Change Model instance by Execute method.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            PersonModel model;
            model = viewModel.person;
            model.Name = "Default Name";
            model.Age = 0;
            model.Telephone = "11111111111";
            model.Comment = "Default Comment";
        }
    }
}
