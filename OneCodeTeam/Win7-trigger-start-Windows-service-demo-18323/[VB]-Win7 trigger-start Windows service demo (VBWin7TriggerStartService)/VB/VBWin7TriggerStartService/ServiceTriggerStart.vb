﻿'*********************************** Module Header ***********************************'
' Module Name:  ServiceTriggerStart.vb
' Project:      VBWin7TriggerStartService
' Copyright (c) Microsoft Corporation.
' 
' The file implements functions to set and get the configuration of service trigger 
' start.
' 
' * ServiceTriggerStart.IsSupported 
'   Check whether the current system supports service trigger start. Service trigger 
'   events are not supported until Windows Server 2008 R2 and Windows 7. Windows Server 
'   2008 R2 and Windows 7 have major version 6 and minor version 1.
'
' * ServiceTriggerStart.IsTriggerStartService
'   Determine whether the specified service is configured to trigger start.
' 
' * ServiceTriggerStart.SetServiceTriggerStartOnUSBArrival
'   Set the service to trigger-start when a generic USB disk becomes available.
' 
' * ServiceTriggerStart.SetServiceTriggerStartOnIPAddressArrival
'   Set the service to trigger-start when the first IP address on the TCP/IP networking 
'   stack becomes available, and trigger-stop when the last IP address on the TCP/IP 
'   networking stack becomes unavailable.
'  
' Services and background processes have tremendous influence on the overall 
' performance of the system. If we could just cut down on the total number of services, 
' we would reduce the total power consumption and increase the overall stability of 
' the system. The Windows 7 Service Control Manager has been extended so that a service 
' can be automatically started and stopped when a specific system event, or trigger, 
' occurs on the system. The new mechanism is called Service Trigger Event. A service 
' can register to be started or stopped when a trigger event occurs. This eliminates 
' the need for services to start when the system starts, or for services to poll or 
' actively wait for an event; a service can start when it is needed, instead of 
' starting automatically whether or not there is work to do. Examples of predefined 
' trigger events include arrival of a device of a specified device interface class or 
' availability of a particular firewall port. A service can also register for a custom 
' trigger event generated by an Event Tracing for Windows (ETW) provider.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
' EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
' MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************************'

#Region "Imports directives"

Imports System.Runtime.InteropServices

#End Region


Friend Class ServiceTriggerStart

#Region "SupportServiceTriggerStart"

    ''' <summary>
    ''' Check whether the current system supports service trigger start
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>
    ''' Service trigger events are not supported until Windows Server 2008 R2 and 
    ''' Windows 7. Windows Server 2008 R2 and Windows 7 have major version 6 and minor
    ''' version 1.
    ''' </remarks>
    Public Shared ReadOnly Property IsSupported() As Boolean
        Get
            Return (Environment.OSVersion.Version >= New Version(6, 1))
        End Get
    End Property

#End Region


