# In-process C++ COM server (CppDllCOMServer)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* COM
* Windows SDK
## Topics
* in-process COM Server
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:36:23
## Description

<h1><span style="font-family:������">COMPONENT OBJECT MODEL</span> (<span style="font-family:������">CppDllCOMServer</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">COM is one of the most popular words in Windows world, there are lots of<span style="">
</span>technologies are based on it, such as: ActiveX control, WMI, even the super<span style="">
</span>star CLR is also based on the COM. This sample demonstrates how to create an in-process COM component by the raw<span style="">
</span>interfaces from Win32 DLL project, describes the fundamental concepts<span style="">
</span>involved.<span style="">&nbsp; </span><span style=""></span></p>
<p class="MsoNormal"><span style="">1) An Cpp Simple Object short-named CppSimpleObject.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>Program ID: CppDllCOMServer.CppSimpleObject
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>CLSID_CppSimpleObject: 3739576F-F27B-4857-9E3E-8BAAA2A030B9
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>IID_ICppSimpleObject: 0AE6650F-C9D2-46b2-80C8-7FE10654CC93
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>LIBID_CppDllCOMServerLib: D180D63C-6728-42ce-B953-885CB6E57F01
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>Methods:
</span></p>
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
<p class="MsoNormal"><span style="">2) Use the IDL(Interface Definition Language) to define the interface and the type library.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>Interface is a set of methods, the component should expose some interfaces for using from outside. Type library contains the information of the component.<span style="">&nbsp;
</span>We can use COM component by importing the type library into our project, and implement the early-binding in Automation with its support.<span style="">&nbsp;
</span>IDL is a general way to define the interface, it will generate the language relative files.<span style="">&nbsp;
</span>After compiled it, it will generate five files in VC&#43;&#43; project: </span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>IDLFileName_h.h<span style="">&nbsp;&nbsp;
</span>-- Contains the definition of interfaces. </span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>IDLFileName_i.c<span style="">&nbsp;&nbsp;
</span>-- Contains the GUIDs, including CLSID, IID. </span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>IDLFileName_p.c<span style="">&nbsp;&nbsp;
</span>-- Implementation of proxy/stub. </span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>dlldata.c<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>-- Contains the entry functions of proxy/stub and some data structs of the proxy class factory.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>ComponentName.tlb -- Type library.
</span></p>
<p class="MsoNormal"><span style="">3) IUnknown interface. </span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>Every COM interface must be inherited from the IUnknown interface directly or indirectly, we need to implement the three methods of it at first:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Increase the reference count for an interface on an object.
STDMETHODIMP_(DWORD) AddRef();
// Decrease the reference count for an interface on an object.
STDMETHODIMP_(DWORD) Release();
// Query to the interface the component supported.
STDMETHODIMP QueryInterface(REFIID riid, void** ppv);

</pre>
<pre id="codePreview" class="cplusplus">
// Increase the reference count for an interface on an object.
STDMETHODIMP_(DWORD) AddRef();
// Decrease the reference count for an interface on an object.
STDMETHODIMP_(DWORD) Release();
// Query to the interface the component supported.
STDMETHODIMP QueryInterface(REFIID riid, void** ppv);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">4) Class factory. </span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>Class factory is respondsible to the creation of the component which implements the interface.<span style="">&nbsp;
</span>A class factory object is inherited from the IClassObject interface, we can get this object from the client by the CoGetClassObject() method, then create the component by its method CreateInstance().
</span></p>
<p class="MsoNormal"><span style="">5) Global exposed functions. </span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>The global exposed functions are used to register/unregister the component, create the class factory object and check the status.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;&nbsp; </span>They are:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Create the class factory and query to the specific interface.
EXTERN_C STDMETHODIMP DllGetClassObject(const CLSID&clsid, const IID& iid, void **ppv);
// Register the component to the registry.
EXTERN_C STDMETHODIMP DllRegisterServer();
// Unregister the component from the registry.
EXTERN_C STDMETHODIMP DllUnregisterServer();
// Check whether we can unload the component from the memory.
EXTERN_C STDMETHODIMP DllCanUnloadNow(void);

