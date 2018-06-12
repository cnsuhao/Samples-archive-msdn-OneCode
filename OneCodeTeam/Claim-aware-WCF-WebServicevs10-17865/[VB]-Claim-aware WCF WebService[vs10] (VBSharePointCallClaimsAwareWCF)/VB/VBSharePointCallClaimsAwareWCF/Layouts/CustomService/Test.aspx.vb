'*************************** Module Header ******************************\
' Module Name:    Test.aspx.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to accomplish custom claim-ware WCF web service 
' for SharePoint 2010.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\****************************************************************************


Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.WebControls

Namespace CustomService.Layouts.CustomService
    Partial Public Class Test
        Inherits LayoutsPageBase
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim client As New CustomServiceClient(SPServiceContext.Current)

            Dim sum As Integer = client.Add(1, 1)

            Dim strSayHello As String = client.HelloWorld()

            TestOutputLabel.Text = [String].Format("1 + 1 = {0}", sum) & "<br/>" & strSayHello
        End Sub
    End Class
End Namespace
