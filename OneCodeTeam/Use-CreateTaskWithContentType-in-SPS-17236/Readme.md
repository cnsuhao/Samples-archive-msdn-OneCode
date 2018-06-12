# Use CreateTaskWithContentType in SPS (CSSharePointTaskWithContentTypeWorkflow)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SharePoint
* CreateTaskWithContentType
## IsPublished
* True
## ModifiedDate
* 2012-06-11 07:08:36
## Description

<h1><span style="">Use CreateTaskWithContentType in SharePoint Visual Studio Workflow
</span>(<span style="">CSSharePointTaskWithContentTypeWorkflow</span>)</h1>
<h2>Introduction </h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The project shows how to use CreateTaskWithContentType activity in a SharePoint Visual Studio workflow.&#8203; &#8203;The CreateTaskWithContentType
 is an import activity in SharePoint visual studio workflow, it will</span> <span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
defines a workflow activity that is used to create a task item in a Microsoft SharePoint 2010 task list, using a specified SharePoint 2010 content type. In the sample, I demonstrate a simple leave approval.
</span></h2>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSSharePointTaskWithContentTypeWorkflow.sln then right click the SharePoint project to edit the &quot;Site Url&quot; to your own.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the &quot;CSSharePointTaskWithContentTypeWorkflow&quot; project and click &quot;Deploy&quot;.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Add the Content Type to your own Workflow Task list.</span>
<span style="">It is necessary. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: Add </span>the workflow &quot;MyWorkflow&quot; <span style="">
to your own Workflow associated list. Start a workflow. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: </span>Open the workflow &quot;MyWorkflow&quot;. A new workflow item has been established.<br style="">
<br style="">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: Open the workflow item then</span> <span style="">to operate.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 7: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style=""><span style="">Step 1: Create a C# </span>Empty SharePoint Project
<span style="">in Visual Studio 2010 and name it as &quot;CSSharePointTaskWithContentTypeWorkflow&quot;.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;
    &lt;!-- Fields for Task of Workflow CreateTaskWithContentTypeWorkflow--&gt;
    &lt;Field ID=&quot;{2FE15855-3CAB-44A6-AB29-1600204FCA20}&quot; Name=&quot;ApproveNote&quot;
           MaxLength=&quot;255&quot; DisplayName=&quot;ApproveNote&quot; Description=&quot;&quot;
           Direction=&quot;None&quot; Type=&quot;Note&quot;
           xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot; /&gt;
    &lt;Field ID=&quot;{517B22A5-1B89-4C24-82BE-3D4FD99645BC}&quot;
        Name=&quot;ApproveType&quot;
        Type=&quot;Choice&quot;
        DisplayName=&quot;ApproveType&quot;
        Format=&quot;RadioButtons&quot; &gt;
        &lt;CHOICES&gt;
            &lt;CHOICE&gt;Pass&lt;/CHOICE&gt;
            &lt;CHOICE&gt;Reject&lt;/CHOICE&gt;
        &lt;/CHOICES&gt;
        &lt;Default&gt;Pass&lt;/Default&gt;
    &lt;/Field&gt;
&lt;/Elements&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;
    &lt;!-- Fields for Task of Workflow CreateTaskWithContentTypeWorkflow--&gt;
    &lt;Field ID=&quot;{2FE15855-3CAB-44A6-AB29-1600204FCA20}&quot; Name=&quot;ApproveNote&quot;
           MaxLength=&quot;255&quot; DisplayName=&quot;ApproveNote&quot; Description=&quot;&quot;
           Direction=&quot;None&quot; Type=&quot;Note&quot;
           xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot; /&gt;
    &lt;Field ID=&quot;{517B22A5-1B89-4C24-82BE-3D4FD99645BC}&quot;
        Name=&quot;ApproveType&quot;
        Type=&quot;Choice&quot;
        DisplayName=&quot;ApproveType&quot;
        Format=&quot;RadioButtons&quot; &gt;
        &lt;CHOICES&gt;
            &lt;CHOICE&gt;Pass&lt;/CHOICE&gt;
            &lt;CHOICE&gt;Reject&lt;/CHOICE&gt;
        &lt;/CHOICES&gt;
        &lt;Default&gt;Pass&lt;/Default&gt;
    &lt;/Field&gt;
