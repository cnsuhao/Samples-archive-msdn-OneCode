'****************************** Module Header ******************************\
' Module Name:  example.aspx.vb
' Project:      VBASPNETGetDesiredResultByAJAXCalls
' Copyright (c) Microsoft Corporation
'
' This ASPX page is used to handle the ajax request and return data.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Partial Public Class example
    Inherits System.Web.UI.Page

    Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
        ' Query String
        Dim strText As String = Request.QueryString("str")
        Dim type As String = Request.QueryString("type")

        ' Output String
        Dim strOutput As String = String.Empty

        ' Returns the appropriate data type by Query String
        Select Case type
            Case "1"
                ' For plain text, "hello world" or some information you have typed.
                If String.IsNullOrEmpty(strText) Then
                    strText = "hello world"
                End If
                strOutput = strText
                Exit Select
            Case "2"
                ' For JSON, {"hello": "world"}                    
                strOutput = "{""hello"": ""world"",""face"": ""smile""}"
                Exit Select
            Case "3"
                ' For XML, <hello>Hello</hello><world>World</word>
                strOutput = "<?xml version=""1.0"" encoding=""GB2312""?><root><hello>Hello</hello><world>World</world></root>"
                Exit Select
            Case Else
                Exit Select
        End Select

        ' Set the HTTP MIME type of the output stream
        Response.ContentType = "text/xml"

        ' Output stream
        output.Write(strOutput)
    End Sub

End Class