'***************************** Module Header ******************************\
' Module Name:  WebRole.vb
' Project:     ControlIIS
' Copyright (c) Microsoft Corporation.
' 
' As we know, cloud service can full control IIS. If someone want to change IIS, 
' they will probably first think about using startup script, since it has been 
' documented in Azure training kit.
' That's a good way but not the only way.
' Actually we can use site class and Configuration config to achieve that.
' This sample will show you how can we control IIS by two different ways in Azure
' Cloud service.
'
' This class will execute when instance is created.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports Microsoft.Web.Administration
Imports Microsoft.WindowsAzure.ServiceRuntime

Public Class WebRole
    Inherits RoleEntryPoint
    Public Overrides Function OnStart() As Boolean
        Using serverManager As New ServerManager()
            Dim webSite As Site = serverManager.Sites(RoleEnvironment.CurrentRoleInstance.Id + "_Web")

            Dim config As Configuration = serverManager.GetApplicationHostConfiguration()
            Dim AppPoolName As String = webSite.Applications(0).ApplicationPoolName

            Dim applicationPoolsSection As ConfigurationSection = config.GetSection("system.applicationHost/applicationPools")

            Dim applicationPoolsCollection As ConfigurationElementCollection = applicationPoolsSection.GetCollection()

            Dim addElement As ConfigurationElement = ConfigurationUtiltiy.FindElement(applicationPoolsCollection, "add", "name", AppPoolName)
            If addElement Is Nothing Then
                Throw New InvalidOperationException("Element not found!")
            End If

            addElement("managedPipelineMode") = "Classic"

            serverManager.CommitChanges()

            Return MyBase.OnStart()
        End Using
    End Function
End Class