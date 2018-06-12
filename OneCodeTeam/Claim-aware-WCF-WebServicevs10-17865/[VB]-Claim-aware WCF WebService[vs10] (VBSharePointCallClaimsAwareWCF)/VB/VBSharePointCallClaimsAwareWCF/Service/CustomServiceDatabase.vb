'*************************** Module Header ******************************\
' Module Name:    CustomServiceDatabase.vb
' Project:        VBSharePointCallClaimsAwareWCF
' Copyright (c) Microsoft Corporation
'
' A common SQL Server database provisioning infrastructure (to use your own database to store data)
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
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Principal
Imports Microsoft.SharePoint.Administration
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Utilities

Namespace CustomService
    <System.Runtime.InteropServices.Guid("FE92B481-00B1-4ad7-9E89-2DFEF629F38A")> _
    Friend NotInheritable Class CustomServiceDatabase
        Inherits SPDatabase
        Public Sub New()
        End Sub

        Friend Sub New(ByVal dbParameters As SPDatabaseParameters)
            MyBase.New(dbParameters)
            Me.Status = SPObjectStatus.Disabled
        End Sub

        Public Overrides Sub Provision()
            ' stop if DB is already provisioned
            If SPObjectStatus.Online = Me.Status Then
                Return
            End If

            Me.Status = SPObjectStatus.Provisioning
            Me.Update()

            Dim options As New Dictionary(Of String, Boolean)(1)
            options.Add(SqlDatabaseOption(CInt(DatabaseOptions.AutoClose)), False)

            SPDatabase.Provision(Me.DatabaseConnectionString, SPUtility.GetGenericSetupPath("Template\sql\CustomService.sql"), options)

            Me.Status = SPObjectStatus.Online
            Me.Update()
        End Sub

        Friend Sub GrantApplicationPoolAccess(ByVal processSecurityIdentifier As SecurityIdentifier)
            Me.GrantAccess(processSecurityIdentifier, "db_owner")
        End Sub

    End Class
End Namespace

