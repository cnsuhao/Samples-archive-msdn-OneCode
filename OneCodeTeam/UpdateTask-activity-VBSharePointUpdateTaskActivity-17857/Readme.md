# UpdateTask activity (VBSharePointUpdateTaskActivity)
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
* 2012-07-22 07:44:40
## Description

<h1><span style="">How to use UpdateTask activity </span>(<span style="">VBSharePointUpdateTaskActivity</span>)</h1>
<h2>Introduction </h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The project illustrates how to Use UpdateTask activity in SharePoint Visual Studio Workflow. In this sample, we assume that the approval requires two
 steps, the first person (the Approver) completes the first step in the approval and then we will re-register the workflow to the second person.
</span></h2>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the VBSharePointUpdateTaskActivity.sln. Set the &quot;Site URL&quot; property of the project to the URL of your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the &quot;VBSharePointUpdateTaskActivity&quot; project and click &quot;Deploy&quot;.<br style="">
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
<span style=""><img src="/site/view/file/62009/1/image.png" alt="" width="878" height="255" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style=""><span style="">Step 1: Create a VB </span>Empty SharePoint Project
<span style="">in Visual Studio 2010 and name it as &quot;VBSharePointUpdateTaskActivity&quot;.
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
                  &lt;Edit&gt;_layouts/MyWorkflow/UpdateTaskWF/TaskEditForm.aspx&lt;/Edit&gt;
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
                  &lt;Edit&gt;_layouts/MyWorkflow/UpdateTaskWF/TaskEditForm.aspx&lt;/Edit&gt;
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
      Name=&quot;UpdateTaskWF&quot;
      Description=&quot;My SharePoint Workflow&quot;
      Id=&quot;d5de27e5-61b3-4ed4-8ea1-1dd23c1c2f50&quot;
      CodeBesideClass=&quot;VBSharePointUpdateTaskActivity.UpdateTaskWF&quot;
      CodeBesideAssembly=&quot;$assemblyname$&quot;
        TaskListContentTypeId=&quot;0x01080100655E7E0BCBA64431B9266D69CB53A7BA&quot;&gt;
       &lt;Categories/&gt;
       &lt;MetaData&gt;
           &lt;AssociationCategories&gt;List&lt;/AssociationCategories&gt;
           &lt;StatusPageUrl&gt;_layouts/WrkStat.aspx&lt;/StatusPageUrl&gt;
       &lt;/MetaData&gt;
   &lt;/Workflow&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Workflow
      Name=&quot;UpdateTaskWF&quot;
      Description=&quot;My SharePoint Workflow&quot;
      Id=&quot;d5de27e5-61b3-4ed4-8ea1-1dd23c1c2f50&quot;
      CodeBesideClass=&quot;VBSharePointUpdateTaskActivity.UpdateTaskWF&quot;
      CodeBesideAssembly=&quot;$assemblyname$&quot;
        TaskListContentTypeId=&quot;0x01080100655E7E0BCBA64431B9266D69CB53A7BA&quot;&gt;
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
<span style="">Set &quot;correlationToken&quot; to &quot;task1&quot; and the sub element of &quot;correlationToken&quot; named &quot;OwnerActivityName&quot; to &quot;UpdateTaskWF&quot;.</span> C<span style="">reate code behind properties for some activity properties,
 such as:</span> <b><span style="">TaskProperties</span></b><span style=""> etc….<br>
</span><span lang="EN" style="">Declare all needed properties. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'workflow Id
    Public workflowId As New Guid
    'Approver 
    Public Approver As [String] = String.Empty
    'TaskStatus
    Private TaskStatus As String = &quot;Pending Approval&quot;
    'Flag for while.
    Private isFinished As Boolean = False


