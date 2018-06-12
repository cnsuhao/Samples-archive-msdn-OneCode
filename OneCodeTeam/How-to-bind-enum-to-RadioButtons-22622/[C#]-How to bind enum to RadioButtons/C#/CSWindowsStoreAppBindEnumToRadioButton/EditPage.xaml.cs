/****************************** Module Header ******************************\
 * Module Name:  EditPage.xaml.cs
 * Project:      CSWindowsStoreAppBindEnumToRadioButton
 * Copyright (c) Microsoft Corporation.
 * 
 * This is the edit page of the sample
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
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppBindEnumToRadioButton
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class EditPage : CSWindowsStoreAppBindEnumToRadioButton.Common.LayoutAwarePage
    {        
        List<int> AgeCollection;
        public EditPage()
        {
            this.InitializeComponent();

            // Initialize the age ComboBox
            AgeCollection = new List<int>();
            for (int i = 1; i <= 120; i++)
            {
                AgeCollection.Add(i);
            }
            AgeComboBox.ItemsSource = AgeCollection;
        }
       

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get selected customer
            Customer cus = e.Parameter as Customer;
            this.DataContext = cus;
            base.OnNavigatedTo(e);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {            
            Frame.Navigate(typeof(MainPage));
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

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                HintTextBlock.Visibility = Visibility.Visible;
                SaveButton.IsEnabled = false;
            }
            else
            {
                HintTextBlock.Visibility = Visibility.Collapsed;
                SaveButton.IsEnabled = true;
            }
        }
    }
}
