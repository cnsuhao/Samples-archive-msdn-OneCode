'***************************** Module Header ******************************\
' Module Name:	ValuesController.vb
' Project:		VBAzureACSWithWebAPI
' Copyright (c) Microsoft Corporation.
' 
' Secure Web API is a hot topic in asp.net forum.
' This sample will show you how to use Azure ACS secure the web API.
' It will require you sign in with Live ID/Google/Yahoo/Live connect account 
' first before you use the web API.
'
' ValuesController is an example WebAPI controller.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports System.Net
Imports System.Web.Http

Public Class ValuesController
    Inherits ApiController

    ' GET api/values
    Public Function GetValues() As IEnumerable(Of String)
        Return New String() { "value1", "value2" }
    End Function

    ' GET api/values/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/values
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/values/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/values/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
