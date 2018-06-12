========================================================================
                  VBASPNETUserControlPassData Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

This project illustrates how to pass data from one user control to another.
A user control can contain other controls like TextBoxes or Labels, These 
control are declared as protected members, We cannot get the use control from
another one directly.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the VBASPNETUserControlPassData.sln.

Step 2: Expand the VBASPNETUserControlPassData web application and press 
        Ctrl + F5 to show the Default.aspx.

Step 3: You can find two messages on Default page. The messages be outputted by 
        UserControl2 user control, UserControl2 can retrieve the data that come from UserControl1
		user control.

Step 4: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a VB "ASP.NET Empty Web Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "VBASPNETUserControlPassData".

Step 2. Add one web form in the root directory, name it as "Default.aspx". This
        page is use to show user controls.

Step 3. Add a folder named "UserControl" with two user controls, "UserControl1.ascx",
        "UserControl2.ascx".

Step 4. The UserControl1 user control provide public property as shown below:
        [code]
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	    If Not IsPostBack Then
            StrCallee = "I come from UserControl1."
            lbPublicVariable.Text = StrCallee
        End If
    End Sub
    ''' <summary>
    ''' UserControl1 message.
    ''' </summary>
    Public Property StrCallee As String = "I come from UserControl1 UserControl."
		[/code]
		
Step 5  The UserControl2 user control is use to output private messages and the data of 
        UserControl1 user control.
	    [code]
    Private userControl1 As UserControl1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Output UserControl2 user control message.
            lbPublicVariable2.Text = StrCaller

            ' Find UserControl1 user control.
            Dim control As Control = Page.FindControl("UserControl1ID")
            userControl1 = DirectCast(control, UserControl1)
            If userControl1 IsNot Nothing Then
                ' Output UserControl1 user control message.
                Dim lbUserControl1 As Label = TryCast(userControl1.FindControl("lbPublicVariable"), Label)
                If lbUserControl1 IsNot Nothing Then
                    lbUserControl1.Text = userControl1.StrCallee
                    tbModifyUserControl1.Text = userControl1.StrCallee
                End If
            End If
        End If

    End Sub
    ''' <summary>
    ''' UserControl2 message.
    ''' </summary>
    Public Property StrCaller As String = "I come from UserControl2."

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        If Not tbModifyUserControl1.Text.Trim().Equals(String.Empty) Then
            Dim control As Control = TryCast(Session("UserControl1"), Control)
            userControl1 = TryCast(control, UserControl1)
            If userControl1 IsNot Nothing Then
                ' Set UserControl1 user control message.
                lbFormatMessage.Text = String.Format("forward message: {0} ", userControl1.StrCallee)
                userControl1.StrCallee = tbModifyUserControl1.Text
                Session("UserControl1") = userControl1
                Dim pageUserControl1 As UserControl1 = TryCast(Page.FindControl("UserControl1ID"), UserControl1)
                Dim lbUserControl1 As Label = TryCast(pageUserControl1.FindControl("lbPublicVariable"), Label)
                lbUserControl1.Text = tbModifyUserControl1.Text
            Else
                control = Page.FindControl("UserControl1ID")
                userControl1 = DirectCast(control, UserControl1)
                userControl1.StrCallee = tbModifyUserControl1.Text.Trim()
                Dim lbUserControl1 As Label = TryCast(userControl1.FindControl("lbPublicVariable"), Label)
                lbUserControl1.Text = userControl1.StrCallee
                Session("UserControl1") = userControl1
            End If
        Else
            lbMessage.Text = "The message can not be null."
        End If
    End Sub
	    [/code]
	   
Step 6. You need drag and drop the user controls in default page.

Step 7. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: ASP.NET User Controls Overview
http://msdn.microsoft.com/en-us/library/fb3w5b53.aspx

MSDN: Page.FindControl Method (String)
http://msdn.microsoft.com/en-us/library/31hxzsdw.aspx

MSDN: Page.LoadControl Method 
http://msdn.microsoft.com/en-us/library/system.web.ui.page.loadcontrol.aspx
/////////////////////////////////////////////////////////////////////////////