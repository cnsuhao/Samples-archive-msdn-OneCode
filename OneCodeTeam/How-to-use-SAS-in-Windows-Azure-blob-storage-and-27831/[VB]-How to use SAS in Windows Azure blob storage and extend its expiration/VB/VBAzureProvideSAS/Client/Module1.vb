'***************************** Module Header ******************************\
' Module Name: Module1.vb
' Project:     VBAzureProvideSAS
' Copyright (c) Microsoft Corporation.
' 
' To secure your Windows Azure storage, you need to generate SAS token to assign 
' user permission for CRUD. This sample will demonstrate how to generate SAS
' by using Web API, and get the SAS from client.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports System.Net

Module Module1

    Sub Main()
        Dim partitionKey As String = "<Partition Key>"


        Using client = New WebClient()
            client.Headers(HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"
            Dim data = Convert.ToString("=") & partitionKey
            Dim result = client.UploadString("http://localhost:12305/api/SASGenerater", "POST", data)
            Console.WriteLine(String.Format("Your SAS token is:{0}", result))
        End Using
        Console.ReadLine()
    End Sub

End Module
