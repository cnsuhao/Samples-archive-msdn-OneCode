/****************************** Module Header ******************************\
* Module Name: UdpConvertMessageEvent.cs
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
* This class inherits EventArgs class and render message on UI page.
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
using System.Text;

namespace CSSL4SocketProgramming
{
    public class UdpConvertMessageEvent : EventArgs
    {
        public string BufferMessage
        {
            get;
            set;
        }

        public IPEndPoint EndPoint
        {
            get;
            set;
        }

        /// <summary>
        /// Receive the message and render them in UI layer.
        /// </summary>
        /// <param name="dataMessage"></param>
        /// <param name="endPoint"></param>
        public UdpConvertMessageEvent(byte[] dataMessage, IPEndPoint endPoint)
        {
            this.BufferMessage = Encoding.UTF8.GetString(dataMessage, 0, dataMessage.Length);
            this.EndPoint = endPoint;
        }
    }
}
