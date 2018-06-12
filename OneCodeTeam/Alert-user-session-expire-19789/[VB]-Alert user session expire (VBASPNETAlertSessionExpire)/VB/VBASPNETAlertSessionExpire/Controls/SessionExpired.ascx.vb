'**************************** Module Header ******************************\
' Module Name:    SessionExpired.ascx.vb
' Project:        VBASPNETAlertSessionExpired
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to design a simple user control, which is used to 
' alert the user when the session is about to expired. 
' 
' In this file, we register the CallServer method to the client side.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL..
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/

Imports System.Web.UI

Imports VBASPNETAlertSessionExpired.Util
Namespace VBASPNETAlertSessionExpired.Controls
    ''' <summary>
    ''' Inherit the ICallbackEventHandler interface to realize async request.
    ''' </summary>
    Partial Public Class SessionExpired
        Inherits System.Web.UI.UserControl
        Implements ICallbackEventHandler
        ''' <summary>
        ''' Register the javascript codes to the client, which is benefit to the client to request
        ''' the server for async.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsPostBack Then
                Session("SessionForTest") = "SessionForTest"
            End If

            ' Set the client method "client_ReceiveServerData" to receive the value
            ' from the server.
            Dim reference As String = Page.ClientScript.GetCallbackEventReference(Me, "", "clientReceiveServerData", "")

            ' Register a client method "CallServer" to request the server for async.
            Dim callbackScript As String = "function clientCallServer()" & "{" & reference & ";}"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientCallServer", callbackScript, True)

            ' Set the Session's timeout value to the client side. It will be assign to a HiddenField that 
            ' it will not affect user use.
            hfTimeOut.Value = Session.Timeout.ToString()

        End Sub


#Region "The Callbackhandler"

        ''' <summary>
        ''' You do not need to get any value from the server side.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetCallbackResult() As String Implements ICallbackEventHandler.GetCallbackResult
            Return String.Empty
        End Function

        ''' <summary>
        ''' Do not add any code for you just need to interactive with the server.
        ''' </summary>
        ''' <param name="eventArgument"></param>
        Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements ICallbackEventHandler.RaiseCallbackEvent

        End Sub

#End Region


    End Class
End Namespace