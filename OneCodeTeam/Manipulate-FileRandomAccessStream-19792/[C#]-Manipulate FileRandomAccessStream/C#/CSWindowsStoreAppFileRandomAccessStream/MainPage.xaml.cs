/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSWindowsStoreAppFileRandomAccessStream
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to manipulate file with FileRandomAccessStream.
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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Windows.UI;
using Windows.UI.Xaml.Media;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppFileRandomAccessStream
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppFileRandomAccessStream.Common.LayoutAwarePage
    {

        string sampleData = "The Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' needs. Our goal is to provide typical code samples for all Microsoft development technologies, and reduce developers' efforts in solving typical programming tasks. Our team listens to developers' pains in MSDN forums, social media and various developer communities. We write code samples based on developers' frequently asked programming tasks, and allow developers to download them with a short code sample publishing cycle. Additionally, our team offers a free code sample request service. This service is a proactive way for our developer community to obtain code samples for certain programming tasks directly from Microsoft.";
        
        ulong streamSize;

        StorageFolder folder = KnownFolders.DocumentsLibrary;

        public MainPage()
        {
            this.InitializeComponent();
        }


        #region Create a file in Documents folder
        /// <summary>
        /// Create a file in Documents folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StorageFile file = await folder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);
                var buffer = CryptographicBuffer.ConvertStringToBinary(sampleData, BinaryStringEncoding.Utf8);
                using (FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await stream.WriteAsync(buffer);
                    streamSize = stream.Size;
                }
                await LoadFileContent();
                svContent.Visibility = Visibility.Visible;
                btnSave.Visibility = Visibility.Visible;
                btnAppend.IsEnabled = true;
                txtInsertData.IsEnabled = true;
                txtPosition.IsEnabled = true;
                tbHint.Text = "(0-" + streamSize + ")"; 
                tbOutput.Text = "Creating 'sample.txt' file in Documents folder successully! ";
            }
            catch (Exception ex)
            {
                NotifyUser(ex.ToString());
            }
        }
        #endregion

        #region Save the file
        /// <summary>
        /// Save the file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbContent.Text))
            {
                try
                {
                    StorageFile file = await folder.GetFileAsync("sample.txt");
                    var buffer = CryptographicBuffer.ConvertStringToBinary(tbContent.Text, BinaryStringEncoding.Utf8);
                    using (FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        await stream.WriteAsync(buffer);
                        streamSize = stream.Size;
                    }
                    tbOutput.Text = "Saving file successully!";
                    tbHint.Foreground = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Black);
                    tbHint.Text = "(0-" + streamSize + ")";
                }
                catch (Exception ex)
                {
                    NotifyUser(ex.ToString());
                }
            }
            else
            {
                NotifyUser("The content is empty!");
            }

        }
        #endregion

        #region Insert data to specific position of the file
        /// <summary>
        /// Insert data to specific position of the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (DataValidation())
            {
                tbHint.Foreground = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Black);
                ulong position = Convert.ToUInt64(txtPosition.Text);
                string insertData = txtInsertData.Text;

                try
                {
                    StorageFile file = await folder.GetFileAsync("sample.txt");
                    using (FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        string remainData = tbContent.Text.Substring((int)position);
                        var buffer = CryptographicBuffer.ConvertStringToBinary(insertData + remainData, BinaryStringEncoding.Utf8);
                        stream.Seek(position);
                        await stream.WriteAsync(buffer);
                        streamSize = stream.Size;
                    }

                    await LoadFileContent();
                    svContent.ScrollToVerticalOffset(svContent.ExtentHeight);
                    svContent.Visibility = Visibility.Visible;
                    btnSave.Visibility = Visibility.Visible;
                    tbOutput.Text = "Inserting content successully!";
                    tbHint.Text = "(0-" + streamSize + ")";

                }
                catch (Exception ex)
                {
                    NotifyUser(ex.ToString());
                }
            }
            else 
            {
                tbOutput.Text = "Failed to insert data.";
            }
        }

        #endregion

        #region Load content from the file
        /// <summary>
        /// Load content from the file
        /// </summary>
        /// <returns></returns>
        private async Task LoadFileContent()
        {
            try
            {
                StorageFile file = await folder.GetFileAsync("sample.txt");
                using (FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.ReadWrite))
                {

                    var inputStream = stream.GetInputStreamAt(0);
                    using (DataReader reader = new DataReader(inputStream))
                    {
                        uint size = await reader.LoadAsync((uint)stream.Size);
                        tbContent.Text = reader.ReadString(size);
                    }
                }
            }
            catch (Exception ex)
            {
                NotifyUser(ex.ToString());
            }
        }
        #endregion

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


        private bool DataValidation()
        {
            bool bValid = true;
            string data = txtInsertData.Text;
            string position =txtPosition.Text;
            Regex reg = new Regex("^[0-9]*$");

            if (string.IsNullOrEmpty(data) || string.IsNullOrEmpty(position))
            {
                bValid = false;
                tbHint.Text = "complete input.";
                tbHint.Foreground = new SolidColorBrush(Colors.Red);
                tbHint.Visibility = Visibility.Visible;
            }
            else if (!reg.IsMatch(position) || Convert.ToUInt64(position) > streamSize)
            {
                bValid = false;
                tbHint.Text = "Valid range:(0-" + streamSize + ")";
                tbHint.Foreground = new SolidColorBrush(Colors.Red);
                tbHint.Visibility = Visibility.Visible;
            }
           
            return bValid;
        }
    }
}
