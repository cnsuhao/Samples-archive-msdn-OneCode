# Out-of-process ATL COM service (ATLCOMService)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* COM
* Windows SDK
## Topics
* out-of-process COM Service
## IsPublished
* True
## ModifiedDate
* 2012-03-04 08:00:52
## Description

<h1>ACTIVE TEMPLATE LIBRARY (ATLCOMService)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Acitve Template Library (ATL) is designed to simplify the process of creating<span style="">
</span>efficient, flexible, lightweight COM components. ATLCOMService provides <span class="GramE">
the <span class="SpellE">our</span></span>-of-process server objects that run in a Windows Service.
</p>
<p class="MsoNormal">ATLCOMService exposes the following items: </p>
<p class="MsoNormal">1. An ATL STA Simple Object short-named <span class="SpellE">
SimpleObject</span>. </p>
<p class="MsoNormal">Program ID: ATLCOMService.SimpleObject </p>
<p class="MsoNormal">CLSID_SimpleObject: 388F1C82-ED00-4966-9590-02F6B9CCA41B </p>
<p class="MsoNormal">IID_ISimpleObject: 1B877090-76CD-4EDE-8115-EC4CCD9676F3 </p>
<p class="MsoNormal">DIID__ISimpleObjectEvents: 7DACF5E9-2885-4E4E-83DD-CA6CC3A88B6D
</p>
<p class="MsoNormal">LIBID_ATLExeCOMServerLib: CC2CA6F0-2220-4D77-BA46-4BCB62156A28
</p>
<p class="MsoNormal"><span class="SpellE">AppID</span>: 5CDE0403-41B3-45F9-8B6F-49E3193B5425
</p>
<p class="MsoNormal">Properties: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// With both get and put accessor methods
FLOAT FloatProperty

</pre>
<pre id="codePreview" class="cplusplus">
// With both get and put accessor methods
FLOAT FloatProperty

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Methods: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// HelloWorld returns a BSTR &quot;HelloWorld&quot;
HRESULT HelloWorld([out,retval] BSTR* pRet);
// GetProcessThreadID outputs the running process ID and thread ID
HRESULT GetProcessThreadID([out] LONG* pdwProcessId, [out] LONG* pdwThreadId);

</pre>
<pre id="codePreview" class="cplusplus">
// HelloWorld returns a BSTR &quot;HelloWorld&quot;
HRESULT HelloWorld([out,retval] BSTR* pRet);
// GetProcessThreadID outputs the running process ID and thread ID
HRESULT GetProcessThreadID([out] LONG* pdwProcessId, [out] LONG* pdwThreadId);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Events: </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// FloatPropertyChanging is fired before new value is set to the 
// FloatProperty property. The [in, out] parameter Cancel allows the client
// to cancel the change of FloatProperty.
void FloatPropertyChanging(
    [in] FLOAT NewValue, [in, out] VARIANT_BOOL* Cancel);.  

</pre>
<pre id="codePreview" class="cplusplus">
// FloatPropertyChanging is fired before new value is set to the 
// FloatProperty property. The [in, out] parameter Cancel allows the client
// to cancel the change of FloatProperty.
void FloatPropertyChanging(
    [in] FLOAT NewValue, [in, out] VARIANT_BOOL* Cancel);.  

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Using the Code</h2>
<h3><span style="">A. Creating the project </span></h3>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step1. Create a Visual C&#43;&#43; / ATL / ATL Project named ATLCOMService in Visual</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Studio 2008.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step2. In the page &quot;Application Settings&quot; of ATL Project Wizard, select the server type as Service (EXE). It generates the main project: ATLCOMService,
 and the proxy/stub project: ATLCOMServicePS. </span></h2>
<h3><span style="">B. Customizing the service in its Overrides </span></h3>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Some famous Overrides are exposed by the service module. For example, InitializeSecurity - Override to set security options for the service via CoInitializeSecurity.
 ServiceMain - Called when the service is started.Handler - Called whenever a control request is received from the service control manager. To override these methods,
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step1. Switch to the Class View of the project, and select the service module CATLCOMServiceModule.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step2. In the Properties dialog, turn to the Overrides page. Select the overridable methods in the list, and add the overrides. The code is generated
 in ATLCOMService.cpp. For example, </span></h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
