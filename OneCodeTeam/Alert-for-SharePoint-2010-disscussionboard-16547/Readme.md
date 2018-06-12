# Alert for SharePoint 2010 disscussionboard (AddAlertForDiscussionBoard)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* Alert
## IsPublished
* True
## ModifiedDate
* 2012-05-10 07:54:28
## Description

<h1><span style="">Add alert function for SharePoint 2010 discussion board </span>
(<span style="">VBSharePointAddAlertForDiscussionBoard</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">The sample code demonstrates how to <span style="font-size:9.5pt; line-height:115%; font-family:Consolas">
add alert function for SharePoint 2010 Discussion board</span>. This is a very common issue in forums,
<span style="">many developers</span> want to create a better SharePoint Discussion board, so we provide this sample code to show how to customize alert for Discussion Board by coding.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step 1: Open the <span class="GramE">
VBAddAlertForDiscussionBoard.sln,</span> modify the &quot;Site URL&quot; to your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step 2: Right-click solutions then run &quot;Deploy&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step 3: Be sure you have setting the &quot;Outgoing E-Mail Settings&quot;<span class="GramE">,<span style="">&nbsp;
</span>The</span> reason behind this is that SharePoint has its setting for SPUtility.SendEmail() method which by default picks the 'From address' from Central administartion-&gt; System Settings -&gt; Outgoing E-Mail Settings. It��s better not to experiment
 with 'From address' without. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step 4: Create a new topic or response a topic.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">Step 5: Validation finished. </span>
</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="GramE"><span style="font-size:9.5pt; font-family:Consolas">Step 1.</span></span><span style="font-size:9.5pt; font-family:Consolas"> Create a VB &quot;Empty SharePoint Project&quot; in Visual Studio 2010. Name it as &quot;VBAddAlertForDiscussionBoard&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">In the SharePoint Customization Wizard, choose Deploy as a farm solution. Click Finish.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="GramE"><span style="font-size:9.5pt; font-family:Consolas">Step 2.</span></span><span style="font-size:9.5pt; font-family:Consolas">
<span class="GramE">In the Solution Explorer, right-click the project.</span> Select &quot;Add New Item&quot;, then add an &quot;Event Receiver&quot;: the type you should select &quot;List Item Events&quot; and the event source should be &quot;Discussion
 Board&quot; and select handle for add event. In this sample have two Event Receiver, one for send Email to ��the topic owner and all those who replied/commented�� while an item was added and the other for the topic owner only.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="GramE"><span style="font-size:9.5pt; font-family:Consolas">Step 3.</span></span><span style="font-size:9.5pt; font-family:Consolas"> Get the SPListItem in which the event occurred then get the User's Mail. For topic owner only and &quot;the topic
 owner and all those who replied/commented&quot;, the method to get SPListItem have some difference, we can get the SPListItem by use Linq for the &quot;only for topic owner&quot; scene.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim taskListItems = (From tItem In list.Items Order By tItem.ID Ascending Select tItem).First()

</pre>
<pre id="codePreview" class="vb">
Dim taskListItems = (From tItem In list.Items Order By tItem.ID Ascending Select tItem).First()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="GramE"><span style="font-size:9.5pt; font-family:Consolas">And &quot;foreach&quot; to loop for the &quot;the topic owner and all those who replied/commented&quot; scene.</span></span><span style="font-size:9.5pt; font-family:Consolas">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
For Each oListItem As SPListItem In collListItems
                  Dim spu As SPUser = AddAlertForDiscussionBoard.Helper.GetSPUserFromSPListItemByFieldName(oListItem, &quot;Created By&quot;)
                  AddAlertForDiscussionBoard.Helper.strMailto = &quot;;&quot; &#43; spu.Email
              Next

</pre>
<pre id="codePreview" class="vb">
For Each oListItem As SPListItem In collListItems
                  Dim spu As SPUser = AddAlertForDiscussionBoard.Helper.GetSPUserFromSPListItemByFieldName(oListItem, &quot;Created By&quot;)
                  AddAlertForDiscussionBoard.Helper.strMailto = &quot;;&quot; &#43; spu.Email
              Next

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas">In the Helper class, the method ��GetSPUserFromSPListItemByFieldName�� is used to get SPUser from the SPFieldUserValue, because the type which we get from the SPListItem by the Fieldname &quot;Created By&quot;
 is ��SPFieldUserValue��. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim _user As SPFieldUser = DirectCast(spItem.Fields(fieldName), SPFieldUser)
Dim userValue As SPFieldUserValue = DirectCast(_user.GetFieldValue(userName), SPFieldUserValue)
Return userValue.User

</pre>
<pre id="codePreview" class="vb">
Dim _user As SPFieldUser = DirectCast(spItem.Fields(fieldName), SPFieldUser)
Dim userValue As SPFieldUserValue = DirectCast(_user.GetFieldValue(userName), SPFieldUserValue)
Return userValue.User

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="GramE"><span style="font-size:9.5pt; font-family:Consolas">Step 4.</span></span><span style="font-size:9.5pt; font-family:Consolas"> Set the information for the mail.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="GramE"><span style="font-size:9.5pt; font-family:Consolas">Step 5.</span></span><span style="font-size:9.5pt; font-family:Consolas"> Modify the Elements.xml by add the following code to perform synchronization events:
</span></p>
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
<span class="GramE"><span style="font-size:9.5pt; font-family:Consolas">Step 6.</span></span><span style="font-size:9.5pt; font-family:Consolas"> Build the feature.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span class="GramE"><span style="font-size:9.5pt; font-family:Consolas">Step 7.</span></span><span style="font-size:9.5pt; font-family:Consolas"> Deploy.</span></p>
<h2>More Information</h2>
<p class="MsoNormal" style="margin-left:.25in"><span style="font-size:9.5pt; line-height:115%; font-family:Consolas"><a href="http://msdn.microsoft.com/en-us/library/ms460489.aspx">SPUtility.SendEmail Method (SPWeb, StringDictionary, String)</a></span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:0in; margin-left:.25in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spuser.aspx">SPUser Class</a></span>
</p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
