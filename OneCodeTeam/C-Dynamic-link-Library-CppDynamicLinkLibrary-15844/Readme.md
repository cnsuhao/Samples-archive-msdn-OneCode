# C++ Dynamic-link Library (CppDynamicLinkLibrary)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* DLL
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:35:37
## Description

<h1><span style="font-family:������">DYNAMIC LINK LIBRARY</span> (<span style="font-family:������">CppDynamicLinkLibrary Project</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
A dynamic-link library (DLL) is <span class="GramE">a module that contain</span> functions and data that can be used by another module (application or DLL). This Win32 DLL code sample demonstrates exporting data, functions and classes for use in executables.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
The sample DLL exports these data, functions and classes:</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&lt;o:p&gt;&nbsp; &lt;/o:p&gt;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
// Global Data
int g_nVal1
int g_nVal2


// Ordinary Functions
int __cdecl GetStringLength1(PCWSTR pszString);
int __stdcall GetStringLength2(PCWSTR pszString);


// Callback Function
int __stdcall CompareInts(int a, int b, PFN_COMPARE cmpFunc)


// Class
class CSimpleObject
{
public:
    CSimpleObject(void);  // Constructor
    virtual ~CSimpleObject(void);  // Destructor
      
    // Property
    float get_FloatProperty(void);
    void set_FloatProperty(float newVal);


    // Method
    HRESULT ToString(PWSTR pszBuffer, DWORD dwSize);


    // Static method
    static int GetStringLength(PCWSTR pszString);


private:
    float m_fField;
};

</pre>
<pre id="codePreview" class="cplusplus">
// Global Data
int g_nVal1
int g_nVal2


// Ordinary Functions
int __cdecl GetStringLength1(PCWSTR pszString);
int __stdcall GetStringLength2(PCWSTR pszString);


// Callback Function
int __stdcall CompareInts(int a, int b, PFN_COMPARE cmpFunc)


// Class
class CSimpleObject
{
public:
    CSimpleObject(void);  // Constructor
    virtual ~CSimpleObject(void);  // Destructor
      
    // Property
    float get_FloatProperty(void);
    void set_FloatProperty(float newVal);


    // Method
    HRESULT ToString(PWSTR pszBuffer, DWORD dwSize);


    // Static method
    static int GetStringLength(PCWSTR pszString);


private:
    float m_fField;
};

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<h2>Using the code<span style=""> </span></h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Two methods are used to export the symbols from the sample DLL:</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Export symbols from a DLL using .DEF files</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp;&nbsp; </span></span>A module-definition (.DEF) file is a text file containing one or more module statements that describe various attributes of a DLL. Create a .DEF file and use the .def file when building the DLL.
 Using this <span style=""><span style="">&nbsp;&nbsp;&nbsp;</span></span>approach, we can export functions from the DLL by ordinal rather than by name.
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Export symbols from a DLL using __<span class="GramE">declspec(</span>dllexport)
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span></span>__<span class="SpellE"><span class="GramE">declspec</span></span><span class="GramE">(</span><span class="SpellE">dllexport</span>) adds the export directive to the object file so
 we do not need to use a .def file. This convenience is most apparent when trying to<span style="">
</span>export decorated C&#43;&#43; function names. <span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">Implementation </span></b></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
A. Creating the project</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span></span>Step1. Create a Visual C&#43;&#43; / Win32 / Win32 Project named &quot;CppDynamicLinkLibrary&quot; in Visual Studio 2008.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span></span>Step2. In the page &quot;Application Settings&quot; of Win32 Application Wizard, selectApplication type as DLL, and check the Export symbols checkbox. Click Finish.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
B. Exporting symbols from a DLL using .DEF files</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span></span><a href="http://msdn.microsoft.com/en-us/library/d91k01sh.aspx">http://msdn.microsoft.com/en-us/library/d91k01sh.aspx</a><span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span></span>A module-definition (.<span class="SpellE">def</span>) file is a text file containing one or more module statements that describe various attributes of a DLL. It provides the linker with
 information about exports, attributes, and <span class="GramE">other <span style="">
<span style="">&nbsp;</span></span>information</span> about the program to be linked.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step1. Declare the data and functions to be exported in the header file, and define them in the .cpp file.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
    int g_nVal1;
    int /*__cdecl*/ GetStringLength1(PCWSTR pszString)
    int __stdcall GetStringLength1(PCWSTR pszString)
    int __stdcall CompareInts(int a, int b, PFN_COMPARE cmpFunc)

</pre>
<pre id="codePreview" class="cplusplus">
    int g_nVal1;
    int /*__cdecl*/ GetStringLength1(PCWSTR pszString)
    int __stdcall GetStringLength1(PCWSTR pszString)
    int __stdcall CompareInts(int a, int b, PFN_COMPARE cmpFunc)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step2. Add a .DEF file named CppDynamicLinkLibrary.def to the project. The first statement in the file must be the LIBRARY statement. This statement identifies the .<span class="SpellE">def</span> file as belonging to a DLL.
<span class="GramE">The <span style=""><span style="">&nbsp;</span></span>LIBRARY</span> statement is followed by the name of the DLL. The linker places this name in the DLL's import library. Next, the EXPORTS statement lists the names and, optionally, the
 ordinal values of the data and functions exported by the DLL. </p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
   LIBRARY   CppDynamicLinkLibrary
   EXPORTS
   GetStringLength1     @1
   CompareInts          @2
   g_nVal1              DATA

</pre>
<pre id="codePreview" class="cplusplus">
   LIBRARY   CppDynamicLinkLibrary
   EXPORTS
   GetStringLength1     @1
   CompareInts          @2
   g_nVal1              DATA

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step3. In order that the DLL project invoke the .def file during the linker phase, right-click the project and open its Properties dialog. In the Linker / Input page, set the value of Module Definition File (/<span class="GramE">DEF:</span>)
<span style=""><span style="">&nbsp;</span></span>to be &quot;CppDynamicLinkLibrary.def&quot;.<span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
C. Exporting symbols from a DLL using __<span class="GramE">declspec(</span>dllexport)</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step1. Create the following #ifdef block in the header file to make exporting &amp; importing from a DLL simpler (This should be automatically added if you check the &quot;Export symbols&quot; checkbox when you create the project). All files within this DLL
 are compiled with the CPPDYNAMICLINKLIBRARY_EXPORTS symbol defined on the command line (see the C/C&#43;&#43; / Preprocessor page in the project Properties dialog). This symbol should not be defined on any project that uses this DLL. This way any other project whose
 source files include this file see SYMBOL_DECLSPEC functions as being imported from a DLL, whereas this DLL sees symbols defined with this macro as being exported.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
    #ifdef CPPDYNAMICLINKLIBRARY_EXPORTS
    #define SYMBOL_DECLSPEC __declspec(dllexport)
    #else
    #define SYMBOL_DECLSPEC __declspec(dllimport)
    #endif

</pre>
<pre id="codePreview" class="cplusplus">
    #ifdef CPPDYNAMICLINKLIBRARY_EXPORTS
    #define SYMBOL_DECLSPEC __declspec(dllexport)
    #else
    #define SYMBOL_DECLSPEC __declspec(dllimport)
    #endif

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step2. Declare the data, functions, and classes to be exported in the header file. Add SYMBOL_DECLSPEC in the signatures. For those data and functions that may be accessed from the C language modules or dynamically linked by any executable, add EXTERN_C (i.e.
 extern &quot;C&quot;) at the beginning to specify C linkage. This removes the C&#43;&#43; type-safe naming (aka. name decoration).
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Initialize the data and implement the functions and classes in the .cpp file. </p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">cplusplus</span>
<pre class="hidden">
EXTERN_C SYMBOL_DECLSPEC int g_nVal2;
EXTERN_C SYMBOL_DECLSPEC int /*__cdecl*/ GetStringLength2(PCWSTR pszString);
EXTERN_C SYMBOL_DECLSPEC int __stdcall GetStringLength2(PCWSTR pszString);
class SYMBOL_DECLSPEC CSimpleObject
{
    ...
};

</pre>
<pre id="codePreview" class="cplusplus">
EXTERN_C SYMBOL_DECLSPEC int g_nVal2;
EXTERN_C SYMBOL_DECLSPEC int /*__cdecl*/ GetStringLength2(PCWSTR pszString);
EXTERN_C SYMBOL_DECLSPEC int __stdcall GetStringLength2(PCWSTR pszString);
class SYMBOL_DECLSPEC CSimpleObject
{
    ...
};

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<h2>More Information</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/z4zxe9k8.aspx">MSDN: Exporting from a DLL</a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/d91k01sh.aspx">MSDN: Exporting from a DLL Using DEF Files</a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/a90k134d.aspx">MSDN: Exporting from a DLL Using __<span class="SpellE">declspec</span>(<span class="SpellE">dllexport</span>)</a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/ms235636.aspx">MSDN: Creating and Using a Dynamic Link Library (C&#43;&#43;)</a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://support.microsoft.com/kb/90530">HOWTO: How To Export Data from a DLL or an Application</a></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://en.wikipedia.org/wiki/Dynamic_link_library">Dynamic-link library</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
