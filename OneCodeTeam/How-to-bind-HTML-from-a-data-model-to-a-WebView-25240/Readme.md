# How to bind HTML from a data model to a WebView.
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows Desktop App Development
## Topics
* WebView
## IsPublished
* False
## ModifiedDate
* 2013-10-09 01:23:20
## Description

<h1><span lang="EN" style="">How to bind HTML from a data model to a WebView</span><span style=""> (CppWindowsStoreAppHtmlBinding)
</span></h1>
<h2><span style="">Introduction </span></h2>
<p class="MsoNormal">​It's been said that if you aren't data binding you aren't really using Xaml, and a frequent topic on the forums is how to bind HTML from a data model to a WebView.</p>
<p class="MsoNormal">The problem: we bind data to properties, but the WebView doesn't have a property to bind to. An app sets the WebView's HTML by calling the NavigateToString method.</p>
<p class="MsoNormal">The solution: create our own property to bind to.</p>
<p class="MsoNormal">NOTE: This code sample is based on following blog: </p>
<p class="MsoNormal"><span lang="EN" style=""><a href="http://blogs.msdn.com/b/wsdevsol/archive/2013/09/26/binding-html-to-a-webview-with-attached-properties.aspx">http://blogs.msdn.com/b/wsdevsol/archive/2013/09/26/binding-html-to-a-webview-with-attached-properties.aspx</a>
</span></p>
<h2><span style="">Running the Sample </span></h2>
<p class="MsoNormal"><span style="">Build the sample in Visual Studio 2012, and then run it. The app looks like this:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/97626/1/image.png" alt="" width="576" height="370" align="middle">
</span><span style=""></span></p>
<h2><span style="">Using the Code </span></h2>
<p class="MsoNormal"><span lang="EN" style="">Windows.UI.Xaml has the concept of attached properties which let us create a stand-alone property which can &quot;attach&quot; to any object, such as our WebView. We can create an attached property &quot;HTML&quot;
 that when changed calls NavigateToString. We can then bind it to HTML data in our data model. First create a new class to hold the attached property, then create the attached property inside it.
</span></p>
<p class="MsoNormal"><span lang="EN" style="">Visual Studio includes a snippet to help with this: type &quot;propa&quot;&lt;tab&gt;&lt;tab&gt; and the basic skeleton for an attached property will be inserted. Change the return type to &quot;string&quot; and
 the name to something appropriate. I named my property &quot;HTML&quot;. The snippet will take care of synchronizing your change to the whole property. Set the ownerType in the RegisterAttached call to the name of your class.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
public ref class MyExtensions sealed : WUX::DependencyObject 
{
public:
&nbsp;&nbsp;&nbsp; MyExtensions(void);
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;static property WUX::DependencyProperty^ HTMLProperty { 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WUX::DependencyProperty^ get() { return _HTMLProperty; }
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;static Platform::String^ MyExtensions::GetHTML(WUX::DependencyObject^ obj) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return (Platform::String^)obj-&gt;GetValue(HTMLProperty);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; static void MyExtensions::SetHTML(WUX::DependencyObject^ obj, Platform::String^ HTML) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;obj-&gt;SetValue(HTMLProperty, HTML);
&nbsp;&nbsp;&nbsp; }


private:
&nbsp;&nbsp;&nbsp; ~MyExtensions(void);


&nbsp;&nbsp;&nbsp; static WUX::DependencyProperty^ _HTMLProperty;
&nbsp;&nbsp;&nbsp; static void OnHTMLChanged(WUX::DependencyObject^ d, WUX::DependencyPropertyChangedEventArgs^ e);




};

