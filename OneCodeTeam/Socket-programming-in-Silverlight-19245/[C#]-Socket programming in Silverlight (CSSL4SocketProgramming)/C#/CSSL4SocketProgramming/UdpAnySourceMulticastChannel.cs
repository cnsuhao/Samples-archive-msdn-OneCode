/****************************** Module Header ******************************\
* Module Name: UdpAnySourceMulticastChannel.cs
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
* This class use to create a ISM client.
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
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Net.Sockets;
using System.Text;

namespace CSSL4SocketProgramming
{
    public class UdpAnySourceMulticastChannel : IDisposable
    {
        private UdpAnySourceMulticastClient ISMClient;
        private byte[] bufferVariable;
        public bool IsJoined;
        public bool IsReceived = true;
        public event EventHandler<UdpConvertMessageEvent> ReceivedEvent;
        public event EventHandler OpeningEvent;
        public event EventHandler ClosingEvent;

        /// <summary>
        /// Constructor method. Define a buffer bytes variable and an ISM client. 
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <param name="maxMessageSize"></param>
        public UdpAnySourceMulticastChannel(IPAddress ipAddress, int port, int maxMessageSize)
        {
            bufferVariable = new byte[maxMessageSize];
            ISMClient = new UdpAnySourceMulticastClient(ipAddress, port);
        }

        /// <summary>
        /// Handle receive message from server event.
        /// </summary>
        /// <param name="ipSource"></param>
        /// <param name="message"></param>
        private void Received(IPEndPoint ipSource, byte[] message)
        {
            var handler = ReceivedEvent;
            if (handler != null)
            {
                handler(this, new UdpConvertMessageEvent(message, ipSource));
            }
        }

        /// <summary>
        /// Handle connect to server event.
        /// </summary>
        private void Opening()
        {
            var handler = OpeningEvent;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Handle close the connection event.
        /// </summary>
        private void Closing()
        {
            var handler = ClosingEvent;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Close()
        {
            this.IsJoined = false;
            this.IsReceived = false;
            this.Closing();
            Dispose(true);
        }

        /// <summary>
        /// Connect to ISM server method.
        /// </summary>
        public void Open()
        {
            if (!IsJoined)
            {
                AsyncCallback callBack = new AsyncCallback(OpenCallBack);
                ISMClient.BeginJoinGroup(callBack, null);
            }
        }

        private void OpenCallBack(IAsyncResult result)
        {
            ISMClient.EndJoinGroup(result);
            this.IsJoined = true;
            Deployment.Current.Dispatcher.BeginInvoke(OpenEvent);
        }

        private void OpenEvent()
        {
            this.Opening();
            this.Receive();
        }

        /// <summary>
        /// Receive message method.
        /// </summary>
        public void Receive()
        {
            if (IsJoined)
            {
                if (IsReceived)
                {
                    Array.Clear(bufferVariable, 0, bufferVariable.Length);
                    AsyncCallback callBack = new AsyncCallback(ReceiveCallBack);
                    ISMClient.BeginReceiveFromGroup(bufferVariable, 0, bufferVariable.Length, callBack, null);
                }
            }
        }

        IPEndPoint fromIP;
        private void ReceiveCallBack(IAsyncResult result)
        {
            if (IsJoined)
            {
                if (IsReceived)
                {
                    ISMClient.EndReceiveFromGroup(result, out fromIP);
                    Deployment.Current.Dispatcher.BeginInvoke(ReceiveEvent);
                }
            }
        }

        private void ReceiveEvent()
        {
            if (IsJoined)
            {
                if (IsReceived)
                {
                    this.Received(fromIP, bufferVariable);
                    this.Receive();
                }
            }
        }

        /// <summary>
        /// Send message method.
        /// </summary>
        /// <param name="message"></param>
        public void Send(string message)
        {
            if (IsJoined)
            {
                byte[] sendMessage = Encoding.UTF8.GetBytes(message);
                AsyncCallback callBack = new AsyncCallback(SendCallBack);
                ISMClient.BeginSendToGroup(sendMessage, 0, sendMessage.Length, callBack, null);
            }
        }

        private void SendCallBack(IAsyncResult result)
        {
            ISMClient.EndSendToGroup(result);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // To detect redundant calls
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                if (ISMClient != null)
                {
                    ISMClient.Dispose();
                }
            }
            disposed = true;
        }
    }
}
