/***************************** Module Header ******************************\
* Module Name:	MainWindow.xaml.cs
* Project:		CSAzureMobileServiceWithTableStorage
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to use table storage with windows Azure mobile service.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/


using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Runtime.Serialization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace CSAzureMobileServiceWithTableStorage
{
    #region Entity Class
    /// <summary>
    /// This class name should equal to the table name you created on Azure mobile service.
    /// </summary>
    public class ShortMessage
    {
        public long Id { get; set; }

        [DataMember(Name = "PartitionKey")]
        public string PartitionKey { get; set; }

        [DataMember(Name = "RowKey")]
        public string RowKey { get; set; }

        [DataMember(Name = "Timestamp")]
        public DateTime Timestamp { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Message")]
        public string Message { get; set; }

        [DataMember(Name = "IsRead")]
        public bool IsRead { get; set; }
    }
    #endregion

    public sealed partial class MainPage : Page
    {
        private readonly IMobileServiceTable<ShortMessage> shortMessageTable = App.MobileService.GetTable<ShortMessage>();
        private MobileServiceCollectionView<ShortMessage> ShortMessageView;
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
            RefreshListView();
        }

        #region Event

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != "" && tbMessage.Text != "")
            {
                var message = new ShortMessage();
                message.Name = tbName.Text;
                message.Message = tbMessage.Text;
                InsertNewMessage(message);  
            }
            else
            {
                lbState.Text = "Name Or Message shouldn't be empty";
            }
            
        }

        private  void appbtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var message = lvwNewMessages.SelectedItem as ShortMessage;
            if (message!=null)
            {
               DeleteNewMessage(message);
            }
            
        }

        private void appbtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var message = lvwNewMessages.SelectedItem as ShortMessage;
            if (message != null)
            {
                UpdateNewMessage(message);
               
            }
            
        }
        #endregion

        #region Method

        /// <summary>
        /// Get New message by RefreshListView() token
        /// </summary>
        private void RefreshListView()
        {   
            ShortMessageView = shortMessageTable.ToCollectionView();

            lvwNewMessages.ItemsSource = ShortMessageView;
        }
       

        /// <summary>
        /// Insert the message into a table storage.
        /// </summary
        private async void InsertNewMessage(ShortMessage message)
        {
            try
            {
                await shortMessageTable.InsertAsync(message);
                lbState.Text = "New message has been left";
                tbMessage.Text = "";
                tbName.Text = "";
                ShortMessageView.Add(message);   
            }
            catch (Exception)
            {
                lbState.Text = "There is something error when leaving message, please try it again.";
            }                         
        }

        /// <summary>
        /// Delete the selected message. 
        /// </summary>
        private async void DeleteNewMessage(ShortMessage message)
        {
            try
            {
                message.Id = long.Parse(message.RowKey);
                await shortMessageTable.DeleteAsync(message);
               
                ShortMessageView.Remove(message);
                lbState.Text = "This item has been deleted.";
            }
            catch (Exception ex)
            {
                lbState.Text = ex.Message;
            }
        }

        /// <summary>
        /// Update the selected message, mark it as read.
        /// </summary>
        private async void UpdateNewMessage(ShortMessage message)
        {
            
            message.Id = long.Parse(message.RowKey);
            message.IsRead = true;
            try
            {
                await shortMessageTable.UpdateAsync(message);

                ShortMessageView.Remove(message);
                lbState.Text = "Select item has been marked as read";
            }     
            catch(Exception ex)
            {
                lbState.Text = ex.Message;
            }
        }
        #endregion
    }
}
