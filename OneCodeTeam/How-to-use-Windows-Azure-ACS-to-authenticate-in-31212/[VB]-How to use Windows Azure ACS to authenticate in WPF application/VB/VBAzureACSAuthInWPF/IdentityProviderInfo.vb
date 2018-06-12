'***************************** Module Header ******************************\
' Module Name:	IdentityProviderInfo.vb
' Project:		VBAzureACAuthInWPF
' Copyright (c) Microsoft Corporation.
' 
' This sample shows:
' how to do authentication based on Azure Access control service(ACS).
' how to use ACS to secure your WCF service.
' 
' Store IDP infos we need.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Public Class IdentityProviderInfo
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property
    Private m_Name As String
    Public Property LoginUrl() As String
        Get
            Return m_LoginUrl
        End Get
        Set(value As String)
            m_LoginUrl = value
        End Set
    End Property
    Private m_LoginUrl As String
End Class