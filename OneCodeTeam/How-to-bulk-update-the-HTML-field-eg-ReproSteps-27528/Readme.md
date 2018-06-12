# How to bulk update the HTML field (e.g. ReproSteps) for TFS workitems
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* .NET Development
* Development Tools
* Team Foundation Server (TFS)
* Team Foundation Server 2012
* Team Foundation Server Extensibility
## Topics
* TFS2012
## IsPublished
* True
## ModifiedDate
* 2014-03-03 11:15:46
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to bulk update the HTML field (e.g.
</span><span style="font-weight:bold; font-size:14pt">ReproSteps</span><span style="font-weight:bold; font-size:14pt">) for TFS
</span><span style="font-weight:bold; font-size:14pt">workitems</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">How to do the bulk edit of the HTML fields in bug work item (e.g.
</span><span style="font-size:11pt">ReproSteps</span><span style="font-size:11pt">) in TFS which cannot be done via excel as the HTML fields are considered as read-only in excel.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This sample will help you to update the HTML Field in
</span><span style="font-size:11pt">workitem</span><span style="font-size:11pt"> which otherwise is not possible to do.</span><span style="font-weight:bold; font-style:italic; font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">This sample assume</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> that you have two HTML fields (</span><span style="font-size:11pt">e.g</span><span style="font-size:11pt">
 Microsft.VSTS.</span><span style="font-size:11pt">CMMI.StepsToReproduce</span><span style="font-size:11pt"> and Microsft.VSTS.</span><span style="font-size:11pt">TCM.ReproSteps</span><span style="font-size:11pt">) in your Bug
</span><span style="font-size:11pt">workitem</span><span style="font-size:11pt">.</span><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">With this sample you want to copy the value of Microsft.VSTS.</span><span style="font-size:11pt">CMMI.StepsToReproduce</span><span style="font-size:11pt"> to Microsft.VSTS.</span><span style="font-size:11pt">TCM.ReproSteps</span><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1. Import the bug IDs in an excel.</span><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. Modify the team project and path of excel in the code.</span><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; text-align:left; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">3. Run the application and provide your TFS server information.</span><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The following code snippet</span><span style="font-size:11pt"> shows how to bulk update the HTML field for TFS
</span><span style="font-size:11pt">workitems.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)
{
    // Get the Uri to the project collection to use
    var collectionUri = Helper.GetCollectionUri(args);
    string tfsProjectName = &quot;TestProj&quot;;
    string tfsWorkItemType = &quot;Bug&quot;;
    try
    {
        // Get the work item store from the TeamFoundationServer
        Console.WriteLine(&quot;Connecting to {0}...&quot;, collectionUri);
        // Get a reference to the team project collection
        using (var projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collectionUri))
        {
            // NOTE: You have to replace the file path with yours.
            string excelpath = @&quot;C:\UpdateBug\BugWI.xlsx&quot;;
            OleDbConnection Con = new OleDbConnection(&quot;Provider=Microsoft.ACE.OLEDB.12.0;Data Source=&quot; &#43; excelpath &#43; &quot;;Extended Properties=Excel 8.0&quot;);
            Con.Open();
            try
            {
                DataSet myDataSet = new DataSet();
                OleDbDataAdapter myCommand = new OleDbDataAdapter(&quot; SELECT * FROM [Sheet1$]&quot;, Con);
                myCommand.Fill(myDataSet);
                for (int i = 2; i &lt;= myDataSet.Tables[0].Rows.Count; i&#43;&#43;)
                {
                    WorkItemStore wit = (WorkItemStore)projectCollection.GetService(typeof(WorkItemStore));
                    WorkItemCollection result = wit.Query(String.Format(&quot;SELECT [System.Id] FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.WorkItemType] = '{1}'&quot;, tfsProjectName, tfsWorkItemType));
                    List&lt;WorkItem&gt; affectedWorkItems = new List&lt;WorkItem&gt;();
                    int witid = int.Parse(myDataSet.Tables[0].Rows[i][0].ToString());
                    WorkItem bug = wit.GetWorkItem(12);
                    Field newReproSteps = bug.Fields[&quot;Microsoft.VSTS.CMMI.StepsToReproduce&quot;];
                    Field reproSteps = bug.Fields[&quot;Microsoft.VSTS.TCM.ReproSteps&quot;];
                    reproSteps.Value = newReproSteps.Value;
                    bug.Save();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(&quot;Error: {0}&quot;, e.Message);
            }
            finally
            {
                Con.Close();
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(&quot;Error: {0}&quot;, e.Message);
    }
}
</pre>
<pre id="codePreview" class="csharp">static void Main(string[] args)
{
    // Get the Uri to the project collection to use
    var collectionUri = Helper.GetCollectionUri(args);
    string tfsProjectName = &quot;TestProj&quot;;
    string tfsWorkItemType = &quot;Bug&quot;;
    try
    {
        // Get the work item store from the TeamFoundationServer
        Console.WriteLine(&quot;Connecting to {0}...&quot;, collectionUri);
        // Get a reference to the team project collection
        using (var projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collectionUri))
        {
            // NOTE: You have to replace the file path with yours.
            string excelpath = @&quot;C:\UpdateBug\BugWI.xlsx&quot;;
            OleDbConnection Con = new OleDbConnection(&quot;Provider=Microsoft.ACE.OLEDB.12.0;Data Source=&quot; &#43; excelpath &#43; &quot;;Extended Properties=Excel 8.0&quot;);
            Con.Open();
            try
            {
                DataSet myDataSet = new DataSet();
                OleDbDataAdapter myCommand = new OleDbDataAdapter(&quot; SELECT * FROM [Sheet1$]&quot;, Con);
                myCommand.Fill(myDataSet);
                for (int i = 2; i &lt;= myDataSet.Tables[0].Rows.Count; i&#43;&#43;)
                {
                    WorkItemStore wit = (WorkItemStore)projectCollection.GetService(typeof(WorkItemStore));
                    WorkItemCollection result = wit.Query(String.Format(&quot;SELECT [System.Id] FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.WorkItemType] = '{1}'&quot;, tfsProjectName, tfsWorkItemType));
                    List&lt;WorkItem&gt; affectedWorkItems = new List&lt;WorkItem&gt;();
                    int witid = int.Parse(myDataSet.Tables[0].Rows[i][0].ToString());
                    WorkItem bug = wit.GetWorkItem(12);
                    Field newReproSteps = bug.Fields[&quot;Microsoft.VSTS.CMMI.StepsToReproduce&quot;];
                    Field reproSteps = bug.Fields[&quot;Microsoft.VSTS.TCM.ReproSteps&quot;];
                    reproSteps.Value = newReproSteps.Value;
                    bug.Save();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(&quot;Error: {0}&quot;, e.Message);
            }
            finally
            {
                Con.Close();
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(&quot;Error: {0}&quot;, e.Message);
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">TeamFoundationServer Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.teamfoundationserver.aspx" style="text-decoration:none"><span style="color:#0563c1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.teamfoundationserver.aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">TfsTeamProjectCollectionFactory Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.tfsteamprojectcollectionfactory.aspx" style="text-decoration:none"><span style="color:#0563c1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.tfsteamprojectcollectionfactory.aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">WorkItemStore Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.workitemtracking.client.workitemstore.aspx" style="text-decoration:none"><span style="color:#0563c1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.workitemtracking.client.workitemstore.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">OleDbConnection Class</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/system.data.oledb.oledbconnection(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563c1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/system.data.oledb.oledbconnection(v=vs.110).aspx</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
