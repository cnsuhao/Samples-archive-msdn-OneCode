'****************************** Module Header ******************************\
' Module Name:  Default.aspx.vb
' Project:      VBAzureUrlRouting_WebRole
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to use URL routing in Azure application. 
' As we know, URL Routing is a common technology in ASP.NET and MVC applications, 
' customers also want to know how to migrate to the original project to Windows 
' Azure Platform. 
'
' This page is used to add some test URLs for testing.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class _Default
    Inherits System.Web.UI.Page
    Public FilePath As String

    ''' <summary>
    ''' Add test links on Default.aspx page.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim requestString As String = Request.Url.AbsoluteUri
        Dim serviceUrl As String = requestString.Substring(0, (requestString.LastIndexOf("/"c) + 1))

        Dim sb As New StringBuilder()
        sb.Append(String.Format("<a href='{0}'>page1</a> <br />", serviceUrl & "page/pageresources/page1.aspx"))
        sb.Append(String.Format("<a href='{0}'>page2</a> <br />", serviceUrl & "page/pageresources/page2.aspx"))
        sb.Append(String.Format("<a href='{0}'>page3</a> <br />", serviceUrl & "page/pageresources2/page3.aspx"))
        sb.Append(String.Format("<a href='{0}'>page4</a> <br />", serviceUrl & "page/pageresources2/page4.aspx"))
        sb.Append(String.Format("<a href='{0}'>sample1</a> <br />", serviceUrl & "sample/sample/sample1.aspx"))
        sb.Append(String.Format("<a href='{0}'>sample2</a> <br />", serviceUrl & "sample/sample/sample2.aspx"))
        FilePath = sb.ToString()
    End Sub

End Class