#Region "GetServiceTriggerInfo"

    ''' <summary>
    ''' Determine whether the specified service is configured to trigger start
    ''' </summary>
    ''' <param name="serviceName">The name of the service</param>
    ''' <returns></returns>
    Public Shared Function IsTriggerStartService(ByVal serviceName As String) As Boolean

        ' Open the local default service control manager database
        Dim schSCManager As SafeServiceHandle = NativeMethods.OpenSCManager( _
        Nothing, Nothing, ServiceControlAccessRights.SC_MANAGER_CONNECT)

        If schSCManager.IsInvalid Then
            ' If the handle is invalid, get the last Win32 error and throw a 
            ' Win32Exception
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error)
        End If

        Try
            ' Try to open the service to query its config
            Dim schService As SafeServiceHandle = NativeMethods.OpenService( _
            schSCManager, serviceName, ServiceAccessRights.SERVICE_QUERY_CONFIG)

            If schService.IsInvalid Then
                ' If the handle is invalid, get the last Win32 error and throw a 
                ' Win32Exception
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error)
            End If

            Try
                Return ServiceTriggerStart.IsTriggerStartService(schService)
            Finally
                schService.Close()
            End Try
        Finally
            schSCManager.Close()
        End Try

    End Function


    ''' <summary>
    ''' Determine whether the specified service is configured to trigger start
    ''' </summary>
    ''' <param name="hService">
    ''' A handle to the service. This handle is returned by the OpenService or 
    ''' CreateService function and must have the SERVICE_QUERY_CONFIG access right.
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsTriggerStartService(ByVal hService As SafeServiceHandle) _
    As Boolean

        ' Query the service trigger info size of the current serivce
        Dim cbBytesNeeded As Integer = -1
        NativeMethods.QueryServiceConfig2( _
        hService, ServiceConfig2InfoLevel.SERVICE_CONFIG_TRIGGER_INFO, IntPtr.Zero, 0, _
        cbBytesNeeded)

        If (cbBytesNeeded = -1) Then
            ' If failed, get the last Win32 error and throw a Win32Exception
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error)
        End If

        ' Allocate memory for the service trigger info struct
        Dim pBuffer As IntPtr = Marshal.AllocHGlobal(cbBytesNeeded)

        Try
            ' Retrieve the service trigger info
            If Not NativeMethods.QueryServiceConfig2( _
            hService, ServiceConfig2InfoLevel.SERVICE_CONFIG_TRIGGER_INFO, pBuffer, _
            cbBytesNeeded, cbBytesNeeded) Then
                ' If failed, get the last Win32 error and throw a Win32Exception
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error)
            End If

            Dim sti As SERVICE_TRIGGER_INFO = DirectCast(Marshal.PtrToStructure( _
            pBuffer, GetType(SERVICE_TRIGGER_INFO)), SERVICE_TRIGGER_INFO)

            '' You can also retrieve more trigger information of the service
            'For i = 0 To sti.cTriggers - 1
            '    ' Calculate the address of the SERVICE_TRIGGER struct
            '    Dim pst As New IntPtr( _
            '    CLng(sti.pTriggers) + i * Marshal.SizeOf(GetType(SERVICE_TRIGGER)))

            '    ' Marshal the native SERVICE_TRIGGER struct to .NET struct
            '    Dim st As SERVICE_TRIGGER = DirectCast(Marshal.PtrToStructure( _
            '    pst, GetType(SERVICE_TRIGGER)), SERVICE_TRIGGER)

            '    ' Get more information from the SERVICE_TRIGGER struct 
            '    ' ...
            'Next

            Return (sti.cTriggers > 0)

        Finally
            ' Free the memory of the service trigger info struct
            If (pBuffer <> IntPtr.Zero) Then Marshal.FreeHGlobal(pBuffer)
        End Try

    End Function

#End Region


#Region "SetServiceTriggerStartOnUSBArrival"

    ''' <summary>
    ''' The GUID_DEVINTERFACE_DISK device interface class is defined for hard disk 
    ''' storage devices.
    ''' http://msdn.microsoft.com/en-us/library/bb663157.aspx
    ''' </summary>
    Private Shared ReadOnly GUID_DEVINTERFACE_DISK As Guid = _
    New Guid("53F56307-B6BF-11D0-94F2-00A0C91EFB8B")

    ''' <summary>
    ''' Hardware ID generated by the USB storage port driver.
    ''' </summary>
    Private Const USBHardwareId As String = "USBSTOR\GenDisk"


    ''' <summary>
    ''' Set the service to trigger-start when a generic USB disk becomes available.
    ''' </summary>
    ''' <param name="serviceName">The name of the service</param>
    Public Shared Sub SetServiceTriggerStartOnUSBArrival(ByVal serviceName As String)

        ' Open the local default service control manager database
        Dim schSCManager As SafeServiceHandle = NativeMethods.OpenSCManager( _
        Nothing, Nothing, ServiceControlAccessRights.SC_MANAGER_CONNECT)

        If schSCManager.IsInvalid Then
            ' If the handle is invalid, get the last Win32 error and throw a 
            ' Win32Exception
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error)
        End If

        Try
            ' Try to open the service with the SERVICE_CHANGE_CONFIG access right
            Dim schService As SafeServiceHandle = NativeMethods.OpenService( _
            schSCManager, serviceName, ServiceAccessRights.SERVICE_CHANGE_CONFIG)

            If schService.IsInvalid Then
                ' If the handle is invalid, get the last Win32 error and throw a 
                ' Win32Exception
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error)
            End If

            Try
                ServiceTriggerStart.SetServiceTriggerStartOnUSBArrival(schService)
            Finally
                schService.Close()
            End Try
        Finally
            schSCManager.Close()
        End Try

    End Sub


    ''' <summary>
    ''' Set the service to trigger-start when a generic USB disk becomes available.
    ''' </summary>
    ''' <param name="hService">
    ''' A handle to the service. This handle is returned by the OpenService or 
    ''' CreateService function and must have the SERVICE_CHANGE_CONFIG access right.
    ''' </param>
    Public Shared Sub SetServiceTriggerStartOnUSBArrival(ByVal hService As SafeServiceHandle)

        Dim pGuidUSBDevice As IntPtr = IntPtr.Zero
        Dim pUSBHardwareId As IntPtr = IntPtr.Zero
        Dim pDeviceData As IntPtr = IntPtr.Zero
        Dim pServiceTrigger As IntPtr = IntPtr.Zero
        Dim pServiceTriggerInfo As IntPtr = IntPtr.Zero

        Try
            ' Marshal the Guid struct GUID_DEVINTERFACE_DISK to native memory

            pGuidUSBDevice = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(Guid)))
            Marshal.StructureToPtr(GUID_DEVINTERFACE_DISK, pGuidUSBDevice, False)

            ' Allocate and set the SERVICE_TRIGGER_SPECIFIC_DATA_ITEM structure

            Dim deviceData As SERVICE_TRIGGER_SPECIFIC_DATA_ITEM
            deviceData.dwDataType = ServiceTriggerDataType.SERVICE_TRIGGER_DATA_TYPE_STRING
            deviceData.cbData = (USBHardwareId.Length + 1) * 2
            pUSBHardwareId = Marshal.StringToHGlobalUni(USBHardwareId)
            deviceData.pData = pUSBHardwareId

            ' Marshal SERVICE_TRIGGER_SPECIFIC_DATA_ITEM to native memory

            pDeviceData = Marshal.AllocHGlobal( _
            Marshal.SizeOf(GetType(SERVICE_TRIGGER_SPECIFIC_DATA_ITEM)))
            Marshal.StructureToPtr(deviceData, pDeviceData, False)

            ' Allocate and set the SERVICE_TRIGGER structure

            Dim serviceTrigger As New SERVICE_TRIGGER
            serviceTrigger.dwTriggerType = _
            ServiceTriggerType.SERVICE_TRIGGER_TYPE_DEVICE_INTERFACE_ARRIVAL
            serviceTrigger.dwAction = _
            ServiceTriggerAction.SERVICE_TRIGGER_ACTION_SERVICE_START
            serviceTrigger.pTriggerSubtype = pGuidUSBDevice
            serviceTrigger.cDataItems = 1
            serviceTrigger.pDataItems = pDeviceData

            ' Marshal the SERVICE_TRIGGER struct to native memory

            pServiceTrigger = Marshal.AllocHGlobal( _
            Marshal.SizeOf(GetType(SERVICE_TRIGGER)))
            Marshal.StructureToPtr(serviceTrigger, pServiceTrigger, False)

            ' Allocate and set the SERVICE_TRIGGER_INFO structure

            Dim serviceTriggerInfo As New SERVICE_TRIGGER_INFO
            serviceTriggerInfo.cTriggers = 1
            serviceTriggerInfo.pTriggers = pServiceTrigger

            ' Marshal the SERVICE_TRIGGER_INFO struct to native memory

            pServiceTriggerInfo = Marshal.AllocHGlobal( _
            Marshal.SizeOf(GetType(SERVICE_TRIGGER_INFO)))
            Marshal.StructureToPtr(serviceTriggerInfo, pServiceTriggerInfo, False)

            ' Call ChangeServiceConfig2 with the SERVICE_CONFIG_TRIGGER_INFO level 
            ' and pass to it the address of the SERVICE_TRIGGER_INFO structure

            If Not NativeMethods.ChangeServiceConfig2( _
            hService, ServiceConfig2InfoLevel.SERVICE_CONFIG_TRIGGER_INFO, _
            pServiceTriggerInfo) Then
                ' If the handle is invalid, get the last Win32 error and throw a 
                ' Win32Exception
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error)
            End If

        Finally
            ' Clean up the native memory

            If (pGuidUSBDevice <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pGuidUSBDevice)
            End If
            If (pUSBHardwareId <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pUSBHardwareId)
            End If
            If (pDeviceData <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pDeviceData)
            End If
            If (pServiceTrigger <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pServiceTrigger)
            End If
            If (pServiceTriggerInfo <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pServiceTriggerInfo)
            End If
        End Try

    End Sub

