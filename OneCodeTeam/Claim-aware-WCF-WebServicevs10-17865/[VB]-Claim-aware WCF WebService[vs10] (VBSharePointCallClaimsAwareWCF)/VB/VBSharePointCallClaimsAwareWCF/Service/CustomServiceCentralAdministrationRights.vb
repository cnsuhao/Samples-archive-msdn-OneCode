'*************************** Module Header ******************************\
' Module Name:    CustomServiceCentralAdministrationRights.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' This is the Custom ServiceCentralAdministrationRights Class
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
    ''' <summary>
    ''' Custom central administration access rights for the sample web service application.
    ''' </summary>
    Friend NotInheritable Class CustomServiceCentralAdministrationRights
        Private Sub New()
        End Sub
        ' NOTE: SPCentralAdministrationRights.Read is required to allow access to the central administration site as a delegated administrator
        Public Const Write As SPCentralAdministrationRights = CType(&H1, SPCentralAdministrationRights) Or SPCentralAdministrationRights.Read
    End Class
End Namespace
