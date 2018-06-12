'***************************** Module Header ******************************\
' Module Name: DownloadHttpHandler.ashx.vb
' Project:     VBASPNETResumeDownload
' Copyright (c) Microsoft Corporation
'
' This project demonstrates how to implement resume download feature in Asp.net.
' As we know, due to network interruptions, downloading a file is a problem when 
' the size of the file is large, we need to support resume download if the connection
' broken.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/

Imports System.Web

Public Class DownloadHttpHandler
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Dim filePath As String = ConfigurationManager.AppSettings("FilePath")
        VBASPNETResumeDownload.Downloader.DownloadFile(context, filePath)

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class