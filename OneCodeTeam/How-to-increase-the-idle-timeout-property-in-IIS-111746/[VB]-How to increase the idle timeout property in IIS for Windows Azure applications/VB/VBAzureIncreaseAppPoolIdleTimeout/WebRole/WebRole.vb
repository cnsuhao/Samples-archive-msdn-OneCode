'**************************** Module Header ******************************\
' Module Name:	WebRole.vb
' Project:		WebRole
' Copyright (c) Microsoft Corporation.
' 
' App-pool Idle Time-out is the amount of time (in minutes) a worker process 
' will remain idle before it shuts down. A worker process is idle if it is 
' not processing requests and no new requests are received.   
' Idle Time-out property can be changed in IIS after you RDP into the VM's of
' Azure, but this is not recommended and remote desktop must be used only
' for basic troubleshooting. Any changes done on the Virtual Machine manually
' after RDP will not be persisted.This is because, in the event of any hardware 
' failure or automatic OS upgrade in Azure cloud, Fabric controller will bring 
' down the VM instance and automatically deploy your package on another VM/on 
' the same VM (Virtual machine). If this happens all the changes done manually 
' on the VM will be lost. Therefore the recommended approach is to perform all 
' the operation by code and deploy the package.
' You can implement this by using ServerManager class defined in Microsoft.Web.Administration DLL.
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


Public Class WebRole
    Inherits RoleEntryPoint

    Public Overrides Function OnStart() As Boolean

        Dim iisManager As New ServerManager()
        Dim app As Application = iisManager.Sites(RoleEnvironment.CurrentRoleInstance.Id + "_Web").Applications(0)

        '================ idle timeout ====================================================//               
        Dim dt As String = iisManager.ApplicationPoolDefaults.ProcessModel.IdleTimeout.ToString()
        Dim ts As New TimeSpan(0, 60, 0)
        iisManager.ApplicationPoolDefaults.ProcessModel.IdleTimeout = ts



        '================ Enable or disable static/Dynamic compression ===================//
        Dim config As Configuration = iisManager.Sites(RoleEnvironment.CurrentRoleInstance.Id + "_Web").GetWebConfiguration()
        Dim urlCompressionSection As ConfigurationSection = config.GetSection("system.webServer/urlCompression")
        urlCompressionSection("doStaticCompression") = True
        urlCompressionSection("doDynamicCompression") = True

        '================ To change Application pool name ================================//

        app.ApplicationPoolName = "ASP.NET v4.0 Classic"
        ' Commit the changes done to server manager. 

        iisManager.CommitChanges()

        Return MyBase.OnStart()

    End Function

End Class
