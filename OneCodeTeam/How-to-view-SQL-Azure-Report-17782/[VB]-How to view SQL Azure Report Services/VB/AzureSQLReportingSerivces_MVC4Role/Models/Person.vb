'****************************** Module Header ******************************\
'Module Name:  Person.vb
'Project:      AzureSQLReportingSerivces_MVC4Role
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to access SQL Azure Reporting Service and
'get data by authenticated username/password by ReportViewer control and 
'non-ReportViewer clients (such as MVC project). The ReportViewer control
'with server report will help use send request to SQL Azure with credentials
'message, but in MVC role, we need to send request and analysis XML by code.
'
'Person entity class.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class Person
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property
    Private m_Name As String

    Public Property ID() As Integer
        Get
            Return m_ID
        End Get
        Set(value As Integer)
            m_ID = value
        End Set
    End Property
    Private m_ID As Integer

    Public Property Comments() As String
        Get
            Return m_Comments
        End Get
        Set(value As String)
            m_Comments = value
        End Set
    End Property
    Private m_Comments As String
End Class
