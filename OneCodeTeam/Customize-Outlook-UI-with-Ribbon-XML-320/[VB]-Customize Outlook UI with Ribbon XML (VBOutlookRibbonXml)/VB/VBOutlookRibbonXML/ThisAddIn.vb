'************************************* Module Header **************************************\
' Module Name:	ThisAddIn.vb
' Project:		VBOutlookRibbonXml
' Copyright (c) Microsoft Corporation.
' 
' The VBOutlookRibbonXml example demonstrates how to use Ribbon XML to create customized 
' Ribbon for Outlook 2007 inspectors.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'******************************************************************************************/


Public Class ThisAddIn

    Private Sub ThisAddIn_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup

    End Sub

    Protected Overrides Function CreateRibbonExtensibilityObject() As Microsoft.Office.Core.IRibbonExtensibility
        ' Outlook will call this method to get our IRibbonExtensibility
        ' implementation.
        Return New Ribbon()
    End Function

    Private Sub ThisAddIn_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
