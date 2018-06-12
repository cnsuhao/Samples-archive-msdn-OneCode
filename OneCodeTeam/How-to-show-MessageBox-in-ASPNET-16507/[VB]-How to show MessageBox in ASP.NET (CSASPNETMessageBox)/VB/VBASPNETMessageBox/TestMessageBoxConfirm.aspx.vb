Imports System.Web.Services

'****************************** Module Header ******************************\
'Module Name:  TestMessageBoxConfirm.aspx.vb
'Project:      VBASPNETIntelligentErrorPage
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to create a MessageBox in asp.net, usually we
'often use JavaScript functions "alert()" or "confirm()" to show simple messages
'and make a simple choice with customers, but these dialog boxes is very simple,
'we can not add any different and complicate controls, images or styles. As we know,
'good web sites always have their own web styles, such as typeface and colors, 
'and in this situation, JavaScript dialog boxes looks not very well. So this sample
'shows how to make an Asp.net MessageBox.
'
'This page defines a customize MessageBox class with some necessary properties.
'For example, title, text, icons, buttons, events, etc. The MessageBox class looks
'like a windows form MessageBox but not the same, because these two application's working
'mechanism is different, we need display the MessageBox in current web page, rather 
'than open a new page for displaying messages, so we need a Literal control for
'receive HTML code and use web service for getting different results.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Partial Public Class TestMessageBoxConfirm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnInvokeConfirm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInvokeConfirm.Click
        Dim title As String = "Confirm"
        Dim text As String = "Hello everyone, I am an Asp.net MessageBox. You can set MessageBox.SuccessEvent and MessageBox.FailedEvent and Click Yes(OK) or No(Cancel) buttons for calling them. The Methods must be a WebMethod because client-side application will call web services."
        Dim messageBox__1 As New MessageBox(text, title, MessageBox.MessageBoxIcons.Question, MessageBox.MessageBoxButtons.OKCancel, MessageBox.MessageBoxStyle.StyleB)
        messageBox__1.SuccessEvent.Add("OkClick")
        messageBox__1.SuccessEvent.Add("OkClick")
        messageBox__1.FailedEvent.Add("CancalClick")
        Literal1.Text = messageBox__1.Show(Me)
    End Sub

    <WebMethod()> _
Public Shared Function OkClick(ByVal sender As Object, ByVal e As EventArgs) As String
        Return "You have clicked Ok button"
    End Function

    <WebMethod()> _
    Public Shared Function CancalClick(ByVal sender As Object, ByVal e As EventArgs) As String
        Return "You have clicked Cancel button."
    End Function
End Class