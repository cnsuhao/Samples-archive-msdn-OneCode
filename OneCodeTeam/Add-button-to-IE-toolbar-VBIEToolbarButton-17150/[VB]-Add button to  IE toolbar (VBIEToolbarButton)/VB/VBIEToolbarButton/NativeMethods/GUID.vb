'*************************** Module Header ******************************'
' Module Name:  GUID.vb
' Project:	    VBIEToolbarButton
' Copyright (c) Microsoft Corporation.
' 
' This class represents a unique identifier. 
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.Runtime
Imports System.Runtime.InteropServices

Namespace NativeMethods
    <StructLayout(LayoutKind.Sequential)>
    Public Class GUID

        Public _guid As System.Guid

        <TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")>
        Public Sub New(ByVal pguid As System.Guid)
            Me._guid = pguid
        End Sub
    End Class
End Namespace
