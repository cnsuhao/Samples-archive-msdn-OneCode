'****************************** Module Header ******************************\
' Module Name:  UserEntity.vb
' Project:      AzureNTierWebRoleWithSession_WebRole
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to build a simple 3-tier Asp.net Web Role, 
' which uses Entity Framework (SQL Azure database) as the Data Access Layer. 
' This sample also shows how to implement a User Session Handling (With Azure Cache Service).
'
' This is a simple User entity class.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class UserEntity
    Public Property UserName() As String
        Get
            Return _userName
        End Get
        Set(value As String)
            _userName = value
        End Set
    End Property
    Private _userName As String

    Public Property PassWord() As String
        Get
            Return _passWord
        End Get
        Set(value As String)
            _passWord = value
        End Set
    End Property
    Private _passWord As String
End Class
