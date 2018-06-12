'***************************** Module Header ******************************\
'Module Name:  alertReceiver2.vb
'Project:      VBSharePointAddAlertForDiscussionBoard
'Copyright (c) Microsoft Corporation.
'
'The event of the EventReceiver.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\**************************************************************************
Option Explicit On
Option Strict On

Imports System.Security.Permissions
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Security
Imports Microsoft.SharePoint.Utilities
Imports Microsoft.SharePoint.Workflow
Imports System.Collections.Specialized
Imports System.Collections.Generic
Imports System.Linq

''' <summary>
''' List Item Events
''' </summary>
Public Class alertReceiver2
    Inherits SPItemEventReceiver
    ''' <summary>
    ''' Send Email to the topic owner and all those who replied/commented while an item was added.
    ''' </summary>
    Public Overrides Sub ItemAdded(ByVal props As SPItemEventProperties)
        MyBase.ItemAdded(props)

        Try
            Dim list As SPList = props.OpenWeb().Lists(props.ListId)
            Dim collListItems As SPListItemCollection = list.GetItems()
            Dim headers As StringDictionary = AddAlertForDiscussionBoard.Helper.getHeaders()

            For Each oListItem As SPListItem In collListItems
                Dim spu As SPUser = AddAlertForDiscussionBoard.Helper.GetSPUserFromSPListItemByFieldName(oListItem, "Created By")
                AddAlertForDiscussionBoard.Helper.strMailto = ";" + spu.Email
            Next

            AddAlertForDiscussionBoard.Helper.strMailBody = "Send Email to the topic owner and all those who replied/commented"
            AddAlertForDiscussionBoard.Helper.strMailto = AddAlertForDiscussionBoard.Helper.strMailto.Substring(1)
            AddAlertForDiscussionBoard.Helper.SendEmail(SPContext.Current.Web)
        Catch e As Exception
            Throw e
        End Try
    End Sub
End Class

