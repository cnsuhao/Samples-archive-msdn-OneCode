'****************************** Module Header ******************************\
' Module Name:  Service1.svc.vb
' Project:      VBLoadAndExecuteDynamicJS
' Copyright (c) Microsoft Corporation
'
' This is the AJAX-enabled WCF Service
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.Web.Script.Services
Imports System.Web.Services

<ServiceContract(Namespace:="")> _
<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)> _
Public Class Service1

    ' To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
    ' To create an operation that returns XML,
    '     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
    '     and include the following line in the operation body:
    '         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
    <OperationContract()> _
    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Function LoadScript(ByVal source As String) As String
        ' Add your operation implementation here
        Return "Scripts/" & source
    End Function

    ' Add more operations here and mark them with <OperationContract()>

End Class
