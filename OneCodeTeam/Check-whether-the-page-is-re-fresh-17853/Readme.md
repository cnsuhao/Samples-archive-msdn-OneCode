# Check whether the page is "re-fresh" (VBASPNETCheckPageRefresh)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* refresh
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:43:36
## Description

<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b><span style="font-size:14.0pt; font-family:&quot;Cambria&quot;,&quot;serif&quot;">How to check whether the page is &quot;re-fresh&quot; or not
</span></b>(<b style=""><span style="font-size:14.0pt; font-family:Consolas">VBASPNETCheckPageRefresh</span></b>)</p>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp;&nbsp; </span>The VBASPNETCheckPageRefresh sample demonstrates how to check whether the page is &quot;re-fresh&quot; or not. Customer want to check whether a page is &quot;refreshed&quot; again in order to avoid duplicated
 inserting things or some other things……etc. In this demo we create a user control to collect such information and do such a control to deal with the problem in different kinds of pages .
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the VBASPNETCheckPageRefresh.sln. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the Default.aspx page then select &quot;View in Browser&quot;. Click f5 to refresh. Then close the page.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Right-click the UrlReferrer.aspx page then click the link. Do the same operation as Step 2.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Create a VB &quot;ASP.NET Web Application&quot; in Visual Studio 2010/Visual Web Developer. Name it as &quot;VBASPNETCheckPageRefresh&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Add a User Control; in this demo we named it &quot;CheckRefreshUserControl.ascx&quot;. Create a UserControl in order to reuse it in different kinds of pages.<br>
Declare a variable to storage refresh flag. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt; 
   ''' Flag for checking whether deplicated refreshing or not
   ''' &lt;/summary&gt;   
   Public Property ReFreshCheck() As Boolean
       Get
           Return m_ReFreshCheck
       End Get
       Set(ByVal value As Boolean)
           m_ReFreshCheck = Value
       End Set
   End Property
   Private m_ReFreshCheck As Boolean

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt; 
   ''' Flag for checking whether deplicated refreshing or not
   ''' &lt;/summary&gt;   
   Public Property ReFreshCheck() As Boolean
       Get
           Return m_ReFreshCheck
       End Get
       Set(ByVal value As Boolean)
           m_ReFreshCheck = Value
       End Set
   End Property
   Private m_ReFreshCheck As Boolean

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The general idea for us to use is Session</span><span style="">: </span>
<span style="">When you first login</span><span style="">,</span><span style=""> session should be null</span><span style="">,</span><span style=""> but next time when you refresh the page</span><span style=""> (</span><span style="">I mean by pressing F5</span><span style="">),</span><span style="">
 because the session isn't null</span><span style="">,</span><span style=""> we can say that you've now had a &quot;duplicated Refresh&quot;</span><span style="">.</span><span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">To differ it from Post Back</span><span style="">, </span><span style="">we should also use IsPostBack to check whether the IsPostBack is true--If this is true</span><span style="">,
</span><span style="">directly set Session=null</span><span style="">; </span><span style="">Otherwise keep what it is originally</span><span style="">.</span><span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">We can operate the Session in the OnInit event of our UserControl. The code as show below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;     
    ''' Fetch the father page's class name, which is unique    
    ''' &lt;/summary&gt;  
    Private parentName As String = Nothing
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        If TypeOf Parent.Parent Is Page Then
            parentName = Parent.Parent.[GetType]().Name
            If IsPostBack Then
                'If it is post back, Reset the Session value to null, and it represents not repeated loading
                ReFreshCheck = False
                Session(parentName) = Nothing
            ElseIf Request.UrlReferrer IsNot Nothing AndAlso Request.UrlReferrer.ToString() &lt;&gt; Request.Url.ToString() Then
                'Detect whether coming from the other page by Response.Redirect, in order to avoid misuse 
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
            Throw New Exception(&quot;You must put the control inside the page&iuml;&frac14;&#129;&quot;)
        End If
    End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;     
    ''' Fetch the father page's class name, which is unique    
    ''' &lt;/summary&gt;  
    Private parentName As String = Nothing
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        If TypeOf Parent.Parent Is Page Then
            parentName = Parent.Parent.[GetType]().Name
            If IsPostBack Then
                'If it is post back, Reset the Session value to null, and it represents not repeated loading
                ReFreshCheck = False
                Session(parentName) = Nothing
            ElseIf Request.UrlReferrer IsNot Nothing AndAlso Request.UrlReferrer.ToString() &lt;&gt; Request.Url.ToString() Then
                'Detect whether coming from the other page by Response.Redirect, in order to avoid misuse 
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
            Throw New Exception(&quot;You must put the control inside the page&iuml;&frac14;&#129;&quot;)
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
<span style="">Step4. In the Default.aspx, we judgment the value of re-refresh flag of user control in the Page_Load event, and then based on the value to write our business logic code.
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
           'do your logic code here
       Else
           WriteMsg(&quot;Page is refresh&quot;)
           'do your logic code here
       End If
   End Sub


   Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
       If IsNotRefresh() Then
           'do your logic code here
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
       Dim isNotRefresh__1 As Boolean = True


       ' User Control
       Dim cruc As CheckRefreshUserControl = TryCast(Me.FindControl(&quot;CheckRefreshUserControl1&quot;), CheckRefreshUserControl)
       'Result
       isNotRefresh__1 = If(cruc.ReFreshCheck = False, True, False)
       Return isNotRefresh__1
   End Function

</pre>
<pre id="codePreview" class="vb">
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


       If IsNotRefresh() Then
           WriteMsg(&quot;Page is not refresh&quot;)
           'do your logic code here
       Else
           WriteMsg(&quot;Page is refresh&quot;)
           'do your logic code here
       End If
   End Sub


   Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
       If IsNotRefresh() Then
           'do your logic code here
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
       Dim isNotRefresh__1 As Boolean = True


       ' User Control
       Dim cruc As CheckRefreshUserControl = TryCast(Me.FindControl(&quot;CheckRefreshUserControl1&quot;), CheckRefreshUserControl)
       'Result
       isNotRefresh__1 = If(cruc.ReFreshCheck = False, True, False)
       Return isNotRefresh__1
   End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The key code to determine whether is refresh or not as show below:
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
