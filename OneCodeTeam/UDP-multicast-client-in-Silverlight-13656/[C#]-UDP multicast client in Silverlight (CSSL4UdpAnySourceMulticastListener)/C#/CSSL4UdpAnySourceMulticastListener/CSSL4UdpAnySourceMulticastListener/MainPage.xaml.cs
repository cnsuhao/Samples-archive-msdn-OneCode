/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.cs
* Project: CSSL4UdpAnySourceMulticastListener
* Copyright (c) Microsoft Corporation.
* 
* This file contains the code actually implementing the CSSL4UdpAnySourceMulticastListener sample.
* This code creates a simple UDP multicast client, listening on port 8888.  Since the client runs from
* Silverlight, it requires that a multicast policy server be available on the same port in order to run. 
* The policy server is exposed in a simple console application, CSSSLUdpAnySourceMulticastPolicyServer, which
* uses MSDN code from the Silverlight documentation samples to expose a very simple interface.
* 
* After opening the connection, the client listens for any messages received on the same multicast port,
* and can send messages to other clients on the port.  
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/    

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CSSL4UdpAnySourceMulticastListener
{
    public partial class MainPage : UserControl
    {
        // When the page loads, instantiate the UdpAnySourceMulticastClient on the standard 
        // multicast IP address, using an arbitrarily selected port 8888.  This is how messages 
        // are broadcast and received from clients. Note that the broadcast will not work through 
        // any device that filters multicast packets, and clients will not be able to listen 
        // to multicast packets from Silverlight unless a Silverlight multicast policy server 
        // is available Silverlight will initially send a UDP multicast request for any listening 
        // policy server on the port, and if  policy is returned (an XML file, just like the 
        // CrossDomainPolicy.xml used for web traffic across domains in Silverlight),  then the 
        // client will continue to listen.  If no policy file is returned, the client will fail 
        // to join the session,  throw an exception when it is accessed.
        private UdpAnySourceMulticastClient client = new UdpAnySourceMulticastClient(IPAddress.Parse("224.0.0.1"), 8888);

        // The session variable is simply a good way to identify each message posted by various 
        // clients to the multicast. In this case, it is selected to be the current session ID, 
        // which the web page hosting this control passes as a parameter to Silverlight.  It is 
        // not required for functionality of the multicast.
        private string session;

        public MainPage()
        {
            InitializeComponent();

            // Add an event handler when the application exits.  This is not strictly necessary, 
            // however, it provides a good opportunity to post a message to the multicast port 
            // indicating the session is ending, for  other users.  Since the connection is stateless, 
            // the client does not need to close cleanly.  When it  broadcasting messages, other 
            // clients will simply no longer receive them.
            Application.Current.Exit += new EventHandler(Current_Exit);

            // Initialize the session variable from the InitParams passed into the control via 
            // the web page on which it is hosted.
            session = App.Current.Host.InitParams["session"];
            
            // Initialize the instructions on the user interface to indicate the current session ID for the user.
            tbInstructions.Text += "\r\n\r\nSession ID for this client: " + session;

            // Join the client to the multicast, initiated with BeginJoinGroup().
            // The last parameter to the BeginJoinGroup() is simply an object which can contain state, 
            // here not used, and passed as null.
            client.BeginJoinGroup(res =>
            {
                // BeginJoinGroup takes an AsyncCallback function as its parameter.  In this case,
                // the simplest way to implement that is with an anonymous function, using =>
                // The callback function must call EndJoinGroup(), passing the IAsyncResult obtained
                // from the BeginJoinGroup() when the callback occurs, the variable res.
                this.client.EndJoinGroup(res);

                // After the multicast is successfully joined, invoke the dispatcher thread again to 
                // send our first multicast message, notifying any other clients that we have joined.
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    Send("Session " + session + " joined multicast.");
                    Receive();
                });
            }, null);  
        }

        void Current_Exit(object sender, EventArgs e)
        {
            // When the application is exiting, we send one last message to inform other clients we 
            // are leaving the multicast.
            Send("Session " + session + " exited multicast.");
        }
        
        private void Send(string message)
        {
            // Convert the string message to be posted into a byte array, which we need to call 
            // BeginSendToGroup(), to post the message.
            byte[] data = Encoding.UTF8.GetBytes(message);

            // Call another asynchronous method, BeginSendToGroup(), passing the byte array, 
            // start point, its length, and finally, another AsyncCallback function, again, 
            // using an anonymous function with =>, which passed the IAsyncResult variable res.
            // The last parameter to BeginSendToGroup() is again simply an optional object containing 
            // state information, which we just pass as null.
            client.BeginSendToGroup(data, 0, data.Length, res =>
                {
                    // When BeginSendToGroup() calls back to notify that it is ready, we must call 
                    // EndSendToGroup() to complete the send operation.
                    client.EndSendToGroup(res);
                }, null); 
        }

        private void Receive()
        {
            // Initialize a byte array to be used as a buffer to receive the next message broadcast on the channel.
            byte[] buffer = new byte[1024];

            // BeginReceieveFromGroup() will call back after a new message is received.  Call back 
            // to anonymous function in the block below, with IAsyncResult res.
            client.BeginReceiveFromGroup(buffer, 0, buffer.Length,
                res =>
                {
                    // Check for null client in case it was released after the receive was initiated.
                    if (client != null)
                    {
                        IPEndPoint src;

                        // Complete the receive, providing required output parameter src, where IP address 
                        // and port of the message source is returned.
                        client.EndReceiveFromGroup(res, out src);

                        // BeginInvoke to call back to the main thread, where we can update UI with the message received.
                        Deployment.Current.Dispatcher.BeginInvoke(
                            () =>
                            {
                                lbChannel.Items.Add(Encoding.UTF8.GetString(buffer, 0, buffer.Length));
                                lbChannel.ScrollIntoView(lbChannel.Items[lbChannel.Items.Count - 1]); 
                                
                            });

                        // Then after the message is processed, call Receive again to start waiting for the next message.
                        Receive();
                    }
                }, null);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            // When Send is pressed, just send a message (identifying this session) and clear the message input TextBox.
            Send("Session " + session + " says:\r\n\t" + tbSend.Text);
            tbSend.Text = "";
        }

        // Just a check to see if user presses Enter, then call btnSend_Click() to send the text.
        private void tbSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) btnSend_Click(sender, e);
        }
    }
}
