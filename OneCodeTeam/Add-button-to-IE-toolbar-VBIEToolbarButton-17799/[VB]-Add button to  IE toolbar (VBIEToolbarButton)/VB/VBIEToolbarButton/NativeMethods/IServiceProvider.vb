'*************************** Module Header ******************************'
' Module Name:  IServiceProvider.vb
' Project:	    VBIEToolbarButton
' Copyright (c) Microsoft Corporation.
' 
' Provides a generic access mechanism to locate a GUID-identified service. 
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

Imports System.Runtime.InteropServices

Namespace NativeMethods
    <ComImport()> _
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    <Guid("6d5140c1-7436-11ce-8034-00aa006009fa")> _
    Friend Interface IServiceProvider
        ''' <summary>
        ''' Acts as the factory method for any services exposed through an 
        ''' implementation of IServiceProvider.
        ''' </summary>
        Sub QueryService(ByRef guid As System.Guid, _
                         ByRef riid As System.Guid, _
                         <Out(), MarshalAs(UnmanagedType.Interface)> ByRef Obj As Object)
    End Interface
End Namespace
