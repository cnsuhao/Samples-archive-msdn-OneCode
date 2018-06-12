'**************************** Module Header ******************************\
' Module Name:	WebRole
' Project:		VBAzureChangeAppPoolIdentity
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to change App pool identity in Azure
'
' WebRole.vb
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/

Imports Microsoft.WindowsAzure.ServiceRuntime
Imports Microsoft.Web.Administration
Imports System.DirectoryServices

Public Class WebRole
    Inherits RoleEntryPoint
    Public Overrides Function OnStart() As Boolean
        ' Name of the site. Default name Azure gives to website is "Web". If this is changed, 
        ' you would need to assign the name of the site to siteName variable. This can be 
        ' obtained from ServiceDefinition.def file.
        Dim siteName = "Web"

        ' Please change the domain\user to domain account that you would like to configure 
        ' for AppPool to run under
        Dim userName = "Domain\user"

        ' Password of the above specified domain user
        Dim password = "********"

        ' This variable is used to iterate through list of Application pools
        Dim metabasePath = "IIS://localhost/W3SVC/AppPools"

        ' This variable is to get the name of AppPool that is created by Azure for current Azure service
        Dim appPoolName = ""


        Using server_Manager As New ServerManager()
            'Get the name of the appPool that is created by Azure
            appPoolName = server_Manager.Sites(RoleEnvironment.CurrentRoleInstance.Id + "_" & siteName).Applications.First().ApplicationPoolName
        End Using

        ' Get list of appPools at specified metabasePath location
        Using appPools As New DirectoryEntry(metabasePath)
            ' From the list of appPools, Search and get the appPool that is created by Azure 
            Using azureAppPool As DirectoryEntry = appPools.Children.Find(appPoolName, "IIsApplicationPool")
                If azureAppPool IsNot Nothing Then

                    ' Set the AppPoolIdentityType to 3. This is equalient to MD_APPPOOL_IDENTITY_TYPE_SPECIFICUSER -  
                    ' The application pool runs as a specified user account.
                    ' Refer to:
                    ' http://www.microsoft.com/technet/prodtechnol/WindowsServer2003/Library/IIS/e3a60d16-1f4d-44a4-9866-5aded450956f.mspx?mfr=true, 
                    ' http://learn.iis.net/page.aspx/624/application-pool-identities/ 
                    ' for more info on AppPoolIdentityType
                    azureAppPool.InvokeSet("AppPoolIdentityType", New [Object]() {3})

                    ' Configure username for the AppPool with above specified username                      
                    azureAppPool.InvokeSet("WAMUserName", New [Object]() {userName})

                    ' Configure password for the AppPool with above specified password                      
                    azureAppPool.InvokeSet("WAMUserPass", New [Object]() {password})

                    ' Write above settings to IIS metabase
                    azureAppPool.Invoke("SetInfo", Nothing)

                    ' Commit the above configuration changes that are written to metabase
                    azureAppPool.CommitChanges()

                End If
            End Using

            Return MyBase.OnStart()
        End Using
    End Function
End Class