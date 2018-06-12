'****************************** Module Header ******************************\
' Module Name:    AjaxTest.aspx.vb
' Project:        VBASPNETRemoveRegisteredScripts
' Copyright (c) Microsoft Corporation
'
' This page shows how to use ScriptManager.RegisterClientScriptBlock and 
' ScriptManager.RegisterStartupScript  
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Partial Public Class AjaxTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ' Client script
    Private script As String = vbCr & vbLf & "        function ToggleItem(id)" _
            & vbCr & vbLf & "          {" _
            & vbCr & vbLf & "            var elem = $get('div'+id);" _
            & vbCr & vbLf & "            if (elem) " _
            & vbCr & vbLf & " {" _
            & vbCr & vbLf & "              if (elem.style.display != 'block') " _
            & vbCr & vbLf & "              {" _
            & vbCr & vbLf & "                elem.style.display = 'block';" _
            & vbCr & vbLf & "                elem.style.visibility = 'visible';" _
            & vbCr & vbLf & "              } " _
            & vbCr & vbLf & "              else" _
            & vbCr & vbLf & "              {" _
            & vbCr & vbLf & "                elem.style.display = 'none';" _
            & vbCr & vbLf & "                elem.style.visibility = 'hidden';" _
            & vbCr & vbLf & "              }" _
            & vbCr & vbLf & "            }" _
            & vbCr & vbLf & "          }" _
            & vbCr & vbLf & "        "

    ''' <summary>
    ''' Register client script.        
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs)
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "ToggleScript", script, True)

        ' You can comment the code above and uncomment the code below
        ' ScriptManager.RegisterStartupScript(this,typeof(Page),"ToggleScript",script,true);
    End Sub

    ''' <summary>
    ''' Remove script: Register a null value to the existing key.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "ToggleScript", "", True)

        ' You can comment the code above and uncomment the code below
        ' ScriptManager.RegisterStartupScript(this,typeof(Page),"ToggleScript","",true);
    End Sub

End Class