# Adding/Removing Catalog Files using CAPI in C++ (CppCATAdmin)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows Security
* Windows SDK
## Topics
* Cryptography
* CAPI
## IsPublished
* True
## ModifiedDate
* 2012-02-16 05:47:21
## Description

<div class="WordSection1">
<h1>Adding/Removing Catalog Files using CAPI in C&#43;&#43;(CppCATAdmin)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This program demonstrates how to add/remove catalog files from a Windows system (XP and higher) programmatically.<span>&nbsp;
</span>This can come in handy when installing third party filter drivers via your own installation program.<span>&nbsp;
</span>Catalog files, which include their digital signatures, can&rsquo;t just be copied to the CATROOT directory in System32.<span>&nbsp;
</span>They need to be added to the Catalog Database (CATDB) in the proper store.<span>&nbsp;&nbsp;
</span>CppCATAdmin demonstrates how this is accomplished so that the filter will appear properly signed during installation.<span>&nbsp;
</span></p>
<p class="MsoNormal">This sample was built based upon information provided in the MSDN on this subject.</p>
<p class="MsoNormal">CheckTokenMembership function:<br>
<span>&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/aa376389(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa376389(VS.85).aspx</a></p>
<p class="MsoNormal">Installing a Catalog File by using CryptCATAdminAddCatalog<span style="font-size:17.0pt; line-height:115%"><br>
</span><a href="http://msdn.microsoft.com/en-us/library/ff547575">http://msdn.microsoft.com/en-us/library/ff547575</a></p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Visual Studio 2010 was used to create and build the sample for either 32bit or 64bit platforms.<span>&nbsp;
</span>However, there is nothing specific to Visual Studio 2010 in the sample code itself.<span>&nbsp;
</span>The only additional external link is WINTRUST.LIB</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">CppCATAdmin is a basic console application that takes as arguments a command and a file path:</p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Usage:<span>&nbsp; </span>CppCATADMIN <span style="font-size:9.5pt; font-family:Consolas; color:black">
[-a&lt;add&gt; | -r&lt;remove&gt;] [catalog file]</span></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black">Example: CppCATAdmin -a C:\\MYWORK\\MYCAT.CAT</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">You need to be an elevated administrator in order to execute the code properly.&nbsp; This program adds an administrator check using the methods outlined here:&nbsp;</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/aa376389(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa376389(VS.85).aspx</a></p>
<p class="MsoNormal">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">BOOL IsAdminUserAndGroup(void)
{
    BOOL bRet;
    SID_IDENTIFIER_AUTHORITY NtAuthority = SECURITY_NT_AUTHORITY;
    PSID AdministratorsGroup;
    
    bRet = AllocateAndInitializeSid(
        &amp;NtAuthority,
        2,
        SECURITY_BUILTIN_DOMAIN_RID,
        DOMAIN_ALIAS_RID_ADMINS,
        0, 0, 0, 0, 0, 0,
        &amp;AdministratorsGroup);
    
    if(bRet)
    {
        if (!CheckTokenMembership( NULL, AdministratorsGroup, &amp;bRet))
        {
             bRet = FALSE;
        }
        FreeSid(AdministratorsGroup);
    }
 
    return(bRet?TRUE:FALSE);
}
</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__datatype">BOOL</span>&nbsp;IsAdminUserAndGroup(<span class="cpp__keyword">void</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;bRet;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SID_IDENTIFIER_AUTHORITY&nbsp;NtAuthority&nbsp;=&nbsp;SECURITY_NT_AUTHORITY;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PSID&nbsp;AdministratorsGroup;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bRet&nbsp;=&nbsp;AllocateAndInitializeSid(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;NtAuthority,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__number">2</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SECURITY_BUILTIN_DOMAIN_RID,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DOMAIN_ALIAS_RID_ADMINS,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;AdministratorsGroup);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(bRet)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!CheckTokenMembership(&nbsp;NULL,&nbsp;AdministratorsGroup,&nbsp;&amp;bRet))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bRet&nbsp;=&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FreeSid(AdministratorsGroup);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>(bRet?TRUE:FALSE);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The functions for both Add and Remove catalog uses methods found here:<span>&nbsp;
</span></div>
<p>&nbsp;</p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<a href="http://msdn.microsoft.com/en-us/library/ff547575">http://msdn.microsoft.com/en-us/library/ff547575</a></p>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">BOOL AddCatalog(LPCTSTR strCatfile,LPCTSTR strFile)
{
    HCATADMIN hAdmin=NULL;
    BOOL bRet=FALSE;
    HCATINFO hInfo=NULL;
    WCHAR strFILE[MAX_PATH];
    WCHAR strBASE[MAX_PATH];
 
    StringCchCopyW(&amp;strFILE[0],MAX_PATH,strCatfile);
    StringCchCopyW(&amp;strBASE[0],MAX_PATH,strFile);
 
    // Get crypto context
    if(CryptCATAdminAcquireContext(&amp;hAdmin, &amp;PolicyGUID, 0))
    {
        hInfo = CryptCATAdminAddCatalog(hAdmin,strFILE,strBASE, 0);
 
        if(hInfo)
        {
            bRet = CryptCATAdminReleaseCatalogContext(hAdmin,hInfo,0);
        }
 
        if (NULL != hAdmin)
            CryptCATAdminReleaseContext(hAdmin, 0);
 
        return TRUE;
    }
 
    return FALSE;
}
 
