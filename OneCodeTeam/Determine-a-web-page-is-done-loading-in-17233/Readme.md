# Determine a web page is done loading in WebBrowser (VBWebBrowserLoadComplete)
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
* 2012-06-10 10:21:45
## Description
================================================================================<br>
&nbsp; &nbsp; &nbsp; Windows APPLICATION: VBWebBrowserLoadComplete Overview &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
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
Step1. Run VBWebBrowserLoadComplete.exe.<br>
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
&nbsp; &nbsp; &nbsp; &lt;ComImport(),<br>
&nbsp; &nbsp; &nbsp; TypeLibType(TypeLibTypeFlags.FHidden),<br>
&nbsp; &nbsp; &nbsp; InterfaceType(ComInterfaceType.InterfaceIsIDispatch),<br>
&nbsp; &nbsp; &nbsp; Guid(&quot;34A715A0-6587-11D0-924A-0020AFC7AC4D&quot;)&gt;<br>
&nbsp; &nbsp; &nbsp; Public Interface DWebBrowserEvents2<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' Fires when a document is completely loaded and initialized.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;DispId(259)&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Sub DocumentComplete(&lt;[In](), MarshalAs(UnmanagedType.IDispatch)&gt; ByVal pDisp As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;[In]()&gt; ByRef URL As Object)<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;DispId(250)&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Sub BeforeNavigate2(&lt;[In](), MarshalAs(UnmanagedType.IDispatch)&gt; ByVal pDisp As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;[In]()&gt; ByRef URL As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;[In]()&gt; ByRef flags As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;[In]()&gt; ByRef targetFrameName As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;[In]()&gt; ByRef postData As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;[In]()&gt; ByRef headers As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;[In](), Out()&gt; ByRef cancel As Boolean)<br>
&nbsp; &nbsp; &nbsp; End Interface<br>
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
&nbsp; &nbsp; &nbsp; Private Class DWebBrowserEvents2Helper<br>
&nbsp; &nbsp; &nbsp; &nbsp;Inherits StandardOleMarshalObject<br>
&nbsp; &nbsp; &nbsp; &nbsp;Implements DWebBrowserEvents2<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Private parent As WebBrowserEx<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub New(ByVal parent As WebBrowserEx)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Me.parent = parent<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Fires when a document is completely loaded and initialized.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' If the frame is the top-level frame / window element, then the page is<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' done loading.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' <br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Then reset the glpDisp to null after the WebBrowser is done loading.<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub DocumentComplete(ByVal pDisp As Object, ByRef URL As Object) _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Implements DWebBrowserEvents2.DocumentComplete<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim _url As String = TryCast(URL, String)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If String.IsNullOrEmpty(_url) OrElse _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_url.Equals(&quot;about:blank&quot;, StringComparison.OrdinalIgnoreCase) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If pDisp IsNot Nothing AndAlso pDisp.Equals(parent.ActiveXInstance) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim e = New WebBrowserDocumentCompletedEventArgs(New Uri(_url))<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;parent.OnLoadCompleted(e)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' Fires before navigation occurs in the given object
<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' (on either a window element or a frameset element).<br>
&nbsp; &nbsp; &nbsp; &nbsp;''' <br>
&nbsp; &nbsp; &nbsp; &nbsp;''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Public Sub BeforeNavigate2(ByVal pDisp As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByRef URL As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByRef flags As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByRef targetFrameName As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByRef postData As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByRef headers As Object,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ByRef cancel As Boolean) _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Implements DWebBrowserEvents2.BeforeNavigate2<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim _url As String = TryCast(URL, String)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If String.IsNullOrEmpty(_url) OrElse _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_url.Equals(&quot;about:blank&quot;, StringComparison.OrdinalIgnoreCase) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Return<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;If pDisp IsNot Nothing AndAlso pDisp.Equals(parent.ActiveXInstance) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim e As New WebBrowserNavigatingEventArgs(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;New Uri(_url), TryCast(targetFrameName, String))<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;parent.OnStartNavigating(e)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;End Sub<br>
<br>
<br>
&nbsp; &nbsp;End Class<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
3. The WebBrowserEx class inherits WebBrowser class and supplies StartNavigating and<br>
&nbsp; LoadCompleted event.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;PermissionSetAttribute(SecurityAction.LinkDemand, Name:=&quot;FullTrust&quot;),<br>
&nbsp; &nbsp; &nbsp; &nbsp; PermissionSetAttribute(SecurityAction.InheritanceDemand, Name:=&quot;FullTrust&quot;)&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; Partial Public Class WebBrowserEx<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Inherits WebBrowser<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Private cookie As AxHost.ConnectionPointCookie<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Private helper As DWebBrowserEvents2Helper<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Public Event LoadCompleted As EventHandler(Of WebBrowserDocumentCompletedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Public Event StartNavigating As EventHandler(Of WebBrowserNavigatingEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' Associates the underlying ActiveX control with a client that can
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' handle control events including NavigateError event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Protected Overrides Sub CreateSink()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MyBase.CreateSink()<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; helper = New DWebBrowserEvents2Helper(Me)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; cookie = New AxHost.ConnectionPointCookie(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.ActiveXInstance, helper, GetType(DWebBrowserEvents2))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' Releases the event-handling client attached in the CreateSink method<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' from the underlying ActiveX control<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Protected Overrides Sub DetachSink()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If cookie IsNot Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; cookie.Disconnect()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; cookie = Nothing<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; MyBase.DetachSink()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' Raise the LoadCompleted event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Protected Overridable Sub OnLoadCompleted(ByVal e As WebBrowserDocumentCompletedEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; RaiseEvent LoadCompleted(Me, e)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' Raise the StartNavigating event.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Protected Overridable Sub OnStartNavigating(ByVal e As WebBrowserNavigatingEventArgs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; RaiseEvent StartNavigating(Me, e)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Sub<br>
&nbsp; &nbsp; &nbsp; &nbsp; End Class<br>
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
