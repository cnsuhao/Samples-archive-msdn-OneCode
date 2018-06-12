'****************************** Module Header ******************************\
' Module Name:  WebRoleRoute.vb
' Project:      VBAzureUrlRouting_WebRole
' Copyright (c) Microsoft Corporation.
'
' This sample demonstrates how to use URL routing in Azure application. 
' As we know, URL Routing is a common technology in ASP.NET and MVC applications, 
' customers also want to know how to migrate to the original project to Windows 
' Azure Platform. 
'
' The RouteHandler class receives URL parameters, and then checks if the folder 
' name is in specific namespace, and if the file path exists.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Web.Routing
Imports System.IO
Imports System.Web.Compilation

Public Class WebRoleRoute
    Implements IRouteHandler
    ''' <summary>
    ''' Check URLs from requests.
    ''' </summary>
    ''' <param name="requestContext"></param>
    ''' <returns></returns>
    Public Function GetHttpHandler(requestContext As RequestContext) As IHttpHandler Implements IRouteHandler.GetHttpHandler
        Dim root As String = requestContext.RouteData.Values("root").ToString().ToLower()
        Dim name As String = requestContext.RouteData.Values("name").ToString().ToLower()
        Dim directory As String = requestContext.RouteData.Values("directory").ToString().ToLower()
        Dim page As String = String.Format("~/{0}/{1}", directory, name)
        Dim xmlPath As String = requestContext.HttpContext.Server.MapPath("~/App_Data/Routing.xml")
        If Not IsInRoot(directory, root, xmlPath) Then
            Return TryCast(BuildManager.CreateInstanceFromVirtualPath("~/NoHandler.aspx", GetType(Page)), IHttpHandler)
        End If
        If File.Exists(requestContext.HttpContext.Server.MapPath(page)) Then
            Dim handler As IHttpHandler = TryCast(BuildManager.CreateInstanceFromVirtualPath(page, GetType(Page)), IHttpHandler)
            Return handler
        Else
            Return TryCast(BuildManager.CreateInstanceFromVirtualPath("~/NoHandler.aspx", GetType(Page)), IHttpHandler)
        End If
    End Function

    ''' <summary>
    ''' Check if the directory name is in root node (XML file).
    ''' </summary>
    ''' <param name="directory"></param>
    ''' <param name="root"></param>
    ''' <param name="xmlPath"></param>
    ''' <returns></returns>
    Private Function IsInRoot(directory As String, root As String, xmlPath As String) As Boolean
        Dim document As XDocument = XDocument.Load(xmlPath)
        Dim list = From e In document.Descendants(root).Descendants("add")
                   Where directory.Equals(e.Value)
                   Select e
        If list.Count() > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
