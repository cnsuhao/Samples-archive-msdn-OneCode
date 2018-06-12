'***************************** Module Header ******************************\
'* Module Name:    Message.vb
'* Project:        VBWCFReverseAJAX
'* Copyright (c) Microsoft Corporation
'*
'* Message class contains all necessary fields in a message package.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
'* All other rights reserved.
'* 
'* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\****************************************************************************



''' <summary>
''' This is a entity class that represents a message item.
''' </summary>
Public Class Message
    ''' <summary>
    ''' The name who will receive this message.
    ''' </summary>
    Public Property RecipientName() As String
        Get
            Return m_RecipientName
        End Get
        Set(value As String)
            m_RecipientName = value
        End Set
    End Property
    Private m_RecipientName As String

    ''' <summary>
    ''' The message content.
    ''' </summary>
    Public Property MessageContent() As String
        Get
            Return m_MessageContent
        End Get
        Set(value As String)
            m_MessageContent = value
        End Set
    End Property
    Private m_MessageContent As String
End Class

