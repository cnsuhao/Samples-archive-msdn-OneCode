'/**************************** Module Header ********************************\
'* Module Name:    ClientInfo.vb
'* Project:        VBASPNETDetectBrowserCloseEvent
'* Copyright (c) Microsoft Corporation
'*
'* As we know, HTTP is a stateless protocol, the browser doesn't keep connecting
'* to the server. When user try to close the browser using alt-f4, browser close(X) 
'* and right click on browser and close -> this all is done and is working fine, 
'* it's not possible to tell the server that the browser is closed. The sample 
'* demonstrates how to detect the browser close event with iframe.
'
'* This class is used as client's entity.
'* 
'
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'* All other rights reserved.
'* 
'* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/

Public Class ClientInfo

    Public Sub New()
    End Sub

    '' ClientID
    Private _clientID As String

    '' Last ActiveTime of the client
    Private _activeTime As DateTime

    '' Last RefreshTime of the iframe
    Private _refreshTime As DateTime

    Public Property ClientID() As String
        Get
            Return _clientID
        End Get
        Set(ByVal value As String)
            _clientID = value
        End Set
    End Property

    Public Property ActiveTime() As DateTime
        Get
            Return _activeTime
        End Get
        Set(ByVal value As DateTime)
            _activeTime = value
        End Set
    End Property

    Public Property RefreshTime() As DateTime
        Get
            Return _refreshTime
        End Get
        Set(ByVal value As DateTime)
            _refreshTime = value
        End Set
    End Property

    ''' <summary>
    ''' Search the client by clientID
    ''' </summary>
    ''' <param name="clientList">ClientList</param>
    ''' <param name="strClientID">ClientID</param>
    Public Shared Function GetClientInfoByClientInfo(ByVal clientList As List(Of ClientInfo), ByVal strClientID As String)
        For i As Integer = 0 To clientList.Count - 1
            If clientList(i).ClientID = strClientID Then
                Return clientList(i)
            End If
        Next
        Return New ClientInfo
    End Function
End Class
