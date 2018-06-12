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
* 2013-07-05 02:36:44
## Description

<h1>How to check whether the page is refreshed or <span class="Heading1Char">not (<span class="SpellE">CSASPNETCheckPageRefresh</span>)
</span></h1>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The CSASPNETCheckPageRefresh sample demonstrates how to check whether the page is refreshed or not. User usually wants to check whether a page is refreshed again in order to avoid some duplicated operations. In this demo, we create a user control
 to collect such information.</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSASPNETCheckPageRefresh.sln. </span></p>
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
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Create a C# &quot;ASP.NET Web Application&quot; in Visual Studio 2012/Visual Web Developer. Name it as &quot;CSASPNETCheckPageRefresh&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Add a User Control; in this demo, we named it &quot;CheckRefreshUserControl.ascx&quot;. Create a UserControl in order to reuse it in different kinds of pages.<br>
Declare a variable to storage refresh flag. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt; 
      /// Flag for checking whether deplicated refreshing or not
      /// &lt;/summary&gt;   
      public bool ReFreshCheck { get; set; }

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt; 
      /// Flag for checking whether deplicated refreshing or not
      /// &lt;/summary&gt;   
      public bool ReFreshCheck { get; set; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">When you login the page for the first time</span><span style="">,</span><span style=""> session should be null</span><span style="">,</span><span style=""> but when you refresh the page</span><span style="">,</span><span style=""> the session
 will not be null</span><span style="">.</span><span style=""> We can say that you've performed a &quot;duplicated Refresh&quot;</span><span style="">.</span><span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">To differentiate it from Post Back</span><span style="">, </span><span style="">we should also use IsPostBack to check whether the IsPostBack is true--If this is true</span><span style="">,
</span><span style="">directly set Session=null</span><span style="">.</span><span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">We can operate the Session in the OnInit event of our UserControl. The code as shown below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;     
/// Fetch the parent page's class name, which is unique.    
/// &lt;/summary&gt;  
string parentName = null;
protected override void OnInit(EventArgs e)
{
    if (Parent.Parent is Page)
    {
        parentName = Parent.Parent.GetType().Name;
        if (IsPostBack)//If it is Post Back, Reset the Session value to null, and it represents not repeated loading
        {
            ReFreshCheck = false;
            Session[parentName] = null;
        }
        else if (Request.UrlReferrer != null && Request.UrlReferrer.ToString() != Request.Url.ToString())
        {
            //Detect whether coming from the other page by Response.Redirect, in order to avoid misuse 
            Session[parentName] = null;
        }
        else
        {                   
            if (Session[parentName] == null)
            {
                ReFreshCheck = false;
                Session[parentName] = true;
            }
            else
            {
                ReFreshCheck = true;
            }
        }
    }
    else
    {
        throw new Exception(&quot;You must put the control inside the page!&quot;);
    }
}      

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;     
/// Fetch the parent page's class name, which is unique.    
/// &lt;/summary&gt;  
string parentName = null;
protected override void OnInit(EventArgs e)
{
    if (Parent.Parent is Page)
    {
        parentName = Parent.Parent.GetType().Name;
        if (IsPostBack)//If it is Post Back, Reset the Session value to null, and it represents not repeated loading
        {
            ReFreshCheck = false;
            Session[parentName] = null;
        }
        else if (Request.UrlReferrer != null && Request.UrlReferrer.ToString() != Request.Url.ToString())
        {
            //Detect whether coming from the other page by Response.Redirect, in order to avoid misuse 
            Session[parentName] = null;
        }
        else
        {                   
            if (Session[parentName] == null)
            {
                ReFreshCheck = false;
                Session[parentName] = true;
            }
            else
            {
                ReFreshCheck = true;
            }
        }
    }
    else
    {
        throw new Exception(&quot;You must put the control inside the page!&quot;);
    }
}      

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step3. Use the UserControl in the Default page. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
&lt;%@ Register Src=&quot;CheckRefreshUserControl.ascx&quot; TagName=&quot;CheckRefreshUserControl&quot;
TagPrefix=&quot;uc1&quot; %&gt;
…
   &lt;uc1:CheckRefreshUserControl ID=&quot;CheckRefreshUserControl1&quot; runat=&quot;server&quot; /&gt;
…</pre>
<pre id="codePreview" class="csharp">
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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected void Page_Load(object sender, EventArgs e)
        {
            if (IsNotRefresh())
            {
                WriteMsg(&quot;Page is not refresh&quot;);
                //do your logic code here
            }
            else
            {
                WriteMsg(&quot;Page is refresh&quot;);
                //do your logic code here
            }
         
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsNotRefresh())
            {
                WriteMsg(&quot;Page is not refresh&quot;);
                //do your logic code here
            }
        }


        /// &lt;summary&gt;
        /// Output some message
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;strMsg&quot;&gt;&lt;/param&gt;
        private void WriteMsg(string strMsg)
        {
            Response.Clear();
            Response.Write(strMsg);
        }


        /// &lt;summary&gt;
        /// Determine whether is refresh or not
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private bool IsNotRefresh()
        {
            bool isNotRefresh = true;


            // User Control
            CheckRefreshUserControl cruc = this.FindControl(&quot;CheckRefreshUserControl1&quot;) as CheckRefreshUserControl;            
            //Result
            isNotRefresh = cruc.ReFreshCheck == false ? true : false;
            return isNotRefresh;
        }

</pre>
<pre id="codePreview" class="csharp">
protected void Page_Load(object sender, EventArgs e)
        {
            if (IsNotRefresh())
            {
                WriteMsg(&quot;Page is not refresh&quot;);
                //do your logic code here
            }
            else
            {
                WriteMsg(&quot;Page is refresh&quot;);
                //do your logic code here
            }
         
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsNotRefresh())
            {
                WriteMsg(&quot;Page is not refresh&quot;);
                //do your logic code here
            }
        }


        /// &lt;summary&gt;
        /// Output some message
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;strMsg&quot;&gt;&lt;/param&gt;
        private void WriteMsg(string strMsg)
        {
            Response.Clear();
            Response.Write(strMsg);
        }


        /// &lt;summary&gt;
        /// Determine whether is refresh or not
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private bool IsNotRefresh()
        {
            bool isNotRefresh = true;


            // User Control
            CheckRefreshUserControl cruc = this.FindControl(&quot;CheckRefreshUserControl1&quot;) as CheckRefreshUserControl;            
            //Result
            isNotRefresh = cruc.ReFreshCheck == false ? true : false;
            return isNotRefresh;
        }

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// User Control
CheckRefreshUserControl cruc = this.FindControl(&quot;CheckRefreshUserControl1&quot;) as CheckRefreshUserControl;            
//Result
isRefresh = cruc.ReFreshCheck;

</pre>
<pre id="codePreview" class="csharp">
// User Control
CheckRefreshUserControl cruc = this.FindControl(&quot;CheckRefreshUserControl1&quot;) as CheckRefreshUserControl;            
//Result
isRefresh = cruc.ReFreshCheck;

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
