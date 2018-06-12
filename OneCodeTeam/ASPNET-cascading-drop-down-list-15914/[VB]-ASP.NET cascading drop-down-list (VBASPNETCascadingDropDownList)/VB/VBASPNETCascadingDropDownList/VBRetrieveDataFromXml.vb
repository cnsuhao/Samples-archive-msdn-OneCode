'****************************** Module Header ******************************\
'Module Name:  VBRetrieveDataFromXml.vb
'Project:      VBASPNETCascadingDropDown
'Copyright (c) Microsoft Corporation.
'
'This class is used to access data source and retrieve data. In this case, 
'the data source is XML file.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Xml

''' <summary>
''' Summary description for CSRetrieveDataFromXml
''' </summary>
''' <remarks></remarks>
Public Class RetrieveDataFromXml
    ''' Constructor 
    Public Sub New()
        '
        ' TODO: Add constructor logic here
        ''
    End Sub

    ''' <summary>
    ''' Get the data source path, in this case, it is the XML file in the 
    ''' App_Data folder
    ''' </summary>
    Private Shared strXmlPath As String = HttpContext.Current.Server.MapPath("App_Data") + "\CustomDataSource.xml"


    ''' <summary>
    ''' Get all country
    ''' </summary>
    ''' <returns>The List contains country</returns>
    Public Shared Function GetAllCountry() As List(Of String)
        Dim document As New XmlDocument()
        document.Load(strXmlPath)
        Dim nodeList As XmlNodeList = document.SelectNodes("Countries/Country")
        Dim list As New List(Of String)()
        For Each node As XmlNode In nodeList
            list.Add(node.Attributes("name").Value)
        Next

        Return list
    End Function


    ''' <summary>
    ''' Get region based on country
    ''' </summary>
    ''' <param name="strCountry">The country name</param>
    ''' <returns>The list contains region</returns>
    Public Shared Function GetRegionByCountry(ByVal strCountry As String) As List(Of String)
        Dim document As New XmlDocument()
        document.Load(strXmlPath)
        Dim nodeList As XmlNodeList = document.SelectNodes("Countries/Country[@name='" & strCountry & "']/Region")
        Dim list As New List(Of String)()
        For Each node As XmlNode In nodeList
            list.Add(node.Attributes("name").Value)
        Next

        Return list
    End Function


    ''' <summary>
    '''  Get city based on region
    ''' </summary>
    ''' <param name="strRegion">The region name</param>
    ''' <returns>The list contains city</returns>
    Public Shared Function GetCityByRegion(ByVal strRegion As String) As List(Of String)
        Dim document As New XmlDocument()
        document.Load(strXmlPath)
        Dim nodeList As XmlNodeList = document.SelectNodes("Countries/Country/Region[@name='" & strRegion & "']/City")
        Dim list As New List(Of String)()
        For Each node As XmlNode In nodeList
            list.Add(node.InnerText.ToString())
        Next
        Return list
    End Function
End Class
