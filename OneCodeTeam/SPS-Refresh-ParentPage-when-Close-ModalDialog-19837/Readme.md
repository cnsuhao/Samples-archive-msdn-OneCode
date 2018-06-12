# SPS Refresh ParentPage when Close ModalDialog (CSSharePointRefreshParentPage)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SharePoint
* Dialog
## IsPublished
* True
## ModifiedDate
* 2012-12-05 09:51:14
## Description

<h1><a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style=""><span style="">How to close the SharePoint modal dialog and refresh the parent page using Server side API
</span>(</span></a><span style=""><span style=""><span class="SpellE"><span style="">CSSharePointRefreshParentPage</span></span>)</span></span></h1>
<h2>Introduction</h2>
<p class="MsoNormal">The project shows how to close the SharePoint modal dialog and refresh the parent page using Server side API. The solution is to write JS directly to the http Response object that will close the dialog. In order to refresh the parent
 page when the dialog is closed, <a name="OLE_LINK3">you can pass the </a><span class="SpellE"><span style="">DialogResult</span></span><span style="">
<span class="SpellE">enum</span> value to <span class="SpellE">SP.UI.ModalDialog.RefreshPage</span> as parameter. The
<span class="SpellE">enum</span> value is returned by <span class="SpellE">dialogReturnValueCallback</span> function</span>.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSSharePointRefreshParentPage.sln then right click the SharePoint project to set the &quot;Site Url&quot; to your own.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the &quot;<span class="SpellE">CSSharePointRefreshParentPage</span>&quot; project and click &quot;Deploy&quot;.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Open the SharePoint site in the browser and select &quot;Page&quot; of a page that you want to operate.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/72022/1/image.png" alt="" width="993" height="409" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 4: </span>Select &quot;Edit&quot;.<br>
<span style=""><img src="/site/view/file/72023/1/image.png" alt="" width="965" height="384" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: </span>Having done that, please select &quot;Insert&quot; tab and click &quot;Web Part&quot;.<br>
<span style=""><img src="/site/view/file/72024/1/image.png" alt="" width="991" height="353" align="middle">
</span><br style="">
<br style="">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: </span>In &quot;Categories&quot;, select &quot;Custom&quot; and correspondingly in &quot;Web Parts&quot; column, select &quot;ModalDialogWebPart&quot;. Then click on &quot;Add&quot; button that appears on the right side.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/72025/1/image.png" alt="" width="1004" height="259" align="middle">
</span><span style=""><br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 7: </span>After clicking &quot;Add&quot; button, you can see your ModalDialog web part appears in the SharePoint site:<br>
<span style=""><img src="/site/view/file/72026/1/image.png" alt="" width="1033" height="139" align="middle">
</span><span style="">&nbsp;</span><br>
<span style="">Step 8: C</span>lick &quot;Create&quot; and then you can see a Modal Dialog appears in the SharePoint site:</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/72027/1/image.png" alt="" width="788" height="225" align="middle">
</span><br>
<br>
<span style="">Step 9: </span>Type some information to test.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/72028/1/image.png" alt="" width="791" height="222" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 10: </span>After clicking &quot;OK&quot;, you can see the modal dialog box is closed, while the parent page is refreshed.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<br>
<span style="">Step 11: Validation is finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: </span></p>
<p class="MsoNormal" style=""><span style="">Step 1: Create a C# </span>Empty SharePoint Project
<span style="">in Visual Studio 2010 and name it as &quot;<span class="SpellE">CSSharePointRefreshParentPage</span>&quot;.
</span></p>
<p class="MsoNormal" style="">Step 2: Add a Web Part, you can name it as ModalDialogWebPart.</p>
<p class="MsoNormal" style="">Step 3: Add JavaScript code to the Web Part. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
function openSitePropertyDialog(url) {
       var dialogOptions = SP.UI.$create_DialogOptions();
       dialogOptions.width = 800;
       dialogOptions.height = 400;
       dialogOptions.dialogReturnValueCallback = Function.createDelegate(null, sitePropertiesDialogCallback);
       commonModalDialogOpen(
               url,
               dialogOptions,
               sitePropertiesDialogCallback,
               null);
   }
   function sitePropertiesDialogCallback(dialogResult, returnValue) {
       if (returnValue != null) {
           var notificationId = SP.UI.Notify.addNotification(returnValue, false);
       }
       SP.UI.ModalDialog.RefreshPage(dialogResult);
       //refreshUpdatePanelOnDialogCallback(dialogResult);
   }
   function refreshUpdatePanelOnDialogCallback(dialogResult) {
       if (dialogResult == SP.UI.DialogResult.OK) {
           __doPostBack(&lt;%SPHttpUtility.AddQuote(SPHttpUtility.NoEncode(SitePropertiesUpdatePanel.ClientID),Response.Output);%&gt;);
       }
   }

