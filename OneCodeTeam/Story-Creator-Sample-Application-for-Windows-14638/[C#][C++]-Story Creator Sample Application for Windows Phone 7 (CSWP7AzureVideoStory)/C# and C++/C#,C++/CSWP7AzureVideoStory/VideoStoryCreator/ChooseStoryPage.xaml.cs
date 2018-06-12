/****************************** Module Header ******************************\
* Module Name:	ChooseStoryPage.xaml.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* The page that allows user to open an existing story.
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
    public partial class ChooseStoryPage : PhoneApplicationPage
    {
        public ChooseStoryPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            this.StoryListBox.ItemsSource = PersistenceHelper.EnumerateStories();
            base.OnNavigatedTo(e);
        }

        private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.StoryListBox.SelectedItem != null || this.StoryListBox.SelectedItem is string)
            {
                string storyName = (string)this.StoryListBox.SelectedItem;
                try
                {
                    // Clear any in-memory data.
                    foreach (var photo in App.MediaCollection)
                    {
                        photo.ThumbnailStream.Close();
                    }
                    App.MediaCollection.Clear();
                    App.CurrentStoryName = storyName;
                    PersistenceHelper.ReadStoryFile(storyName);
                    this.NavigationService.Navigate(new Uri("/ComposePage.xaml", UriKind.Relative));
                }
                catch
                {
                    MessageBox.Show("Unable to load the story. The file is likely to be cruppted.");
                }
            }
        }

        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}