# Set IIS Web Virtual Directory Properties (CSSetIISWebVirtualDirProperties)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* IIS
## Topics
* Virtual Directory
## IsPublished
* True
## ModifiedDate
* 2012-04-07 02:04:55
## Description

<h1>Set IIS Web Virtual Directory Properties (CSSetIISWebVirtualDirProperties)</h1>
<h2>Introduction</h2>
<p>This sample application demonstrates how to set the Application name and Path on Virtual Directory tab (Properties) in IIS 6 programmatically. We are using here System.DirectoryServices namespace. This namespace is used to manage Directory Services using
 ADSI, Active Directory Services Interface.&nbsp; This ADSI Interface has the interfaces for IIS metabase.</p>
<p>However, you cannot perform the following tasks unless you are using Windows XP Professional with Service Pack 2 or Windows Server 2003 with Service Pack 1. Doing so results in errors like &quot;The directory cannot report the number of properties&quot;:</p>
<p>Enumerating through a collection of properties</p>
<p>Setting binary properties</p>
<p>Adding entries to a property collection</p>
<p>Deleting entries from a property collection</p>
<p>Moving or copying metabase nodes</p>
<p>Configuring MIME types or IP security properties</p>
<h2>Running the Sample</h2>
<p>You can execute this sample by creating the exe via Visual Studio. Before calling this application, you must have IIS 6.0 installed on your machine. After you execute this program you should see that there is a Virtual directory created with the name you
 specified.</p>
<p>This sample concentrates on how to provide the Application Name however it is needed to set the Path name of the virtual directory under IIS.</p>
<h2>Using the Code</h2>
<p>You can use this project to set the Application name for a virtual directory in IIS. This application demonstrates how to use System.DirectoryServices to use ADSI interface for IIS. Once we bind to the root of the IIS metabase, we create the IIsWebVirtualDir
 schema object. Once we get this object we set the Path and the Application&rsquo;s friendly name.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">string siteName = &quot;HelloWorldSite&quot;;
string physicalPath = @&quot;C:\HelloWorldSite&quot;;
 
//Using DirectoryEntry bind to the Root of the IIS metabase.
using (DirectoryEntry rootEntry = new DirectoryEntry(&quot;IIS://localhost/W3SVC/1/Root&quot;))
{
    //Create your Web Virtual Directory
    using (DirectoryEntry testDirectoryEntry = rootEntry.Children.Add(siteName, &quot;IIsWebVirtualDir&quot;))
    {
        //Closing &amp; Disposing DirectoryEntry object
        rootEntry.Close();
 
        //Give the physical path for the Virtual Directory
        testDirectoryEntry.Properties[&quot;Path&quot;][0] = physicalPath;
 
        //Save back the changes back to the IIS metabase
        testDirectoryEntry.CommitChanges();
 
        //We are going to set the Name of the Virtual Directory
        //By setting it's AppFriendlyName property
        testDirectoryEntry.Properties[&quot;AppFriendlyName&quot;][0] = siteName;
 
        //Save the changes back to the IIS metabase
        testDirectoryEntry.CommitChanges();
 
        //Do a close on the DirectoryEntry object
        testDirectoryEntry.Close();
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">string</span>&nbsp;siteName&nbsp;=&nbsp;<span class="cs__string">&quot;HelloWorldSite&quot;</span>;&nbsp;
<span class="cs__keyword">string</span>&nbsp;physicalPath&nbsp;=&nbsp;@<span class="cs__string">&quot;C:\HelloWorldSite&quot;</span>;&nbsp;
&nbsp;&nbsp;
<span class="cs__com">//Using&nbsp;DirectoryEntry&nbsp;bind&nbsp;to&nbsp;the&nbsp;Root&nbsp;of&nbsp;the&nbsp;IIS&nbsp;metabase.</span>&nbsp;
<span class="cs__keyword">using</span>&nbsp;(DirectoryEntry&nbsp;rootEntry&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DirectoryEntry(<span class="cs__string">&quot;IIS://localhost/W3SVC/1/Root&quot;</span>))&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;your&nbsp;Web&nbsp;Virtual&nbsp;Directory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(DirectoryEntry&nbsp;testDirectoryEntry&nbsp;=&nbsp;rootEntry.Children.Add(siteName,&nbsp;<span class="cs__string">&quot;IIsWebVirtualDir&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Closing&nbsp;&amp;&nbsp;Disposing&nbsp;DirectoryEntry&nbsp;object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rootEntry.Close();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Give&nbsp;the&nbsp;physical&nbsp;path&nbsp;for&nbsp;the&nbsp;Virtual&nbsp;Directory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;testDirectoryEntry.Properties[<span class="cs__string">&quot;Path&quot;</span>][<span class="cs__number">0</span>]&nbsp;=&nbsp;physicalPath;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;back&nbsp;the&nbsp;changes&nbsp;back&nbsp;to&nbsp;the&nbsp;IIS&nbsp;metabase</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;testDirectoryEntry.CommitChanges();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//We&nbsp;are&nbsp;going&nbsp;to&nbsp;set&nbsp;the&nbsp;Name&nbsp;of&nbsp;the&nbsp;Virtual&nbsp;Directory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//By&nbsp;setting&nbsp;it's&nbsp;AppFriendlyName&nbsp;property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;testDirectoryEntry.Properties[<span class="cs__string">&quot;AppFriendlyName&quot;</span>][<span class="cs__number">0</span>]&nbsp;=&nbsp;siteName;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;the&nbsp;changes&nbsp;back&nbsp;to&nbsp;the&nbsp;IIS&nbsp;metabase</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;testDirectoryEntry.CommitChanges();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Do&nbsp;a&nbsp;close&nbsp;on&nbsp;the&nbsp;DirectoryEntry&nbsp;object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;testDirectoryEntry.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h2>More Information</h2>
<p>For more information on System.DirectoryServices for IIS Administrator, visit <a href="http://msdn.microsoft.com/en-us/library/ms525791(VS.90).aspx">
http://msdn.microsoft.com/en-us/library/ms525791(VS.90).aspx</a></p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
