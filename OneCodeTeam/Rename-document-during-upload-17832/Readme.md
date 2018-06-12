# Rename document during upload (VBSharePointRenameDocumentDuringUpload)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SharePoint
* Event receiver
* rename document
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:37:24
## Description

<h1><span style="">How to rename the document during upload </span>(<span style="">VBSharePointRenameDocumentDuringUpload</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">The sample code will show you how to rename the document using event receiver during upload. We mainly use SPFile.MoveTo method to rename the newly uploaded document. The &quot;MoveTo&quot; method renames the document by moving the file
 to a specified destination URL.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1: Open the VBSharePointRenameDocumentDuringUpload.sln, modify the &quot;Site URL&quot; to your own site.</p>
<p class="MsoNormal">Step 2: Right-click the solution then click &quot;Deploy&quot;.</p>
<p class="MsoNormal">Step 3: Open the &quot;Shared Documents&quot; or other Document Library to add a new document.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&nbsp;</span><span style="font-size:9.5pt; font-family:Consolas"> <img src="/site/view/file/61943/1/image.png" alt="" width="781" height="79" align="middle">
</span><span style="font-size:9.5pt; font-family:Consolas"><br>
</span>Try to upload a file, and you may find the file was renamed successfully.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><br>
<span style=""><img src="/site/view/file/61944/1/image.png" alt="" width="541" height="238" align="middle">
</span><br>
<span style=""><img src="/site/view/file/61945/1/image.png" alt="" width="675" height="76" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal">Step 4: Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1: Create a VB &quot;Empty SharePoint Project&quot; in Visual Studio 2010. Name it as &quot;VBSharePointRenameDocumentDuringUpload&quot;.</p>
<p class="MsoNormal">In the SharePoint Customization Wizard, choose Deploy as a farm solution. Click Finish.</p>
<p class="MsoNormal">Step 2: In the Solution Explorer, right-click the project. Select &quot;Add New Item&quot;, then add an &quot;Event Receiver&quot;: the type you should select &quot;List Item Events&quot; and the event source should be &quot;Document
 Library&quot; and select handle for adding event. </p>
<p class="MsoNormal">Step 3: First we need to set the value of EventFiringEnabled to false. Then get the document library in which the event occurred and get the new document's URL.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'Sets the value that indicates whether event firing is enabled to false
           EventFiringEnabled = False


           'This url should be like:sharepointlist/filename (for example: books/mybook.doc)
           Dim url As String = properties.AfterUrl

</pre>
<pre id="codePreview" class="vb">
'Sets the value that indicates whether event firing is enabled to false
           EventFiringEnabled = False


           'This url should be like:sharepointlist/filename (for example: books/mybook.doc)
           Dim url As String = properties.AfterUrl

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal">Then get the file which you just uploaded.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'Get the file
           Dim file As SPFile = properties.ListItem.File

</pre>
<pre id="codePreview" class="vb">
'Get the file
           Dim file As SPFile = properties.ListItem.File

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Step 4:<span style="font-size:9.5pt; font-family:Consolas"> </span><span style="">Rename the document by moving the file to a specified destination URL.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
newUrl = properties.ListTitle &#43; &quot;/&quot; & CleanupFileName(file.Name)
            'Rename the document by moving the file to a specified destination url
            file.MoveTo(newUrl, True)

</pre>
<pre id="codePreview" class="vb">
newUrl = properties.ListTitle &#43; &quot;/&quot; & CleanupFileName(file.Name)
            'Rename the document by moving the file to a specified destination url
            file.MoveTo(newUrl, True)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">The </span>CleanupFileName method is used to get the new file name.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Shared Function CleanupFileName(ByVal fileName As String) As String
        'Special Characters Not Allowed: ~ &quot; # % & * : &lt; &gt; ? / \ { | }      
        If Not String.IsNullOrEmpty(fileName) Then
            'Regex to Replace the Special Character
...
 End If

</pre>
<pre id="codePreview" class="vb">
Public Shared Function CleanupFileName(ByVal fileName As String) As String
        'Special Characters Not Allowed: ~ &quot; # % & * : &lt; &gt; ? / \ { | }      
        If Not String.IsNullOrEmpty(fileName) Then
            'Regex to Replace the Special Character
...
 End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:green"></span></p>
<p class="MsoNormal">Step 5: Open Elements.xml file and add following code to perform synchronization events:</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Synchronization&gt;Synchronous&lt;/Synchronization&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Synchronization&gt;Synchronous&lt;/Synchronization&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal">Step 6. Build the feature.</p>
<p class="MsoNormal">Step 7. Deploy.</p>
<h2>More Information<br>
<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">SPEventReceiverBase<span>.</span>EventFiringEnabled Property</span></h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.speventreceiverbase.eventfiringenabled.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.speventreceiverbase.eventfiringenabled.aspx</a><br>
<span style="">SPFile<span>.</span>MoveTo Method</span><span style="font-size:17.0pt; line-height:115%"><br>
</span><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spfile.moveto.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spfile.moveto.aspx</a><br style="">
<br style="">
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
