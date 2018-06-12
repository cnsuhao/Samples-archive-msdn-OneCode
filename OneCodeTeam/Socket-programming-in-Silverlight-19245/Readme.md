# Socket programming in Silverlight (CSSL4SocketProgramming)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Silverlight
## Topics
* Socket
## IsPublished
* True
## ModifiedDate
* 2012-10-25 02:02:58
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CSSL4SocketProgramming Overview<br>
========================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Use:<br>
<br>
The project illustrates how to use Socket achieve MultiCast function<br>
in Silverlight. We demonstrate ISM and SSM in this sample, The <br>
application includes a console application as server side and a <br>
Silverlight application as client side, the server will broadcast<br>
messages to client sides and client sides can also send messages <br>
to other users.<br>
<br>
[Note]<br>
This sample-code use Microsoft.Silverlight.PolicyServers.dll for<br>
create server-side console application. The reference of this dll <br>
file come from :<br>
http://archive.msdn.microsoft.com/silverlightsdk<br>
[/Note]<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the CSSL4SocketProgramming.sln and rebuild solution. &nbsp;<br>
<br>
Step 2: Open the CSSL4SocketProgrammingServer.exe through this path : <br>
&nbsp; &nbsp; &nbsp; &nbsp;CSSL4SocketProgramming\CSSL4SocketProgrammingServer\bin\Debug\CSSL4SocketProgrammingServer.exe<br>
<br>
Step 3: Expand the CSSL4SocketProgramming web application and Set <br>
&nbsp; &nbsp; &nbsp; &nbsp;CSSL4SocketProgramming as start up project. press Ctrl &#43; F5
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;to show the CSSL4SocketProgrammingTestPage.html page.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Note]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Before running Silverlight application Remember modify the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPConfig.resx file of CSSL4SocketProgramming project.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Set YourIP field value to local IP address.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/Note]<br>
<br>
Step 4: You will find the CSSL4SocketProgramming.exe will broadcast<br>
&nbsp; &nbsp; &nbsp; &nbsp;the message to clients.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The send message will be like this:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;The broadcast server have send XX bytes message to clients.&quot;<br>
<br>
Step 5: Please switch to client-side page you can find the page will <br>
&nbsp; &nbsp; &nbsp; &nbsp;receive messages every 3 seconds.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The receive message will be like this:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;Come from : [your IP address : port] : Send message : My time is [server time]&quot;
<br>
<br>
Step 6: Users can also input their messages in TextBox control and click<br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;Send&quot; button for show to other users. This function need open more<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client-sides.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If you have only one computer please copy the URL of
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CSSL4SocketProgrammingTestPage.html page and paste it in the new
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;windows or tabs of browser's URL bar. &nbsp;<br>
<br>
Step 7: Please send your message from one of clients and you can find them<br>
&nbsp; &nbsp; &nbsp; &nbsp;in other clients.<br>
<br>
Step 8: If you have more computers please copy this web application to <br>
&nbsp; &nbsp; &nbsp; &nbsp;others. You need run one server application of these computers, and
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;modify other clients's IPConfig.resx file, set YourIP field value<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;as server's IP address and run client application.<br>
<br>
Step 9: You will find all clients can receive message from the server-side<br>
&nbsp; &nbsp; &nbsp; &nbsp;application and other clients.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logical:<br>
<br>
Step 1. Create a C# &quot;Silverlight Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;CSSL4SocketProgramming&quot;.<br>
<br>
Step 2. Create a Silverlight page and named it as &quot;Demo.xaml&quot;, and please <br>
&nbsp; &nbsp; &nbsp; &nbsp;modify the App.xaml.cs file, set RootVisual property as Demo.
<br>
<br>
Step 3. Add some class files in the root directory of Silverlight project.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Named them as &quot;UdpAnySourceMulticastChannel.cs&quot;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;UdpConvertMessageEvent.cs&quot; and &quot;UdpSingleSourceMulticastChannel.cs&quot;.<br>
<br>
Step 4. The UdpAnySourceMulticastChannel class is use to create a ISM client<br>
&nbsp; &nbsp; &nbsp; &nbsp;and send, receive message.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;private UdpAnySourceMulticastClient ISMClient;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private byte[] bufferVariable;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private bool IsJoined;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public event EventHandler&lt;UdpConvertMessageEvent&gt; ReceivedEvent;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public event EventHandler OpeningEvent;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public event EventHandler ClosingEvent;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Constructor method. Define a buffer bytes variable and an ISM client.
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;ipAddress&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;port&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;maxMessageSize&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public UdpAnySourceMulticastChannel(IPAddress ipAddress, int port, int maxMessageSize)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;bufferVariable = new byte[maxMessageSize];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ISMClient = new UdpAnySourceMulticastClient(ipAddress, port);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Handle receive message from server event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;ipSource&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;message&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void Received(IPEndPoint ipSource, byte[] message)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var handler = ReceivedEvent;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (handler != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;handler(this, new UdpConvertMessageEvent(message, ipSource));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Handle connect to server event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void Opening()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var handler = OpeningEvent;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (handler != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;handler(this, EventArgs.Empty);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Handle close the connection event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void Closing()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var handler = ClosingEvent;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (handler != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;handler(this, EventArgs.Empty);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Connect to ISM server method.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void Open()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!IsJoined)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsyncCallback callBack = new AsyncCallback(OpenCallBack);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ISMClient.BeginJoinGroup(callBack, null);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void OpenCallBack(IAsyncResult result)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ISMClient.EndJoinGroup(result);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.IsJoined = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Deployment.Current.Dispatcher.BeginInvoke(OpenEvent);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void OpenEvent()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Opening();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Receive();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Receive message method.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void Receive()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (IsJoined)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Array.Clear(bufferVariable, 0, bufferVariable.Length);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsyncCallback callBack = new AsyncCallback(ReceiveCallBack);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ISMClient.BeginReceiveFromGroup(bufferVariable, 0, bufferVariable.Length, callBack, null);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;IPEndPoint fromIP;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void ReceiveCallBack(IAsyncResult result)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ISMClient.EndReceiveFromGroup(result, out fromIP);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Deployment.Current.Dispatcher.BeginInvoke(ReceiveEvent);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void ReceiveEvent()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Received(fromIP, bufferVariable);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Receive();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Send message method.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;message&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void Send(string message)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (IsJoined)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;byte[] sendMessage = Encoding.UTF8.GetBytes(message);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsyncCallback callBack = new AsyncCallback(SendCallBack);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ISMClient.BeginSendToGroup(sendMessage, 0, sendMessage.Length, callBack, null);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void SendCallBack(IAsyncResult result)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ISMClient.EndSendToGroup(result);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void Dispose()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (ISMClient != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ISMClient.Dispose();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; [/code]<br>
<br>
Step 5. The UdpConvertMessageEvent inherits EventArgs class. It use to<br>
&nbsp; &nbsp; &nbsp; &nbsp;convert bytes to string and render them on page.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; [code]<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;public class UdpConvertMessageEvent : EventArgs<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public string BufferMessage<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public IPEndPoint EndPoint<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;get;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;set;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// Receive the message and render them in UI layer.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;dataMessage&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;endPoint&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public UdpConvertMessageEvent(byte[] dataMessage, IPEndPoint endPoint)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.BufferMessage = Encoding.UTF8.GetString(dataMessage, 0, dataMessage.Length);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.EndPoint = endPoint;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; [/code] &nbsp;<br>
<br>
Step 6. The UdpSingleSourceMulticastChannel class use to create SSM client<br>
&nbsp; &nbsp; &nbsp; &nbsp;and receive message from server application.<br>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public class UdpSingleSourceMulticastChannel : IDisposable<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private UdpSingleSourceMulticastClient SSMClient;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private byte[] byteBuffer;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private IPAddress serverIP;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private IPAddress targetIP;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private int port;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private int sourcePoint;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private bool isJoinBroadcast;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public bool isReceived;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public event EventHandler AfterOpen;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public event EventHandler&lt;UdpConvertMessageEvent&gt; BeforeReceived;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public event EventHandler BeforeCloseSSM;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// Constructor method. Define a buffer bytes variable,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// server IP, group IP, port, and a SSM client.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;serverIP&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;targetIP&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;port&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;messageSize&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public UdpSingleSourceMulticastChannel(IPAddress serverIP, IPAddress targetIP, int port, int messageSize)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.serverIP = serverIP;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.targetIP = targetIP;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.port = port;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;byteBuffer = new byte[messageSize];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient = new UdpSingleSourceMulticastClient(serverIP, targetIP, port);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// Connect to SSM server method.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public void Open()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (this.isJoinBroadcast)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (SSMClient == null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient = new UdpSingleSourceMulticastClient(serverIP, targetIP, port);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsyncCallback callBack = new AsyncCallback(OpenCallBack);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient.BeginJoinGroup(callBack, null);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private void OpenCallBack(IAsyncResult result)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient.EndJoinGroup(result);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.isJoinBroadcast = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.isReceived = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Deployment.Current.Dispatcher.BeginInvoke(OpenEvent);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private void OpenEvent()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var openHandler = AfterOpen;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (openHandler != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;openHandler(this, EventArgs.Empty);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Received();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// Receive message from ISM server method.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public void Received()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!this.isJoinBroadcast)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!this.isReceived)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Array.Clear(byteBuffer, 0, byteBuffer.Length);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsyncCallback callBack = new AsyncCallback(ReceivedCallBack);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient.BeginReceiveFromSource(byteBuffer, 0, byteBuffer.Length, callBack, null);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (Exception ex)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw ex;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private void ReceivedCallBack(IAsyncResult result)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient.EndReceiveFromSource(result, out sourcePoint);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Deployment.Current.Dispatcher.BeginInvoke(ReceivedEvent);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private void ReceivedEvent()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var receivedHandler = BeforeReceived;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (receivedHandler != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;receivedHandler(this, new UdpConvertMessageEvent(byteBuffer, new IPEndPoint(serverIP, sourcePoint)));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.Received();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// Close the connection event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public void Close()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.isJoinBroadcast = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var closeHandler = BeforeCloseSSM;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (closeHandler != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;closeHandler(this, EventArgs.Empty);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dispose();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public void Dispose()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (SSMClient != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient.Dispose();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 7. Add these code in your Demo.xaml.cs file:<br>
&nbsp; &nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Define two UDP channel for send and receive the message from server or other clients.<br>
&nbsp; &nbsp; &nbsp; &nbsp;public UdpSingleSourceMulticastChannel udpSSMChannel;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public UdpAnySourceMulticastChannel udpISMChannel;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public Demo()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Initialize the UDP channel with resource files, There you can add
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// user-defined event for connect server, send or receive message.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InitializeComponent();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// SSM(UdpSingleSourceMulticast) channel.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpSSMChannel = new UdpSingleSourceMulticastChannel(IPAddress.Parse(IPConfig.YourIP), IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.SSMLocalPort), 2048);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpSSMChannel.AfterOpen &#43;= new EventHandler(AfterOpeningSSMEvent);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpSSMChannel.BeforeReceived &#43;= new EventHandler&lt;UdpConvertMessageEvent&gt;(BeforeReceivedSSMEvent);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpSSMChannel.BeforeCloseSSM &#43;= new EventHandler(BeforeCloseSSMEvent);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpSSMChannel.Open();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// ISM(UdpAnySourceMulticast) channel.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpISMChannel = new UdpAnySourceMulticastChannel(IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.ISMLocalPort), 2048);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpISMChannel.OpeningEvent &#43;= new EventHandler(OpeningISMEvent);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpISMChannel.ReceivedEvent &#43;= new EventHandler&lt;UdpConvertMessageEvent&gt;(ReceivedISMEvent);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpISMChannel.ClosingEvent &#43;= new EventHandler(ClosingISMEvent);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpISMChannel.Open();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Executes when the user navigates to this page.<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected override void OnNavigatedTo(NavigationEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Connect ISM server event. <br>
&nbsp; &nbsp; &nbsp; &nbsp;private void OpeningISMEvent(object obj, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, &quot;Connect ISM server&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Receive message from ISM server event. <br>
&nbsp; &nbsp; &nbsp; &nbsp;private void ReceivedISMEvent(object obj, UdpConvertMessageEvent e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string message = string.Format(&quot;{0} - Come from：{1}&quot;, e.BufferMessage.TrimEnd('\0'), e.EndPoint.ToString());<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, message);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Close ISM server event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void ClosingISMEvent(object obj, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, &quot;Disconnect ISM server&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Connect SSM server event<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void AfterOpeningSSMEvent(object obj, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, &quot;Connect SSM server&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Receive message from SSM server event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void BeforeReceivedSSMEvent(object obj, UdpConvertMessageEvent e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string message = String.Format(&quot;Come from {0} : {1}&quot;, e.EndPoint, e.BufferMessage);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, message);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Close SSM server event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void BeforeCloseSSMEvent(object obj, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, &quot;Disconnect SSM server&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Send message from the client-side to other client-sides<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void Button_Click(object sender, RoutedEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string strSendText = tbSendMessage.Text;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (strSendText.Trim() == String.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, &quot;You can not send empty message&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string sendMessage = String.Format(&quot;The message -- {0} :&quot;, strSendText);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpISMChannel.Send(sendMessage);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 8. Create a console application, and named it as <br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;CSSL4SocketProgrammingServer&quot;, and add VB code as the sample.<br>
<br>
Step 9. Build the application and you can debug it.<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
MSDN: UdpAnySourceMulticastClient Class<br>
http://msdn.microsoft.com/en-us/library/system.net.sockets.udpanysourcemulticastclient(VS.95).aspx<br>
<br>
MSDN: UdpSingleSourceMulticastClient Class<br>
http://msdn.microsoft.com/en-us/library/system.net.sockets.udpsinglesourcemulticastclient(VS.96).aspx<br>
<br>
MSDN: Policy Files <br>
http://msdn.microsoft.com/en-us/library/aa529254.aspx<br>
/////////////////////////////////////////////////////////////////////////////<br>