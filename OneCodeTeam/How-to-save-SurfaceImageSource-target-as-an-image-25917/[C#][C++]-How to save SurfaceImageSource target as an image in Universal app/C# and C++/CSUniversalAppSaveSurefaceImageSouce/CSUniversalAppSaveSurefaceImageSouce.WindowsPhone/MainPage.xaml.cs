/****************************** Module Header ******************************\
* Module Name:    MainPage.xaml.cs
* Project:        CSUniversalAppSaveSurfaceImageSource.WindowsPhone
* Copyright (c) Microsoft Corporation
*
* This code sample shows how to save the content of SurfaceImageSource to image file.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using MyImageSourceComponent;
using Windows.UI;

namespace CSUniversalAppSaveSurefaceImageSouce
{
    public sealed partial class MainPage : Page, IFileSavePickerContinuable
    {
        uint imageWidth;
        uint imageHeight;
        MyImageSource myImageSource;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            imageWidth = (uint)MyImage.Width;
            imageHeight = (uint)MyImage.Height;
            myImageSource = new MyImageSource(imageWidth, imageHeight, true);
            MyImage.Source = myImageSource;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Begin updating the surfaceImageSource
            myImageSource.BeginDraw();

            // Clear background
            myImageSource.Clear(Colors.Black);

            // Draw something...
            Rect rect;
            float startPointX = 0.0f;
            float startPointY = 0.0f;
            float deltaX = 3.0f;
            float deltaY = 3.0f;

            rect.X = startPointX;
            rect.Y = startPointY;
            rect.Width = (imageWidth - deltaX * 2) / 2.0f;
            rect.Height = (imageHeight - deltaY * 2) / 2.0f;
            myImageSource.FillSolidRect(Color.FromArgb(255, 250, 67, 5), rect);

            rect.X = startPointX + rect.Width + 2 * deltaX;
            myImageSource.FillSolidRect(Color.FromArgb(255, 96, 176, 6), rect);

            rect.X = startPointX;
            rect.Y = startPointY + rect.Height + 2 * deltaY;
            myImageSource.FillSolidRect(Color.FromArgb(255, 14, 179, 241), rect);

            rect.X = startPointX + rect.Width + 2 * deltaX;
            myImageSource.FillSolidRect(Color.FromArgb(255, 247, 199, 36), rect);

            // Stop updating the SurfaceImageSource and draw its contents 
            myImageSource.EndDraw();
        }
        private void SaveContent_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.FileTypeChoices.Add("Png file", new List<string>() { ".png" });
            savePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            savePicker.PickSaveFileAndContinue();

        }
        public async void ContinueFileSavePicker(Windows.ApplicationModel.Activation.FileSavePickerContinuationEventArgs args)
        {
            StorageFile file = args.File;
            if (file != null)
            {
                IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite);
                myImageSource.SaveSurfaceImageToFile(stream);
            }
        }
        private async void Footer_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton hyperlinkButton = sender as HyperlinkButton;
            if (hyperlinkButton != null)
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri(hyperlinkButton.Tag.ToString()));
            }
        }
        
    }
}
