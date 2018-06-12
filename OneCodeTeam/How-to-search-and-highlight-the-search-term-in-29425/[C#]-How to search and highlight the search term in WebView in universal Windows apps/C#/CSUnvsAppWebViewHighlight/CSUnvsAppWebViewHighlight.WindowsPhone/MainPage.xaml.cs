/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.cs
* Project:      CSUnvsAppWebViewHighlight.WindowsPhone
* Copyright (c) Microsoft Corporation.
*
* This code sample shows how to search and highlight the search term in WebView
* in Universal apps.
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
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace CSUnvsAppWebViewHighlight
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string highlightFunctionJS;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            StorageFile highlightFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///highlight.js"));
            highlightFunctionJS = await FileIO.ReadTextAsync(highlightFile);
        }

        private async void HighlightButton_Click(object sender, RoutedEventArgs e)
        {
            if (HighlightTerm.Text == "")
            {
                return;
            }
            await MyWebView.InvokeScriptAsync("eval", new string[] { highlightFunctionJS + " HighlightFunction('" + HighlightTerm.Text + "');" });           
        }

        private async void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (HighlightTerm.Text == "")
            {
                return;
            }
            await MyWebView.InvokeScriptAsync("eval", new string[] { highlightFunctionJS + " RestoreFunction();" });
           
            HighlightTerm.Text = "";
        }

        private void MyWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            HighLightBtn.IsEnabled = true;
            ClearBtn.IsEnabled = true;
        }
        private async void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));
        }

    }
}
