# List process type information for all running processes (CppCheckProcessType)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
* Windws General
## Topics
* Process type
## IsPublished
* True
## ModifiedDate
* 2012-02-05 06:51:55
## Description

<div class="WordSection1">
<h1><span>List process type information for all running processes</span> (<span class="SpellE">CppCheckProcessType</span>)</h1>
<h2>Introduction</h2>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>This sample code lists process type information for all running processes. Like:</span></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>Is a Console Application or Is a Windows Application</span></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>Is a Managed Application or Is a Native Application</span></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>Is a .NET 4.0 Application</span></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>Is a WPF Application</span></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>Is a 64 Bit Application or Is a 32 Bit Application</span></div>
<h2>Building the Sample</h2>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>1) Open Project in Visual Studio 2010</span></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>2) Go to &quot;Build&quot; -&gt; &quot;Build Solution&quot;</span></div>
<h2>Running the Sample</h2>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>1) Open project in Visual Studio 2010</span></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>2) Go to &quot;Debug&quot; -&gt; &quot;Start Debugging&quot;</span></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>3) Click on &quot;Refresh&quot;</span></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>4) All running processes will be listed with information</span></div>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span><img src="/site/view/file/49103/1/image001.png" alt="" width="362" height="461"></span></div>
<h2>Using the Code</h2>
<div class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span>The code sample provides following reusable components</span></div>
<div class="MsoListParagraph" style="margin-bottom:.0001pt; text-indent:-18.0pt; line-height:normal; text-autospace:none">
<span><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>For a particular process ID, you can determine various process type information</span><span style="font-size:9.5pt; font-family:Consolas">&nbsp;</span></div>
<div class="MsoListParagraphCxSpFirst" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">ProcessInfo piProcessInfo(dwProcessID);
cout &lt;&lt; piProcessInfo.m_fIsManaged &lt;&lt; endl;
cout &lt;&lt; piProcessInfo.m_fIsDotNet4 &lt;&lt; endl;
cout &lt;&lt; piProcessInfo.m_fIsWPF &lt;&lt; endl;
cout &lt;&lt; piProcessInfo.m_fIs64Bit &lt;&lt; endl;
cout &lt;&lt; piProcessInfo.m_fIsConsole &lt;&lt; endl;</pre>
<div class="preview">
<pre class="cplusplus">ProcessInfo&nbsp;piProcessInfo(dwProcessID);&nbsp;
cout&nbsp;&lt;&lt;&nbsp;piProcessInfo.m_fIsManaged&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
cout&nbsp;&lt;&lt;&nbsp;piProcessInfo.m_fIsDotNet4&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
cout&nbsp;&lt;&lt;&nbsp;piProcessInfo.m_fIsWPF&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
cout&nbsp;&lt;&lt;&nbsp;piProcessInfo.m_fIs64Bit&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
cout&nbsp;&lt;&lt;&nbsp;piProcessInfo.m_fIsConsole&nbsp;&lt;&lt;&nbsp;endl;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:9.5pt; font-family:Consolas"><span>&nbsp; 2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span>You can also list process type information for all running processes</span></div>
</div>
<div class="MsoListParagraph" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">ProcessInfo piProcesssesInfo[SIZE];
DWORD cbProcessInfo;
DWORD cProcessInfo;
DWORD fResult;
UINT i;
TCHAR line[SIZE] = L&quot;&quot;;    
 
Enumerator enumerator;
 
fResult = enumerator.EnumerateProcessInfo(piProcesssesInfo,sizeof(piProcesssesInfo),&amp;cbProcessInfo);
 
if(!fResult)
{
    return;
}
 
cProcessInfo = cbProcessInfo / sizeof(ProcessInfo);    
 
SendMessage(g_hProListBox, LB_RESETCONTENT , 0, 0);
 