&lt;/Elements&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;
    &lt;!-- Parent ContentType: Task (0x0108)--&gt;
    &lt;ContentType ID=&quot;0x01080100FFbc98c2529347a5886b8d2576b954e3&quot;
                     Name=&quot;MyWorkflowTasksContentType&quot;
                     Group=&quot;Custom Content Types&quot; Inherits=&quot;false&quot;
                     Description=&quot;Content Type of Tasks of MyWorkflow&quot;
                   &gt;
        &lt;FieldRefs&gt;
            &lt;FieldRef ID=&quot;{2FE15855-3CAB-44A6-AB29-1600204FCA20}&quot; Name=&quot;ApproveNote&quot; DisplayName=&quot;ApproveNote&quot; /&gt;
            &lt;FieldRef ID=&quot;{517B22A5-1B89-4C24-82BE-3D4FD99645BC}&quot; Name=&quot;ApproveType&quot; DisplayName=&quot;ApproveType&quot; /&gt;




            &lt;FieldRef ID=&quot;{c042a256-787d-4a6f-8a8a-cf6ab767f12d}&quot; Name=&quot;ContentType&quot; /&gt;
            …
        &lt;/FieldRefs&gt;
        &lt;XmlDocuments&gt;
            &lt;XmlDocument NamespaceURI=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms&quot;&gt;
                &lt;FormTemplates xmlns=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms&quot;&gt;
                    &lt;Display&gt;ListForm&lt;/Display&gt;
                    &lt;Edit&gt;ListForm&lt;/Edit&gt;
                    &lt;New&gt;ListForm&lt;/New&gt;
                &lt;/FormTemplates&gt;
            &lt;/XmlDocument&gt;
            &lt;!--If you want to use custom Application Page,uncomment the following lines then modify the url.--&gt;
            &lt;!--&lt;XmlDocument NamespaceURI=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
                &lt;FormUrls xmlns=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
                    &lt;Display&gt;_layouts/yourProject/Display.aspx&lt;/Display&gt;
                    &lt;Edit&gt;_layouts/yourProject/Approve.aspx&lt;/Edit&gt;
                &lt;/FormUrls&gt;
            &lt;/XmlDocument&gt;--&gt;
        &lt;/XmlDocuments&gt;
    &lt;/ContentType&gt;
&lt;/Elements&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Elements xmlns=&quot;http://schemas.microsoft.com/sharepoint/&quot;&gt;
    &lt;!-- Parent ContentType: Task (0x0108)--&gt;
    &lt;ContentType ID=&quot;0x01080100FFbc98c2529347a5886b8d2576b954e3&quot;
                     Name=&quot;MyWorkflowTasksContentType&quot;
                     Group=&quot;Custom Content Types&quot; Inherits=&quot;false&quot;
                     Description=&quot;Content Type of Tasks of MyWorkflow&quot;
                   &gt;
        &lt;FieldRefs&gt;
            &lt;FieldRef ID=&quot;{2FE15855-3CAB-44A6-AB29-1600204FCA20}&quot; Name=&quot;ApproveNote&quot; DisplayName=&quot;ApproveNote&quot; /&gt;
            &lt;FieldRef ID=&quot;{517B22A5-1B89-4C24-82BE-3D4FD99645BC}&quot; Name=&quot;ApproveType&quot; DisplayName=&quot;ApproveType&quot; /&gt;




            &lt;FieldRef ID=&quot;{c042a256-787d-4a6f-8a8a-cf6ab767f12d}&quot; Name=&quot;ContentType&quot; /&gt;
            …
        &lt;/FieldRefs&gt;
        &lt;XmlDocuments&gt;
            &lt;XmlDocument NamespaceURI=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms&quot;&gt;
                &lt;FormTemplates xmlns=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms&quot;&gt;
                    &lt;Display&gt;ListForm&lt;/Display&gt;
                    &lt;Edit&gt;ListForm&lt;/Edit&gt;
                    &lt;New&gt;ListForm&lt;/New&gt;
                &lt;/FormTemplates&gt;
            &lt;/XmlDocument&gt;
            &lt;!--If you want to use custom Application Page,uncomment the following lines then modify the url.--&gt;
            &lt;!--&lt;XmlDocument NamespaceURI=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
                &lt;FormUrls xmlns=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
                    &lt;Display&gt;_layouts/yourProject/Display.aspx&lt;/Display&gt;
                    &lt;Edit&gt;_layouts/yourProject/Approve.aspx&lt;/Edit&gt;
                &lt;/FormUrls&gt;
            &lt;/XmlDocument&gt;--&gt;
        &lt;/XmlDocuments&gt;
    &lt;/ContentType&gt;
