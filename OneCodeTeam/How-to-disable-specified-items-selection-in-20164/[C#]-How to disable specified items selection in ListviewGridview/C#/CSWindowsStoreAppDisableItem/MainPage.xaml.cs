/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSWindowsStoreAppDisableItem
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to disable specified item selection in Gridview.
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
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppDisableItem
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppDisableItem.Common.LayoutAwarePage
    {
        ObservableCollection<Book> books = new ObservableCollection<Book>();
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gvBooks.ItemsSource = books;
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

        #region Add Button Click Event
        /// <summary>
        /// Add item to the Gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInfo())
            {
                tbHint.Visibility = Visibility.Collapsed;
                Book book = new Book();
                book.Name = txtName.Text;
                book.Category = cbCategory.SelectedValue.ToString();
                book.Price = Convert.ToDecimal(txtPrice.Text);
                book.Available = Convert.ToBoolean( cbAvailable.SelectedIndex);
                books.Add(book);
                svContent.ScrollToVerticalOffset(svContent.ExtentHeight);
            }
        }
        #endregion

        #region Validate information
        /// <summary>
        /// Check if the information is valid
        /// </summary>
        /// <returns></returns>
        private bool ValidateInfo()
        {
            bool valid = false;
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                tbHint.Text = "Please complete the information!";
                tbHint.Visibility = Visibility.Visible;
            }            
            else
            {
                valid = true;
            }
            return valid;
        }
        #endregion
        
        #region Tapped Event
        /// <summary>
        /// Selete the selectable item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvBooks_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // The y coordinate of the tapped position
            double y = e.GetPosition((UIElement)sender).Y;

            // The x coordinate of the tapped position
            double x = e.GetPosition((UIElement)sender).X;
            
            GridView gvBooksContainer = sender as GridView;

            gvBooksContainer.Measure(new Size(235, 80));
            Size size = gvBooksContainer.DesiredSize;            
            
            // The tapped item's x index
            int itemX = (int)(x / size.Width);

            // The tapped item's y index
            int itemY = (int)(y / size.Height);

            // Get the index of tapped item
            int index = (int)(itemY * (int)(gvBooks.ActualWidth / size.Width)) + itemX;

            if (index < gvBooks.Items.Count)
            {
                Book book = gvBooks.Items[index] as Book;
                if (book.Available == true)
                {
                    // Get the tapped item
                    GridViewItem tappedItem = gvBooksContainer.ItemContainerGenerator.ContainerFromIndex(index) as GridViewItem;
                    gvBooksContainer.SelectionMode = ListViewSelectionMode.Single;
                    tappedItem.IsSelected = true;
                }
                else
                {
                    gvBooksContainer.SelectionMode = ListViewSelectionMode.None;
                }
            }
        }
        #endregion

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                tbHint.Text = "Price format is not valid! e.g. 12.35";
                tbHint.Visibility = Visibility.Visible;
            }
            else
            {
                tbHint.Visibility = Visibility.Collapsed;
            }
        }
    }
}
