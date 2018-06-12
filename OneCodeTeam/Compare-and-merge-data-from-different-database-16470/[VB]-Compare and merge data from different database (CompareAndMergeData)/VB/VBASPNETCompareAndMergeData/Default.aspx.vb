'****************************** Module Header ******************************\
' Module Name:    Default.aspx.vb
' Project:        VBASPNETCompareAndMergeData
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to compare and merge data which from different 
' datasources. In this sample, we store some data in xml file and SQL Server 
' database respectively. We need to compare the data from different datasources 
' and display the columns with one GridView Control. If the records ID are equal 
' we need to set the status column as "ok". Otherwise the status column should 
' be set as "null". When we display the columns from different datasources we 
' may need to merge the datasets in order to bind to GridView Control.
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

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Sql connection
        Dim connString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Books.mdf;Integrated Security=True;User Instance=True"
        ' Path of xml.
        Dim filePath As String = Server.MapPath("Book.xml")

        ' Sql DataSource
        Dim connection As New SqlConnection(connString)
        Dim queryString As String = "select * from bookData"
        Dim adapter As New SqlDataAdapter()
        adapter.SelectCommand = New SqlCommand(queryString, connection)

        ' Open connection
        connection.Open()

        ' Fill Sql data in DataSet.
        Dim sqlData As New DataSet()
        adapter.FillSchema(sqlData, SchemaType.Source, "BookData")
        adapter.Fill(sqlData, "BookData")

        ' Close connection
        connection.Close()

        ' Fill xml data in DataSet.
        Dim xmlData As New DataSet()
        xmlData.ReadXml(filePath)
        xmlData.AcceptChanges()

        ' A column is used to store compare state.
        xmlData.Tables(0).Columns.Add("CompareState")

        ' Declare a table to hold Xml data.
        Dim dtXml As DataTable = xmlData.Tables(0)

        ' Declare a table to hold Sql data.
        Dim dtSql As DataTable = sqlData.Tables(0)

        ' The table is used to store Merged data.
        Dim dtXmlTemp As DataTable = dtXml.Clone()

        ' Copy dtXml data to dtXmlTemp.
        For Each row As DataRow In dtXml.Rows
            dtXmlTemp.ImportRow(row)
        Next

        ' Compare and merge operations

        ' Loop all rows of the sql table and xml table.
        ' If the ISBN in the dtXml is equal to the ISBN in dtSql we can merge the two records and 
        ' set CompareState as "OK", Otherwise we can add the null value to the records in dtXml. 
        For Each dr1 As DataRow In dtXml.Rows
            For Each dr2 As DataRow In dtSql.Rows
                If dr1(0).ToString().Equals(dr2(0).ToString()) Then
                    ' Compare the ISBN
                    ' Get the index of current row, then update the CompareState in the copy of dtXml(dtXmlTemp).
                    Dim intIndex As Integer = dtXml.Rows.IndexOf(dr1)
                    ' Set CompareState value
                    dtXmlTemp.Rows(intIndex)(5) = "OK"
                Else
                    ' Add record to dtXmlTemp and add a "null" flag.
                    Dim drNew As DataRow = dtXmlTemp.NewRow()
                    drNew("ISBN") = dr2("ISBN")
                    drNew("CompareState") = "null"

                    ' Add a new row if the table does not has duplicate rows.
                    If IsNotExist(drNew, dtXmlTemp) Then
                        dtXmlTemp.Rows.Add(drNew)
                    End If
                End If
            Next
        Next

        ' This is a merger in the system
        ' sqlData.Merge(xmlData, true, MissingSchemaAction.AddWithKey);

        ' Bind datatable to GridView
        gdvData.DataSource = dtXmlTemp
        gdvData.DataBind()
    End Sub


    ''' <summary>
    ''' Loop all rows of the specified table to determine whether the row exists, remove duplicate rows.
    ''' </summary>
    ''' <param name="drNew">The row to be determined.</param>
    ''' <param name="dtXmlTemp">The specified table</param>
    ''' <returns>true means do not exist</returns>
    Private Function IsNotExist(ByVal drNew As DataRow, ByVal dtXmlTemp As DataTable) As Boolean
        Dim _isNotExist As Boolean = True

        For Each dr As DataRow In dtXmlTemp.Rows
            If dr(0).ToString().Equals(drNew(0).ToString()) Then
                _isNotExist = False
                Exit For
            End If
        Next
        Return _isNotExist
    End Function
End Class