/***************************** Module Header ******************************\
* Module Name:	MainPage.xaml.cs
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
using CSAzureWin8WithAzureStorage.View;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace CSAzureWin8WithAzureStorage
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Page
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


        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {

            this.lstMassageInfos.ItemsSource = PictureDataSource.GetAllImages();
        }

     
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

        private async void lstMassageInfos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as PictureViewModel;
            tbFileName.Text = item.Name;
            tbDescription.Text = item.Description;
            if (item.PictureFile==null)
            {
                var blob = new CloudBlockBlob(new Uri(item.PictureUrl), App.credentials);
                StorageFile file;
                try
                {
                    file = await temporaryFolder.CreateFileAsync(item.Name, CreationCollisionOption.ReplaceExisting);
                    using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        await blob.DownloadToStreamAsync(fileStream);
                    }
                    item.PictureFile = file;
                    imgBlobItem.Source = new BitmapImage(new Uri(file.Path));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                
                imgBlobItem.Source = new BitmapImage(new Uri(item.PictureFile.Path));
            }
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UploadPage));
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var item = lstMassageInfos.SelectedItem as PictureViewModel;
            if (item!=null)
            {
               await PictureDataSource.DeletePictureFormCloud(item);
               lstMassageInfos.SelectedItem = null;
               CleanDetails();
            }
        }
        private void CleanDetails()
        {
            tbFileName.Text = string.Empty;
            tbDescription.Text = string.Empty;
            imgBlobItem.Source = null;
        }
    }
}
