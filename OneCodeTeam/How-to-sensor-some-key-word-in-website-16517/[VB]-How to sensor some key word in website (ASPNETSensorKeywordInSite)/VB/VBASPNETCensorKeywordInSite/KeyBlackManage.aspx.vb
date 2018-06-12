'****************************** Module Header ******************************\
' Module Name:  KeyBlackManage.aspx.vb
' Project:      VBASPNETCensorKeywordInSite
' Copyright (c) Microsoft Corporation
'
' The page is used to manage blacklist.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.Data.SqlClient

Partial Public Class KeyBlackManage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindGrid()

    End Sub
    ' Sql connection.
    Shared connetionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
    Private connection As New SqlConnection(connetionString)

    ''' <summary>
    ''' Bind datatable to GridView
    ''' </summary>
    Private Sub BindGrid()
        ' Query string
        Dim queryString As String = "SELECT [Id], [Name] FROM [WordBlack]"
        Dim adapter As New SqlDataAdapter()

        ' set query string
        adapter.SelectCommand = New SqlCommand(queryString, connection)

        ' Open connection
        connection.Open()

        ' Sql data is stored DataSet.                 
        Dim sqlData As New DataSet()

        adapter.Fill(sqlData, "WordBlack")

        ' Close connection
        connection.Close()

        ' Bind datatable to GridView
        gdvKeyword.DataSource = sqlData.Tables(0)
        gdvKeyword.DataBind()
    End Sub

    ' database operation
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
        If IsValid Then
            Dim queryString As String = "Insert into [WordBlack](Name)values(@Keyword)"
            Dim para As New SqlParameter("Keyword", tbKey.Text.Trim())
            Dim command As New SqlCommand(queryString, connection)
            command.Parameters.Add(para)
            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()

            BindGrid()
        End If
    End Sub
End Class