BOOL RemoveCatalog(LPCTSTR strCatfile)
{
    HCATADMIN hAdmin=NULL;
    BOOL bRet=FALSE;
    WCHAR strFILE[MAX_PATH];
 
    StringCchCopyW(&amp;strFILE[0],MAX_PATH,strCatfile);
 
    // Get crypto context
    if(CryptCATAdminAcquireContext(&amp;hAdmin, &amp;PolicyGUID, 0))
    {
        bRet = CryptCATAdminRemoveCatalog(hAdmin,strFILE,0);
 
        if (hAdmin) CryptCATAdminReleaseContext(hAdmin, 0);
    }
 
    return bRet;
}</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__datatype">BOOL</span>&nbsp;AddCatalog(<span class="cpp__datatype">LPCTSTR</span>&nbsp;strCatfile,<span class="cpp__datatype">LPCTSTR</span>&nbsp;strFile)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HCATADMIN&nbsp;hAdmin=NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;bRet=FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HCATINFO&nbsp;hInfo=NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">WCHAR</span>&nbsp;strFILE[MAX_PATH];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">WCHAR</span>&nbsp;strBASE[MAX_PATH];&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StringCchCopyW(&amp;strFILE[<span class="cpp__number">0</span>],MAX_PATH,strCatfile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StringCchCopyW(&amp;strBASE[<span class="cpp__number">0</span>],MAX_PATH,strFile);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Get&nbsp;crypto&nbsp;context</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(CryptCATAdminAcquireContext(&amp;hAdmin,&nbsp;&amp;PolicyGUID,&nbsp;<span class="cpp__number">0</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hInfo&nbsp;=&nbsp;CryptCATAdminAddCatalog(hAdmin,strFILE,strBASE,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(hInfo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bRet&nbsp;=&nbsp;CryptCATAdminReleaseCatalogContext(hAdmin,hInfo,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(NULL&nbsp;!=&nbsp;hAdmin)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CryptCATAdminReleaseContext(hAdmin,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;RemoveCatalog(<span class="cpp__datatype">LPCTSTR</span>&nbsp;strCatfile)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HCATADMIN&nbsp;hAdmin=NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;bRet=FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">WCHAR</span>&nbsp;strFILE[MAX_PATH];&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StringCchCopyW(&amp;strFILE[<span class="cpp__number">0</span>],MAX_PATH,strCatfile);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Get&nbsp;crypto&nbsp;context</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(CryptCATAdminAcquireContext(&amp;hAdmin,&nbsp;&amp;PolicyGUID,&nbsp;<span class="cpp__number">0</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bRet&nbsp;=&nbsp;CryptCATAdminRemoveCatalog(hAdmin,strFILE,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(hAdmin)&nbsp;CryptCATAdminReleaseContext(hAdmin,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;bRet;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">NOTE:<span>&nbsp; </span>The PolicyGUID used above defines the third party installed drivers store and is a system defined variable.<span>&nbsp;
</span>This will allow both Add/Remove catalog functions to properly add the Catalog file to the proper store.<span>&nbsp;
</span>This physical location can be found at C:\WINDOWS\SYSTEM32\CATROOT.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// Specifies the third party store...
 
GUID PolicyGUID = DRIVER_ACTION_VERIFY; // Defined in softpub.h
 
//////////////////////////////////////////////////////////////////////////////
//
// DRIVER_ACTION_VERIFY Guid  (Authenticode add-on)
//----------------------------------------------------------------------------
//  Assigned to the pgActionID parameter of WinVerifyTrust to verify the
//  authenticity of a WHQL signed driver.  This is an Authenticode add-on
//  Policy Provider,
//
//          {F750E6C3-38EE-11d1-85E5-00C04FC295EE}
//
#define     DRIVER_ACTION_VERIFY                                        \
                { 0xf750e6c3,                                           \
                  0x38ee,                                               \
                  0x11d1,                                               \
                  { 0x85, 0xe5, 0x0, 0xc0, 0x4f, 0xc2, 0x95, 0xee }     \
                }
</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__com">//&nbsp;Specifies&nbsp;the&nbsp;third&nbsp;party&nbsp;store...</span>&nbsp;
&nbsp;&nbsp;
GUID&nbsp;PolicyGUID&nbsp;=&nbsp;DRIVER_ACTION_VERIFY;&nbsp;<span class="cpp__com">//&nbsp;Defined&nbsp;in&nbsp;softpub.h</span>&nbsp;
&nbsp;&nbsp;
<span class="cpp__com">//////////////////////////////////////////////////////////////////////////////</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;DRIVER_ACTION_VERIFY&nbsp;Guid&nbsp;&nbsp;(Authenticode&nbsp;add-on)</span>&nbsp;
<span class="cpp__com">//----------------------------------------------------------------------------</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;Assigned&nbsp;to&nbsp;the&nbsp;pgActionID&nbsp;parameter&nbsp;of&nbsp;WinVerifyTrust&nbsp;to&nbsp;verify&nbsp;the</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;authenticity&nbsp;of&nbsp;a&nbsp;WHQL&nbsp;signed&nbsp;driver.&nbsp;&nbsp;This&nbsp;is&nbsp;an&nbsp;Authenticode&nbsp;add-on</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;Policy&nbsp;Provider,</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{F750E6C3-38EE-11d1-85E5-00C04FC295EE}</span>&nbsp;
<span class="cpp__com">//</span><span class="cpp__preproc">&nbsp;
#define&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DRIVER_ACTION_VERIFY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;0xf750e6c3,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;0x38ee,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;0x11d1,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;0x85,&nbsp;0xe5,&nbsp;0x0,&nbsp;0xc0,&nbsp;0x4f,&nbsp;0xc2,&nbsp;0x95,&nbsp;0xee&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<p>&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p>&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
</div>