&lt;/Elements&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">Inside &quot;FormUrls&quot; tag we specify our custom form template we created.<br>
<b style="">[Note]</b> The new content type is derived from the &quot;Workflow Task&quot; content type 0×010801. The content type id should begin with 0x01080100. In the &quot;FieldRefs&quot; section we add our fields we need inside the workflow.
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 4: Create a &quot;Sequential Workflow&quot; project item named &quot;MyWorkflow&quot;. Create the workflow as &quot;List Workflow&quot;. We manually associate the workflow with lists after it is
 created. <br>
<br>
Step 5: Add a &quot;Create Task With Content Type&quot; workflow activity, it will use the Content Type we have created</span><span style="">.</span>
<span style="">Open the &quot;Toolbox&quot; pane and drag &quot;CreateTaskWithContentType&quot; into the Workflow Designer.</span>
<span style="">Now we need to configure the workflow activity in the &quot;Properties&quot; pane.</span>
<span style="">Set &quot;correlationToken&quot; to &quot;task1&quot; and the sub element of &quot;correlationToken&quot; named &quot;OwnerActivityName&quot; to &quot;MyWorkflow&quot;.</span>
<span style="">Now we need to create code behind properties for some activity properties. As example I'll show how to create a code behind property for &quot;ContentTypeId&quot;.Click on the Button &quot;…&quot; at the activity property edit box:<br>
<br>
</span><span style=""><img src="/site/view/file/59776/1/image.png" alt="" width="297" height="18" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style=""><span lang="EN" style="">In the dialog select the tab &quot;Bind to a new member&quot;. Enter the name &quot;New member name&quot; and select the &quot;Create Property&quot; radio button. Press &quot;OK&quot;.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
&quot;ContentTypeId&quot; = &quot;task1ContentTypeId&quot;
&quot;TaskId&quot; = &quot;task1Guid&quot;
&quot;TaskProperties&quot; = &quot;task1Properties&quot;

