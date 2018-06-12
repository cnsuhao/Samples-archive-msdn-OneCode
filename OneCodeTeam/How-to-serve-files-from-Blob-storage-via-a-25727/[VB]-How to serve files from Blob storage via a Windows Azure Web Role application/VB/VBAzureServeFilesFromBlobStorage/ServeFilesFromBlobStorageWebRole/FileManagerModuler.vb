'****************************** Module Header ******************************\
' Module Name:  FileManagerModuler.vb
' Project:      ServeFilesFromBlobStorageWebRole
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates a way to serve files from storage via a web role.
' A file from blob storage (such as http://xxx.cloudapp.net/files/File1) can be 
' reached as the normal files in your application by relative path ("files/File1"). 
' And this http module can also filter some files of specific types. 
'
' An HttpModule runs before every http request is processed to check the types of 
' requested files. In this sample, you can access .aspx, .jpg and .css files, 
' other requests will be thrown into NoHandler.aspx page. If you want to add more 
' types, please try to add them into GetContentType method.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports TableStorageManager

Public Class FileManagerModuler
    Implements IHttpModule

    Public Sub Dispose() Implements IHttpModule.Dispose

    End Sub

    Public Sub Init(context As HttpApplication) Implements IHttpModule.Init
        AddHandler context.BeginRequest, AddressOf Me.Application_BeginRequest
    End Sub

    ''' <summary>
    ''' Check file types and request it by cloud blob API.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    Private Sub Application_BeginRequest(source As [Object], e As EventArgs)
        Dim url As String = HttpContext.Current.Request.Url.ToString()
        Dim fileName As String = url.Substring(url.LastIndexOf("/"c) + 1).ToString()
        Dim extensionName As String = String.Empty
        If fileName.Substring(fileName.LastIndexOf("."c) + 1).ToString().Equals("aspx") Then
            Return
        End If

        If Not fileName.Equals(String.Empty) Then
            extensionName = fileName.Substring(fileName.LastIndexOf("."c) + 1).ToString()
            If Not extensionName.Equals(String.Empty) Then
                Dim contentType As String = Me.GetContentType(fileName)
                If contentType.Equals(String.Empty) Then
                    HttpContext.Current.Server.Transfer("NoHandler.aspx")
                End If


                If True Then
                    Dim dataSource As New FileDataSource()
                    Dim paritionKey As String = Me.GetPartitionName(extensionName)
                    If [String].IsNullOrEmpty(paritionKey) Then
                        HttpContext.Current.Server.Transfer("NoHandler.aspx")
                    End If
                    Dim entity As FileEntity = dataSource.GetEntitiesByName(paritionKey, "Files/" & fileName)
                    If entity IsNot Nothing Then
                        HttpContext.Current.Response.Redirect(entity.FileUrl)
                    Else
                        HttpContext.Current.Server.Transfer("NoResources.aspx")
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Get file's Content-Type.
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    Public Function GetContentType(filename As String) As String
        Dim res As String = String.Empty

        Select Case filename.Substring(filename.LastIndexOf("."c) + 1).ToString().ToLower()
            Case "jpg"
                res = "image/jpg"
                Exit Select
            Case "css"
                res = "text/css"
                Exit Select
        End Select

        Return res
    End Function

    ''' <summary>
    ''' Get file's partitionKey.
    ''' </summary>
    ''' <param name="extensionName"></param>
    ''' <returns></returns>
    Public Function GetPartitionName(extensionName As String) As String
        Dim partitionName As String = String.Empty
        Select Case extensionName
            Case "jpg"
                partitionName = "image"
                Exit Select
            Case "css"
                partitionName = "css"
                Exit Select
        End Select
        Return partitionName
    End Function
End Class
