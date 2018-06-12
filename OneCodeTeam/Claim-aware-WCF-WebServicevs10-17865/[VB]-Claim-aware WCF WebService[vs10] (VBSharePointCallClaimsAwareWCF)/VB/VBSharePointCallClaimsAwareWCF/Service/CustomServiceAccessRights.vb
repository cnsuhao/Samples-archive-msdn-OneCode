'*************************** Module Header ******************************\
' Module Name:    CustomServiceAccessRights.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This class is used to custom ServiceAccessRights
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
Imports Microsoft.SharePoint.Administration.AccessControl

Namespace CustomService
    Friend NotInheritable Class CustomServiceAccessRights
        Private Sub New()
        End Sub
        Public Const Add As SPIisWebServiceApplicationRights = CType(&H1, SPIisWebServiceApplicationRights)
        Public Const Subtract As SPIisWebServiceApplicationRights = CType(&H2, SPIisWebServiceApplicationRights)
        Public Const Hello As SPIisWebServiceApplicationRights = CType(&H3, SPIisWebServiceApplicationRights)
    End Class
End Namespace
