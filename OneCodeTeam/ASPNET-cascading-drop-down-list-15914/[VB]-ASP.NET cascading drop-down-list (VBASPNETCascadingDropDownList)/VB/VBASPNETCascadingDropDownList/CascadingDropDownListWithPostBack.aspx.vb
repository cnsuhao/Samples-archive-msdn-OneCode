'****************************** Module Header ******************************\
'Module Name:  CascadingDropDownListWithPostBack.aspx.vb
'Project:      VBASPNETCascadingDropDown
'Copyright (c) Microsoft Corporation.
'
'This page is used to show the Cascading DropDownList with postback.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Partial Public Class CascadingDropDownListWithPostBack
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Page Load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Bind Country dropdownlist
            BindddlCountry()
            ddlRegion.Enabled = False
            ddlCity.Enabled = False

            ' Insert one item to dropdownlist top
            ddlRegion.Items.Insert(0, New ListItem("Select Region", "-1"))
            ddlCity.Items.Insert(0, New ListItem("Select City", "-1"))

            ' Initialize city dropdownlist selected index
            hdfDdlCitySelectIndex.Value = "0"
        End If
    End Sub

    ''' <summary>
    ''' Bind Country dropdownlist
    ''' </summary>
    Public Sub BindddlCountry()
        Dim list As List(Of String) = RetrieveDataFromXml.GetAllCountry()
        ddlCountry.DataSource = list
        ddlCountry.DataBind()
        ddlCountry.Items.Insert(0, New ListItem("Select Country", "-1"))
    End Sub

    ''' <summary>
    ''' Show selected value
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        ' Get the selected index of city dropdownlist
        Dim iCitySelected As Integer = Convert.ToInt16(hdfDdlCitySelectIndex.Value)

        ' The result will be showing
        Dim strResult As String = String.Empty
        If ddlCountry.SelectedIndex = 0 Then
            strResult = "Please select a Country."
        ElseIf ddlRegion.SelectedIndex = 0 AndAlso strResult = String.Empty Then
            strResult = "Please select a Region"
        ElseIf hdfDdlCitySelectIndex.Value = "0" AndAlso strResult = String.Empty Then
            strResult = "Please select a City."
        Else
            strResult = (("You selected Country: " + ddlCountry.SelectedValue & " ; Region: ") + ddlRegion.SelectedValue & " ; City: ") + ddlCity.Items(iCitySelected).Value
        End If

        lblResult.Text = strResult
    End Sub
    ''' <summary>
    ''' Country dropdownlist SelectedIndexChanged event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCountry.SelectedIndexChanged
        ' Remove region dropdownlist items
        ddlRegion.Items.Clear()
        Dim strCountry As String = String.Empty
        strCountry = ddlCountry.SelectedValue
        Dim list As List(Of String) = Nothing

        ' Bind Region dropdownlist based on country value
        If ddlCountry.SelectedIndex <> 0 Then
            list = RetrieveDataFromXml.GetRegionByCountry(strCountry)
            If list IsNot Nothing AndAlso list.Count <> 0 Then
                ddlRegion.Enabled = True
            End If

            ddlRegion.DataSource = list
            ddlRegion.DataBind()
        Else
            ddlRegion.Enabled = False
        End If

        ddlRegion.Items.Insert(0, New ListItem("Select Region", "-1"))

        ' Clear city dropdownlist
        ddlCity.Enabled = False
        ddlCity.Items.Clear()
        ddlCity.Items.Insert(0, New ListItem("Select City", "-1"))

        ' Initialize city dropdownlist selected index
        hdfDdlCitySelectIndex.Value = "0"
    End Sub
    ''' <summary>
    ''' Region dropdownlist SelectedIndexChanged event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlRegion.SelectedIndexChanged
        ' Bind city dropdownlist based on region value
        Dim strRegion As String = String.Empty
        strRegion = ddlRegion.SelectedValue
        Dim list As List(Of String) = Nothing
        list = RetrieveDataFromXml.GetCityByRegion(strRegion)
        ddlCity.Items.Clear()
        ddlCity.DataSource = list
        ddlCity.DataBind()
        ddlCity.Items.Insert(0, New ListItem("Select City", "-1"))

        ' Initialize city dropdownlist selected index
        hdfDdlCitySelectIndex.Value = "0"

        ' Enable city dropdownlist when it has items
        If list.Count > 0 Then
            ddlCity.Enabled = True
        Else
            ddlCity.Enabled = False
        End If
    End Sub
End Class