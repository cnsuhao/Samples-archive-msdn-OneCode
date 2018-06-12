'****************************** Module Header ******************************\
' Module Name:  Default.aspx.vb
' Project:      VBASPNETDataListImageGallery
' Copyright (c) Microsoft Corporation.
'
' This module is used to show how to do a simple image gallery with a thumbnail 
' navigation bar using DataList. User can select a thumbnail image from DataList 
' to view the bigger one in main image. This can be implemented in some personal 
' space site, online shopping site and etc.
'
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Data

Partial Public Class _Default
    Inherits System.Web.UI.Page

    'Set page size
    Private _pageSize As Integer = 5

    'Property for current page index
    Public Property Page_Index() As Integer
        Get
            Return CInt(ViewState("_Page_Index"))
        End Get
        Set(ByVal value As Integer)
            ViewState("_Page_Index") = value
        End Set
    End Property

    'Property for total page count
    Public Property Page_Count() As Integer
        Get
            Return CInt(ViewState("_Page_Count"))
        End Get
        Set(ByVal value As Integer)
            ViewState("_Page_Count") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Initial page index
            Page_Index = 0

            'Set page count
            If (ImageCount() Mod _pageSize) = 0 Then
                Page_Count = ImageCount() \ _pageSize
                If Page_Count = 0 Then
                    lbnFirstPage.Enabled = False
                    lbnPrevPage.Enabled = False
                    lbnNextPage.Enabled = False
                    lbnLastPage.Enabled = False
                End If
            Else
                Page_Count = (ImageCount() \ _pageSize + 1)
            End If

            'Bind DataList
            DataList1.DataSource = BindGrid()
            DataList1.DataBind()

            'Disable two button for the initial page
            lbnFirstPage.Enabled = False
            lbnPrevPage.Enabled = False
        End If
    End Sub

    'Return the data source for DataList
    Protected Function BindGrid() As DataTable
        'Get all image paths             
        Dim di As New DirectoryInfo(Server.MapPath("Image/"))
        Dim fi As FileInfo() = di.GetFiles()

        'Save all paths to the DataTable as the data source
        Dim dt As New DataTable()
        Dim dc As New DataColumn("Url", GetType(System.String))
        dt.Columns.Add(dc)
        Dim lastindex As Integer = 0
        If Page_Count = 0 OrElse Page_Index = Page_Count - 1 Then
            lastindex = ImageCount()
        Else
            lastindex = Page_Index * _pageSize + 5
        End If
        For i As Integer = Page_Index * _pageSize To lastindex - 1
            Dim dro As DataRow = dt.NewRow()
            dro(0) = fi(i).Name
            dt.Rows.Add(dro)
        Next
        Return dt
    End Function

    'Return total number of images
    Protected Function ImageCount() As Integer
        Dim di As New DirectoryInfo(Server.MapPath("/Image/"))
        Dim fi As FileInfo() = di.GetFiles()
        Return fi.GetLength(0)
    End Function

    'Handle the navigation button event
    Public Sub Page_OnClick(ByVal sender As [Object], ByVal e As CommandEventArgs)
        If e.CommandName = "first" Then
            Page_Index = 0
            lbnFirstPage.Enabled = False
            lbnPrevPage.Enabled = False
            lbnNextPage.Enabled = True
            lbnLastPage.Enabled = True
        ElseIf e.CommandName = "prev" Then
            Page_Index -= 1
            If Page_Index = 0 Then
                lbnFirstPage.Enabled = False
                lbnPrevPage.Enabled = False
                lbnNextPage.Enabled = True
                lbnLastPage.Enabled = True
            Else
                lbnFirstPage.Enabled = True
                lbnPrevPage.Enabled = True
                lbnNextPage.Enabled = True
                lbnLastPage.Enabled = True
            End If
        ElseIf e.CommandName = "next" Then
            Page_Index += 1
            If Page_Index = Page_Count - 1 Then
                lbnFirstPage.Enabled = True
                lbnPrevPage.Enabled = True
                lbnNextPage.Enabled = False
                lbnLastPage.Enabled = False
            Else
                lbnFirstPage.Enabled = True
                lbnPrevPage.Enabled = True
                lbnNextPage.Enabled = True
                lbnLastPage.Enabled = True
            End If
        ElseIf e.CommandName = "last" Then
            Page_Index = Page_Count - 1
            lbnFirstPage.Enabled = True
            lbnPrevPage.Enabled = True
            lbnNextPage.Enabled = False
            lbnLastPage.Enabled = False
        End If

        DataList1.SelectedIndex = 0
        DataList1.DataSource = BindGrid()
        DataList1.DataBind()
        Image1.ImageUrl = DirectCast(DataList1.Items(0).FindControl("imgBtn"), Image).ImageUrl
    End Sub

    'Handle the thumbnail image selecting event
    Protected Sub imgBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim ib As ImageButton = DirectCast(sender, ImageButton)
        Image1.ImageUrl = ib.ImageUrl
        DataList1.SelectedIndex = Convert.ToInt32(ib.CommandArgument)
    End Sub

End Class