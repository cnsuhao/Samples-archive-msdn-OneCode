'****************************** Module Header ******************************\
' Module Name:    Province.vb
' Project:        VBASPNETJqueryFilterLoadDynamicContent
' Copyright (c) Microsoft Corporation
'
' Province Data.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Public Class Province
    Public Property ProvinceName() As String
        Get
            Return m_ProvinceName
        End Get
        Set(ByVal value As String)
            m_ProvinceName = value
        End Set
    End Property
    Private m_ProvinceName As String
    Public Property PinYin() As String
        Get
            Return m_PinYin
        End Get
        Set(ByVal value As String)
            m_PinYin = value
        End Set
    End Property
    Private m_PinYin As String
    Public Property countryID() As String
        Get
            Return m_countryID
        End Get
        Set(ByVal value As String)
            m_countryID = value
        End Set
    End Property
    Private m_countryID As String
End Class