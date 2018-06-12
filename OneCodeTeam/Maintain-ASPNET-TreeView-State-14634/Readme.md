# Maintain ASP.NET TreeView State (CSASPNETMaintainTreeViewState)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* TreeView
## IsPublished
* True
## ModifiedDate
* 2011-12-28 11:31:52
## Description

<h1>Maintain ASP.NET TreeView State (CSASPNETMaintainTreeViewState)</h1>
<h2>Summary</h2>
<p>The code-sample illustrates how to maintain TreeView's state across postbacks.&nbsp; The web application use session store the TreeView nodes' status and restore them in the next postback event. This interesting function can be used as the signs of the navigator
 bar.</p>
<h2>Demo</h2>
<p>Please follow these demonstration steps below.</p>
<p>Step 1: Open the CSASPNETMaintainTreeViewState.sln.</p>
<p>Step 2: Expand the CSASPNETMaintainTreeViewState web application and press&nbsp;Ctrl &#43; F5 to show the TreeViewPage.aspx.</p>
<p>Step 3: You will see an TreeView control on the page, please operate the TreeView's nodes and Click the Save TreeView state button.</p>
<p>Step 4: Click the Refresh This Page button to invoke the post back event.&nbsp; You can find the TreeView's state will stay the same.</p>
<p>Step 5: You can also click the refresh button of the Browsers, the TreeView state can still be maintained.</p>
<h2>Code Logical</h2>
<p>Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;CSASPNETMaintainTreeViewState&quot;.</p>
<p>Step 2. Add one web form in the root directory, name it as &quot;TreeViewPage.aspx&quot;.</p>
<p>Step 3. Add a TreeView control and two buttons on the page, you can add some nodes of TreeView manually.<br>
&nbsp;&nbsp;<br>
Step 4&nbsp; Create App_Code folder and add TreeViewState class file, This class use to handler TreeView nodes status and restore them:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        /// &lt;summary&gt;
        /// Store TreeView's state in a session.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;treeView&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;key&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;context&quot;&gt;&lt;/param&gt;
        public void SaveTreeView(TreeView treeView, string key,HttpContext context)
        {
            context.Session[key] = treeView.Nodes;
        }

        /// &lt;summary&gt;
        /// Restore TreeView's state from session variable, and invoke SaveTreeView method.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;treeView&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;key&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;context&quot;&gt;&lt;/param&gt;
        public void RestoreTreeView(TreeView treeView, string key, HttpContext context)
        {
            if (new TreeViewState(key).IsSaved)
            {
                treeView.Nodes.Clear();

                TreeNodeCollection nodes = (TreeNodeCollection)context.Session[key];
                for (int index = nodes.Count - 1; index &gt;= 0; index--)
                {
                    treeView.Nodes.AddAt(0, nodes[index]);
                }
                this.SaveTreeView(treeView, key, context);
            }
            
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;Store&nbsp;TreeView's&nbsp;state&nbsp;in&nbsp;a&nbsp;session.</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;treeView&quot;&gt;&lt;/param&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;key&quot;&gt;&lt;/param&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;context&quot;&gt;&lt;/param&gt;</span><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;SaveTreeView(TreeView&nbsp;treeView,&nbsp;<span class="cs__keyword">string</span>&nbsp;key,HttpContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Session[key]&nbsp;=&nbsp;treeView.Nodes;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;Restore&nbsp;TreeView's&nbsp;state&nbsp;from&nbsp;session&nbsp;variable,&nbsp;and&nbsp;invoke&nbsp;SaveTreeView&nbsp;method.</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;treeView&quot;&gt;&lt;/param&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;key&quot;&gt;&lt;/param&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;context&quot;&gt;&lt;/param&gt;</span><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;RestoreTreeView(TreeView&nbsp;treeView,&nbsp;<span class="cs__keyword">string</span>&nbsp;key,&nbsp;HttpContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">new</span>&nbsp;TreeViewState(key).IsSaved)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;treeView.Nodes.Clear();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TreeNodeCollection&nbsp;nodes&nbsp;=&nbsp;(TreeNodeCollection)context.Session[key];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;index&nbsp;=&nbsp;nodes.Count&nbsp;-&nbsp;<span class="cs__number">1</span>;&nbsp;index&nbsp;&gt;=&nbsp;<span class="cs__number">0</span>;&nbsp;index--)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;treeView.Nodes.AddAt(<span class="cs__number">0</span>,&nbsp;nodes[index]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.SaveTreeView(treeView,&nbsp;key,&nbsp;context);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 5. Add SaveTreeViewState button's OnClick event and TreeView data bind event code of TreeViewState.aspx.cs file below:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">		    /// &lt;summary&gt;
        /// The method use to bind TreeView with node's last save state across postback.
        /// &lt;/summary&gt;
        private void TreeViewBind()
        {
            if (state.IsSaved)
            {
                state.RestoreTreeView(tvwNodes, &quot;TreeViewState&quot;, HttpContext.Current);
            }
        }

        /// &lt;summary&gt;
        /// The button click event use to save TreeView's state 
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        protected void btnSaveTreeViewState_Click(object sender, EventArgs e)
        {
            state.SaveTreeView(tvwNodes, &quot;TreeViewState&quot;, HttpContext.Current);
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;The&nbsp;method&nbsp;use&nbsp;to&nbsp;bind&nbsp;TreeView&nbsp;with&nbsp;node's&nbsp;last&nbsp;save&nbsp;state&nbsp;across&nbsp;postback.</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;TreeViewBind()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(state.IsSaved)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;state.RestoreTreeView(tvwNodes,&nbsp;<span class="cs__string">&quot;TreeViewState&quot;</span>,&nbsp;HttpContext.Current);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;The&nbsp;button&nbsp;click&nbsp;event&nbsp;use&nbsp;to&nbsp;save&nbsp;TreeView's&nbsp;state&nbsp;</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span><span class="cs__keyword">protected</span><span class="cs__keyword">void</span>&nbsp;btnSaveTreeViewState_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;state.SaveTreeView(tvwNodes,&nbsp;<span class="cs__string">&quot;TreeViewState&quot;</span>,&nbsp;HttpContext.Current);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 6. Build the application and you can debug it.</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode">References</h2>
</div>
<p>&nbsp;</p>
<p>MSDN: TreeView Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treeview.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treeview.aspx</a></p>
<p>MSDN: TreeNodeCollection Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treenodecollection.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treenodecollection.aspx</a></p>
<p>&nbsp;</p>
<p></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p></p>
