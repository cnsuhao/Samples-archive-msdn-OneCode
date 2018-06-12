'****************************** Module Header ******************************\
' Module Name: WebRole.vb
' Project:     sslRole
' Copyright (c) Microsoft Corporation.
' 
' While hosting the applications in Azure, developers are required to modify IIS 
' settings to suit their application requirements. Many of these IIS settings can 
' be modified only programmatically and developers are required to write code, 
' startup tasks to achieve what they are looking for. One common things customers 
' do while hosting the applications on-premise is to mix the SSL content with 
' non-SSL content. In Azure, by default you can enable SSL for entire site. There
' is no provision to enable SSL only for few pages. Hence, I have written this sample 
' that can be used it with out investing more time to achieve the task.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.Diagnostics
Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.Web.Administration

Public Class WebRole
    Inherits RoleEntryPoint

    Public Overrides Function OnStart() As Boolean

        ' Create new ServerManager object to modify IIS7 configuration
        Dim serverManager As New ServerManager()

        ' Retrieve Current Application Host Configuration of IIS
        Dim config As Configuration = serverManager.GetApplicationHostConfiguration()

        ' Since we are looking to enable SSL for only specific page, get the section 
        ' of configuration which needs to be changed for specific location
        ' Website name can be obtained using  RoleEnvironment.CurrentRoleInstance.Id 
        ' and then append "_" along with actual site name specified in ServiceDefinition.csdef
        ' Default name of the website is Web. If you have specified different sitename, 
        ' please replace "Web" with the specified name in below line of code.
        Dim section As ConfigurationSection = config.GetSection("system.webServer/security/access", RoleEnvironment.CurrentRoleInstance.Id + "_Web" & "/sslpage.aspx")

        ' Get the sslFlags attribute which is used for configuring SSL settings
        Dim enabled As ConfigurationAttribute = section.GetAttribute("sslFlags")

        ' Configure sslFlags value as "ssl". This will enable "Require SSL" flag
        enabled.Value = "Ssl"

        ' Save the changes. If role is not running under elevated executionContext, 
        ' this line will result in exception.
        serverManager.CommitChanges()

        ' For information on handling configuration changes
        ' see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
 
        Return MyBase.OnStart()

    End Function

End Class

