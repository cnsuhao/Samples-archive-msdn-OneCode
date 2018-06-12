'/**************************** Module Header ********************************\
'* Module Name:    Default.aspx
'* Project:        VBASPNETDetectBrowserCloseEvent
'* Copyright (c) Microsoft Corporation
'*
'* As we know, HTTP is a stateless protocol, the browser doesn't keep connecting
'* to the server. When user try to close the browser using alt-f4, browser close(X) 
'* and right click on browser and close -> this all is done and is working fine, 
'* it's not possible to tell the server that the browser is closed. The sample 
'* demonstrates how to detect the browser close event with iframe.
'
'* This page is used to display the current online client's clientID
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

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim client As New ClientInfo
        Dim clientList As List(Of ClientInfo) = CType(Application("ClientInfo"), List(Of ClientInfo))
        client = ClientInfo.GetClientInfoByClientInfo(clientList, Me.Session.SessionID)

        '' Update the ActiveTime
        client.ActiveTime = DateTime.Now

        For i As Integer = 0 To clientList.Count - 1
            Response.Write(CStr(clientList(i).ClientID))
            Response.Write("<br />")
        Next
    End Sub
End Class