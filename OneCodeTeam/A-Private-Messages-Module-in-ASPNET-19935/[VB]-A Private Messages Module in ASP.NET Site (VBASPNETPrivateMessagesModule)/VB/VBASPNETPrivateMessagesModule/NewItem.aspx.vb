'***************************** Module Header ******************************\
' Module Name:    NewItem.aspx.vb
' Project:        VBASPNETPrivateMessagesModule
' Copyright (c) Microsoft Corporation
'
' This page is used to reply or send new item
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/

Imports System.Web.Security
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient



Partial Public Class NewItem
    Inherits System.Web.UI.Page
    Dim rid As Integer = 0
    ' The message to reply
    Dim state As Integer = 1
    ' The status of the sent message 
    Dim strFrom As String = String.Empty
    ' fromuser
    Dim strTo As String = String.Empty
    ' touser
    Dim strTitle As String = String.Empty
    ' title
    Dim strContent As String = String.Empty
    ' content
    Dim strTime As String = String.Empty
    ' createtime
    Dim queryString As String = String.Empty
    ' Query string
    Dim command As SqlCommand = Nothing
    ' sql commmand
    Dim para1 As SqlParameter = Nothing
    ' SqlParameter
    Dim para2 As SqlParameter = Nothing
    ' SqlDataReader
    Dim reader As SqlDataReader = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not String.IsNullOrEmpty(Request.QueryString("rid")) Then
            rid = CInt(Request.QueryString("rid"))

            ' The flag of reply and reply all.
            Dim flag As String = Request.QueryString("flag")

            ' According to the flag, get the recipient list
            Select Case flag
                Case "1"
                    ' reply
                    GetBasicInfo()
                    strTo = Common.getUserNameByProviderUserKey(strFrom)
                    Exit Select
                Case "2"
                    ' replyall
                    GetBasicInfo()
                    GetReplyAllTo()
                    Exit Select
                Case Else
                    Exit Select
            End Select

            strContent = "From: " & Common.getUserNameByProviderUserKey(strFrom) & vbLf & "Sent: " _
            & strTime & vbLf & "To: " & strTo & vbLf & "Title: " & strTitle & vbLf & "Content: " & strContent

            strTitle = "Re:" & strTitle
        End If

        If Not IsPostBack Then
            BindUser()

            txtContent.Text = strContent
            txtTo.Text = strTo
            txtTitle.Text = strTitle
        End If
    End Sub

    ''' <summary>
    ''' Get recipient list of reply all
    ''' </summary>
    Private Sub GetReplyAllTo()
        Using connection As New SqlConnection(Common.ConnectionString)
            queryString = "SELECT ToUserId from MessageTable where CreateDate=@create and FromUserId=@FromUserId"
            command = New SqlCommand(queryString, connection)
            para1 = New SqlParameter("create", strTime)
            para2 = New SqlParameter("FromUserId", strFrom)
            command.Parameters.Clear()
            command.CommandText = queryString
            command.Parameters.Add(para1)
            command.Parameters.Add(para2)

            connection.Open()
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
    End Sub

    ''' <summary>
    ''' Get the basic infomation of the message
    ''' </summary>
    Private Sub GetBasicInfo()
        Dim currentUser As MembershipUser
        ' Current User
        currentUser = Membership.GetUser()

        ' Query string
        queryString = "SELECT [MessageID], [FromUserId], [ToUserId], [Message], [CreateDate]," _
            & " [MessageTitle], [State] FROM [MessageTable] " _
            & "where MessageID=@id and (ToUserId=@userid or FromUserId=@userid)"
        Using connection As New SqlConnection(Common.ConnectionString)
            command = New SqlCommand(queryString, connection)
            para1 = New SqlParameter("id", rid)
            para2 = New SqlParameter("userId", currentUser.ProviderUserKey)
            command.Parameters.Add(para1)
            command.Parameters.Add(para2)
            connection.Open()
            reader = command.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                strFrom = reader("FromUserId").ToString()
                strTitle = reader("MessageTitle").ToString()
                strContent = reader("Message").ToString()
                strTime = reader("CreateDate").ToString()
            End If
            reader.Close()
            connection.Close()
        End Using
    End Sub


    ''' <summary>
    ''' Get all MembershipUser
    ''' </summary>
    Private Sub BindUser()
        Dim muc As MembershipUserCollection = Membership.GetAllUsers()
        chlUser.DataSource = muc
        chlUser.DataBind()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim strTo As String = String.Empty

        ' Loop the users and add the selected user to recipient list
        For Each item As ListItem In Me.chlUser.Items
            If item.Selected Then
               strTo += ";" & item.Text
            End If
        Next

        If strTo.Length > 0 Then
            txtTo.Text = strTo.Substring(1)
        End If
    End Sub

    ' Send message
    Protected Sub btnEnter_Click(ByVal sender As Object, ByVal e As EventArgs)
        If IsValid Then
            SaveToDB()
        End If
    End Sub

    ''' <summary>
    ''' Save the message to Database 
    ''' </summary>
    Private Sub SaveToDB()
        Dim strSql As String = ""
        ' Get recipient list
        Dim tos As String() = txtTo.Text.Split(";"c)

        ' Save message for everyone in the recipient list
        For i As Integer = 0 To tos.Length - 1
            strSql += "insert into MessageTable(FromUserId,ToUserId,Message,MessageTitle,CreateDate,state)" _
          & " values('" & Membership.GetUser().ProviderUserKey.ToString() _
          & "','" & Common.getUserKeyByUserName(tos(i)) & "','" & txtContent.Text.Trim() _
          & "','" & txtTitle.Text.Trim() & "','" & DateTime.Now.ToString() & "'," & state & ");"
        Next

        Using connection As New SqlConnection(Common.ConnectionString)
            connection.Open()
            Dim tran As SqlTransaction = connection.BeginTransaction()
            Try

                Dim cmd As New SqlCommand(strSql, connection, tran)
                cmd.ExecuteNonQuery()
                tran.Commit()
            Catch e As Exception
                tran.Rollback()
            Finally
                connection.Close()
                Response.Redirect("messagelist.aspx?flag=2")
            End Try
        End Using
    End Sub


    ''' <summary>
    ''' save draft
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnDraft_Click(ByVal sender As Object, ByVal e As EventArgs)
        state = 0
        ' This is the value of draft
        SaveToDB()
    End Sub
End Class
