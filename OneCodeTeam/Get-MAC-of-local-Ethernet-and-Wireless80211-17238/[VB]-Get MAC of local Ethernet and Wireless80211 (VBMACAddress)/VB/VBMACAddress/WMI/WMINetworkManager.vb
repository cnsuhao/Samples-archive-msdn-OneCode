'************************** Module Header ******************************'
' Module Name:  WMINetworkManager.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' This class implements the IMACManager interface and use the Win32 WMI classes
' to get MAC of the local or remote host. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*************************************************************************'

Imports System.Collections.ObjectModel
Imports System.Management
Imports System.Net
Imports System.Net.NetworkInformation
Imports VBMACAddress.WMIHelper

Namespace WMI
    Public Class WMINetworkManager
        Implements IMACManager

        Private Shared _instance As WMINetworkManager = Nothing
        Public Shared ReadOnly Property Instance() As WMINetworkManager
            Get
                If _instance Is Nothing Then
                    _instance = New WMINetworkManager()
                End If
                Return _instance
            End Get
        End Property

        Private _locker As New Object()

        Private _adapters As List(Of Win32_NetworkAdapterSetting) = Nothing

        ''' <summary>
        ''' A list of local adapters.
        ''' </summary>
        Public ReadOnly Property Adapters() As ReadOnlyCollection(Of Win32_NetworkAdapterSetting)
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
        Private Function GetLocalAdapters() As List(Of Win32_NetworkAdapterSetting)

            ' The \root\wmi namespace of local machine.
            Dim scope As New ManagementScope("\\.\root\cimv2")

            Return GetAdapters(scope)
        End Function

        ''' <summary>
        ''' Get all the Win32_NetworkAdapterSetting WMI classes in the specified
        ''' scope.
        ''' </summary>
        Private Function GetAdapters(ByVal scope As ManagementScope) As List(Of Win32_NetworkAdapterSetting)
            Dim adapters = New List(Of Win32_NetworkAdapterSetting)()

            ' Query the MSNdis_EthernetCurrentAddress objects in the specified scope.
            Dim query As New SelectQuery("Win32_NetworkAdapterSetting")
            Dim searcher As ManagementObjectSearcher = Nothing
            Dim queryCollection As ManagementObjectCollection = Nothing

            Try
                searcher = New ManagementObjectSearcher(scope, query)
                queryCollection = searcher.Get()

                For Each adapterobject As ManagementObject In queryCollection

                    ' Convert the ManagementObject to a MSNdis_EthernetCurrentAddress 
                    'instance.
                    Dim adapter As Win32_NetworkAdapterSetting =
                        TryCast(WMIObjectFactory.GetInstance(
                                adapterobject, GetType(Win32_NetworkAdapterSetting), scope), 
                            Win32_NetworkAdapterSetting)

                    If adapter IsNot Nothing AndAlso
                        adapter.Element.PhysicalAdapter = True AndAlso
                        (Not String.IsNullOrEmpty(adapter.Setting.MACAddress)) Then

                        Select Case adapter.Element.AdapterTypeID
                            ' Ethernet 802.3 and  Wireless
                            Case 0, 9
                                adapters.Add(adapter)
                            Case Else
                        End Select
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
                If Not String.IsNullOrEmpty(adapter.Setting.MACAddress) Then
                    adaptersMAC.Add(
                        adapter.Element.Name,
                        PhysicalAddress.Parse(adapter.Setting.MACAddress.Replace(":", String.Empty)))
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
                path = String.Format("\\{0}.\root\cimv2", ipAddress)
            Else
                path = String.Format("\\{0}\root\cimv2", remoteHost)
            End If

            Dim scope As New ManagementScope(path, options)

            ' Get the adapters of the remote host.
            Dim adapters = GetAdapters(scope)

            Dim adaptersMAC = New Dictionary(Of String, PhysicalAddress)()

            For Each adapter In adapters
                If Not String.IsNullOrEmpty(adapter.Setting.MACAddress) Then
                    adaptersMAC.Add(
                        adapter.Element.Name,
                        PhysicalAddress.Parse(adapter.Setting.MACAddress.Replace(":", String.Empty)))
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
