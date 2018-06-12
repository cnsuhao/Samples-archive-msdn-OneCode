'****************************** Module Header ******************************\
' Module Name:  PageStatusEventReceiver.vb
' Project:      VBSharePointSetPageStatus
' Copyright (c) Microsoft Corporation.
' 
' This sample will show you how to add page status to an application page
' and from list event receiver. 
' This is custom web part.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System
Imports System.Security.Permissions
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Utilities
Imports Microsoft.SharePoint.Workflow

Public Class PageStatusEventReceiver
    Inherits SPItemEventReceiver


    Private statusBarWebPart As StatusBarWebPart

    ''' <summary>
    ''' An item was added.
    ''' </summary>
    Public Overrides Sub ItemAdded(properties As SPItemEventProperties)
        MyBase.ItemAdded(properties)

        Dim web As SPWeb = properties.Web
        Dim oUrl As String = properties.List.DefaultViewUrl
        Dim coll As Microsoft.SharePoint.WebPartPages.SPLimitedWebPartManager = web.GetLimitedWebPartManager(oUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.[Shared])

        If coll.WebParts.Count > 1 Then
            statusBarWebPart = DirectCast(coll.WebParts(1), StatusBarWebPart)
            If statusBarWebPart IsNot Nothing Then
                statusBarWebPart.Message = "Item Added-vb"
                coll.SaveChanges(statusBarWebPart)
            End If
        Else
            statusBarWebPart = New StatusBarWebPart()
            statusBarWebPart.Message = "Item Added-vb"
            statusBarWebPart.Hidden = True
            coll.AddWebPart(statusBarWebPart, "Left", 1)
            coll.SaveChanges(statusBarWebPart)
        End If
    End Sub


    ''' <summary>
    ''' An item was updated.
    ''' </summary>
    Public Overrides Sub ItemUpdated(properties As SPItemEventProperties)
        MyBase.ItemUpdated(properties)

        Dim web As SPWeb = properties.Web
        Dim oUrl As String = properties.List.DefaultViewUrl
        Dim coll As Microsoft.SharePoint.WebPartPages.SPLimitedWebPartManager = web.GetLimitedWebPartManager(oUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.[Shared])

        If coll.WebParts.Count > 1 Then
            statusBarWebPart = DirectCast(coll.WebParts(1), StatusBarWebPart)
            If statusBarWebPart IsNot Nothing Then
                statusBarWebPart.Message = "Item Updated-vb"
                coll.SaveChanges(statusBarWebPart)
            End If
        Else
            statusBarWebPart = New StatusBarWebPart()
            statusBarWebPart.Message = "Item Updated-vb"
            statusBarWebPart.Hidden = True
            coll.AddWebPart(statusBarWebPart, "Left", 1)
            coll.SaveChanges(statusBarWebPart)
        End If
    End Sub

End Class
