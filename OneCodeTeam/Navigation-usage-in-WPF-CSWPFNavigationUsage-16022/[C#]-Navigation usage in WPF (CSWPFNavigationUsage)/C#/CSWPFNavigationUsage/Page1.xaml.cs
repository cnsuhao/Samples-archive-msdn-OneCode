/****************************** Module Header ******************************\
 Module Name:  Page1.xaml.cs
 Project:      CSWPFNavigationUsage
 Copyright (c) Microsoft Corporation.

 The sample demonstrates navigation usages in a WPF application.

 This source is subject to the Microsoft Public License.
 See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
 All other rights reserved.

 THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace CSWPFNavigationUsage
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            // Get a reference to the NavigationService that navigated to this Page
            NavigationService ns = NavigationService.GetNavigationService(this);
        }
        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Create a pack URI
            Uri uri = new Uri("AnotherPage.xaml", UriKind.Relative);
            // Get the navigation service that was used to 
            // navigate to this page, and navigate to 
            // AnotherPage.xaml
            this.NavigationService.Navigate(uri);
        }
    }
}
