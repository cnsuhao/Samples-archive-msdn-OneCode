/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSWindowsStoreAppAdaptToResolutionGridView
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to create a custom GridView which can adapt to 
 * different resolutions.
 *  
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

namespace CSWindowsStoreAppAdaptToResolutionGridView
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppAdaptToResolutionGridView.Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Bind the customer collection to GridView
           AGridView.ItemsSource = CustomerCollection.Customers;
        }

        #region Common methods

        /// <summary>
        /// The the event handler for the click event of the link in the footer. 
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private async void FooterClick(object sender, RoutedEventArgs e)
        {
            HyperlinkButton hyperlinkButton = sender as HyperlinkButton;
            if (hyperlinkButton != null)
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri(hyperlinkButton.Tag.ToString()));
            }
        }

        public void NotifyUser(string message)
        {
            this.StatusText.Text = message;
        }

        #endregion
    }
}
