'**************************** Module Header ******************************\
'* Module Name:	App.xaml.cs
'* Project:		VBAzureACSJWT
'* Copyright (c) Microsoft Corporation.
'* 
'* This sample shows:
'* how to do authentication based on Azure Access control service(ACS).
'* 
'* Store ACS infos we need.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
'* All other rights reserved.
'* 
'* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\*************************************************************************
Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.
    Public Shared ReadOnly realm As String = "your realm"

    Public Shared ReadOnly serviceNamespace As String = "your namespace"
    'Access Control Namespaces 
    Public Shared ReadOnly acsHostUrl As String = "accesscontrol.windows.net"
End Class
