/****************************** Module Header ******************************\
* Module Name:    MainPage.xaml.cs
* Project:        CSWP8Zooming
* Copyright (c) Microsoft Corporation
*
* This demo shows how to zoom in/out image and video.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace CSWP8Zooming
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void ImageZoom(object sender, RoutedEventArgs e)
        {
            NavigateMethod("/ImageZoom.xaml");
        }       

        private void VideoZoom(object sender, RoutedEventArgs e)
        {
            NavigateMethod("/VideoZoom.xaml");
        }      

        private void NavigateMethod(string uriString)
        {
            NavigationService.Navigate(new Uri(uriString, UriKind.Relative));
        }       
    }
}