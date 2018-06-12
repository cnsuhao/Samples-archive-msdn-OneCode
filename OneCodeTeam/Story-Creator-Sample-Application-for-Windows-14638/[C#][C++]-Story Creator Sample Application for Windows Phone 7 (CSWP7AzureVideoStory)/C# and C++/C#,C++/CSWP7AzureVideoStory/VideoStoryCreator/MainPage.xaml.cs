/****************************** Module Header ******************************\
* Module Name:	MainPage.xaml.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* The main page. It contains buttons that link to other pages.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace VideoStoryCreator
{
    // Since PhoneApplicationPage is not CLS compliant, we have to set it to false in the derived class.
    [CLSCompliant(false)]
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void NewStoryButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (MessageBox.Show(
                "If you begin a new story, unsaved progress in the current story may be lost. Do you wish to continue?"
                , "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                this.newStoryStoryboard.Begin();
            }
        }

        private void LastStoryButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(App.CurrentStoryName))
            {
                MessageBox.Show("Current story not found.");
                return;
            }
            this.NavigationService.Navigate(new Uri("/ComposePage.xaml", UriKind.Relative));
        }

        private void PreviousStoryButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ChooseStoryPage.xaml", UriKind.Relative));
        }

        private void newStoryOKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.newStoryNameTextBox.Text))
            {
                // Clear any in-memory data.
                foreach (var photo in App.MediaCollection)
                {
                    photo.ThumbnailStream.Close();
                }
                App.MediaCollection.Clear();
                App.CurrentStoryName = this.newStoryNameTextBox.Text;
                this.closeNewStoryStoryboard.Begin();
                this.NavigationService.Navigate(new Uri("/ComposePage.xaml", UriKind.Relative));
            }
        }

        private void newStoryCancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.closeNewStoryStoryboard.Begin();
        }
    }
}