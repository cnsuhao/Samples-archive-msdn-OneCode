'****************************** Module Header ******************************\
' Module Name: Default.aspx.vb
' Project:     VBASPNETModifySessionStateSection
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to modify sessionState section in the Web.Config
' file at run time. Customers always wants to know how to modify web.config in
' code-behind page, thus, we provide two methods in this sample code to access
' configuration file of web application. Remember if you change the Web.Config file,
' the Asp.net application will restart, so please use it carefully.
' 
' This page use XmlDocument class to access and modify web.config file. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/



Imports System.Xml

Public Class _Default
    Inherits System.Web.UI.Page

    '' Define common variables, public string, web.config file path and XmlDocument instance.
    Public strDisplay As String = String.Empty
    Protected configPath As String = AppDomain.CurrentDomain.BaseDirectory + "\Web.Config"
    Private document As New XmlDocument()

    ''' <summary>
    ''' Load current web.config information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            document.Load(configPath)
            Dim nodeSession As XmlNode = document.SelectSingleNode("/configuration/system.web/sessionState")
            Dim elementSession As XmlElement = DirectCast(nodeSession, XmlElement)

            Dim strTimeOut As String = elementSession.Attributes("timeout").Value
            Dim value As Integer = 0
            If Integer.TryParse(strTimeOut, value) AndAlso value > 0 Then
                tbCookieTimeOut.Text = strTimeOut
            Else
                lbError.Text = "Session Timeout value is incorrect."
            End If

            Dim strCookieName As String = elementSession.Attributes("cookieName").Value
            If strCookieName <> String.Empty Then
                tbCookieName.Text = strCookieName
            Else
                lbError.Text = "Session Name value is empty."
            End If
        End If

    End Sub
    ''' <summary>
    ''' Use XmlDocument instance to modify Session properties.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnModifyByXml_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModifyByXml.Click
        Try
            Dim strbDisplay As New StringBuilder()
            document.Load(configPath)
            Dim nodeSession As XmlNode = document.SelectSingleNode("/configuration/system.web/sessionState")
            Dim elementSession As XmlElement = DirectCast(nodeSession, XmlElement)
            strbDisplay.Append("Forward Settings:<br />")
            strbDisplay.Append("Session TimeOut: ")
            strbDisplay.Append(elementSession.Attributes("timeout").Value)
            strbDisplay.Append("<br />")
            strbDisplay.Append("Session cookieName: ")
            strbDisplay.Append(elementSession.Attributes("cookieName").Value)
            strDisplay = strbDisplay.ToString()

            Dim strMin As String = tbCookieTimeOut.Text.Trim()
            Dim strName As String = tbCookieName.Text.Trim()
            If strName = String.Empty Then
                strDisplay = String.Empty
                lbError.Text = "Cookie Name is null."
                Return
            End If
            Dim intMin As Integer
            If Integer.TryParse(strMin, intMin) Then
                elementSession.Attributes("cookieName").Value = strName
                elementSession.Attributes("timeout").Value = intMin.ToString()
                document.Save(configPath)
                lbError.Text = "Save Web config file success, please can open web.config file for value checking."
            Else
                strDisplay = String.Empty
                lbError.Text = "Session Timeout value must be an integer number."
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
            strDisplay = String.Empty
        End Try
    End Sub
End Class