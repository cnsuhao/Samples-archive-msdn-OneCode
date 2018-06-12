'****************************** Module Header ******************************\
' Module Name:  IService.vb
' Project:      VBWindowsStoreAppAccessSQLServer
' Copyright (c) Microsoft Corporation.
' 
' This is service interface 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IService1" in both code and config file together.
<ServiceContract()>
Public Interface IService
    ' Query data
    <OperationContract>
    Function querySql(ByRef queryParam As Boolean) As DataSet
End Interface

