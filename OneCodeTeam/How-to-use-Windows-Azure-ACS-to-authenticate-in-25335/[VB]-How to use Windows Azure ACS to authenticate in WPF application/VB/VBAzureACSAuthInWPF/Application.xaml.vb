'**************************** Module Header ******************************\
' Module Name:	Application.vb
' Project:		VBAzureACAuthInWPF
' Copyright (c) Microsoft Corporation.
' 
' This sample shows:
' how to do authentication based on Azure Access control service(ACS).
' how to use ACS secure your WCF service.
' 
' Store ACS infos we need.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/


Class Application
    Public Shared ReadOnly realm As String = "your realm"
    'In this example it should be http://localhost:12526/RESTUserService.svc
    Public Shared ReadOnly serviceNamespace As String = "your namespace"
    'Access Control Namespaces
    Public Shared ReadOnly acsHostUrl As String = "accesscontrol.windows.net"

End Class
