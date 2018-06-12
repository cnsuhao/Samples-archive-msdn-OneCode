# Get link info of a TFS work item (VBTFSWorkItemLinkInfoDetails)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* TFS
## Topics
* WorkItemLinkInfo
## IsPublished
* True
## ModifiedDate
* 2011-07-12 10:36:31
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: VBTFSWorkItemLinkInfoDetails</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to get the link details of a WorkItemLinkInfo object.<br>
The detailed information is like :<br>
<br>
Source:[Source title] ==&gt; LinkType:[Link Type] ==&gt; Target:[Target title]<br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
Team Explorer 2010.<br>
<br>
You can download it in the following link:<br>
<a target="_blank" href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=fe4f9904-0480-4c9d-a264-02fedd78ab38">http://www.microsoft.com/downloads/en/details.aspx?FamilyID=fe4f9904-0480-4c9d-a264-02fedd78ab38</a><br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open this project in &nbsp;Visual Studio 2010. <br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
Step2. Build the solution. <br>
<br>
Step3. Run the application VBTFSWorkItemLinkInfoDetails.exe in command line in <br>
&nbsp; &nbsp; &nbsp; following format:<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;VBTFSWorkItemLinkInfoDetails.exe &lt;CollectionUrl&gt; &lt;WorkItemID&gt;<br>
<br>
&nbsp; &nbsp; &nbsp; If your default credential fails to connect to the TFSTeamProjectCollection, a
<br>
&nbsp; &nbsp; &nbsp; dialog will be launched to let you type the UserName/Password.<br>
<br>
<br>
Step4. You will see following message if the specified work item has related work item<br>
&nbsp; &nbsp; &nbsp; links.<br>
<br>
&nbsp; &nbsp; &nbsp; Source:[Source title] ==&gt; LinkType:[Link Type] ==&gt; Target:[Target title]<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
<br>
A. Connect to a TFS Team Project Collection and the WorkItemStore service.<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;' If the credential failed, an UICredentialsProvider instance will be launched.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.ProjectCollection = New TfsTeamProjectCollection(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;collectionUri, credential, New UICredentialsProvider())<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.ProjectCollection.EnsureAuthenticated()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Get the WorkItemStore service.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Me.WorkItemStore = Me.ProjectCollection.GetService(Of WorkItemStore)()<br>
&nbsp; &nbsp; &nbsp; <br>
<br>
B. Construct the WIQL.<br>
<br>
&nbsp; &nbsp; &nbsp; Private Const _queryFormat As String =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot;select * from WorkItemLinks where [Source].[System.ID] = {0}&quot;<br>
&nbsp; &nbsp; &nbsp; Dim queryStr As String = String.Format(_queryFormat, workitemID)<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; Dim linkQuery As New Query(Me.WorkItemStore, queryStr)<br>
<br>
&nbsp; &nbsp; &nbsp; ' Get all WorkItemLinkInfo objects.<br>
&nbsp; &nbsp; &nbsp; Dim linkinfos() As WorkItemLinkInfo = linkQuery.RunLinkQuery()<br>
<br>
C. Get the detailed information.<br>
<br>
&nbsp; &nbsp; &nbsp; Private _linkTypes As Dictionary(Of Integer, WorkItemLinkType)<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; ' The dictionary to store the ID and WorkItemLinkType KeyValuePair.<br>
&nbsp; &nbsp; &nbsp; Public ReadOnly Property LinkTypes() As Dictionary(Of Integer, WorkItemLinkType)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Get<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ' Get all WorkItemLinkType from WorkItemStore.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If _linkTypes Is Nothing Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; _linkTypes = New Dictionary(Of Integer, WorkItemLinkType)()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; For Each type In Me.WorkItemStore.WorkItemLinkTypes<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; _linkTypes.Add(type.ForwardEnd.Id, type)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Next type<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Return _linkTypes<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End Get<br>
&nbsp; &nbsp; &nbsp; End Property<br>
<br>
&nbsp; &nbsp; &nbsp; ''' &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; ''' Get WorkItemLinkInfoDetails from the &nbsp;WorkItemLinkInfo object.<br>
&nbsp; &nbsp; &nbsp; ''' &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; Public Function GetDetailsFromWorkItemLinkInfo(ByVal linkInfo As WorkItemLinkInfo) _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; As WorkItemLinkInfoDetails<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; If Me.LinkTypes.ContainsKey(linkInfo.LinkTypeId) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Dim details As New WorkItemLinkInfoDetails(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; linkInfo,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.WorkItemStore.GetWorkItem(linkInfo.SourceId),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.WorkItemStore.GetWorkItem(linkInfo.TargetId),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Me.LinkTypes(linkInfo.LinkTypeId))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Return details<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Throw New ApplicationException(&quot;Cannot find WorkItemLinkType!&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; End If<br>
&nbsp; &nbsp; &nbsp; End Function<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; </p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
TfsTeamProjectCollection Constructor (Uri, ICredentials, ICredentialsProvider)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ff733681.aspx">http://msdn.microsoft.com/en-us/library/ff733681.aspx</a><br>
<br>
WIQL syntax for Link Query<br>
<a target="_blank" href="http://blogs.msdn.com/b/team_foundation/archive/2010/07/02/wiql-syntax-for-link-query.aspx">http://blogs.msdn.com/b/team_foundation/archive/2010/07/02/wiql-syntax-for-link-query.aspx</a><br>
<br>
Work Item Tracking Queries Object Model in 2010<br>
<a target="_blank" href="http://blogs.msdn.com/b/team_foundation/archive/2010/06/16/work-item-tracking-queries-object-model-in-2010.aspx">http://blogs.msdn.com/b/team_foundation/archive/2010/06/16/work-item-tracking-queries-object-model-in-2010.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
