# C++ invokes .NET assembly via C++/CLI wrapper (CppCallNETAssemblyWrapper)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* Interop
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:19:10
## Description

<h1><span style="">C&#43;&#43; invokes .NET assembly via C&#43;&#43;/CLI wrapper (<span class="SpellE">CppCallNETAssemblyWrapper</span>)
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
The code sample demonstrates calling the .NET classes defined in a managed assembly from a native C&#43;&#43; application through C&#43;&#43;/CLI wrapper classes.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style=""><span style="">?/span&gt;After you successfully build the
<span class="SpellE">CSClassLibrary</span>, <span class="SpellE">CppCLINETAssemblyWrapper</span>, and
<span class="SpellE">CppCallNETAssemblyWrapper</span> sample projects in Visual Studio 2008, you will get these outputs:
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span style="font-family:Symbol"><span style="">?span style='font:7.0pt &quot;Times New Roman&quot;'&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">CppCallNETAssemblyWrapper.exe </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span style="font-family:Symbol"><span style="">?span style='font:7.0pt &quot;Times New Roman&quot;'&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="">CppCLINETAssemblyWrapper.dll </span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span style="font-family:Symbol"><span style="">?span style='font:7.0pt &quot;Times New Roman&quot;'&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="">CSClassLibrary.dll. </span></p>
<p class="MsoNormal" style="margin-left:54.0pt"><span style="">Their relationship is that
<span class="SpellE">CppCallNETAssemblyWrapper</span> invokes CppCLINETAssemblyWrapper.dll, which further invokes the public class defined in CSClassLibrary.dll.
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Run CppCallNETAssemblyWrapper.exe, and you will see
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/65171/1/image.png" alt="" width="374" height="95" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpLast"><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style=""><span style="">A.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create a C# Class Library project <span class="SpellE">
CSClassLibrary</span>. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style=""><span style="">B.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create a CLI .NET Assembly wrapper <span class="SpellE">
CppCLINETAssemblyWrapper</span>. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Reference the C# class library <span class="SpellE">
CSClassLibrary</span> in the C&#43;&#43;/CLI class library project. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Configure the C&#43;&#43;/CLI class library to export symbols. The symbols can be imported and called by native C&#43;&#43; applications.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="">Add CPPCLINETASSEMBLYWRAPPER_EXPORTS to the preprocessor definitions of the project (see the C/C&#43;&#43; / Preprocessor page in the project Properties dialog). All files within this
 DLL are compiled with the symbol CPPCLINETASSEMBLYWRAPPER_EXPORTS. This symbol should not be defined on any project that uses this DLL.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style="">In the header file
<span class="SpellE">CppCLINETAssemblyWrapper.h</span>, add the following definitions:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
#ifdef CPPCLINETASSEMBLYWRAPPER_EXPORTS
#define SYMBOL_DECLSPEC __declspec(dllexport)
#else
#define SYMBOL_DECLSPEC牋?__declspec(dllimport)
#endif

</pre>
<pre id="codePreview" class="cplusplus">
#ifdef CPPCLINETASSEMBLYWRAPPER_EXPORTS
#define SYMBOL_DECLSPEC __declspec(dllexport)
#else
#define SYMBOL_DECLSPEC牋?__declspec(dllimport)
#endif

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span style="">Any other projects whose source files include this header file see SYMBOL_DECLSPEC classes and functions as being imported from a DLL, whereas this DLL sees symbols defined with
 this macro as being exported. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="">Because the header file may be included by any other native C&#43;&#43; project, the file should only contain native C&#43;&#43; types, includes and keywords.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Design the C&#43;&#43; wrapper class <span class="SpellE">
CSSimpleObjectWrapper</span> for the .NET class <span class="SpellE">CSimpleObject</span> defined in the C# class library
<span class="SpellE">CSClassLibrary</span>. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style="">In the header file
<span class="SpellE">CppCLINETAssemblyWrapper.h</span>, declare the class. </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
class SYMBOL_DECLSPEC CSSimpleObjectWrapper
{
public:
牋?CSSimpleObjectWrapper(void);
牋?virtual ~CSSimpleObjectWrapper(void);


牋?// Property
牋?float get_FloatProperty(void);
牋?void set_FloatProperty(float fVal);


牋?// Method
牋?HRESULT ToString(PWSTR pszBuffer, DWORD dwSize);


牋?// Static method
牋?static int GetStringLength(PCWSTR pszString);


private:
牋?void *m_impl;
};

</pre>
<pre id="codePreview" class="cplusplus">
class SYMBOL_DECLSPEC CSSimpleObjectWrapper
{
public:
牋?CSSimpleObjectWrapper(void);
牋?virtual ~CSSimpleObjectWrapper(void);


牋?// Property
牋?float get_FloatProperty(void);
牋?void set_FloatProperty(float fVal);


牋?// Method
牋?HRESULT ToString(PWSTR pszBuffer, DWORD dwSize);


牋?// Static method
牋?static int GetStringLength(PCWSTR pszString);


private:
牋?void *m_impl;
};

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style="">The class contains a native C&#43;&#43; generic pointer (void *<span class="SpellE">m_<span class="GramE">impl</span></span><span class="GramE">;</span>) to the wrapped .NET object.
 It is initialized in the constructor <span class="SpellE"><span class="GramE">CSSimpleObjectWrapper</span></span><span class="GramE">(</span>void);, and the wrapped object is freed in the