#Region &quot;Properties&quot;
    Public workflowProperties As New SPWorkflowActivationProperties


    ''' &lt;summary&gt;
    ''' SpecialPermissions
    ''' &lt;/summary&gt;
    Public ReadOnly Property SpecialPermissions() As HybridDictionary
        Get
            Dim taskPermissions As New HybridDictionary()
            taskPermissions(TaskProperties.AssignedTo) = SPRoleType.Contributor
            Return taskPermissions
        End Get
    End Property


    Public Shared HistoryDescriptionProperty As DependencyProperty = DependencyProperty.Register(&quot;HistoryDescription&quot;, 


GetType(System.String), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))


    …
    Public Shared HistoryOutcomeProperty As DependencyProperty = DependencyProperty.Register(&quot;HistoryOutcome&quot;, 


GetType(System.String), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))


…
    Public Shared TaskIdProperty As DependencyProperty = DependencyProperty.Register(&quot;TaskId&quot;,


 GetType(System.Guid), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))


…


    Public Shared TaskPropertiesProperty As DependencyProperty = DependencyProperty.Register(&quot;TaskProperties&quot;, 


GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))


…


    Public Shared TaskAfterPropertiesProperty As DependencyProperty = DependencyProperty.Register(&quot;TaskAfterProperties&quot;, 


GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))


…
#End Region

</pre>
<pre id="codePreview" class="vb">
'workflow Id
    Public workflowId As New Guid
    'Approver 
    Public Approver As [String] = String.Empty
    'TaskStatus
    Private TaskStatus As String = &quot;Pending Approval&quot;
    'Flag for while.
    Private isFinished As Boolean = False


#Region &quot;Properties&quot;
    Public workflowProperties As New SPWorkflowActivationProperties


    ''' &lt;summary&gt;
    ''' SpecialPermissions
    ''' &lt;/summary&gt;
    Public ReadOnly Property SpecialPermissions() As HybridDictionary
        Get
            Dim taskPermissions As New HybridDictionary()
            taskPermissions(TaskProperties.AssignedTo) = SPRoleType.Contributor
            Return taskPermissions
        End Get
    End Property


    Public Shared HistoryDescriptionProperty As DependencyProperty = DependencyProperty.Register(&quot;HistoryDescription&quot;, 


GetType(System.String), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))


    …
    Public Shared HistoryOutcomeProperty As DependencyProperty = DependencyProperty.Register(&quot;HistoryOutcome&quot;, 


GetType(System.String), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))


…
    Public Shared TaskIdProperty As DependencyProperty = DependencyProperty.Register(&quot;TaskId&quot;,


 GetType(System.Guid), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))


…


    Public Shared TaskPropertiesProperty As DependencyProperty = DependencyProperty.Register(&quot;TaskProperties&quot;, 


GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))


…


    Public Shared TaskAfterPropertiesProperty As DependencyProperty = DependencyProperty.Register(&quot;TaskAfterProperties&quot;, 


GetType(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), GetType(VBSharePointUpdateTaskActivity.UpdateTaskWF))


