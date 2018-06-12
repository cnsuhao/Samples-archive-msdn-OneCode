'**************************** Module Header ******************************\
' Module Name: Program.vb
' Project:     VBSL4SocketProgrammingServer
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to use Socket achieve MultiCast function
' in Silverlight. We demonstrate ISM and SSM in this sample, The 
' application includes a console application as server side and a 
' Silverlight application as client side, the server will broadcast
' messages to client sides and client sides can also send messages 
' to other users.
'
' This class use to create a server.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************




Imports Microsoft.Silverlight.PolicyServers
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports VBSL4SocketProgrammingServer.My.Resources

Module Program
    ' Define UDP server and end point.
    Dim serverPoint As New IPEndPoint(IPAddress.Any, Convert.ToInt32(IPConfig.ServerIPPort))
    Dim broadcastPoint As New IPEndPoint(IPAddress.Broadcast, Convert.ToInt32(IPConfig.BroadcastIPPort))
    Public udpServer As New UdpClient(serverPoint)
    Sub Main()
        Console.WriteLine("=======================================" & vbCr & vbLf)
        Console.WriteLine("Silverlight Socket Programming Server" & vbCr & vbLf)
        Console.WriteLine("=======================================" & vbCr & vbLf)
        Console.WriteLine("Server start..")

        ' SSM server start.
        Dim configSSM As New MulticastPolicyConfiguration()
        configSSM.SingleSourceConfiguration.Add("*", New MulticastResource(IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.BroadcastIPPort)))
        Dim serverSSM As New MulticastPolicyServer(configSSM)
        serverSSM.Start()

        ' ASM server start.
        Dim configASM As New MulticastPolicyConfiguration()
        configASM.AnySourceConfiguration.Add("*", New MulticastResource(IPAddress.Parse(IPConfig.BroadcastIP), Convert.ToInt32(IPConfig.PolicyLocalPort)))
        Dim serverASM As New MulticastPolicyServer(configASM)
        serverASM.Start()

        ' Create a timer and invoke Send method.
        Dim timer = New System.Timers.Timer()
        timer.Interval = 1000.0
        AddHandler timer.Elapsed, AddressOf Send
        timer.Start()
        Console.WriteLine("Start complete.")
        Console.ReadKey()
    End Sub
    ''' <summary>
    ''' This method send broadcast messages every 1 seconds.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Send()
        Dim msg As String = String.Format("{0}: {1} - [{2}]", Dns.GetHostName(), " Send Message : My Time is", DateTime.Now.ToString("HH:mm:ss"))
        Dim data As Byte() = Encoding.UTF8.GetBytes(msg)

        Dim byteNumber As Integer = udpServer.Send(data, data.Length, broadcastPoint)
        Console.WriteLine([String].Format("The broadcast server have send {0} bytes message to clients.", byteNumber))
    End Sub


End Module
