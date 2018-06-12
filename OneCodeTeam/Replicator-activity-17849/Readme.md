# Replicator activity (VBSharepointrReplicatorActivity)
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
* 2012-07-22 07:42:30
## Description

<h1><span style="">Use replicator activity in SharePoint workflow </span>(<span style="">VBSharePointReplicatorActivity</span>)</h1>
<h2>Introduction </h2>
<p class="MsoPlainText"><span style="">The project shows how to use Replicator activity in a SharePoint Visual Studio workflow.&#8203; &#8203;</span><span style="">In real world, when we develop an approval workflow, we often need to assign task to multiple
 approvers dynamically, so we need to use replicator activity<b>. </b></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1 Open the CSSharePointReplicatorActivity.sln. Set the &quot;Site URL&quot; property of the project to the URL of your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Right-click the &quot;VBSharePointReplicatorActivity&quot; project and click &quot;Deploy&quot;.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Add the Workflow to a list. Then set the Workflow Association Data which is the approval Partners here.</span><span style="font-size:9.5pt; font-family:Consolas"><br>
<span style=""><img src="/site/view/file/61986/1/image.png" alt="" width="976" height="199" align="middle">
</span></span><br style="">
<br style="">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: After set the approval Partners, we click the save button to save Association Data.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Start a workflow on the list. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/61987/1/image.png" alt="" width="857" height="69" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: Enter task list. <br>
<span style=""><img src="/site/view/file/61988/1/image.png" alt="" width="998" height="290" align="middle">
</span>. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Set the Status to &quot;Completed&quot; then you can observe the status of whole workflow. You will see only if the entire task item is completed the workflow to complete.<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 7: Validation is finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style=""><span style="">Step 1: Create a VB &quot;Empty SharePoint Project&quot; in Visual Studio 2010 and name it as &quot;VBSharePointReplicatorActivity&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Now we will create all tools we need for our </span><span style="">Workflow<span style="">.
<br>
Create a </span>reusable activity <span style="">for Replicator. </span>We have at least two ways to achieve this<span style="">: one way is to add a
</span><span class="SpellE">SequentialWorkflow</span> and modify the class inherited from SequenceActivity then move it to the specified directory which in the sample is the project root directory then delete the generated workflow configuration file. The
 other way is to create a new workflow project and add an activity item then move the workflow to our project.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF"><img src="/site/view/file/61989/1/image.png" alt="" width="207" height="34" align="middle">
</span><span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF"><br>
</span><span style="">In the </span><span style="">reusable activity, we set Token and other Property as usual. Token is the same as task.
<br>
</span><span style="font-size:9.5pt; font-family:Consolas; color:#2B91AF"><img src="/site/view/file/61990/1/image.png" alt="" width="272" height="383" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Then we write the while condition and other </span>Invoking methods in code-behind.<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'Flag for while Condition
    Private isFinished As Boolean


    Private Sub createTask1_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        'Create Task
        TaskId = Guid.NewGuid()


        'Initialize an instance of SPWorkflowTaskProperties and set value
        TaskProperties = New SPWorkflowTaskProperties()
        TaskProperties.Title = TaskTitle
        TaskProperties.Description = TaskDescription
        TaskProperties.AssignedTo = TaskAssignedTo
        TaskProperties.PercentComplete = 0
        TaskProperties.StartDate = DateTime.Today
        TaskProperties.DueDate = TaskDueDate
    End Sub


    ''' &lt;summary&gt;
    ''' handle of OnTaskChanged
    '''  Set the value of the loop condition flag according to the taskStatus
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;  
    Private Sub onTaskChanged1_Invoked(ByVal sender As Object, ByVal e As ExternalDataEventArgs)
        Dim taskStatus As String = AfterProperties.ExtendedProperties(TaskStatusFieldId).ToString()
        If taskStatus.Equals(&quot;Completed&quot;) Then
            isFinished = True
        End If
    End Sub


    'Condition of while
    Private Sub while1Invoke(ByVal sender As Object, ByVal e As ConditionalEventArgs)
        e.Result = Not isFinished
    End Sub


    ' handle of CompleteTask
    Private Sub completeTask1_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        TaskOutcome = &quot;Task Complete&quot;
    End Sub

</pre>
<pre id="codePreview" class="vb">
'Flag for while Condition
    Private isFinished As Boolean


    Private Sub createTask1_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        'Create Task
        TaskId = Guid.NewGuid()


        'Initialize an instance of SPWorkflowTaskProperties and set value
        TaskProperties = New SPWorkflowTaskProperties()
        TaskProperties.Title = TaskTitle
        TaskProperties.Description = TaskDescription
        TaskProperties.AssignedTo = TaskAssignedTo
        TaskProperties.PercentComplete = 0
        TaskProperties.StartDate = DateTime.Today
        TaskProperties.DueDate = TaskDueDate
    End Sub


    ''' &lt;summary&gt;
    ''' handle of OnTaskChanged
    '''  Set the value of the loop condition flag according to the taskStatus
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;  
    Private Sub onTaskChanged1_Invoked(ByVal sender As Object, ByVal e As ExternalDataEventArgs)
        Dim taskStatus As String = AfterProperties.ExtendedProperties(TaskStatusFieldId).ToString()
        If taskStatus.Equals(&quot;Completed&quot;) Then
            isFinished = True
        End If
    End Sub


    'Condition of while
    Private Sub while1Invoke(ByVal sender As Object, ByVal e As ConditionalEventArgs)
        e.Result = Not isFinished
    End Sub


    ' handle of CompleteTask
    Private Sub completeTask1_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        TaskOutcome = &quot;Task Complete&quot;
    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<b style=""><span style="font-size:9.5pt; font-family:Consolas"></span></b></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">We declare some properties for receiving the value from the workflow.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
