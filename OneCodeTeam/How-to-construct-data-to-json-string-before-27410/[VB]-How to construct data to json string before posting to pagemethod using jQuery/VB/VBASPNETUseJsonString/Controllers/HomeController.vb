'***************************** Module Header ******************************\
' Module Name:	HomeController.vb
' Project:		VBASPNETUseJsonString
' Copyright (c) Microsoft Corporation.
' 
' This sample shows how to post complex data to MVC server side using json string.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports Newtonsoft.Json

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Home
    Public Function Index() As ActionResult
        Return View()
    End Function

    <HttpPost> _
    Public Function saveUserInfos(data As String) As ActionResult
        Try
            Dim userInfoList = JsonConvert.DeserializeObject(Of IEnumerable(Of UserInfo))(data)
            'Save these data to Your DB
            Return Json("Data saved successfuly.")
        Catch e As JsonReaderException
            Return Json(e.Message)
        End Try
    End Function


End Class