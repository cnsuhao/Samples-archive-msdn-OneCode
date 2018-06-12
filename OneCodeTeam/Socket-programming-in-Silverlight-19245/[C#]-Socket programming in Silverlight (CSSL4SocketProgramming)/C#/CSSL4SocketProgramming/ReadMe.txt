========================================================================
                  CSSL4SocketProgramming Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to use Socket achieve MultiCast function
in Silverlight. We demonstrate ISM and SSM in this sample, The 
application includes a console application as server side and a 
Silverlight application as client side, the server will broadcast
messages to client sides and client sides can also send messages 
to other users.

[Note]
This sample-code use Microsoft.Silverlight.PolicyServers.dll for
create server-side console application. The reference of this dll 
file come from :
http://archive.msdn.microsoft.com/silverlightsdk
[/Note]

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the CSSL4SocketProgramming.sln and rebuild solution.  

Step 2: Open the CSSL4SocketProgrammingServer.exe through this path : 
        CSSL4SocketProgramming\CSSL4SocketProgrammingServer\bin\Debug\CSSL4SocketProgrammingServer.exe

Step 3: Expand the CSSL4SocketProgramming web application and Set 
        CSSL4SocketProgramming as start up project. press Ctrl + F5 
		to show the CSSL4SocketProgrammingTestPage.html page.
		[Note]
		Before running Silverlight application Remember modify the 
		IPConfig.resx file of CSSL4SocketProgramming project.
		Set YourIP field value to local IP address.
		[/Note]

Step 4: You will find the CSSL4SocketProgramming.exe will broadcast
        the message to clients.
		The send message will be like this:
		"The broadcast server have send XX bytes message to clients."

Step 5: Please switch to client-side page you can find the page will 
        receive messages every 3 seconds.
		The receive message will be like this:
		"Come from : [your IP address : port] : Send message : My time is [server time]" 

Step 6: Users can also input their messages in TextBox control and click
        "Send" button for show to other users. This function need open more
		client-sides.
		If you have only one computer please copy the URL of 
		CSSL4SocketProgrammingTestPage.html page and paste it in the new 
		windows or tabs of browser's URL bar.  

Step 7: Please send your message from one of clients and you can find them
        in other clients.

Step 8: If you have more computers please copy this web application to 
        others. You need run one server application of these computers, and 
		modify other clients's IPConfig.resx file, set YourIP field value
	    as server's IP address and run client application.

Step 9: You will find all clients can receive message from the server-side
        application and other clients.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "Silverlight Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSSL4SocketProgramming".

Step 2. Create a Silverlight page and named it as "Demo.xaml", and please 
        modify the App.xaml.cs file, set RootVisual property as Demo. 

Step 3. Add some class files in the root directory of Silverlight project.
        Named them as "UdpAnySourceMulticastChannel.cs",
		"UdpConvertMessageEvent.cs" and "UdpSingleSourceMulticastChannel.cs".

Step 4. The UdpAnySourceMulticastChannel class is use to create a ISM client
        and send, receive message.
		[code]
        private UdpAnySourceMulticastClient ISMClient;
        private byte[] bufferVariable;
        private bool IsJoined;
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
                Array.Clear(bufferVariable, 0, bufferVariable.Length);
                AsyncCallback callBack = new AsyncCallback(ReceiveCallBack);
                ISMClient.BeginReceiveFromGroup(bufferVariable, 0, bufferVariable.Length, callBack, null);
            }
        }

        IPEndPoint fromIP;
        private void ReceiveCallBack(IAsyncResult result)
        {
            ISMClient.EndReceiveFromGroup(result, out fromIP);
            Deployment.Current.Dispatcher.BeginInvoke(ReceiveEvent);
        }

        private void ReceiveEvent()
        {
            this.Received(fromIP, bufferVariable);
            this.Receive();
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
            if (ISMClient != null)
            {
                ISMClient.Dispose();
            }
        }
	   [/code]

Step 5. The UdpConvertMessageEvent inherits EventArgs class. It use to
        convert bytes to string and render them on page.
	   [code]
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
       [/code]  

Step 6. The UdpSingleSourceMulticastChannel class use to create SSM client
        and receive message from server application.
    	[code]
		public class UdpSingleSourceMulticastChannel : IDisposable
        {
            private UdpSingleSourceMulticastClient SSMClient;
            private byte[] byteBuffer;
            private IPAddress serverIP;
            private IPAddress targetIP;
            private int port;
            private int sourcePoint;
            private bool isJoinBroadcast;
            public bool isReceived;
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
                if (this.isJoinBroadcast)
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
                this.isJoinBroadcast = true;
                this.isReceived = true;
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
                try
                {
                    if (!this.isJoinBroadcast)
                    {
                        return;
                    }
                    if (!this.isReceived)
                    {
                        return;
                    }
                    Array.Clear(byteBuffer, 0, byteBuffer.Length);
                    AsyncCallback callBack = new AsyncCallback(ReceivedCallBack);
                    SSMClient.BeginReceiveFromSource(byteBuffer, 0, byteBuffer.Length, callBack, null);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            private void ReceivedCallBack(IAsyncResult result)
            {
                SSMClient.EndReceiveFromSource(result, out sourcePoint);
                Deployment.Current.Dispatcher.BeginInvoke(ReceivedEvent);
            }

            private void ReceivedEvent()
            {
                var receivedHandler = BeforeReceived;
                if (receivedHandler != null)
                {
                    receivedHandler(this, new UdpConvertMessageEvent(byteBuffer, new IPEndPoint(serverIP, sourcePoint)));
                }
                this.Received();
            }

            /// <summary>
            /// Close the connection event.
            /// </summary>
            public void Close()
            {
                this.isJoinBroadcast = false;
                var closeHandler = BeforeCloseSSM;
                if (closeHandler != null)
                {
                    closeHandler(this, EventArgs.Empty);
                }
                Dispose();
            }

            public void Dispose()
            {
                if (SSMClient != null)
                {
                    SSMClient.Dispose();
                    SSMClient = null;
                }
            }
	    }
    	[/code]

Step 7. Add these code in your Demo.xaml.cs file:
        [code]
		// Define two UDP channel for send and receive the message from server or other clients.
        public UdpSingleSourceMulticastChannel udpSSMChannel;
        public UdpAnySourceMulticastChannel udpISMChannel;
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
        private void Button_Click(object sender, RoutedEventArgs e)
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
		[/code]

Step 8. Create a console application, and named it as 
        "CSSL4SocketProgrammingServer", and add VB code as the sample.

Step 9. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: UdpAnySourceMulticastClient Class
http://msdn.microsoft.com/en-us/library/system.net.sockets.udpanysourcemulticastclient(VS.95).aspx

MSDN: UdpSingleSourceMulticastClient Class
http://msdn.microsoft.com/en-us/library/system.net.sockets.udpsinglesourcemulticastclient(VS.96).aspx

MSDN: Policy Files 
http://msdn.microsoft.com/en-us/library/aa529254.aspx
/////////////////////////////////////////////////////////////////////////////