for( i = 0; i &lt; cProcessInfo; i&#43;&#43;)
{
    if(piProcesssesInfo[i].m_fIsValid)
    {
        StringCchPrintf(line,SIZE,L&quot;PID : %d&quot;,piProcesssesInfo[i].m_dwProcessID);            
        SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)line);    
        SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)piProcesssesInfo[i].m_szFileName);
        SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)(piProcesssesInfo[i].m_fIsManaged?L&quot;Managed Application&quot;:L&quot;Native Application&quot;));    
        SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)(piProcesssesInfo[i].m_fIsDotNet4?L&quot;.NET 4.0 Application&quot;:L&quot;Not .NET 4.0 Application&quot;));    
        SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)(piProcesssesInfo[i].m_fIsWPF?L&quot;WPF Application&quot;:L&quot;Not WPF Application&quot;));    
        SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)(piProcesssesInfo[i].m_fIs64Bit?L&quot;64 Bit Application&quot;:L&quot;32 Bit Application&quot;));    
        SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)(piProcesssesInfo[i].m_fIsConsole?L&quot;Console Application&quot;:L&quot;Windows Application&quot;));    
        SendMessage(g_hProListBox, LB_ADDSTRING, 0, (LPARAM)L&quot;&quot;);    
    }
}
</pre>
<div class="preview">
<pre class="cplusplus">ProcessInfo&nbsp;piProcesssesInfo[SIZE];&nbsp;
<span class="cpp__datatype">DWORD</span>&nbsp;cbProcessInfo;&nbsp;
<span class="cpp__datatype">DWORD</span>&nbsp;cProcessInfo;&nbsp;
<span class="cpp__datatype">DWORD</span>&nbsp;fResult;&nbsp;
<span class="cpp__datatype">UINT</span>&nbsp;i;&nbsp;
<span class="cpp__datatype">TCHAR</span>&nbsp;line[SIZE]&nbsp;=&nbsp;L<span class="cpp__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
Enumerator&nbsp;enumerator;&nbsp;
&nbsp;&nbsp;
fResult&nbsp;=&nbsp;enumerator.EnumerateProcessInfo(piProcesssesInfo,<span class="cpp__keyword">sizeof</span>(piProcesssesInfo),&amp;cbProcessInfo);&nbsp;
&nbsp;&nbsp;
<span class="cpp__keyword">if</span>(!fResult)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
}&nbsp;
&nbsp;&nbsp;
cProcessInfo&nbsp;=&nbsp;cbProcessInfo&nbsp;/&nbsp;<span class="cpp__keyword">sizeof</span>(ProcessInfo);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
SendMessage(g_hProListBox,&nbsp;LB_RESETCONTENT&nbsp;,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;
<span class="cpp__keyword">for</span>(&nbsp;i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;cProcessInfo;&nbsp;i&#43;&#43;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(piProcesssesInfo[i].m_fIsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringCchPrintf(line,SIZE,L<span class="cpp__string">&quot;PID&nbsp;:&nbsp;%d&quot;</span>,piProcesssesInfo[i].m_dwProcessID);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendMessage(g_hProListBox,&nbsp;LB_ADDSTRING,&nbsp;<span class="cpp__number">0</span>,&nbsp;(<span class="cpp__datatype">LPARAM</span>)line);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendMessage(g_hProListBox,&nbsp;LB_ADDSTRING,&nbsp;<span class="cpp__number">0</span>,&nbsp;(<span class="cpp__datatype">LPARAM</span>)piProcesssesInfo[i].m_szFileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendMessage(g_hProListBox,&nbsp;LB_ADDSTRING,&nbsp;<span class="cpp__number">0</span>,&nbsp;(<span class="cpp__datatype">LPARAM</span>)(piProcesssesInfo[i].m_fIsManaged?L<span class="cpp__string">&quot;Managed&nbsp;Application&quot;</span>:L<span class="cpp__string">&quot;Native&nbsp;Application&quot;</span>));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendMessage(g_hProListBox,&nbsp;LB_ADDSTRING,&nbsp;<span class="cpp__number">0</span>,&nbsp;(<span class="cpp__datatype">LPARAM</span>)(piProcesssesInfo[i].m_fIsDotNet4?L<span class="cpp__string">&quot;.NET&nbsp;4.0&nbsp;Application&quot;</span>:L<span class="cpp__string">&quot;Not&nbsp;.NET&nbsp;4.0&nbsp;Application&quot;</span>));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendMessage(g_hProListBox,&nbsp;LB_ADDSTRING,&nbsp;<span class="cpp__number">0</span>,&nbsp;(<span class="cpp__datatype">LPARAM</span>)(piProcesssesInfo[i].m_fIsWPF?L<span class="cpp__string">&quot;WPF&nbsp;Application&quot;</span>:L<span class="cpp__string">&quot;Not&nbsp;WPF&nbsp;Application&quot;</span>));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendMessage(g_hProListBox,&nbsp;LB_ADDSTRING,&nbsp;<span class="cpp__number">0</span>,&nbsp;(<span class="cpp__datatype">LPARAM</span>)(piProcesssesInfo[i].m_fIs64Bit?L<span class="cpp__string">&quot;64&nbsp;Bit&nbsp;Application&quot;</span>:L<span class="cpp__string">&quot;32&nbsp;Bit&nbsp;Application&quot;</span>));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendMessage(g_hProListBox,&nbsp;LB_ADDSTRING,&nbsp;<span class="cpp__number">0</span>,&nbsp;(<span class="cpp__datatype">LPARAM</span>)(piProcesssesInfo[i].m_fIsConsole?L<span class="cpp__string">&quot;Console&nbsp;Application&quot;</span>:L<span class="cpp__string">&quot;Windows&nbsp;Application&quot;</span>));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendMessage(g_hProListBox,&nbsp;LB_ADDSTRING,&nbsp;<span class="cpp__number">0</span>,&nbsp;(<span class="cpp__datatype">LPARAM</span>)L<span class="cpp__string">&quot;&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<h2><span style="font-size:small">References</span></h2>
<div><span style="font-size:small">GetConsoleMode Function<br>
&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms683167(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms683167(VS.85).aspx</a><br>
&nbsp;<br>
GetStdHandle Function<br>
&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms683231(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms683231(VS.85).aspx</a><br>
&nbsp;<br>
AttachConsole Function<br>
&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms681952(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms681952(VS.85).aspx</a><br>
&nbsp;<br>
FreeConsole Function<br>
&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms683150(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms683150(VS.85).aspx</a><br>
&nbsp;<br>
Determine Whether a Program Is a Console or GUI Application<br>
&nbsp;<a href="http://www.devx.com/tips/Tip/33584">http://www.devx.com/tips/Tip/33584</a><br>
&nbsp;<br>
EnumProcessModulesEx Function<br>
&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms682633(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms682633(VS.85).aspx</a><br>
&nbsp;<br>
GetModuleFileNameEx Function<br>
&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms683198(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms683198(VS.85).aspx</a><br>
&nbsp;<br>
IsWow64Process Function<br>
&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms684139(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms684139(VS.85).aspx</a><br>
</span></div>
<div><span style="font-size:small"><br>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
&nbsp;</span></div>
</div>
</span></div>
</div>
