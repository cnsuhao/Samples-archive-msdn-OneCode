'/****************************** Module Header ******************************\
' Module Name:   ILeaveService.vb
' Project:       VBWCFService
' Copyright (c)  Microsoft Corporation.
' 
' This Class is a service interface. Here we define three service methods.
' Outlook Client will call this WCF service to interact with workflow.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\***************************************************************************/


Imports DBOperate
<ServiceContract()>
Public Interface ILeaveService

    ''' <summary>
    ''' Get checking list
    ''' </summary>
    ''' <returns></returns>
    <OperationContract()> _
    Function GetLeaveList() As List(Of Leave)

    ''' <summary>
    ''' Create Leave
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="day"></param>
    <OperationContract()> _
    Sub CreateLeave(name As String, day As String)

    ''' <summary>
    ''' audit Leave
    ''' </summary>
    ''' <param name="id">Leave Id</param>
    ''' <param name="comment">Approve or Reject</param>
    <OperationContract()> _
    Sub AuditingLeave(id As String, comment As String)

End Interface