#End Region


#Region "SetServiceTriggerStartOnIPAddressArrival"

    ''' <summary>
    ''' The event is triggered when the first IP address on the TCP/IP networking stack 
    ''' becomes available. 
    ''' </summary>
    Private Shared ReadOnly NETWORK_MANAGER_FIRST_IP_ADDRESS_ARRIVAL_GUID As Guid = _
    New Guid("4F27F2DE-14E2-430B-A549-7CD48CBC8245")

    ''' <summary>
    ''' The event is triggered when the last IP address on the TCP/IP networking stack 
    ''' becomes unavailable.
    ''' </summary>
    Private Shared ReadOnly NETWORK_MANAGER_LAST_IP_ADDRESS_REMOVAL_GUID As Guid = _
    New Guid("CC4BA62A-162E-4648-847A-B6BDF993E335")


    ''' <summary>
    ''' Set the service to trigger-start when the first IP address on the TCP/IP 
    ''' networking stack becomes available, and trigger-stop when the last IP 
    ''' address on the TCP/IP networking stack becomes unavailable.
    ''' </summary>
    ''' <param name="serviceName">The name of the service</param>
    Public Shared Sub SetServiceTriggerStartOnIPAddressArrival(ByVal serviceName As String)

        ' Open the local default service control manager database
        Dim schSCManager As SafeServiceHandle = NativeMethods.OpenSCManager( _
        Nothing, Nothing, ServiceControlAccessRights.SC_MANAGER_CONNECT)

        If schSCManager.IsInvalid Then
            ' If the handle is invalid, get the last Win32 error and throw a 
            ' Win32Exception
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error)
        End If

        Try
            ' Try to open the service with the SERVICE_CHANGE_CONFIG access right
            Dim schService As SafeServiceHandle = NativeMethods.OpenService( _
            schSCManager, serviceName, ServiceAccessRights.SERVICE_CHANGE_CONFIG)

            If schService.IsInvalid Then
                ' If the handle is invalid, get the last Win32 error and throw a 
                ' Win32Exception
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error)
            End If

            Try
                ServiceTriggerStart.SetServiceTriggerStartOnIPAddressArrival(schService)
            Finally
                schService.Close()
            End Try
        Finally
            schSCManager.Close()
        End Try

    End Sub


    ''' <summary>
    ''' Set the service to trigger-start when the first IP address on the TCP/IP 
    ''' networking stack becomes available, and trigger-stop when the last IP 
    ''' address on the TCP/IP networking stack becomes unavailable.
    ''' </summary>
    ''' <param name="hService">
    ''' A handle to the service. This handle is returned by the OpenService or 
    ''' CreateService function and must have the SERVICE_CHANGE_CONFIG access right.
    ''' </param>
    ''' <remarks></remarks>
    Public Shared Sub SetServiceTriggerStartOnIPAddressArrival(ByVal hService As SafeServiceHandle)

        Dim pGuidIpAddressArrival As IntPtr = IntPtr.Zero
        Dim pGuidIpAddressRemoval As IntPtr = IntPtr.Zero
        Dim pServiceTriggers As IntPtr = IntPtr.Zero
        Dim pServiceTriggerInfo As IntPtr = IntPtr.Zero

        Try
            ' Marshal Guid struct NETWORK_MANAGER_FIRST_IP_ADDRESS_ARRIVAL_GUID 
            ' and NETWORK_MANAGER_LAST_IP_ADDRESS_REMOVAL_GUID to native memory

            Dim cbGuid As Integer = Marshal.SizeOf(GetType(Guid))
            pGuidIpAddressArrival = Marshal.AllocHGlobal(cbGuid)
            Marshal.StructureToPtr(NETWORK_MANAGER_FIRST_IP_ADDRESS_ARRIVAL_GUID, _
                                   pGuidIpAddressArrival, False)
            pGuidIpAddressRemoval = Marshal.AllocHGlobal(cbGuid)
            Marshal.StructureToPtr(NETWORK_MANAGER_LAST_IP_ADDRESS_REMOVAL_GUID, _
                                   pGuidIpAddressRemoval, False)

            ' Allocate and set the SERVICE_TRIGGER structure for 
            ' NETWORK_MANAGER_FIRST_IP_ADDRESS_ARRIVAL_GUID to start the service

            Dim serviceTrigger1 As New SERVICE_TRIGGER
            serviceTrigger1.dwTriggerType = _
            ServiceTriggerType.SERVICE_TRIGGER_TYPE_IP_ADDRESS_AVAILABILITY
            serviceTrigger1.dwAction = _
            ServiceTriggerAction.SERVICE_TRIGGER_ACTION_SERVICE_START
            serviceTrigger1.pTriggerSubtype = pGuidIpAddressArrival

            ' Allocate and set the SERVICE_TRIGGER structure for 
            ' NETWORK_MANAGER_LAST_IP_ADDRESS_REMOVAL_GUID to stop the service

            Dim serviceTrigger2 As New SERVICE_TRIGGER
            serviceTrigger2.dwTriggerType = _
            ServiceTriggerType.SERVICE_TRIGGER_TYPE_IP_ADDRESS_AVAILABILITY
            serviceTrigger2.dwAction = _
            ServiceTriggerAction.SERVICE_TRIGGER_ACTION_SERVICE_STOP
            serviceTrigger2.pTriggerSubtype = pGuidIpAddressRemoval

            ' Marshal the 2 SERVICE_TRIGGER structs to native memory as an array

            Dim cbServiceTrigger As Integer = Marshal.SizeOf(GetType(SERVICE_TRIGGER))
            pServiceTriggers = Marshal.AllocHGlobal(cbServiceTrigger * 2)
            Marshal.StructureToPtr(serviceTrigger1, pServiceTriggers, False)
            Marshal.StructureToPtr(serviceTrigger2, New IntPtr( _
                                   CLng(pServiceTriggers) + cbServiceTrigger), False)

            ' Allocate and set the SERVICE_TRIGGER_INFO structure

            Dim serviceTriggerInfo As New SERVICE_TRIGGER_INFO
            serviceTriggerInfo.cTriggers = 2
            serviceTriggerInfo.pTriggers = pServiceTriggers

            ' Marshal the SERVICE_TRIGGER_INFO struct to native memory

            pServiceTriggerInfo = Marshal.AllocHGlobal( _
            Marshal.SizeOf(GetType(SERVICE_TRIGGER_INFO)))
            Marshal.StructureToPtr(serviceTriggerInfo, pServiceTriggerInfo, False)

            ' Call ChangeServiceConfig2 with the SERVICE_CONFIG_TRIGGER_INFO level 
            ' and pass to it the address of the SERVICE_TRIGGER_INFO structure

            If Not NativeMethods.ChangeServiceConfig2( _
            hService, ServiceConfig2InfoLevel.SERVICE_CONFIG_TRIGGER_INFO, _
            pServiceTriggerInfo) Then
                ' If the handle is invalid, get the last Win32 error and throw a 
                ' Win32Exception
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error)
            End If

        Finally
            ' Clean up the native memory

            If (pGuidIpAddressArrival <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pGuidIpAddressArrival)
            End If
            If (pGuidIpAddressRemoval <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pGuidIpAddressRemoval)
            End If
            If (pServiceTriggers <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pServiceTriggers)
            End If
            If (pServiceTriggerInfo <> IntPtr.Zero) Then
                Marshal.FreeHGlobal(pServiceTriggerInfo)
            End If
        End Try

    End Sub

#End Region

End Class