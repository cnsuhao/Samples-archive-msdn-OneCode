'****************************** Module Header ******************************\
'Module Name:  MessageBoxCore.vb
'Project:      VBASPNETIntelligentErrorPage
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to create a MessageBox in asp.net, usually we
'often use JavaScript functions "alert()" or "confirm()" to show simple messages
'and make a simple choice with customers, but these dialog boxes is very simple,
'we can not add any different and complicate controls, images or styles. As we know,
'good web sites always have their own web styles, such as typeface and colors, 
'and in this situation, JavaScript dialog boxes looks not very well. So this sample
'shows how to make an Asp.net MessageBox.
'
'The MessageBoxCore class stores the MessageBox's core html code, we will replace 
'the important parts of MessageBox, such as text, title, icons, script and so on.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/




Public Class MessageBoxCore
    Public Shared MessageBoxButtonHtml As String = "<input type='button' value='{0}' class='{1}' onclick='{2}' />"

    Public Shared MessageBoxHTML As String = "<div id='wholePage' class=page>&nbsp;</div>" & vbCr & vbLf &
                                             "<div id='messageBox' class='content'>" & vbCr & vbLf & vbTab &
                                             "<div style='margin:4px;'>" & vbCr & vbLf & vbTab & vbTab &
                                             "<table  style='background-color:#FFFFFF; border:1px solid #999999; width: 100%;height:192px '>" & vbCr & vbLf & vbTab & vbTab & vbTab &
                                             "<tr>" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab &
                                             "<td colspan='2' style='border-bottom:1px solid #CCCCCC;font-family:tahoma; font-size:11px; font-weight:bold; padding-left:5px; color:Black; text-align:center; height:30px;'>MessageBox-{0}</td>" & vbCr & vbLf & vbTab & vbTab & vbTab &
                                             "</tr><tr><tr><td></td><td></td></tr><tr><td></td><td></td></tr>" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab &
                                             "<td style='width:150px;text-align:center;'>{1}</td>" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab &
                                             "<td style='font-family:tahoma; font-size:14px;padding-left:5px;'>" & vbCr & vbLf &
                                             "<textarea style='overflow:hidden; width: 99%;height:62px; border:none; font-size:14px'>{2}</textarea>" & vbCr & vbLf &
                                             "</td></tr>" & vbCr & vbLf & vbTab & vbTab & vbTab &
                                             "<tr>" & vbCr & vbLf & vbTab & vbTab & vbTab & vbTab &
                                             "<td colspan='2' style='margin-top:5px;text-align:center;'>{3}</td>" & vbCr & vbLf & vbTab & vbTab & vbTab &
                                             "</tr>" & vbCr & vbLf & vbTab & vbTab &
                                             "</table>" & vbCr & vbLf & vbTab &
                                             "</div>" & vbCr & vbLf &
                                             "</div>"

    Public Shared MessageBoxScript As String = "var xmlHttpRequest;" & vbCr & vbLf &
                                               "function Yes() {{" & vbCr & vbLf &
                                               "var info = document.getElementById('result');" & vbCr & vbLf &
                                               "info.innerHTML = """";" & vbCr & vbLf &
                                               "var back = document.getElementById('wholePage');" & vbCr & vbLf &
                                               "back.parentNode.removeChild(back);" & vbCr & vbLf &
                                               "var message = document.getElementById('messageBox');" & vbCr & vbLf &
                                               "message.parentNode.removeChild(message);{0}}}" & vbCr & vbLf & vbCr & vbLf &
                                               "function Success(result) {{" & vbCr & vbLf &
                                               "var info = document.getElementById('result');" & vbCr & vbLf &
                                               "info.innerHTML = info.innerHTML + ""<br />"" + result;" & vbCr & vbLf &
                                               "}}" & vbCr & vbLf & vbCr & vbLf &
                                               "function Failed(error) {{" & vbCr & vbLf &
                                               "var info = document.getElementById('result');" & vbCr & vbLf &
                                               "info.innerHTML = info.innerHTML + ""<br />"" + error;" & vbCr & vbLf &
                                               "}}" & vbCr & vbLf & vbCr & vbLf &
                                               "function No() {{" & vbCr & vbLf &
                                               "var info = document.getElementById('result');" & vbCr & vbLf &
                                               "info.innerHTML = """";" & vbCr & vbLf &
                                               "var back = document.getElementById('wholePage');" & vbCr & vbLf &
                                               "back.parentNode.removeChild(back);" & vbCr & vbLf &
                                               "var message = document.getElementById('messageBox');" & vbCr & vbLf &
                                               "message.parentNode.removeChild(message);{1}}}"
End Class
