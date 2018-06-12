# Silverlight 3 out-of-browser application (VBSL3OOB)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Out-of-Browser
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:16:28
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : VBSL3OOB Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Overview:</h3>
<p style="font-family:Courier New"><br>
This example demonstrates how to work with OOB using VB.<br>
It includes the following features:<br>
Install OOB with code (but you cannot remove OOB with code).<br>
Check if the application is already installed.<br>
Check for updates.<br>
Check for network state.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Required:<br>
Silverlight 3 Chained Installer<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a">http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a</a><br>
-88f3-5e7b5409e9dd&displaylang=en<br>
<br>
</p>
<h3>Usage:</h3>
<p style="font-family:Courier New"><br>
As for the usage of this sample, first please make sure you've set the<br>
VBSL3OOB.Web project as the startup project. Otherwise some features will not<br>
work properly.<br>
<br>
Click the Install with code Button, or right click and choose Install VBSL3OOB<br>
application onto this computer, to install the application.<br>
<br>
Close the browser, but do not close the OOB window. Update the source code,<br>
rebuild and launch the application in browser again. You'll notice the OOB<br>
application has not been updated yet. Click Check for update in the OOB<br>
application (not the browser application), and you'll see it asks you to<br>
restart the OOB. After you restart, you'll notice the update has been applied.<br>
<br>
Disable your network connection, and note the red text (information about<br>
network status) in the bottom of the screen being updated. Enable your network<br>
connection again, and the red text will be updated again.<br>
<br>
</p>
<h3>Documentation:</h3>
<p style="font-family:Courier New">OOB, as the name indicates, allows you to work with Silverlight applications<br>
out of browser. It is very easy to configure a Silverlight application to<br>
support OOB within Visual Studio. In the Properties page of the Silverlight<br>
project, simply check &quot;Enable running application out of browser&quot;. Click the<br>
Out-Of-Browser Settings Button to configure the OOB properties. The MSDN<br>
document has detailed description about the properties.<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/dd833073(VS.95).aspx">http://msdn.microsoft.com/en-us/library/dd833073(VS.95).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd833073(VS.95).aspx">http://msdn.microsoft.com/en-us/library/dd833073(VS.95).aspx</a><br>
&nbsp; &nbsp;<br>
Under the hook, what Visual Studio does is exactly creating a manifest file<br>
that corresponds to that described in the MSDN document. You can find it in<br>
the Bin folder after you build your application. You can also edit the<br>
OutOfBrowserSettings.xml file under the Properties folder directly, if you<br>
don't want to use the tool.<br>
<br>
OOB supports update, if it is downloaded from a web site (instead of local<br>
file system). But you have to manually check if an update is available by<br>
handling the Application.Current.CheckAndDownloadUpdateCompleted event.<br>
<br>
Most Silverlight features work fine in OOB. However, certain features will<br>
only work if the application is installed from a web site. For example, check<br>
for update. That's why this sample includes a web application. Please run the<br>
web application instead of the Silverlight application directly. Also, if the<br>
application needs to perform network access, you'll have to host it in a web<br>
site. Otherwise you'll ge cross-scheme errors even if you run inside the<br>
browser...<br>
<br>
Network features work fine in OOB. If you're accessing a network resource<br>
from the same domain where you install the application, no cross-domain<br>
policy file is needed. Otherwise, as long as the cross-domain policy file<br>
allows you to access the resource, it will work fine.<br>
<br>
So how does OOB work? Actually the following application is always launched<br>
when you open an OOB application:<br>
For x86: C:\Program Files\Microsoft Silverlight\sllauncher.exe<br>
For x64: C:\Program Files (x86)\Microsoft Silverlight\sllauncher.exe<br>
<br>
This application accepts a command line argument like:<br>
(a number as ID).domainname<br>
<br>
When you install the OOB, several files will be downloaded to the following<br>
folder:<br>
<br>
For Vista and later:<br>
Users\yourname\AppData\LocalLow\Microsoft\Silverlight\OutOfBrowser<br>
\NumberAsID.domain<br>
<br>
For ealier OS:<br>
Documents and Settings\yourname\Local Settings\Application Data\Microsoft<br>
\Silverlight\OutOfBrowser\NumberAsID.domain<br>
<br>
You'll find a metadata file in this location. This metadata file stores<br>
information such as where this OOB was downloaded. This affects both update<br>
and network. If you modify this file to specify another domain, update will<br>
no longer work, and the original domain does not contain a cross-domain<br>
policy file, you will no longer be able to access to the network resource.<br>
However, you can actually use it at your advantage to access network<br>
resources on another domain that does not have a cross-domain policy file.<br>
Please refer to the following instructions:<br>
<br>
Create your application so that it accesses a network resource on another<br>
domain that does not have a cross-domain policy file (such as www.bing.com).<br>
Install the OOB.<br>
Open the metadata file for the OOB application.<br>
Modify the FinalAppUri, OriginalSourceUri, and SourceDomain properties, so<br>
that they point to the external domain.<br>
Launch the OOB application, and you'll notice you're able to access the<br>
network resources on the other domain.<br>
<br>
However, you have to instruct your users to perform all those steps.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/dd833073(VS.95).aspx">http://msdn.microsoft.com/en-us/library/dd833073(VS.95).aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd833073(VS.95).aspx">http://msdn.microsoft.com/en-us/library/dd833073(VS.95).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
