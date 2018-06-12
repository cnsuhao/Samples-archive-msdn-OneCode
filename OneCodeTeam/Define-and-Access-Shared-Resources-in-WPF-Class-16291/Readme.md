# Define and Access Shared Resources in WPF Class Library (CSWPFSharedResources)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* WPF
## Topics
* Shared Resources
* Markup Extension
## IsPublished
* True
## ModifiedDate
* 2012-04-07 01:59:02
## Description

<h1>Define and Access Shared Resources in WPF Class Library (CSWPFSharedResources)</h1>
<h2>Introduction</h2>
<p>This sample demonstrates the approach of</p>
<ol>
<li>Defining and using shared resources in WPF class library. </li><li>Accessing shared resources using markup extension. </li></ol>
<p>Normally in a WPF class library the resources used in the controls will not be reflected at the design time. This approach of combining the shared resources along with markup extension helps us to overcome this limitation.</p>
<h2>Running the Sample</h2>
<ol>
<li>Open the solution in Visual Studio. </li><li>Rebuild the solution. </li><li>Under the &ldquo;SharedResource_UsingMarkupExtension&rdquo; project open the Design view of &ldquo;CustomRect.xaml&rdquo;. The page looks empty. This page is using shared resource without MarkupExtension.
</li><li>Open design view of &ldquo;CustomRectangle.xaml&rdquo;. We can see the image is displayed from the resource file&rdquo; MyResources.xaml&rdquo;.
</li><li>The design of user control &ldquo;CustomRect.xaml&rdquo; will be viewable only when used in a WPF application. We overcome this limitation by using markup extension.
</li><li>To test the working of this sample, hit &ldquo;Ctrl&#43;F5&rdquo;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .
</li><li>A new window will open. The right side with &ldquo;Grey&rdquo; background shows the usercontrol using SharedResource with MarkupExtension and the left side usercontrol use SharedResource without MarkupExtension.
</li></ol>
<p><img src="/site/view/file/55727/1/image001.png" alt="" width="538" height="361"></p>
<h2>Using the Code</h2>
<p>This sample solves the problem having a common place to have application level resources in WPF class library by using Shared resources. Also, we can see the design of the user control in the WPF class library without being implemented in a WPF application
 by using markup extension.</p>
<p>You can add more property to the SharedResourceExtension and include more logic in the ProvideValue method to modify the code as per the requirement.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Adding new parameter.
private object defaultvalue;
 
public object Default
{
    get
    {
        return defaultvalue;
    }
    set
    {
                defaultvalue = value;
    }
}
 
 // Constructor accepting two parameter.
public SharedResourceExtension(object key, object defaultvalue)
{
    Key = key;
    this.Default = defaultvalue;
}
 
public override object ProvideValue(IServiceProvider serviceProvider)
{
    object localValue = SharedResourceDictionaryManager.SharedResourceDictionary[Key];
 
    if (localValue == null)
    {
        return SharedResourceDictionaryManager.SharedResourceDictionary[Key];
    }
 
    return localValue;
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Adding&nbsp;new&nbsp;parameter.</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;defaultvalue;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;Default&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;defaultvalue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;defaultvalue&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;&nbsp;
&nbsp;<span class="cs__com">//&nbsp;Constructor&nbsp;accepting&nbsp;two&nbsp;parameter.</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;SharedResourceExtension(<span class="cs__keyword">object</span>&nbsp;key,&nbsp;<span class="cs__keyword">object</span>&nbsp;defaultvalue)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Key&nbsp;=&nbsp;key;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Default&nbsp;=&nbsp;defaultvalue;&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;ProvideValue(IServiceProvider&nbsp;serviceProvider)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;localValue&nbsp;=&nbsp;SharedResourceDictionaryManager.SharedResourceDictionary[Key];&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(localValue&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;SharedResourceDictionaryManager.SharedResourceDictionary[Key];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;localValue;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h2>More Information</h2>
<p><a href="http://msdn.microsoft.com/en-us/library/ee855815.aspx">http://msdn.microsoft.com/en-us/library/ee855815.aspx</a>&nbsp;&nbsp;</p>
<p><a href="http://msdn.microsoft.com/en-us/library/ms747254.aspx">http://msdn.microsoft.com/en-us/library/ms747254.aspx</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/ms747254.aspx">http://msdn.microsoft.com/en-us/library/ms747254.aspx</a></p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