</pre>
<pre id="codePreview" class="js">
function openSitePropertyDialog(url) {
       var dialogOptions = SP.UI.$create_DialogOptions();
       dialogOptions.width = 800;
       dialogOptions.height = 400;
       dialogOptions.dialogReturnValueCallback = Function.createDelegate(null, sitePropertiesDialogCallback);
       commonModalDialogOpen(
               url,
               dialogOptions,
               sitePropertiesDialogCallback,
               null);
   }
   function sitePropertiesDialogCallback(dialogResult, returnValue) {
       if (returnValue != null) {
           var notificationId = SP.UI.Notify.addNotification(returnValue, false);
       }
       SP.UI.ModalDialog.RefreshPage(dialogResult);
       //refreshUpdatePanelOnDialogCallback(dialogResult);
   }
   function refreshUpdatePanelOnDialogCallback(dialogResult) {
       if (dialogResult == SP.UI.DialogResult.OK) {
           __doPostBack(&lt;%SPHttpUtility.AddQuote(SPHttpUtility.NoEncode(SitePropertiesUpdatePanel.ClientID),Response.Output);%&gt;);
       }
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Step 4: Now, let's add SharePoint &quot;Layouts&quot; Mapped Folder and then add two Application Pages. One is used to add property and the other is used to edit property.</p>
<p class="MsoNormal" style="">Step 5: Customize the form then we should add some codes to code-behind file as below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
if (!Page.IsValid)
           {
               return;
           }


           //Get propertyName and propertyValue to add
           string propertyName = NameInputFormTextBox.Text.Trim();
           string propertyValue = ValueInputFormTextBox.Text.Trim();


           if (String.IsNullOrEmpty(propertyName))
           {
               NameErrorLabel.Text = &quot;Site property name cannot be empty.&quot;;
               return;
           }


           try
           {
               if (Web.GetProperty(propertyName) != null)
               {
                   NameErrorLabel.Text = &quot;Site property name already exists.&quot;;
                   return;
               }


               Web.AddProperty(propertyName, propertyValue);
               Web.Update();
           }
           catch (Exception ex)
           {
               throw new SPException(ex.Message);
           }


           //Refresh the page when the dialog is closed by write JS directly to the
           //http Response object that will close the dialog         
           if (SPContext.Current.IsPopUI)
           {
               Response.Clear();
               Response.Write(String.Format(@&quot;&lt;script language=&quot;&quot;javascript&quot;&quot; type=&quot;&quot;text/javascript&quot;&quot;&gt;










               window.frameElement.commonModalDialogClose(1, &quot;&quot;{0}&quot;&quot;);&lt;/script&gt;&quot;, &quot;Site property is successfully added.&quot;));
               Response.End();
           }
           else
           {
               SPUtility.Redirect(strSource, SPRedirectFlags.UseSource, this.Context);
           }          

</pre>
<pre id="codePreview" class="csharp">
if (!Page.IsValid)
           {
               return;
           }


           //Get propertyName and propertyValue to add
           string propertyName = NameInputFormTextBox.Text.Trim();
           string propertyValue = ValueInputFormTextBox.Text.Trim();


           if (String.IsNullOrEmpty(propertyName))
           {
               NameErrorLabel.Text = &quot;Site property name cannot be empty.&quot;;
               return;
           }


           try
           {
               if (Web.GetProperty(propertyName) != null)
               {
                   NameErrorLabel.Text = &quot;Site property name already exists.&quot;;
                   return;
               }


               Web.AddProperty(propertyName, propertyValue);
               Web.Update();
           }
           catch (Exception ex)
           {
               throw new SPException(ex.Message);
           }


           //Refresh the page when the dialog is closed by write JS directly to the
           //http Response object that will close the dialog         
           if (SPContext.Current.IsPopUI)
           {
               Response.Clear();
               Response.Write(String.Format(@&quot;&lt;script language=&quot;&quot;javascript&quot;&quot; type=&quot;&quot;text/javascript&quot;&quot;&gt;










               window.frameElement.commonModalDialogClose(1, &quot;&quot;{0}&quot;&quot;);&lt;/script&gt;&quot;, &quot;Site property is successfully added.&quot;));
               Response.End();
           }
           else
           {
               SPUtility.Redirect(strSource, SPRedirectFlags.UseSource, this.Context);
           }          

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><b style="">[Note]</b> The following code is the key; it will refresh the page when the dialog is closed:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
Response.Clear();
Response.Write(String.Format(@&quot;&lt;script language=&quot;&quot;javascript&quot;&quot; type=&quot;&quot;text/javascript&quot;&quot;&gt;










window.frameElement.commonModalDialogClose(1, &quot;&quot;{0}&quot;&quot;);&lt;/script&gt;&quot;, &quot;Site property is successfully added.&quot;));
Response.End();

</pre>
<pre id="codePreview" class="csharp">
Response.Clear();
Response.Write(String.Format(@&quot;&lt;script language=&quot;&quot;javascript&quot;&quot; type=&quot;&quot;text/javascript&quot;&quot;&gt;










window.frameElement.commonModalDialogClose(1, &quot;&quot;{0}&quot;&quot;);&lt;/script&gt;&quot;, &quot;Site property is successfully added.&quot;));
Response.End();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""><br>
</span>Step 6: Build the solution and then try to deploy the project to the SharePoint site. Then you can test it.</p>
<p class="MsoNormal" style="">SP.UI.ModalDialog.commonModalDialogOpen(url, options, callback, args) Method<br>
<a href="http://technet.microsoft.com/en-us/library/ff409609.aspx">http://technet.microsoft.com/en-us/library/ff409609.aspx</a><br>
SP.UI.ModalDialog.RefreshPage(dialogResult) Method<br>
<a href="http://msdn.microsoft.com/en-us/library/ff411790.aspx">http://msdn.microsoft.com/en-us/library/ff411790.aspx</a><br>
SP.UI.ModalDialog.commonModalDialogClose(dialogResult, returnVal) Method<br>
<a href="http://msdn.microsoft.com/en-us/library/ff409682.aspx">http://msdn.microsoft.com/en-us/library/ff409682.aspx</a><br>
SP.UI.Notify Class<br>
<a href="http://msdn.microsoft.com/en-us/library/ff408137.aspx">http://msdn.microsoft.com/en-us/library/ff408137.aspx</a></p>
<p class="MsoNormal" style=""></p>
<p class="MsoNormal" style=""><br style="">
<br style="">
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
