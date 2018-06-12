'**************************** Module Header ******************************\
' Module Name:  GetImage.ashx.vb
' Project:      VBSQLAzureStoreImages_WebRole
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to store images in Windows Azure SQL Server.
' We can use this class to get the images from SQL Azure and return to the client.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Linq

''' <summary>
''' Use it to get the images from SQL Azure.
''' </summary>
Public Class GetImage
    Implements IHttpHandler
    Private imagesDb As New ImagesContext()

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "image/jpeg"

        Dim imageId As Int32 = Int32.Parse(context.Request.QueryString("ImageId"))
        Dim image As ImagesTable = (
            From i In imagesDb.ImagesTable
            Where i.ImageId = imageId
            Select i).FirstOrDefault()
        If image IsNot Nothing Then
            context.Response.BinaryWrite(image.ImageData)
        Else
            context.Response.Write("No this Image")
        End If
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class
