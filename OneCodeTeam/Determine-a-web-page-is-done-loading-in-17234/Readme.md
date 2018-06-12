# Determine a web page is done loading in WebBrowser (CSWebBrowserLoadComplete)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Internet Explorer
## Topics
* WebBrowser
## IsPublished
* True
## ModifiedDate
* 2012-06-10 10:22:02
## Description
================================================================================<br>
&nbsp; &nbsp; &nbsp; Windows APPLICATION: CSWebBrowserLoadComplete Overview &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
===============================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
<br>
The sample demonstrates how to determine when a page is done loading in webBrowser<br>
control.<br>
<br>
In the case of a page with no frames, the DocumentComplete event is fired once after<br>
everything is done. In case of multiple frames, the DocumentComplete event gets fired<br>
multiple times.<br>
<br>
So, to check if a page is done loading, you need to check if sender of the event<br>
is the same as the WebBrowser control.<br>
<br>
NOTE:<br>
1. Within one frame of the frameset, if the user clicks on a link that opens a new page
<br>
&nbsp; in the frame itself and keeps the rest of the frameset intact, the LoadCompleted<br>
&nbsp; event of the WebBrowser event will not be fired, you have to check the DocumentComplete<br>
&nbsp; event of the specified frame. <br>
<br>
2. If you visit some pages, such as http://www.microsoft.com, you may find that the
<br>
&nbsp; LoadCompleted event is not the latest event. This is because that the page may
<br>
&nbsp; load other links by itself after the page is done loading.<br>
<br>
<br>
////////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
Step1. Run CSWebBrowserLoadComplete.exe.<br>
<br>
Step2. The default url in the Textbox is the path of &quot;\Resource\FramesPage.htm&quot;.<br>
&nbsp; &nbsp; &nbsp; Click the button &quot;Go&quot;. <br>
<br>
&nbsp; &nbsp; &nbsp; The FramesPage.htm contains 3 frames. After the page is loaded, you will get<br>
&nbsp; &nbsp; &nbsp; following message in the buttom of the form.<br>
<br>
&nbsp; &nbsp; &nbsp; DocumentCompleted:4 LoadCompleted:1.<br>
<br>
&nbsp; &nbsp; &nbsp; This meaages means that the DocumentCompleted evet was fired 4 times, and the<br>
&nbsp; &nbsp; &nbsp; LoadCompleted event was fired once. <br>
<br>
&nbsp; &nbsp; &nbsp; And you can also get the detailed activity records in the list box.<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Code Logic:<br>
<br>
1. The interface DWebBrowserEvents2 designates an event sink interface that an application<br>
&nbsp; must implement to receive event notifications from a WebBrowser control or from the
<br>
&nbsp; Windows Internet Explorer application. The event notifications include DocumentCompleted<br>
&nbsp; and BeforeNavigate2 events that will be used in this application.<br>
<br>
&nbsp; &nbsp; &nbsp; [ComImport, TypeLibType(TypeLibTypeFlags.FHidden), <br>
&nbsp; &nbsp; &nbsp; InterfaceType(ComInterfaceType.InterfaceIsIDispatch),<br>
&nbsp; &nbsp; &nbsp; Guid(&quot;34A715A0-6587-11D0-924A-0020AFC7AC4D&quot;)]<br>
&nbsp; &nbsp; &nbsp; public interface DWebBrowserEvents2<br>
&nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; /// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; /// Fires when a document is completely loaded and initialized.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; /// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [DispId(259)]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; void DocumentComplete(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [In] ref object URL);<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [DispId(250)]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; void BeforeNavigate2(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [In] ref object URL, <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [In] ref object flags, <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [In] ref object targetFrameName,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [In] ref object postData, <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [In] ref object headers,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [In, Out] ref bool cancel);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; }<br>
<br>
2. The class DWebBrowserEvents2Helper implements the DWebBrowserEvents2 interface to check<br>
&nbsp; whether the page is done loading.<br>
&nbsp; <br>
&nbsp; If the WebBrowser control is hosting a normal html page without frame, the
<br>
&nbsp; DocumentComplete event is fired once after everything is done.<br>
&nbsp; <br>
&nbsp; If the WebBrowser control is hosting a frameset. DocumentComplete gets fired multiple<br>
&nbsp; times. The DocumentComplete event has a pDisp parameter, which is the IDispatch of the
<br>
&nbsp; frame (shdocvw) for which DocumentComplete is fired. <br>
&nbsp; <br>
&nbsp; Then we could check if the pDisp parameter of the DocumentComplete is the same<br>
&nbsp; as the ActiveXInstance of the WebBrowser.<br>
<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private class DWebBrowserEvents2Helper : StandardOleMarshalObject, DWebBrowserEvents2<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;private WebBrowserEx parent;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public DWebBrowserEvents2Helper(WebBrowserEx parent)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.parent = parent;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public void DocumentComplete(object pDisp, ref object URL)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string url = URL as string;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (string.IsNullOrEmpty(url)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;|| url.Equals(&quot;about:blank&quot;, StringComparison.OrdinalIgnoreCase))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (pDisp != null && pDisp.Equals(parent.ActiveXInstance))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var e = new WebBrowserDocumentCompletedEventArgs(new Uri(url));
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;parent.OnLoadCompleted(e);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;public void BeforeNavigate2(object pDisp, ref object URL, ref object flags,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ref object targetFrameName, ref object postData, ref object headers,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ref bool cancel)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string url = URL as string;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (string.IsNullOrEmpty(url)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;|| url.Equals(&quot;about:blank&quot;, StringComparison.OrdinalIgnoreCase))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (pDisp != null && pDisp.Equals(parent.ActiveXInstance))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;WebBrowserNavigatingEventArgs e = new WebBrowserNavigatingEventArgs(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new Uri(url), targetFrameName as string);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;parent.OnStartNavigating(e);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
3. The WebBrowserEx class inherits WebBrowser class and supplies StartNavigating and<br>
&nbsp; LoadCompleted event.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; public partial class WebBrowserEx : WebBrowser<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;AxHost.ConnectionPointCookie cookie;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;DWebBrowserEvents2Helper helper;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public event EventHandler&lt;WebBrowserNavigatingEventArgs&gt; StartNavigating;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public event EventHandler&lt;WebBrowserDocumentCompletedEventArgs&gt; LoadCompleted;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Associates the underlying ActiveX control with a client that can
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// handle control events including NavigateError event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected override void CreateSink()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;base.CreateSink();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;helper = new DWebBrowserEvents2Helper(this);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;cookie = new AxHost.ConnectionPointCookie(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.ActiveXInstance, helper, typeof(DWebBrowserEvents2)); &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Releases the event-handling client attached in the CreateSink method<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// from the underlying ActiveX control<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected override void DetachSink()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (cookie != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;cookie.Disconnect();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;cookie = null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;base.DetachSink();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Raise the LoadCompleted event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected virtual void OnLoadCompleted(WebBrowserDocumentCompletedEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (LoadCompleted != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.LoadCompleted(this, e);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Raise the StartNavigating event.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;protected virtual void OnStartNavigating(WebBrowserNavigatingEventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (StartNavigating != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.StartNavigating(this, e);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp;<br>
4. The MainFrom is the UI of this application. If the WebBroeser was navigated to an<br>
&nbsp; URL, it will display the count of how many times DocumentCompleted event were fired<br>
&nbsp; and how many times LoadCompleted event were fired, also includes the detailed
<br>
&nbsp; activity records.<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
How To Determine When a Page Is Done Loading in WebBrowser Control<br>
http://support.microsoft.com/kb/q180366/<br>
<br>
DWebBrowserEvents2 Interface<br>
http://msdn.microsoft.com/en-us/library/aa768283(VS.85).aspx<br>
<br>
WebBrowser.CreateSink Method <br>
http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.createsink.aspx<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
