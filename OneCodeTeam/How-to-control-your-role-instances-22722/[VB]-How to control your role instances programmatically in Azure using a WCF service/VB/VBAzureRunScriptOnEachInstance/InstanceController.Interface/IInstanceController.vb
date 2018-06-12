'***************************** Module Header ******************************\
' Module Name:  IInstanceController.vb
' Project:      InstanceController.Interface
' Copyright (c) Microsoft Corporation.
' 
' A WCF service contract.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/
Imports System.ServiceModel
<ServiceContract(Name:="IInstanceControllerService", [Namespace]:="http://www.Onecode.com")> _
Public Interface IInstanceController
    <OperationContract> _
    Function GetInstanceInternalEndPoint() As List(Of String)

    <OperationContract> _
    Sub DownLoadFileFromBlob(ContainerName As String, FileName As String)

    <OperationContract> _
    Sub RunExecutableFile(Container As String, FileName As String)

    <OperationContract> _
    Function RunScriptOnEveryInstance(Container As String, FileName As String) As Boolean

End Interface