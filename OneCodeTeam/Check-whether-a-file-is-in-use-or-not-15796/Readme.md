# Check whether a file is in use or not (CSCheckFileInUse)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* File System
## IsPublished
* True
## ModifiedDate
* 2012-03-01 08:48:41
## Description

<div class="WordSection1">
<h1>The project illustrates how to check whether a file is in use or not (<span class="SpellE">CSCheckFileInUse</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The project illustrates how to check whether a file is in use or not.</p>
<p class="MsoNormal">Lots of developers ask about this in the MSDN forums, so we created the code sample to address the frequently asked programming scenario.</p>
<p class="MsoNormal"><a href="http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/76d63016-3864-4020-849a-01a82276493d/">http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/76d63016-3864-4020-849a-01a82276493d/</a>
<br>
<a href="http://social.msdn.microsoft.com/forums/en-us/netfxbcl/thread/a539cbdc-5f42-4f09-9e04-860845aa049d/">http://social.msdn.microsoft.com/forums/en-us/netfxbcl/thread/a539cbdc-5f42-4f09-9e04-860845aa049d/</a><br>
<a href="http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/4e3a6014-4cd7-4d38-ba87-ccf9ce28b3c5/">http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/4e3a6014-4cd7-4d38-ba87-ccf9ce28b3c5/</a><br>
<a href="http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/f225e48c-0321-49a3-9134-53f409dee5d9/">http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/f225e48c-0321-49a3-9134-53f409dee5d9/</a><br>
<a href="http://social.msdn.microsoft.com/Forums/en/netfxbcl/thread/e99a7cea-43d3-49b1-82bc-5669e0b9d052">http://social.msdn.microsoft.com/Forums/en/netfxbcl/thread/e99a7cea-43d3-49b1-82bc-5669e0b9d052</a></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl &#43; F5 to run this sample.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Type a valid file path.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Type &ldquo;exit&rdquo; to exit.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><img src="http://i1.code.msdn.s-msft.com/cscheckfileinuse-1974c9a1/image/file/52547/1/image001.png" alt=""></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The following function checks whether a file is in use or not.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// This function checks whether the file is in use or not.
/// &lt;/summary&gt;
/// &lt;param name=&quot;filename&quot;&gt;File Name&lt;/param&gt;
/// &lt;returns&gt;Return True if file in use else false&lt;/returns&gt;
public static bool IsFileInUse(string filename)
{
    bool locked = false;
    FileStream fs = null;
    try
    {
        fs =
             File.Open(filename, FileMode.OpenOrCreate,
             FileAccess.ReadWrite, FileShare.None);
    }
    catch (IOException )
    {
        locked = true;
    }
    finally
    {
        if (fs != null)
        {
            fs.Close();
        }
    }
    return locked;
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;This&nbsp;function&nbsp;checks&nbsp;whether&nbsp;the&nbsp;file&nbsp;is&nbsp;in&nbsp;use&nbsp;or&nbsp;not.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;filename&quot;&gt;File&nbsp;Name&lt;/param&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;returns&gt;Return&nbsp;True&nbsp;if&nbsp;file&nbsp;in&nbsp;use&nbsp;else&nbsp;false&lt;/returns&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsFileInUse(<span class="cs__keyword">string</span>&nbsp;filename)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;locked&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;FileStream&nbsp;fs&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fs&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;File.Open(filename,&nbsp;FileMode.OpenOrCreate,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileAccess.ReadWrite,&nbsp;FileShare.None);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(IOException&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;locked&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(fs&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fs.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;locked;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<h2>More Information</h2>
<p class="MsoNormal">MSDN: FileStream Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.io.filestream.aspx">http://msdn.microsoft.com/en-us/library/system.io.filestream.aspx</a></p>
<p class="MsoNormal">MSDN: FileAccess Enumeration<br>
<a href="http://msdn.microsoft.com/en-us/library/4z36sx0f.aspx">http://msdn.microsoft.com/en-us/library/4z36sx0f.aspx</a></p>
<p class="MsoNormal">MSDN: File Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.io.file.aspx">http://msdn.microsoft.com/en-us/library/system.io.file.aspx</a></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
<p>&nbsp;</p>
</div>
