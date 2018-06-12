'************************** Module Header ******************************'
' Module Name:  IMACManager.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' This interface defines the basic methods used to get the MAC of local or 
' remote host.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.Net
Imports System.Net.NetworkInformation


Public Interface IMACManager

    ''' <summary>
    ''' Get the MAC of local adapters.
    ''' </summary>
    Function GetLocalAdaptersMAC() As Dictionary(Of String, PhysicalAddress)

    ''' <summary>
    ''' Get the MAC of remote host.
    ''' </summary>
    ''' <param name="credential">
    ''' If necessary, we have to supply the credential to connect to 
    ''' remote host.
    ''' </param>
    Function GetRemoteMachineMAC(ByVal remoteHost As String,
                                 ByVal credential As NetworkCredential) _
                             As Dictionary(Of String, PhysicalAddress)

    ''' <summary>
    ''' Refresh the result.
    ''' </summary>
    Sub Refresh()

End Interface

