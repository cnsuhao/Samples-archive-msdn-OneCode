# How to check if a file or folder exists in local storage in Windows Store apps
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* file
* Files
* code snippets
## IsPublished
* True
## ModifiedDate
* 2014-06-15 08:27:22
## Description

<h1>How to check if a file or folder exists in the local storage in Windows Store apps</h1>
<h2>Introduction</h2>
<p>This code snippet will show you how to check if a file or folder exists in the local storage in Windows Store apps.</p>
<h2>Using the Code</h2>
<p>Use the <em>StorageFolder.TryGetItemAsync</em> method to try to get a file or folder by name, without the need to add error-catching logic to your code (like you would if you used
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefolder.getitemasync.aspx">
StorageFolder.GetItemAsync</a>). If the file or folder can't be found, <em>TryGetItemAsync</em> will return
<em>null</em> and will not raise an exception. Because the method returns <em>null</em>, you can use it to check if the specified file or folder exists.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span><span>C&#43;&#43;</span><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span><span class="hidden">js</span>
<pre class="hidden">// The following code snippet shows how to asynchronously check if a file or folder exists in the specific folder.
public async Task&lt;bool&gt; IfStorageItemExist(StorageFolder folder, string itemName)
{
    try
    {
        IStorageItem item = await folder.TryGetItemAsync(itemName);
        return (item != null);
    }
    catch (Exception ex)
    {
        // Should never get here
        return false;
    }
}
Usage:
       if(await IfStorageItemExist(folder, itemName))
       {
           // file/folder exists.
       }
       else
       {
           // file/folder does not exist.
       }
</pre>
<pre class="hidden">'  The following code snippet shows how to asynchronously check if a file or folder exists in the specific folder.
Public Function IfStorageItemExist(folder As StorageFolder, itemName As String) As Task(Of Boolean)
 Try
  Dim item As IStorageItem = Await folder.TryGetItemAsync(itemName)
  Return (item IsNot Nothing)
 Catch ex As Exception
  ' Should never get here
  Return False
 End Try
End Function
Usage:
If Await IfStorageItemExist(folder, itemName) Then
  ' file/folder exists.
Else
  ' file/folder does not exist.
End If
</pre>
<pre class="hidden">task&lt;bool&gt; IfStorageItemExist(StorageFolder^ folder, String^ itemName)
{
    return create_task(folder-&gt;TryGetItemAsync(itemName)).then([](task&lt;IStorageItem^&gt; taskResult)
    {
        try
        {
            auto result = taskResult.get();
            return (result != nullptr);
        }
        catch (COMException ^ex)
        {
          return false;
        }
    });
}
Usage:
    IfStorageItemExist(storageFolder, itemName).then([this](bool exists)
    {
       if(exists)
        {
           // file/folder exists
        }
       else
        {
           // file/folder does not exist
        }
    });
</pre>
<pre class="hidden">function getFile()
    {
        var filename = &quot;test.txt&quot;;
        // for the local storage of the application
        WinJS.Application.local.exists(filename).done(function (isExist) {
            if (isExist) {
                // file exists
                // print the message
                document.getElementById(&quot;output&quot;).innerText = &quot;file exists, the file name is: &quot; &#43; file.name;
            }
            else {
                // file does not exist
                // print the message
                document.getElementById(&quot;output&quot;).innerText = &quot;file does not exist!&quot;;
            }
        });
        // otherwise, we can call StorageFolder.tryGetItemAsync() method to check if the file exist
        var folderStorage = Windows.Storage.KnownFolders.picturesLibrary; // for test
        CheckFileExist(folderStorage, filename);
    }
    function CheckFileExist(folder,filename)
    {
        folder.tryGetItemAsync(filename).done(function (file) {
            if (file !== null) {
                // file exists
                // print the message               
            }
            else {
                // file does not exist
                // print the message
            }
        });
    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;The&nbsp;following&nbsp;code&nbsp;snippet&nbsp;shows&nbsp;how&nbsp;to&nbsp;asynchronously&nbsp;check&nbsp;if&nbsp;a&nbsp;file&nbsp;or&nbsp;folder&nbsp;exists&nbsp;in&nbsp;the&nbsp;specific&nbsp;folder.</span><span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;<span class="cs__keyword">bool</span>&gt;&nbsp;IfStorageItemExist(StorageFolder&nbsp;folder,&nbsp;<span class="cs__keyword">string</span>&nbsp;itemName)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IStorageItem&nbsp;item&nbsp;=&nbsp;await&nbsp;folder.TryGetItemAsync(itemName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;(item&nbsp;!=&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Should&nbsp;never&nbsp;get&nbsp;here</span><span class="cs__keyword">return</span><span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
Usage:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(await&nbsp;IfStorageItemExist(folder,&nbsp;itemName))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;file/folder&nbsp;exists.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;file/folder&nbsp;does&nbsp;not&nbsp;exist.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<p>Note: Before you can use Pictures Library, you must declare the necessary capabilities in your app manifest. To learn more about file access and capabilities, see
<a href="http://msdn.microsoft.com/en-US/library/windows/apps/hh967755">File access and permissions</a> and
<a href="http://msdn.microsoft.com/en-US/library/windows/apps/hh464936">Access to user resource using the Windows Runtime</a>.</p>
<h2>More Information</h2>
<ul>
<li><span style="font-size:10px">StorageFolder.TryGetItemAsync | tryGetItemAsync method</span>
</li></ul>
<ol>
</ol>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefolder.trygetitemasync.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefolder.trygetitemasync.aspx</a></p>
<ul>
<li><span style="font-size:10px">local.exists method</span> </li></ul>
<ol>
</ol>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh700817.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh700817.aspx</a></p>
<ul>
<li><span style="font-size:10px">File access and permissions in Windows Store apps</span>
</li></ul>
<ol>
</ol>
<p><a href="http://msdn.microsoft.com/en-US/library/windows/apps/hh967755">http://msdn.microsoft.com/en-US/library/windows/apps/hh967755</a></p>
