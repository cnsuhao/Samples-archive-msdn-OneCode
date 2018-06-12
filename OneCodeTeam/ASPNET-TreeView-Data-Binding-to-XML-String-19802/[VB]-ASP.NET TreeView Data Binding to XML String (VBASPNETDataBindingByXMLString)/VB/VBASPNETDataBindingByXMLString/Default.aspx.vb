'**************************** Module Header ******************************\
' Module Name: Default.aspx.vb
' Project:     VBASPNETDataBindingByXMLString
' Copyright (c) Microsoft Corporation
'
' This code sample demonstrates how to bind TreeView by using an XML string
' variable. The web application converts XML string to XML object and binds
' data to TreeView's nodes, the TreeViewBind() method supports binding with
' multilayer structure of XML object via recursion algorithm.
' 
' The Default.aspx page is used to show bind TreeView control by using XML string.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************




Imports System.Xml

Public Class _Default
    Inherits System.Web.UI.Page
    Dim data As XmlData

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TreeViewBind()
    End Sub
    ''' <summary>
    ''' It's used to load an XML string via XmlDocument
    ''' object, and convert it to XML Object. Binding object to TreeView
    ''' data source.
    ''' </summary>
    Private Sub TreeViewBind()
        Try
            Dim document As New XmlDocument()
            Dim strXmlString As String = Me.GetXmlStringEvent()
            document.LoadXml(strXmlString)
            Dim nodeXml As XmlNode = document.DocumentElement
            Dim nodeTree As TreeNode = Nothing
            For Each node As XmlNode In nodeXml.ChildNodes
                nodeTree = New TreeNode()
                Dim elementXml As XmlElement = DirectCast(node, XmlElement)
                nodeTree.Text = elementXml.GetAttribute("name").ToString()
                Me.AddChildNode(nodeTree, node)
                Me.tvwTreeView.Nodes.Add(nodeTree)
            Next
        Catch xmlEx As XmlException
            Response.Write("XML string errors, please check your XmlData class.<br />")
            Response.Write(xmlEx.Message)
            tvwTreeView.Nodes.Clear()
        Catch ex As Exception
            Response.Write(ex.Message)
            tvwTreeView.Nodes.Clear()
        End Try
    End Sub


    ''' <summary>
    ''' It's used to add child nodes to the TreeView nodes via 
    ''' recursion algorithm. 
    ''' </summary>
    ''' <param name="nodeParent"></param>
    ''' <param name="node"></param>
    Private Sub AddChildNode(ByVal nodeParent As TreeNode, ByVal node As XmlNode)
        Dim nodeTreeChild As TreeNode = Nothing
        For Each nodeChild As XmlNode In node.ChildNodes
            If node.ChildNodes.Count = 0 Then
                nodeParent.ChildNodes.Add(nodeTreeChild)
            Else
                nodeTreeChild = New TreeNode()
                Dim elementChild As XmlElement = DirectCast(nodeChild, XmlElement)
                nodeTreeChild.Text = elementChild.GetAttribute("name").ToString()
                Me.AddChildNode(nodeTreeChild, nodeChild)
                nodeParent.ChildNodes.Add(nodeTreeChild)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Get XML string.
    ''' </summary>
    ''' <returns></returns>
    Private Function GetXmlStringEvent() As String
        data = New XmlData()
        Dim strXmlString As String = data.GetXmlString()
        Return strXmlString
    End Function

End Class