#Region &quot;TaskProperties&quot;
    Public Property TaskTitle() As String
        Get
            Return m_TaskTitle
        End Get
        Set(ByVal value As String)
            m_TaskTitle = value
        End Set
    End Property
    Private m_TaskTitle As String
    Public Property TaskDescription() As String
        Get
            Return m_TaskDescription
        End Get
        Set(ByVal value As String)
            m_TaskDescription = value
        End Set
    End Property
    Private m_TaskDescription As String
    Public Property TaskAssignedTo() As String
        Get
            Return m_TaskAssignedTo
        End Get
        Set(ByVal value As String)
            m_TaskAssignedTo = value
        End Set
    End Property
    Private m_TaskAssignedTo As String
    Public Property TaskDueDate() As DateTime
        Get
            Return m_TaskDueDate
        End Get
        Set(ByVal value As DateTime)
            m_TaskDueDate = value
        End Set
    End Property
    Private m_TaskDueDate As DateTime
    Public TaskStatusFieldId As New Guid(&quot;c15b34c3-ce7d-490a-b133-3f4de8801b76&quot;)


#End Region

</pre>
<pre id="codePreview" class="vb">
#Region &quot;TaskProperties&quot;
    Public Property TaskTitle() As String
        Get
            Return m_TaskTitle
        End Get
        Set(ByVal value As String)
            m_TaskTitle = value
        End Set
    End Property
    Private m_TaskTitle As String
    Public Property TaskDescription() As String
        Get
            Return m_TaskDescription
        End Get
        Set(ByVal value As String)
            m_TaskDescription = value
        End Set
    End Property
    Private m_TaskDescription As String
    Public Property TaskAssignedTo() As String
        Get
            Return m_TaskAssignedTo
        End Get
        Set(ByVal value As String)
            m_TaskAssignedTo = value
        End Set
    End Property
    Private m_TaskAssignedTo As String
    Public Property TaskDueDate() As DateTime
        Get
            Return m_TaskDueDate
        End Get
        Set(ByVal value As DateTime)
            m_TaskDueDate = value
        End Set
    End Property
    Private m_TaskDueDate As DateTime
    Public TaskStatusFieldId As New Guid(&quot;c15b34c3-ce7d-490a-b133-3f4de8801b76&quot;)


#End Region

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><a name="OLE_LINK12"><b style=""><span style="font-size:9.5pt; line-height:115%; font-family:Consolas">Note:
</span></b>You can get the&nbsp;&quot;</a><span class="SpellE"><span style="">TaskStatusFieldId</span></span><span style="">&quot; from &quot;<span class="SpellE">AfterProperties.ExtendedProperties</span>&quot; in debugging mode, and then you should use
 this GUID in your code.</span><span style=""><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">
