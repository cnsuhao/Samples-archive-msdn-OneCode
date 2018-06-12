'***************************** Module Header ******************************\
' Module Name:    Common.vb
' Project:        VBASPNETPrivateMessagesModule
' Copyright (c) Microsoft Corporation
'
' This is the helper class
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/

Imports System.Configuration
Imports System.Data.SqlClient


Public Class Common
    'Sql connection.
    Public Shared ConnectionString As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ConnectionString

    ''' <summary>
    ''' Get UserName By ProviderUserKey
    ''' </summary>
    ''' <param name="id">ProviderUserKey</param>
    ''' <returns>UserName</returns>
    Public Shared Function getUserNameByProviderUserKey(id As String) As String
        ' UserName
        Dim strName As String = String.Empty

        ' Query string
        Dim queryString As String = "SELECT UserName FROM [aspnet_Users] where UserID=@id"

        '#Region "database Operation"
        Using connection As New SqlConnection(ConnectionString)
            Dim command As New SqlCommand(queryString, connection)
            Dim para2 As New SqlParameter("id", id)
            command.Parameters.Add(para2)
            connection.Open()
            Dim reader As SqlDataReader = command.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                strName = reader(0).ToString()
            End If
            reader.Close()
            connection.Close()
        End Using
        '#End Region

        Return strName
    End Function

    ''' <summary>
    ''' Get ProviderUserKey By UserName
    ''' </summary>
    ''' <param name="strName">UserName</param>
    ''' <returns>ProviderUserKey</returns>
    Public Shared Function getUserKeyByUserName(strName As String) As String
        ' ProviderUserKey
        Dim strUserKey As String = String.Empty

        ' Query string
        Dim queryString As String = "SELECT UserID FROM [aspnet_Users] where UserName=@Name"

        '#Region "database Operation"
        Using connection As New SqlConnection(ConnectionString)
            Dim command As New SqlCommand(queryString, connection)
            Dim para2 As New SqlParameter("Name", strName)
            command.Parameters.Add(para2)
            connection.Open()
            Dim reader As SqlDataReader = command.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                strUserKey = reader(0).ToString()
            End If
            reader.Close()
            connection.Close()
        End Using
        '#End Region

        Return strUserKey
    End Function

End Class