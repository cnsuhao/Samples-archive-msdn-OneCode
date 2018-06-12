/****************************** Module Header ******************************\
 * Module Name:  MainPage.xaml.cs
 * Project:      CSWindowsStoreAppFileConcurrency
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample demonstrates how to deal with file access concurrency when save app data
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
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CSWindowsStoreAppFileConcurrency
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : CSWindowsStoreAppFileConcurrency.Common.LayoutAwarePage
    {

        string filename = "test.txt";

        public MainPage()
        {
            this.InitializeComponent();
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

        /// <summary>
        /// When writting data to the file, the 'Save' button is not enabled, this is to prevent reentrancy.
        /// Before saving data, we have 3 sceconds delay, this is easy to see the currency control, only one
        /// thread can access the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SemaphoreSlim semaphore = getSemaphore(filename);
            await semaphore.WaitAsync();
            try
            {
                var storageFolder = KnownFolders.DocumentsLibrary;
                StorageFile file = await storageFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                string content = dataTextBox.Text;
                if (!string.IsNullOrEmpty(content))
                {
                    saveButton.IsEnabled = false;
                    await Task.Delay(TimeSpan.FromSeconds(3)); 
                    await FileIO.WriteTextAsync(file, content);                    
                }
                saveButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                NotifyUser(ex.ToString());
            }
            finally
            {
                semaphore.Release();
            }
        }

        private async void loadButton_Click(object sender, RoutedEventArgs e)
        {
            SemaphoreSlim semaphore = getSemaphore(filename);
            await semaphore.WaitAsync();
            try
            {
                var storageFolder = KnownFolders.DocumentsLibrary;
                StorageFile file = await storageFolder.GetFileAsync(filename);
                string content = await FileIO.ReadTextAsync(file);
                if (!string.IsNullOrEmpty(content))
                {
                    dataTextBlock.Text = content;         
                }
            }
            catch (Exception ex)
            {
                NotifyUser(ex.ToString());
            }
            finally
            {
                semaphore.Release();
            }
        }

        // A Dictionary to store SemaphoreSlim instances
        private static readonly Dictionary<string, SemaphoreSlim> semaphores = new Dictionary<string, SemaphoreSlim>();

        /// <summary>
        /// Get a SemaphoreSlim instance. If the instance is already exist, return the exist one, otherwise, create a new
        /// instance and return it.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static SemaphoreSlim getSemaphore(string filename)
        {
            if (semaphores.ContainsKey(filename))
                return semaphores[filename];

            var semaphore = new SemaphoreSlim(1);
            semaphores[filename] = semaphore;
            return semaphore;
        }

        private void dataTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataInputScrollViewer.ScrollToVerticalOffset(dataInputScrollViewer.ExtentHeight);
        }
    }
}
