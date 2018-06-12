'****************************** Module Header ******************************\
' Module Name:  UserService.vb
' Project:      RESTfulWCFLibrary
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to access the WCF service via Access control
' service token. Here we create a Silverlight application and a normal Console 
' application client. The Token format is SWT, and we will use password as the 
' Service identities.
'
' This is the Service class that implements service interface.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class UserService
    Implements IUserService

    Private users As New List(Of User)()

    ''' <summary>
    ''' Add default users.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Dim user As New User()
        user.UserId = "1"
        user.FirstName = "Jim"
        user.LastName = "James"
        Dim user2 As New User()
        user2.UserId = "2"
        user2.FirstName = "Nancy"
        user2.LastName = "Wang"
        users.Add(user)
        users.Add(user2)
    End Sub

    ''' <summary>
    ''' Return all users.
    ''' </summary>
    ''' <param name="u"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddNewUser(u As User) As Boolean Implements IUserService.AddNewUser
        If Not users.Exists(Function(e) e.UserId = u.UserId) Then
            users.Add(u)
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Add a new user in user list.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllUsers() As System.Collections.Generic.List(Of User) Implements IUserService.GetAllUsers
        Return users
    End Function

    ''' <summary>
    ''' Get user info by id.
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUser(userId As String) As User Implements IUserService.GetUser
        If users.Exists(Function(e) e.UserId = userId) Then
            Return users.Find(Function(f) f.UserId = userId)
        Else
            Dim user As New User()
            user.UserId = ""
            Return user
        End If
    End Function
End Class
