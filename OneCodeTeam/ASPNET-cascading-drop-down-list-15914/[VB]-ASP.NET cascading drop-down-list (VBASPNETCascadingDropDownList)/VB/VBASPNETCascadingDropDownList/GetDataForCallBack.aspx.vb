'****************************** Module Header ******************************\
'Module Name:  GetDataForCallBack.aspx.vb
'Project:      VBASPNETCascadingDropDown
'Copyright (c) Microsoft Corporation.
'
'This page is used to retrieve data in callback and write data to client.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Partial Public Class GetDataForCallBack
    Inherits System.Web.UI.Page
    ''' <summary>
    ''' Page Load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Get querystring from URL and retrieve data based on it
        If Request.QueryString.Count > 0 Then
            Dim strValue As String = Request.QueryString(0)
            If Request.QueryString("country") IsNot Nothing Then
                RetrieveRegionByCountry(strValue)
            Else
                RetrieveCityByRegion(strValue)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Get region based on country value
    ''' </summary>
    ''' <param name="strValue">The country value</param>
    Public Sub RetrieveRegionByCountry(ByVal strValue As String)
        Dim list As List(Of String) = RetrieveDataFromXml.GetRegionByCountry(strValue)
        WriteData(list)
    End Sub

    ''' <summary>
    ''' Get city based on region value
    ''' </summary>
    ''' <param name="strValue">The region value</param>
    Public Sub RetrieveCityByRegion(ByVal strValue As String)
        Dim list As List(Of String) = RetrieveDataFromXml.GetCityByRegion(strValue)
        WriteData(list)
    End Sub

    ''' <summary>
    ''' Write data to client
    ''' </summary>
    ''' <param name="list">The list contains value </param>
    Public Sub WriteData(ByVal list As List(Of String))
        Dim iCount As Integer = list.Count
        Dim builder As New StringBuilder()
        If iCount > 0 Then
            For i As Integer = 0 To iCount - 2
                builder.Append(list(i) + ",")
            Next
            builder.Append(list(iCount - 1))
        End If

        Response.ContentType = "text/xml"
        ' Write data in string format "###,###,###" to client
        Response.Write(builder.ToString())
        Response.[End]()
    End Sub
End Class