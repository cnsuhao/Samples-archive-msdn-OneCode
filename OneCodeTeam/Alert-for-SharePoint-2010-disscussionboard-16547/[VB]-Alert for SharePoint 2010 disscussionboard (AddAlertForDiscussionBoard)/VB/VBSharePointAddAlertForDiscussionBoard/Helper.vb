'***************************** Module Header ******************************\
'Module Name:  Helper.vb
'Project:      VBSharePointAddAlertForDiscussionBoard
'Copyright (c) Microsoft Corporation.
'
'The helper class of the feature.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\**************************************************************************


Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections.Specialized
Imports Microsoft.SharePoint.Utilities
Imports Microsoft.SharePoint

Namespace AddAlertForDiscussionBoard
    Friend Class Helper
        ''' <summary>
        ''' The name-value pairs for header fields.
        ''' </summary>
        ''' <returns>StringDictionary</returns>
        Friend Shared Function getHeaders() As StringDictionary
            Dim headers As New StringDictionary()
            headers.Add("Cc", "")
            headers.Add("Bcc", "")
            headers.Add("From", "seiya1223@hotmail.com")
            headers.Add("To", strMailto)
            headers.Add("subject", "New reply")
            headers.Add("content-type", "text/html")
            Return headers
        End Function

        Friend Shared strMailto As String = String.Empty
        Friend Shared strMailBody As String = String.Empty

        ''' <summary>
        ''' Send Email
        ''' </summary>
        ''' <param name="spWeb"></param>
        Friend Shared Sub SendEmail(ByVal spWeb As SPWeb)
            If strMailto.Length > 0 AndAlso spWeb IsNot Nothing Then
                SPUtility.SendEmail(spWeb, getHeaders(), strMailBody)
            End If
        End Sub

        ''' <summary>
        ''' Processing SPListItem, get this object "Created By" (creator), and return SPUser type
        ''' </summary>
        ''' <param name="spItem">SPListItem</param>
        ''' <param name="fieldName">FieldName,it is "Created By" here</param>
        ''' <returns>SPUser</returns>
        Friend Shared Function GetSPUserFromSPListItemByFieldName(ByVal spItem As SPListItem, ByVal fieldName As String) As SPUser
            Dim userName As String = spItem(fieldName).ToString()
            Dim _user As SPFieldUser = DirectCast(spItem.Fields(fieldName), SPFieldUser)
            Dim userValue As SPFieldUserValue = DirectCast(_user.GetFieldValue(userName), SPFieldUserValue)
            Return userValue.User
        End Function
    End Class
End Namespace