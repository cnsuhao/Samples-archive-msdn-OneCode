'***************************** Module Header ******************************\
'* Module Name:    Global.asax
'* Project:        VBASPNETCodeFirstCRUDInGridViewWithDetailsView
'* Copyright (c) Microsoft Corporation
'*
'* The file is used to automatically generate db with several tables when
'* server starts.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
'* All other rights reserved.
'\**************************************************************************


Imports System.Configuration

Public Class Global_asax
    Inherits System.Web.HttpApplication

    ''' <summary>
    ''' To decide whether to create data contents once the Server starts.
    ''' </summary>
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        DBCreator.DBAutoCreator(Convert.ToBoolean(ConfigurationManager.AppSettings("RecreateDB")))
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

End Class