'****************************** Module Header ******************************\
' Module Name:    Module1.vb
' Project:        VBWCFClientTest
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to use both User Name and Client Certificates 
' as client credential type in WCF. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/


Module Module1

    Sub Main()

        Dim output As String = ""
        ' Define the proxy 
        Dim c As New ServiceReference1.Service1Client()

        c.ClientCredentials.UserName.UserName = "Melissa"
        c.ClientCredentials.UserName.Password = "123@abc"
        output = c.GetData("123")
        Console.WriteLine(output)
        Console.ReadLine()

    End Sub

End Module
