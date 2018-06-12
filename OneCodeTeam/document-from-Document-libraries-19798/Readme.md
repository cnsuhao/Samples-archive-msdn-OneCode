# Download document from Document libraries (VBSharePointDownloadDocument)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SharePoint
* Download
## IsPublished
* True
## ModifiedDate
* 2012-12-03 11:14:04
## Description

<h1>How to d<span style="">ownload the documents from SharePoint document libraries
</span>&nbsp;(VBSharePointDownloadDocument)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">This demo will demonstrate how to download the documents from SharePoint document libraries across site collection in an easy fashion. Our implementation ideas are as follows: add the OOTB document library name to a list
 if document library in this list will not be downloaded. According to the specified URL circulation Site list, obtain the document libraries and compared with the OOTB document library's name list; if the document library's name does not exist in the OOTB
 list, download the document library. </span></p>
<p class="MsoNormal" style="margin-top:10.0pt; margin-right:0in; margin-bottom:0in; margin-left:0in; margin-bottom:.0001pt">
<b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Running the Sample
</span></b></p>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the VBSharePointDownloadDocument.sln file. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Open the Module1.vb file to modify the Site URL and the </span>
<span style="font-size:9.5pt; font-family:Consolas">DownloadPath(For example: &quot;C:\MyDownloadFolder\&quot;)</span><span style="">. The Site URL is the URL of SharePoint Site which you want to download. After that you can press &quot;Ctrl&#43;F5&quot; to run
 the sample.<br>
<span style=""><img src="/site/view/file/71831/1/image.png" alt="" width="674" height="328" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">View the downloaded documents in the specified download directory. Download catalog in the sample which called MyDownloadFolder. The result will be as follows:<br>
<span style=""><img src="/site/view/file/71832/1/image.png" alt="" width="698" height="272" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 3: Validation is completed. </span></p>
<p class="MsoNormal" style="margin-top:10.0pt; margin-right:0in; margin-bottom:0in; margin-left:0in; margin-bottom:.0001pt">
<b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Using the Code
</span></b></p>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Create a VB &quot;Console Application&quot; in Visual Studio 2010 and named it as &quot;VBSharePointDownloadDocument&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal"><span style="">Step 2: Add the following assembly reference:<br>
<span style="color:black">Project-&gt; References -&gt;…</span></span> <span style="color:black">
Microsoft.</span><span style="">SharePoint.dll </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 3: Add the following namespace in Module1.vb. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports Microsoft.SharePoint
Imports System.IO

</pre>
<pre id="codePreview" class="vb">
Imports Microsoft.SharePoint
Imports System.IO

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 4: Specify the URL and </span><span style="font-size:9.5pt; font-family:Consolas">DownloadPath</span><span style="">.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Path to download the files
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strDownloadPath As String = &quot;C:\MyDownloadFolder\&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim url As String = &quot;http://Site_Url&quot;

