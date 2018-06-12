'****************************** Module Header ******************************\
' Module Name:  User.vb
' Project:      RESTfulWCFLibrary
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to access the WCF service via Access control
' service token. Here we create a Silverlight application and a normal Console 
' application client. The Token format is SWT, and we will use password as the 
' Service identities.
'
' This is the entity class.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Runtime.Serialization

<DataContract(Name:="User", [Namespace]:="")> _
Public Class User
    <DataMember(Name:="UserId", Order:=1)> _
    Public Property UserId() As String
        Get
            Return m_UserId
        End Get
        Set(value As String)
            m_UserId = value
        End Set
    End Property
    Private m_UserId As String

    <DataMember(Name:="FirstName", Order:=2)> _
    Public Property FirstName() As String
        Get
            Return m_FirstName
        End Get
        Set(value As String)
            m_FirstName = value
        End Set
    End Property
    Private m_FirstName As String


    <DataMember(Name:="LastName", Order:=3)> _
    Public Property LastName() As String
        Get
            Return m_LastName
        End Get
        Set(value As String)
            m_LastName = value
        End Set
    End Property
    Private m_LastName As String

End Class
