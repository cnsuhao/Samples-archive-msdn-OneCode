/**************************** Module Header ********************************\
* Module Name:    UploadPage.xaml.cs
* Project:        CSAzureWPImageUpload
* Copyright (c) Microsoft Corporation
*
* UploadPage.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using CSAzureWPImageUpload.ViewModels;
using Windows.Storage;
using System.IO;
using CSAzureWPImageUpload.DataSource;

namespace CSAzureWPImageUpload
{
    public partial class UploadPage : PhoneApplicationPage
    {

        private BitmapImage chosenBitmapImage;
        private UploadViewModel uploadForm;

        public BitmapImage ChosenBitmapImage
        {
            get { return chosenBitmapImage; }
            set { chosenBitmapImage = value; }
        }
        public UploadViewModel UploadForm
        {
            get { return uploadForm; }
            set { uploadForm = value; }
        }
        
        public UploadPage()
        {
            InitializeComponent();
            chosenBitmapImage = new BitmapImage();

            uploadForm = new UploadViewModel();
            this.DataContext = this.UploadForm;

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += photoChooserTask_Completed;
            photoChooserTask.Show();
        }

        private void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                // Code to display the photo on the page in an image control named myImage.
                System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
                bmp.SetSource(e.ChosenPhoto);

                imgSelected.Source = bmp;
                chosenBitmapImage = bmp;
            }
        }

        private async void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder applicationFolder = ApplicationData.Current.LocalFolder;
            StorageFile storageFile = await applicationFolder.CreateFileAsync(Guid.NewGuid().ToString(), CreationCollisionOption.ReplaceExisting);

            using (Stream stream = await storageFile.OpenStreamForWriteAsync())
            {
                using (MemoryStream mem = new MemoryStream())
                {
                    WriteableBitmap wb = new WriteableBitmap(this.chosenBitmapImage);
                    wb.Invalidate();
                    wb.SaveJpeg(mem, wb.PixelWidth, wb.PixelHeight, 0, 100);
                    mem.Seek(0, System.IO.SeekOrigin.Begin);
                    byte[] content = ReadFully(mem);
                    await stream.WriteAsync(content, 0, content.Length);
                }
            }
            if (storageFile!=null)
            {
                this.UploadForm.PictureFile = storageFile;
            }

            if (this.IsValid(this.UploadForm))
            {
                btnUpload.IsEnabled = false;
                btnSelect.IsEnabled = false;
                await PictureDataSource.UploadPicture(this.UploadForm);
                btnUpload.IsEnabled = true;
                btnSelect.IsEnabled = true;
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        /// <summary>
        /// Stream to byte.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[input.Length];

            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private bool IsValid(UploadViewModel uploadForm)
        {
            if (uploadForm.PictureFile == default(StorageFile))
            {

                MessageBox.Show("Please select a picture before uploading.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(uploadForm.PictureName))
            {
                MessageBox.Show("Please provide a picture title.");
                return false;
            }
            return true;
        }    
    }
}