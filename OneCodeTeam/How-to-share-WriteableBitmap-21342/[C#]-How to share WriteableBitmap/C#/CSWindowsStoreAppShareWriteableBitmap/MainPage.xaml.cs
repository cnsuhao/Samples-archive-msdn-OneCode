/****************************** Module Header ******************************\
 * Module Name:  MainPage.cs
 * Project:      CSWindowsStoreAppShareWriteableBitmap
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to share WriteableBitmap image in Windows Store app
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
using System.IO;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppShareWriteableBitmap
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppShareWriteableBitmap.Common.LayoutAwarePage
    {
        DataTransferManager dataTransferManager;
        WriteableBitmap image;
        StorageFile file;
        public MainPage()
        {
            this.InitializeComponent();
        }

        #region Common methods

        async private void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));
        }


        public void NotifyUser(string message)
        {
            this.statusText.Text = message;
        }

        #endregion

        #region Load image file to image control
        // Use FileOpenPicker to pick an image and display it in UI
        private async void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.EnsureUnsnapped())
            {
                FileOpenPicker openPicker = new FileOpenPicker();
                openPicker.ViewMode = PickerViewMode.Thumbnail;
                openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                openPicker.FileTypeFilter.Add(".jpg");
                openPicker.FileTypeFilter.Add(".jpeg");
                openPicker.FileTypeFilter.Add(".png");

                file = await openPicker.PickSingleFileAsync();
                using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    image = new WriteableBitmap(1, 1);
                    image.SetSource(stream);
                    WriteableBitmapImage.Source = image;
                }
                ShareButton.IsEnabled = true;
            }           
        }

        internal bool EnsureUnsnapped()
        {
            // FilePicker APIs will not work if the application is in a snapped state.
            // If an app wants to show a FilePicker while snapped, it must attempt to unsnap first
            bool unsnapped = ((ApplicationView.Value != ApplicationViewState.Snapped) || ApplicationView.TryUnsnap());
            if (!unsnapped)
            {
                NotifyUser("Cannot unsnap the sample.");
            }

            return unsnapped;
        }
        #endregion

        #region Register share contract and unregister share contract
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.dataTransferManager = DataTransferManager.GetForCurrentView();
            this.dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.OnDataRequested);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            this.dataTransferManager.DataRequested -= new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.OnDataRequested);
        }
        #endregion        

        private async void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequestDeferral deferral = e.Request.GetDeferral();

            DataPackage requestData = e.Request.Data;
            requestData.Properties.Title = "Share WriteableBitmap Image Sample";            
            requestData.Properties.Description = "This sample demonstrates how to share WriteableBitmap image in Windows Store app.";

            // This stream is to create a bitmap image later
            IRandomAccessStream stream = new InMemoryRandomAccessStream();

            // Determin which type of BitmapEncoder we should create
            Guid encoderId;
            if (file != null)
            {
                switch (file.FileType)
                {
                    case ".png":
                        encoderId = BitmapEncoder.PngEncoderId;
                        break;
                    case ".bmp":
                        encoderId = BitmapEncoder.BmpEncoderId;
                        break;
                    default:
                        encoderId = BitmapEncoder.JpegEncoderId;
                        break;
                }

                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(encoderId, stream);
                Stream pixelStream = image.PixelBuffer.AsStream();
                byte[] pixels = new byte[pixelStream.Length];
                await pixelStream.ReadAsync(pixels, 0, pixels.Length);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)image.PixelWidth, (uint)image.PixelHeight, 96.0, 96.0, pixels);

                requestData.SetBitmap(RandomAccessStreamReference.CreateFromStream(stream));
                await encoder.FlushAsync();
            }

            deferral.Complete();
        }
       
        private void ShareButton_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }
    }
}
