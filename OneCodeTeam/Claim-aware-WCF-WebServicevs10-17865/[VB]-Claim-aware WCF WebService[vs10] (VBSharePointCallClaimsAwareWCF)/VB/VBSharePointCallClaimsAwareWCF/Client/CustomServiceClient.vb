'*************************** Module Header ******************************\
' Module Name:    CustomServiceClient.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This class is used to define Service Client
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\****************************************************************************


Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Microsoft.SharePoint

Namespace CustomService
    Public NotInheritable Class CustomServiceClient
        Private _serviceContext As SPServiceContext

        Public Sub New(ByVal serviceContext As SPServiceContext)
            If serviceContext Is Nothing Then
                Throw New ArgumentNullException("serviceContext")
            End If

            _serviceContext = serviceContext
        End Sub

        Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer
            Return Add(a, b, ExecuteOptions.None)
        End Function

        Public Function Add(ByVal a As Integer, ByVal b As Integer, ByVal options As ExecuteOptions) As Integer
            Dim sum As Integer = 0
            CustomServiceApplicationProxy.Invoke(_serviceContext, Function(proxy) InlineAssignHelper(sum, proxy.Add(a, b, options)))
            Return sum
        End Function

        Public Function HelloWorld() As String
            Return HelloWorld(ExecuteOptions.None)
        End Function

        Public Function HelloWorld(ByVal options As ExecuteOptions) As String
            Dim result As String = String.Empty

            CustomServiceApplicationProxy.Invoke(_serviceContext, Function(proxy) InlineAssignHelper(result, proxy.HelloWorld(options)))

            Return result
        End Function
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
            target = value
            Return value
        End Function
    End Class
End Namespace

