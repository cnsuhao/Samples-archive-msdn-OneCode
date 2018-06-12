/***************************** Module Header ******************************\
* Module Name:	MainWindow.xaml.cs
* Project:		CSAzureTableStorageClassLibaryWithStoreApp
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to use latest Azure Storage SDK with Windows Store app.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/

using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CSAzureTableStorageClassLibaryWithStoreApp
{
    public class TodoItem:TableEntity
    {
        [DataMember(Name="Message")]
        public string Message{get;set;}

        [DataMember(Name="IsComplete")]
        public bool IsComplete { get; set; }

    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<TodoItem> todoItemList = new List<TodoItem>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Get the latest query results.
        /// </summary>
        private async void UpdateListView()
        {          
            await App.table.CreateIfNotExistsAsync();
            TableContinuationToken continuationToken=null;

            TableQuery<TodoItem> query = new TableQuery<TodoItem>().
                Where(TableQuery.GenerateFilterConditionForBool("IsComplete", QueryComparisons.Equal, false));

            var todoItemList = await App.table.ExecuteQuerySegmentedAsync(query, continuationToken);
            lvwTodoItems.ItemsSource = todoItemList;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            UpdateListView();
        }

        /// <summary>
        /// Save the a new todo item to Azure table storage.
        /// </summary>
        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var item = new TodoItem()
            {
                PartitionKey = "default",
                RowKey = DateTime.Now.ToString("yyyyMMddHHmmss"),
                IsComplete = false,
                Message = tbMessage.Text
            };

            try
            {
                TableOperation insertOperation = TableOperation.Insert(item);
                await App.table.ExecuteAsync(insertOperation);

                lbState.Text += DateTime.Now.ToString()+ ": Save message successfully!\n";
                todoItemList.Add(item);
  
                UpdateListView();
            }
            catch (Exception ex)
            {
                lbState.Text += ex.Message;
            }

        }

        /// <summary>
        /// Delete a new item in new table storage.
        /// </summary>
        /// <param name="sender"></param>
        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvwTodoItems.SelectedIndex != -1)
            {
                var item = lvwTodoItems.SelectedItem as TodoItem;
                try
                {
                    TableOperation deleteOperation = TableOperation.Delete(item);
                    await App.table.ExecuteAsync(deleteOperation);

                    lbState.Text += DateTime.Now.ToString() + ": Delete message successfully!\n";
                    todoItemList.Remove(item);

                    UpdateListView();
                }
                catch (Exception ex)
                {
                    lbState.Text += ex.Message;
                }
            }
        }

        /// <summary>
        /// Change the complete filed in table storage to true, and this item won't list in
        /// listview. 
        /// </summary>
        private async void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            if (lvwTodoItems.SelectedIndex!=-1)
            {
                var item = lvwTodoItems.SelectedItem as TodoItem;
                item.IsComplete = true;

                try
                {
                    item.IsComplete = true;
                    await App.table.ExecuteAsync(TableOperation.Merge(item));

                    lbState.Text += string.Format("{0}: {1} is complete!\n", DateTime.Now.ToString(), item.Message);
                    todoItemList.Remove(item);

                    UpdateListView();

                }
                catch (Exception ex)
                {
                    lbState.Text += ex.Message;
                }
            }           
        }  
    }
}
