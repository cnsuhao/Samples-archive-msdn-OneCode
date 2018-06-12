/***************************** Module Header ******************************\
* Module Name:	MainPage.xaml.cs
* Project:		CSAzureBlobClassLiabaryWithWin8App
* Copyright (c) Microsoft Corporation.
* 
* Windows Azure storage class library now supports windows store app.
* This sample will show you how to operate Azure blob storage in your store app, 
* including upload/download/delete file from blob storage.
*
* MainPage.xaml.cs
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/

using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CSAzureBlobClassLiabaryWithWin8App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Windows.Storage.StorageFolder temporaryFolder = ApplicationData.Current.TemporaryFolder;

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            refreshListview();
        }

        /// <summary>
        /// Refresh the Listview.
        /// </summary>
        private async void refreshListview()
        {
            try
            {
                await App.container.CreateIfNotExistsAsync();
                BlobContinuationToken token = null;
                var blobSSegmented = await App.container.ListBlobsSegmentedAsync(token);
                lvwBlobs.ItemsSource = blobSSegmented.Results;
            }
            catch (Exception ex)
            {
                lbState.Text += (ex.Message + "\n"); 
            } 
           
        }

        /// <summary>
        /// Select a image file, and save it to Azure blob.
        /// </summary>
        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".jpeg");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                using (var fileStream = await file.OpenSequentialReadAsync())
                {
                    try
                    {
                        await App.container.CreateIfNotExistsAsync();
                        var blob = App.container.GetBlockBlobReference(file.Name);
                        await blob.DeleteIfExistsAsync();
                        await blob.UploadFromStreamAsync(fileStream);
                        lbState.Text += DateTime.Now.ToString() + ": Save picture '"+file.Name+ "' successfully!\n";
                        refreshListview();
                    }
                    catch (Exception ex)
                    {
                        lbState.Text += (ex.Message + "\n"); 
                    } 
                }
            }
        }

        /// <summary>
        /// Delete the Item in blob.
        /// </summary>
        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvwBlobs.SelectedIndex!=-1)
            {
                var item = lvwBlobs.SelectedItem as CloudBlockBlob;
                var blob= App.container.GetBlockBlobReference(item.Name);
                try
                {
                    await blob.DeleteIfExistsAsync();
                    imgBlobItem.Source = null;
                }
                catch (Exception ex)
                {
                    lbState.Text += (ex.Message + "\n"); 
                }
                
                refreshListview();
                lbState.Text += DateTime.Now.ToString() + item.Name + " has been removed from blob\n";
            }
        }


        /// <summary>
        /// Download file from blob, save it to tempfolder and show it in screen.
        /// </summary>
        private async void lvwBlobs_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as CloudBlockBlob;
             var blob = App.container.GetBlockBlobReference(item.Name);
             StorageFile file;
             try
             {
                 file = await temporaryFolder.CreateFileAsync(item.Name,
                    CreationCollisionOption.ReplaceExisting);

                 using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                 {
                     await blob.DownloadToStreamAsync(fileStream);
                 }

                 // Make sure it's an image file.
                 imgBlobItem.Source = new BitmapImage(new Uri(file.Path));   
             }
             catch (Exception ex)
             {
                 lbState.Text += (ex.Message + "\n");
             }
        }
    }
}
