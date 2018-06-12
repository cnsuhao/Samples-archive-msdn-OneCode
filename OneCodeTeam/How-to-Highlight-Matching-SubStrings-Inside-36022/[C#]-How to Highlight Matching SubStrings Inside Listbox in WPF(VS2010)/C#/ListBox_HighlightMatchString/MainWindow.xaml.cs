/****************************** Module Header ******************************\
* Module Name:  MainWindow.cs
* Project:      ListBox_HighlightMatchString
* Copyright (c) Microsoft Corporation.
*
* Main window class where the controls are added for testing.
*
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListBox_HighlightMatchString
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void chkMatchCase_Checked(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        private void chkMatchWholeWord_Checked(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        private void chkMatchCase_Unchecked(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        private void chkMatchWholeWord_Unchecked(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = string.Empty;
        }
    }
}
