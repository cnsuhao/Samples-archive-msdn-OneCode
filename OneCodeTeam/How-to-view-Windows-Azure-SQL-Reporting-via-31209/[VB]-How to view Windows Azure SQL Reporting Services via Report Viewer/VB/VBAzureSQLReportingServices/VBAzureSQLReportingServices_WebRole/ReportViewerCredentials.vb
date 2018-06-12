'****************************** Module Header ******************************\
'Module Name:  ReportViewerCredentials.vb
'Project:      AzureSQLReportingServices_WebRole
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to access SQL Azure Reporting Service and
'get data by authenticated username/password by ReportViewer control and 
'non-ReportViewer clients (such as MVC project). The ReportViewer control
'with server report will help use send request to SQL Azure with credentials
'message, but in MVC role, we need to send request and analysis XML by code.
'
'This class is used to create forms credentials.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WebForms

<Serializable()> _
Public Class ReportViewerCredentials
    Implements IReportServerCredentials
    Private reportUser As String
    Private reportPassword As String
    Private reportDomain As String

    Public Sub New(user As String, password As String, domain As String)
        Me.reportUser = user
        Me.reportPassword = password
        Me.reportDomain = domain
    End Sub

    Public Function GetFormsCredentials(ByRef authCookie As Cookie, ByRef user As String, ByRef password As String, ByRef authority As String) As Boolean Implements IReportServerCredentials.GetFormsCredentials
        authCookie = Nothing
        user = Me.reportUser
        password = Me.reportPassword
        authority = Me.reportDomain

        Return True
    End Function

    Public ReadOnly Property ImpersonationUser() As WindowsIdentity Implements IReportServerCredentials.ImpersonationUser
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property NetworkCredentials() As ICredentials Implements IReportServerCredentials.NetworkCredentials
        Get
            Return Nothing
        End Get
    End Property
End Class
