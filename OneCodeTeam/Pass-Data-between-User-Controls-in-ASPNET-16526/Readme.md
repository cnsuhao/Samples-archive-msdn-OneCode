# Pass Data between User Controls in ASP.NET (VBASPNETUserControlPassData)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* User Control
## IsPublished
* True
## ModifiedDate
* 2012-06-11 12:50:43
## Description
========================================================================<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;VBASPNETUserControlPassData Overview<br>
========================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Use:<br>
<br>
This project illustrates how to pass data from one user control to another.<br>
A user control can contain other controls like TextBoxes or Labels, These <br>
control are declared as protected members, We cannot get the use control from<br>
another one directly.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the VBASPNETUserControlPassData.sln.<br>
<br>
Step 2: Expand the VBASPNETUserControlPassData web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx.<br>
<br>
Step 3: You can find two messages on Default page. The messages be outputted by <br>
&nbsp; &nbsp; &nbsp; &nbsp;UserControl2 user control, UserControl2 can retrieve the data that come from UserControl1<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;user control.<br>
<br>
Step 4: Validation finished.<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logical:<br>
<br>
Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBASPNETUserControlPassData&quot;.<br>
<br>
Step 2. Add one web form in the root directory, name it as &quot;Default.aspx&quot;. This<br>
&nbsp; &nbsp; &nbsp; &nbsp;page is use to show user controls.<br>
<br>
Step 3. Add a folder named &quot;UserControl&quot; with two user controls, &quot;UserControl1.ascx&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;UserControl2.ascx&quot;.<br>
<br>
Step 4. The UserControl1 user control provide public property as shown below:<br>
&nbsp; &nbsp; &nbsp; &nbsp;[code]<br>
&nbsp; &nbsp;Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;If Not IsPostBack Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StrCallee = &quot;I come from UserControl1.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbPublicVariable.Text = StrCallee<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' UserControl1 message.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Public Property StrCallee As String = &quot;I come from UserControl1 UserControl.&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step 5 &nbsp;The UserControl2 user control is use to output private messages and the data of
<br>
&nbsp; &nbsp; &nbsp; &nbsp;UserControl1 user control.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[code]<br>
&nbsp; &nbsp;Private userControl1 As UserControl1<br>
<br>
&nbsp; &nbsp;Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load<br>
&nbsp; &nbsp; &nbsp; &nbsp;If Not Page.IsPostBack Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Output UserControl2 user control message.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbPublicVariable2.Text = StrCaller<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Find UserControl1 user control.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim control As Control = Page.FindControl(&quot;UserControl1ID&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;userControl1 = DirectCast(control, UserControl1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If userControl1 IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Output UserControl1 user control message.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim lbUserControl1 As Label = TryCast(userControl1.FindControl(&quot;lbPublicVariable&quot;), Label)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If lbUserControl1 IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbUserControl1.Text = userControl1.StrCallee<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tbModifyUserControl1.Text = userControl1.StrCallee<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp;End Sub<br>
&nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp;''' UserControl2 message.<br>
&nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp;Public Property StrCaller As String = &quot;I come from UserControl2.&quot;<br>
<br>
&nbsp; &nbsp;Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click<br>
&nbsp; &nbsp; &nbsp; &nbsp;If Not tbModifyUserControl1.Text.Trim().Equals(String.Empty) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim control As Control = TryCast(Session(&quot;UserControl1&quot;), Control)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;userControl1 = TryCast(control, UserControl1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If userControl1 IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Set UserControl1 user control message.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbFormatMessage.Text = String.Format(&quot;forward message: {0} &quot;, userControl1.StrCallee)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;userControl1.StrCallee = tbModifyUserControl1.Text<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Session(&quot;UserControl1&quot;) = userControl1<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim pageUserControl1 As UserControl1 = TryCast(Page.FindControl(&quot;UserControl1ID&quot;), UserControl1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim lbUserControl1 As Label = TryCast(pageUserControl1.FindControl(&quot;lbPublicVariable&quot;), Label)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbUserControl1.Text = tbModifyUserControl1.Text<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;control = Page.FindControl(&quot;UserControl1ID&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;userControl1 = DirectCast(control, UserControl1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;userControl1.StrCallee = tbModifyUserControl1.Text.Trim()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim lbUserControl1 As Label = TryCast(userControl1.FindControl(&quot;lbPublicVariable&quot;), Label)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbUserControl1.Text = userControl1.StrCallee<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Session(&quot;UserControl1&quot;) = userControl1<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lbMessage.Text = &quot;The message can not be null.&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp;End Sub<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code]<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
Step 6. You need drag and drop the user controls in default page.<br>
<br>
Step 7. Build the application and you can debug it.<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
MSDN: ASP.NET User Controls Overview<br>
http://msdn.microsoft.com/en-us/library/fb3w5b53.aspx<br>
<br>
MSDN: Page.FindControl Method (String)<br>
http://msdn.microsoft.com/en-us/library/31hxzsdw.aspx<br>
<br>
MSDN: Page.LoadControl Method <br>
http://msdn.microsoft.com/en-us/library/system.web.ui.page.loadcontrol.aspx<br>
/////////////////////////////////////////////////////////////////////////////<br>
