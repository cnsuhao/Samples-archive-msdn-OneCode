'****************************** Module Header ******************************\
' Module Name:  XmlHandler.vb
' Project:      VBASPNETIntelligentErrorPage
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to create the intelligent error page in Asp.net 
' application. In this sample, we add a custom 404 error page and find the similar 
' local resources, then display them in error page. In this way, we will improve 
' the user-experience, since users don’t need to face a boring and helpless error 
' page any more.
'
' The XmlHandler class will get data from xml file and include some basic
' methods of the sample code.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Data
Imports System.Xml.Linq

Public Class XmlHandler
    Private tabItems As New DataTable()
    Private xmlPath As String = String.Empty
    Public Sub New(ByVal url As String)
        Me.xmlPath = url
        Dim dcName As New DataColumn("Name", Type.[GetType]("System.String"))
        Dim dcCategory As New DataColumn("Category", Type.[GetType]("System.String"))
        Dim dcUrl As New DataColumn("Path", Type.[GetType]("System.String"))
        tabItems.Columns.Add(dcName)
        tabItems.Columns.Add(dcCategory)
        tabItems.Columns.Add(dcUrl)
    End Sub

    Public Function GetOpenData() As DataTable
        tabItems.Clear()
        Dim document As XDocument = XDocument.Load(xmlPath)
        For Each item As XElement In document.Descendants("Item")
            If item.Attribute("open").Value.Equals("1") Then
                Dim dr As DataRow = tabItems.NewRow()
                dr("Name") = item.Element("Name").Value
                dr("Category") = item.Element("Category").Value
                dr("Path") = item.Element("Path").Value
                tabItems.Rows.Add(dr)
            End If
        Next
        Return tabItems
    End Function

    Public Function GetDataItemByName(ByVal name As String) As DataTable
        tabItems.Clear()
        Dim document As XDocument = XDocument.Load(xmlPath)
        For Each item As XElement In document.Descendants("Item")
            If (item.Element("Category").Value.ToLower().Contains(name.ToLower()) OrElse item.Element("Name").Value.ToLower().Contains(name.ToLower())) Then
                Dim dr As DataRow = tabItems.NewRow()
                dr("Name") = item.Element("Name").Value
                dr("Category") = item.Element("Category").Value
                dr("Path") = item.Element("Path").Value
                tabItems.Rows.Add(dr)
            End If
        Next
        Return tabItems

    End Function
End Class
