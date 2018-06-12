# Export data from one excel sheet into a new sheet using task pane app
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Office
* Office Development
## Topics
* Task Pane App
## IsPublished
* True
## ModifiedDate
* 2013-06-11 01:49:57
## Description

<h1>How to Export data from one excel sheet into a new sheet from the task pane app (JSO15ExportCellData)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This demonstration shows how to export data from one Excel sheet into a new sheet from the task pane app. Customers
<span style="">should </span>input source sheet range and <span style="">destination sheet range in the UI of the task pane app. Then click Export button to process export task.
</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal"><span style="">Install Office 2013 RTM and Install Visual Studio 2012 RTM.
</span></p>
<p class="MsoNormal"><a href="http://www.microsoft.com/web/handlers/WebPI.ashx?command=GetInstallerRedirect&appid=OfficeToolsForVS2012GA"><span style="font-size:11.5pt; line-height:115%; color:#954F72">Download</span></a><span class="apple-converted-space"><span style="font-size:11.5pt; line-height:115%; color:black"><span style="">&nbsp;</span></span><span style="font-size:11.5pt; line-height:115%; color:black">and
 Install Microsoft Office Developer Tools for Visual Studio 2012-Preview 2.</span></span><span style="font-size:11.5pt; line-height:115%; color:black">
</span><span style=""></span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Step1.<span style="">&nbsp; </span>Open &quot;JSO15ExportCellData.sln&quot; to open the solution. Press &quot;F5&quot; on the keyboard to run the project. The form resembles the following:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84035/1/image.png" alt="" width="576" height="515" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Step2. Input the correct sheet range in the textbox and then click &quot;Export&quot; button to export data from one sheet to a new sheet. If export manipulation is successful, you will receive a message:
<span style="">&quot;<span style="color:red">Export data from one sheet to a new sheet successfully!</span>&quot;
</span>. The form resembles the following: </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84036/1/image.png" alt="" width="576" height="514" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Step3. Switch to sheet2 table, you will see the range data in sheet1 have been exported to sheet2.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84037/1/image.png" alt="" width="576" height="537" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style="">Step1. Create an App for Office 2013 project by using Visual Studio 2012 RTM.
</span></p>
<p class="MsoNormal"><span style="">Step2. Design the UI of the Task Pane by using the following HTML code snippets:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;body&gt;
    &lt;!-- Replace the following with your content --&gt;
    <div id="Content">
     &lt;label&gt;Source Sheet Range:&lt;/label&gt;&lt;input type=&quot;text&quot; id=&quot;sourceRange&quot;  style=&quot;width:150px;margin-left:15px&quot;/&gt;
        <br>
        &lt;label&gt;Exported Sheet Range:&lt;/label&gt;&lt;input type=&quot;text&quot; id=&quot;exportedRange&quot;  style=&quot;width:150px; margin-top:5px; margin-left:5px&quot;/&gt;
      <br>
        &lt;input type=&quot;button&quot; value=&quot;Export&quot; id=&quot;btnExport&quot; style=&quot;margin-top:10px&quot;/&gt;
         <div id="message"></div>
    </div>
 
&lt;/body&gt;

</pre>
<pre id="codePreview" class="html">
&lt;body&gt;
    &lt;!-- Replace the following with your content --&gt;
    <div id="Content">
     &lt;label&gt;Source Sheet Range:&lt;/label&gt;&lt;input type=&quot;text&quot; id=&quot;sourceRange&quot;  style=&quot;width:150px;margin-left:15px&quot;/&gt;
        <br>
        &lt;label&gt;Exported Sheet Range:&lt;/label&gt;&lt;input type=&quot;text&quot; id=&quot;exportedRange&quot;  style=&quot;width:150px; margin-top:5px; margin-left:5px&quot;/&gt;
      <br>
        &lt;input type=&quot;button&quot; value=&quot;Export&quot; id=&quot;btnExport&quot; style=&quot;margin-top:10px&quot;/&gt;
         <div id="message"></div>
    </div>
 
&lt;/body&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">Step3. Insert the event handle by using the following JavaScript code snippets:
</span></p>
<h2>More Information</h2>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span>Bindings.addFromNamedItemAsync method (apps for Office)
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/fp123590.aspx">http://msdn.microsoft.com/en-us/library/fp123590.aspx</a><span style="">
</span></p>
<p class="MsoNormal"><span style="">Binding.getDataAsync method (apps for Office)
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/fp161073.aspx">http://msdn.microsoft.com/en-us/library/fp161073.aspx</a>
</span></p>
<p class="MsoNormal"><span style="">Binding.setDataAsync method (apps for Office)
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/fp161120.aspx">http://msdn.microsoft.com/en-us/library/fp161120.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
