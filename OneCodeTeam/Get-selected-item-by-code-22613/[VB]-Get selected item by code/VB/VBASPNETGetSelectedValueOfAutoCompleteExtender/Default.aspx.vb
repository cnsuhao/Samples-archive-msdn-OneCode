'****************************** Module Header ******************************\
' Module Name:    Default.aspx.vb
' Project:        VBASPNETGetSelectedValueOfAutoCompleteExtender
' Copyright (c) Microsoft Corporation
'
' This demo shows how you can get selected item when you select an item from 
' list populated by AutoCompleteExtender at code behind.
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

Namespace VBASPNETGetSelectedValueOfAutoCompleteExtender
    Partial Public Class _Default
        Inherits System.Web.UI.Page
        ' Sql connection.
        Shared connetionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Private connection As New SqlConnection(connetionString)

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            BindGrid()
        End Sub

        ''' <summary>
        ''' Bind datatable to GridView
        ''' </summary>
        Private Sub BindGrid()
            ' Query string
            Dim queryString As String = "SELECT [Id], [Keywords], [Count] FROM [KeywordsStatistics]"
            Dim adapter As New SqlDataAdapter()

            ' set query string
            adapter.SelectCommand = New SqlCommand(queryString, connection)

            ' Open connection
            connection.Open()

            ' Sql data is stored DataSet.                 
            Dim sqlData As New DataSet()
            adapter.Fill(sqlData, "KeywordsStatistics")

            ' Close connection
            connection.Close()

            ' Bind datatable to GridView
            gdvKeyword.DataSource = sqlData.Tables(0)
            gdvKeyword.DataBind()
        End Sub

        ' database operation
        Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Get the selected value of the AutoCompleteExtender
            Dim hifvalue As String = hf1.Value

            Dim queryString As String = "SELECT id FROM [KeywordsStatistics] where Keywords=@Keyword"
            Dim para As New SqlParameter("Keyword", hifvalue)
            Dim command As New SqlCommand(queryString, connection)
            command.Parameters.Add(para)
            connection.Open()
            Dim reader As SqlDataReader = command.ExecuteReader()

            ' If there is a corresponding search record, update the statistics. Otherwise, add a new record.
            If reader.HasRows Then
                ' Update the statistics.
                queryString = "update KeywordsStatistics set Count=count+1 where Keywords=@Keyword"
            Else
                ' Add a new record.
                queryString = "Insert into [KeywordsStatistics](Keywords, Count)values(@Keyword,1)"
            End If
            reader.Close()
            command.CommandText = queryString
            command.ExecuteNonQuery()
            connection.Close()

            BindGrid()
        End Sub

    End Class
End Namespace