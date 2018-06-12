'****************************** Module Header ******************************\
' Module Name:    AssociationData.vb
' Project:        VBSharePointReplicatorActivity
' Copyright (c) Microsoft Corporation
'
' This class is used to store Association Data.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

<Serializable()> _
Public Class AssociationData
    Private m_partners As Contacts = Nothing
    Public Property Partners() As Contacts
        Get
            Return Me.m_partners
        End Get
        Set(ByVal value As Contacts)
            Me.m_partners = value
        End Set
    End Property

    Private m_description As String = Nothing
    Public Property Description() As String
        Get
            Return Me.m_description
        End Get
        Set(ByVal value As String)
            Me.m_description = value
        End Set
    End Property

    Public Sub AddContact(ByVal contact As String)
        If Me.m_partners Is Nothing Then
            Me.m_partners = New Contacts()
        End If
        Me.m_partners.AddContact(contact)
    End Sub
    Public Function Getpartners() As String()
        Return Me.m_partners.ContactList.ToArray()
    End Function
End Class

<Serializable()> _
Public Class Contacts
    Private contacts As List(Of String)

    Public Property ContactList() As List(Of String)
        Get
            Return contacts
        End Get
        Set(ByVal value As List(Of String))
            contacts = value
        End Set
    End Property
    Public Sub AddContact(ByVal contact As String)
        If Me.contacts Is Nothing Then
            Me.contacts = New List(Of String)()
        End If
        Me.contacts.Add(contact)
    End Sub

End Class