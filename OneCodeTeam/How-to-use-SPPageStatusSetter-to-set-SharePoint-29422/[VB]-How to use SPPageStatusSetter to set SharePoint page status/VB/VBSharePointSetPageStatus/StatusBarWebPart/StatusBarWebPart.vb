'/****************************** Module Header ******************************\
' * Module Name:  StatusBarWebPart.vb
' * Project:      VBSharePointSetPageStatus
' * Copyright (c) Microsoft Corporation.
' * 
' * This sample will show you how to add page status to an application page
' * and from list event receiver. 
' * This is custom web part.
' *
' * This source is subject to the Microsoft Public License.
' * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' * All other rights reserved.
' * 
' * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/

Imports System
Imports System.ComponentModel
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.WebControls

<ToolboxItemAttribute(false)> _
Public Class StatusBarWebPart
    Inherits WebPart

    Private statusBar As SPPageStatusSetter
    Private strMessage As String

    Public Sub New()
        Me.Message = String.Empty
    End Sub


    <Category("Custom Properties")> _
    <Browsable(False)> _
    Public Property Message() As String
        Get
            Return strMessage
        End Get
        Set(value As String)
            strMessage = value
        End Set
    End Property

    Protected Overrides Sub CreateChildControls()
        statusBar = New SPPageStatusSetter()
        statusBar.AddStatus("Action", Message, SPPageStatusColor.Blue)

        If Not String.IsNullOrEmpty(Message) Then
            Controls.Add(statusBar)
        End If
    End Sub

    Protected Overrides Sub RenderContents(writer As HtmlTextWriter)
        writer.Write("Status Bar demo")
        RenderChildren(writer)
    End Sub


End Class
