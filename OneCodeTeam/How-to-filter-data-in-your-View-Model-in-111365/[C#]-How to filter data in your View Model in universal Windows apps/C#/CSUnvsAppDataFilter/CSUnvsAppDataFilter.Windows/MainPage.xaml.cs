/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSUnvsAppDataFilter.Windows
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to filter data in your View Model.
 *
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using CSUnvsAppDataFilter.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace CSUnvsAppDataFilter
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel viewModel = new MainViewModel();
        public MainPage()
        {
            this.InitializeComponent();

            this.DataContext = viewModel;
        }

        async private void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(e.NewSize.Width < 800.0)
            {
                VisualStateManager.GoToState(this, "MinimalLayout", true);
            }
            else if(e.NewSize.Width < e.NewSize.Height)
            {
                VisualStateManager.GoToState(this, "PortraitLayout", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "DefaultLayout", true);
            }
        }
    }
}
