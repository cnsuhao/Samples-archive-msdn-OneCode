# Check whether the page is "re-fresh"
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* refresh
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:37:57
## Description

<h1>How to check whether the page is refreshed or not (<span class="SpellE">VBASPNETCheckPageRefresh</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The VBASPNETCheckPageRefresh sample demonstrates how to check whether the page is refreshed or not. User usually wants to check whether a page is refreshed again in order to avoid some duplicated operations. In this demo, we create a user control
 to collect such information. </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the VBASPNETCheckPageRefresh.sln. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the Default.aspx page then select &quot;View in Browser&quot;. Press F5 to refresh. Then close the page.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Right-click the UrlReferrer.aspx page then click the link. Do the same operation as Step 2.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Create a VB &quot;ASP.NET Web Application&quot; in Visual Studio 2012/Visual Web Developer. Name it as &quot;VBASPNETCheckPageRefresh&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Add a User Control; in this demo, we named it &quot;CheckRefreshUserControl.ascx&quot;. Create a UserControl in order to reuse it in different kinds of pages.<br>
Declare a variable to storage refresh flag. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt; 
''' Flag for checking whether duplicated refreshing or not.
''' &lt;/summary&gt;   
Public Property ReFreshCheck() As Boolean
    Get
        Return _reFreshCheck
    End Get
    Set(ByVal value As Boolean)
        _reFreshCheck = Value
    End Set
End Property
Private _reFreshCheck As Boolean

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt; 
''' Flag for checking whether duplicated refreshing or not.
''' &lt;/summary&gt;   
Public Property ReFreshCheck() As Boolean
    Get
        Return _reFreshCheck
    End Get
    Set(ByVal value As Boolean)
        _reFreshCheck = Value
    End Set
End Property
Private _reFreshCheck As Boolean

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">When you login the page for the first time</span><span style="">,</span><span style=""> session should be null</span><span style="">,</span><span style=""> but when you refresh the page</span><span style="">,</span><span style=""> the session
 will not be null</span><span style="">.</span><span style=""> We can say that you've performed a &quot;duplicated Refresh&quot;</span><span style="">.</span><span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">To differentiate it from Post Back</span><span style="">, </span><span style="">we should also use
<span class="SpellE">IsPostBack</span> to check whether the <span class="SpellE">
IsPostBack</span> is true--If this is true</span><span style="">, </span><span style="">directly set Session=null</span><span style="">.</span><span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">We can operate the Session in the <span class="SpellE">OnInit</span> event of our
<span class="SpellE">UserControl</span>. The code as shown below: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;     
''' Fetch the parent page's class name, which is unique.    
''' &lt;/summary&gt;  
Private parentName As String = Nothing
Protected Overrides Sub OnInit(ByVal e As EventArgs)
    If TypeOf Parent.Parent Is Page Then
        parentName = Parent.Parent.[GetType]().Name
        If IsPostBack Then
            ' If it is postback, reset the Session value to null, and it represents 
            ' it's not a repeated loading.
            ReFreshCheck = False
            Session(parentName) = Nothing
        ElseIf Request.UrlReferrer IsNot Nothing AndAlso Request.UrlReferrer.ToString() &lt;&gt; Request.Url.ToString() Then


            ' Detect whether the request comes from the other page. 
            Session(parentName) = Nothing
        Else
            If Session(parentName) Is Nothing Then
                ReFreshCheck = False
                Session(parentName) = True
            Else
                ReFreshCheck = True
            End If
        End If
    Else
        Throw New Exception(&quot;You must put the control inside the page!&quot;)
    End If
End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;     
''' Fetch the parent page's class name, which is unique.    
''' &lt;/summary&gt;  
Private parentName As String = Nothing
Protected Overrides Sub OnInit(ByVal e As EventArgs)
    If TypeOf Parent.Parent Is Page Then
        parentName = Parent.Parent.[GetType]().Name
        If IsPostBack Then
            ' If it is postback, reset the Session value to null, and it represents 
            ' it's not a repeated loading.
            ReFreshCheck = False
            Session(parentName) = Nothing
        ElseIf Request.UrlReferrer IsNot Nothing AndAlso Request.UrlReferrer.ToString() &lt;&gt; Request.Url.ToString() Then


            ' Detect whether the request comes from the other page. 
            Session(parentName) = Nothing
        Else
            If Session(parentName) Is Nothing Then
                ReFreshCheck = False
                Session(parentName) = True
            Else
                ReFreshCheck = True
            End If
        End If
    Else
        Throw New Exception(&quot;You must put the control inside the page!&quot;)
    End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step3. Use the UserControl in the Default page. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;%@ Register Src=&quot;CheckRefreshUserControl.ascx&quot; TagName=&quot;CheckRefreshUserControl&quot;
TagPrefix=&quot;uc1&quot; %&gt;
…
   &lt;uc1:CheckRefreshUserControl ID=&quot;CheckRefreshUserControl1&quot; runat=&quot;server&quot; /&gt;
…</pre>
<pre id="codePreview" class="vb">
&lt;%@ Register Src=&quot;CheckRefreshUserControl.ascx&quot; TagName=&quot;CheckRefreshUserControl&quot;
TagPrefix=&quot;uc1&quot; %&gt;
…
   &lt;uc1:CheckRefreshUserControl ID=&quot;CheckRefreshUserControl1&quot; runat=&quot;server&quot; /&gt;
…</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step4. In the Default.aspx, first, we judge the value of refresh flag in the
<span class="SpellE">Page_Load</span> event, and then write our business logic code based on the value.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    If IsNotRefresh() Then
        WriteMsg(&quot;Page is not refresh&quot;)
        ' Do your logic code here
    Else
        WriteMsg(&quot;Page is refresh&quot;)
        ' Do your logic code here
    End If
End Sub


Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
    If IsNotRefresh() Then
        ' Do your logic code here
        WriteMsg(&quot;Page is not refresh&quot;)
    End If
End Sub




''' &lt;summary&gt;
''' Output some message
''' &lt;/summary&gt;
''' &lt;param name=&quot;strMsg&quot;&gt;&lt;/param&gt;
Private Sub WriteMsg(ByVal strMsg As String)
    Response.Clear()
    Response.Write(strMsg)
End Sub


''' &lt;summary&gt;
''' Determine whether is refresh or not
''' &lt;/summary&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Function IsNotRefresh() As Boolean
    Dim _isNotRefresh As Boolean = True


    ' User Control
    Dim cruc As CheckRefreshUserControl = TryCast(Me.FindControl(&quot;CheckRefreshUserControl1&quot;), CheckRefreshUserControl)


    ' Result
    _isNotRefresh = If(cruc.ReFreshCheck = False, True, False)
    Return _isNotRefresh
End Function

</pre>
<pre id="codePreview" class="vb">
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    If IsNotRefresh() Then
        WriteMsg(&quot;Page is not refresh&quot;)
        ' Do your logic code here
    Else
        WriteMsg(&quot;Page is refresh&quot;)
        ' Do your logic code here
    End If
End Sub


Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
    If IsNotRefresh() Then
        ' Do your logic code here
        WriteMsg(&quot;Page is not refresh&quot;)
    End If
End Sub




''' &lt;summary&gt;
''' Output some message
''' &lt;/summary&gt;
''' &lt;param name=&quot;strMsg&quot;&gt;&lt;/param&gt;
Private Sub WriteMsg(ByVal strMsg As String)
    Response.Clear()
    Response.Write(strMsg)
End Sub


''' &lt;summary&gt;
''' Determine whether is refresh or not
''' &lt;/summary&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Function IsNotRefresh() As Boolean
    Dim _isNotRefresh As Boolean = True


    ' User Control
    Dim cruc As CheckRefreshUserControl = TryCast(Me.FindControl(&quot;CheckRefreshUserControl1&quot;), CheckRefreshUserControl)


    ' Result
    _isNotRefresh = If(cruc.ReFreshCheck = False, True, False)
    Return _isNotRefresh
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The key code to judge whether the page is refreshed or not as shown below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' User Control
Dim cruc As CheckRefreshUserControl = TryCast(Me.FindControl(&quot;CheckRefreshUserControl1&quot;), CheckRefreshUserControl)
'Result
isRefresh = cruc.ReFreshCheck

</pre>
<pre id="codePreview" class="vb">
' User Control
Dim cruc As CheckRefreshUserControl = TryCast(Me.FindControl(&quot;CheckRefreshUserControl1&quot;), CheckRefreshUserControl)
'Result
isRefresh = cruc.ReFreshCheck

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step5.<b style=""> </b>Build the application and you can debug it.<b style="">
</b></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
