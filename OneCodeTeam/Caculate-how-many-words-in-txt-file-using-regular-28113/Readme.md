# Caculate how many words in txt file using regular expression
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* .NET Development
* Windows Desktop App Development
## Topics
* Regular Expression
## IsPublished
* True
## ModifiedDate
* 2014-04-10 02:00:30
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<h2><span lang="EN-US" style="">Introduction </span></h2>
<p><span lang="EN-US" style="font-family:&quot;Calibri Light&quot;,&quot;sans-serif&quot;">The sample demonstrates the following features:
</span></p>
<p><span lang="EN-US" style="font-family:&quot;Calibri Light&quot;,&quot;sans-serif&quot;">1. How to calculate how many words in txt file using regular expression.
</span></p>
<p><span lang="EN-US" style="font-family:&quot;Calibri Light&quot;,&quot;sans-serif&quot;">2.&nbsp;How to calculate the occurrence count of&nbsp;a word.
</span></p>
<p><span lang="EN-US" style="font-family:&quot;Calibri Light&quot;,&quot;sans-serif&quot;"></span></p>
<h2><span lang="EN-US" style="">Running the Sample </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span lang="EN-US" style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="">Press Ctrl &#43; F5 to run this sample.
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span lang="EN-US" style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="">Type a valid file path. </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/112601/1/image.png" alt="" width="575" height="290" align="middle">
</span><span lang="EN-US" style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span lang="EN-US" style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="">Choose the appropriate option from the menu.
</span></p>
<p class="MsoListParagraphCxSpLast"><span style=""><img src="/site/view/file/112602/1/image.png" alt="" width="576" height="293" align="middle">
</span><span lang="EN-US" style=""></span></p>
<h2><span lang="EN-US" style=""></span></h2>
<h2><span lang="EN-US" style=""></span></h2>
<h2><span lang="EN-US" style="">Using the Code </span></h2>
<p class="MsoNormal"><span lang="EN-US" style="">The following function returns the total number of words in the input text file.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
static int totalWords(string filename)
        {
            int count = 0;
            StreamReader sr = new StreamReader(filename);
            string input;
            string pattern = @&quot;\b\w&#43;\b&quot;;


            while (sr.Peek() &gt;= 0)
            {
                input = sr.ReadLine();
                Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matches = rgx.Matches(input);
                count &#43;= matches.Count;
            }
            sr.Close();
            return count;
        }

</pre>
<pre id="codePreview" class="csharp">
static int totalWords(string filename)
        {
            int count = 0;
            StreamReader sr = new StreamReader(filename);
            string input;
            string pattern = @&quot;\b\w&#43;\b&quot;;


            while (sr.Peek() &gt;= 0)
            {
                input = sr.ReadLine();
                Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matches = rgx.Matches(input);
                count &#43;= matches.Count;
            }
            sr.Close();
            return count;
        }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN-US" style=""></span></p>
<p class="MsoNormal"><span lang="EN-US" style=""></span></p>
<p class="MsoNormal"><span lang="EN-US" style=""></span></p>
<p class="MsoNormal"><span lang="EN-US" style="">The following function returns the number of occurrences of a specific word in the input text file.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
static int wordCount(string filename, string word)
{
    int count = 0;
    StreamReader sr = new StreamReader(filename);
    string input;
    
    string pattern = word&#43;@&quot;\W&quot;;
    //string pattern = @&quot;(?i)\b&quot;&#43;word&#43;&quot;\b&quot;;
    while (sr.Peek() &gt;= 0)
    {
        input = sr.ReadLine();
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection matches = rgx.Matches(input);
        count &#43;= matches.Count;
    }
    sr.Close();
    return count;    
}

</pre>
<pre id="codePreview" class="csharp">
static int wordCount(string filename, string word)
{
    int count = 0;
    StreamReader sr = new StreamReader(filename);
    string input;
    
    string pattern = word&#43;@&quot;\W&quot;;
    //string pattern = @&quot;(?i)\b&quot;&#43;word&#43;&quot;\b&quot;;
    while (sr.Peek() &gt;= 0)
    {
        input = sr.ReadLine();
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection matches = rgx.Matches(input);
        count &#43;= matches.Count;
    }
    sr.Close();
    return count;    
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span lang="EN-US" style=""></span></p>
<h2><span lang="EN-US" style="">More Information </span></h2>
<p class="MsoNormal"><span lang="EN-US" style="">MSDN: .NET Framework Regular Expressions<br>
<a href="http://msdn.microsoft.com/en-us/library/hs600312.aspx">http://msdn.microsoft.com/en-us/library/hs600312.aspx</a>
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">MSDN: Regular Expression Language: Quick Reference<br>
<a href="http://msdn.microsoft.com/en-us/library/az24scfc.aspx">http://msdn.microsoft.com/en-us/library/az24scfc.aspx</a>
</span></p>
<p class="MsoNormal"><span lang="EN-US" style=""></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