</pre>
<pre id="codePreview" class="cplusplus">
// Create the class factory and query to the specific interface.
EXTERN_C STDMETHODIMP DllGetClassObject(const CLSID&clsid, const IID& iid, void **ppv);
// Register the component to the registry.
EXTERN_C STDMETHODIMP DllRegisterServer();
// Unregister the component from the registry.
EXTERN_C STDMETHODIMP DllUnregisterServer();
// Check whether we can unload the component from the memory.
EXTERN_C STDMETHODIMP DllCanUnloadNow(void);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Running the Sample</h2>
<p class="MsoNormal">Run cmd.exe as Administrator, type below commands to register/unregiser the<span style="">
</span>component. </p>
<p class="MsoNormal">A. Register<span style="">&nbsp;&nbsp; </span>-- DllRegisterServer() getting called.
</p>
<p class="MsoNormal">Regsvr32.exe %<span class="SpellE">ComponentPath</span>%\CppDllCOMServer.dll<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53158/1/image.png" alt="" width="458" height="151" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">B. Unregister -- <span class="GramE">DllUnregisterServer(</span>) getting called.
</p>
<p class="MsoNormal">Regsvr32.exe /u %<span class="SpellE">ComponentPath</span>%\CppDllCOMServer.dll<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53159/1/image.png" alt="" width="458" height="151" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">%ComponentPath% is the path of directory your latest DLL generated in.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. Create a Win32 DLL project named &quot;CppDllCOMServer&quot; from the wizard in VS2008, accept the default settings and click &quot;Finish&quot;.
</p>
<p class="MsoNormal">Step2. Add an IDL file into the project to define the interface. We defined a ISimpleObject interface which has two methods: HelloWorld(), GetProcessThreadID().
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Define ISimpleObject interface
[
    object,
    uuid(0AE6650F-C9D2-46b2-80C8-7FE10654CC93),
    dual,
    helpstring(&quot;ISimpleObject Interface&quot;),
    pointer_default(unique)
]
interface ISimpleObject : IDispatch
{
    [propget, id(1), helpstring(&quot;property FloatProperty&quot;)] HRESULT FloatProperty([out, retval] FLOAT* pVal);
    [propput, id(1), helpstring(&quot;property FloatProperty&quot;)] HRESULT FloatProperty([in] FLOAT newVal);
    [id(2), helpstring(&quot;method HelloWorld&quot;)] HRESULT HelloWorld([out,retval] BSTR* pRet);
    [id(3), helpstring(&quot;method GetProcessThreadID&quot;)] HRESULT GetProcessThreadID([out] LONG* pdwProcessId, [out] LONG* pdwThreadId);
};

</pre>
<pre id="codePreview" class="cplusplus">
// Define ISimpleObject interface
[
    object,
    uuid(0AE6650F-C9D2-46b2-80C8-7FE10654CC93),
    dual,
    helpstring(&quot;ISimpleObject Interface&quot;),
    pointer_default(unique)
]
interface ISimpleObject : IDispatch
{
    [propget, id(1), helpstring(&quot;property FloatProperty&quot;)] HRESULT FloatProperty([out, retval] FLOAT* pVal);
    [propput, id(1), helpstring(&quot;property FloatProperty&quot;)] HRESULT FloatProperty([in] FLOAT newVal);
    [id(2), helpstring(&quot;method HelloWorld&quot;)] HRESULT HelloWorld([out,retval] BSTR* pRet);
    [id(3), helpstring(&quot;method GetProcessThreadID&quot;)] HRESULT GetProcessThreadID([out] LONG* pdwProcessId, [out] LONG* pdwThreadId);
};

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step3. Add a class into the project to implement the ISimpleObject interface:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
class SimpleObject : public ISimpleObject
{
public:
    // IUnknown
    IFACEMETHODIMP QueryInterface(REFIID riid, void **ppv);
    IFACEMETHODIMP_(ULONG) AddRef();
    IFACEMETHODIMP_(ULONG) Release();


    // IDispatch
    IFACEMETHODIMP GetTypeInfoCount(UINT *pctinfo);
    IFACEMETHODIMP GetTypeInfo(UINT itinfo, LCID lcid, ITypeInfo **pptinfo);
    IFACEMETHODIMP GetIDsOfNames(REFIID riid, LPOLESTR *rgszNames, UINT cNames, LCID lcid, DISPID* rgdispid);
    IFACEMETHODIMP Invoke(DISPID dispidMember, REFIID riid, LCID lcid, WORD wFlags, DISPPARAMS *pdispParams, VARIANT *pvarResult, EXCEPINFO *pExcepInfo, UINT *puArgErr);


    // ISimpleObject
    IFACEMETHODIMP get_FloatProperty(FLOAT *pVal);
    IFACEMETHODIMP put_FloatProperty(FLOAT newVal);
    IFACEMETHODIMP HelloWorld(BSTR *pRet);
    IFACEMETHODIMP GetProcessThreadID(LONG *pdwProcessId, LONG *pdwThreadId);


    SimpleObject();


protected:
    ~SimpleObject();


private:
    // Reference count of component.
    long m_cRef;


    // The value of FloatProperty.
    float m_fField;


    // Pointer to type-library (for implementing IDispatch).
    LPTYPEINFO m_ptinfo;


    // Helper function to load the type info (for implementing IDispatch).
    HRESULT LoadTypeInfo(ITypeInfo **pptinfo, const CLSID& libid, const CLSID& iid, LCID lcid);
};

