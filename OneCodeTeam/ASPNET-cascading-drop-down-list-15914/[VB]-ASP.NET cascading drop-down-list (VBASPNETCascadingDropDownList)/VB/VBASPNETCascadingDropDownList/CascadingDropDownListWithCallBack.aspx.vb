'****************************** Module Header ******************************\
'Module Name:  CascadingDropDownListWithCallBack.aspx.vb
'Project:      VBASPNETCascadingDropDown
'Copyright (c) Microsoft Corporation.
'
'This page is used to show the Cascading DropDownList with callback.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Partial Public Class CascadingDropDownListWithCallBack
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Page Load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Register client onclick event for submit button
        btnSubmit.Attributes.Add("onclick", "SaveSelectedData();")
        If Not IsPostBack Then
            ' Bind country dropdownlist
            BindddlCountry()
            ' Initialize hide field value
            hdfResult.Value = ""
            hdfCity.Value = ""
            hdfCitySelectValue.Value = "0"
            hdfRegion.Value = ""
            hdfRegionSelectValue.Value = ""
        End If
    End Sub

    ''' <summary>
    ''' Bind country dropdownlist
    ''' </summary>
    Public Sub BindddlCountry()
        Dim list As List(Of String) = RetrieveDataFromXml.GetAllCountry()
        ddlCountry.DataSource = list
        ddlCountry.DataBind()
    End Sub

    ''' <summary>
    ''' Submit button click event and show select result
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        ' Get result from hide field saved in client
        Dim strResult As String = hdfResult.Value
        lblResult.Text = strResult
    End Sub
End Class