'***************************** Module Header ******************************\
' Module Name:	products.vb
' Project:		VBAzureACSWithWebAPI
' Copyright (c) Microsoft Corporation.
' 
' Secure Web API is a hot topic in asp.net forum.
' This sample will show you how to use Azure ACS secure the web API.
' It will require you sign in with Live ID/Google/Yahoo/Live connect account 
' first before you use the web API.
'
' Product model
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Public Class Product
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set(value As Integer)
            m_Id = value
        End Set
    End Property
    Private m_Id As Integer
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property
    Private m_Name As String
    Public Property Category() As String
        Get
            Return m_Category
        End Get
        Set(value As String)
            m_Category = value
        End Set
    End Property
    Private m_Category As String
    Public Property Price() As Decimal
        Get
            Return m_Price
        End Get
        Set(value As Decimal)
            m_Price = value
        End Set
    End Property
    Private m_Price As Decimal
End Class