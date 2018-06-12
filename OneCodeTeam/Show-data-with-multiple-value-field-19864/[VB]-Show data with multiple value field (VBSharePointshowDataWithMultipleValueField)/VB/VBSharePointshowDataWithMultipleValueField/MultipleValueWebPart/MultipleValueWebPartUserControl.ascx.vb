'****************************** Module Header ******************************\
' Module Name:    MultipleValueWebPart.ascx.vb
' Project:        VBSharePointshowDataWithMultipleValueField
' Copyright (c) Microsoft Corporation
'
' This demo will show how to get data with multiple value field in a site collection.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/


Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports Microsoft.Office.Server.Search.Query
Imports Microsoft.SharePoint.WebControls

Partial Public Class MultipleValueWebPartUserControl
    Inherits UserControl

    ''' <summary>
    ''' Page_Load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Bind data to GridView
        MyGridView.DataSource = GetFTSQueryItems()
        MyGridView.DataBind()
    End Sub

    ''' <summary>
    ''' Using FullTextSqlQuery to get Items
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFTSQueryItems() As DataTable
        ' Create a DataTable to store data
        Dim results As New DataTable()

        ' The web site's URL
        Dim url As String = SPContext.Current.Web.Url

        ' Query text
        Dim queryText As String = "SELECT Title,AssignedTo,LastModifiedTime FROM SCOPE()"

        ' Open the site
        Using site As New SPSite(url)
            ' Create a new FullTextSqlQuery class - use property initializers to set query
            Dim fts As New FullTextSqlQuery(site)
            fts.QueryText = queryText
            fts.ResultTypes = ResultType.RelevantResults
            fts.RowLimit = 300

            ' Execute the query and load the results into the datatable
            Dim rtc As ResultTableCollection = fts.Execute()
            If rtc.Count > 0 Then
                Using relevantResults As ResultTable = rtc(ResultType.RelevantResults)
                    results.Load(relevantResults, LoadOption.OverwriteChanges)
                End Using
            End If

            Return results
        End Using
    End Function

    ''' <summary>
    ''' Bind the value of multiple value field (user-multi field in this sample) to SPGridView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub SPGridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' The control will be used to show the multiple value field's value
            Dim gdvPeople As SPGridView = TryCast(e.Row.Cells(1).FindControl("gdvPeople"), SPGridView)

            ' A string array to store the multiple value field
            Dim userName As String() = Nothing

            ' Handle while the multiple value field's value is not null. 
            If Not (TypeOf (DataBinder.Eval(e.Row.DataItem, "AssignedTo")) Is DBNull) Then
                userName = DirectCast(DataBinder.Eval(e.Row.DataItem, "AssignedTo"), String())
            End If

            ' Create a table to store the multiple value field's value 
            Dim tblUserName As New DataTable()
            tblUserName.Columns.Add("Uname")

            If userName IsNot Nothing Then
                Dim url As String = SPContext.Current.Web.Url

                Using site As New SPSite(url)
                    ' Deal with the multiple value field's value
                    For Each item As String In userName
                        If item.Contains("#") Then
                            Dim arrayUser As String() = item.Split(";"c)

                            Dim i As Integer = 0
                            While i < arrayUser.Length
                                tblUserName.Rows.Add(arrayUser(i).Replace("#"c, " "c).Trim())
                                i = i + 2
                            End While
                        Else
                            ' add username to datatable
                            tblUserName.Rows.Add(item)
                        End If
                    Next
                End Using

                If tblUserName.Rows.Count > 0 Then
                    gdvPeople.DataSource = tblUserName
                Else
                    SetVisible(gdvPeople)
                End If
            Else
                SetVisible(gdvPeople)
            End If

            gdvPeople.DataBind()
        End If
    End Sub

    ''' <summary>
    ''' Sets a value that indicates whether the SPGridView is rendered
    ''' </summary>
    ''' <param name="gdvPeople"></param>
    Private Shared Sub SetVisible(gdvPeople As SPGridView)
        gdvPeople.DataSource = Nothing
        gdvPeople.Visible = False
    End Sub

End Class