</span></span><span style=""><span style="">Then build your project.</span></span><span style=""><span style="font-size:12.0pt; line-height:115%; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">
</span></span></p>
<img src="/site/view/file/61991/1/image.png" alt="" width="285" height="384" align="middle">
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN" style="">Handle &quot;</span>Initialized&quot; and &quot;<span class="SpellE">ChildInitialized</span>&quot; events of
<span class="SpellE">ReplicatorActivity</span>. And set value for<span style="font-size:9.5pt; font-family:Consolas"> &quot;</span><span class="SpellE"><span style="">InitialChildData</span></span><span style="">&quot; property.</span><span style="font-size:9.5pt; font-family:Consolas; color:green">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'handler of OnWorkflowActivated
    Private Sub onWorkflowActivated1_Invoked(ByVal sender As Object, ByVal e As ExternalDataEventArgs)
        workflowId = workflowProperties.WorkflowId
    End Sub


    Private Sub replicatorActivity1_Initialized(ByVal sender As Object, ByVal e As EventArgs)
        'Create a set of InitialChildData for task
        'Anti-serialization workflowProperties.InitiationData to get the initial form instance
        Dim serializer As New XmlSerializer(GetType(AssociationData))
        Dim reader As New XmlTextReader(New System.IO.StringReader(workflowProperties.AssociationData))
        Dim wfData As AssociationData = DirectCast(serializer.Deserialize(reader), AssociationData)


        'Set InitialChild Data
        InitialChildData = New ArrayList()
        For i As Integer = 0 To wfData.Partners.ContactList.Count - 1
            InitialChildData.Add(wfData.Partners.ContactList(i))
        Next


        'Set data for first task       
        reTasksActivity1.TaskAssignedTo = InitialChildData(InitialChildData.Count - 1).ToString()
        reTasksActivity1.TaskTitle = &quot;Vacation Request Approval&quot;
        reTasksActivity1.TaskDescription = &quot;Approve Vacation&quot;
        reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7)
    End Sub


    Private Sub rePlicatorActivity_ChildInitialized(ByVal sender As Object, ByVal e As ReplicatorChildEventArgs)
        'Looping through each assignee   
        reTasksActivity1.TaskAssignedTo = e.InstanceData.ToString()
        reTasksActivity1.TaskTitle = &quot;Vacation Request Approval&quot;
        reTasksActivity1.TaskDescription = &quot;Approve Vacation&quot;
        reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7)
    End Sub

</pre>
<pre id="codePreview" class="vb">
'handler of OnWorkflowActivated
    Private Sub onWorkflowActivated1_Invoked(ByVal sender As Object, ByVal e As ExternalDataEventArgs)
        workflowId = workflowProperties.WorkflowId
    End Sub


    Private Sub replicatorActivity1_Initialized(ByVal sender As Object, ByVal e As EventArgs)
        'Create a set of InitialChildData for task
        'Anti-serialization workflowProperties.InitiationData to get the initial form instance
        Dim serializer As New XmlSerializer(GetType(AssociationData))
        Dim reader As New XmlTextReader(New System.IO.StringReader(workflowProperties.AssociationData))
        Dim wfData As AssociationData = DirectCast(serializer.Deserialize(reader), AssociationData)


        'Set InitialChild Data
        InitialChildData = New ArrayList()
        For i As Integer = 0 To wfData.Partners.ContactList.Count - 1
            InitialChildData.Add(wfData.Partners.ContactList(i))
        Next


        'Set data for first task       
        reTasksActivity1.TaskAssignedTo = InitialChildData(InitialChildData.Count - 1).ToString()
        reTasksActivity1.TaskTitle = &quot;Vacation Request Approval&quot;
        reTasksActivity1.TaskDescription = &quot;Approve Vacation&quot;
        reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7)
    End Sub


    Private Sub rePlicatorActivity_ChildInitialized(ByVal sender As Object, ByVal e As ReplicatorChildEventArgs)
        'Looping through each assignee   
        reTasksActivity1.TaskAssignedTo = e.InstanceData.ToString()
        reTasksActivity1.TaskTitle = &quot;Vacation Request Approval&quot;
        reTasksActivity1.TaskDescription = &quot;Approve Vacation&quot;
        reTasksActivity1.TaskDueDate = DateTime.Today.AddDays(7)
    End Sub

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
