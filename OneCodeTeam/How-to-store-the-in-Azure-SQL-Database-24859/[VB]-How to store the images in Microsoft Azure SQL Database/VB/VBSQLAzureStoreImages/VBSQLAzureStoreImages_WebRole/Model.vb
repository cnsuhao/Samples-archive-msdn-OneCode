'**************************** Module Header ******************************\
' Module Name:  Model.vb
' Project:      VBSQLAzureStoreImages_WebRole
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to store images in Windows Azure SQL Server.
' This file includes the model of Entity Framework.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.ComponentModel.DataAnnotations.Schema
Imports System.ComponentModel.DataAnnotations


''' <summary>
''' If we store the image in the blog, we will use this table to store 
''' the info of image and uri of Blob.
''' </summary>
Public Class ImageInBlob
    <Key()>
    Public Property ImageId() As Int32
    Public Property FileName() As String
    Public Property ImageName() As String
    Public Property Description() As String
    Public Property BlobUri() As String
End Class

''' <summary>
''' If we store the image in the SQL Azure, we will use this table to 
''' store the info of the image.
''' </summary>
Public Class ImageInSQLAzure
    <Key()>
    Public Property ImageId() As Int32
    Public Property FileName() As String
    Public Property ImageName() As String
    Public Property Description() As String
End Class

''' <summary>
''' If we store the image in the SQL Azure we will use this table to 
''' store the data of the image.
''' </summary>
Public Class ImagesTable
    <Key()>
    Public Property Id() As Int32

    <Column(TypeName:="image")>
    Public Property ImageData() As Byte()

    Public Property ImageId() As Int32
    <ForeignKey("ImageId")>
    Public Property ImageInfo() As ImageInSQLAzure
End Class
