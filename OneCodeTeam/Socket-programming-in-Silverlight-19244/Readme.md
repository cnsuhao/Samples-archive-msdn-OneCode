# Socket programming in Silverlight (VBSL4SocketProgramming)
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
* 2012-10-25 02:02:42
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;VBSL4SocketProgramming Overview<br>
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
Step 1: Open the VBSL4SocketProgramming.sln and rebuild solution. &nbsp;<br>
<br>
Step 2: Open the VBSL4SocketProgramming.exe though this path : <br>
&nbsp; &nbsp; &nbsp; &nbsp;VBSL4SocketProgramming\VBSL4SocketProgrammingServer\bin\Debug\VBSL4SocketProgrammingServer.exe<br>
<br>
Step 3: Expand the VBSL4SocketProgramming web application and Set <br>
&nbsp; &nbsp; &nbsp; &nbsp;VBSL4SocketProgramming as start up project. press Ctrl &#43; F5
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;to show the VBSL4SocketProgrammingTestPage.html page.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Note]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Before running Silverlight application Remember modify the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPConfig.resx file of VBSL4SocketProgramming project.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Set YourIP field value to local IP address.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/Note]<br>
<br>
Step 4: You will find the VBSL4SocketProgramming.exe will broadcast<br>
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
Step 8: If you have more computers, please copy this web application to <br>
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
Step 1. Create a VB &quot;Silverlight Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBSL4SocketProgramming&quot;.<br>
<br>
Step 2. Create a Silverlight page and named it as &quot;Demo.xaml&quot;, and please <br>
&nbsp; &nbsp; &nbsp; &nbsp;modify the App.xaml.vb file, set RootVisual property as Demo.
<br>
<br>
Step 3. Add some class files in the root directory of Silverlight project.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Named them as &quot;UdpAnySourceMulticastChannel.vb&quot;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;UdpConvertMessageEvent.vb&quot; and &quot;UdpSingleSourceMulticastChannel.vb&quot;.<br>
<br>
Step 4. The UdpAnySourceMulticastChannel class use to create a ISM client<br>
&nbsp; &nbsp; &nbsp; &nbsp;and send, receive message.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Class UdpAnySourceMulticastChannel<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Implements IDisposable<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private AsmClient As UdpAnySourceMulticastClient<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private bufferVariable As Byte()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private IsJoined As Boolean<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Event ReceivedEvent As EventHandler(Of UdpConvertMessageEvent)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Event OpeningEvent As EventHandler<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Event ClosingEvent As EventHandler<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' Constructor method. Define a buffer bytes variable and an ASM client.
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;ipAddress&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;port&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;maxMessageSize&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Sub New(ByVal ipAddress As IPAddress, ByVal port As Integer, ByVal maxMessageSize As Integer)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;bufferVariable = New Byte(maxMessageSize - 1) {}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsmClient = New UdpAnySourceMulticastClient(ipAddress, port)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &nbsp;Handle receive message from server event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;ipSource&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;message&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private Sub Received(ByVal ipSource As IPEndPoint, ByVal message As Byte())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent ReceivedEvent(Me, New UdpConvertMessageEvent(message, ipSource))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' Handle connect to server event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private Sub Opening()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent OpeningEvent(Me, EventArgs.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' Handle close the connection event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private Sub Closing()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent ClosingEvent(Me, EventArgs.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' Connect to ASM server method.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Sub Open()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Not IsJoined Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim callBack As New AsyncCallback(AddressOf OpenEvent)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsmClient.BeginJoinGroup(callBack, Nothing)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private Sub OpenEvent(ByVal result As IAsyncResult)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsmClient.EndJoinGroup(result)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.IsJoined = True<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Deployment.Current.Dispatcher.BeginInvoke(AddressOf OpenInvoke)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private Sub OpenInvoke()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.Opening()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.Recive()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' Receive message method.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Sub Recive()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If IsJoined Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Array.Clear(bufferVariable, 0, bufferVariable.Length)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim callBack As New AsyncCallback(AddressOf ReciveCallBack)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsmClient.BeginReceiveFromGroup(bufferVariable, 0, bufferVariable.Length, callBack, Nothing)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim fromIP As IPEndPoint = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Sub ReciveCallBack(ByVal result As IAsyncResult)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsmClient.EndReceiveFromGroup(result, fromIP)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Deployment.Current.Dispatcher.BeginInvoke(AddressOf ReciveInvoke)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Sub ReciveInvoke()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Received(fromIP, bufferVariable)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Recive()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' Send message method.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;message&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Sub Send(ByVal message As String)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If IsJoined Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim sendMessage As Byte() = Encoding.UTF8.GetBytes(message)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim callBack As New AsyncCallback(AddressOf SendInvoke)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsmClient.BeginSendToGroup(sendMessage, 0, sendMessage.Length, callBack, Nothing)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Sub SendInvoke(ByVal result)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsmClient.EndSendToGroup(result)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;#Region &quot;IDisposable Support&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Private disposedValue As Boolean ' To detect redundant calls<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' IDisposable<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Protected Overridable Sub Dispose(ByVal disposing As Boolean)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Not Me.disposedValue Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If disposing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' TODO: dispose managed state (managed objects).<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Dispose ASM client.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If AsmClient IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AsmClient.Dispose()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' TODO: set large fields to null.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.disposedValue = True<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;'Protected Overrides Sub Finalize()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' &nbsp; &nbsp;' Do not change this code. &nbsp;Put cleanup code in Dispose(ByVal disposing As Boolean) above.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' &nbsp; &nbsp;Dispose(False)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' &nbsp; &nbsp;MyBase.Finalize()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;'End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' This code added by Visual Basic to correctly implement the disposable pattern.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Public Sub Dispose() Implements IDisposable.Dispose<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Do not change this code. &nbsp;Put cleanup code in Dispose(ByVal disposing As Boolean) above.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dispose(True)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; GC.SuppressFinalize(Me)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; #End Region<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; End Class<br>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 5. The UdpConvertMessageEvent inherits EventArgs class. It use to<br>
&nbsp; &nbsp; &nbsp; &nbsp;convert bytes to string and render them on page.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;Public Property BufferMessage() As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Property EndPoint() As IPEndPoint<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Receive the message and render them in UI layer.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;dataMessage&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;endPoint&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub New(ByVal dataMessage As Byte(), ByVal endPoint As IPEndPoint)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.BufferMessage = Encoding.UTF8.GetString(dataMessage, 0, dataMessage.Length)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.EndPoint = endPoint<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;[/code] &nbsp;<br>
<br>
Step 6. The UdpSingleSourceMulticastChannel class use to create SSM client<br>
&nbsp; &nbsp; &nbsp; &nbsp;and receive message from server application.<br>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Implements IDisposable<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private SSMClient As UdpSingleSourceMulticastClient<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private byteBuffer As Byte()<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private serverIP As IPAddress<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private targetIP As IPAddress<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private port As Integer<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private isJoinBroadcast As Boolean<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public isReceived As Boolean<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Event AfterOpen As EventHandler<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Event BeforeReceived As EventHandler(Of UdpConvertMessageEvent)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Event BeforeCloseSSM As EventHandler<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Constructor method. Define a buffer bytes variable,<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' server IP, group IP, port, and a SSM client.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;serverIP&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;targetIP&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;port&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;messageSize&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub New(ByVal serverIP As IPAddress, ByVal targetIP As IPAddress, ByVal port As Integer, ByVal messageSize As Integer)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.serverIP = serverIP<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.targetIP = targetIP<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.port = port<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;byteBuffer = New Byte(messageSize - 1) {}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient = New UdpSingleSourceMulticastClient(serverIP, targetIP, port)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Connect to SSM server method.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub Open()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Me.isJoinBroadcast Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If SSMClient Is Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient = New UdpSingleSourceMulticastClient(serverIP, targetIP, port)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim callBack As New AsyncCallback(AddressOf OpenCallBack)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient.BeginJoinGroup(callBack, Nothing)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub OpenCallBack(ByVal result As IAsyncResult)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient.EndJoinGroup(result)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.isJoinBroadcast = True<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.isReceived = True<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Deployment.Current.Dispatcher.BeginInvoke(AddressOf OpenInvoke)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub OpenInvoke()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent AfterOpen(Me, EventArgs.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Received()<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Receive message from ASM server method.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub Received()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Not Me.isJoinBroadcast Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Not Me.isReceived Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Array.Clear(byteBuffer, 0, byteBuffer.Length)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim callBack As New AsyncCallback(AddressOf ReceiveCallBack)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient.BeginReceiveFromSource(byteBuffer, 0, byteBuffer.Length, callBack, Nothing)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Catch ex As Exception<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Throw ex<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End Try<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub ReceiveInvoke()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent BeforeReceived(Me, New UdpConvertMessageEvent(byteBuffer, New IPEndPoint(serverIP, sourcePoint)))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.Received()<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim sourcePoint As Integer<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub ReceiveCallBack(ByVal result As IAsyncResult)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient.EndReceiveFromSource(result, sourcePoint)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Deployment.Current.Dispatcher.BeginInvoke(AddressOf ReceiveInvoke)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Close the connection event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub Close()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.isJoinBroadcast = False<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RaiseEvent BeforeCloseSSM(Me, EventArgs.Empty)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dispose()<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;#Region &quot;IDisposable Support&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private disposedValue As Boolean ' To detect redundant calls<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' IDisposable<br>
&nbsp; &nbsp; &nbsp; &nbsp;Protected Overridable Sub Dispose(ByVal disposing As Boolean)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If Not Me.disposedValue Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If disposing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' TODO: dispose managed state (managed objects).<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If SSMClient IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient.Dispose()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SSMClient = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' TODO: set large fields to null.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.disposedValue = True<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.<br>
&nbsp; &nbsp; &nbsp; &nbsp;'Protected Overrides Sub Finalize()<br>
&nbsp; &nbsp; &nbsp; &nbsp;' &nbsp; &nbsp;' Do not change this code. &nbsp;Put cleanup code in Dispose(ByVal disposing As Boolean) above.<br>
&nbsp; &nbsp; &nbsp; &nbsp;' &nbsp; &nbsp;Dispose(False)<br>
&nbsp; &nbsp; &nbsp; &nbsp;' &nbsp; &nbsp;MyBase.Finalize()<br>
&nbsp; &nbsp; &nbsp; &nbsp;'End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' This code added by Visual Basic to correctly implement the disposable pattern.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub Dispose() Implements IDisposable.Dispose<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Do not change this code. &nbsp;Put cleanup code in Dispose(ByVal disposing As Boolean) above.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dispose(True)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GC.SuppressFinalize(Me)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp;#End Region<br>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 7. Add these code in your Demo.xaml.vb file:<br>
&nbsp; &nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public udpSSMChannel As UdpSingleSourceMulticastChannel<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public udpASMChannel As UdpAnySourceMulticastChannel<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub New()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Initialize the UDP channel with resource files, There you can add
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' user-defined event for connect server, send or receive message.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InitializeComponent()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' SSM(UdpSingleSourceMulticast) channel.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpSSMChannel = New UdpSingleSourceMulticastChannel(IPAddress.Parse(IPConfig.YourIP), IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.SSMLocalPort), 2048)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddHandler udpSSMChannel.AfterOpen, AddressOf AfterOpeningSSMEvent<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddHandler udpSSMChannel.BeforeReceived, AddressOf BeforeReceivedSSMEvent<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddHandler udpSSMChannel.BeforeCloseSSM, AddressOf BeforeCloseSSMEvent<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpSSMChannel.Open()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' ASM(UdpAnySourceMulticast) channel.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpASMChannel = New UdpAnySourceMulticastChannel(IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.ASMLocalPort), 2048)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddHandler udpASMChannel.OpeningEvent, AddressOf OpeningASMEvent<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddHandler udpASMChannel.ReceivedEvent, AddressOf ReceivedASMEvent<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddHandler udpASMChannel.ClosingEvent, AddressOf ClosingASMEvent<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;udpASMChannel.Open()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;'Executes when the user navigates to this page.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Connect ASM server event. <br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub OpeningASMEvent(ByVal obj As Object, ByVal e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, &quot;Connect ASM server&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Receive message from ASM server event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub ReceivedASMEvent(ByVal obj As Object, ByVal e As UdpConvertMessageEvent)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim message As String = String.Format(&quot;{0} - Come from：{1}&quot;, e.BufferMessage.TrimEnd(ControlChars.NullChar), e.EndPoint.ToString())<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, message)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Close ASM server event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub ClosingASMEvent(ByVal obj As Object, ByVal e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, &quot;Disconnect ASM server&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Connect SSM server event<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub AfterOpeningSSMEvent(ByVal obj As Object, ByVal e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, &quot;Connect SSM server&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Receive message from SSM server event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub BeforeReceivedSSMEvent(ByVal obj As Object, ByVal e As UdpConvertMessageEvent)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim message As String = [String].Format(&quot;Come from {0} : {1}&quot;, e.EndPoint, e.BufferMessage)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, message)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Close SSM server event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub BeforeCloseSSMEvent(ByVal obj As Object, ByVal e As EventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lstAllMsg.Items.Insert(0, &quot;Disconnect SSM server&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Send message from the client-side to other client-sides<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;remarks&gt;&lt;/remarks&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim strSendText As String = tbSendMessage.Text<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If strSendText.Trim() = [String].Empty Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; lstAllMsg.Items.Insert(0, &quot;You can not send empty message&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim sendMessage As String = [String].Format(&quot;The message {0}:&quot;, strSendText)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; udpASMChannel.Send(sendMessage)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
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
