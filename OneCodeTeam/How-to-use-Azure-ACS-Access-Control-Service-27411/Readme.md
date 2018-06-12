# How to use Azure ACS (Access Control Service) protect ASP.NET Web API
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Azure
## IsPublished
* True
## ModifiedDate
* 2014-02-25 12:58:44
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<h1><span lang="EN-US">Use ACS secure Asp.net Web API (CSAzureACSWithWebAPI)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<p class="Normal"><span lang="EN-US">Secure Web API is a hot topic in asp.net forum.</span></p>
<p class="Normal"><span lang="EN-US">This sample will show you how to use Azure ACS secure the web API. It will require you sign in with Live ID/Google/Yahoo/Live connect account first before you use the web API.</span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Right click &quot;CSAzureACSWithWebAPI&quot; project, and choose &quot;identity and access&quot;. (If you can't find this selection, go to the tools-&gt;Extentions and updates-&gt;OnLine-&gt;search &quot;Identity&quot;
 and install the &quot;Identity and Access Tool&quot;, then restart your Visual Studio.)</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Choose &quot;Use the Windows Azure Access Control Service&quot;, and configure your ACS Namesapce.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/109363/1/image.png" alt="" width="486" height="317" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Check all the items in check boxes list, then click ok.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/109364/1/image.png" alt="" width="576" height="418" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span lang="EN-US"></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Login to your Azure portal, choose your &quot;Access control Namespace&quot; and click Manage.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/109365/1/image.png" alt="" width="576" height="390" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span lang="EN-US"></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">In your ACS portal choose &quot;relying party applications&quot; in Trust relationships.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">You can find the replying party applications is auto created.<span style="">
<img src="/site/view/file/109366/1/image.png" alt="" width="576" height="245" align="middle">
</span></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Add a new relying party Application for your Web API, for more details please refer to
<a href="http://msdn.microsoft.com/en-us/library/windowsazure/hh289317.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/hh289317.aspx</a>.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Press Ctrl&#43;F5 to run the sample, click login and choose an IDP and sign in.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">9.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">After you sign in ,you can get the content in the textbox as below</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/109367/1/image.png" alt="" width="576" height="243" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:18.0pt"><span lang="EN-US"></span></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US" style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Please read this article first to get the concept of how to secure your Web API
<a href="http://msdn.microsoft.com/en-us/library/windowsazure/hh289317.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/hh289317.aspx</a>.</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US" style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Create a Web API Project, you can create any kind of web API you want. In this sample, we create a Web API as this article described:
<a href="http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api">
http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api</a>.</span></p>
<p class="Normal" style="margin-left:18.0pt; text-indent:5.0pt"><span lang="EN-US" style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Add the SWTModule</span></p>
<h3><span lang="EN-US">SWTModule</span></h3>
<p class="Normal"><span lang="EN-US">4. Add the token validator:</span></p>
<h3><span lang="EN-US">Token validator</span></h3>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US">5. Create CSAzureACSWithWebAPI project, and in Default.aspx code behind paste the code below:</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US">Default.aspx code behind</span></p>
<p class="Normal"><span lang="EN-US">6. In default.aspx copy the login url from ACS portal-&gt; application integration-&gt;login pages.</span></p>
<h2><span lang="EN-US">More Information</span></h2>
<p class="MsoNormal"><span lang="EN-US"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/hh289317.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/hh289317.aspx</a></span></p>
<p class="MsoNormal"><span lang="EN-US"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
