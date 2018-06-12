# How to use Bing Translator API in Azure [VB.NET-Visual Studio 2010]
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Bing
* Bing Translator API
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:36:19
## Description

<h1>Using Bing translator via Azure web role application (VBAzureBingTranslatorSample)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">This Sample will show you how to use Bing translator, when you get it from Azure market place.
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Here provide three scenarios that we usually choose. Each page uses a different interface for get data from Bing translator.
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:新宋体"></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal"><span style="">Step 1: Get your client ID and client secret from windows Azure market place. Detail steps here:</span><a href="http://blogs.msdn.com/b/translation/p/gettingstarted1.aspx"><span style="font-size:9.5pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;">Signing
 up for Microsoft Translator on Azure Data Market</span></a><span style="font-size:9.5pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:black">. Make sure your redirect URL is your local IIS URL. In my computer it's:&quot;</span>
<span style="font-size:9.5pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:black">
127.0.0.1:81&quot;.</span><span style=""> </span></p>
<p class="MsoNormal"><span style="">Step 2: Open the CSAzureBingTranslatorSample.sln.
</span>Expand the Web Role project, open UserData.cs in App_code folder.</p>
<p class="MsoNormal">Step 3: Input your <span style="">client ID and client secret you get from step 1 to the parameters in UserData class.</span></p>
<p class="MsoNormal">Step 4: Press Ctrl&#43;F5 to show the Default.aspx.</p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span>&lt;v:shapetype id=&quot;_x0000_t75&quot; coordsize=&quot;21600,21600&quot; o:spt=&quot;75&quot; o:preferrelative=&quot;t&quot; path=&quot;m@4@5l@4@11@9@11@9@5xe&quot; filled=&quot;f&quot; stroked=&quot;f&quot;&gt; &lt;v:stroke joinstyle=&quot;miter&quot;/&gt; &lt;v:formulas&gt; &lt;v:f eqn=&quot;if
 lineDrawn pixelLineWidth 0&quot;/&gt; &lt;v:f eqn=&quot;sum @0 1 0&quot;/&gt; &lt;v:f eqn=&quot;sum 0 0 @1&quot;/&gt; &lt;v:f eqn=&quot;prod @2 1 2&quot;/&gt; &lt;v:f eqn=&quot;prod @3 21600 pixelWidth&quot;/&gt; &lt;v:f eqn=&quot;prod @3 21600 pixelHeight&quot;/&gt; &lt;v:f eqn=&quot;sum @0 0 1&quot;/&gt; &lt;v:f eqn=&quot;prod @6 1 2&quot;/&gt; &lt;v:f eqn=&quot;prod @7 21600 pixelWidth&quot;/&gt;
 &lt;v:f eqn=&quot;sum @8 21600 0&quot;/&gt; &lt;v:f eqn=&quot;prod @7 21600 pixelHeight&quot;/&gt; &lt;v:f eqn=&quot;sum @10 21600 0&quot;/&gt; &lt;/v:formulas&gt; &lt;v:path o:extrusionok=&quot;f&quot; gradientshapeok=&quot;t&quot; o:connecttype=&quot;rect&quot;/&gt; &lt;o:lock v:ext=&quot;edit&quot; aspectratio=&quot;t&quot;/&gt; &lt;/v:shapetype&gt;&lt;v:shape id=&quot;Picture_x0020_1&quot;
 o:spid=&quot;_x0000_i1026&quot; type=&quot;#_x0000_t75&quot; style='width:6in;height:279.75pt;visibility:visible;mso-wrap-style:square'&gt; &lt;v:imagedata src=&quot;Readme_files/image001.png&quot; o:title=&quot;&quot;/&gt; &lt;/v:shape&gt;</span></p>
<p class="MsoNormal">Step 5: Click these links one by one. You will get the function page. Input &quot;Hello world!&quot; in text box, and click translate button.</p>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 6: You will get the translation in Chinese.</p>
<p class="MsoNormal"><span style="">&lt;v:shape id=&quot;Picture_x0020_2&quot; o:spid=&quot;_x0000_i1025&quot; type=&quot;#_x0000_t75&quot; style='width:6in;height:341.25pt; visibility:visible;mso-wrap-style:square'&gt; &lt;v:imagedata src=&quot;Readme_files/image002.png&quot; o:title=&quot;&quot;/&gt; &lt;/v:shape&gt;</span><span style="">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Code Logical:</p>
<p class="MsoNormal">Step 1:<span style="">&nbsp; </span>Create a vb.net windows cloud service with a web role. Service name is &quot;VBAzureBingTranslatorSample&quot;, and web role name is: &quot;VBTranslatorForAzure&quot;.</p>
<p class="MsoNormal">Step2:<span style="">&nbsp; </span>Add an App_code folder, and add three classes:&quot;AdmAccessToken.vb&quot;,&quot; AdmAuthentication.vb&quot;,&quot; UserData.vb&quot;, to it.</p>
<p class="MsoNormal">Step3:<span style="">&nbsp; </span>The AdmAuthentication class is used to create an access token for marked place authentication.</p>
<h3>The following code shows how to create a market place access token.</h3>
<p class="MsoNormal"><span class="SpellE"><b style=""><span style="">AdmAccessToken.vb</span></b></span><b style=""><span style="">:
</span></b></p>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 3: Then we can begin to design our Web form. Please drag and drop some server controls to the pages.<span style="">&nbsp;
</span>And paste this code to related button click event.</p>
<h3>The following code showing how to send request and get request by each translate API.</h3>
<p class="MsoNormal"><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">AJAXAPI.aspx:
</span></b></p>
<p class="MsoNormal"><b style=""><span style="font-size:14.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;"></span></b></p>
<p class="MsoNormal"><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">HTTPAPI.aspx.vb
</span></b></p>
<p class="MsoNormal"><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;"></span></b></p>
<p class="MsoNormal"><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">SOAPAPI.aspx.vb
</span></b></p>
<p class="MsoNormal"><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;"></span></b></p>
<p class="MsoNormal">Step 5: Build the application and you can debug it.</p>
<p class="MsoNormal"><b style=""><span style="font-size:14.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;"></span></b></p>
<h2>More Information</h2>
<p class="MsoNormal"></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/hh847649.aspx">Subscribing to the Microsoft Translator API</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/hh454950.aspx">Obtaining an Access Token</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
