# UpdateTask activity (CSSharePointUpdateTaskActivity)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* Workflow
* UpdateTask Activity
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:44:56
## Description

<h1><span style="">How to use UpdateTask activity </span>(<span style="">CSSharePointUpdateTaskActivity</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">The project illustrates how to Use <span class="SpellE">
UpdateTask</span> activity in SharePoint Visual Studio Workflow. In this sample, we assume that the approval requires two steps, the first person (the Approver) completes the first step in the approval and then we will re-register the workflow to the second
 person.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSSharePointUpdateTaskActivity.sln. Set the &quot;Site URL&quot; property of the project to the URL of your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;</span> </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the &quot;CSSharePointUpdateTaskActivity&quot; project and click &quot;Deploy&quot;.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Add </span>the workflow <span style="">to your own Workflow associated list. Start a workflow.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: </span>Open the workflow. A new workflow item has been established.<br style="">
<br style="">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Open the workflow item then</span> <span style="">to operate. See the log on history list.<br>
<span style=""><img src="/site/view/file/62010/1/image.png" alt="" width="878" height="255" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style=""><span style="">Step 1: Create a C# </span>Empty SharePoint Project
<span style="">in Visual Studio 2010 and name it as &quot;CSSharePointUpdateTaskActivity&quot;.
</span></p>
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


    &lt;FieldRefs&gt;
        …
    &lt;/FieldRefs&gt;


    &lt;XmlDocuments&gt;
        &lt;XmlDocument NamespaceURI=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
            &lt;FormUrls xmlns=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
                &lt;Edit&gt;_layouts/MyWorkflow/UpdateTaskWF2/TaskEditForm.aspx&lt;/Edit&gt;                
            &lt;/FormUrls&gt;
        &lt;/XmlDocument&gt;
    &lt;/XmlDocuments&gt;
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


    &lt;FieldRefs&gt;
        …
    &lt;/FieldRefs&gt;


    &lt;XmlDocuments&gt;
        &lt;XmlDocument NamespaceURI=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
            &lt;FormUrls xmlns=&quot;http://schemas.microsoft.com/sharepoint/v3/contenttype/forms/url&quot;&gt;
                &lt;Edit&gt;_layouts/MyWorkflow/UpdateTaskWF2/TaskEditForm.aspx&lt;/Edit&gt;                
            &lt;/FormUrls&gt;
        &lt;/XmlDocument&gt;
    &lt;/XmlDocuments&gt;
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
       Name=&quot;UpdateTaskWF2&quot;
       Description=&quot;UpdateTaskWF2&quot;
       Id=&quot;679d6ed9-9361-4558-8bc1-143c801d833a&quot;
      CodeBesideClass=&quot;MyWorkflow.UpdateTaskWF2.UpdateTaskWF2&quot;
      CodeBesideAssembly=&quot;$assemblyname$&quot;     
       TaskListContentTypeId=&quot;0x01080100655E7E0BCBA64431B9266D69CB53A7BA&quot;
      &gt;  
        &lt;Categories/&gt;
        &lt;MetaData&gt;
            &lt;AssociationCategories&gt;List&lt;/AssociationCategories&gt;
            &lt;StatusPageUrl&gt;_layouts/WrkStat.aspx&lt;/StatusPageUrl&gt;
        &lt;/MetaData&gt;
    &lt;/Workflow&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Workflow
       Name=&quot;UpdateTaskWF2&quot;
       Description=&quot;UpdateTaskWF2&quot;
       Id=&quot;679d6ed9-9361-4558-8bc1-143c801d833a&quot;
      CodeBesideClass=&quot;MyWorkflow.UpdateTaskWF2.UpdateTaskWF2&quot;
      CodeBesideAssembly=&quot;$assemblyname$&quot;     
       TaskListContentTypeId=&quot;0x01080100655E7E0BCBA64431B9266D69CB53A7BA&quot;
      &gt;  
        &lt;Categories/&gt;
        &lt;MetaData&gt;
            &lt;AssociationCategories&gt;List&lt;/AssociationCategories&gt;
            &lt;StatusPageUrl&gt;_layouts/WrkStat.aspx&lt;/StatusPageUrl&gt;
        &lt;/MetaData&gt;
    &lt;/Workflow&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style=""><br>
Step 4: Add a &quot;Create Task&quot; workflow activity</span><span style="">.</span>
<span style="">We need to configure the workflow activity in the &quot;Properties&quot; pane.</span>
<span style="">Set &quot;<a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style="">correlation</span></a>Token&quot; to &quot;task1&quot; and the sub element of &quot;correlationToken&quot; named &quot;OwnerActivityName&quot; to &quot;UpdateTaskWF2&quot;.</span>
 C<span style="">reate code behind properties for some activity properties, such as:</span>
<b><span style="">TaskProperties</span></b><span style=""> etc….<br>
</span><span lang="EN" style="">Declare all needed properties. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public Guid workflowId = default(System.Guid);
       public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();


       // fields to store initiation data from initiation form     
       public string Approver = default(string); //Approver     
      
       #region Workflow history
       public String HistoryDescription = default(System.String);
       public String HistoryOutcome = default(System.String);
       #endregion
       
       public Guid TaskId = default(System.Guid);
       public SPWorkflowTaskProperties TaskProperties = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
       string TaskStatus = &quot;Pending Approval&quot;;


       /// &lt;summary&gt;
       /// SpecialPermissions
       /// &lt;/summary&gt;
       public HybridDictionary SpecialPermissions
       {
           get
           {
               HybridDictionary taskPermissions = new HybridDictionary();
               taskPermissions[TaskProperties.AssignedTo] = SPRoleType.Contributor;
               return taskPermissions;
           }
       }


       //AfterProperties of OnTaskChanged
       public SPWorkflowTaskProperties TaskAfterProperties = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();


       //Flag for while.
       private bool isFinished = false;

</pre>
<pre id="codePreview" class="csharp">
public Guid workflowId = default(System.Guid);
       public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();


       // fields to store initiation data from initiation form     
       public string Approver = default(string); //Approver     
      
       #region Workflow history
       public String HistoryDescription = default(System.String);
       public String HistoryOutcome = default(System.String);
       #endregion
       
       public Guid TaskId = default(System.Guid);
       public SPWorkflowTaskProperties TaskProperties = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
       string TaskStatus = &quot;Pending Approval&quot;;


       /// &lt;summary&gt;
       /// SpecialPermissions
       /// &lt;/summary&gt;
       public HybridDictionary SpecialPermissions
       {
           get
           {
               HybridDictionary taskPermissions = new HybridDictionary();
               taskPermissions[TaskProperties.AssignedTo] = SPRoleType.Contributor;
               return taskPermissions;
           }
       }


       //AfterProperties of OnTaskChanged
       public SPWorkflowTaskProperties TaskAfterProperties = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();


       //Flag for while.
       private bool isFinished = false;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style=""><br>
Create method for CreateTask Method Invoking. Your method looks like this: </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void createTask1_MethodInvoking(object sender, EventArgs e)
      {
          // generate new GUID used to initialize task correlation token 
          TaskId = Guid.NewGuid();


          // assign initial properties prior to task creation 
          TaskProperties.Title = string.Format(&quot;Review:[{0}]&quot;, this.workflowProperties.Item.DisplayName);
          TaskProperties.PercentComplete = 0;
          TaskProperties.StartDate = DateTime.Today;
          TaskProperties.DueDate = DateTime.Today.AddDays(3);
          TaskProperties.ExtendedProperties[&quot;TaskStatus&quot;] = TaskStatus;
          TaskProperties.AssignedTo = Approver;


          createApprovalTask.SpecialPermissions = SpecialPermissions;
      }

</pre>
<pre id="codePreview" class="csharp">
private void createTask1_MethodInvoking(object sender, EventArgs e)
      {
          // generate new GUID used to initialize task correlation token 
          TaskId = Guid.NewGuid();


          // assign initial properties prior to task creation 
          TaskProperties.Title = string.Format(&quot;Review:[{0}]&quot;, this.workflowProperties.Item.DisplayName);
          TaskProperties.PercentComplete = 0;
          TaskProperties.StartDate = DateTime.Today;
          TaskProperties.DueDate = DateTime.Today.AddDays(3);
          TaskProperties.ExtendedProperties[&quot;TaskStatus&quot;] = TaskStatus;
          TaskProperties.AssignedTo = Approver;


          createApprovalTask.SpecialPermissions = SpecialPermissions;
      }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style=""><br>
Step 5: Back in the workflow designer. We drag a &quot;While&quot; activity from the Toolbox pane into the workflow behind the &quot;Create Task&quot; activity. Into the &quot;While&quot; activity we drag a &quot;Sequence&quot; property from the Toolbox pane.
 Into the &quot;Sequence&quot; activity we drag an &quot;OnTaskChanged&quot; activity and an &quot;Updatetask&quot; activity from the Toolbox pane. Now we edit the properties of the created activity. We have to set the &quot;CorrelationToken&quot; as described
 above. Additionally we specify new property bindings:<b style=""> &quot;AfterProperties&quot;, &quot;BeforeProperties&quot; and &quot;TaskId&quot; etc…<br>
</b>In the &quot;Invoked&quot; property add the method name &quot;onTaskChanged_Invoked&quot; and &quot;</span><span style="color:black">updateTask1_MethodInvoking</span><span lang="EN" style="">&quot; for each activity.
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 6: &quot;</span><span style="color:black">isFinished</span><span lang="EN" style="">&quot; will contain the information whether the Workflow Task Item we created before was &quot;Completed&quot;
 by the assigned user. In the &quot;onTaskChanged_Invoked&quot; method we set the &quot;isFinished&quot; property.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
//Handler of OnTaskChanged
       private void onTaskChanged_Invoked(object sender, ExternalDataEventArgs e)
       {
           //If this is the second approval, complete the workflow.
           if (!TaskProperties.AssignedTo.Equals(Approver))
           {
               isFinished = (TaskAfterProperties.ExtendedProperties[&quot;TaskStatus&quot;].ToString() == &quot;Completed&quot;);
           }
       }

</pre>
<pre id="codePreview" class="csharp">
//Handler of OnTaskChanged
       private void onTaskChanged_Invoked(object sender, ExternalDataEventArgs e)
       {
           //If this is the second approval, complete the workflow.
           if (!TaskProperties.AssignedTo.Equals(Approver))
           {
               isFinished = (TaskAfterProperties.ExtendedProperties[&quot;TaskStatus&quot;].ToString() == &quot;Completed&quot;);
           }
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">In the &quot;updateTask1_MethodInvoking&quot; we modify the property of Task Item.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void updateTask1_MethodInvoking(object sender, EventArgs e)
       {
           //If this is the first approval, re-register the workflow to the second person.
           if (TaskProperties.AssignedTo.Equals(Approver))
           {
               int itemId = TaskAfterProperties.TaskItemId;
               updateTask1.TaskProperties.TaskItemId = itemId;
               updateTask1.TaskProperties.AssignedTo = &quot;Seiya-MSFT\\Seiya&quot;;


              
updateTask1.TaskProperties.Title = string.Format(&quot;【{0}】&quot;, this.workflowProperties.Item.DisplayName);


               updateTask1.TaskProperties.DueDate = DateTime.Today.AddDays(5);
           }
       }

</pre>
<pre id="codePreview" class="csharp">
private void updateTask1_MethodInvoking(object sender, EventArgs e)
       {
           //If this is the first approval, re-register the workflow to the second person.
           if (TaskProperties.AssignedTo.Equals(Approver))
           {
               int itemId = TaskAfterProperties.TaskItemId;
               updateTask1.TaskProperties.TaskItemId = itemId;
               updateTask1.TaskProperties.AssignedTo = &quot;Seiya-MSFT\\Seiya&quot;;


              
updateTask1.TaskProperties.Title = string.Format(&quot;【{0}】&quot;, this.workflowProperties.Item.DisplayName);


               updateTask1.TaskProperties.DueDate = DateTime.Today.AddDays(5);
           }
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:black"><span style="">&nbsp;</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>updateTask1.TaskProperties.Title = </span><span style="color:blue">string</span><span style="color:black">.Format(</span><span style="color:#A31515">&quot;</span><span lang="ZH-CN" style="font-size:9.5pt; font-family:宋体; color:#A31515">【</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">{0}</span><span lang="ZH-CN" style="font-size:9.5pt; font-family:宋体; color:#A31515">】</span><span style="color:#A31515">&quot;</span><span style="color:black">,
</span><span style="color:blue">this</span><span style="color:black">.workflowProperties.Item.DisplayName);
</span></p>
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
<p class="MsoNormal" style=""><span lang="EN" style="">Step 8: In the workflow designer add a &quot;CompleteTask&quot; activity behind the &quot;While&quot; activity. Drag the &quot;CompleteTask&quot; activity from the Toolbar pane into the workflow designer.
 Select the CompleteTask activity and edit its properties in the Property pane.<br>
Step 9: Custom edit page: TaskEditForm.aspx. You can add it by adding an Application Page then dragging it to workflow.<br>
The code as shown below: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected override void OnInit(EventArgs e)
       {
           btnApprove.Click &#43;= new EventHandler(btnApprove_Click);
           btnReject.Click &#43;= new EventHandler(btnReject_Click);
           btnCancel.Click &#43;= new EventHandler(btnCancel_Click);
       }


       protected string ListId;//List Id
       protected SPList TaskList;//Task List
       protected SPListItem TaskItem;//Task Item
       protected Guid WorkflowInstanceId;//WorkflowInstance Id
       protected SPWorkflow WorkflowInstance;//Workflow Instance
       protected SPList ItemList;//Item List
       protected SPListItem Item;//SPListItem
       protected SPWorkflowTask Task;//SPWorkflowTask
       protected string TaskName;


       protected override void OnLoad(EventArgs e)
       {


           ListId = Request.QueryString[&quot;List&quot;];
           TaskList = Web.Lists[new Guid(ListId)];
           TaskItem = TaskList.GetItemById(Convert.ToInt32(Request.Params[&quot;ID&quot;]));
           WorkflowInstanceId = new Guid((string)TaskItem[&quot;WorkflowInstanceID&quot;]);
           WorkflowInstance = new SPWorkflow(Web, WorkflowInstanceId);
           Task = WorkflowInstance.Tasks[0];
           ItemList = WorkflowInstance.ParentList;
           Item = ItemList.GetItemById(WorkflowInstance.ItemId);
           TaskName = TaskItem[&quot;Title&quot;].ToString();


           //Url of the Item
           string UrlToItem = Web.Site.MakeFullUrl(ItemList.RootFolder.Url &#43;
                                                   @&quot;\DispForm.aspx?ID=&quot; &#43;
                                                   Item.ID.ToString());
           string ItemName;
           if (Item.File != null)
           {
               ItemName = Item.File.Name;
           }
           else
           {
               ItemName = Item.Title;
           }


           //bind value to control
           lnkItem.Text = ItemName;
           lnkItem.NavigateUrl = UrlToItem;
           lblListName.Text = ItemList.Title;
           lblSiteUrl.Text = Web.Url;
       }


       /// &lt;summary&gt;
       /// Approve event
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       protected void btnApprove_Click(object sender, EventArgs e)
       {
           SetApprove(&quot;Approved&quot;);
           commitPopup();
       }


       /// &lt;summary&gt;
       /// Rejected event
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       protected void btnReject_Click(object sender, EventArgs e)
       {
           SetApprove(&quot;Rejected&quot;);
           commitPopup();
       }


       /// &lt;summary&gt;
       /// Cancel
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       protected void btnCancel_Click(object sender, EventArgs e)
       {
           commitPopup();
       }


       /// &lt;summary&gt;
       /// Approve operate
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;strFlag&quot;&gt;&lt;/param&gt;
       private void SetApprove(string strFlag)
       {
           Hashtable taskHash = new Hashtable();
           taskHash[&quot;TaskStatus&quot;] = &quot;Completed&quot;;
           taskHash[&quot;TaskOutcome&quot;] = strFlag;
           taskHash[&quot;Outcome&quot;] = strFlag;
           taskHash[&quot;ApproverComments&quot;] = txtComments.Text;


           //Update specified task with the specified property value
           SPWorkflowTask.AlterTask(TaskItem, taskHash, true);
       }


       /// &lt;summary&gt;
       /// Close popup
       /// &lt;/summary&gt;
       private void commitPopup()
       {
           if (Request[&quot;IsDlg&quot;] == &quot;1&quot;)
           {
               Context.Response.Write(&quot;&lt;script type='text/javascript'&gt;window.frameElement.commitPopup();&lt;/script&gt;&quot;);
               Context.Response.Flush();
               Context.Response.End();
           }
           else
           {
               SPUtility.Redirect(ItemList.DefaultViewUrl, SPRedirectFlags.UseSource, HttpContext.Current);
           }
       }

</pre>
<pre id="codePreview" class="csharp">
protected override void OnInit(EventArgs e)
       {
           btnApprove.Click &#43;= new EventHandler(btnApprove_Click);
           btnReject.Click &#43;= new EventHandler(btnReject_Click);
           btnCancel.Click &#43;= new EventHandler(btnCancel_Click);
       }


       protected string ListId;//List Id
       protected SPList TaskList;//Task List
       protected SPListItem TaskItem;//Task Item
       protected Guid WorkflowInstanceId;//WorkflowInstance Id
       protected SPWorkflow WorkflowInstance;//Workflow Instance
       protected SPList ItemList;//Item List
       protected SPListItem Item;//SPListItem
       protected SPWorkflowTask Task;//SPWorkflowTask
       protected string TaskName;


       protected override void OnLoad(EventArgs e)
       {


           ListId = Request.QueryString[&quot;List&quot;];
           TaskList = Web.Lists[new Guid(ListId)];
           TaskItem = TaskList.GetItemById(Convert.ToInt32(Request.Params[&quot;ID&quot;]));
           WorkflowInstanceId = new Guid((string)TaskItem[&quot;WorkflowInstanceID&quot;]);
           WorkflowInstance = new SPWorkflow(Web, WorkflowInstanceId);
           Task = WorkflowInstance.Tasks[0];
           ItemList = WorkflowInstance.ParentList;
           Item = ItemList.GetItemById(WorkflowInstance.ItemId);
           TaskName = TaskItem[&quot;Title&quot;].ToString();


           //Url of the Item
           string UrlToItem = Web.Site.MakeFullUrl(ItemList.RootFolder.Url &#43;
                                                   @&quot;\DispForm.aspx?ID=&quot; &#43;
                                                   Item.ID.ToString());
           string ItemName;
           if (Item.File != null)
           {
               ItemName = Item.File.Name;
           }
           else
           {
               ItemName = Item.Title;
           }


           //bind value to control
           lnkItem.Text = ItemName;
           lnkItem.NavigateUrl = UrlToItem;
           lblListName.Text = ItemList.Title;
           lblSiteUrl.Text = Web.Url;
       }


       /// &lt;summary&gt;
       /// Approve event
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       protected void btnApprove_Click(object sender, EventArgs e)
       {
           SetApprove(&quot;Approved&quot;);
           commitPopup();
       }


       /// &lt;summary&gt;
       /// Rejected event
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       protected void btnReject_Click(object sender, EventArgs e)
       {
           SetApprove(&quot;Rejected&quot;);
           commitPopup();
       }


       /// &lt;summary&gt;
       /// Cancel
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       protected void btnCancel_Click(object sender, EventArgs e)
       {
           commitPopup();
       }


       /// &lt;summary&gt;
       /// Approve operate
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;strFlag&quot;&gt;&lt;/param&gt;
       private void SetApprove(string strFlag)
       {
           Hashtable taskHash = new Hashtable();
           taskHash[&quot;TaskStatus&quot;] = &quot;Completed&quot;;
           taskHash[&quot;TaskOutcome&quot;] = strFlag;
           taskHash[&quot;Outcome&quot;] = strFlag;
           taskHash[&quot;ApproverComments&quot;] = txtComments.Text;


           //Update specified task with the specified property value
           SPWorkflowTask.AlterTask(TaskItem, taskHash, true);
       }


       /// &lt;summary&gt;
       /// Close popup
       /// &lt;/summary&gt;
       private void commitPopup()
       {
           if (Request[&quot;IsDlg&quot;] == &quot;1&quot;)
           {
               Context.Response.Write(&quot;&lt;script type='text/javascript'&gt;window.frameElement.commitPopup();&lt;/script&gt;&quot;);
               Context.Response.Flush();
               Context.Response.End();
           }
           else
           {
               SPUtility.Redirect(ItemList.DefaultViewUrl, SPRedirectFlags.UseSource, HttpContext.Current);
           }
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 10: Deploy and you can debug it.</span><b style="">
</b></p>
<a href="http://msdn.microsoft.com/en-us/library/ms446376(v=office.12).aspx">http://msdn.microsoft.com/en-us/library/ms446376(v=office.12).aspx</a>
<a href="http://msdn.microsoft.com/en-us/library/ms463449.aspx">http://msdn.microsoft.com/en-us/library/ms463449.aspx</a>
<a href="http://msdn.microsoft.com/en-us/library/ms438856.aspx">http://msdn.microsoft.com/en-us/library/ms438856.aspx</a>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
