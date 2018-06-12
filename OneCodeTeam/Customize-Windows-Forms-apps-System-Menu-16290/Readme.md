# Customize Windows Forms app's System Menu (CSCustomizeSysMenu)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows Forms
## Topics
* System Menu
## IsPublished
* True
## ModifiedDate
* 2012-04-07 01:38:51
## Description

<h1>This application demonstrates how to modify a winform application&rsquo;s system menu. (CSCustomizeSysMenu)</h1>
<h2>Introduction</h2>
<div>This application demonstrates how to modify a winform application&rsquo;s system menu.</div>
<div>&nbsp;</div>
<h2>Running the Sample</h2>
<div>This is how the application looks like&hellip;</div>
<div><img src="/site/view/file/55723/1/image001.png" alt=""></div>
<div></div>
<h2>Using the Code</h2>
<div>In this application I&rsquo;ve demonstrated how to do the following actions&hellip;</div>
<ol>
<li>Retrieve system menu: refer btnAddToFormSystemMenu_Click </li><li>Modify system menu: refer btnAddToFormSystemMenu_Click </li><li>Retrieve text item of a system menu item: refer handleSysCustomCommand </li></ol>
<div>How to handle events from system menu items: refer WndProc</div>
<div>The gist of the application lies in the following functions&hellip;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void btnAddToFormSystemMenu_Click(object sender, EventArgs e)
{
    IntPtr hMenu = GetSystemMenu(this.Handle, false);
    if (hMenu != IntPtr.Zero)
    {
        Int32 Count             = GetMenuItemCount(hMenu);
        MENUITEMINFO mnuInfo    = new MENUITEMINFO();
        mnuInfo.cbSize          = MENUITEMINFO.sizeOf;
        mnuInfo.fMask           = MIIM_STRING | MIIM_ID;
        mnuInfo.fState          = MFS_ENABLED;
        mnuInfo.fType           = MFT_STRING;
        mnuInfo.wID             = BaseCommandId &#43; &#43;&#43;CurrentIndex;
        mnuInfo.dwTypeData      = txtMenuCaption.Text;
        InsertMenuItem(hMenu, (UInt32)Count, true, ref mnuInfo);
        DrawMenuBar(hMenu);
    }
}
</pre>
<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;btnAddToFormSystemMenu_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;hMenu&nbsp;=&nbsp;GetSystemMenu(<span class="js__operator">this</span>.Handle,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(hMenu&nbsp;!=&nbsp;IntPtr.Zero)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Int32&nbsp;Count&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;GetMenuItemCount(hMenu);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MENUITEMINFO&nbsp;mnuInfo&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;MENUITEMINFO();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mnuInfo.cbSize&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;MENUITEMINFO.sizeOf;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mnuInfo.fMask&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;MIIM_STRING&nbsp;|&nbsp;MIIM_ID;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mnuInfo.fState&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;MFS_ENABLED;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mnuInfo.fType&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;MFT_STRING;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mnuInfo.wID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;BaseCommandId&nbsp;&#43;&nbsp;&#43;&#43;CurrentIndex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mnuInfo.dwTypeData&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;txtMenuCaption.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InsertMenuItem(hMenu,&nbsp;(UInt32)Count,&nbsp;true,&nbsp;ref&nbsp;mnuInfo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawMenuBar(hMenu);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void handleSysCustomCommand(UInt32 CmdId)
{
    IntPtr hMenu = GetSystemMenu(this.Handle, false);
    MENUITEMINFO mnuInfo = new MENUITEMINFO();
    mnuInfo.cbSize = MENUITEMINFO.sizeOf;
    mnuInfo.fType = MFT_STRING;
    mnuInfo.fMask = MIIM_STRING;
 
    // Get size of buffer first, this call will fill out mnuInfo.cch val which is the buffere size
    if (!GetMenuItemInfo(hMenu, CmdId, false, ref mnuInfo))
    {
        ShowLastError();
    }
    else
    {
        // Pad up a bit
        mnuInfo.cch &#43;= 4; 
        mnuInfo.dwTypeData = new String(' ', (Int32)mnuInfo.cch);
        if(!GetMenuItemInfo(hMenu, CmdId, false, ref mnuInfo)) // This time get menu item text
        {
            ShowLastError();
        }
        else
        {
            String Text = String.Format(&quot;You clicked on: {0}&quot;, mnuInfo.dwTypeData);
            MessageBox.Show(Text, &quot;Menu text&quot;, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
 
// A demo on how to handle the event from the new system menu items...
protected override void WndProc(ref Message Msg)
{
    if (Msg.Msg == WM_SYSCOMMAND)
    {
        if ((UInt32)Msg.WParam.ToInt32() &gt; BaseCommandId)
        {
            handleSysCustomCommand((UInt32)Msg.WParam.ToInt32());
        }
    }
    base.WndProc(ref Msg);
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;handleSysCustomCommand(UInt32&nbsp;CmdId)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;hMenu&nbsp;=&nbsp;GetSystemMenu(<span class="cs__keyword">this</span>.Handle,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MENUITEMINFO&nbsp;mnuInfo&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MENUITEMINFO();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mnuInfo.cbSize&nbsp;=&nbsp;MENUITEMINFO.sizeOf;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mnuInfo.fType&nbsp;=&nbsp;MFT_STRING;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mnuInfo.fMask&nbsp;=&nbsp;MIIM_STRING;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;size&nbsp;of&nbsp;buffer&nbsp;first,&nbsp;this&nbsp;call&nbsp;will&nbsp;fill&nbsp;out&nbsp;mnuInfo.cch&nbsp;val&nbsp;which&nbsp;is&nbsp;the&nbsp;buffere&nbsp;size</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!GetMenuItemInfo(hMenu,&nbsp;CmdId,&nbsp;<span class="cs__keyword">false</span>,&nbsp;<span class="cs__keyword">ref</span>&nbsp;mnuInfo))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowLastError();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Pad&nbsp;up&nbsp;a&nbsp;bit</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mnuInfo.cch&nbsp;&#43;=&nbsp;<span class="cs__number">4</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mnuInfo.dwTypeData&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;String(<span class="cs__string">'&nbsp;'</span>,&nbsp;(Int32)mnuInfo.cch);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(!GetMenuItemInfo(hMenu,&nbsp;CmdId,&nbsp;<span class="cs__keyword">false</span>,&nbsp;<span class="cs__keyword">ref</span>&nbsp;mnuInfo))&nbsp;<span class="cs__com">//&nbsp;This&nbsp;time&nbsp;get&nbsp;menu&nbsp;item&nbsp;text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowLastError();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String&nbsp;Text&nbsp;=&nbsp;String.Format(<span class="cs__string">&quot;You&nbsp;clicked&nbsp;on:&nbsp;{0}&quot;</span>,&nbsp;mnuInfo.dwTypeData);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(Text,&nbsp;<span class="cs__string">&quot;Menu&nbsp;text&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.Information);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cs__com">//&nbsp;A&nbsp;demo&nbsp;on&nbsp;how&nbsp;to&nbsp;handle&nbsp;the&nbsp;event&nbsp;from&nbsp;the&nbsp;new&nbsp;system&nbsp;menu&nbsp;items...</span>&nbsp;
<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;WndProc(<span class="cs__keyword">ref</span>&nbsp;Message&nbsp;Msg)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Msg.Msg&nbsp;==&nbsp;WM_SYSCOMMAND)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;((UInt32)Msg.WParam.ToInt32()&nbsp;&gt;&nbsp;BaseCommandId)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;handleSysCustomCommand((UInt32)Msg.WParam.ToInt32());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.WndProc(<span class="cs__keyword">ref</span>&nbsp;Msg);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<div>GetSystemMenu function</div>
<div><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms647985(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms647985(v=vs.85).aspx</a></div>
<div></div>
<div>GetMenuItemInfo function</div>
<div><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms647980(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms647980(v=vs.85).aspx</a></div>
<div>&nbsp;</div>
<div>GetMenuItemCount</div>
<div><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms647978(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms647978(v=vs.85).aspx</a></div>
<div></div>
<div>DrawMenuBar function</div>
<div><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms647633(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms647633(v=vs.85).aspx</a></div>
<div>
<p>GetMenuItemID function&nbsp;<br>
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms647979(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms647979(v=vs.85).aspx</a></p>
<p>GetMenuInfo function&nbsp;<br>
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms647977(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms647977(v=vs.85).aspx</a><br>
&nbsp;<br>
&nbsp;</p>
<p>&nbsp;</p>
</div>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
