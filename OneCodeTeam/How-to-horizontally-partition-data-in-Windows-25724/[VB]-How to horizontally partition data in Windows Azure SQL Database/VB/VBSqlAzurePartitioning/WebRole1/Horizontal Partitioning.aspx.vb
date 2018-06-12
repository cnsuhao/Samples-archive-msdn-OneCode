'****************************** Module Header ******************************\
' Module Name:  Horizontal Partitioning.aspx.vb
' Project:      VBSqlAzurePartitioning
' Copyright (c) Microsoft Corporation.
' 
' We are using a hash base partitioning schema in this example – hashing on the 
' primary key of the row.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Data.SqlClient

Public Class Horizontal_Partitioning
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        If Not String.IsNullOrEmpty(tbAccountName.Text) Then
            InsertAccount(tbAccountName.Text)

            ' Refresh GridViews to update the account info.
            Me.GridView1.DataBind()
            Me.GridView2.DataBind()
        End If
    End Sub

    ''' <summary>
    ''' We use the primary key to calculate the connection string and the as well 
    ''' as a parameter to the SqlCommand.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Private Shared Function AccountName(id As Guid) As [String]
        Dim accountDataReader = SQLAzureHelper.ExecuteReader(SQLAzureHelper.ConnectionString(id), Function(sqlConnection)
                                                                                                      Dim sql As [String] = "SELECT [Name] FROM [Accounts] WHERE Id = @Id"
                                                                                                      Dim sqlCommand As New SqlCommand(sql, sqlConnection)
                                                                                                      sqlCommand.Parameters.AddWithValue("@Id", id)
                                                                                                      Return (sqlCommand.ExecuteReader())

                                                                                                  End Function)

        Return ((From row In accountDataReader
                 Select DirectCast(row("Name"), String)).FirstOrDefault())
    End Function

    ''' <summary>
    ''' When inserting a single row, we need to know the primary key before connecting to the database.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Private Shared Function InsertAccount(name As [String]) As Guid
        Dim id As Guid = Guid.NewGuid()

        SQLAzureHelper.ExecuteNonQuery(SQLAzureHelper.ConnectionString(id), Sub(sqlConnection)
                                                                                Dim sql As [String] = "INSERT INTO [Accounts] ([Id], [Name]) VALUES (@Id, @Name)"
                                                                                Dim sqlCommand As New SqlCommand(sql, sqlConnection)
                                                                                sqlCommand.Parameters.AddWithValue("@Name", name)
                                                                                sqlCommand.Parameters.AddWithValue("@Id", id)
                                                                                sqlCommand.ExecuteNonQuery()

                                                                            End Sub)

        Return (id)
    End Function
End Class