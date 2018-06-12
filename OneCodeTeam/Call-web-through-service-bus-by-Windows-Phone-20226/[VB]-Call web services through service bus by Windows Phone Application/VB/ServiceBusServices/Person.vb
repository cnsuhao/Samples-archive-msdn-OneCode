'****************************** Module Header ******************************\
'Module Name:  Person.vb
'Project:      ServiceBusServices
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to expose an on-premise REST service to Internet
'via Service Bus, then you can access this service by Windows Phone application.
'The service includes normal string, generics and image methods.
'
'This is Person model class with some basic properties.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class Person
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property
    Private m_Name As String

    Public Property Comments() As String
        Get
            Return m_Comments
        End Get
        Set(value As String)
            m_Comments = value
        End Set
    End Property
    Private m_Comments As String
End Class
