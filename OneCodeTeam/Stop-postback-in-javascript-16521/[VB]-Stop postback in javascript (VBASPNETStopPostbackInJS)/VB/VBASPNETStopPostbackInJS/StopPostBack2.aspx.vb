'**************************** Module Header ******************************
' Module Name: StopPostBack2.aspx.vb
' Project:     VBASPNETStopPostbackInJS
' Copyright (c) Microsoft Corporation
'
' This page contains a client button and a hidden button. 
' Use JavasCript code to invoke hidden button onclick event or not.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************



Public Class StopPostBack2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCausePostback_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHiddenCausePostback.Click
        ' Postbacks code
        textDisplay.Value += "  This is a server click"
    End Sub
End Class