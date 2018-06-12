# How to use Azure Mobile Services to operate Table storage from Windows Store app
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Windows
* Windows 8
* Windows Azure Mobile Services
* Windows Store app Development
## Topics
* Azure
* WinRT
## IsPublished
* True
## ModifiedDate
* 2015-02-09 06:10:08
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1>How to use Azure Mobile Services to operate Table storage from Windows Store app</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample shows how to operate Table storage with Windows Azure mobile service.</p>
<h2>Building the Sample</h2>
<p class="Normal"><span>To build t</span>his sample<span> you</span> need <span>
to </span>install&nbsp;<span style="font-size:10px">Windows Azure Mobile Services:</span></p>
<p class="Normal"><a href="http://azure.microsoft.com/en-us/develop/mobile/developer-tools/" target="_blank">http://azure.microsoft.com/en-us/develop/mobile/developer-tools/</a></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">To run this sample</p>
<p class="MsoListParagraphCxSpFirst" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In Azure portal create a new Azure mobile service:</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span><img src="/site/view/file/109337/1/image.png" alt="" width="576" height="247" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt">Choose any database as you like, because we don't use it in our sample:</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span><img src="/site/view/file/109338/1/image.png" alt="" width="434" height="207" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After you create it, go to the DATA tab and create a new table named ShortMessage.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><em>Note: Please make sure your table name is equal to your entity class name in</em><em><span> default</span>.</em><em><span>js</span>.
</em></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<em><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></em>Select the Table you create and click SCRIPT tab.<em> </em>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span><img src="/site/view/file/109339/1/image.png" alt="" width="352" height="106" align="middle">
</span><em>&nbsp;</em></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Copy the server side script to the specific operation, and change the storage account name and account key to your own. If you haven't create a<span>n</span> Azure storage yet, please refer to :</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><a href="http://www.windowsazure.com/en-us/manage/services/storage/how-to-create-a-storage-account/">How To Create a Storage Account</a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span><img src="/site/view/file/109340/1/image.png" alt="" width="576" height="437" align="middle">
</span><em>&nbsp;</em></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Change the Mobile service Name and Application key to your own in defalt.js file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">var client = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;https://[Your Azure mobile service name].azure-mobile.net/&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;[You Azure mobile service application key]&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );</pre>
<pre id="codePreview" class="js">var client = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;https://[Your Azure mobile service name].azure-mobile.net/&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;[You Azure mobile service application key]&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; );</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:18.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Press </span>Ctrl&#43;F5 <span>to </span>run the sample.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Input a Name and a Message into the textbox and click leave message button.</p>
<p class="MsoNormal"><span><img src="/site/view/file/109341/1/image.png" alt="" width="576" height="256" align="middle">
</span></p>
<p class="MsoListParagraphCxSpFirst" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click the check box will remove the item in listview, and change the 'IsRead' property to true in azure table storage.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>9.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click the item in listview then right click in other place, you can
<span>see </span>this app bar at the bottom.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt"><span><img src="/site/view/file/109342/1/image.png" alt="" width="156" height="83" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>10.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span>Delete button will delete the record in your storage.</p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a new <span class="SpellE">javascript</span> blank <span>
Windows S</span>tore app named <span class="SpellE">JSAzureMobileServiceWithTableStorage</span>.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Make sure you have d</span>o<span>ne</span> the 1-5 steps in
<span class="GramE"><span>Running</span></span> the sample<span> section</span>.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:18.0pt; text-indent:5.0pt">
<span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create the UI:</p>
<h3>Default.html</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;!DOCTYPE html&gt;
&lt;html&gt;
&lt;head&gt;
    &lt;meta charset=&quot;utf-8&quot; /&gt;
    &lt;title&gt;JSAzureMobileServiceWithTableStorage&lt;/title&gt;

    &lt;!-- WinJS references --&gt;
    &lt;link href=&quot;//Microsoft.WinJS.1.0/css/ui-dark.css&quot; rel=&quot;stylesheet&quot; /&gt;
    &lt;script src=&quot;//Microsoft.WinJS.1.0/js/base.js&quot;&gt;&lt;/script&gt;&lt;script src=&quot;//Microsoft.WinJS.1.0/js/ui.js&quot;&gt;&lt;/script&gt;
    &lt;script type=&quot;text/javascript&quot; src=&quot;/MobileServicesJavaScriptClient/MobileServices.js&quot;&gt;&lt;/script&gt;

    &lt;!-- JSAzureMobileServiceWithTableStorage references --&gt;
    &lt;link href=&quot;/css/default.css&quot; rel=&quot;stylesheet&quot; /&gt;
    &lt;script src=&quot;/js/default.js&quot;&gt;&lt;/script&gt;
    &lt;script src=&quot;js/data.js&quot;&gt;&lt;/script&gt;
 
