# How to check whether a file is in use
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Storage
* .NET Development
* Windows Desktop App Development
* Local File Systems
## Topics
* file
## IsPublished
* True
## ModifiedDate
* 2013-10-15 08:38:10
## Description

<h1><span lang="EN-US" style="">The project illustrates how to check whether a file is in use or not (<span class="SpellE">CSCheckFileInUse</span>)
</span></h1>
<h2><span lang="EN-US" style="">Introduction </span></h2>
<p class="MsoNormal"><span lang="EN-US" style="">The project illustrates how to check whether a file is in use or not.
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">Lots of developers ask about this in the MSDN forums, so we created the code sample to address the frequently asked programming scenario.
</span></p>
<p class="MsoNormal" style="margin-top:1.5pt; margin-right:0in; margin-bottom:1.5pt; margin-left:0in; line-height:normal">
<span style="color:black"><a href="http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/76d63016-3864-4020-849a-01a82276493d/">http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/76d63016-3864-4020-849a-01a82276493d/</a>
</span><span style="color:black"></span></p>
<p class="MsoNormal" style="margin-top:1.5pt; margin-right:0in; margin-bottom:1.5pt; margin-left:0in">
<span style="color:black"><a href="http://social.msdn.microsoft.com/forums/en-us/netfxbcl/thread/a539cbdc-5f42-4f09-9e04-860845aa049d/">http://social.msdn.microsoft.com/forums/en-us/netfxbcl/thread/a539cbdc-5f42-4f09-9e04-860845aa049d/</a>
</span></p>
<p class="MsoNormal" style="margin-top:1.5pt; margin-right:0in; margin-bottom:1.5pt; margin-left:0in">
<span style="color:black"><a href="http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/4e3a6014-4cd7-4d38-ba87-ccf9ce28b3c5/">http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/4e3a6014-4cd7-4d38-ba87-ccf9ce28b3c5/</a>
</span></p>
<p class="MsoNormal" style="margin-top:1.5pt; margin-right:0in; margin-bottom:1.5pt; margin-left:0in">
<span style="color:black"><a href="http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/f225e48c-0321-49a3-9134-53f409dee5d9/">http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/f225e48c-0321-49a3-9134-53f409dee5d9/</a>
</span></p>
<p class="MsoNormal" style="margin-top:1.5pt; margin-right:0in; margin-bottom:1.5pt; margin-left:0in">
<span style="color:black"><a href="http://social.msdn.microsoft.com/Forums/en/netfxbcl/thread/e99a7cea-43d3-49b1-82bc-5669e0b9d052">http://social.msdn.microsoft.com/Forums/en/netfxbcl/thread/e99a7cea-43d3-49b1-82bc-5669e0b9d052</a>
</span></p>
<h2><span lang="EN-US" style="">Running the Sample </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span lang="EN-US" style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="">Press Ctrl &#43; F5 to run this sample.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span lang="EN-US" style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="">Type a valid file path. </span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span lang="EN-US" style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="">Type &quot;exit&quot; to exit. </span>
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/98015/1/image.png" alt="" width="665" height="427" align="middle">
</span><span lang="EN-US" style=""></span></p>
<h2><span lang="EN-US" style="">Using the Code </span></h2>
<p class="MsoNormal"><span lang="EN-US" style="">The following function checks whether a file is in use or not.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:green; background:white">// &lt;summary&gt;</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:green; background:white">//
<span class="GramE">This</span> function checks whether the file is in use or not.</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:green; background:white">// &lt;/summary&gt;</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:green; background:white">// &lt;<span class="SpellE">param</span> name=&quot;filename&quot;&gt;File Name&lt;/<span class="SpellE">param</span>&gt;</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:green; background:white">// &lt;returns&gt;Return True if file in use else false&lt;/returns&gt;</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="GramE"><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">public</span></span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">static</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">bool</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
<span class="SpellE">IsFileInUse</span>(</span><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">string</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"> filename)
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">{
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span class="GramE"><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">bool</span></span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"> Locked =
</span><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">false</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span class="GramE"><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">try</span></span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>{<span style="">&nbsp;&nbsp; </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span style="font-size:9.5pt; font-family:Consolas; color:green; background:white">//Open the file in a try block in exclusive mode.
</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span style="font-size:9.5pt; font-family:Consolas; color:green; background:white">//If the file is in use, it will throw an
<span class="SpellE">IOException</span>.</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF; background:white">FileStream</span></span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
<span class="SpellE">fs</span> = </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span class="SpellE"><span class="GramE"><span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF; background:white">File</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">.Open</span></span></span><span class="GramE"><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">(</span></span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">filename,
</span><span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF; background:white">FileMode</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">.OpenOrCreate</span></span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">,
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF; background:white">FileAccess</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">.ReadWrite</span></span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">,
</span><span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF; background:white">FileShare</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">.None</span></span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">);
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="SpellE"><span class="GramE">fs.Close</span></span><span class="GramE">(</span>);
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>} </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:green; background:white">// If an exception is caught, it means that the file is in Use</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span class="GramE"><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">catch</span></span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"> (</span><span class="SpellE"><span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF; background:white">IOException</span></span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">
 ex) </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>{ </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="">&nbsp;</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>Locked =
</span><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">true</span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>} </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span class="GramE"><span style="font-size:9.5pt; font-family:Consolas; color:blue; background:white">return</span></span><span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"> Locked;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white">}
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:black; background:white"></span></p>
<p class="MsoNormal"><span lang="EN-US" style=""></span></p>
<h2><span lang="EN-US" style="">More Information </span></h2>
<p class="MsoNormal"><span lang="EN-US" style="">MSDN: FileStream Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.io.filestream.aspx">http://msdn.microsoft.com/en-us/library/system.io.filestream.aspx</a>
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">MSDN: FileAccess Enumeration<br>
<a href="http://msdn.microsoft.com/en-us/library/4z36sx0f.aspx">http://msdn.microsoft.com/en-us/library/4z36sx0f.aspx</a>
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">MSDN: File Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.io.file.aspx">http://msdn.microsoft.com/en-us/library/system.io.file.aspx</a>
</span></p>
<p class="MsoNormal"><span lang="EN-US" style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
