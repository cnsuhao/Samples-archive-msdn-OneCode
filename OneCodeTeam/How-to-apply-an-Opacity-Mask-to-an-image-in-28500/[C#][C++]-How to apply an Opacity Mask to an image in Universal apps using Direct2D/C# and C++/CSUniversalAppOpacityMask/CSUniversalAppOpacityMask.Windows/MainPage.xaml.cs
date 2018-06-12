/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSUniversalAppOpacityMask.Windows
 * Copyright (c) Microsoft Corporation.
 * 
 *  This is the MainPage of the app.
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
using D2DImageSourceWithOpacityMask;
using Windows.Storage.FileProperties;
using Windows.UI;
using Windows.Storage.Pickers;
using Windows.Storage;

namespace CSUniversalAppOpacityMask
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // An image source derived from SurfaceImageSource, used to draw DirectX content
        D2DImageSource m_d2dImageSource;
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            Window.Current.SizeChanged += MainPage_SizeChanged;
            _btnRender.IsEnabled = false;

        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            m_d2dImageSource = new D2DImageSource(
                (int)(ImageGrid.ActualWidth - Image.Margin.Left - Image.Margin.Right),
                (int)(ImageGrid.ActualHeight - Image.Margin.Top - Image.Margin.Bottom), false);

            // Use m_d2dImageSource as a source for the Image control
            Image.Source = m_d2dImageSource;
        }

        private void MainPage_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (e.Size.Width <= 800)
            {
                VisualStateManager.GoToState(this, "MinimalLayout", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "DefaultLayout", true);
            }
        }

        private void _btnRender_Click(object sender, RoutedEventArgs e)
        {
            // Begin updating the SurfaceImageSource
            m_d2dImageSource.BeginDraw();

            // Clear background
            m_d2dImageSource.Clear(Colors.Transparent);

            // Render the source and apply the mask
            m_d2dImageSource.RenderBitmap();

            // Stop updating the SurfaceImageSource and draw its contents
            m_d2dImageSource.EndDraw();
        }

        private async void OpenImageBtn_Click(object sender, RoutedEventArgs e)
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
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                m_d2dImageSource.SetSource(stream);
                var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                await bitmapImage.SetSourceAsync(stream);
                OrignalImage.Source = bitmapImage;
                ImageProperties imageProperties = await file.Properties.GetImagePropertiesAsync();
                OriImageSize.Text = "Image size: " + imageProperties.Width + " * " + imageProperties.Height;
                _btnRender.IsEnabled = true;
            }
        }
        private async void MaskComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StorageFile file;
            var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            switch (MaskComboBox.SelectedIndex)
            {
                case 0:
                    file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/BitmapMask.png"));
                    var stream1 = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    m_d2dImageSource.SetMask(stream1);
                    await bitmapImage.SetSourceAsync(stream1);
                    MaskImage.Source = bitmapImage;
                    ImageProperties imageProperties1 = await file.Properties.GetImagePropertiesAsync();
                    MaskImageSize.Text = "Image size: " + imageProperties1.Width + " * " + imageProperties1.Height;
                    break;
                case 1:
                    file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Mask1.png"));
                    var stream2 = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    m_d2dImageSource.SetMask(stream2);
                    await bitmapImage.SetSourceAsync(stream2);
                    MaskImage.Source = bitmapImage;
                    ImageProperties imageProperties2 = await file.Properties.GetImagePropertiesAsync();
                    MaskImageSize.Text = "Image size: " + imageProperties2.Width + " * " + imageProperties2.Height;
                    break;
                case 2:
                    file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Mask2.png"));
                    var stream3 = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    m_d2dImageSource.SetMask(stream3);
                    await bitmapImage.SetSourceAsync(stream3);
                    MaskImage.Source = bitmapImage;
                    ImageProperties imageProperties3 = await file.Properties.GetImagePropertiesAsync();
                    MaskImageSize.Text = "Image size: " + imageProperties3.Width + " * " + imageProperties3.Height;
                    break;
            }
        }

        private async void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));
        }




    }
}
