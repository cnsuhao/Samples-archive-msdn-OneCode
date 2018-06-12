/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSWindowsStoreAppProgressRingOverWebView
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to display ProgressRing over WebView.
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
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppProgressRingOverWebView
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppProgressRingOverWebView.Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();                        
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
       

        private void DisplayWebView_LoadCompleted(object sender, NavigationEventArgs e)
        {
            LoadingProcessProgressRing.IsActive = false;
            DisplayWebView.Visibility = Visibility.Visible;
            MaskRectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Transparent);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = ValidateAndGetUri(UrlTextBox.Text);
            if (uri != null)
            {
                try
                {
                    LoadingProcessProgressRing.IsActive = true;
                    WebViewBrush brush = new WebViewBrush();
                    brush.SourceName = "DisplayWebView";
                    brush.Redraw();
                    MaskRectangle.Fill = brush;
                    DisplayWebView.Navigate(uri);
                    DisplayWebView.Visibility = Visibility.Collapsed;
                }
                catch (Exception ex)
                {
                    NotifyUser(ex.ToString());
                }
            }
        }

        private Uri ValidateAndGetUri(string uriString)
        {
            Uri uri = null;
            try
            {
                uri = new Uri(uriString);
                HintTextBlock.Visibility = Visibility.Collapsed;      
            }
            catch (FormatException)
            {
                HintTextBlock.Visibility = Visibility.Visible;     
            }
            return uri;
        }

        private void UrlTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(UrlTextBox.Text))
            {
                LoadButton.IsEnabled = true;
            }
            else
            {
                LoadButton.IsEnabled = false;
            }
        }
    }
}
