'**************************** Module Header ******************************\
' Module Name: Default.aspx.vb
' Project:     VBASPNETGloablizationInAssembly
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to access resource files that has compiled in 
' class library or dll file. So we can not use GetGlobalResourceObject function
' to get it, here we give an effective way to get specific resources from
' compiled file and then apply resource value in whole application.
'
' In this page, we use ResoueceManager and Assembly to achieve this goal. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************

Imports System.Resources
Imports System.Globalization
Imports VBASPNETGloablizationInAssemblyResource.My.Resources

''' <summary>
''' This project class is used to access resource files from class 
''' library, and render the correct content with current culture.
''' </summary>
''' <remarks></remarks>
Public Class _Default
    Inherits System.Web.UI.Page
    Public strContent As String = String.Empty
    Public strUrl As String = String.Empty
    Public strLink As String = String.Empty
    Const strBaseName As String = "VBASPNETGloablizationInAssemblyResource.LanguageResource"

    ' Get ResourceManager instance by assembly resource type.
    Private manager As New ResourceManager(strBaseName, GetType(LanguageResource).Assembly)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim culture As New CultureInfo(Context.Request.UserLanguages(0))

            Dim strTitle As String = manager.GetString("Title", culture)
            Dim strAuthor As String = manager.GetString("Author", culture)
            Me.strContent = manager.GetString("Content", culture)
            Me.strUrl = manager.GetString("Url", culture)
            Me.strLink = manager.GetString("Link", culture)
            lbTitle.Text = strTitle
            lbAuthor.Text = strAuthor
            Dim flag As Boolean = False
            For i As Integer = 0 To ddlLanguage.Items.Count - 1
                If ddlLanguage.Items(i).Value = culture.Name.ToLower() Then
                    flag = True
                End If
            Next
            If flag Then
                ddlLanguage.SelectedValue = culture.Name.ToLower()
            Else
                ddlLanguage.SelectedIndex = 0
            End If

        End If

    End Sub
    ''' <summary>
    ''' Add built-in language items of DropDownList control.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        ddlLanguage.Items.Add(New ListItem("United State", "en-us"))
        ddlLanguage.Items.Add(New ListItem("France", "fr-fr"))
        ddlLanguage.Items.Add(New ListItem("中国", "zh-cn"))
    End Sub

    ''' <summary>
    ''' Change page culture and content by DropDownList SelectedValue.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub ddlLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim languageCode As String = ddlLanguage.SelectedValue
        Dim currentCulture As CultureInfo = Me.GetLanguageSpecifically(languageCode)
        lbTitle.Text = manager.GetString("Title", currentCulture)
        lbAuthor.Text = manager.GetString("Author", currentCulture)
        Me.strContent = manager.GetString("Content", currentCulture)
        Me.strLink = manager.GetString("Link", currentCulture)
        Me.strUrl = manager.GetString("Url", currentCulture)
    End Sub

    Public Function GetLanguageSpecifically(ByVal languageCode As String) As CultureInfo
        Dim culture As New CultureInfo(languageCode)
        Return culture
    End Function

End Class