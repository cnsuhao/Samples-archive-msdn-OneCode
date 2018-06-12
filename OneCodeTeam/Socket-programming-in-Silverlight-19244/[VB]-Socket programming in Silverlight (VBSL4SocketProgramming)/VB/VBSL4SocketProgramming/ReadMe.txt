========================================================================
                  VBSL4SocketProgramming Overview
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

Step 1: Open the VBSL4SocketProgramming.sln and rebuild solution.  

Step 2: Open the VBSL4SocketProgramming.exe though this path : 
        VBSL4SocketProgramming\VBSL4SocketProgrammingServer\bin\Debug\VBSL4SocketProgrammingServer.exe

Step 3: Expand the VBSL4SocketProgramming web application and Set 
        VBSL4SocketProgramming as start up project. press Ctrl + F5 
		to show the VBSL4SocketProgrammingTestPage.html page.
		[Note]
		Before running Silverlight application Remember modify the 
		IPConfig.resx file of VBSL4SocketProgramming project.
		Set YourIP field value to local IP address.
		[/Note]

Step 4: You will find the VBSL4SocketProgramming.exe will broadcast
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

Step 8: If you have more computers, please copy this web application to 
        others. You need run one server application of these computers, and 
		modify other clients's IPConfig.resx file, set YourIP field value
	    as server's IP address and run client application.

Step 9: You will find all clients can receive message from the server-side
        application and other clients.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a VB "Silverlight Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "VBSL4SocketProgramming".

Step 2. Create a Silverlight page and named it as "Demo.xaml", and please 
        modify the App.xaml.vb file, set RootVisual property as Demo. 

Step 3. Add some class files in the root directory of Silverlight project.
        Named them as "UdpAnySourceMulticastChannel.vb",
		"UdpConvertMessageEvent.vb" and "UdpSingleSourceMulticastChannel.vb".

Step 4. The UdpAnySourceMulticastChannel class use to create a ISM client
        and send, receive message.
		[code]
        Public Class UdpAnySourceMulticastChannel
            Implements IDisposable

            Private AsmClient As UdpAnySourceMulticastClient
            Private bufferVariable As Byte()
            Private IsJoined As Boolean
            Public Event ReceivedEvent As EventHandler(Of UdpConvertMessageEvent)
            Public Event OpeningEvent As EventHandler
            Public Event ClosingEvent As EventHandler

            ''' <summary>
            ''' Constructor method. Define a buffer bytes variable and an ASM client. 
            ''' </summary>
            ''' <param name="ipAddress"></param>
            ''' <param name="port"></param>
            ''' <param name="maxMessageSize"></param>
            ''' <remarks></remarks>
            Public Sub New(ByVal ipAddress As IPAddress, ByVal port As Integer, ByVal maxMessageSize As Integer)
                bufferVariable = New Byte(maxMessageSize - 1) {}
                AsmClient = New UdpAnySourceMulticastClient(ipAddress, port)
            End Sub

            ''' <summary>
            '''  Handle receive message from server event.
            ''' </summary>
            ''' <param name="ipSource"></param>
            ''' <param name="message"></param>
            ''' <remarks></remarks>
            Private Sub Received(ByVal ipSource As IPEndPoint, ByVal message As Byte())
                RaiseEvent ReceivedEvent(Me, New UdpConvertMessageEvent(message, ipSource))
            End Sub

            ''' <summary>
            ''' Handle connect to server event.
            ''' </summary>
            ''' <remarks></remarks>
            Private Sub Opening()
                RaiseEvent OpeningEvent(Me, EventArgs.Empty)
            End Sub

            ''' <summary>
            ''' Handle close the connection event.
            ''' </summary>
            ''' <remarks></remarks>
            Private Sub Closing()
                RaiseEvent ClosingEvent(Me, EventArgs.Empty)
            End Sub

            ''' <summary>
            ''' Connect to ASM server method.
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub Open()
                If Not IsJoined Then
                    Dim callBack As New AsyncCallback(AddressOf OpenEvent)
                    AsmClient.BeginJoinGroup(callBack, Nothing)
                End If
            End Sub

            Private Sub OpenEvent(ByVal result As IAsyncResult)
                AsmClient.EndJoinGroup(result)
                Me.IsJoined = True
                Deployment.Current.Dispatcher.BeginInvoke(AddressOf OpenInvoke)

            End Sub

            Private Sub OpenInvoke()
                 Me.Opening()
                 Me.Recive()
            End Sub

            ''' <summary>
            ''' Receive message method.
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub Recive()
                If IsJoined Then
                    Array.Clear(bufferVariable, 0, bufferVariable.Length)
                    Dim callBack As New AsyncCallback(AddressOf ReciveCallBack)
                    AsmClient.BeginReceiveFromGroup(bufferVariable, 0, bufferVariable.Length, callBack, Nothing)
                End If
            End Sub

            Dim fromIP As IPEndPoint = Nothing
            Public Sub ReciveCallBack(ByVal result As IAsyncResult)
                AsmClient.EndReceiveFromGroup(result, fromIP)
                Deployment.Current.Dispatcher.BeginInvoke(AddressOf ReciveInvoke)
            End Sub
            Public Sub ReciveInvoke()
                Me.Received(fromIP, bufferVariable)
                Me.Recive()
            End Sub

            ''' <summary>
            ''' Send message method.
            ''' </summary>
            ''' <param name="message"></param>
            ''' <remarks></remarks>
            Public Sub Send(ByVal message As String)
                If IsJoined Then
                    Dim sendMessage As Byte() = Encoding.UTF8.GetBytes(message)
                    Dim callBack As New AsyncCallback(AddressOf SendInvoke)
                    AsmClient.BeginSendToGroup(sendMessage, 0, sendMessage.Length, callBack, Nothing)
                End If
            End Sub

            Public Sub SendInvoke(ByVal result)
                AsmClient.EndSendToGroup(result)
            End Sub

            #Region "IDisposable Support"
            Private disposedValue As Boolean ' To detect redundant calls

            ' IDisposable
            Protected Overridable Sub Dispose(ByVal disposing As Boolean)
                If Not Me.disposedValue Then
                    If disposing Then
                        ' TODO: dispose managed state (managed objects).
                    End If

                    ' Dispose ASM client.
                    If AsmClient IsNot Nothing Then
                        AsmClient.Dispose()
                    End If
                    ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                    ' TODO: set large fields to null.
                End If
                Me.disposedValue = True
            End Sub

            ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
            'Protected Overrides Sub Finalize()
            '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            '    Dispose(False)
            '    MyBase.Finalize()
            'End Sub

            ' This code added by Visual Basic to correctly implement the disposable pattern.
            Public Sub Dispose() Implements IDisposable.Dispose
                ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
                 Dispose(True)
                 GC.SuppressFinalize(Me)
            End Sub
         #End Region

         End Class
    	[/code]

