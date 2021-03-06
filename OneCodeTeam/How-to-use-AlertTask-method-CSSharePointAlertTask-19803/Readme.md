# How to use AlertTask method (CSSharePointAlertTask)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SharePoint
## IsPublished
* True
## ModifiedDate
* 2012-12-03 11:14:51
## Description

<h1>How to use <span class="SpellE">AlertTask</span> method (<span class="SpellE">CSSharePointAlertTask</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample code will demo how to deal with a workflow task by using AlertTask method.
<span style="">In real scenario</span>, customers often need to deal with their workflow task outside SharePoint, so they need to use AlertTask method. But we found that there is little information about this method and some developers still misunderstood the
 way to work with workflow task. Often, they made mistakes by directly update the workflow task in a normal way which we will use to update list item. Therefore we provide this sample code to show how to deal with workflow task correctly.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the CSSharePointAlertTask.sln. Set the &quot;Site URL&quot; property of the project to the URL of your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 2: Right-click the &quot;CSSharePointAlertTask&quot; project and click &quot;Deploy&quot;.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 3: Add </span>the workflow <span style="">to your own Workflow associated list. And then start a workflow.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 4: </span>Open the workflow and a new workflow item will be established.<br style="">
<br style="">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 5: Open the workflow item then</span> <span style="">to operate. Then to edit the task item in the operate page. We can see the log on workflow history list.<br>
<span style="">In custom task form, we will<span style="">&nbsp; </span>achieve completing, reassigning and cancelling etc. The custom task edit form will show as below:
<br>
<img src="/site/view/file/71840/1/image.png" alt="" width="621" height="413" align="middle">
<br>
After we click on the approve button, the workflow will be completed.<br>
<img src="/site/view/file/71841/1/image.png" alt="" width="777" height="206" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">If we click on the reassign button, the current task item will be completed. After that it will create a new task item by the new value for assignto.
<br>
<img src="/site/view/file/71842/1/image.png" alt="" width="840" height="292" align="middle">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<b style=""><span style="">[Note]</span></b><span style="">In the real scene, we need a form to specify the reassign user.<span style="">&nbsp;
</span>In order to test this sample, we just insert a default value (administrator) into the hashtable as the assignto value.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">If we click on the canceltask button, the task item will be canceled directly. The workflow will not be affected.<br style="">
<br style="">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">If we click on the canceloperation button, the pop-up edit window will be closed. The workflow does not have any impact.<span style="">&nbsp;
</span><br style="">
<br style="">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 6: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style=""><span style="">Step 1: Create a C# </span>Empty SharePoint Project
<span style="">in Visual Studio 2010 and name it as &quot;CSSharePointAlertTask&quot;.
</span></p>
<p class="MsoNormal" style="margin-top:10.0pt; margin-right:0in; margin-bottom:0in; margin-left:0in; margin-bottom:.0001pt">
<span style="">Step 2: </span><span lang="EN" style="">Create a &quot;Sequential Workflow&quot; project item. Create the workflow as &quot;List Workflow&quot;. We manually associate the workflow with lists after it is created.</span><b><span lang="EN" style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
<br>
</span></b><span style="">Create the content type for our Workflow. We can add it to the Elements.xml of workflow.</span><b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></b><span lang="EN" style="">The content type definition as shown below:</span><b><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;; color:blue">
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;ContentType
ID=&quot;0x01080100655E7E0BCBA64431B9266D69CB53A7BA&quot;
Name=&quot;Approval Task&quot;
Group=&quot;My Content Types&quot;
Overwrite=&quot;TRUE&quot;
Inherits=&quot;FALSE&quot;
Description=&quot;Used to approve and reject My proposals&quot;
Version=&quot;14&quot;&gt;


&nbsp; &lt;FieldRefs&gt;
&nbsp;&nbsp;&nbsp; &lt;FieldRef ID=&quot;{fa564e0f-0c70-4ab9-b863-0177e6ddd247}&quot; Name=&quot;Title&quot; Required=&quot;TRUE&quot; ShowInNewForm=&quot;TRUE&quot; ShowInEditForm=&quot;TRUE&quot;/&gt;
&nbsp;&nbsp;&nbsp; &lt;FieldRef ID=&quot;{c3a92d97-2b77-4a25-9698-3ab54874bc6f}&quot; Name=&quot;Predecessors&quot; /&gt;
&nbsp;&nbsp;&nbsp; &lt;FieldRef ID=&quot;{a8eb573e-9e11-481a-a8c9-1104a54b2fbd}&quot; Name=&quot;Priority&quot; /&gt;
&nbsp;&nbsp;&nbsp; &lt;FieldRef ID=&quot;{c15b34c3-ce7d-490a-b133-3f4de8801b76}&quot; Name=&quot;Status&quot; /&gt;&nbsp;&nbsp; 
...
&nbsp; &lt;/FieldRefs&gt;
&nbsp; &lt;XmlDocuments&gt;
&nbsp;&nbsp;&nbsp; &lt;XmlDocument NamespaceURI=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;FormUrls xmlns=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Edit&gt;_layouts/CSSharePointAlertTask/MyAlertTaskWF/TaskEditForm.aspx&lt;/Edit&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/FormUrls&gt;
&nbsp;&nbsp;&nbsp; &lt;/XmlDocument&gt;
&nbsp; &lt;/XmlDocuments&gt;
&lt;/ContentType&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;ContentType
ID=&quot;0x01080100655E7E0BCBA64431B9266D69CB53A7BA&quot;
Name=&quot;Approval Task&quot;
Group=&quot;My Content Types&quot;
Overwrite=&quot;TRUE&quot;
Inherits=&quot;FALSE&quot;
Description=&quot;Used to approve and reject My proposals&quot;
Version=&quot;14&quot;&gt;


&nbsp; &lt;FieldRefs&gt;
&nbsp;&nbsp;&nbsp; &lt;FieldRef ID=&quot;{fa564e0f-0c70-4ab9-b863-0177e6ddd247}&quot; Name=&quot;Title&quot; Required=&quot;TRUE&quot; ShowInNewForm=&quot;TRUE&quot; ShowInEditForm=&quot;TRUE&quot;/&gt;
&nbsp;&nbsp;&nbsp; &lt;FieldRef ID=&quot;{c3a92d97-2b77-4a25-9698-3ab54874bc6f}&quot; Name=&quot;Predecessors&quot; /&gt;
&nbsp;&nbsp;&nbsp; &lt;FieldRef ID=&quot;{a8eb573e-9e11-481a-a8c9-1104a54b2fbd}&quot; Name=&quot;Priority&quot; /&gt;
&nbsp;&nbsp;&nbsp; &lt;FieldRef ID=&quot;{c15b34c3-ce7d-490a-b133-3f4de8801b76}&quot; Name=&quot;Status&quot; /&gt;&nbsp;&nbsp; 
...
&nbsp; &lt;/FieldRefs&gt;
&nbsp; &lt;XmlDocuments&gt;
&nbsp;&nbsp;&nbsp; &lt;XmlDocument NamespaceURI=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;FormUrls xmlns=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Edit&gt;_layouts/CSSharePointAlertTask/MyAlertTaskWF/TaskEditForm.aspx&lt;/Edit&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/FormUrls&gt;
&nbsp;&nbsp;&nbsp; &lt;/XmlDocument&gt;
&nbsp; &lt;/XmlDocuments&gt;
&lt;/ContentType&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">Inside &quot;FormUrls&quot; tag we specify our custom form template we created.<br>
<b style="">[Note]</b> The new content type is derived from the &quot;Workflow Task&quot; content type 0×010801. The content type id should begin with 0x01080100. In the &quot;FieldRefs&quot; section we add our fields we need inside the workflow.
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 3: The definition of the workflow as shown below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Workflow
&nbsp;&nbsp;&nbsp; Name=&quot;MyAlertTaskWF&quot;
&nbsp;&nbsp;&nbsp; Description=&quot;My SharePoint AlertTask Workflow&quot;
&nbsp;&nbsp;&nbsp; Id=&quot;4ceec6fc-2d79-496a-be15-0e7c2aa5aea4&quot;
&nbsp;&nbsp;&nbsp; CodeBesideClass=&quot;CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF&quot;
&nbsp;&nbsp;&nbsp; CodeBesideAssembly=&quot;$assemblyname$&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskListContentTypeId=&quot;0x01080100655E7E0BCBA64431B9266D69CB53A7BA&quot;
&nbsp;&nbsp;&nbsp; &gt;
&nbsp;&nbsp; &lt;Categories/&gt;
&nbsp;&nbsp; &lt;MetaData&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &lt;AssociationCategories&gt;List&lt;/AssociationCategories&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &lt;StatusPageUrl&gt;_layouts/WrkStat.aspx&lt;/StatusPageUrl&gt;
&nbsp;&nbsp; &lt;/MetaData&gt;
 &lt;/Workflow&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Workflow
&nbsp;&nbsp;&nbsp; Name=&quot;MyAlertTaskWF&quot;
&nbsp;&nbsp;&nbsp; Description=&quot;My SharePoint AlertTask Workflow&quot;
&nbsp;&nbsp;&nbsp; Id=&quot;4ceec6fc-2d79-496a-be15-0e7c2aa5aea4&quot;
&nbsp;&nbsp;&nbsp; CodeBesideClass=&quot;CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF&quot;
&nbsp;&nbsp;&nbsp; CodeBesideAssembly=&quot;$assemblyname$&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskListContentTypeId=&quot;0x01080100655E7E0BCBA64431B9266D69CB53A7BA&quot;
&nbsp;&nbsp;&nbsp; &gt;
&nbsp;&nbsp; &lt;Categories/&gt;
&nbsp;&nbsp; &lt;MetaData&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &lt;AssociationCategories&gt;List&lt;/AssociationCategories&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &lt;StatusPageUrl&gt;_layouts/WrkStat.aspx&lt;/StatusPageUrl&gt;
&nbsp;&nbsp; &lt;/MetaData&gt;
 &lt;/Workflow&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 4: In the workflow designer. We drag a &quot;While&quot; activity from the Toolbox pane into the workflow. In the &quot;While&quot; activity we drag a &quot;Sequence&quot; activity from the Toolbox
 pane. In the &quot;Sequence&quot; activity we drag a &quot;Create Task&quot; activity, an &quot;OnTaskChanged&quot; activity and a &quot;CompleteTask&quot; activity from the Toolbox pane. In this sample, we will add LogToHistoryListActivity for task activity
 and workflow activity</span><span style="">.</span> <span style="">We need to configure the task activity in the &quot;Properties&quot; pane.</span>
<span style="">Set &quot;correlationToken&quot; to &quot;taskToken&quot; and the sub element of &quot;correlationToken&quot; named &quot;OwnerActivityName&quot; to &quot;</span><span lang="EN" style="">sequenceActivity1</span><span style="">&quot;.
</span>C<span style="">reate code behind properties for some activity properties, such as:</span>
<b><span style="">TaskProperties</span></b><span style=""> etc….</span><span style="">
<span lang="EN"></span></span></p>
<p class="MsoNormal" style=""><b style=""><span lang="EN" style="">[Note]</span></b><span lang="EN" style="">First time Activities complete with Correction token defined in the workflow design, if the Task is reassigning then it will not work, for that we
 have to put all the Activities(such as: Create Task, Task changes, complete Task etc…) inside the sequential activities and changes the
</span><span style="">OwnerActivityName</span><span lang="EN" style=""> to sequenceActivity1.</span><span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public static DependencyProperty TaskIdProperty = DependencyProperty.Register(&quot;TaskId&quot;, typeof(System.Guid), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [BrowsableAttribute(true)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [CategoryAttribute(&quot;Misc&quot;)]
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;public Guid TaskId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return ((System.Guid)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskIdProperty)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskIdProperty, value);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public static DependencyProperty TaskPropertiesProperty = DependencyProperty.Register(&quot;TaskProperties&quot;, typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [BrowsableAttribute(true)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [CategoryAttribute(&quot;Misc&quot;)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public SPWorkflowTaskProperties TaskProperties
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskPropertiesProperty)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskPropertiesProperty, value);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public static DependencyProperty TaskAfterPropertiesProperty = DependencyProperty.Register(&quot;TaskAfterProperties&quot;, typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [BrowsableAttribute(true)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [CategoryAttribute(&quot;Misc&quot;)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public SPWorkflowTaskProperties TaskAfterProperties
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskAfterPropertiesProperty)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskAfterPropertiesProperty, value);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public static DependencyProperty HistoryDescriptionProperty = DependencyProperty.Register(&quot;HistoryDescription&quot;, typeof(System.String), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [BrowsableAttribute(true)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [CategoryAttribute(&quot;Misc&quot;)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public String HistoryDescription
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return ((string)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryDescriptionProperty)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryDescriptionProperty, value);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public static DependencyProperty HistoryOutcomeProperty = DependencyProperty.Register(&quot;HistoryOutcome&quot;, typeof(System.String), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [BrowsableAttribute(true)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [CategoryAttribute(&quot;Misc&quot;)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public String HistoryOutcome
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return ((string)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryOutcomeProperty)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryOutcomeProperty, value);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">
public static DependencyProperty TaskIdProperty = DependencyProperty.Register(&quot;TaskId&quot;, typeof(System.Guid), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [BrowsableAttribute(true)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [CategoryAttribute(&quot;Misc&quot;)]
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;public Guid TaskId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return ((System.Guid)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskIdProperty)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskIdProperty, value);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public static DependencyProperty TaskPropertiesProperty = DependencyProperty.Register(&quot;TaskProperties&quot;, typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [BrowsableAttribute(true)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [CategoryAttribute(&quot;Misc&quot;)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public SPWorkflowTaskProperties TaskProperties
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskPropertiesProperty)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskPropertiesProperty, value);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public static DependencyProperty TaskAfterPropertiesProperty = DependencyProperty.Register(&quot;TaskAfterProperties&quot;, typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [BrowsableAttribute(true)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [CategoryAttribute(&quot;Misc&quot;)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public SPWorkflowTaskProperties TaskAfterProperties
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskAfterPropertiesProperty)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.TaskAfterPropertiesProperty, value);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public static DependencyProperty HistoryDescriptionProperty = DependencyProperty.Register(&quot;HistoryDescription&quot;, typeof(System.String), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [BrowsableAttribute(true)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [CategoryAttribute(&quot;Misc&quot;)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public String HistoryDescription
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return ((string)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryDescriptionProperty)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryDescriptionProperty, value);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public static DependencyProperty HistoryOutcomeProperty = DependencyProperty.Register(&quot;HistoryOutcome&quot;, typeof(System.String), typeof(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [BrowsableAttribute(true)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [CategoryAttribute(&quot;Misc&quot;)]
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public String HistoryOutcome
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return ((string)(base.GetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryOutcomeProperty)));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; base.SetValue(CSSharePointAlertTask.MyAlertTaskWF.MyAlertTaskWF.HistoryOutcomeProperty, value);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">Declare all needed properties.<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
string strReassignee = string.Empty;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private bool isReassign = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string assignee = default(System.String);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string strTaskStatus = &quot;Pending Approval&quot;;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //Flag for while.
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private bool isFinished = false;

</pre>
<pre id="codePreview" class="csharp">
string strReassignee = string.Empty;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private bool isReassign = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string assignee = default(System.String);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string strTaskStatus = &quot;Pending Approval&quot;;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //Flag for while.
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private bool isFinished = false;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">Additionally we specify new property bindings:<b style=""> &quot;AfterProperties&quot;, &quot;BeforeProperties&quot; and &quot;TaskId&quot; etc…
<br>
</b>Step 5: In the &quot;Invoked&quot; property add the method name &quot;onTaskChanged_Invoked&quot; and &quot;</span><span style="color:black">createTask1_MethodInvoking</span><span lang="EN" style="">&quot; for each activity. Your method will look like this:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// CreateTask Created
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private void createTask1_MethodInvoking(object sender, EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // generate new GUID used to initialize task correlation token 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TaskId = Guid.NewGuid();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (strReassignee != null && isReassign == true)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.AssignedTo = strReassignee;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.Title = string.Format(&quot;Review 2:ã€&#144;{0}ã€'&quot;, this.workflowProperties.Item.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties = new SPWorkflowTaskProperties();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // assign initial properties prior to task creation 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TaskProperties.Title = string.Format(&quot;Review:{0}'&quot;, this.workflowProperties.Item.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.PercentComplete = 0;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.StartDate = DateTime.Today;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.DueDate = DateTime.Today.AddDays(3);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.ExtendedProperties[&quot;TaskStatus&quot;] = strTaskStatus;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.AssignedTo = assignee;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp; private void onTaskChanged_Invoked(object sender, ExternalDataEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isReassign = bool.Parse(TaskAfterProperties.ExtendedProperties[&quot;isReassign&quot;].ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (isReassign == true)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strReassignee = TaskAfterProperties.ExtendedProperties[&quot;ReAssignedTo&quot;].ToString();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFinished = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFinished = (TaskAfterProperties.ExtendedProperties[&quot;TaskStatus&quot;].ToString() == &quot;Completed&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (Exception ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; logForTaskChanged.HistoryDescription = ex.ToString();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// CreateTask Created
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private void createTask1_MethodInvoking(object sender, EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // generate new GUID used to initialize task correlation token 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TaskId = Guid.NewGuid();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (strReassignee != null && isReassign == true)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.AssignedTo = strReassignee;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.Title = string.Format(&quot;Review 2:ã€&#144;{0}ã€'&quot;, this.workflowProperties.Item.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties = new SPWorkflowTaskProperties();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // assign initial properties prior to task creation 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TaskProperties.Title = string.Format(&quot;Review:{0}'&quot;, this.workflowProperties.Item.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.PercentComplete = 0;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.StartDate = DateTime.Today;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.DueDate = DateTime.Today.AddDays(3);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.ExtendedProperties[&quot;TaskStatus&quot;] = strTaskStatus;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskProperties.AssignedTo = assignee;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp; private void onTaskChanged_Invoked(object sender, ExternalDataEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isReassign = bool.Parse(TaskAfterProperties.ExtendedProperties[&quot;isReassign&quot;].ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (isReassign == true)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strReassignee = TaskAfterProperties.ExtendedProperties[&quot;ReAssignedTo&quot;].ToString();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFinished = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFinished = (TaskAfterProperties.ExtendedProperties[&quot;TaskStatus&quot;].ToString() == &quot;Completed&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (Exception ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; logForTaskChanged.HistoryDescription = ex.ToString();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style=""><br>
Step 6: &quot;</span><span style="color:black">isFinished</span><span lang="EN" style="">&quot; will contain the information whether the Workflow Task Item we created before was &quot;Completed&quot; by the assigned user. In the &quot;onTaskChanged_Invoked&quot;
 method we set the &quot;isFinished&quot; property. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
isReassign = bool.Parse(TaskAfterProperties.ExtendedProperties[&quot;isReassign&quot;].ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (isReassign == true)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strReassignee = TaskAfterProperties.ExtendedProperties[&quot;ReAssignedTo&quot;].ToString();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFinished = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFinished = (TaskAfterProperties.ExtendedProperties[&quot;TaskStatus&quot;].ToString() == &quot;Completed&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">
isReassign = bool.Parse(TaskAfterProperties.ExtendedProperties[&quot;isReassign&quot;].ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (isReassign == true)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strReassignee = TaskAfterProperties.ExtendedProperties[&quot;ReAssignedTo&quot;].ToString();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFinished = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; isFinished = (TaskAfterProperties.ExtendedProperties[&quot;TaskStatus&quot;].ToString() == &quot;Completed&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 7: Now we need to specify the condition for the &quot;While&quot; activity. In the workflow designer select this activity. In the &quot;Condition&quot; property select &quot;Code Condition&quot;
 and expand the property. Enter &quot;while1Invoke&quot; in the subproperty with (the same) name &quot;Condition&quot;. In the code editor enter the code for &quot;while1Invoke&quot; like this:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
//Condition of while
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private void while1Invoke(object sender, ConditionalEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; e.Result = !isFinished;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">
//Condition of while
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private void while1Invoke(object sender, ConditionalEventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; e.Result = !isFinished;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">The &quot;e.Result&quot; property has to be &quot;TRUE&quot; as long as the while loop should run. It should not run anymore (&quot;e.Result = false&quot;) if &quot;isFinished&quot; is TRUE.
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 8: Custom edit page: TaskEditForm.aspx. You can add it by adding an Application Page then dragging it to workflow.<br>
The code as shown below: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected override void OnInit(EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnApprove.Click &#43;= new EventHandler(btnApprove_Click);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnCancel.Click &#43;= new EventHandler(btnCancel_Click);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected string ListId;//List Id
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPList TaskList;//Task List
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPListItem TaskItem;//Task Item
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected Guid WorkflowInstanceId;//WorkflowInstance Id
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPWorkflow WorkflowInstance;//Workflow Instance
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPList ItemList;//Item List
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPListItem Item;//SPListItem
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPWorkflowTask Task;//SPWorkflowTask
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected string TaskName;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected override void OnLoad(EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ListId = Request.QueryString[&quot;List&quot;];
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskList = Web.Lists[new Guid(ListId)];
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskItem = TaskList.GetItemById(Convert.ToInt32(Request.Params[&quot;ID&quot;]));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WorkflowInstanceId = new Guid((string)TaskItem[&quot;WorkflowInstanceID&quot;]);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WorkflowInstance = new SPWorkflow(Web, WorkflowInstanceId);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Task = WorkflowInstance.Tasks[0];
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemList = WorkflowInstance.ParentList;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Item = ItemList.GetItemById(WorkflowInstance.ItemId);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskName = TaskItem[&quot;Title&quot;].ToString();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //Url of the Item
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string UrlToItem = Web.Site.MakeFullUrl(ItemList.RootFolder.Url &#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; @&quot;\DispForm.aspx?ID=&quot; &#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Item.ID.ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string ItemName;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (Item.File != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemName = Item.File.Name;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemName = Item.Title;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //bind value to control
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lnkItem.Text = ItemName;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lnkItem.NavigateUrl = UrlToItem;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lblListName.Text = ItemList.Title;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lblSiteUrl.Text = Web.Url;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// Approve event
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;protected void btnApprove_Click(object sender, EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hashtable hashTable = new Hashtable();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SetApprove(&quot;Approved&quot;, &quot;Completed&quot;, hashTable, false);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; commitPopup();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// Cancel the operation
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected void btnCancel_Click(object sender, EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; commitPopup();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }






&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/// Operating task.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;strFlag&quot;&gt;TaskOutcome&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;strTaskStatus&quot;&gt;TaskStatus&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;taskHashs&quot;&gt;task Hashs&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;isReassign&quot;&gt;flag for reassign&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private void SetApprove(string strFlag, string strTaskStatus, Hashtable taskHashs, bool isReassign)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hashtable taskHash = taskHashs;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (taskHash.Count == 0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash = new Hashtable();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;TaskStatus&quot;] = strTaskStatus;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;TaskOutcome&quot;] = strFlag;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;Outcome&quot;] = strFlag;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;ApproverComments&quot;] = txtComments.Text;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash.Add(&quot;isReassign&quot;, isReassign);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Update specified task with the specified property value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SPWorkflowTask.AlterTask(TaskItem, taskHash, true);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected void btnReassign_Click(object sender, EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hashtable taskHash = new Hashtable();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;TaskStatus&quot;] = &quot;Inprogress&quot;;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash.Add(&quot;ReAssignedTo&quot;, &quot;administrator&quot;);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SetApprove(&quot;Reassign&quot;, &quot;in process&quot;, taskHash, true);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; commitPopup();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// Cancel the Workflow and task
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected void btnCancelTask_Click(object sender, EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // cancel the task
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hashtable taskHash = new Hashtable();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;TaskStatus&quot;] = &quot;Canceled&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;Status&quot;] = &quot;Canceled&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SetApprove(&quot;CancelTask&quot;, &quot;Canceled&quot;, taskHash, false);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Cancel the Workflow
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // SPWorkflowManager.CancelWorkflow(WorkflowInstance);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //Close the popup
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; commitPopup();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// Close popup
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private void commitPopup()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (Request[&quot;IsDlg&quot;] == &quot;1&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Context.Response.Write(&quot;&lt;script type='text/javascript'&gt;window.frameElement.commitPopup();&lt;/script&gt;&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Context.Response.Flush();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Context.Response.End();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SPUtility.Redirect(ItemList.DefaultViewUrl, SPRedirectFlags.UseSource, HttpContext.Current);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">
protected override void OnInit(EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnApprove.Click &#43;= new EventHandler(btnApprove_Click);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; btnCancel.Click &#43;= new EventHandler(btnCancel_Click);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected string ListId;//List Id
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPList TaskList;//Task List
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPListItem TaskItem;//Task Item
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected Guid WorkflowInstanceId;//WorkflowInstance Id
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPWorkflow WorkflowInstance;//Workflow Instance
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPList ItemList;//Item List
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPListItem Item;//SPListItem
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected SPWorkflowTask Task;//SPWorkflowTask
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected string TaskName;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected override void OnLoad(EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ListId = Request.QueryString[&quot;List&quot;];
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskList = Web.Lists[new Guid(ListId)];
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskItem = TaskList.GetItemById(Convert.ToInt32(Request.Params[&quot;ID&quot;]));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WorkflowInstanceId = new Guid((string)TaskItem[&quot;WorkflowInstanceID&quot;]);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WorkflowInstance = new SPWorkflow(Web, WorkflowInstanceId);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Task = WorkflowInstance.Tasks[0];
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemList = WorkflowInstance.ParentList;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Item = ItemList.GetItemById(WorkflowInstance.ItemId);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TaskName = TaskItem[&quot;Title&quot;].ToString();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //Url of the Item
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string UrlToItem = Web.Site.MakeFullUrl(ItemList.RootFolder.Url &#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; @&quot;\DispForm.aspx?ID=&quot; &#43;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Item.ID.ToString());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string ItemName;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (Item.File != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemName = Item.File.Name;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemName = Item.Title;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //bind value to control
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lnkItem.Text = ItemName;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lnkItem.NavigateUrl = UrlToItem;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lblListName.Text = ItemList.Title;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lblSiteUrl.Text = Web.Url;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// Approve event
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;protected void btnApprove_Click(object sender, EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hashtable hashTable = new Hashtable();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SetApprove(&quot;Approved&quot;, &quot;Completed&quot;, hashTable, false);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; commitPopup();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// Cancel the operation
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected void btnCancel_Click(object sender, EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; commitPopup();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }






&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/// Operating task.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;strFlag&quot;&gt;TaskOutcome&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;strTaskStatus&quot;&gt;TaskStatus&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;taskHashs&quot;&gt;task Hashs&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;isReassign&quot;&gt;flag for reassign&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private void SetApprove(string strFlag, string strTaskStatus, Hashtable taskHashs, bool isReassign)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hashtable taskHash = taskHashs;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (taskHash.Count == 0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash = new Hashtable();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;TaskStatus&quot;] = strTaskStatus;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;TaskOutcome&quot;] = strFlag;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;Outcome&quot;] = strFlag;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;ApproverComments&quot;] = txtComments.Text;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash.Add(&quot;isReassign&quot;, isReassign);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Update specified task with the specified property value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SPWorkflowTask.AlterTask(TaskItem, taskHash, true);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected void btnReassign_Click(object sender, EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hashtable taskHash = new Hashtable();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;TaskStatus&quot;] = &quot;Inprogress&quot;;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash.Add(&quot;ReAssignedTo&quot;, &quot;administrator&quot;);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SetApprove(&quot;Reassign&quot;, &quot;in process&quot;, taskHash, true);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; commitPopup();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// Cancel the Workflow and task
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; protected void btnCancelTask_Click(object sender, EventArgs e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // cancel the task
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hashtable taskHash = new Hashtable();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;TaskStatus&quot;] = &quot;Canceled&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; taskHash[&quot;Status&quot;] = &quot;Canceled&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SetApprove(&quot;CancelTask&quot;, &quot;Canceled&quot;, taskHash, false);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Cancel the Workflow
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // SPWorkflowManager.CancelWorkflow(WorkflowInstance);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //Close the popup
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; commitPopup();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// Close popup
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private void commitPopup()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (Request[&quot;IsDlg&quot;] == &quot;1&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Context.Response.Write(&quot;&lt;script type='text/javascript'&gt;window.frameElement.commitPopup();&lt;/script&gt;&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Context.Response.Flush();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Context.Response.End();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SPUtility.Redirect(ItemList.DefaultViewUrl, SPRedirectFlags.UseSource, HttpContext.Current);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 9: Deploy and you can debug it.</span><span lang="EN" style="">
</span><span lang="EN" style="font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#676767"><span style="">&nbsp;</span></span></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.workflow.spworkflowtask.altertask.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.workflow.spworkflowtask.altertask.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
