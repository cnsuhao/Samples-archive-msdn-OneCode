# How to call Directory.GetFiles with multiple filters
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
* .NET Development
## Topics
* code snippets
* Filter files
## IsPublished
* True
## ModifiedDate
* 2014-05-03 06:32:11
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to use multiple filters to get files from a directory</span><span style="font-weight:bold; font-size:14pt">
</span><span>in</span><span style="font-weight:bold; font-size:14pt"> .NET</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>This is a code snippet project. It will show you how to use multiple filters to get files from a directory</span><span> in .</span><a name="_GoBack"></a><span>NET</span><span>.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Code Snippet</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt"><span>&bull;&nbsp;</span><span style="font-size:11pt">We use</span><span style="font-weight:bold"> System.IO.Directory.EnumerateFiles</span><span style="font-size:11pt"> method or
</span><span style="font-weight:bold">System.IO.Directroy.GetFiles</span><span style="font-size:11pt"> method to get the files from the specified path.</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-weight:bold">[Note]</span><span style="font-size:11pt"> B</span><span>oth of t</span><span style="font-size:11pt">he two methods work on NET Framework 4.5. Using
</span><span style="font-weight:bold">GetFiles </span><span style="font-size:11pt">method will cause memory or performance issues if the directory contains many files. By using the
</span><span style="font-weight:bold">EnumerateFiles</span><span style="font-size:11pt">, we can avoid the memory issues.</span></span></p>
<p style="margin-left:36pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal; text-indent:-18pt">
<span style="font-size:11pt"><span>&bull;&nbsp;</span><span style="font-size:11pt">Then we will use
</span><span style="font-weight:bold">LINQ</span><span style="font-size:11pt">&rsquo;s
</span><span style="font-weight:bold">where </span><span style="font-size:11pt">clause to filter the file</span><span style="font-size:11pt"> list. In the following example, the filter condition is &ldquo;</span><span style="font-weight:bold">s =&gt; s.EndsWith(&quot;.mp3&quot;,
 StringComparison.OrdinalIgnoreCase) || s.EndsWith(&quot;.jpg&quot;)</span><span style="font-size:11pt">.&rdquo;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">/// &lt;summary&gt;
        ///  For .NET 4.0 and later
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;strPath&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public static dynamic GetFilesByFiltersNet4Later(string strPath)
        {         
            var files = Directory.EnumerateFiles(strPath, &quot;*.*&quot;, SearchOption.AllDirectories)
                        .Where(s =&gt; s.EndsWith(&quot;.mp3&quot;, StringComparison.OrdinalIgnoreCase) || s.EndsWith(&quot;.jpg&quot;));
            return files;
        }
        /// &lt;summary&gt;
        /// For earlier versions of .NET
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;strPath&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public static dynamic GetFilesByFiltersBeforeNet4(string strPath)
        {        
            var files = Directory.GetFiles(strPath, &quot;*.*&quot;, SearchOption.AllDirectories)
                        .Where(s =&gt; s.EndsWith(&quot;.mp3&quot;, StringComparison.OrdinalIgnoreCase) || s.EndsWith(&quot;.jpg&quot;));
            return files;
        }
</pre>
<pre class="hidden">''' &lt;summary&gt;
'''  For .NET 4.0 and later
''' &lt;/summary&gt;
''' &lt;param name=&quot;strPath&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Public Shared Function GetFilesByFiltersNet4Later(strPath As String) As dynamic
 Dim files = Directory.EnumerateFiles(strPath, &quot;*.*&quot;, SearchOption.AllDirectories).Where(Function(s) s.EndsWith(&quot;.mp3&quot;, StringComparison.OrdinalIgnoreCase) OrElse s.EndsWith(&quot;.jpg&quot;))
 Return files
