/****************************** Module Header ******************************\
* Module Name: MainPage.xaml.cs
* Project:     CSSL4DataGridBindingInMVVM
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to bind data source with using two way mode with
* frequent changed data, the clients can be notified when properties has been 
* changed. The sample designed by MVVM pattern, the lightly pattern provides a 
* flexible way for improving code re-use, simply maintenance and testing.
* 
* The main page is used to display binding message.
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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;
using System.IO.IsolatedStorage;

namespace CSSL4DataGridBindingInMVVM
{
    public partial class MainPage : UserControl
    {
        private bool flag = true;
        private IsolatedStorageSettings appSetting;
        public MainPage()
        {
            InitializeComponent();
            appSetting = IsolatedStorageSettings.ApplicationSettings;
            if (!appSetting.Contains("validateFlag"))
            {
                appSetting.Add("validateFlag", this.flag);
            }
        }

        /// <summary>
        /// The method is used for catching binding exceptions.
        /// We can also store validate variable with IsolatedStorageSettings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void tbValidate(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                (e.OriginalSource as Control).Background = new SolidColorBrush(Colors.Yellow);
                flag = false;
            }
            if (e.Action == ValidationErrorEventAction.Removed)
            {
                (e.OriginalSource as Control).Background = new SolidColorBrush(Colors.White);
                flag = true;
            }
            appSetting["validateFlag"] = flag;
        }

    }
}
