'****************************** Module Header ******************************\
' Project Name:   VBAzureWebRoleBackendProcessing
' Module Name:    Processor
' File Name:      Program.vb
' Copyright (c) Microsoft Corporation
'
' This console application instantiates a BackendProcessor object and start it up.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/


Imports VBAzureWebRoleBackendProcessing.Common

Class Program
    Public Shared Sub Main()
        ' Trace to the console window.
        Trace.Listeners.Add(New ConsoleTraceListener())

        ' Start-up the backend processor.
        Dim backendProcessor = New BackendProcessor()
        backendProcessor.Start()

        ' Pause.
        Console.ReadKey()
    End Sub
End Class