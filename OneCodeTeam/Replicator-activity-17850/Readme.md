# Replicator activity (CSSharepointrReplicatorActivity)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* Workflow
* Replicator Activity
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:42:46
## Description

<h1><span style="">Use replicator activity in SharePoint workflow </span>(<span style="">CSSharePointReplicatorActivity</span>)</h1>
<h2>Introduction </h2>
<p class="MsoPlainText"><span style="">The project shows how to use Replicator activity in a SharePoint Visual Studio workflow.&#8203; &#8203;</span><span style="">In real world, when we develop an approval workflow, we often need to assign task to multiple
 approvers dynamically, so we need to use replicator activity. </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSSharePointReplicatorActivity.sln then right click the SharePoint project to edit the &quot;Site Url&quot; to your own.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the &quot;CSSharePointReplicatorActivity&quot; project and click &quot;Deploy&quot;.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Add the Workflow to a list. Then set the Workflow Association Data which is the approval Partners here.</span><span style="font-size:9.5pt; font-family:Consolas"><br>
<span style=""><img src="/site/view/file/61992/1/image.png" alt="" width="976" height="199" align="middle">
</span></span><br style="">
<br style="">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: After set the approval Partners, you can click the save button to save Association Data.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Start a workflow on the list. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/61993/1/image.png" alt="" width="857" height="69" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: Enter task list. <br>
<span style=""><img src="/site/view/file/61994/1/image.png" alt="" width="998" height="290" align="middle">
</span>. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<a name="OLE_LINK10"></a><a name="OLE_LINK11"><span style=""><span style="">Set the Status to &quot;Completed&quot; then you can observe the status of whole workflow. You will see only if the entire task item is completed the workflow to complete.<br style="">
<br style="">
</span></span></a></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 7: Validation is finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style=""><span style="">Step 1: Create a C# Empty SharePoint Project in Visual Studio 2010 and name it as &quot;CSSharePointReplicatorActivity&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Now we will create all tools we need for our </span><span style="">Workflow<span style="">.
<br>
Create a </span>reusable activity <span style="">for Replicator. </span>We have at least two ways to achieve this<span style="">: one way is to add a
</span>SequentialWorkflow and modify the class inherited from SequenceActivity then move it to the specified directory which in the sample is the project root directory then delete the generated workflow configuration file. The other way is to create a new
 workflow project and add an activity item then move the workflow to our project.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF"><img src="/site/view/file/61995/1/image.png" alt="" width="207" height="34" align="middle">
</span><span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF"><br>
</span><span style="">In the </span><span style="">reusable activity, we set Token and other Property as usual. Token is the same as task.
<br>
</span><span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF"><img src="/site/view/file/61996/1/image.png" alt="" width="272" height="383" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Then we write the while condition and other </span>Invoking methods in code-behind.<span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b style=""><span style="font-size:9.5pt; font-family:Consolas"></span></b></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<a name="OLE_LINK13"></a><a name="OLE_LINK14"><span style=""><span style="">We declare some properties for receiving the value from the workflow.
</span></span></a></p>
<p class="MsoNormal" style=""><span style=""><span style=""><a name="OLE_LINK12"><b style=""><span style="font-size:9.5pt; line-height:115%; font-family:Consolas">Note:
</span></b>You can get the&nbsp;&quot;TaskStatusFieldId&quot; from &quot;AfterProperties.ExtendedProperties&quot; in debugging mode, and then you should use this GUID in your code.</a></span></span><span style=""><span style=""><span style=""><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">
</span></span></span></span><span style=""><span style=""><span style=""><span style="">Then build your project.</span></span></span></span><span style=""><span style=""><span style=""><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">
</span></span></span></span></p>
<img src="/site/view/file/61997/1/image.png" alt="" width="285" height="384" align="middle">
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN" style="">Handle &quot;</span>Initialized&quot; and &quot;ChildInitialized&quot; events of ReplicatorActivity. And set value for<span style="font-size:9.5pt; font-family:Consolas"> &quot;</span><span style="">InitialChildData&quot; property.</span><span style="font-size:9.5pt; font-family:Consolas; color:green">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
//workflowId
       public Guid workflowId = default(System.Guid);
       //workflowProperties
       public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();


       //handler of OnWorkflowActivated
       private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
       {
           workflowId = workflowProperties.WorkflowId;
       }


       private void replicatorActivity1_Initialized(object sender, EventArgs e)
       {
           //Create a set of InitialChildData for task
           //Anti-serialization workflowProperties.InitiationData to get the initial form instance
           XmlSerializer serializer = new XmlSerializer(typeof(AssociationData));
           XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(workflowProperties.AssociationData));
           AssociationData wfData = (AssociationData)serializer.Deserialize(reader);


           //Set InitialChild Data
           InitialChildData = new ArrayList();
           for (int i = 0; i &lt; wfData.Partners.ContactList.Count; i&#43;&#43;)
           {
               InitialChildData.Add(wfData.Partners.ContactList[i]);
           }
          
           //Set data for first task       
           reTasksActivity1.TaskAssignedTo = InitialChildData[InitialChildData.Count - 1].ToString();
           reTasksActivity1.TaskTitle = &quot;Vacation Request Approval&quot;;
           reTasksActivity1.TaskDescription = &quot;Approve Vacation&quot;;
           reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7);
       }


       private void rePlicatorActivity_ChildInitialized(object sender, ReplicatorChildEventArgs e)
       {
           //Looping through each assignee   
           reTasksActivity1.TaskAssignedTo = e.InstanceData.ToString();
           reTasksActivity1.TaskTitle = &quot;Vacation Request Approval&quot;;
           reTasksActivity1.TaskDescription = &quot;Approve Vacation&quot;;
           reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7);
       }

</pre>
<pre id="codePreview" class="csharp">
//workflowId
       public Guid workflowId = default(System.Guid);
       //workflowProperties
       public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();


       //handler of OnWorkflowActivated
       private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
       {
           workflowId = workflowProperties.WorkflowId;
       }


       private void replicatorActivity1_Initialized(object sender, EventArgs e)
       {
           //Create a set of InitialChildData for task
           //Anti-serialization workflowProperties.InitiationData to get the initial form instance
           XmlSerializer serializer = new XmlSerializer(typeof(AssociationData));
           XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(workflowProperties.AssociationData));
           AssociationData wfData = (AssociationData)serializer.Deserialize(reader);


           //Set InitialChild Data
           InitialChildData = new ArrayList();
           for (int i = 0; i &lt; wfData.Partners.ContactList.Count; i&#43;&#43;)
           {
               InitialChildData.Add(wfData.Partners.ContactList[i]);
           }
          
           //Set data for first task       
           reTasksActivity1.TaskAssignedTo = InitialChildData[InitialChildData.Count - 1].ToString();
           reTasksActivity1.TaskTitle = &quot;Vacation Request Approval&quot;;
           reTasksActivity1.TaskDescription = &quot;Approve Vacation&quot;;
           reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7);
       }


       private void rePlicatorActivity_ChildInitialized(object sender, ReplicatorChildEventArgs e)
       {
           //Looping through each assignee   
           reTasksActivity1.TaskAssignedTo = e.InstanceData.ToString();
           reTasksActivity1.TaskTitle = &quot;Vacation Request Approval&quot;;
           reTasksActivity1.TaskDescription = &quot;Approve Vacation&quot;;
           reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7);
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 5: In the Properties Panel of Replicator Activity set the value of ExecutionType to &quot;Parallel&quot;.
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 6: You can deploy and debug it.</span><b style="">
</b></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