</pre>
<pre id="codePreview" class="cplusplus">
class SimpleObject : public ISimpleObject
{
public:
    // IUnknown
    IFACEMETHODIMP QueryInterface(REFIID riid, void **ppv);
    IFACEMETHODIMP_(ULONG) AddRef();
    IFACEMETHODIMP_(ULONG) Release();


    // IDispatch
    IFACEMETHODIMP GetTypeInfoCount(UINT *pctinfo);
    IFACEMETHODIMP GetTypeInfo(UINT itinfo, LCID lcid, ITypeInfo **pptinfo);
    IFACEMETHODIMP GetIDsOfNames(REFIID riid, LPOLESTR *rgszNames, UINT cNames, LCID lcid, DISPID* rgdispid);
    IFACEMETHODIMP Invoke(DISPID dispidMember, REFIID riid, LCID lcid, WORD wFlags, DISPPARAMS *pdispParams, VARIANT *pvarResult, EXCEPINFO *pExcepInfo, UINT *puArgErr);


    // ISimpleObject
    IFACEMETHODIMP get_FloatProperty(FLOAT *pVal);
    IFACEMETHODIMP put_FloatProperty(FLOAT newVal);
    IFACEMETHODIMP HelloWorld(BSTR *pRet);
    IFACEMETHODIMP GetProcessThreadID(LONG *pdwProcessId, LONG *pdwThreadId);


    SimpleObject();


protected:
    ~SimpleObject();


private:
    // Reference count of component.
    long m_cRef;


    // The value of FloatProperty.
    float m_fField;


    // Pointer to type-library (for implementing IDispatch).
    LPTYPEINFO m_ptinfo;


    // Helper function to load the type info (for implementing IDispatch).
    HRESULT LoadTypeInfo(ITypeInfo **pptinfo, const CLSID& libid, const CLSID& iid, LCID lcid);
};

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Add a class into the project to implement the IClassFactory interface:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
class ClassFactory : public IClassFactory
{
public:
    // IUnknown
    IFACEMETHODIMP QueryInterface(REFIID riid, void **ppv);
    IFACEMETHODIMP_(ULONG) AddRef();
    IFACEMETHODIMP_(ULONG) Release();


    // IClassFactory
    IFACEMETHODIMP CreateInstance(IUnknown *pUnkOuter, REFIID riid, void **ppv);
    IFACEMETHODIMP LockServer(BOOL fLock);


    ClassFactory();


protected:
    ~ClassFactory();


private:
    long m_cRef;
};

</pre>
<pre id="codePreview" class="cplusplus">
class ClassFactory : public IClassFactory
{
public:
    // IUnknown
    IFACEMETHODIMP QueryInterface(REFIID riid, void **ppv);
    IFACEMETHODIMP_(ULONG) AddRef();
    IFACEMETHODIMP_(ULONG) Release();


    // IClassFactory
    IFACEMETHODIMP CreateInstance(IUnknown *pUnkOuter, REFIID riid, void **ppv);
    IFACEMETHODIMP LockServer(BOOL fLock);


    ClassFactory();


protected:
    ~ClassFactory();


private:
    long m_cRef;
};

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step5. Implement the four global exposed functions. </p>
<p class="MsoNormal">Step6. Add a DEF file into the project to export the global exposed functions:
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
LIBRARY    &quot;CppDllCOMServer&quot;
EXPORTS
    DllGetClassObject   PRIVATE
    DllCanUnloadNow     PRIVATE
    DllRegisterServer   PRIVATE
    DllUnregisterServer PRIVATE

</pre>
<pre id="codePreview" class="cplusplus">
LIBRARY    &quot;CppDllCOMServer&quot;
EXPORTS
    DllGetClassObject   PRIVATE
    DllCanUnloadNow     PRIVATE
    DllRegisterServer   PRIVATE
    DllUnregisterServer PRIVATE

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">// Standard self-registration table. </p>
<p class="MsoNormal">// There are two places we need to specify in the registry:
</p>
<p class="MsoNormal">// 1. HKEY_CLASSES_ROOT\CLSID\{CLSID of Component} </p>
<p class="MsoNormal">// 2. HKEY_CLASSES_ROOT\{ProgID of Component} </p>
<p class="MsoNormal">// ProgID is a easy way to get the CLSID to create the COM component, we can
</p>
<p class="MsoNormal">// get the CLSID from the ProgID through the method GetClsIdFromProgid().
</p>
<p class="MsoNormal">Step7. Compile the project. </p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/ms680573(VS.85).aspx">MSDN: Component Object Model (COM)</a>
</p>
<p class="MsoNormal"><a href="http://www.codeproject.com/KB/COM/simplecomserver.aspx">http://www.codeproject.com/KB/COM/simplecomserver.aspx</a>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
