'****************************** Module Header ******************************\
' Module Name: ClickHandlers.vb
' Project:     VBASPNETDynamicallyBindEvent
' Copyright (c) Microsoft Corporation.
' 
' This is a Handler class.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Public Class ClickHandlers
    Private root As XElement = XElement.Load(HttpContext.Current.Server.MapPath("SourceFile.xml"))
    Public Sub ResponseImageURL(sender As Object, e As EventArgs)
        Dim lbtn = DirectCast(sender, LinkButton)
        Dim lbtnID As String = lbtn.ID

        Dim images = root.Element("Images")
        Dim imageElements = images.Elements("Image")
        Dim imageURL = (From i In imageElements Where i.Element("ID").Value = lbtnID Select i.Element("URL")).First().Value

        System.Web.HttpContext.Current.Response.Write(String.Format("The {0}'s absolute path is:{1}", lbtn.Text, imageURL))
    End Sub


    Public Sub ResponseImageID(sender As Object, e As EventArgs)
        Dim lbtn = DirectCast(sender, LinkButton)
        System.Web.HttpContext.Current.Response.Write(String.Format("The {0}'s ID:{1}", lbtn.Text, lbtn.ID))

    End Sub
End Class