&lt;/head&gt;
&lt;body&gt;
    &lt;div class=&quot;custom&quot;&gt;
    &lt;div&gt;&lt;label id=&quot;lbstate&quot;&gt;&lt;/label&gt;&lt;/div&gt;&lt;br/&gt;
    &lt;div &gt;&lt;span&gt;Name:&lt;/span&gt;&lt;/div&gt;
    &lt;input  type=&quot;text&quot; id=&quot;txtName&quot; /&gt;&lt;br /&gt;
    &lt;div &gt;&lt;span&gt;Short Message&lt;/span&gt;&lt;/div&gt;
    &lt;div &gt;&lt;input  type=&quot;text&quot; id=&quot;txtMessage&quot; /&gt;&lt;/div&gt;&lt;br /&gt;&lt;br/&gt;
    &lt;button  id=&quot;btnsave&quot; &gt;Leave Message&lt;/button&gt;
    &lt;div&gt;&lt;span&gt;The message you haven't read:&lt;/span&gt;&lt;/div&gt;
   
  &lt;div id=&quot;TemplateItem&quot; data-win-control=&quot;WinJS.Binding.Template&quot;&gt;
        &lt;div  class=&quot;myItem&quot;&gt;
            &lt;input type=&quot;checkbox&quot; style=&quot;-ms-grid-row:auto;margin-top:10px&quot; data-win-bind=&quot;checked: complete; dataContext: this&quot; /&gt;
            &lt;h3 style=&quot;-ms-grid-column:2; -ms-grid-row:1;&quot;&gt;Name:&lt;/h3&gt;
            &lt;h3 style=&quot;-ms-grid-column:2; -ms-grid-row:1;margin-left:50px&quot;  data-win-bind=&quot;innerText: Name&quot;&gt;&lt;/h3&gt;
            &lt;h3 style=&quot;-ms-grid-column:2; -ms-grid-row:2;&quot;&gt;Message:&lt;/h3&gt;
             &lt;h3  style=&quot;-ms-grid-column:2; -ms-grid-row:2;margin-left:70px&quot; data-win-bind=&quot;innerText: Message&quot;&gt;
            &lt;/h3&gt;
        &lt;/div&gt;
    &lt;/div&gt;
    &lt;div id=&quot;listItems&quot; 
        class=&quot;win-selectionstylefilled&quot;
        data-win-control=&quot;WinJS.UI.ListView&quot;
        data-win-options=&quot;{ selectionMode: 'single',itemTemplate: TemplateItem, layout: {type: WinJS.UI.ListLayout} }&quot;&gt;
    &lt;/div&gt;

    &lt;div id=&quot;createAppBar&quot; data-win-control=&quot;WinJS.UI.AppBar&quot; data-win-options=&quot;&quot;&gt;
        &lt;button data-win-control=&quot;WinJS.UI.AppBarCommand&quot; data-win-options=&quot;{id:'cmdDelete',label:'delete',icon:'clear',section:'selection',tooltip:'delete item'}&quot;&gt;
        &lt;/button&gt;
    &lt;/div&gt;
