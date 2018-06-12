/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSWindowsStoreAppAddItem
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrate how to add item to grouped GridView
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

using CSWindowsStoreAppAddItem.SampleData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppAddItem
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppAddItem.Common.LayoutAwarePage
    {

        /// <summary>
        /// The data source for the grouped grid view.
        /// </summary>
        private static ObservableCollection<GroupInfoCollection<Item>> _source;

        public MainPage()
        {
            this.InitializeComponent();

            _source = (new StoreData()).GetGroupsByCategory();

            collectionViewSource.Source = _source;

            ObservableCollection<string> pictureOptions = new ObservableCollection<string>
                                                              {
                                                                  "Banana",
                                                                  "Lemon",
                                                                  "Mint",
                                                                  "Orange",
                                                                  "SauceCaramel",
                                                                  "SauceChocolate",
                                                                  "SauceStrawberry",
                                                                  "SprinklesChocolate",
                                                                  "SprinklesRainbow",
                                                                  "SprinklesVanilla",
                                                                  "Strawberry",
                                                                  "Vanilla"
                                                              };
            pictureComboBox.ItemsSource = pictureOptions;
            pictureComboBox.SelectedIndex = 0;

            ObservableCollection<string> groupOptions = new ObservableCollection<string>();
            foreach (GroupInfoCollection<Item> groupInfoList in _source)
            {
                groupOptions.Add(groupInfoList.Key);
            }

            groupComboBox.ItemsSource = groupOptions;
            groupComboBox.SelectedIndex = 0;
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

        private void btnAddItemClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string path = string.Format(CultureInfo.InvariantCulture, "SampleData/Images/60{0}.png", 
                pictureComboBox.SelectedItem);

            Item item = new Item
            {
                Title = titleTextBox.Text,
                Category = (string)groupComboBox.SelectedItem
            };
            item.SetImage(StoreData.BaseUri, path);

            GroupInfoCollection<Item> group =
                _source.Single(groupInfoList => groupInfoList.Key == item.Category);

            group.Add(item);            
        }
    }
}
