'****************************** Module Header ******************************\
' Module Name:    PaginationWebPartUserControl.ascx.vb
' Project:        VBSharePointPaginationWebPart
' Copyright (c) Microsoft Corporation
'
' This sample code demonstrates how to implement Pagination through SPquery.
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

Partial Public Class PaginationWebPartUserControl
    Inherits UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            AddHandler btnNext.Click, AddressOf btnNext_Click
            AddHandler btnPre.Click, AddressOf btnPre_Click
            ' Get the default page data
            BindData(Nothing)
        End If
    End Sub

    ''' <summary>
    ''' Change the page no by the flag and then query the data based on the current page no
    ''' and binding. 
    ''' </summary>
    ''' <param name="strOperation">The flag for changing page:Pre=Pervious page,Next=next Page,null=Default page</param>
    Private Sub BindData(ByVal strOperation As String)
        ' Current Page No
        Dim intCurrentPageNo As Integer = 1

        If Not String.IsNullOrEmpty(strOperation) Then
            ' The Page count of
            Dim iPageCount As Integer = 0

            ' Store the PageNo and PageCount by ViewState.
            If ViewState("CurrentPageNo") IsNot Nothing Then
                intCurrentPageNo = Convert.ToInt32(ViewState("CurrentPageNo"))
            End If
            If ViewState("PageCount") IsNot Nothing Then
                iPageCount = Convert.ToInt32(ViewState("PageCount"))
                ViewState("PageCount") = iPageCount
            End If

            ' If the current page number is not greater than the total number of pages.
            If intCurrentPageNo <= iPageCount Then
                Select Case strOperation
                    Case "Pre" 'Pervious Page
                        If intCurrentPageNo > 1 Then
                            intCurrentPageNo = intCurrentPageNo - 1
                        End If
                        Exit Select
                    Case "Next" 'Next Page
                        intCurrentPageNo = intCurrentPageNo + 1
                        Exit Select
                    Case Else
                        Exit Select
                End Select
            End If
        End If

        ViewState("CurrentPageNo") = intCurrentPageNo

        ' Get current page's data and then bind to SPGridView
        Dim items As SPListItemCollection = GetListItems(5, intCurrentPageNo)
        GridView2.DataSource = items
        GridView2.DataBind()
    End Sub

    ''' <summary>
    '''  Get data by SPQuery
    ''' </summary>
    ''' <param name="rowlimit"></param>
    ''' <param name="pageNo">Current PageNO</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetListItems(ByVal rowlimit As Integer, ByVal pageNo As Integer) As SPListItemCollection
        ' your siteurl
        Dim SiteCollectionUrl As String = "http://localhost:7947"

        ' Connect to Sharepoint Site
        Using site As New SPSite(SiteCollectionUrl)
            ' Open Sharepoint Site
            Using oWebsiteRoot As SPWeb = site.OpenWeb()
                ' Get the list by list name
                Dim oList As SPList = oWebsiteRoot.Lists("test1")  'list_name

                ' Get the number of the items in the list
                Dim TotalListItems As Integer = oList.ItemCount

                ' Get the count of the page
                Dim iPageCount As Integer = CInt(Math.Ceiling(TotalListItems / CDec(rowlimit)))

                ViewState("PageCount") = iPageCount

                ' SPQuery
                Dim query As New SPQuery()
                query.RowLimit = CUInt(rowlimit)
                query.Query = "<OrderBy Override=""TRUE""><FieldRef Name=""FileLeafRef"" /></OrderBy>"

                Dim index As Integer = 1
                Dim items As SPListItemCollection

                Do
                    items = oList.GetItems(query)
                    If index = pageNo Then
                        Exit Do
                    End If
                    query.ListItemCollectionPosition = items.ListItemCollectionPosition
                    index += 1
                Loop While query.ListItemCollectionPosition IsNot Nothing

                Return items
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Previous Page
    ''' </summary>
    ''' <param name="sender">btnPre</param>
    ''' <param name="e">Click</param>
    ''' <remarks></remarks>
    Protected Sub btnPre_Click(ByVal sender As Object, ByVal e As EventArgs)
        BindData("Pre")
    End Sub

    ''' <summary>
    ''' Next page
    ''' </summary>
    ''' <param name="sender">btnNext</param>
    ''' <param name="e">Click</param>
    ''' <remarks></remarks>
    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs)
        BindData("Next")
    End Sub

End Class
