'**************************** Module Header ******************************\
' Module Name:  ImagesContext.vb
' Project:      VBSQLAzureStoreImages_WebRole
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to store images in Windows Azure SQL Server.
' This file includes the Context of Entity Framework.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Data.Entity


Public Class ImagesContext
    Inherits DbContext
    Public Property BlobImages() As DbSet(Of ImageInBlob)

    Public Property SQLAzureImages() As DbSet(Of ImageInSQLAzure)

    Public Property ImagesTable() As DbSet(Of ImagesTable)
End Class
