# How to export the distribution groups from Office 365 Exchange Online
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* O365
* distribution groups
## IsPublished
* True
## ModifiedDate
* 2014-04-24 02:48:33
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<h1>How to Export the Distribution Groups (CSO365ExportGroup)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Sometimes we need to export the distribution groups and their members, but Outlook Web App (OWA) doesn't provide the function. In this application, we will demonstrate how to export the Distribution Groups and their members.
</p>
<p class="MsoNormal">1. We get the members of the root group. </p>
<p class="MsoNormal">2. We export all the mailbox in the group. </p>
<p class="MsoNormal">3. We can choose to process the following up steps recursively for the nested groups.
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal">First, we use our account to connect the Exchange Online.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/113563/1/image.png" alt="" width="408" height="57" align="middle">
</span></p>
<p class="MsoNormal">Then, we need to input the distribution group address.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/113564/1/image.png" alt="" width="644" height="35" align="middle">
</span></p>
<p class="MsoNormal">And we also need to input the file path that we want to store the addresses.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/113565/1/image.png" alt="" width="638" height="28" align="middle">
</span></p>
<p class="MsoNormal">Following is the result:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/113566/1/image.png" alt="" width="641" height="151" align="middle">
</span></p>
<p class="MsoNormal">We can also find the file as the following:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/113567/1/image.png" alt="" width="1052" height="140" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Get the distribution group address</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
User need to input the distribution group address, and we will check if the address in a valid address.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private static String GetGroupAddress()
{
&nbsp;&nbsp;&nbsp; String pattern = @&quot;\w&#43;([-&#43;.]\w&#43;)*@\w&#43;([-.]\w&#43;)*\.\w&#43;([-.]\w&#43;)*&quot;;
&nbsp;&nbsp;&nbsp; Regex regex = new Regex(pattern);
&nbsp;&nbsp;&nbsp; do
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.Write(&quot;Please input the Distribution Group Address:&quot;);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; String address = Console.ReadLine();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (regex.IsMatch(address))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return address;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;The Email address is invaild.&quot;);
&nbsp;&nbsp;&nbsp; } while (true);
}

</pre>
<pre id="codePreview" class="csharp">
private static String GetGroupAddress()
{
&nbsp;&nbsp;&nbsp; String pattern = @&quot;\w&#43;([-&#43;.]\w&#43;)*@\w&#43;([-.]\w&#43;)*\.\w&#43;([-.]\w&#43;)*&quot;;
&nbsp;&nbsp;&nbsp; Regex regex = new Regex(pattern);
&nbsp;&nbsp;&nbsp; do
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.Write(&quot;Please input the Distribution Group Address:&quot;);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; String address = Console.ReadLine();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (regex.IsMatch(address))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return address;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;The Email address is invaild.&quot;);
&nbsp;&nbsp;&nbsp; } while (true);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Process recursively</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
If user needs recursion, and the member is group, we will process the method recursively.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
if (isRecursive & (member.MailboxType == MailboxType.ContactGroup || 
&nbsp;&nbsp;&nbsp;&nbsp;member.MailboxType == MailboxType.PublicGroup))
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(pad &#43; &quot;{0,-50}{1,-11}&quot;, member.Address, member.MailboxType);
&nbsp;&nbsp;&nbsp; ExportGroup(service, member, pad, isRecursive, writer);
}

</pre>
<pre id="codePreview" class="csharp">
if (isRecursive & (member.MailboxType == MailboxType.ContactGroup || 
&nbsp;&nbsp;&nbsp;&nbsp;member.MailboxType == MailboxType.PublicGroup))
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(pad &#43; &quot;{0,-50}{1,-11}&quot;, member.Address, member.MailboxType);
&nbsp;&nbsp;&nbsp; ExportGroup(service, member, pad, isRecursive, writer);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
3. Export the members</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
If user sets recursion, the method exports the mailbox addresses of the root group and the nested groups; or the method exports the mailbox and group addresses of the root group.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
else
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(pad &#43; &quot;{0,-50}{1,-11}&quot;, member.Address, member.MailboxType);
&nbsp;&nbsp;&nbsp; writer.WriteLine(&quot;\&quot;{0}\&quot;,\&quot;{1}\&quot;&quot;, groupAddress, member.Address);
}

</pre>
<pre id="codePreview" class="csharp">
else
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(pad &#43; &quot;{0,-50}{1,-11}&quot;, member.Address, member.MailboxType);
&nbsp;&nbsp;&nbsp; writer.WriteLine(&quot;\&quot;{0}\&quot;,\&quot;{1}\&quot;&quot;, groupAddress, member.Address);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx">EWS Managed API 2.0</a>
</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/hh532557(v=exchg.80).aspx">Expanding a distribution list by using the EWS Managed API</a></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
