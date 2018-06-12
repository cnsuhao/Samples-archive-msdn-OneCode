'************************** Module Header ******************************'
' Module Name:  MIB_IPNET_ROW2.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' The MIB_IPNET_ROW2 structure stores information about a neighbor IP address.
'  
' http://msdn.microsoft.com/en-us/library/aa814498(VS.85).aspx
' 
' Syntax
'  
' typedef struct _MIB_IPNET_ROW2 {
'   SOCKADDR_INET     Address;
'   NET_IFINDEX       InterfaceIndex;
'   NET_LUID          InterfaceLuid;
'    UCHAR            PhysicalAddress[IF_MAX_PHYS_ADDRESS_LENGTH];
'   ULONG             PhysicalAddressLength;
'   NL_NEIGHBOR_STATE State;
'   union {
'     struct {
'       BOOLEAN IsRouter  :1;
'       BOOLEAN IsUnreachable  :1;
'     };
'     UCHAR  Flags;
'   };
'   union {
'     ULONG LastReachable;
'     ULONG LastUnreachable;
'   } ReachabilityTime;
' } MIB_IPNET_ROW2, *PMIB_IPNET_ROW2;
' 
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'************************************************************************'

Imports System.Runtime.InteropServices

Namespace NetworkInformation


    ''' <summary>
    ''' The MIB_IPNET_ROW2 structure stores information about a neighbor IP address.
    ''' Its size is 88 bytes.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)>
    Friend Structure MIB_IPNET_ROW2

        ''' <summary>
        ''' The neighbor IP address. This member can be an IPv6 address or an IPv4 address.
        ''' Its size is 28 bytes.
        ''' </summary>
        <MarshalAs(UnmanagedType.Struct)>
        Friend Address As SOCKADDR_INET

        ''' <summary>
        ''' The local index value for the network interface associated with this IP address.
        ''' typedef ULONG NET_IFINDEX, *PNET_IFINDEX; Its size is 4 bytes.
        ''' </summary>
        <MarshalAs(UnmanagedType.U4)>
        Friend InterfaceIndex As UInteger

        ''' <summary>
        ''' The locally unique identifier (LUID) for the network interface associated
        ''' with this IP address.
        ''' Its size is 8 bytes.
        ''' </summary>
        <MarshalAs(UnmanagedType.Struct)>
        Friend InterfaceLuid As NET_LUID

        ''' <summary>
        ''' The physical hardware address of the adapter for the network interface
        ''' associated with this IP address.
        ''' #define IF_MAX_PHYS_ADDRESS_LENGTH 32; Its size is 32 bytes.
        ''' </summary>
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
        Friend PhysicalAddress() As Byte

        ''' <summary>
        ''' The length, in bytes, of the physical hardware address specified by 
        ''' the PhysicalAddress member. The maximum value supported is 32 bytes.
        ''' Its size is 4 bytes.
        ''' </summary>
        <MarshalAs(UnmanagedType.U4)>
        Friend PhysicalAddressLength As UInteger

        ''' <summary>
        ''' The state of a network neighbor IP address as defined in RFC 2461,
        ''' section 7.3.2. For more information, see http://www.ietf.org/rfc/rfc2461.txt. 
        ''' This member can be one of the values from the NL_NEIGHBOR_STATE enumeration
        ''' type defined in the Nldef.h header file. 
        ''' Its size is 4 bytes
        ''' </summary>
        <MarshalAs(UnmanagedType.U4)>
        Friend State As NL_NEIGHBOR_STATE

        ''' <summary>
        ''' Its size is 4 bytes
        ''' </summary>
        <MarshalAs(UnmanagedType.Struct)>
        Friend Union As MIB_IPNET_ROW2_Flags_Union

        ''' <summary>
        ''' Its size is 4 bytes
        ''' </summary>
        <MarshalAs(UnmanagedType.Struct)>
        Friend ReachabilityTime As MIB_IPNET_ROW2_ReachabilityTime
    End Structure


    <StructLayout(LayoutKind.Explicit)>
    Friend Structure MIB_IPNET_ROW2_Flags_Union

        <FieldOffset(0)>
        Friend Struct As MIB_IPNET_ROW2_Flags_Struct

        ''' <summary>
        ''' A set of flags that indicate whether the IP address is a router and
        ''' whether the IP address is unreachable.
        ''' </summary>
        <FieldOffset(0)>
        Friend Flags As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Friend Structure MIB_IPNET_ROW2_Flags_Struct
        Friend value As UInteger

        ''' <summary>
        ''' A value that indicates if this IP address is a router.
        ''' Its value is the lowest bit of the value field.
        ''' </summary>
        Friend Property IsRouter() As UInteger
            Get
                Return CUInt(Me.value And &H1)
            End Get
            Set(ByVal value As UInteger)
                Me.value = CUInt(value Or Me.value)
            End Set
        End Property

        ''' <summary>
        ''' A value that indicates if this IP address is unreachable.
        ''' Its value is the second lowest bit of the value field.
        ''' </summary>
        Friend Property IsUnreachable() As UInteger
            Get
                Return CUInt((Me.value And &H2) >> 1)
            End Get
            Set(ByVal value As UInteger)
                Me.value = CUInt((value << 1) Or Me.value)
            End Set
        End Property

    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Friend Structure MIB_IPNET_ROW2_ReachabilityTime

        ''' <summary>
        ''' The time, in milliseconds, that a node assumes a neighbor is
        ''' reachable after having received a reachability confirmation. 
        ''' </summary>
        <FieldOffset(0)>
        Friend LastReachable As UInteger

        ''' <summary>
        ''' The time, in milliseconds, that a node assumes a neighbor is 
        ''' unreachable after not having received a reachability confirmation. 
        ''' </summary>
        <FieldOffset(0)>
        Friend LastUnreachable As UInteger
    End Structure
End Namespace
