'****************************** Module Header ******************************\
' Module Name:    Handler.ashx.vb
' Project:        VBASPNETVerificationImage
' Copyright (c) Microsoft Corporation
'
' Use Graphics to generate an image with random numbers or letters. Then send
' it back to the client and save the random content into Session.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.Web
Imports System.Web.Services
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class Handler
    Implements System.Web.IHttpHandler, IRequiresSessionState

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        ' Whether to generate verification code or not.
        Dim isCreate As Boolean = True

        ' Session["CreateTime"]: The createTime of verification code
        If context.Session("CreateTime") Is Nothing Then
            context.Session("CreateTime") = DateTime.Now
        Else
            Dim startTime As DateTime = Convert.ToDateTime(context.Session("CreateTime"))
            Dim endTime As DateTime = Convert.ToDateTime(DateTime.Now)
            Dim ts As TimeSpan = endTime - startTime

            ' The time interval to generate a verification code.
            If ts.Minutes > 15 Then
                isCreate = True
                context.Session("CreateTime") = DateTime.Now
            Else
                isCreate = False
            End If
        End If


        context.Response.ContentType = "image/gif"

        ' Create Bitmap object and to draw
        Dim basemap As New Bitmap(200, 60)
        Dim graph As Graphics = Graphics.FromImage(basemap)
        graph.FillRectangle(New SolidBrush(Color.White), 0, 0, 200, 60)
        Dim font As New Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel)
        Dim r As New Random()
        Dim letters As String = "ABCDEFGHIJKLMNPQRSTUVWXYZabcdefghijklmnpqrstuvwxyz0123456789"
        Dim letter As String
        Dim s As New StringBuilder()

        If isCreate Then
            ' Add a random string
            For x As Integer = 0 To 4
                letter = letters.Substring(r.[Next](0, letters.Length - 1), 1)
                s.Append(letter)

                ' Draw the String
                graph.DrawString(letter, font, New SolidBrush(Color.Black), x * 38, r.[Next](0, 10))
            Next
        Else
            ' Using the previously generated verification code.
            Dim currentCode As String = context.Session("ValidateCode").ToString()
            s.Append(currentCode)

            For Each item As Char In currentCode
                letter = item.ToString()
                ' Draw the String
                graph.DrawString(letter, font, New SolidBrush(Color.Black), currentCode.IndexOf(item) * 38, r.[Next](0, 10))
            Next
        End If

        ' Confuse background
        Dim linePen As New Pen(New SolidBrush(Color.Black), 2)
        For x As Integer = 0 To 6
            graph.DrawLine(linePen, New Point(r.[Next](0, 199), r.[Next](0, 59)), New Point(r.[Next](0, 199), r.[Next](0, 59)))
        Next

        ' Save the picture to the output stream     
        basemap.Save(context.Response.OutputStream, ImageFormat.Gif)

        ' If you do not implement the IRequiresSessionState,it will be wrong here,and it can not generate a picture also.
        context.Session("ValidateCode") = s.ToString()
        context.Response.[End]()


    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class