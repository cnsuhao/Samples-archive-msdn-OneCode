'**************************** Module Header ******************************\
' Module Name: XmlData.vb
' Project:     VBsASPNETDataBindingByXMLString
' Copyright (c) Microsoft Corporation
'
' This code-sample demonstrates how to bind TreeView by using an XML string
' variable. The web application converts XML string to XML object and binds
' data to TreeView's nodes, the TreeViewBind() method supports binding with
' multilayer structure of XML object via recursion algorithm.
' 
' The XmlData class is use to provide an XML string.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************




Public Class XmlData
    Public Function GetXmlString() As String
        ' XML data string.
        Dim strXml As String =
            "<Nodes>" +
            "<ParentNode name=""paNode1"" id=""1"">" +
            "<ChildNode name=""chNode11"" id=""11"">" +
            "<Level2ChildNode name=""Level2chNode111"" id=""111""></Level2ChildNode>" +
            "<Level2ChildNode name=""Level2chNode112"" id=""112""></Level2ChildNode>" +
            "</ChildNode>" +
            " <ChildNode name=""chNode12"" id=""12""></ChildNode>" +
            "<ChildNode name=""chNode13"" id=""13""></ChildNode>" +
            "</ParentNode>" +
            "<ParentNode name=""paNode2"" id=""2"">" +
            "<ChildNode name=""chNode21"" id=""21""></ChildNode>" +
            "<ChildNode name=""chNode22"" id=""22""></ChildNode>" +
            "<ChildNode name=""chNode23"" id=""23""></ChildNode>" +
            "</ParentNode>" +
            "<ParentNode name=""paNode3"" id=""3"">" +
            "<ChildNode name=""chNode31"" id=""31""></ChildNode>" +
            "<ChildNode name=""chNode32"" id=""32""></ChildNode>" +
            "<ChildNode name=""chNode33"" id=""33""></ChildNode>" +
            "</ParentNode>" +
            "</Nodes>"
        Return strXml
    End Function


End Class
