/****************************** Module Header ******************************\
* Module Name:	ChooseMediaPage.xaml.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* This page allows the user to choose photos.
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using VideoStoryCreator.Models;
using VideoStoryCreator.Transitions;
using VideoStoryCreator.ViewModels;

namespace VideoStoryCreator
{
    // Since PhoneApplicationPage is not CLS compliant, we have to set it to false in the derived class.
    [CLSCompliant(false)]
    public partial class ChooseMediaPage : PhoneApplicationPage
    {
        private ObservableCollection<ChoosePhotoViewModel> _photoDataSource;
        private List<ChoosePhotoViewModel> _selectedPhotos;
        private int _currentPage = 0;

        // TODO: Design consideration: Currently hard code 20.
        // Should we move all hard coded value to a single place,
        // so in the future, it will be easier to support user configuration?
        private int _pageSize = 20;

        public ChooseMediaPage()
        {
            InitializeComponent();

            this._photoDataSource = new ObservableCollection<ChoosePhotoViewModel>();
            this._selectedPhotos = new List<ChoosePhotoViewModel>();
            this.GetPicturesForCurrentPage();
            this.MediaListBox.ItemsSource = _photoDataSource;
        }

        /// <summary>
        /// It's not a good idea to display all photos at once.
        /// This method implements paging.
        /// TODO: Design consideration: Should we create a helper class to interact with media library
        /// instead of putting the code in code behind for a XAML page?
        /// </summary>
        private void GetPicturesForCurrentPage()
        {
            // Page number should not be less than 0.
            if (this._currentPage < 0)
            {
                this._currentPage = 0;
                return;
            }

            MediaLibrary mediaLibrary = new MediaLibrary();

            // Already the last page.
            int pageCount = mediaLibrary.Pictures.Count / this._pageSize;
            if (this._currentPage > pageCount)
            {
                this._currentPage = pageCount;
                return;
            }

            // Store the selection.
            this.StoreSelection();

            // Reset the data source.
            this._photoDataSource.Clear();

            var picturesOnCurrentPage = mediaLibrary.Pictures.Skip(this._currentPage * this._pageSize).Take(this._pageSize);
            foreach (var picture in picturesOnCurrentPage)
            {
                Stream pictureStream = picture.GetThumbnail();
                ChoosePhotoViewModel viewModel = new ChoosePhotoViewModel()
                {
                    Name = picture.Name,
                    MediaStream = pictureStream
                };

                // In PhotoViewModel, we override Equals to compare the name of the photo rather than the reference.
                // So if a photo with the same name is found in selected photos, Contains will return true.
                if (this._selectedPhotos.Contains(viewModel))
                {
                    viewModel.IsSelected = true;
                }

                _photoDataSource.Add(viewModel);
            }
        }

        /// <summary>
        /// Add selected photos on the current page to selected photo list,
        /// and close unselected photos.
        /// </summary>
        private void StoreSelection()
        {
            foreach (ChoosePhotoViewModel photo in this._photoDataSource)
            {
                if (photo.IsSelected && !this._selectedPhotos.Contains(photo))
                {
                    this._selectedPhotos.Add(photo);
                }
                // If the media is not chosen, close the thumbnail stream.
                else
                {
                    photo.MediaStream.Close();
                }
            }
        }

        private void OKButton_Click(object sender, System.EventArgs e)
        {
            this.StoreSelection();

            // Add all selected photos to App.MediaCollection.
            foreach (ChoosePhotoViewModel photo in this._selectedPhotos)
            {
                Photo photoModel = new Photo()
                {
                    Name = photo.Name,
                    ThumbnailStream = photo.MediaStream,
                    PhotoDuration = TimeSpan.FromSeconds(5d),
                    Transition = TransitionFactory.CreateDefaultTransition()
                };
                if (!App.MediaCollection.Contains(photoModel))
                {
                    App.MediaCollection.Add(photoModel);
                }
            }

            // Go back to the calling page.
            this.NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            // Close all thumbnail streams.
            foreach (ChoosePhotoViewModel photo in this._photoDataSource)
            {
                photo.MediaStream.Close();
            }

            // Go back to the calling page without doing anything.
            this.NavigationService.GoBack();
        }

        private void PreviousPageButton_Click(object sender, System.EventArgs e)
        {
            this._currentPage--;
            this.GetPicturesForCurrentPage();
        }

        private void NextPageButton_Click(object sender, System.EventArgs e)
        {
            this._currentPage++;
            this.GetPicturesForCurrentPage();
        }
    }
}