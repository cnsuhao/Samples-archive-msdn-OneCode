'***************************** Module Header ******************************\
'Module Name:  alertReceiver1.vb
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
Option Strict Off

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
Public Class alertReceiver1
    Inherits SPItemEventReceiver

    ''' <summary>
    ''' Send Email to topic owner while an item was added.
    ''' </summary>
    Public Overrides Sub ItemAdded(ByVal props As SPItemEventProperties)
        MyBase.ItemAdded(props)

        Try
            Dim list As SPList = props.OpenWeb().Lists(props.ListId)
            Dim collListItems As SPListItemCollection = list.GetItems()
            Dim headers As StringDictionary = AddAlertForDiscussionBoard.Helper.getHeaders()
            Dim taskListItems = (From tItem In list.Items Order By tItem.ID Ascending Select tItem).First()

            Dim spl As SPListItem = DirectCast(taskListItems, SPListItem)
            Dim spOwner As SPUser = AddAlertForDiscussionBoard.Helper.GetSPUserFromSPListItemByFieldName(spl, "Created By")

            AddAlertForDiscussionBoard.Helper.strMailto = spOwner.Email
            AddAlertForDiscussionBoard.Helper.strMailBody = "Send Email to topic owner"
            AddAlertForDiscussionBoard.Helper.SendEmail(SPContext.Current.Web)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class


