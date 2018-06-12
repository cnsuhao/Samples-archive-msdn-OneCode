# Image Verification Code for Logging
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* ASP.NET
## IsPublished
* True
## ModifiedDate
* 2013-01-13 06:59:23
## Description

<h1>ASP.NET Image Verification Code for logging (VBASPNETVerificationImage)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample will demo you how to create an image verification code in ASP.NET. Whether registered or logged in, many times we all need the verification code in order to prevent malicious actions. Such as: auto registration by &quot;Automatic-Teller
 Registration Machine&quot; or the malicious password cracking. We provide a program to acquire a specified number of characters or symbols, and add some interference with the line, and then output a picture at the same time save the value in session. The user
 input content according to the display contents of the picture, and then to compare the input with the value in SESSION.<span style="">&nbsp;
</span>According to the results of the comparison, we will determine the follow-up operations.
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the VBASPNETVerificationImage.sln file. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the Default.aspx page then select &quot;View in Browser&quot;.
<br>
<span style=""><img src="/site/view/file/74563/1/image.png" alt="" width="457" height="101" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Enter the characters in the picture and then we will see as below:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""><img src="/site/view/file/74564/1/image.png" alt="" width="498" height="91" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">If we do not enter the characters in the picture. The page will be shown as below:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""><img src="/site/view/file/74565/1/image.png" alt="" width="494" height="86" align="middle">
</span><span style=""><span style="">&nbsp;</span> </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 3: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Create a VB &quot;ASP.NET Web Application&quot; in Visual Studio /Visual Web Developer. Name it as &quot;VBASPNETVerificationImage&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal"><span style="">Step 2: Follow the steps below to add a generic handler to our solution.<br>
Right-click the solution&gt;&gt; add a new item &gt;&gt; Generic Handler. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 3: Code will be rewritten as follows: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class Handler
&nbsp;&nbsp;&nbsp; Implements System.Web.IHttpHandler, IRequiresSessionState


&nbsp;&nbsp;&nbsp; Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Whether to generate verification code or not.
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim isCreate As Boolean = True


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Session[&quot;CreateTime&quot;]: The createTime of verification code
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If context.Session(&quot;CreateTime&quot;) Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Session(&quot;CreateTime&quot;) = DateTime.Now
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim startTime As DateTime = Convert.ToDateTime(context.Session(&quot;CreateTime&quot;))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim endTime As DateTime = Convert.ToDateTime(DateTime.Now)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ts As TimeSpan = endTime - startTime


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' The time interval to generate a verification code.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If ts.Minutes &gt; 15 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isCreate = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Session(&quot;CreateTime&quot;) = DateTime.Now
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isCreate = False
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If




