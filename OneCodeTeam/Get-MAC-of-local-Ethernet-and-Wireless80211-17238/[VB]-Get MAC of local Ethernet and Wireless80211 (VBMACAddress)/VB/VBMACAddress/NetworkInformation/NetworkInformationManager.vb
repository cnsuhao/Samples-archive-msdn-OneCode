'************************** Module Header ******************************'
' Module Name:  NDISNetworkManager.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' This class implements the IMACManager interface and use the IP Helper APIs
' to get MAC of the local or remote host. 
' 
' These new APIs are introduced in Windows Vista / Windows Server 2008 or later
' versions.
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
Imports System.Linq
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Runtime.InteropServices

Namespace NetworkInformation
    Public Class NetworkInformationManager
        Implements IMACManager


        Private Shared _instance As NetworkInformationManager = Nothing
        Public Shared ReadOnly Property Instance() As NetworkInformationManager
            Get
                If _instance Is Nothing Then
                    _instance = New NetworkInformationManager()
                End If
                Return _instance
            End Get
        End Property

        Private _locker As New Object()

        Private _interfaces() As NetworkInterface = Nothing

        ''' <summary>
        ''' A list of local adapters.
        ''' </summary>
        Public ReadOnly Property Interfaces() As ReadOnlyCollection(Of NetworkInterface)
            Get
                If _interfaces Is Nothing Then
                    SyncLock _locker
                        If _interfaces Is Nothing Then
                            _interfaces = NetworkInterface.GetAllNetworkInterfaces()
                        End If
                    End SyncLock
                End If
                Return Array.AsReadOnly(Of NetworkInterface)(_interfaces)
            End Get
        End Property

#Region "INetworkManager interface"


        ''' <summary>
        ''' Get local adapters.
        ''' The Key is the adapter name, the value is the MAC of the adapter.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetLocalAdaptersMAC() As Dictionary(Of String, PhysicalAddress) _
            Implements IMACManager.GetLocalAdaptersMAC

            Dim adaptersMAC = New Dictionary(Of String, PhysicalAddress)()

            For Each networkInterface In Interfaces

                ' It must be an Ethernet and Wireless adapters. 
                Select Case networkInterface.NetworkInterfaceType
                    Case NetworkInterfaceType.Ethernet, NetworkInterfaceType.Wireless80211
                        Dim address = networkInterface.GetPhysicalAddress()
                        If address IsNot Nothing Then
                            adaptersMAC.Add(networkInterface.Description, address)
                        End If
                    Case Else

                End Select
            Next networkInterface
            Return adaptersMAC
        End Function

        ''' <summary>
        ''' Get the MAC of the remote host.
        ''' </summary>
        ''' <param name="remoteHost">
        '''  This parameter could be the machine name or an IP address.
        ''' </param>
        ''' <param name="credential">The credential to connect the remote host.</param>
        ''' <returns>
        ''' The Key is the IP address, the value is the MAC of the adapter.
        ''' </returns>
        Public Function GetRemoteMachineMAC(ByVal remoteHost As String,
                                            ByVal credential As NetworkCredential) _
                                        As Dictionary(Of String, PhysicalAddress) _
                                        Implements IMACManager.GetRemoteMachineMAC

            Dim results = New Dictionary(Of String, PhysicalAddress)()

            ' Resolve the IP addresses of the remote host.
            Dim addresses = ResolveIPAddress(remoteHost)

            If addresses Is Nothing OrElse addresses.Count() = 0 Then
                Return results
            End If

            Dim ptable As IntPtr = IntPtr.Zero
            Try

                ' Get the IP neighbor table. 
                Dim hr As Integer = NativeMethods.GetIpNetTable2(CUShort(AddressFamily.Unspecified), ptable)

                Marshal.ThrowExceptionForHR(hr)

                ' Get the MIB_IPNET_ROW2 array.
                Dim rows = MIB_IPNET_TABLE2.GetTable(ptable)

                ' Search the IP neighbor table for the specified IP address.
                For Each remoteMachineAddress In addresses
                    If remoteMachineAddress.AddressFamily <> AddressFamily.InterNetwork _
                        AndAlso remoteMachineAddress.AddressFamily <> AddressFamily.InterNetworkV6 Then
                        Continue For
                    End If

                    For Each row In rows

                        If row.PhysicalAddressLength > 0 Then
                            Dim ipAddress As IPAddress = Nothing
                            If remoteMachineAddress.AddressFamily = AddressFamily.InterNetwork Then
                                ipAddress = New IPAddress(row.Address.Ipv4.Address)
                            Else
                                ipAddress = New IPAddress(row.Address.Ipv6.Address)
                            End If

                            If remoteMachineAddress.Equals(ipAddress) Then
                                Dim macAddress =
                                    New PhysicalAddress(row.PhysicalAddress.Take(
                                                        CInt(Fix(row.PhysicalAddressLength))).ToArray())
                                results.Add(ipAddress.ToString(), macAddress)
                                Exit For
                            End If
                        End If
                    Next row
                Next remoteMachineAddress
            Finally
                If ptable <> IntPtr.Zero Then
                    Marshal.FreeCoTaskMem(ptable)
                End If
            End Try

            Return results

        End Function

        Public Sub Refresh() Implements IMACManager.Refresh
            _interfaces = Nothing
        End Sub

#End Region

        Private Function ResolveIPAddress(ByVal remoteHost As String) As IEnumerable(Of IPAddress)
            Dim addresses() As IPAddress = Nothing
            Dim ipAddress As IPAddress = Nothing
            Dim success As Boolean = ipAddress.TryParse(remoteHost, ipAddress)

            If Not success Then
                Dim entry = Dns.GetHostEntry(remoteHost)
                If entry IsNot Nothing AndAlso entry.AddressList.Length > 0 Then
                    addresses = entry.AddressList
                End If
            Else
                addresses = New IPAddress() {ipAddress}
            End If

            Return addresses
        End Function

    End Class
End Namespace
