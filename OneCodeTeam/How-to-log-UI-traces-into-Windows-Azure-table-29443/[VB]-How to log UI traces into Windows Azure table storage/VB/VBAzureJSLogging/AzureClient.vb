'***************************** Module Header ******************************\
' Module Name: HomeController.vb
' Project:     VBAzureJSLogging
' Copyright (c) Microsoft Corporation
'
' AzureClient
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/
Imports Microsoft.WindowsAzure.Storage.Table
Imports Microsoft.WindowsAzure.Storage
Imports Microsoft.WindowsAzure.Storage.Shared.Protocol

Public Class AzureClient

    Public Shared StorageAccount As New CloudStorageAccount(New Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("{Your-Storage-Account}", "{Your-Storage-Acccount-Key}"), False)

    ''' <summary>
    ''' Enable Table Service CORS
    ''' Make sure log table can be use.
    ''' </summary>
    Public Shared Sub TableServiceInitialization()
        Dim tableClient As CloudTableClient = StorageAccount.CreateCloudTableClient()
        ' Aslo check the log table make sure it has been created.
        Dim table As CloudTable = tableClient.GetTableReference("log")
        table.CreateIfNotExists()
        Dim tableServiceProperties As New ServiceProperties()
        tableServiceProperties.HourMetrics = Nothing
        tableServiceProperties.MinuteMetrics = Nothing
        tableServiceProperties.Logging = Nothing

        ' Enable and Configure CORS
        ConfigureCors(tableServiceProperties)
        tableClient.SetServiceProperties(tableServiceProperties)
    End Sub

    ''' <summary>
    ''' Adds CORS rule to the service properties.
    ''' </summary>
    ''' <param name="serviceProperties">ServiceProperties</param>
    Private Shared Sub ConfigureCors(serviceProperties As ServiceProperties)
        serviceProperties.Cors = New CorsProperties()
        ' 30 minutes
        serviceProperties.Cors.CorsRules.Add(New CorsRule() With { _
             .AllowedHeaders = New List(Of String)() From { _
                "*" _
            }, _
             .AllowedMethods = CorsHttpMethods.Put Or CorsHttpMethods.[Get] Or CorsHttpMethods.Head Or CorsHttpMethods.Post, _
             .AllowedOrigins = New List(Of String)() From { _
                "*" _
            }, _
             .ExposedHeaders = New List(Of String)() From { _
                "*" _
            }, _
             .MaxAgeInSeconds = 1800 _
        })
    End Sub
End Class
