'****************************** Module Header ******************************\
' Module Name:    MessageList.aspx.vb
' Project:        VBASPNETPrivateMessagesModule
' Copyright (c) Microsoft Corporation
'
' This page is used to show the message list
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Imports System.Data.SqlClient

Partial Public Class MessageList
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim currentUser As MembershipUser = Membership.GetUser()     ' Current User

        Dim strFlag As String = Request.QueryString("flag")
        If Not IsPostBack Then
            ' Query string
            Dim queryString As String = "SELECT [MessageID], [FromUserId], [ToUserId], [Message], " _
            & "[CreateDate], [MessageTitle], [State] FROM [MessageTable]"

            ' The status field has two values, the normal message is 1 while a draft is 0.
            Select Case strFlag
                Case "0"
                    ' Draft
                    queryString += " where state=0 and FromUserId=@UserId"
                    Exit Select
                Case "1"
                    ' Inbox
                    queryString += " where state=1 and ToUserId=@UserId"
                    Exit Select
                Case "2"
                    ' Outbox
                    queryString += " where state=1 and FromUserId=@UserId"
                    Exit Select
                Case Else
                    Exit Select
            End Select

            If Not String.IsNullOrEmpty(strFlag) Then
                Dim adapter As New SqlDataAdapter()
                Dim sqlData As New DataSet()

                Using connection As New SqlConnection(Common.ConnectionString)
                    ' Set query string
                    adapter.SelectCommand = New SqlCommand(queryString, connection)
                    Dim para As New SqlParameter("UserId", currentUser.ProviderUserKey)
                    adapter.SelectCommand.Parameters.Add(para)

                    ' Open connection
                    connection.Open()

                    ' Sql data is stored DataSet.
                    adapter.Fill(sqlData, "MessageTable")

                    ' Close connection
                    connection.Close()
                End Using

                ' Bind datatable to GridView
                gdvView.DataSource = sqlData.Tables(0)
                gdvView.DataBind()

            End If
        End If
    End Sub

End Class

