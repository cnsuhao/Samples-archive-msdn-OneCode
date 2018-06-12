/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSWindowsStoreAppDynamicFontsize
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to set Dynamic Fontsize for TextBlock
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
using Windows.UI.Xaml.Media;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppDynamicFontsize
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppDynamicFontsize.Common.LayoutAwarePage
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


        /// <summary>
        /// Change TextBlock's Fontsize if the content is too long
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBlock contentTextBlock = sender as TextBlock;
            if (contentTextBlock != null)
            {
                double height = contentTextBlock.Height;
                if (this.ContentTextBlock.ActualHeight > height)
                {
                    // Get how many times the TextBlock's height compares with the existing one
                    double fontsizeMultiplier = Math.Sqrt(height / this.ContentTextBlock.ActualHeight);

                    // Set the new FontSize
                    this.ContentTextBlock.FontSize = Math.Floor(this.ContentTextBlock.FontSize * fontsizeMultiplier);
                }
                contentTextBlock.Height = height;  
            }           
        }       

        /// <summary>
        /// set the TextBlock's Fontsize as default and assign TextBox's Text to the TextBlock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentTextBlock.FontSize = 30;
            ContentTextBlock.Text = ContentTextBox.Text;
        }        
    }
}
