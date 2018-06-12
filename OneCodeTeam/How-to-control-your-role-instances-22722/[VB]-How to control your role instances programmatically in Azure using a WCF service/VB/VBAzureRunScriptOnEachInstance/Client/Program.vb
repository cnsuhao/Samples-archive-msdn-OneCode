'***************************** Module Header ******************************\
' Module Name:  Program.vb
' Project:      ConsoleApplication1
' Copyright (c) Microsoft Corporation.
'
' This is a client project which will run on your on-promise computer.
'
' Inovke the WCF service directly.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.ServiceModel
Imports InstanceController.Interface
Module Program

    Sub Main()
        Dim binding As New BasicHttpBinding()
        'This is a example 
        Using channel As New ChannelFactory(Of IInstanceController)(binding, "http://127.0.0.1:3721/InternalService")
            Dim proxy As IInstanceController = channel.CreateChannel()
            If proxy.RunScriptOnEveryInstance("batcontainer", "ConsoleApplication1.exe") Then
                Console.WriteLine("The file is executed correctly!")
            Else
                Console.WriteLine("The file can't be executed correctly!")
            End If
            Console.Read()
        End Using
    End Sub

End Module
