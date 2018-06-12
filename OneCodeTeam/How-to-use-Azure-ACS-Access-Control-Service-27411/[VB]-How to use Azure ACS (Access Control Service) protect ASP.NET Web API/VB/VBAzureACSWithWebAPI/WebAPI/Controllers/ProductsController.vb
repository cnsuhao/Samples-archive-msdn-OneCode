'***************************** Module Header ******************************\
' Module Name:	ProductsController.vb
' Project:		VBAzureACSWithWebAPI
' Copyright (c) Microsoft Corporation.
' 
' Secure Web API is a hot topic in asp.net forum.
' This sample will show you how to use Azure ACS secure the web API.
' It will require you sign in with Live ID/Google/Yahoo/Live connect account 
' first before you use the web API.
'
' ProductsController
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports System.Web.Http
Imports System.Net

Public Class ProductsController
    Inherits ApiController
    Private products As Product() = New Product() {New Product() With {
        .Id = 1, _
        .Name = "Tomato Soup", _
        .Category = "Groceries", _
        .Price = 1 _
    }, New Product() With { _
        .Id = 2, _
        .Name = "Yo-yo", _
        .Category = "Toys", _
        .Price = 3.75D _
    }, New Product() With { _
        .Id = 3, _
        .Name = "Hammer", _
        .Category = "Hardware", _
        .Price = 16.99D _
    }}

    Public Function GetAllProducts() As IEnumerable(Of Product)
        Return products
    End Function

    Public Function GetProductById(id As Integer) As Product
        Dim product = products.FirstOrDefault(Function(p) p.Id = id)
        If product Is Nothing Then
            Throw New HttpResponseException(HttpStatusCode.NotFound)
        End If
        Return product
    End Function

    Public Function GetProductsByCategory(category As String) As IEnumerable(Of Product)
        Return products.Where(Function(p) String.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase))
    End Function

End Class