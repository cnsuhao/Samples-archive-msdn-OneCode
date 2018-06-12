'****************************** Module Header ******************************\
' Module Name:  Default.aspx.vb
' Project:      VBAzureDeploymentSlot
' Copyright (c) Microsoft Corporation.
'
' This page is used to retrieve Deployment ID of Staging and Production state role,
' then compare with RoleEnvironment.DeploymentID properties.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports Microsoft.WindowsAzure.ServiceRuntime
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports System.Net

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' You basic information of the Deployment of Azure application.
        Dim deploymentId As String = RoleEnvironment.DeploymentId
        Dim subscriptionID As String = "<Your subscription ID>"
        Dim thrumbnail As String = "<Your certificate thumbnail print>"
        Dim hostedServiceName As String = "<Your hosted service name>"
        Dim productionString As String = String.Format("https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}", subscriptionID, hostedServiceName, "Production")
        Dim requestUri As New Uri(productionString)

        ' Add client certificate.
        Dim store As New X509Store(StoreName.My, StoreLocation.LocalMachine)
        store.Open(OpenFlags.OpenExistingOnly)
        Dim collection As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindByThumbprint, thrumbnail, False)
        store.Close()

        If collection.Count <> 0 Then
            Dim certificate As X509Certificate2 = collection(0)
            Dim httpRequest As HttpWebRequest = DirectCast(HttpWebRequest.Create(requestUri), HttpWebRequest)
            httpRequest.ClientCertificates.Add(certificate)
            httpRequest.Headers.Add("x-ms-version", "2011-10-01")
            httpRequest.KeepAlive = False
            Dim httpResponse As HttpWebResponse = TryCast(httpRequest.GetResponse(), HttpWebResponse)

            ' Get response stream from Management API.
            Dim stream As Stream = httpResponse.GetResponseStream()
            Dim result As String = String.Empty
            Using reader As New StreamReader(stream)

                result = reader.ReadToEnd()
            End Using
            If result Is Nothing OrElse result.Trim() = String.Empty Then
                Return
            End If
            Dim document As XDocument = XDocument.Parse(result)
            Dim serverID As String = String.Empty
            Dim list = From item In document.Descendants(XName.[Get]("PrivateID", "http://schemas.microsoft.com/windowsazure"))
                       Select item

            serverID = list.First().Value
            Response.Write("Check Production: <br />")
            Response.Write("DeploymentID : " & deploymentId & "<br> ServerID :" & serverID)
            If deploymentId.Equals(serverID) Then
                lbStatus.Text = "Production"
            Else
                ' If the application not in Production slot, try to check Staging slot.
                Dim stagingString As String = String.Format("https://management.core.windows.net/{0}/services/hostedservices/{1}/deploymentslots/{2}", subscriptionID, hostedServiceName, "Staging")
                Dim stagingUri As New Uri(stagingString)
                httpRequest = DirectCast(HttpWebRequest.Create(stagingUri), HttpWebRequest)
                httpRequest.ClientCertificates.Add(certificate)
                httpRequest.Headers.Add("x-ms-version", "2011-10-01")
                httpRequest.KeepAlive = False
                httpResponse = TryCast(httpRequest.GetResponse(), HttpWebResponse)
                stream = httpResponse.GetResponseStream()
                result = String.Empty
                Using reader As New StreamReader(stream)

                    result = reader.ReadToEnd()
                End Using
                If result Is Nothing OrElse result.Trim() = String.Empty Then
                    Return
                End If
                document = XDocument.Parse(result)
                serverID = String.Empty
                list = From item In document.Descendants(XName.[Get]("PrivateID", "http://schemas.microsoft.com/windowsazure"))
                       Select item

                serverID = list.First().Value
                Response.Write("<br /> Check Staging:")
                Response.Write("<br /> DeploymentID : " & deploymentId & "<br> ServerID :" & serverID)
                If deploymentId.Equals(serverID) Then
                    lbStatus.Text = "Staging"
                Else
                    lbStatus.Text = "Do not find this id"
                End If
            End If
            httpResponse.Close()
            stream.Close()
        End If
    End Sub

End Class