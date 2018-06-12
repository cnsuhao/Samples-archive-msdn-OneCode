'************************************* Module Header ***********************\
' Module Name:  Ashwid.vb
' Project:      VBWindowsStoreAppASHWID
' Copyright (c) Microsoft Corporation.
' 
'  Model class for Hardware ID ASHWID storage.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

''' <summary>
''' Model class for ASHWID Hardware token
''' The class is used as Json objects accross C/S.
''' </summary>
<DataContract> _
Public Class Ashwid

    <Key, DataMember> _
    Public Property CustomerId As Guid

    <DataMember> _
    Public Property HardwareId As Byte()

    <DataMember> _
    Public Property Certificate As Byte()

    <DataMember> _
    Public Property Signature As Byte()
End Class

