'************************** Module Header ******************************\
' Module Name:  MTAThreadHelper.vb
' Project:      VBMDbgTrackManagedProcessActivities
' Copyright (c) Microsoft Corporation.
' 
' The main thread of WinForm Application is STAThread, but the debugger needs
' MTAThread,
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/

Imports System.Threading


Public Class MTAThreadHelper
    Public Shared Function RunInMTAThread(ByVal start As ParameterizedThreadStart,
                                          ByVal parameter As Object) As Thread
        Dim thread As New Thread(start)
        Dim result = thread.TrySetApartmentState(ApartmentState.MTA)
        thread.Start(parameter)
        Return thread
    End Function

    Public Shared Function RunInMTAThread(ByVal start As ThreadStart) As Thread
        Dim thread As New Thread(start)
        Dim result = thread.TrySetApartmentState(ApartmentState.MTA)
        thread.Start()
        Return thread
    End Function
End Class
