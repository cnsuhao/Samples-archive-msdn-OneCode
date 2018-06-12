/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSWindowsStoreAppAccessSQLServer
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to access data from SQL Server database in Windows Store apps 
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
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppAccessSQLServer
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppAccessSQLServer.Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        // Get data from SQL Server by WCF Service
        private async void GetButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear Erro message
            this.NotifyUser("");

            // Create proxy instance
            AccessSQLService.ServiceClient serviceClient = new AccessSQLService.ServiceClient();

            // async call WCF method to get returned data
            AccessSQLService.querySqlRequest request = new AccessSQLService.querySqlRequest();
            AccessSQLService.querySqlResponse ds = await serviceClient.querySqlAsync(request);

            if (ds.queryParam)
            {
                // Convert Xml to List<Article>
                XDocument xdoc = XDocument.Parse(ds.querySqlResult.Nodes[1].ToString(), LoadOptions.None);
                var data = from query in xdoc.Descendants("Table")
                           select new Article
                           {
                               Title = query.Element("Title").Value,
                               Text = query.Element("Text").Value
                           };

                // Set ItemsSource of ListView control
                lvDataTemplates.ItemsSource = data;
            }
            else
            {
                NotifyUser("Error occurs. Please make sure the database has been attached to SQL Server!");
            }
        }
        
        #region Common methods

        /// <summary>
        /// The event handler for the click event of the link in the footer. 
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
            this.StatusBlock.Text = message;
        }

        #endregion     
    }
}