&lt;/div&gt;
&lt;/body&gt;
&lt;/html&gt;
</pre>
<div class="preview">
<pre class="html"><span class="html__doctype">&lt;!DOCTYPE&nbsp;html&gt;</span>&nbsp;
<span class="html__tag_start">&lt;html</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;head</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;meta</span>&nbsp;<span class="html__attr_name">charset</span>=<span class="html__attr_value">&quot;utf-8&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;title</span><span class="html__tag_start">&gt;</span>JSAzureMobileServiceWithTableStorage<span class="html__tag_end">&lt;/title&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--&nbsp;WinJS&nbsp;references&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;link</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;//Microsoft.WinJS.1.0/css/ui-dark.css&quot;</span>&nbsp;<span class="html__attr_name">rel</span>=<span class="html__attr_value">&quot;stylesheet&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;//Microsoft.WinJS.1.0/js/base.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span><span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;//Microsoft.WinJS.1.0/js/ui.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;/MobileServicesJavaScriptClient/MobileServices.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--&nbsp;JSAzureMobileServiceWithTableStorage&nbsp;references&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;link</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;/css/default.css&quot;</span>&nbsp;<span class="html__attr_name">rel</span>=<span class="html__attr_value">&quot;stylesheet&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;/js/default.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;js/data.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;
<span class="html__tag_end">&lt;/head&gt;</span>&nbsp;
<span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;custom&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;lbstate&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/label&gt;</span><span class="html__tag_end">&lt;/div&gt;</span><span class="html__tag_start">&lt;br</span><span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;span</span><span class="html__tag_start">&gt;</span>Name:<span class="html__tag_end">&lt;/span&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;txtName&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span><span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;span</span><span class="html__tag_start">&gt;</span>Short&nbsp;Message<span class="html__tag_end">&lt;/span&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;input</span>&nbsp;&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;txtMessage&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span><span class="html__tag_end">&lt;/div&gt;</span><span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span><span class="html__tag_start">&lt;br</span><span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;btnsave&quot;</span>&nbsp;<span class="html__tag_start">&gt;</span>Leave&nbsp;Message<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;span</span><span class="html__tag_start">&gt;</span>The&nbsp;message&nbsp;you&nbsp;haven't&nbsp;read:<span class="html__tag_end">&lt;/span&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;TemplateItem&quot;</span>&nbsp;<span class="html__attr_name">data-win-control</span>=<span class="html__attr_value">&quot;WinJS.Binding.Template&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;myItem&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;checkbox&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;-ms-grid-row:auto;margin-top:10px&quot;</span>&nbsp;<span class="html__attr_name">data-win-bind</span>=<span class="html__attr_value">&quot;checked:&nbsp;complete;&nbsp;dataContext:&nbsp;this&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h3</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;-ms-grid-column:2;&nbsp;-ms-grid-row:1;&quot;</span><span class="html__tag_start">&gt;</span>Name:<span class="html__tag_end">&lt;/h3&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h3</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;-ms-grid-column:2;&nbsp;-ms-grid-row:1;margin-left:50px&quot;</span>&nbsp;&nbsp;<span class="html__attr_name">data-win-bind</span>=<span class="html__attr_value">&quot;innerText:&nbsp;Name&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/h3&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h3</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;-ms-grid-column:2;&nbsp;-ms-grid-row:2;&quot;</span><span class="html__tag_start">&gt;</span>Message:<span class="html__tag_end">&lt;/h3&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h3</span>&nbsp;&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;-ms-grid-column:2;&nbsp;-ms-grid-row:2;margin-left:70px&quot;</span>&nbsp;<span class="html__attr_name">data-win-bind</span>=<span class="html__attr_value">&quot;innerText:&nbsp;Message&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/h3&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;listItems&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;win-selectionstylefilled&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">data-win-control</span>=<span class="html__attr_value">&quot;WinJS.UI.ListView&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">data-win-options</span>=<span class="html__attr_value">&quot;{&nbsp;selectionMode:&nbsp;'single',itemTemplate:&nbsp;TemplateItem,&nbsp;layout:&nbsp;{type:&nbsp;WinJS.UI.ListLayout}&nbsp;}&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;createAppBar&quot;</span>&nbsp;<span class="html__attr_name">data-win-control</span>=<span class="html__attr_value">&quot;WinJS.UI.AppBar&quot;</span>&nbsp;<span class="html__attr_name">data-win-options</span>=<span class="html__attr_value">&quot;&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">data-win-control</span>=<span class="html__attr_value">&quot;WinJS.UI.AppBarCommand&quot;</span>&nbsp;<span class="html__attr_name">data-win-options</span>=<span class="html__attr_value">&quot;{id:'cmdDelete',label:'delete',icon:'clear',section:'selection',tooltip:'delete&nbsp;item'}&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/html&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<p class="MsoNormal">5. Add reference to Windows Azure Mobile Services JavaScript Client.</p>
<p class="MsoNormal">6. Add several codes to operate the Mobile Service, please refer to default.js for details.</p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/jj554226">http://msdn.microsoft.com/en-us/library/windowsazure/jj554226</a></p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
