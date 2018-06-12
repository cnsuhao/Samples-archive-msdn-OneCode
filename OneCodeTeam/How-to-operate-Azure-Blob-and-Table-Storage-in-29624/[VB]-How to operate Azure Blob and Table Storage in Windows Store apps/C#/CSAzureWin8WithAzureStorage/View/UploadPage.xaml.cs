/***************************** Module Header ******************************\
* Module Name:	UploadPage.xaml.cs
* Project:		CSAzureWin8WithAzureStorage
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to store images to Windows Azure Blob storage,
* and save image information to table storage.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/
using CSAzureWin8WithAzureStorage.Common;
using CSAzureWin8WithAzureStorage.Model;
using System;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSAzureWin8WithAzureStorage.View
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class UploadPage : Page
    {
        StorageFolder temporaryFolder = ApplicationData.Current.TemporaryFolder;
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public UploadPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var pictureVM = new PictureViewModel();
            this.DefaultViewModel["uploadForm"] = pictureVM;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var uploadForm = this.DefaultViewModel["uploadForm"] as PictureViewModel;
            var openPicker = new FileOpenPicker()
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };

            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            var file = await openPicker.PickSingleFileAsync();
            StorageFile tempFile;
            if (file != null)
            {             
                tempFile = await file.CopyAsync(temporaryFolder, Guid.NewGuid().ToString());
                uploadForm.PictureFile = tempFile;
                txtFileName.Text = file.Name;
                var thumbnail = await file.GetThumbnailAsync(ThumbnailMode.PicturesView);
                var bitmap = new BitmapImage();
                bitmap.SetSource(thumbnail);
                imgThumbnail.Source = bitmap;
            }  
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.IsEnabled = false;
            var uploadForm = this.DefaultViewModel["uploadForm"] as PictureViewModel;
            uploadForm.Description = txtDescription.Text;
            uploadForm.Name = txtFileName.Text;
            if (uploadForm.Description==string.Empty||uploadForm.Name==string.Empty||uploadForm.PictureFile==null)
            {
                var messageBox = new MessageDialog("Please fill all the information", "Warning!");
                await messageBox.ShowAsync();
                btnSave.IsEnabled = true;
                return;
            }
            if (await PictureDataSource.UploadPictureToCloud(uploadForm))
            {
                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                MessageDialog messageBox = new MessageDialog("Failed to upload, please try it again later.");
                await messageBox.ShowAsync();
            }
        }
    }
}
