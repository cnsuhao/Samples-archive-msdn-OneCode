'************************** Module Header ******************************'
' Module Name:  MSNdisNetworkManager.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' This class implements the IMACManager interface and use the NDIS WMI classes
' to get MAC of the local or remote host. 
' 
' The NDIS WMI classes are available in Windows Vista / Windows Server 2008 
' or later version.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'************************************************************************'

Imports System.Collections.ObjectModel
Imports System.Management
Imports System.Net
Imports System.Net.NetworkInformation
Imports VBMACAddress.WMIHelper

Namespace NDIS
    Public Class MSNdisNetworkManager
        Implements IMACManager

        Private Shared _instance As MSNdisNetworkManager = Nothing
        Public Shared ReadOnly Property Instance() As MSNdisNetworkManager
            Get
                If _instance Is Nothing Then
                    _instance = New MSNdisNetworkManager()
                End If
                Return _instance
            End Get
        End Property

        Private _locker As New Object()

        Private _adapters As List(Of MSNdis_EthernetCurrentAddress) = Nothing

        ''' <summary>
        ''' A list of local Ethernet Adapters.
        ''' </summary>
        Public ReadOnly Property Adapters() As ReadOnlyCollection(Of MSNdis_EthernetCurrentAddress)
            Get
                If _adapters Is Nothing Then
                    SyncLock _locker
                        If _adapters Is Nothing Then
                            _adapters = GetLocalAdapters()
                        End If
                    End SyncLock
                End If
                Return _adapters.AsReadOnly()
            End Get
        End Property

        ''' <summary>
        ''' Get local adapters.
        ''' </summary>
        ''' <returns></returns>
        Private Function GetLocalAdapters() As List(Of MSNdis_EthernetCurrentAddress)

            ' The \root\wmi namespace of local machine.
            Dim scope As New ManagementScope("\\.\root\WMI")

            Return GetAdapters(scope)
        End Function

        ''' <summary>
        ''' Get all the MSNdis_EthernetCurrentAddress WMI classes in the specified
        ''' scope.
        ''' </summary>
        Private Function GetAdapters(ByVal scope As ManagementScope) _
            As List(Of MSNdis_EthernetCurrentAddress)

            Dim adapterInstanceNames = GetEnumerateAdapterEx(scope)
            Dim physicalMediums = GetPhysicalMediums(scope)

            Dim adapters = New List(Of MSNdis_EthernetCurrentAddress)()

            ' Query the MSNdis_EthernetCurrentAddress objects in the specified scope.
            Dim query As New SelectQuery("MSNdis_EthernetCurrentAddress")
            Dim searcher As ManagementObjectSearcher = Nothing
            Dim queryCollection As ManagementObjectCollection = Nothing

            Try
                searcher = New ManagementObjectSearcher(scope, query)
                queryCollection = searcher.Get()

                For Each adapterobject As ManagementObject In queryCollection

                    ' Convert the ManagementObject to a MSNdis_EthernetCurrentAddress 
                    ' instance.
                    Dim adapter As MSNdis_EthernetCurrentAddress = TryCast(
                        WMIObjectFactory.GetInstance(
                            adapterobject, GetType(MSNdis_EthernetCurrentAddress), scope), 
                        MSNdis_EthernetCurrentAddress)

                    If adapter IsNot Nothing AndAlso
                        adapterInstanceNames.Contains(adapter.InstanceName) AndAlso
                        physicalMediums.Contains(adapter.InstanceName) Then
                        adapters.Add(adapter)
                    End If
                Next adapterobject
                Return adapters
            Finally
                If queryCollection IsNot Nothing Then
                    queryCollection.Dispose()
                End If

                If searcher IsNot Nothing Then
                    searcher.Dispose()
                End If
            End Try
        End Function

        ''' <summary>
        ''' Get all the physical adapter instances.
        ''' </summary>
        Private Function GetPhysicalMediums(ByVal scope As ManagementScope) _
            As List(Of String)

            Dim physicalMediums As New List(Of String)()

            ' Query the MSNdis_QueryPhysicalMediumTypeEx objects in the specified scope.
            Dim query As New SelectQuery("MSNdis_QueryPhysicalMediumTypeEx")
            Dim searcher As ManagementObjectSearcher = Nothing
            Dim queryCollection As ManagementObjectCollection = Nothing

            Try
                searcher = New ManagementObjectSearcher(scope, query)
                queryCollection = searcher.Get()

                For Each adapterobject As ManagementObject In queryCollection

                    ' Convert the ManagementObject to a MSNdis_QueryPhysicalMediumTypeEx 
                    'instance.
                    Dim adapter As MSNdis_QueryPhysicalMediumTypeEx =
                        TryCast(WMIObjectFactory.GetInstance(
                                adapterobject, GetType(MSNdis_QueryPhysicalMediumTypeEx), scope), 
                            MSNdis_QueryPhysicalMediumTypeEx)

                    If adapter IsNot Nothing AndAlso adapter.Active = True Then
                        physicalMediums.Add(adapter.InstanceName)
                    End If
                Next adapterobject
                Return physicalMediums
            Finally
                If queryCollection IsNot Nothing Then
                    queryCollection.Dispose()
                End If

                If searcher IsNot Nothing Then
                    searcher.Dispose()
                End If
            End Try
        End Function

        ''' <summary>
        ''' Get all the Ethernet and Wireless adapter instances.
        ''' </summary>
        Private Function GetEnumerateAdapterEx(ByVal scope As ManagementScope) _
            As List(Of String)

            Dim adapterInstanceNames As New List(Of String)()

            Dim adapterQuery As New SelectQuery("MSNdis_EnumerateAdapterEx")
            Dim adapterSearcher As ManagementObjectSearcher = Nothing
            Dim adapterQueryCollection As ManagementObjectCollection = Nothing

            Try
                adapterSearcher = New ManagementObjectSearcher(scope, adapterQuery)
                adapterQueryCollection = adapterSearcher.Get()

                For Each adapterobject As ManagementObject In adapterQueryCollection

                    ' Convert the ManagementObject to a MSNdis_EnumerateAdapterEx 
                    'instance.
                    Dim adapter As MSNdis_EnumerateAdapterEx =
                        TryCast(WMIObjectFactory.GetInstance(
                                adapterobject, GetType(MSNdis_EnumerateAdapterEx), scope), 
                            MSNdis_EnumerateAdapterEx)

                    If adapter IsNot Nothing Then
                        Dim netluid As New NetworkInformation.NET_LUID()
                        netluid.Value = adapter.EnumerateAdapter.NetLuid

                        Select Case netluid.Info.IfType
                            ' IF_TYPE_ETHERNET_CSMACD and  IF_TYPE_IEEE80211
                            Case 6, 71
                                adapterInstanceNames.Add(adapter.InstanceName)
                            Case Else
                        End Select


                    End If
                Next adapterobject
                Return adapterInstanceNames
            Finally
                If adapterQueryCollection IsNot Nothing Then
                    adapterQueryCollection.Dispose()
                End If

                If adapterSearcher IsNot Nothing Then
                    adapterSearcher.Dispose()
                End If
            End Try
        End Function

#Region "INetworkManager interface"

        ''' <summary>
        ''' Get the MAC of local adapters.
        ''' The Key is the adapter name, the value is the MAC of the adapter.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetLocalAdaptersMAC() As Dictionary(Of String, PhysicalAddress) _
            Implements IMACManager.GetLocalAdaptersMAC

            Dim adaptersMAC = New Dictionary(Of String, PhysicalAddress)()

            For Each adapter In Me.Adapters
                If adapter.NdisCurrentAddress IsNot Nothing _
                    AndAlso adapter.NdisCurrentAddress.Address IsNot Nothing Then

                    adaptersMAC.Add(
                        adapter.InstanceName,
                        New PhysicalAddress(adapter.NdisCurrentAddress.Address))
                End If
            Next adapter

            Return adaptersMAC
        End Function

        ''' <summary>
        ''' Get the MAC of the remote host.
        ''' </summary>
        ''' <param name="remoteHost">
        ''' This parameter could be the machine name or an IP address.
        ''' </param>
        ''' <param name="credential">
        ''' The credential to connect the remote host.
        ''' </param>
        ''' <returns>The Key is the adapter name, the value is the MAC of the adapter.</returns>
        Public Function GetRemoteMachineMAC(ByVal remoteHost As String,
                                            ByVal credential As NetworkCredential) _
                                        As Dictionary(Of String, PhysicalAddress) _
                                        Implements IMACManager.GetRemoteMachineMAC


            ' Initialize a ConnectionOptions instance, which contains the credential
            ' to connect the remote host.
            Dim options As New ConnectionOptions()

            If credential IsNot Nothing Then
                options.Username = String.Format("{0}\{1}", credential.Domain, credential.UserName)
                options.Password = credential.Password
            End If

            options.EnablePrivileges = True
            options.Impersonation = ImpersonationLevel.Impersonate
            options.Authentication = AuthenticationLevel.Default
            options.Timeout = New TimeSpan(0, 0, 5)

            Dim path As String = String.Empty

            Dim ipAddress As IPAddress = Nothing
            Dim success As Boolean = ipAddress.TryParse(remoteHost, ipAddress)

            ' If the remoteHost parameter is an IP Address, then add '.' to the path.
            ' Like \\192.168.1.1.\root\wmi
            If success Then
                path = String.Format("\\{0}.\root\wmi", ipAddress)
            Else
                path = String.Format("\\{0}\root\wmi", remoteHost)
            End If

            Dim scope As New ManagementScope(path, options)

            ' Get the adapters of the remote host.
            Dim adapters = GetAdapters(scope)

            Dim adaptersMAC = New Dictionary(Of String, PhysicalAddress)()

            For Each adapter In adapters
                If adapter.NdisCurrentAddress IsNot Nothing _
                    AndAlso adapter.NdisCurrentAddress.Address IsNot Nothing Then
                    adaptersMAC.Add(
                        adapter.InstanceName,
                        New PhysicalAddress(adapter.NdisCurrentAddress.Address))
                End If
            Next adapter

            Return adaptersMAC
        End Function

        Public Sub Refresh() Implements IMACManager.Refresh
            Me._adapters = Nothing
        End Sub

#End Region
    End Class
End Namespace
