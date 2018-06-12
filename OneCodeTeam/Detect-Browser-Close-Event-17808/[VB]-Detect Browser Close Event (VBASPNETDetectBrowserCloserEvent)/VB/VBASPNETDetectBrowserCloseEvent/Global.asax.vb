'/**************************** Module Header ********************************\
'* Module Name:    Global.asax
'* Project:        VBASPNETDetectBrowserCloseEvent
'* Copyright (c) Microsoft Corporation
'*
'* As we know, HTTP is a stateless protocol, the browser doesn't keep connecting
'* to the server. When user try to close the browser using alt-f4, browser close(X) 
'* and right click on browser and close -> this all is done and is working fine, 
'* it's not possible to tell the server that the browser is closed. The sample 
'* demonstrates how to detect the browser close event.
'
'* This class is used to detect the browser whether closed every three seconds.
'* And it will auto delete off-line client with iframe.
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

Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim timer As New Timers.Timer
        timer.Interval = 3000
        AddHandler timer.Elapsed, AddressOf timer_Elapsed
        timer.Start()
    End Sub

    ''' <summary>
    ''' Search the off-line client and delete it.
    ''' </summary>
    Sub timer_Elapsed(ByVal sender As Object, ByVal e As EventArgs)
        Dim client As New ClientInfo
        Dim clientList As List(Of ClientInfo) = CType(Application("ClientInfo"), List(Of ClientInfo))

        '' If the iframe is no refresh beyond 5 seconds 
        '' or the page has no active beyond 20 minutes,
        '' delete this client.
        For i As Integer = 0 To clientList.Count - 1
            If clientList(i).RefreshTime < DateTime.Now.AddSeconds(0 - 5) Or
                clientList(i).ActiveTime < DateTime.Now.AddMinutes(0 - 20) Then
                client = ClientInfo.GetClientInfoByClientInfo(clientList, clientList(i).ClientID)
                clientList.Remove(client)
            End If
        Next

        Application("ClientInfo") = clientList
    End Sub

    ''' <summary>
    ''' Add new client into Application
    ''' </summary>
    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        Application.Lock()
        Dim client As New ClientInfo

        '' If there are clients in Application
        If Application("ClientInfo") <> Nothing Then
            Dim clientList As List(Of ClientInfo) = CType(Application("ClientInfo"), List(Of ClientInfo))

            '' New client information
            client.ClientID = Me.Session.SessionID
            client.ActiveTime = DateTime.Now
            client.RefreshTime = DateTime.Now

            Dim flag As Boolean = False
            For Each clientInfo As ClientInfo In clientList
                '' If the client exist in clientList
                If clientInfo.ClientID = client.ClientID Then
                    flag = True
                    Exit For
                End If
            Next

            If flag = False Then
                clientList.Add(client)
                Application("ClientInfo") = clientList
            End If
        Else
            Dim clientList As New List(Of ClientInfo)
            client.ClientID = Me.Session.SessionID
            client.RefreshTime = DateTime.Now
            clientList.Add(client)
            Application("ClientInfo") = clientList
        End If

        Application.UnLock()
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class