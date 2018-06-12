'****************************** Module Header ******************************\
' Module Name: Default2.aspx.vb
' Project:     VBASPNETModifySessionStateSection
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to modify sessionState section in the Web.Config
' file at run time. Customers always wants to know how to modify web.config in
' code-behind page, thus, we provide two methods in this sample code to access
' configuration file of web application. Remember if you change the Web.Config file,
' the Asp.net application will restart, so please use it carefully.
' 
' This page use WebConfigurationManager class to access and modify web.config 
' file.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/




Imports System.Configuration
Imports System.Web.Configuration

Public Class Default2
    Inherits System.Web.UI.Page
    Public strDisplay As String = String.Empty
    ' Define common variables, public string and Configuration instance.
    Private manager As Configuration

    ''' <summary>
    ''' Load current web.config information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
            Dim sections As SystemWebSectionGroup = TryCast(manager.GetSectionGroup("system.web"), SystemWebSectionGroup)
            Dim cookieName As String = sections.SessionState.CookieName
            If Not cookieName.Equals(String.Empty) Then
                tbCookieName.Text = cookieName
            Else
                lbError.Text = "Session Name value is empty."
            End If

            Dim timeout As TimeSpan = sections.SessionState.Timeout
            Dim minutes As Double = timeout.TotalMinutes
            If Not timeout.Equals(String.Empty) AndAlso minutes > 0 Then
                tbCookieTimeOut.Text = minutes.ToString()
            Else
                lbError.Text = "Session Timeout value is incorrect."
            End If
        End If

    End Sub
    ''' <summary>
    ''' Use WebConfigurationManager instance to get and set session state properties.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnModifyByXml_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModifyByXml.Click
        Try
            manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
            Dim sections As SystemWebSectionGroup = TryCast(manager.GetSectionGroup("system.web"), SystemWebSectionGroup)

            Dim strbDisplay As New StringBuilder()
            strbDisplay.Append("Forward Settings:<br />")
            strbDisplay.Append("Session TimeOut: ")
            strbDisplay.Append(sections.SessionState.Timeout.TotalMinutes.ToString())
            strbDisplay.Append("(m) <br />")
            strbDisplay.Append("Session cookieName: ")
            strbDisplay.Append(sections.SessionState.CookieName)
            strDisplay = strbDisplay.ToString()

            Dim strMin As String = tbCookieTimeOut.Text.Trim()
            Dim strName As String = tbCookieName.Text.Trim()
            If strName = String.Empty Then
                strDisplay = String.Empty
                lbError.Text = "Cookie Name is null."
                Return
            End If
            Dim intMin As Double
            If Double.TryParse(strMin, intMin) Then
                sections.SessionState.CookieName = strName
                sections.SessionState.Timeout = TimeSpan.FromMinutes(intMin)
                manager.Save()
                lbError.Text = "Save Web config file success, please can open web.config file for value checking."
            Else
                strDisplay = String.Empty
                lbError.Text = "Session Timeout value must be an integer number."
            End If
        Catch ex As Exception
            strDisplay = String.Empty
            Response.Write(ex.Message)
        End Try
    End Sub
End Class