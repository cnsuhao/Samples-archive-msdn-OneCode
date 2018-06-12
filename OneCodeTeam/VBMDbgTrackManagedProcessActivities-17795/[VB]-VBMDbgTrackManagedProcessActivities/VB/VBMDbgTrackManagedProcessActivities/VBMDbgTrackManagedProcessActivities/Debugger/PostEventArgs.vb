'************************** Module Header ******************************\
' Module Name:  PostEventArgs.vb
' Project:      VBMDbgTrackManagedProcessActivities
' Copyright (c) Microsoft Corporation.
' 
' The class ErrorEventArgs defines the arguments used by the PostEvent event.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************/


Namespace Debugger
    Public Class PostEventArgs
        Inherits EventArgs
        Public Property EventMessage() As String
    End Class
End Namespace
