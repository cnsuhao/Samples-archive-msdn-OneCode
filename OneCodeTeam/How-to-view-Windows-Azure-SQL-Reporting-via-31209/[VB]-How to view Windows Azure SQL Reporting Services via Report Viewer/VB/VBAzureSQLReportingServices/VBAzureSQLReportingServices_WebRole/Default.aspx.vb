'****************************** Module Header ******************************\
'Module Name:  Default.aspx.vb
'Project:      AzureSQLReportingServices_WebRole
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to access SQL Azure Reporting Service and
'get data by authenticated username/password by ReportViewer control and 
'non-ReportViewer clients (such as MVC project). The ReportViewer control
'with server report will help use send request to SQL Azure with credentials
'message, but in MVC role, we need to send request and analysis XML by code.
'
'This page is normal WebRole page. We need provide username/password/domain 
'to ReportViewer control.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim user As String = ConfigurationManager.AppSettings("sqlAzureRSUser")
            Dim password As String = ConfigurationManager.AppSettings("sqlAzureRSPassword")
            Dim domain As String = ConfigurationManager.AppSettings("sqlAzureRSDomain")
            Me.ReportViewer1.ServerReport.ReportServerCredentials = New ReportViewerCredentials(user, password, domain)
            Me.ReportViewer1.ServerReport.Refresh()
        End If
    End Sub

End Class