<span class="SpellE">desctructor</span> (virtual ~<span class="SpellE">CSSimpleObjectWrapper</span>(void);).
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
CSSimpleObjectWrapper::CSSimpleObjectWrapper(void)
{
牋?// Instantiate the C# class CSSimpleObject.
牋?CSSimpleObject ^ obj = gcnew CSSimpleObject();


牋?// Pin the CSSimpleObject .NET object, and record the address of the 
牋牋// pinned object in m_impl. 
牋牋m_impl = GCHandle::ToIntPtr(GCHandle::Alloc(obj)).ToPointer(); 
}


CSSimpleObjectWrapper::~CSSimpleObjectWrapper(void)
{
牋?// Get the GCHandle associated with the pinned object based on its 
牋牋// address, and free the GCHandle. At this point, the CSSimpleObject 
牋牋// object is eligible for GC.
牋?GCHandle h = GCHandle::FromIntPtr(IntPtr(m_impl));
牋?h.Free();
}

</pre>
<pre id="codePreview" class="cplusplus">
CSSimpleObjectWrapper::CSSimpleObjectWrapper(void)
{
牋?// Instantiate the C# class CSSimpleObject.
牋?CSSimpleObject ^ obj = gcnew CSSimpleObject();


牋?// Pin the CSSimpleObject .NET object, and record the address of the 
牋牋// pinned object in m_impl. 
牋牋m_impl = GCHandle::ToIntPtr(GCHandle::Alloc(obj)).ToPointer(); 
}


