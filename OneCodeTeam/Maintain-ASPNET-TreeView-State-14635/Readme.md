# Maintain ASP.NET TreeView State (VBASPNETMainta​inTreeViewState​​)
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
* 2011-12-28 11:37:34
## Description

<h1>Maintain ASP.NET TreeView State (VBASPNETMaintainTreeViewState)</h1>
<h2>Summary</h2>
<p>The code-sample illustrates how to maintain TreeView's state across postbacks.&nbsp; The web application use session store the TreeView nodes' status and restore them in the next postback event. This interesting function can be used as the signs of the navigator
 bar.</p>
<h2>Demo</h2>
<p>Please follow these demonstration steps below.</p>
<p>Step 1: Open the VBASPNETMaintainTreeViewState.sln.</p>
<p>Step 2: Expand the VBASPNETMaintainTreeViewState web application and press&nbsp;Ctrl &#43; F5 to show the TreeViewPage.aspx.</p>
<p>Step 3: You will see an TreeView control on the page, please operate the TreeView's nodes and Click the Save TreeView state button.&nbsp;</p>
<p>Step 4: Click the Refresh This Page button to invoke the post back event.&nbsp; You can find the TreeView's state will stay the same.</p>
<p>Step 5: You can also click the refresh button of Browsers, the TreeView state can still be maintained.</p>
<h2>Code Logical</h2>
<p>Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or&nbsp;Visual Web Developer 2010. Name it as &quot;VBASPNETMaintainTreeViewState&quot;.</p>
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
<pre class="hidden">        ''' &lt;summary&gt;
        ''' Store TreeView's state in a session.
        ''' &lt;/summary&gt;
        ''' &lt;param name=&quot;treeView&quot;&gt;&lt;/param&gt;
        ''' &lt;param name=&quot;key&quot;&gt;&lt;/param&gt;
        ''' &lt;param name=&quot;context&quot;&gt;&lt;/param&gt;
        Public Sub SaveTreeView(ByVal treeView As TreeView, ByVal key As String, ByVal context As HttpContext)
            context.Session(key) = treeView.Nodes
        End Sub

        ''' &lt;summary&gt;
        ''' Restore TreeView's state from session variable, and invoke SaveTreeView method.
        ''' &lt;/summary&gt;
        ''' &lt;param name=&quot;treeView&quot;&gt;&lt;/param&gt;
        ''' &lt;param name=&quot;key&quot;&gt;&lt;/param&gt;
        ''' &lt;param name=&quot;context&quot;&gt;&lt;/param&gt;
        Public Sub RestoreTreeView(ByVal treeView As TreeView, ByVal key As String, ByVal context As HttpContext)
            If New TreeViewState(key).IsSaved Then
                treeView.Nodes.Clear()

                Dim nodes As TreeNodeCollection = DirectCast(context.Session(key), TreeNodeCollection)
                For index As Integer = nodes.Count - 1 To 0 Step -1
                    treeView.Nodes.AddAt(0, nodes(index))
                Next
                Me.SaveTreeView(treeView, key, context)
            End If

        End Sub</pre>
<div class="preview">
<pre class="csharp"><span class="cs__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span><span class="cs__string">'&nbsp;Store&nbsp;TreeView'</span>s&nbsp;state&nbsp;<span class="cs__keyword">in</span>&nbsp;a&nbsp;session.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="cs__string">&quot;treeView&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="cs__string">&quot;key&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="cs__string">&quot;context&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Sub&nbsp;SaveTreeView(ByVal&nbsp;treeView&nbsp;As&nbsp;TreeView,&nbsp;ByVal&nbsp;key&nbsp;As&nbsp;String,&nbsp;ByVal&nbsp;context&nbsp;As&nbsp;HttpContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Session(key)&nbsp;=&nbsp;treeView.Nodes&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span><span class="cs__string">'&nbsp;Restore&nbsp;TreeView'</span>s&nbsp;state&nbsp;from&nbsp;session&nbsp;variable,&nbsp;and&nbsp;invoke&nbsp;SaveTreeView&nbsp;method.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="cs__string">&quot;treeView&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="cs__string">&quot;key&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="cs__string">&quot;context&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Sub&nbsp;RestoreTreeView(ByVal&nbsp;treeView&nbsp;As&nbsp;TreeView,&nbsp;ByVal&nbsp;key&nbsp;As&nbsp;String,&nbsp;ByVal&nbsp;context&nbsp;As&nbsp;HttpContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;New&nbsp;TreeViewState(key).IsSaved&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;treeView.Nodes.Clear()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;nodes&nbsp;As&nbsp;TreeNodeCollection&nbsp;=&nbsp;DirectCast(context.Session(key),&nbsp;TreeNodeCollection)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;index&nbsp;As&nbsp;Integer&nbsp;=&nbsp;nodes.Count&nbsp;-&nbsp;<span class="cs__number">1</span>&nbsp;To&nbsp;<span class="cs__number">0</span>&nbsp;Step&nbsp;-<span class="cs__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;treeView.Nodes.AddAt(<span class="cs__number">0</span>,&nbsp;nodes(index))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.SaveTreeView(treeView,&nbsp;key,&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 5. Add SaveTreeViewState button's OnClick event and TreeView data bind event code of TreeViewState.aspx.vb file below:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    		''' &lt;summary&gt;
        ''' The method use to bind TreeView with node's last save state across postback.
        ''' &lt;/summary&gt;
        Private Sub TreeViewBind()
            If state.IsSaved Then
                state.RestoreTreeView(tvwNodes, &quot;TreeViewState&quot;, HttpContext.Current)
            End If
        End Sub

        ''' &lt;summary&gt;
        ''' The button click event use to save TreeView's state 
        ''' &lt;/summary&gt;
        ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        Protected Sub btnSaveTreeViewState_Click(ByVal sender As Object, ByVal e As EventArgs)
            state.SaveTreeView(tvwNodes, &quot;TreeViewState&quot;, HttpContext.Current)
        End Sub</pre>
<div class="preview">
<pre class="csharp"><span class="cs__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span><span class="cs__string">'&nbsp;The&nbsp;method&nbsp;use&nbsp;to&nbsp;bind&nbsp;TreeView&nbsp;with&nbsp;node'</span>s&nbsp;last&nbsp;save&nbsp;state&nbsp;across&nbsp;postback.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;TreeViewBind()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;state.IsSaved&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;state.RestoreTreeView(tvwNodes,&nbsp;<span class="cs__string">&quot;TreeViewState&quot;</span>,&nbsp;HttpContext.Current)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span><span class="cs__string">'&nbsp;The&nbsp;button&nbsp;click&nbsp;event&nbsp;use&nbsp;to&nbsp;save&nbsp;TreeView'</span>s&nbsp;state&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="cs__string">&quot;sender&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="cs__string">&quot;e&quot;</span>&gt;&lt;/param&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Protected&nbsp;Sub&nbsp;btnSaveTreeViewState_Click(ByVal&nbsp;sender&nbsp;As&nbsp;Object,&nbsp;ByVal&nbsp;e&nbsp;As&nbsp;EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;state.SaveTreeView(tvwNodes,&nbsp;<span class="cs__string">&quot;TreeViewState&quot;</span>,&nbsp;HttpContext.Current)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 6. Build the application and you can debug it.</div>
</div>
<p>&nbsp;</p>
<h2>References:</h2>
<p>MSDN: TreeView Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treeview.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treeview.aspx</a></p>
<p>MSDN: TreeNodeCollection Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treenodecollection.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treenodecollection.aspx</a></p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
