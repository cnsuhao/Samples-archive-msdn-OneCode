'****************************** Module Header ******************************\
' Module Name:  ItemModel.vb
' Project:      VBASPNETIntelligentErrorPage
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to create the intelligent error page in Asp.net 
' application. In this sample, we add a custom 404 error page and find the similar 
' local resources, then display them in error page. In this way, we will improve 
' the user-experience, since users don’t need to face a boring and helpless error 
' page any more.
'
' This class is the model of url path.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class ItemModel
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            m_Name = Value
        End Set
    End Property
    Private m_Name As String

    Public Property Category() As String
        Get
            Return m_Category
        End Get
        Set(ByVal value As String)
            m_Category = Value
        End Set
    End Property
    Private m_Category As String

    Public Property Url() As String
        Get
            Return m_Url
        End Get
        Set(ByVal value As String)
            m_Url = Value
        End Set
    End Property
    Private m_Url As String
End Class
