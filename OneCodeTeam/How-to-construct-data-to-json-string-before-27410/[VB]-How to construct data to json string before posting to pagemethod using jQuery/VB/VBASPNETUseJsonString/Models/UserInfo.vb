'***************************** Module Header ******************************\
' Module Name:	UserInfo.vb
' Project:		VBASPNETUseJsonString
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to post complex data to MVC server side using json string.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Public Class UserInfo
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = Value
        End Set
    End Property
    Private m_Name As String

    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(value As String)
            m_Email = Value
        End Set
    End Property
    Private m_Email As String
End Class
