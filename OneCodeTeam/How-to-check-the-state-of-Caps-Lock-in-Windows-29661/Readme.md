# How to check the state of Caps Lock in Windows Store apps using JavaScript
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Windows Store app
* Windows Store app Development
* Windows 8.1
* Windows 8.1 HTML/WinJS
## Topics
* code snippets
* Capslock
## IsPublished
* True
## ModifiedDate
* 2014-07-02 02:21:39
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1>How to check the state of Caps Lock in Windows Store apps using JavaScript</h1>
<h2>Introduction</h2>
<p>This code snippet demonstrates how to check if the Caps Lock is off or not. The
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.core.corevirtualkeystates(v=win.10).aspx">
CoreVirtualKeyStates</a> offers us 3 states. We can create a C# Windows Runtime Component, and use CoreVirtualKeyStates Check Caps Lock State instead of using Key Code.</p>
<h2>Using the Code</h2>
<p>We need first create a Simple Component:</p>
<ol>
<li>Create the component project: In&nbsp;<strong>Solution Explorer</strong>, open the shortcut menu for the Sample App solution and choose&nbsp;<strong>Add</strong>, and then choose&nbsp;<strong>New Project</strong>&nbsp;to add a new C# or Visual Basic project
 to the solution. In the&nbsp;<strong>Installed Templates</strong>&nbsp;section of the&nbsp;<strong>Add New Project</strong>&nbsp;dialog box, choose&nbsp;Visual Basic&nbsp;or&nbsp;Visual C#, and then choose&nbsp;<strong>Windows Store</strong>. Choose the&nbsp;Windows
 Runtime Component&nbsp;template and enter&nbsp;<strong>SimpleComponent</strong> for the project name.
</li><li>Change the name of the class to&nbsp;<strong>CoreHelper</strong>. Notice that by default, the class is marked
<strong>public sealed&nbsp;(Public NotInheritable&nbsp;</strong>in Visual Basic). All the Windows Runtime classes you expose from your component must be sealed.
</li></ol>
<p>&nbsp;</p>
<p>Now, Use the code below to check Caps Lock State.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public sealed class CoreHelper 
{ 
    public static bool isCapLock() 
    { 
        CoreVirtualKeyStates state = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.CapitalLock); 
        if (state == (CoreVirtualKeyStates.Locked)) 
        { 
           return true; 
        } 
        return false; 
    } 
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CoreHelper&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;isCapLock()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CoreVirtualKeyStates&nbsp;state&nbsp;=&nbsp;CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.CapitalLock);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(state&nbsp;==&nbsp;(CoreVirtualKeyStates.Locked))&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Add HTML controls to the JavaScript project:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;input type=&quot;text&quot; id=&quot;tbContent&quot;  /&gt; 
&lt;label id=&quot;lbState&quot;&gt;&lt;/label&gt;
</pre>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;input</span><span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span><span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;tbContent&quot;</span><span class="html__tag_start">/&gt;</span><span class="html__tag_start">&lt;label</span><span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;lbState&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/label&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Add Code Below to default.js app.onactivated</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">var nativeObject = new SimpleComponent.CoreHelper();
        tbContent.onkeyup = checkCapsWarning;
        tbContent.onfocus = checkCapsWarning;
        tbContent.onblur = removeCapsWarning;
        function checkCapsWarning(event) {
            if (SimpleComponent.CoreHelper.isCapLock()) {
                lbState.innerHTML = &quot;Caps Locked&quot;;
            }
            else {
                removeCapsWarning();
            }
        }
        function removeCapsWarning() {
            lbState.innerHTML = &quot;&quot;;
        }
</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;nativeObject&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SimpleComponent.CoreHelper();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbContent.onkeyup&nbsp;=&nbsp;checkCapsWarning;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbContent.onfocus&nbsp;=&nbsp;checkCapsWarning;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbContent.onblur&nbsp;=&nbsp;removeCapsWarning;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;checkCapsWarning(event)&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(SimpleComponent.CoreHelper.isCapLock())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbState.innerHTML&nbsp;=&nbsp;<span class="js__string">&quot;Caps&nbsp;Locked&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;removeCapsWarning();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__operator">function</span>&nbsp;removeCapsWarning()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbState.innerHTML&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2>More Information</h2>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.core.corevirtualkeystates(v=win.10).aspx">CoreVirtualKeyStates enumeration</a></p>
<p>&nbsp;</p>
<div class="endscriptcode"></div>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
