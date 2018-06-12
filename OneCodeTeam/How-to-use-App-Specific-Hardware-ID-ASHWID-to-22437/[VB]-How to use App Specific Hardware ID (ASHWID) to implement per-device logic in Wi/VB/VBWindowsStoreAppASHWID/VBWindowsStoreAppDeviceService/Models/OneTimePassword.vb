'************************************* Module Header ***********************\
' Module Name:  OneTimePassword.vb
' Project:      VBWindowsStoreAppASHWID
' Copyright (c) Microsoft Corporation.
' 
' Model class for OTP Nonce storage.
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
''' Model class for One Time Password repository
''' The class is used as Json objects accross C/S.
''' </summary>
<DataContract> _
Public Class OneTimePassword

    <Key, IgnoreDataMember> _
    Public Property AgentId As Guid

    <IgnoreDataMember> _
    Public Property ExpiredTime As DateTime

    <DataMember> _
    Public Property Nonce As String

End Class


