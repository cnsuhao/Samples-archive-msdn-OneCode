# How to develop a custom content type with associated workflow in SharePoint
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* SharePoint
* SharePoint Development
## Topics
* SharePoint
## IsPublished
* True
## ModifiedDate
* 2013-09-12 08:17:21
## Description

<h1><a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style=""><span style="">How to develop a custom content type with a workflow associated</span></span></a><a name="OLE_LINK4"></a><a name="OLE_LINK3"><span style=""><span style=""><span style="">(</span></span></span></a><span style=""><span style=""><span style=""><span style=""><span style="">CSSharePointAssociateWorkflowToContentType</span>)</span></span></span></span><span style=""><span style=""></span></span></h1>
<h2>Introduction </h2>
<p class="MsoNormal" style=""><span style="">This sample code will demonstrate how to develop a custom content type with a workflow associated. In a real world scenario, customers not only need to structure the data but also need to process the data, so develop
 a custom content type with workflow associated is significant for customers. There is seldom information about how to develop a custom content type with workflow associated, so this sample will surely bring a lot of help for customers.&#8203;
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the CSSharePointAssociateWorkflowToContentType.sln file and then set the &quot;Site URL&quot; to your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Open the Feature2.EventReceiver.cs file to modify the &quot;siteName&quot;.
</span></p>
<p class="MsoNormal" style="background:white"><span style=""><br>
Step 3: </span><span style="color:#222222">Go to Shared Documents | List Settings | Advanced settings
<br>
Allow management of content types? : choose yes | OK<br>
Continue, click &quot;Add from existing site content types&quot; link as follows:</span><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:#222222"><br>
</span><span style="font-size:11.5pt; line-height:115%; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#222222"><img src="/site/view/file/96049/1/image.png" alt="" width="885" height="410" align="middle">
</span><span style="font-size:11.5pt; line-height:115%; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#222222"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: </span><span style="color:#222222">Choose </span><span style="">MyContentType</span>
<span style="color:#222222">then click Add button<br>
</span><span style=""><img src="/site/view/file/96050/1/image.png" alt="" width="455" height="228" align="middle">
</span><span style="color:#222222"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:#222222">The result will be shown as below<br>
</span><span style=""><img src="/site/view/file/96051/1/image.png" alt="" width="464" height="244" align="middle">
</span><span style="color:#222222"><br>
</span><span style="">Step 5: </span>Add a new document.<span style="color:#222222"><br>
</span><span style="">Automatically workflow run as follows:</span><span style="color:#222222">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/96052/1/image.png" alt="" width="1045" height="83" align="middle">
</span><span style=""><br style="">
<br style="">
</span><span style="font-size:9.5pt"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="background:white"><span style="">Step 1: Create a C# &quot;Empty SharePoint Project&quot; in Visual Studio 2010 and named it as &quot;CSSharePointAssociateWorkflowToContentType&quot;.
</span><span style="color:#222222">Deploy as a farm solution.</span><span style="">
</span></p>
<p class="MsoNormal" style="background:white"><span style="">Step 2: Right-click the project and add a new &quot;Content Type&quot; item to our project and named it as &quot;MyContentType&quot;.
<br>
</span><span style="color:#222222">Choose content type Document (option) from DropdownList.<br>
You see the structure as follows then you can change name of Content Type </span>
</p>
<p class="MsoNormal" style="background:white"><span style="color:#222222"><img src="/site/view/file/96053/1/image.png" alt="" width="428" height="155" align="middle">
</span><span style="color:#222222"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: <span style="color:#222222">Right click to project | Add | New Item…<br>
<span style="">&nbsp;</span>Choose Sequential Workflow and type name is WorkflowForContentType<br>
Type name for workflow is WorkflowForContentType<br>
Choose library or list, history list, task list as follows:<br>
</span><span style=""><img src="/site/view/file/96054/1/image.png" alt="" width="471" height="382" align="middle">
</span><span style="color:#222222"><br>
Set default then click Finish<br>
Appear Feature2 when Workflow is added </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: <span style="color:#222222">Right click to Feature2 | Add Event Receiver.<br>
Declare &quot;</span><span style="color:blue">using</span><span style="color:#222222"> Microsoft.SharePoint.Workflow&quot;.<br>
Declare Workflow Name and ContentType Name above method FeatureActivated. </span>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Your site
       private string siteName = &quot;http://win-2ed380lbo8e:7947/&quot;;
       // Workflow Name
       private string WorkflowName = &quot;WorkflowForContentType&quot;;
       // ContentType Name
       private string ContentTypeName = &quot;MyContentType&quot;;

</pre>
<pre id="codePreview" class="csharp">
// Your site
       private string siteName = &quot;http://win-2ed380lbo8e:7947/&quot;;
       // Workflow Name
       private string WorkflowName = &quot;WorkflowForContentType&quot;;
       // ContentType Name
       private string ContentTypeName = &quot;MyContentType&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal; background:white"><span style="color:#222222">Uncommnet method FeatureActivated and paste this segment code to within it.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
UpdateWorkflowAssociation(1);

</pre>
<pre id="codePreview" class="csharp">
UpdateWorkflowAssociation(1);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal; background:white"><span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:#222222"><br>
</span><span style="color:#222222">Uncommnet method FeatureDeactivating and paste this segment code to within it.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
UpdateWorkflowAssociation(0);