…
#End Region

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style=""><br>
Create method for CreateTask Method Invoking. Your method looks like this: </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   ''' CreateTask Created
   ''' &lt;/summary&gt;
   Private Sub createTask1_MethodInvoking(sender As System.Object, e As System.EventArgs)
       Try
           ' generate new GUID used to initialize task correlation token 
           TaskId = Guid.NewGuid()


           ' assign initial properties prior to task creation 
           TaskProperties = New Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties
           TaskProperties.Title = String.Format(&quot;Review:&atilde;€&#144;{0}&atilde;€'&quot;, workflowProperties.Item.DisplayName)
           TaskProperties.PercentComplete = 0
           TaskProperties.StartDate = DateTime.Today
           TaskProperties.DueDate = DateTime.Today.AddDays(3)
           TaskProperties.ExtendedProperties(&quot;TaskStatus&quot;) = TaskStatus
           TaskProperties.AssignedTo = Approver


           createApprovalTask.SpecialPermissions = SpecialPermissions
       Catch ex As Exception
           HistoryDescription = ex.Message
       End Try
   End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   ''' CreateTask Created
   ''' &lt;/summary&gt;
   Private Sub createTask1_MethodInvoking(sender As System.Object, e As System.EventArgs)
       Try
           ' generate new GUID used to initialize task correlation token 
           TaskId = Guid.NewGuid()


           ' assign initial properties prior to task creation 
           TaskProperties = New Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties
           TaskProperties.Title = String.Format(&quot;Review:&atilde;€&#144;{0}&atilde;€'&quot;, workflowProperties.Item.DisplayName)
           TaskProperties.PercentComplete = 0
           TaskProperties.StartDate = DateTime.Today
           TaskProperties.DueDate = DateTime.Today.AddDays(3)
           TaskProperties.ExtendedProperties(&quot;TaskStatus&quot;) = TaskStatus
           TaskProperties.AssignedTo = Approver


           createApprovalTask.SpecialPermissions = SpecialPermissions
       Catch ex As Exception
           HistoryDescription = ex.Message
       End Try
   End Sub

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
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub onTaskChanged_Invoked(sender As System.Object, e As System.Workflow.Activities.ExternalDataEventArgs)
      'If this is the second approval, complete the workflow.
      If Not TaskProperties.AssignedTo.Equals(Approver) Then
          isFinished = (TaskAfterProperties.ExtendedProperties(&quot;TaskStatus&quot;).ToString() = &quot;Completed&quot;)
      End If
  End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub onTaskChanged_Invoked(sender As System.Object, e As System.Workflow.Activities.ExternalDataEventArgs)
      'If this is the second approval, complete the workflow.
      If Not TaskProperties.AssignedTo.Equals(Approver) Then
          isFinished = (TaskAfterProperties.ExtendedProperties(&quot;TaskStatus&quot;).ToString() = &quot;Completed&quot;)
      End If
  End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">In the &quot;updateTask1_MethodInvoking&quot; we modify the property of Task Item.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub updateTask1_MethodInvoking(sender As System.Object, e As System.EventArgs)
       'If this is the first approval, re-register the workflow to the second person.
       If TaskProperties.AssignedTo.Equals(Approver) Then
           Dim itemId As Integer = TaskAfterProperties.TaskItemId
           updateTask1.TaskProperties.TaskItemId = itemId
           updateTask1.TaskProperties.AssignedTo = &quot;Seiya-MSFT\Seiya&quot;
           updateTask1.TaskProperties.Title = String.Format(&quot;[&#144;{0}]&quot;, Me.workflowProperties.Item.DisplayName)
           updateTask1.TaskProperties.DueDate = DateTime.Today.AddDays(5)
       End If
   End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub updateTask1_MethodInvoking(sender As System.Object, e As System.EventArgs)
       'If this is the first approval, re-register the workflow to the second person.
       If TaskProperties.AssignedTo.Equals(Approver) Then
           Dim itemId As Integer = TaskAfterProperties.TaskItemId
           updateTask1.TaskProperties.TaskItemId = itemId
           updateTask1.TaskProperties.AssignedTo = &quot;Seiya-MSFT\Seiya&quot;
           updateTask1.TaskProperties.Title = String.Format(&quot;[&#144;{0}]&quot;, Me.workflowProperties.Item.DisplayName)
           updateTask1.TaskProperties.DueDate = DateTime.Today.AddDays(5)
       End If
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span lang="EN" style="">Step 7: Now we need to specify the condition for the &quot;While&quot; activity. In the workflow designer select this activity. In the &quot;Condition&quot; property select &quot;Code Condition&quot;
 and expand the property. Enter &quot;while1Invoke&quot; in the subproperty with (the same) name &quot;Condition&quot;. In the code editor enter the code for &quot;while1Invoke&quot; like this:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'Condition of while
    Private Sub while1Invoke(sender As Object, e As ConditionalEventArgs)
        e.Result = Not isFinished
    End Sub

</pre>
<pre id="codePreview" class="vb">
'Condition of while
    Private Sub while1Invoke(sender As Object, e As ConditionalEventArgs)
        e.Result = Not isFinished
    End Sub

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
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Overrides Sub OnInit(e As EventArgs)
           AddHandler btnApprove.Click, AddressOf btnApprove_Click
           AddHandler btnReject.Click, AddressOf btnReject_Click
           AddHandler btnCancel.Click, AddressOf btnCancel_Click
       End Sub


       Protected ListId As String
       'List Id
       Protected TaskList As SPList
       'Task List
       Protected TaskItem As SPListItem
       'Task Item
       Protected WorkflowInstanceId As Guid
       'WorkflowInstance Id
       Protected WorkflowInstance As SPWorkflow
       'Workflow Instance
       Protected ItemList As SPList
       'Item List
       Protected Item As SPListItem
       'SPListItem
       Protected Task As SPWorkflowTask
       'SPWorkflowTask
       Protected TaskName As String


       Protected Overrides Sub OnLoad(e As EventArgs)


           ListId = Request.QueryString(&quot;List&quot;)
           TaskList = Web.Lists(New Guid(ListId))
           TaskItem = TaskList.GetItemById(Convert.ToInt32(Request.Params(&quot;ID&quot;)))
           WorkflowInstanceId = New Guid(DirectCast(TaskItem(&quot;WorkflowInstanceID&quot;), String))
           WorkflowInstance = New SPWorkflow(Web, WorkflowInstanceId)
           Task = WorkflowInstance.Tasks(0)
           ItemList = WorkflowInstance.ParentList
           Item = ItemList.GetItemById(WorkflowInstance.ItemId)
           TaskName = TaskItem(&quot;Title&quot;).ToString()


           'Url of the Item
           Dim UrlToItem As String = Web.Site.MakeFullUrl(Convert.ToString(ItemList.RootFolder.Url) & &quot;\DispForm.aspx?ID=&quot; & Item.ID.ToString())
           Dim ItemName As String
           If Item.File IsNot Nothing Then
               ItemName = Item.File.Name
           Else
               ItemName = Item.Title
           End If


           'bind value to control
           lnkItem.Text = ItemName
           lnkItem.NavigateUrl = UrlToItem
           lblListName.Text = ItemList.Title
           lblSiteUrl.Text = Web.Url
       End Sub


       ''' &lt;summary&gt;
       ''' Approve event
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       Protected Sub btnApprove_Click(sender As Object, e As EventArgs)
           SetApprove(&quot;Approved&quot;)
           commitPopup()
       End Sub


       ''' &lt;summary&gt;
       ''' Rejected event
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       Protected Sub btnReject_Click(sender As Object, e As EventArgs)
           SetApprove(&quot;Rejected&quot;)
           commitPopup()
       End Sub


       ''' &lt;summary&gt;
       ''' Cancel
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
           commitPopup()
       End Sub


       ''' &lt;summary&gt;
       ''' Approve operate
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;strFlag&quot;&gt;&lt;/param&gt;
       Private Sub SetApprove(strFlag As String)
           Dim taskHash As New Hashtable()
           taskHash(&quot;TaskStatus&quot;) = &quot;Completed&quot;
           taskHash(&quot;TaskOutcome&quot;) = strFlag
           taskHash(&quot;Outcome&quot;) = strFlag
           taskHash(&quot;ApproverComments&quot;) = txtComments.Text


           'Update specified task with the specified property value
           SPWorkflowTask.AlterTask(TaskItem, taskHash, True)
       End Sub


       ''' &lt;summary&gt;
       ''' Close popup
       ''' &lt;/summary&gt;
       Private Sub commitPopup()
           If Request(&quot;IsDlg&quot;) = &quot;1&quot; Then
               Context.Response.Write(&quot;&lt;script type='text/javascript'&gt;window.frameElement.commitPopup();&lt;/script&gt;&quot;)
               Context.Response.Flush()
               Context.Response.[End]()
           Else
               SPUtility.Redirect(ItemList.DefaultViewUrl, SPRedirectFlags.UseSource, HttpContext.Current)
           End If
       End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Overrides Sub OnInit(e As EventArgs)
           AddHandler btnApprove.Click, AddressOf btnApprove_Click
           AddHandler btnReject.Click, AddressOf btnReject_Click
           AddHandler btnCancel.Click, AddressOf btnCancel_Click
       End Sub


       Protected ListId As String
       'List Id
       Protected TaskList As SPList
       'Task List
       Protected TaskItem As SPListItem
       'Task Item
       Protected WorkflowInstanceId As Guid
       'WorkflowInstance Id
       Protected WorkflowInstance As SPWorkflow
       'Workflow Instance
       Protected ItemList As SPList
       'Item List
       Protected Item As SPListItem
       'SPListItem
       Protected Task As SPWorkflowTask
       'SPWorkflowTask
       Protected TaskName As String


       Protected Overrides Sub OnLoad(e As EventArgs)


           ListId = Request.QueryString(&quot;List&quot;)
           TaskList = Web.Lists(New Guid(ListId))
           TaskItem = TaskList.GetItemById(Convert.ToInt32(Request.Params(&quot;ID&quot;)))
           WorkflowInstanceId = New Guid(DirectCast(TaskItem(&quot;WorkflowInstanceID&quot;), String))
           WorkflowInstance = New SPWorkflow(Web, WorkflowInstanceId)
           Task = WorkflowInstance.Tasks(0)
           ItemList = WorkflowInstance.ParentList
           Item = ItemList.GetItemById(WorkflowInstance.ItemId)
           TaskName = TaskItem(&quot;Title&quot;).ToString()


           'Url of the Item
           Dim UrlToItem As String = Web.Site.MakeFullUrl(Convert.ToString(ItemList.RootFolder.Url) & &quot;\DispForm.aspx?ID=&quot; & Item.ID.ToString())
           Dim ItemName As String
           If Item.File IsNot Nothing Then
               ItemName = Item.File.Name
           Else
               ItemName = Item.Title
           End If


           'bind value to control
           lnkItem.Text = ItemName
           lnkItem.NavigateUrl = UrlToItem
           lblListName.Text = ItemList.Title
           lblSiteUrl.Text = Web.Url
       End Sub


       ''' &lt;summary&gt;
       ''' Approve event
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       Protected Sub btnApprove_Click(sender As Object, e As EventArgs)
           SetApprove(&quot;Approved&quot;)
           commitPopup()
       End Sub


       ''' &lt;summary&gt;
       ''' Rejected event
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       Protected Sub btnReject_Click(sender As Object, e As EventArgs)
           SetApprove(&quot;Rejected&quot;)
           commitPopup()
       End Sub


       ''' &lt;summary&gt;
       ''' Cancel
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
       ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
       Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
           commitPopup()
       End Sub


       ''' &lt;summary&gt;
       ''' Approve operate
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;strFlag&quot;&gt;&lt;/param&gt;
       Private Sub SetApprove(strFlag As String)
           Dim taskHash As New Hashtable()
           taskHash(&quot;TaskStatus&quot;) = &quot;Completed&quot;
           taskHash(&quot;TaskOutcome&quot;) = strFlag
           taskHash(&quot;Outcome&quot;) = strFlag
           taskHash(&quot;ApproverComments&quot;) = txtComments.Text


           'Update specified task with the specified property value
           SPWorkflowTask.AlterTask(TaskItem, taskHash, True)
       End Sub


       ''' &lt;summary&gt;
       ''' Close popup
       ''' &lt;/summary&gt;
       Private Sub commitPopup()
           If Request(&quot;IsDlg&quot;) = &quot;1&quot; Then
               Context.Response.Write(&quot;&lt;script type='text/javascript'&gt;window.frameElement.commitPopup();&lt;/script&gt;&quot;)
               Context.Response.Flush()
               Context.Response.[End]()
           Else
               SPUtility.Redirect(ItemList.DefaultViewUrl, SPRedirectFlags.UseSource, HttpContext.Current)
           End If
       End Sub

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
