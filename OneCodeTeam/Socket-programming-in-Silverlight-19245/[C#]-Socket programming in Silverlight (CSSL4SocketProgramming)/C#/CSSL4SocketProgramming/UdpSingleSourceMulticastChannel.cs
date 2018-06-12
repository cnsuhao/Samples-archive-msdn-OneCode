/****************************** Module Header ******************************\
* Module Name: UdpSingleSourceMulticastChannel.cs
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
* This class use to create a SSM client.
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
    public class UdpSingleSourceMulticastChannel : IDisposable
    {
        private UdpSingleSourceMulticastClient SSMClient;
        private byte[] byteBuffer;
        private IPAddress serverIP;
        private IPAddress targetIP;
        private int port;
        private int sourcePoint;
        public bool IsJoinBroadcast;
        public bool IsReceived = true;
        public event EventHandler AfterOpen;
        public event EventHandler<UdpConvertMessageEvent> BeforeReceived;
        public event EventHandler BeforeCloseSSM;

        /// <summary>
        /// Constructor method. Define a buffer bytes variable,
        /// server IP, group IP, port, and a SSM client.
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="targetIP"></param>
        /// <param name="port"></param>
        /// <param name="messageSize"></param>
        public UdpSingleSourceMulticastChannel(IPAddress serverIP, IPAddress targetIP, int port, int messageSize)
        {
            this.serverIP = serverIP;
            this.targetIP = targetIP;
            this.port = port;
            byteBuffer = new byte[messageSize];
            SSMClient = new UdpSingleSourceMulticastClient(serverIP, targetIP, port);
        }

        /// <summary>
        /// Connect to SSM server method.
        /// </summary>
        public void Open()
        {
            if (this.IsJoinBroadcast)
            {
                return;
            }
            if (SSMClient == null)
            {
                SSMClient = new UdpSingleSourceMulticastClient(serverIP, targetIP, port);
            }
            AsyncCallback callBack = new AsyncCallback(OpenCallBack);
            SSMClient.BeginJoinGroup(callBack, null);
        }

        private void OpenCallBack(IAsyncResult result)
        {
            SSMClient.EndJoinGroup(result);
            this.IsJoinBroadcast = true;
            this.IsReceived = true;
            Deployment.Current.Dispatcher.BeginInvoke(OpenEvent);
        }

        private void OpenEvent()
        {
            var openHandler = AfterOpen;
            if (openHandler != null)
                openHandler(this, EventArgs.Empty);
            this.Received();
        }

        /// <summary>
        /// Receive message from ISM server method.
        /// </summary>
        public void Received()
        {
            if (!this.IsJoinBroadcast)
            {
                return;
            }
            if (this.IsReceived)
            {
                Array.Clear(byteBuffer, 0, byteBuffer.Length);
                SSMClient.BeginReceiveFromSource(byteBuffer, 0, byteBuffer.Length, result =>
                {
                    if (this.IsJoinBroadcast)
                    {
                        SSMClient.EndReceiveFromSource(result, out sourcePoint);
                        Deployment.Current.Dispatcher.BeginInvoke(() =>
                        {
                            if (this.IsJoinBroadcast)
                            {
                                var receivedHandler = BeforeReceived;
                                if (receivedHandler != null)
                                {
                                    receivedHandler(this, new UdpConvertMessageEvent(byteBuffer, new IPEndPoint(serverIP, sourcePoint)));
                                }
                                this.Received();
                            }
                            else
                            {
                                return;
                            }
                        });
                    }
                    else
                    { return; }
                }, null);
            }
        }

        /// <summary>
        /// Close the connection event.
        /// </summary>
        public void Close()
        {
            this.IsJoinBroadcast = false;
            var closeHandler = BeforeCloseSSM;
            if (closeHandler != null)
            {
                closeHandler(this, EventArgs.Empty);
            }
            Dispose(true);
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
                if (SSMClient != null)
                {
                    SSMClient.Dispose();
                    SSMClient = null;
                }
            }
            disposed = true;
        }
    }
}
