/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSUniversalAppOpacityMask.WindowsPhone
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
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using D2DImageSourceWithOpacityMask;
using CSUniversalAppOpacityMask.Common;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CSUniversalAppOpacityMask
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IFileOpenPickerContinuable
    {
        // An image source derived from SurfaceImageSource, used to draw DirectX content
        private D2DImageSource m_d2dImageSource;
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

            this.Loaded += MainPage_Loaded;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            _btnRender.IsEnabled = false;

            this.NavigationCacheMode = NavigationCacheMode.Required;

            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            e.PageState["ImageStream"] = m_stream;
        }

        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {      
            if(e.PageState != null)
            {
                m_stream = e.PageState["ImageStream"] as Windows.Storage.Streams.IRandomAccessStream;
            }
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            m_d2dImageSource = new D2DImageSource(
                (int)(contentGrid.ActualWidth),
                (int)(contentGrid.ActualHeight), false);        
        }

        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (this.Frame.CurrentSourcePageType == typeof(MainPage))
            {
                this.Frame.BackStack.Clear();
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);            
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        private void OpenImageBtn_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.PickSingleFileAndContinue();
        }

        private Windows.Storage.Streams.IRandomAccessStream m_stream;
        public async void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
        {
            IReadOnlyList<StorageFile> files = args.Files;
            if (files.Count > 0)
            {
                m_stream = await files[0].OpenAsync(Windows.Storage.FileAccessMode.Read);

                var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                await bitmapImage.SetSourceAsync(m_stream);
                OrignalImage.Source = bitmapImage;

                _btnRender.IsEnabled = true;                
            }
        }

        private void _btnRender_Click(object sender, RoutedEventArgs e)
        {
            m_d2dImageSource.SetSource(m_stream);

            // Begin updating the SurfaceImageSource
            m_d2dImageSource.BeginDraw();

            // Clear background
            m_d2dImageSource.Clear(Windows.UI.Colors.Transparent);

            // Render the source and apply the mask
            m_d2dImageSource.RenderBitmap();

            // Stop updating the SurfaceImageSource and draw its contents
            m_d2dImageSource.EndDraw();

            this.Frame.Navigate(typeof(ImagePage), m_d2dImageSource);
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
                    
                    break;
                case 1:
                    file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Mask1.png"));
                    var stream2 = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    m_d2dImageSource.SetMask(stream2);
                    await bitmapImage.SetSourceAsync(stream2);
                    MaskImage.Source = bitmapImage;
                    break;
                case 2:
                    file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Mask2.png"));
                    var stream3 = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    m_d2dImageSource.SetMask(stream3);
                    await bitmapImage.SetSourceAsync(stream3);
                    MaskImage.Source = bitmapImage;
                    break;
            }
        }

        private async void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));
        }
    }
}
