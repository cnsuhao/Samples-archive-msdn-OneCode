'****************************** Module Header ******************************\
' Module Name:    ModalDialog.ascx.vb
' Project:        VBSharePointRefreshParentPage
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to close the sharepoint modal dialog and
' refresh the parent page using Server side API.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Partial Public Class ModalDialogWebPartUserControl
    Inherits UserControl

    Private Const JSBlockKeySiteProperties As String = "JSBlockKeyManageSiteProperties"
    Private Const JSBlockSitePropertiesFormatString As String = "var ADD_SITE_PROPERTY_URL = ""{0}"";"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim cs As ClientScriptManager = Page.ClientScript

        Dim web As SPWeb = SPContext.Current.Web

        ' JS Block for concatenating SiteProperty Url
        If Not cs.IsClientScriptBlockRegistered(GetType(Page), JSBlockKeySiteProperties) Then
            Dim scriptBlock As String = [String].Format(JSBlockSitePropertiesFormatString, [String].Format(web.Url & "/_layouts/CloseModalDialogRefreshParentPage/AddSiteProperty.aspx?Source=" & SPContext.Current.File.Url & ""))
            cs.RegisterClientScriptBlock(GetType(Page), JSBlockKeySiteProperties, scriptBlock, True)
        End If

        ' Get the PropertyKey list
        Dim keyList As New ArrayList()
        For Each key As String In web.AllProperties.Keys
            keyList.Add(key)
        Next

        keyList.Sort()

        ' Get the Property list
        Dim propertyList As New ArrayList()
        For Each key As String In keyList
            propertyList.Add(New With { _
             Key .Name = key, _
             Key .Value = web.GetProperty(key).ToString() _
            })
        Next

        ' Bind to GridView
        SitePropertiesGridView.DataSource = propertyList
        SitePropertiesGridView.DataBind()
    End Sub

    ''' <summary>
    ''' Get edit SiteProperty Url
    ''' </summary>
    ''' <param name="propertyNameUrlEncoded">propertyName</param>
    ''' <returns></returns>
    Public Shared Function GetEditSitePropertyUrl(propertyNameUrlEncoded As String) As String
        Dim web As SPWeb = SPContext.Current.Web
        Return [String].Format(web.Url + "/_layouts/CloseModalDialogRefreshParentPage/EditSiteProperty.aspx?property={0}&Source={1}", propertyNameUrlEncoded, SPContext.Current.File)
    End Function
End Class
