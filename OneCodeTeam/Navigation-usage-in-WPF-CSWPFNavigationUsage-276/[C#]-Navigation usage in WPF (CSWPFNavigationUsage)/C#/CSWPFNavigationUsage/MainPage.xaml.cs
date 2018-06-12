/****************************** Module Header ******************************\
 Module Name:  MainPage.xaml.cs
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

namespace CSWPFNavigationUsage
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();           
        }

        private void OnHyperlink(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        }
      
        private void OnNavagateToObject(object sender, RoutedEventArgs e)
        {
            MyDummy obj = new MyDummy() { Property1 = "Hello", Property2 = "everyone" };
            this.NavigationService.Navigate(obj);
        }
       
        private void OnNavagateToPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("FramePage.xaml", UriKind.Relative));
        }
    }

    public class MyDummy
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
}