&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Response.ContentType = &quot;image/gif&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Create Bitmap object and to draw
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim basemap As New Bitmap(200, 60)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim graph As Graphics = Graphics.FromImage(basemap)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; graph.FillRectangle(New SolidBrush(Color.White), 0, 0, 200, 60)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim font As New Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim r As New Random()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim letters As String = &quot;ABCDEFGHIJKLMNPQRSTUVWXYZabcdefghijklmnpqrstuvwxyz0123456789&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim letter As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim s As New StringBuilder()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If isCreate Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add a random five-letter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For x As Integer = 0 To 4
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; letter = letters.Substring(r.[Next](0, letters.Length - 1), 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; s.Append(letter)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Draw the String
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;graph.DrawString(letter, font, New SolidBrush(Color.Black), x * 38, r.[Next](0, 15))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Using the previously generated verification code.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim currentCode As String = context.Session(&quot;ValidateCode&quot;).ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; s.Append(currentCode)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each item As Char In currentCode
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; letter = item.ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Draw the String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; graph.DrawString(letter, font, New SolidBrush(Color.Black), currentCode.IndexOf(item) * 38, r.[Next](0, 15))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Confusion background
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim linePen As New Pen(New SolidBrush(Color.Black), 2)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For x As Integer = 0 To 9
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; graph.DrawLine(linePen, New Point(r.[Next](0, 199), r.[Next](0, 59)), New Point(r.[Next](0, 199), r.[Next](0, 59)))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Save the picture to the output stream&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;basemap.Save(context.Response.OutputStream, ImageFormat.Gif)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' If you do not realize the IRequiresSessionState,it will be wrong here,and it can not generate a picture also.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Session(&quot;ValidateCode&quot;) = s.ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Response.[End]()




&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return False
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp; End Property


End Class

</pre>
<pre id="codePreview" class="vb">
Public Class Handler
&nbsp;&nbsp;&nbsp; Implements System.Web.IHttpHandler, IRequiresSessionState


&nbsp;&nbsp;&nbsp; Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Whether to generate verification code or not.
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim isCreate As Boolean = True


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Session[&quot;CreateTime&quot;]: The createTime of verification code
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If context.Session(&quot;CreateTime&quot;) Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Session(&quot;CreateTime&quot;) = DateTime.Now
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim startTime As DateTime = Convert.ToDateTime(context.Session(&quot;CreateTime&quot;))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim endTime As DateTime = Convert.ToDateTime(DateTime.Now)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ts As TimeSpan = endTime - startTime


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' The time interval to generate a verification code.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If ts.Minutes &gt; 15 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isCreate = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Session(&quot;CreateTime&quot;) = DateTime.Now
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isCreate = False
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If




&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Response.ContentType = &quot;image/gif&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Create Bitmap object and to draw
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim basemap As New Bitmap(200, 60)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim graph As Graphics = Graphics.FromImage(basemap)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; graph.FillRectangle(New SolidBrush(Color.White), 0, 0, 200, 60)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim font As New Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim r As New Random()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim letters As String = &quot;ABCDEFGHIJKLMNPQRSTUVWXYZabcdefghijklmnpqrstuvwxyz0123456789&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim letter As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim s As New StringBuilder()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If isCreate Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add a random five-letter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For x As Integer = 0 To 4
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; letter = letters.Substring(r.[Next](0, letters.Length - 1), 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; s.Append(letter)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Draw the String
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;graph.DrawString(letter, font, New SolidBrush(Color.Black), x * 38, r.[Next](0, 15))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Using the previously generated verification code.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim currentCode As String = context.Session(&quot;ValidateCode&quot;).ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; s.Append(currentCode)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each item As Char In currentCode
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; letter = item.ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Draw the String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; graph.DrawString(letter, font, New SolidBrush(Color.Black), currentCode.IndexOf(item) * 38, r.[Next](0, 15))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Confusion background
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim linePen As New Pen(New SolidBrush(Color.Black), 2)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For x As Integer = 0 To 9
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; graph.DrawLine(linePen, New Point(r.[Next](0, 199), r.[Next](0, 59)), New Point(r.[Next](0, 199), r.[Next](0, 59)))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Save the picture to the output stream&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;basemap.Save(context.Response.OutputStream, ImageFormat.Gif)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' If you do not realize the IRequiresSessionState,it will be wrong here,and it can not generate a picture also.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Session(&quot;ValidateCode&quot;) = s.ToString()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; context.Response.[End]()




&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return False
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp; End Property


End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<b style=""><span style="">[Note] </span></b><span style="">The Handler class is not only need to implement the IHttpHandler interface (apparently), in order to use the SessionState Handler class we also need to implement the IRequiresSessionState interface.
 For this interface, the MSDN explanation of like this: Specifies that the target HTTP handlerrequires read and write access to session-state values. This is a marker interface and has no methods.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 4: Modify the code of the test page. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;asp:TextBox ID=&quot;tbCode&quot; runat=&quot;server&quot;&gt;&lt;/asp:TextBox&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Image ID=&quot;Image1&quot; ImageUrl=&quot;~/Handler.ashx&quot; runat=&quot;server&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Button ID=&quot;btnOK&quot; runat=&quot;server&quot; Text=&quot;Validate&quot; OnClick=&quot;btnOK_Click&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Literal ID=&quot;ltrMessage&quot; runat=&quot;server&quot;&gt;&lt;/asp:Literal&gt;

</pre>
<pre id="codePreview" class="vb">
&lt;asp:TextBox ID=&quot;tbCode&quot; runat=&quot;server&quot;&gt;&lt;/asp:TextBox&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Image ID=&quot;Image1&quot; ImageUrl=&quot;~/Handler.ashx&quot; runat=&quot;server&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Button ID=&quot;btnOK&quot; runat=&quot;server&quot; Text=&quot;Validate&quot; OnClick=&quot;btnOK_Click&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Literal ID=&quot;ltrMessage&quot; runat=&quot;server&quot;&gt;&lt;/asp:Literal&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">The image will show the </span>Image Verification Code. The button will be used to validate and the Literal will be used to show the result.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
The code of the click event of button as shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Compare the value in session and type. If equal, set a success to the text of Literal, otherwise failed.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp;&nbsp; Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If tbCode.Text.Trim().ToLower.Equals(Session(&quot;ValidateCode&quot;).ToString().ToLower()) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ltrMessage.Text = &quot;success&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ltrMessage.Text = &quot;failed&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Compare the value in session and type. If equal, set a success to the text of Literal, otherwise failed.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp;&nbsp; Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If tbCode.Text.Trim().ToLower.Equals(Session(&quot;ValidateCode&quot;).ToString().ToLower()) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ltrMessage.Text = &quot;success&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ltrMessage.Text = &quot;failed&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style="">Step 5: You can debug and test it.
</span></p>
<h2>More Information<br>
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">IRequiresSessionState Interface
</span></h2>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/system.web.sessionstate.irequiressessionstate.aspx">http://msdn.microsoft.com/en-us/library/system.web.sessionstate.irequiressessionstate.aspx</a><br>
IHttpHandler Interface<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ihttphandler.aspx">http://msdn.microsoft.com/en-us/library/system.web.ihttphandler.aspx</a><br>
IHttpHandler<span>.</span>ProcessRequest Method<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ihttphandler.processrequest">http://msdn.microsoft.com/en-us/library/system.web.ihttphandler.processrequest</a></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
