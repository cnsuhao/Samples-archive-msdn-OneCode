/****************************** Module Header ******************************\
* Module Name:	ComposePage.xaml.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* The page used to compose the story.
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
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Phone.Controls;
using VideoStoryCreator.Models;
using VideoStoryCreator.ServiceLocators;
using VideoStoryCreator.Transitions;
using VideoStoryCreator.ViewModels;

namespace VideoStoryCreator
{
    // Since PhoneApplicationPage is not CLS compliant, we have to set it to false in the derived class.
    [CLSCompliant(false)]
    public partial class ComposePage : PhoneApplicationPage
    {
        private ObservableCollection<ComposePhotoViewModel> _photoDataSource;
        private ComposePhotoViewModel _viewModelBackup;

        public ComposePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Prepare the data source.
            this._photoDataSource = new ObservableCollection<ComposePhotoViewModel>();
            this.nameTextBox.Text = App.CurrentStoryName;
            foreach (Photo photo in App.MediaCollection)
            {
                _photoDataSource.Add(ComposePhotoViewModel.CreateFromModel(photo));
            }
            this.photoListBox.ItemsSource = this._photoDataSource;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            this.UpdateModels();
            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// The controls are bound to view model.
        /// So we need to explicitly update the underlying model when needed.
        /// </summary>
        private void UpdateModels()
        {
            foreach (ComposePhotoViewModel viewModel in this._photoDataSource)
            {
                viewModel.UpdateModel();
            }
        }

        private void PreviewButton_Click(object sender, System.EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/PreviewPage.xaml", UriKind.Relative));
        }

        private void EditPhotoButton_Click(object sender, System.EventArgs e)
        {
            if (this.photoListBox.SelectedItem != null && this.photoListBox.SelectedItem is ComposePhotoViewModel)
            {
                this.photoListBox.IsEnabled = false;

                // Backup a copy of the view model, so we can cancel the update operation.
                this._viewModelBackup = ((ComposePhotoViewModel)this.photoListBox.SelectedItem).CopyTo();
                this.ShowEditPanelStoryboard.Begin();
            }
        }

        private void OKButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.photoListBox.IsEnabled = true;
            this.CloseEditPanelStoryboard.Begin();
        }

        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Restore the view model backup.
            if (this._viewModelBackup != null)
            {
                ((ComposePhotoViewModel)this.photoListBox.SelectedItem).CopyFrom(this._viewModelBackup);
            }
            this.photoListBox.IsEnabled = true;
            this.CloseEditPanelStoryboard.Begin();
        }

        private void AddPhotoButton_Click(object sender, System.EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ChooseMediaPage.xaml", UriKind.Relative));
        }

        private void RemovePhotoButton_Click(object sender, System.EventArgs e)
        {
            // Remove the selected item, and close the corresponding stream.
            if (this.photoListBox.SelectedItem != null && this.photoListBox.SelectedItem is ComposePhotoViewModel)
            {
                ComposePhotoViewModel photo = (ComposePhotoViewModel)this.photoListBox.SelectedItem;
                photo.MediaStream.Close();
                this._photoDataSource.Remove(photo);
                photo.RemoveModel();
            }
        }

        private void nameTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // Update the story name.
            if (App.CurrentStoryName != this.nameTextBox.Text && this.nameTextBox.Text != null)
            {
                if (IsolatedStorageHelper.FileExists(this.nameTextBox.Text + ".xml"))
                {
                    if (MessageBox.Show(
                        "A story with the same name already exists. Do you want to override it?",
                        "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        this.RenameStory();
                    }
                    // Revert to the old name.
                    else
                    {
                        this.nameTextBox.Text = App.CurrentStoryName;
                    }
                }
                else
                {
                    this.RenameStory();
                }
            }
        }

        /// <summary>
        /// Rename the story.
        /// </summary>
        private void RenameStory()
        {
            IsolatedStorageHelper.RenameFile(App.CurrentStoryName + ".xml", this.nameTextBox.Text + ".xml");
            App.CurrentStoryName = this.nameTextBox.Text;
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            // Make sure we're using the latest data.
            this.UpdateModels();
            StoryServiceLocator locator = new StoryServiceLocator();
            locator.StoryUploaded += new EventHandler(locator_StoryUploaded);
            locator.UploadStory();
        }

        void locator_StoryUploaded(object sender, EventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                MessageBox.Show("Story successfully uploaded to the cloud.");
            });
        }

        private void TransitionList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.photoListBox.SelectedItem != null && this.photoListBox.SelectedItem is ComposePhotoViewModel)
            {
                // Update the designer to show additional controls for the selected transition.
                // The UI is a ContentControl whose Content is bound to the view model's TransitionDesigner property.
                ComposePhotoViewModel photo = (ComposePhotoViewModel)this.photoListBox.SelectedItem;
                photo.TransitionDesigner = TransitionFactory.CreateTransitionDesigner(this.transitionList.SelectedItem.ToString());
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}