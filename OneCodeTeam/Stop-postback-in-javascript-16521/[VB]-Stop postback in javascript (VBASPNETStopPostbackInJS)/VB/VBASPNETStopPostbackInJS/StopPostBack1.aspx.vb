'***************************** Module Header ******************************
' Module Name: StopPostBack1.aspx.vb
' Project:     VBASPNETStopPostbackInJS
' Copyright (c) Microsoft Corporation
'
' This page uses a server button control's onClientClick event check to
' stop or continue postbacks event.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************



Public Class StopPostBack1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCausePostback_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCausePostback.Click
        ' Postbacks code
        textDisplay.Value += "  This is a server click"
    End Sub
End Class