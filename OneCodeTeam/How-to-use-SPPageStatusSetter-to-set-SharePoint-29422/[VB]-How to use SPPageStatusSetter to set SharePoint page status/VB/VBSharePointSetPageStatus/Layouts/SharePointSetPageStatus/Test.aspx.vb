'/****************************** Module Header ******************************\
' * Module Name:  Test.aspx.vb
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
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.WebControls

Namespace Layouts.SharePointSetPageStatus

    Partial Public Class Test
        Inherits LayoutsPageBase
        Dim spss As SPPageStatusSetter = New SPPageStatusSetter()
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnShow_Click(sender As Object, e As EventArgs)
            spss.AddStatus("Tip", "Welcome to OneCode!", SPPageStatusColor.Green)
            Me.Controls.Add(spss)
        End Sub

        Protected Sub btnHide_Click(sender As Object, e As EventArgs)
            Me.Controls.Remove(spss)
        End Sub

    End Class

End Namespace
