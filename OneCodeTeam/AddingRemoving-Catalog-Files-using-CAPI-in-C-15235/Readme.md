# Adding/Removing Catalog Files using CAPI in C# (CSCATAdmin)
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
* 2012-02-16 05:24:57
## Description

<div class="WordSection1">
<h1>Adding/Removing Catalog Files using CAPI in C# (<span class="SpellE">CSCATAdmin</span>)</h1>
<h2>Introduction</h2>
<div class="MsoNormal">This program demonstrates how to add/remove catalog files from a Windows system (XP and higher) programmatically.<span>&nbsp;
</span>This can come in handy when installing third party filter drivers via your own installation program.<span>&nbsp;
</span>Catalog files, which include their digital signatures, can&rsquo;t just be copied to the CATROOT directory in System32.<span>&nbsp;
</span>They need to be added to the Catalog Database (CATDB) in the proper store.<span>&nbsp;
</span>CSCATAdmin demonstrates how this is accomplished so that the filter will appear properly signed during installation.<span>&nbsp;
</span></div>
<div class="MsoNormal">This sample was built based upon information provided in the MSDN on this subject.</div>
<div class="MsoNormal">CheckTokenMembership function:<br>
<span>&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/aa376389(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa376389(VS.85).aspx</a></div>
<div class="MsoNormal">Installing a Catalog File by using CryptCATAdminAddCatalog<span style="font-size:17.0pt; line-height:115%"><br>
</span><a href="http://msdn.microsoft.com/en-us/library/ff547575">http://msdn.microsoft.com/en-us/library/ff547575</a></div>
<h2>Building the Sample</h2>
<div class="MsoNormal">Visual Studio 2010 was used to create and build the sample for either 32bit or 64bit platforms.<span>&nbsp;
</span>However, there is nothing specific to Visual Studio 2010 in the sample code itself.<span>&nbsp;
</span></div>
<h2>Running the Sample</h2>
<div class="MsoNormal"><span class="SpellE">CSCATAdmin</span> is a basic console application that takes as arguments a command and a file path:</div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Usage:<span>&nbsp; </span>CATADMINCS <span style="font-size:9.5pt; font-family:Consolas; color:black">
[-a&lt;add&gt; | -r&lt;remove&gt;] [catalog file]</span></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black">Example: <span class="SpellE">
CSCATAdmin</span> -a C:\\MYWORK\\MYCAT.CAT</span></div>
<h2>Using the Code&nbsp;</h2>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<div class="endscriptcode">You need to be an elevated administrator in order to execute the code properly.&nbsp; The following code can be used to determine administrative access during runtime.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        static bool IsAdministrator()
        {
            // Greatly simplified from the C version...
            WindowsIdentity  identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal (identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsAdministrator()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Greatly&nbsp;simplified&nbsp;from&nbsp;the&nbsp;C&nbsp;version...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WindowsIdentity&nbsp;&nbsp;identity&nbsp;=&nbsp;WindowsIdentity.GetCurrent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WindowsPrincipal&nbsp;principal&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WindowsPrincipal&nbsp;(identity);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;principal.IsInRole(WindowsBuiltInRole.Administrator);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">The functions for both Add and Remove catalog uses methods found here:<span>&nbsp;
</span></div>
</div>
</div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<a href="http://msdn.microsoft.com/en-us/library/ff547575">http://msdn.microsoft.com/en-us/library/ff547575</a></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static bool AddCatalog(string strFullPath, string strFilePart)
 {
     IntPtr catAdmin;
     IntPtr catInfo;
 
     // Acquire a handle to a catalog administrator context
     if (!CAPIFunctions.CryptCATAdminAcquireContext(out catAdmin, DriverActionVerify, 0))
     {
         Console.WriteLine(&quot;CAPI Error: Unable to obtain catalog administrator context&quot;);
         return false;
     }
 
     // Attempt to add the catalog file...
     catInfo = CAPIFunctions.CryptCATAdminAddCatalog(catAdmin, strFullPath, strFilePart, 0);
 
     // Cleanup...
     if (catInfo==null)
     {
         CAPIFunctions.CryptCATAdminReleaseContext(catAdmin, 0);
         Console.WriteLine(&quot;CAPI Error: Unable to add catalog file %s&quot;,strFilePart);
         return false;
     }
     else
     {
         CAPIFunctions.CryptCATAdminReleaseCatalogContext(catAdmin, catInfo, 0);
         CAPIFunctions.CryptCATAdminReleaseContext(catAdmin, 0);
         Console.WriteLine(&quot;%s added successfully&quot;, strFilePart);
     }
 
     return true;
 }
 
 /* RemoveCatalog calls the native function CryptCATAdminRemoveCatalog.
  * This function takes as the argument only the filename part of the catalog to be removed
  * The strFile parameter must be the filename part only and must not contain any path information
  * e.g. CATALOG.CAT only and not C:\MYDIR\CATALOG.CAT
  */
  
 static bool RemoveCatalog(string strFile)
 {
     IntPtr catAdmin;
 
     // Acquire a handle to a catalog administrator context...
     if (!CAPIFunctions.CryptCATAdminAcquireContext(out catAdmin, DriverActionVerify, 0))
     {
         Console.WriteLine(&quot;CAPI Error: Unable to obtain catalog administrator context&quot;);
         return false;
     }
 
     // Attempt to remove the catalog file...
     if (!CAPIFunctions.CryptCATAdminRemoveCatalog(catAdmin, strFile, 0))
     {
         Console.WriteLine(&quot;CAPI Error: Unable to remove catalog&quot;);
     }
     else Console.WriteLine(&quot;%s removed successfully&quot;, strFile);
 
     // Cleanup...
     if (catAdmin != null) CAPIFunctions.CryptCATAdminReleaseContext(catAdmin, 0);
 
     return true;
 }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;AddCatalog(<span class="cs__keyword">string</span>&nbsp;strFullPath,&nbsp;<span class="cs__keyword">string</span>&nbsp;strFilePart)&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;catAdmin;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;catInfo;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Acquire&nbsp;a&nbsp;handle&nbsp;to&nbsp;a&nbsp;catalog&nbsp;administrator&nbsp;context</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!CAPIFunctions.CryptCATAdminAcquireContext(<span class="cs__keyword">out</span>&nbsp;catAdmin,&nbsp;DriverActionVerify,&nbsp;<span class="cs__number">0</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CAPI&nbsp;Error:&nbsp;Unable&nbsp;to&nbsp;obtain&nbsp;catalog&nbsp;administrator&nbsp;context&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Attempt&nbsp;to&nbsp;add&nbsp;the&nbsp;catalog&nbsp;file...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;catInfo&nbsp;=&nbsp;CAPIFunctions.CryptCATAdminAddCatalog(catAdmin,&nbsp;strFullPath,&nbsp;strFilePart,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Cleanup...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(catInfo==<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CAPIFunctions.CryptCATAdminReleaseContext(catAdmin,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CAPI&nbsp;Error:&nbsp;Unable&nbsp;to&nbsp;add&nbsp;catalog&nbsp;file&nbsp;%s&quot;</span>,strFilePart);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CAPIFunctions.CryptCATAdminReleaseCatalogContext(catAdmin,&nbsp;catInfo,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CAPIFunctions.CryptCATAdminReleaseContext(catAdmin,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;%s&nbsp;added&nbsp;successfully&quot;</span>,&nbsp;strFilePart);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;<span class="cs__mlcom">/*&nbsp;RemoveCatalog&nbsp;calls&nbsp;the&nbsp;native&nbsp;function&nbsp;CryptCATAdminRemoveCatalog.&nbsp;
&nbsp;&nbsp;*&nbsp;This&nbsp;function&nbsp;takes&nbsp;as&nbsp;the&nbsp;argument&nbsp;only&nbsp;the&nbsp;filename&nbsp;part&nbsp;of&nbsp;the&nbsp;catalog&nbsp;to&nbsp;be&nbsp;removed&nbsp;
&nbsp;&nbsp;*&nbsp;The&nbsp;strFile&nbsp;parameter&nbsp;must&nbsp;be&nbsp;the&nbsp;filename&nbsp;part&nbsp;only&nbsp;and&nbsp;must&nbsp;not&nbsp;contain&nbsp;any&nbsp;path&nbsp;information&nbsp;
&nbsp;&nbsp;*&nbsp;e.g.&nbsp;CATALOG.CAT&nbsp;only&nbsp;and&nbsp;not&nbsp;C:\MYDIR\CATALOG.CAT&nbsp;
&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;RemoveCatalog(<span class="cs__keyword">string</span>&nbsp;strFile)&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;catAdmin;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Acquire&nbsp;a&nbsp;handle&nbsp;to&nbsp;a&nbsp;catalog&nbsp;administrator&nbsp;context...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!CAPIFunctions.CryptCATAdminAcquireContext(<span class="cs__keyword">out</span>&nbsp;catAdmin,&nbsp;DriverActionVerify,&nbsp;<span class="cs__number">0</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CAPI&nbsp;Error:&nbsp;Unable&nbsp;to&nbsp;obtain&nbsp;catalog&nbsp;administrator&nbsp;context&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Attempt&nbsp;to&nbsp;remove&nbsp;the&nbsp;catalog&nbsp;file...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!CAPIFunctions.CryptCATAdminRemoveCatalog(catAdmin,&nbsp;strFile,&nbsp;<span class="cs__number">0</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;CAPI&nbsp;Error:&nbsp;Unable&nbsp;to&nbsp;remove&nbsp;catalog&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;Console.WriteLine(<span class="cs__string">&quot;%s&nbsp;removed&nbsp;successfully&quot;</span>,&nbsp;strFile);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Cleanup...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(catAdmin&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;CAPIFunctions.CryptCATAdminReleaseContext(catAdmin,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="MsoNormal">NOTE:<span>&nbsp; </span>The <span class="SpellE">DriverActionVerify</span> GUID used above defines the third party installed drivers store and is a system defined variable.<span>&nbsp;
</span>This will allow both Add/Remove catalog functions to properly add the Catalog file to the proper store.<span>&nbsp;
</span>This physical location can be found at C:\WINDOWS\SYSTEM32\CATROOT.</div>
<div class="MsoNormal">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// This specifies the 3rd party authenticode store...
static public readonly Guid DriverActionVerify = new Guid(&quot;{f750e6c3-38ee-11d1-85e5-00c04fc295ee}&quot;);

</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;This&nbsp;specifies&nbsp;the&nbsp;3rd&nbsp;party&nbsp;authenticode&nbsp;store...</span>&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;Guid&nbsp;DriverActionVerify&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Guid(<span class="cs__string">&quot;{f750e6c3-38ee-11d1-85e5-00c04fc295ee}&quot;</span>);&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
&nbsp;</div>
</div>