</pre>
<pre id="codePreview" class="csharp">
UpdateWorkflowAssociation(0);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style=""><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">The U</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">pdateWorkflowAssociation()
</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">as shown below.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
       /// Set the associated between workflow and Content Type.
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;type&quot;&gt;0: Remove; 1: Add or update&lt;/param&gt;
       private void UpdateWorkflowAssociation(int type)
       {
           // Connect to Sharepoint Site
           using (SPSite site = new SPSite(siteName))
           {
               // Open Sharepoint Site
               using (SPWeb web = site.OpenWeb())
               {
                   // Get the ContentType by Specific Name
                   SPContentType theCT = web.ContentTypes[ContentTypeName];
                   // Workflow Template
                   SPWorkflowTemplate theWF = null;


                   // Fetch the collection of Workflow Template to get the specific one
                   foreach (SPWorkflowTemplate tpl in web.WorkflowTemplates)
                   {
                       if (tpl.Name == WorkflowName)
                       {
                           theWF = tpl;
                       }
                   }


                   // Represents the association of the workflow template
                   SPWorkflowAssociation wfAssociation = theCT.WorkflowAssociations.GetAssociationByName(WorkflowName, web.Locale);


                   // If it has associated, remove the association. 
                   if (wfAssociation != null)
                   {
                       theCT.WorkflowAssociations.Remove(wfAssociation);
                   }


                   //  Update Workflow Associations
                   theCT.UpdateWorkflowAssociationsOnChildren(true, true, true, false);


                   //
                   if (type &gt; 0)
                   {
                       // Create web ContentType association to the workflow template
                       wfAssociation = SPWorkflowAssociation.CreateWebContentTypeAssociation(theWF, WorkflowName, &quot;Tasks&quot;, &quot;Workflow History&quot;);


                       // If it hasn't associated then to add a association. Or updates the association.
                       if (theCT.WorkflowAssociations.GetAssociationByName(wfAssociation.Name, web.Locale) == null)
                       {
                           theCT.WorkflowAssociations.Add(wfAssociation);
                       }
                       else
                       {
                           theCT.WorkflowAssociations.Update(wfAssociation);
                       }


                       //  Update Workflow Associations
                       theCT.UpdateWorkflowAssociationsOnChildren(true, true, true, false);
                   }
               }
           }
       }

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
       /// Set the associated between workflow and Content Type.
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;type&quot;&gt;0: Remove; 1: Add or update&lt;/param&gt;
       private void UpdateWorkflowAssociation(int type)
       {
           // Connect to Sharepoint Site
           using (SPSite site = new SPSite(siteName))
           {
               // Open Sharepoint Site
               using (SPWeb web = site.OpenWeb())
               {
                   // Get the ContentType by Specific Name
                   SPContentType theCT = web.ContentTypes[ContentTypeName];
                   // Workflow Template
                   SPWorkflowTemplate theWF = null;


                   // Fetch the collection of Workflow Template to get the specific one
                   foreach (SPWorkflowTemplate tpl in web.WorkflowTemplates)
                   {
                       if (tpl.Name == WorkflowName)
                       {
                           theWF = tpl;
                       }
                   }


                   // Represents the association of the workflow template
                   SPWorkflowAssociation wfAssociation = theCT.WorkflowAssociations.GetAssociationByName(WorkflowName, web.Locale);


                   // If it has associated, remove the association. 
                   if (wfAssociation != null)
                   {
                       theCT.WorkflowAssociations.Remove(wfAssociation);
                   }


                   //  Update Workflow Associations
                   theCT.UpdateWorkflowAssociationsOnChildren(true, true, true, false);


                   //
                   if (type &gt; 0)
                   {
                       // Create web ContentType association to the workflow template
                       wfAssociation = SPWorkflowAssociation.CreateWebContentTypeAssociation(theWF, WorkflowName, &quot;Tasks&quot;, &quot;Workflow History&quot;);


                       // If it hasn't associated then to add a association. Or updates the association.
                       if (theCT.WorkflowAssociations.GetAssociationByName(wfAssociation.Name, web.Locale) == null)
                       {
                           theCT.WorkflowAssociations.Add(wfAssociation);
                       }
                       else
                       {
                           theCT.WorkflowAssociations.Update(wfAssociation);
                       }


                       //  Update Workflow Associations
                       theCT.UpdateWorkflowAssociationsOnChildren(true, true, true, false);
                   }
               }
           }
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="text-autospace:none"><span style="">Step 5: You can debug and test it.
</span></p>
<p class="MsoNormal" style=""><span class="SpellE">SPWorkflowAssociation</span> Class<br>
<a href="http://msdn.microsoft.com/en-us/library/ms409472">http://msdn.microsoft.com/en-us/library/ms409472</a><br>
<span class="SpellE">SPWorkflowAssociation<span>.</span>CreateWebContentTypeAssociation</span> Method<br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.workflow.spworkflowassociation.createwebcontenttypeassociation.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.workflow.spworkflowassociation.createwebcontenttypeassociation.aspx</a><br>
<span class="SpellE">SPContentType<span>.</span>UpdateWorkflowAssociationsOnChildren</span> Method<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spcontenttype.updateworkflowassociationsonchildren.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spcontenttype.updateworkflowassociationsonchildren.aspx</a><br>
</span><span class="SpellE">SPContentType</span> Class<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spcontenttype.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spcontenttype.aspx</a><br>
</span><span class="SpellE">SPWorkflowTemplate</span> Class<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.workflow.spworkflowtemplate.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.workflow.spworkflowtemplate.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
