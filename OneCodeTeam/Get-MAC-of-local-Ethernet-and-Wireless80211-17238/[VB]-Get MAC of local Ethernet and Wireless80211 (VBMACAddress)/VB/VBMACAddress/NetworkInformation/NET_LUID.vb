'************************** Module Header ******************************'
' Module Name:  NET_LUID.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' The NET_LUID union is the locally unique identifier (LUID) for a network
' interface.
'  
' http://msdn.microsoft.com/en-us/library/aa366320(VS.85).aspx
' 
' Syntax
'  
' typedef union _NET_LUID {
'   ULONG64 Value;
'   struct {
'     ULONG64 Reserved  :24;
'     ULONG64 NetLuidIndex  :24;
'     ULONG64 IfType  :16;
'   } Info;
' } NET_LUID, *PNET_LUID;
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

    <StructLayout(LayoutKind.Explicit)>
    Friend Structure NET_LUID

        <FieldOffset(0)>
        Friend Value As ULong

        <FieldOffset(0)>
        Friend Info As NET_LUID_Info
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Friend Structure NET_LUID_Info

        Friend value As ULong

        Public Property Reserved() As ULong
            Get
                Return CULng(Me.value And &HFFFFFF)
            End Get
            Set(ByVal value As ULong)
                Me.value = CULng(value Or Me.value)
            End Set
        End Property

        Friend Property NetLuidIndex() As ULong
            Get
                Return CULng((Me.value And &HFFFFFF000000) >> 24)
            End Get
            Set(ByVal value As ULong)
                Me.value = CULng((value << 24) Or Me.value)
            End Set
        End Property

        Friend Property IfType() As ULong
            Get
                Return CULng((Me.value And &HFFFF000000000000) >> 48)
            End Get
            Set(ByVal value As ULong)
                Me.value = CULng((value << 48) Or Me.value)
            End Set
        End Property
    End Structure

End Namespace

