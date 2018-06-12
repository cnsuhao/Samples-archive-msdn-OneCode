'****************************** Module Header ******************************\
' Module Name:    CustomCalendarWebPart.vb
' Project:        VBSharePointCustomCalendar
' Copyright (c) Microsoft Corporation
'
' This sample demonstrates how to use SPCalendarView to develop a custom calendar
' in a visual web part.This is the WebPart. 
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Imports System.ComponentModel
Imports System.Web.UI
Imports Microsoft.SharePoint.WebPartPages

<ToolboxItemAttribute(false)> _
Public Class CustomCalendarWebPart
    Inherits WebPart

    ' Visual Studio might automatically update this path when you change the Visual Web Part project item.
    Private Const _ascxPath As String = "~/_CONTROLTEMPLATES/VBSharePointCustomCalendar/CustomCalendarWebPart/CustomCalendarWebPartUserControl.ascx"

    Protected Overrides Sub CreateChildControls()
        Dim control As Control = Page.LoadControl(_ascxPath)
        Controls.Add(control)
    End Sub

End Class
