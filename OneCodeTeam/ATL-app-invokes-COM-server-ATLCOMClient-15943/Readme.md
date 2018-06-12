# ATL app invokes COM server (ATLCOMClient)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* COM Client
## IsPublished
* True
## ModifiedDate
* 2012-03-04 08:16:55
## Description

<h1><span style="font-family:������">CONSOLE APPLICATION</span> (ATLCOMClient)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">ATLCOMClient shows you how to call COM server objects in ATL and implement an event sink using the ATL IDispEventImpl and IDispEventSimpleImpl classes for events in the COM server.</p>
<p class="MsoNormal">For the event sink, you can use IDispEventImpl when you have access to a type library. Use IDispEventSimpleImpl when you do not have access to the type library or when you want to be more efficient by not loading the type library.<span style="">&nbsp;
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53751/1/image.png" alt="" width="713" height="330" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. Create a C&#43;&#43; Win32 console project in Visual Studio 20<span style="">10</span>, and add common header files for ATL.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
#include &lt;atlbase.h&gt;
#include &lt;atlstr.h&gt;
#include &lt;atlcom.h&gt; // This header file requires to be added manually

</pre>
<pre id="codePreview" class="cplusplus">
#include &lt;atlbase.h&gt;
#include &lt;atlstr.h&gt;
#include &lt;atlcom.h&gt; // This header file requires to be added manually

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step2. Declare and initialize the current ATL module.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// You may derive a class from CAtlModule and use it if you want to 
// override something.
class CATLCOMClientModule : public CAtlExeModuleT&lt;CATLCOMClientModule&gt;
{ };
// Declare and initialize the current ATL module. 
CATLCOMClientModule _AtlModule;

</pre>
<pre id="codePreview" class="cplusplus">
// You may derive a class from CAtlModule and use it if you want to 
// override something.
class CATLCOMClientModule : public CAtlExeModuleT&lt;CATLCOMClientModule&gt;
{ };
// Declare and initialize the current ATL module. 
CATLCOMClientModule _AtlModule;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Import the type library of the COM server:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
#import &quot;ATLDllCOMServer.dll&quot; no_namespace named_guids
// [-or-]
//#import &quot;libid:9B23EFED-A0C1-46B6-A903-218206447F3E&quot; no_namespace named_guids

</pre>
<pre id="codePreview" class="cplusplus">
#import &quot;ATLDllCOMServer.dll&quot; no_namespace named_guids
// [-or-]
//#import &quot;libid:9B23EFED-A0C1-46B6-A903-218206447F3E&quot; no_namespace named_guids

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Add the file ATLSimpleSinkObject.h. The file contains three different sink objects all of which handle the FloatPropertyChanging event which is
</p>
<p class="MsoNormal">fired by the source COM object &quot;ATLDllCOMServer.SimpleObject&quot;.
</p>
<p class="MsoNormal">Step5. Create the ATLDllCOMServer.SimpleObject COM object using the #import directive and smart pointers.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
CComQIPtr&lt;ISimpleObject&gt; spSimpleObj;
hr = spSimpleObj.CoCreateInstance(OLESTR(
    &quot;ATLDllCOMServer.SimpleObject&quot;));

</pre>
<pre id="codePreview" class="cplusplus">
CComQIPtr&lt;ISimpleObject&gt; spSimpleObj;
hr = spSimpleObj.CoCreateInstance(OLESTR(
    &quot;ATLDllCOMServer.SimpleObject&quot;));

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step6. Use sink object 1 (CATLSimpleSinkObject1) to set up the sink for the events of the source COM object.</p>
<p class="MsoNormal"></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>6.1 Construct the sink object CATLSimpleSinkObject1 defined in ATLSimpleSinkObject.h</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>6.2 Make sure the COM object corresponding to pUnk implements IProvideClassInfo2 or IPersist*. Call this method to extract info about<span style="">
</span>source type library if you specified only 2 parameters to IDispEventImpl.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>6.3 Connect the sink and source, spSimpleObj is the source COM object</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>6.4 Invoke the source COM object</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>6.5 Disconnect from the source COM object if connected</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>6.6 Destroy the sink object</p>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step7. Use sink object 2 (CATLSimpleSinkObject2) to set up the sink for the events of the source COM object.</p>
<p class="MsoNormal"></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>7.1 Construct the sink object CATLSimpleSinkObject2 defined in </p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>ATLSimpleSinkObject.h</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>7.2 Connect the sink and source, m_spSrcObj is the source COM object</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>7.3 Invoke the source COM object</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>7.4 Disconnect from source if connected</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>7.5 Destroy the sink object</p>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step8. Use sink object 3 (CATLSimpleSinkObject3) to set up the sink for the events of the source COM object.</p>
<p class="MsoNormal"></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>8.1 Construct the sink object CATLSimpleSinkObject3 defined in </p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>ATLSimpleSinkObject.h</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>8.2 Connect the sink and source, m_spSrcObj is the source COM object</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>8.3 Invoke the source COM object</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>8.4 Disconnect from source if connected</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>8.5 Destroy the sink object</p>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step9. Release the COM object.</p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><a href="http://support.microsoft.com/kb/194179">KB: AtlEvnt.exe sample shows how to creates ATL sinks by using the ATL IDispEventImpl and IDispEventSimpleImpl classes<span style="">.</span></a><span style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
