'****************************** Module Header ******************************\
' Module Name: ImageController.ascx.vb
' Project:     VBASPNETDynamicallyBindEvent
' Copyright (c) Microsoft Corporation.
' 
' This user control will first load SourceFile.xml then dynamically create 
' linkbutton based on the SourceFile.xml's records.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.Reflection

Public Class ImageController
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim root As XElement = XElement.Load(Server.MapPath("~/SourceFile.xml"))
        Dim images = root.Element("Images")
        Dim imageElements = images.Elements("Image")
        For Each imageElement In imageElements
            Dim lbtn = New LinkButton()

            ' Use image Name as linkButton Text
            Dim strArray = imageElement.Element("URL").Value.Split("/"c)
            lbtn.Text = strArray(strArray.Length - 1)

            ' Bind click event with relection method
            AddHandler lbtn.Click, Sub(ibtnSender, imageClickArgs)
                                       Dim clickHandlerType As Type = GetType(ClickHandlers)
                                       Dim constructor As ConstructorInfo = clickHandlerType.GetConstructor(Type.EmptyTypes)
                                       Dim clickHandlerObject As [Object] = constructor.Invoke(New [Object]() {})

                                       Dim method = clickHandlerType.GetMethod(imageElement.Element("ClickHandler").Value)
                                       Dim addHandlerArgs As [Object]() = {ibtnSender, imageClickArgs}
                                       method.Invoke(clickHandlerObject, addHandlerArgs)
                                   End Sub

            lbtn.ID = imageElement.Element("ID").Value

            pnlImages.Controls.Add(lbtn)
        Next
    End Sub
End Class