'***************************** Module Header ******************************\
' Module Name:    itemdetail.aspx.vb
' Project:        VBASPNETPrivateMessagesModule
' Copyright (c) Microsoft Corporation
'
' This Page is used to show the detail of the message
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/

Imports System.Data.SqlClient
Imports System.Web.Security


Partial Public Class itemdetail
    Inherits System.Web.UI.Page
    Private strFrom As String = String.Empty
    ' fromuser
    Private strTo As String = String.Empty
    ' touser
    Private strTitle As String = String.Empty
    ' title
    Private strContent As String = String.Empty
    ' content
    Private strTime As String = String.Empty
    ' createtime
    Private intId As Integer = 0
    ' messageid
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim currentUser As MembershipUser
        ' Current User
        currentUser = Membership.GetUser()

        If Not String.IsNullOrEmpty(Request.QueryString("ID")) Then
            intId = CInt(Request.QueryString("ID"))
            ' Query string
            Dim queryString As String = "SELECT [MessageID], [FromUserId], [ToUserId], [Message], " _
            & "[CreateDate], [MessageTitle], [State] FROM [MessageTable] " _
            & " where MessageID=@id and (ToUserId=@userid or FromUserId=@userid)"

            Using connection As New SqlConnection(Common.ConnectionString)
                ' sql command
                Dim command As New SqlCommand(queryString, connection)

                Dim para1 As New SqlParameter("id", intId)
                Dim para2 As New SqlParameter("userId", currentUser.ProviderUserKey)
                command.Parameters.Add(para1)
                command.Parameters.Add(para2)
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    strFrom = reader("FromUserId").ToString()
                    strTitle = reader("MessageTitle").ToString()
                    strContent = reader("Message").ToString()

                    strTime = reader("CreateDate").ToString()
                End If
                reader.Close()


                queryString = "SELECT ToUserId FROM MessageTable where CreateDate = @CreateDate" _
                & " AND FromUserId = @FromUserId"
                para1 = New SqlParameter("CreateDate", Convert.ToDateTime(strTime))
                para2 = New SqlParameter("FromUserId", DirectCast(strFrom, Object))
                command.Parameters.Clear()
                command.CommandText = queryString
                command.Parameters.Add(para1)
                command.Parameters.Add(para2)
                reader = command.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        strTo += ";" & Common.getUserNameByProviderUserKey(reader(0).ToString())
                    End While
                End If
                If strTo.Length > 0 Then
                    strTo = strTo.Substring(1)
                End If
                reader.Close()

                connection.Close()
            End Using
        End If

        ltrContent.Text = strContent
        ltrFrom.Text = Common.getUserNameByProviderUserKey(strFrom)
        ltrTo.Text = strTo
        ltrTime.Text = strTime
        ltrTitle.Text = strTitle
    End Sub

    Protected Sub btnReply_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("NewItem.aspx?flag=1&rid=" & intId)
    End Sub

    Protected Sub btnReplyAll_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("NewItem.aspx?flag=2&rid=" & intId)
    End Sub
End Class
