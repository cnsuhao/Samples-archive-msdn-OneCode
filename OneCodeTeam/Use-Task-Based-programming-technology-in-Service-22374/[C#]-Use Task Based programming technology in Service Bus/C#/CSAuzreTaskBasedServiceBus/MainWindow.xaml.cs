/***************************** Module Header ******************************\
* Module Name:	MainWindow.xaml.cs
* Project:		CSAuzreTaskBasedServiceBus
* Copyright (c) Microsoft Corporation.
* 
* This sample shows the new feature in Windows Azure Service Bus Client SDK 2.0.
* The SDK APIs have been improved to offer System.Threading.Tasks.Task based versions 
* of all asynchronous APIs. 
* This means that you can write asynchronous code that mere mortals can read.
*
* MainWindow.xaml.cs
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/

using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace CSAuzreTaskBasedServiceBus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initializeControls();
        }

        /// <summary>
        /// Initialize all controls which need to get data from service bus.
        /// </summary>
        public async void initializeControls()
        {
            cbxChooseRetrieveMessageQueue.IsEnabled = false;
            cbxChooseSendMessageQueue.IsEnabled = false;
            NamespaceManager manager = NamespaceManager.Create();
            List<string> queueNameList = new List<string>();
            var Queues = await manager.GetQueuesAsync();
            lstQueues.Items.Clear();
            foreach (var queue in Queues)
            {
                queueNameList.Add(queue.Path);
                lstQueues.Items.Add(string.Format("{0}\t\t\tlength={1}", queue.Path, queue.MessageCount));
            }
            cbxChooseSendMessageQueue.ItemsSource = queueNameList;
            cbxChooseRetrieveMessageQueue.ItemsSource = queueNameList;
            cbxChooseSendMessageQueue.IsEnabled = true;
            cbxChooseRetrieveMessageQueue.IsEnabled = true;

        }
        /// <summary>
        /// Create new service bus queue use Async method.
        /// </summary>
        private async void btnCreateNewQueue_Click(object sender, RoutedEventArgs e)
        {
            btnCreateNewQueue.IsEnabled = false;
            NamespaceManager manager = NamespaceManager.Create();
            if (txtCreateQueue.Text != "" && (!await (manager.QueueExistsAsync(txtCreateQueue.Text))))
            {
                await manager.CreateQueueAsync(txtCreateQueue.Text);
            }
            initializeControls();
            btnCreateNewQueue.IsEnabled = true;
            txtCreateQueue.Text = null;
        }

        /// <summary>
        /// Send message to service bus queue use Async method.
        /// </summary>
        private async void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            btnSendMessage.IsEnabled = false;
            QueueClient client = QueueClient.Create(cbxChooseSendMessageQueue.SelectedValue.ToString());
            if (txtSendMessage.Text != null)
            {

                await client.SendAsync(new BrokeredMessage(txtSendMessage.Text));


                initializeControls();
            }
            btnSendMessage.IsEnabled = true;
        }

        /// <summary>
        /// Retrieve service bus message use Async method.
        /// </summary>
        private async void btnRetrieveMessage_Click(object sender, RoutedEventArgs e)
        {
            btnRetrieveMessage.IsEnabled = false;
            QueueClient client = QueueClient.Create(cbxChooseRetrieveMessageQueue.SelectedValue.ToString(), 
                ReceiveMode.ReceiveAndDelete);

            BrokeredMessage receivedMessage = await client.ReceiveAsync();
            if (receivedMessage != null)
            {
                txtDetails.Text = string.Format("Message Content:\n{0}\n\n", receivedMessage.GetBody<string>());
                txtDetails.Text += ("BrokeredMessage Properties\n" +
                    string.Format("Size\t{0}\n", receivedMessage.Size) +
                    string.Format("MessageId\t{0}\n", receivedMessage.MessageId) +
                    string.Format("TimeToLive\t{0}\n", receivedMessage.TimeToLive) +
                    string.Format("EnqueuedTimeUtc\t{0}\n", receivedMessage.EnqueuedTimeUtc) +
                    string.Format("ExpiresAtUtc\t{0}\n", receivedMessage.ExpiresAtUtc));

            }
            initializeControls();
            btnRetrieveMessage.IsEnabled = true;
        }
    }
}