Step 5. The UdpConvertMessageEvent inherits EventArgs class. It use to
        convert bytes to string and render them on page.
	    [code]
	    Public Property BufferMessage() As String
        Public Property EndPoint() As IPEndPoint

        ''' <summary>
        ''' Receive the message and render them in UI layer.
        ''' </summary>
        ''' <param name="dataMessage"></param>
        ''' <param name="endPoint"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal dataMessage As Byte(), ByVal endPoint As IPEndPoint)
            Me.BufferMessage = Encoding.UTF8.GetString(dataMessage, 0, dataMessage.Length)
            Me.EndPoint = endPoint
        End Sub
        [/code]  

Step 6. The UdpSingleSourceMulticastChannel class use to create SSM client
        and receive message from server application.
    	[code]
		Implements IDisposable
        Private SSMClient As UdpSingleSourceMulticastClient
        Private byteBuffer As Byte()
        Private serverIP As IPAddress
        Private targetIP As IPAddress
        Private port As Integer
        Private isJoinBroadcast As Boolean
        Public isReceived As Boolean
        Public Event AfterOpen As EventHandler
        Public Event BeforeReceived As EventHandler(Of UdpConvertMessageEvent)
        Public Event BeforeCloseSSM As EventHandler

        ''' <summary>
        ''' Constructor method. Define a buffer bytes variable,
        ''' server IP, group IP, port, and a SSM client.
        ''' </summary>
        ''' <param name="serverIP"></param>
        ''' <param name="targetIP"></param>
        ''' <param name="port"></param>
        ''' <param name="messageSize"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal serverIP As IPAddress, ByVal targetIP As IPAddress, ByVal port As Integer, ByVal messageSize As Integer)
            Me.serverIP = serverIP
            Me.targetIP = targetIP
            Me.port = port
            byteBuffer = New Byte(messageSize - 1) {}
            SSMClient = New UdpSingleSourceMulticastClient(serverIP, targetIP, port)
        End Sub

        ''' <summary>
        ''' Connect to SSM server method.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Open()
            If Me.isJoinBroadcast Then
                Return
            End If
            If SSMClient Is Nothing Then
                SSMClient = New UdpSingleSourceMulticastClient(serverIP, targetIP, port)
            End If
            Dim callBack As New AsyncCallback(AddressOf OpenCallBack)
            SSMClient.BeginJoinGroup(callBack, Nothing)
        End Sub

        Private Sub OpenCallBack(ByVal result As IAsyncResult)
            SSMClient.EndJoinGroup(result)
            Me.isJoinBroadcast = True
            Me.isReceived = True
            Deployment.Current.Dispatcher.BeginInvoke(AddressOf OpenInvoke)
        End Sub

        Private Sub OpenInvoke()
            RaiseEvent AfterOpen(Me, EventArgs.Empty)
            Me.Received()
        End Sub

        ''' <summary>
        ''' Receive message from ASM server method.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Received()
            Try
                If Not Me.isJoinBroadcast Then
                    Return
                End If
                If Not Me.isReceived Then
                    Return
                End If
                Array.Clear(byteBuffer, 0, byteBuffer.Length)
                Dim callBack As New AsyncCallback(AddressOf ReceiveCallBack)
                SSMClient.BeginReceiveFromSource(byteBuffer, 0, byteBuffer.Length, callBack, Nothing)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub ReceiveInvoke()
            RaiseEvent BeforeReceived(Me, New UdpConvertMessageEvent(byteBuffer, New IPEndPoint(serverIP, sourcePoint)))
            Me.Received()
        End Sub
        Dim sourcePoint As Integer
        Private Sub ReceiveCallBack(ByVal result As IAsyncResult)
            SSMClient.EndReceiveFromSource(result, sourcePoint)
            Deployment.Current.Dispatcher.BeginInvoke(AddressOf ReceiveInvoke)
        End Sub

        ''' <summary>
        ''' Close the connection event.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Close()
            Me.isJoinBroadcast = False
            RaiseEvent BeforeCloseSSM(Me, EventArgs.Empty)
            Dispose()
        End Sub



        #Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If
                If SSMClient IsNot Nothing Then
                    SSMClient.Dispose()
                    SSMClient = Nothing
                End If
                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
        #End Region
    	[/code]

Step 7. Add these code in your Demo.xaml.vb file:
        [code]
		Public udpSSMChannel As UdpSingleSourceMulticastChannel
        Public udpASMChannel As UdpAnySourceMulticastChannel

        Public Sub New()

            ' Initialize the UDP channel with resource files, There you can add 
            ' user-defined event for connect server, send or receive message.
            InitializeComponent()

            ' SSM(UdpSingleSourceMulticast) channel.
            udpSSMChannel = New UdpSingleSourceMulticastChannel(IPAddress.Parse(IPConfig.YourIP), IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.SSMLocalPort), 2048)
            AddHandler udpSSMChannel.AfterOpen, AddressOf AfterOpeningSSMEvent
            AddHandler udpSSMChannel.BeforeReceived, AddressOf BeforeReceivedSSMEvent
            AddHandler udpSSMChannel.BeforeCloseSSM, AddressOf BeforeCloseSSMEvent
            udpSSMChannel.Open()

            ' ASM(UdpAnySourceMulticast) channel.
            udpASMChannel = New UdpAnySourceMulticastChannel(IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.ASMLocalPort), 2048)
            AddHandler udpASMChannel.OpeningEvent, AddressOf OpeningASMEvent
            AddHandler udpASMChannel.ReceivedEvent, AddressOf ReceivedASMEvent
            AddHandler udpASMChannel.ClosingEvent, AddressOf ClosingASMEvent
            udpASMChannel.Open()

         End Sub

        'Executes when the user navigates to this page.
        Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)

        End Sub

        ' Connect ASM server event. 
        Private Sub OpeningASMEvent(ByVal obj As Object, ByVal e As EventArgs)
            lstAllMsg.Items.Insert(0, "Connect ASM server")
        End Sub

        ' Receive message from ASM server event.
        Private Sub ReceivedASMEvent(ByVal obj As Object, ByVal e As UdpConvertMessageEvent)
            Dim message As String = String.Format("{0} - Come from：{1}", e.BufferMessage.TrimEnd(ControlChars.NullChar), e.EndPoint.ToString())
            lstAllMsg.Items.Insert(0, message)
        End Sub
    
        ' Close ASM server event.
        Private Sub ClosingASMEvent(ByVal obj As Object, ByVal e As EventArgs)
            lstAllMsg.Items.Insert(0, "Disconnect ASM server")
        End Sub

        ' Connect SSM server event
        Private Sub AfterOpeningSSMEvent(ByVal obj As Object, ByVal e As EventArgs)
            lstAllMsg.Items.Insert(0, "Connect SSM server")
        End Sub

        ' Receive message from SSM server event.
        Private Sub BeforeReceivedSSMEvent(ByVal obj As Object, ByVal e As UdpConvertMessageEvent)
            Dim message As String = [String].Format("Come from {0} : {1}", e.EndPoint, e.BufferMessage)
            lstAllMsg.Items.Insert(0, message)
        End Sub

        ' Close SSM server event.
        Private Sub BeforeCloseSSMEvent(ByVal obj As Object, ByVal e As EventArgs)
            lstAllMsg.Items.Insert(0, "Disconnect SSM server")
        End Sub

        ''' <summary>
        ''' Send message from the client-side to other client-sides
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
             Dim strSendText As String = tbSendMessage.Text
             If strSendText.Trim() = [String].Empty Then
                 lstAllMsg.Items.Insert(0, "You can not send empty message")
                Return
             End If
             Dim sendMessage As String = [String].Format("The message {0}:", strSendText)
             udpASMChannel.Send(sendMessage)
        End Sub
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