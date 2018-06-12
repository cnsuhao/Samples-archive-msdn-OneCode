# Get VS service from a background thread (CppVSGetServiceInBackgroundThread)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Background thread
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:41:33
## Description

<p style="font-family:Courier New"></p>
<h2>VISUAL STUDIO EXTENSIBILITY : CppVSGetServiceInBackgroundThread Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to get a service in a background thread.<br>
Services cannot be obtained by means of IServiceProvider.QueryService from a<br>
background thread. If you use QueryService to get a service on the main<br>
thread, and then try to use the service on a background thread, it also will<br>
fail.<br>
<br>
To get a service from a background thread, use<br>
CoMarshalInterThreadInterfaceInStream in the IVsPackage.SetSite method to<br>
marshal the service provider into a stream on the main thread. You then can<br>
unmarshal the service provider on a background thread and use it to get the<br>
service. You can unmarshal only once, so cache the interface that you get<br>
back.<br>
<br>
Note:<br>
Managed code automatically marshals interfaces between threads, so getting<br>
a service from a background thread does not require special code.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
VS 2008 SDK must be installed on the machine. You can download it from:<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?FamilyID=30402623-93ca-479a-">http://www.microsoft.com/downloads/details.aspx?FamilyID=30402623-93ca-479a-</a><br>
867c-04dc45164f5b&displaylang=en<br>
<br>
Otherwise the project may not be opened by Visual Studio.<br>
<br>
If you run this project on a x64 OS, please also config the Debug tab of the<br>
project setting. Set the &quot;Start external program&quot; to <br>
C:\Program Files(x86)\Microsoft Visual Studio 9.0\Common7\IDE\devenv.exe<br>
<br>
In VC&#43;&#43; projects, please go to solution folder and open VsSDK.vsprops file. <br>
Change the VSIntegrationRoot value to:<br>
C:\Program Files(X86)\Microsoft Visual Studio 2008 SDK\VisualStudioIntegration<br>
<br>
NOTE: The Package Load Failure Dialog occurs because there is no<br>
&nbsp; &nbsp; &nbsp;PLK(Package Load Key) Specified in this package. To obtain a PLK, please<br>
&nbsp; &nbsp; &nbsp;to go to WebSite:<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/vsx/cc655795.aspx">http://msdn.microsoft.com/en-us/vsx/cc655795.aspx</a><br>
&nbsp; &nbsp; &nbsp;More info:<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb165395.aspx">http://msdn.microsoft.com/en-us/library/bb165395.aspx</a><br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CppVSGetServiceInBackgroundThread -&gt; CSVSService<br>
CppVSGetServiceInBackgroundThread consumes the global service defined in<br>
CSVSService project.<br>
<br>
</p>
<h3>Build:</h3>
<p style="font-family:Courier New"><br>
CppVSGetServiceInBackgroundThread depends on the CSVSService. &nbsp;To build and run<br>
CppVSGetServiceInBackgroundThread successfully, please make sure CSVSService is<br>
built and registered rightly.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a Visual Studio Integration Package project from the New<br>
Project dialog named CppVSGetServiceInBackgroundThread, choose Visual C&#43;&#43; as<br>
the development language.<br>
Check the Menu Command checkbox to create a menu command, we create the<br>
background thread to consume the service in its handler.<br>
<br>
Step2. Generate the type library from the assembly CSVSService.dll created in<br>
the CSVSService project. &nbsp;Type below command in the Command Prompt:<br>
<br>
regasm %CSVSServiceAssemblyPath%\CSVSService.dll /tlb<br>
<br>
%CSVSServiceAssemblyPath% is the folder which the assembly locates in.<br>
This command will generate a .tlb file which is the type library of the<br>
services in the %AssemblyPath%. &nbsp;This is necessary to get the information<br>
about the services and interfaces.<br>
Copy the CSVSService.tlb file to the CppVSGetServiceInBackgroundThread folder.<br>
<br>
Step3. The C&#43;&#43; Integration Package project template will generate two<br>
projects: CppVSGetServiceInBackgroundThread and<br>
CppVSGetServiceInBackgroundThreadUI. &nbsp;Expand the<br>
CppVSGetServiceInBackgroundThread project node, open the Package.h file, it<br>
contains the definition of the package.<br>
<br>
Step4. Import the type library at the top of the Package.h file:<br>
#import &quot;CSVSService.tlb&quot; no_namespace named_guids<br>
<br>
Step5. Add two private members:<br>
<br>
private:<br>
&nbsp; &nbsp;// Used to marshal IServiceProvider between threads<br>
&nbsp; &nbsp;CComPtr&lt; IStream &gt; m_pSPStream;<br>
&nbsp; &nbsp;// IServiceProvider proxy for the background thread<br>
&nbsp; &nbsp;CComPtr&lt; IServiceProvider &gt; m_pBackgroundSP;<br>
<br>
Step6. Modify the command handler, it will create a new background thread:<br>
<br>
// Command handler called when the user selects the<br>
// &quot;GetServiceInBackgroundThread&quot; command.<br>
void OnGetServiceInBackgroundThread(<br>
CommandHandler* /*pSender*/,<br>
DWORD /*flags*/,<br>
VARIANT* /*pIn*/,<br>
VARIANT* /*pOut*/)<br>
{<br>
&nbsp; &nbsp;HANDLE hThread = NULL;<br>
&nbsp; &nbsp;// Create the background thread which will query for the<br>
&nbsp; &nbsp;// ICSGlobalService interface will defined in CSVSService project and<br>
&nbsp; &nbsp;// call its method.<br>
&nbsp; &nbsp;hThread = (HANDLE)(_beginthreadex(<br>
&nbsp; &nbsp; &nbsp; &nbsp;NULL,<br>
&nbsp; &nbsp; &nbsp; &nbsp;0,<br>
&nbsp; &nbsp; &nbsp; &nbsp;&ThreadProc,<br>
&nbsp; &nbsp; &nbsp; &nbsp;(LPVOID)this,<br>
&nbsp; &nbsp; &nbsp; &nbsp;0,<br>
&nbsp; &nbsp; &nbsp; &nbsp;NULL));<br>
&nbsp; &nbsp;if (NULL == hThread)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;MessageBox(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NULL,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TEXT(&quot;Create thread failed!&quot;),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TEXT(&quot;CppVSGetServiceInBackgroundThread&quot;),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MB_OK);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;// Wait for the thread end.<br>
&nbsp; &nbsp;// Because WaitForSingleObject() will break the UI messages handling<br>
&nbsp; &nbsp;// that hands the Visual Studio, so here we use<br>
&nbsp; &nbsp;// MsgWaitForMultipleObjects(), it can handle the UI messages at the<br>
&nbsp; &nbsp;// same time.<br>
&nbsp; &nbsp;MsgWaitForMultipleObjects(1, &hThread, FALSE, 0, INFINITE);<br>
&nbsp; &nbsp;CloseHandle(hThread);<br>
}<br>
<br>
Step7. Override the SetSite() method to marshal the service provider:<br>
<br>
HRESULT STDMETHODCALLTYPE SetSite(IServiceProvider *pSP)<br>
{<br>
&nbsp; &nbsp;// Marshal the service provider into a stream so that the background<br>
&nbsp; &nbsp;// thread can retrieve it later.<br>
&nbsp; &nbsp;CoMarshalInterThreadInterfaceInStream(<br>
&nbsp; &nbsp; &nbsp; &nbsp;IID_IServiceProvider,<br>
&nbsp; &nbsp; &nbsp; &nbsp;pSP,<br>
&nbsp; &nbsp; &nbsp; &nbsp;&m_pSPStream);<br>
<br>
&nbsp; &nbsp;return S_OK;<br>
}<br>
<br>
Step8. Add a method to call unmarshal the service provider and consume the<br>
service:<br>
<br>
// Call this when your background thread needs to call QueryService.<br>
// The first time through, it unmarshals the interface stored.<br>
HRESULT QueryServiceFromBackgroundThread(<br>
&nbsp; &nbsp;REFGUID rsid, &nbsp; &nbsp; &nbsp; &nbsp;// [in] Service ID<br>
&nbsp; &nbsp;REFIID riid, &nbsp; &nbsp; &nbsp; &nbsp; // [in] Interface ID<br>
&nbsp; &nbsp;// [out] Interface pointer of requested service (NULL on error)<br>
&nbsp; &nbsp;void **ppvObj)<br>
{<br>
&nbsp; &nbsp;if(!m_pBackgroundSP)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;if(!m_pSPStream)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return E_UNEXPECTED;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;HRESULT hr = CoGetInterfaceAndReleaseStream(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;m_pSPStream,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;IID_IServiceProvider,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(void **)&m_pBackgroundSP);<br>
&nbsp; &nbsp; &nbsp; &nbsp;if(FAILED(hr))<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return hr;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// The CoGetInterfaceAndReleaseStream has already destroyed the<br>
&nbsp; &nbsp; &nbsp; &nbsp;// stream. &nbsp;To avoid double-freeing, the smart wrapper needs to<br>
&nbsp; &nbsp; &nbsp; &nbsp;// be detached.<br>
&nbsp; &nbsp; &nbsp; &nbsp;m_pSPStream.Detach();<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp;return m_pBackgroundSP-&gt;QueryService(rsid, riid, ppvObj);<br>
}<br>
<br>
Step9. Add the thread procedure:<br>
<br>
UINT STDMETHODCALLTYPE ThreadProc(LPVOID pParam)<br>
{<br>
&nbsp; &nbsp;// Guid of the service SCSGlobalService defined in CSVSService project.<br>
&nbsp; &nbsp;GUID guidService = {0x81099ee5, 0xd61c, 0x4cd7,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{0xbf, 0x44,0xcb, 0x5c, 0x48, 0x66, 0x7b, 0x49}};<br>
&nbsp; &nbsp;ICSGlobalService *ppvICSGlobalService = NULL;<br>
&nbsp; &nbsp;// Call the QueryServiceFromBackgroundThread() method to unmarshal the<br>
&nbsp; &nbsp;// service provider and get the ICSGlobalService interface.<br>
&nbsp; &nbsp;((CCppVSGetServiceInBackgroundThreadPackage*)pParam)-&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;QueryServiceFromBackgroundThread(<br>
&nbsp; &nbsp; &nbsp; &nbsp;guidService,<br>
&nbsp; &nbsp; &nbsp; &nbsp;IID_ICSGlobalService,<br>
&nbsp; &nbsp; &nbsp; &nbsp;(void**)&ppvICSGlobalService);<br>
<br>
&nbsp; &nbsp;if (NULL == ppvICSGlobalService)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;MessageBox(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NULL,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TEXT(&quot;Query interface falied!&quot;),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TEXT(&quot;CppVSGetServiceInBackgroundThread&quot;),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MB_OK);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;return -1;<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp;// Call the GlobalServiceMethod() method of ICSGlobalService interface.<br>
&nbsp; &nbsp;ppvICSGlobalService-&gt;GlobalServiceMethod();<br>
<br>
&nbsp; &nbsp;return 0;<br>
}<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Services<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166389.aspx">http://msdn.microsoft.com/en-us/library/bb166389.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