</pre>
<pre id="codePreview" class="csharp">
&quot;ContentTypeId&quot; = &quot;task1ContentTypeId&quot;
&quot;TaskId&quot; = &quot;task1Guid&quot;
&quot;TaskProperties&quot; = &quot;task1Properties&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style=""><br>
In &quot;MethodInvoking&quot; type &quot;createTask1Invoke&quot; and press ENTER. – You'll be directed to the code editor. In the method we initialize the task1-Properties we created before. The &quot;ContentTypeId&quot; is taken from the &quot;Schema.xml&quot;
 file of our &quot;</span><span style="">MyWorkflow</span><span lang="EN" style=""> Tasks&quot; list where we created the Content Type &quot;</span><span style="">MyWorkflow</span><span lang="EN" style=""> Task&quot;. After that your method looks like this:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void createTask1Invoke(object sender, EventArgs e)
      {
          task1Properties = new SPWorkflowTaskProperties();           
          task1Properties.Title = string.Format(&quot;Please approval:&atilde;€&#144;{0}&atilde;€'&quot;, this.workflowProperties.Item.DisplayName);
          task1Guid = Guid.NewGuid();
          //This is the Content type which is used by the workFlow
          task1ContentTypeId = &quot;0x01080100FFbc98c2529347a5886b8d2576b954e3&quot;; 
      }

</pre>
<pre id="codePreview" class="csharp">
private void createTask1Invoke(object sender, EventArgs e)
      {
          task1Properties = new SPWorkflowTaskProperties();           
          task1Properties.Title = string.Format(&quot;Please approval:&atilde;€&#144;{0}&atilde;€'&quot;, this.workflowProperties.Item.DisplayName);
          task1Guid = Guid.NewGuid();
          //This is the Content type which is used by the workFlow
          task1ContentTypeId = &quot;0x01080100FFbc98c2529347a5886b8d2576b954e3&quot;; 
      }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style=""><br>
Step 6: Back in the workflow designer. We drag a &quot;While&quot; activity from the Toolbox pane into the workflow behind the &quot;Create Task&quot; activity. Into the &quot;While&quot; activity we drag a &quot;Sequence&quot; property from the Toolbox pane.
 Into the &quot;Sequence&quot; activity we drag a &quot;OnTaskChanged&quot; activity from the Toolbox pane. Now we edit the properties of the created &quot;OnTaskChanged&quot; activity. We have to set the &quot;CorrelationToken&quot; as described above. Additionally
 we specify new property bindings:<br>
<b style="">&quot;AfterProperties&quot; = &quot;task1Changed1_AfterProperties&quot;<br>
&quot;BeforeProperties&quot; = &quot;task1Changed1_BeforeProperties&quot;<br>
&quot;TaskId&quot; =&gt; Bind to the existing member &quot;task1Guid&quot;<br>
</b>In the &quot;Invoked&quot; property add the method name &quot;task1Changed1Invoke&quot;. – The code editor will be opened.
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 7: In the code we add a property at class level:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private bool isFinished = false;

</pre>
<pre id="codePreview" class="csharp">
private bool isFinished = false;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">This property we set inside the &quot;OnWorkflowItemChanged&quot; activity. It will contain the information whether the Workflow Task Item we created before was &quot;Completed&quot; by the assigned user.
 In the &quot;task1Changed1Invoke&quot; method we set the &quot;isFinished&quot; property.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
//Handler of OnTaskChanged
       private void task1Changed1Invoke(object sender, ExternalDataEventArgs e)
       {
           //isFinished = task1Changed1_AfterProperties.PercentComplete == 1F;
           isFinished = (task1Changed1_AfterProperties.ExtendedProperties[SPBuiltInFieldId.TaskStatus].ToString() == &quot;Completed&quot;);         
       }

</pre>
<pre id="codePreview" class="csharp">
//Handler of OnTaskChanged
       private void task1Changed1Invoke(object sender, ExternalDataEventArgs e)
       {
           //isFinished = task1Changed1_AfterProperties.PercentComplete == 1F;
           isFinished = (task1Changed1_AfterProperties.ExtendedProperties[SPBuiltInFieldId.TaskStatus].ToString() == &quot;Completed&quot;);         
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 8: Now we need to specify the condition for the &quot;While&quot; activity. In the workflow designer select this activity. In the &quot;Condition&quot; property select &quot;Code Condition&quot;
 and expand the property. Enter &quot;while1Invoke&quot; in the subproperty with (the same) name &quot;Condition&quot;. In the code editor enter the code for &quot;while1Invoke&quot; like this:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void while1Invoke(object sender, ConditionalEventArgs e)
       {
           e.Result = !isFinished;
       }

</pre>
<pre id="codePreview" class="csharp">
private void while1Invoke(object sender, ConditionalEventArgs e)
       {
           e.Result = !isFinished;
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">The &quot;e.Result&quot; property has to be &quot;TRUE&quot; as long as the while loop should run. It should not run anymore (&quot;e.Result = false&quot;) if &quot;isFinished&quot; is TRUE.
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 9: In the workflow designer add a &quot;CompleteTask&quot; activity behind the &quot;While&quot; activity. Drag the &quot;CompleteTask&quot; activity from the Toolbar pane into the workflow designer.
 Select the &quot;completeTask1&quot; activity and edit its properties in the Property pane.<br>
Bind &quot;TaskId&quot; to the existing member &quot;task1Guid&quot;<br>
Create a new member named &quot;task1Outcome&quot; for binding to &quot;TaskOutcome&quot;. Set the &quot;CorrelationToken&quot; to &quot;task1&quot;</span><b style=""><br>
</b><span lang="EN" style="">Step 10: Deploy and you can debug it.</span><b style="">
</b></p>
<a href="http://msdn.microsoft.com/en-us/library/ms196289.aspx">http://msdn.microsoft.com/en-us/library/ms196289.aspx</a>
<a href="http://msdn.microsoft.com/en-us/library/ms463449.aspx">http://msdn.microsoft.com/en-us/library/ms463449.aspx</a>
<a href="http://msdn.microsoft.com/en-us/library/ms438856.aspx">http://msdn.microsoft.com/en-us/library/ms438856.aspx</a>
<p class="MsoNormal" style=""><br style="">
<br style="">
</p>
<p class="MsoNormal" style=""></p>
<p class="MsoNormal" style=""><br style="">
<br style="">
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
