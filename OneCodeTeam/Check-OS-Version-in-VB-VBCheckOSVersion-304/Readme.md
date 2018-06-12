# Check OS Version in VB (VBCheckOSVersion)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* OS Version
## IsPublished
* True
## ModifiedDate
* 2012-11-27 08:40:14
## Description

<h1>Check OS Version in <span style="">VB</span> (<span class="SpellE"><span style="">VB</span>CheckOSVersion</span>)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The <span class="SpellE">VBCheckOSVersion</span> sample demonstrates how to detect the version of the current operating system, and how to make application that checks for the minimum operating system version work with
 later operating system versions. </span></p>
<p class="MsoNormal"><span style="">Note that compatibility mode set in the executable program's property dialog does not apply to the managed code applications. However, if your application is mixed (native and managed) and you are checking for the operating
 system version with a native call, then setting compatibility mode may help. You may refer to the
<span class="SpellE">CppCheckOSVersion</span> for more information about compatibility mode.
</span></p>
<p class="MsoNormal"><span style="">The most common application compatibility issue that users as well as developers face is when an application fails upon checking the operating system version. A lot can go wrong when version checking is misused. A user
 might experience a silent fail where the application simply fails to load and nothing happens. Or, a user might see a dialog box indicating something to the effect of -you must be running Microsoft Windows XP or later- when in fact, the computer is running
 Windows 7. Many other consequences to poor version checking can inconvenience users as well.
</span></p>
<p class="MsoNormal"><span style="">When an application runs on an &quot;incompatible&quot; (due to poor version checking) version of Windows, it will generally display an error message, but it may also exit silently or behave erratically. Often, if we work
 around the version checking, the application will run well. End-users and IT professionals may apply a fix to let the application think it is running on an older version of Windows.
</span></p>
<h2>Running the Sample:<span style=""> </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style="">When the current OS is Windows7 SP1, if you press
<b style="">F5</b> to run this application, you will see following result. </span>
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/71350/1/image.png" alt="" width="312" height="107" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Detect the current operating system version: </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Environment.OSVersion.Version
Environment.OSVersion.VersionString

</pre>
<pre id="codePreview" class="vb">
Environment.OSVersion.Version
Environment.OSVersion.VersionString

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Check if the current OS is at least Windows XP
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If Environment.OSVersion.Version &lt; New Version(5, 1) Then
    Console.WriteLine(&quot;Windows XP or later required.&quot;)
    ' Quit the application due to incompatible OS
    Return
End If

</pre>
<pre id="codePreview" class="vb">
If Environment.OSVersion.Version &lt; New Version(5, 1) Then
    Console.WriteLine(&quot;Windows XP or later required.&quot;)
    ' Quit the application due to incompatible OS
    Return
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.environment.osversion.aspx">MSDN: Environment.OSVersion Property</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
