'/**************************** Module Header ********************************\
'* Module Name:    DetectBrowserClosePage.aspx
'* Project:        VBASPNETDetectBrowserCloseEvent
'* Copyright (c) Microsoft Corporation
'*
'* As we know, HTTP is a stateless protocol, the browser doesn't keep connecting
'* to the server. When user try to close the browser using alt-f4, browser close(X) 
'* and right click on browser and close -> this all is done and is working fine, 
'* it's not possible to tell the server that the browser is closed. The sample 
'* demonstrates how to detect the browser close event with iframe.
'
'* This page is used as an iframe for Default.aspx page. It will refresh per 
'* second to detect the browser whether closed.
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

Public Class DetectBrowserClosePage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim client As New ClientInfo
        Dim clientList As List(Of ClientInfo) = CType(Application("ClientInfo"), List(Of ClientInfo))
        client = ClientInfo.GetClientInfoByClientInfo(clientList, Me.Session.SessionID)

        '' Update the RefreshTime
        client.RefreshTime = DateTime.Now
    End Sub

End Class