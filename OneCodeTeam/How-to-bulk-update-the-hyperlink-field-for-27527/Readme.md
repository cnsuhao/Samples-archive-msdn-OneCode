# How to bulk update the hyperlink field for TFS workitems
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
* 2014-03-03 11:13:31
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to bulk update the hyperlink field for TFS workitems using VB.NET</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Currently</span><span style="font-size:11pt"> there is no direct way to update the hyperlink field in
</span><span style="font-size:11pt">workitems and customer</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> had to update this field for thousand</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> of
</span><span style="font-size:11pt">workitems. To avoid </span><span style="font-size:11pt">manual</span><span style="font-size:11pt"> update</span><span style="font-size:11pt">s</span><span style="font-size:11pt">, we can write an application using TFS</span><span style="font-size:11pt">.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Build the solution and run the console application by passing the collection information along with old information about hyperlink and new information about hyperlink to update.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The following code snippet shows how to bulk update the hyperlink field for TFS workitems programmatically.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Shared Sub Main(args As String())
    ' Get the Uri to the project collection to use
    Dim collectionUri = UpdateHyperLink.Helper.GetCollectionUri(args)
    ' Get the old server information and new server information for replacing
    Dim oldText As String = args(1)
    Dim newText As String = args(2)
    Try
        ' Get the work item store from the TeamFoundationServer
        Console.WriteLine(&quot;Connecting to {0}...&quot;, collectionUri)
        ' Get a reference to the team project collection
        Using projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collectionUri)
            ' Get a reference to the work item tracking service
            Dim workItemStore = projectCollection.GetService(Of WorkItemStore)()
            If workItemStore.Projects.Count &lt;= 0 Then
                Throw New ApplicationException(&quot;There are no projects in this server&quot;)
            End If
            Dim hyperWic As WorkItemCollection = workItemStore.Query(&quot;select [system.id] from workitems where [System.HyperLinkCount] &gt; 0&quot;)
            For Each wi As WorkItem In hyperWic
                'Copy the references to the links to another collection, enumerate over that collection, do your remove and add to the wi.Links collection.
                Dim tempForEmenuration As New List(Of LinkCollection)()
                For Each link As Link In wi.Links
                    If link.BaseType = BaseLinkType.Hyperlink Then
                        tempForEmenuration.Add(wi.Links)
                    End If
                Next
                For Each temp As LinkCollection In tempForEmenuration
                    For Each tempLink As Link In temp
                        Dim hyper As Hyperlink = DirectCast(tempLink, Hyperlink)
                        If hyper.Location.Contains(oldText) Then
                            Dim comment As String = hyper.Comment
                            Dim newLinkAfterChange As String = hyper.Location.Replace(oldText, newText)
                            temp.Remove(tempLink)
                            Dim newHyper As New Hyperlink(newLinkAfterChange)
                            newHyper.Comment = comment
                            wi.Links.Add(newHyper)
                            wi.Save()
                            Exit For
                        End If
                    Next
                Next
            Next
        End Using
    Catch e As Exception
        Console.WriteLine(&quot;Error: {0}&quot;, e.StackTrace)
    End Try
End Sub
</pre>
<pre id="codePreview" class="vb">
Public Shared Sub Main(args As String())
    ' Get the Uri to the project collection to use
    Dim collectionUri = UpdateHyperLink.Helper.GetCollectionUri(args)
    ' Get the old server information and new server information for replacing
    Dim oldText As String = args(1)
    Dim newText As String = args(2)
    Try
        ' Get the work item store from the TeamFoundationServer
        Console.WriteLine(&quot;Connecting to {0}...&quot;, collectionUri)
        ' Get a reference to the team project collection
        Using projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(collectionUri)
            ' Get a reference to the work item tracking service
            Dim workItemStore = projectCollection.GetService(Of WorkItemStore)()
            If workItemStore.Projects.Count &lt;= 0 Then
                Throw New ApplicationException(&quot;There are no projects in this server&quot;)
            End If
            Dim hyperWic As WorkItemCollection = workItemStore.Query(&quot;select [system.id] from workitems where [System.HyperLinkCount] &gt; 0&quot;)
            For Each wi As WorkItem In hyperWic
                'Copy the references to the links to another collection, enumerate over that collection, do your remove and add to the wi.Links collection.
                Dim tempForEmenuration As New List(Of LinkCollection)()
                For Each link As Link In wi.Links
                    If link.BaseType = BaseLinkType.Hyperlink Then
                        tempForEmenuration.Add(wi.Links)
                    End If
                Next
                For Each temp As LinkCollection In tempForEmenuration
                    For Each tempLink As Link In temp
                        Dim hyper As Hyperlink = DirectCast(tempLink, Hyperlink)
                        If hyper.Location.Contains(oldText) Then
                            Dim comment As String = hyper.Comment
                            Dim newLinkAfterChange As String = hyper.Location.Replace(oldText, newText)
                            temp.Remove(tempLink)
                            Dim newHyper As New Hyperlink(newLinkAfterChange)
                            newHyper.Comment = comment
                            wi.Links.Add(newHyper)
                            wi.Save()
                            Exit For
                        End If
                    Next
                Next
            Next
        End Using
    Catch e As Exception
        Console.WriteLine(&quot;Error: {0}&quot;, e.StackTrace)
    End Try
End Sub
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt"></span><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">TeamFoundationServer </span>
<span style="font-size:11pt">Class</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.teamfoundationserver.aspx" style="text-decoration:none"><span style="color:#0563C1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.teamfoundationserver.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">TfsTeamProjectCollectionFactory Class</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.tfsteamprojectcollectionfactory.aspx" style="text-decoration:none"><span style="color:#0563C1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.client.tfsteamprojectcollectionfactory.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">WorkItemStore Class </span>
</span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.workitemtracking.client.workitemstore.aspx" style="text-decoration:none"><span style="color:#0563C1; font-size:11pt; text-decoration:underline">http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.workitemtracking.client.workitemstore.aspx</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