</pre>
<pre id="codePreview" class="vb">
' Path to download the files
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strDownloadPath As String = &quot;C:\MyDownloadFolder\&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim url As String = &quot;http://Site_Url&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Create a method to traverse all ListItems and download SPFile.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Traverse all ListItems and download
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;list&quot;&gt;List of operation&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;path&quot;&gt;Storage path&lt;/param&gt;
&nbsp;&nbsp; Private Sub TraverseAllListItems(list As SPList, path As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim qry As New SPQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; qry.ViewAttributes = &quot;Scope=&quot;&quot;Recursive&quot;&quot;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ic As SPListItemCollection = list.GetItems(qry)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each subitem As SPListItem In ic


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim itemurl As String = subitem.Url
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim index As Integer = itemurl.IndexOf(&quot;/&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim subpath As String = itemurl.Substring(index &#43; 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim finalpath As String = path & subpath
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; finalpath = finalpath.Replace(subitem.Name, &quot;&quot;)
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;finalpath = finalpath.Replace(&quot;/&quot;, &quot;\&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(finalpath)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Directory.CreateDirectory(finalpath)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim binFile As Byte() = subitem.File.OpenBinary()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim fstream As System.IO.FileStream = System.IO.File.Create((finalpath & &quot;\&quot;) &#43; subitem.Name)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fstream.Write(binFile, 0, binFile.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fstream.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch e As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(e.Message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
 &nbsp;&nbsp;End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Traverse all ListItems and download
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;list&quot;&gt;List of operation&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;path&quot;&gt;Storage path&lt;/param&gt;
&nbsp;&nbsp; Private Sub TraverseAllListItems(list As SPList, path As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim qry As New SPQuery()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; qry.ViewAttributes = &quot;Scope=&quot;&quot;Recursive&quot;&quot;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ic As SPListItemCollection = list.GetItems(qry)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each subitem As SPListItem In ic


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim itemurl As String = subitem.Url
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim index As Integer = itemurl.IndexOf(&quot;/&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim subpath As String = itemurl.Substring(index &#43; 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim finalpath As String = path & subpath
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; finalpath = finalpath.Replace(subitem.Name, &quot;&quot;)
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;finalpath = finalpath.Replace(&quot;/&quot;, &quot;\&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(finalpath)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Directory.CreateDirectory(finalpath)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim binFile As Byte() = subitem.File.OpenBinary()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim fstream As System.IO.FileStream = System.IO.File.Create((finalpath & &quot;\&quot;) &#43; subitem.Name)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fstream.Write(binFile, 0, binFile.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fstream.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch e As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(e.Message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
 &nbsp;&nbsp;End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:green"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Create a method to obtain the specified URL to download the document library.<span style="">&nbsp;
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Add the OOTB document library name to a list, document library in this list will not be downloaded.
&nbsp;&nbsp; ''' According to the specified url circulation Site list, and then obtain the document
&nbsp;&nbsp; ''' library and compared with the OOTB document libraries's name list;
&nbsp;&nbsp; ''' If the document library's name does not exist in the OOTB list, download the document library.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;siteURL&quot;&gt;Site URL&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;sitepath&quot;&gt;Site Path&lt;/param&gt;
&nbsp;&nbsp; Private Sub DownloadDocs(siteURL As String, sitepath As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'List of OOTB document libraries - These doc libraries will not be downloaded
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ootbLib As New List(Of String)()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Converted Forms&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Form Templates&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Images&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;List Template Gallery&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Master Page Gallery&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Pages&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Reporting Templates&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Site Collection Documents&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Site Collection Images&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Site Template Gallery&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Style Library&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Web Part Gallery&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' open site
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using oSite As New SPSite(siteURL)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' open web
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using oWeb As SPWeb = oSite.OpenWeb()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' loop site lists
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each list As SPList In oWeb.Lists
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' storage path
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim actpath As String = (sitepath & &quot;\&quot;) &#43; list.Title & &quot;\&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' obtain the document library by list.BaseType
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If list.BaseType = SPBaseType.DocumentLibrary Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'determine whether the document library is OOTB document library or not
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not ootbLib.Exists(Function(p As String) p.Trim() = list.Title) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Downloading from Library ::&quot; &#43; list.Title)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Directory.CreateDirectory(actpath)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TraverseAllListItems(list, actpath)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Add the OOTB document library name to a list, document library in this list will not be downloaded.
&nbsp;&nbsp; ''' According to the specified url circulation Site list, and then obtain the document
&nbsp;&nbsp; ''' library and compared with the OOTB document libraries's name list;
&nbsp;&nbsp; ''' If the document library's name does not exist in the OOTB list, download the document library.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;siteURL&quot;&gt;Site URL&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;sitepath&quot;&gt;Site Path&lt;/param&gt;
&nbsp;&nbsp; Private Sub DownloadDocs(siteURL As String, sitepath As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'List of OOTB document libraries - These doc libraries will not be downloaded
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ootbLib As New List(Of String)()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Converted Forms&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Form Templates&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Images&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;List Template Gallery&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Master Page Gallery&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Pages&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Reporting Templates&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Site Collection Documents&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Site Collection Images&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Site Template Gallery&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Style Library&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ootbLib.Add(&quot;Web Part Gallery&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' open site
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using oSite As New SPSite(siteURL)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' open web
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using oWeb As SPWeb = oSite.OpenWeb()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' loop site lists
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each list As SPList In oWeb.Lists
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' storage path
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim actpath As String = (sitepath & &quot;\&quot;) &#43; list.Title & &quot;\&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' obtain the document library by list.BaseType
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If list.BaseType = SPBaseType.DocumentLibrary Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'determine whether the document library is OOTB document library or not
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not ootbLib.Exists(Function(p As String) p.Trim() = list.Title) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Downloading from Library ::&quot; &#43; list.Title)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Directory.CreateDirectory(actpath)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TraverseAllListItems(list, actpath)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Note that sample is based on the site URL and document's </span><span style="color:black">download path
</span><span style="">to download. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Sub Main()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Path to download the files
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strDownloadPath As String = &quot;C:\MyDownloadFolder\&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim url As String = &quot;http://Site_Url&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using oSiteCollection As New SPSite(url)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim collWebsites As SPWebCollection = oSiteCollection.AllWebs
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Websites Count: {0}&quot;, collWebsites.Count)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot; &quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rootwebtitle As String = oSiteCollection.RootWeb.Title
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each oWebsite As SPWeb In collWebsites
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Site : &quot; &#43; oWebsite.Title)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Path to download the files
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim websiteurl As String = oWebsite.Url
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim framedUrl As String = websiteurl.Replace(oSiteCollection.Url, &quot;&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim path As String = strDownloadPath & &quot;\&quot; & rootwebtitle & framedUrl.Replace(&quot;/&quot;c, &quot;\&quot;c)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Directory.CreateDirectory(path)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DownloadDocs(oWebsite.Url, path)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; oWebsite.Dispose()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;--------------------&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Please click enter to exit&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.ReadLine()
&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
Sub Main()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Path to download the files
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strDownloadPath As String = &quot;C:\MyDownloadFolder\&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim url As String = &quot;http://Site_Url&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using oSiteCollection As New SPSite(url)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim collWebsites As SPWebCollection = oSiteCollection.AllWebs
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Websites Count: {0}&quot;, collWebsites.Count)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot; &quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rootwebtitle As String = oSiteCollection.RootWeb.Title
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each oWebsite As SPWeb In collWebsites
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Site : &quot; &#43; oWebsite.Title)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Path to download the files
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim websiteurl As String = oWebsite.Url
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim framedUrl As String = websiteurl.Replace(oSiteCollection.Url, &quot;&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim path As String = strDownloadPath & &quot;\&quot; & rootwebtitle & framedUrl.Replace(&quot;/&quot;c, &quot;\&quot;c)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Directory.CreateDirectory(path)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DownloadDocs(oWebsite.Url, path)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; oWebsite.Dispose()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;--------------------&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Please click enter to exit&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.ReadLine()
&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style="">Step 6: You can debug and test it.
</span></p>
<h2>More Information</h2>
<p class="MsoNormal"><span class="apple-style-span"><span style="background:white">List.Exists Method</span><br>
<a href="http://technet.microsoft.com/en-us/magazine/bfed8bca(VS.80).aspx">http://technet.microsoft.com/en-us/magazine/bfed8bca(VS.80).aspx</a></span><span style=""><br>
List<span>&lt;</span><span class="typeparameter"><span>T</span></span><span>&gt;</span><span>.</span>Exists Method<br>
<a href="http://msdn.microsoft.com/en-us/library/bfed8bca.aspx#Y900">http://msdn.microsoft.com/en-us/library/bfed8bca.aspx#Y900</a><br>
Directory.CreateDirectory Method (String)<br>
</span><a href="http://msdn.microsoft.com/en-us/library/54a0at6s.aspx">http://msdn.microsoft.com/en-us/library/54a0at6s.aspx</a><br>
FileStream Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.io.filestream.aspx">http://msdn.microsoft.com/en-us/library/system.io.filestream.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
