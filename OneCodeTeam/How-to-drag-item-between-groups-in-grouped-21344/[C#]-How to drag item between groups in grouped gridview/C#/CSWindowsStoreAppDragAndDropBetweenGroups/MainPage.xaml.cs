/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSWindowsStoreAppDragAndDropBetweenGroups
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to drag and drop item between groups in a 
 * grouped GridView.
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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CSWindowsStoreAppDragAndDropBetweenGroups.Model;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppDragAndDropBetweenGroups
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppDragAndDropBetweenGroups.Common.LayoutAwarePage
    {

        Book draggedItem;
        public MainPage()
        {
            this.InitializeComponent();
            categoryCollectionViewSource.Source = new SampleData().GetCategoryDataSource();
            bookCollectionViewSource.Source = new SampleData().GetBookDataSource();
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

        private void ItemsByCategory_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            draggedItem = e.Items[0] as Book;
        }

        private void VariableSizedWrapGrid_Drop(object sender, DragEventArgs e)
        {
            try
            {
                if (draggedItem != null)
                {
                    var sourceCategory = draggedItem.Cate;
                    var child = (((VariableSizedWrapGrid)sender).Children[0] as GridViewItem).Content as Book;
                    draggedItem.Cate = child.Cate;

                    child.Cate.BookList.Add(draggedItem);
                    sourceCategory.BookList.Remove(draggedItem);
                    draggedItem = null;
                }
            }
            catch (Exception ex)
            {
                NotifyUser(ex.ToString());
            }
        }
    }
}
