/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      ClientApp
 * Copyright (c) Microsoft Corporation.
 * 
 * This is the Main Page of the app.
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
using System.Reflection;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media.Imaging;
using WatermarkComponent;
using System.Threading.Tasks;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ClientApp
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : ClientApp.Common.LayoutAwarePage
    {
        D2DWrapper d2dWrapper;
        IRandomAccessStream backgroundImageStream;
        IRandomAccessStream watermarkImageStream;
        IRandomAccessStream currentImageStream; 
        IRandomAccessStream previousImageStream; // For undo purpose.
        Color fontColor;
        int backgroundImagePixelWidth;
        int backgroundImagePixelHeight;

        StartPointCalculator startPointCalculator;

        public MainPage()
        {
            this.InitializeComponent();

            // New a D2DWrapper instance.
            d2dWrapper = new D2DWrapper();

            // Initialize D2DWrapper.
            d2dWrapper.Initialize();

            // Set up datasource for comboboxes.
            SetupComboboxDataSource();

            startPointCalculator = new StartPointCalculator();

            // Set up the DataContext.
            this.DataContext = startPointCalculator;
        }

        private void SetupComboboxDataSource()
        {
            // Set data source for font family combobox
            this.FontFamilyComBox.ItemsSource = d2dWrapper.GetSystemFont().OrderBy(x=>x).ToArray();
            this.FontFamilyComBox.SelectedIndex = 0;

            // Set data source for font size combobox
            for (int fontSize = 10; fontSize <= 72; ++fontSize)
            {
                this.FontSizeComBox.Items.Add(fontSize);
            }
            this.FontSizeComBox.SelectedIndex = 0;

            // Set data source for font weight combobox
            this.FontWeightComBox.ItemsSource = Enum.GetValues(typeof(WatermarkComponent.FONT_WEIGHT_ENUM)).Cast<WatermarkComponent.FONT_WEIGHT_ENUM>();
            this.FontWeightComBox.SelectedIndex = 0;

            // Set data source for font color combobox
            var colors = typeof(Colors).GetTypeInfo().DeclaredProperties;
            foreach (var item in colors)
            {
                this.FontColorComBox.Items.Add(item);
            }
            this.FontColorComBox.SelectedIndex = 0;

            // Set data source font style combobox
            this.FontStyleComBox.ItemsSource = Enum.GetValues(typeof(WatermarkComponent.FONT_STYLE_ENUM)).Cast<WatermarkComponent.FONT_STYLE_ENUM>();
            this.FontStyleComBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        async private void LoadBackgroundImage_Click(object sender, RoutedEventArgs e)
        {
            // Clear status text.
            this.NotifyUser("");

            StorageFile imgFile = await LoadImage();

            if (imgFile != null)
            {
                try
                {
                    if (backgroundImageStream != null)
                    {
                        backgroundImageStream.Dispose();
                        backgroundImageStream = null;
                    }

                    // Disable the Undo button.
                    this.UndoButton.IsEnabled = false;

                    // Ensure the stream is disposed once the image is loaded
                    using (IRandomAccessStream fileStream = await imgFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
                    {
                        // Update the background image.
                        backgroundImageStream = fileStream.CloneStream();
                        BitmapImage bitmapImage = new BitmapImage();
                        await bitmapImage.SetSourceAsync(fileStream);
                        this.BackgroundImage.Source = bitmapImage;

                        // Update the preview image.
                        fileStream.Seek(0);
                        BitmapImage previewImage = new BitmapImage();
                        await previewImage.SetSourceAsync(fileStream);
                        this.PreviewImage.Source = previewImage;

                        backgroundImagePixelHeight = bitmapImage.PixelHeight;
                        backgroundImagePixelWidth = bitmapImage.PixelWidth;

                        // Set bitmap render target.
                        d2dWrapper.SetBitmapRenderTarget(backgroundImageStream);

                        if (currentImageStream != null)
                        {
                            currentImageStream.Dispose();
                            currentImageStream = null;
                        }
                        currentImageStream = backgroundImageStream;
                    }
                }
                catch(Exception ex)
                {
                    this.NotifyUser(ex.Message);
                    return;
                }

                // Enable the sliders
                this.OffsetXSlider.IsEnabled = true;
                this.OffsetYSlider.IsEnabled = true;

                this.SaveToFileButton.IsEnabled = true;

                startPointCalculator.OffsetXInPercent = this.OffsetXSlider.Value;
                startPointCalculator.OffsetYInPercent = this.OffsetYSlider.Value;

                this.startPointIndicator.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        async private void LoadwatermarkImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear status text.
            this.NotifyUser("");

            if (backgroundImageStream != null)
            {
                if (watermarkImageStream != null)
                {
                    watermarkImageStream.Dispose();
                    watermarkImageStream = null;
                }

                StorageFile imgFile = await LoadImage();
                if (imgFile != null)
                {
                    using (IRandomAccessStream fileStream = await imgFile.OpenAsync(FileAccessMode.Read))
                    {
                        watermarkImageStream = fileStream.CloneStream();
                        BitmapImage watermarkImage = new BitmapImage();
                        await watermarkImage.SetSourceAsync(fileStream);
                        this.watermarkImage.Source = watermarkImage;

                        if (watermarkImage.PixelWidth > backgroundImagePixelWidth || 
                            watermarkImage.PixelHeight > backgroundImagePixelHeight)
                        {
                            this.NotifyUser("The watermark image is too big, please choose a smaller one.");
                            this.AddwatermarkImageButton.IsEnabled = false;
                        }
                        else
                        {
                            this.AddwatermarkImageButton.IsEnabled = true;
                        }
                    }
                }
            }
            else
            {
                this.NotifyUser("Please load background image first.");
            }
        }

        async private void AddTextButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear status text.
            this.NotifyUser("");

            try
            {
                if (backgroundImageStream != null)
                {
                    if (previousImageStream != null)
                    {
                        previousImageStream.Dispose();
                        previousImageStream = null;
                    }

                    // Cache the stream for Undo purpose.
                    previousImageStream = currentImageStream;
                    this.UndoButton.IsEnabled = true;

                    Point startPoint = new Point(this.OffsetXSlider.Value, this.OffsetYSlider.Value);
                    Color textColor = Color.FromArgb((byte)(this.FontOpacitySlider.Value * 255), fontColor.R, fontColor.G,
                        fontColor.B);
                    uint fontSize = Convert.ToUInt32(this.FontSizeComBox.SelectedValue);

                    FONT_STYLE_ENUM fontStyle = (FONT_STYLE_ENUM)Enum.Parse(typeof(FONT_STYLE_ENUM),
                        FontStyleComBox.SelectedValue.ToString());

                    FONT_WEIGHT_ENUM fontWeight = (FONT_WEIGHT_ENUM)Enum.Parse(typeof(FONT_WEIGHT_ENUM),
                        this.FontWeightComBox.SelectedValue.ToString());

                    // BeginDraw
                    d2dWrapper.BeginDraw();

                    // Draw text
                    d2dWrapper.DrawText(this.inputText.Text, startPoint, this.FontFamilyComBox.SelectedValue.ToString(),
                        textColor, fontSize, fontStyle, fontWeight, string.Empty);

                    // EndDraw
                    currentImageStream = d2dWrapper.EndDraw(true);
                    currentImageStream.Seek(0);

                    // Update the preview image.
                    BitmapImage bi = new BitmapImage();
                    await bi.SetSourceAsync(currentImageStream);
                    this.PreviewImage.Source = bi;
                }
                else
                {
                    this.NotifyUser("Can't add text watermark. Please make sure you have loaded background image.");
                }
            }
            catch (Exception ex)
            {
                this.NotifyUser(ex.Message);
            }
        }

        async private void AddwatermarkImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear status text.
            this.NotifyUser("");

            try
            {
                if (backgroundImageStream != null && watermarkImageStream != null)
                {
                    if (previousImageStream != null)
                    {
                        previousImageStream.Dispose();
                        previousImageStream = null;
                    }

                    // Cache the stream for Undo purpose.
                    previousImageStream = currentImageStream;
                    this.UndoButton.IsEnabled = true;

                    Point startPoint = new Point(this.OffsetXSlider.Value, this.OffsetYSlider.Value);

                    // BeginDraw
                    d2dWrapper.BeginDraw();

                    // Draw image
                    d2dWrapper.DrawImage(watermarkImageStream, startPoint, (float)this.watermarkImageOpacitySlider.Value);

                    // EndDraw
                    currentImageStream = d2dWrapper.EndDraw(true);
                    currentImageStream.Seek(0);

                    BitmapImage bi = new BitmapImage();
                    await bi.SetSourceAsync(currentImageStream);
                    this.PreviewImage.Source = bi;
                }
                else
                {
                    this.NotifyUser("Can't add watermark image. Please make sure you have loaded background image and watermark image.");
                }
            }
            catch (Exception ex)
            {
                this.NotifyUser(ex.Message);
            }

        }

        private void SaveToFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear status text.
            this.NotifyUser("");

            if (backgroundImageStream != null)
            {
                d2dWrapper.SaveBitmapToFile();
            }
            else
            {
                this.NotifyUser("There is no background image...");
            }
        }

        // Load Image file
        async private Task<StorageFile> LoadImage()
        {
            // Clear status text.
            this.NotifyUser("");

            StorageFile imgFile = null;
            bool unsnapped = ((ApplicationView.Value != ApplicationViewState.Snapped) || ApplicationView.TryUnsnap());
            if (!unsnapped)
            {
                NotifyUser("Cannot unsnap the app.");
                return null;
            }

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".bmp");
            openPicker.FileTypeFilter.Add(".png");
            imgFile = await openPicker.PickSingleFileAsync();

            return imgFile;
        }

        private void FontColorComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.FontColorComBox.SelectedIndex != -1)
            {
                var pi = this.FontColorComBox.SelectedItem as PropertyInfo;
                fontColor = (Color)pi.GetValue(null);
            }
        }

        private void inputText_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                if (!String.IsNullOrWhiteSpace(tb.Text))
                {
                    this.AddTextButton.IsEnabled = true;
                }
                else
                {
                    this.AddTextButton.IsEnabled = false;
                }
            }
        }

        // If the size of the background image container has been changed, we should recalculate the start point indicator.
        private void BackgroundGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            startPointCalculator.ImageContainerActualHeight = e.NewSize.Height; ;
            startPointCalculator.ImageContainerActualWidth = e.NewSize.Width;
        }

        // If the size of the background image has been changed, we should recalculate the start point indicator.
        private void BackgroundImage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            startPointCalculator.BackgroundImageActualHeight = e.NewSize.Height;
            startPointCalculator.BackgroundImageActualWidth = e.NewSize.Width;
        }

        // In this sample, we just support undo the last operation.
        async private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentImageStream != null)
            {
                currentImageStream.Dispose();
                currentImageStream = null;
            }

            // Update currentImageStream.
            currentImageStream = previousImageStream;
            currentImageStream.Seek(0);

            this.d2dWrapper.SetBitmapRenderTarget(currentImageStream);
            this.UndoButton.IsEnabled = false;

            // NOTE: We should set the position of the stream to 0 again.
            currentImageStream.Seek(0);

            // Update the preview image.
            BitmapImage bi = new BitmapImage();
            await bi.SetSourceAsync(currentImageStream);
            this.PreviewImage.Source = bi;

            // Set previousImageStream as null.
            previousImageStream = null;
        }

        async private void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));
        }

        public void NotifyUser(string message)
        {
            this.statusText.Text = message;
        }
    }
}
