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
* 2013-09-12 08:17:18
## Description

<h1><span style="">How to develop a custom content type with a workflow associated</span>(<span style="">VBSharePointAssociateWorkflowToContentType</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal" style=""><span style="">This sample code will demonstrate how to develop a custom content type with a workflow associated. In a real world scenario, customers not only need to structure the data but also need to process the data. Therefore
 developing a custom content type with workflow associated is significant for customers. There is seldom information about how to develop a custom content type with workflow associated, so this sample will surely bring a lot of help for customers.&#8203;
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the VBSharePointAssociateWorkflowToContentType.sln file and then set the &quot;Site URL&quot; to your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Open the Feature2.EventReceiver.vb file to modify the &quot;siteName&quot;.
</span></p>
<p class="MsoNormal" style="background:white"><span style=""><br>
Step 3: </span><span style="color:#222222">Go to Shared Documents | List Settings | Advanced settings
<br>
Allow management of content types? : choose yes | OK<br>
Continue, click &quot;Add from existing site content types&quot; link as follows:</span><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:#222222"><br>
</span><span style="font-size:11.5pt; line-height:115%; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#222222"><img src="/site/view/file/96042/1/image.png" alt="" width="885" height="410" align="middle">
</span><span style="font-size:11.5pt; line-height:115%; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#222222"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: </span><span style="color:#222222">Choose </span><span style="">MyContentType and</span>
<span style="color:#222222">then click Add button<br>
</span><span style=""><img src="/site/view/file/96043/1/image.png" alt="" width="455" height="228" align="middle">
</span><span style="color:#222222"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:#222222">The result will be shown as below<br>
</span><span style=""><img src="/site/view/file/96044/1/image.png" alt="" width="464" height="244" align="middle">
</span><span style="color:#222222"><br>
</span><span style="">Step 5: </span>Add a new document.<span style="color:#222222"><br>
</span><span style="">Automatically workflow run as follows:</span><span style="color:#222222">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/96045/1/image.png" alt="" width="1045" height="83" align="middle">
</span><span style=""><br style="">
<br style="">
</span><span style="font-size:9.5pt"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="background:white"><span style="">Step 1: Create a VB &quot;Empty SharePoint Project&quot; in Visual Studio 2010 and named it as &quot;VBSharePointAssociateWorkflowToContentType&quot;.
</span><span style="color:#222222">Deploy as a farm solution.</span><span style="">
</span></p>
<p class="MsoNormal" style="background:white"><span style="">Step 2: Right-click the project and add a new &quot;Content Type&quot; item to our project and named it as &quot;MyContentType&quot;.
<br>
</span><span style="color:#222222">Choose content type Document (option) from DropdownList.<br>
You will see the structure as follows. Then you can change name of Content Type </span>
</p>
<p class="MsoNormal" style="background:white"><span style="color:#222222"><img src="/site/view/file/96046/1/image.png" alt="" width="428" height="155" align="middle">
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
</span><span style=""><img src="/site/view/file/96047/1/image.png" alt="" width="471" height="382" align="middle">
</span><span style="color:#222222"><br>
Set default value and then click Finish<br>
Appear Feature2 when Workflow is added </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: <span style="color:#222222">Right click to Feature2 | Add Event Receiver.<br>
Declare &quot;</span><span style="color:blue">using</span><span style="color:#222222"> Microsoft.SharePoint.Workflow&quot;.<br>
Declare Workflow Name and ContentType Name above method FeatureActivated. </span>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Your site
   Private siteName As String = &quot;http://win-2ed380lbo8e:7947/&quot;
   ' Workflow Name
   Private WorkflowName As String = &quot;WorkflowForContentType&quot;
   ' ContentType Name
   Private ContentTypeName As String = &quot;MyContentType&quot;

</pre>
<pre id="codePreview" class="vb">
' Your site
   Private siteName As String = &quot;http://win-2ed380lbo8e:7947/&quot;
   ' Workflow Name
   Private WorkflowName As String = &quot;WorkflowForContentType&quot;
   ' ContentType Name
   Private ContentTypeName As String = &quot;MyContentType&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal; background:white"><span style="color:#222222">Uncommnet method FeatureActivated and paste this segment code to it.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
UpdateWorkflowAssociation(1)

</pre>
<pre id="codePreview" class="vb">
UpdateWorkflowAssociation(1)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal; background:white"><span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:#222222"><br>
</span><span style="color:#222222">Uncommnet method FeatureDeactivating and paste this segment code to it.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
UpdateWorkflowAssociation(0)

</pre>
<pre id="codePreview" class="vb">
UpdateWorkflowAssociation(0)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style=""><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">The U</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">pdateWorkflowAssociation()
</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">as shown below.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub UpdateWorkflowAssociation(ByVal type As Integer)
       ' Connect to Sharepoint Site
       Using site = New SPSite(siteName)


           ' Open Sharepoint Site
           Using Web = site.OpenWeb()
               ' Get the ContentType by Specific Name
               Dim theCT As SPContentType = Web.ContentTypes(ContentTypeName)
               ' Workflow Template
               Dim theWF As SPWorkflowTemplate = Nothing


               ' Fetch the collection of Workflow Template to get the specific one
               For Each tpl As SPWorkflowTemplate In Web.WorkflowTemplates
                   If tpl.Name = WorkflowName Then
                       theWF = tpl
                   End If
               Next


               ' Represents the association of the workflow template
               Dim wfAssociation As SPWorkflowAssociation = theCT.WorkflowAssociations.GetAssociationByName(WorkflowName, Web.Locale)


               ' If it has associated, remove the association. 
               If wfAssociation IsNot Nothing Then
                   theCT.WorkflowAssociations.Remove(wfAssociation)
               End If


               '  Update Workflow Associations
               theCT.UpdateWorkflowAssociationsOnChildren(True, True, True, False)


               '
               If type &gt; 0 Then
                   ' Create web ContentType association to the workflow template
                   wfAssociation = SPWorkflowAssociation.CreateWebContentTypeAssociation(theWF, WorkflowName, &quot;Tasks&quot;, &quot;Workflow History&quot;)


                   ' If it hasn't associated then to add a association. Or updates the association.
                   If theCT.WorkflowAssociations.GetAssociationByName(wfAssociation.Name, Web.Locale) Is Nothing Then
                       theCT.WorkflowAssociations.Add(wfAssociation)
                   Else
                       theCT.WorkflowAssociations.Update(wfAssociation)
                   End If


                   '  Update Workflow Associations
                   theCT.UpdateWorkflowAssociationsOnChildren(True, True, True, False)
               End If


           End Using
       End Using


   End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub UpdateWorkflowAssociation(ByVal type As Integer)
       ' Connect to Sharepoint Site
       Using site = New SPSite(siteName)


           ' Open Sharepoint Site
           Using Web = site.OpenWeb()
               ' Get the ContentType by Specific Name
               Dim theCT As SPContentType = Web.ContentTypes(ContentTypeName)
               ' Workflow Template
               Dim theWF As SPWorkflowTemplate = Nothing


               ' Fetch the collection of Workflow Template to get the specific one
               For Each tpl As SPWorkflowTemplate In Web.WorkflowTemplates
                   If tpl.Name = WorkflowName Then
                       theWF = tpl
                   End If
               Next


               ' Represents the association of the workflow template
               Dim wfAssociation As SPWorkflowAssociation = theCT.WorkflowAssociations.GetAssociationByName(WorkflowName, Web.Locale)


               ' If it has associated, remove the association. 
               If wfAssociation IsNot Nothing Then
                   theCT.WorkflowAssociations.Remove(wfAssociation)
               End If


               '  Update Workflow Associations
               theCT.UpdateWorkflowAssociationsOnChildren(True, True, True, False)


               '
               If type &gt; 0 Then
                   ' Create web ContentType association to the workflow template
                   wfAssociation = SPWorkflowAssociation.CreateWebContentTypeAssociation(theWF, WorkflowName, &quot;Tasks&quot;, &quot;Workflow History&quot;)


                   ' If it hasn't associated then to add a association. Or updates the association.
                   If theCT.WorkflowAssociations.GetAssociationByName(wfAssociation.Name, Web.Locale) Is Nothing Then
                       theCT.WorkflowAssociations.Add(wfAssociation)
                   Else
                       theCT.WorkflowAssociations.Update(wfAssociation)
                   End If


                   '  Update Workflow Associations
                   theCT.UpdateWorkflowAssociationsOnChildren(True, True, True, False)
               End If


           End Using
       End Using


   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="text-autospace:none"><span style="">Step 5: You can debug and test it.
</span></p>
<p class="MsoNormal" style="">SPWorkflowAssociation Class<br>
<a href="http://msdn.microsoft.com/en-us/library/ms409472">http://msdn.microsoft.com/en-us/library/ms409472</a><br>
SPWorkflowAssociation<span>.</span>CreateWebContentTypeAssociation Method<br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.workflow.spworkflowassociation.createwebcontenttypeassociation.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.workflow.spworkflowassociation.createwebcontenttypeassociation.aspx</a><br>
SPContentType<span>.</span>UpdateWorkflowAssociationsOnChildren Method<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spcontenttype.updateworkflowassociationsonchildren.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spcontenttype.updateworkflowassociationsonchildren.aspx</a><br>
</span>SPContentType Class<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spcontenttype.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spcontenttype.aspx</a><br>
</span>SPWorkflowTemplate Class<br>
<span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.workflow.spworkflowtemplate.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.workflow.spworkflowtemplate.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
