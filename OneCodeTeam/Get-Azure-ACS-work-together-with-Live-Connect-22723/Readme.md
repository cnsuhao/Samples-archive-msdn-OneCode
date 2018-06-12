# Get Azure ACS work together with Live Connect.
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
* Microsoft Azure
## Topics
* Azure
* Microsoft Azure
## IsPublished
* True
## ModifiedDate
* 2013-06-16 06:32:02
## Description

<p class="MsoNormal"><span lang="EN-US">Many developers want to use ACS for their Authentication.</span></p>
<p class="MsoNormal"><span lang="EN-US">When they use Live ID as their authentication provider, they get the claims without any unique information, so they can't save user's information.</span></p>
<p class="MsoNormal"><span lang="EN-US">This sample will show you how to create a custom STS by using Live connect API. It can return all the information you want in claims.</span></p>
<p class="MsoNormal"><span lang="EN-US">This sample needs WIF SDK:</span></p>
<p class="MsoNormal"><span lang="EN-US"><a href="http://www.microsoft.com/en-us/download/details.aspx?id=4451">http://www.microsoft.com/en-us/download/details.aspx?id=4451</a></span></p>
<p class="MsoNormal"><span lang="EN-US">Also it needs a certificate in your local machine.</span></p>
<p class="MsoNormal"><span lang="EN-US">You can create a website with asp.net security token service web site template.</span></p>
<p class="MsoNormal"><span lang="EN-US">This template will automatically create a certificate and install it in your certificates pool.</span></p>
<p class="MsoNormal"><span lang="EN-US" style=""><img src="/site/view/file/85027/1/image.png" alt="" width="448" height="419" align="middle">
</span></p>
<p class="MsoNormal"><span lang="EN-US">Please create the project by yourself, because the template will create a FederationMetadata.xml for you, the federationMetadata in this project will not work for you.</span></p>
<p class="MsoNormal"><span lang="EN-US">Or you can use some tool such as <a href="http://stsmetadataeditor.codeplex.com/">
stsmetatdataeditor</a></span></p>
<p class="MsoListParagraphCxSpFirst" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">In ACS portal add a new Relying party applications for your client app.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/85028/1/image.png" alt="" width="576" height="114" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">In Add Identity Provider, choose a WS-Federation identity provider (e.g. Microsoft AD FS 2.0), click next</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/85029/1/image.png" alt="" width="576" height="321" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Choose the FederationMetadata.xml in your local(if you published, choose the FederationMetadata.xml's url).</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Add the login Url redirect to your LiveCustomSTS login page.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Right click your Client project, Add STS reference to the RP you created before, and let the Rule groups include your STS provider.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Start the Cloud service first, and then start a debug instance to your Client.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">You will be redirected to LiveConnect login page.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/85030/1/image.png" alt="" width="400" height="437" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">After you signed in, you will get: </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/85031/1/image.png" alt="" width="481" height="236" align="middle">
</span><span lang="EN-US"></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:18.0pt; text-indent:5.0pt">
<span lang="EN-US" style=""><span style="">9.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">Now you can get user's Email address.</span></p>
<p class="MsoNormal"><span lang="EN-US"></span></p>
<p class="MsoNormal"><span lang="EN-US"></span></p>
<p class="MsoNormal"><span lang="EN-US"><a href="http://msdn.microsoft.com/en-us/library/ms733095.aspx">http://msdn.microsoft.com/en-us/library/ms733095.aspx</a></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
