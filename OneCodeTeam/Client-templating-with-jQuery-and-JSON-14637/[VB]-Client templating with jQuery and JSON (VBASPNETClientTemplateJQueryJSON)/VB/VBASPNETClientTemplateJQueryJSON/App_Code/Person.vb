'**************************** Module Header ******************************\
' Module Name: Person.vb
' Project:     VBASPNETClientTemplateJQueryJSON
' Copyright (c) Microsoft Corporation
'
' This project illustrates how to display a tabular data to users based on 
' some inputs in ASP.NET application. We will see how this can be addressed
' with JQuery and JSON to build a tabular data display in web page. Here we
' use JQuery plug-in JTemplate to make it easy.
' 
' Person entity class. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************




<Serializable()> _
Public Class Person

    Public Property Name As String
    Public Property Age As Integer
    Public Property Country As String
    Public Property Address As String
    Public Property Mail As String
    Public Property Telephone As String
    Public Property Comment As String

End Class

