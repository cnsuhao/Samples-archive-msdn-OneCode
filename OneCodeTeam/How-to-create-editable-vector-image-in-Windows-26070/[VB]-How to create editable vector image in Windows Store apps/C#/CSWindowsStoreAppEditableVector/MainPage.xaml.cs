/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSWindowsStoreAppEditableVector
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to create an editable vector 
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
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppEditableVector
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppEditableVector.Common.LayoutAwarePage
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

        private void Rectangle_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var r = sender as Rectangle;
            var x = (double)r.GetValue(Canvas.LeftProperty) + e.Delta.Translation.X;
            var y = (double)r.GetValue(Canvas.TopProperty) + e.Delta.Translation.Y;

            if (x > VectorContainer.Width)
            {
                x = VectorContainer.Width;
            }
            else if (x < -5)
            {
                x = -5;
            }

            if (y > VectorContainer.Height)
            {
                y = VectorContainer.Height;
            }
            else if (y < -5)
            {
                y = -5;
            }
            r.SetValue(Canvas.LeftProperty, x);
            r.SetValue(Canvas.TopProperty, y);
            int k = Convert.ToInt32(r.Tag);
            EditablePolygon.Points[k] = new Point(x + 5, y + 5);
        }
    }
}