void CATLCOMServiceModule::ServiceMain(DWORD dwArgc, LPTSTR* lpszArgv)
    {
        // TODO: Add your specialized code here and/or call the base class
        CAtlServiceModuleT&lt;CATLCOMServiceModule,100&gt;::ServiceMain(
            dwArgc, lpszArgv);
    }

</pre>
<pre id="codePreview" class="cplusplus">
void CATLCOMServiceModule::ServiceMain(DWORD dwArgc, LPTSTR* lpszArgv)
    {
        // TODO: Add your specialized code here and/or call the base class
        CAtlServiceModuleT&lt;CATLCOMServiceModule,100&gt;::ServiceMain(
            dwArgc, lpszArgv);
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3><span style="">C. Adding an ATL Simple Object </span></h3>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step1. In Solution Explorer, add a new ATL / ATL Simple Object class to the project.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step2. In ATL Simple Object Wizard, specify the short name as SimpleObject, and select the threading model as Apartment (corresponding</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">to STA), select Interface as Dual that supports both IDispatch (late binding)</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">and vtable binding (early binding). Last, select the Connection points check box. This creates the _ISimpleObjectEvents interface in the file ATLCOMService.idl.
 The Connection points option is the prerequisite for the component to supporting events.
</span></h2>
<h3><span style="">D. Adding Properties to the ATL Simple Object</span><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span></h3>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step1. In Class View, find the interface ISimpleObject. Right click it and select Add / Add Property in the menu.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step2. In Add Property Wizard, specify the property type as FLOAT, property name as FloatProperty. Select both Get function and Put function. SimpleObject
 therefore exposes FloatProperty with the get&amp;put accessor methods: get_FloatProperty, put_FloatProperty.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step3. Add a float field, m_fField, to the class CSimpleObject:
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">protected:</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span></h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Used by FloatProperty
float m_fField;        

</pre>
<pre id="codePreview" class="cplusplus">
// Used by FloatProperty
float m_fField;        

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Implement the get&amp;put accessor methods of FloatProperty to access m_fField.
</span></h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
STDMETHODIMP CSimpleObject::get_FloatProperty(FLOAT* pVal)
    {
        *pVal = m_fField;
        return S_OK;
    }


    STDMETHODIMP CSimpleObject::put_FloatProperty(FLOAT newVal)
    {
        m_fField = newVal;
        return S_OK;
    }

</pre>
<pre id="codePreview" class="cplusplus">
STDMETHODIMP CSimpleObject::get_FloatProperty(FLOAT* pVal)
    {
        *pVal = m_fField;
        return S_OK;
    }


    STDMETHODIMP CSimpleObject::put_FloatProperty(FLOAT newVal)
    {
        m_fField = newVal;
        return S_OK;
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3><span style="">E. Adding Methods to the ATL Simple Object </span></h3>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step1. In Class View, find the interface ISimpleObject. Right-click it</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">and select Add / Add Method in the menu.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step2. In Add Method Wizard, specify the method name as HelloWorld. Add a parameter whose parameter attributes = retval, parameter type = BSTR*, and
 parameter name = pRet. </span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step3. Write the body of HelloWorld as this:
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">With the almost same steps, the method GetProcessThreadID is added to get the</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">executing process ID and thread ID.HRESULT GetProcessThreadID([out] LONG* pdwProcessId, [out] LONG* pdwThreadId);
</span></h2>
<h3><span style="">F. Adding Events to the ATL Simple Object </span></h3>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The Connection points option in B/Step2 is the prerequisite for the component</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">to supporting events.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step1. In Class View, expand ATLExeCOMServer and ATLExeCOMServerLib to display_ISimpleObjectEvents.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step2. Right-click _ISimpleObjectEvents. In the menu, click Add, and then click Add Method.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step3. Select a Return Type of void, enter FloatPropertyChanging in the</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Method name box, and add an [in] parameter FLOAT NewValue, and an [in, out] parameter VARIANT_BOOL* Cancel. After clicking Finish, _ISimpleObjectEvents
 dispinterface in the ATLExeCOMServer.idl file should look like this: </span></h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
    dispinterface _ISimpleObjectEvents
    {
        properties:
        methods:
            [id(1), helpstring(&quot;method FloatPropertyChanging&quot;)] void 
            FloatPropertyChanging(
            [in] FLOAT NewValue, [in,out] VARIANT_BOOL* Cancel);
    };

</pre>
<pre id="codePreview" class="cplusplus">
    dispinterface _ISimpleObjectEvents
    {
        properties:
        methods:
            [id(1), helpstring(&quot;method FloatPropertyChanging&quot;)] void 
            FloatPropertyChanging(
            [in] FLOAT NewValue, [in,out] VARIANT_BOOL* Cancel);
    };

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step4. Generate the type library by rebuilding the project or by right-clicking the ATLCOMService.idl file in Solution Explorer and clicking</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Compile on the shortcut menu. Please note: We must compile the IDL file BEFORE setting up a connection point.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step5. Use the Implement Connection Point Wizard to implement the Connection</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Point interface: In Class View, right-click the component's implementation class CSimpleObject. On the shortcut menu, click Add, and then click Add
 Connection Point. Select _ISimpleObjectEvents from the Source Interfaces list and double-click it to add it to the Implement connection points column. Click Finish. A proxy class for the connection point will be generated (ie. CProxy_ISimpleObjectEvents in
 this sample) in the file _ISimpleObjectEvents_CP.h. This also creates a function with the name</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Fire_[eventname] which can be called to raise events in the client.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step6. Fire the event in put_FloatProperty:
</span></h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
    STDMETHODIMP CSimpleObject::put_FloatProperty(FLOAT newVal)
    {
        // Fire the event, FloatPropertyChanging
        VARIANT_BOOL cancel = VARIANT_FALSE; 
        Fire_FloatPropertyChanging(newVal, &cancel);


        if (cancel == VARIANT_FALSE)
        {
            m_fField = newVal;    // Save the new value
        } // else, do nothing
        return S_OK;
    }

</pre>
<pre id="codePreview" class="cplusplus">
    STDMETHODIMP CSimpleObject::put_FloatProperty(FLOAT newVal)
    {
        // Fire the event, FloatPropertyChanging
        VARIANT_BOOL cancel = VARIANT_FALSE; 
        Fire_FloatPropertyChanging(newVal, &cancel);


        if (cancel == VARIANT_FALSE)
        {
            m_fField = newVal;    // Save the new value
        } // else, do nothing
        return S_OK;
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h3><span style="">G. Configuring and building the project as an ATL COM service </span>
</h3>
<h3><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step1. Open SimpleObject.rgs and add the following value the ForceRemove {388F1C82-ED00-4966-9590-02F6B9CCA41B} registry key.
</span></h3>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>val AppID = s '%APPID%' </span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The result is like
</span></h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
    ForceRemove {388F1C82-ED00-4966-9590-02F6B9CCA41B} = 
        s 'SimpleObject Class'
    {
        ProgID = s 'ATLCOMService.SimpleObject.1'
        VersionIndependentProgID = s 'ATLCOMService.SimpleObject'
        ForceRemove 'Programmable'
        LocalServer32 = s '%MODULE%'
        val AppID = s '%APPID%'
        'TypeLib' = s '{CC2CA6F0-2220-4D77-BA46-4BCB62156A28}'
    }

</pre>
<pre id="codePreview" class="cplusplus">
    ForceRemove {388F1C82-ED00-4966-9590-02F6B9CCA41B} = 
        s 'SimpleObject Class'
    {
        ProgID = s 'ATLCOMService.SimpleObject.1'
        VersionIndependentProgID = s 'ATLCOMService.SimpleObject'
        ForceRemove 'Programmable'
        LocalServer32 = s '%MODULE%'
        val AppID = s '%APPID%'
        'TypeLib' = s '{CC2CA6F0-2220-4D77-BA46-4BCB62156A28}'
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">This is a known product issue of ATL Simple template in Visual Studio 2008. Without the AppID entry, the calls of CoCreateInstance on the client sides
 return 0x80080005. Jigar Mehta's article &quot;CoCreateInstance returns 0x80080005 for Visual Studio 2008 based ATL service&quot; illustrates the details of the issue.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step2. Right-click the ATLCOMService project and select Properties to open its Property Pages. Turn to Build Events / Post Build Event, and change the
 Command Line value from </span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&quot;$(TargetPath)&quot; /RegServer </span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">to
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&quot;$(TargetPath)&quot; /Service </span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">This registers the server in the system registry and as a service, instead of as just a plain EXE.
</span></h2>
<h3><span style="">H. Configuring DCOM-specific settings </span></h3>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"><a href="http://msdn.microsoft.com/en-us/library/wdyy0xsw.aspx">DCOM-specific settings of the ATL service can be configured in the DCOMCNFG utility.</a>
</span></h2>
<h2>More Information </h2>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
