'****************************** Module Header ******************************\
' Module Name:    NonAjaxTest.aspx.vb
' Project:        VBASPNETRemoveRegisteredScripts
' Copyright (c) Microsoft Corporation
'
' This page shows how to use ClientScript.RegisterClientScriptBlock and 
' ClientScript.RegisterStartupScript  
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Partial Public Class NonAjaxTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''' <summary>
    ''' Register client script.
    ''' RegisterStartupScript puts the javascript before the closing tag of the page
    ''' and RegisterClientScriptBlock puts it right after the starting tag of the page 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Not ClientScript.IsClientScriptBlockRegistered("RegisterKey") Then
            ' Client script
            Dim sbAlertScript As New StringBuilder()
            sbAlertScript.Append("<script language='javascript'>" & vbLf)
            sbAlertScript.Append("function test()" & vbLf)
            sbAlertScript.Append("{" & vbLf)
            sbAlertScript.Append("alert(""test1"");" & vbLf)
            sbAlertScript.Append("}" & vbLf)
            sbAlertScript.Append("</script>" & vbLf)

            ' Register the client script

            ' You can comment the code above and uncomment the code below
            ' ClientScript.RegisterStartupScript(this.GetType(), "RegisterKey", sbAlertScript.ToString());       
            ClientScript.RegisterClientScriptBlock(Me.[GetType](), "RegisterKey", sbAlertScript.ToString())
        End If
    End Sub

    ''' <summary>
    ''' Remove script: Register a null value to the existing key.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
        ClientScript.RegisterClientScriptBlock(Me.[GetType](), "RegisterKey", "")

        ' You can comment the code above and uncomment the code below
        ' ClientScript.RegisterStartupScript(this.GetType(), "RegisterKey", "");    
    End Sub

End Class