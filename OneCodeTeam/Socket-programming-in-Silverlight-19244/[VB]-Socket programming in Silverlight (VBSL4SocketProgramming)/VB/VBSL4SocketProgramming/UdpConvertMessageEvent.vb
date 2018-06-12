'**************************** Module Header ******************************\
' Module Name: UdpConvertMessageEvent.vb
' Project:     VBSL4SocketProgramming
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to use Socket achieve MultiCast function
' in Silverlight. We demonstrate ISM and SSM in this sample, The 
' application includes a console application as server side and a 
' Silverlight application as client side, the server will broadcast
' messages to client sides and client sides can also send messages 
' to other users.
'
' This class inherits EventArgs class and render message on UI page.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************




Imports System.Text

Public Class UdpConvertMessageEvent
    Inherits EventArgs
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

End Class
