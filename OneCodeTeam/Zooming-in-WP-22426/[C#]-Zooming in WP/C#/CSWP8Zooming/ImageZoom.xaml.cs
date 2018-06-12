/****************************** Module Header ******************************\
* Module Name:    ImageZoom.xaml.cs
* Project:        CSWP8Zooming
* Copyright (c) Microsoft Corporation
*
* This demo shows how to zoom in/out image and video.
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
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace CSWP8Zooming
{
    public partial class ImageZoom : PhoneApplicationPage
    {
        int initHight = 0;                    // Initial high.
        int initWidth = 0;                    // Initial width.
        double maxHight = 0;                  // Max hight.
        double maxWidth = 0;                  // Max width.
        int changeHight = 0;                  // The amount of the increase or decrease of the high.
        int changeWidth = 0;                  // The amount of the increase or decrease of the width.
        string strPath = "1code.jpg";         // Image path.
        string strImageName = "test.jpg";     // Image name.
        bool isLoad = false;                  // Flag for initialization. 

        // Constructor
        public ImageZoom()
        {
            InitializeComponent();

            // Save image to isolated storage. You can capture an image from camera instead of local image.
            SaveImageToIsolatedStorage(initWidth, initHight);

            // Load image and rendering.
            LoadImageFromIsolatedStorage(0, 0);

            // Prevent repeat initialized.
            if (!isLoad)
            {
                maxWidth = img.Width;
                maxHight = img.Height;
                changeHight = Convert.ToInt32(((maxHight - initHight) / 20));
                changeWidth = Convert.ToInt32((maxWidth - initWidth) / 20);
                isLoad = true;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Save image to IsolatedStorage.
        /// </summary>     
        private void SaveImageToIsolatedStorage(int intPixelWidth, int intPixelHeight)
        {
            // Use Uri to get local images.
            StreamResourceInfo sri = null;
            Uri uri = new Uri(strPath, UriKind.Relative);
            sri = Application.GetResourceStream(uri);

            using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (iso.FileExists(strImageName))
                {
                    iso.DeleteFile(strImageName);
                }

                using (IsolatedStorageFileStream isostream = iso.CreateFile(strImageName))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.SetSource(sri.Stream);
                    WriteableBitmap wb = new WriteableBitmap(bitmap);

                    if (intPixelHeight > 0)
                    {
                        // Encode WriteableBitmap object to a JPEG stream.
                        Extensions.SaveJpeg(wb, isostream, intPixelWidth, intPixelHeight, 0, 85);
                    }
                    else
                    {
                        // Encode WriteableBitmap object to a JPEG stream.
                        Extensions.SaveJpeg(wb, isostream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                    }
                }
            }
        }

        /// <summary>
        /// Sample code for loading image from IsolatedStorage
        /// </summary> 
        private void LoadImageFromIsolatedStorage(int intPixelWidth, int intPixelHeight)
        {
            // The image will be read from isolated storage into the following byte array
            byte[] data;

            // Read the entire image in one go into a byte array
            try
            {
                using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream isfs = isf.OpenFile(strImageName, FileMode.Open, FileAccess.Read))
                    {
                        // Allocate an array large enough for the entire file
                        data = new byte[isfs.Length];

                        // Read the entire file and then close it
                        isfs.Read(data, 0, data.Length);
                    }
                }

                // Create memory stream and bitmap
                MemoryStream ms = new MemoryStream(data);
                BitmapImage bi = new BitmapImage();

                // Set bitmap source to memory stream
                bi.SetSource(ms);

                // Note: You must remove previous picture.
                LayoutRoot.Children.Remove(img);
                img = new Image();

                // Set size of image to bitmap size for this demonstration
                if (intPixelHeight > 0)
                {
                    img.Height = intPixelHeight;
                    img.Width = intPixelWidth;
                }
                else
                {
                    img.Height = bi.PixelHeight;
                    img.Width = bi.PixelWidth;
                }

                img.Source = bi;
                LayoutRoot.Children.Add(img);
            }
            catch (Exception e)
            {
                // handle the exception
                Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Zoom in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (img.Width <= maxWidth && img.Height <= maxHight)
            {
                int width = GetInt(img.Width);   // Current width.
                int hight = GetInt(img.Height);  // Current hight.
                SaveImageToIsolatedStorage(width += changeWidth, hight += changeHight);
                LoadImageFromIsolatedStorage(width += changeWidth, hight += changeHight);
            }
        }

        /// <summary>
        /// Zoom out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (img.Width > changeWidth && img.Height > changeHight)
            {
                int width = GetInt(img.Width);   // Current width.
                int hight = GetInt(img.Height);  // Current hight.
                SaveImageToIsolatedStorage(width -= changeWidth, hight -= changeHight);
                LoadImageFromIsolatedStorage(width -= changeWidth, hight -= changeHight);
            }
        }

        /// <summary>
        /// Convert method
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int GetInt(double p)
        {
            return Convert.ToInt32(p);
        }
    }
}