End Function
''' &lt;summary&gt;
''' For earlier versions of .NET
''' &lt;/summary&gt;
''' &lt;param name=&quot;strPath&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Public Shared Function GetFilesByFiltersBeforeNet4(strPath As String) As dynamic
 Dim files = Directory.GetFiles(strPath, &quot;*.*&quot;, SearchOption.AllDirectories).Where(Function(s) s.EndsWith(&quot;.mp3&quot;, StringComparison.OrdinalIgnoreCase) OrElse s.EndsWith(&quot;.jpg&quot;))
 Return files
End Function
</pre>
<pre id="codePreview" class="csharp">/// &lt;summary&gt;
        ///  For .NET 4.0 and later
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;strPath&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public static dynamic GetFilesByFiltersNet4Later(string strPath)
        {         
            var files = Directory.EnumerateFiles(strPath, &quot;*.*&quot;, SearchOption.AllDirectories)
                        .Where(s =&gt; s.EndsWith(&quot;.mp3&quot;, StringComparison.OrdinalIgnoreCase) || s.EndsWith(&quot;.jpg&quot;));
            return files;
        }
        /// &lt;summary&gt;
        /// For earlier versions of .NET
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;strPath&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public static dynamic GetFilesByFiltersBeforeNet4(string strPath)
        {        
            var files = Directory.GetFiles(strPath, &quot;*.*&quot;, SearchOption.AllDirectories)
                        .Where(s =&gt; s.EndsWith(&quot;.mp3&quot;, StringComparison.OrdinalIgnoreCase) || s.EndsWith(&quot;.jpg&quot;));
            return files;
        }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">You can call the methods as follows:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">var laterFiles = FiltersFilesFromDirectory.GetFilesByFiltersBeforeNet4(&quot;C:\\path&quot;);
           foreach (var item in laterFiles)
           {
               Console.WriteLine(&quot;Current name is:&quot; &#43; item);
           }
</pre>
<pre class="hidden">Dim laterFiles = FiltersFilesFromDirectory.GetFilesByFiltersBeforeNet4(&quot;C:\path&quot;)
For Each item As var In laterFiles
 Console.WriteLine(&quot;Current name is:&quot; &amp; Convert.ToString(item))
Next
</pre>
<pre id="codePreview" class="csharp">var laterFiles = FiltersFilesFromDirectory.GetFilesByFiltersBeforeNet4(&quot;C:\\path&quot;);
           foreach (var item in laterFiles)
           {
               Console.WriteLine(&quot;Current name is:&quot; &#43; item);
           }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>&nbsp;</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Directory.EnumerateFiles Method (String, String, SearchOption)</span><span style="font-size:11pt">
<br>
</span><a href="http://msdn.microsoft.com/en-us/library/dd383571(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/dd383571(v=vs.110).aspx</span></a><span style="font-size:11pt">
<br>
</span><span style="font-size:11pt">Directory.GetFiles Method (String, String, SearchOption)</span><span style="font-size:11pt">
<br>
</span><a href="http://msdn.microsoft.com/en-us/library/ms143316(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/ms143316(v=vs.110).aspx</span></a><span style="font-size:11pt">
<br>
</span><span style="font-size:11pt">Filtering Data</span><span style="font-size:11pt">
<br>
</span><a href="http://msdn.microsoft.com/en-us/library/bb546161.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/bb546161.aspx</span></a><span style="font-size:11pt">
<br>
</span><span style="font-size:11pt">dynamic (C# Reference)</span><span style="font-size:11pt">
<br>
</span><a href="http://msdn.microsoft.com/en-us/library/dd264741.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/dd264741.aspx</span></a><span style="font-size:11pt">
<br>
</span><span style="font-size:11pt">var (C# Reference)</span><span style="font-size:11pt">
<br>
</span><a href="http://msdn.microsoft.com/en-us/library/bb383973.aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">http://msdn.microsoft.com/en-us/library/bb383973.aspx</span></a><span style="font-size:11pt">
<br>
</span><span style="font-size:11pt"><br>
</span></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