</pre>
<pre id="codePreview" class="cplusplus">
public ref class MyExtensions sealed : WUX::DependencyObject 
{
public:
&nbsp;&nbsp;&nbsp; MyExtensions(void);
&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;static property WUX::DependencyProperty^ HTMLProperty { 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WUX::DependencyProperty^ get() { return _HTMLProperty; }
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;static Platform::String^ MyExtensions::GetHTML(WUX::DependencyObject^ obj) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return (Platform::String^)obj-&gt;GetValue(HTMLProperty);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; static void MyExtensions::SetHTML(WUX::DependencyObject^ obj, Platform::String^ HTML) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;obj-&gt;SetValue(HTMLProperty, HTML);
&nbsp;&nbsp;&nbsp; }


private:
&nbsp;&nbsp;&nbsp; ~MyExtensions(void);


&nbsp;&nbsp;&nbsp; static WUX::DependencyProperty^ _HTMLProperty;
&nbsp;&nbsp;&nbsp; static void OnHTMLChanged(WUX::DependencyObject^ d, WUX::DependencyPropertyChangedEventArgs^ e);




};

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span lang="EN" style="">At this point we have a property which can be set to a string, but it isn't connected to the WebView's document. To do that we need to add a change handler to the property's PropertyMetaData:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
DependencyProperty^ MyExtensions::_HTMLProperty = DependencyProperty::RegisterAttached(
&nbsp;&nbsp;&nbsp; &quot;HTML&quot;,
&nbsp;&nbsp;&nbsp; TypeName(String::typeid), 
&nbsp;&nbsp;&nbsp;&nbsp;TypeName(MyExtensions::typeid), 
&nbsp;&nbsp;&nbsp;&nbsp;ref new PropertyMetadata(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; nullptr, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ref new PropertyChangedCallback(OnHTMLChanged)
&nbsp;&nbsp;&nbsp; )
);
 
void MyExtensions::OnHTMLChanged(DependencyObject^ d, DependencyPropertyChangedEventArgs^ e)
{
&nbsp;&nbsp;&nbsp; WebView^ wv = (WebView^)d;
&nbsp;&nbsp;&nbsp; String^ value = (String^)e-&gt;NewValue;


&nbsp;&nbsp;&nbsp; wv-&gt;NavigateToString(value);
}

</pre>
<pre id="codePreview" class="cplusplus">
DependencyProperty^ MyExtensions::_HTMLProperty = DependencyProperty::RegisterAttached(
&nbsp;&nbsp;&nbsp; &quot;HTML&quot;,
&nbsp;&nbsp;&nbsp; TypeName(String::typeid), 
&nbsp;&nbsp;&nbsp;&nbsp;TypeName(MyExtensions::typeid), 
&nbsp;&nbsp;&nbsp;&nbsp;ref new PropertyMetadata(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; nullptr, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ref new PropertyChangedCallback(OnHTMLChanged)
&nbsp;&nbsp;&nbsp; )
);
 
void MyExtensions::OnHTMLChanged(DependencyObject^ d, DependencyPropertyChangedEventArgs^ e)
{
&nbsp;&nbsp;&nbsp; WebView^ wv = (WebView^)d;
&nbsp;&nbsp;&nbsp; String^ value = (String^)e-&gt;NewValue;


&nbsp;&nbsp;&nbsp; wv-&gt;NavigateToString(value);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN" style="">Now all we need to do is to reference the attached property in our Xaml to bind the WebView to HTML from an &quot;HTMLText&quot; property in our data model:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;WebView local:MyExtensions.HTML=&quot;{Binding HTMLText}&quot;&gt;&lt;/WebView&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;WebView local:MyExtensions.HTML=&quot;{Binding HTMLText}&quot;&gt;&lt;/WebView&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN" style="">The same technique can be used to enable binding RTF into a RichEditBox and for other controls which ones sets by method rather than properties.
</span></p>
<h2><span style="">More Information </span></h2>
<p class="MsoNormal"><span lang="EN" style="">For more on Dependency Properties and Attached Properties see:<br>
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh700353.aspx" title="Dependency properties overview">Dependency properties overview</a><br>
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh758282.aspx" title="Attached properties overview">Attached properties overview<br>
</a><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh965327.aspx" title="Custom attached properties">Custom attached properties</a></span><span style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
