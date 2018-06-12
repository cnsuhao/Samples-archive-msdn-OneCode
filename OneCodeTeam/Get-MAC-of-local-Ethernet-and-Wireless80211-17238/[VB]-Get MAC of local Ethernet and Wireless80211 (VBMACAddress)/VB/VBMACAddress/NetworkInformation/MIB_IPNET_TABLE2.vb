'************************** Module Header ******************************'
' Module Name:  MIB_IPNET_TABLE2.vb
' Project:      VBMACAddress
' Copyright (c) Microsoft Corporation.
' 
' The MIB_IPNET_TABLE2 structure contains a table of neighbor IP address entries.
'  
' http://msdn.microsoft.com/en-us/library/aa814499(VS.85).aspx
' 
' Syntax
'  
' typedef struct _MIB_IPNET_TABLE2 {
'     ULONG       NumEntries;
'     MIB_IF_ROW2 Table[ANY_SIZE];
' } MIB_IPNET_TABLE2, *PMIB_IPNET_TABLE2;
' 
' Because the length of the Table field is not fixed, we cannot marshal it
' directly. If we get the pointer of the MIB_IPNET_TABLE2 instance, we have 
' to get the MIB_IF_ROW2 instance one by one using the pointer.
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

Namespace NetworkInformation
    <StructLayout(LayoutKind.Sequential)>
    Friend Structure MIB_IPNET_TABLE2
        ''' <summary>
        ''' A value that specifies the number of IP network neighbor 
        ''' address entries in the array.
        ''' </summary>
        <MarshalAs(UnmanagedType.U4)>
        Friend NumEntries As UInteger


        ''' <summary>
        ''' MIB_IF_ROW2 Table[ANY_SIZE];
        ''' Because the length of the Table field is not fixed, we cannot marshal it
        ''' directly. If we get the pointer of the MIB_IPNET_TABLE2 instance, we have 
        ''' to get the MIB_IF_ROW2 instance one by one using the pointer.
        ''' </summary>
        ''' <param name="pMIB_IPNET_TABLE2">
        ''' A pointer to a MIB_IPNET_TABLE2 structure that contains a table of neighbor
        ''' IP address entries on the local computer. 
        ''' </param>
        ''' <returns></returns>
        Public Shared Function GetTable(ByVal pMIB_IPNET_TABLE2 As IntPtr) As MIB_IPNET_ROW2()
            Dim table() As MIB_IPNET_ROW2 = Nothing
            Try

                ' Marshal a MIB_IPNET_TABLE2 instance from the pointer.
                Dim mib_ipnet_table2 As MIB_IPNET_TABLE2 = CType(
                    Marshal.PtrToStructure(
                        pMIB_IPNET_TABLE2, GetType(MIB_IPNET_TABLE2)), MIB_IPNET_TABLE2)

                ' The array length is the NumEntries.
                table = New MIB_IPNET_ROW2(mib_ipnet_table2.NumEntries - 1) {}

                ' Get the start address of the MIB_IPNET_ROW2 array.
                Dim currentPointer As IntPtr = pMIB_IPNET_TABLE2 + 8

                For i As Integer = 0 To mib_ipnet_table2.NumEntries - 1

                    table(i) = CType(Marshal.PtrToStructure(
                            currentPointer, GetType(MIB_IPNET_ROW2)), MIB_IPNET_ROW2)

                    currentPointer += Marshal.SizeOf(table(i))
                Next i

                Return table
            Catch
                Return Nothing
            End Try


        End Function
    End Structure

End Namespace
