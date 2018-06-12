# Add new DropDownList option
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
* DropDownList
## IsPublished
* True
## ModifiedDate
* 2014-03-03 10:37:36
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b><span style="font-size:14.0pt; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Add a new item to a DropDownList</span></b>(<b style=""><span style="font-size:14.0pt; font-family:Consolas">JSASPNETUserConsent</span></b>)</p>
<h2>Introduction </h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">This project uses three popular methods to display a popup message for asking user whether or not to add a new item to a DropDownList. They all happen at client side, and do not postback. They are javascript's native confirm() function,<span style="">&nbsp;
</span>AJAX control toolkit's ModalPopupExtender, and jQuery UI's Dialog. </span>
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the JSASPNETUserConsent .sln. Enter something in the text box, for example, &quot;new item1&quot;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/109897/1/image.png" alt="" width="809" height="83" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: </span><span style="">&nbsp;</span>Click &quot;Add by JavaScript's confirm()' button, you can see new item1 is added to top of the DropDownList.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/109898/1/image.png" alt="" width="851" height="110" align="middle">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step </span>3<span style="">:</span> Enter something in the text box, for example, &quot;new item2&quot;</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step </span>4<span style="">:</span> Click &quot;Add by ModalPopupExtender&quot; button, you can see new item2 is added to top of the DropDownList.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&nbsp;&nbsp; </span><span style=""><img src="/site/view/file/109899/1/image.png" alt="" width="835" height="117" align="middle">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step </span>5<span style="">:</span> Enter something in the text box, for example, &quot;new item3&quot;</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step </span>6<span style="">:</span> Click &quot;Add by jQuery UI's Dialog&quot; button, you can see new item2 is added to top of the DropDownList.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/109900/1/image.png" alt="" width="841" height="113" align="middle">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">If you do not type anything in the text box, then after you click OK<span style="">&nbsp;
</span>it gives you message of &quot;New item must not be empty.&quot;</span><span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/109901/1/image.png" alt="" width="687" height="281" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 7: Validation finished.</span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Create a Empty &quot;ASP.NET Web Application&quot; in Visual Studio /Visual Web Developer. Name it as &quot;JSASPNETUserConsent &quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Add a Web Form page in the project.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3. Install AJAX Control Toolkit. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step4. At &lt;head&gt; part, add jQuery's and jQuery UI's reference from Microsoft CDN, something like
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;script type=&quot;text/javascript&quot; src=&quot;http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.4.4.js&quot;&gt;&lt;/script&gt;&lt;script type=&quot;text/javascript&quot; src=&quot;http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.7/jquery-ui.js&quot;&gt;&lt;/script&gt;
  &lt;link type=&quot;text/css&quot; rel=&quot;Stylesheet&quot; href=&quot;http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.7/themes/redmond/jquery-ui.css&quot; /&gt; 

</pre>
<pre id="codePreview" class="html">
&lt;script type=&quot;text/javascript&quot; src=&quot;http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.4.4.js&quot;&gt;&lt;/script&gt;&lt;script type=&quot;text/javascript&quot; src=&quot;http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.7/jquery-ui.js&quot;&gt;&lt;/script&gt;
  &lt;link type=&quot;text/css&quot; rel=&quot;Stylesheet&quot; href=&quot;http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.7/themes/redmond/jquery-ui.css&quot; /&gt; 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step5. Add a DropDownList Control, a TextBox Control, three Button Controls, a Panel Control, a ModalPopupExtender.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step6. In that Panel Control, add some texts and 2 Button Controls for ModalPopupExtender OnOkScript=&quot;add_top()&quot; calls a javascript function, which is explained later.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step7. Add 3 javascript functions to assist the code. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
function confirmation() {


               if (confirm('Add new item to the DropDownList?')) {
                   add_top();
               }


               return false;
           }

</pre>
<pre id="codePreview" class="js">
function confirmation() {


               if (confirm('Add new item to the DropDownList?')) {
                   add_top();
               }


               return false;
           }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span>It confirms whether or not to add the text supplied in the text box to the DropDownList. If &quot;OK&quot;, then calls add_top() to add it. If &quot;Cancel&quot;, then do nothing.<span style="">&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span>NOTE: return false; must be specified to cancel the button's Postback.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
function add_top() {
               var item = document.getElementById('newitem').value;


               if (!item) {
                   alert(&quot;New item must not be empty.&quot;);
                   return false;
               }


               var ddl = document.getElementById('ddl');
               var option = document.createElement('option');


               option.text = option.value = item;
               ddl.add(option, ddl.options[0] /* IE 7 & below, 0 */);
               ddl.selectedIndex = 0;
           }

</pre>
<pre id="codePreview" class="js">
function add_top() {
               var item = document.getElementById('newitem').value;


               if (!item) {
                   alert(&quot;New item must not be empty.&quot;);
                   return false;
               }


               var ddl = document.getElementById('ddl');
               var option = document.createElement('option');


               option.text = option.value = item;
               ddl.add(option, ddl.options[0] /* IE 7 & below, 0 */);
               ddl.selectedIndex = 0;
           }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span>It first find the target TextBox, to check if it is empty. If is empty, then alert the user to input.<span style="">&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span>If user inputs text in the textbox, create a new instance of &quot;option element&quot;, assign text and value to it, append it at the top of DropDownList, and make it be selected.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
function jquerydialog() {
                $('<div>Add new item to DropDownList?</div>').dialog({
                    buttons: {


                        &quot;OK&quot;: function () {
                            add_top();
                            $(this).dialog(&quot;close&quot;);
                        },


                        &quot;Cancel&quot;: function () {
                            $(this).dialog(&quot;close&quot;);
                        }
                    }
                });
                return false;
            }

</pre>
<pre id="codePreview" class="js">
function jquerydialog() {
                $('<div>Add new item to DropDownList?</div>').dialog({
                    buttons: {


                        &quot;OK&quot;: function () {
                            add_top();
                            $(this).dialog(&quot;close&quot;);
                        },


                        &quot;Cancel&quot;: function () {
                            $(this).dialog(&quot;close&quot;);
                        }
                    }
                });
                return false;
            }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span>It defines the jQuery UI's dialog. $('&lt;div&gt;Add new item to DropDownList?&lt;/div&gt;')<span style="">&nbsp;
</span>is a new instance of popup. It calls jQuery UI's dialog() with the parameter.<span style="">&nbsp;
</span>In that parameter, give the &quot;OK&quot; a function, that calls add_top().<span style="">&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;&nbsp; </span>NOTE: return false; must be specified to cancel the button's Postback.
</span></p>
<h2>More Information</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">ModalPopup </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><a href="http://www.asp.net/ajax/ajaxcontroltoolkit/Samples/ModalPopup/ModalPopup.aspx">http://www.asp.net/ajax/ajaxcontroltoolkit/Samples/ModalPopup/ModalPopup.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">jQuery UI </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><a href="http://jqueryui.com/demos/dialog/">http://jqueryui.com/demos/dialog/</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
