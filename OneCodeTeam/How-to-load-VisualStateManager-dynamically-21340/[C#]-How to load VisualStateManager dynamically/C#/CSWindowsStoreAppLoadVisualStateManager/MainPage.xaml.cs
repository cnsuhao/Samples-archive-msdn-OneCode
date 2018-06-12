/****************************** Module Header ******************************\
 * Module Name:  MainPage.cs
 * Project:      CSWindowsStoreAppLoadVisualStateManager
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to load VisualStateManager dynamically and 
 * attach it to the page at runtime.
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppLoadVisualStateManager
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppLoadVisualStateManager.Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
            SampleData sampleData = new SampleData();
            BooksGridView.ItemsSource = sampleData.Books;
            BooksListView.ItemsSource = sampleData.Books;

            VisualStateResources.LoadVisualStateManager.AttachVisualStateGroups(rootContent);
        }

        #region Common methods

        async private void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));
        }


        public void NotifyUser(string message)
        {
            this.statusText.Text = message;
        }

        #endregion
    }
}