CSSimpleObjectWrapper::~CSSimpleObjectWrapper(void)
{
牋?// Get the GCHandle associated with the pinned object based on its 
牋牋// address, and free the GCHandle. At this point, the CSSimpleObject 
牋牋// object is eligible for GC.
牋?GCHandle h = GCHandle::FromIntPtr(IntPtr(m_impl));
牋?h.Free();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="">The public member methods of
<span class="SpellE">CSSimpleObjectWrapper</span> wrap those of the C# class <span class="SpellE">
CSSimpleObject</span>. They <span class="GramE">redirects</span> the calls to <span class="SpellE">
CSSimpleObject</span> through the <span class="SpellE">CSSimpleObject</span> object pointed by
<span class="SpellE">m_impl</span>. Type marshaling takes place between the managed and native code.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
float CSSimpleObjectWrapper::get_FloatProperty(void)
{
牋?// Get the pinned CSSimpleObject object from its memory address.
牋?GCHandle h = GCHandle::FromIntPtr(IntPtr(m_impl));
牋?CSSimpleObject ^ obj = safe_cast&lt;CSSimpleObject^&gt;(h.Target);


牋?// Redirect the call to the corresponding property of the wrapped 
牋牋// CSSimpleObject object.
牋?return obj-&gt;FloatProperty;
}


void CSSimpleObjectWrapper::set_FloatProperty(float fVal)
{
牋?// Get the pinned CSSimpleObject object from its memory address.
牋?GCHandle h = GCHandle::FromIntPtr(IntPtr(m_impl));
牋?CSSimpleObject ^ obj = safe_cast&lt;CSSimpleObject^&gt;(h.Target);


牋?// Redirect the call to the corresponding property of the wrapped 
牋牋// CSSimpleObject object.
牋?obj-&gt;FloatProperty = fVal;
}


HRESULT CSSimpleObjectWrapper::ToString(PWSTR pszBuffer, DWORD dwSize)
{
牋?// Get the pinned CSSimpleObject object from its memory address.
牋?GCHandle h = GCHandle::FromIntPtr(IntPtr(m_impl));
牋?CSSimpleObject ^ obj = safe_cast&lt;CSSimpleObject^&gt;(h.Target);


牋?String ^ str;
牋?HRESULT hr;
牋?try
牋?{
牋牋牋?// Redirect the call to the corresponding method of the wrapped 
牋牋牋牋// CSSimpleObject object.
牋牋牋?str = obj-&gt;ToString();
牋?}
牋?catch (Exception ^ e)
牋?{
牋?牋牋hr = Marshal::GetHRForException(e);
牋?}


牋?if (SUCCEEDED(hr))
牋?{
牋牋牋?// Convert System::String to PCWSTR.
牋牋牋?marshal_context ^ context = gcnew marshal_context();
牋牋牋?PCWSTR pszStr = context-&gt;marshal_as&lt;const wchar_t*&gt;(str);
牋牋牋?hr = StringCchCopy(pszBuffer, dwSize, pszStr == NULL ? L&quot;&quot; : pszStr);
牋牋牋?delete context; // This will also free the memory pointed by pszStr
牋?}


牋?return hr;
}


int CSSimpleObjectWrapper::GetStringLength(PCWSTR pszString)
{
牋?return CSSimpleObject::GetStringLength(gcnew String(pszString));
}

</pre>
<pre id="codePreview" class="cplusplus">
float CSSimpleObjectWrapper::get_FloatProperty(void)
{
牋?// Get the pinned CSSimpleObject object from its memory address.
牋?GCHandle h = GCHandle::FromIntPtr(IntPtr(m_impl));
牋?CSSimpleObject ^ obj = safe_cast&lt;CSSimpleObject^&gt;(h.Target);


牋?// Redirect the call to the corresponding property of the wrapped 
牋牋// CSSimpleObject object.
牋?return obj-&gt;FloatProperty;
}


void CSSimpleObjectWrapper::set_FloatProperty(float fVal)
{
牋?// Get the pinned CSSimpleObject object from its memory address.
牋?GCHandle h = GCHandle::FromIntPtr(IntPtr(m_impl));
牋?CSSimpleObject ^ obj = safe_cast&lt;CSSimpleObject^&gt;(h.Target);


牋?// Redirect the call to the corresponding property of the wrapped 
牋牋// CSSimpleObject object.
牋?obj-&gt;FloatProperty = fVal;
}


HRESULT CSSimpleObjectWrapper::ToString(PWSTR pszBuffer, DWORD dwSize)
{
牋?// Get the pinned CSSimpleObject object from its memory address.
牋?GCHandle h = GCHandle::FromIntPtr(IntPtr(m_impl));
牋?CSSimpleObject ^ obj = safe_cast&lt;CSSimpleObject^&gt;(h.Target);


牋?String ^ str;
牋?HRESULT hr;
牋?try
牋?{
牋牋牋?// Redirect the call to the corresponding method of the wrapped 
牋牋牋牋// CSSimpleObject object.
牋牋牋?str = obj-&gt;ToString();
牋?}
牋?catch (Exception ^ e)
牋?{
牋?牋牋hr = Marshal::GetHRForException(e);
牋?}


牋?if (SUCCEEDED(hr))
牋?{
牋牋牋?// Convert System::String to PCWSTR.
牋牋牋?marshal_context ^ context = gcnew marshal_context();
牋牋牋?PCWSTR pszStr = context-&gt;marshal_as&lt;const wchar_t*&gt;(str);
牋牋牋?hr = StringCchCopy(pszBuffer, dwSize, pszStr == NULL ? L&quot;&quot; : pszStr);
牋牋牋?delete context; // This will also free the memory pointed by pszStr
牋?}


牋?return hr;
}


int CSSimpleObjectWrapper::GetStringLength(PCWSTR pszString)
{
牋?return CSSimpleObject::GetStringLength(gcnew String(pszString));
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style=""><span style="">C.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create a C&#43;&#43; Win32 application <span class="SpellE">
CppCallNETAssemblyWrapper</span>. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Implicitly link to the C&#43;&#43;/CLI class library <span class="SpellE">
CppCLINETAssemblyWrapper</span> that exports the wrapper class <span class="SpellE">
CSSimpleObjectWrapper</span>. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt; text-indent:5.0pt">
<span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>i.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">You need to link the LIB file of the DLL by entering the LIB file name in Project Properties / Linker / Input / Additional Dependencies. You can configure the search path of the LIB file in Project Properties / Linker / General
 / Additional Library Directories. </span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>ii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Include the header file that declares the wrapper class.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
#include &quot;CppCLINETAssemblyWrapper.h&quot;

</pre>
<pre id="codePreview" class="cplusplus">
#include &quot;CppCLINETAssemblyWrapper.h&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span style=""><span style="">?</span>You can configure the search path of the header file in Project Properties /C/C&#43;&#43; / General / Additional Include Directories.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Call the wrapper class <span class="SpellE">
CSSimpleObjectWrapper</span> exported by <span class="SpellE">CppCLINETAssemblyWrapper</span> to indirectly access the .NET class
<span class="SpellE">CSSimpleObject</span> defined in the C# class library <span class="SpellE">
CSClassLibrary</span>. For example, </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
CSSimpleObjectWrapper obj;


obj.set_FloatProperty(1.2F);
float fProp = obj.get_FloatProperty();
wprintf(L&quot;Class: CSSimpleObject::FloatProperty = %.2f\n&quot;, fProp);

</pre>
<pre id="codePreview" class="cplusplus">
CSSimpleObjectWrapper obj;


obj.set_FloatProperty(1.2F);
float fProp = obj.get_FloatProperty();
wprintf(L&quot;Class: CSSimpleObject::FloatProperty = %.2f\n&quot;, fProp);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoNormal" style=""></p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">?span style='font:7.0pt &quot;Times New Roman&quot;'&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><a href="http://msdn.microsoft.com/en-us/library/2x8kf7zx.aspx">Using C&#43;&#43;
<span class="SpellE">Interop</span> (Implicit <span class="SpellE">PInvoke</span>)</a>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
