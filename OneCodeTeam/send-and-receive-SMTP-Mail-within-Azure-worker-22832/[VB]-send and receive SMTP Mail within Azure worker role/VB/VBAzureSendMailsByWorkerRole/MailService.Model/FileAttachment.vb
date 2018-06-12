'***************************** Module Header ******************************\
' Module Name:  FileAttachment.vb
' Project:      VBAzureSendMailsByWorkerRole
' Copyright (c) Microsoft Corporation.
' 
' As you know, System.Net.Mail api can't be used in Windows Runtime application, 
' However, we can create a WCF service to consume the api, and hold this service 
' on Azure.
' 
' In this way, we can use this service to send email in Windows Store app. 
' 
' This interface defines the contracts of the WCF service.
'
' This class contains necessary information of the attachment file.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/


Imports System.Runtime.Serialization
Imports System.IO

''' <summary>
''' This class contains necessary information of the attachment file.
''' </summary>
<DataContract()>
Public Class FileAttachment

#Region "Public properties"
    ''' <summary>
    ''' Save the file content as a byte array.
    ''' </summary>
    <DataMember()>
    Public Property FileContentByteArray() As Byte()
        Get
            Return m_FileContentByteArray
        End Get
        Set(value As Byte())
            m_FileContentByteArray = value
        End Set
    End Property
    Private m_FileContentByteArray As Byte()

    ''' <summary>
    ''' Contains the necessary information of the file.<br/>
    ''' </summary>
    <DataMember()>
    Public Property Info() As FileInfo
        Get
            Return m_Info
        End Get
        Set(value As FileInfo)
            m_Info = value
        End Set
    End Property
    Private m_Info As FileInfo
#End Region
End Class
