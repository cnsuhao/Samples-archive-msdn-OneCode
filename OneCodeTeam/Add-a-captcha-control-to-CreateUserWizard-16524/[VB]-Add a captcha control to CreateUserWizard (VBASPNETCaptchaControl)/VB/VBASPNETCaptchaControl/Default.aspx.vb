Imports System.Drawing

'**************************** Module Header ******************************\
' Module Name: Default.aspx.vb
' Project:     VBASPNETCaptchaControl
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to add a captcha control to the CreateUserWizard
' control. As we know, we can use customize the contents of the CreateUserWizard
' control using the CreateUserWizardStep and CompleteWizardStep template.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************



Public Class _Default
    Inherits System.Web.UI.Page
    Private IsCreateSuc As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim captchaCode As String = GenerateRandomCode()
            Me.Session("CaptchaImageText") = captchaCode
        End If
    End Sub

    ' Used to create numbers randomly 
    Private Function GenerateRandomCode() As String
        Dim allChar As String = "1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z"
        Dim codeCount As Integer = 6
        Dim allCharArray As String() = allChar.Split(","c)
        Dim randomCode As String = ""
        Dim temp As Integer = -1

        Dim rand As New Random()
        For i As Integer = 0 To codeCount - 1
            If temp <> -1 Then
                rand = New Random(i * temp * Convert.ToInt32(DateTime.Now.Ticks.ToString().Substring(0, 7)))
            End If
            Dim t As Integer = rand.[Next](allCharArray.Length)
            If temp = t Then
                Return GenerateRandomCode()
            End If
            temp = t
            randomCode += allCharArray(t)

            Dim bmp As New Bitmap(120, 30)
            Dim graphics__1 As Graphics = Graphics.FromImage(bmp)
            Dim random As New Random()
            Dim font As New Font(FontFamily.GenericSerif, 24, FontStyle.Italic, GraphicsUnit.Pixel)
            graphics__1.DrawString(randomCode, font, New SolidBrush(Color.Green), New PointF(random.[Next](0, 18), random.[Next](0, 1)))
            Dim pen As New Pen(New SolidBrush(Color.Blue), 2)
            graphics__1.DrawLine(pen, New Point(random.[Next](0, 119), random.[Next](0, 29)), New Point(random.[Next](0, 119), random.[Next](0, 29)))
            bmp.Save(Server.MapPath("~") & "/captcha.bmp")

            ' Get label from CreateUserWizard control.
            Dim ctrlControl As Control = CreateUserWizardName.CreateUserStep.ContentTemplateContainer.FindControl("imgCaptcha")
            Dim imgCaptcha As New System.Web.UI.WebControls.Image()
            imgCaptcha.Visible = True
        Next

        ' Set value to session variable when the function is called. 
        Session("CaptchaImageText") = randomCode
        Return randomCode
    End Function

    ''' <summary>
    ''' After create a user account, display user's basic information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub CreateUserWizardName_NextButtonClick(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)
        If IsCreateSuc Then
            ' Display an informational message
            lbError.Text = "Create a new user success!!"
            ' Display your information
            Dim ctrlName As Control = CreateUserWizardName.CreateUserStep.ContentTemplateContainer.FindControl("UserName")
            Dim strUserName As String = DirectCast(ctrlName, TextBox).Text
            Dim ctrlPassword As Control = CreateUserWizardName.CreateUserStep.ContentTemplateContainer.FindControl("Password")
            Dim strPassword As String = DirectCast(ctrlPassword, TextBox).Text
            Dim ctrlLbUsername As Control = CreateUserWizardName.CompleteStep.ContentTemplateContainer.FindControl("lbUserName")
            Dim ctrlLbEmail As Control = CreateUserWizardName.CompleteStep.ContentTemplateContainer.FindControl("lbEmail")
            Dim ctrlLbQuestion As Control = CreateUserWizardName.CompleteStep.ContentTemplateContainer.FindControl("lbQuestion")
            Dim userInfo As MembershipUser
            If Membership.ValidateUser(strUserName, strPassword) = True Then
                userInfo = Membership.GetUser(strUserName)
                DirectCast(ctrlLbUsername, Label).Text = userInfo.UserName
                DirectCast(ctrlLbQuestion, Label).Text = userInfo.PasswordQuestion
                DirectCast(ctrlLbEmail, Label).Text = userInfo.Email
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    ''' <summary>
    ''' Check the captcha code is matched.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub CreateUserWizardName_CreatingUser(ByVal sender As Object, ByVal e As LoginCancelEventArgs)
        Dim ctrl As Control = CreateUserWizardName.CreateUserStep.ContentTemplateContainer.FindControl("codeNumberTextBox")
        Dim txb As TextBox = DirectCast(ctrl, TextBox)
        ' You can check the user input like this: 
        If txb.Text = Me.Session("CaptchaImageText").ToString() Then
            Me.IsCreateSuc = True
        Else
            Me.IsCreateSuc = False
            lbError.Text = "ERROR: Captcha code incorrect, please try again."
            txb.Text = ""
            e.Cancel = True
        End If
    End Sub

End Class