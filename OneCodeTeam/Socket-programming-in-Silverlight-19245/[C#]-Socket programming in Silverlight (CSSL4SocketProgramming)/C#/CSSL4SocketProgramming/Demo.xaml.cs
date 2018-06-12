/****************************** Module Header ******************************\
* Module Name: Demo.xaml.cs
* Project:     CSSL4SocketProgramming
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to use Socket achieve MultiCast function
* in Silverlight. We demonstrate ISM and SSM in this sample, The 
* application includes a console application as server side and a 
* Silverlight application as client side, the server will broadcast
* messages to client sides and client sides can also send messages 
* to other users.
*
* This page use to send and receive messages from server application.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace CSSL4SocketProgramming
{
    public partial class Demo : Page
    {
        // Define two UDP channels for sending and receiving the message from server or other clients.
        private UdpSingleSourceMulticastChannel udpSSMChannel;
        private UdpAnySourceMulticastChannel udpISMChannel;
        private bool isPause = false;
        public Demo()
        {
            // Initialize the UDP channel with resource files, There you can add 
            // user-defined event for connect server, send or receive message.
            InitializeComponent();

            // SSM(UdpSingleSourceMulticast) channel.
            udpSSMChannel = new UdpSingleSourceMulticastChannel(IPAddress.Parse(IPConfig.YourIP), IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.SSMLocalPort), 2048);
            udpSSMChannel.AfterOpen += new EventHandler(AfterOpeningSSMEvent);
            udpSSMChannel.BeforeReceived += new EventHandler<UdpConvertMessageEvent>(BeforeReceivedSSMEvent);
            udpSSMChannel.BeforeCloseSSM += new EventHandler(BeforeCloseSSMEvent);
            udpSSMChannel.Open();

            // ISM(UdpAnySourceMulticast) channel.
            udpISMChannel = new UdpAnySourceMulticastChannel(IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.ISMLocalPort), 2048);
            udpISMChannel.OpeningEvent += new EventHandler(OpeningISMEvent);
            udpISMChannel.ReceivedEvent += new EventHandler<UdpConvertMessageEvent>(ReceivedISMEvent);
            udpISMChannel.ClosingEvent += new EventHandler(ClosingISMEvent);
            udpISMChannel.Open();
            
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        // Connect ISM server event. 
        private void OpeningISMEvent(object obj, EventArgs e)
        {
            lstAllMsg.Items.Insert(0, "Connect ISM server");
        }

        // Receive message from ISM server event. 
        private void ReceivedISMEvent(object obj, UdpConvertMessageEvent e)
        {
            string message = string.Format("{0} - Come from：{1}", e.BufferMessage.TrimEnd('\0'), e.EndPoint.ToString());
            lstAllMsg.Items.Insert(0, message);
        }
        
        // Close ISM server event.
        private void ClosingISMEvent(object obj, EventArgs e)
        {
            lstAllMsg.Items.Insert(0, "Disconnect ISM server");
        }

        // Connect SSM server event
        private void AfterOpeningSSMEvent(object obj, EventArgs e)
        {
            lstAllMsg.Items.Insert(0, "Connect SSM server");
        }

        // Receive message from SSM server event.
        private void BeforeReceivedSSMEvent(object obj, UdpConvertMessageEvent e)
        {
            string message = String.Format("Come from {0} : {1}", e.EndPoint, e.BufferMessage);
            lstAllMsg.Items.Insert(0, message);
            if (this.isPause)
            {
                lstAllMsg.Items.Insert(0, "The broadcast had been paused.");
            }
        }

        // Close SSM server event.
        private void BeforeCloseSSMEvent(object obj, EventArgs e)
        {
            lstAllMsg.Items.Insert(0, "Disconnect SSM server");
        }

        /// <summary>
        /// Send message from the client-side to other client-sides
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            string strSendText = tbSendMessage.Text;
            if (strSendText.Trim() == String.Empty)
            {
                lstAllMsg.Items.Insert(0, "You can not send empty message");
                return;
            }
            string sendMessage = String.Format("The message -- {0} :", strSendText);
            udpISMChannel.Send(sendMessage);
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (udpISMChannel.IsJoined != false && udpSSMChannel.IsJoinBroadcast != false)
            {
                if (this.isPause)
                {
                    btnPause.Content = "Pause broadcast";
                    this.isPause = false;
                    udpISMChannel.IsReceived = true;
                    udpSSMChannel.IsReceived = true;
                    udpSSMChannel.Received();
                    lstAllMsg.Items.Insert(0, "The broadcast had been resumed.");
                }
                else
                {
                    btnPause.Content = "Resume broadcast";
                    this.isPause = true;
                    udpISMChannel.IsReceived = false;
                    udpSSMChannel.IsReceived = false;
                }
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            udpISMChannel.Close();
            udpSSMChannel.Close();
        }

  
    }
}
