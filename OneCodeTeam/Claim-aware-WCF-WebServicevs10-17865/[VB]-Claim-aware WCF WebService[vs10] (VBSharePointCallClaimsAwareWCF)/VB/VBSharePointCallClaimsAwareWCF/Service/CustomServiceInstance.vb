'*************************** Module Header ******************************\
' Module Name:    CustomServiceInstance.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This is the CustomServiceInstance Class
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
Imports Microsoft.SharePoint.Administration
Imports CustomService

Namespace CustomService
    Public Class CustomServiceInstance
        Inherits SPIisWebServiceInstance
        Public Sub New()
        End Sub

        Public Sub New(ByVal server As SPServer, ByVal service As CustomService)
            MyBase.New(server, service)
        End Sub

        Public Overrides ReadOnly Property TypeName() As String
            Get
                Return "Custom Service"
            End Get
        End Property
    End Class
End Namespace
