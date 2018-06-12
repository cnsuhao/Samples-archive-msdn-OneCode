'****************************** Module Header ******************************\
' Module Name:  Module1.vb
' Project:      ConsoleApplication1
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to access the WCF service via Access control
' service token. Here we create a Silverlight application and a normal Console 
' application client. The Token format is SWT, and we will use password as the 
' Service identities.
'
' The Console client first sends HttpWebRequest to ACS and gets Token back, 
' then re-sends a request to service with Token in http header to get data from
' WCF service.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Net
Imports System.Collections.Specialized
Imports System.Text
Imports System.IO
Imports System.Web

Module Module1
    ''' <summary>
    ''' Necessary variables from ACS Portal.
    ''' </summary>
    ''' <remarks></remarks>
    Dim serviceNamespace As String = "<Your ACS namespace>"
    Dim acsHostUrl As String = "accesscontrol.windows.net"
    Dim realm As String = "<Your ACS service path>"
    Dim userUrl As String = "<Your user service path>"
    Dim uid As String = "<Your service identity name>"
    Dim pwd As String = "<Your service identity password>"

    ''' <summary>
    ''' Access the service via ACS Token.
    ''' </summary>
    ''' <remarks></remarks>
    Sub Main()
        Dim token As String = GetTokenFromACS(realm)

        Dim client As New WebClient()

        Dim headerValue As String = String.Format("WRAP access_token=""{0}""", token)

        Dim request As HttpWebRequest = TryCast(HttpWebRequest.Create(userUrl), HttpWebRequest)
        request.ContentLength = 0
        request.Method = "GET"
        request.Headers("Authorization") = headerValue

        Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
        Using reader As New StreamReader(response.GetResponseStream())
            Dim obj As String = reader.ReadToEnd()
            Console.Write(obj)
            Console.ReadLine()
        End Using
    End Sub
    ''' <summary>
    ''' Get Token from ACS.
    ''' </summary>
    ''' <param name="scope"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTokenFromACS(scope As String) As String
        Dim wrapPassword As String = pwd
        Dim wrapUsername As String = uid

        ' Request a token from ACS
        Dim client As New WebClient()
        client.BaseAddress = String.Format("https://{0}.{1}", serviceNamespace, acsHostUrl)

        Dim values As New NameValueCollection()
        values.Add("wrap_name", wrapUsername)
        values.Add("wrap_password", wrapPassword)
        values.Add("wrap_scope", scope)

        Dim responseBytes As Byte() = client.UploadValues("WRAPv0.9/", "POST", values)

        Dim response As String = Encoding.UTF8.GetString(responseBytes)

        Console.WriteLine(vbLf & "received token from ACS: {0}" & vbLf, response)

        Return HttpUtility.UrlDecode(response.Split("&"c).[Single](Function(value) value.StartsWith("wrap_access_token=", StringComparison.OrdinalIgnoreCase)).Split("="c)(1))
    End Function
End Module
