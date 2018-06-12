'****************************** Module Header ******************************\
' Module Name: SearchEngine.aspx.vb
' Project:     VBASPNETDisplayDataStreamResource
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to display the data stream from Internet resource
' and site resource in a web page. Customers want to know how to display the 
' title, content or other information of web pages. Thus, the sample can search
' the target web page which you input url address in TextBox control and get all
' relative link resources of it. 
' 
' The page is used to display relative web pages by key words.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/



Imports System.IO
Imports System.Net

Public Class DisplayResource
    Inherits System.Web.UI.Page
    Private webResources As WebPageEntity
    Public publicTable As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

 ''' <summary>
    ''' The method is used to load resource by specific web pages.
    ''' </summary>
    Public Sub LoadLink(ByVal url As String)
        Dim method As New RegexMethod()
        webResources = New WebPageEntity()
        SyncLock Me
            Dim result As String = Me.LoadResource(url)
            Dim webEntity As New WebPageEntity()
            webEntity.Name = Path.GetFileName(url)
            webEntity.Link = method.GetLinks(result, url)
            webEntity.Content = result
            webResources = webEntity
        End SyncLock
        Dim builder As New StringBuilder()
        builder.Append("<table>")
        For i As Integer = 0 To webResources.Link.Count - 1
            builder.Append("<tr><td><a href='" & webResources.Link(i).ToString() & "'>")
            builder.Append(webResources.Link(i).ToString())
            builder.Append("</a></td></tr>")
        Next
        builder.Append("</table>")
        publicTable = builder.ToString()
    End Sub

    ''' <summary>
    ''' Use HttpWebRequest, HttpWebResponse, StreamReader for retrieving
    ''' information of pages, and calling Regex methods to get useful 
    ''' information.
    ''' </summary>
    ''' <param name="url"></param>
    ''' <returns></returns>
    Public Function LoadResource(ByVal url As String) As String
        Dim webResponse As HttpWebResponse = Nothing
        Dim reader As StreamReader = Nothing
        Try
            Dim webRequest__1 As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
            webRequest__1.Timeout = 30000
            webResponse = DirectCast(webRequest__1.GetResponse(), HttpWebResponse)
            Dim resource As String = [String].Empty
            If webResponse Is Nothing Then
                Return String.Empty
            ElseIf webResponse.StatusCode <> HttpStatusCode.OK Then
                Return String.Empty
            Else
                reader = New StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding("utf-8"))
                resource = reader.ReadToEnd()
                Return resource
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            If webResponse IsNot Nothing Then
                webResponse.Close()
            End If
            If reader IsNot Nothing Then
                reader.Close()
            End If
        End Try
    End Function

    ''' <summary>
    ''' The search button click event is used to compare key words and 
    ''' page resources for selecting relative pages. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnSearchPage_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tbKeyWord.Text.Trim() <> String.Empty Then
            If RegexMethod.IsUrl(tbKeyWord.Text.Trim()) Then
                Me.LoadLink(tbKeyWord.Text.Trim())
            Else
                Response.Write("Url address is not valid")
            End If
        Else
            Response.Write("Url address can not be null.")
        End If

    End Sub
End Class